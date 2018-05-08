<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmARCVer
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
        Me.lstExternal = New System.Windows.Forms.ListBox
        Me.lstInternal = New System.Windows.Forms.ListBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnVerify = New System.Windows.Forms.Button
        Me.lblExternal = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.rptReconAdjustments1 = New SFS.rptReconAdjustments
        Me.SuspendLayout()
        '
        'lstExternal
        '
        Me.lstExternal.FormattingEnabled = True
        Me.lstExternal.Location = New System.Drawing.Point(8, 35)
        Me.lstExternal.Name = "lstExternal"
        Me.lstExternal.Size = New System.Drawing.Size(291, 186)
        Me.lstExternal.TabIndex = 1
        '
        'lstInternal
        '
        Me.lstInternal.FormattingEnabled = True
        Me.lstInternal.Location = New System.Drawing.Point(320, 35)
        Me.lstInternal.Name = "lstInternal"
        Me.lstInternal.Size = New System.Drawing.Size(295, 186)
        Me.lstInternal.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(310, 243)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 40)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnVerify
        '
        Me.btnVerify.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerify.Location = New System.Drawing.Point(191, 243)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(91, 40)
        Me.btnVerify.TabIndex = 6
        Me.btnVerify.Text = "Verify"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'lblExternal
        '
        Me.lblExternal.AutoSize = True
        Me.lblExternal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExternal.Location = New System.Drawing.Point(7, 19)
        Me.lblExternal.Name = "lblExternal"
        Me.lblExternal.Size = New System.Drawing.Size(88, 13)
        Me.lblExternal.TabIndex = 8
        Me.lblExternal.Text = "US Bank Data"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(317, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "ARC Data"
        '
        'frmARCVer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblExternal)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnVerify)
        Me.Controls.Add(Me.lstInternal)
        Me.Controls.Add(Me.lstExternal)
        Me.Name = "frmARCVer"
        Me.ShowIcon = False
        Me.Text = "ARC Verification"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstExternal As System.Windows.Forms.ListBox
    Friend WithEvents lstInternal As System.Windows.Forms.ListBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnVerify As System.Windows.Forms.Button
    Friend WithEvents lblExternal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rptReconAdjustments1 As SFS.rptReconAdjustments
End Class
