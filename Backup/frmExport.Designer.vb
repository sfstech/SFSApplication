<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
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
        Me.grdDataList = New System.Windows.Forms.DataGridView
        Me.lblAmount = New System.Windows.Forms.Label
        Me.txtTotalAmount = New System.Windows.Forms.TextBox
        Me.lblNumberOfTran = New System.Windows.Forms.Label
        Me.txtNumberOfTran = New System.Windows.Forms.TextBox
        Me.lblDate = New System.Windows.Forms.Label
        Me.txtCreateDate = New System.Windows.Forms.TextBox
        Me.lblUser = New System.Windows.Forms.Label
        Me.txtCreateUser = New System.Windows.Forms.TextBox
        Me.lblFileName = New System.Windows.Forms.Label
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.btnGO = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtParameter1 = New System.Windows.Forms.TextBox
        Me.txtParameter2 = New System.Windows.Forms.TextBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.lblVerDate = New System.Windows.Forms.Label
        Me.txtVerDate = New System.Windows.Forms.TextBox
        Me.lblVerUser = New System.Windows.Forms.Label
        Me.txtVerUser = New System.Windows.Forms.TextBox
        Me.txtdbModule = New System.Windows.Forms.TextBox
        Me.rptTest = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnTest = New System.Windows.Forms.Button
        Me.BtnCTTest = New System.Windows.Forms.Button
        CType(Me.grdDataList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDataList
        '
        Me.grdDataList.AllowUserToAddRows = False
        Me.grdDataList.AllowUserToDeleteRows = False
        Me.grdDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDataList.Location = New System.Drawing.Point(29, 64)
        Me.grdDataList.Name = "grdDataList"
        Me.grdDataList.Size = New System.Drawing.Size(644, 357)
        Me.grdDataList.TabIndex = 17
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Location = New System.Drawing.Point(193, 37)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(85, 13)
        Me.lblAmount.TabIndex = 16
        Me.lblAmount.Text = "Total of Amount:"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalAmount.Location = New System.Drawing.Point(284, 37)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(72, 13)
        Me.txtTotalAmount.TabIndex = 15
        Me.txtTotalAmount.TabStop = False
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumberOfTran
        '
        Me.lblNumberOfTran.AutoSize = True
        Me.lblNumberOfTran.Location = New System.Drawing.Point(185, 12)
        Me.lblNumberOfTran.Name = "lblNumberOfTran"
        Me.lblNumberOfTran.Size = New System.Drawing.Size(93, 13)
        Me.lblNumberOfTran.TabIndex = 14
        Me.lblNumberOfTran.Text = "# of Transactions:"
        '
        'txtNumberOfTran
        '
        Me.txtNumberOfTran.BackColor = System.Drawing.SystemColors.Control
        Me.txtNumberOfTran.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNumberOfTran.Location = New System.Drawing.Point(284, 12)
        Me.txtNumberOfTran.Name = "txtNumberOfTran"
        Me.txtNumberOfTran.ReadOnly = True
        Me.txtNumberOfTran.Size = New System.Drawing.Size(72, 13)
        Me.txtNumberOfTran.TabIndex = 13
        Me.txtNumberOfTran.TabStop = False
        Me.txtNumberOfTran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(370, 37)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(64, 13)
        Me.lblDate.TabIndex = 12
        Me.lblDate.Text = "Created On:"
        '
        'txtCreateDate
        '
        Me.txtCreateDate.BackColor = System.Drawing.SystemColors.Control
        Me.txtCreateDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreateDate.Location = New System.Drawing.Point(443, 37)
        Me.txtCreateDate.Name = "txtCreateDate"
        Me.txtCreateDate.ReadOnly = True
        Me.txtCreateDate.Size = New System.Drawing.Size(83, 13)
        Me.txtCreateDate.TabIndex = 11
        Me.txtCreateDate.TabStop = False
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(371, 12)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(62, 13)
        Me.lblUser.TabIndex = 10
        Me.lblUser.Text = "Created By:"
        '
        'txtCreateUser
        '
        Me.txtCreateUser.BackColor = System.Drawing.SystemColors.Control
        Me.txtCreateUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreateUser.Location = New System.Drawing.Point(443, 12)
        Me.txtCreateUser.Name = "txtCreateUser"
        Me.txtCreateUser.ReadOnly = True
        Me.txtCreateUser.Size = New System.Drawing.Size(83, 13)
        Me.txtCreateUser.TabIndex = 9
        Me.txtCreateUser.TabStop = False
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(27, 12)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(26, 13)
        Me.lblFileName.TabIndex = 19
        Me.lblFileName.Text = "File:"
        '
        'txtFileName
        '
        Me.txtFileName.BackColor = System.Drawing.SystemColors.Control
        Me.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFileName.Location = New System.Drawing.Point(59, 12)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(120, 13)
        Me.txtFileName.TabIndex = 18
        Me.txtFileName.TabStop = False
        Me.txtFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnGO
        '
        Me.btnGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGO.Location = New System.Drawing.Point(229, 437)
        Me.btnGO.Name = "btnGO"
        Me.btnGO.Size = New System.Drawing.Size(91, 39)
        Me.btnGO.TabIndex = 20
        Me.btnGO.Text = "&Go"
        Me.btnGO.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(399, 437)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 39)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtParameter1
        '
        Me.txtParameter1.Location = New System.Drawing.Point(67, 427)
        Me.txtParameter1.Name = "txtParameter1"
        Me.txtParameter1.Size = New System.Drawing.Size(30, 20)
        Me.txtParameter1.TabIndex = 22
        Me.txtParameter1.Visible = False
        '
        'txtParameter2
        '
        Me.txtParameter2.Location = New System.Drawing.Point(103, 427)
        Me.txtParameter2.Name = "txtParameter2"
        Me.txtParameter2.Size = New System.Drawing.Size(32, 20)
        Me.txtParameter2.TabIndex = 23
        Me.txtParameter2.Visible = False
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(399, 438)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(91, 39)
        Me.btnExit.TabIndex = 24
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblVerDate
        '
        Me.lblVerDate.AutoSize = True
        Me.lblVerDate.Location = New System.Drawing.Point(532, 37)
        Me.lblVerDate.Name = "lblVerDate"
        Me.lblVerDate.Size = New System.Drawing.Size(62, 13)
        Me.lblVerDate.TabIndex = 28
        Me.lblVerDate.Text = "Verified On:"
        '
        'txtVerDate
        '
        Me.txtVerDate.BackColor = System.Drawing.SystemColors.Control
        Me.txtVerDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVerDate.Location = New System.Drawing.Point(605, 37)
        Me.txtVerDate.Name = "txtVerDate"
        Me.txtVerDate.ReadOnly = True
        Me.txtVerDate.Size = New System.Drawing.Size(69, 13)
        Me.txtVerDate.TabIndex = 27
        Me.txtVerDate.TabStop = False
        '
        'lblVerUser
        '
        Me.lblVerUser.AutoSize = True
        Me.lblVerUser.Location = New System.Drawing.Point(533, 12)
        Me.lblVerUser.Name = "lblVerUser"
        Me.lblVerUser.Size = New System.Drawing.Size(59, 13)
        Me.lblVerUser.TabIndex = 26
        Me.lblVerUser.Text = "Verified by:"
        '
        'txtVerUser
        '
        Me.txtVerUser.BackColor = System.Drawing.SystemColors.Control
        Me.txtVerUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVerUser.Location = New System.Drawing.Point(605, 12)
        Me.txtVerUser.Name = "txtVerUser"
        Me.txtVerUser.ReadOnly = True
        Me.txtVerUser.Size = New System.Drawing.Size(69, 13)
        Me.txtVerUser.TabIndex = 25
        Me.txtVerUser.TabStop = False
        '
        'txtdbModule
        '
        Me.txtdbModule.Location = New System.Drawing.Point(30, 427)
        Me.txtdbModule.Name = "txtdbModule"
        Me.txtdbModule.Size = New System.Drawing.Size(31, 20)
        Me.txtdbModule.TabIndex = 29
        Me.txtdbModule.Visible = False
        '
        'rptTest
        '
        Me.rptTest.FileName = "rassdk://I:\groups\sfs\dbases\SFS\Reports\rptTest.rpt"
        '
        'btnReport
        '
        Me.btnReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.Location = New System.Drawing.Point(229, 438)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(91, 38)
        Me.btnReport.TabIndex = 30
        Me.btnReport.Text = "Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(12, 472)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 31
        Me.btnTest.Text = "Test Conn"
        Me.btnTest.UseVisualStyleBackColor = True
        Me.btnTest.Visible = False
        '
        'BtnCTTest
        '
        Me.BtnCTTest.Location = New System.Drawing.Point(103, 459)
        Me.BtnCTTest.Name = "BtnCTTest"
        Me.BtnCTTest.Size = New System.Drawing.Size(75, 36)
        Me.BtnCTTest.TabIndex = 32
        Me.BtnCTTest.Text = "Update VE from CT"
        Me.BtnCTTest.UseVisualStyleBackColor = True
        Me.BtnCTTest.Visible = False
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 501)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnCTTest)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.txtdbModule)
        Me.Controls.Add(Me.lblVerDate)
        Me.Controls.Add(Me.txtVerDate)
        Me.Controls.Add(Me.lblVerUser)
        Me.Controls.Add(Me.txtVerUser)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.txtParameter2)
        Me.Controls.Add(Me.txtParameter1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnGO)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.grdDataList)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.txtTotalAmount)
        Me.Controls.Add(Me.lblNumberOfTran)
        Me.Controls.Add(Me.txtNumberOfTran)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.txtCreateDate)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.txtCreateUser)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExport"
        Me.ShowIcon = False
        Me.Text = "Export"
        CType(Me.grdDataList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdDataList As System.Windows.Forms.DataGridView
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblNumberOfTran As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfTran As System.Windows.Forms.TextBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents txtCreateDate As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtCreateUser As System.Windows.Forms.TextBox
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnGO As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtParameter1 As System.Windows.Forms.TextBox
    Friend WithEvents txtParameter2 As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblVerDate As System.Windows.Forms.Label
    Friend WithEvents txtVerDate As System.Windows.Forms.TextBox
    Friend WithEvents lblVerUser As System.Windows.Forms.Label
    Friend WithEvents txtVerUser As System.Windows.Forms.TextBox
    Friend WithEvents txtdbModule As System.Windows.Forms.TextBox
    Friend WithEvents rptTest As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents BtnCTTest As System.Windows.Forms.Button
End Class
