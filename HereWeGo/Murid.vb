Public Class Murid
    Private parentForm As Admin

    ' Konstruktor menerima referensi ke Admin
    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' Tombol Tambah
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tambah_Murid(parentForm))
    End Sub

    ' Tombol Ubah
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        parentForm.ShowFormInPanel(New Ubah_Murid(parentForm))
    End Sub
End Class
