Imports Newtonsoft.Json
Imports System.Threading.Tasks

Public Class RfidRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "rfid"

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    ' 🔹 Ambil semua data RFID (aktif dulu)
    Public Async Function GetAllAsync() As Task(Of List(Of RfidModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,rfid_id.asc")
        Return JsonConvert.DeserializeObject(Of List(Of RfidModel))(json)
    End Function

    ' 🔹 Pagination
    Public Async Function GetPagedAsync(limit As Integer, offset As Integer) As Task(Of List(Of RfidModel))
        Dim json = Await _client.GetAsync($"{TableName}?select=*&order=status.desc,rfid_id.asc&limit={limit}&offset={offset}")
        Return JsonConvert.DeserializeObject(Of List(Of RfidModel))(json)
    End Function

    ' 🔹 Tambah RFID
    Public Async Function AddAsync(data As RfidModel) As Task
        data.status = True
        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .rfid_id = data.rfid_id,
            .nis = data.nis,
            .status = data.status
        })
        Await _client.PostAsync(TableName, jsonBody)
    End Function

    ' 🔹 Update RFID
    Public Async Function UpdateAsync(rfid_id As String, data As RfidModel) As Task
        Dim jsonBody = JsonConvert.SerializeObject(New With {
            .nis = data.nis,
            .status = data.status
        })
        Await _client.PatchAsync($"{TableName}?rfid_id=eq.{rfid_id}", jsonBody)
    End Function

    ' 🔹 Nonaktifkan
    Public Async Function DeactivateAsync(rfid_id As String) As Task(Of Boolean)
        Dim jsonBody = JsonConvert.SerializeObject(New With {.status = False})
        Dim response = Await _client.PatchAsync($"{TableName}?rfid_id=eq.{rfid_id}", jsonBody)
        Return Not (String.IsNullOrWhiteSpace(response) OrElse response.Contains("error"))
    End Function

    ' 🔹 Hitung total data
    Public Async Function GetCountAsync() As Task(Of Integer)
        Dim json = Await _client.GetAsync($"{TableName}?select=rfid_id")
        Dim list = JsonConvert.DeserializeObject(Of List(Of RfidModel))(json)
        Return list.Count
    End Function

    ' 🔍 Pencarian
    Public Async Function SearchPagedAsync(keyword As String, limit As Integer, offset As Integer) As Task(Of List(Of RfidModel))
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim query = $"{TableName}?select=*&or=(rfid_id.ilike.{encodedKeyword},nis.ilike.{encodedKeyword})&order=status.desc,rfid_id.asc&limit={limit}&offset={offset}"
        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of RfidModel))(json)

        If keyword.ToLower() = "aktif" Then
            list = list.Where(Function(u) u.status = True).ToList()
        ElseIf keyword.ToLower() = "nonaktif" Then
            list = list.Where(Function(u) u.status = False).ToList()
        End If

        Return list
    End Function

    Public Async Function GetSearchCountAsync(keyword As String) As Task(Of Integer)
        Dim encodedKeyword = Uri.EscapeDataString("%" & keyword & "%")
        Dim query = $"{TableName}?select=rfid_id&or=(rfid_id.ilike.{encodedKeyword},nis.ilike.{encodedKeyword})"
        Dim json = Await _client.GetAsync(query)
        Dim list = JsonConvert.DeserializeObject(Of List(Of RfidModel))(json)
        If keyword.ToLower() = "aktif" Then
            list = list.Where(Function(u) u.status = True).ToList()
        ElseIf keyword.ToLower() = "nonaktif" Then
            list = list.Where(Function(u) u.status = False).ToList()
        End If
        Return list.Count
    End Function
End Class
