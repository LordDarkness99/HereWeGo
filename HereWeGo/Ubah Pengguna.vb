Imports System.Windows.Forms.VisualStyles

Public Class Ubah_Pengguna
    Private repo As New PenggunaRepository()
    Private userId As Integer

    Public Sub New(id As Integer)
        InitializeComponent()
        userId = id
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Simpan
        Dim data As New PenggunaModel With {
            .email = TextBox3.Text,
            .password = TextBox2.Text,
            .role = ComboBox1.Text,
            .status = ComboBox2.Text 'aktif / tidak aktif
        }

        Await repo.UpdateAsync(userId, data)
        MessageBox.Show("Data pengguna berhasil diubah!", "Sukses")
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'Batal
        Me.Close()
    End Sub
End Class
