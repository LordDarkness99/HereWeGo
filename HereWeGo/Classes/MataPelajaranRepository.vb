Imports Newtonsoft.Json

Public Class MataPelajaranRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "mapel"

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    ' 🔹 Ambil semua data mapel (aktif dulu)
    Public Async Function GetAllAsync() As Task(Of List(Of MataPelajaranModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,id_mapel.asc")
        Return JsonConvert.DeserializeObject(Of List(Of MataPelajaranModel))(json)
    End Function

    ' 🔹 Pagination
    Public Async Function GetPagedAsync(limit As Integer, offset As Integer) As Task(Of List(Of MataPelajaranModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,id_mapel.asc&limit={limit}&offset={offset}")
        Return JsonConvert.DeserializeObject(Of List(Of MataPelajaranModel))(json)
    End Function

    ' 🔹 Tambah mapel baru
    Public Async Function AddAsync(data As MataPelajaranModel) As Task
        data.status = True
        data.id_mapel = GenerateUniqueId()

        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .id_mapel = data.id_mapel,
            .nama_mapel = data.nama_mapel,
            .id_guru = data.id_guru,
            .status = data.status
        })
        Await _client.PostAsync(TableName, jsonBody)
    End Function

    ' 🔹 Ubah data mapel
    Public Async Function UpdateAsync(id_mapel As String, data As MataPelajaranModel) As Task
        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .nama_mapel = data.nama_mapel,
            .id_guru = data.id_guru
        })
        Await _client.PatchAsync($"{TableName}?id_mapel=eq.{id_mapel}", jsonBody)
    End Function

    ' 🔹 Nonaktifkan mapel
    Public Async Function DeactivateAsync(id_mapel As String) As Task(Of Boolean)
        Dim jsonBody = JsonConvert.SerializeObject(New With {.status = False})
        Dim response = Await _client.PatchAsync($"{TableName}?id_mapel=eq.{id_mapel}", jsonBody)
        Return Not (String.IsNullOrWhiteSpace(response) OrElse response.Contains("error"))
    End Function

    ' 🔹 Hitung total
    Public Async Function GetCountAsync() As Task(Of Integer)
        Dim json = Await _client.GetAsync($"{TableName}?select=id_mapel")
        Dim list = JsonConvert.DeserializeObject(Of List(Of MataPelajaranModel))(json)
        Return list.Count
    End Function

    ' 🔍 Pencarian
    Public Async Function SearchPagedAsync(keyword As String, limit As Integer, offset As Integer) As Task(Of List(Of MataPelajaranModel))
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim query = $"{TableName}?select=*&or=(id_mapel.ilike.{encodedKeyword},nama_mapel.ilike.{encodedKeyword})&limit={limit}&offset={offset}"
        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of MataPelajaranModel))(json)
        Return list
    End Function

    Public Async Function GetSearchCountAsync(keyword As String) As Task(Of Integer)
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim json = Await _client.GetAsync($"{TableName}?select=id_mapel&or=(id_mapel.ilike.{encodedKeyword},nama_mapel.ilike.{encodedKeyword})")
        Dim list = JsonConvert.DeserializeObject(Of List(Of MataPelajaranModel))(json)
        Return list.Count
    End Function

    Private Function GenerateUniqueId() As String
        Dim prefix = "MAP"
        Dim tanggal = Date.Now.ToString("yyyyMMdd")
        Dim random = New Random().Next(100, 999).ToString()
        Return $"{prefix}{tanggal}{random}"
    End Function
End Class
