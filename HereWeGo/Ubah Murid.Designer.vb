<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ubah_Murid
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
        Label1 = New Label()
        Label2 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        GroupBox1 = New GroupBox()
        ComboBox1 = New ComboBox()
        TextBox1 = New TextBox()
        Label6 = New Label()
        TextBox3 = New TextBox()
        TextBox2 = New TextBox()
        Button2 = New Button()
        Button1 = New Button()
        Label5 = New Label()
        TextBox4 = New TextBox()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(150, 116)
        Label1.Name = "Label1"
        Label1.Size = New Size(153, 29)
        Label1.TabIndex = 34
        Label1.Text = "Ubah Murid"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(6, 122)
        Label2.Name = "Label2"
        Label2.Size = New Size(83, 25)
        Label2.TabIndex = 1
        Label2.Text = "Id Kelas"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(6, 76)
        Label4.Name = "Label4"
        Label4.Size = New Size(122, 25)
        Label4.TabIndex = 3
        Label4.Text = "Nama Siswa"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(6, 170)
        Label3.Name = "Label3"
        Label3.Size = New Size(73, 25)
        Label3.TabIndex = 2
        Label3.Text = "Alamat"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TextBox4)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(ComboBox1)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(TextBox3)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Location = New Point(196, 156)
        GroupBox1.Margin = New Padding(3, 4, 3, 4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 4, 3, 4)
        GroupBox1.Size = New Size(624, 247)
        GroupBox1.TabIndex = 35
        GroupBox1.TabStop = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(203, 119)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(399, 28)
        ComboBox1.TabIndex = 18
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(203, 26)
        TextBox1.Margin = New Padding(3, 4, 3, 4)
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.Size = New Size(399, 30)
        TextBox1.TabIndex = 17
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(6, 31)
        Label6.Name = "Label6"
        Label6.Size = New Size(45, 25)
        Label6.TabIndex = 16
        Label6.Text = "NIS"
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox3.Location = New Point(203, 71)
        TextBox3.Margin = New Padding(3, 4, 3, 4)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(399, 30)
        TextBox3.TabIndex = 7
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox2.Location = New Point(203, 165)
        TextBox2.Margin = New Padding(3, 4, 3, 4)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(399, 30)
        TextBox2.TabIndex = 6
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(684, 425)
        Button2.Margin = New Padding(3, 4, 3, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(136, 52)
        Button2.TabIndex = 37
        Button2.Text = "Batal"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(542, 425)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(136, 52)
        Button1.TabIndex = 36
        Button1.Text = "Simpan"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(6, 206)
        Label5.Name = "Label5"
        Label5.Size = New Size(98, 25)
        Label5.TabIndex = 19
        Label5.Text = "Link_Foto"
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox4.Location = New Point(203, 206)
        TextBox4.Margin = New Padding(3, 4, 3, 4)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(399, 30)
        TextBox4.TabIndex = 20
        ' 
        ' Ubah_Murid
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        ClientSize = New Size(971, 626)
        Controls.Add(Label1)
        Controls.Add(GroupBox1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(3, 4, 3, 4)
        Name = "Ubah_Murid"
        Text = "Ubah_Murid"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label5 As Label
End Class
