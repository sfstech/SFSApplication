'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subSDBAccessLogSelect
'*** B. subSDBAccessLogAction
'****************************************
'****************************************

Public Class clsSDB_Access_Log

    Dim objConnection As New SqlConnection _
       (frmMainMenu.strSFSCon)


    '*** A. subSDBAccessLogSelect
    Public Sub subSDBAccessLogSelect(ByVal strAction As String, ByVal strBindTarget As String, ByVal intRowID As Integer, ByVal dtRequestDate As Date, ByVal strRequestorSDBLogin As String, _
                ByVal strRequestorName As String, ByVal strRequestorEmail As String, ByVal strSupervisorName As String, ByVal strSupervisorEmail As String, _
                ByVal strDirectorName As String, ByVal strAdditionalNeeds As String, _
                ByVal strSDBAdminUser As String, ByVal dtSDBAdminDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procSDB_Access_Log"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequestDate", dtRequestDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequestorSDBLogin ", strRequestorSDBLogin)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequestorName", strRequestorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequestorEmail", strRequestorEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SupervisorName", strSupervisorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SupervisorEmail", strSupervisorEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DirectorName", strDirectorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AdditionalNeeds", strAdditionalNeeds)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBAdminUser", strSDBAdminUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBAdminDate", dtSDBAdminDate)
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsSDBAccess")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsSDBAccess"

                'Setup form title...
                frmSearch.Text = "SDB User Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Width = 80
                frmSearch.grdDataList.Columns(2).Width = 100
                frmSearch.grdDataList.Columns(3).Width = 120
                frmSearch.grdDataList.Columns(4).Visible = False
                frmSearch.grdDataList.Columns(5).Visible = False
                frmSearch.grdDataList.Columns(6).Visible = False
                frmSearch.grdDataList.Columns(7).Visible = False
                frmSearch.grdDataList.Columns(8).Visible = False
                frmSearch.grdDataList.Columns(9).Width = 100
                frmSearch.grdDataList.Columns(10).Width = 120
                frmSearch.grdDataList.Columns(1).HeaderText = "Request Date"
                frmSearch.grdDataList.Columns(2).HeaderText = "SDB Login"
                frmSearch.grdDataList.Columns(2).HeaderText = "Name"
                frmSearch.grdDataList.Columns(9).HeaderText = "Created By"
                frmSearch.grdDataList.Columns(10).HeaderText = "Created On"
         
        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        ''objSDBAccessData = New clsSDB_Access_Log
        'Call objSDBAccessData.subSDBAccessLogSelect(strBindTarget:="frmSearch", strAction:="SEARCH-ALL", intRowID:=CInt(frmMainMenu.txtActionID.Text), dtRequestDate:="01/01/1900", strRequestorSDBLogin:="", _
        '        strRequestorName:="", strRequestorEmail:="", strSupervisorName:="", strSupervisorEmail:="", _
        '        strDirectorName:="", strAdditionalNeeds:="",
        '        strSDBAdminUser:=SystemInformation.UserName, dtSDBAdminDate:=System.DateTime.Now)
        '***********************************************
        '***********************************************


    End Sub


    '*** B. subSDBAccessLogAction
    Public Sub subSDBAccessLogAction(ByVal strAction As String, ByVal intRowID As Integer, ByVal dtRequestDate As Date, ByVal strRequestorSDBLogin As String, _
                ByVal strRequestorName As String, ByVal strRequestorEmail As String, ByVal strSupervisorName As String, ByVal strSupervisorEmail As String, _
                ByVal strDirectorName As String, ByVal strAdditionalNeeds As String, _
                ByVal strSDBAdminUser As String, ByVal dtSDBAdminDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procSDB_Access_Log"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@RequestDate", dtRequestDate)
        objCommand.Parameters.AddWithValue("@RequestorSDBLogin ", strRequestorSDBLogin)
        objCommand.Parameters.AddWithValue("@RequestorName", strRequestorName)
        objCommand.Parameters.AddWithValue("@RequestorEmail", strRequestorEmail)
        objCommand.Parameters.AddWithValue("@SupervisorName", strSupervisorName)
        objCommand.Parameters.AddWithValue("@SupervisorEmail", strSupervisorEmail)
        objCommand.Parameters.AddWithValue("@DirectorName", strDirectorName)
        objCommand.Parameters.AddWithValue("@AdditionalNeeds", strAdditionalNeeds)
        objCommand.Parameters.AddWithValue("@SDBAdminUser", strSDBAdminUser)
        objCommand.Parameters.AddWithValue("@SDBAdminDate", dtSDBAdminDate)

        Cursor.Current = Cursors.WaitCursor
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()


        'Close the database connection...
        objConnection.Close()

        Cursor.Current = Cursors.Arrow

        ''***********************************************
        ''******************* ACTION CODE ***************
        ''***********************************************
        'objSDBAccessLogAction = New clsSDB_Access_Log
        'Call objSDBAccessLogAction.subSDBAccessLogAction(strAction:="UPDATE-SDB-BUD-APPROVED", intRowID:=CInt(frmMainMenu.txtActionID.Text), dtRequestDate:="01/01/1900", strRequestorSDBLogin:="", _
        '        strRequestorName:="", strRequestorEmail:="", strSupervisorName:="", strSupervisorEmail:="", _
        '        strDirectorName:="",  strAdditionalNeeds:="",
        '        strSDBAdminUser:=SystemInformation.UserName, dtSDBAdminDate:=System.DateTime.Now)
        '    '***********************************************
        '    '***********************************************

    End Sub

End Class
