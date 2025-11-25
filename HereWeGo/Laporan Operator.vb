Imports System.Drawing.Printing

Public Class Laporan_Operator

    Private kelasRepo As New KelasRepository()
    Private mapelRepo As New MataPelajaranRepository()
    Private rekapRepo As New PresensiRekapRepository()

    Private currentPrintRow As Integer = 0

    Private Async Sub Laporan_Operator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadKelas()
        Await LoadMapel()
        SetupGrid()
    End Sub

    Private parentForm As GuruAsOperator
    Public Sub New(parent As GuruAsOperator)
        InitializeComponent()
        Me.parentForm = parent
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub
    ' ======================================
    ' LOAD KELAS
    ' ======================================
    Private Async Function LoadKelas() As Task
        ComboBox1.Items.Clear()

        Dim list = Await kelasRepo.GetAllAsync()
        For Each item In list
            ComboBox1.Items.Add(New KeyValuePair(Of String, String)(item.id_kelas, item.nama_kelas))
        Next

        ComboBox1.DisplayMember = "Value"
        ComboBox1.ValueMember = "Key"
    End Function

    ' ======================================
    ' LOAD MAPEL
    ' ======================================
    Private Async Function LoadMapel() As Task
        ComboBox2.Items.Clear()

        Dim list = Await mapelRepo.GetAllAsync()
        For Each item In list
            ComboBox2.Items.Add(New KeyValuePair(Of String, String)(item.id_mapel, item.nama_mapel))
        Next

        ComboBox2.DisplayMember = "Value"
        ComboBox2.ValueMember = "Key"
    End Function

    ' ======================================
    ' SETUP GRID
    ' ======================================
    Private Sub SetupGrid()
        DataGridView1.Columns.Clear()

        DataGridView1.Columns.Add("nis", "NIS")
        DataGridView1.Columns.Add("nama", "Nama Siswa")
        DataGridView1.Columns.Add("hadir", "Hadir")
        DataGridView1.Columns.Add("izin", "Izin")
        DataGridView1.Columns.Add("sakit", "Sakit")
        DataGridView1.Columns.Add("alfa", "Tidak Hadir")

        DataGridView1.AllowUserToAddRows = False
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' ======================================
    ' TOMBOL TAMPILKAN
    ' ======================================
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.SelectedItem Is Nothing Or ComboBox2.SelectedItem Is Nothing Then
            MessageBox.Show("Pilih kelas dan mapel terlebih dahulu!")
            Exit Sub
        End If

        Dim kelas = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String))
        Dim mapel = DirectCast(ComboBox2.SelectedItem, KeyValuePair(Of String, String))

        Dim tglAwal = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim tglAkhir = DateTimePicker2.Value.ToString("yyyy-MM-dd")

        Dim raw = Await rekapRepo.GetRekapAsync(kelas.Key, mapel.Key, tglAwal, tglAkhir)

        If raw.Count = 0 Then
            MessageBox.Show("Tidak ada data presensi dengan filter tersebut.")
            Exit Sub
        End If

        SetupGrid()
        DataGridView1.Rows.Clear()

        ' ==== GROUP REKAP ====
        Dim grouped = raw.
            GroupBy(Function(x) x.nis).
            Select(Function(g) New With {
                .nis = g.Key,
                .nama = g.First().nama_siswa,
                .hadir = g.Count(Function(x) x.status = "Hadir"),
                .izin = g.Count(Function(x) x.status = "Izin"),
                .sakit = g.Count(Function(x) x.status = "Sakit"),
                .alfa = g.Count(Function(x) x.status = "Alfa")
            }).ToList()

        ' ==== MASUKKAN DATA ====
        For Each r In grouped
            DataGridView1.Rows.Add(r.nis, r.nama, r.hadir, r.izin, r.sakit, r.alfa)
        Next

    End Sub

    ' ======================================
    ' TOMBOL CETAK
    ' ======================================
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pd As New PrintDocument()
        AddHandler pd.PrintPage, AddressOf PrintHandler

        Dim preview As New PrintPreviewDialog()
        preview.Document = pd
        preview.ShowDialog()
    End Sub

    ' ======================================
    ' PRINT LOGIC
    ' ======================================
    Private Sub PrintHandler(sender As Object, e As PrintPageEventArgs)

        Dim fontJudul As New Font("Segoe UI", 14, FontStyle.Bold)
        Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontIsi As New Font("Segoe UI", 10)
        Dim fontSmall As New Font("Segoe UI", 9)

        Dim marginLeft = e.MarginBounds.Left
        Dim marginTop = e.MarginBounds.Top
        Dim pageWidth = e.MarginBounds.Width

        Dim y As Integer = marginTop

        ' ===========================================
        ' 1. HEADER SEKOLAH (CENTER)
        ' ===========================================
        Dim title1 = "SMK NEGERI 1 MOJOKERTO"
        Dim title2 = "Jl. Raya Kedung Sari, Magersari, Kota Mojokerto, Jawa Timur"
        Dim title3 = "Website : http://smkn1mojokerto.sch.id | Telp : (0321) 381959"

        e.Graphics.DrawString(title1, fontJudul, Brushes.Black,
                          marginLeft + (pageWidth - e.Graphics.MeasureString(title1, fontJudul).Width) \ 2, y)
        y += 28

        e.Graphics.DrawString(title2, fontSmall, Brushes.Black,
                          marginLeft + (pageWidth - e.Graphics.MeasureString(title2, fontSmall).Width) \ 2, y)
        y += 20

        e.Graphics.DrawString(title3, fontSmall, Brushes.Black,
                          marginLeft + (pageWidth - e.Graphics.MeasureString(title3, fontSmall).Width) \ 2, y)
        y += 25

        ' Garis pemisah
        e.Graphics.DrawLine(Pens.Black, marginLeft, y, marginLeft + pageWidth, y)
        y += 25

        ' ===========================================
        ' 2. JUDUL LAPORAN (CENTER)
        ' ===========================================
        Dim judul = "LAPORAN REKAPITULASI PRESENSI SISWA"
        e.Graphics.DrawString(judul, fontJudul, Brushes.Black,
                          marginLeft + (pageWidth - e.Graphics.MeasureString(judul, fontJudul).Width) \ 2, y)
        y += 40

        ' ===========================================
        ' 3. INFORMASI MAPEL & KELAS
        ' ===========================================
        e.Graphics.DrawString("Mata Pelajaran :", fontHeader, Brushes.Black, marginLeft, y)
        e.Graphics.DrawString(ComboBox2.Text, fontIsi, Brushes.Black, marginLeft + 140, y)
        y += 22

        e.Graphics.DrawString("Kelas :", fontHeader, Brushes.Black, marginLeft, y)
        e.Graphics.DrawString(ComboBox1.Text, fontIsi, Brushes.Black, marginLeft + 140, y)
        y += 32

        Dim tglAwal As String = DateTimePicker1.Value.ToString("dd/MM/yyyy")
        Dim tglAkhir As String = DateTimePicker2.Value.ToString("dd/MM/yyyy")

        e.Graphics.DrawString("Periode Presensi :", fontHeader, Brushes.Black, marginLeft, y)
        e.Graphics.DrawString(tglAwal & "  s/d  " & tglAkhir, fontIsi, Brushes.Black, marginLeft + 140, y)
        y += 35

        ' ===========================================
        ' 4. LAYOUT TABEL (center)
        ' ===========================================
        Dim colWidths = {40, 100, 250, 90, 60, 60, 60, 60, 85}  ' Total 805px
        Dim totalTableWidth = colWidths.Sum()

        Dim startX As Integer = marginLeft + (pageWidth - totalTableWidth) \ 2

        ' ===========================================
        ' 5. HEADER TABEL
        ' ===========================================
        Dim headers = {"No", "NIS", "Nama", "Pertemuan", "Alfa", "Hadir", "Izin", "Sakit", "Persentase"}

        Dim x = startX

        ' Background Header
        e.Graphics.FillRectangle(Brushes.LightGray, startX, y, totalTableWidth, 30)

        For i = 0 To headers.Length - 1
            e.Graphics.DrawRectangle(Pens.Black, x, y, colWidths(i), 30)
            e.Graphics.DrawString(headers(i), fontHeader, Brushes.Black, x + 5, y + 7)
            x += colWidths(i)
        Next

        y += 30

        ' ===========================================
        ' 6. ISI TABEL
        ' ===========================================
        Dim rowHeight = 25

        While currentPrintRow < DataGridView1.Rows.Count

            Dim row = DataGridView1.Rows(currentPrintRow)
            If row.IsNewRow Then
                currentPrintRow += 1
                Continue While
            End If

            If y > e.MarginBounds.Bottom - 40 Then
                e.HasMorePages = True
                Return
            End If

            x = startX

            Dim nis = row.Cells("nis").Value.ToString()
            Dim nama = row.Cells("nama").Value.ToString()

            Dim hadir = CInt(row.Cells("hadir").Value)
            Dim izin = CInt(row.Cells("izin").Value)
            Dim sakit = CInt(row.Cells("sakit").Value)
            Dim alfa = CInt(row.Cells("alfa").Value)

            Dim total = hadir + izin + sakit + alfa
            Dim persen = If(total > 0, (hadir / total) * 100, 0)

            ' Border per row
            e.Graphics.DrawRectangle(Pens.Black, startX, y, totalTableWidth, rowHeight)

            ' Isi kolom
            Dim values = {
            (currentPrintRow + 1).ToString(),
            nis, nama, total.ToString(),
            alfa.ToString(), hadir.ToString(),
            izin.ToString(), sakit.ToString(),
            persen.ToString("0.00") & "%"
        }

            For i = 0 To values.Length - 1
                e.Graphics.DrawString(values(i), fontIsi, Brushes.Black, x + 5, y + 5)
                x += colWidths(i)
            Next

            y += rowHeight
            currentPrintRow += 1
        End While

        currentPrintRow = 0
        e.HasMorePages = False

        ' ===========================================
        ' FOOTER: TANGGAL CETAK + TTD WALI KELAS
        ' ===========================================
        Dim footerY As Integer = y + 40     ' → TARUH FOOTER SETELAH TABEL

        ' Jika footer terlalu dekat, tambahkan minimal spacing
        If footerY < e.MarginBounds.Bottom - 200 Then
            footerY = e.MarginBounds.Bottom - 200
        End If

        Dim tanggalCetak As String = Date.Now.ToString("dd MMMM yyyy")

        e.Graphics.DrawString("Dicetak pada : " & tanggalCetak,
                              fontSmall, Brushes.Black, marginLeft, footerY)

        footerY += 40

        ' Kolom tanda tangan wali kelas (kanan)
        Dim ttdX As Integer = marginLeft + pageWidth - 250

        e.Graphics.DrawString("Guru / Wali Kelas",
                              fontHeader, Brushes.Black, ttdX, footerY)
        footerY += 90

        e.Graphics.DrawString("............................",
                              fontHeader, Brushes.Black, ttdX, footerY)


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
