<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Presensi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Lanjut = New Button()
        DataGridView1 = New DataGridView()
        id_presensi = New DataGridViewTextBoxColumn()
        id_siswa = New DataGridViewTextBoxColumn()
        id_mapel = New DataGridViewTextBoxColumn()
        id_kelas = New DataGridViewTextBoxColumn()
        id_guru = New DataGridViewTextBoxColumn()
        id_tahun = New DataGridViewTextBoxColumn()
        tanggal = New DataGridViewTextBoxColumn()
        status = New DataGridViewTextBoxColumn()
        catatan = New DataGridViewTextBoxColumn()
        TextBox2 = New TextBox()
        Label3 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.Location = New Point(304, 561)
        Button4.Margin = New Padding(3, 4, 3, 4)
        Button4.Name = "Button4"
        Button4.Size = New Size(136, 52)
        Button4.TabIndex = 58
        Button4.Text = "Hapus"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(162, 561)
        Button3.Margin = New Padding(3, 4, 3, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(136, 52)
        Button3.TabIndex = 57
        Button3.Text = "Ubah"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(20, 561)
        Button2.Margin = New Padding(3, 4, 3, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(136, 52)
        Button2.TabIndex = 56
        Button2.Text = "Tambah"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(672, 561)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(136, 52)
        Button1.TabIndex = 55
        Button1.Text = "Sebelum"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Lanjut
        ' 
        Lanjut.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Lanjut.Location = New Point(814, 561)
        Lanjut.Margin = New Padding(3, 4, 3, 4)
        Lanjut.Name = "Lanjut"
        Lanjut.Size = New Size(136, 52)
        Lanjut.TabIndex = 54
        Lanjut.Text = "Lanjut"
        Lanjut.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {id_presensi, id_siswa, id_mapel, id_kelas, id_guru, id_tahun, tanggal, status, catatan})
        DataGridView1.Location = New Point(20, 72)
        DataGridView1.Margin = New Padding(3, 4, 3, 4)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.RowTemplate.Height = 24
        DataGridView1.Size = New Size(930, 481)
        DataGridView1.TabIndex = 51
        ' 
        ' id_presensi
        ' 
        id_presensi.HeaderText = "Id Presensi"
        id_presensi.MinimumWidth = 6
        id_presensi.Name = "id_presensi"
        id_presensi.ReadOnly = True
        id_presensi.Width = 103
        ' 
        ' id_siswa
        ' 
        id_siswa.HeaderText = "Id Siswa"
        id_siswa.MinimumWidth = 6
        id_siswa.Name = "id_siswa"
        id_siswa.ReadOnly = True
        id_siswa.Width = 103
        ' 
        ' id_mapel
        ' 
        id_mapel.HeaderText = "Id Mapel"
        id_mapel.MinimumWidth = 6
        id_mapel.Name = "id_mapel"
        id_mapel.ReadOnly = True
        id_mapel.Width = 103
        ' 
        ' id_kelas
        ' 
        id_kelas.HeaderText = "Id Kelas"
        id_kelas.MinimumWidth = 6
        id_kelas.Name = "id_kelas"
        id_kelas.ReadOnly = True
        id_kelas.Width = 103
        ' 
        ' id_guru
        ' 
        id_guru.HeaderText = "Id Guru"
        id_guru.MinimumWidth = 6
        id_guru.Name = "id_guru"
        id_guru.ReadOnly = True
        id_guru.Width = 103
        ' 
        ' id_tahun
        ' 
        id_tahun.HeaderText = "Id Tahun"
        id_tahun.MinimumWidth = 6
        id_tahun.Name = "id_tahun"
        id_tahun.ReadOnly = True
        id_tahun.Width = 103
        ' 
        ' tanggal
        ' 
        tanggal.HeaderText = "Tanggal"
        tanggal.MinimumWidth = 6
        tanggal.Name = "tanggal"
        tanggal.ReadOnly = True
        tanggal.Width = 103
        ' 
        ' status
        ' 
        status.HeaderText = "Status"
        status.MinimumWidth = 6
        status.Name = "status"
        status.ReadOnly = True
        status.Width = 103
        ' 
        ' catatan
        ' 
        catatan.HeaderText = "Catatan"
        catatan.MinimumWidth = 6
        catatan.Name = "catatan"
        catatan.ReadOnly = True
        catatan.Width = 103
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = Color.LightGray
        TextBox2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox2.Location = New Point(752, 16)
        TextBox2.Margin = New Padding(3, 4, 3, 4)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(198, 36)
        TextBox2.TabIndex = 53
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(698, 24)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 25)
        Label3.TabIndex = 52
        Label3.Text = "Cari"
        ' 
        ' Presensi
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        ClientSize = New Size(971, 626)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Lanjut)
        Controls.Add(DataGridView1)
        Controls.Add(TextBox2)
        Controls.Add(Label3)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(3, 4, 3, 4)
        Name = "Presensi"
        Text = "Presensi"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Lanjut As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents id_presensi As DataGridViewTextBoxColumn
    Friend WithEvents id_siswa As DataGridViewTextBoxColumn
    Friend WithEvents id_mapel As DataGridViewTextBoxColumn
    Friend WithEvents id_kelas As DataGridViewTextBoxColumn
    Friend WithEvents id_guru As DataGridViewTextBoxColumn
    Friend WithEvents id_tahun As DataGridViewTextBoxColumn
    Friend WithEvents tanggal As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents catatan As DataGridViewTextBoxColumn
End Class
