Public Class Admin
    ' Fungsi untuk menampilkan form di dalam panel
    Private Sub ShowFormInPanel(frm As Form)
        ' Hapus kontrol sebelumnya di panel
        Panel2.Controls.Clear()

        ' Siapkan form agar bisa ditampilkan di dalam panel
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill

        ' Tambahkan ke panel
        Panel2.Controls.Add(frm)
        frm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New Pengguna()
        ShowFormInPanel(f)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
