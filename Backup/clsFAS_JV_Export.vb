'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subJVExportSelect
'*** B. subJVExportAction
'*** C. fncGetJVBatchNumber
'*** D. fncGetJVNameByJVNumber
'*** E. fncCheckCreateUserMatch
'*** F. subJVEditCheck
'****************************************
'****************************************

Public Class clsFAS_JV_Export
    Public WithEvents objSecurityCheck As clsSystem

    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)
    Public intCreateUserMatch As Integer = 0

    '*** A. subJVExportSelect
    Public Sub subJVExportSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, _
                ByVal intTransactionCode As Integer, ByVal strJVDate As String, _
                ByVal strJVNumber As String, ByVal strBudgetNumber As String, _
                ByVal strAccountCode As String, ByVal dblAmount As Double, _
                ByVal strDeptRefNumber As String, ByVal strCostAcctTask As String, _
                ByVal strCostAcctOption As String, ByVal strCostAcctProject As String, _
                ByVal strPositionNumber As String, ByVal strOccupationCode As String, _
                ByVal strServicePeriod As String, ByVal strFTE As String, _
                ByVal strDescription As String, ByVal strJVName As String, _
                ByVal strModule As String, ByVal strExplanation As String, _
                ByVal strCreateUser As String, ByVal dtCreateDate As Date, _
                ByVal strckManagerVer As String, ByVal strManagerVerUser As String, _
                ByVal dtManagerVerDate As Date, ByVal strckSubmitted As String, _
                ByVal strSubmittedUser As String, ByVal dtSubmittedDate As Date, _
                ByVal strckValidated As String, ByVal strValidatedUser As String, _
                ByVal dtValidatedDate As Date, ByVal strOrganizationSuffix As String)


        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procFAS_JV_Export"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TransactionCode", intTransactionCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@JVDate", strJVDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@JVNumber", strJVNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AccountCode", strAccountCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DeptRefNumber", strDeptRefNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CostAcctTask", strCostAcctTask)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CostAcctOption", strCostAcctOption)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CostAcctProject", strCostAcctProject)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PositionNumber", strPositionNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OccupationCode", strOccupationCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ServicePeriod", strServicePeriod)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FTE", strFTE)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Description", strDescription)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@JVName", strJVName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strModule)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Explanation", strExplanation)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ckManagerVer", strckManagerVer)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ManagerVerUser", strManagerVerUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ManagerVerDate", dtManagerVerDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ckSubmitted", strckSubmitted)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SubmittedUser", strSubmittedUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SubmittedDate", dtSubmittedDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ckValidated", strckValidated)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ValidatedUser", strValidatedUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ValidatedDate", dtValidatedDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OrganizationSuffix", strOrganizationSuffix)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsJVExport")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch-By-JV", "frmSearch-By-CU"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsJVExport"

                'Setup form title...
                If strBindTarget = "frmSearch-By-CU" Then
                    frmSearch.Text = "Journal Voucher Created by Search"
                Else
                    frmSearch.Text = "Journal Voucher Search"
                End If

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Width = 150
                frmSearch.grdDataList.Columns(1).Width = 50
                frmSearch.grdDataList.Columns(2).Width = 50
                frmSearch.grdDataList.Columns(3).Width = 100
                frmSearch.grdDataList.Columns(4).Width = 80
                frmSearch.grdDataList.Columns(5).Width = 80


                'Setup column headers...
                frmSearch.grdDataList.Columns(0).HeaderText = "JV Name"
                frmSearch.grdDataList.Columns(1).HeaderText = "Module"
                frmSearch.grdDataList.Columns(2).HeaderText = "Count"
                frmSearch.grdDataList.Columns(3).HeaderText = "Total"
                If strAction = "SELECT-BY-UNVERIFIED" Then
                    frmSearch.grdDataList.Columns(4).HeaderText = "Created By"
                    frmSearch.grdDataList.Columns(5).HeaderText = "Created On"
                ElseIf (strAction = "SELECT-ALL" Or strAction = "JV-SEARCH-CREATEUSER") Then
                    frmSearch.grdDataList.Columns(4).HeaderText = "Created By"
                    frmSearch.grdDataList.Columns(5).HeaderText = "Created On"
                    frmSearch.grdDataList.Columns(6).HeaderText = "Approved By"
                    frmSearch.grdDataList.Columns(7).HeaderText = "Approved On"
                    frmSearch.grdDataList.Columns(8).HeaderText = "Submitted By"
                    frmSearch.grdDataList.Columns(9).HeaderText = "Submitted On"
                    frmSearch.grdDataList.Columns(10).HeaderText = "Validated By"
                    frmSearch.grdDataList.Columns(11).HeaderText = "Validated On"
                Else
                    frmSearch.grdDataList.Columns(4).HeaderText = "Approved By"
                    frmSearch.grdDataList.Columns(5).HeaderText = "Approved On"
                End If
            Case "frmJV-Grid"
                'Set the DataGridView properties to bind it to the data...
                frmJV.grdDataList.DataSource = objDataSet
                frmJV.grdDataList.DataMember = "dsJVExport"

                'Setup alternating rows style...
                frmJV.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmJV.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmJV.grdDataList.Columns(0).Visible = False
                frmJV.grdDataList.Columns(1).Width = 60
                frmJV.grdDataList.Columns(2).Width = 320
                frmJV.grdDataList.Columns(3).Width = 60
                frmJV.grdDataList.Columns(4).Width = 60
                frmJV.grdDataList.Columns(5).Width = 80
                frmJV.grdDataList.Columns(6).Width = 60
                frmJV.grdDataList.Columns(7).Width = 60

                'Setup column headers...
                frmJV.grdDataList.Columns(1).HeaderText = "Date"
                frmJV.grdDataList.Columns(2).HeaderText = "Description"
                frmJV.grdDataList.Columns(3).HeaderText = "Budget"
                frmJV.grdDataList.Columns(4).HeaderText = "Account"
                frmJV.grdDataList.Columns(5).HeaderText = "Amount"
                frmJV.grdDataList.Columns(6).HeaderText = "Module"
                frmJV.grdDataList.Columns(7).HeaderText = "CreateUser"

            Case "frmJV"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsJVExport")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsJVExport"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmExport.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmJV.cboModule.DataBindings.Clear()
                frmJV.txtCount.DataBindings.Clear()
                frmJV.txtTotal.DataBindings.Clear()
                frmJV.txtExplanation.DataBindings.Clear()
                frmJV.txtCreatedBy.DataBindings.Clear()
                frmJV.txtCreatedOn.DataBindings.Clear()
                frmJV.txtApprovedBy.DataBindings.Clear()
                frmJV.txtApprovedOn.DataBindings.Clear()
                frmJV.txtSubmittedBy.DataBindings.Clear()
                frmJV.txtSubmittedOn.DataBindings.Clear()
                frmJV.txtVerifiedBy.DataBindings.Clear()
                frmJV.txtVerifiedOn.DataBindings.Clear()
                frmJV.txtJVNumber.DataBindings.Clear()
                frmJV.txtDeptRefNum.DataBindings.Clear()

                'Add new bindings to the DataView object...

                frmJV.cboModule.DataSource = objDataSet.Tables("dsJVExport")
                frmJV.cboModule.DisplayMember = "Module"
                frmJV.cboModule.ValueMember = "Module"
                frmJV.txtCount.DataBindings.Add("text", objDataView, "TotalCount")
                frmJV.txtTotal.DataBindings.Add("text", objDataView, "TotalAmount")
                frmJV.txtExplanation.DataBindings.Add("text", objDataView, "Explanation")
                frmJV.txtCreatedBy.DataBindings.Add("text", objDataView, "CreateUser")
                frmJV.txtCreatedOn.DataBindings.Add("text", objDataView, "CreateDate")
                frmJV.txtApprovedBy.DataBindings.Add("text", objDataView, "ManagerVerUser")
                frmJV.txtApprovedOn.DataBindings.Add("text", objDataView, "ManagerVerDate")
                frmJV.txtSubmittedBy.DataBindings.Add("text", objDataView, "SubmittedUser")
                frmJV.txtSubmittedOn.DataBindings.Add("text", objDataView, "SubmittedDate")
                frmJV.txtVerifiedBy.DataBindings.Add("text", objDataView, "ValidatedUser")
                frmJV.txtVerifiedOn.DataBindings.Add("text", objDataView, "ValidatedDate")
                frmJV.txtJVNumber.DataBindings.Add("text", objDataView, "JVNumber")
                frmJV.txtDeptRefNum.DataBindings.Add("text", objDataView, "DeptRefNumber")
            Case "frmJVDataTable"
                frmJV.JVDataTable = objDataSet.Tables("dsJVExport")
            Case "frmJV-Export-Temp"
                frmJV.JVExportTable = objDataSet.Tables("dsJVExport")
        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objJVExportData = New clsFAS_JV_Export
        'Call objJVExportData.subJVExportSelect(strBindTarget:="frmSearch", strAction:="ADD", _
        'intRowID:=0, intTransactionCode:=0, strJVDate:="NONE", _
        'strJVNumber:="NONE", strBudgetNumber:="NONE", strAccountCode:="NONE", dblAmount:=0, _
        'strDeptRefNumber:="NONE", strCostAcctTask:="NONE", strCostAcctOption:="NONE", _
        'strCostAcctProject:="NONE", strPositionNumber:="NONE", strOccupationCode:="NONE", _
        'strServicePeriod:="NONE", strFTE:="NONE", strDescription:="NONE", strJVName:="NONE", _
        'strModule:="NONE", strExplanation:="NONE", strCreateUser:="NONE", dtCreateDate:="01/01/1900", _
        'strckManagerVer:="0", strManagerVerUser:="NONE", dtManagerVerDate:="01/01/1900", _
        'strckSubmitted:="0", strSubmittedUser:="NONE", dtSubmittedDate:="01/01/1900", _
        'strckValidated:="0", strValidatedUser:="NONE", dtValidatedDate:="01/01/1900", _
        'strOrganizationSuffix:=frmMainMenu.txtOrganizationSuffix.text)
        '***********************************************
        '***********************************************

    End Sub


    '*** B. subJVExportAction
    Public Sub subJVExportAction(ByVal strAction As String, ByVal intRowID As Integer, _
                ByVal intTransactionCode As Integer, ByVal strJVDate As String, _
                ByVal strJVNumber As String, ByVal strBudgetNumber As String, _
                ByVal strAccountCode As String, ByVal dblAmount As Double, _
                ByVal strDeptRefNumber As String, ByVal strCostAcctTask As String, _
                ByVal strCostAcctOption As String, ByVal strCostAcctProject As String, _
                ByVal strPositionNumber As String, ByVal strOccupationCode As String, _
                ByVal strServicePeriod As String, ByVal strFTE As String, _
                ByVal strDescription As String, ByVal strJVName As String, _
                ByVal strModule As String, ByVal strExplanation As String, _
                ByVal strCreateUser As String, ByVal dtCreateDate As Date, _
                ByVal strckManagerVer As String, ByVal strManagerVerUser As String, _
                ByVal dtManagerVerDate As Date, ByVal strckSubmitted As String, _
                ByVal strSubmittedUser As String, ByVal dtSubmittedDate As Date, _
                ByVal strckValidated As String, ByVal strValidatedUser As String, _
                ByVal dtValidatedDate As Date, ByVal strOrganizationSuffix As String)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procFAS_JV_Export"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@TransactionCode", intTransactionCode)
        objCommand.Parameters.AddWithValue("@JVDate", strJVDate)
        objCommand.Parameters.AddWithValue("@JVNumber", strJVNumber)
        objCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objCommand.Parameters.AddWithValue("@AccountCode", strAccountCode)
        objCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objCommand.Parameters.AddWithValue("@DeptRefNumber", strDeptRefNumber)
        objCommand.Parameters.AddWithValue("@CostAcctTask", strCostAcctTask)
        objCommand.Parameters.AddWithValue("@CostAcctOption", strCostAcctOption)
        objCommand.Parameters.AddWithValue("@CostAcctProject", strCostAcctProject)
        objCommand.Parameters.AddWithValue("@PositionNumber", strPositionNumber)
        objCommand.Parameters.AddWithValue("@OccupationCode", strOccupationCode)
        objCommand.Parameters.AddWithValue("@ServicePeriod", strServicePeriod)
        objCommand.Parameters.AddWithValue("@FTE", strFTE)
        objCommand.Parameters.AddWithValue("@Description", strDescription)
        objCommand.Parameters.AddWithValue("@JVName", strJVName)
        objCommand.Parameters.AddWithValue("@Module", strModule)
        objCommand.Parameters.AddWithValue("@Explanation", strExplanation)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objCommand.Parameters.AddWithValue("@ckManagerVer", strckManagerVer)
        objCommand.Parameters.AddWithValue("@ManagerVerUser", strManagerVerUser)
        objCommand.Parameters.AddWithValue("@ManagerVerDate", dtManagerVerDate)
        objCommand.Parameters.AddWithValue("@ckSubmitted", strckSubmitted)
        objCommand.Parameters.AddWithValue("@SubmittedUser", strSubmittedUser)
        objCommand.Parameters.AddWithValue("@SubmittedDate", dtSubmittedDate)
        objCommand.Parameters.AddWithValue("@ckValidated", strckValidated)
        objCommand.Parameters.AddWithValue("@ValidatedUser", strValidatedUser)
        objCommand.Parameters.AddWithValue("@ValidatedDate", dtValidatedDate)
        objCommand.Parameters.AddWithValue("@OrganizationSuffix", strOrganizationSuffix)

        'Create a SqlParameter object to hold the RETURN value, set the direction to ReturnValue and add to parameters
        Dim retValParam As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        retValParam.Direction = ParameterDirection.ReturnValue
        objCommand.Parameters.Add(retValParam)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()
        intCreateUserMatch = Convert.ToInt32(retValParam.Value)

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objJVExportData = New clsFAS_JV_Export
        'Call objJVExportData.subJVExportAction(strAction:="ADD", _
        'intRowID:=0, intTransactionCode:=0, strJVDate:="NONE", _
        'strJVNumber:="NONE", strBudgetNumber:="NONE", strAccountCode:="NONE", dblAmount:=0, _
        'strDeptRefNumber:="NONE", strCostAcctTask:="NONE", strCostAcctOption:="NONE", _
        'strCostAcctProject:="NONE", strPositionNumber:="NONE", strOccupationCode:="NONE", _
        'strServicePeriod:="NONE", strFTE:="NONE", strDescription:="NONE", strJVName:="NONE", _
        'strModule:="NONE", strExplanation:="NONE", strCreateUser:="NONE", dtCreateDate:="01/01/1900", _
        'strckManagerVer:="0", strManagerVerUser:="NONE", dtManagerVerDate:="01/01/1900", _
        'strckSubmitted:="0", strSubmittedUser:="NONE", dtSubmittedDate:="01/01/1900", _
        'strckValidated:="0", strValidatedUser:="NONE", dtValidatedDate:="01/01/1900", _
        'strOrganizationSuffix:=frmMainMenu.txtOrganizationSuffix.text)
        '***********************************************
        '***********************************************

    End Sub
    '*** C. fncGetJVBatchNumber
    Public Function fncGetJVBatchNumber(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, _
                ByVal intTransactionCode As Integer, ByVal strJVDate As String, _
                ByVal strJVNumber As String, ByVal strBudgetNumber As String, _
                ByVal strAccountCode As String, ByVal dblAmount As Double, _
                ByVal strDeptRefNumber As String, ByVal strCostAcctTask As String, _
                ByVal strCostAcctOption As String, ByVal strCostAcctProject As String, _
                ByVal strPositionNumber As String, ByVal strOccupationCode As String, _
                ByVal strServicePeriod As String, ByVal strFTE As String, _
                ByVal strDescription As String, ByVal strJVName As String, _
                ByVal strModule As String, ByVal strExplanation As String, _
                ByVal strCreateUser As String, ByVal dtCreateDate As Date, _
                ByVal strckManagerVer As String, ByVal strManagerVerUser As String, _
                ByVal dtManagerVerDate As Date, ByVal strckSubmitted As String, _
                ByVal strSubmittedUser As String, ByVal dtSubmittedDate As Date, _
                ByVal strckValidated As String, ByVal strValidatedUser As String, _
                ByVal dtValidatedDate As Date, ByVal strOrganizationSuffix As String) As String
        Dim intBatchNum As Integer

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procFAS_JV_Export"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", "GET-BATCH-NUM")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TransactionCode", intTransactionCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@JVDate", strJVDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@JVNumber", strJVNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AccountCode", strAccountCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DeptRefNumber", strDeptRefNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CostAcctTask", strCostAcctTask)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CostAcctOption", strCostAcctOption)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CostAcctProject", strCostAcctProject)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PositionNumber", strPositionNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OccupationCode", strOccupationCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ServicePeriod", strServicePeriod)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FTE", strFTE)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Description", strDescription)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@JVName", strJVName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strModule)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Explanation", strExplanation)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ckManagerVer", strckManagerVer)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ManagerVerUser", strManagerVerUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ManagerVerDate", dtManagerVerDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ckSubmitted", strckSubmitted)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SubmittedUser", strSubmittedUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SubmittedDate", dtSubmittedDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ckValidated", strckValidated)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ValidatedUser", strValidatedUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ValidatedDate", dtValidatedDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OrganizationSuffix", strOrganizationSuffix)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsGetBatchNum")

        'Close the database connection...
        objConnection.Close()
        intBatchNum = 0

        If objDataSet.Tables("dsGetBatchNum").Rows.Count = 0 Then
            'No match set intBatchNum to 1...
            intBatchNum = 1
        Else
            Dim MyTable As DataTable
            Dim loop1, numrows As Integer

            MyTable = New DataTable
            MyTable = objDataSet.Tables("dsGetBatchNum")

            numrows = MyTable.Rows.Count

            If numrows = 0 Then
                MsgBox("No Records")
            Else
                For loop1 = 0 To numrows - 1
                    'Do Stuff
                    If (MyTable.Rows(loop1).Item("BatchNum")) >= intBatchNum Then
                        intBatchNum = MyTable.Rows(loop1).Item("BatchNum") + 1
                    Else
                        'Do Nothing
                    End If
                Next loop1
            End If
        End If

        'Next
        Cursor.Current = Cursors.Arrow
        Return CStr(intBatchNum)

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objJVExportData = New clsFAS_JV_Export
        'Call objJVExportData.fncGetJVBatchNumber(strBindTarget:="NONE", strAction:="NONE", _
        'intRowID:=0, intTransactionCode:=0, strJVDate:="NONE", _
        'strJVNumber:="NONE", strBudgetNumber:="NONE", strAccountCode:="NONE", dblAmount:=0, _
        'strDeptRefNumber:="NONE", strCostAcctTask:="NONE", strCostAcctOption:="NONE", _
        'strCostAcctProject:="NONE", strPositionNumber:="NONE", strOccupationCode:="NONE", _
        'strServicePeriod:="NONE", strFTE:="NONE", strDescription:="NONE", strJVName:="NONE", _
        'strModule:="NONE", strExplanation:="NONE", strCreateUser:="NONE", dtCreateDate:="01/01/1900", _
        'strckManagerVer:="0", strManagerVerUser:="NONE", dtManagerVerDate:="01/01/1900", _
        'strckSubmitted:="0", strSubmittedUser:="NONE", dtSubmittedDate:="01/01/1900", _
        'strckValidated:="0", strValidatedUser:="NONE", dtValidatedDate:="01/01/1900", _
        'strOrganizationSuffix:=frmMainMenu.txtOrganizationSuffix.text)

        '***********************************************
        '***********************************************

    End Function

    '*** D. fncGetJVNameByJVNumber
    Public Function fncGetJVNameByJVNumber(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, _
                ByVal intTransactionCode As Integer, ByVal strJVDate As String, _
                ByVal strJVNumber As String, ByVal strBudgetNumber As String, _
                ByVal strAccountCode As String, ByVal dblAmount As Double, _
                ByVal strDeptRefNumber As String, ByVal strCostAcctTask As String, _
                ByVal strCostAcctOption As String, ByVal strCostAcctProject As String, _
                ByVal strPositionNumber As String, ByVal strOccupationCode As String, _
                ByVal strServicePeriod As String, ByVal strFTE As String, _
                ByVal strDescription As String, ByVal strJVName As String, _
                ByVal strModule As String, ByVal strExplanation As String, _
                ByVal strCreateUser As String, ByVal dtCreateDate As Date, _
                ByVal strckManagerVer As String, ByVal strManagerVerUser As String, _
                ByVal dtManagerVerDate As Date, ByVal strckSubmitted As String, _
                ByVal strSubmittedUser As String, ByVal dtSubmittedDate As Date, _
                ByVal strckValidated As String, ByVal strValidatedUser As String, _
                ByVal dtValidatedDate As Date, ByVal strOrganizationSuffix As String) As String

        Dim strJVNameReturn As String
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procFAS_JV_Export"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", "GET-JVNameByJVNumber")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TransactionCode", intTransactionCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@JVDate", strJVDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@JVNumber", strJVNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AccountCode", strAccountCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DeptRefNumber", strDeptRefNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CostAcctTask", strCostAcctTask)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CostAcctOption", strCostAcctOption)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CostAcctProject", strCostAcctProject)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PositionNumber", strPositionNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OccupationCode", strOccupationCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ServicePeriod", strServicePeriod)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FTE", strFTE)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Description", strDescription)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@JVName", strJVName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strModule)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Explanation", strExplanation)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ckManagerVer", strckManagerVer)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ManagerVerUser", strManagerVerUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ManagerVerDate", dtManagerVerDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ckSubmitted", strckSubmitted)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SubmittedUser", strSubmittedUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SubmittedDate", dtSubmittedDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ckValidated", strckValidated)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ValidatedUser", strValidatedUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ValidatedDate", dtValidatedDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OrganizationSuffix", strOrganizationSuffix)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsGetJVNum")
        'Close the database connection...
        objConnection.Close()

        strJVNameReturn = "NONE"

        If objDataSet.Tables("dsGetJVNum").Rows.Count = 0 Then
            strJVNameReturn = "FAIL"
        Else
            strJVNameReturn = "PASS"
            Dim MyTable As DataTable
            Dim loop1, numrows As Integer

            MyTable = New DataTable
            MyTable = objDataSet.Tables("dsGetJVNum")

            numrows = MyTable.Rows.Count

            If numrows = 0 Then
                MsgBox("No Records")
            Else
                For loop1 = 0 To numrows - 1
                    strJVNameReturn = MyTable.Rows(loop1).Item("JVName")
                Next loop1
            End If
        End If

        Cursor.Current = Cursors.Arrow

        Return CStr(strJVNameReturn)

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objJVExportData = New clsFAS_JV_Export
        'Call objJVExportData.fncGetJVNameByJVNumber(strBindTarget:="NONE", strAction:="NONE", _
        'intRowID:=0, intTransactionCode:=0, strJVDate:="NONE", _
        'strJVNumber:=InputBox("Enter JV name:", "JV Search"), strBudgetNumber:="NONE", strAccountCode:="NONE", dblAmount:=0, _
        'strDeptRefNumber:="NONE", strCostAcctTask:="NONE", strCostAcctOption:="NONE", _
        'strCostAcctProject:="NONE", strPositionNumber:="NONE", strOccupationCode:="NONE", _
        'strServicePeriod:="NONE", strFTE:="NONE", strDescription:="NONE", strJVName:="NONE", _
        'strModule:="NONE", strExplanation:="NONE", strCreateUser:="NONE", dtCreateDate:="01/01/1900", _
        'strckManagerVer:="0", strManagerVerUser:="NONE", dtManagerVerDate:="01/01/1900", _
        'strckSubmitted:="0", strSubmittedUser:="NONE", dtSubmittedDate:="01/01/1900", _
        'strckValidated:="0", strValidatedUser:="NONE", dtValidatedDate:="01/01/1900", _
        'strOrganizationSuffix:=frmMainMenu.txtOrganizationSuffix.text)

        '***********************************************
        '***********************************************

    End Function

    '*** E. fncCheckCreateUserMatch
    Public Function fncEditCheck(ByVal strAction As String) As Integer
        If strAction = "CreateUser" Then
            Call subJVExportAction(strAction:="CREATEUSER-EDIT-CHECK", _
            intRowID:=0, intTransactionCode:=0, strJVDate:="NONE", _
            strJVNumber:="NONE", strBudgetNumber:="NONE", strAccountCode:="NONE", dblAmount:=0, _
            strDeptRefNumber:="NONE", strCostAcctTask:="NONE", strCostAcctOption:="NONE", _
            strCostAcctProject:="NONE", strPositionNumber:="NONE", strOccupationCode:="NONE", _
            strServicePeriod:="NONE", strFTE:="NONE", strDescription:="NONE", strJVName:=frmMainMenu.txtActionID.Text, _
            strModule:="NONE", strExplanation:="NONE", strCreateUser:=SystemInformation.UserName, dtCreateDate:="01/01/1900", _
            strckManagerVer:="0", strManagerVerUser:="NONE", dtManagerVerDate:="01/01/1900", _
            strckSubmitted:="0", strSubmittedUser:="NONE", dtSubmittedDate:="01/01/1900", _
            strckValidated:="0", strValidatedUser:="NONE", dtValidatedDate:="01/01/1900", strOrganizationSuffix:=frmMainMenu.txtOrganizationSuffix.Text)

            Return intCreateUserMatch
        End If

        If strAction = "ManagerVerUser" Then
            Call subJVExportAction(strAction:="MANAGERVERUSER-EDIT-CHECK", _
            intRowID:=0, intTransactionCode:=0, strJVDate:="NONE", _
            strJVNumber:="NONE", strBudgetNumber:="NONE", strAccountCode:="NONE", dblAmount:=0, _
            strDeptRefNumber:="NONE", strCostAcctTask:="NONE", strCostAcctOption:="NONE", _
            strCostAcctProject:="NONE", strPositionNumber:="NONE", strOccupationCode:="NONE", _
            strServicePeriod:="NONE", strFTE:="NONE", strDescription:="NONE", strJVName:=frmMainMenu.txtActionID.Text, _
            strModule:="NONE", strExplanation:="NONE", strCreateUser:="NONE", dtCreateDate:="01/01/1900", _
            strckManagerVer:="0", strManagerVerUser:=SystemInformation.UserName, dtManagerVerDate:="01/01/1900", _
            strckSubmitted:="0", strSubmittedUser:="NONE", dtSubmittedDate:="01/01/1900", _
            strckValidated:="0", strValidatedUser:="NONE", dtValidatedDate:="01/01/1900", strOrganizationSuffix:=frmMainMenu.txtOrganizationSuffix.Text)

            Return intCreateUserMatch
        End If

    End Function

    '*** F. subJVEditCheck
    Public Sub subJVEditCheck()
        Dim strEditCheck As String

        strEditCheck = "FAIL"

        'Allow CreateUser to edit if JV has not been approved by manager
        If fncEditCheck("CreateUser") <> 0 Then
            strEditCheck = "PASS"
        End If

        ''LOGIC NEEDS WORK
        ''Allow Manager access to edit if JV has not been submitted
        'If fncEditCheck("ManagerVerUser") <> 0 Then
        '    strEditCheck = "PASS"
        'End If

        If strEditCheck = "FAIL" Then
            frmJV.Text = "Journal Voucher (" + frmMainMenu.txtActionID.Text + ") Read Only"
            frmJV.btnGO.Visible = False
            frmJV.btnExit.ForeColor = Color.Red
            frmJV.btnAdd.Enabled = False
            frmJV.btnReport.Enabled = True
            frmJV.cboModule.Enabled = False
            frmJV.txtExplanation.ReadOnly = True
        Else
            frmJV.Text = "Journal Voucher (" + frmMainMenu.txtActionID.Text + ") Edit Mode"
            frmJV.btnGO.Visible = True
            frmJV.btnGO.Text = "Save"
            frmJV.btnGO.ForeColor = Color.Green
            frmJV.btnExit.ForeColor = Color.Red
            frmJV.btnAdd.Enabled = True
            frmJV.btnReport.Enabled = True
            frmJV.cboModule.Enabled = True
            frmJV.txtExplanation.ReadOnly = False
        End If

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objJVExportData = New clsFAS_JV_Export
        'Call objJVExportData.subJVEditCheck()
        '***********************************************
        '***********************************************

    End Sub

End Class
