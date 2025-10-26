Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks

Public Class SupabaseClient
    Private ReadOnly _url As String = "https://zlguyrxjkdmmcexyjjxg.supabase.co"
    Private ReadOnly _anonKey As String = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InpsZ3V5cnhqa2RtbWNleHlqanhnIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTg2OTUyMTIsImV4cCI6MjA3NDI3MTIxMn0.848TLaIbvHzvIM1Q-cYjsj4fwpl3f5GZ8N_cGHqcJQk"
    Private ReadOnly _client As HttpClient

    Public Sub New()
        _client = New HttpClient()
        _client.DefaultRequestHeaders.Add("apikey", _anonKey)
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " & _anonKey)
        _client.DefaultRequestHeaders.Add("Accept-Profile", "public")
        _client.DefaultRequestHeaders.Add("Content-Profile", "public")
    End Sub

    Public Async Function GetAsync(endpoint As String) As Task(Of String)
        Try
            Dim fullUrl = $"{_url}/rest/v1/{endpoint}"
            Console.WriteLine("GET: " & fullUrl)

            Dim response = Await _client.GetAsync(fullUrl)
            Dim content = Await response.Content.ReadAsStringAsync()

            If Not response.IsSuccessStatusCode Then
                Throw New Exception($"Error {response.StatusCode}: {content}")
            End If

            Return content
        Catch ex As Exception
            MessageBox.Show("GET Error: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Async Function PostAsync(endpoint As String, jsonBody As String) As Task(Of String)
        Try
            Dim fullUrl = $"{_url}/rest/v1/{endpoint}"
            Console.WriteLine("POST: " & fullUrl)

            Dim content = New StringContent(jsonBody, Encoding.UTF8, "application/json")
            Dim response = Await _client.PostAsync(fullUrl, content)
            Dim result = Await response.Content.ReadAsStringAsync()

            If Not response.IsSuccessStatusCode Then
                Throw New Exception($"Error {response.StatusCode}: {result}")
            End If

            Return result
        Catch ex As Exception
            MessageBox.Show("POST Error: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Async Function PatchAsync(endpoint As String, jsonBody As String) As Task(Of String)
        Try
            Dim fullUrl = $"{_url}/rest/v1/{endpoint}"
            Console.WriteLine("PATCH: " & fullUrl)

            Dim request = New HttpRequestMessage(HttpMethod.Patch, fullUrl) With {
                .Content = New StringContent(jsonBody, Encoding.UTF8, "application/json")
            }

            Dim response = Await _client.SendAsync(request)
            Dim result = Await response.Content.ReadAsStringAsync()

            If Not response.IsSuccessStatusCode Then
                Throw New Exception($"Error {response.StatusCode}: {result}")
            End If

            Return result
        Catch ex As Exception
            MessageBox.Show("PATCH Error: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Async Function DeleteAsync(endpoint As String) As Task(Of String)
        Try
            Dim fullUrl = $"{_url}/rest/v1/{endpoint}"
            Console.WriteLine("DELETE: " & fullUrl)

            Dim response = Await _client.DeleteAsync(fullUrl)
            Dim result = Await response.Content.ReadAsStringAsync()

            If Not response.IsSuccessStatusCode Then
                Throw New Exception($"Error {response.StatusCode}: {result}")
            End If

            Return result
        Catch ex As Exception
            MessageBox.Show("DELETE Error: " & ex.Message)
            Return Nothing
        End Try
    End Function

End Class
