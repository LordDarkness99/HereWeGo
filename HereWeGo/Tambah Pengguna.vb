Imports System.Threading.Tasks

Public Class Tambah_Pengguna
    Private parentForm As Admin
    Private repo As New PenggunaRepository()

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' Tombol Batal
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Pengguna(parentForm))
    End Sub

    ' Tombol Simpan
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Validasi sederhana
            If String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox4.Text) OrElse
               ComboBox1.SelectedItem Is Nothing Then
                MessageBox.Show("Semua field wajib diisi.")
                Return
            End If

            If TextBox2.Text <> TextBox4.Text Then
                MessageBox.Show("Password dan ulangi password tidak sama!")
                Return
            End If

            Dim data As New PenggunaModel With {
                .email = TextBox3.Text.Trim(),
                .password = TextBox2.Text.Trim(),
                .role = ComboBox1.SelectedItem.ToString(),
                .status = True
            }

            Await repo.AddAsync(data)
            MessageBox.Show("Pengguna baru berhasil ditambahkan!", "Sukses")

            parentForm.ShowFormInPanel(New Pengguna(parentForm))

        Catch ex As Exception
            MessageBox.Show("Gagal menambah pengguna: " & ex.Message)
        End Try
    End Sub

End Class
