<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rfid
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
        DataGridView1 = New DataGridView()
        Button4 = New Button()
        Button3 = New Button()
        Button1 = New Button()
        Lanjut = New Button()
        TextBox2 = New TextBox()
        Label3 = New Label()
        card_id = New DataGridViewTextBoxColumn()
        nis = New DataGridViewTextBoxColumn()
        status = New DataGridViewTextBoxColumn()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {card_id, nis, status})
        DataGridView1.Location = New Point(20, 72)
        DataGridView1.Margin = New Padding(3, 4, 3, 4)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.RowTemplate.Height = 24
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(930, 478)
        DataGridView1.TabIndex = 43
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.Location = New Point(162, 561)
        Button4.Margin = New Padding(3, 4, 3, 4)
        Button4.Name = "Button4"
        Button4.Size = New Size(136, 52)
        Button4.TabIndex = 50
        Button4.Text = "Hapus"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(20, 561)
        Button3.Margin = New Padding(3, 4, 3, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(136, 52)
        Button3.TabIndex = 49
        Button3.Text = "Ubah"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(672, 558)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(136, 52)
        Button1.TabIndex = 47
        Button1.Text = "Sebelum"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Lanjut
        ' 
        Lanjut.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Lanjut.Location = New Point(814, 558)
        Lanjut.Margin = New Padding(3, 4, 3, 4)
        Lanjut.Name = "Lanjut"
        Lanjut.Size = New Size(136, 52)
        Lanjut.TabIndex = 46
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
        TextBox2.TabIndex = 45
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(698, 24)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 25)
        Label3.TabIndex = 44
        Label3.Text = "Cari"
        ' 
        ' card_id
        ' 
        card_id.HeaderText = "Card ID"
        card_id.MinimumWidth = 6
        card_id.Name = "card_id"
        card_id.ReadOnly = True
        card_id.Width = 310
        ' 
        ' nis
        ' 
        nis.HeaderText = "NIS"
        nis.MinimumWidth = 6
        nis.Name = "nis"
        nis.ReadOnly = True
        nis.Width = 310
        ' 
        ' status
        ' 
        status.HeaderText = "Status"
        status.MinimumWidth = 6
        status.Name = "status"
        status.ReadOnly = True
        status.Width = 310
        ' 
        ' Rfid
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        ClientSize = New Size(971, 626)
        Controls.Add(DataGridView1)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button1)
        Controls.Add(Lanjut)
        Controls.Add(TextBox2)
        Controls.Add(Label3)
        Name = "Rfid"
        Text = "Rfid"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Lanjut As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents card_id As DataGridViewTextBoxColumn
    Friend WithEvents nis As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
End Class
