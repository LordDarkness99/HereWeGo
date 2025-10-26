Imports Newtonsoft.Json

Public Class KelasRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "kelas"

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    ' 🔹 Ambil semua data kelas (aktif dulu)
    Public Async Function GetAllAsync() As Task(Of List(Of KelasModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,id_kelas.asc")
        Return JsonConvert.DeserializeObject(Of List(Of KelasModel))(json)
    End Function

    ' 🔹 Pagination
    Public Async Function GetPagedAsync(limit As Integer, offset As Integer) As Task(Of List(Of KelasModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,id_kelas.asc&limit={limit}&offset={offset}")
        Return JsonConvert.DeserializeObject(Of List(Of KelasModel))(json)
    End Function

    ' 🔹 Tambah kelas baru
    Public Async Function AddAsync(data As KelasModel) As Task
        data.status = True
        data.id_kelas = GenerateUniqueId()

        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .id_kelas = data.id_kelas,
            .nama_kelas = data.nama_kelas,
            .status = data.status
        })
        Await _client.PostAsync(TableName, jsonBody)
    End Function

    ' 🔹 Ubah kelas
    Public Async Function UpdateAsync(id_kelas As String, data As KelasModel) As Task
        Dim jsonBody = JsonConvert.SerializeObject(New With {
        .nama_kelas = data.nama_kelas
    })

        Await _client.PatchAsync($"{TableName}?id_kelas=eq.{id_kelas}", jsonBody)
    End Function


    ' 🔹 Nonaktifkan kelas
    Public Async Function DeactivateAsync(id_kelas As String) As Task(Of Boolean)
        Dim jsonBody = JsonConvert.SerializeObject(New With {.status = False})
        Dim response = Await _client.PatchAsync($"{TableName}?id_kelas=eq.{id_kelas}", jsonBody)
        If String.IsNullOrWhiteSpace(response) OrElse response.Contains("error") Then
            Return False
        End If
        Return True
    End Function

    ' 🔹 Hitung total
    Public Async Function GetCountAsync() As Task(Of Integer)
        Dim json = Await _client.GetAsync($"{TableName}?select=id_kelas")
        Dim list = JsonConvert.DeserializeObject(Of List(Of KelasModel))(json)
        Return list.Count
    End Function

    ' 🔍 Pencarian
    Public Async Function SearchPagedAsync(keyword As String, limit As Integer, offset As Integer) As Task(Of List(Of KelasModel))
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim query = $"{TableName}?select=*&or=(id_kelas.ilike.{encodedKeyword},nama_kelas.ilike.{encodedKeyword})&limit={limit}&offset={offset}"
        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of KelasModel))(json)

        ' Filter manual status aktif/nonaktif
        Return list.Where(Function(k)
                              If keyword.ToLower() = "aktif" Then
                                  Return k.status
                              ElseIf keyword.ToLower() = "nonaktif" Then
                                  Return Not k.status
                              Else
                                  Return True
                              End If
                          End Function).ToList()
    End Function

    Public Async Function GetSearchCountAsync(keyword As String) As Task(Of Integer)
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim json = Await _client.GetAsync($"{TableName}?select=id_kelas&or=(id_kelas.ilike.{encodedKeyword},nama_kelas.ilike.{encodedKeyword})")
        Dim list = JsonConvert.DeserializeObject(Of List(Of KelasModel))(json)
        Return list.Count
    End Function

    Private Function GenerateUniqueId() As String
        Dim prefix = "KLS"
        Dim tanggal = Date.Now.ToString("yyyyMMdd")
        Dim random = New Random().Next(100, 999).ToString()
        Return $"{prefix}{tanggal}{random}"
    End Function
End Class
