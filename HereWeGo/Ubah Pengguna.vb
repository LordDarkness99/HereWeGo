Imports System.Threading.Tasks

Public Class Ubah_Pengguna
    Private parentForm As Admin
    Private repo As New PenggunaRepository()
    Private currentUserId As String

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' Terima data dari form Pengguna
    Public Sub LoadUserData(id_user As String, email As String, role As String)
        currentUserId = id_user
        TextBox1.Text = id_user
        TextBox1.ReadOnly = True
        TextBox3.Text = email
        ComboBox1.SelectedItem = role
    End Sub

    ' Tombol Batal
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Pengguna(parentForm))
    End Sub

    ' Tombol Simpan/Ubah
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Pastikan semua kolom diisi
            If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox4.Text) OrElse
               ComboBox1.SelectedItem Is Nothing Then
                MessageBox.Show("Semua field wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validasi password dan ulangi password
            If TextBox2.Text <> TextBox4.Text Then
                MessageBox.Show("Password dan ulangi password tidak sama!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Buat model pengguna baru untuk dikirim ke repository
            Dim data As New PenggunaModel With {
                .email = TextBox3.Text.Trim(),
                .password = TextBox2.Text.Trim(),
                .role = ComboBox1.SelectedItem.ToString()
            }

            ' Gunakan ID dari textbox (backup jaga-jaga kalau currentUserId kosong)
            Dim targetId As String = If(String.IsNullOrEmpty(currentUserId), TextBox1.Text.Trim(), currentUserId)

            Await repo.UpdateAsync(targetId, data)

            MessageBox.Show("Data pengguna berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            parentForm.ShowFormInPanel(New Pengguna(parentForm))

        Catch ex As Exception
            MessageBox.Show("Gagal mengubah data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
