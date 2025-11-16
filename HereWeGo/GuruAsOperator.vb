Public Class guruAsOperator
    Private ParentForm As Admin
    Private activeButton As Button = Nothing

    ' Constructor dengan parameter parent (Admin)
    Public Sub New(parent As Admin)
        InitializeComponent()
        ParentForm = parent
    End Sub

    ' Constructor tanpa parameter (opsional untuk desain form)
    Public Sub New()
        InitializeComponent()
    End Sub

    ' 🔹 Menampilkan form di Panel2
    Public Sub ShowFormInPanel(frm As Form)
        Panel2.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        Panel2.Controls.Add(frm)
        frm.Show()
    End Sub

    ' 🔹 Tombol Presensi (buka form Presensi_Operator)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SetActiveButton(Button2)
        ShowFormInPanel(New Presensi_Operator(Me))
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetActiveButton(Button1)
        ShowFormInPanel(New Laporan_Operator(Me))
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        SetActiveButton(Button10)

        ' Konfirmasi logout
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            ' Tampilkan form login dan tutup form admin
            Dim login As New Login()
            login.Show()
            Me.Close()
        End If
    End Sub

    Sub StyleSidebarButton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.FromArgb(25, 25, 112) ' warna sidebar dasar
        btn.ForeColor = Color.FromArgb(224, 230, 237)
        btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btn.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    Private Sub SidebarButton_MouseEnter(sender As Object, e As EventArgs) Handles _
    Button1.MouseEnter, Button2.MouseEnter
        If sender IsNot activeButton Then
            sender.BackColor = Color.FromArgb(41, 121, 255)
        End If
    End Sub

    Private Sub SidebarButton_MouseLeave(sender As Object, e As EventArgs) Handles _
    Button1.MouseLeave, Button2.MouseLeave
        If sender IsNot activeButton Then
            sender.BackColor = Color.FromArgb(25, 25, 112)
        End If
    End Sub

    Private Sub ButtonLogout_MouseEnter(sender As Object, e As EventArgs) Handles Button10.MouseEnter
        If sender IsNot activeButton Then
            sender.BackColor = Color.FromArgb(255, 82, 82)
        End If
    End Sub

    Private Sub ButtonLogout_MouseLeave(sender As Object, e As EventArgs) Handles Button10.MouseLeave
        If sender IsNot activeButton Then
            sender.BackColor = Color.FromArgb(25, 25, 112)
        End If
    End Sub

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StyleSidebarButton(Button1)
        StyleSidebarButton(Button2)
        StyleSidebarButton(Button10)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        ' Reset semua tombol di panel sidebar
        For Each ctrl As Control In Panel1.Controls
            If TypeOf ctrl Is Button Then
                ctrl.BackColor = Color.FromArgb(25, 25, 112) ' warna sidebar dasar
                ctrl.ForeColor = Color.FromArgb(224, 230, 237)
            End If
        Next

        ' Jika tombol logout ditekan, warnanya tetap merah
        If btn Is Button10 Then
            btn.BackColor = Color.FromArgb(255, 82, 82) ' merah
            btn.ForeColor = Color.White
            activeButton = btn
            Exit Sub
        End If

        ' Tombol lain tetap biru saat aktif
        activeButton = btn
        btn.BackColor = Color.FromArgb(41, 121, 255)
        btn.ForeColor = Color.White
    End Sub

End Class
