Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class PresensiRekapRepository
    Private ReadOnly _client As SupabaseClient
    Private Const TableName As String = "presensi"

    Public Sub New()
        _client = New SupabaseClient()
    End Sub

    ' 🔹 Ambil rekap presensi dalam rentang tanggal
    Public Async Function GetRekapAsync(idKelas As String,
                                       idMapel As String,
                                       tglAwal As String,
                                       tglAkhir As String) As Task(Of List(Of PresensiRekapModel))

        Dim query =
            $"{TableName}?" &
            "select=nis,siswa(nama_siswa),status,tanggal," &
            "jadwal_mapel!inner(id_kelas,id_mapel)" &
            $"&jadwal_mapel.id_kelas=eq.{idKelas}" &
            $"&jadwal_mapel.id_mapel=eq.{idMapel}" &
            $"&tanggal=gte.{tglAwal}" &
            $"&tanggal=lte.{tglAkhir}"

        Dim json = Await _client.GetAsync(query)

        If String.IsNullOrEmpty(json) Then Return New List(Of PresensiRekapModel)

        Dim list As New List(Of PresensiRekapModel)

        Try
            Dim jsonList As List(Of JObject) = JsonConvert.DeserializeObject(Of List(Of JObject))(json)

            For Each item In jsonList
                Dim m As New PresensiRekapModel()
                m.nis = item.Value(Of String)("nis")
                m.status = item.Value(Of String)("status")
                m.tanggal = item.Value(Of String)("tanggal")

                Dim siswaObj = TryCast(item("siswa"), JObject)
                If siswaObj IsNot Nothing Then
                    m.nama_siswa = siswaObj.Value(Of String)("nama_siswa")
                End If

                list.Add(m)
            Next

        Catch ex As Exception
            MessageBox.Show("Gagal parsing: " & ex.Message)
        End Try

        Return list
    End Function
End Class
