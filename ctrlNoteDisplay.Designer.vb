<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlNoteDisplay
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlNoteDisplay))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnAddNote = New System.Windows.Forms.Button
        Me.grdNoteData = New System.Windows.Forms.DataGridView
        Me.lblGrid = New System.Windows.Forms.Label
        CType(Me.grdNoteData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAddNote
        '
        Me.btnAddNote.Image = CType(resources.GetObject("btnAddNote.Image"), System.Drawing.Image)
        Me.btnAddNote.Location = New System.Drawing.Point(435, 1)
        Me.btnAddNote.Name = "btnAddNote"
        Me.btnAddNote.Size = New System.Drawing.Size(30, 22)
        Me.btnAddNote.TabIndex = 5
        Me.btnAddNote.UseVisualStyleBackColor = True
        '
        'grdNoteData
        '
        Me.grdNoteData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNoteData.Location = New System.Drawing.Point(3, 26)
        Me.grdNoteData.Name = "grdNoteData"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdNoteData.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdNoteData.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grdNoteData.Size = New System.Drawing.Size(462, 111)
        Me.grdNoteData.TabIndex = 4
        '
        'lblGrid
        '
        Me.lblGrid.AutoSize = True
        Me.lblGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrid.Location = New System.Drawing.Point(3, 10)
        Me.lblGrid.Name = "lblGrid"
        Me.lblGrid.Size = New System.Drawing.Size(40, 13)
        Me.lblGrid.TabIndex = 9
        Me.lblGrid.Text = "Notes"
        '
        'ctrlNoteDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblGrid)
        Me.Controls.Add(Me.btnAddNote)
        Me.Controls.Add(Me.grdNoteData)
        Me.Name = "ctrlNoteDisplay"
        Me.Size = New System.Drawing.Size(468, 141)
        Me.Tag = "frmJV JV 123"
        CType(Me.grdNoteData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddNote As System.Windows.Forms.Button
    Friend WithEvents grdNoteData As System.Windows.Forms.DataGridView
    Friend WithEvents lblGrid As System.Windows.Forms.Label

End Class
