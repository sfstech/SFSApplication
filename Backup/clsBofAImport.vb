Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subBofAImportSelect
'*** B. subBofAImportAction
'****************************************
'****************************************
' Note: BofAImportDetail table access is through this class

Public Class clsBofAImport
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subBofAImportSelect
    Public Sub subBofAImportSelect(ByVal strAction As String, ByVal strBindTarget As String, ByVal dtAsOf As Date, ByVal strCurrency As String, ByVal strBankIDType As String, ByVal intAccount As Integer, ByVal strDataType As String, ByVal strBAICode As String, ByVal strDescription As String, ByVal dblAmount As Double, ByVal strImmediateAvail As String, ByVal strOneDayFloat As String, ByVal strTwoPlusDayFloat As String, ByVal strBankReference As String, ByVal strCustomerReference As String, ByVal strText As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procBofAImport"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AsOf", dtAsOf)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Currency", strCurrency)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankIDType", strBankIDType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Account", intAccount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DataType", strDataType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BAICode", strBAICode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Description", strDescription)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImmediateAvail", strImmediateAvail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OneDayFloat", strOneDayFloat)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TwoPlusDayFloat", strTwoPlusDayFloat)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankReference", strBankReference)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerReference", strCustomerReference)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Text", strText)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsBofAImportData")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsBofAImportData"

                'Setup form title...
                frmSearch.Text = "Bank of America Data Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objBofAImport = New clsBofAImport
        'Call objBofAImport.subBofAImportSelect(strAction:="SELECT-ALL-BY-AMOUNT", strBindTarget:="frmBankData", _
        'dtAsOf:="01/01/1900", strCurrency:="NONE",strBankIDType:="NONE", intAccount:"62045000",strDataType:="NONE", _
        'strBAICode:="NONE", strDescription:="NONE", dblAmount:=0, strImmediateAvail :="NONE",strOneDayFloat:="NONE", _
        'strTwoPlusDayFloat:="NONE", strBankReference:="NONE", strCustomerReference:="NONE", strText :="NONE",strCreateUser:="NONE", dtCreateDate:="01/01/1900"
        '***********************************************
        '***********************************************
    End Sub

    Public Sub subBofAAction(ByVal strAction As String, ByVal dtAsOf As Date, ByVal strCurrency As String, _
                             ByVal strBankIDType As String, ByVal intAccount As Integer, ByVal strDataType As String, ByVal strBAICode As String, ByVal strDescription As String, _
                             ByVal dblAmount As Double, ByVal strImmediateAvail As String, ByVal strOneDayFloat As String, ByVal strTwoPlusDayFloat As String, ByVal strBankReference As String, _
                             ByVal strCustomerReference As String, ByVal strText As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procBofAImport"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@AsOf", dtAsOf)
        objCommand.Parameters.AddWithValue("@Currency", strCurrency)
        objCommand.Parameters.AddWithValue("@BankIDType", strBankIDType)
        objCommand.Parameters.AddWithValue("@Account", intAccount)
        objCommand.Parameters.AddWithValue("@DataType", strDataType)
        objCommand.Parameters.AddWithValue("@BAICode", strBAICode)
        objCommand.Parameters.AddWithValue("@Description", strDescription)
        objCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objCommand.Parameters.AddWithValue("@ImmediateAvail", strImmediateAvail)
        objCommand.Parameters.AddWithValue("@OneDayFloat", strOneDayFloat)
        objCommand.Parameters.AddWithValue("@TwoPlusDayFloat", strTwoPlusDayFloat)
        objCommand.Parameters.AddWithValue("@BankReference", strBankReference)
        objCommand.Parameters.AddWithValue("@CustomerReference", strCustomerReference)
        objCommand.Parameters.AddWithValue("@Text", strText)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Create a SqlParameter object to hold the RETURN value, set the direction to ReturnValue and add to parameters
        Dim retValParam As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        retValParam.Direction = ParameterDirection.ReturnValue
        objCommand.Parameters.Add(retValParam)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        frmImport.intStoredProcRet = Convert.ToInt32(retValParam.Value)

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objBofAImport = New clsBofAImport
        'Call objBofAImport.subBofAImportSelect(strAction:="ADD-BOFA-DETAIL",  _
        'dtAsOf:="01/01/1900", strCurrency:="NONE",strBankIDType:="NONE", intAccount:"62045000",strDataType:="NONE", _
        'strBAICode:="NONE", strDescription:="NONE", dblAmount:=0, strImmediateAvail :="NONE",strOneDayFloat:="NONE", _
        'strTwoPlusDayFloat:="NONE", strBankReference:="NONE", strCustomerReference:="NONE", strText :="NONE",strCreateUser:="NONE", dtCreateDate:="01/01/1900"
        '***********************************************
        '***********************************************

    End Sub
End Class
