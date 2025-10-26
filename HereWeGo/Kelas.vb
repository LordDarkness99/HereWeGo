Imports System.Threading.Tasks

Public Class Kelas
    Private parentForm As Admin
    Private repo As New KelasRepository()

    Private selectedId As String
    Private selectedNama As String

    ' 🔹 Variabel untuk pagination & state
    Private currentPage As Integer = 0
    Private pageSize As Integer = 15
    Private totalData As Integer = 0
    Private currentKeyword As String = ""
    Private isLoading As Boolean = False

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' 🔹 Saat form pertama kali dimuat
    Private Async Sub Kelas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadTotalDataAsync()
        Await LoadDataAsync()
    End Sub

    ' 🔹 Hitung total data (tergantung apakah sedang search)
    Private Async Function LoadTotalDataAsync() As Task
        totalData = If(String.IsNullOrWhiteSpace(currentKeyword),
                       Await repo.GetCountAsync(),
                       Await repo.GetSearchCountAsync(currentKeyword))
    End Function

    ' 🔹 Fungsi utama untuk memuat data (baik normal maupun search)
    Private Async Function LoadDataAsync() As Task
        If isLoading Then Return
        isLoading = True

        Try
            DataGridView1.Rows.Clear()
            Dim offset = currentPage * pageSize

            Dim list = If(String.IsNullOrWhiteSpace(currentKeyword),
                          Await repo.GetPagedAsync(pageSize, offset),
                          Await repo.SearchPagedAsync(currentKeyword, pageSize, offset))

            For Each kls In list
                DataGridView1.Rows.Add(
                    kls.id_kelas,
                    kls.nama_kelas,
                    If(kls.status, "Aktif", "Nonaktif")
                )
            Next

            Await LoadTotalDataAsync()
            UpdateNavigationButtons()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data kelas: " & ex.Message)
        Finally
            isLoading = False
        End Try
    End Function

    ' 🔹 Update status tombol navigasi
    Private Sub UpdateNavigationButtons()
        Button1.Enabled = (currentPage > 0)
        Lanjut.Enabled = ((currentPage + 1) * pageSize < totalData)
    End Sub

    ' 🔹 Tombol Sebelumnya
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentPage > 0 Then
            currentPage -= 1
            Await LoadDataAsync()
        End If
    End Sub

    ' 🔹 Tombol Lanjut
    Private Async Sub Lanjut_Click(sender As Object, e As EventArgs) Handles Lanjut.Click
        If (currentPage + 1) * pageSize < totalData Then
            currentPage += 1
            Await LoadDataAsync()
        End If
    End Sub

    ' 🔍 Search realtime (sama dengan Pengguna & Guru)
    Private Async Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        currentKeyword = TextBox2.Text.Trim()
        currentPage = 0
        Await LoadDataAsync()
    End Sub

    ' 🔹 Pilih baris dari tabel
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            selectedId = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            selectedNama = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
        End If
    End Sub

    ' 🔹 Tombol Tambah
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tambah_Kelas(parentForm))
    End Sub

    ' 🔹 Tombol Ubah
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If selectedId Is Nothing Then
            MessageBox.Show("Pilih kelas terlebih dahulu.")
            Return
        End If

        Dim status = DataGridView1.CurrentRow.Cells(2).Value.ToString() = "Aktif"
        Dim formUbah As New Ubah_Kelas(parentForm)
        formUbah.LoadKelasData(selectedId, selectedNama, status)
        parentForm.ShowFormInPanel(formUbah)
    End Sub

    ' 🔹 Tombol Nonaktifkan
    Private Async Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If selectedId IsNot Nothing Then
            Dim success = Await repo.DeactivateAsync(selectedId)
            MessageBox.Show(If(success, "Kelas berhasil dinonaktifkan.", "Gagal menonaktifkan kelas."))

            Await LoadTotalDataAsync()
            Await LoadDataAsync()
        Else
            MessageBox.Show("Silakan pilih kelas terlebih dahulu.")
        End If
    End Sub
End Class
