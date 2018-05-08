<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepartment
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
        Dim btnEditDeptartment As System.Windows.Forms.Button
        Dim btnEditBudget As System.Windows.Forms.Button
        Dim btnEditMerchant As System.Windows.Forms.Button
        Dim btnAddMerchant As System.Windows.Forms.Button
        Dim btnAddBudget As System.Windows.Forms.Button
        Dim btnAddDept As System.Windows.Forms.Button
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepartment))
        Me.btnExit = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnSearch = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.grpDept = New System.Windows.Forms.GroupBox
        Me.lblDeptName = New System.Windows.Forms.Label
        Me.txtDeptName = New System.Windows.Forms.TextBox
        Me.lblDeptID = New System.Windows.Forms.Label
        Me.txtDeptID = New System.Windows.Forms.TextBox
        Me.grpBudgets = New System.Windows.Forms.GroupBox
        Me.grdBudgetDisplay = New System.Windows.Forms.DataGridView
        Me.grpMerchants = New System.Windows.Forms.GroupBox
        Me.grdMerchant = New System.Windows.Forms.DataGridView
        btnEditDeptartment = New System.Windows.Forms.Button
        btnEditBudget = New System.Windows.Forms.Button
        btnEditMerchant = New System.Windows.Forms.Button
        btnAddMerchant = New System.Windows.Forms.Button
        btnAddBudget = New System.Windows.Forms.Button
        btnAddDept = New System.Windows.Forms.Button
        Me.ToolStrip1.SuspendLayout()
        Me.grpDept.SuspendLayout()
        Me.grpBudgets.SuspendLayout()
        CType(Me.grdBudgetDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMerchants.SuspendLayout()
        CType(Me.grdMerchant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEditDeptartment
        '
        btnEditDeptartment.Location = New System.Drawing.Point(546, 28)
        btnEditDeptartment.Name = "btnEditDeptartment"
        btnEditDeptartment.Size = New System.Drawing.Size(47, 20)
        btnEditDeptartment.TabIndex = 28
        btnEditDeptartment.Text = "Edit"
        btnEditDeptartment.UseVisualStyleBackColor = True
        AddHandler btnEditDeptartment.Click, AddressOf Me.btnEditDeptartment_Click
        '
        'btnEditBudget
        '
        btnEditBudget.Location = New System.Drawing.Point(546, 90)
        btnEditBudget.Name = "btnEditBudget"
        btnEditBudget.Size = New System.Drawing.Size(47, 20)
        btnEditBudget.TabIndex = 29
        btnEditBudget.Text = "Edit"
        btnEditBudget.UseVisualStyleBackColor = True
        AddHandler btnEditBudget.Click, AddressOf Me.btnEditBudget_Click
        '
        'btnEditMerchant
        '
        btnEditMerchant.Location = New System.Drawing.Point(546, 259)
        btnEditMerchant.Name = "btnEditMerchant"
        btnEditMerchant.Size = New System.Drawing.Size(47, 20)
        btnEditMerchant.TabIndex = 31
        btnEditMerchant.Text = "Edit"
        btnEditMerchant.UseVisualStyleBackColor = True
        AddHandler btnEditMerchant.Click, AddressOf Me.btnEditMerchant_Click
        '
        'btnAddMerchant
        '
        btnAddMerchant.Location = New System.Drawing.Point(493, 259)
        btnAddMerchant.Name = "btnAddMerchant"
        btnAddMerchant.Size = New System.Drawing.Size(47, 20)
        btnAddMerchant.TabIndex = 32
        btnAddMerchant.Text = "Add"
        btnAddMerchant.UseVisualStyleBackColor = True
        AddHandler btnAddMerchant.Click, AddressOf Me.btnAddMerchant_Click
        '
        'btnAddBudget
        '
        btnAddBudget.Location = New System.Drawing.Point(493, 90)
        btnAddBudget.Name = "btnAddBudget"
        btnAddBudget.Size = New System.Drawing.Size(47, 20)
        btnAddBudget.TabIndex = 33
        btnAddBudget.Text = "Add"
        btnAddBudget.UseVisualStyleBackColor = True
        AddHandler btnAddBudget.Click, AddressOf Me.btnAddBudget_Click
        '
        'btnAddDept
        '
        btnAddDept.Location = New System.Drawing.Point(493, 28)
        btnAddDept.Name = "btnAddDept"
        btnAddDept.Size = New System.Drawing.Size(47, 20)
        btnAddDept.TabIndex = 34
        btnAddDept.Text = "Add"
        btnAddDept.UseVisualStyleBackColor = True
        AddHandler btnAddDept.Click, AddressOf Me.btnAddDept_Click
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(260, 478)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(91, 39)
        Me.btnExit.TabIndex = 22
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSearch, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(620, 25)
        Me.ToolStrip1.TabIndex = 25
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSearch
        '
        Me.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(23, 22)
        Me.btnSearch.Text = "Search"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'grpDept
        '
        Me.grpDept.Controls.Add(Me.lblDeptName)
        Me.grpDept.Controls.Add(Me.txtDeptName)
        Me.grpDept.Controls.Add(Me.lblDeptID)
        Me.grpDept.Controls.Add(Me.txtDeptID)
        Me.grpDept.Location = New System.Drawing.Point(12, 42)
        Me.grpDept.Name = "grpDept"
        Me.grpDept.Size = New System.Drawing.Size(596, 39)
        Me.grpDept.TabIndex = 27
        Me.grpDept.TabStop = False
        Me.grpDept.Text = "Department"
        '
        'lblDeptName
        '
        Me.lblDeptName.AutoSize = True
        Me.lblDeptName.Location = New System.Drawing.Point(147, 17)
        Me.lblDeptName.Name = "lblDeptName"
        Me.lblDeptName.Size = New System.Drawing.Size(38, 13)
        Me.lblDeptName.TabIndex = 6
        Me.lblDeptName.Text = "Name:"
        '
        'txtDeptName
        '
        Me.txtDeptName.BackColor = System.Drawing.SystemColors.Control
        Me.txtDeptName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDeptName.Location = New System.Drawing.Point(191, 17)
        Me.txtDeptName.Name = "txtDeptName"
        Me.txtDeptName.ReadOnly = True
        Me.txtDeptName.Size = New System.Drawing.Size(390, 13)
        Me.txtDeptName.TabIndex = 5
        '
        'lblDeptID
        '
        Me.lblDeptID.AutoSize = True
        Me.lblDeptID.Location = New System.Drawing.Point(8, 17)
        Me.lblDeptID.Name = "lblDeptID"
        Me.lblDeptID.Size = New System.Drawing.Size(21, 13)
        Me.lblDeptID.TabIndex = 4
        Me.lblDeptID.Text = "ID:"
        '
        'txtDeptID
        '
        Me.txtDeptID.BackColor = System.Drawing.SystemColors.Control
        Me.txtDeptID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDeptID.Location = New System.Drawing.Point(35, 17)
        Me.txtDeptID.Name = "txtDeptID"
        Me.txtDeptID.ReadOnly = True
        Me.txtDeptID.Size = New System.Drawing.Size(100, 13)
        Me.txtDeptID.TabIndex = 3
        '
        'grpBudgets
        '
        Me.grpBudgets.Controls.Add(Me.grdBudgetDisplay)
        Me.grpBudgets.Location = New System.Drawing.Point(12, 104)
        Me.grpBudgets.Name = "grpBudgets"
        Me.grpBudgets.Size = New System.Drawing.Size(596, 149)
        Me.grpBudgets.TabIndex = 28
        Me.grpBudgets.TabStop = False
        Me.grpBudgets.Text = "Budgets"
        '
        'grdBudgetDisplay
        '
        Me.grdBudgetDisplay.AllowUserToAddRows = False
        Me.grdBudgetDisplay.AllowUserToDeleteRows = False
        Me.grdBudgetDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBudgetDisplay.Location = New System.Drawing.Point(12, 19)
        Me.grdBudgetDisplay.Name = "grdBudgetDisplay"
        Me.grdBudgetDisplay.Size = New System.Drawing.Size(569, 124)
        Me.grdBudgetDisplay.TabIndex = 0
        '
        'grpMerchants
        '
        Me.grpMerchants.Controls.Add(Me.grdMerchant)
        Me.grpMerchants.Location = New System.Drawing.Point(12, 274)
        Me.grpMerchants.Name = "grpMerchants"
        Me.grpMerchants.Size = New System.Drawing.Size(596, 200)
        Me.grpMerchants.TabIndex = 30
        Me.grpMerchants.TabStop = False
        Me.grpMerchants.Text = "GroupBox1"
        '
        'grdMerchant
        '
        Me.grdMerchant.AllowUserToAddRows = False
        Me.grdMerchant.AllowUserToDeleteRows = False
        Me.grdMerchant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdMerchant.Location = New System.Drawing.Point(12, 19)
        Me.grdMerchant.Name = "grdMerchant"
        Me.grdMerchant.Size = New System.Drawing.Size(569, 175)
        Me.grdMerchant.TabIndex = 6
        '
        'frmDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 529)
        Me.ControlBox = False
        Me.Controls.Add(btnAddDept)
        Me.Controls.Add(btnAddBudget)
        Me.Controls.Add(btnAddMerchant)
        Me.Controls.Add(btnEditMerchant)
        Me.Controls.Add(Me.grpMerchants)
        Me.Controls.Add(btnEditBudget)
        Me.Controls.Add(Me.grpBudgets)
        Me.Controls.Add(btnEditDeptartment)
        Me.Controls.Add(Me.grpDept)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnExit)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDepartment"
        Me.ShowIcon = False
        Me.Text = "frmDepartment"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpDept.ResumeLayout(False)
        Me.grpDept.PerformLayout()
        Me.grpBudgets.ResumeLayout(False)
        CType(Me.grdBudgetDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMerchants.ResumeLayout(False)
        CType(Me.grdMerchant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpDept As System.Windows.Forms.GroupBox
    Friend WithEvents lblDeptName As System.Windows.Forms.Label
    Friend WithEvents txtDeptName As System.Windows.Forms.TextBox
    Friend WithEvents lblDeptID As System.Windows.Forms.Label
    Friend WithEvents txtDeptID As System.Windows.Forms.TextBox
    Friend WithEvents grpBudgets As System.Windows.Forms.GroupBox
    Friend WithEvents grdBudgetDisplay As System.Windows.Forms.DataGridView
    Friend WithEvents grpMerchants As System.Windows.Forms.GroupBox
    Friend WithEvents grdMerchant As System.Windows.Forms.DataGridView
End Class
