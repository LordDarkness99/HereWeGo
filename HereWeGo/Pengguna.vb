Imports Newtonsoft.Json

Public Class Pengguna
    Private Async Sub Pengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadData()
    End Sub

    Public Async Function LoadData() As Task
        Try
            ' Kosongkan dulu grid (biar tidak numpuk)
            DataGridView1.Rows.Clear()

            ' Ambil data dari Supabase
            Dim json = Await SupabaseClient.GetAsync("akun?select=*")
            Dim data = JsonConvert.DeserializeObject(Of List(Of Akun))(json)

            ' Masukkan data ke grid satu per satu (manual)
            For Each akun In data
                DataGridView1.Rows.Add(akun.id, akun.email, akun.role, akun.password)
            Next

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message)
        End Try
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim formTambah As New Tambah_Pengguna()
        formTambah.ShowDialog()
    End Sub
End Class
