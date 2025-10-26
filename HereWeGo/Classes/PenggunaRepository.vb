Imports Newtonsoft.Json
Imports System.Security.Cryptography
Imports System.Text

Public Class PenggunaRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "akun"

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    ' 🔒 Hash password (SHA256)
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

    ' 🔹 Ambil semua data pengguna (urut: aktif dulu, lalu terbaru)
    Public Async Function GetAllAsync() As Task(Of List(Of PenggunaModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,id_user.asc")
        Return JsonConvert.DeserializeObject(Of List(Of PenggunaModel))(json)
    End Function

    ' 🔹 Tambah pengguna baru
    Public Async Function AddAsync(data As PenggunaModel) As Task
        data.password = HashPassword(data.password)
        data.id_user = GenerateUniqueUserCode()
        data.status = True

        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .id_user = data.id_user,
            .email = data.email,
            .password = data.password,
            .role = data.role,
            .status = data.status
        })

        Await _client.PostAsync(TableName, jsonBody)
    End Function

    ' 🔹 Ubah data pengguna (email, password, role)
    Public Async Function UpdateAsync(id_user As String, data As PenggunaModel) As Task
        data.password = HashPassword(data.password)

        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .email = data.email,
            .password = data.password,
            .role = data.role
        })

        Await _client.PatchAsync($"{TableName}?id_user=eq.{id_user}", jsonBody)
    End Function

    ' 🔹 Nonaktifkan pengguna
    Public Async Function DeactivateAsync(id_user As String) As Task(Of Boolean)
        Dim jsonBody = JsonConvert.SerializeObject(New With {.status = False})
        Dim response = Await _client.PatchAsync($"{TableName}?id_user=eq.{id_user}", jsonBody)

        If Not String.IsNullOrWhiteSpace(response) AndAlso Not response.Contains("error") Then
            Return True
        Else
            Return False
        End If
    End Function


    ' 🔹 Generate kode user unik (contoh: USR20251024001)
    Private Function GenerateUniqueUserCode() As String
        Dim prefix = "USR"
        Dim tanggal = Date.Now.ToString("yyyyMMdd")
        Dim random = New Random().Next(100, 999).ToString()
        Return $"{prefix}{tanggal}{random}"
    End Function

    ' 🔹 Ambil pengguna per halaman (aktif dulu, lalu terbaru)
    Public Async Function GetPagedAsync(limit As Integer, offset As Integer) As Task(Of List(Of PenggunaModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,id_user.asc&limit={limit}&offset={offset}")
        Return JsonConvert.DeserializeObject(Of List(Of PenggunaModel))(json)
    End Function

    ' 🔹 Hitung total data
    Public Async Function GetCountAsync() As Task(Of Integer)
        Dim json = Await _client.GetAsync($"{TableName}?select=id_user")
        Dim list = JsonConvert.DeserializeObject(Of List(Of PenggunaModel))(json)
        Return list.Count
    End Function

    ' 🔍 Pencarian (urut: aktif dulu, lalu terbaru)
    Public Async Function SearchPagedAsync(keyword As String, limit As Integer, offset As Integer) As Task(Of List(Of PenggunaModel))
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim query = $"{TableName}?select=*&or=(id_user.ilike.{encodedKeyword},email.ilike.{encodedKeyword},role.ilike.{encodedKeyword})&order=status.desc,id_user.asc&limit={limit}&offset={offset}"


        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of PenggunaModel))(json)

        ' Filter manual jika keyword = "aktif" atau "nonaktif"
        Return list.Where(Function(u)
                              If keyword.ToLower() = "aktif" Then
                                  Return u.status = True
                              ElseIf keyword.ToLower() = "nonaktif" Then
                                  Return u.status = False
                              Else
                                  Return True
                              End If
                          End Function).ToList()
    End Function

    ' 🔢 Hitung total hasil pencarian
    Public Async Function GetSearchCountAsync(keyword As String) As Task(Of Integer)
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim query = $"{TableName}?select=id_user&or=(id_user.ilike.{encodedKeyword},email.ilike.{encodedKeyword},role.ilike.{encodedKeyword})"
        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of PenggunaModel))(json)

        ' Filter status manual juga
        Dim filtered = list.Where(Function(u)
                                      Dim statusText = If(u.status, "aktif", "nonaktif")
                                      Return statusText.ToLower().Contains(keyword.ToLower())
                                  End Function).ToList()

        list.AddRange(filtered.Where(Function(u) Not list.Any(Function(x) x.id_user = u.id_user)))
        Return list.Count
    End Function

End Class
