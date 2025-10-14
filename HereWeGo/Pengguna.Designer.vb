<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Pengguna
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
        DataGridView1 = New DataGridView()
        id_user = New DataGridViewTextBoxColumn()
        Email = New DataGridViewTextBoxColumn()
        Pasword = New DataGridViewTextBoxColumn()
        Role = New DataGridViewTextBoxColumn()
        Status = New DataGridViewTextBoxColumn()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Lanjut = New Button()
        TextBox2 = New TextBox()
        Label3 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {id_user, Email, Pasword, Role, Status})
        DataGridView1.Location = New Point(20, 72)
        DataGridView1.Margin = New Padding(3, 4, 3, 4)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.RowTemplate.Height = 24
        DataGridView1.Size = New Size(930, 635)
        DataGridView1.TabIndex = 22
        ' 
        ' id_user
        ' 
        id_user.HeaderText = "Id User"
        id_user.MinimumWidth = 6
        id_user.Name = "id_user"
        id_user.ReadOnly = True
        id_user.Width = 232
        ' 
        ' Email
        ' 
        Email.HeaderText = "Email"
        Email.MinimumWidth = 6
        Email.Name = "Email"
        Email.ReadOnly = True
        Email.Width = 232
        ' 
        ' Pasword
        ' 
        Pasword.HeaderText = "Pasword"
        Pasword.MinimumWidth = 6
        Pasword.Name = "Pasword"
        Pasword.ReadOnly = True
        Pasword.Width = 232
        ' 
        ' Role
        ' 
        Role.HeaderText = "Role"
        Role.MinimumWidth = 6
        Role.Name = "Role"
        Role.ReadOnly = True
        Role.Width = 232
        ' 
        ' Status
        ' 
        Status.HeaderText = "Status"
        Status.MinimumWidth = 6
        Status.Name = "Status"
        Status.ReadOnly = True
        Status.Width = 232
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.Location = New Point(262, 715)
        Button4.Margin = New Padding(3, 4, 3, 4)
        Button4.Name = "Button4"
        Button4.Size = New Size(115, 52)
        Button4.TabIndex = 29
        Button4.Text = "Hapus"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(141, 715)
        Button3.Margin = New Padding(3, 4, 3, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(115, 52)
        Button3.TabIndex = 28
        Button3.Text = "Ubah"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(20, 715)
        Button2.Margin = New Padding(3, 4, 3, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(115, 52)
        Button2.TabIndex = 27
        Button2.Text = "Tambah"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(752, 715)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(93, 52)
        Button1.TabIndex = 26
        Button1.Text = "Lihat"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Lanjut
        ' 
        Lanjut.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Lanjut.Location = New Point(851, 715)
        Lanjut.Margin = New Padding(3, 4, 3, 4)
        Lanjut.Name = "Lanjut"
        Lanjut.Size = New Size(93, 52)
        Lanjut.TabIndex = 25
        Lanjut.Text = "Lanjut"
        Lanjut.UseVisualStyleBackColor = True
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = Color.LightGray
        TextBox2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox2.Location = New Point(752, 16)
        TextBox2.Margin = New Padding(3, 4, 3, 4)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(198, 36)
        TextBox2.TabIndex = 24
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(698, 24)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 25)
        Label3.TabIndex = 23
        Label3.Text = "Cari"
        ' 
        ' Pengguna
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        ClientSize = New Size(971, 782)
        Controls.Add(DataGridView1)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Lanjut)
        Controls.Add(TextBox2)
        Controls.Add(Label3)
        Margin = New Padding(3, 4, 3, 4)
        Name = "Pengguna"
        Text = "Pengguna"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Lanjut As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents id_user As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents Pasword As DataGridViewTextBoxColumn
    Friend WithEvents Role As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
End Class
