Imports System.Threading.Tasks

Public Class Ubah_Tahun_Ajaran
    Private parentForm As Admin
    Private repo As New TahunAjaranRepository()
    Private currentId As String

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Public Async Sub LoadData(id As String)
        currentId = id
        Dim list = Await repo.GetAllAsync()
        Dim data = list.FirstOrDefault(Function(x) x.id_tahun = id)

        If data IsNot Nothing Then
            TextBox1.Text = data.id_tahun
            TextBox3.Text = data.tahun_ajaran
            TextBox4.Text = data.semester
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tahun_Ajaran(parentForm))
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(TextBox4.Text) Then
                MessageBox.Show("Semua field wajib diisi.")
                Return
            End If

            Dim tahunBaru = TextBox3.Text.Trim()
            Dim semesterBaru = TextBox4.Text.Trim()

            ' Ambil semua data tahun ajaran
            Dim semuaData = Await repo.GetAllAsync()

            ' Cek duplikasi pada data aktif (kecuali id yang sedang diubah)
            Dim duplikatAktif = semuaData.Any(Function(x)
                                                  Return x.tahun_ajaran.Equals(tahunBaru, StringComparison.OrdinalIgnoreCase) _
                                                      AndAlso x.semester.Equals(semesterBaru, StringComparison.OrdinalIgnoreCase) _
                                                      AndAlso x.status = True _
                                                      AndAlso x.id_tahun <> currentId
                                              End Function)

            If duplikatAktif Then
                MessageBox.Show($"Tahun ajaran {tahunBaru} semester {semesterBaru} sudah digunakan oleh data aktif lain.", "Duplikasi Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Update data
            Dim data As New TahunAjaranModel With {
                .tahun_ajaran = tahunBaru,
                .semester = semesterBaru
            }

            Await repo.UpdateAsync(currentId, data)
            MessageBox.Show("Data berhasil diperbarui.", "Sukses")
            parentForm.ShowFormInPanel(New Tahun_Ajaran(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui data: " & ex.Message)
        End Try
    End Sub
End Class
