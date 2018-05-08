Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subARCExternalSelect
'*** B. subARCExternalAction
'*** C. subARCInternalSelect
'*** D. subARCInternalAction
'****************************************
'****************************************


    Public Class clsARC

    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subARCExternalSelect
    Public Sub subARCExternalSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal strBatchID As String, ByVal strTransmissionDepositID As String, ByVal strBankNumber As String, ByVal strAccountNum As String, ByVal strCheckNumber As String, ByVal dblAmount As Double, ByVal strTransactionType As String, ByVal dtRecdDate As Date, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim DS As System.Data.DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procARCExternal"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BatchID", strBatchID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TransmissionDepositID", strTransmissionDepositID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankNumber", strBankNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AccountNum", strAccountNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CheckNumber", strCheckNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TransactionType", strTransactionType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RecdDate", dtRecdDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsARCExternal")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmARCVer"
                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsARCExternal"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmARCVer.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmARCVer.lstExternal.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmARCVer.lstExternal.DataSource = objDataSet.Tables("dsARCExternal")
                frmARCVer.lstExternal.DisplayMember = "Display"

            Case "frmSearch-All"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsARCExternal"

                'Setup form title...
                SearchMenu.Text = "Select US Bank Data"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 230
                SearchMenu.grdDataList.Columns(1).Width = 68
                SearchMenu.grdDataList.Columns(2).Width = 58
                SearchMenu.grdDataList.Columns(3).Width = 58
                SearchMenu.grdDataList.Columns(4).Width = 58
                SearchMenu.grdDataList.Columns(5).Width = 68

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Transmission Deposit ID"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Rec'd Date"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Count"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Imported By"
                SearchMenu.grdDataList.Columns(5).HeaderText = "Import Date"

            Case "frmBankData"
                'Set the DataGridView properties to bind it to the data...
                frmBankData.DataGridView1.DataSource = objDataSet
                frmBankData.DataGridView1.DataMember = "dsARCExternal"

                'Setup form title...
                frmBankData.Text = "US Bank ARC Data"
                frmBankData.lblAsOf.Text = "Bank Date:"

                'Setup alternating rows style...
                frmBankData.DataGridView1.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmBankData.DataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmBankData.DataGridView1.Columns(0).Visible = False
                frmBankData.DataGridView1.Columns(1).Width = 230
                frmBankData.DataGridView1.Columns(2).Width = 65
                frmBankData.DataGridView1.Columns(3).Width = 100
                frmBankData.DataGridView1.Columns(4).Width = 65
                frmBankData.DataGridView1.Columns(5).Width = 65
                frmBankData.DataGridView1.Columns(6).Width = 65
                frmBankData.DataGridView1.Columns(7).Width = 65
                frmBankData.DataGridView1.Columns(8).Width = 50
                frmBankData.DataGridView1.Columns(9).Width = 65
                frmBankData.DataGridView1.Columns(10).Width = 65

                'Setup column headers...
                frmBankData.DataGridView1.Columns(1).HeaderText = "Transmission Deposit ID"
                frmBankData.DataGridView1.Columns(2).HeaderText = "Bank Number"
                frmBankData.DataGridView1.Columns(3).HeaderText = "Account Number"
                frmBankData.DataGridView1.Columns(4).HeaderText = "Check Number"
                frmBankData.DataGridView1.Columns(5).HeaderText = "Amount"
                frmBankData.DataGridView1.Columns(6).HeaderText = "Transaction Type"
                frmBankData.DataGridView1.Columns(7).HeaderText = "Rec'd Date"
                frmBankData.DataGridView1.Columns(8).HeaderText = "Verified"
                frmBankData.DataGridView1.Columns(9).HeaderText = "Imported By"
                frmBankData.DataGridView1.Columns(10).HeaderText = "Import Date"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objARCExternalData = New clsARC
        'Call objARCExternalData.subARCExternalSelect(strBindTarget:="NONE", strAction:="SELECT", _
        'strBatchID:="NONE", strTransmissionDepositID:="NONE", strBankNumber:="NONE", strAccountNum:="NONE", strCheckNumber:="NONE",  _
        'dblAmount:=0.00, strTransactionType:="NONE", dtRecdDate:="01/01/1900", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subARCExternalAction
    Public Sub subARCExternalAction(ByVal strBindTarget As String, ByVal strAction As String, _
            ByVal strBatchID As String, ByVal strTransmissionDepositID As String, _
            ByVal strBankNumber As String, ByVal strAccountNum As String, _
            ByVal strCheckNumber As String, ByVal dblAmount As Double, _
            ByVal strTransactionType As String, ByVal dtRecdDate As Date, _
            ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procARCExternal"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@BatchID", strBatchID)
        objCommand.Parameters.AddWithValue("@TransmissionDepositID", strTransmissionDepositID)
        objCommand.Parameters.AddWithValue("@BankNumber", strBankNumber)
        objCommand.Parameters.AddWithValue("@AccountNum", strAccountNum)
        objCommand.Parameters.AddWithValue("@CheckNumber", strCheckNumber)
        objCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objCommand.Parameters.AddWithValue("@TransactionType", strTransactionType)
        objCommand.Parameters.AddWithValue("@RecdDate", dtRecdDate)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objARCExternalAction = New clsARC
        'Call objARCExternalAction.subARCExternalAction(strBindTarget:="NONE", strAction:="VERIFY", _
        'strBatchID:="NONE", strTransmissionDepositID:="NONE", strBankNumber:="NONE", strAccountNum:="NONE", strCheckNumber:="NONE",  _
        'dblAmount:=0.00, strTransactionType:="NONE", dtRecdDate:="01/01/1900", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub


    '*** C. subARCInternalSelect
    Public Sub subARCInternalSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal strBatchID As String, ByVal strBankNumber As String, ByVal strAccountNum As String, ByVal strCheckNumber As String, ByVal dblAmount As Double, ByVal strTransactionType As String, ByVal dtCaptureTime As Date, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim DS As System.Data.DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procARCInternal"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BatchID", strBatchID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankNumber", strBankNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AccountNum", strAccountNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CheckNumber", strCheckNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TransactionType", strTransactionType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CaptureTime", dtCaptureTime)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsARCInternal")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmARCVer"
                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsARCInternal"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmARCVer.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmARCVer.lstInternal.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmARCVer.lstInternal.DataSource = objDataSet.Tables("dsARCInternal")
                frmARCVer.lstInternal.DisplayMember = "Display"

            Case "frmSearch-All"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsARCInternal"

                'Setup form title...
                SearchMenu.Text = "Select ACH Terminal Data"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 230
                SearchMenu.grdDataList.Columns(1).Width = 68
                SearchMenu.grdDataList.Columns(2).Width = 58
                SearchMenu.grdDataList.Columns(3).Width = 58
                SearchMenu.grdDataList.Columns(4).Width = 58
                SearchMenu.grdDataList.Columns(5).Width = 68

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Batch ID"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Capture Date"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Count"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Imported By"
                SearchMenu.grdDataList.Columns(5).HeaderText = "Import Date"

            Case "frmBankData"
                'Set the DataGridView properties to bind it to the data...
                frmBankData.DataGridView1.DataSource = objDataSet
                frmBankData.DataGridView1.DataMember = "dsARCInternal"

                'Setup form title...
                frmBankData.Text = "US Bank ARC Data"
                frmBankData.lblAsOf.Text = "Batch Date:"

                'Setup alternating rows style...
                frmBankData.DataGridView1.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmBankData.DataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmBankData.DataGridView1.Columns(0).Visible = False
                frmBankData.DataGridView1.Columns(1).Width = 230
                frmBankData.DataGridView1.Columns(2).Width = 65
                frmBankData.DataGridView1.Columns(3).Width = 100
                frmBankData.DataGridView1.Columns(4).Width = 50
                frmBankData.DataGridView1.Columns(5).Width = 65
                frmBankData.DataGridView1.Columns(6).Width = 65
                frmBankData.DataGridView1.Columns(7).Width = 120
                frmBankData.DataGridView1.Columns(8).Width = 50
                frmBankData.DataGridView1.Columns(9).Width = 60
                frmBankData.DataGridView1.Columns(10).Width = 65


                'Setup column headers...
                frmBankData.DataGridView1.Columns(1).HeaderText = "Batch ID"
                frmBankData.DataGridView1.Columns(2).HeaderText = "Bank Number"
                frmBankData.DataGridView1.Columns(3).HeaderText = "Account Number"
                frmBankData.DataGridView1.Columns(4).HeaderText = "Check Number"
                frmBankData.DataGridView1.Columns(5).HeaderText = "Amount"
                frmBankData.DataGridView1.Columns(6).HeaderText = "Transaction Type"
                frmBankData.DataGridView1.Columns(7).HeaderText = "Capture Date/Time"
                frmBankData.DataGridView1.Columns(8).HeaderText = "Verified"
                frmBankData.DataGridView1.Columns(9).HeaderText = "Imported By"
                frmBankData.DataGridView1.Columns(10).HeaderText = "Import Date"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objARCInternalData = New clsARC
        'Call objARCExternalData.subARCInternalSelect(strBindTarget:="NONE", strAction:="SELECT", _
        'strBatchID:="NONE", strBankNumber:="NONE", strAccountNum:="NONE", strCheckNumber:="NONE",  _
        'dblAmount:=0.00, strTransactionType:="NONE", dtCaptureTime:="01/01/1900", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub
    End Class
