Imports Newtonsoft.Json
Imports System.Threading.Tasks

Public Class Akun
    Public Property id As Integer
    Public Property email As String
    Public Property password As String
    Public Property role As String
    Public Property status As String

    Public Shared Async Function TambahAsync(email As String, password As String, role As String) As Task(Of Boolean)
        Dim data = New Dictionary(Of String, Object) From {
            {"email", email},
            {"password", password},
            {"role", role}
        }

        Dim jsonData = JsonConvert.SerializeObject(data)

        Try
            Dim result = Await SupabaseClient.PostAsync("akun", jsonData)
            Return True
        Catch ex As Exception
            MessageBox.Show("Gagal menambah akun: " & ex.Message)
            Return False
        End Try
    End Function
End Class
