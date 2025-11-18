<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Laporan_Operator
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
        Button3 = New Button()
        DataGridView1 = New DataGridView()
        NIS = New DataGridViewTextBoxColumn()
        nama_siswa = New DataGridViewTextBoxColumn()
        hadir = New DataGridViewTextBoxColumn()
        izin = New DataGridViewTextBoxColumn()
        sakit = New DataGridViewTextBoxColumn()
        tidak_hadir = New DataGridViewTextBoxColumn()
        presentase = New DataGridViewTextBoxColumn()
        ComboBox2 = New ComboBox()
        ComboBox1 = New ComboBox()
        Label2 = New Label()
        Label4 = New Label()
        Button1 = New Button()
        Label1 = New Label()
        Label3 = New Label()
        DateTimePicker1 = New DateTimePicker()
        DateTimePicker2 = New DateTimePicker()
        PictureBox1 = New PictureBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(42, 580)
        Button3.Margin = New Padding(3, 4, 3, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(903, 41)
        Button3.TabIndex = 57
        Button3.Text = "Cetak"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {NIS, nama_siswa, hadir, izin, sakit, tidak_hadir, presentase})
        DataGridView1.Location = New Point(29, 93)
        DataGridView1.Margin = New Padding(3, 4, 3, 4)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.RowTemplate.Height = 24
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(930, 479)
        DataGridView1.TabIndex = 55
        ' 
        ' NIS
        ' 
        NIS.HeaderText = "NIS"
        NIS.MinimumWidth = 6
        NIS.Name = "NIS"
        NIS.ReadOnly = True
        NIS.Width = 240
        ' 
        ' nama_siswa
        ' 
        nama_siswa.HeaderText = "Nama Siswa"
        nama_siswa.MinimumWidth = 6
        nama_siswa.Name = "nama_siswa"
        nama_siswa.ReadOnly = True
        nama_siswa.Width = 250
        ' 
        ' hadir
        ' 
        hadir.HeaderText = "Hadir"
        hadir.MinimumWidth = 6
        hadir.Name = "hadir"
        hadir.ReadOnly = True
        hadir.Width = 125
        ' 
        ' izin
        ' 
        izin.HeaderText = "Izin"
        izin.MinimumWidth = 6
        izin.Name = "izin"
        izin.ReadOnly = True
        izin.Width = 125
        ' 
        ' sakit
        ' 
        sakit.HeaderText = "Sakit"
        sakit.MinimumWidth = 6
        sakit.Name = "sakit"
        sakit.ReadOnly = True
        sakit.Width = 125
        ' 
        ' tidak_hadir
        ' 
        tidak_hadir.HeaderText = "Tidak Hadir"
        tidak_hadir.MinimumWidth = 6
        tidak_hadir.Name = "tidak_hadir"
        tidak_hadir.ReadOnly = True
        tidak_hadir.Width = 125
        ' 
        ' presentase
        ' 
        presentase.HeaderText = "Presentase"
        presentase.MinimumWidth = 6
        presentase.Name = "presentase"
        presentase.ReadOnly = True
        presentase.Width = 125
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(97, 54)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(202, 28)
        ComboBox2.TabIndex = 54
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(97, 20)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(202, 28)
        ComboBox1.TabIndex = 53
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(25, 57)
        Label2.Name = "Label2"
        Label2.Size = New Size(66, 25)
        Label2.TabIndex = 50
        Label2.Text = "Mapel"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(25, 23)
        Label4.Name = "Label4"
        Label4.Size = New Size(62, 25)
        Label4.TabIndex = 51
        Label4.Text = "Kelas"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(740, 23)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(139, 45)
        Button1.TabIndex = 52
        Button1.Text = "Tampilkan"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(328, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(132, 25)
        Label1.TabIndex = 58
        Label1.Text = "Tanggal Awal"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(328, 57)
        Label3.Name = "Label3"
        Label3.Size = New Size(134, 25)
        Label3.TabIndex = 59
        Label3.Text = "Tanggal Akhir"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(466, 23)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(250, 27)
        DateTimePicker1.TabIndex = 60
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Location = New Point(466, 59)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(250, 27)
        DateTimePicker2.TabIndex = 61
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Dock = DockStyle.Fill
        PictureBox1.Image = My.Resources.Resources.Copy_of_Blue_and_White_Modern_Welcome_Banner__1280_x_720_px___989_x_673_px_
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(971, 626)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 62
        PictureBox1.TabStop = False
        ' 
        ' Laporan_Operator
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        ClientSize = New Size(971, 626)
        Controls.Add(DateTimePicker2)
        Controls.Add(DateTimePicker1)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(Button3)
        Controls.Add(DataGridView1)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        Controls.Add(Label2)
        Controls.Add(Label4)
        Controls.Add(Button1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "Laporan_Operator"
        Text = "Laporan_Operator"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents NIS As DataGridViewTextBoxColumn
    Friend WithEvents nama_siswa As DataGridViewTextBoxColumn
    Friend WithEvents hadir As DataGridViewTextBoxColumn
    Friend WithEvents izin As DataGridViewTextBoxColumn
    Friend WithEvents sakit As DataGridViewTextBoxColumn
    Friend WithEvents tidak_hadir As DataGridViewTextBoxColumn
    Friend WithEvents presentase As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As PictureBox
End Class
