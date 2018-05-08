'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subChargeCodeAccessSelect
'*** B. subChargeCodeAccessAction
'****************************************
'****************************************
Public Class clsSDB_ChargeCodeAccess
    Dim objConnection As New SqlConnection _
       (frmMainMenu.strSFSCon)


    '*** A. subChargeCodeAccessSelect
    Public Sub subChargeCodeAccessSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, ByVal strRequesterSDBLogin As String, _
                ByVal strRequestorName As String, ByVal strRequesterEmail As String, ByVal strSupervisorName As String, ByVal strSupervisorEmail As String, _
                ByVal strDirectorName As String, ByVal strDirectorEmail As String, ByVal strChargeCode1 As String, ByVal strChargeCode2 As String, _
                ByVal strChargeCode3 As String, ByVal strChargeCode4 As String, ByVal strChargeCode5 As String, ByVal strChargeCode6 As String, _
                ByVal strChargeCode7 As String, ByVal strChargeCode8 As String, ByVal strChargeCode9 As String, ByVal strChargeCode10 As String, _
                ByVal strSDBAdminUser As String, ByVal dtSDBAdminDate As Date, ByVal strImportUser As String, ByVal dtImportDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procSDB_ChargeCodeAccess"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequestorSDBLogin ", strRequesterSDBLogin)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequestorName", strRequestorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequestorEmail", strRequesterEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SupervisorName", strSupervisorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SupervisorEmail", strSupervisorEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DirectorName", strDirectorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DirectorEmail", strDirectorEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCode1", strChargeCode1)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCode2", strChargeCode2)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCode3", strChargeCode3)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCode4", strChargeCode4)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCode5", strChargeCode5)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCode6", strChargeCode6)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCode7", strChargeCode7)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCode8", strChargeCode8)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCode9", strChargeCode9)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCode10", strChargeCode10)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBAdminUser", strSDBAdminUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBAdminDate", dtSDBAdminDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportDate", dtImportDate)
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsChargeCodeAccess")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsChargeCodeAccess"

                'Setup form title...
                frmSearch.Text = "ChargeCodeAccess Data Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Width = 80
                frmSearch.grdDataList.Columns(2).Width = 80
                frmSearch.grdDataList.Columns(3).Width = 120
                frmSearch.grdDataList.Columns(4).Width = 80
                frmSearch.grdDataList.Columns(5).Width = 120
                frmSearch.grdDataList.Columns(6).Width = 80
                frmSearch.grdDataList.Columns(7).Width = 120
                frmSearch.grdDataList.Columns(1).HeaderText = "SDB Login"
                frmSearch.grdDataList.Columns(2).HeaderText = "User"
                frmSearch.grdDataList.Columns(3).HeaderText = "User Email"
                frmSearch.grdDataList.Columns(4).HeaderText = "Supervisor"
                frmSearch.grdDataList.Columns(5).HeaderText = "Supervisor Email"
                frmSearch.grdDataList.Columns(6).HeaderText = "Director"
                frmSearch.grdDataList.Columns(7).HeaderText = "Director Email"
                frmSearch.grdDataList.Columns(8).HeaderText = "ChargeCode1"
                frmSearch.grdDataList.Columns(9).HeaderText = "ChargeCode2"
                frmSearch.grdDataList.Columns(10).HeaderText = "ChargeCode3"
                frmSearch.grdDataList.Columns(11).HeaderText = "ChargeCode4"
                frmSearch.grdDataList.Columns(12).HeaderText = "ChargeCode5"
                frmSearch.grdDataList.Columns(13).HeaderText = "ChargeCode6"
                frmSearch.grdDataList.Columns(14).HeaderText = "ChargeCode7"
                frmSearch.grdDataList.Columns(15).HeaderText = "ChargeCode8"
                frmSearch.grdDataList.Columns(16).HeaderText = "ChargeCode9"
                frmSearch.grdDataList.Columns(17).HeaderText = "ChargeCode10"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        ''objChargeCodeAccessData = New clsSDB_ChargeCodeAccess
        'Call objChargeCodeAccessData.subChargeCodeAccessSelect(strBindTarget:="frmSearch", strAction:="SELECT-SDB-BUD-NOT-APP", intRowID:=0, strRequesterSDBLogin:="", _
        '                strRequestorName:="", strRequesterEmail:="", strSupervisorName:="", strSupervisorEmail:="", _
        '                strDirectorName:="", strDirectorEmail:="", strChargeCode1:="", strChargeCode2:="", _
        '                strChargeCode3:="", strChargeCode4:="", strChargeCode5:="", strChargeCode6:="", _
        '                strChargeCode7:="", strChargeCode8:="", strChargeCode9:="", strChargeCode10:="", _
        '                strSDBAdminUser:="", dtSDBAdminDate:="01/01/1900", strImportUser:="", dtImportDate:="01/01/1900")
        '***********************************************
        '***********************************************


    End Sub


    '*** B. subChargeCodeAccessAction
    Public Sub subChargeCodeAccessAction(ByVal strAction As String, ByVal intRowID As Integer, ByVal strRequesterSDBLogin As String, _
                ByVal strRequestorName As String, ByVal strRequesterEmail As String, ByVal strSupervisorName As String, ByVal strSupervisorEmail As String, _
                ByVal strDirectorName As String, ByVal strDirectorEmail As String, ByVal strChargeCode1 As String, ByVal strChargeCode2 As String, _
                ByVal strChargeCode3 As String, ByVal strChargeCode4 As String, ByVal strChargeCode5 As String, ByVal strChargeCode6 As String, _
                ByVal strChargeCode7 As String, ByVal strChargeCode8 As String, ByVal strChargeCode9 As String, ByVal strChargeCode10 As String, _
                ByVal strSDBAdminUser As String, ByVal dtSDBAdminDate As Date, ByVal strImportUser As String, ByVal dtImportDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procSDB_ChargeCodeAccess"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@RequestorSDBLogin ", strRequesterSDBLogin)
        objCommand.Parameters.AddWithValue("@RequestorName", strRequestorName)
        objCommand.Parameters.AddWithValue("@RequestorEmail", strRequesterEmail)
        objCommand.Parameters.AddWithValue("@SupervisorName", strSupervisorName)
        objCommand.Parameters.AddWithValue("@SupervisorEmail", strSupervisorEmail)
        objCommand.Parameters.AddWithValue("@DirectorName", strDirectorName)
        objCommand.Parameters.AddWithValue("@DirectorEmail", strDirectorEmail)
        objCommand.Parameters.AddWithValue("@ChargeCode1", strChargeCode1)
        objCommand.Parameters.AddWithValue("@ChargeCode2", strChargeCode2)
        objCommand.Parameters.AddWithValue("@ChargeCode3", strChargeCode3)
        objCommand.Parameters.AddWithValue("@ChargeCode4", strChargeCode4)
        objCommand.Parameters.AddWithValue("@ChargeCode5", strChargeCode5)
        objCommand.Parameters.AddWithValue("@ChargeCode6", strChargeCode6)
        objCommand.Parameters.AddWithValue("@ChargeCode7", strChargeCode7)
        objCommand.Parameters.AddWithValue("@ChargeCode8", strChargeCode8)
        objCommand.Parameters.AddWithValue("@ChargeCode9", strChargeCode9)
        objCommand.Parameters.AddWithValue("@ChargeCode10", strChargeCode10)
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
        'objChargeCodeAccessAction = New clsSDB_ChargeCodeAccess
        'Call objChargeCodeAccessAction.subChargeCodeAccessAction(strAction:="UPDATE-SDB-BUD-APPROVED", intRowID:=CInt(frmMainMenu.txtActionID.Text), strRequesterSDBLogin:="", _
        '        strRequestorName:="", strRequesterEmail:="", strSupervisorName:="", strSupervisorEmail:="", _
        '        strDirectorName:="", strDirectorEmail:="", strChargeCode1:="", strChargeCode2:="", _
        '        strChargeCode3:="", strChargeCode4:="", strChargeCode5:="", strChargeCode6:="", _
        '        strChargeCode7:="", strChargeCode8:="", strChargeCode9:="", strChargeCode10:="", _
        '        strSDBAdminUser:=SystemInformation.UserName, dtSDBAdminDate:=System.DateTime.Now, strImportUser:="", dtImportDate:="01/01/1900")
        '    '***********************************************
        '    '***********************************************

    End Sub

End Class