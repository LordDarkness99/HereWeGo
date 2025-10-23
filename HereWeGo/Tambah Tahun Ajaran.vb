Public Class Tambah_Tahun_Ajaran
    Private parentForm As Admin

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' Tombol Batal → kembali ke form Guru
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tahun_Ajaran(parentForm))
    End Sub
End Class