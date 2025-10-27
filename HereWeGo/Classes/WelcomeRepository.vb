Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Threading.Tasks

Public Class WelcomeRepository
    Private ReadOnly client As SupabaseClient
    Private Const ViewName As String = "v_presensi_rfid_detail"

    Public Sub New()
        client = New SupabaseClient()
    End Sub

    ' 🔹 Ambil data RFID terbaru
    Public Async Function GetLatestScanAsync() As Task(Of WelcomeModel)
        Try
            ' ambil data terakhir (limit 1)
            Dim json = Await client.GetAsync($"{ViewName}?order=waktu_scan.desc&limit=1")

            If String.IsNullOrWhiteSpace(json) OrElse json = "[]" Then
                Return Nothing
            End If

            Dim list = JsonConvert.DeserializeObject(Of List(Of WelcomeModel))(json)
            If list Is Nothing OrElse list.Count = 0 Then Return Nothing

            Return list(0)
        Catch ex As Exception
            Console.WriteLine($"❌ Gagal mengambil data RFID: {ex.Message}")
            Return Nothing
        End Try
    End Function
End Class
