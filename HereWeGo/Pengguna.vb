Public Class Pengguna
    Private parentForm As Admin

    ' Konstruktor menerima referensi ke form Admin
    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' Tombol Tambah
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tambah_Pengguna(parentForm))
    End Sub

    ' Tombol Ubah
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        parentForm.ShowFormInPanel(New Ubah_Pengguna(parentForm))
    End Sub
End Class
