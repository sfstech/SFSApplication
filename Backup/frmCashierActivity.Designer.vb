<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashierActivity
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCashierActivity))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim ClsNote1 As SFS.clsNote = New SFS.clsNote
        Dim ClsNote2 As SFS.clsNote = New SFS.clsNote
        Me.lblCashier = New System.Windows.Forms.Label
        Me.dtpActivityDate = New System.Windows.Forms.DateTimePicker
        Me.lblActivityDate = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdPmtCat = New System.Windows.Forms.DataGridView
        Me.btnAddPmtCat = New System.Windows.Forms.Button
        Me.txtPmtMethTot = New System.Windows.Forms.TextBox
        Me.lblPmtMethTot = New System.Windows.Forms.Label
        Me.btnAddPmtMeth = New System.Windows.Forms.Button
        Me.grdPmtMeth = New System.Windows.Forms.DataGridView
        Me.lblPmtMeth = New System.Windows.Forms.Label
        Me.txtPmtCatTot = New System.Windows.Forms.TextBox
        Me.lblPmtCatTot = New System.Windows.Forms.Label
        Me.btnGO = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.cbxSubmit = New System.Windows.Forms.CheckBox
        Me.cboCashier = New System.Windows.Forms.ComboBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbtnEdit = New System.Windows.Forms.ToolStripButton
        Me.tsbtnDel = New System.Windows.Forms.ToolStripButton
        Me.tsbtnReport = New System.Windows.Forms.ToolStripButton
        Me.tsWizard = New System.Windows.Forms.ToolStripButton
        Me.btnAddCashOnHand = New System.Windows.Forms.Button
        Me.grdCashOnHand = New System.Windows.Forms.DataGridView
        Me.lblCashOnHand = New System.Windows.Forms.Label
        Me.txtCashOnHandTot = New System.Windows.Forms.TextBox
        Me.lblcashOnHandTot = New System.Windows.Forms.Label
        Me.ErrProvCash = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.CtrlNoteDisplay1 = New SFS.ctrlNoteDisplay
        Me.txtBagNbr = New System.Windows.Forms.TextBox
        Me.lblBagNbr = New System.Windows.Forms.Label
        Me.txtDepositSlip = New System.Windows.Forms.TextBox
        Me.lblDepSlip = New System.Windows.Forms.Label
        Me.lblVerifiedOn = New System.Windows.Forms.Label
        Me.lblVerifiedBy = New System.Windows.Forms.Label
        Me.txtSubmittedOn = New System.Windows.Forms.TextBox
        Me.txtSubmittedBy = New System.Windows.Forms.TextBox
        Me.txtApprovedOn = New System.Windows.Forms.TextBox
        Me.lblApprovedOn = New System.Windows.Forms.Label
        Me.txtApprovedBy = New System.Windows.Forms.TextBox
        Me.lblApprovedBy = New System.Windows.Forms.Label
        Me.txtCreatedOn = New System.Windows.Forms.TextBox
        Me.lblCreatedOn = New System.Windows.Forms.Label
        Me.txtCreatedBy = New System.Windows.Forms.TextBox
        Me.lblCreatedBy = New System.Windows.Forms.Label
        Me.txtCashInBag = New System.Windows.Forms.TextBox
        Me.lblCashInBag = New System.Windows.Forms.Label
        CType(Me.grdPmtCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPmtMeth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grdCashOnHand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrProvCash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCashier
        '
        Me.lblCashier.AutoSize = True
        Me.lblCashier.Location = New System.Drawing.Point(51, 36)
        Me.lblCashier.Name = "lblCashier"
        Me.lblCashier.Size = New System.Drawing.Size(45, 13)
        Me.lblCashier.TabIndex = 0
        Me.lblCashier.Text = "Cashier:"
        '
        'dtpActivityDate
        '
        Me.dtpActivityDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpActivityDate.Location = New System.Drawing.Point(359, 28)
        Me.dtpActivityDate.Name = "dtpActivityDate"
        Me.dtpActivityDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpActivityDate.TabIndex = 2
        '
        'lblActivityDate
        '
        Me.lblActivityDate.AutoSize = True
        Me.lblActivityDate.Location = New System.Drawing.Point(307, 35)
        Me.lblActivityDate.Name = "lblActivityDate"
        Me.lblActivityDate.Size = New System.Drawing.Size(33, 13)
        Me.lblActivityDate.TabIndex = 5
        Me.lblActivityDate.Text = "Date:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Payment Category"
        '
        'grdPmtCat
        '
        Me.grdPmtCat.AllowUserToAddRows = False
        Me.grdPmtCat.AllowUserToDeleteRows = False
        Me.grdPmtCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPmtCat.Location = New System.Drawing.Point(12, 240)
        Me.grdPmtCat.Name = "grdPmtCat"
        Me.grdPmtCat.Size = New System.Drawing.Size(462, 110)
        Me.grdPmtCat.TabIndex = 9
        '
        'btnAddPmtCat
        '
        Me.btnAddPmtCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddPmtCat.Image = CType(resources.GetObject("btnAddPmtCat.Image"), System.Drawing.Image)
        Me.btnAddPmtCat.Location = New System.Drawing.Point(444, 218)
        Me.btnAddPmtCat.Name = "btnAddPmtCat"
        Me.btnAddPmtCat.Size = New System.Drawing.Size(30, 22)
        Me.btnAddPmtCat.TabIndex = 38
        Me.btnAddPmtCat.UseVisualStyleBackColor = True
        '
        'txtPmtMethTot
        '
        Me.txtPmtMethTot.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtPmtMethTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPmtMethTot.Location = New System.Drawing.Point(355, 166)
        Me.txtPmtMethTot.Name = "txtPmtMethTot"
        Me.txtPmtMethTot.ReadOnly = True
        Me.txtPmtMethTot.Size = New System.Drawing.Size(100, 20)
        Me.txtPmtMethTot.TabIndex = 45
        Me.txtPmtMethTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPmtMethTot
        '
        Me.lblPmtMethTot.AutoSize = True
        Me.lblPmtMethTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPmtMethTot.Location = New System.Drawing.Point(309, 173)
        Me.lblPmtMethTot.Name = "lblPmtMethTot"
        Me.lblPmtMethTot.Size = New System.Drawing.Size(40, 13)
        Me.lblPmtMethTot.TabIndex = 44
        Me.lblPmtMethTot.Text = "Total:"
        '
        'btnAddPmtMeth
        '
        Me.btnAddPmtMeth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddPmtMeth.Image = CType(resources.GetObject("btnAddPmtMeth.Image"), System.Drawing.Image)
        Me.btnAddPmtMeth.Location = New System.Drawing.Point(440, 9)
        Me.btnAddPmtMeth.Name = "btnAddPmtMeth"
        Me.btnAddPmtMeth.Size = New System.Drawing.Size(30, 22)
        Me.btnAddPmtMeth.TabIndex = 50
        Me.btnAddPmtMeth.UseVisualStyleBackColor = True
        '
        'grdPmtMeth
        '
        Me.grdPmtMeth.AllowUserToAddRows = False
        Me.grdPmtMeth.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPmtMeth.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdPmtMeth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdPmtMeth.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdPmtMeth.Location = New System.Drawing.Point(9, 30)
        Me.grdPmtMeth.Name = "grdPmtMeth"
        Me.grdPmtMeth.Size = New System.Drawing.Size(462, 130)
        Me.grdPmtMeth.TabIndex = 49
        '
        'lblPmtMeth
        '
        Me.lblPmtMeth.AutoSize = True
        Me.lblPmtMeth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPmtMeth.Location = New System.Drawing.Point(10, 14)
        Me.lblPmtMeth.Name = "lblPmtMeth"
        Me.lblPmtMeth.Size = New System.Drawing.Size(101, 13)
        Me.lblPmtMeth.TabIndex = 48
        Me.lblPmtMeth.Text = "Payment Method"
        '
        'txtPmtCatTot
        '
        Me.txtPmtCatTot.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtPmtCatTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPmtCatTot.Location = New System.Drawing.Point(357, 357)
        Me.txtPmtCatTot.Name = "txtPmtCatTot"
        Me.txtPmtCatTot.ReadOnly = True
        Me.txtPmtCatTot.Size = New System.Drawing.Size(100, 20)
        Me.txtPmtCatTot.TabIndex = 47
        Me.txtPmtCatTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPmtCatTot
        '
        Me.lblPmtCatTot.AutoSize = True
        Me.lblPmtCatTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPmtCatTot.Location = New System.Drawing.Point(202, 364)
        Me.lblPmtCatTot.Name = "lblPmtCatTot"
        Me.lblPmtCatTot.Size = New System.Drawing.Size(149, 13)
        Me.lblPmtCatTot.TabIndex = 46
        Me.lblPmtCatTot.Text = "Deposited to Bank Total:"
        '
        'btnGO
        '
        Me.btnGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGO.ForeColor = System.Drawing.Color.Green
        Me.btnGO.Location = New System.Drawing.Point(143, 653)
        Me.btnGO.Name = "btnGO"
        Me.btnGO.Size = New System.Drawing.Size(91, 38)
        Me.btnGO.TabIndex = 52
        Me.btnGO.Text = "Save"
        Me.btnGO.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Red
        Me.btnExit.Location = New System.Drawing.Point(287, 653)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(91, 39)
        Me.btnExit.TabIndex = 51
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cbxSubmit
        '
        Me.cbxSubmit.AutoSize = True
        Me.cbxSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSubmit.Location = New System.Drawing.Point(16, 360)
        Me.cbxSubmit.Name = "cbxSubmit"
        Me.cbxSubmit.Size = New System.Drawing.Size(136, 17)
        Me.cbxSubmit.TabIndex = 5
        Me.cbxSubmit.Text = "Submit for approval"
        Me.cbxSubmit.UseVisualStyleBackColor = True
        '
        'cboCashier
        '
        Me.cboCashier.FormattingEnabled = True
        Me.cboCashier.Location = New System.Drawing.Point(102, 28)
        Me.cboCashier.Name = "cboCashier"
        Me.cboCashier.Size = New System.Drawing.Size(100, 21)
        Me.cboCashier.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnEdit, Me.tsbtnDel, Me.tsbtnReport, Me.tsWizard})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(499, 25)
        Me.ToolStrip1.TabIndex = 72
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtnEdit
        '
        Me.tsbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnEdit.Image = CType(resources.GetObject("tsbtnEdit.Image"), System.Drawing.Image)
        Me.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnEdit.Name = "tsbtnEdit"
        Me.tsbtnEdit.Size = New System.Drawing.Size(23, 22)
        Me.tsbtnEdit.Text = "ToolStripButton1"
        Me.tsbtnEdit.ToolTipText = "ToolEdit"
        Me.tsbtnEdit.Visible = False
        '
        'tsbtnDel
        '
        Me.tsbtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnDel.Image = CType(resources.GetObject("tsbtnDel.Image"), System.Drawing.Image)
        Me.tsbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnDel.Name = "tsbtnDel"
        Me.tsbtnDel.Size = New System.Drawing.Size(23, 22)
        Me.tsbtnDel.Text = "Delete Record"
        Me.tsbtnDel.ToolTipText = "Delete"
        '
        'tsbtnReport
        '
        Me.tsbtnReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnReport.Image = CType(resources.GetObject("tsbtnReport.Image"), System.Drawing.Image)
        Me.tsbtnReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnReport.Name = "tsbtnReport"
        Me.tsbtnReport.Size = New System.Drawing.Size(23, 22)
        Me.tsbtnReport.Text = "Print Payment Reconciliation Sheet1"
        Me.tsbtnReport.ToolTipText = "Daily Reconciliation Report"
        '
        'tsWizard
        '
        Me.tsWizard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsWizard.Enabled = False
        Me.tsWizard.Image = CType(resources.GetObject("tsWizard.Image"), System.Drawing.Image)
        Me.tsWizard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsWizard.Name = "tsWizard"
        Me.tsWizard.Size = New System.Drawing.Size(23, 22)
        Me.tsWizard.Text = "Input Items Wizard"
        '
        'btnAddCashOnHand
        '
        Me.btnAddCashOnHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddCashOnHand.Image = CType(resources.GetObject("btnAddCashOnHand.Image"), System.Drawing.Image)
        Me.btnAddCashOnHand.Location = New System.Drawing.Point(444, 75)
        Me.btnAddCashOnHand.Name = "btnAddCashOnHand"
        Me.btnAddCashOnHand.Size = New System.Drawing.Size(30, 22)
        Me.btnAddCashOnHand.TabIndex = 77
        Me.btnAddCashOnHand.UseVisualStyleBackColor = True
        '
        'grdCashOnHand
        '
        Me.grdCashOnHand.AllowUserToAddRows = False
        Me.grdCashOnHand.AllowUserToDeleteRows = False
        Me.grdCashOnHand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCashOnHand.Location = New System.Drawing.Point(12, 98)
        Me.grdCashOnHand.Name = "grdCashOnHand"
        Me.grdCashOnHand.Size = New System.Drawing.Size(462, 93)
        Me.grdCashOnHand.TabIndex = 76
        '
        'lblCashOnHand
        '
        Me.lblCashOnHand.AutoSize = True
        Me.lblCashOnHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashOnHand.Location = New System.Drawing.Point(14, 82)
        Me.lblCashOnHand.Name = "lblCashOnHand"
        Me.lblCashOnHand.Size = New System.Drawing.Size(87, 13)
        Me.lblCashOnHand.TabIndex = 75
        Me.lblCashOnHand.Text = "Cash on Hand"
        '
        'txtCashOnHandTot
        '
        Me.txtCashOnHandTot.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtCashOnHandTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashOnHandTot.Location = New System.Drawing.Point(357, 197)
        Me.txtCashOnHandTot.Name = "txtCashOnHandTot"
        Me.txtCashOnHandTot.ReadOnly = True
        Me.txtCashOnHandTot.Size = New System.Drawing.Size(100, 20)
        Me.txtCashOnHandTot.TabIndex = 74
        Me.txtCashOnHandTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblcashOnHandTot
        '
        Me.lblcashOnHandTot.AutoSize = True
        Me.lblcashOnHandTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcashOnHandTot.Location = New System.Drawing.Point(190, 204)
        Me.lblcashOnHandTot.Name = "lblcashOnHandTot"
        Me.lblcashOnHandTot.Size = New System.Drawing.Size(161, 13)
        Me.lblcashOnHandTot.TabIndex = 73
        Me.lblcashOnHandTot.Text = "Net Amount Counted Total:"
        '
        'ErrProvCash
        '
        Me.ErrProvCash.BlinkRate = 1000
        Me.ErrProvCash.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.ErrProvCash.ContainerControl = Me
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 388)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(501, 218)
        Me.TabControl1.TabIndex = 78
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.lblCashInBag)
        Me.TabPage1.Controls.Add(Me.txtCashInBag)
        Me.TabPage1.Controls.Add(Me.lblPmtMeth)
        Me.TabPage1.Controls.Add(Me.lblPmtMethTot)
        Me.TabPage1.Controls.Add(Me.txtPmtMethTot)
        Me.TabPage1.Controls.Add(Me.grdPmtMeth)
        Me.TabPage1.Controls.Add(Me.btnAddPmtMeth)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(493, 192)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Payment Method"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.CtrlNoteDisplay1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(493, 192)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Notes"
        '
        'CtrlNoteDisplay1
        '
        Me.CtrlNoteDisplay1.Location = New System.Drawing.Point(6, 4)
        Me.CtrlNoteDisplay1.Name = "CtrlNoteDisplay1"
        Me.CtrlNoteDisplay1.objNoteAction = ClsNote1
        Me.CtrlNoteDisplay1.objNoteData = ClsNote2
        Me.CtrlNoteDisplay1.Size = New System.Drawing.Size(470, 150)
        Me.CtrlNoteDisplay1.TabIndex = 0
        Me.CtrlNoteDisplay1.Tag = "frmCashierActivity Cashier 123"
        '
        'txtBagNbr
        '
        Me.txtBagNbr.Location = New System.Drawing.Point(359, 55)
        Me.txtBagNbr.Name = "txtBagNbr"
        Me.txtBagNbr.Size = New System.Drawing.Size(100, 20)
        Me.txtBagNbr.TabIndex = 112
        '
        'lblBagNbr
        '
        Me.lblBagNbr.AutoSize = True
        Me.lblBagNbr.Location = New System.Drawing.Point(284, 62)
        Me.lblBagNbr.Name = "lblBagNbr"
        Me.lblBagNbr.Size = New System.Drawing.Size(69, 13)
        Me.lblBagNbr.TabIndex = 113
        Me.lblBagNbr.Text = "Bag Number:"
        '
        'txtDepositSlip
        '
        Me.txtDepositSlip.Location = New System.Drawing.Point(102, 55)
        Me.txtDepositSlip.Name = "txtDepositSlip"
        Me.txtDepositSlip.Size = New System.Drawing.Size(100, 20)
        Me.txtDepositSlip.TabIndex = 111
        '
        'lblDepSlip
        '
        Me.lblDepSlip.AutoSize = True
        Me.lblDepSlip.Location = New System.Drawing.Point(30, 62)
        Me.lblDepSlip.Name = "lblDepSlip"
        Me.lblDepSlip.Size = New System.Drawing.Size(66, 13)
        Me.lblDepSlip.TabIndex = 110
        Me.lblDepSlip.Text = "Deposit Slip:"
        '
        'lblVerifiedOn
        '
        Me.lblVerifiedOn.AutoSize = True
        Me.lblVerifiedOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerifiedOn.Location = New System.Drawing.Point(332, 636)
        Me.lblVerifiedOn.Name = "lblVerifiedOn"
        Me.lblVerifiedOn.Size = New System.Drawing.Size(74, 13)
        Me.lblVerifiedOn.TabIndex = 109
        Me.lblVerifiedOn.Text = "Verified On:"
        '
        'lblVerifiedBy
        '
        Me.lblVerifiedBy.AutoSize = True
        Me.lblVerifiedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerifiedBy.Location = New System.Drawing.Point(332, 612)
        Me.lblVerifiedBy.Name = "lblVerifiedBy"
        Me.lblVerifiedBy.Size = New System.Drawing.Size(72, 13)
        Me.lblVerifiedBy.TabIndex = 108
        Me.lblVerifiedBy.Text = "Verified By:"
        '
        'txtSubmittedOn
        '
        Me.txtSubmittedOn.BackColor = System.Drawing.SystemColors.Control
        Me.txtSubmittedOn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubmittedOn.Location = New System.Drawing.Point(422, 636)
        Me.txtSubmittedOn.Name = "txtSubmittedOn"
        Me.txtSubmittedOn.ReadOnly = True
        Me.txtSubmittedOn.Size = New System.Drawing.Size(66, 13)
        Me.txtSubmittedOn.TabIndex = 107
        Me.txtSubmittedOn.TabStop = False
        '
        'txtSubmittedBy
        '
        Me.txtSubmittedBy.BackColor = System.Drawing.SystemColors.Control
        Me.txtSubmittedBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubmittedBy.Location = New System.Drawing.Point(420, 612)
        Me.txtSubmittedBy.Name = "txtSubmittedBy"
        Me.txtSubmittedBy.ReadOnly = True
        Me.txtSubmittedBy.Size = New System.Drawing.Size(67, 13)
        Me.txtSubmittedBy.TabIndex = 106
        Me.txtSubmittedBy.TabStop = False
        '
        'txtApprovedOn
        '
        Me.txtApprovedOn.BackColor = System.Drawing.SystemColors.Control
        Me.txtApprovedOn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtApprovedOn.Location = New System.Drawing.Point(244, 636)
        Me.txtApprovedOn.Name = "txtApprovedOn"
        Me.txtApprovedOn.ReadOnly = True
        Me.txtApprovedOn.Size = New System.Drawing.Size(67, 13)
        Me.txtApprovedOn.TabIndex = 105
        Me.txtApprovedOn.TabStop = False
        '
        'lblApprovedOn
        '
        Me.lblApprovedOn.AutoSize = True
        Me.lblApprovedOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovedOn.Location = New System.Drawing.Point(160, 636)
        Me.lblApprovedOn.Name = "lblApprovedOn"
        Me.lblApprovedOn.Size = New System.Drawing.Size(85, 13)
        Me.lblApprovedOn.TabIndex = 104
        Me.lblApprovedOn.Text = "Approved On:"
        '
        'txtApprovedBy
        '
        Me.txtApprovedBy.BackColor = System.Drawing.SystemColors.Control
        Me.txtApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtApprovedBy.Location = New System.Drawing.Point(244, 612)
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.ReadOnly = True
        Me.txtApprovedBy.Size = New System.Drawing.Size(67, 13)
        Me.txtApprovedBy.TabIndex = 103
        Me.txtApprovedBy.TabStop = False
        '
        'lblApprovedBy
        '
        Me.lblApprovedBy.AutoSize = True
        Me.lblApprovedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovedBy.Location = New System.Drawing.Point(160, 612)
        Me.lblApprovedBy.Name = "lblApprovedBy"
        Me.lblApprovedBy.Size = New System.Drawing.Size(83, 13)
        Me.lblApprovedBy.TabIndex = 102
        Me.lblApprovedBy.Text = "Approved By:"
        '
        'txtCreatedOn
        '
        Me.txtCreatedOn.BackColor = System.Drawing.SystemColors.Control
        Me.txtCreatedOn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreatedOn.Location = New System.Drawing.Point(81, 636)
        Me.txtCreatedOn.Name = "txtCreatedOn"
        Me.txtCreatedOn.ReadOnly = True
        Me.txtCreatedOn.Size = New System.Drawing.Size(67, 13)
        Me.txtCreatedOn.TabIndex = 101
        Me.txtCreatedOn.TabStop = False
        '
        'lblCreatedOn
        '
        Me.lblCreatedOn.AutoSize = True
        Me.lblCreatedOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedOn.Location = New System.Drawing.Point(6, 636)
        Me.lblCreatedOn.Name = "lblCreatedOn"
        Me.lblCreatedOn.Size = New System.Drawing.Size(75, 13)
        Me.lblCreatedOn.TabIndex = 100
        Me.lblCreatedOn.Text = "Created On:"
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.BackColor = System.Drawing.SystemColors.Control
        Me.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreatedBy.Location = New System.Drawing.Point(81, 612)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.ReadOnly = True
        Me.txtCreatedBy.Size = New System.Drawing.Size(67, 13)
        Me.txtCreatedBy.TabIndex = 99
        Me.txtCreatedBy.TabStop = False
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.AutoSize = True
        Me.lblCreatedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedBy.Location = New System.Drawing.Point(8, 612)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Size = New System.Drawing.Size(73, 13)
        Me.lblCreatedBy.TabIndex = 98
        Me.lblCreatedBy.Text = "Created By:"
        '
        'txtCashInBag
        '
        Me.txtCashInBag.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtCashInBag.Location = New System.Drawing.Point(139, 166)
        Me.txtCashInBag.Name = "txtCashInBag"
        Me.txtCashInBag.ReadOnly = True
        Me.txtCashInBag.Size = New System.Drawing.Size(100, 20)
        Me.txtCashInBag.TabIndex = 51
        '
        'lblCashInBag
        '
        Me.lblCashInBag.AutoSize = True
        Me.lblCashInBag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashInBag.Location = New System.Drawing.Point(10, 173)
        Me.lblCashInBag.Name = "lblCashInBag"
        Me.lblCashInBag.Size = New System.Drawing.Size(123, 13)
        Me.lblCashInBag.TabIndex = 52
        Me.lblCashInBag.Text = "Cash/Checks in Bag"
        '
        'frmCashierActivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(499, 695)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtBagNbr)
        Me.Controls.Add(Me.lblBagNbr)
        Me.Controls.Add(Me.txtDepositSlip)
        Me.Controls.Add(Me.lblDepSlip)
        Me.Controls.Add(Me.lblVerifiedOn)
        Me.Controls.Add(Me.lblVerifiedBy)
        Me.Controls.Add(Me.txtSubmittedOn)
        Me.Controls.Add(Me.txtSubmittedBy)
        Me.Controls.Add(Me.txtApprovedOn)
        Me.Controls.Add(Me.lblApprovedOn)
        Me.Controls.Add(Me.txtApprovedBy)
        Me.Controls.Add(Me.lblApprovedBy)
        Me.Controls.Add(Me.txtCreatedOn)
        Me.Controls.Add(Me.lblCreatedOn)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnAddCashOnHand)
        Me.Controls.Add(Me.grdCashOnHand)
        Me.Controls.Add(Me.lblCashOnHand)
        Me.Controls.Add(Me.txtCashOnHandTot)
        Me.Controls.Add(Me.lblcashOnHandTot)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.cboCashier)
        Me.Controls.Add(Me.cbxSubmit)
        Me.Controls.Add(Me.btnGO)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.txtPmtCatTot)
        Me.Controls.Add(Me.lblPmtCatTot)
        Me.Controls.Add(Me.btnAddPmtCat)
        Me.Controls.Add(Me.grdPmtCat)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblActivityDate)
        Me.Controls.Add(Me.dtpActivityDate)
        Me.Controls.Add(Me.lblCashier)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCashierActivity"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cashier Activity"
        CType(Me.grdPmtCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPmtMeth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grdCashOnHand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrProvCash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCashier As System.Windows.Forms.Label
    Friend WithEvents dtpActivityDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblActivityDate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdPmtCat As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddPmtCat As System.Windows.Forms.Button
    Friend WithEvents txtPmtMethTot As System.Windows.Forms.TextBox
    Friend WithEvents lblPmtMethTot As System.Windows.Forms.Label
    Friend WithEvents btnAddPmtMeth As System.Windows.Forms.Button
    Friend WithEvents grdPmtMeth As System.Windows.Forms.DataGridView
    Friend WithEvents lblPmtMeth As System.Windows.Forms.Label
    Friend WithEvents txtPmtCatTot As System.Windows.Forms.TextBox
    Friend WithEvents lblPmtCatTot As System.Windows.Forms.Label
    Friend WithEvents btnGO As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents cbxSubmit As System.Windows.Forms.CheckBox
    Friend WithEvents cboCashier As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAddCashOnHand As System.Windows.Forms.Button
    Friend WithEvents grdCashOnHand As System.Windows.Forms.DataGridView
    Friend WithEvents lblCashOnHand As System.Windows.Forms.Label
    Friend WithEvents txtCashOnHandTot As System.Windows.Forms.TextBox
    Friend WithEvents lblcashOnHandTot As System.Windows.Forms.Label
    Friend WithEvents tsbtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnReport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrProvCash As System.Windows.Forms.ErrorProvider
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CtrlNoteDisplay1 As SFS.ctrlNoteDisplay
    Friend WithEvents txtBagNbr As System.Windows.Forms.TextBox
    Friend WithEvents lblBagNbr As System.Windows.Forms.Label
    Friend WithEvents txtDepositSlip As System.Windows.Forms.TextBox
    Friend WithEvents lblDepSlip As System.Windows.Forms.Label
    Friend WithEvents lblVerifiedOn As System.Windows.Forms.Label
    Friend WithEvents lblVerifiedBy As System.Windows.Forms.Label
    Friend WithEvents txtSubmittedOn As System.Windows.Forms.TextBox
    Friend WithEvents txtSubmittedBy As System.Windows.Forms.TextBox
    Friend WithEvents txtApprovedOn As System.Windows.Forms.TextBox
    Friend WithEvents lblApprovedOn As System.Windows.Forms.Label
    Friend WithEvents txtApprovedBy As System.Windows.Forms.TextBox
    Friend WithEvents lblApprovedBy As System.Windows.Forms.Label
    Friend WithEvents txtCreatedOn As System.Windows.Forms.TextBox
    Friend WithEvents lblCreatedOn As System.Windows.Forms.Label
    Friend WithEvents txtCreatedBy As System.Windows.Forms.TextBox
    Friend WithEvents lblCreatedBy As System.Windows.Forms.Label
    Friend WithEvents tsWizard As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCashInBag As System.Windows.Forms.Label
    Friend WithEvents txtCashInBag As System.Windows.Forms.TextBox
End Class
