Imports System.Threading.Tasks

Public Class Ubah_Rfid
    Private parentForm As Admin
    Private repo As New RfidRepository()
    Private currentRfidId As String

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Public Sub LoadRfidData(rfid_id As String, nis As String)
        currentRfidId = rfid_id
        TextBox1.Text = rfid_id
        TextBox1.ReadOnly = True
        TextBox2.Text = nis
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(New String() {"Aktif", "Nonaktif"})
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'simpan
        Try
            If String.IsNullOrWhiteSpace(TextBox2.Text) OrElse ComboBox1.SelectedItem Is Nothing Then
                MessageBox.Show("NIS dan Status wajib diisi.")
                Return
            End If

            Dim data As New RfidModel With {
                .nis = TextBox2.Text.Trim(),
                .status = (ComboBox1.SelectedItem.ToString() = "Aktif")
            }

            Await repo.UpdateAsync(currentRfidId, data)
            MessageBox.Show("Data RFID berhasil diubah.", "Sukses")
            parentForm.ShowFormInPanel(New Rfid(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal mengubah data RFID: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'batal
        parentForm.ShowFormInPanel(New Rfid(parentForm))
    End Sub
End Class
