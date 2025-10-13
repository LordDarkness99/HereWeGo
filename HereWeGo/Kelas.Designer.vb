<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Kelas
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Lanjut = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Kode_Kelas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kelas2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tingkatan_Kelas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jurusan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tahun_Jaran = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Kode_Kelas, Me.Kelas2, Me.Tingkatan_Kelas, Me.Jurusan, Me.Tahun_Jaran})
        Me.DataGridView1.Location = New System.Drawing.Point(23, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(930, 508)
        Me.DataGridView1.TabIndex = 25
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(265, 572)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(115, 42)
        Me.Button4.TabIndex = 32
        Me.Button4.Text = "Hapus"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(144, 572)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(115, 42)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "Ubah"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(23, 572)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 42)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "Tambah"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(755, 572)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 42)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Lihat"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Lanjut
        '
        Me.Lanjut.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lanjut.Location = New System.Drawing.Point(854, 572)
        Me.Lanjut.Name = "Lanjut"
        Me.Lanjut.Size = New System.Drawing.Size(93, 42)
        Me.Lanjut.TabIndex = 28
        Me.Lanjut.Text = "Lanjut"
        Me.Lanjut.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.LightGray
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(755, 13)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(198, 36)
        Me.TextBox2.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(701, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 25)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Cari"
        '
        'Kode_Kelas
        '
        Me.Kode_Kelas.HeaderText = "Kode Kelas"
        Me.Kode_Kelas.MinimumWidth = 6
        Me.Kode_Kelas.Name = "Kode_Kelas"
        Me.Kode_Kelas.ReadOnly = True
        Me.Kode_Kelas.Width = 186
        '
        'Kelas2
        '
        Me.Kelas2.HeaderText = "Kelas"
        Me.Kelas2.MinimumWidth = 6
        Me.Kelas2.Name = "Kelas2"
        Me.Kelas2.ReadOnly = True
        Me.Kelas2.Width = 186
        '
        'Tingkatan_Kelas
        '
        Me.Tingkatan_Kelas.HeaderText = "Tingkatan Kelas"
        Me.Tingkatan_Kelas.MinimumWidth = 6
        Me.Tingkatan_Kelas.Name = "Tingkatan_Kelas"
        Me.Tingkatan_Kelas.ReadOnly = True
        Me.Tingkatan_Kelas.Width = 186
        '
        'Jurusan
        '
        Me.Jurusan.HeaderText = "Jurusan"
        Me.Jurusan.MinimumWidth = 6
        Me.Jurusan.Name = "Jurusan"
        Me.Jurusan.ReadOnly = True
        Me.Jurusan.Width = 186
        '
        'Tahun_Jaran
        '
        Me.Tahun_Jaran.HeaderText = "Tahun Ajaran"
        Me.Tahun_Jaran.MinimumWidth = 6
        Me.Tahun_Jaran.Name = "Tahun_Jaran"
        Me.Tahun_Jaran.ReadOnly = True
        Me.Tahun_Jaran.Width = 186
        '
        'Kelas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(971, 626)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Lanjut)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Kelas"
        Me.Text = "Kelas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Lanjut As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Kode_Kelas As DataGridViewTextBoxColumn
    Friend WithEvents Kelas2 As DataGridViewTextBoxColumn
    Friend WithEvents Tingkatan_Kelas As DataGridViewTextBoxColumn
    Friend WithEvents Jurusan As DataGridViewTextBoxColumn
    Friend WithEvents Tahun_Jaran As DataGridViewTextBoxColumn
End Class
