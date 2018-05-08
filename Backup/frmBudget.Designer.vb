<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBudget
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBudget))
        Me.txtBudgetID = New System.Windows.Forms.TextBox
        Me.txtAction = New System.Windows.Forms.TextBox
        Me.lblBudgetNum = New System.Windows.Forms.Label
        Me.txtDeptID = New System.Windows.Forms.TextBox
        Me.txtDeptName = New System.Windows.Forms.TextBox
        Me.lblDeptName = New System.Windows.Forms.Label
        Me.lblRevCode = New System.Windows.Forms.Label
        Me.txtTask = New System.Windows.Forms.TextBox
        Me.lblTask = New System.Windows.Forms.Label
        Me.txtOption = New System.Windows.Forms.TextBox
        Me.lblOption = New System.Windows.Forms.Label
        Me.txtProject = New System.Windows.Forms.TextBox
        Me.lblProject = New System.Windows.Forms.Label
        Me.txtCreateUser = New System.Windows.Forms.TextBox
        Me.lblCreateUser = New System.Windows.Forms.Label
        Me.txtCreateDate = New System.Windows.Forms.TextBox
        Me.lblCreateDate = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnSaveBudget = New System.Windows.Forms.ToolStripButton
        Me.txtBudgetNum = New System.Windows.Forms.MaskedTextBox
        Me.txtRevCode = New System.Windows.Forms.MaskedTextBox
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBudgetID
        '
        Me.txtBudgetID.Location = New System.Drawing.Point(174, 108)
        Me.txtBudgetID.Name = "txtBudgetID"
        Me.txtBudgetID.Size = New System.Drawing.Size(10, 20)
        Me.txtBudgetID.TabIndex = 0
        Me.txtBudgetID.Visible = False
        '
        'txtAction
        '
        Me.txtAction.Location = New System.Drawing.Point(164, 108)
        Me.txtAction.Name = "txtAction"
        Me.txtAction.Size = New System.Drawing.Size(10, 20)
        Me.txtAction.TabIndex = 2
        Me.txtAction.Visible = False
        '
        'lblBudgetNum
        '
        Me.lblBudgetNum.AutoSize = True
        Me.lblBudgetNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBudgetNum.Location = New System.Drawing.Point(4, 59)
        Me.lblBudgetNum.Name = "lblBudgetNum"
        Me.lblBudgetNum.Size = New System.Drawing.Size(54, 13)
        Me.lblBudgetNum.TabIndex = 25
        Me.lblBudgetNum.Text = "Budget #:"
        '
        'txtDeptID
        '
        Me.txtDeptID.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeptID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeptID.Location = New System.Drawing.Point(190, 108)
        Me.txtDeptID.Name = "txtDeptID"
        Me.txtDeptID.ReadOnly = True
        Me.txtDeptID.Size = New System.Drawing.Size(10, 20)
        Me.txtDeptID.TabIndex = 28
        Me.txtDeptID.Visible = False
        '
        'txtDeptName
        '
        Me.txtDeptName.BackColor = System.Drawing.SystemColors.Control
        Me.txtDeptName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDeptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeptName.Location = New System.Drawing.Point(72, 34)
        Me.txtDeptName.Name = "txtDeptName"
        Me.txtDeptName.ReadOnly = True
        Me.txtDeptName.Size = New System.Drawing.Size(312, 13)
        Me.txtDeptName.TabIndex = 30
        Me.txtDeptName.TabStop = False
        '
        'lblDeptName
        '
        Me.lblDeptName.AutoSize = True
        Me.lblDeptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeptName.Location = New System.Drawing.Point(4, 34)
        Me.lblDeptName.Name = "lblDeptName"
        Me.lblDeptName.Size = New System.Drawing.Size(65, 13)
        Me.lblDeptName.TabIndex = 29
        Me.lblDeptName.Text = "Department:"
        '
        'lblRevCode
        '
        Me.lblRevCode.AutoSize = True
        Me.lblRevCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRevCode.Location = New System.Drawing.Point(212, 59)
        Me.lblRevCode.Name = "lblRevCode"
        Me.lblRevCode.Size = New System.Drawing.Size(58, 13)
        Me.lblRevCode.TabIndex = 31
        Me.lblRevCode.Text = "Rev Code:"
        '
        'txtTask
        '
        Me.txtTask.Location = New System.Drawing.Point(72, 82)
        Me.txtTask.Name = "txtTask"
        Me.txtTask.Size = New System.Drawing.Size(47, 20)
        Me.txtTask.TabIndex = 2
        '
        'lblTask
        '
        Me.lblTask.AutoSize = True
        Me.lblTask.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTask.Location = New System.Drawing.Point(4, 85)
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(34, 13)
        Me.lblTask.TabIndex = 33
        Me.lblTask.Text = "Task:"
        '
        'txtOption
        '
        Me.txtOption.Location = New System.Drawing.Point(203, 82)
        Me.txtOption.Name = "txtOption"
        Me.txtOption.Size = New System.Drawing.Size(47, 20)
        Me.txtOption.TabIndex = 3
        '
        'lblOption
        '
        Me.lblOption.AutoSize = True
        Me.lblOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOption.Location = New System.Drawing.Point(149, 85)
        Me.lblOption.Name = "lblOption"
        Me.lblOption.Size = New System.Drawing.Size(41, 13)
        Me.lblOption.TabIndex = 35
        Me.lblOption.Text = "Option:"
        '
        'txtProject
        '
        Me.txtProject.Location = New System.Drawing.Point(337, 82)
        Me.txtProject.Name = "txtProject"
        Me.txtProject.Size = New System.Drawing.Size(47, 20)
        Me.txtProject.TabIndex = 4
        '
        'lblProject
        '
        Me.lblProject.AutoSize = True
        Me.lblProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProject.Location = New System.Drawing.Point(281, 84)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(43, 13)
        Me.lblProject.TabIndex = 37
        Me.lblProject.Text = "Project:"
        '
        'txtCreateUser
        '
        Me.txtCreateUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreateUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreateUser.Location = New System.Drawing.Point(72, 111)
        Me.txtCreateUser.Name = "txtCreateUser"
        Me.txtCreateUser.ReadOnly = True
        Me.txtCreateUser.Size = New System.Drawing.Size(86, 13)
        Me.txtCreateUser.TabIndex = 40
        Me.txtCreateUser.TabStop = False
        '
        'lblCreateUser
        '
        Me.lblCreateUser.AutoSize = True
        Me.lblCreateUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreateUser.Location = New System.Drawing.Point(4, 111)
        Me.lblCreateUser.Name = "lblCreateUser"
        Me.lblCreateUser.Size = New System.Drawing.Size(62, 13)
        Me.lblCreateUser.TabIndex = 39
        Me.lblCreateUser.Text = "Created By:"
        '
        'txtCreateDate
        '
        Me.txtCreateDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreateDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreateDate.Location = New System.Drawing.Point(284, 111)
        Me.txtCreateDate.Name = "txtCreateDate"
        Me.txtCreateDate.ReadOnly = True
        Me.txtCreateDate.Size = New System.Drawing.Size(100, 13)
        Me.txtCreateDate.TabIndex = 42
        Me.txtCreateDate.TabStop = False
        '
        'lblCreateDate
        '
        Me.lblCreateDate.AutoSize = True
        Me.lblCreateDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreateDate.Location = New System.Drawing.Point(206, 111)
        Me.lblCreateDate.Name = "lblCreateDate"
        Me.lblCreateDate.Size = New System.Drawing.Size(64, 13)
        Me.lblCreateDate.TabIndex = 41
        Me.lblCreateDate.Text = "Created On:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSaveBudget})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(396, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSaveBudget
        '
        Me.btnSaveBudget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSaveBudget.Image = CType(resources.GetObject("btnSaveBudget.Image"), System.Drawing.Image)
        Me.btnSaveBudget.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveBudget.Name = "btnSaveBudget"
        Me.btnSaveBudget.Size = New System.Drawing.Size(23, 22)
        Me.btnSaveBudget.Text = "ToolStripButton1"
        '
        'txtBudgetNum
        '
        Me.txtBudgetNum.Location = New System.Drawing.Point(72, 56)
        Me.txtBudgetNum.Mask = "##-####"
        Me.txtBudgetNum.Name = "txtBudgetNum"
        Me.txtBudgetNum.Size = New System.Drawing.Size(100, 20)
        Me.txtBudgetNum.TabIndex = 0
        '
        'txtRevCode
        '
        Me.txtRevCode.Location = New System.Drawing.Point(276, 56)
        Me.txtRevCode.Mask = "####-##"
        Me.txtRevCode.Name = "txtRevCode"
        Me.txtRevCode.Size = New System.Drawing.Size(100, 20)
        Me.txtRevCode.TabIndex = 1
        '
        'frmBudget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 141)
        Me.Controls.Add(Me.txtRevCode)
        Me.Controls.Add(Me.txtBudgetNum)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtCreateDate)
        Me.Controls.Add(Me.lblCreateDate)
        Me.Controls.Add(Me.txtCreateUser)
        Me.Controls.Add(Me.lblCreateUser)
        Me.Controls.Add(Me.txtProject)
        Me.Controls.Add(Me.lblProject)
        Me.Controls.Add(Me.txtOption)
        Me.Controls.Add(Me.lblOption)
        Me.Controls.Add(Me.txtTask)
        Me.Controls.Add(Me.lblTask)
        Me.Controls.Add(Me.lblRevCode)
        Me.Controls.Add(Me.txtDeptName)
        Me.Controls.Add(Me.lblDeptName)
        Me.Controls.Add(Me.txtDeptID)
        Me.Controls.Add(Me.lblBudgetNum)
        Me.Controls.Add(Me.txtAction)
        Me.Controls.Add(Me.txtBudgetID)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBudget"
        Me.ShowIcon = False
        Me.Text = "Budget"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBudgetID As System.Windows.Forms.TextBox
    Friend WithEvents txtAction As System.Windows.Forms.TextBox
    Friend WithEvents lblBudgetNum As System.Windows.Forms.Label
    Friend WithEvents txtDeptID As System.Windows.Forms.TextBox
    Friend WithEvents txtDeptName As System.Windows.Forms.TextBox
    Friend WithEvents lblDeptName As System.Windows.Forms.Label
    Friend WithEvents lblRevCode As System.Windows.Forms.Label
    Friend WithEvents txtTask As System.Windows.Forms.TextBox
    Friend WithEvents lblTask As System.Windows.Forms.Label
    Friend WithEvents txtOption As System.Windows.Forms.TextBox
    Friend WithEvents lblOption As System.Windows.Forms.Label
    Friend WithEvents txtProject As System.Windows.Forms.TextBox
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents txtCreateUser As System.Windows.Forms.TextBox
    Friend WithEvents lblCreateUser As System.Windows.Forms.Label
    Friend WithEvents txtCreateDate As System.Windows.Forms.TextBox
    Friend WithEvents lblCreateDate As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSaveBudget As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtBudgetNum As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtRevCode As System.Windows.Forms.MaskedTextBox
End Class
