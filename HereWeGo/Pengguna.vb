Imports System.Threading.Tasks

Public Class Pengguna
    Private parentForm As Admin
    Private repo As New PenggunaRepository()

    ' Variabel data terpilih
    Private selectedId As String
    Private selectedEmail As String
    Private selectedRole As String

    ' Pagination
    Private currentPage As Integer = 0
    Private pageSize As Integer = 15
    Private totalData As Integer = 0
    Private currentKeyword As String = ""
    Private isLoading As Boolean = False ' 🔒 Mencegah eksekusi ganda

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Async Sub Pengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler searchTimer.Tick, AddressOf searchTimer_Tick ' 🔹 tambahkan baris ini
        Await RefreshDataAsync()
    End Sub

    ' 🔄 Fungsi refresh utama
    Private Async Function RefreshDataAsync() As Task
        If isLoading Then Return
        isLoading = True

        Try
            DataGridView1.Rows.Clear()
            If String.IsNullOrWhiteSpace(currentKeyword) Then
                Await LoadTotalDataAsync()
                Await LoadDataAsync()
            Else
                Await LoadSearchAsync(currentKeyword)
            End If
        Finally
            isLoading = False
        End Try
    End Function

    ' 🔹 Hitung total data
    Private Async Function LoadTotalDataAsync() As Task
        totalData = Await repo.GetCountAsync()
    End Function

    ' 🔹 Load data tanpa filter
    Private Async Function LoadDataAsync() As Task
        Try
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

    ' 🔍 Load data hasil pencarian
    Private Async Function LoadSearchAsync(keyword As String) As Task
        Try
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

    ' 🔹 Update tombol navigasi
    Private Sub UpdateNavigationButtons()
        Button1.Enabled = (currentPage > 0)
        Lanjut.Enabled = ((currentPage + 1) * pageSize < totalData)
    End Sub

    ' 🔙 Tombol Sebelumnya
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentPage > 0 Then
            currentPage -= 1
            Await RefreshDataAsync()
        End If
    End Sub

    ' 🔜 Tombol Lanjut
    Private Async Sub Lanjut_Click(sender As Object, e As EventArgs) Handles Lanjut.Click
        If (currentPage + 1) * pageSize < totalData Then
            currentPage += 1
            Await RefreshDataAsync()
        End If
    End Sub

    ' 🔎 Search realtime dengan debounce (mencegah double refresh)
    Private searchTimer As New Timer() With {.Interval = 500} ' 0.5 detik delay

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        searchTimer.Stop()
        searchTimer.Tag = TextBox2.Text.Trim()
        searchTimer.Start()
    End Sub

    Private Async Sub searchTimer_Tick(sender As Object, e As EventArgs)
        searchTimer.Stop()
        currentKeyword = searchTimer.Tag.ToString()
        currentPage = 0
        Await RefreshDataAsync()
    End Sub


    ' 🔹 Klik baris DataGrid
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < DataGridView1.Rows.Count Then
            selectedId = DataGridView1.Rows(e.RowIndex).Cells(0).Value?.ToString()
            selectedEmail = DataGridView1.Rows(e.RowIndex).Cells(1).Value?.ToString()
            selectedRole = DataGridView1.Rows(e.RowIndex).Cells(3).Value?.ToString()
        End If
    End Sub

    ' ➕ Tambah Pengguna
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tambah_Pengguna(parentForm))
    End Sub

    ' ✏️ Ubah Pengguna
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If String.IsNullOrWhiteSpace(selectedId) Then
            MessageBox.Show("Pilih pengguna terlebih dahulu.")
            Return
        End If

        Dim formUbah As New Ubah_Pengguna(parentForm)
        formUbah.LoadUserData(selectedId, selectedEmail, selectedRole)
        parentForm.ShowFormInPanel(formUbah)
    End Sub

    ' 🚫 Nonaktifkan
    Private Async Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If String.IsNullOrWhiteSpace(selectedId) Then
            MessageBox.Show("Silakan pilih pengguna terlebih dahulu.")
            Return
        End If

        Try
            Await repo.DeactivateAsync(selectedId)
            MessageBox.Show("Pengguna berhasil dinonaktifkan.", "Sukses")
            Await RefreshDataAsync()
        Catch ex As Exception
            MessageBox.Show("Gagal menonaktifkan pengguna: " & ex.Message)
        End Try
    End Sub
End Class
