Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subUSBImportSelect
'*** B. subUSBImportAction
'****************************************
'****************************************

Public Class clsUSBImport

    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subUSBImportSelect
    Public Sub subUSBImportSelect(ByVal strAction As String, ByVal strBindTarget As String, ByVal intRowID As Integer, ByVal strAcctName As String, ByVal strBankNbr As String, ByVal strTranDesc As String, ByVal strBDCR As String, ByVal dblAmount As Double, ByVal strAcctNbr As String, ByVal dtLedgerDate As Date, ByVal strCustRef As String, ByVal strTranType As String, ByVal strCcy As String, ByVal strBankName As String, ByVal strValueDate As String, ByVal strNarrative As String, ByVal strImportFileName As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procUSBankImport"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AcctName", strAcctName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankNbr", strBankNbr)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranDesc", strTranDesc)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BDCR", strBDCR)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AcctNbr", strAcctNbr)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@LedgerDate", dtLedgerDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CustRef", strCustRef)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranType", strTranType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Ccy", strCcy)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankName", strBankName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ValueDate", strValueDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Narrative", strNarrative)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsUSBImportData")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsUSBImportData"

                'Setup form title...
                SearchMenu.Text = "US Bank Data Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objUSBImport = New clsUSBImport
        'Call objUSBImport.subUSBImportSelect(strAction:="USB-SELECT-ALL-BY-AMOUNT", strBindTarget:="frmSearch", _
        'intRowID:=0, strAcctName:=frmMainMenu.txtActionID.Text, strBankNbr:="0",strTranDesc:="NONE", strBDCR:="NONE", dblAmount:="NONE", _
        'strAcctNbr:="NONE", dtLedgerDate:="01/01/1900", strCustRef:="NONE", strTranType:="NONE", strCcy:="NONE", strBankName:="NONE", _
        'strValueDate:="NONE", strNarrative:="NONE", strImportFileName:="NONE", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

End Class
