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
        Dim today As String = DateTime.Now.ToString("yyyy-MM-dd")

        ' ✅ Query yang benar-benar mengambil presensi sesuai kelas dan mapel
        Dim query = $"{TableName}?select=id_presensi,nis,status,tanggal," &
    "jadwal_mapel!inner(id_jadwal,id_kelas,id_mapel),siswa(nama_siswa)" &
    $"&jadwal_mapel.id_kelas=eq.{idKelas}" &
    $"&jadwal_mapel.id_mapel=eq.{idMapel}" &
    $"&tanggal=eq.{today}"


        Dim json = Await _client.GetAsync(query)
        If String.IsNullOrWhiteSpace(json) Then
            Return New List(Of PresensiModel)
        End If

        Dim result As New List(Of PresensiModel)
        Try
            Dim rawList As List(Of JObject) = JsonConvert.DeserializeObject(Of List(Of JObject))(json)

            For Each item In rawList
                Dim p As New PresensiModel()
                p.id_presensi = item.Value(Of String)("id_presensi")
                p.nis = item.Value(Of String)("nis")
                p.status = item.Value(Of String)("status")

                ' Ambil data dari jadwal_mapel (relasi)
                Dim jadwalObj = TryCast(item("jadwal_mapel"), JObject)
                If jadwalObj IsNot Nothing Then
                    p.id_kelas = jadwalObj.Value(Of String)("id_kelas")
                    p.id_mapel = jadwalObj.Value(Of String)("id_mapel")
                End If

                ' Ambil nama siswa
                Dim siswaObj = TryCast(item("siswa"), JObject)
                If siswaObj IsNot Nothing Then
                    p.nama_siswa = siswaObj.Value(Of String)("nama_siswa")
                End If

                result.Add(p)
            Next
        Catch ex As Exception
            MessageBox.Show("Gagal parsing data presensi: " & ex.Message)
        End Try

        Return result
    End Function


    ' 🔹 Update status presensi ke database
    Public Async Function UpdateStatusAsync(idPresensi As String, status As String) As Task(Of Boolean)
        Try
            Dim data As New Dictionary(Of String, Object) From {
                {"status", status}
            }
            Dim jsonBody As String = JsonConvert.SerializeObject(data)
            Dim response = Await _client.PatchAsync($"{TableName}?id_presensi=eq.{idPresensi}&select=*", jsonBody)
            If Not String.IsNullOrWhiteSpace(response) AndAlso Not response.Contains("error") Then
                Return True
            Else
                If String.IsNullOrWhiteSpace(response) Then
                    Return True
                End If
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui status: " & ex.Message)
            Return False
        End Try
    End Function
End Class
