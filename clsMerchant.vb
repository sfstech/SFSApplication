Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subMerchSelect
'*** B. subMerchAction
'****************************************
'****************************************
Public Class clsMerchant
    Dim objConnection As New SqlConnection(frmMainMenu.strSFSCon)

    '*** A. subMerchSelect
    Public Sub subMerchSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intMerchantID As Integer, ByVal strMerchantNum As String, ByVal strMerchantNumFull As String, ByVal strMerchantType As String, _
    ByVal strMerchantDesc As String, ByVal btOptOut As Boolean, ByVal intContactID As Integer, ByVal strCreateUser As String, ByVal dtCreateDate As Date, _
    ByVal strprocess_type As String, ByVal strprocess_type_desc As String, ByVal strterminal_status As String, ByVal strstatement_pref As String, _
    ByVal strBillingServicer As String, ByVal strRevBudgetNum As String, ByVal strRevRevenueCode As String, ByVal strRevTask As String, ByVal strRevOption As String, _
    ByVal strRevProject As String, ByVal strExpBudgetNum As String, ByVal strExpRevenueCode As String, ByVal strExpTask As String, ByVal strExpOption As String, _
    ByVal strExpProject As String, ByVal strStatus As String, ByVal intDeptID As Integer, ByVal dtLastSurveyDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "[procMerchant]"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantID", intMerchantID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantNum", strMerchantNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantNumFull", strMerchantNumFull)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantType", strMerchantType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantDesc", strMerchantDesc)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OptOut", btOptOut)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ContactID", intContactID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@process_type", strprocess_type)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@process_type_desc", strprocess_type_desc)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@terminal_status", strterminal_status)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@statement_pref ", strstatement_pref)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BillingServicer ", strBillingServicer)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RevBudgetNum", strRevBudgetNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RevRevenueCode", strRevRevenueCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RevTask", strRevTask)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RevOption", strRevOption)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RevProject", strRevProject)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ExpBudgetNum", strExpBudgetNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ExpRevenueCode", strExpRevenueCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ExpTask", strExpTask)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ExpOption", strExpOption)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ExpProject", strExpProject)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Status", strStatus)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DeptID", intDeptID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@LastSurveyDate", dtLastSurveyDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsMerchant")

        'Close the database connection...
        objConnection.Close()

        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmMerchants"
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsMerchant"
                frmMerchants.MerchTbl = objDataSet.Tables(0)
                frmMerchants.txtMerchantDesc.Text = objDataSet.Tables(0).Rows(0).Item("MerchantDesc").ToString
                frmMerchants.txtMerchantAbbrv.Text = objDataSet.Tables(0).Rows(0).Item("MerchantNum").ToString
                If Len(objDataSet.Tables(0).Rows(0).Item("MerchantNumFull").ToString) > 0 Then
                    frmMerchants.txtMerchantNumFull.Text = objDataSet.Tables(0).Rows(0).Item("MerchantNumFull").ToString
                End If
                '  Dim t As String = objDataSet.Tables(0).Rows(0).Item("BillingServicer")
                frmMerchants.cboMerchantType.Text = objDataSet.Tables(0).Rows(0).Item("MerchantType").ToString
                frmMerchants.cboProcessingType.Text = objDataSet.Tables(0).Rows(0).Item("process_type").ToString
                frmMerchants.cboTermStatus.Text = objDataSet.Tables(0).Rows(0).Item("terminal_status").ToString
                frmMerchants.txtProcTypeDesc.Text = objDataSet.Tables(0).Rows(0).Item("process_type_desc").ToString
                frmMerchants.cboStatus.Text = objDataSet.Tables(0).Rows(0).Item("Status").ToString
                If objDataSet.Tables(0).Rows(0).Item("LastSurveyDate") IsNot System.DBNull.Value Then
                    If Len(objDataSet.Tables(0).Rows(0).Item("LastSurveyDate").ToString) > 0 And Format(objDataSet.Tables(0).Rows(0).Item("LastSurveyDate"), "short date") <> "1/1/1900" Then
                        frmMerchants.txtLastSurveyDate.Text = Format(objDataSet.Tables(0).Rows(0).Item("LastSurveyDate"), "short date")
                    End If
                End If
                frmMerchants.cboBillServ.Text = objDataSet.Tables(0).Rows(0).Item("BillingServicer").ToString
                If objDataSet.Tables(0).Rows(0).Item("opt_out").ToString = True Then
                    frmMerchants.cboOptOut.Text = "Y"
                Else
                    frmMerchants.cboOptOut.Text = "N"
                End If
                frmMerchants.cboPerson.Text = objDataSet.Tables(0).Rows(0).Item("LName").ToString + ", " + objDataSet.Tables(0).Rows(0).Item("FName").ToString
                frmMerchants.cboStatePref.Text = objDataSet.Tables(0).Rows(0).Item("statement_pref").ToString
                frmMerchants.cboDepartment.Text = objDataSet.Tables(0).Rows(0).Item("DeptName").ToString
                frmMerchants.txtPhone.Text = objDataSet.Tables(0).Rows(0).Item("PrefPhone").ToString
                frmMerchants.txtEmail.Text = objDataSet.Tables(0).Rows(0).Item("Email").ToString
                frmMerchants.txtCreateUser.Text = objDataSet.Tables(0).Rows(0).Item("CreateUser").ToString

                frmMerchants.txtCreateDate.Text = Format(objDataSet.Tables(0).Rows(0).Item("CreateDate"), "short date")
                '       Format(System.DateTime.Now, "short date")

                ' Budget Tab
                frmMerchants.tabBudtxtRevBudget.Text = objDataSet.Tables(0).Rows(0).Item("RevBudgetNum").ToString
                frmMerchants.tabBudtxtRevRevCode.Text = objDataSet.Tables(0).Rows(0).Item("RevRevenueCode").ToString
                frmMerchants.tabBudtxtRevTask.Text = objDataSet.Tables(0).Rows(0).Item("RevTask").ToString
                frmMerchants.tabBudtxtRevOption.Text = objDataSet.Tables(0).Rows(0).Item("RevOption").ToString
                frmMerchants.tabBudtxtRevProject.Text = objDataSet.Tables(0).Rows(0).Item("RevProject").ToString

                frmMerchants.tabBudtxtExpBudget.Text = objDataSet.Tables(0).Rows(0).Item("ExpBudgetNum").ToString
                frmMerchants.tabBudtxtExpRevCode.Text = objDataSet.Tables(0).Rows(0).Item("ExpRevenueCode").ToString
                frmMerchants.tabBudtxtExpTask.Text = objDataSet.Tables(0).Rows(0).Item("ExpTask").ToString
                frmMerchants.tabBudtxtExpOption.Text = objDataSet.Tables(0).Rows(0).Item("ExpOption").ToString
                frmMerchants.tabBudtxtExpProject.Text = objDataSet.Tables(0).Rows(0).Item("ExpProject").ToString


            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsMerchant"

                'Setup form title...
                SearchMenu.Text = "Select Merchant"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).Visible = False
                SearchMenu.grdDataList.Columns(2).Width = 70
                SearchMenu.grdDataList.Columns(3).Width = 200
                SearchMenu.grdDataList.Columns(4).Width = 55
                SearchMenu.grdDataList.Columns(5).Width = 55
                SearchMenu.grdDataList.Columns(6).Width = 65
                SearchMenu.grdDataList.Columns(7).Width = 55
                SearchMenu.grdDataList.Columns(8).Width = 85
                SearchMenu.grdDataList.Columns(9).Width = 80
                SearchMenu.grdDataList.Columns(10).Width = 75
                SearchMenu.grdDataList.Columns(11).Width = 200

                '  frmMerchants.gridMerchants.Columns(0).HeaderText = "Merchant ID"
                '  frmMerchants.gridMerchants.Columns(1).HeaderText = "DeptID"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Merchant"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Department"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Revenue"
                SearchMenu.grdDataList.Columns(5).HeaderText = "Expense"
                SearchMenu.grdDataList.Columns(6).HeaderText = "Processing Type"
                SearchMenu.grdDataList.Columns(7).HeaderText = "First"
                SearchMenu.grdDataList.Columns(8).HeaderText = "Last"
                SearchMenu.grdDataList.Columns(9).HeaderText = "Last Survey"
                SearchMenu.grdDataList.Columns(10).HeaderText = "Create Date"
                SearchMenu.grdDataList.Columns(11).HeaderText = "Merchant Name"

            Case "frmMerchantsChangesTab"
                'Set the DataGridView properties to bind it to the data...
                frmMerchants.gridChanges.DataSource = objDataSet
                frmMerchants.gridChanges.DataMember = "dsMerchant"

                frmMerchants.gridChanges.Columns(0).Width = 75
                frmMerchants.gridChanges.Columns(1).Width = 400
                frmMerchants.gridChanges.Columns(2).Width = 150

                frmMerchants.gridChanges.EditMode = DataGridViewEditMode.EditProgrammatically

            Case "frmMerchantsOtherMerchTab"

                'Set the DataGridView properties to bind it to the data...
                frmMerchants.gridMerchants.DataSource = objDataSet
                frmMerchants.gridMerchants.DataMember = "dsMerchant"

                frmMerchants.gridMerchants.Columns(0).Visible = False
                frmMerchants.gridMerchants.Columns(1).Visible = False
                frmMerchants.gridMerchants.Columns(2).Width = 70
                frmMerchants.gridMerchants.Columns(3).Width = 60
                frmMerchants.gridMerchants.Columns(4).Width = 50
                frmMerchants.gridMerchants.Columns(5).Width = 290
                frmMerchants.gridMerchants.Columns(6).Width = 50
                frmMerchants.gridMerchants.Columns(7).Width = 50
                frmMerchants.gridMerchants.Columns(8).Width = 60

                frmMerchants.gridMerchants.EditMode = DataGridViewEditMode.EditProgrammatically

                'Setup column headers...
                frmMerchants.gridMerchants.Columns(0).HeaderText = "Merchant ID"
                frmMerchants.gridMerchants.Columns(1).HeaderText = "DeptID"
                frmMerchants.gridMerchants.Columns(2).HeaderText = "Merchant Full #"
                frmMerchants.gridMerchants.Columns(3).HeaderText = "Merchant"
                frmMerchants.gridMerchants.Columns(4).HeaderText = "Type"
                frmMerchants.gridMerchants.Columns(5).HeaderText = "Description"
                frmMerchants.gridMerchants.Columns(6).HeaderText = "Rev budget"
                frmMerchants.gridMerchants.Columns(7).HeaderText = "Exp Budget"
                frmMerchants.gridMerchants.Columns(8).HeaderText = "Processing Type"

            Case "frmMerchantsBillHistTab"

                'Set the DataGridView properties to bind it to the data...
                frmMerchants.gridBillHistory.DataSource = objDataSet
                frmMerchants.gridBillHistory.DataMember = "dsMerchant"

                frmMerchants.gridBillHistory.Columns(0).Width = 70
                frmMerchants.gridBillHistory.Columns(1).Width = 100
                frmMerchants.gridBillHistory.Columns(2).Width = 60
                frmMerchants.gridBillHistory.Columns(3).Width = 80
                frmMerchants.gridBillHistory.Columns(4).Width = 100

                frmMerchants.gridBillHistory.Columns(0).HeaderText = "Date"
                frmMerchants.gridBillHistory.Columns(1).HeaderText = "Period Month"
                frmMerchants.gridBillHistory.Columns(2).HeaderText = "Year"
                frmMerchants.gridBillHistory.Columns(3).HeaderText = "   Total"
                frmMerchants.gridBillHistory.Columns(3).DefaultCellStyle.Format = "c"
                frmMerchants.gridBillHistory.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmMerchants.gridBillHistory.Columns(4).HeaderText = "Create User"
            Case "frmMerchant-Merch-Check"
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsMerchant"
                frmMerchants.MerchTbl = objDataSet.Tables(0)
            Case "frmSearch-MerchBill"

                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsMerchant"

                'Setup form title...
                SearchMenu.Text = "Merchant Billing Email"
                'Case "frmDepartment-grdMerchant"
                '    'BOINGO
                '    'Set the DataGridView properties to bind it to the data...
                '    frmDepartment.grdMerchant.DataSource = objDataSet
                '    frmDepartment.grdMerchant.DataMember = "dsDepartment"

                '    'Setup alternating rows style...
                '    frmDepartment.grdMerchant.AutoGenerateColumns = True
                '    Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                '    objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                '    frmDepartment.grdMerchant.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                '    'Setup column widths...
                '    frmDepartment.grdMerchant.Columns(0).Visible = False
                '    frmDepartment.grdMerchant.Columns(1).Visible = False
                '    frmDepartment.grdMerchant.Columns(2).Width = 70
                '    ' frmDepartment.grdMerchant.Columns(3).Width = False
                '    frmDepartment.grdMerchant.Columns(3).Width = 80
                '    frmDepartment.grdMerchant.Columns(4).Width = 150
                '    frmDepartment.grdMerchant.Columns(5).Width = 80
                '    frmDepartment.grdMerchant.Columns(6).Visible = False
                '    frmDepartment.grdMerchant.Columns(7).Width = 35
                '    frmDepartment.grdMerchant.Columns(8).Width = 85
                '    frmDepartment.grdMerchant.Columns(9).Visible = False
                '    frmDepartment.grdMerchant.Columns(10).Width = 85
                '    frmDepartment.grdMerchant.Columns(11).Visible = False

                '    'Setup column headers...
                '    frmDepartment.grdMerchant.Columns(2).HeaderText = "Merchant #"
                '    ' frmDepartment.grdMerchant.Columns(3).HeaderText = "Merchant # Full"
                '    frmDepartment.grdMerchant.Columns(3).HeaderText = "Type"
                '    frmDepartment.grdMerchant.Columns(4).HeaderText = "Desc"
                '    frmDepartment.grdMerchant.Columns(5).HeaderText = "Contact"
                '    frmDepartment.grdMerchant.Columns(7).HeaderText = "Opt Out"
                '    frmDepartment.grdMerchant.Columns(8).HeaderText = "Created By"
                '    frmDepartment.grdMerchant.Columns(10).HeaderText = "Created On"
                'Case "frmExport"
                '    'Set the DataGridView properties to bind it to the data...
                '    frmExport.grdDataList.DataSource = objDataSet
                '    frmExport.grdDataList.DataMember = "dsDepartment"
        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'Call objMerchData.subMerchSelect(strBindTarget:="frmSearch", strAction:="SELECT_MERCH-ALL", strMerchantNum:="NONE", strMerchantNumFull:="NONE", strMerchantType:="NONE", _
        '        strMerchantDesc:="NONE", btOptOut:=0, intContactID:=0, strCreateUser:="NONE", dtCreateDate:="01/01/1900", _
        '        strprocess_type:="NONE", strprocess_type_desc:="NONE", strterminal_status:="NONE", strstatement_pref:="NONE", _
        '        strBillingServicer:="NONE", strRevBudgetNum:="NONE", strRevRevenueCode:="NONE", strRevTask:="NONE", strRevOption:="NONE", _
        '        strRevProject:="NONE", strExpBudgetNum:="NONE", strExpRevenueCode:="NONE", strExpTask:="NONE", strExpOption:="NONE", _
        '        strExpProject:="NONE", strStatus:="NONE")
        '***********************************************
        '***********************************************

    End Sub

    '*** B. subMerchAction
    Public Sub subMerchAction(ByVal strAction As String, ByVal intMerchantID As Integer, ByVal strMerchantNum As String, ByVal strMerchantNumFull As String, ByVal strMerchantType As String, _
    ByVal strMerchantDesc As String, ByVal btOptOut As Boolean, ByVal intContactID As Integer, ByVal strCreateUser As String, ByVal dtCreateDate As Date, _
    ByVal strprocess_type As String, ByVal strprocess_type_desc As String, ByVal strterminal_status As String, ByVal strstatement_pref As String, _
    ByVal strBillingServicer As String, ByVal strRevBudgetNum As String, ByVal strRevRevenueCode As String, ByVal strRevTask As String, ByVal strRevOption As String, _
    ByVal strRevProject As String, ByVal strExpBudgetNum As String, ByVal strExpRevenueCode As String, ByVal strExpTask As String, ByVal strExpOption As String, _
    ByVal strExpProject As String, ByVal strStatus As String, ByVal intDeptID As Integer, ByVal dtLastSurveyDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "[procMerchant]"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@MerchantID", intMerchantID)
        objCommand.Parameters.AddWithValue("@MerchantNum", strMerchantNum)
        objCommand.Parameters.AddWithValue("@MerchantNumFull", strMerchantNumFull)
        objCommand.Parameters.AddWithValue("@MerchantType", strMerchantType)
        objCommand.Parameters.AddWithValue("@MerchantDesc", strMerchantDesc)
        objCommand.Parameters.AddWithValue("@OptOut", btOptOut)
        objCommand.Parameters.AddWithValue("@ContactID", intContactID)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objCommand.Parameters.AddWithValue("@process_type", strprocess_type)
        objCommand.Parameters.AddWithValue("@process_type_desc", strprocess_type_desc)
        objCommand.Parameters.AddWithValue("@terminal_status", strterminal_status)
        objCommand.Parameters.AddWithValue("@statement_pref ", strstatement_pref)
        objCommand.Parameters.AddWithValue("@BillingServicer ", strBillingServicer)
        objCommand.Parameters.AddWithValue("@RevBudgetNum", strRevBudgetNum)
        objCommand.Parameters.AddWithValue("@RevRevenueCode", strRevRevenueCode)
        objCommand.Parameters.AddWithValue("@RevTask", strRevTask)
        objCommand.Parameters.AddWithValue("@RevOption", strRevOption)
        objCommand.Parameters.AddWithValue("@RevProject", strRevProject)
        objCommand.Parameters.AddWithValue("@ExpBudgetNum", strExpBudgetNum)
        objCommand.Parameters.AddWithValue("@ExpRevenueCode", strExpRevenueCode)
        objCommand.Parameters.AddWithValue("@ExpTask", strExpTask)
        objCommand.Parameters.AddWithValue("@ExpOption", strExpOption)
        objCommand.Parameters.AddWithValue("@ExpProject", strExpProject)
        objCommand.Parameters.AddWithValue("@Status", strStatus)
        objCommand.Parameters.AddWithValue("@DeptID", intDeptID)
        objCommand.Parameters.AddWithValue("@LastSurveyDate", dtLastSurveyDate)
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objDeptAction = New clsDepartment
        'Call objDeptAction.subDeptAction(strAction:="UPDATE-DEPARTMENT", intDeptID:=0 , strDeptName:="NONE", _
        'strBudgetNum:="NONE", strRevenueCode:="NONE", strTask:="X", strOption:="X", strProject:="X", _
        'intBudgetID:=0,intMerchantID:=0, strMerchantNum:="NONE", strMerchantType:="NONE", strMerchantDesc:="NONE", btOptOut:="False", _
        'strCreateUser:="NONE",stCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub
End Class
