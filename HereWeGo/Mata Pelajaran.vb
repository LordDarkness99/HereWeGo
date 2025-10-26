Imports System.Threading.Tasks

Public Class Mata_Pelajaran
    Private parentForm As Admin
    Private repo As New MataPelajaranRepository()
    Private selectedId As String
    Private selectedNama As String

    ' Pagination dan kontrol
    Private currentPage As Integer = 0
    Private pageSize As Integer = 15
    Private totalData As Integer = 0
    Private currentKeyword As String = ""
    Private isLoading As Boolean = False

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Async Sub Mata_Pelajaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadTotalDataAsync()
        Await LoadDataAsync()
    End Sub

    Private Async Function LoadTotalDataAsync() As Task
        totalData = If(String.IsNullOrWhiteSpace(currentKeyword),
                       Await repo.GetCountAsync(),
                       Await repo.GetSearchCountAsync(currentKeyword))
    End Function

    Private Async Function LoadDataAsync() As Task
        If isLoading Then Return
        isLoading = True

        Try
            DataGridView1.Rows.Clear()
            Dim offset = currentPage * pageSize

            Dim list = If(String.IsNullOrWhiteSpace(currentKeyword),
                          Await repo.GetPagedAsync(pageSize, offset),
                          Await repo.SearchPagedAsync(currentKeyword, pageSize, offset))

            ' urutkan agar aktif di atas
            Dim sortedList = list.OrderByDescending(Function(m) m.status).ToList()

            For Each m In sortedList
                DataGridView1.Rows.Add(
                    m.id_mapel,
                    m.nama_mapel,
                    m.id_guru,
                    If(m.status, "Aktif", "Nonaktif")
                )
            Next

            Await LoadTotalDataAsync()
            UpdateNavigationButtons()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data mata pelajaran: " & ex.Message)
        Finally
            isLoading = False
        End Try
    End Function

    Private Sub UpdateNavigationButtons()
        Button1.Enabled = (currentPage > 0)
        Lanjut.Enabled = ((currentPage + 1) * pageSize < totalData)
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentPage > 0 Then
            currentPage -= 1
            Await LoadDataAsync()
        End If
    End Sub

    Private Async Sub Lanjut_Click(sender As Object, e As EventArgs) Handles Lanjut.Click
        If (currentPage + 1) * pageSize < totalData Then
            currentPage += 1
            Await LoadDataAsync()
        End If
    End Sub

    ' ✅ Revisi utama di sini
    Private Async Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        currentKeyword = TextBox2.Text.Trim()
        currentPage = 0

        ' kalau textbox kosong, tampilkan semua data lagi
        If String.IsNullOrWhiteSpace(currentKeyword) Then
            currentKeyword = ""
            Await LoadTotalDataAsync()
            Await LoadDataAsync()
        Else
            Await LoadDataAsync()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            selectedId = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            selectedNama = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tambah_Mata_Pelajaran(parentForm))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If String.IsNullOrEmpty(selectedId) Then
            MessageBox.Show("Pilih mata pelajaran terlebih dahulu.")
            Return
        End If

        Dim formUbah As New Ubah_Mata_Pelajaran(parentForm)
        formUbah.LoadMapelData(selectedId, selectedNama)
        parentForm.ShowFormInPanel(formUbah)
    End Sub

    Private Async Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If String.IsNullOrEmpty(selectedId) Then
            MessageBox.Show("Silakan pilih mata pelajaran terlebih dahulu.")
            Return
        End If

        Dim success = Await repo.DeactivateAsync(selectedId)
        MessageBox.Show(If(success, "Mata pelajaran berhasil dinonaktifkan.", "Gagal menonaktifkan mata pelajaran."))

        Await LoadTotalDataAsync()
        Await LoadDataAsync()
    End Sub
End Class
