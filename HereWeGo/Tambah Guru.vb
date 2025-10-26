Imports System.Threading.Tasks

Public Class Tambah_Guru
    Private parentForm As Admin
    Private repo As New GuruRepository()
    Private userRepo As New PenggunaRepository() ' untuk ambil id_user

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Async Sub Tambah_Guru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadUserIdsAsync()
    End Sub

    Private Async Function LoadUserIdsAsync() As Task
        ComboBox1.Items.Clear()

        ' 🔹 Ambil semua user dan semua guru
        Dim users = Await userRepo.GetAllAsync()
        Dim guruList = Await repo.GetAllAsync()

        ' 🔹 Buat list id_user yang sudah dipakai guru
        Dim usedUserIds = guruList.Select(Function(g) g.id_user).ToList()

        ' 🔹 Tampilkan hanya user aktif dan belum digunakan oleh guru mana pun
        For Each u In users
            If u.status AndAlso Not usedUserIds.Contains(u.id_user) Then
                ComboBox1.Items.Add(u.id_user)
            End If
        Next
    End Function

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' 🔹 Validasi input
            If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse ComboBox1.SelectedItem Is Nothing Then
                MessageBox.Show("Nama dan User wajib diisi.")
                Return
            End If

            ' 🔹 Siapkan data guru baru
            Dim guru As New GuruModel With {
                .nama = TextBox1.Text.Trim(),
                .id_user = ComboBox1.SelectedItem.ToString(),
                .status = True
            }

            Await repo.AddAsync(guru)
            MessageBox.Show("Guru berhasil ditambahkan.", "Sukses")
            parentForm.ShowFormInPanel(New Guru(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal menambah guru: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Guru(parentForm))
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
