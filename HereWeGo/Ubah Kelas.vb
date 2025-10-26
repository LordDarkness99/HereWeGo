Imports System.Threading.Tasks

Public Class Ubah_Kelas
    Private parentForm As Admin
    Private repo As New KelasRepository()
    Private currentId As String

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' 🔹 Load hanya id dan nama kelas, tanpa status edit
    Public Sub LoadKelasData(id_kelas As String, nama_kelas As String, status As Boolean)
        currentId = id_kelas
        TextBox1.Text = id_kelas
        TextBox1.ReadOnly = True
        TextBox2.Text = nama_kelas

        ' Tampilkan status hanya sebagai label agar tidak bisa diubah
        'LabelStatus.Text = If(status, "Status: Aktif", "Status: Nonaktif")
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If String.IsNullOrWhiteSpace(TextBox2.Text) Then
                MessageBox.Show("Nama kelas wajib diisi.")
                Return
            End If

            ' 🔹 Ambil semua kelas untuk cek duplikasi
            Dim allKelas = Await repo.GetAllAsync()
            Dim namaBaru = TextBox2.Text.Trim()

            ' Cek apakah ada kelas aktif lain dengan nama yang sama
            Dim duplikat = allKelas.Any(Function(k)
                                            Return k.nama_kelas.Equals(namaBaru, StringComparison.OrdinalIgnoreCase) _
                                                AndAlso k.status = True _
                                                AndAlso k.id_kelas <> currentId
                                        End Function)

            If duplikat Then
                MessageBox.Show("Nama kelas sudah digunakan oleh kelas aktif lain.", "Data Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' 🔹 Lanjut update nama kelas
            Dim data As New KelasModel With {
                .nama_kelas = namaBaru
            }

            Await repo.UpdateAsync(currentId, data)
            MessageBox.Show("Nama kelas berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            parentForm.ShowFormInPanel(New Kelas(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal mengubah data kelas: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Kelas(parentForm))
    End Sub
End Class
