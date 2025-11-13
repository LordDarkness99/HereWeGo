Imports Newtonsoft.Json

Public Class MuridRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "siswa"

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    ' 🔹 Ambil semua murid (urut: aktif dulu, lalu nis)
    Public Async Function GetAllAsync() As Task(Of List(Of MuridModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,nis.asc")
        Return JsonConvert.DeserializeObject(Of List(Of MuridModel))(json)
    End Function

    ' 🔹 Tambah murid baru
    Public Async Function AddAsync(data As MuridModel) As Task
        data.status = True

        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .nis = data.nis,
            .nama_siswa = data.nama_siswa,
            .id_kelas = data.id_kelas,
            .alamat = data.alamat,
            .link_foto = data.link_foto,
            .status = data.status
        })

        Await _client.PostAsync(TableName, jsonBody)
    End Function

    ' 🔹 Ubah data murid
    Public Async Function UpdateAsync(nis As String, data As MuridModel) As Task
        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .nama_siswa = data.nama_siswa,
            .id_kelas = data.id_kelas,
            .alamat = data.alamat,
            .link_foto = data.link_foto
        })
        Await _client.PatchAsync($"{TableName}?nis=eq.{nis}", jsonBody)
    End Function

    ' 🔹 Nonaktifkan murid
    Public Async Function DeactivateAsync(nis As String) As Task(Of Boolean)
        Dim jsonBody = JsonConvert.SerializeObject(New With {.status = False})
        Dim response = Await _client.PatchAsync($"{TableName}?nis=eq.{nis}", jsonBody)
        Return Not String.IsNullOrWhiteSpace(response) AndAlso Not response.Contains("error")
    End Function

    ' 🔹 Pagination
    Public Async Function GetPagedAsync(limit As Integer, offset As Integer) As Task(Of List(Of MuridModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,nis.asc&limit={limit}&offset={offset}")
        Return JsonConvert.DeserializeObject(Of List(Of MuridModel))(json)
    End Function

    ' 🔢 Hitung total data
    Public Async Function GetCountAsync() As Task(Of Integer)
        Dim json = Await _client.GetAsync($"{TableName}?select=nis")
        Dim list = JsonConvert.DeserializeObject(Of List(Of MuridModel))(json)
        Return list.Count
    End Function

    ' 🔍 Pencarian
    Public Async Function SearchPagedAsync(keyword As String, limit As Integer, offset As Integer) As Task(Of List(Of MuridModel))
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim query = $"{TableName}?select=*&or=(nis.ilike.{encodedKeyword},nama_siswa.ilike.{encodedKeyword},alamat.ilike.{encodedKeyword})&order=status.desc,nis.asc&limit={limit}&offset={offset}"
        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of MuridModel))(json)

        ' Filter manual jika keyword = aktif/nonaktif
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
        Dim query = $"{TableName}?select=nis&or=(nis.ilike.{encodedKeyword},nama_siswa.ilike.{encodedKeyword},alamat.ilike.{encodedKeyword})"
        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of MuridModel))(json)

        ' Filter status manual
        Dim filtered = list.Where(Function(u)
                                      Dim statusText = If(u.status, "aktif", "nonaktif")
                                      Return statusText.ToLower().Contains(keyword.ToLower())
                                  End Function).ToList()

        list.AddRange(filtered.Where(Function(u) Not list.Any(Function(x) x.nis = u.nis)))
        Return list.Count
    End Function
End Class
