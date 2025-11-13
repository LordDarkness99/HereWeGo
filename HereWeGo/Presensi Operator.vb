Imports System.Threading.Tasks
Imports Newtonsoft.Json

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
    End Sub

    Private Async Function LoadKelasAsync() As Task
        ComboBox1.Items.Clear()
        Dim list = Await kelasRepo.GetAllAsync()
        For Each k In list
            ComboBox1.Items.Add(New KeyValuePair(Of String, String)(k.id_kelas, k.nama_kelas))
        Next
        ComboBox1.DisplayMember = "Value"
        ComboBox1.ValueMember = "Key"
    End Function

    Private Async Function LoadMapelAsync() As Task
        ComboBox2.Items.Clear()
        Dim list = Await mapelRepo.GetAllAsync()
        For Each m In list
            ComboBox2.Items.Add(New KeyValuePair(Of String, String)(m.id_mapel, m.nama_mapel))
        Next
        ComboBox2.DisplayMember = "Value"
        ComboBox2.ValueMember = "Key"
    End Function


    ' 🔹 Saat pilih kelas
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Hanya menampilkan nama kelas (sudah otomatis karena DisplayMember)
    End Sub

    ' 🔹 Saat pilih mapel
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ' Hanya menampilkan nama mapel (DisplayMember)
    End Sub

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
            Dim list = Await presensiRepo.GetByFilterAsync(idKelas, idMapel)

            For Each p In list
                DataGridView1.Rows.Add(p.nis, p.nama_siswa, p.status)
            Next
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data presensi: " & ex.Message)
        End Try
    End Function


    ' 🔹 Klik ubah status presensi
    Private Async Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click ' mengarah ke form ubah presensi

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Menampilkan data siswa saja (nis, nama, status)
    End Sub
End Class
