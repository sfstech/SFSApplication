'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subBudgetAccessSelect
'*** B. subBudgetAccessAction
'****************************************
'****************************************
Public Class clsSDB_BudgetAccess
    Dim objConnection As New SqlConnection _
       (frmMainMenu.strSFSCon)


    '*** A. subBudgetAccessSelect
    Public Sub subBudgetAccessSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, ByVal strRequesterSDBLogin As String, _
                ByVal strRequestorName As String, ByVal strRequesterEmail As String, ByVal strSupervisorName As String, ByVal strSupervisorEmail As String, _
                ByVal strDirectorName As String, ByVal strDirectorEmail As String, ByVal strBudget1 As String, ByVal strBudget2 As String, _
                ByVal strBudget3 As String, ByVal strBudget4 As String, ByVal strBudget5 As String, ByVal strBudget6 As String, _
                ByVal strBudget7 As String, ByVal strBudget8 As String, ByVal strBudget9 As String, ByVal strBudget10 As String, _
                ByVal strSDBAdminUser As String, ByVal dtSDBAdminDate As Date, ByVal strImportUser As String, ByVal dtImportDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procSDB_BudgetAccess"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequesterSDBLogin ", strRequesterSDBLogin)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequestorName", strRequestorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequesterEmail", strRequesterEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SupervisorName", strSupervisorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SupervisorEmail", strSupervisorEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DirectorName", strDirectorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DirectorEmail", strDirectorEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget1", strBudget1)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget2", strBudget2)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget3", strBudget3)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget4", strBudget4)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget5", strBudget5)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget6", strBudget6)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget7", strBudget7)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget8", strBudget8)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget9", strBudget9)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget10", strBudget10)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBAdminUser", strSDBAdminUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBAdminDate", dtSDBAdminDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportDate", dtImportDate)
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsBudgetAccess")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsBudgetAccess"

                'Setup form title...
                SearchMenu.Text = "BudgetAccess Data Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).Width = 80
                SearchMenu.grdDataList.Columns(2).Width = 80
                SearchMenu.grdDataList.Columns(3).Width = 120
                SearchMenu.grdDataList.Columns(4).Width = 80
                SearchMenu.grdDataList.Columns(5).Width = 120
                SearchMenu.grdDataList.Columns(6).Width = 80
                SearchMenu.grdDataList.Columns(7).Width = 120
                SearchMenu.grdDataList.Columns(1).HeaderText = "SDB Login"
                SearchMenu.grdDataList.Columns(2).HeaderText = "User"
                SearchMenu.grdDataList.Columns(3).HeaderText = "User Email"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Supervisor"
                SearchMenu.grdDataList.Columns(5).HeaderText = "Supervisor Email"
                SearchMenu.grdDataList.Columns(6).HeaderText = "Director"
                SearchMenu.grdDataList.Columns(7).HeaderText = "Director Email"
                SearchMenu.grdDataList.Columns(8).HeaderText = "Budget1"
                SearchMenu.grdDataList.Columns(9).HeaderText = "Budget2"
                SearchMenu.grdDataList.Columns(10).HeaderText = "Budget3"
                SearchMenu.grdDataList.Columns(11).HeaderText = "Budget4"
                SearchMenu.grdDataList.Columns(12).HeaderText = "Budget5"
                SearchMenu.grdDataList.Columns(13).HeaderText = "Budget6"
                SearchMenu.grdDataList.Columns(14).HeaderText = "Budget7"
                SearchMenu.grdDataList.Columns(15).HeaderText = "Budget8"
                SearchMenu.grdDataList.Columns(16).HeaderText = "Budget9"
                SearchMenu.grdDataList.Columns(17).HeaderText = "Budget10"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        ''objBudgetAccessData = New clsSDB_BudgetAccess
        'Call objBudgetAccessData.subBudgetAccessSelect(strBindTarget:="frmSearch", strAction:="SELECT-SDB-BUD-NOT-APP", intRowID:=0, strRequesterSDBLogin:="", _
        '                strRequestorName:="", strRequesterEmail:="", strSupervisorName:="", strSupervisorEmail:="", _
        '                strDirectorName:="", strDirectorEmail:="", strBudget1:="", strBudget2:="", _
        '                strBudget3:="", strBudget4:="", strBudget5:="", strBudget6:="", _
        '                strBudget7:="", strBudget8:="", strBudget9:="", strBudget10:="", _
        '                strSDBAdminUser:="", dtSDBAdminDate:="01/01/1900", strImportUser:="", dtImportDate:="01/01/1900")
        '***********************************************
        '***********************************************


    End Sub


    '*** B. subBudgetAccessAction
    Public Sub subBudgetAccessAction(ByVal strAction As String, ByVal intRowID As Integer, ByVal strRequesterSDBLogin As String, _
                ByVal strRequestorName As String, ByVal strRequesterEmail As String, ByVal strSupervisorName As String, ByVal strSupervisorEmail As String, _
                ByVal strDirectorName As String, ByVal strDirectorEmail As String, ByVal strBudget1 As String, ByVal strBudget2 As String, _
                ByVal strBudget3 As String, ByVal strBudget4 As String, ByVal strBudget5 As String, ByVal strBudget6 As String, _
                ByVal strBudget7 As String, ByVal strBudget8 As String, ByVal strBudget9 As String, ByVal strBudget10 As String, _
                ByVal strSDBAdminUser As String, ByVal dtSDBAdminDate As Date, ByVal strImportUser As String, ByVal dtImportDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procSDB_BudgetAccess"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@RequesterSDBLogin ", strRequesterSDBLogin)
        objCommand.Parameters.AddWithValue("@RequestorName", strRequestorName)
        objCommand.Parameters.AddWithValue("@RequesterEmail", strRequesterEmail)
        objCommand.Parameters.AddWithValue("@SupervisorName", strSupervisorName)
        objCommand.Parameters.AddWithValue("@SupervisorEmail", strSupervisorEmail)
        objCommand.Parameters.AddWithValue("@DirectorName", strDirectorName)
        objCommand.Parameters.AddWithValue("@DirectorEmail", strDirectorEmail)
        objCommand.Parameters.AddWithValue("@Budget1", strBudget1)
        objCommand.Parameters.AddWithValue("@Budget2", strBudget2)
        objCommand.Parameters.AddWithValue("@Budget3", strBudget3)
        objCommand.Parameters.AddWithValue("@Budget4", strBudget4)
        objCommand.Parameters.AddWithValue("@Budget5", strBudget5)
        objCommand.Parameters.AddWithValue("@Budget6", strBudget6)
        objCommand.Parameters.AddWithValue("@Budget7", strBudget7)
        objCommand.Parameters.AddWithValue("@Budget8", strBudget8)
        objCommand.Parameters.AddWithValue("@Budget9", strBudget9)
        objCommand.Parameters.AddWithValue("@Budget10", strBudget10)
        objCommand.Parameters.AddWithValue("@SDBAdminUser", strSDBAdminUser)
        objCommand.Parameters.AddWithValue("@SDBAdminDate", dtSDBAdminDate)
        objCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objCommand.Parameters.AddWithValue("@ImportDate", dtImportDate)

        'Create a SqlParameter object to hold the RETURN value, set the direction to ReturnValue and add to parameters
        'Dim retValParam As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        'retValParam.Direction = ParameterDirection.ReturnValue
        'objCommand.Parameters.Add(retValParam)

        Cursor.Current = Cursors.WaitCursor
        '   objCommand.CommandTimeout = 600
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'frmImport.intStoredProcRet = Convert.ToInt32(retValParam.Value)

        'Close the database connection...
        objConnection.Close()

        Cursor.Current = Cursors.Arrow

        ''***********************************************
        ''******************* ACTION CODE ***************
        ''***********************************************
        'objBudgetAccessAction = New clsSDB_BudgetAccess
        'Call objBudgetAccessAction.subBudgetAccessAction(strAction:="UPDATE-SDB-BUD-APPROVED", intRowID:=CInt(frmMainMenu.txtActionID.Text), strRequesterSDBLogin:="", _
        '        strRequestorName:="", strRequesterEmail:="", strSupervisorName:="", strSupervisorEmail:="", _
        '        strDirectorName:="", strDirectorEmail:="", strBudget1:="", strBudget2:="", _
        '        strBudget3:="", strBudget4:="", strBudget5:="", strBudget6:="", _
        '        strBudget7:="", strBudget8:="", strBudget9:="", strBudget10:="", _
        '        strSDBAdminUser:=SystemInformation.UserName, dtSDBAdminDate:=System.DateTime.Now, strImportUser:="", dtImportDate:="01/01/1900")
        '    '***********************************************
        '    '***********************************************

    End Sub

End Class
