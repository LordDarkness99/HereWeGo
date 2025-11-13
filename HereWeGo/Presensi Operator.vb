Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports System.Windows.Forms

Public Class Presensi_Operator
    Private parentForm As GuruAsOperator
    Private presensiRepo As New PresensiRepository()
    Private kelasRepo As New KelasRepository()
    Private mapelRepo As New MataPelajaranRepository()

    Public Sub New(parent As GuruAsOperator)
        InitializeComponent()
        parentForm = parent
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

        Dim sukses As Integer = 0
        Dim gagal As Integer = 0

        For Each row As DataGridViewRow In DataGridView1.Rows
            Try
                Dim idPresensi As String = If(row.Cells("id_presensi").Value, "").ToString()
                Dim status As String = If(row.Cells("status").Value, "").ToString()

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
End Class
