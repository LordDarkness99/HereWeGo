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
        Button3 = New Button()
        Button2 = New Button()
        DataGridView1 = New DataGridView()
        NIS = New DataGridViewTextBoxColumn()
        nama_siswa = New DataGridViewTextBoxColumn()
        status_kehadiran = New DataGridViewTextBoxColumn()
        ComboBox2 = New ComboBox()
        ComboBox1 = New ComboBox()
        Label2 = New Label()
        Label4 = New Label()
        Button1 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(20, 562)
        Button3.Margin = New Padding(3, 4, 3, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(190, 52)
        Button3.TabIndex = 57
        Button3.Text = "Ubah Status"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(814, 562)
        Button2.Margin = New Padding(3, 4, 3, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(136, 52)
        Button2.TabIndex = 56
        Button2.Text = "Simpan"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {NIS, nama_siswa, status_kehadiran})
        DataGridView1.Location = New Point(20, 75)
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
        NIS.Width = 310
        ' 
        ' nama_siswa
        ' 
        nama_siswa.HeaderText = "Nama Siswa"
        nama_siswa.MinimumWidth = 6
        nama_siswa.Name = "nama_siswa"
        nama_siswa.ReadOnly = True
        nama_siswa.Width = 310
        ' 
        ' status_kehadiran
        ' 
        status_kehadiran.HeaderText = "Status Kehadiran"
        status_kehadiran.MinimumWidth = 6
        status_kehadiran.Name = "status_kehadiran"
        status_kehadiran.ReadOnly = True
        status_kehadiran.Width = 310
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(468, 20)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(202, 28)
        ComboBox2.TabIndex = 54
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(131, 20)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(202, 28)
        ComboBox1.TabIndex = 53
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(357, 22)
        Label2.Name = "Label2"
        Label2.Size = New Size(107, 25)
        Label2.TabIndex = 50
        Label2.Text = "Pilih Mapel"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(24, 22)
        Label4.Name = "Label4"
        Label4.Size = New Size(103, 25)
        Label4.TabIndex = 51
        Label4.Text = "Pilih Kelas"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(710, 12)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(215, 45)
        Button1.TabIndex = 52
        Button1.Text = "Tampilkan Siswa"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.Location = New Point(216, 562)
        Button4.Margin = New Padding(3, 4, 3, 4)
        Button4.Name = "Button4"
        Button4.Size = New Size(190, 52)
        Button4.TabIndex = 58
        Button4.Text = "Ubah Status"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button5.Location = New Point(412, 561)
        Button5.Margin = New Padding(3, 4, 3, 4)
        Button5.Name = "Button5"
        Button5.Size = New Size(190, 52)
        Button5.TabIndex = 59
        Button5.Text = "Ubah Status"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Presensi
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        ClientSize = New Size(971, 626)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(DataGridView1)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        Controls.Add(Label2)
        Controls.Add(Label4)
        Controls.Add(Button1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(3, 4, 3, 4)
        Name = "Presensi"
        Text = "Presensi"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents NIS As DataGridViewTextBoxColumn
    Friend WithEvents nama_siswa As DataGridViewTextBoxColumn
    Friend WithEvents status_kehadiran As DataGridViewTextBoxColumn
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
