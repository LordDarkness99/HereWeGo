Imports System.Threading.Tasks
Imports System.Security.Cryptography
Imports System.Text

Public Class Login
    Private repo As New PenggunaRepository()

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim email = TextBox1.Text.Trim()
            Dim password = TextBox2.Text.Trim()

            ' 🔸 Validasi input
            If String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(password) Then
                MessageBox.Show("Email dan password wajib diisi.")
                Return
            End If

            ' 🔸 Ambil semua akun dari database
            Dim semuaAkun = Await repo.GetAllAsync()
            Dim akun = semuaAkun.FirstOrDefault(Function(a) a.email.Equals(email, StringComparison.OrdinalIgnoreCase))

            If akun Is Nothing Then
                MessageBox.Show("Email tidak ditemukan.")
                Return
            End If

            ' 🔸 Cek apakah akun aktif
            If Not akun.status Then
                MessageBox.Show("Akun Anda tidak aktif. Hubungi admin.")
                Return
            End If

            ' 🔸 Verifikasi password (SHA256)
            Dim hashedInput = HashPassword(password)
            If akun.password <> hashedInput Then
                MessageBox.Show("Password salah.")
                Return
            End If

            ' 🔸 Login sukses: arahkan berdasarkan role
            MessageBox.Show($"Login berhasil sebagai {akun.role}!", "Sukses")

            Select Case akun.role.ToLower()
                Case "admin"
                    Dim frmAdmin As New Admin()
                    frmAdmin.Show()
                    Me.Hide()
                Case "guru"
                    Dim frmGuru As New GuruAsOperator()
                    frmGuru.Show()
                    Me.Hide()
                Case Else
                    MessageBox.Show("Role tidak dikenali. Hubungi admin sistem.")
            End Select

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat login: " & ex.Message)
        End Try
    End Sub

    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub
End Class
