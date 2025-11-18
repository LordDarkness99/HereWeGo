Imports System.Threading.Tasks

Public Class Rfid
    Private parentForm As Admin
    Private repo As New RfidRepository()

    Private selectedRfidId As String = Nothing
    Private selectedNis As String = Nothing

    Private currentPage As Integer = 0
    Private pageSize As Integer = 15
    Private totalData As Integer = 0
    Private currentKeyword As String = ""
    Private isLoading As Boolean = False

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Async Sub Rfid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadTotalDataAsync()
        Await LoadDataAsync()
    End Sub

    Private Async Function LoadTotalDataAsync() As Task
        totalData = Await repo.GetCountAsync()
    End Function

    Public Async Function LoadDataAsync() As Task
        If isLoading Then Return
        isLoading = True

        Try
            DataGridView1.Rows.Clear()
            Dim offset = currentPage * pageSize
            Dim list = Await repo.GetPagedAsync(pageSize, offset)

            For Each rfid In list
                DataGridView1.Rows.Add(
                    rfid.rfid_id,
                    rfid.nis,
                    If(rfid.status, "Aktif", "Nonaktif")
                )
            Next
            UpdateNavigationButtons()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data RFID: " & ex.Message)
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
            If String.IsNullOrWhiteSpace(currentKeyword) Then
                Await LoadDataAsync()
            Else
                Await LoadSearchAsync(currentKeyword)
            End If
        End If
    End Sub

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

    Public Async Function LoadSearchAsync(keyword As String) As Task
        If isLoading Then Return
        isLoading = True

        Try
            DataGridView1.Rows.Clear()
            Dim offset = currentPage * pageSize
            Dim list = Await repo.SearchPagedAsync(keyword, pageSize, offset)
            totalData = Await repo.GetSearchCountAsync(keyword)

            For Each rfid In list
                DataGridView1.Rows.Add(
                    rfid.rfid_id,
                    rfid.nis,
                    If(rfid.status, "Aktif", "Nonaktif")
                )
            Next
            UpdateNavigationButtons()
        Catch ex As Exception
            MessageBox.Show("Gagal mencari data RFID: " & ex.Message)
        Finally
            isLoading = False
        End Try
    End Function

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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            selectedRfidId = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            selectedNis = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) 'ubah
        If selectedRfidId Is Nothing Then
            MessageBox.Show("Pilih kartu terlebih dahulu.")
            Return
        End If
        Dim formUbah As New Ubah_Rfid(parentForm)
        formUbah.LoadRfidData(selectedRfidId, selectedNis)
        parentForm.ShowFormInPanel(formUbah)
    End Sub

    Private Async Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click 'hapus
        If selectedRfidId IsNot Nothing Then
            Await repo.DeactivateAsync(selectedRfidId)
            MessageBox.Show("Kartu RFID berhasil dinonaktifkan.")
            Await LoadDataAsync()
        Else
            MessageBox.Show("Silakan pilih kartu terlebih dahulu.")
        End If
    End Sub
End Class
