Imports Newtonsoft.Json
Imports System.Security.Cryptography
Imports System.Text

Public Class PenggunaRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "akun"

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    ' 🔐 Hash Password
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    ' 🔹 Get semua pengguna
    Public Async Function GetAllAsync() As Task(Of List(Of PenggunaModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=id.asc")
        Return JsonConvert.DeserializeObject(Of List(Of PenggunaModel))(json)
    End Function

    ' 🔹 Tambah pengguna
    ' 🔹 Tambah pengguna (tanpa id dikirim)
    Public Async Function AddAsync(data As PenggunaModel) As Task
        data.password = HashPassword(data.password)

        ' Kirim hanya kolom yang diperlukan (tanpa id)
        Dim jsonBody = JsonConvert.SerializeObject(New With {
        .email = data.email,
        .password = data.password,
        .role = data.role,
        .status = data.status
    })

        Await _client.PostAsync(TableName, jsonBody)
    End Function

    ' 🔹 Update pengguna
    Public Async Function UpdateAsync(id As Integer, data As PenggunaModel) As Task
        data.password = HashPassword(data.password)
        Dim jsonBody = JsonConvert.SerializeObject(data)
        Await _client.PatchAsync($"{TableName}?id=eq.{id}", jsonBody)
    End Function

    ' 🔹 Hapus pengguna
    Public Async Function DeleteAsync(id As Integer) As Task
        Await _client.DeleteAsync($"{TableName}?id=eq.{id}")
    End Function
End Class
