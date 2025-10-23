Public Class Ubah_Mata_Pelajaran
    Private parentForm As Admin

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' Tombol Batal → kembali ke form Mata_Pelajaran
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Mata_Pelajaran(parentForm))
    End Sub
End Class
