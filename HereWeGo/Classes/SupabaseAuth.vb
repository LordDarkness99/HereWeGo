Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class SupabaseAuth
    Private Shared ReadOnly baseUrl As String = "https://lcfsixhzrozwedxxtgig.supabase.co"
    Private Shared ReadOnly apiKey As String = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImxjZnNpeGh6cm96d2VkeHh0Z2lnIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTg1ODU0NTMsImV4cCI6MjA3NDE2MTQ1M30.wP6f3qwMg4idomxm_Y-RlJNWy7qoO37bzJs0_fEMb5A"

    Public Shared Async Function TambahUserAsync(email As String, password As String) As Task(Of Boolean)
        Dim json = JsonConvert.SerializeObject(New With {
            .email = email,
            .password = password
        })
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Using client As New HttpClient()
            client.DefaultRequestHeaders.Add("apikey", apiKey)
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " & apiKey)

            Dim response = Await client.PostAsync($"{baseUrl}/auth/v1/signup", content)
            Return response.IsSuccessStatusCode
        End Using
    End Function
End Class
