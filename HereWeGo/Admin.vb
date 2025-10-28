Public Class Admin
    ' Method umum untuk menampilkan form di dalam Panel2
    Public Sub ShowFormInPanel(frm As Form)
        Panel2.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        Panel2.Controls.Add(frm)
        frm.Show()
    End Sub

    ' Tombol untuk membuka Form Pengguna
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ShowFormInPanel(New Pengguna(Me))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ShowFormInPanel(New Guru(Me))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ShowFormInPanel(New Kelas(Me))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ShowFormInPanel(New Mata_Pelajaran(Me))
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ShowFormInPanel(New Murid(Me))
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ShowFormInPanel(New Tahun_Ajaran(Me))
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ShowFormInPanel(New Rfid(Me))
    End Sub

End Class
