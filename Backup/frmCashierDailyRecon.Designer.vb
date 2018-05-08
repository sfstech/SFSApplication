<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashierDailyRecon
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
        Me.lblUserID = New System.Windows.Forms.Label
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.lblUserName = New System.Windows.Forms.Label
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.lblDate = New System.Windows.Forms.Label
        Me.DTMPTranDate1 = New System.Windows.Forms.DateTimePicker
        Me.lblCashOnHand = New System.Windows.Forms.Label
        Me.lblCashDeposited = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.lblCashHeader = New System.Windows.Forms.Label
        Me.lblChangeFund = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Location = New System.Drawing.Point(23, 10)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(43, 13)
        Me.lblUserID.TabIndex = 0
        Me.lblUserID.Text = "User ID"
        '
        'txtUserID
        '
        Me.txtUserID.Enabled = False
        Me.txtUserID.Location = New System.Drawing.Point(26, 26)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(100, 20)
        Me.txtUserID.TabIndex = 1
        Me.txtUserID.Text = "System"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(163, 10)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(73, 13)
        Me.lblUserName.TabIndex = 2
        Me.lblUserName.Text = "Cashier Name"
        '
        'txtUserName
        '
        Me.txtUserName.Enabled = False
        Me.txtUserName.Location = New System.Drawing.Point(166, 26)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(100, 20)
        Me.txtUserName.TabIndex = 3
        Me.txtUserName.Text = "System"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(308, 9)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(89, 13)
        Me.lblDate.TabIndex = 4
        Me.lblDate.Text = "Transaction Date"
        '
        'DTMPTranDate1
        '
        Me.DTMPTranDate1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTMPTranDate1.Location = New System.Drawing.Point(311, 25)
        Me.DTMPTranDate1.Name = "DTMPTranDate1"
        Me.DTMPTranDate1.Size = New System.Drawing.Size(100, 20)
        Me.DTMPTranDate1.TabIndex = 5
        '
        'lblCashOnHand
        '
        Me.lblCashOnHand.AutoSize = True
        Me.lblCashOnHand.Location = New System.Drawing.Point(24, 91)
        Me.lblCashOnHand.Name = "lblCashOnHand"
        Me.lblCashOnHand.Size = New System.Drawing.Size(77, 13)
        Me.lblCashOnHand.TabIndex = 6
        Me.lblCashOnHand.Text = "Cash On Hand"
        '
        'lblCashDeposited
        '
        Me.lblCashDeposited.AutoSize = True
        Me.lblCashDeposited.Location = New System.Drawing.Point(226, 126)
        Me.lblCashDeposited.Name = "lblCashDeposited"
        Me.lblCashDeposited.Size = New System.Drawing.Size(82, 13)
        Me.lblCashDeposited.TabIndex = 7
        Me.lblCashDeposited.Text = "Cash Deposited"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(109, 88)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.Text = "Entered"
        '
        'lblCashHeader
        '
        Me.lblCashHeader.AutoSize = True
        Me.lblCashHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashHeader.Location = New System.Drawing.Point(23, 61)
        Me.lblCashHeader.Name = "lblCashHeader"
        Me.lblCashHeader.Size = New System.Drawing.Size(40, 13)
        Me.lblCashHeader.TabIndex = 9
        Me.lblCashHeader.Text = "CASH"
        '
        'lblChangeFund
        '
        Me.lblChangeFund.AutoSize = True
        Me.lblChangeFund.Location = New System.Drawing.Point(227, 95)
        Me.lblChangeFund.Name = "lblChangeFund"
        Me.lblChangeFund.Size = New System.Drawing.Size(71, 13)
        Me.lblChangeFund.TabIndex = 10
        Me.lblChangeFund.Text = "Change Fund"
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(311, 88)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 11
        Me.TextBox2.Text = "System"
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(311, 123)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 12
        Me.TextBox3.Text = "System Calc"
        '
        'frmCashierDailyRecon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 378)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.lblChangeFund)
        Me.Controls.Add(Me.lblCashHeader)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblCashDeposited)
        Me.Controls.Add(Me.lblCashOnHand)
        Me.Controls.Add(Me.DTMPTranDate1)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.lblUserID)
        Me.Name = "frmCashierDailyRecon"
        Me.Text = "frmCashierDailyRecon"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents DTMPTranDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCashOnHand As System.Windows.Forms.Label
    Friend WithEvents lblCashDeposited As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblCashHeader As System.Windows.Forms.Label
    Friend WithEvents lblChangeFund As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
End Class
