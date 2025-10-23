Public Class Kelas
    Private parentForm As Admin

    ' Konstruktor menerima referensi ke Admin
    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' Tombol Tambah → tampilkan form Tambah_Kelas
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tambah_Kelas(parentForm))
    End Sub

    ' Tombol Ubah → tampilkan form Ubah_Kelas
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        parentForm.ShowFormInPanel(New Ubah_Kelas(parentForm))
    End Sub
End Class
