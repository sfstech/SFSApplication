
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subVendorExpressSelect
'*** B. subVendorExpressAction
'****************************************
'****************************************



Public Class clsVendorExpress
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '    '*** A. subVendorExpressSelect
    Public Sub subVendorExpressSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, ByVal dtAsOf As Date, ByVal strCurrency As String, ByVal strBankIDType As String, ByVal intBankID As Integer, ByVal strBankIDDesc As String, ByVal intAccount As Integer, ByVal strAccountDesc As String, ByVal strRowType As String, ByVal strDataType As String, ByVal intBAICode As Integer, ByVal strDescription As String, ByVal intAmount As Double, _
                                      ByVal dtBalanceValueDate As Date, ByVal strCustomerReference As String, ByVal strBankReference As String, ByVal strCreditImmedAvail As String, ByVal strOneDayFloat As String, ByVal strTwoPlusDayFloat As String, ByVal intItemCount As Integer, ByVal strText As String, ByVal strAssignedTo As String, ByVal strAssignedToSub As String, ByVal strAssignedUser As String, ByVal dtAssignedDate As Date, ByVal strAssignedNotes As String, ByVal strCTNumber As String, ByVal dtCTDate As Date, ByVal intCTAmount As Integer, _
                                      ByVal strImportFileName As String, ByVal intBofA_Import_Link As Integer, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager




        Dim DS As System.Data.DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procVendorExpress"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AsOf", dtAsOf)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Currency", strCurrency)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankIDType", strBankIDType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankID", intBankID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankIDDesc", strBankIDDesc)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Account", intAccount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AccountDesc", strAccountDesc)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowType", strRowType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DataType", strDataType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BAICode", intBAICode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Description", strDescription)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", intAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BalanceValueDate", dtBalanceValueDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerReference", strCustomerReference)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankReference", strBankReference)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreditImmedAvail", strCreditImmedAvail)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OneDayFloat", strOneDayFloat)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TwoPlusDayFloat", strTwoPlusDayFloat)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ItemCount", intItemCount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Text", strText)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AssignedTo", strAssignedTo)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AssignedToSub", strAssignedToSub)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AssignedUser", strAssignedUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AssignedDate", dtAssignedDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AssignedNotes", strAssignedNotes)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CTNumber", strCTNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CTDate", dtCTDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CTAmount", intCTAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BofA_Import_Link", intBofA_Import_Link)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsVendorExpress")

        'Close the database connection...
        objConnection.Close()

        Select Case strBindTarget
            Case "frmVendorExpress"
                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsVendorExpress"))
                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmVendorExpress.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmVendorExpress.dtAsOf.DataBindings.Clear()
                frmVendorExpress.txtAmount.DataBindings.Clear()
                frmVendorExpress.txtCustomerRef.DataBindings.Clear()
                frmVendorExpress.txtVETextR.DataBindings.Clear()
                frmVendorExpress.txtCTNumber.DataBindings.Clear()
                frmVendorExpress.txtCTAmount.DataBindings.Clear()
                frmVendorExpress.dtCTDate.DataBindings.Clear()
                frmVendorExpress.cboAssignedTo.DataBindings.Clear()
                frmVendorExpress.cboAssignedToSub.DataBindings.Clear()
                frmVendorExpress.txtAssignedUser.DataBindings.Clear()
                frmVendorExpress.dtAssignedDate.DataBindings.Clear()
                frmVendorExpress.txtAssignedNotes.DataBindings.Clear()
                frmVendorExpress.txtCreateUser.DataBindings.Clear()
                frmVendorExpress.dtCreateDate.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmVendorExpress.dtAsOf.DataBindings.Add("text", objDataView, "AsOf")
                frmVendorExpress.txtAmount.DataBindings.Add("text", objDataView, "Amount")
                frmVendorExpress.txtCustomerRef.DataBindings.Add("text", objDataView, "CustomerReference")
                frmVendorExpress.txtVETextR.DataBindings.Add("text", objDataView, "Text")
                frmVendorExpress.txtCTNumber.DataBindings.Add("text", objDataView, "CTNumber")
                frmVendorExpress.txtCTAmount.DataBindings.Add("text", objDataView, "CTAmount")
                frmVendorExpress.dtCTDate.DataBindings.Add("text", objDataView, "CTDate")
                frmVendorExpress.cboAssignedTo.DataBindings.Add("text", objDataView, "AssignedTo")
                frmVendorExpress.cboAssignedToSub.DataBindings.Add("text", objDataView, "AssignedToSub")
                frmVendorExpress.txtAssignedUser.DataBindings.Add("text", objDataView, "AssignedUser")
                frmVendorExpress.dtAssignedDate.DataBindings.Add("text", objDataView, "AssignedDate")
                frmVendorExpress.txtAssignedNotes.DataBindings.Add("text", objDataView, "AssignedNotes")
                frmVendorExpress.txtCreateUser.DataBindings.Add("text", objDataView, "CreateUser")
                frmVendorExpress.dtCreateDate.DataBindings.Add("text", objDataView, "CreateDate")

            Case "frmSearch-assign"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsVendorExpress"

                'Setup form title...
                frmSearch.Text = "Unassigned Vendor Express Transactions"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Width = 67
                frmSearch.grdDataList.Columns(2).Visible = False
                frmSearch.grdDataList.Columns(3).Visible = False
                frmSearch.grdDataList.Columns(4).Visible = False
                frmSearch.grdDataList.Columns(5).Visible = False
                frmSearch.grdDataList.Columns(6).Visible = False
                frmSearch.grdDataList.Columns(7).Visible = False
                frmSearch.grdDataList.Columns(8).Visible = False
                frmSearch.grdDataList.Columns(9).Visible = False
                frmSearch.grdDataList.Columns(10).Visible = False
                frmSearch.grdDataList.Columns(11).Visible = False
                frmSearch.grdDataList.Columns(12).Width = 75
                frmSearch.grdDataList.Columns(13).Visible = False
                frmSearch.grdDataList.Columns(14).Visible = False
                frmSearch.grdDataList.Columns(15).Visible = False
                frmSearch.grdDataList.Columns(16).Visible = False
                frmSearch.grdDataList.Columns(17).Visible = False
                frmSearch.grdDataList.Columns(18).Visible = False
                frmSearch.grdDataList.Columns(19).Visible = False
                frmSearch.grdDataList.Columns(20).Width = 543
                frmSearch.grdDataList.Columns(21).Visible = False
                frmSearch.grdDataList.Columns(22).Visible = False
                frmSearch.grdDataList.Columns(23).Visible = False
                frmSearch.grdDataList.Columns(24).Visible = False
                frmSearch.grdDataList.Columns(25).Visible = False
                frmSearch.grdDataList.Columns(26).Visible = False
                frmSearch.grdDataList.Columns(27).Visible = False
                frmSearch.grdDataList.Columns(28).Visible = False
                frmSearch.grdDataList.Columns(29).Visible = False
                frmSearch.grdDataList.Columns(30).Visible = False
                frmSearch.grdDataList.Columns(31).Visible = False
                frmSearch.grdDataList.Columns(32).Visible = False

                'Setup column headers...
                frmSearch.grdDataList.Columns(1).HeaderText = "Bank Date"
                frmSearch.grdDataList.Columns(12).HeaderText = "Amount"
                frmSearch.grdDataList.Columns(20).HeaderText = "Text"

            Case "frmSearch-enterCT"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsVendorExpress"

                'Setup form title...
                frmSearch.Text = "Unverified Vendor Express Transactions"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Width = 67
                frmSearch.grdDataList.Columns(2).Visible = False
                frmSearch.grdDataList.Columns(3).Visible = False
                frmSearch.grdDataList.Columns(4).Visible = False
                frmSearch.grdDataList.Columns(5).Visible = False
                frmSearch.grdDataList.Columns(6).Visible = False
                frmSearch.grdDataList.Columns(7).Visible = False
                frmSearch.grdDataList.Columns(8).Visible = False
                frmSearch.grdDataList.Columns(9).Visible = False
                frmSearch.grdDataList.Columns(10).Visible = False
                frmSearch.grdDataList.Columns(11).Visible = False
                frmSearch.grdDataList.Columns(12).Width = 83
                frmSearch.grdDataList.Columns(13).Visible = False
                frmSearch.grdDataList.Columns(14).Visible = False
                frmSearch.grdDataList.Columns(15).Visible = False
                frmSearch.grdDataList.Columns(16).Visible = False
                frmSearch.grdDataList.Columns(17).Visible = False
                frmSearch.grdDataList.Columns(18).Visible = False
                frmSearch.grdDataList.Columns(19).Visible = False
                frmSearch.grdDataList.Columns(20).Visible = False
                frmSearch.grdDataList.Columns(21).Width = 180
                frmSearch.grdDataList.Columns(22).Width = 180
                frmSearch.grdDataList.Columns(23).Visible = False
                frmSearch.grdDataList.Columns(24).Visible = False
                frmSearch.grdDataList.Columns(25).Width = 175
                frmSearch.grdDataList.Columns(26).Visible = False
                frmSearch.grdDataList.Columns(27).Visible = False
                frmSearch.grdDataList.Columns(28).Visible = False
                frmSearch.grdDataList.Columns(29).Visible = False
                frmSearch.grdDataList.Columns(30).Visible = False
                frmSearch.grdDataList.Columns(31).Visible = False
                frmSearch.grdDataList.Columns(32).Visible = False


                'Setup column headers...
                frmSearch.grdDataList.Columns(1).HeaderText = "As Of Date"
                frmSearch.grdDataList.Columns(12).HeaderText = "Amount"
                frmSearch.grdDataList.Columns(21).HeaderText = "Assigned To"
                frmSearch.grdDataList.Columns(22).HeaderText = "Type"
                frmSearch.grdDataList.Columns(25).HeaderText = "Notes"

            Case "frmSearch-Normal"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsVendorExpress"

                'Setup form title...
                frmSearch.Text = "Vendor Express Search by CT #"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Visible = False
                frmSearch.grdDataList.Columns(2).Visible = False
                frmSearch.grdDataList.Columns(3).Visible = False
                frmSearch.grdDataList.Columns(4).Visible = False
                frmSearch.grdDataList.Columns(5).Visible = False
                frmSearch.grdDataList.Columns(6).Visible = False
                frmSearch.grdDataList.Columns(7).Visible = False
                frmSearch.grdDataList.Columns(8).Visible = False
                frmSearch.grdDataList.Columns(9).Visible = False
                frmSearch.grdDataList.Columns(10).Visible = False
                frmSearch.grdDataList.Columns(11).Visible = False
                frmSearch.grdDataList.Columns(12).Width = 83
                frmSearch.grdDataList.Columns(13).Visible = False
                frmSearch.grdDataList.Columns(14).Visible = False
                frmSearch.grdDataList.Columns(15).Visible = False
                frmSearch.grdDataList.Columns(16).Visible = False
                frmSearch.grdDataList.Columns(17).Visible = False
                frmSearch.grdDataList.Columns(18).Visible = False
                frmSearch.grdDataList.Columns(19).Visible = False
                frmSearch.grdDataList.Columns(20).Width = 125
                frmSearch.grdDataList.Columns(21).Width = 65
                frmSearch.grdDataList.Columns(22).Width = 65
                frmSearch.grdDataList.Columns(23).Visible = False
                frmSearch.grdDataList.Columns(24).Visible = False
                frmSearch.grdDataList.Columns(25).Width = 65
                frmSearch.grdDataList.Columns(26).Width = 65
                frmSearch.grdDataList.Columns(27).Width = 67
                frmSearch.grdDataList.Columns(28).Visible = False
                frmSearch.grdDataList.Columns(29).Width = 90
                frmSearch.grdDataList.Columns(30).Visible = False
                frmSearch.grdDataList.Columns(31).Visible = False
                frmSearch.grdDataList.Columns(32).Visible = False

                'Setup column headers...
                frmSearch.grdDataList.Columns(12).HeaderText = "Amount"
                frmSearch.grdDataList.Columns(20).HeaderText = "Text"
                frmSearch.grdDataList.Columns(21).HeaderText = "Assigned To"
                frmSearch.grdDataList.Columns(22).HeaderText = "Assigned Type"
                frmSearch.grdDataList.Columns(25).HeaderText = "Assigned Notes"
                frmSearch.grdDataList.Columns(26).HeaderText = "CT #"
                frmSearch.grdDataList.Columns(27).HeaderText = "CT Date"
                frmSearch.grdDataList.Columns(29).HeaderText = "Import File"

            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsVendorExpress"

                'Setup form title...
                frmSearch.Text = "Vendor Express Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Width = 68
                frmSearch.grdDataList.Columns(2).Visible = False
                frmSearch.grdDataList.Columns(3).Visible = False
                frmSearch.grdDataList.Columns(4).Visible = False
                frmSearch.grdDataList.Columns(5).Visible = False
                frmSearch.grdDataList.Columns(6).Visible = False
                frmSearch.grdDataList.Columns(7).Visible = False
                frmSearch.grdDataList.Columns(8).Visible = False
                frmSearch.grdDataList.Columns(9).Visible = False
                frmSearch.grdDataList.Columns(10).Visible = False
                frmSearch.grdDataList.Columns(11).Visible = False
                frmSearch.grdDataList.Columns(12).Width = 83
                frmSearch.grdDataList.Columns(13).Visible = False
                frmSearch.grdDataList.Columns(14).Visible = False
                frmSearch.grdDataList.Columns(15).Visible = False
                frmSearch.grdDataList.Columns(16).Visible = False
                frmSearch.grdDataList.Columns(17).Visible = False
                frmSearch.grdDataList.Columns(18).Visible = False
                frmSearch.grdDataList.Columns(19).Visible = False
                frmSearch.grdDataList.Columns(20).Width = 60
                frmSearch.grdDataList.Columns(21).Width = 60
                frmSearch.grdDataList.Columns(22).Width = 60
                frmSearch.grdDataList.Columns(23).Width = 60
                frmSearch.grdDataList.Columns(24).Visible = False
                frmSearch.grdDataList.Columns(25).Width = 60
                frmSearch.grdDataList.Columns(26).Width = 65
                frmSearch.grdDataList.Columns(26).Width = 65
                frmSearch.grdDataList.Columns(27).Width = 67
                frmSearch.grdDataList.Columns(28).Width = 83
                frmSearch.grdDataList.Columns(29).Visible = False
                frmSearch.grdDataList.Columns(30).Visible = False
                frmSearch.grdDataList.Columns(31).Visible = False
                frmSearch.grdDataList.Columns(32).Visible = False


                'Setup column headers...
                frmSearch.grdDataList.Columns(1).HeaderText = "As Of"
                frmSearch.grdDataList.Columns(12).HeaderText = "Amount"
                frmSearch.grdDataList.Columns(20).HeaderText = "Text"
                frmSearch.grdDataList.Columns(21).HeaderText = "Assigned To"
                frmSearch.grdDataList.Columns(22).HeaderText = "Assigned Type"
                frmSearch.grdDataList.Columns(23).HeaderText = "Assigned By"
                frmSearch.grdDataList.Columns(25).HeaderText = "Assigned Notes"
                frmSearch.grdDataList.Columns(26).HeaderText = "CT #"
                frmSearch.grdDataList.Columns(27).HeaderText = "CT Date"
                frmSearch.grdDataList.Columns(28).HeaderText = "CT Amount"
            Case "frmSearch-auto-assign", "frmSearch-auto-assign-det"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = Nothing
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsVendorExpress"
        End Select

        Select Case strBindTarget
            Case "frmSearch-auto-assign"
                frmSearch.grdDataList.Columns("Amount").DefaultCellStyle.Format = "c"
                frmSearch.grdDataList.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Case "frmSearch-auto-assign-det"
                frmSearch.grdDataList.Columns("RowID").Visible = False
                frmSearch.grdDataList.Columns("SSN").Visible = False
                '  frmSearch.grdDataList.Columns("Stno").DefaultCellStyle.Format = "0000000"
                frmSearch.grdDataList.Columns("Student").Width = 150
                frmSearch.grdDataList.Columns("Qtr").Width = 50
                frmSearch.grdDataList.Columns("Year").Width = 50
                frmSearch.grdDataList.Columns("Amount").DefaultCellStyle.Format = "c"
                frmSearch.grdDataList.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmSearch.grdDataList.Columns("Balance").DefaultCellStyle.Format = "c"
                frmSearch.grdDataList.Columns("Balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmSearch.grdDataList.Columns("ProcessFlag").Visible = False

                'objDataSet.Tables(0).DefaultView.Sort = "ProcessFlag ASC"
            Case Else
                frmSearch.grdDataList.Columns(12).DefaultCellStyle.Format = "c"
                frmSearch.grdDataList.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmSearch.grdDataList.Columns(28).DefaultCellStyle.Format = "c"
                frmSearch.grdDataList.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End Select


        
        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objVendorExpressData = New clsVendorExpress
        'Call objVendorExpressData.subVendorExpressSelect(strBindTarget:="frmSearch", strAction:="VENDEXACH-SEARCH-ALL", _
        'intRowID:=0, strReconType:="NONE",strReconDesc:="NONE",strMonth:="NONE", strQuarter:="NONE", intYear:=0, strReconciler:="NONE" _
        'dtStartDate:="01/01/1900",dtStopDate:="01/01/1900", intNumRecItems:=0, intSumRecItems:=0, strCreatedUser:=SystemInformation.UserName,dtCreatedDate:="01/01/1900")
        '***********************************************
        '***********************************************

    End Sub

    '*** B. subVendorExpressAction
    Public Sub subVendorExpressAction(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, ByVal dtAsOf As Date, ByVal strCurrency As String, ByVal strBankIDType As String, ByVal intBankID As Integer, ByVal strBankIDDesc As String, ByVal intAccount As Integer, ByVal strAccountDesc As String, ByVal strRowType As String, ByVal strDataType As String, ByVal intBAICode As Integer, ByVal strDescription As String, ByVal intAmount As Double, _
                                      ByVal dtBalanceValueDate As Date, ByVal strCustomerReference As String, ByVal strBankReference As String, ByVal strCreditImmedAvail As String, ByVal strOneDayFloat As String, ByVal strTwoPlusDayFloat As String, ByVal intItemCount As Integer, ByVal strText As String, ByVal strAssignedTo As String, ByVal strAssignedToSub As String, ByVal strAssignedUser As String, ByVal dtAssignedDate As Date, ByVal strCTNumber As String, ByVal strAssignedNotes As String, ByVal dtCTDate As Date, ByVal intCTAmount As Double, _
                                      ByVal strImportFileName As String, ByVal intBofA_Import_Link As Integer, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procVendorExpress"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@AsOf", dtAsOf)
        objCommand.Parameters.AddWithValue("@Currency", strCurrency)
        objCommand.Parameters.AddWithValue("@BankIDType", strBankIDType)
        objCommand.Parameters.AddWithValue("@BankID", intBankID)
        objCommand.Parameters.AddWithValue("@BankIDDesc", strBankIDDesc)
        objCommand.Parameters.AddWithValue("@Account", intAccount)
        objCommand.Parameters.AddWithValue("@AccountDesc", strAccountDesc)
        objCommand.Parameters.AddWithValue("@RowType", strRowType)
        objCommand.Parameters.AddWithValue("@DataType", strDataType)
        objCommand.Parameters.AddWithValue("@BAICode", intBAICode)
        objCommand.Parameters.AddWithValue("@Description", strDescription)
        objCommand.Parameters.AddWithValue("@Amount", intAmount)
        objCommand.Parameters.AddWithValue("@BalanceValueDate", dtBalanceValueDate)
        objCommand.Parameters.AddWithValue("@CustomerReference", strCustomerReference)
        objCommand.Parameters.AddWithValue("@BankReference", strBankReference)
        objCommand.Parameters.AddWithValue("@CreditImmedAvail", strCreditImmedAvail)
        objCommand.Parameters.AddWithValue("@OneDayFloat", strOneDayFloat)
        objCommand.Parameters.AddWithValue("@TwoPlusDayFloat", strTwoPlusDayFloat)
        objCommand.Parameters.AddWithValue("@ItemCount", intItemCount)
        objCommand.Parameters.AddWithValue("@Text", strText)
        objCommand.Parameters.AddWithValue("@AssignedTo", strAssignedTo)
        objCommand.Parameters.AddWithValue("@AssignedToSub", strAssignedToSub)
        objCommand.Parameters.AddWithValue("@AssignedUser", strAssignedUser)
        objCommand.Parameters.AddWithValue("@AssignedDate", dtAssignedDate)
        objCommand.Parameters.AddWithValue("@AssignedNotes", strAssignedNotes)
        objCommand.Parameters.AddWithValue("@CTNumber", strCTNumber)
        objCommand.Parameters.AddWithValue("@CTDate", dtCTDate)
        objCommand.Parameters.AddWithValue("@CTAmount", intCTAmount)
        objCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objCommand.Parameters.AddWithValue("@BofA_Import_Link", intBofA_Import_Link)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '        '***********************************************
        '        '******************* ACTION CODE ***************
        '        '***********************************************
        '        ' objVendorExpressAction = New clsVendorExpress
        '        ' Call objVendorExpressAction.subVendorExpressAction(strBindTarget:="frmVendorExpress", strAction:="ASSIGN", intRowID:=frmMainMenu.txtActionID.Text, dtAsOf:=Me.dtAsOf.Text, strCurrency:="NONE", strBankIDType:="NONE", intBankID:=0, strBankIDDesc:="NONE", intAccount:=0, _
        '               strAccountDesc:="NONE", strRowType:="NONE", strDataType:="NONE", intBAICode:=0, strDescription:="NONE", intAmount:=0, dtBalanceValueDate:="01/01/1900", strCustomerReference:="NONE", strBankReference:="NONE", _
        '               strCreditImmedAvail:="NONE", strOneDayFloat:="NONE", strTwoPlusDayFloat:="NONE", intItemCount:=0, strText:="NONE", strAssignedTo:=Me.cboAssignedTo.Text, strAssignedToSub:=Me.cboAssignedToSub.Text, strAssignedUser:=Me.txtAssignedUser.Text, dtAssignedDate:=Me.dtAssignedDate.Text, strAssignedNotes:=Me.txtAssignedNotes.Text, strCTNumber:="NONE", dtCTDate:="01/01/1900", intCTAmount:=0, strImportFileName:="NONE", _
        '               intBofA_Import_Link:=0, strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '
        '        '***********************************************
        '        '***********************************************
    End Sub
End Class

