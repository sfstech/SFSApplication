<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDirdepEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDirdepEmail))
        Me.lblAttachment = New System.Windows.Forms.Label
        Me.txtAttachment = New System.Windows.Forms.TextBox
        Me.lblSubject = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblFrom = New System.Windows.Forms.Label
        Me.lblTo = New System.Windows.Forms.Label
        Me.txtNebulaPassword = New System.Windows.Forms.MaskedTextBox
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.txtFrom = New System.Windows.Forms.TextBox
        Me.lblMessage = New System.Windows.Forms.Label
        Me.txtMessage = New System.Windows.Forms.TextBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.btnSend = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnPreview = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblAttachment
        '
        Me.lblAttachment.AutoSize = True
        Me.lblAttachment.Location = New System.Drawing.Point(36, 93)
        Me.lblAttachment.Name = "lblAttachment"
        Me.lblAttachment.Size = New System.Drawing.Size(64, 13)
        Me.lblAttachment.TabIndex = 22
        Me.lblAttachment.Text = "Attachment:"
        Me.lblAttachment.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtAttachment
        '
        Me.txtAttachment.Location = New System.Drawing.Point(104, 93)
        Me.txtAttachment.Name = "txtAttachment"
        Me.txtAttachment.Size = New System.Drawing.Size(475, 20)
        Me.txtAttachment.TabIndex = 16
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Location = New System.Drawing.Point(36, 119)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(46, 13)
        Me.lblSubject.TabIndex = 21
        Me.lblSubject.Text = "Subject:"
        Me.lblSubject.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(351, 70)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(93, 13)
        Me.lblPassword.TabIndex = 20
        Me.lblPassword.Text = "Nebula Password:"
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(49, 67)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(33, 13)
        Me.lblFrom.TabIndex = 19
        Me.lblFrom.Text = "From:"
        Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(59, 41)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(23, 13)
        Me.lblTo.TabIndex = 18
        Me.lblTo.Text = "To:"
        Me.lblTo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtNebulaPassword
        '
        Me.txtNebulaPassword.Location = New System.Drawing.Point(450, 67)
        Me.txtNebulaPassword.Name = "txtNebulaPassword"
        Me.txtNebulaPassword.Size = New System.Drawing.Size(129, 20)
        Me.txtNebulaPassword.TabIndex = 15
        Me.txtNebulaPassword.UseSystemPasswordChar = True
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(104, 119)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(475, 20)
        Me.txtSubject.TabIndex = 17
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(104, 41)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(243, 20)
        Me.txtTo.TabIndex = 13
        '
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(104, 67)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(243, 20)
        Me.txtFrom.TabIndex = 14
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(29, 156)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(53, 13)
        Me.lblMessage.TabIndex = 25
        Me.lblMessage.Text = "Message:"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(104, 153)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(475, 127)
        Me.txtMessage.TabIndex = 24
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(585, 91)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 23)
        Me.btnBrowse.TabIndex = 39
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnSend
        '
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.Color.Green
        Me.btnSend.Image = CType(resources.GetObject("btnSend.Image"), System.Drawing.Image)
        Me.btnSend.Location = New System.Drawing.Point(189, 311)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(106, 23)
        Me.btnSend.TabIndex = 40
        Me.btnSend.Text = "Send      Email"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(377, 311)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
        Me.btnPreview.Location = New System.Drawing.Point(615, 91)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(24, 23)
        Me.btnPreview.TabIndex = 42
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'frmDirdepEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 358)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.lblAttachment)
        Me.Controls.Add(Me.txtAttachment)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.txtNebulaPassword)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.txtFrom)
        Me.Name = "frmDirdepEmail"
        Me.Text = "frmDirdepEmail"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAttachment As System.Windows.Forms.Label
    Friend WithEvents txtAttachment As System.Windows.Forms.TextBox
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents txtNebulaPassword As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
End Class
