<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAppLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAppLogin))
        Me.txtAppUserName = New System.Windows.Forms.TextBox
        Me.lblAppName = New System.Windows.Forms.Label
        Me.lblAppUsername = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonDel = New System.Windows.Forms.ToolStripButton
        Me.cboAppName = New System.Windows.Forms.ComboBox
        Me.txtAppID = New System.Windows.Forms.TextBox
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAppUserName
        '
        Me.txtAppUserName.Location = New System.Drawing.Point(167, 69)
        Me.txtAppUserName.Name = "txtAppUserName"
        Me.txtAppUserName.Size = New System.Drawing.Size(100, 20)
        Me.txtAppUserName.TabIndex = 1
        '
        'lblAppName
        '
        Me.lblAppName.AutoSize = True
        Me.lblAppName.Location = New System.Drawing.Point(19, 50)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(59, 13)
        Me.lblAppName.TabIndex = 3
        Me.lblAppName.Text = "Application"
        '
        'lblAppUsername
        '
        Me.lblAppUsername.AutoSize = True
        Me.lblAppUsername.Location = New System.Drawing.Point(167, 50)
        Me.lblAppUsername.Name = "lblAppUsername"
        Me.lblAppUsername.Size = New System.Drawing.Size(89, 13)
        Me.lblAppUsername.TabIndex = 4
        Me.lblAppUsername.Text = "User Login Name"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonSave, Me.ToolStripButtonDel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(292, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSave.Image = CType(resources.GetObject("ToolStripButtonSave.Image"), System.Drawing.Image)
        Me.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSave.Name = "ToolStripButtonSave"
        Me.ToolStripButtonSave.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonSave.Text = "ToolStripButton1"
        '
        'ToolStripButtonDel
        '
        Me.ToolStripButtonDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDel.Image = CType(resources.GetObject("ToolStripButtonDel.Image"), System.Drawing.Image)
        Me.ToolStripButtonDel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDel.Name = "ToolStripButtonDel"
        Me.ToolStripButtonDel.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonDel.Text = "ToolStripButton2"
        '
        'cboAppName
        '
        Me.cboAppName.FormattingEnabled = True
        Me.cboAppName.Items.AddRange(New Object() {"SDB Codes", "Campus Partner", "Cashier Number", "External Cashier"})
        Me.cboAppName.Location = New System.Drawing.Point(22, 66)
        Me.cboAppName.Name = "cboAppName"
        Me.cboAppName.Size = New System.Drawing.Size(121, 21)
        Me.cboAppName.TabIndex = 8
        '
        'txtAppID
        '
        Me.txtAppID.Location = New System.Drawing.Point(12, 27)
        Me.txtAppID.Name = "txtAppID"
        Me.txtAppID.Size = New System.Drawing.Size(52, 20)
        Me.txtAppID.TabIndex = 9
        Me.txtAppID.Visible = False
        '
        'frmAppLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 139)
        Me.Controls.Add(Me.txtAppID)
        Me.Controls.Add(Me.cboAppName)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lblAppUsername)
        Me.Controls.Add(Me.lblAppName)
        Me.Controls.Add(Me.txtAppUserName)
        Me.Location = New System.Drawing.Point(650, 450)
        Me.Name = "frmAppLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Application Logins"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAppUserName As System.Windows.Forms.TextBox
    Friend WithEvents lblAppName As System.Windows.Forms.Label
    Friend WithEvents lblAppUsername As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboAppName As System.Windows.Forms.ComboBox
    Friend WithEvents txtAppID As System.Windows.Forms.TextBox
End Class
