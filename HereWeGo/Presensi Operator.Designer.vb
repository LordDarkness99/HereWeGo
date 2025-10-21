<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Presensi_Operator
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label2 = New Label()
        Label4 = New Label()
        Button1 = New Button()
        ComboBox1 = New ComboBox()
        ComboBox2 = New ComboBox()
        DataGridView1 = New DataGridView()
        NIS = New DataGridViewTextBoxColumn()
        Nama_Siswa = New DataGridViewTextBoxColumn()
        Hadir = New DataGridViewButtonColumn()
        Izin = New DataGridViewButtonColumn()
        Sakit = New DataGridViewButtonColumn()
        Alfa = New DataGridViewButtonColumn()
        Button2 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(357, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(107, 25)
        Label2.TabIndex = 1
        Label2.Text = "Pilih Mapel"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(24, 21)
        Label4.Name = "Label4"
        Label4.Size = New Size(103, 25)
        Label4.TabIndex = 3
        Label4.Text = "Pilih Kelas"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(710, 11)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(215, 45)
        Button1.TabIndex = 36
        Button1.Text = "Tampilkan Siswa"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(131, 19)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(202, 28)
        ComboBox1.TabIndex = 37
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(468, 19)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(202, 28)
        ComboBox2.TabIndex = 38
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {NIS, Nama_Siswa, Hadir, Izin, Sakit, Alfa})
        DataGridView1.Location = New Point(20, 74)
        DataGridView1.Margin = New Padding(3, 4, 3, 4)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.RowTemplate.Height = 24
        DataGridView1.Size = New Size(930, 479)
        DataGridView1.TabIndex = 39
        ' 
        ' NIS
        ' 
        NIS.HeaderText = "NIS"
        NIS.MinimumWidth = 6
        NIS.Name = "NIS"
        NIS.ReadOnly = True
        NIS.Width = 155
        ' 
        ' Nama_Siswa
        ' 
        Nama_Siswa.HeaderText = "Nama Siswa"
        Nama_Siswa.MinimumWidth = 6
        Nama_Siswa.Name = "Nama_Siswa"
        Nama_Siswa.ReadOnly = True
        Nama_Siswa.Width = 155
        ' 
        ' Hadir
        ' 
        Hadir.HeaderText = "Hadir"
        Hadir.MinimumWidth = 6
        Hadir.Name = "Hadir"
        Hadir.ReadOnly = True
        Hadir.Width = 155
        ' 
        ' Izin
        ' 
        Izin.HeaderText = "Izin"
        Izin.MinimumWidth = 6
        Izin.Name = "Izin"
        Izin.ReadOnly = True
        Izin.Width = 155
        ' 
        ' Sakit
        ' 
        Sakit.HeaderText = "Sakit"
        Sakit.MinimumWidth = 6
        Sakit.Name = "Sakit"
        Sakit.ReadOnly = True
        Sakit.Width = 155
        ' 
        ' Alfa
        ' 
        Alfa.HeaderText = "Alfa"
        Alfa.MinimumWidth = 6
        Alfa.Name = "Alfa"
        Alfa.ReadOnly = True
        Alfa.Width = 155
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(814, 561)
        Button2.Margin = New Padding(3, 4, 3, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(136, 52)
        Button2.TabIndex = 48
        Button2.Text = "Simpan"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Presensi_Operator
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        ClientSize = New Size(971, 626)
        Controls.Add(Button2)
        Controls.Add(DataGridView1)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        Controls.Add(Label2)
        Controls.Add(Label4)
        Controls.Add(Button1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "Presensi_Operator"
        Text = "Presensi Operator"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents NIS As DataGridViewTextBoxColumn
    Friend WithEvents Nama_Siswa As DataGridViewTextBoxColumn
    Friend WithEvents Hadir As DataGridViewButtonColumn
    Friend WithEvents Izin As DataGridViewButtonColumn
    Friend WithEvents Sakit As DataGridViewButtonColumn
    Friend WithEvents Alfa As DataGridViewButtonColumn
    Friend WithEvents Button2 As Button
End Class
