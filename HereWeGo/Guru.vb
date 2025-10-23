Public Class Guru
    Private parentForm As Admin

    ' Konstruktor: menerima referensi ke Admin
    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' Tombol Tambah Guru
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tambah_Guru(parentForm))
    End Sub

    ' Tombol Ubah Guru
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        parentForm.ShowFormInPanel(New Ubah_Guru(parentForm))
    End Sub
End Class
