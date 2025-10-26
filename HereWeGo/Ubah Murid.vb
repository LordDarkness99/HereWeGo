Public Class Ubah_Murid
    Private parentForm As Admin
    Private repo As New MuridRepository()
    Private kelasRepo As New KelasRepository()
    Private currentNis As String

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Public Async Sub LoadMuridData(nis As String, nama As String)
        currentNis = nis
        TextBox1.Text = nis
        TextBox3.Text = nama
        Await LoadKelasAktifAsync()
    End Sub

    Private Async Function LoadKelasAktifAsync() As Task
        Try
            ComboBox1.Items.Clear()
            Dim listKelas = Await kelasRepo.GetAllAsync()

            For Each kls In listKelas
                If kls.status Then
                    ComboBox1.Items.Add(kls.id_kelas)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data kelas: " & ex.Message)
        End Try
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Murid(parentForm))
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
           ComboBox1.SelectedItem Is Nothing OrElse
           String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Semua field wajib diisi.")
            Return
        End If

        Dim linkFoto As String = TextBox4.Text.Trim() ' TextBox4 = link GDrive opsional

        Dim data As New MuridModel With {
            .nama_siswa = TextBox3.Text.Trim(),
            .id_kelas = ComboBox1.SelectedItem.ToString(),
            .alamat = TextBox2.Text.Trim(),
            .link_foto = If(String.IsNullOrWhiteSpace(linkFoto), Nothing, linkFoto)
        }

        Try
            Await repo.UpdateAsync(currentNis, data)
            MessageBox.Show("Data murid berhasil diperbarui.", "Sukses")
            parentForm.ShowFormInPanel(New Murid(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui data murid: " & ex.Message)
        End Try
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        ' TextBox4 digunakan untuk link foto GDrive
    End Sub
End Class
