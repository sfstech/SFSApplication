'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subChargeCodeSelect
'*** B. subChargeCodeAction
'****************************************
'****************************************
Public Class clsSDB_ChargeCode
    Dim objConnection As New SqlConnection _
       (frmMainMenu.strSFSCon)


    '*** A. subChargeCodeSelect
    Public Sub subChargeCodeSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, ByVal strRequestorNetID As String, _
                ByVal strRequestorName As String, ByVal strRequestorEmail As String, ByVal strSupervisorName As String, ByVal strSupervisorEmail As String, _
                ByVal strDirectorName As String, ByVal strDirectorEmail As String, ByVal strChargeCode As String, ByVal strChargeCodeName As String, _
                ByVal strChargeCodeAbbrev As String, ByVal dblMaxAmount As Double, ByVal dblAmount As Double, ByVal strBudget As String, _
                ByVal strContactName As String, ByVal strContactBox As String, ByVal strContactPhone As String, ByVal strContactEmail As String, _
                ByVal strComment As String, ByVal strSDBAdminUser As String, ByVal dtSDBAdminDate As Date, ByVal strImportUser As String, ByVal dtImportDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procSDB_ChargeCode"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequestorNetID ", strRequestorNetID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequestorName", strRequestorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RequestorEmail", strRequestorEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SupervisorName", strSupervisorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SupervisorEmail", strSupervisorEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DirectorName", strDirectorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DirectorEmail", strDirectorEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCode", strChargeCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCodeName", strChargeCodeName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ChargeCodeAbbrev", strChargeCodeAbbrev)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MaxAmount", dblMaxAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget", strBudget)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ContactName", strContactName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ContactBox", strContactBox)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ContactPhone", strContactPhone)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ContactEmail", strContactEmail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Comment", strComment)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBAdminUser", strSDBAdminUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBAdminDate", dtSDBAdminDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportDate", dtImportDate)
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsChargeCode")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsChargeCode"

                'Setup form title...
                frmSearch.Text = "ChargeCode Data Search"

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
                frmSearch.grdDataList.Columns(1).HeaderText = "NetID Login"
                frmSearch.grdDataList.Columns(2).HeaderText = "User"
                frmSearch.grdDataList.Columns(3).HeaderText = "User Email"
                frmSearch.grdDataList.Columns(4).HeaderText = "Supervisor"
                frmSearch.grdDataList.Columns(5).HeaderText = "Supervisor Email"
                frmSearch.grdDataList.Columns(6).HeaderText = "Director"
                frmSearch.grdDataList.Columns(7).HeaderText = "Director Email"
                frmSearch.grdDataList.Columns(8).HeaderText = "ChargeCode"
                frmSearch.grdDataList.Columns(9).HeaderText = "ChargeCodeName"
                frmSearch.grdDataList.Columns(10).HeaderText = "ChargeCodeAbbrev"
                frmSearch.grdDataList.Columns(11).HeaderText = "MaxAmount"
                frmSearch.grdDataList.Columns(12).HeaderText = "Amount"
                frmSearch.grdDataList.Columns(13).HeaderText = "Budget"
                frmSearch.grdDataList.Columns(14).HeaderText = "Contact Name"
                frmSearch.grdDataList.Columns(15).HeaderText = "ContactBox"
                frmSearch.grdDataList.Columns(16).HeaderText = "ContactPhone"
                frmSearch.grdDataList.Columns(17).HeaderText = "ContactEmail"
                frmSearch.grdDataList.Columns(18).HeaderText = "Comment"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        ''objChargeCodeData = New clsSDB_ChargeCode
        'Call objChargeCodeData.subChargeCodeSelect(strBindTarget:="frmSearch", strAction:="SELECT-SDB-BUD-NOT-APP", intRowID:=0, strRequesterSDBLogin:="", _
        '                strRequestorName:="", strRequesterEmail:="", strSupervisorName:="", strSupervisorEmail:="", _
        '                strDirectorName:="", strDirectorEmail:="", strChargeCode1:="", strChargeCode2:="", _
        '                strChargeCode3:="", strChargeCode4:="", strChargeCode5:="", strChargeCode6:="", _
        '                strChargeCode7:="", strChargeCode8:="", strChargeCode9:="", strChargeCode10:="", _
        '                strSDBAdminUser:="", dtSDBAdminDate:="01/01/1900", strImportUser:="", dtImportDate:="01/01/1900")
        '***********************************************
        '***********************************************


    End Sub


    '*** B. subChargeCodeAction
    Public Sub subChargeCodeAction(ByVal strAction As String, ByVal intRowID As Integer, ByVal strRequestorNetID As String, _
                ByVal strRequestorName As String, ByVal strRequestorEmail As String, ByVal strSupervisorName As String, ByVal strSupervisorEmail As String, _
                ByVal strDirectorName As String, ByVal strDirectorEmail As String, ByVal strChargeCode As String, ByVal strChargeCodeName As String, _
                ByVal strChargeCodeAbbrev As String, ByVal dblMaxAmount As Double, ByVal dblAmount As Double, ByVal strBudget As String, _
                ByVal strContactName As String, ByVal strContactBox As String, ByVal strContactPhone As String, ByVal strContactEmail As String, _
                ByVal strComment As String, ByVal strSDBAdminUser As String, ByVal dtSDBAdminDate As Date, ByVal strImportUser As String, ByVal dtImportDate As Date)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procSDB_ChargeCode"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@RequestorNetID ", strRequestorNetID)
        objCommand.Parameters.AddWithValue("@RequestorName", strRequestorName)
        objCommand.Parameters.AddWithValue("@RequestorEmail", strRequestorEmail)
        objCommand.Parameters.AddWithValue("@SupervisorName", strSupervisorName)
        objCommand.Parameters.AddWithValue("@SupervisorEmail", strSupervisorEmail)
        objCommand.Parameters.AddWithValue("@DirectorName", strDirectorName)
        objCommand.Parameters.AddWithValue("@DirectorEmail", strDirectorEmail)
        objCommand.Parameters.AddWithValue("@ChargeCode", strChargeCode)
        objCommand.Parameters.AddWithValue("@ChargeCodeName", strChargeCodeName)
        objCommand.Parameters.AddWithValue("@ChargeCodeAbbrev", strChargeCodeAbbrev)
        objCommand.Parameters.AddWithValue("@MaxAmount", dblMaxAmount)
        objCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objCommand.Parameters.AddWithValue("@Budget", strBudget)
        objCommand.Parameters.AddWithValue("@ContactName", strContactName)
        objCommand.Parameters.AddWithValue("@ContactBox", strContactBox)
        objCommand.Parameters.AddWithValue("@ContactPhone", strContactPhone)
        objCommand.Parameters.AddWithValue("@ContactEmail", strContactEmail)
        objCommand.Parameters.AddWithValue("@Comment", strComment)
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
        'objChargeCodeAction = New clsSDB_ChargeCode
        'Call objChargeCodeAction.subChargeCodeAction(strAction:="UPDATE-SDB-BUD-APPROVED", intRowID:=CInt(frmMainMenu.txtActionID.Text), strRequesterSDBLogin:="", _
        '        strRequestorName:="", strRequesterEmail:="", strSupervisorName:="", strSupervisorEmail:="", _
        '        strDirectorName:="", strDirectorEmail:="", strChargeCode1:="", strChargeCode2:="", _
        '        strChargeCode3:="", strChargeCode4:="", strChargeCode5:="", strChargeCode6:="", _
        '        strChargeCode7:="", strChargeCode8:="", strChargeCode9:="", strChargeCode10:="", _
        '        strSDBAdminUser:=SystemInformation.UserName, dtSDBAdminDate:=System.DateTime.Now, strImportUser:="", dtImportDate:="01/01/1900")
        '    '***********************************************
        '    '***********************************************

    End Sub

End Class