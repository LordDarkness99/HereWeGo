<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Welcome
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
        Label1 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label5 = New Label()
        Label6 = New Label()
        GroupBox1 = New GroupBox()
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        PictureBox2 = New PictureBox()
        Button1 = New Button()
        GroupBox1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Rockwell", 40.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(16, 54)
        Label1.Name = "Label1"
        Label1.Size = New Size(413, 82)
        Label1.TabIndex = 0
        Label1.Text = "WELCOME"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Lucida Bright", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(58, 462)
        Label3.Name = "Label3"
        Label3.Size = New Size(84, 29)
        Label3.TabIndex = 3
        Label3.Text = "Nama"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Lucida Bright", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(58, 518)
        Label4.Name = "Label4"
        Label4.Size = New Size(73, 29)
        Label4.TabIndex = 4
        Label4.Text = "NISN"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(171, 466)
        TextBox1.Margin = New Padding(3, 4, 3, 4)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(204, 27)
        TextBox1.TabIndex = 5
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(171, 521)
        TextBox2.Margin = New Padding(3, 4, 3, 4)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(204, 27)
        TextBox2.TabIndex = 6
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Lucida Bright", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(146, 462)
        Label5.Name = "Label5"
        Label5.Size = New Size(19, 29)
        Label5.TabIndex = 7
        Label5.Text = ":"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Lucida Bright", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(146, 518)
        Label6.Name = "Label6"
        Label6.Size = New Size(19, 29)
        Label6.TabIndex = 8
        Label6.Text = ":"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(PictureBox1)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Location = New Point(381, 189)
        GroupBox1.Margin = New Padding(3, 4, 3, 4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 4, 3, 4)
        GroupBox1.Size = New Size(461, 585)
        GroupBox1.TabIndex = 9
        GroupBox1.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.Twibbon_Peserta_Cabang_Lomba_BPC
        PictureBox1.Location = New Point(145, 160)
        PictureBox1.Margin = New Padding(3, 4, 3, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(155, 288)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Magneto", 34.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(886, 11)
        Label2.Name = "Label2"
        Label2.Size = New Size(373, 72)
        Label2.TabIndex = 2
        Label2.Text = "HereWeGo"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Location = New Point(-1, -49)
        PictureBox2.Margin = New Padding(3, 4, 3, 4)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(176, 234)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 10
        PictureBox2.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(1044, 86)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 11
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Welcome
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        ClientSize = New Size(1262, 841)
        Controls.Add(Button1)
        Controls.Add(PictureBox2)
        Controls.Add(Label2)
        Controls.Add(GroupBox1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Welcome"
        Text = "Welcome"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Button1 As Button
End Class
