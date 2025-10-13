Public Class Tambah_Pengguna
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email = TextBox3.Text.Trim()
        Dim password = TextBox2.Text.Trim()
        Dim ulangi = TextBox4.Text.Trim()
        Dim role = ComboBox1.Text

        If email = "" Or password = "" Or ulangi = "" Or role = "" Then
            MessageBox.Show("Semua field wajib diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If password <> ulangi Then
            MessageBox.Show("Password tidak cocok!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim sukses = Await Akun.TambahAsync(email, password, role)

        If sukses Then
            MessageBox.Show("Akun berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

            ' 🔧 Pastikan pengambilan form Pengguna seperti ini:
            Dim penggunaForm = Application.OpenForms().OfType(Of Pengguna)().FirstOrDefault()
            If penggunaForm IsNot Nothing Then
                Await penggunaForm.LoadData()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class
