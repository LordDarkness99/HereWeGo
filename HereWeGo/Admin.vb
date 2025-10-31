Public Class Admin
    ' Method umum untuk menampilkan form di dalam Panel2
    ' Simpan tombol yang sedang aktif
    Private activeButton As Button = Nothing
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
        SetActiveButton(Button2)
        ShowFormInPanel(New Pengguna(Me))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetActiveButton(Button1)
        ShowFormInPanel(New Guru(Me))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SetActiveButton(Button3)
        ShowFormInPanel(New Kelas(Me))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SetActiveButton(Button4)
        ShowFormInPanel(New Mata_Pelajaran(Me))
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SetActiveButton(Button5)
        ShowFormInPanel(New Murid(Me))
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SetActiveButton(Button6)
        ShowFormInPanel(New Tahun_Ajaran(Me))
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SetActiveButton(Button7)
        ShowFormInPanel(New Rfid(Me))
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SetActiveButton(Button8)
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        SetActiveButton(Button9)
    End Sub

    Sub StyleSidebarButton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.FromArgb(30, 42, 56) ' warna sidebar dasar
        btn.ForeColor = Color.FromArgb(224, 230, 237)
        btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btn.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    Private Sub SidebarButton_MouseEnter(sender As Object, e As EventArgs) Handles _
    Button1.MouseEnter, Button2.MouseEnter, Button3.MouseEnter, Button4.MouseEnter, Button5.MouseEnter, Button6.MouseEnter, Button7.MouseEnter, Button8.MouseEnter, Button9.MouseEnter
        If sender IsNot activeButton Then
            sender.BackColor = Color.FromArgb(41, 121, 255)
        End If
    End Sub

    Private Sub SidebarButton_MouseLeave(sender As Object, e As EventArgs) Handles _
    Button1.MouseLeave, Button2.MouseLeave, Button3.MouseLeave, Button4.MouseLeave, Button5.MouseLeave, Button6.MouseLeave, Button7.MouseLeave, Button8.MouseLeave, Button9.MouseLeave
        If sender IsNot activeButton Then
            sender.BackColor = Color.FromArgb(30, 42, 56)
        End If
    End Sub

    Private SidebarTextColor As Color = Color.FromArgb(224, 230, 237)
    Private SidebarTextActiveColor As Color = Color.FromArgb(240, 240, 240)

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StyleSidebarButton(Button1)
        StyleSidebarButton(Button2)
        StyleSidebarButton(Button3)
        StyleSidebarButton(Button4)
        StyleSidebarButton(Button5)
        StyleSidebarButton(Button6)
        StyleSidebarButton(Button7)
        StyleSidebarButton(Button8)
        StyleSidebarButton(Button9)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        ' Reset semua tombol di panel sidebar
        For Each ctrl As Control In Panel1.Controls
            If TypeOf ctrl Is Button Then
                ctrl.BackColor = Color.FromArgb(30, 42, 56) ' warna sidebar dasar
                ctrl.ForeColor = Color.FromArgb(224, 230, 237)
            End If
        Next

        ' Tandai tombol aktif
        activeButton = btn
        btn.BackColor = Color.FromArgb(41, 121, 255) ' warna aktif biru terang
        btn.ForeColor = Color.White
    End Sub

End Class