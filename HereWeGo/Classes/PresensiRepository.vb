Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class PresensiRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "presensi"

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    ' 🔹 Ambil presensi berdasarkan kelas & mapel
    Public Async Function GetByFilterAsync(idKelas As String, idMapel As String) As Task(Of List(Of PresensiModel))
        Dim query = $"{TableName}?select=nis,status,id_kelas,id_mapel,siswa(nama_siswa)&id_kelas=eq.{idKelas}&id_mapel=eq.{idMapel}"
        Dim json = Await _client.GetAsync(query)

        ' Bentuk hasil nested (siswa.nama_siswa)
        Dim rawList = JsonConvert.DeserializeObject(Of List(Of JObject))(json)
        Dim result As New List(Of PresensiModel)

        For Each item In rawList
            Dim p As New PresensiModel()
            p.nis = item.Value(Of String)("nis")
            p.status = item.Value(Of String)("status")
            p.id_kelas = item.Value(Of String)("id_kelas")
            p.id_mapel = item.Value(Of String)("id_mapel")

            ' ambil nama dari nested object siswa
            Dim siswaObj = item("siswa")
            If siswaObj IsNot Nothing Then
                p.nama_siswa = siswaObj.Value(Of String)("nama_siswa")
            Else
                p.nama_siswa = "(Tidak ditemukan)"
            End If

            result.Add(p)
        Next

        Return result
    End Function


    ' 🔹 Ubah status presensi siswa
    Public Async Function UpdateStatusAsync(nis As String, statusBaru As String) As Task
        Dim jsonBody = JsonConvert.SerializeObject(New With {.status = statusBaru})
        Await _client.PatchAsync($"{TableName}?nis=eq.{nis}", jsonBody)
    End Function
End Class
