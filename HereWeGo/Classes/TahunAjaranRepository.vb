Imports Newtonsoft.Json

Public Class TahunAjaranRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "tahun_ajaran"

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    ' 🔹 Ambil semua tahun ajaran (urut: aktif dulu)
    Public Async Function GetAllAsync() As Task(Of List(Of TahunAjaranModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,id_tahun.asc")
        Return JsonConvert.DeserializeObject(Of List(Of TahunAjaranModel))(json)
    End Function

    ' 🔹 Tambah tahun ajaran baru
    Public Async Function AddAsync(data As TahunAjaranModel) As Task
        data.status = True
        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .tahun_ajaran = data.tahun_ajaran,
            .semester = data.semester,
            .status = data.status
        })
        Await _client.PostAsync(TableName, jsonBody)
    End Function

    ' 🔹 Update tahun ajaran
    Public Async Function UpdateAsync(id_tahun As String, data As TahunAjaranModel) As Task
        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .tahun_ajaran = data.tahun_ajaran,
            .semester = data.semester
        })
        Await _client.PatchAsync($"{TableName}?id_tahun=eq.{id_tahun}", jsonBody)
    End Function

    ' 🔹 Nonaktifkan (hapus)
    Public Async Function DeactivateAsync(id_tahun As String) As Task(Of Boolean)
        Dim jsonBody = JsonConvert.SerializeObject(New With {.status = False})
        Dim response = Await _client.PatchAsync($"{TableName}?id_tahun=eq.{id_tahun}", jsonBody)

        ' Supabase sering mengembalikan [] meskipun sukses, jadi cek status response saja
        Return response IsNot Nothing AndAlso Not response.ToLower().Contains("error")
    End Function

    ' 🔹 Pagination
    Public Async Function GetPagedAsync(limit As Integer, offset As Integer) As Task(Of List(Of TahunAjaranModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,id_tahun.asc&limit={limit}&offset={offset}")
        Return JsonConvert.DeserializeObject(Of List(Of TahunAjaranModel))(json)
    End Function

    ' 🔹 Hitung total data
    Public Async Function GetCountAsync() As Task(Of Integer)
        Dim json = Await _client.GetAsync($"{TableName}?select=id_tahun")
        Dim list = JsonConvert.DeserializeObject(Of List(Of TahunAjaranModel))(json)
        Return list.Count
    End Function

    ' 🔍 Pencarian
    Public Async Function SearchPagedAsync(keyword As String, limit As Integer, offset As Integer) As Task(Of List(Of TahunAjaranModel))
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim query = $"{TableName}?select=*&or=(tahun_ajaran.ilike.{encodedKeyword},semester.ilike.{encodedKeyword})&order=status.desc,id_tahun.asc&limit={limit}&offset={offset}"
        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of TahunAjaranModel))(json)

        ' Filter manual untuk kata aktif/nonaktif
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

    ' 🔢 Hitung hasil pencarian
    Public Async Function GetSearchCountAsync(keyword As String) As Task(Of Integer)
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim query = $"{TableName}?select=id_tahun&or=(tahun_ajaran.ilike.{encodedKeyword},semester.ilike.{encodedKeyword})"
        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of TahunAjaranModel))(json)
        Return list.Count
    End Function
End Class
