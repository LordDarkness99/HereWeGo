<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Guru
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
        Me.NIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tempat_Tanggal_Lahir = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Lanjut = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NIP, Me.Nama, Me.Gender, Me.Tempat_Tanggal_Lahir})
        Me.DataGridView1.Location = New System.Drawing.Point(20, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(930, 508)
        Me.DataGridView1.TabIndex = 22
        '
        'NIP
        '
        Me.NIP.HeaderText = "NIP"
        Me.NIP.MinimumWidth = 6
        Me.NIP.Name = "NIP"
        Me.NIP.ReadOnly = True
        Me.NIP.Width = 232
        '
        'Nama
        '
        Me.Nama.HeaderText = "Nama"
        Me.Nama.MinimumWidth = 6
        Me.Nama.Name = "Nama"
        Me.Nama.ReadOnly = True
        Me.Nama.Width = 232
        '
        'Gender
        '
        Me.Gender.HeaderText = "Gender"
        Me.Gender.MinimumWidth = 6
        Me.Gender.Name = "Gender"
        Me.Gender.ReadOnly = True
        Me.Gender.Width = 232
        '
        'Tempat_Tanggal_Lahir
        '
        Me.Tempat_Tanggal_Lahir.HeaderText = "Tempat, Tanggal Lahir"
        Me.Tempat_Tanggal_Lahir.MinimumWidth = 6
        Me.Tempat_Tanggal_Lahir.Name = "Tempat_Tanggal_Lahir"
        Me.Tempat_Tanggal_Lahir.ReadOnly = True
        Me.Tempat_Tanggal_Lahir.Width = 232
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(262, 572)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(115, 42)
        Me.Button4.TabIndex = 29
        Me.Button4.Text = "Hapus"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(141, 572)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(115, 42)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "Ubah"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(20, 572)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 42)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "Tambah"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(752, 572)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 42)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Lihat"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Lanjut
        '
        Me.Lanjut.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lanjut.Location = New System.Drawing.Point(851, 572)
        Me.Lanjut.Name = "Lanjut"
        Me.Lanjut.Size = New System.Drawing.Size(93, 42)
        Me.Lanjut.TabIndex = 25
        Me.Lanjut.Text = "Lanjut"
        Me.Lanjut.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.LightGray
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(752, 13)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(198, 36)
        Me.TextBox2.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(698, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 25)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Cari"
        '
        'Guru
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
        Me.Name = "Guru"
        Me.Text = "Guru"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents NIP As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Gender As DataGridViewTextBoxColumn
    Friend WithEvents Tempat_Tanggal_Lahir As DataGridViewTextBoxColumn
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Lanjut As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
End Class
