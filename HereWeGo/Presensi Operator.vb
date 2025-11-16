Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json

Public Class Presensi_Operator
    Private parentForm As GuruAsOperator
    Private presensiRepo As New PresensiRepository()
    Private kelasRepo As New KelasRepository()
    Private mapelRepo As New MataPelajaranRepository()
    ' 🔹 Variabel untuk cetak
    Private WithEvents printDocument As New PrintDocument()
    Private WithEvents printPreview As New PrintPreviewDialog()
    Private currentRow As Integer = 0
    Private pageNumber As Integer = 1


    Public Sub New(parent As GuruAsOperator)
        InitializeComponent()
        parentForm = parent
        AddHandler printDocument.PrintPage, AddressOf printDocument_PrintPage
        AddHandler Button3.Click, AddressOf Button3_Click ' kalau Handles bermasalah
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Async Sub Presensi_Operator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadKelasAsync()
        Await LoadMapelAsync()
        SetupDataGridView()
    End Sub

    ' 🔹 Inisialisasi kolom DataGridView
    Private Sub SetupDataGridView()
        DataGridView1.Columns.Clear()
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("id_presensi", "ID Presensi")
        DataGridView1.Columns("id_presensi").Visible = False ' disembunyikan
        DataGridView1.Columns.Add("nis", "NIS")
        DataGridView1.Columns.Add("nama_siswa", "Nama Siswa")
        DataGridView1.Columns.Add("status", "Status Kehadiran")
    End Sub


    ' 🔹 Ambil data kelas
    Private Async Function LoadKelasAsync() As Task
        ComboBox1.Items.Clear()
        Dim list = Await kelasRepo.GetAllAsync()
        For Each k In list
            ComboBox1.Items.Add(New KeyValuePair(Of String, String)(k.id_kelas, k.nama_kelas))
        Next
        ComboBox1.DisplayMember = "Value"
        ComboBox1.ValueMember = "Key"
    End Function


    ' 🔹 Ambil data mapel
    Private Async Function LoadMapelAsync() As Task
        ComboBox2.Items.Clear()
        Dim list = Await mapelRepo.GetAllAsync()
        For Each m In list
            ComboBox2.Items.Add(New KeyValuePair(Of String, String)(m.id_mapel, m.nama_mapel))
        Next
        ComboBox2.DisplayMember = "Value"
        ComboBox2.ValueMember = "Key"
    End Function


    ' 🔹 Tampilkan siswa berdasarkan filter
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem Is Nothing OrElse ComboBox2.SelectedItem Is Nothing Then
            MessageBox.Show("Pilih kelas dan mapel terlebih dahulu.")
            Return
        End If

        Dim selectedKelas = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String))
        Dim selectedMapel = DirectCast(ComboBox2.SelectedItem, KeyValuePair(Of String, String))

        Await LoadPresensiAsync(selectedKelas.Key, selectedMapel.Key)
    End Sub


    ' 🔹 Ambil data presensi siswa
    Private Async Function LoadPresensiAsync(idKelas As String, idMapel As String) As Task
        Try
            DataGridView1.Rows.Clear()
            DataGridView1.Controls.Clear() ' bersihkan panel radio lama

            Dim list = Await presensiRepo.GetByFilterAsync(idKelas, idMapel)

            For Each p In list
                Dim index As Integer = DataGridView1.Rows.Add(p.id_presensi, p.nis, p.nama_siswa, p.status)
            Next

            ' Tunggu DataGridView selesai render
            Await Task.Delay(150)

            ' Tambahkan radio button di setiap baris
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim statusValue As String = If(DataGridView1.Rows(i).Cells("status").Value, "")
                AddRadioButtonsToRow(i, statusValue)
            Next

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data presensi: " & ex.Message)
        End Try
    End Function


    ' 🔹 Tambahkan radio button ke setiap baris
    Private Sub AddRadioButtonsToRow(rowIndex As Integer, statusValue As String)
        If rowIndex < 0 OrElse rowIndex >= DataGridView1.Rows.Count Then Exit Sub
        Dim colIndex As Integer = DataGridView1.Columns("status").Index
        Dim cellRect As Rectangle = DataGridView1.GetCellDisplayRectangle(colIndex, rowIndex, True)

        If cellRect.Width <= 0 OrElse cellRect.Height <= 0 Then Exit Sub

        Dim panel As New Panel() With {.Size = New Size(cellRect.Width - 10, cellRect.Height), .Tag = rowIndex}

        Dim rbHadir As New RadioButton() With {.Text = "Hadir", .AutoSize = True, .Tag = "Hadir"}
        Dim rbIzin As New RadioButton() With {.Text = "Izin", .AutoSize = True, .Tag = "Izin", .Left = 70}
        Dim rbSakit As New RadioButton() With {.Text = "Sakit", .AutoSize = True, .Tag = "Sakit", .Left = 130}
        Dim rbAlpa As New RadioButton() With {.Text = "Alfa", .AutoSize = True, .Tag = "Alfa", .Left = 200}

        AddHandler rbHadir.CheckedChanged, AddressOf RadioChanged
        AddHandler rbIzin.CheckedChanged, AddressOf RadioChanged
        AddHandler rbSakit.CheckedChanged, AddressOf RadioChanged
        AddHandler rbAlpa.CheckedChanged, AddressOf RadioChanged

        panel.Controls.AddRange(New Control() {rbHadir, rbIzin, rbSakit, rbAlpa})

        ' Centang radio button berdasarkan status yang ada
        Select Case statusValue.ToLower()
            Case "hadir" : rbHadir.Checked = True
            Case "izin" : rbIzin.Checked = True
            Case "sakit" : rbSakit.Checked = True
            Case "alfa" : rbAlpa.Checked = True
        End Select

        DataGridView1.Controls.Add(panel)
        panel.Location = New Point(cellRect.X + 5, cellRect.Y + 2)
    End Sub


    ' 🔹 Simpan pilihan radio ke DataGridView
    Private Sub RadioChanged(sender As Object, e As EventArgs)
        Dim rb As RadioButton = CType(sender, RadioButton)
        If rb.Checked Then
            Dim panel As Panel = CType(rb.Parent, Panel)
            Dim rowIndex As Integer = CInt(panel.Tag)
            DataGridView1.Rows(rowIndex).Cells("status").Value = rb.Tag.ToString()
        End If
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data presensi untuk disimpan.")
            Return
        End If

        Dim sukses = 0
        Dim gagal = 0

        For Each row As DataGridViewRow In DataGridView1.Rows
            Try
                Dim idPresensi = If(row.Cells("id_presensi").Value, "").ToString
                Dim status = If(row.Cells("status").Value, "").ToString

                If String.IsNullOrWhiteSpace(idPresensi) OrElse String.IsNullOrWhiteSpace(status) Then
                    Continue For
                End If

                Dim result = Await presensiRepo.UpdateStatusAsync(idPresensi, status)
                If result Then
                    sukses += 1
                Else
                    gagal += 1
                End If

            Catch ex As Exception
                gagal += 1
            End Try
        Next

        MessageBox.Show($"✅ {sukses} data berhasil disimpan, ❌ {gagal} gagal.", "Simpan Presensi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'cdtak
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk dicetak.", "Cetak Presensi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        printPreview.Document = printDocument
        printPreview.Width = 1000
        printPreview.Height = 700
        printPreview.ShowDialog()
    End Sub
    Private Sub printDocument_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDocument.PrintPage
        ' ==== Font dan Layout ====
        Dim fontJudul As New Font("Segoe UI", 14, FontStyle.Bold)
        Dim fontSubJudul As New Font("Segoe UI", 10, FontStyle.Regular)
        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontIsi As New Font("Segoe UI", 10, FontStyle.Regular)
        Dim brush As New SolidBrush(Color.Black)

        Dim marginLeft As Integer = e.MarginBounds.Left
        Dim marginTop As Integer = e.MarginBounds.Top
        Dim y As Integer = marginTop

        ' ==== Header Sekolah ====
        e.Graphics.DrawString("SMA NEGERI 1 CONTOH KOTA", New Font("Segoe UI", 14, FontStyle.Bold), brush, marginLeft + 150, y)
        y += 25
        e.Graphics.DrawString("Jl. Pendidikan No. 123, Contoh Kota", fontSubJudul, brush, marginLeft + 180, y)
        y += 25
        e.Graphics.DrawLine(Pens.Black, marginLeft, y, e.MarginBounds.Right, y)
        y += 20

        ' ==== Judul Laporan ====
        e.Graphics.DrawString("LAPORAN PRESENSI SISWA", fontJudul, brush, marginLeft + 200, y)
        y += 40

        ' ==== Info Tambahan ====
        Dim kelas As String = If(ComboBox1.Text, "-")
        Dim mapel As String = If(ComboBox2.Text, "-")
        e.Graphics.DrawString($"Kelas               : {kelas}", fontSubJudul, brush, marginLeft, y)
        y += 20
        e.Graphics.DrawString($"Mata Pelajaran      : {mapel}", fontSubJudul, brush, marginLeft, y)
        y += 30

        ' ==== Header Tabel ====
        Dim colNisWidth = 120
        Dim colNamaWidth = 250
        Dim colStatusWidth = 120

        e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), marginLeft, y, colNisWidth + colNamaWidth + colStatusWidth, 25)
        e.Graphics.DrawRectangle(Pens.Black, marginLeft, y, colNisWidth, 25)
        e.Graphics.DrawRectangle(Pens.Black, marginLeft + colNisWidth, y, colNamaWidth, 25)
        e.Graphics.DrawRectangle(Pens.Black, marginLeft + colNisWidth + colNamaWidth, y, colStatusWidth, 25)

        e.Graphics.DrawString("NIS", fontHeader, brush, marginLeft + 5, y + 5)
        e.Graphics.DrawString("Nama Siswa", fontHeader, brush, marginLeft + colNisWidth + 5, y + 5)
        e.Graphics.DrawString("Status", fontHeader, brush, marginLeft + colNisWidth + colNamaWidth + 5, y + 5)
        y += 25

        ' ==== Isi Tabel ====
        Dim rowHeight = 25
        While currentRow < DataGridView1.Rows.Count
            Dim row = DataGridView1.Rows(currentRow)
            If row.IsNewRow Then
                currentRow += 1
                Continue While
            End If

            Dim nis = If(row.Cells("nis").Value, "").ToString()
            Dim nama = If(row.Cells("nama_siswa").Value, "").ToString()
            Dim status = If(row.Cells("status").Value, "").ToString()

            e.Graphics.DrawRectangle(Pens.Black, marginLeft, y, colNisWidth, rowHeight)
            e.Graphics.DrawRectangle(Pens.Black, marginLeft + colNisWidth, y, colNamaWidth, rowHeight)
            e.Graphics.DrawRectangle(Pens.Black, marginLeft + colNisWidth + colNamaWidth, y, colStatusWidth, rowHeight)

            e.Graphics.DrawString(nis, fontIsi, brush, marginLeft + 5, y + 5)
            e.Graphics.DrawString(nama, fontIsi, brush, marginLeft + colNisWidth + 5, y + 5)
            e.Graphics.DrawString(status, fontIsi, brush, marginLeft + colNisWidth + colNamaWidth + 5, y + 5)

            y += rowHeight
            currentRow += 1

            ' Halaman baru jika tabel melewati batas bawah
            If y + rowHeight > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                pageNumber += 1
                Return
            End If
        End While

        ' ==== Footer ====
        y += 40
        e.Graphics.DrawString("Dicetak pada: " & DateTime.Now.ToString("dd MMMM yyyy HH:mm"), fontSubJudul, brush, marginLeft, y)
        y += 40
        e.Graphics.DrawString("Guru / Wali Kelas,", fontSubJudul, brush, marginLeft + 400, y)
        y += 60
        e.Graphics.DrawString("(_______________________)", fontSubJudul, brush, marginLeft + 400, y)

        ' Reset variabel untuk halaman berikutnya
        currentRow = 0
        pageNumber = 1
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
