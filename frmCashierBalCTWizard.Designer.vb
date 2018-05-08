<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashierBalCTWizard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCashierBalCTWizard))
        Me.txtCount = New System.Windows.Forms.TextBox
        Me.lblCount = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.grdCTAmounts = New System.Windows.Forms.DataGridView
        Me.tsCTWizard = New System.Windows.Forms.ToolStrip
        Me.tsBtnDel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        CType(Me.grdCTAmounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsCTWizard.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCount
        '
        Me.txtCount.AcceptsReturn = True
        Me.txtCount.Enabled = False
        Me.txtCount.Location = New System.Drawing.Point(60, 181)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(26, 20)
        Me.txtCount.TabIndex = 16
        Me.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.Location = New System.Drawing.Point(14, 188)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(40, 13)
        Me.lblCount.TabIndex = 15
        Me.lblCount.Text = "Count"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(102, 188)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(36, 13)
        Me.lblTotal.TabIndex = 14
        Me.lblTotal.Text = "Total"
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(151, 181)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(98, 20)
        Me.txtTotal.TabIndex = 13
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Red
        Me.btnExit.Location = New System.Drawing.Point(163, 223)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(65, 23)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "Cancel"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Green
        Me.btnSave.Location = New System.Drawing.Point(60, 223)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(65, 23)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Location = New System.Drawing.Point(1, 223)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(65, 23)
        Me.btnReset.TabIndex = 10
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        Me.btnReset.Visible = False
        '
        'grdCTAmounts
        '
        Me.grdCTAmounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCTAmounts.Location = New System.Drawing.Point(24, 25)
        Me.grdCTAmounts.Name = "grdCTAmounts"
        Me.grdCTAmounts.Size = New System.Drawing.Size(240, 150)
        Me.grdCTAmounts.TabIndex = 9
        '
        'tsCTWizard
        '
        Me.tsCTWizard.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsBtnDel, Me.ToolStripButton1})
        Me.tsCTWizard.Location = New System.Drawing.Point(0, 0)
        Me.tsCTWizard.Name = "tsCTWizard"
        Me.tsCTWizard.Size = New System.Drawing.Size(292, 25)
        Me.tsCTWizard.TabIndex = 17
        Me.tsCTWizard.Text = "ToolStrip1"
        '
        'tsBtnDel
        '
        Me.tsBtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtnDel.Image = CType(resources.GetObject("tsBtnDel.Image"), System.Drawing.Image)
        Me.tsBtnDel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnDel.Name = "tsBtnDel"
        Me.tsBtnDel.Size = New System.Drawing.Size(23, 22)
        Me.tsBtnDel.Text = "ToolStripButton1"
        Me.tsBtnDel.ToolTipText = "Delete"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'frmCashierBalCTWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.tsCTWizard)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.grdCTAmounts)
        Me.Location = New System.Drawing.Point(520, 50)
        Me.Name = "frmCashierBalCTWizard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmCashierBalCTWizard"
        CType(Me.grdCTAmounts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsCTWizard.ResumeLayout(False)
        Me.tsCTWizard.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents grdCTAmounts As System.Windows.Forms.DataGridView
    Friend WithEvents tsCTWizard As System.Windows.Forms.ToolStrip
    Friend WithEvents tsBtnDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
