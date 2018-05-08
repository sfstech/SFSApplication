
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

    ''jjea added binding source for search all section. Filtering only works with binding source
    Public vendexBindingSource As New BindingSource

    '    '*** A. subVendorExpressSelect
    ''' <summary>
    ''' procVendorExpress
    ''' </summary>
    Public Sub subVendorExpressSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, ByVal dtAsOf As Date, ByVal strCurrency As String, ByVal strBankIDType As String, ByVal intBankID As Integer, ByVal strBankIDDesc As String, ByVal intAccount As Integer, ByVal strAccountDesc As String, ByVal strRowType As String, ByVal strDataType As String, ByVal intBAICode As Integer, ByVal strDescription As String, ByVal intAmount As Double, _
                                      ByVal dtBalanceValueDate As Date, ByVal strCustomerReference As String, ByVal strBankReference As String, ByVal strCreditImmedAvail As String, ByVal strOneDayFloat As String, ByVal strTwoPlusDayFloat As String, ByVal intItemCount As Integer, ByVal strText As String, ByVal strAssignedTo As String, ByVal strAssignedToSub As String, ByVal strAssignedUser As String, ByVal dtAssignedDate As Date, ByVal strAssignedNotes As String, ByVal strCTNumber As String, ByVal dtCTDate As Date, ByVal intCTAmount As Integer, _
                                      ByVal strImportFileName As String, ByVal intBofA_Import_Link As Integer, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objDataSet As New DataSet
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Dim DS As System.Data.DataSet

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
            Case "frmSearch-VE-tot"
                '   Dim t As String = String.Format("{0:N}", objDataSet.Tables("dsVendorExpress").Rows(0).Item(1))

                SearchMenu.txtTotCount.Text = objDataSet.Tables("dsVendorExpress").Rows(0).Item(0)
                SearchMenu.txtTotAmount.Text = String.Format("{0:N}", objDataSet.Tables("dsVendorExpress").Rows(0).Item(1))
            Case "frmSearch-assign"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsVendorExpress"

                'Setup form title...
                SearchMenu.Text = "Unassigned Vendor Express Transactions"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).Width = 67
                SearchMenu.grdDataList.Columns(2).Visible = False
                SearchMenu.grdDataList.Columns(3).Visible = False
                SearchMenu.grdDataList.Columns(4).Visible = False
                SearchMenu.grdDataList.Columns(5).Visible = False
                SearchMenu.grdDataList.Columns(6).Visible = False
                SearchMenu.grdDataList.Columns(7).Visible = False
                SearchMenu.grdDataList.Columns(8).Visible = False
                SearchMenu.grdDataList.Columns(9).Visible = False
                SearchMenu.grdDataList.Columns(10).Visible = False
                SearchMenu.grdDataList.Columns(11).Visible = False
                SearchMenu.grdDataList.Columns(12).Width = 75
                SearchMenu.grdDataList.Columns(13).Visible = False
                SearchMenu.grdDataList.Columns(14).Visible = False
                SearchMenu.grdDataList.Columns(15).Visible = False
                SearchMenu.grdDataList.Columns(16).Visible = False
                SearchMenu.grdDataList.Columns(17).Visible = False
                SearchMenu.grdDataList.Columns(18).Visible = False
                SearchMenu.grdDataList.Columns(19).Visible = False
                SearchMenu.grdDataList.Columns(20).Width = 543
                SearchMenu.grdDataList.Columns(21).Visible = False
                SearchMenu.grdDataList.Columns(22).Visible = False
                SearchMenu.grdDataList.Columns(23).Visible = False
                SearchMenu.grdDataList.Columns(24).Visible = False
                SearchMenu.grdDataList.Columns(25).Visible = False
                SearchMenu.grdDataList.Columns(26).Visible = False
                SearchMenu.grdDataList.Columns(27).Visible = False
                SearchMenu.grdDataList.Columns(28).Visible = False
                SearchMenu.grdDataList.Columns(29).Visible = False
                SearchMenu.grdDataList.Columns(30).Visible = False
                SearchMenu.grdDataList.Columns(31).Visible = False
                SearchMenu.grdDataList.Columns(32).Visible = False

                'Setup column headers...
                SearchMenu.grdDataList.Columns(1).HeaderText = "Bank Date"
                SearchMenu.grdDataList.Columns(12).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(20).HeaderText = "Text"

            Case "frmSearch-enterCT"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsVendorExpress"

                'Setup form title...
                SearchMenu.Text = "Unverified Vendor Express Transactions"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).Width = 67
                SearchMenu.grdDataList.Columns(2).Visible = False
                SearchMenu.grdDataList.Columns(3).Visible = False
                SearchMenu.grdDataList.Columns(4).Visible = False
                SearchMenu.grdDataList.Columns(5).Visible = False
                SearchMenu.grdDataList.Columns(6).Visible = False
                SearchMenu.grdDataList.Columns(7).Visible = False
                SearchMenu.grdDataList.Columns(8).Visible = False
                SearchMenu.grdDataList.Columns(9).Visible = False
                SearchMenu.grdDataList.Columns(10).Visible = False
                SearchMenu.grdDataList.Columns(11).Visible = False
                SearchMenu.grdDataList.Columns(12).Width = 83
                SearchMenu.grdDataList.Columns(13).Visible = False
                SearchMenu.grdDataList.Columns(14).Visible = False
                SearchMenu.grdDataList.Columns(15).Visible = False
                SearchMenu.grdDataList.Columns(16).Visible = False
                SearchMenu.grdDataList.Columns(17).Visible = False
                SearchMenu.grdDataList.Columns(18).Visible = False
                SearchMenu.grdDataList.Columns(19).Visible = False
                SearchMenu.grdDataList.Columns(20).Visible = False
                SearchMenu.grdDataList.Columns(21).Width = 180
                SearchMenu.grdDataList.Columns(22).Width = 180
                SearchMenu.grdDataList.Columns(23).Visible = False
                SearchMenu.grdDataList.Columns(24).Visible = False
                SearchMenu.grdDataList.Columns(25).Width = 175
                SearchMenu.grdDataList.Columns(26).Visible = False
                SearchMenu.grdDataList.Columns(27).Visible = False
                SearchMenu.grdDataList.Columns(28).Visible = False
                SearchMenu.grdDataList.Columns(29).Visible = False
                SearchMenu.grdDataList.Columns(30).Visible = False
                SearchMenu.grdDataList.Columns(31).Visible = False
                SearchMenu.grdDataList.Columns(32).Visible = False


                'Setup column headers...
                SearchMenu.grdDataList.Columns(1).HeaderText = "As Of Date"
                SearchMenu.grdDataList.Columns(12).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(21).HeaderText = "Assigned To"
                SearchMenu.grdDataList.Columns(22).HeaderText = "Type"
                SearchMenu.grdDataList.Columns(25).HeaderText = "Notes"

            Case "frmSearch-Normal"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsVendorExpress"

                'Setup form title...
                SearchMenu.Text = "Vendor Express Search by CT #"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).Visible = False
                SearchMenu.grdDataList.Columns(2).Visible = False
                SearchMenu.grdDataList.Columns(3).Visible = False
                SearchMenu.grdDataList.Columns(4).Visible = False
                SearchMenu.grdDataList.Columns(5).Visible = False
                SearchMenu.grdDataList.Columns(6).Visible = False
                SearchMenu.grdDataList.Columns(7).Visible = False
                SearchMenu.grdDataList.Columns(8).Visible = False
                SearchMenu.grdDataList.Columns(9).Visible = False
                SearchMenu.grdDataList.Columns(10).Visible = False
                SearchMenu.grdDataList.Columns(11).Visible = False
                SearchMenu.grdDataList.Columns(12).Width = 83
                SearchMenu.grdDataList.Columns(13).Visible = False
                SearchMenu.grdDataList.Columns(14).Visible = False
                SearchMenu.grdDataList.Columns(15).Visible = False
                SearchMenu.grdDataList.Columns(16).Visible = False
                SearchMenu.grdDataList.Columns(17).Visible = False
                SearchMenu.grdDataList.Columns(18).Visible = False
                SearchMenu.grdDataList.Columns(19).Visible = False
                SearchMenu.grdDataList.Columns(20).Width = 125
                SearchMenu.grdDataList.Columns(21).Width = 65
                SearchMenu.grdDataList.Columns(22).Width = 65
                SearchMenu.grdDataList.Columns(23).Visible = False
                SearchMenu.grdDataList.Columns(24).Visible = False
                SearchMenu.grdDataList.Columns(25).Width = 65
                SearchMenu.grdDataList.Columns(26).Width = 65
                SearchMenu.grdDataList.Columns(27).Width = 67
                SearchMenu.grdDataList.Columns(28).Visible = False
                SearchMenu.grdDataList.Columns(29).Width = 90
                SearchMenu.grdDataList.Columns(30).Visible = False
                SearchMenu.grdDataList.Columns(31).Visible = False
                SearchMenu.grdDataList.Columns(32).Visible = False

                'Setup column headers...
                SearchMenu.grdDataList.Columns(12).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(20).HeaderText = "Text"
                SearchMenu.grdDataList.Columns(21).HeaderText = "Assigned To"
                SearchMenu.grdDataList.Columns(22).HeaderText = "Assigned Type"
                SearchMenu.grdDataList.Columns(25).HeaderText = "Assigned Notes"
                SearchMenu.grdDataList.Columns(26).HeaderText = "CT #"
                SearchMenu.grdDataList.Columns(27).HeaderText = "CT Date"
                SearchMenu.grdDataList.Columns(29).HeaderText = "Import File"

            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...

                ''jjea assigning as binding source to be able to filter
                objDataView = objDataSet.Tables(0).DefaultView
                vendexBindingSource.DataSource = objDataView
                SearchMenu.grdDataList.DataSource = vendexBindingSource

                'SearchMenu.grdDataList.DataSource = objDataSet
                'SearchMenu.grdDataList.DataMember = "dsVendorExpress"


                'Setup form title...
                SearchMenu.Text = "Vendor Express Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).Width = 68
                SearchMenu.grdDataList.Columns(2).Visible = False
                SearchMenu.grdDataList.Columns(3).Visible = False
                SearchMenu.grdDataList.Columns(4).Visible = False
                SearchMenu.grdDataList.Columns(5).Visible = False
                SearchMenu.grdDataList.Columns(6).Visible = False
                SearchMenu.grdDataList.Columns(7).Visible = False
                SearchMenu.grdDataList.Columns(8).Visible = False
                SearchMenu.grdDataList.Columns(9).Visible = False
                SearchMenu.grdDataList.Columns(10).Visible = False
                SearchMenu.grdDataList.Columns(11).Visible = False
                SearchMenu.grdDataList.Columns(12).Width = 83
                SearchMenu.grdDataList.Columns(13).Visible = False
                SearchMenu.grdDataList.Columns(14).Visible = False
                SearchMenu.grdDataList.Columns(15).Visible = False
                SearchMenu.grdDataList.Columns(16).Visible = False
                SearchMenu.grdDataList.Columns(17).Visible = False
                SearchMenu.grdDataList.Columns(18).Visible = False
                SearchMenu.grdDataList.Columns(19).Visible = False
                SearchMenu.grdDataList.Columns(20).Width = 60
                SearchMenu.grdDataList.Columns(21).Width = 80
                SearchMenu.grdDataList.Columns(22).Width = 60
                SearchMenu.grdDataList.Columns(23).Width = 60
                SearchMenu.grdDataList.Columns(24).Width = 67
                SearchMenu.grdDataList.Columns(25).Width = 60
                SearchMenu.grdDataList.Columns(26).Width = 65
                SearchMenu.grdDataList.Columns(26).Width = 65
                SearchMenu.grdDataList.Columns(27).Width = 67
                SearchMenu.grdDataList.Columns(28).Width = 83
                SearchMenu.grdDataList.Columns(29).Visible = False
                SearchMenu.grdDataList.Columns(30).Visible = False
                SearchMenu.grdDataList.Columns(31).Visible = False
                SearchMenu.grdDataList.Columns(32).Visible = False


                'Setup column headers...
                SearchMenu.grdDataList.Columns(1).HeaderText = "As Of"
                SearchMenu.grdDataList.Columns(12).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(12).DefaultCellStyle.Format = "c"
                SearchMenu.grdDataList.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                SearchMenu.grdDataList.Columns(20).HeaderText = "Text"
                SearchMenu.grdDataList.Columns(21).HeaderText = "Assigned To"
                SearchMenu.grdDataList.Columns(22).HeaderText = "Assigned Type"
                SearchMenu.grdDataList.Columns(23).HeaderText = "Assigned By"
                SearchMenu.grdDataList.Columns(24).HeaderText = "Assigned Date"
                SearchMenu.grdDataList.Columns(25).HeaderText = "Assigned Notes"
                SearchMenu.grdDataList.Columns(26).HeaderText = "CT #"
                SearchMenu.grdDataList.Columns(27).HeaderText = "CT Date"
                SearchMenu.grdDataList.Columns(28).HeaderText = "CT Amount"
                SearchMenu.grdDataList.Columns(28).DefaultCellStyle.Format = "c"
                SearchMenu.grdDataList.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



            Case "frmSearch-auto-assign", "frmSearch-auto-assign-det", "frmSearch-auto-asgn-cao", "frmSearch-auto-va-seattle", "frmSearch-auto-va-tacoma", "frmSearch-auto-va-bothell"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = Nothing
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsVendorExpress"

        End Select

        Select Case strBindTarget
            Case "frmSearch-auto-assign", "frmSearch-auto-asgn-cao", "frmSearch-auto-va-seattle", "frmSearch-auto-va-tacoma", "frmSearch-auto-va-bothell"
                SearchMenu.grdDataList.Columns("Amount").DefaultCellStyle.Format = "c"
                SearchMenu.grdDataList.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Case "frmSearch-auto-assign-det"
                SearchMenu.grdDataList.Columns("RowID").Visible = False
                SearchMenu.grdDataList.Columns("SSN").Visible = False
                '  frmSearch.grdDataList.Columns("Stno").DefaultCellStyle.Format = "0000000"
                SearchMenu.grdDataList.Columns("Student").Width = 150
                SearchMenu.grdDataList.Columns("Qtr").Width = 50
                SearchMenu.grdDataList.Columns("Year").Width = 50
                SearchMenu.grdDataList.Columns("Amount").DefaultCellStyle.Format = "c"
                SearchMenu.grdDataList.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                SearchMenu.grdDataList.Columns("Balance").DefaultCellStyle.Format = "c"
                SearchMenu.grdDataList.Columns("Balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                SearchMenu.grdDataList.Columns("ProcessFlag").Visible = False
            Case "frmSearch-auto-acct"
                SearchMenu.VEDataTable = objDataSet.Tables("dsVendorExpress")
                'this CASE needs to be here (not above) so CASE ELSE does not get executed otherwise frmSearch --> subVE_Search_AutoAsGN_Acct() will not execute

            Case Else
                SearchMenu.grdDataList.Columns(12).DefaultCellStyle.Format = "c"
                SearchMenu.grdDataList.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                SearchMenu.grdDataList.Columns(28).DefaultCellStyle.Format = "c"
                SearchMenu.grdDataList.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
    ''' <summary>
    ''' procVendorExpress
    ''' </summary>
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

