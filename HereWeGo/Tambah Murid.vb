Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Tambah_Murid
    Private parentForm As Admin
    Private repo As New MuridRepository()
    Private kelasRepo As New KelasRepository()

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Async Sub Tambah_Murid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        ' Validasi input — semua wajib diisi kecuali NIS otomatis
        If String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
           ComboBox1.SelectedItem Is Nothing OrElse
           String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Semua field wajib diisi (kecuali NIS, karena otomatis).")
            Return
        End If

        Dim linkFoto As String = TextBox1.Text.Trim() ' input link GDrive opsional

        Dim data As New MuridModel With {
            .nama_siswa = TextBox3.Text.Trim(),
            .id_kelas = ComboBox1.SelectedItem.ToString(),
            .alamat = TextBox2.Text.Trim(),
            .link_foto = If(String.IsNullOrWhiteSpace(linkFoto), Nothing, linkFoto),
            .status = True
        }

        Try
            Await repo.AddAsync(data)
            MessageBox.Show("Data murid berhasil disimpan!", "Sukses")
            parentForm.ShowFormInPanel(New Murid(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data murid: " & ex.Message)
        End Try
    End Sub

    ' TextBox1 = Link Foto GDrive
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    End Sub
End Class
