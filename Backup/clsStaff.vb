'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subStaffSelect
'*** B. subStaffAction
'****************************************
'****************************************

Public Class clsStaff
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subStaffSelect
    Public Sub subStaffSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intStaffID As Integer, _
    ByVal intPersonID As Integer, ByVal strArea As String, ByVal strPosition As String, ByVal strHours As String, _
    ByVal strStatus As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procStaff"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure


        'Set the paramaters...
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StaffID", intStaffID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PersonID", intPersonID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Area", strArea)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Position", strPosition)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hours", strHours)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Status", strStatus)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsStaff")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsStaff"

                'Setup form title...
                frmSearch.Text = "Staff Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Visible = False
                frmSearch.grdDataList.Columns(2).Width = 100
                frmSearch.grdDataList.Columns(3).Width = 100
                frmSearch.grdDataList.Columns(4).Visible = False
                frmSearch.grdDataList.Columns(5).Width = 150
                frmSearch.grdDataList.Columns(6).Width = 180
                frmSearch.grdDataList.Columns(7).Width = 180
                frmSearch.grdDataList.Columns(8).Visible = False
                frmSearch.grdDataList.Columns(9).Visible = False

                'Setup column headers...
                frmSearch.grdDataList.Columns(2).HeaderText = "Last Name"
                frmSearch.grdDataList.Columns(3).HeaderText = "First Name"
                frmSearch.grdDataList.Columns(5).HeaderText = "Area"
                frmSearch.grdDataList.Columns(6).HeaderText = "Position"
                frmSearch.grdDataList.Columns(7).HeaderText = "Hours"

            Case "frmStaff"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....

                objDataAdapter.Fill(objDataSet, "dsStaff")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsStaff"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmStaff.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmStaff.txtStaffID.DataBindings.Clear()
                frmStaff.cboArea.DataBindings.Clear()
                frmStaff.txtPosition.DataBindings.Clear()
                frmStaff.txtHours.DataBindings.Clear()
                frmStaff.cboStatus.DataBindings.Clear()
                frmStaff.txtCreateUser.DataBindings.Clear()
                frmStaff.txtCreateDate.DataBindings.Clear()


                'Add new bindings to the DataView object...
                frmStaff.txtStaffID.Visible = True
                frmStaff.txtStaffID.DataBindings.Add("text", objDataView, "StaffID")
                frmStaff.txtStaffID.Visible = False
                frmStaff.cboArea.DataBindings.Add("text", objDataView, "Area")
                frmStaff.txtPosition.DataBindings.Add("text", objDataView, "Position")
                frmStaff.txtHours.DataBindings.Add("text", objDataView, "Hours")
                frmStaff.cboStatus.DataBindings.Add("text", objDataView, "Status")
                frmStaff.txtCreateUser.DataBindings.Add("text", objDataView, "CreateUser")
                frmStaff.txtCreateDate.DataBindings.Add("text", objDataView, "CreateDate")

            Case "frmProcReview"
                Dim dt As DataTable = objDataSet.Tables("dsStaff")
                frmProcReview.lboStaffNames.DataSource = dt ' objDataSet.Tables("dsProc")
                frmProcReview.lboStaffNames.DisplayMember = "StaffName"
                '    frmProcReview.lboStaffNames.ValueMember = "StaffName"
                frmProcReview.lboStaffNames.DataBindings.Add("text", dt, "StaffName")
                '  TextBox1.DataBindings.Add("text", dt, "FirstName")
            Case "frmProcedure-Updt-cb"
                Dim dtu As DataTable = objDataSet.Tables("dsStaff")
                frmProcedure.cboUpdated.DataSource = dtu ' objDataSet.Tables("dsProc")
                frmProcedure.cboUpdated.DisplayMember = "StaffName"
                frmProcedure.cboUpdated.ValueMember = "StaffID"
            Case "frmProcedure-Test-cb"
                Dim dtt As DataTable = objDataSet.Tables("dsStaff")
                frmProcedure.cboTested.DataSource = dtt ' objDataSet.Tables("dsProc")
                frmProcedure.cboTested.DisplayMember = "StaffName"
                frmProcedure.cboTested.ValueMember = "StaffID"
            Case "frmProcedure-App-cb"
                Dim dta As DataTable = objDataSet.Tables("dsStaff")
                frmProcedure.cboApproved.DataSource = dta ' objDataSet.Tables("dsProc")
                frmProcedure.cboApproved.DisplayMember = "StaffName"
                frmProcedure.cboApproved.ValueMember = "StaffID"

            Case "frmProcedure-CkName-cb"
                Dim dtc As DataTable = objDataSet.Tables("dsStaff")
                frmProcedure.cboCheckNames.DataSource = dtc ' objDataSet.Tables("dsProc")
                frmProcedure.cboCheckNames.DisplayMember = "StaffName"
                frmProcedure.cboCheckNames.ValueMember = "StaffID"


                'frmProcedure.cboStaffID.DataSource = dt ' objDataSet.Tables("dsProc")
                'frmProcedure.cboStaffID.DisplayMember = "StaffID"
                'frmProcedure.cboStaffID.ValueMember = "StaffID"
                '    frmProcReview.lboStaffNames.ValueMember = "StaffName"
                'frmProcedure.cboApproved.DataBindings.Add("text", dt, "StaffName")
                '  TextBox1.DataBindings.Add("text", dt, "FirstName")

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objStaffData = New clsStaff
        'Call objStaffData.subStaffSelect(strBindTarget:="frmSearch", strAction:="SEARCH-ALL", _
        'intStaffID:=0, intPersonID:=0,strArea:="NONE",strPosition:="NONE", strHours:="NONE" _
        'strStatus:="A",strCreateUser:=SystemInformation.UserName,dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subStaffAction
    Public Sub subStaffAction(ByVal strAction As String, ByVal intStaffID As Integer, _
    ByVal intPersonID As Integer, ByVal strArea As String, ByVal strPosition As String, ByVal strHours As String, _
    ByVal strStatus As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procStaff"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@StaffID", intStaffID)
        objCommand.Parameters.AddWithValue("@PersonID", intPersonID)
        objCommand.Parameters.AddWithValue("@Area", strArea)
        objCommand.Parameters.AddWithValue("@Position", strPosition)
        objCommand.Parameters.AddWithValue("@Hours", strHours)
        objCommand.Parameters.AddWithValue("@Status", strStatus)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objStaffAction = New clsStaff
        'Call objStaffAction.subStaffAction(strAction:="UPDATE", intStaffID:=0, intPersonID:=0, _
        '    strArea:="NONE", strPosition:="NONE", strHours:="NONE", strStatus:="A", strCreateUser:=SystemInformation.UserName, dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

End Class
