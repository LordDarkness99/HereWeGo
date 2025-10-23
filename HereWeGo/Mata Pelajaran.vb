Public Class Mata_Pelajaran
    Private parentForm As Admin

    ' Konstruktor menerima referensi ke Admin
    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' Tombol Tambah → buka form Tambah_Mata_Pelajaran
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Tambah_Mata_Pelajaran(parentForm))
    End Sub

    ' Tombol Ubah → buka form Ubah_Mata_Pelajaran
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        parentForm.ShowFormInPanel(New Ubah_Mata_Pelajaran(parentForm))
    End Sub
End Class
