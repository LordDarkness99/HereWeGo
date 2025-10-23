Public Class Tambah_Kelas
    Private parentForm As Admin

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' Tombol Batal → kembali ke form Kelas
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Kelas(parentForm))
    End Sub

    Private Sub Tambah_Kelas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
