<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mata_Pelajaran
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
        id_mapel = New DataGridViewTextBoxColumn()
        nama_mapel = New DataGridViewTextBoxColumn()
        id_guru = New DataGridViewTextBoxColumn()
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
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {id_mapel, nama_mapel, id_guru})
        DataGridView1.Location = New Point(20, 71)
        DataGridView1.Margin = New Padding(3, 4, 3, 4)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.RowTemplate.Height = 24
        DataGridView1.Size = New Size(930, 481)
        DataGridView1.TabIndex = 35
        ' 
        ' id_mapel
        ' 
        id_mapel.HeaderText = "Id Mapel"
        id_mapel.MinimumWidth = 6
        id_mapel.Name = "id_mapel"
        id_mapel.ReadOnly = True
        id_mapel.Width = 310
        ' 
        ' nama_mapel
        ' 
        nama_mapel.HeaderText = "Nama Mapel"
        nama_mapel.MinimumWidth = 6
        nama_mapel.Name = "nama_mapel"
        nama_mapel.ReadOnly = True
        nama_mapel.Width = 310
        ' 
        ' id_guru
        ' 
        id_guru.HeaderText = "Id Guru"
        id_guru.MinimumWidth = 6
        id_guru.Name = "id_guru"
        id_guru.ReadOnly = True
        id_guru.Width = 310
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.Location = New Point(304, 560)
        Button4.Margin = New Padding(3, 4, 3, 4)
        Button4.Name = "Button4"
        Button4.Size = New Size(136, 52)
        Button4.TabIndex = 42
        Button4.Text = "Hapus"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(162, 560)
        Button3.Margin = New Padding(3, 4, 3, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(136, 52)
        Button3.TabIndex = 41
        Button3.Text = "Ubah"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(20, 560)
        Button2.Margin = New Padding(3, 4, 3, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(136, 52)
        Button2.TabIndex = 40
        Button2.Text = "Tambah"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(672, 560)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(136, 52)
        Button1.TabIndex = 39
        Button1.Text = "Sebelum"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Lanjut
        ' 
        Lanjut.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Lanjut.Location = New Point(814, 560)
        Lanjut.Margin = New Padding(3, 4, 3, 4)
        Lanjut.Name = "Lanjut"
        Lanjut.Size = New Size(136, 52)
        Lanjut.TabIndex = 38
        Lanjut.Text = "Lanjut"
        Lanjut.UseVisualStyleBackColor = True
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = Color.LightGray
        TextBox2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox2.Location = New Point(752, 15)
        TextBox2.Margin = New Padding(3, 4, 3, 4)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(198, 36)
        TextBox2.TabIndex = 37
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(698, 23)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 25)
        Label3.TabIndex = 36
        Label3.Text = "Cari"
        ' 
        ' Mata_Pelajaran
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(253))
        ClientSize = New Size(971, 626)
        Controls.Add(DataGridView1)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Lanjut)
        Controls.Add(TextBox2)
        Controls.Add(Label3)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(3, 4, 3, 4)
        Name = "Mata_Pelajaran"
        Text = "Mata_Pelajaran"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents id_mapel As DataGridViewTextBoxColumn
    Friend WithEvents nama_mapel As DataGridViewTextBoxColumn
    Friend WithEvents id_guru As DataGridViewTextBoxColumn
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Lanjut As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
End Class
