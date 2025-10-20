Imports Newtonsoft.Json

Public Class Tambah_Pengguna
    Private repo As New PenggunaRepository()

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) 'Simpan
        Dim data As New PenggunaModel With {
            .email = TextBox3.Text,
            .password = TextBox2.Text,
            .role = ComboBox1.Text,
            .status = "aktif"
        }

        Await repo.AddAsync(data)
        MessageBox.Show("Pengguna berhasil ditambahkan!", "Sukses")
        Close
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 'Batal
        Close
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub
End Class
