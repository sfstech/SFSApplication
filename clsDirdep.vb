Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subDirdepSelect
'*** B. subDirdepAction 
'*** C. fncGetDirdepBatchNumber
'****************************************
'****************************************

Public Class clsDirdep

    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subDirdepSelect
    Public Sub subDirdepSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, ByVal intTransactionCode As Integer, ByVal dtTransactionDate As Date, ByVal strDocumentNumber As String, ByVal strBankCode As String, ByVal strDepositNumber As String, ByVal strBudgetNumber As String, ByVal intAmount As Integer, ByVal strGLCode As String, ByVal strTask As String, ByVal strOption As String, ByVal strProject As String, ByVal strInvoiceNumber As String, ByVal strPayeeName As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date, ByVal strMercString As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim DS As System.Data.DataSet
        Dim objDataView As New DataView
        'Dim objCurrencyManager As New CurrencyManager


        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procDirectDeposit"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure


        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TransactionCode", intTransactionCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TransactionDate", dtTransactionDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DocumentNumber", strDocumentNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankCode", strBankCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DepositNumber", strDepositNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", intAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@GLCode", strGLCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Task", strTask)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Option", strOption)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Project", strProject)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@InvoiceNumber", strInvoiceNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PayeeName", strPayeeName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MercString", strMercString)




        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsDirdep")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch-Dirdep-Batch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsDirdep"

                'Setup form title...
                SearchMenu.Text = "Direct Deposit Data Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 100
                SearchMenu.grdDataList.Columns(1).Width = 50
                SearchMenu.grdDataList.Columns(2).Width = 100
                SearchMenu.grdDataList.Columns(3).Width = 100
                SearchMenu.grdDataList.Columns(4).Visible = False
                SearchMenu.grdDataList.Columns(5).Width = 100
                SearchMenu.grdDataList.Columns(6).Visible = False

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Date"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Batch #"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Total"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(5).HeaderText = "CT File"

                'Inialize and Bind to the correct from...

            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsDirdep"

                'Setup form title...
                SearchMenu.Text = "Direct Deposit Data Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 100
                SearchMenu.grdDataList.Columns(1).Width = 100
                SearchMenu.grdDataList.Columns(2).Width = 100

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Bank Date"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Imported By"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Imported On"


            Case "frmExport-Grid"

                'Set the DataGridView properties to bind it to the data...
                frmExport.grdDataList.DataSource = objDataSet
                frmExport.grdDataList.DataMember = "dsDirdep"


                'Setup alternating rows style...
                frmExport.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmExport.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmExport.grdDataList.Columns(0).Visible = False
                frmExport.grdDataList.Columns(1).Width = 25
                frmExport.grdDataList.Columns(2).Width = 75
                frmExport.grdDataList.Columns(3).Width = 25
                frmExport.grdDataList.Columns(4).Width = 60
                frmExport.grdDataList.Columns(5).Width = 60
                frmExport.grdDataList.Columns(6).Width = 60
                frmExport.grdDataList.Columns(7).Visible = False
                frmExport.grdDataList.Columns(8).Width = 50
                frmExport.grdDataList.Columns(9).Visible = False
                frmExport.grdDataList.Columns(10).Visible = False
                frmExport.grdDataList.Columns(11).Visible = False
                frmExport.grdDataList.Columns(12).Visible = False
                frmExport.grdDataList.Columns(13).Width = 250
                frmExport.grdDataList.Columns(14).Visible = False
                frmExport.grdDataList.Columns(15).Visible = False
                frmExport.grdDataList.Columns(16).Visible = False
                frmExport.grdDataList.Columns(17).Visible = False
                frmExport.grdDataList.Columns(18).Visible = False
                frmExport.grdDataList.Columns(19).Visible = False

                'Setup column headers...
                frmExport.grdDataList.Columns(1).HeaderText = "TC"
                frmExport.grdDataList.Columns(2).HeaderText = "Doc #"
                frmExport.grdDataList.Columns(3).HeaderText = "BC"
                frmExport.grdDataList.Columns(4).HeaderText = "Deposit #"
                frmExport.grdDataList.Columns(5).HeaderText = "Budget #"
                frmExport.grdDataList.Columns(6).HeaderText = "Amount"
                frmExport.grdDataList.Columns(8).HeaderText = "GL"
                frmExport.grdDataList.Columns(13).HeaderText = "Description"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objDirdepData = New clsDirdep
        'Call objDirdepData.subDirdepSelect(strBindTarget:="NONE", strAction:="SELECT", dtDirdepDate:="01/01/1900", strDirdepString:="NONE", 
        'intMerchantID:=0,intPersonID:=0, strCreateUser:="NONE")
        '***********************************************
        '***********************************************
    End Sub


    '*** B. subDirdepAction
    Public Sub subDirdepAction(ByVal strAction As String, ByVal intRowID As Integer, ByVal intTransactionCode As Integer, ByVal dtTransactionDate As Date, ByVal strDocumentNumber As String, ByVal strBankCode As String, ByVal strDepositNumber As String, ByVal strBudgetNumber As String, ByVal intAmount As Integer, ByVal strGLCode As String, ByVal strTask As String, ByVal strOption As String, ByVal strProject As String, ByVal strInvoiceNumber As String, ByVal strPayeeName As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date, ByVal strMercString As String)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procDirectDeposit"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@TransactionCode", intTransactionCode)
        objCommand.Parameters.AddWithValue("@TransactionDate", dtTransactionDate)
        objCommand.Parameters.AddWithValue("@DocumentNumber", strDocumentNumber)
        objCommand.Parameters.AddWithValue("@BankCode", strBankCode)
        objCommand.Parameters.AddWithValue("@DepositNumber", strDepositNumber)
        objCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objCommand.Parameters.AddWithValue("@Amount", intAmount)
        objCommand.Parameters.AddWithValue("@GLCode", strGLCode)
        objCommand.Parameters.AddWithValue("@Task", strTask)
        objCommand.Parameters.AddWithValue("@Option", strOption)
        objCommand.Parameters.AddWithValue("@Project", strProject)
        objCommand.Parameters.AddWithValue("@InvoiceNumber", strInvoiceNumber)
        objCommand.Parameters.AddWithValue("@PayeeName", strPayeeName)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objCommand.Parameters.AddWithValue("@MercString", strMercString)



        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objDirdepAction = New clsDirdep
        'Call objDirdepAction.subDirdepAction(strAction:="CREATE-FAS-EXPORT", dtDirdepDate:="01/01/1900", strDirdepString:="NONE", intMerchantID:=0, intPersonID:=0,  strCreateUser:="NONE")
        '***********************************************
        '***********************************************
    End Sub
End Class
