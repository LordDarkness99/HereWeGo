Imports System.Threading.Tasks

Public Class Tambah_Kelas
    Private parentForm As Admin
    Private repo As New KelasRepository()

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                MessageBox.Show("Nama kelas wajib diisi.")
                Return
            End If

            Dim namaBaru = TextBox1.Text.Trim()

            ' 🔹 Cek apakah ada kelas aktif lain dengan nama sama
            Dim allKelas = Await repo.GetAllAsync()
            Dim duplikat = allKelas.Any(Function(k)
                                            Return k.nama_kelas.Equals(namaBaru, StringComparison.OrdinalIgnoreCase) _
                                            AndAlso k.status = True
                                        End Function)

            If duplikat Then
                MessageBox.Show("Nama kelas sudah digunakan oleh kelas aktif lain.", "Data Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' 🔹 Kelas baru selalu aktif
            Dim kelas As New KelasModel With {
            .nama_kelas = namaBaru,
            .status = True
        }

            Await repo.AddAsync(kelas)
            MessageBox.Show("Kelas berhasil ditambahkan dan otomatis aktif.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            parentForm.ShowFormInPanel(New Kelas(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal menambah kelas: " & ex.Message)
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Kelas(parentForm))
    End Sub
End Class
