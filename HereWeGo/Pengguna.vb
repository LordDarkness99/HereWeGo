Imports System.Threading.Tasks

Public Class Pengguna
    Private parentForm As Admin
    Private repo As New PenggunaRepository()
    Private selectedId As String = Nothing
    Private selectedEmail As String = Nothing
    Private selectedRole As String = Nothing

    ' 🔹 Variabel pagination
    Private currentPage As Integer = 0
    Private pageSize As Integer = 15
    Private totalData As Integer = 0
    Private currentKeyword As String = ""

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Async Sub Pengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadTotalDataAsync()
        Await LoadDataAsync()
    End Sub

    Private Async Function LoadTotalDataAsync() As Task
        totalData = Await repo.GetCountAsync()
    End Function

    Public Async Function LoadDataAsync() As Task
        Try
            DataGridView1.Rows.Clear()

            Dim offset = currentPage * pageSize
            Dim list = Await repo.GetPagedAsync(pageSize, offset)

            For Each pengguna In list
                DataGridView1.Rows.Add(
                    pengguna.id_user,
                    pengguna.email,
                    pengguna.password,
                    pengguna.role,
                    If(pengguna.status, "Aktif", "Nonaktif")
                )
            Next

            UpdateNavigationButtons()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data pengguna: " & ex.Message)
        End Try
    End Function

    ' 🔍 Fungsi untuk load data hasil pencarian
    Public Async Function LoadSearchAsync(keyword As String) As Task
        Try
            DataGridView1.Rows.Clear()

            Dim offset = currentPage * pageSize
            Dim list = Await repo.SearchPagedAsync(keyword, pageSize, offset)
            totalData = Await repo.GetSearchCountAsync(keyword)

            For Each pengguna In list
                DataGridView1.Rows.Add(
                    pengguna.id_user,
                    pengguna.email,
                    pengguna.password,
                    pengguna.role,
                    If(pengguna.status, "Aktif", "Nonaktif")
                )
            Next

            UpdateNavigationButtons()
        Catch ex As Exception
            MessageBox.Show("Gagal mencari data: " & ex.Message)
        End Try
    End Function

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

    ' 🔹 Search realtime
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

    ' 🔹 Pilih baris di DataGridView
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            selectedId = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            selectedEmail = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
            selectedRole = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString()
        End If
    End Sub

    ' 🔹 Tombol Tambah
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tambah_Pengguna(parentForm))
    End Sub

    ' 🔹 Tombol Ubah
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If selectedId Is Nothing Then
            MessageBox.Show("Pilih pengguna terlebih dahulu.")
            Return
        End If

        Dim formUbah As New Ubah_Pengguna(parentForm)
        formUbah.LoadUserData(selectedId, selectedEmail, selectedRole)
        parentForm.ShowFormInPanel(formUbah)
    End Sub

    ' 🔹 Tombol Nonaktifkan
    Private Async Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If selectedId IsNot Nothing Then
            Await repo.DeactivateAsync(selectedId)
            MessageBox.Show("Pengguna berhasil dinonaktifkan.")
            If String.IsNullOrWhiteSpace(currentKeyword) Then
                Await LoadDataAsync()
            Else
                Await LoadSearchAsync(currentKeyword)
            End If
        Else
            MessageBox.Show("Silakan pilih pengguna terlebih dahulu.")
        End If
    End Sub
End Class
