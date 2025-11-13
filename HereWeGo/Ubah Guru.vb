Imports System.Threading.Tasks

Public Class Ubah_Guru
    Private parentForm As Admin
    Private repo As New GuruRepository()
    Private userRepo As New PenggunaRepository()
    Private currentNip As String

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Public Async Sub LoadGuruData(nip As String, nama As String, id_user As String)
        currentNip = nip
        TextBox1.Text = nip
        TextBox1.ReadOnly = True
        TextBox2.Text = nama
        Await LoadUserIdsAsync()
        ComboBox1.SelectedItem = id_user
    End Sub

    Private Async Function LoadUserIdsAsync() As Task
        ComboBox1.Items.Clear()

        ' Ambil semua pengguna aktif
        Dim users = Await userRepo.GetAllAsync()

        ' Ambil semua guru untuk mengecek id_user yang sudah dipakai
        Dim allGuru = Await repo.GetAllAsync()

        ' Ambil semua id_user yang sudah dipakai guru lain
        Dim usedUserIds = allGuru.Where(Function(g) g.id_user IsNot Nothing AndAlso g.id_user <> currentNip).
                              Select(Function(g) g.id_user).ToHashSet()

        ' Masukkan hanya pengguna aktif yang belum digunakan guru lain
        For Each u In users
            If u.status Then
                ' Jika belum digunakan guru lain, atau ini user milik guru yang sedang diedit
                If Not usedUserIds.Contains(u.id_user) OrElse ComboBox1.SelectedItem?.ToString() = u.id_user Then
                    ComboBox1.Items.Add(u.id_user)
                End If
            End If
        Next
    End Function



    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If String.IsNullOrWhiteSpace(TextBox2.Text) OrElse ComboBox1.SelectedItem Is Nothing Then
                MessageBox.Show("Nama dan ID User wajib diisi.")
                Return
            End If

            Dim data As New GuruModel With {
                .nama = TextBox2.Text.Trim(),
                .id_user = ComboBox1.SelectedItem.ToString()
            }

            Await repo.UpdateAsync(currentNip, data)
            MessageBox.Show("Data guru berhasil diubah.", "Sukses")
            parentForm.ShowFormInPanel(New Guru(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal mengubah data guru: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Guru(parentForm))
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Ubah_Guru_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
