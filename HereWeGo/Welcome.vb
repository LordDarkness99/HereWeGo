Public Class Welcome
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Buat instance form Login
        Dim formLogin As New Login()

        ' Tampilkan form Login
        formLogin.Show()

        ' Sembunyikan (atau tutup) form Welcome
        Me.Hide()
    End Sub
End Class
