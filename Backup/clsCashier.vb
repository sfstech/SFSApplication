'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subCashierSelect
'*** B. subCashierAction
'****************************************
'****************************************

Public Class clsCashier
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)


    '*** A. subCashierSelect
    Public Sub subCashierSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intCashierTranID As Integer, _
                ByVal dtTranDate As Date, ByVal strDepositSlip As String, ByVal strBagNumber As String, _
                ByVal strCashierUserName As String, _
                ByVal strCreateUser As String, ByVal dtCreateDate As Date, _
                ByVal strApproveUser As String, ByVal dtApproveDate As Date, _
                ByVal strFASVerifyUser As String, ByVal dtFASVerifyDate As Date, ByVal strSubmittedFlag As Boolean)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procCashier"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CashierTranID ", intCashierTranID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranDate", dtTranDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DepositSlip", strDepositSlip)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BagNumber", strBagNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CashierUserName", strCashierUserName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ApproveUser", strApproveUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ApproveDate", dtApproveDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FASVerifyUser", strFASVerifyUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FASVerifyDate", dtFASVerifyDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ckSubmitted", strSubmittedFlag)
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsCashier")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsCashier"

                'Setup form title...
                frmSearch.Text = "Cashier Data Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Width = 80
                frmSearch.grdDataList.Columns(2).Width = 80
                frmSearch.grdDataList.Columns(3).Width = 80
                frmSearch.grdDataList.Columns(4).Width = 80
                frmSearch.grdDataList.Columns(5).Width = 120

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objCashierData = New clsCashier
        'Call objCashierData.subCashierSelect(strBindTarget:="frmSearch", strAction:="SELECT-ALL", _
        'intCashierTranID:=0, dtTranDate:="01/01/1900", strDepositSlip:="NONE", _
        'strBagNumber:="NONE", strCashierUserName:="NONE", strCreateUser:="NONE", _
        'dtCreateDate:="01/01/1900", strApproveUser:="NONE", dtApproveDate:="01/01/1900", _
        'strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", bitCashOnHand:=0)
        '***********************************************
        '***********************************************

    End Sub


    '*** B. subCashierAction
    Public Sub subCashierAction(ByVal strAction As String, ByVal intCashierTranID As Integer, _
                ByVal dtTranDate As Date, ByVal strDepositSlip As String, ByVal strBagNumber As String, _
                ByVal strCashierUserName As String, _
                ByVal strCreateUser As String, ByVal dtCreateDate As Date, _
                ByVal strApproveUser As String, ByVal dtApproveDate As Date, _
                ByVal strFASVerifyUser As String, ByVal dtFASVerifyDate As Date, ByVal strSubmittedFlag As Boolean)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procCashier"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@CashierTranID ", intCashierTranID)
        objCommand.Parameters.AddWithValue("@TranDate", dtTranDate)
        objCommand.Parameters.AddWithValue("@DepositSlip", strDepositSlip)
        objCommand.Parameters.AddWithValue("@BagNumber", strBagNumber)
        objCommand.Parameters.AddWithValue("@CashierUserName", strCashierUserName)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objCommand.Parameters.AddWithValue("@ApproveUser", strApproveUser)
        objCommand.Parameters.AddWithValue("@ApproveDate", dtApproveDate)
        objCommand.Parameters.AddWithValue("@FASVerifyUser", strFASVerifyUser)
        objCommand.Parameters.AddWithValue("@FASVerifyDate", dtFASVerifyDate)
        objCommand.Parameters.AddWithValue("@ckSubmitted", strSubmittedFlag)

        'Create a SqlParameter object to hold the RETURN value, set the direction to ReturnValue and add to parameters
        Dim retValParam As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        retValParam.Direction = ParameterDirection.ReturnValue
        objCommand.Parameters.Add(retValParam)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        frmCashierActivity.intRetCashierRecNbr = Convert.ToInt32(retValParam.Value)

        'Close the database connection...
        objConnection.Close()

        '    '***********************************************
        '    '******************* ACTION CODE ***************
        '    '***********************************************
        'objCashierData = New clsCashier
        'Call objCashierData.subCashierAction(strBindTarget:="frmSearch", strAction:="SELECT-ALL", _
        'intCashierTranID:=0, dtTranDate:="01/01/1900", strDepositSlip:="NONE", _
        'strBagNumber:="NONE", strCashierUserName:="NONE", strCreateUser:="NONE", _
        'dtCreateDate:="01/01/1900", strApproveUser:="NONE", dtApproveDate:="01/01/1900", _
        'strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", bitCashOnHand:=0, strSubmittedFlag: ="")
        '    '***********************************************
        '    '***********************************************

    End Sub
    
End Class