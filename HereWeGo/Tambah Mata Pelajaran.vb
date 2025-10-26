Imports System.Threading.Tasks

Public Class Tambah_Mata_Pelajaran
    Private parentForm As Admin
    Private repo As New MataPelajaranRepository()
    Private guruRepo As New GuruRepository() ' 🔹 untuk ambil id_guru

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Async Sub Tambah_Mata_Pelajaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadGuruAktifAsync()
    End Sub

    Private Async Function LoadGuruAktifAsync() As Task
        ComboBox1.Items.Clear()
        Dim guruList = Await guruRepo.GetAllAsync()

        ' 🔹 Hanya tampilkan guru yang masih aktif
        For Each g In guruList
            If g.status Then
                ComboBox1.Items.Add(g.nip)
            End If
        Next
    End Function

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Validasi input
            If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse ComboBox1.SelectedItem Is Nothing Then
                MessageBox.Show("Nama mapel dan guru wajib diisi.")
                Return
            End If

            ' 🔹 Tambahkan mapel baru dan otomatis aktif
            Dim mapel As New MataPelajaranModel With {
                .nama_mapel = TextBox1.Text.Trim(),
                .id_guru = ComboBox1.SelectedItem.ToString(),
                .status = True
            }

            Await repo.AddAsync(mapel)
            MessageBox.Show("Mata pelajaran berhasil ditambahkan dan otomatis aktif.", "Sukses")

            parentForm.ShowFormInPanel(New Mata_Pelajaran(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal menambah mata pelajaran: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Mata_Pelajaran(parentForm))
    End Sub
End Class
