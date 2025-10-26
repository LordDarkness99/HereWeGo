<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ubah_Tahun_Ajaran
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
        GroupBox1 = New GroupBox()
        TextBox4 = New TextBox()
        TextBox1 = New TextBox()
        Label6 = New Label()
        TextBox3 = New TextBox()
        Button2 = New Button()
        Button1 = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(150, 149)
        Label1.Name = "Label1"
        Label1.Size = New Size(248, 29)
        Label1.TabIndex = 38
        Label1.Text = "Ubah Tahun Ajaran"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(6, 122)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 25)
        Label2.TabIndex = 1
        Label2.Text = "Semester"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(6, 76)
        Label4.Name = "Label4"
        Label4.Size = New Size(131, 25)
        Label4.TabIndex = 3
        Label4.Text = "Tahun Ajaran"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TextBox4)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(TextBox3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Location = New Point(196, 189)
        GroupBox1.Margin = New Padding(3, 4, 3, 4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 4, 3, 4)
        GroupBox1.Size = New Size(624, 177)
        GroupBox1.TabIndex = 39
        GroupBox1.TabStop = False
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox4.Location = New Point(203, 118)
        TextBox4.Margin = New Padding(3, 4, 3, 4)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(399, 30)
        TextBox4.TabIndex = 18
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
        Label6.Size = New Size(90, 25)
        Label6.TabIndex = 16
        Label6.Text = "Id Tahun"
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
        ' Button2
        ' 
        Button2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(684, 391)
        Button2.Margin = New Padding(3, 4, 3, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(136, 52)
        Button2.TabIndex = 41
        Button2.Text = "Batal"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(542, 391)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(136, 52)
        Button1.TabIndex = 40
        Button1.Text = "Simpan"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Ubah_Tahun_Ajaran
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
        Name = "Ubah_Tahun_Ajaran"
        Text = "Ubah_Tahun_Ajaran"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class
