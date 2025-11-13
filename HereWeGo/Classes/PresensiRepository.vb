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
        ' Gunakan embedding agar nama_siswa ikut ditarik dari tabel siswa
        Dim today As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim query = $"{TableName}?select=id_presensi,nis,status,jadwal_mapel(id_kelas,id_mapel),siswa(nama_siswa)" &
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
                p.id_kelas = item.Value(Of String)("id_kelas")
                p.id_mapel = item.Value(Of String)("id_mapel")

                ' Ambil nama siswa dari tabel siswa
                Dim siswaObj = TryCast(item("siswa"), JObject)
                If siswaObj IsNot Nothing Then
                    p.nama_siswa = siswaObj.Value(Of String)("nama_siswa")
                Else
                    p.nama_siswa = "(Tidak ditemukan)"
                End If

                result.Add(p)
            Next

        Catch ex As Exception
            MessageBox.Show("Gagal parsing data presensi: " & ex.Message)
        End Try

        Return result
    End Function
End Class
