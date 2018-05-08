<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashierBalancing
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCashierBalancing))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtBagNbr = New System.Windows.Forms.TextBox()
        Me.lblBagNbr = New System.Windows.Forms.Label()
        Me.txtDepositSlip = New System.Windows.Forms.TextBox()
        Me.lblDepSlip = New System.Windows.Forms.Label()
        Me.cboCashier = New System.Windows.Forms.ComboBox()
        Me.lblActivityDate = New System.Windows.Forms.Label()
        Me.dtpActivityDate = New System.Windows.Forms.DateTimePicker()
        Me.lblCashier = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnDel = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnReport = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxSubmit = New System.Windows.Forms.CheckBox()
        Me.txtPmtCatTot = New System.Windows.Forms.TextBox()
        Me.lblPmtCatTot = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblTypePymtRec = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblCnt = New System.Windows.Forms.Label()
        Me.lblCash = New System.Windows.Forms.Label()
        Me.txtCash = New System.Windows.Forms.TextBox()
        Me.lblCashLink = New System.Windows.Forms.Label()
        Me.txtlCashLink = New System.Windows.Forms.TextBox()
        Me.txtPoPVirtualMerchCnt = New System.Windows.Forms.TextBox()
        Me.lblPoPVirtualMerch = New System.Windows.Forms.Label()
        Me.txtPoPVirtualMerch = New System.Windows.Forms.TextBox()
        Me.txtManualCheckCnt = New System.Windows.Forms.TextBox()
        Me.lblManualCheck = New System.Windows.Forms.Label()
        Me.txtManualCheck = New System.Windows.Forms.TextBox()
        Me.lblCashInBag = New System.Windows.Forms.Label()
        Me.txtCashInBag = New System.Windows.Forms.TextBox()
        Me.lblPmtMethTot = New System.Windows.Forms.Label()
        Me.txtPmtMethTot = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lblGrid = New System.Windows.Forms.Label()
        Me.grdNoteData = New System.Windows.Forms.DataGridView()
        Me.btnAddNote = New System.Windows.Forms.Button()
        Me.txtCTCnt = New System.Windows.Forms.TextBox()
        Me.lblCT = New System.Windows.Forms.Label()
        Me.txtCTAmt = New System.Windows.Forms.TextBox()
        Me.lblVerifiedOn = New System.Windows.Forms.Label()
        Me.lblVerifiedBy = New System.Windows.Forms.Label()
        Me.txtSubmittedOn = New System.Windows.Forms.TextBox()
        Me.txtSubmittedBy = New System.Windows.Forms.TextBox()
        Me.txtApprovedOn = New System.Windows.Forms.TextBox()
        Me.lblApprovedOn = New System.Windows.Forms.Label()
        Me.txtApprovedBy = New System.Windows.Forms.TextBox()
        Me.lblApprovedBy = New System.Windows.Forms.Label()
        Me.txtCreatedOn = New System.Windows.Forms.TextBox()
        Me.lblCreatedOn = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New System.Windows.Forms.TextBox()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.btnGO = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblSAPayment = New System.Windows.Forms.Label()
        Me.txtSAPmtAmt = New System.Windows.Forms.TextBox()
        Me.txtSAPmtCnt = New System.Windows.Forms.TextBox()
        Me.lblOverShort = New System.Windows.Forms.Label()
        Me.txtOverShortAmt = New System.Windows.Forms.TextBox()
        Me.ErrProvCash = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tsRptSummary = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.grdNoteData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrProvCash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBagNbr
        '
        Me.txtBagNbr.Location = New System.Drawing.Point(327, 52)
        Me.txtBagNbr.Name = "txtBagNbr"
        Me.txtBagNbr.Size = New System.Drawing.Size(100, 20)
        Me.txtBagNbr.TabIndex = 20
        '
        'lblBagNbr
        '
        Me.lblBagNbr.AutoSize = True
        Me.lblBagNbr.Location = New System.Drawing.Point(252, 59)
        Me.lblBagNbr.Name = "lblBagNbr"
        Me.lblBagNbr.Size = New System.Drawing.Size(69, 13)
        Me.lblBagNbr.TabIndex = 121
        Me.lblBagNbr.Text = "Bag Number:"
        '
        'txtDepositSlip
        '
        Me.txtDepositSlip.BackColor = System.Drawing.SystemColors.Window
        Me.txtDepositSlip.Location = New System.Drawing.Point(70, 52)
        Me.txtDepositSlip.Name = "txtDepositSlip"
        Me.txtDepositSlip.Size = New System.Drawing.Size(100, 20)
        Me.txtDepositSlip.TabIndex = 15
        '
        'lblDepSlip
        '
        Me.lblDepSlip.AutoSize = True
        Me.lblDepSlip.Location = New System.Drawing.Point(-2, 59)
        Me.lblDepSlip.Name = "lblDepSlip"
        Me.lblDepSlip.Size = New System.Drawing.Size(66, 13)
        Me.lblDepSlip.TabIndex = 118
        Me.lblDepSlip.Text = "Deposit Slip:"
        '
        'cboCashier
        '
        Me.cboCashier.FormattingEnabled = True
        Me.cboCashier.Location = New System.Drawing.Point(70, 25)
        Me.cboCashier.Name = "cboCashier"
        Me.cboCashier.Size = New System.Drawing.Size(100, 21)
        Me.cboCashier.TabIndex = 5
        '
        'lblActivityDate
        '
        Me.lblActivityDate.AutoSize = True
        Me.lblActivityDate.Location = New System.Drawing.Point(275, 32)
        Me.lblActivityDate.Name = "lblActivityDate"
        Me.lblActivityDate.Size = New System.Drawing.Size(33, 13)
        Me.lblActivityDate.TabIndex = 117
        Me.lblActivityDate.Text = "Date:"
        '
        'dtpActivityDate
        '
        Me.dtpActivityDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpActivityDate.Location = New System.Drawing.Point(327, 25)
        Me.dtpActivityDate.Name = "dtpActivityDate"
        Me.dtpActivityDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpActivityDate.TabIndex = 10
        '
        'lblCashier
        '
        Me.lblCashier.AutoSize = True
        Me.lblCashier.Location = New System.Drawing.Point(19, 33)
        Me.lblCashier.Name = "lblCashier"
        Me.lblCashier.Size = New System.Drawing.Size(45, 13)
        Me.lblCashier.TabIndex = 114
        Me.lblCashier.Text = "Cashier:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnEdit, Me.tsbtnDel, Me.tsbtnReport, Me.tsRptSummary})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(537, 25)
        Me.ToolStrip1.TabIndex = 122
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(151, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 13)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "Cashier Summary (M725)"
        '
        'cbxSubmit
        '
        Me.cbxSubmit.AutoSize = True
        Me.cbxSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSubmit.Location = New System.Drawing.Point(43, 215)
        Me.cbxSubmit.Name = "cbxSubmit"
        Me.cbxSubmit.Size = New System.Drawing.Size(136, 17)
        Me.cbxSubmit.TabIndex = 120
        Me.cbxSubmit.Text = "Submit for approval"
        Me.cbxSubmit.UseVisualStyleBackColor = True
        '
        'txtPmtCatTot
        '
        Me.txtPmtCatTot.BackColor = System.Drawing.SystemColors.Window
        Me.txtPmtCatTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPmtCatTot.Location = New System.Drawing.Point(384, 212)
        Me.txtPmtCatTot.Name = "txtPmtCatTot"
        Me.txtPmtCatTot.ReadOnly = True
        Me.txtPmtCatTot.Size = New System.Drawing.Size(100, 20)
        Me.txtPmtCatTot.TabIndex = 50
        Me.txtPmtCatTot.TabStop = False
        Me.txtPmtCatTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPmtCatTot
        '
        Me.lblPmtCatTot.AutoSize = True
        Me.lblPmtCatTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPmtCatTot.Location = New System.Drawing.Point(245, 216)
        Me.lblPmtCatTot.Name = "lblPmtCatTot"
        Me.lblPmtCatTot.Size = New System.Drawing.Size(133, 13)
        Me.lblPmtCatTot.TabIndex = 125
        Me.lblPmtCatTot.Text = " M725 Total Receipts:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TabPage1)
        Me.TabPage2.Controls.Add(Me.TabPage3)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(15, 249)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.SelectedIndex = 0
        Me.TabPage2.Size = New System.Drawing.Size(501, 267)
        Me.TabPage2.TabIndex = 60
        Me.TabPage2.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.lblTypePymtRec)
        Me.TabPage1.Controls.Add(Me.lblAmount)
        Me.TabPage1.Controls.Add(Me.lblCnt)
        Me.TabPage1.Controls.Add(Me.lblCash)
        Me.TabPage1.Controls.Add(Me.txtCash)
        Me.TabPage1.Controls.Add(Me.lblCashLink)
        Me.TabPage1.Controls.Add(Me.txtlCashLink)
        Me.TabPage1.Controls.Add(Me.txtPoPVirtualMerchCnt)
        Me.TabPage1.Controls.Add(Me.lblPoPVirtualMerch)
        Me.TabPage1.Controls.Add(Me.txtPoPVirtualMerch)
        Me.TabPage1.Controls.Add(Me.txtManualCheckCnt)
        Me.TabPage1.Controls.Add(Me.lblManualCheck)
        Me.TabPage1.Controls.Add(Me.txtManualCheck)
        Me.TabPage1.Controls.Add(Me.lblCashInBag)
        Me.TabPage1.Controls.Add(Me.txtCashInBag)
        Me.TabPage1.Controls.Add(Me.lblPmtMethTot)
        Me.TabPage1.Controls.Add(Me.txtPmtMethTot)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(493, 241)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Payments"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblTypePymtRec
        '
        Me.lblTypePymtRec.AutoSize = True
        Me.lblTypePymtRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTypePymtRec.Location = New System.Drawing.Point(132, 12)
        Me.lblTypePymtRec.Name = "lblTypePymtRec"
        Me.lblTypePymtRec.Size = New System.Drawing.Size(160, 13)
        Me.lblTypePymtRec.TabIndex = 160
        Me.lblTypePymtRec.Text = "Type of Payment Received"
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.Location = New System.Drawing.Point(396, 32)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(49, 13)
        Me.lblAmount.TabIndex = 159
        Me.lblAmount.Text = "Amount"
        '
        'lblCnt
        '
        Me.lblCnt.AutoSize = True
        Me.lblCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCnt.Location = New System.Drawing.Point(290, 32)
        Me.lblCnt.Name = "lblCnt"
        Me.lblCnt.Size = New System.Drawing.Size(40, 13)
        Me.lblCnt.TabIndex = 158
        Me.lblCnt.Text = "Count"
        '
        'lblCash
        '
        Me.lblCash.AutoSize = True
        Me.lblCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCash.Location = New System.Drawing.Point(27, 133)
        Me.lblCash.Name = "lblCash"
        Me.lblCash.Size = New System.Drawing.Size(194, 13)
        Me.lblCash.TabIndex = 154
        Me.lblCash.Text = "Cash ( minus $300 change fund )"
        '
        'txtCash
        '
        Me.txtCash.BackColor = System.Drawing.SystemColors.Window
        Me.txtCash.Location = New System.Drawing.Point(363, 130)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.ReadOnly = True
        Me.txtCash.Size = New System.Drawing.Size(100, 20)
        Me.txtCash.TabIndex = 90
        Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCashLink
        '
        Me.lblCashLink.AutoSize = True
        Me.lblCashLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashLink.Location = New System.Drawing.Point(27, 83)
        Me.lblCashLink.Name = "lblCashLink"
        Me.lblCashLink.Size = New System.Drawing.Size(59, 13)
        Me.lblCashLink.TabIndex = 152
        Me.lblCashLink.Text = "CashLink"
        '
        'txtlCashLink
        '
        Me.txtlCashLink.BackColor = System.Drawing.SystemColors.Window
        Me.txtlCashLink.Location = New System.Drawing.Point(363, 80)
        Me.txtlCashLink.Name = "txtlCashLink"
        Me.txtlCashLink.Size = New System.Drawing.Size(100, 20)
        Me.txtlCashLink.TabIndex = 75
        Me.txtlCashLink.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPoPVirtualMerchCnt
        '
        Me.txtPoPVirtualMerchCnt.BackColor = System.Drawing.SystemColors.Window
        Me.txtPoPVirtualMerchCnt.Location = New System.Drawing.Point(286, 54)
        Me.txtPoPVirtualMerchCnt.Name = "txtPoPVirtualMerchCnt"
        Me.txtPoPVirtualMerchCnt.Size = New System.Drawing.Size(51, 20)
        Me.txtPoPVirtualMerchCnt.TabIndex = 65
        Me.txtPoPVirtualMerchCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPoPVirtualMerch
        '
        Me.lblPoPVirtualMerch.AutoSize = True
        Me.lblPoPVirtualMerch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoPVirtualMerch.Location = New System.Drawing.Point(27, 57)
        Me.lblPoPVirtualMerch.Name = "lblPoPVirtualMerch"
        Me.lblPoPVirtualMerch.Size = New System.Drawing.Size(146, 13)
        Me.lblPoPVirtualMerch.TabIndex = 149
        Me.lblPoPVirtualMerch.Text = "Pop (  Virtual Merchant )"
        '
        'txtPoPVirtualMerch
        '
        Me.txtPoPVirtualMerch.BackColor = System.Drawing.SystemColors.Window
        Me.txtPoPVirtualMerch.Location = New System.Drawing.Point(363, 54)
        Me.txtPoPVirtualMerch.Name = "txtPoPVirtualMerch"
        Me.txtPoPVirtualMerch.Size = New System.Drawing.Size(100, 20)
        Me.txtPoPVirtualMerch.TabIndex = 70
        Me.txtPoPVirtualMerch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtManualCheckCnt
        '
        Me.txtManualCheckCnt.BackColor = System.Drawing.SystemColors.Window
        Me.txtManualCheckCnt.Location = New System.Drawing.Point(286, 104)
        Me.txtManualCheckCnt.Name = "txtManualCheckCnt"
        Me.txtManualCheckCnt.ReadOnly = True
        Me.txtManualCheckCnt.Size = New System.Drawing.Size(51, 20)
        Me.txtManualCheckCnt.TabIndex = 80
        Me.txtManualCheckCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblManualCheck
        '
        Me.lblManualCheck.AutoSize = True
        Me.lblManualCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManualCheck.Location = New System.Drawing.Point(27, 107)
        Me.lblManualCheck.Name = "lblManualCheck"
        Me.lblManualCheck.Size = New System.Drawing.Size(180, 13)
        Me.lblManualCheck.TabIndex = 146
        Me.lblManualCheck.Text = "Manual Checks ( not scanned)"
        '
        'txtManualCheck
        '
        Me.txtManualCheck.BackColor = System.Drawing.SystemColors.Window
        Me.txtManualCheck.Location = New System.Drawing.Point(363, 104)
        Me.txtManualCheck.Name = "txtManualCheck"
        Me.txtManualCheck.ReadOnly = True
        Me.txtManualCheck.Size = New System.Drawing.Size(100, 20)
        Me.txtManualCheck.TabIndex = 85
        Me.txtManualCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCashInBag
        '
        Me.lblCashInBag.AutoSize = True
        Me.lblCashInBag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashInBag.Location = New System.Drawing.Point(27, 213)
        Me.lblCashInBag.Name = "lblCashInBag"
        Me.lblCashInBag.Size = New System.Drawing.Size(98, 13)
        Me.lblCashInBag.TabIndex = 52
        Me.lblCashInBag.Text = "Deposit to Bank"
        '
        'txtCashInBag
        '
        Me.txtCashInBag.BackColor = System.Drawing.SystemColors.Window
        Me.txtCashInBag.Location = New System.Drawing.Point(144, 210)
        Me.txtCashInBag.Name = "txtCashInBag"
        Me.txtCashInBag.ReadOnly = True
        Me.txtCashInBag.Size = New System.Drawing.Size(100, 20)
        Me.txtCashInBag.TabIndex = 95
        Me.txtCashInBag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPmtMethTot
        '
        Me.lblPmtMethTot.AutoSize = True
        Me.lblPmtMethTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPmtMethTot.Location = New System.Drawing.Point(317, 213)
        Me.lblPmtMethTot.Name = "lblPmtMethTot"
        Me.lblPmtMethTot.Size = New System.Drawing.Size(40, 13)
        Me.lblPmtMethTot.TabIndex = 44
        Me.lblPmtMethTot.Text = "Total:"
        '
        'txtPmtMethTot
        '
        Me.txtPmtMethTot.BackColor = System.Drawing.SystemColors.Window
        Me.txtPmtMethTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPmtMethTot.Location = New System.Drawing.Point(363, 206)
        Me.txtPmtMethTot.Name = "txtPmtMethTot"
        Me.txtPmtMethTot.ReadOnly = True
        Me.txtPmtMethTot.Size = New System.Drawing.Size(100, 20)
        Me.txtPmtMethTot.TabIndex = 100
        Me.txtPmtMethTot.TabStop = False
        Me.txtPmtMethTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lblGrid)
        Me.TabPage3.Controls.Add(Me.grdNoteData)
        Me.TabPage3.Controls.Add(Me.btnAddNote)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(493, 241)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lblGrid
        '
        Me.lblGrid.AutoSize = True
        Me.lblGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrid.Location = New System.Drawing.Point(21, 23)
        Me.lblGrid.Name = "lblGrid"
        Me.lblGrid.Size = New System.Drawing.Size(40, 13)
        Me.lblGrid.TabIndex = 10
        Me.lblGrid.Text = "Notes"
        '
        'grdNoteData
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdNoteData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdNoteData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdNoteData.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdNoteData.Location = New System.Drawing.Point(10, 51)
        Me.grdNoteData.Name = "grdNoteData"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdNoteData.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdNoteData.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grdNoteData.Size = New System.Drawing.Size(462, 111)
        Me.grdNoteData.TabIndex = 5
        '
        'btnAddNote
        '
        Me.btnAddNote.Image = CType(resources.GetObject("btnAddNote.Image"), System.Drawing.Image)
        Me.btnAddNote.Location = New System.Drawing.Point(435, 23)
        Me.btnAddNote.Name = "btnAddNote"
        Me.btnAddNote.Size = New System.Drawing.Size(30, 22)
        Me.btnAddNote.TabIndex = 11
        Me.btnAddNote.UseVisualStyleBackColor = True
        '
        'txtCTCnt
        '
        Me.txtCTCnt.BackColor = System.Drawing.SystemColors.Window
        Me.txtCTCnt.Location = New System.Drawing.Point(307, 162)
        Me.txtCTCnt.Name = "txtCTCnt"
        Me.txtCTCnt.ReadOnly = True
        Me.txtCTCnt.Size = New System.Drawing.Size(51, 20)
        Me.txtCTCnt.TabIndex = 35
        Me.txtCTCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCT
        '
        Me.lblCT.AutoSize = True
        Me.lblCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCT.Location = New System.Drawing.Point(48, 165)
        Me.lblCT.Name = "lblCT"
        Me.lblCT.Size = New System.Drawing.Size(107, 13)
        Me.lblCT.TabIndex = 156
        Me.lblCT.Text = "Cash Transmittals"
        '
        'txtCTAmt
        '
        Me.txtCTAmt.BackColor = System.Drawing.SystemColors.Window
        Me.txtCTAmt.Location = New System.Drawing.Point(384, 162)
        Me.txtCTAmt.Name = "txtCTAmt"
        Me.txtCTAmt.ReadOnly = True
        Me.txtCTAmt.Size = New System.Drawing.Size(100, 20)
        Me.txtCTAmt.TabIndex = 40
        Me.txtCTAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblVerifiedOn
        '
        Me.lblVerifiedOn.AutoSize = True
        Me.lblVerifiedOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerifiedOn.Location = New System.Drawing.Point(350, 568)
        Me.lblVerifiedOn.Name = "lblVerifiedOn"
        Me.lblVerifiedOn.Size = New System.Drawing.Size(74, 13)
        Me.lblVerifiedOn.TabIndex = 141
        Me.lblVerifiedOn.Text = "Verified On:"
        '
        'lblVerifiedBy
        '
        Me.lblVerifiedBy.AutoSize = True
        Me.lblVerifiedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerifiedBy.Location = New System.Drawing.Point(350, 544)
        Me.lblVerifiedBy.Name = "lblVerifiedBy"
        Me.lblVerifiedBy.Size = New System.Drawing.Size(72, 13)
        Me.lblVerifiedBy.TabIndex = 140
        Me.lblVerifiedBy.Text = "Verified By:"
        '
        'txtSubmittedOn
        '
        Me.txtSubmittedOn.BackColor = System.Drawing.SystemColors.Control
        Me.txtSubmittedOn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubmittedOn.Location = New System.Drawing.Point(440, 568)
        Me.txtSubmittedOn.Name = "txtSubmittedOn"
        Me.txtSubmittedOn.ReadOnly = True
        Me.txtSubmittedOn.Size = New System.Drawing.Size(66, 13)
        Me.txtSubmittedOn.TabIndex = 139
        Me.txtSubmittedOn.TabStop = False
        '
        'txtSubmittedBy
        '
        Me.txtSubmittedBy.BackColor = System.Drawing.SystemColors.Control
        Me.txtSubmittedBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubmittedBy.Location = New System.Drawing.Point(438, 544)
        Me.txtSubmittedBy.Name = "txtSubmittedBy"
        Me.txtSubmittedBy.ReadOnly = True
        Me.txtSubmittedBy.Size = New System.Drawing.Size(67, 13)
        Me.txtSubmittedBy.TabIndex = 138
        Me.txtSubmittedBy.TabStop = False
        '
        'txtApprovedOn
        '
        Me.txtApprovedOn.BackColor = System.Drawing.SystemColors.Control
        Me.txtApprovedOn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtApprovedOn.Location = New System.Drawing.Point(262, 568)
        Me.txtApprovedOn.Name = "txtApprovedOn"
        Me.txtApprovedOn.ReadOnly = True
        Me.txtApprovedOn.Size = New System.Drawing.Size(67, 13)
        Me.txtApprovedOn.TabIndex = 137
        Me.txtApprovedOn.TabStop = False
        '
        'lblApprovedOn
        '
        Me.lblApprovedOn.AutoSize = True
        Me.lblApprovedOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovedOn.Location = New System.Drawing.Point(178, 568)
        Me.lblApprovedOn.Name = "lblApprovedOn"
        Me.lblApprovedOn.Size = New System.Drawing.Size(85, 13)
        Me.lblApprovedOn.TabIndex = 136
        Me.lblApprovedOn.Text = "Approved On:"
        '
        'txtApprovedBy
        '
        Me.txtApprovedBy.BackColor = System.Drawing.SystemColors.Control
        Me.txtApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtApprovedBy.Location = New System.Drawing.Point(262, 544)
        Me.txtApprovedBy.Name = "txtApprovedBy"
        Me.txtApprovedBy.ReadOnly = True
        Me.txtApprovedBy.Size = New System.Drawing.Size(67, 13)
        Me.txtApprovedBy.TabIndex = 135
        Me.txtApprovedBy.TabStop = False
        '
        'lblApprovedBy
        '
        Me.lblApprovedBy.AutoSize = True
        Me.lblApprovedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovedBy.Location = New System.Drawing.Point(178, 544)
        Me.lblApprovedBy.Name = "lblApprovedBy"
        Me.lblApprovedBy.Size = New System.Drawing.Size(83, 13)
        Me.lblApprovedBy.TabIndex = 134
        Me.lblApprovedBy.Text = "Approved By:"
        '
        'txtCreatedOn
        '
        Me.txtCreatedOn.BackColor = System.Drawing.SystemColors.Control
        Me.txtCreatedOn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreatedOn.Location = New System.Drawing.Point(99, 568)
        Me.txtCreatedOn.Name = "txtCreatedOn"
        Me.txtCreatedOn.ReadOnly = True
        Me.txtCreatedOn.Size = New System.Drawing.Size(67, 13)
        Me.txtCreatedOn.TabIndex = 133
        Me.txtCreatedOn.TabStop = False
        '
        'lblCreatedOn
        '
        Me.lblCreatedOn.AutoSize = True
        Me.lblCreatedOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedOn.Location = New System.Drawing.Point(24, 568)
        Me.lblCreatedOn.Name = "lblCreatedOn"
        Me.lblCreatedOn.Size = New System.Drawing.Size(75, 13)
        Me.lblCreatedOn.TabIndex = 132
        Me.lblCreatedOn.Text = "Created On:"
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.BackColor = System.Drawing.SystemColors.Control
        Me.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreatedBy.Location = New System.Drawing.Point(99, 544)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.ReadOnly = True
        Me.txtCreatedBy.Size = New System.Drawing.Size(67, 13)
        Me.txtCreatedBy.TabIndex = 131
        Me.txtCreatedBy.TabStop = False
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.AutoSize = True
        Me.lblCreatedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedBy.Location = New System.Drawing.Point(26, 544)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Size = New System.Drawing.Size(73, 13)
        Me.lblCreatedBy.TabIndex = 130
        Me.lblCreatedBy.Text = "Created By:"
        '
        'btnGO
        '
        Me.btnGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGO.ForeColor = System.Drawing.Color.Green
        Me.btnGO.Location = New System.Drawing.Point(146, 601)
        Me.btnGO.Name = "btnGO"
        Me.btnGO.Size = New System.Drawing.Size(91, 38)
        Me.btnGO.TabIndex = 105
        Me.btnGO.Text = "Save"
        Me.btnGO.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Red
        Me.btnExit.Location = New System.Drawing.Point(295, 601)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(91, 39)
        Me.btnExit.TabIndex = 110
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblSAPayment
        '
        Me.lblSAPayment.AutoSize = True
        Me.lblSAPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSAPayment.Location = New System.Drawing.Point(48, 139)
        Me.lblSAPayment.Name = "lblSAPayment"
        Me.lblSAPayment.Size = New System.Drawing.Size(109, 13)
        Me.lblSAPayment.TabIndex = 143
        Me.lblSAPayment.Text = "Student Payments"
        '
        'txtSAPmtAmt
        '
        Me.txtSAPmtAmt.BackColor = System.Drawing.SystemColors.Window
        Me.txtSAPmtAmt.Location = New System.Drawing.Point(384, 136)
        Me.txtSAPmtAmt.Name = "txtSAPmtAmt"
        Me.txtSAPmtAmt.Size = New System.Drawing.Size(100, 20)
        Me.txtSAPmtAmt.TabIndex = 30
        Me.txtSAPmtAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSAPmtCnt
        '
        Me.txtSAPmtCnt.BackColor = System.Drawing.SystemColors.Window
        Me.txtSAPmtCnt.Location = New System.Drawing.Point(307, 136)
        Me.txtSAPmtCnt.Name = "txtSAPmtCnt"
        Me.txtSAPmtCnt.Size = New System.Drawing.Size(51, 20)
        Me.txtSAPmtCnt.TabIndex = 25
        Me.txtSAPmtCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOverShort
        '
        Me.lblOverShort.AutoSize = True
        Me.lblOverShort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverShort.Location = New System.Drawing.Point(46, 189)
        Me.lblOverShort.Name = "lblOverShort"
        Me.lblOverShort.Size = New System.Drawing.Size(78, 13)
        Me.lblOverShort.TabIndex = 146
        Me.lblOverShort.Text = "Over / Short"
        '
        'txtOverShortAmt
        '
        Me.txtOverShortAmt.BackColor = System.Drawing.SystemColors.Window
        Me.txtOverShortAmt.Location = New System.Drawing.Point(384, 186)
        Me.txtOverShortAmt.Name = "txtOverShortAmt"
        Me.txtOverShortAmt.Size = New System.Drawing.Size(100, 20)
        Me.txtOverShortAmt.TabIndex = 45
        Me.txtOverShortAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ErrProvCash
        '
        Me.ErrProvCash.BlinkRate = 1000
        Me.ErrProvCash.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.ErrProvCash.ContainerControl = Me
        '
        'tsRptSummary
        '
        Me.tsRptSummary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsRptSummary.Image = CType(resources.GetObject("tsRptSummary.Image"), System.Drawing.Image)
        Me.tsRptSummary.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRptSummary.Name = "tsRptSummary"
        Me.tsRptSummary.Size = New System.Drawing.Size(23, 22)
        Me.tsRptSummary.Text = "Summary Report"
        '
        'frmCashierBalancing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 749)
        Me.Controls.Add(Me.lblOverShort)
        Me.Controls.Add(Me.txtOverShortAmt)
        Me.Controls.Add(Me.txtCTCnt)
        Me.Controls.Add(Me.txtSAPmtCnt)
        Me.Controls.Add(Me.lblCT)
        Me.Controls.Add(Me.lblSAPayment)
        Me.Controls.Add(Me.txtCTAmt)
        Me.Controls.Add(Me.txtSAPmtAmt)
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
        Me.Controls.Add(Me.btnGO)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.TabPage2)
        Me.Controls.Add(Me.cbxSubmit)
        Me.Controls.Add(Me.txtPmtCatTot)
        Me.Controls.Add(Me.lblPmtCatTot)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtBagNbr)
        Me.Controls.Add(Me.lblBagNbr)
        Me.Controls.Add(Me.txtDepositSlip)
        Me.Controls.Add(Me.lblDepSlip)
        Me.Controls.Add(Me.cboCashier)
        Me.Controls.Add(Me.lblActivityDate)
        Me.Controls.Add(Me.dtpActivityDate)
        Me.Controls.Add(Me.lblCashier)
        Me.Name = "frmCashierBalancing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmCashierBalancing"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.grdNoteData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrProvCash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBagNbr As System.Windows.Forms.TextBox
    Friend WithEvents lblBagNbr As System.Windows.Forms.Label
    Friend WithEvents txtDepositSlip As System.Windows.Forms.TextBox
    Friend WithEvents lblDepSlip As System.Windows.Forms.Label
    Friend WithEvents cboCashier As System.Windows.Forms.ComboBox
    Friend WithEvents lblActivityDate As System.Windows.Forms.Label
    Friend WithEvents dtpActivityDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCashier As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnReport As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxSubmit As System.Windows.Forms.CheckBox
    Friend WithEvents txtPmtCatTot As System.Windows.Forms.TextBox
    Friend WithEvents lblPmtCatTot As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lblCashInBag As System.Windows.Forms.Label
    Friend WithEvents txtCashInBag As System.Windows.Forms.TextBox
    Friend WithEvents lblPmtMethTot As System.Windows.Forms.Label
    Friend WithEvents txtPmtMethTot As System.Windows.Forms.TextBox
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
    Friend WithEvents btnGO As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblSAPayment As System.Windows.Forms.Label
    Friend WithEvents txtSAPmtAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtSAPmtCnt As System.Windows.Forms.TextBox
    Friend WithEvents lblOverShort As System.Windows.Forms.Label
    Friend WithEvents txtOverShortAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtManualCheckCnt As System.Windows.Forms.TextBox
    Friend WithEvents lblManualCheck As System.Windows.Forms.Label
    Friend WithEvents txtManualCheck As System.Windows.Forms.TextBox
    Friend WithEvents lblCT As System.Windows.Forms.Label
    Friend WithEvents txtCTAmt As System.Windows.Forms.TextBox
    Friend WithEvents lblCash As System.Windows.Forms.Label
    Friend WithEvents txtCash As System.Windows.Forms.TextBox
    Friend WithEvents lblCashLink As System.Windows.Forms.Label
    Friend WithEvents txtlCashLink As System.Windows.Forms.TextBox
    Friend WithEvents txtPoPVirtualMerchCnt As System.Windows.Forms.TextBox
    Friend WithEvents lblPoPVirtualMerch As System.Windows.Forms.Label
    Friend WithEvents txtPoPVirtualMerch As System.Windows.Forms.TextBox
    Friend WithEvents txtCTCnt As System.Windows.Forms.TextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblCnt As System.Windows.Forms.Label
    Friend WithEvents lblTypePymtRec As System.Windows.Forms.Label
    Friend WithEvents ErrProvCash As System.Windows.Forms.ErrorProvider
    Friend WithEvents grdNoteData As System.Windows.Forms.DataGridView
    Friend WithEvents lblGrid As System.Windows.Forms.Label
    Friend WithEvents btnAddNote As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents tsRptSummary As System.Windows.Forms.ToolStripButton
End Class
