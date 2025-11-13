Imports System.Threading.Tasks

Public Class Jadwal_Mapel
    Private parentForm As Admin
    Private repo As New JadwalMapelRepository()
    Private currentPage As Integer = 0
    Private pageSize As Integer = 15
    Private totalData As Integer = 0
    Private currentKeyword As String = ""
    Private selectedId As String = Nothing
    Private isLoading As Boolean = False

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Async Sub Jadwal_Mapel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadTotalDataAsync()
        Await LoadDataAsync()
    End Sub

    Private Async Function LoadTotalDataAsync() As Task
        totalData = Await repo.GetCountAsync()
    End Function

    Private Async Function LoadDataAsync() As Task
        If isLoading Then Return
        isLoading = True
        Try
            DataGridView1.Rows.Clear()
            Dim offset = currentPage * pageSize
            Dim list = Await repo.GetPagedAsync(pageSize, offset)

            For Each j In list
                DataGridView1.Rows.Add(j.id_jadwal, j.id_kelas, j.id_mapel, j.nip, j.hari, j.jam_mulai, j.jam_selesai, If(j.status, "Aktif", "Nonaktif"))
            Next

            UpdateNavigationButtons()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data jadwal: " & ex.Message)
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

    Private Async Function LoadSearchAsync(keyword As String) As Task
        DataGridView1.Rows.Clear()
        Dim offset = currentPage * pageSize
        Dim list = Await repo.SearchPagedAsync(keyword, pageSize, offset)
        totalData = Await repo.GetSearchCountAsync(keyword)

        For Each j In list
            DataGridView1.Rows.Add(j.id_jadwal, j.id_kelas, j.id_mapel, j.nip, j.hari, j.jam_mulai, j.jam_selesai, If(j.status, "Aktif", "Nonaktif"))
        Next

        UpdateNavigationButtons()
    End Function

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            selectedId = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tambah_Jadwal_Mapel(parentForm))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If selectedId Is Nothing Then
            MessageBox.Show("Pilih jadwal terlebih dahulu.")
            Return
        End If
        Dim formUbah As New Ubah_Jadwal_Mapel(parentForm)
        formUbah.LoadJadwalData(selectedId)
        parentForm.ShowFormInPanel(formUbah)
    End Sub

    Private Async Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If selectedId IsNot Nothing Then
            Await repo.DeactivateAsync(selectedId)
            MessageBox.Show("Jadwal berhasil dinonaktifkan.")
            Await LoadDataAsync()
        Else
            MessageBox.Show("Silakan pilih jadwal terlebih dahulu.")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
