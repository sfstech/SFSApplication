<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashierDetail
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCashierDetail))
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.lblType = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.lblAmount = New System.Windows.Forms.Label
        Me.lblCount = New System.Windows.Forms.Label
        Me.txtCount = New System.Windows.Forms.TextBox
        Me.tsCashierEdit = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnHelp = New System.Windows.Forms.ToolStripButton
        Me.ErrProvCashDet = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnGo = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblKnowCount = New System.Windows.Forms.Label
        Me.cboKnowCount = New System.Windows.Forms.ComboBox
        Me.lblKnowCount2 = New System.Windows.Forms.Label
        Me.tsCashierEdit.SuspendLayout()
        CType(Me.ErrProvCashDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboType
        '
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(89, 33)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(121, 21)
        Me.cboType.TabIndex = 0
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(44, 41)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(39, 13)
        Me.lblType.TabIndex = 1
        Me.lblType.Text = "Type:"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(89, 60)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(121, 20)
        Me.txtAmount.TabIndex = 2
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.Location = New System.Drawing.Point(30, 67)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(53, 13)
        Me.lblAmount.TabIndex = 3
        Me.lblAmount.Text = "Amount:"
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.Location = New System.Drawing.Point(39, 89)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(44, 13)
        Me.lblCount.TabIndex = 5
        Me.lblCount.Text = "Count:"
        '
        'txtCount
        '
        Me.txtCount.Location = New System.Drawing.Point(89, 86)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(33, 20)
        Me.txtCount.TabIndex = 4
        Me.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsCashierEdit
        '
        Me.tsCashierEdit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnDelete, Me.btnHelp})
        Me.tsCashierEdit.Location = New System.Drawing.Point(0, 0)
        Me.tsCashierEdit.Name = "tsCashierEdit"
        Me.tsCashierEdit.Size = New System.Drawing.Size(235, 25)
        Me.tsCashierEdit.TabIndex = 15
        Me.tsCashierEdit.Text = "ToolStrip1"
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(23, 22)
        Me.btnSave.Text = "Save Data Record"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(23, 22)
        Me.btnDelete.Text = "Delete Record"
        '
        'btnHelp
        '
        Me.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(23, 22)
        Me.btnHelp.Text = "ToolStripButton1"
        Me.btnHelp.ToolTipText = "KeyBoard -->   Enter  -  Save,   ESC - Cancel,   Tab - Next Field"
        '
        'ErrProvCashDet
        '
        Me.ErrProvCashDet.BlinkRate = 1000
        Me.ErrProvCashDet.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.ErrProvCashDet.ContainerControl = Me
        '
        'btnGo
        '
        Me.btnGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.ForeColor = System.Drawing.Color.Green
        Me.btnGo.Location = New System.Drawing.Point(62, 146)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(47, 20)
        Me.btnGo.TabIndex = 16
        Me.btnGo.TabStop = False
        Me.btnGo.Text = "Save"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Red
        Me.btnCancel.Location = New System.Drawing.Point(124, 146)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 20)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblKnowCount
        '
        Me.lblKnowCount.AutoSize = True
        Me.lblKnowCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKnowCount.Location = New System.Drawing.Point(6, 110)
        Me.lblKnowCount.Name = "lblKnowCount"
        Me.lblKnowCount.Size = New System.Drawing.Size(85, 13)
        Me.lblKnowCount.TabIndex = 18
        Me.lblKnowCount.Text = "Do you know "
        Me.lblKnowCount.Visible = False
        '
        'cboKnowCount
        '
        Me.cboKnowCount.FormattingEnabled = True
        Me.cboKnowCount.Items.AddRange(New Object() {"No", "Yes"})
        Me.cboKnowCount.Location = New System.Drawing.Point(89, 115)
        Me.cboKnowCount.Name = "cboKnowCount"
        Me.cboKnowCount.Size = New System.Drawing.Size(76, 21)
        Me.cboKnowCount.TabIndex = 19
        Me.cboKnowCount.Text = "No"
        Me.cboKnowCount.Visible = False
        '
        'lblKnowCount2
        '
        Me.lblKnowCount2.AutoSize = True
        Me.lblKnowCount2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKnowCount2.Location = New System.Drawing.Point(11, 124)
        Me.lblKnowCount2.Name = "lblKnowCount2"
        Me.lblKnowCount2.Size = New System.Drawing.Size(72, 13)
        Me.lblKnowCount2.TabIndex = 20
        Me.lblKnowCount2.Text = "the count?:"
        Me.lblKnowCount2.Visible = False
        '
        'frmCashierDetail
        '
        Me.AcceptButton = Me.btnGo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(235, 178)
        Me.Controls.Add(Me.lblKnowCount2)
        Me.Controls.Add(Me.cboKnowCount)
        Me.Controls.Add(Me.lblKnowCount)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.tsCashierEdit)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.cboType)
        Me.Location = New System.Drawing.Point(520, 50)
        Me.Name = "frmCashierDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cashier Transaction"
        Me.tsCashierEdit.ResumeLayout(False)
        Me.tsCashierEdit.PerformLayout()
        CType(Me.ErrProvCashDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents tsCashierEdit As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrProvCashDet As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboKnowCount As System.Windows.Forms.ComboBox
    Friend WithEvents lblKnowCount As System.Windows.Forms.Label
    Friend WithEvents lblKnowCount2 As System.Windows.Forms.Label
End Class
