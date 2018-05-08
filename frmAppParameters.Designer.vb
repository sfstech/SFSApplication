<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAppParameters
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
        Me.dgvAppParameters = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ApplicationParameters = New SFS.ApplicationParameters()
        Me.TblAppParametersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblAppParametersTableAdapter = New SFS.ApplicationParametersTableAdapters.tblAppParametersTableAdapter()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParameternameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParametervalueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessnameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifieddateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifiedbyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSave = New System.Windows.Forms.Button()
        CType(Me.dgvAppParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ApplicationParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblAppParametersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAppParameters
        '
        Me.dgvAppParameters.AllowUserToDeleteRows = False
        Me.dgvAppParameters.AutoGenerateColumns = False
        Me.dgvAppParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAppParameters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.ParameternameDataGridViewTextBoxColumn, Me.ParametervalueDataGridViewTextBoxColumn, Me.ProcessnameDataGridViewTextBoxColumn, Me.ModifieddateDataGridViewTextBoxColumn, Me.ModifiedbyDataGridViewTextBoxColumn})
        Me.dgvAppParameters.DataSource = Me.TblAppParametersBindingSource
        Me.dgvAppParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAppParameters.Location = New System.Drawing.Point(0, 0)
        Me.dgvAppParameters.Name = "dgvAppParameters"
        Me.dgvAppParameters.Size = New System.Drawing.Size(742, 353)
        Me.dgvAppParameters.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvAppParameters)
        Me.Panel1.Location = New System.Drawing.Point(4, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(742, 353)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Location = New System.Drawing.Point(7, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(739, 57)
        Me.Panel2.TabIndex = 2
        '
        'ApplicationParameters
        '
        Me.ApplicationParameters.DataSetName = "ApplicationParameters"
        Me.ApplicationParameters.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TblAppParametersBindingSource
        '
        Me.TblAppParametersBindingSource.DataMember = "tblAppParameters"
        Me.TblAppParametersBindingSource.DataSource = Me.ApplicationParameters
        '
        'TblAppParametersTableAdapter
        '
        Me.TblAppParametersTableAdapter.ClearBeforeFill = True
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ParameternameDataGridViewTextBoxColumn
        '
        Me.ParameternameDataGridViewTextBoxColumn.DataPropertyName = "parameter_name"
        Me.ParameternameDataGridViewTextBoxColumn.HeaderText = "parameter_name"
        Me.ParameternameDataGridViewTextBoxColumn.Name = "ParameternameDataGridViewTextBoxColumn"
        Me.ParameternameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ParametervalueDataGridViewTextBoxColumn
        '
        Me.ParametervalueDataGridViewTextBoxColumn.DataPropertyName = "parameter_value"
        Me.ParametervalueDataGridViewTextBoxColumn.HeaderText = "parameter_value"
        Me.ParametervalueDataGridViewTextBoxColumn.Name = "ParametervalueDataGridViewTextBoxColumn"
        '
        'ProcessnameDataGridViewTextBoxColumn
        '
        Me.ProcessnameDataGridViewTextBoxColumn.DataPropertyName = "process_name"
        Me.ProcessnameDataGridViewTextBoxColumn.HeaderText = "process_name"
        Me.ProcessnameDataGridViewTextBoxColumn.Name = "ProcessnameDataGridViewTextBoxColumn"
        Me.ProcessnameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ModifieddateDataGridViewTextBoxColumn
        '
        Me.ModifieddateDataGridViewTextBoxColumn.DataPropertyName = "modified_date"
        Me.ModifieddateDataGridViewTextBoxColumn.HeaderText = "modified_date"
        Me.ModifieddateDataGridViewTextBoxColumn.Name = "ModifieddateDataGridViewTextBoxColumn"
        Me.ModifieddateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ModifiedbyDataGridViewTextBoxColumn
        '
        Me.ModifiedbyDataGridViewTextBoxColumn.DataPropertyName = "modified_by"
        Me.ModifiedbyDataGridViewTextBoxColumn.HeaderText = "modified_by"
        Me.ModifiedbyDataGridViewTextBoxColumn.Name = "ModifiedbyDataGridViewTextBoxColumn"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(653, 31)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmAppParameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 433)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmAppParameters"
        Me.Text = "Application Parameters"
        CType(Me.dgvAppParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.ApplicationParameters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblAppParametersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAppParameters As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ApplicationParameters As SFS.ApplicationParameters
    Friend WithEvents TblAppParametersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblAppParametersTableAdapter As SFS.ApplicationParametersTableAdapters.tblAppParametersTableAdapter
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParameternameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParametervalueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessnameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifieddateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifiedbyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
