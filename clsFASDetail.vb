Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subFASDetailSelect
'*** B. subFASDetailAction
'****************************************
'****************************************

Public Class clsFASDetail
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subFASDetailSelect
    Public Sub subFASDetailSelect(ByVal strAction As String, ByVal strBindTarget As String, ByVal strBankCode As String, ByVal intAcctMonth As Integer, ByVal intBiennium As Integer, ByVal intPostDate As Integer, ByVal intTransDate As Integer, ByVal strBudget As String, ByVal strRevCode As String, ByVal strFund As String, ByVal strRef1 As String, ByVal strRef2 As String, ByVal strRef3 As String, ByVal strDescr As String, ByVal dblCredit As Double, ByVal dblDebit As Double, ByVal strERGOSource As String, ByVal strImportFileName As String, ByVal strImportUser As String, ByVal strImportDate As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager
        Dim dblCurrency As Double
        Dim strCurrency As String

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procERGO_FASDetail"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankCode", strBankCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AcctMonth", intAcctMonth)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Biennium", intBiennium)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PostDate", intPostDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TransDate", intTransDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget", strBudget)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RevCode", strRevCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Fund", strFund)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Ref1", strRef1)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Ref2", strRef2)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Ref3", strRef3)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Descr", strDescr)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Credit", dblCredit)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Debit", dblDebit)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ERGOSource", strERGOSource)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportDate", strImportDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsFASDetail")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmFasDetail-cboBankCode"
                frmFASDetail.cboBankCode.DataSource = objDataSet.Tables("dsFASDetail")
                frmFASDetail.cboBankCode.DisplayMember = "BankCode"
                frmFASDetail.cboBankCode.ValueMember = "BankCode"
            Case "frmFasDetail-cboAcctMonth"
                frmFASDetail.cboAcctMonth.DataSource = objDataSet.Tables("dsFASDetail")
                frmFASDetail.cboAcctMonth.DisplayMember = "AcctMonth"
                frmFASDetail.cboAcctMonth.ValueMember = "AcctMonth"
            Case "frmFasDetail-cboBiennium"
                frmFASDetail.cboBiennium.DataSource = objDataSet.Tables("dsFASDetail")
                frmFASDetail.cboBiennium.DisplayMember = "Biennium"
                frmFASDetail.cboBiennium.ValueMember = "Biennium"
            Case "frmFasDetail-Totals"
                frmFASDetail.txtCredits.Text = ""
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsFASDetail")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsFASDetail"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmExport.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmFASDetail.txtCredits.DataBindings.Clear()
                frmFASDetail.txtDebits.DataBindings.Clear()
                frmFASDetail.txtTotal.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmFASDetail.txtCredits.DataBindings.Add("text", objDataView, Format("{0:c}", "Credits"))
                'Format as currency
                Dim strT As String = frmFASDetail.txtCredits.Text
                dblCurrency = frmFASDetail.txtCredits.Text
                strCurrency = String.Format("{0:c}", dblCurrency)
                frmFASDetail.txtCredits.Text = strCurrency

                frmFASDetail.txtDebits.DataBindings.Add("text", objDataView, "Debits")
                'Format as currency
                dblCurrency = frmFASDetail.txtDebits.Text
                strCurrency = String.Format("{0:c}", dblCurrency)
                frmFASDetail.txtDebits.Text = strCurrency

                frmFASDetail.txtTotal.DataBindings.Add("text", objDataView, "Total")
                'Format as currency
                dblCurrency = frmFASDetail.txtTotal.Text
                strCurrency = String.Format("{0:c}", dblCurrency)
                frmFASDetail.txtTotal.Text = strCurrency

            Case "frmFASDetail"
                'Set the DataGridView properties to bind it to the data...
                frmFASDetail.grdDataList.DataSource = objDataSet
                frmFASDetail.grdDataList.DataMember = "dsFASDetail"

                'Setup form title...
                frmFASDetail.Text = "FAS Search"

                'Setup alternating rows style...
                frmFASDetail.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmFASDetail.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objFASDetail= New clsFASDetail
        'Call objFASDetail.subFASDetailSelect(strAction:="NONE", strBindTarget:="NONE", strBankCode:="NONE",  _
        'intAcctMonth:=0, intBiennium:=0, intPostDate:=0, intTransDate :=0, strBudget:="NONE", strRevCode:="NONE",  _
        'strFund:="NONE", strRef1:="NONE", strRef2:="NONE", strRef3:="NONE", strDescr:="NONE", dblCredit:=0,  _
        'dblDebit:=0, strERGOSource:="NONE", strImportFileName:="NONE", strImportUser:="NONE", strImportDate:="NONE")
        '***********************************************
        '***********************************************
    End Sub
End Class
