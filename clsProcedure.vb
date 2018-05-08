Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subProcedureSelect
'*** B. subProcedureAction
'****************************************
'****************************************

Public Class clsProcedure
    Dim objConnection As New SqlConnection(frmMainMenu.strSFSCon)

    '*** A. subProcedureSelect
    Public Sub subProcedureSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intProcedureID As Integer, ByVal strModule As String, ByVal strCategory As String, ByVal strDescription As String, ByVal strFilePath As String, _
                                  ByVal dtUpdatedDT As Date, ByVal intUpdatedID As Integer, ByVal dtTestedDT As Date, ByVal intTestedID As Integer, ByVal dtApprovedDT As Date, ByVal intApprovedID As Integer, _
                                  ByVal dtCreateDate As Date, ByVal strCreateUser As String)


        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procProcedure"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ProcedureID", intProcedureID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strModule)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Category", strCategory)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Description", strDescription)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FilePath", strFilePath)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UpdatedDT", dtUpdatedDT)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UpdatedID", intUpdatedID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TestedDT", dtTestedDT)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TestedID", intTestedID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ApprovedDT", dtApprovedDT)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ApprovedID", intApprovedID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsProc")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsProc"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                'frmSearch.grdDataList.Columns(1).Visible = False
                SearchMenu.grdDataList.Columns(2).Width = 100
                SearchMenu.grdDataList.Columns(3).Width = 250
                SearchMenu.grdDataList.Columns(4).Width = 100

                SearchMenu.grdDataList.Columns(5).Width = 100
                SearchMenu.grdDataList.Columns(6).Width = 100
                SearchMenu.grdDataList.Columns(7).Width = 100
                SearchMenu.grdDataList.Columns(8).Width = 100
            Case "frmSearchHelp"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsProc"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                'frmSearch.grdDataList.Columns(1).Visible = False
                SearchMenu.grdDataList.Columns(2).Width = 260
                SearchMenu.grdDataList.Columns(3).Width = 320
            Case "frmProcedure"
                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsProc"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmProcedure.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmProcedure.txtModule.DataBindings.Clear()
                frmProcedure.txtProcedureID.DataBindings.Clear()
                frmProcedure.cboCategory.DataBindings.Clear()
                frmProcedure.txtDesc.DataBindings.Clear()
                frmProcedure.txtFilePath.DataBindings.Clear()
                'frmProcedure.txtLastReviewed.DataBindings.Clear()
                'frmProcedure.txtLastReveiwedDate.DataBindings.Clear()
                frmProcedure.dtpUpdatedDT.DataBindings.Clear()
                frmProcedure.txtUpdateID.DataBindings.Clear()
                frmProcedure.cboUpdated.DataBindings.Clear()
                frmProcedure.dtpTestedDT.DataBindings.Clear()
                frmProcedure.txtTestID.DataBindings.Clear()
                frmProcedure.cboTested.DataBindings.Clear()
                frmProcedure.dtpApprovedDT.DataBindings.Clear()
                frmProcedure.txtAppID.DataBindings.Clear()
                frmProcedure.cboApproved.DataBindings.Clear()
                frmProcedure.txtCreateUser.DataBindings.Clear()
                frmProcedure.txtCreateDate.DataBindings.Clear()
                ' ??? - clear bindings for new text fields - not sure about ID fields and name

                'Add new bindings to the DataView object...
                frmProcedure.txtModule.DataBindings.Add("text", objDataView, "Module")
                frmProcedure.txtProcedureID.Visible = True
                frmProcedure.txtProcedureID.DataBindings.Add("text", objDataView, "ProcedureID")
                frmProcedure.txtProcedureID.Visible = False
                frmProcedure.cboCategory.DataBindings.Add("text", objDataView, "Category")
                frmProcedure.txtDesc.DataBindings.Add("text", objDataView, "Description")
                frmProcedure.txtFilePath.DataBindings.Add("text", objDataView, "FilePath")
                frmProcedure.dtpUpdatedDT.DataBindings.Add("text", objDataView, "UpdatedDT")
                frmProcedure.txtUpdateID.DataBindings.Add("text", objDataView, "UpdatedID")
                frmProcedure.dtpTestedDT.DataBindings.Add("text", objDataView, "TestedDT")
                frmProcedure.txtTestID.DataBindings.Add("text", objDataView, "TestedID")
                frmProcedure.dtpApprovedDT.DataBindings.Add("text", objDataView, "ApprovedDT")
                frmProcedure.txtAppID.DataBindings.Add("text", objDataView, "ApprovedID")
                frmProcedure.txtCreateUser.DataBindings.Add("text", objDataView, "CreateUser")
                frmProcedure.txtCreateDate.DataBindings.Add("text", objDataView, "CreateDate")
                ' bind Category to combo box
            Case "frmProcedure-cb"
                frmProcedure.cboCategory.DataSource = objDataSet.Tables("dsProc")
                frmProcedure.cboCategory.DisplayMember = "Category"
                frmProcedure.cboCategory.ValueMember = "Category"
            Case "frmReport-Param1-Owners"
                frmReportMenu.cboParam1.DataSource = objDataSet.Tables("dsProc")
                frmReportMenu.cboParam1.DisplayMember = "Owner"
                frmReportMenu.cboParam1.ValueMember = "Owner"
            Case "frmReport-Param1-Module"
                frmReportMenu.cboParam1.DataSource = objDataSet.Tables("dsProc")
                frmReportMenu.cboParam1.DisplayMember = "Module"
                frmReportMenu.cboParam1.ValueMember = "Module"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objProcData = New clsProcedure
        'Call objProcData.subProcedureSelect(strBindTarget:="NONE", strAction:="SELECT", intProcedureID:=0, strModule:="NONE", _
        'strCategory:="NONE", strDescription:="NONE", strFilePath:="NONE", dtUpdatedDT:="01/01/1900", intUpdatedID:=0, dtTestedDT:="01/01/1900", _
        'intTestedID:=0, dtApprovedDT:="01/01/1900", intApprovedID:=0, dtCreateDate:="01/01/1900", strCreateUser:="NONE")
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subProcedureAction
    Public Sub subProcedureAction(ByVal strAction As String, ByVal intProcedureID As Integer, ByVal strModule As String, ByVal strCategory As String, ByVal strDescription As String, ByVal strFilePath As String, _
                                  ByVal dtUpdatedDT As Date, ByVal intUpdatedID As Integer, ByVal dtTestedDT As Date, ByVal intTestedID As Integer, ByVal dtApprovedDT As Date, ByVal intApprovedID As Integer, _
                                  ByVal dtCreateDate As Date, ByVal strCreateUser As String)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procProcedure"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@ProcedureID", intProcedureID)
        objCommand.Parameters.AddWithValue("@Module", strModule)
        objCommand.Parameters.AddWithValue("@Category", strCategory)
        objCommand.Parameters.AddWithValue("@Description", strDescription)
        objCommand.Parameters.AddWithValue("@FilePath", strFilePath)
        objCommand.Parameters.AddWithValue("@UpdatedDT", dtUpdatedDT)
        objCommand.Parameters.AddWithValue("@UpdatedID", intUpdatedID)
        objCommand.Parameters.AddWithValue("@TestedDT", dtTestedDT)
        objCommand.Parameters.AddWithValue("@TestedID", intTestedID)
        objCommand.Parameters.AddWithValue("@ApprovedDT", dtApprovedDT)
        objCommand.Parameters.AddWithValue("@ApprovedID", intApprovedID)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objProcData = New clsProcedure
        'Call objProcData.subProcedureAction(strAction:="UPDATE", intProcedureID:=frmProcedure.txtProcedureID.Text,strModule:=frmProcedure.txtModule.Text, _
        'strCategory:=frmProcedure.cboCategory.Text, strDescription:=frmProcedure.txtDesc.Text, strFilePath:=frmProcedure.txtFilePath.Text, strLastReveiwed:=frmProcedure.txtLastReviewed.Text, dtLastReveiwedDate:=frmProcedure.dtLastReveiwedDate.Text, strCreateUser:=SystemInformation.UserName)
        '***********************************************
        '***********************************************
    End Sub
End Class
