Imports System.Threading.Tasks

Public Class Pengguna
    Private repo As New PenggunaRepository()
    Private dataList As List(Of PenggunaModel)
    Private currentPage As Integer = 0
    Private Const pageSize As Integer = 10

    Private Async Sub Pengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadDataAsync()
    End Sub

    Private Async Function LoadDataAsync() As Task
        dataList = Await repo.GetAllAsync()
        ShowPage(0)
    End Function

    Private Sub ShowPage(page As Integer)
        DataGridView1.Rows.Clear()
        Dim skip = page * pageSize
        Dim pageData = dataList.Skip(skip).Take(pageSize).ToList()

        For Each user In pageData
            DataGridView1.Rows.Add(user.id, user.email, user.password, user.role, user.status)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) 'sebelumnya
        If currentPage > 0 Then
            currentPage -= 1
            ShowPage(currentPage)
        End If
    End Sub

    Private Sub Lanjut_Click(sender As Object, e As EventArgs) 'selanjutnya
        If (currentPage + 1) * pageSize < dataList.Count Then
            currentPage += 1
            ShowPage(currentPage)
        End If
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) 'Tambah
        Dim f As New Tambah_Pengguna
        f.ShowDialog
        Await LoadDataAsync
    End Sub


    Private Async Sub Button3_Click(sender As Object, e As EventArgs) 'Ubah
        If DataGridView1.CurrentRow Is Nothing Then Exit Sub
        Dim id = Convert.ToInt32(DataGridView1.CurrentRow.Cells(0).Value)
        Dim f As New Ubah_Pengguna(id)
        f.ShowDialog
        Await LoadDataAsync
    End Sub

    Private Async Sub Button4_Click(sender As Object, e As EventArgs) 'Hapus
        If DataGridView1.CurrentRow Is Nothing Then Exit Sub
        Dim id = Convert.ToInt32(DataGridView1.CurrentRow.Cells(0).Value)
        If MessageBox.Show("Hapus pengguna ini?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Await repo.DeleteAsync(id)
            Await LoadDataAsync
        End If
    End Sub
End Class
