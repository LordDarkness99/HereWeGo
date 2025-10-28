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
        nama_siswa = New DataGridViewTextBoxColumn()
        status_kehadiran = New DataGridViewTextBoxColumn()
        Button2 = New Button()
        Button3 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(359, 29)
        Label2.Name = "Label2"
        Label2.Size = New Size(107, 25)
        Label2.TabIndex = 1
        Label2.Text = "Pilih Mapel"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(26, 29)
        Label4.Name = "Label4"
        Label4.Size = New Size(103, 25)
        Label4.TabIndex = 3
        Label4.Text = "Pilih Kelas"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(712, 19)
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
        ComboBox1.Location = New Point(133, 27)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(202, 28)
        ComboBox1.TabIndex = 37
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(470, 27)
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
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {NIS, nama_siswa, status_kehadiran})
        DataGridView1.Location = New Point(22, 82)
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
        ' nama_siswa
        ' 
        nama_siswa.HeaderText = "Nama Siswa"
        nama_siswa.MinimumWidth = 6
        nama_siswa.Name = "nama_siswa"
        nama_siswa.ReadOnly = True
        nama_siswa.Width = 170
        ' 
        ' status_kehadiran
        ' 
        status_kehadiran.HeaderText = "Status Kehadiran"
        status_kehadiran.MinimumWidth = 6
        status_kehadiran.Name = "status_kehadiran"
        status_kehadiran.ReadOnly = True
        status_kehadiran.Width = 170
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(816, 569)
        Button2.Margin = New Padding(3, 4, 3, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(136, 52)
        Button2.TabIndex = 48
        Button2.Text = "Simpan"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(22, 569)
        Button3.Margin = New Padding(3, 4, 3, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(190, 52)
        Button3.TabIndex = 49
        Button3.Text = "Ubah Status"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Presensi_Operator
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        ClientSize = New Size(971, 626)
        Controls.Add(Button3)
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
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents NIS As DataGridViewTextBoxColumn
    Friend WithEvents nama_siswa As DataGridViewTextBoxColumn
    Friend WithEvents status_kehadiran As DataGridViewTextBoxColumn
End Class
