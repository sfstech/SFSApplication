<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.lblAsOf = New System.Windows.Forms.Label
        Me.txtAsOf = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtImportedBy = New System.Windows.Forms.TextBox
        Me.lblImportUser = New System.Windows.Forms.Label
        Me.txtImportOn = New System.Windows.Forms.TextBox
        Me.lblImportDate = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 52)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(933, 476)
        Me.DataGridView1.TabIndex = 0
        '
        'lblAsOf
        '
        Me.lblAsOf.AutoSize = True
        Me.lblAsOf.Location = New System.Drawing.Point(23, 19)
        Me.lblAsOf.Name = "lblAsOf"
        Me.lblAsOf.Size = New System.Drawing.Size(62, 13)
        Me.lblAsOf.TabIndex = 1
        Me.lblAsOf.Text = "As Of Date:"
        '
        'txtAsOf
        '
        Me.txtAsOf.BackColor = System.Drawing.SystemColors.Control
        Me.txtAsOf.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAsOf.Location = New System.Drawing.Point(91, 19)
        Me.txtAsOf.Name = "txtAsOf"
        Me.txtAsOf.ReadOnly = True
        Me.txtAsOf.Size = New System.Drawing.Size(100, 13)
        Me.txtAsOf.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(424, 551)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 40)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtImportedBy
        '
        Me.txtImportedBy.BackColor = System.Drawing.SystemColors.Control
        Me.txtImportedBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtImportedBy.Location = New System.Drawing.Point(291, 19)
        Me.txtImportedBy.Name = "txtImportedBy"
        Me.txtImportedBy.ReadOnly = True
        Me.txtImportedBy.Size = New System.Drawing.Size(100, 13)
        Me.txtImportedBy.TabIndex = 8
        '
        'lblImportUser
        '
        Me.lblImportUser.AutoSize = True
        Me.lblImportUser.Location = New System.Drawing.Point(223, 19)
        Me.lblImportUser.Name = "lblImportUser"
        Me.lblImportUser.Size = New System.Drawing.Size(66, 13)
        Me.lblImportUser.TabIndex = 7
        Me.lblImportUser.Text = "Imported By:"
        '
        'txtImportOn
        '
        Me.txtImportOn.BackColor = System.Drawing.SystemColors.Control
        Me.txtImportOn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtImportOn.Location = New System.Drawing.Point(495, 19)
        Me.txtImportOn.Name = "txtImportOn"
        Me.txtImportOn.ReadOnly = True
        Me.txtImportOn.Size = New System.Drawing.Size(100, 13)
        Me.txtImportOn.TabIndex = 10
        '
        'lblImportDate
        '
        Me.lblImportDate.AutoSize = True
        Me.lblImportDate.Location = New System.Drawing.Point(421, 19)
        Me.lblImportDate.Name = "lblImportDate"
        Me.lblImportDate.Size = New System.Drawing.Size(68, 13)
        Me.lblImportDate.TabIndex = 9
        Me.lblImportDate.Text = "Imported On:"
        '
        'frmBankData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 603)
        Me.Controls.Add(Me.txtImportOn)
        Me.Controls.Add(Me.lblImportDate)
        Me.Controls.Add(Me.txtImportedBy)
        Me.Controls.Add(Me.lblImportUser)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtAsOf)
        Me.Controls.Add(Me.lblAsOf)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmBankData"
        Me.ShowIcon = False
        Me.Text = "frmBankData"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lblAsOf As System.Windows.Forms.Label
    Friend WithEvents txtAsOf As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtImportedBy As System.Windows.Forms.TextBox
    Friend WithEvents lblImportUser As System.Windows.Forms.Label
    Friend WithEvents txtImportOn As System.Windows.Forms.TextBox
    Friend WithEvents lblImportDate As System.Windows.Forms.Label
End Class
