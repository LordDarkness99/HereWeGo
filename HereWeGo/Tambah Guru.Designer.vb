<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Tambah_Guru
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(512, 141)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(154, 22)
        Me.DateTimePicker1.TabIndex = 17
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Laki-Laki", "Perempuan"})
        Me.ComboBox1.Location = New System.Drawing.Point(267, 94)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(399, 33)
        Me.ComboBox1.TabIndex = 15
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(267, 15)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(399, 30)
        Me.TextBox3.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Gender"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(166, 203)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(684, 184)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(267, 137)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(239, 30)
        Me.TextBox1.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(209, 25)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Tempat, Tanggal Lahir"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(267, 55)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(399, 30)
        Me.TextBox2.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "NIP"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(120, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(291, 29)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Tambah Identitas Guru"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(736, 414)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 42)
        Me.Button2.TabIndex = 29
        Me.Button2.Text = "Batal"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(618, 414)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 42)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Simpan"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Tambah_Guru
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(971, 626)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Tambah_Guru"
        Me.Text = "Tambah_Guru"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class
