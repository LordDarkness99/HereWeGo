Imports Newtonsoft.Json

Public Class GuruRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "guru"
    Private isSearching As Boolean = False

    Public Sub New()
        _client = New SupabaseClient()
    End Sub


    ' 🔹 Ambil semua data guru
    Public Async Function GetAllAsync() As Task(Of List(Of GuruModel))
        ' Urutkan: yang aktif dulu (status=True), lalu berdasarkan NIP
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,nip.asc")
        Return JsonConvert.DeserializeObject(Of List(Of GuruModel))(json)
    End Function

    ' 🔹 Pagination (urutkan sama seperti di atas)
    Public Async Function GetPagedAsync(limit As Integer, offset As Integer) As Task(Of List(Of GuruModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,nip.asc&limit={limit}&offset={offset}")
        Return JsonConvert.DeserializeObject(Of List(Of GuruModel))(json)
    End Function

    Public Async Function AddAsync(data As GuruModel) As Task
        ' 🔒 Cegah guru memakai akun nonaktif
        Dim userRepo As New PenggunaRepository()
        Dim users = Await userRepo.GetAllAsync()
        Dim selectedUser = users.FirstOrDefault(Function(u) u.id_user = data.id_user)

        If selectedUser Is Nothing Then
            Throw New Exception("ID User tidak ditemukan.")
        End If

        If Not selectedUser.status Then
            Throw New Exception("Pengguna ini sudah nonaktif dan tidak dapat digunakan lagi.")
        End If

        data.status = True ' otomatis aktif saat dibuat
        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .nip = data.nip,
            .nama = data.nama,
            .id_user = data.id_user,
            .status = data.status
        })
        Await _client.PostAsync(TableName, jsonBody)
    End Function

    ' 🔹 Ubah data guru (nama, id_user)
    Public Async Function UpdateAsync(nip As String, data As GuruModel) As Task
        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .nama = data.nama,
            .id_user = data.id_user
        })
        Await _client.PatchAsync($"{TableName}?nip=eq.{nip}", jsonBody)
    End Function

    ' 🔹 Nonaktifkan guru
    Public Async Function DeactivateAsync(nip As String) As Task(Of Boolean)
        Dim jsonBody = JsonConvert.SerializeObject(New With {.status = False})
        Dim response = Await _client.PatchAsync($"{TableName}?nip=eq.{nip}", jsonBody)

        ' Jika SupabaseClient mengembalikan JSON kosong berarti update gagal
        If String.IsNullOrWhiteSpace(response) OrElse response.Contains("error") Then
            Return False
        End If

        Return True
    End Function

    ' 🔹 Hitung total data
    Public Async Function GetCountAsync() As Task(Of Integer)
        Dim json = Await _client.GetAsync($"{TableName}?select=nip")
        Dim list = JsonConvert.DeserializeObject(Of List(Of GuruModel))(json)
        Return list.Count
    End Function

    ' 🔍 Search guru berdasarkan nama, nip, id_user, atau status
    Public Async Function SearchPagedAsync(keyword As String, limit As Integer, offset As Integer) As Task(Of List(Of GuruModel))
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")

        ' Tambahkan order agar hasil konsisten
        Dim query = $"{TableName}?select=*&or=(nip.ilike.{encodedKeyword},nama.ilike.{encodedKeyword},id_user.ilike.{encodedKeyword})&order=status.desc,nip.asc&limit={limit}&offset={offset}"
        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of GuruModel))(json)

        ' 🔹 Filter manual jika keyword = aktif/nonaktif
        If keyword.ToLower() = "aktif" Then
            list = list.Where(Function(u) u.status = True).ToList()
        ElseIf keyword.ToLower() = "nonaktif" Then
            list = list.Where(Function(u) u.status = False).ToList()
        End If

        Return list
    End Function


    ' 🔢 Hitung total hasil pencarian
    Public Async Function GetSearchCountAsync(keyword As String) As Task(Of Integer)
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim query = $"{TableName}?select=nip&or=(nip.ilike.{encodedKeyword},nama.ilike.{encodedKeyword},id_user.ilike.{encodedKeyword})"
        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of GuruModel))(json)

        ' 🔹 Filter status manual dengan aman
        If keyword.ToLower() = "aktif" Then
            list = list.Where(Function(u) u.status = True).ToList()
        ElseIf keyword.ToLower() = "nonaktif" Then
            list = list.Where(Function(u) u.status = False).ToList()
        End If

        ' ❌ HAPUS baris ini karena bikin duplikasi
        ' list.AddRange(filtered.Where(Function(u) Not list.Any(Function(x) x.nip = u.nip)))

        Return list.Count
    End Function
End Class
