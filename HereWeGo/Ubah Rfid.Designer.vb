<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ubah_Rfid
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
        Button2 = New Button()
        Button1 = New Button()
        GroupBox1 = New GroupBox()
        ComboBox1 = New ComboBox()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label2 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(120, 179)
        Label1.Name = "Label1"
        Label1.Size = New Size(256, 29)
        Label1.TabIndex = 38
        Label1.Text = "Ubah Identitas Guru"
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(714, 395)
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
        Button1.Location = New Point(572, 395)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(136, 52)
        Button1.TabIndex = 36
        Button1.Text = "Simpan"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(ComboBox1)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Location = New Point(166, 219)
        GroupBox1.Margin = New Padding(3, 4, 3, 4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 4, 3, 4)
        GroupBox1.Size = New Size(684, 169)
        GroupBox1.TabIndex = 39
        GroupBox1.TabStop = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(267, 110)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(397, 28)
        ComboBox1.TabIndex = 9
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(267, 20)
        TextBox1.Margin = New Padding(3, 4, 3, 4)
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.Size = New Size(399, 30)
        TextBox1.TabIndex = 8
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox2.Location = New Point(267, 64)
        TextBox2.Margin = New Padding(3, 4, 3, 4)
        TextBox2.Name = "TextBox2"
        TextBox2.ReadOnly = True
        TextBox2.Size = New Size(399, 30)
        TextBox2.TabIndex = 6
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(6, 70)
        Label2.Name = "Label2"
        Label2.Size = New Size(45, 25)
        Label2.TabIndex = 1
        Label2.Text = "NIS"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(6, 24)
        Label4.Name = "Label4"
        Label4.Size = New Size(89, 25)
        Label4.TabIndex = 3
        Label4.Text = "Card Uid"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(6, 114)
        Label3.Name = "Label3"
        Label3.Size = New Size(68, 25)
        Label3.TabIndex = 2
        Label3.Text = "Status"
        ' 
        ' Ubah_Rfid
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        ClientSize = New Size(971, 626)
        Controls.Add(Label1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(GroupBox1)
        Name = "Ubah_Rfid"
        Text = "Ubah Rfid"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
End Class
