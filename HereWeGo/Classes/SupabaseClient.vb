Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading.Tasks

Public Class SupabaseClient
    Private Shared ReadOnly baseUrl As String = "https://lcfsixhzrozwedxxtgig.supabase.co"
    Private Shared ReadOnly apiKey As String = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImxjZnNpeGh6cm96d2VkeHh0Z2lnIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTg1ODU0NTMsImV4cCI6MjA3NDE2MTQ1M30.wP6f3qwMg4idomxm_Y-RlJNWy7qoO37bzJs0_fEMb5A" ' ANON KEY

    Private Shared ReadOnly httpClient As HttpClient = New HttpClient()

    Shared Sub New()
        httpClient.DefaultRequestHeaders.Add("apikey", apiKey)
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " & apiKey)
        httpClient.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
    End Sub

    Public Shared Async Function PostAsync(endpoint As String, jsonData As String) As Task(Of String)
        Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")
        Dim response = Await httpClient.PostAsync($"{baseUrl}/rest/v1/{endpoint}", content)
        Dim responseText = Await response.Content.ReadAsStringAsync()
        If Not response.IsSuccessStatusCode Then
            Throw New Exception($"Supabase error: {response.StatusCode} - {responseText}")
        End If
        Return responseText
    End Function

    Public Shared Async Function GetAsync(endpoint As String) As Task(Of String)
        Dim response = Await httpClient.GetAsync($"{baseUrl}/rest/v1/{endpoint}")
        Dim responseText = Await response.Content.ReadAsStringAsync()
        If Not response.IsSuccessStatusCode Then
            Throw New Exception($"Supabase error: {response.StatusCode} - {responseText}")
        End If
        Return responseText
    End Function
End Class
