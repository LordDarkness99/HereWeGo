Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class UtilityRepository
    Private ReadOnly _client As SupabaseClient

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    ' Menjalankan function generate_presensi_harian() di PostgreSQL
    Public Async Function GeneratePresensiHarianAsync() As Task(Of Boolean)
        Try
            Dim endpoint As String = "rpc/generate_presensi_harian"

            ' RPC Supabase harus POST dan mengirim body JSON kosong
            Dim body As String = "{}"

            Dim result = Await _client.PostAsync(endpoint, body)

            ' Jika tidak error, selalu berhasil
            Return True

        Catch ex As Exception
            MessageBox.Show("Gagal menjalankan generate_presensi_harian(): " & ex.Message)
            Return False
        End Try
    End Function
End Class
