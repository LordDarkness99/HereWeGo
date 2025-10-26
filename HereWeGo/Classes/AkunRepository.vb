Imports Newtonsoft.Json
Imports System.Threading.Tasks

Public Class AkunRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "akun"

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    Public Async Function GetByEmailAsync(email As String) As Task(Of AkunModel)
        Dim encodedEmail = Uri.EscapeDataString(email)
        Dim json = Await _client.GetAsync($"{TableName}?select=*&email=eq.{encodedEmail}")
        Dim list = JsonConvert.DeserializeObject(Of List(Of AkunModel))(json)
        Return list.FirstOrDefault()
    End Function
End Class
