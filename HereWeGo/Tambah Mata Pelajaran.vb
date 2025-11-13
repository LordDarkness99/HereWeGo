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
        Try
            Dim guruList = Await guruRepo.GetAllAsync()
            Dim guruAktif = guruList.Where(Function(g) g.status).ToList()

            ' ✅ Gabungkan NIP dan nama guru untuk tampilan
            Dim displayList = guruAktif.Select(Function(g) New With {
            .DisplayText = $"{g.nip} ({g.nama})",
            .Value = g.nip
        }).ToList()

            ComboBox1.DataSource = displayList
            ComboBox1.DisplayMember = "DisplayText"
            ComboBox1.ValueMember = "Value"
            ComboBox1.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data guru: " & ex.Message)
        End Try
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
                .id_guru = ComboBox1.SelectedValue.ToString(),
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
