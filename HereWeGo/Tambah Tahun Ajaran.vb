Imports System.Threading.Tasks

Public Class Tambah_Tahun_Ajaran
    Private parentForm As Admin
    Private repo As New TahunAjaranRepository()

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tahun_Ajaran(parentForm))
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If String.IsNullOrWhiteSpace(TextBox3.Text) OrElse ComboBox1.SelectedItem Is Nothing Then
                MessageBox.Show("Tahun ajaran dan semester wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim tahunBaru = TextBox3.Text.Trim()
            Dim semesterBaru = ComboBox1.SelectedItem.ToString().Trim()

            ' Validasi semester (hanya Ganjil/Genap)
            If Not (semesterBaru.Equals("Ganjil", StringComparison.OrdinalIgnoreCase) OrElse semesterBaru.Equals("Genap", StringComparison.OrdinalIgnoreCase)) Then
                MessageBox.Show("Semester harus 'Ganjil' atau 'Genap'.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Ambil semua data tahun ajaran
            Dim semuaData = Await repo.GetAllAsync()

            ' 1) Cek apakah sudah ada tahun ajaran aktif dengan kombinasi tahun+semester yang sama
            Dim aktifSama = semuaData.Any(Function(x)
                                              Return x.status = True _
                                                     AndAlso x.tahun_ajaran.Equals(tahunBaru, StringComparison.OrdinalIgnoreCase) _
                                                     AndAlso x.semester.Equals(semesterBaru, StringComparison.OrdinalIgnoreCase)
                                          End Function)
            If aktifSama Then
                MessageBox.Show($"Tidak dapat menambah: Tahun ajaran '{tahunBaru}' semester '{semesterBaru}' sudah aktif.", "Duplikasi Aktif", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' 2) Cek apakah ada duplikasi (tahun+semester) tetapi non-aktif — ini diperbolehkan
            Dim pernahAdaNonAktif = semuaData.Any(Function(x)
                                                      Return x.status = False _
                                                             AndAlso x.tahun_ajaran.Equals(tahunBaru, StringComparison.OrdinalIgnoreCase) _
                                                             AndAlso x.semester.Equals(semesterBaru, StringComparison.OrdinalIgnoreCase)
                                                  End Function)
            If pernahAdaNonAktif Then
                ' opsional: tanyakan konfirmasi sebelum menambah lagi (karena sebelumnya nonaktif)
                Dim res = MessageBox.Show($"Terdapat entri tahun ajaran {tahunBaru} semester {semesterBaru} yang pernah dibuat namun non-aktif. " &
                                          "Apakah Anda tetap ingin menambahkan sebagai tahun ajaran baru dan mengaktifkannya?",
                                          "Konfirmasi Tambah", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If res = DialogResult.No Then
                    Return
                End If
            End If

            ' 3) Cek jika ada entri aktif dengan tahun sama tetapi semester berbeda --> diperbolehkan.
            '    (tidak ada batasan lain menurut spesifikasi)

            ' Tambahkan data baru dan set aktif
            Dim data As New TahunAjaranModel With {
                .tahun_ajaran = tahunBaru,
                .semester = If(semesterBaru.Equals("Ganjil", StringComparison.OrdinalIgnoreCase), "Ganjil", "Genap"),
                .status = True
            }

            Await repo.AddAsync(data)

            MessageBox.Show("Data tahun ajaran berhasil ditambahkan dan diaktifkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            parentForm.ShowFormInPanel(New Tahun_Ajaran(parentForm))

        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
