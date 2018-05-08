<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmELM
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
        Me.lblID = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtAmt = New System.Windows.Forms.TextBox
        Me.lblAmt = New System.Windows.Forms.Label
        Me.grdElmData = New System.Windows.Forms.DataGridView
        Me.btnExit = New System.Windows.Forms.Button
        Me.txtdbModule = New System.Windows.Forms.TextBox
        CType(Me.grdElmData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(8, 14)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(21, 13)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "ID:"
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.SystemColors.Control
        Me.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtID.Location = New System.Drawing.Point(73, 14)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(128, 13)
        Me.txtID.TabIndex = 1
        Me.txtID.TabStop = False
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.SystemColors.Control
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtName.Location = New System.Drawing.Point(262, 14)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(269, 13)
        Me.txtName.TabIndex = 3
        Me.txtName.TabStop = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(207, 14)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Name:"
        '
        'txtAmt
        '
        Me.txtAmt.BackColor = System.Drawing.SystemColors.Control
        Me.txtAmt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAmt.Location = New System.Drawing.Point(713, 14)
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.ReadOnly = True
        Me.txtAmt.Size = New System.Drawing.Size(87, 13)
        Me.txtAmt.TabIndex = 5
        Me.txtAmt.TabStop = False
        '
        'lblAmt
        '
        Me.lblAmt.AutoSize = True
        Me.lblAmt.Location = New System.Drawing.Point(658, 14)
        Me.lblAmt.Name = "lblAmt"
        Me.lblAmt.Size = New System.Drawing.Size(34, 13)
        Me.lblAmt.TabIndex = 4
        Me.lblAmt.Text = "Total:"
        '
        'grdElmData
        '
        Me.grdElmData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdElmData.Location = New System.Drawing.Point(12, 53)
        Me.grdElmData.Name = "grdElmData"
        Me.grdElmData.Size = New System.Drawing.Size(788, 422)
        Me.grdElmData.TabIndex = 6
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(374, 492)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(91, 39)
        Me.btnExit.TabIndex = 25
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'txtdbModule
        '
        Me.txtdbModule.Location = New System.Drawing.Point(12, 481)
        Me.txtdbModule.Name = "txtdbModule"
        Me.txtdbModule.Size = New System.Drawing.Size(100, 20)
        Me.txtdbModule.TabIndex = 26
        Me.txtdbModule.Visible = False
        '
        'frmELM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 559)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtdbModule)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.grdElmData)
        Me.Controls.Add(Me.txtAmt)
        Me.Controls.Add(Me.lblAmt)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblID)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmELM"
        Me.Text = "ELM"
        CType(Me.grdElmData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtAmt As System.Windows.Forms.TextBox
    Friend WithEvents lblAmt As System.Windows.Forms.Label
    Friend WithEvents grdElmData As System.Windows.Forms.DataGridView
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txtdbModule As System.Windows.Forms.TextBox
End Class
