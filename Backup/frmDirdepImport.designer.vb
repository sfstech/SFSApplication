<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDirdepImport
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
        Me.dtDirdepImport = New System.Windows.Forms.DateTimePicker
        Me.lblDirdepImportDate = New System.Windows.Forms.Label
        Me.btnGo = New System.Windows.Forms.Button
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'dtDirdepImport
        '
        Me.dtDirdepImport.CustomFormat = "m/d/yyyy 12:00:00 AM"
        Me.dtDirdepImport.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDirdepImport.Location = New System.Drawing.Point(199, 58)
        Me.dtDirdepImport.Name = "dtDirdepImport"
        Me.dtDirdepImport.Size = New System.Drawing.Size(103, 20)
        Me.dtDirdepImport.TabIndex = 0
        Me.dtDirdepImport.Value = New Date(2008, 10, 22, 0, 0, 0, 0)
        '
        'lblDirdepImportDate
        '
        Me.lblDirdepImportDate.AutoSize = True
        Me.lblDirdepImportDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirdepImportDate.Location = New System.Drawing.Point(24, 58)
        Me.lblDirdepImportDate.Name = "lblDirdepImportDate"
        Me.lblDirdepImportDate.Size = New System.Drawing.Size(169, 17)
        Me.lblDirdepImportDate.TabIndex = 1
        Me.lblDirdepImportDate.Text = "Select Bank File Date:"
        '
        'btnGo
        '
        Me.btnGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.ForeColor = System.Drawing.Color.Green
        Me.btnGo.Location = New System.Drawing.Point(141, 121)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 2
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(278, 124)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(61, 20)
        Me.txtModule.TabIndex = 3
        Me.txtModule.Visible = False
        '
        'frmDirdepImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 188)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.lblDirdepImportDate)
        Me.Controls.Add(Me.dtDirdepImport)
        Me.Name = "frmDirdepImport"
        Me.Text = "Direct Deposit Import "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtDirdepImport As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDirdepImportDate As System.Windows.Forms.Label
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents txtModule As System.Windows.Forms.TextBox
End Class
