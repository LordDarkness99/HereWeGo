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
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Lanjut = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.catatan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_tahun = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_guru = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_kelas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_mapel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_siswa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_presensi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(304, 572)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(136, 42)
        Me.Button4.TabIndex = 58
        Me.Button4.Text = "Hapus"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(162, 572)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(136, 42)
        Me.Button3.TabIndex = 57
        Me.Button3.Text = "Ubah"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(20, 572)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 42)
        Me.Button2.TabIndex = 56
        Me.Button2.Text = "Tambah"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(672, 572)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 42)
        Me.Button1.TabIndex = 55
        Me.Button1.Text = "Sebelum"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Lanjut
        '
        Me.Lanjut.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lanjut.Location = New System.Drawing.Point(814, 572)
        Me.Lanjut.Name = "Lanjut"
        Me.Lanjut.Size = New System.Drawing.Size(136, 42)
        Me.Lanjut.TabIndex = 54
        Me.Lanjut.Text = "Lanjut"
        Me.Lanjut.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_presensi, Me.id_siswa, Me.id_mapel, Me.id_kelas, Me.id_guru, Me.id_tahun, Me.tanggal, Me.status, Me.catatan})
        Me.DataGridView1.Location = New System.Drawing.Point(20, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(930, 508)
        Me.DataGridView1.TabIndex = 51
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.LightGray
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(752, 13)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(198, 36)
        Me.TextBox2.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(698, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 25)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Cari"
        '
        'catatan
        '
        Me.catatan.HeaderText = "Catatan"
        Me.catatan.MinimumWidth = 6
        Me.catatan.Name = "catatan"
        Me.catatan.ReadOnly = True
        Me.catatan.Width = 103
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Width = 103
        '
        'tanggal
        '
        Me.tanggal.HeaderText = "Tanggal"
        Me.tanggal.MinimumWidth = 6
        Me.tanggal.Name = "tanggal"
        Me.tanggal.ReadOnly = True
        Me.tanggal.Width = 103
        '
        'id_tahun
        '
        Me.id_tahun.HeaderText = "Id Tahun"
        Me.id_tahun.MinimumWidth = 6
        Me.id_tahun.Name = "id_tahun"
        Me.id_tahun.ReadOnly = True
        Me.id_tahun.Width = 103
        '
        'id_guru
        '
        Me.id_guru.HeaderText = "Id Guru"
        Me.id_guru.MinimumWidth = 6
        Me.id_guru.Name = "id_guru"
        Me.id_guru.ReadOnly = True
        Me.id_guru.Width = 103
        '
        'id_kelas
        '
        Me.id_kelas.HeaderText = "Id Kelas"
        Me.id_kelas.MinimumWidth = 6
        Me.id_kelas.Name = "id_kelas"
        Me.id_kelas.ReadOnly = True
        Me.id_kelas.Width = 103
        '
        'id_mapel
        '
        Me.id_mapel.HeaderText = "Id Mapel"
        Me.id_mapel.MinimumWidth = 6
        Me.id_mapel.Name = "id_mapel"
        Me.id_mapel.ReadOnly = True
        Me.id_mapel.Width = 103
        '
        'id_siswa
        '
        Me.id_siswa.HeaderText = "Id Siswa"
        Me.id_siswa.MinimumWidth = 6
        Me.id_siswa.Name = "id_siswa"
        Me.id_siswa.ReadOnly = True
        Me.id_siswa.Width = 103
        '
        'id_presensi
        '
        Me.id_presensi.HeaderText = "Id Presensi"
        Me.id_presensi.MinimumWidth = 6
        Me.id_presensi.Name = "id_presensi"
        Me.id_presensi.ReadOnly = True
        Me.id_presensi.Width = 103
        '
        'Presensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(971, 626)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Lanjut)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Presensi"
        Me.Text = "Presensi"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
