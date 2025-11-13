Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class Tambah_Jadwal_Mapel
    Private parentForm As Admin
    Private repo As New JadwalMapelRepository()
    Private kelasRepo As New KelasRepository()
    Private mapelRepo As New MataPelajaranRepository()
    Private guruRepo As New GuruRepository()

    Private Class ComboItem
        Public Property Value As String
        Public Property Text As String
        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Async Sub Tambah_Jadwal_Mapel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadComboBoxDataAsync()
    End Sub

    Private Async Function LoadComboBoxDataAsync() As Task
        Dim kelasList = Await kelasRepo.GetAllAsync()
        ComboBox1.Items.Clear()
        For Each k In kelasList.Where(Function(x) x.status)
            ComboBox1.Items.Add(New ComboItem With {.Value = k.id_kelas, .Text = k.nama_kelas})
        Next

        Dim mapelList = Await mapelRepo.GetAllAsync()
        ComboBox2.Items.Clear()
        For Each m In mapelList.Where(Function(x) x.status)
            ComboBox2.Items.Add(New ComboItem With {.Value = m.id_mapel, .Text = m.nama_mapel})
        Next

        Dim guruList = Await guruRepo.GetAllAsync()
        ComboBox3.Items.Clear()
        For Each g In guruList.Where(Function(x) x.status)
            ComboBox3.Items.Add(New ComboItem With {.Value = g.nip, .Text = g.nama})
        Next

        ComboBox4.Items.AddRange({"Senin", "Selasa", "Rabu", "Kamis", "Jumat"})
    End Function

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' 🔹 Validasi input kosong
            If ComboBox1.SelectedItem Is Nothing OrElse ComboBox2.SelectedItem Is Nothing OrElse ComboBox3.SelectedItem Is Nothing OrElse
               ComboBox4.SelectedItem Is Nothing OrElse String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) Then
                MessageBox.Show("Semua field wajib diisi.")
                Return
            End If

            ' 🔹 Normalisasi format jam
            Dim jamMulai As String = TextBox1.Text.Trim().Replace(".", ":")
            Dim jamSelesai As String = TextBox2.Text.Trim().Replace(".", ":")

            ' 🔹 Validasi format waktu
            Dim timeCheck As TimeSpan
            If Not TimeSpan.TryParse(jamMulai, timeCheck) Then
                MessageBox.Show("Format jam mulai tidak valid. Gunakan format HH:MM (contoh: 07:00)")
                Return
            End If
            If Not TimeSpan.TryParse(jamSelesai, timeCheck) Then
                MessageBox.Show("Format jam selesai tidak valid. Gunakan format HH:MM (contoh: 08:30)")
                Return
            End If

            ' 🔹 Pastikan jam selesai lebih besar
            If TimeSpan.Parse(jamSelesai) <= TimeSpan.Parse(jamMulai) Then
                MessageBox.Show("Jam selesai harus lebih besar dari jam mulai.")
                Return
            End If

            ' 🔹 Simpan data
            Dim data As New JadwalMapelModel With {
                .id_kelas = CType(ComboBox1.SelectedItem, ComboItem).Value,
                .id_mapel = CType(ComboBox2.SelectedItem, ComboItem).Value,
                .nip = CType(ComboBox3.SelectedItem, ComboItem).Value,
                .hari = ComboBox4.SelectedItem.ToString(),
                .jam_mulai = jamMulai,
                .jam_selesai = jamSelesai
            }

            Await repo.AddAsync(data)
            MessageBox.Show("Jadwal berhasil ditambahkan.")
            parentForm.ShowFormInPanel(New Jadwal_Mapel(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal menambah jadwal: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Jadwal_Mapel(parentForm))
    End Sub
End Class
