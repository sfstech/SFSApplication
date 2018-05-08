Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subStaffActivitySelect
'*** B. subStaffActivityAction
'****************************************
'****************************************


Public Class clsStaffActivity
    Dim objConnection As New SqlConnection _
(frmMainMenu.strSFSCon)

    '*** A. subStaffActititySelect
    Public Sub subStaffActivitySelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, ByVal strUnit As String, ByVal strRequestor As String, ByVal strAssignee As String, ByVal strDescription As String, ByVal dtStartDate As Date, ByVal dtStopDate As Date, ByVal strType As String, ByVal strPriority As String, ByVal strStatus As String, ByVal strReferral As String, ByVal strNotes As String, ByVal strContactMethod As String, ByVal strCreatedBy As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Dim DS As System.Data.DataSet


        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procStaffActivity"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Unit", strUnit)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Requestor", strRequestor)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Assignee", strAssignee)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Description", strDescription)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StartDate", dtStartDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StopDate", dtStopDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Type", strType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Priority", strPriority)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Status", strStatus)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Referral", strReferral)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Notes", strNotes)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ContactMethod", strContactMethod)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreatedBy", strCreatedBy)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)



        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsStaffActivity")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmStaffActivity"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....

                objDataAdapter.Fill(objDataSet, "dsStaffActivity")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsStaffActivity"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmStaffActivity.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmStaffActivity.cboUnit.DataBindings.Clear()
                frmStaffActivity.cboRequestor.DataBindings.Clear()
                frmStaffActivity.cboAssignee.DataBindings.Clear()
                frmStaffActivity.dtStartDate.DataBindings.Clear()
                frmStaffActivity.dtStopDate.DataBindings.Clear()
                frmStaffActivity.txtDescription.DataBindings.Clear()
                frmStaffActivity.cboType.DataBindings.Clear()
                frmStaffActivity.cboContactMethod.DataBindings.Clear()
                frmStaffActivity.cboPriority.DataBindings.Clear()
                frmStaffActivity.cboStatus.DataBindings.Clear()
                frmStaffActivity.txtReferral.DataBindings.Clear()
                frmStaffActivity.txtNotes.DataBindings.Clear()
                frmStaffActivity.txtCreatedBy.DataBindings.Clear()
                frmStaffActivity.dtCreateDate.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmStaffActivity.cboUnit.DataBindings.Add("text", objDataView, "Unit")
                frmStaffActivity.cboRequestor.DataBindings.Add("text", objDataView, "Requestor")
                frmStaffActivity.cboAssignee.DataBindings.Add("text", objDataView, "Assignee")
                frmStaffActivity.dtStartDate.DataBindings.Add("text", objDataView, "StartDate")
                frmStaffActivity.dtStopDate.DataBindings.Add("text", objDataView, "StopDate")
                frmStaffActivity.txtDescription.DataBindings.Add("text", objDataView, "Description")
                frmStaffActivity.cboType.DataBindings.Add("text", objDataView, "Type")
                frmStaffActivity.cboContactMethod.DataBindings.Add("text", objDataView, "ContactMethod")
                frmStaffActivity.cboPriority.DataBindings.Add("text", objDataView, "Priority")
                frmStaffActivity.cboStatus.DataBindings.Add("text", objDataView, "Status")
                frmStaffActivity.txtReferral.DataBindings.Add("text", objDataView, "Referral")
                frmStaffActivity.txtNotes.DataBindings.Add("text", objDataView, "Notes")
                frmStaffActivity.txtCreatedBy.DataBindings.Add("text", objDataView, "CreatedBy")
                frmStaffActivity.dtCreateDate.DataBindings.Add("text", objDataView, "CreateDate")










            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsStaffActivity"

                'Setup form title...
                SearchMenu.Text = "Staff Activity Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).Width = 65
                SearchMenu.grdDataList.Columns(2).Width = 65
                SearchMenu.grdDataList.Columns(3).Width = 75
                SearchMenu.grdDataList.Columns(4).Width = 75
                SearchMenu.grdDataList.Columns(5).Visible = False
                SearchMenu.grdDataList.Columns(6).Visible = False
                SearchMenu.grdDataList.Columns(7).Width = 75
                SearchMenu.grdDataList.Columns(8).Width = 75
                SearchMenu.grdDataList.Columns(9).Width = 75
                SearchMenu.grdDataList.Columns(10).Visible = False
                SearchMenu.grdDataList.Columns(11).Visible = False
                SearchMenu.grdDataList.Columns(12).Visible = False
                SearchMenu.grdDataList.Columns(13).Visible = False
                SearchMenu.grdDataList.Columns(14).Visible = False




                'Setup column headers...
                SearchMenu.grdDataList.Columns(1).HeaderText = "Unit"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Requestor"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Assignee"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Desc"
                SearchMenu.grdDataList.Columns(7).HeaderText = "Type"
                SearchMenu.grdDataList.Columns(9).HeaderText = "Status"




        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objStaffActivity = New clsStaffActivity
        'Call objStaffActivity.subStaffActvity(strBindTarget:="NONE", strAction:="NONE", strGroup:="NONE",	strRequestor:="NONE", strAssignee:="NONE", strDesc:="NONE",  dtStartDate:="01/01/1900", dtStopDate:="01/01/1900", strType:="NONE",	strPriority:="NONE", strStatus:="NONE",	strReferral:="NONE", strNotes:="NONE", strContactMethod:="NONE", strCreatedBy:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub


    '*** B. subRStaffActivityAction
    Public Sub subStaffActivityAction(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, ByVal strUnit As String, ByVal strRequestor As String, ByVal strAssignee As String, ByVal strDescription As String, ByVal dtStartDate As Date, ByVal dtStopDate As Date, ByVal strType As String, ByVal strPriority As String, ByVal strStatus As String, ByVal strReferral As String, ByVal strNotes As String, ByVal strContactMethod As String, ByVal strCreatedBy As String, ByVal dtCreateDate As Date)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procStaffActivity"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@Unit", strUnit)
        objCommand.Parameters.AddWithValue("@Requestor", strRequestor)
        objCommand.Parameters.AddWithValue("@Assignee", strAssignee)
        objCommand.Parameters.AddWithValue("@Description", strDescription)
        objCommand.Parameters.AddWithValue("@StartDate", dtStartDate)
        objCommand.Parameters.AddWithValue("@StopDate", dtStopDate)
        objCommand.Parameters.AddWithValue("@Type", strType)
        objCommand.Parameters.AddWithValue("@Priority", strPriority)
        objCommand.Parameters.AddWithValue("@Status", strStatus)
        objCommand.Parameters.AddWithValue("@Referral", strReferral)
        objCommand.Parameters.AddWithValue("@Notes", strNotes)
        objCommand.Parameters.AddWithValue("@ContactMethod", strContactMethod)
        objCommand.Parameters.AddWithValue("@CreatedBy", strCreatedBy)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '        '***********************************************
        '        '******************* ACTION CODE ***************
        '        '***********************************************
        '        ' objStaffActivityAction = New clsStaffActivity
        '        'Call objStaffActivityAction.subStaffActivityAction(strAction:="DELETE-tblELM_IMPORT", intSSN:=0, intStudent_no:=0, dtElmDate:="01/01/1900",intBatchNum:=0, strElmString:="NONE", strCreateUser:="NONE")
        '        '***********************************************
        '        '***********************************************
    End Sub

End Class
