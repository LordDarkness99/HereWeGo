Public Class guruAsOperator
    Private ParentForm As Admin

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
        ShowFormInPanel(New Presensi_Operator(Me))
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
    End Sub
End Class
