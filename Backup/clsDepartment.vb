Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subDeptSelect
'*** B. subDeptAction
'*** C. fncGetMaxDeptID
'****************************************
'****************************************

Public Class clsDepartment
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subDeptSelect
    Public Sub subDeptSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intDeptID As Integer, _
    ByVal strDeptName As String, ByVal strBudgetNum As String, ByVal strRevenueCode As String, ByVal strTask As String, _
    ByVal strOption As String, ByVal strProject As String, ByVal intBudgetID As Integer, ByVal intMerchantID As Integer, _
    ByVal strMerchantNum As String, ByVal strMerchantNumFull As String, ByVal strMerchantType As String, ByVal strMerchantDesc As String, _
    ByVal bitOptOut As Boolean, ByVal strCreateUser As String, ByVal dtCreateDate As Date, _
    ByVal strprocess_type As String, ByVal strprocess_type_desc As String, ByVal strterminal_status As String, ByVal strstatement_pref As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "[procDepartment]"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DeptID", intDeptID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DeptName", strDeptName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetNum", strBudgetNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RevenueCode", strRevenueCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Task", strTask)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Option", strOption)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Project", strProject)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetID", intBudgetID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantID", intMerchantID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantNum", strMerchantNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantNumFull", strMerchantNumFull)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantType", strMerchantType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantDesc", strMerchantDesc)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OptOut", bitOptOut)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@process_type", strprocess_type)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@process_type_desc", strprocess_type_desc)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@terminal_status", strterminal_status)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@statement_pref ", strstatement_pref)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsDepartment")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsDepartment"

                'Setup form title...
                frmSearch.Text = "Select Department"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Width = 50
                frmSearch.grdDataList.Columns(1).Width = 250
                frmSearch.grdDataList.Columns(2).Visible = False
                frmSearch.grdDataList.Columns(3).Visible = False

                'Setup column headers...
                frmSearch.grdDataList.Columns(0).HeaderText = "Dept ID"
                frmSearch.grdDataList.Columns(1).HeaderText = "Department"

            Case "frmDepartment-grdBudgetDisplay"
                'Set the DataGridView properties to bind it to the data...
                frmDepartment.grdBudgetDisplay.DataSource = objDataSet
                frmDepartment.grdBudgetDisplay.DataMember = "dsDepartment"

                'Setup alternating rows style...
                frmDepartment.grdBudgetDisplay.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmDepartment.grdBudgetDisplay.Columns(0).Visible = False
                frmDepartment.grdBudgetDisplay.Columns(1).Visible = False
                frmDepartment.grdBudgetDisplay.Columns(2).Width = 80
                frmDepartment.grdBudgetDisplay.Columns(3).Width = 80
                frmDepartment.grdBudgetDisplay.Columns(4).Width = 50
                frmDepartment.grdBudgetDisplay.Columns(5).Width = 50
                frmDepartment.grdBudgetDisplay.Columns(6).Width = 50
                frmDepartment.grdBudgetDisplay.Columns(7).Width = 85
                frmDepartment.grdBudgetDisplay.Columns(8).Visible = False
                frmDepartment.grdBudgetDisplay.Columns(9).Width = 85

                'Setup column headers...
                frmDepartment.grdBudgetDisplay.Columns(2).HeaderText = "Budget #"
                frmDepartment.grdBudgetDisplay.Columns(3).HeaderText = "Rev Code"
                frmDepartment.grdBudgetDisplay.Columns(4).HeaderText = "Task"
                frmDepartment.grdBudgetDisplay.Columns(5).HeaderText = "Option"
                frmDepartment.grdBudgetDisplay.Columns(6).HeaderText = "Project"
                frmDepartment.grdBudgetDisplay.Columns(7).HeaderText = "Created By"
                frmDepartment.grdBudgetDisplay.Columns(9).HeaderText = "Created On"

            Case "frmDepartment-grdMerchant"
                'BOINGO
                'Set the DataGridView properties to bind it to the data...
                frmDepartment.grdMerchant.DataSource = objDataSet
                frmDepartment.grdMerchant.DataMember = "dsDepartment"

                'Setup alternating rows style...
                frmDepartment.grdMerchant.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmDepartment.grdMerchant.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmDepartment.grdMerchant.Columns(0).Visible = False
                frmDepartment.grdMerchant.Columns(1).Visible = False
                frmDepartment.grdMerchant.Columns(2).Width = 70
                ' frmDepartment.grdMerchant.Columns(3).Width = False
                frmDepartment.grdMerchant.Columns(3).Width = 80
                frmDepartment.grdMerchant.Columns(4).Width = 150
                frmDepartment.grdMerchant.Columns(5).Width = 80
                frmDepartment.grdMerchant.Columns(6).Visible = False
                frmDepartment.grdMerchant.Columns(7).Width = 35
                frmDepartment.grdMerchant.Columns(8).Width = 85
                frmDepartment.grdMerchant.Columns(9).Visible = False
                frmDepartment.grdMerchant.Columns(10).Width = 85
                frmDepartment.grdMerchant.Columns(11).Visible = False

                'Setup column headers...
                frmDepartment.grdMerchant.Columns(2).HeaderText = "Merchant #"
                ' frmDepartment.grdMerchant.Columns(3).HeaderText = "Merchant # Full"
                frmDepartment.grdMerchant.Columns(3).HeaderText = "Type"
                frmDepartment.grdMerchant.Columns(4).HeaderText = "Desc"
                frmDepartment.grdMerchant.Columns(5).HeaderText = "Contact"
                frmDepartment.grdMerchant.Columns(7).HeaderText = "Opt Out"
                frmDepartment.grdMerchant.Columns(8).HeaderText = "Created By"
                frmDepartment.grdMerchant.Columns(10).HeaderText = "Created On"
            Case "frmExport"
                'Set the DataGridView properties to bind it to the data...
                frmExport.grdDataList.DataSource = objDataSet
                frmExport.grdDataList.DataMember = "dsDepartment"
            Case "frmMerchants-Dept-cbo"
                frmMerchants.cboDepartment.DataSource = objDataSet.Tables(0)
                frmMerchants.cboDepartment.DisplayMember = "DeptName"
                frmMerchants.cboDepartment.ValueMember = "DeptID"
            Case "frmMerchants-Dept-cbo-Text"
                frmMerchants.cboDepartment.Text = objDataSet.Tables(0).Rows(0).Item("DeptName")
                
        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objDeptData = New clsDepartment
        'Call objDeptData.subDeptSelect(strBindTarget:="NONE", strAction:="SELECT", intDeptID:=0,strDeptName:="NONE", _
        'strBudgetNum:="NONE", strRevenueCode:="NONE", strTask:="NONE", strOption:="NONE", strProject:="NONE", _
        'intMerchantID:=0, intBudgetID:=0, strMerchantNum:="NONE",strMerchantType:="NONE", strMerchantDesc:="NONE", bitOptOut:="FALSE", _
        ' strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************

    End Sub

    '*** B. subDeptAction
    Public Sub subDeptAction(ByVal strAction As String, ByVal intDeptID As Integer, ByVal strDeptName As String, _
    ByVal strBudgetNum As String, ByVal strRevenueCode As String, ByVal strTask As String, ByVal strOption As String, _
    ByVal strProject As String, ByVal intBudgetID As Integer, ByVal intMerchantID As Integer, _
    ByVal strMerchantNum As String, ByVal strMerchantNumFull As String, ByVal strMerchantType As String, ByVal strMerchantDesc As String, _
    ByVal btOptOut As Boolean, ByVal strCreateUser As String, ByVal stCreateDate As Date, _
    ByVal strprocess_type As String, ByVal strprocess_type_desc As String, ByVal strterminal_status As String, ByVal strstatement_pref As String)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "[procDepartment]"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@DeptID", intDeptID)
        objCommand.Parameters.AddWithValue("@DeptName", strDeptName)
        objCommand.Parameters.AddWithValue("@BudgetNum", strBudgetNum)
        objCommand.Parameters.AddWithValue("@RevenueCode", strRevenueCode)
        objCommand.Parameters.AddWithValue("@Task", strTask)
        objCommand.Parameters.AddWithValue("@Option", strOption)
        objCommand.Parameters.AddWithValue("@Project", strProject)
        objCommand.Parameters.AddWithValue("@BudgetID", intBudgetID)
        objCommand.Parameters.AddWithValue("@MerchantID", intMerchantID)
        objCommand.Parameters.AddWithValue("@MerchantNum", strMerchantNum)
        objCommand.Parameters.AddWithValue("@MerchantNumFull", strMerchantNumFull)
        objCommand.Parameters.AddWithValue("@MerchantType", strMerchantType)
        objCommand.Parameters.AddWithValue("@MerchantDesc", strMerchantDesc)
        objCommand.Parameters.AddWithValue("@OptOut", btOptOut)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", stCreateDate)
        objCommand.Parameters.AddWithValue("@process_type", strprocess_type)
        objCommand.Parameters.AddWithValue("@process_type_desc", strprocess_type_desc)
        objCommand.Parameters.AddWithValue("@terminal_status", strterminal_status)
        objCommand.Parameters.AddWithValue("@statement_pref ", strstatement_pref)

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

    '*** C. fncGetMaxDeptID
    Public Function fncGetMaxDeptID() As Integer
        Dim intDeptID As Integer
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procDepartment"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", "MAX-DEPTID")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DeptID", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DeptName", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetNum", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RevenueCode", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Task", "X")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Option", "X")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Project", "X")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetID", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantID", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantNum", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantNumFull", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantType", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantDesc", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OptOut", False)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", "01/01/1900")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@process_type", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@process_type_desc", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@terminal_status", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@statement_pref ", "NONE")

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsGetDeptID")

        'Close the database connection...
        objConnection.Close()

        'Get the Export ID...
        If objDataSet.Tables("dsGetDeptID").Rows.Count = 0 Then
            'No match set intExportID to 0...
            intDeptID = 0
        Else
            intDeptID = objDataSet.Tables("dsGetDeptID").Rows(0).Item("MaxDeptID")
        End If

        Return intDeptID

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objGetDeptID= New clsDepartment
        'Call objGetDeptID.fncGetMaxDeptID()
        '***********************************************
        '***********************************************

    End Function

    '*** D. subAddDept
    Public Sub subAddDept()
        Dim strDeptName As String
        strDeptName = InputBox("Enter new department name:", "Add Department")

        If strDeptName <> Nothing Then

            subDeptAction(strAction:="ADD-DEPARTMENT", intDeptID:=0, strDeptName:=strDeptName, _
            strBudgetNum:="NONE", strRevenueCode:="NONE", strTask:="X", strOption:="X", strProject:="X", _
            intBudgetID:=0, intMerchantID:=0, strMerchantNum:="NONE", strMerchantType:="NONE", strMerchantNumFull:="NONE", strMerchantDesc:="NONE", btOptOut:="False", _
            strCreateUser:=SystemInformation.UserName, stCreateDate:="01/01/1900", strprocess_type:="NONE", strprocess_type_desc:="NONE", strterminal_status:="NONE", strstatement_pref:="NONE")

            frmMainMenu.txtActionID.Text = fncGetMaxDeptID()
            frmMainMenu.txtModule.Text = "DEPT-SEARCH"

            frmDepartment.MdiParent = frmMainMenu
            frmDepartment.Show()
            frmDepartment.Text = "Departments"
            frmDepartment.txtDeptID.Text = fncGetMaxDeptID()
            frmDepartment.txtDeptName.Text = strDeptName
            frmDepartment.btnExit.ForeColor = Color.Red
            frmDepartment.grpMerchants.Text = "Click budget in grid above to view merchant data."
            frmDepartment.grdBudgetDisplay.EditMode = DataGridViewEditMode.EditProgrammatically
            frmDepartment.grdMerchant.EditMode = DataGridViewEditMode.EditProgrammatically

            '***********************************************
            '******************* ACTION CODE ***************
            '***********************************************
            ' objAddDeptID= New clsDepartment
            'Call objAddDeptID.subAddDept()
            '***********************************************
            '***********************************************
        End If
    End Sub

    Public Sub subAddDeptNew()
        Dim strDeptName As String
        strDeptName = InputBox("Enter new department name:", "Add Department")

        If strDeptName <> Nothing Then
            subDeptAction(strAction:="ADD-DEPARTMENT", intDeptID:=0, strDeptName:=strDeptName, _
            strBudgetNum:="NONE", strRevenueCode:="NONE", strTask:="X", strOption:="X", strProject:="X", _
            intBudgetID:=0, intMerchantID:=0, strMerchantNum:="NONE", strMerchantType:="NONE", strMerchantNumFull:="NONE", strMerchantDesc:="NONE", btOptOut:="False", _
            strCreateUser:=SystemInformation.UserName, stCreateDate:="01/01/1900", strprocess_type:="NONE", strprocess_type_desc:="NONE", strterminal_status:="NONE", strstatement_pref:="NONE")

            frmMainMenu.txtActionID.Text = fncGetMaxDeptID()
        End If
    End Sub
End Class
