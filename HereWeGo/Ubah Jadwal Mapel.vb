Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class Ubah_Jadwal_Mapel
    Private parentForm As Admin
    Private repo As New JadwalMapelRepository()
    Private kelasRepo As New KelasRepository()
    Private mapelRepo As New MataPelajaranRepository()
    Private guruRepo As New GuruRepository()
    Private currentId As String

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

    Public Async Sub LoadJadwalData(id_jadwal As String)
        currentId = id_jadwal

        ' 🔹 Muat combobox dulu
        Await LoadComboBoxDataAsync()

        ' 🔹 Ambil data jadwal
        Dim list = Await repo.GetAllAsync()
        Dim jadwal = list.FirstOrDefault(Function(j) j.id_jadwal = id_jadwal)

        If jadwal Is Nothing Then
            MessageBox.Show("Data tidak ditemukan.")
            parentForm.ShowFormInPanel(New Jadwal_Mapel(parentForm))
            Return
        End If

        ' 🔹 Isi field
        TextBox1.Text = jadwal.id_jadwal
        ComboBox1.SelectedItem = ComboBox1.Items.Cast(Of ComboItem).FirstOrDefault(Function(x) x.Value = jadwal.id_kelas)
        ComboBox2.SelectedItem = ComboBox2.Items.Cast(Of ComboItem).FirstOrDefault(Function(x) x.Value = jadwal.id_mapel)
        ComboBox3.SelectedItem = ComboBox3.Items.Cast(Of ComboItem).FirstOrDefault(Function(x) x.Value = jadwal.nip)
        ComboBox4.SelectedItem = jadwal.hari
        TextBox2.Text = jadwal.jam_mulai
        TextBox3.Text = jadwal.jam_selesai
    End Sub

    Private Async Function LoadComboBoxDataAsync() As Task
        ' sama seperti di Tambah_Jadwal_Mapel
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        ComboBox4.Items.Clear()

        Dim kelasList = Await kelasRepo.GetAllAsync()
        For Each k In kelasList.Where(Function(x) x.status)
            ComboBox1.Items.Add(New ComboItem With {.Value = k.id_kelas, .Text = k.nama_kelas})
        Next

        Dim mapelList = Await mapelRepo.GetAllAsync()
        For Each m In mapelList.Where(Function(x) x.status)
            ComboBox2.Items.Add(New ComboItem With {.Value = m.id_mapel, .Text = m.nama_mapel})
        Next

        Dim guruList = Await guruRepo.GetAllAsync()
        For Each g In guruList.Where(Function(x) x.status)
            ComboBox3.Items.Add(New ComboItem With {.Value = g.nip, .Text = g.nama})
        Next

        ComboBox4.Items.AddRange({"Senin", "Selasa", "Rabu", "Kamis", "Jumat"})
    End Function

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim data As New JadwalMapelModel With {
                .id_kelas = CType(ComboBox1.SelectedItem, ComboItem).Value,
                .id_mapel = CType(ComboBox2.SelectedItem, ComboItem).Value,
                .nip = CType(ComboBox3.SelectedItem, ComboItem).Value,
                .hari = ComboBox4.SelectedItem.ToString(),
                .jam_mulai = TextBox2.Text.Trim(),
                .jam_selesai = TextBox3.Text.Trim()
            }

            Await repo.UpdateAsync(currentId, data)
            MessageBox.Show("Jadwal berhasil diperbarui.")
            parentForm.ShowFormInPanel(New Jadwal_Mapel(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui jadwal: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Jadwal_Mapel(parentForm))
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub
End Class
