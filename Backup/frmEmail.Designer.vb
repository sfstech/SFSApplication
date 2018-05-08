<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmail))
        Me.txtFrom = New System.Windows.Forms.TextBox
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.txtMessage = New System.Windows.Forms.TextBox
        Me.txtNebulaPassword = New System.Windows.Forms.MaskedTextBox
        Me.lblTo = New System.Windows.Forms.Label
        Me.lblFrom = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblSubject = New System.Windows.Forms.Label
        Me.lblMessage = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnSend = New System.Windows.Forms.ToolStripButton
        Me.CachedrptDailyBankTransfer1 = New SFS.CachedrptDailyBankTransfer
        Me.lblAttachment = New System.Windows.Forms.Label
        Me.txtAttachement = New System.Windows.Forms.TextBox
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(77, 55)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(243, 20)
        Me.txtFrom.TabIndex = 1
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(77, 29)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(243, 20)
        Me.txtTo.TabIndex = 0
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(77, 107)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(475, 20)
        Me.txtSubject.TabIndex = 4
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(77, 133)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(475, 205)
        Me.txtMessage.TabIndex = 5
        '
        'txtNebulaPassword
        '
        Me.txtNebulaPassword.Location = New System.Drawing.Point(423, 55)
        Me.txtNebulaPassword.Name = "txtNebulaPassword"
        Me.txtNebulaPassword.Size = New System.Drawing.Size(129, 20)
        Me.txtNebulaPassword.TabIndex = 2
        Me.txtNebulaPassword.UseSystemPasswordChar = True
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(32, 29)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(23, 13)
        Me.lblTo.TabIndex = 5
        Me.lblTo.Text = "To:"
        Me.lblTo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(22, 55)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(33, 13)
        Me.lblFrom.TabIndex = 6
        Me.lblFrom.Text = "From:"
        Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(324, 58)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(93, 13)
        Me.lblPassword.TabIndex = 7
        Me.lblPassword.Text = "Nebula Password:"
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Location = New System.Drawing.Point(9, 107)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(46, 13)
        Me.lblSubject.TabIndex = 8
        Me.lblSubject.Text = "Subject:"
        Me.lblSubject.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(8, 136)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(53, 13)
        Me.lblMessage.TabIndex = 9
        Me.lblMessage.Text = "Message:"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSend})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(567, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSend
        '
        Me.btnSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSend.Image = CType(resources.GetObject("btnSend.Image"), System.Drawing.Image)
        Me.btnSend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(23, 22)
        Me.btnSend.Text = "ToolStripButton1"
        Me.btnSend.ToolTipText = "Send Email"
        '
        'lblAttachment
        '
        Me.lblAttachment.AutoSize = True
        Me.lblAttachment.Location = New System.Drawing.Point(9, 81)
        Me.lblAttachment.Name = "lblAttachment"
        Me.lblAttachment.Size = New System.Drawing.Size(64, 13)
        Me.lblAttachment.TabIndex = 12
        Me.lblAttachment.Text = "Attachment:"
        Me.lblAttachment.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtAttachement
        '
        Me.txtAttachement.Location = New System.Drawing.Point(77, 81)
        Me.txtAttachement.Name = "txtAttachement"
        Me.txtAttachement.Size = New System.Drawing.Size(475, 20)
        Me.txtAttachement.TabIndex = 3
        '
        'frmEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 353)
        Me.Controls.Add(Me.lblAttachment)
        Me.Controls.Add(Me.txtAttachement)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.txtNebulaPassword)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.txtFrom)
        Me.Name = "frmEmail"
        Me.Text = "frmEmail"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtNebulaPassword As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSend As System.Windows.Forms.ToolStripButton
    Friend WithEvents CachedrptDailyBankTransfer1 As SFS.CachedrptDailyBankTransfer
    Friend WithEvents lblAttachment As System.Windows.Forms.Label
    Friend WithEvents txtAttachement As System.Windows.Forms.TextBox
End Class
