Imports System.Threading.Tasks

Public Class Guru
    Private parentForm As Admin
    Private repo As New GuruRepository()

    Private selectedNip As String = Nothing
    Private selectedNama As String = Nothing
    Private selectedUserId As String = Nothing

    ' 🔹 Variabel pagination
    Private currentPage As Integer = 0
    Private pageSize As Integer = 15
    Private totalData As Integer = 0
    Private currentKeyword As String = ""
    Private isLoading As Boolean = False

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' 🔹 Load awal
    Private Async Sub Guru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadTotalDataAsync()
        Await LoadDataAsync()
    End Sub

    ' 🔹 Hitung total data
    Private Async Function LoadTotalDataAsync() As Task
        totalData = Await repo.GetCountAsync()
    End Function

    ' 🔹 Load data semua guru (tanpa filter)
    Public Async Function LoadDataAsync() As Task
        If isLoading Then Return
        isLoading = True

        Try
            DataGridView1.Rows.Clear()

            Dim offset = currentPage * pageSize
            Dim list = Await repo.GetPagedAsync(pageSize, offset)

            For Each guru In list
                DataGridView1.Rows.Add(
                    guru.nip,
                    guru.nama,
                    guru.id_user,
                    If(guru.status, "Aktif", "Nonaktif")
                )
            Next

            UpdateNavigationButtons()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data guru: " & ex.Message)
        Finally
            isLoading = False
        End Try
    End Function

    ' 🔍 Load data hasil pencarian
    Public Async Function LoadSearchAsync(keyword As String) As Task
        If isLoading Then Return
        isLoading = True

        Try
            DataGridView1.Rows.Clear()

            Dim offset = currentPage * pageSize
            Dim list = Await repo.SearchPagedAsync(keyword, pageSize, offset)
            totalData = Await repo.GetSearchCountAsync(keyword)

            For Each guru In list
                DataGridView1.Rows.Add(
                    guru.nip,
                    guru.nama,
                    guru.id_user,
                    If(guru.status, "Aktif", "Nonaktif")
                )
            Next

            UpdateNavigationButtons()
        Catch ex As Exception
            MessageBox.Show("Gagal mencari data guru: " & ex.Message)
        Finally
            isLoading = False
        End Try
    End Function

    ' 🔹 Update tombol navigasi
    Private Sub UpdateNavigationButtons()
        Button1.Enabled = (currentPage > 0)
        Lanjut.Enabled = ((currentPage + 1) * pageSize < totalData)
    End Sub

    ' 🔹 Tombol Sebelum
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentPage > 0 Then
            currentPage -= 1
            If String.IsNullOrWhiteSpace(currentKeyword) Then
                Await LoadDataAsync()
            Else
                Await LoadSearchAsync(currentKeyword)
            End If
        End If
    End Sub

    ' 🔹 Tombol Lanjut
    Private Async Sub Lanjut_Click(sender As Object, e As EventArgs) Handles Lanjut.Click
        If (currentPage + 1) * pageSize < totalData Then
            currentPage += 1
            If String.IsNullOrWhiteSpace(currentKeyword) Then
                Await LoadDataAsync()
            Else
                Await LoadSearchAsync(currentKeyword)
            End If
        End If
    End Sub

    ' 🔹 Search realtime (sama seperti pengguna)
    Private Async Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        currentKeyword = TextBox2.Text.Trim()
        currentPage = 0

        If String.IsNullOrWhiteSpace(currentKeyword) Then
            Await LoadTotalDataAsync()
            Await LoadDataAsync()
        Else
            Await LoadSearchAsync(currentKeyword)
        End If
    End Sub

    ' 🔹 Pilih guru dari tabel
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            selectedNip = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            selectedNama = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
            selectedUserId = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
        End If
    End Sub

    ' 🔹 Tombol Tambah
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tambah_Guru(parentForm))
    End Sub

    ' 🔹 Tombol Ubah
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If selectedNip Is Nothing Then
            MessageBox.Show("Pilih guru terlebih dahulu.")
            Return
        End If

        Dim formUbah As New Ubah_Guru(parentForm)
        formUbah.LoadGuruData(selectedNip, selectedNama, selectedUserId)
        parentForm.ShowFormInPanel(formUbah)
    End Sub

    ' 🔹 Tombol Nonaktifkan
    Private Async Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If selectedNip IsNot Nothing Then
            Await repo.DeactivateAsync(selectedNip)
            MessageBox.Show("Guru berhasil dinonaktifkan.")
            If String.IsNullOrWhiteSpace(currentKeyword) Then
                Await LoadDataAsync()
            Else
                Await LoadSearchAsync(currentKeyword)
            End If
        Else
            MessageBox.Show("Silakan pilih guru terlebih dahulu.")
        End If
    End Sub
End Class
