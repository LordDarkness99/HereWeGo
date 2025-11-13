Imports Newtonsoft.Json

Public Class JadwalMapelRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "jadwal_mapel"

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    ' 🔹 Ambil semua jadwal mapel
    Public Async Function GetAllAsync() As Task(Of List(Of JadwalMapelModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,id_kelas.asc")
        Return JsonConvert.DeserializeObject(Of List(Of JadwalMapelModel))(json)
    End Function

    ' 🔹 Pagination
    Public Async Function GetPagedAsync(limit As Integer, offset As Integer) As Task(Of List(Of JadwalMapelModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,id_kelas.asc&limit={limit}&offset={offset}")
        Return JsonConvert.DeserializeObject(Of List(Of JadwalMapelModel))(json)
    End Function

    ' 🔹 Tambah jadwal mapel
    Public Async Function AddAsync(data As JadwalMapelModel) As Task
        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .id_kelas = data.id_kelas,
            .id_mapel = data.id_mapel,
            .nip = data.nip,
            .hari = data.hari,
            .jam_mulai = data.jam_mulai,
            .jam_selesai = data.jam_selesai,
            .status = True
        })
        Await _client.PostAsync(TableName, jsonBody)
    End Function

    ' 🔹 Update jadwal mapel
    Public Async Function UpdateAsync(id_jadwal As String, data As JadwalMapelModel) As Task
        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .id_kelas = data.id_kelas,
            .id_mapel = data.id_mapel,
            .nip = data.nip,
            .hari = data.hari,
            .jam_mulai = data.jam_mulai,
            .jam_selesai = data.jam_selesai
        })
        Await _client.PatchAsync($"{TableName}?id_jadwal=eq.{id_jadwal}", jsonBody)
    End Function

    ' 🔹 Nonaktifkan jadwal
    Public Async Function DeactivateAsync(id_jadwal As String) As Task(Of Boolean)
        Dim jsonBody = JsonConvert.SerializeObject(New With {.status = False})
        Dim response = Await _client.PatchAsync($"{TableName}?id_jadwal=eq.{id_jadwal}", jsonBody)
        Return Not (String.IsNullOrWhiteSpace(response) OrElse response.Contains("error"))
    End Function

    ' 🔹 Hitung total
    Public Async Function GetCountAsync() As Task(Of Integer)
        Dim json = Await _client.GetAsync($"{TableName}?select=id_jadwal")
        Dim list = JsonConvert.DeserializeObject(Of List(Of JadwalMapelModel))(json)
        Return list.Count
    End Function

    ' 🔍 Search berdasarkan id_kelas, id_mapel, nip, hari
    Public Async Function SearchPagedAsync(keyword As String, limit As Integer, offset As Integer) As Task(Of List(Of JadwalMapelModel))
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim query = $"{TableName}?select=*&or=(id_kelas.ilike.{encodedKeyword},id_mapel.ilike.{encodedKeyword},nip.ilike.{encodedKeyword},hari.ilike.{encodedKeyword})&order=status.desc,id_kelas.asc&limit={limit}&offset={offset}"
        Dim json = Await _client.GetAsync(query)
        Return JsonConvert.DeserializeObject(Of List(Of JadwalMapelModel))(json)
    End Function

    Public Async Function GetSearchCountAsync(keyword As String) As Task(Of Integer)
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim json = Await _client.GetAsync($"{TableName}?select=id_jadwal&or=(id_kelas.ilike.{encodedKeyword},id_mapel.ilike.{encodedKeyword},nip.ilike.{encodedKeyword},hari.ilike.{encodedKeyword})")
        Dim list = JsonConvert.DeserializeObject(Of List(Of JadwalMapelModel))(json)
        Return list.Count
    End Function
End Class
