Public Class Ubah_Pengguna
    Private parentForm As Admin

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' Tombol Batal
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Pengguna(parentForm))
    End Sub
End Class
