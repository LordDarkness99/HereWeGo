Public Class Welcome
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New Login()
        f.Show()          ' Tampilkan form Login
        Me.Hide()         ' Sembunyikan form Welcome
    End Sub
End Class