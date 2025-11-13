Imports System.Threading.Tasks

Public Class Ubah_Mata_Pelajaran
    Private parentForm As Admin
    Private repo As New MataPelajaranRepository()
    Private guruRepo As New GuruRepository() ' 🔹 untuk ambil guru aktif
    Private currentId As String

    Public Sub New(parent As Admin)
        InitializeComponent()
        parentForm = parent
    End Sub

    Private Async Sub Ubah_Mata_Pelajaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


    Public Sub LoadMapelData(id_mapel As String, nama_mapel As String, Optional nip_guru As String = Nothing)
        currentId = id_mapel
        TextBox1.Text = id_mapel
        TextBox1.ReadOnly = True
        TextBox2.Text = nama_mapel

        ' 🔹 Set combo box ke guru yang sekarang
        If Not String.IsNullOrEmpty(nip_guru) Then
            ComboBox1.SelectedValue = nip_guru
        End If

    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Validasi input
            If String.IsNullOrWhiteSpace(TextBox2.Text) Then
                MessageBox.Show("Nama mata pelajaran wajib diisi.")
                Return
            End If
            If ComboBox1.SelectedItem Is Nothing Then
                MessageBox.Show("Guru wajib dipilih.")
                Return
            End If

            Dim allMapel = Await repo.GetAllAsync()
            Dim namaBaru = TextBox2.Text.Trim()

            ' 🔹 Cek duplikasi nama mapel aktif
            Dim duplikat = allMapel.Any(Function(m)
                                            Return m.nama_mapel.Equals(namaBaru, StringComparison.OrdinalIgnoreCase) _
                                                AndAlso m.status = True _
                                                AndAlso m.id_mapel <> currentId
                                        End Function)
            If duplikat Then
                MessageBox.Show("Nama mata pelajaran sudah digunakan oleh mapel aktif lain.", "Data Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' 🔹 Data baru untuk update
            Dim data As New MataPelajaranModel With {
                .nama_mapel = namaBaru,
                .id_guru = ComboBox1.SelectedValue.ToString()
            }

            Await repo.UpdateAsync(currentId, data)
            MessageBox.Show("Mata pelajaran berhasil diubah.", "Sukses")
            parentForm.ShowFormInPanel(New Mata_Pelajaran(parentForm))
        Catch ex As Exception
            MessageBox.Show("Gagal mengubah data mata pelajaran: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        parentForm.ShowFormInPanel(New Mata_Pelajaran(parentForm))
    End Sub
End Class
