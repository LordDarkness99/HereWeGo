Imports System.Threading.Tasks
Imports System.IO
Imports System.Net.Http

Public Class Welcome
    Private ReadOnly repo As New WelcomeRepository()
    Private WithEvents refreshTimer As New Timer() With {.Interval = 2000} ' setiap 2 detik
    Private lastUidDisplayed As String = ""

    Private Async Sub Welcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshTimer.Start()
        Await RefreshLatestScanAsync()
    End Sub

    ' ====================================================
    ' 🔁 CEK SCAN TERBARU DARI VIEW v_presensi_rfid_detail
    ' ====================================================
    Private Async Function RefreshLatestScanAsync() As Task
        Try
            Dim data = Await repo.GetLatestScanAsync()
            If data Is Nothing Then
                ClearFields()
                Exit Function
            End If

            ' tampilkan hanya jika UID baru
            If data.rfid_id <> lastUidDisplayed Then
                lastUidDisplayed = data.rfid_id

                TextBox1.Text = data.nis
                TextBox2.Text = data.nama_siswa

                If Not String.IsNullOrEmpty(data.link_foto) Then
                    Await LoadFotoAsync(data.link_foto)
                Else
                    PictureBox1.Image = Nothing
                End If
            End If
        Catch ex As Exception
            Console.WriteLine($"⚠️ Error refresh data: {ex.Message}")
        End Try
    End Function

    ' ====================================================
    ' 🖼️ LOAD FOTO SISWA DARI LINK SUPABASE
    ' ====================================================
    Private Async Function LoadFotoAsync(url As String) As Task
        Try
            Using httpClient As New HttpClient()
                Dim data = Await httpClient.GetByteArrayAsync(url)
                Using ms As New MemoryStream(data)
                    PictureBox1.Image = Image.FromStream(ms)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"⚠️ Gagal memuat foto: {ex.Message}")
            PictureBox1.Image = Nothing
        End Try
    End Function

    ' ====================================================
    ' 🔁 TIMER REFRESH SETIAP 2 DETIK
    ' ====================================================
    Private Async Sub refreshTimer_Tick(sender As Object, e As EventArgs) Handles refreshTimer.Tick
        refreshTimer.Stop()
        Await RefreshLatestScanAsync()
        refreshTimer.Start()
    End Sub

    ' ====================================================
    ' 🧹 HAPUS DATA DARI FORM
    ' ====================================================
    Private Sub ClearFields()
        TextBox1.Clear()
        TextBox2.Clear()
        PictureBox1.Image = Nothing
    End Sub

    ' ====================================================
    ' 🔘 TOMBOL LOGIN (opsional)
    ' ====================================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formLogin As New Login()
        formLogin.Show()
        Me.Hide()
    End Sub
End Class
