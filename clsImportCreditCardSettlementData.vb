'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subCCSettleDataSelect
'*** B. subCCSettleDataAction
'****************************************
'****************************************
Public Class clsImportCreditCardSettlementData
    Dim objConnection As New SqlConnection _
          (frmMainMenu.strSFSCon)

    '*** A. subCCSettleDataSelect
    Public Sub subCCSettleDataSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal strMerchantNum As String, _
                ByVal intStoreNo As Integer, ByVal strCardType As String, ByVal dtSettleDate As Date, ByVal intBatchNo As Integer, _
                ByVal intItems As Integer, ByVal dblSalesAmount As Double, ByVal dblCreditAmount As Double, ByVal dblNetTotal As Double, _
                ByVal strImportFileName As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procCCSettleData"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantNum ", strMerchantNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StoreNo", intStoreNo)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CardType", strCardType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SettleDate", dtSettleDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BatchNo", intBatchNo)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Items", intItems)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SalesAmount", dblSalesAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreditAmount", dblCreditAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@NetTotal", dblNetTotal)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)


        objDataAdapter.SelectCommand.CommandTimeout = 600
        'Open the database connection...
        objConnection.Open()

        Cursor.Current = Cursors.WaitCursor

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsCCSettleData")

        Cursor.Current = Cursors.Arrow

        frmReconMatch.ScholDataTable = objDataSet.Tables("dsCCSettleData")
        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmScholarship"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....

                objDataAdapter.Fill(objDataSet, "dsCCSettleData")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsCCSettleData"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmScholarship.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmScholarship.txtStno.DataBindings.Clear()
                frmScholarship.txtSSN.DataBindings.Clear()
                frmScholarship.txtName.DataBindings.Clear()
                frmScholarship.txtQtr.DataBindings.Clear()
                frmScholarship.txtYear.DataBindings.Clear()
                frmScholarship.txtContract.DataBindings.Clear()
                frmScholarship.txtStatus.DataBindings.Clear()
                frmScholarship.txtSponsor.DataBindings.Clear()
                frmScholarship.txtExpenses.DataBindings.Clear()
                frmScholarship.txtRevenue.DataBindings.Clear()
                frmScholarship.txtBalance.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmScholarship.txtStno.DataBindings.Add("text", objDataView, "Stno")
                frmScholarship.txtSSN.DataBindings.Add("text", objDataView, "ss_no")
                frmScholarship.txtName.DataBindings.Add("text", objDataView, "student_name")
                frmScholarship.txtQtr.DataBindings.Add("text", objDataView, "Qtr")
                frmScholarship.txtYear.DataBindings.Add("text", objDataView, "Year")
                frmScholarship.txtContract.DataBindings.Add("text", objDataView, "ContractID")
                frmScholarship.txtStatus.DataBindings.Add("text", objDataView, "Status")
                frmScholarship.txtSponsor.DataBindings.Add("text", objDataView, "SponsorName")
                frmScholarship.txtExpenses.DataBindings.Add("text", objDataView, "Expenses")
                frmScholarship.txtRevenue.DataBindings.Add("text", objDataView, "Revenue")
                frmScholarship.txtBalance.DataBindings.Add("text", objDataView, "Balance")






            Case "frmVendorExpressPmt-grdALL"

                frmVendorExpressPmt.grdScholAll.DataSource = objDataSet
                frmVendorExpressPmt.grdScholAll.DataMember = "dsScholarship"

                frmVendorExpressPmt.PmtAllDataTable = objDataSet.Tables("dsScholarship")

                frmVendorExpressPmt.dvPmtAll = frmVendorExpressPmt.PmtAllDataTable.DefaultView
                frmVendorExpressPmt.dvPmtAll.RowFilter = "Flag = 0"
                frmVendorExpressPmt.grdScholAll.DataSource = frmVendorExpressPmt.dvPmtAll
                frmVendorExpressPmt.PmtAllDataTable.DefaultView.AllowNew = False  ' deletes blank row at bottom of grid
                'Setup form title...
                frmVendorExpressPmt.grdScholAll.Text = " Open Scholarships (GET)"


                frmVendorExpressPmt.grdScholAll.Columns(0).Visible = False  ' Seq Record #
                frmVendorExpressPmt.grdScholAll.Columns(1).Visible = False  ' Flag for Grid rowfilter - to show or not
                frmVendorExpressPmt.grdScholAll.Columns(2).Visible = False  ' RowID of Detail record to process/update
                frmVendorExpressPmt.grdScholAll.Columns(3).Width = 50
                frmVendorExpressPmt.grdScholAll.Columns(4).Width = 50
                frmVendorExpressPmt.grdScholAll.Columns(5).Width = 97
                frmVendorExpressPmt.grdScholAll.Columns(6).Width = 25
                frmVendorExpressPmt.grdScholAll.Columns(7).Width = 33
                frmVendorExpressPmt.grdScholAll.Columns(8).Width = 65

                frmVendorExpressPmt.grdScholAll.Columns(3).DefaultCellStyle.Format = "0000000"
                frmVendorExpressPmt.grdScholAll.Columns(8).DefaultCellStyle.Format = "c"
                frmVendorExpressPmt.grdScholAll.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmVendorExpressPmt.grdScholAll.EditMode = DataGridViewEditMode.EditProgrammatically

            Case "frmVendorExpressPmt-grdSEL"

                frmVendorExpressPmt.grdScholSelect.DataSource = objDataSet
                frmVendorExpressPmt.grdScholSelect.DataMember = "dsScholarship"

                frmVendorExpressPmt.PmtSelDataTable = objDataSet.Tables("dsScholarship")

                frmVendorExpressPmt.dvPmtSel = frmVendorExpressPmt.PmtSelDataTable.DefaultView
                frmVendorExpressPmt.dvPmtSel.RowFilter = "Flag = 0"
                frmVendorExpressPmt.grdScholSelect.DataSource = frmVendorExpressPmt.dvPmtSel
                frmVendorExpressPmt.PmtSelDataTable.DefaultView.AllowNew = False  ' deletes blank row at bottom of grid

                'Setup form title...
                frmVendorExpressPmt.grdScholSelect.Text = " Open Scholarships (GET)"

                frmVendorExpressPmt.grdScholSelect.Columns(0).Visible = False       ' Seq Record #
                frmVendorExpressPmt.grdScholSelect.Columns(1).Visible = False       ' Flag for Grid rowfilter - to show or not
                frmVendorExpressPmt.grdScholSelect.Columns(2).Visible = False       ' RowID of Detail record to process/update
                frmVendorExpressPmt.grdScholSelect.Columns(3).Width = 50
                frmVendorExpressPmt.grdScholSelect.Columns(4).Width = 50
                frmVendorExpressPmt.grdScholSelect.Columns(5).Width = 97
                frmVendorExpressPmt.grdScholSelect.Columns(6).Width = 25
                frmVendorExpressPmt.grdScholSelect.Columns(7).Width = 33
                frmVendorExpressPmt.grdScholSelect.Columns(8).Width = 65

                frmVendorExpressPmt.grdScholSelect.Columns(3).DefaultCellStyle.Format = "0000000"
                frmVendorExpressPmt.grdScholSelect.Columns(8).DefaultCellStyle.Format = "c"
                frmVendorExpressPmt.grdScholSelect.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmVendorExpressPmt.grdScholSelect.EditMode = DataGridViewEditMode.EditProgrammatically

        End Select
        'frmSearch.grdDataList.Columns(2).DefaultCellStyle.Format = "c"

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objScholarshipSelect = New clsScholarship
        'Call objScholarshipSelect.subScholarshipSelect(strBindTarget:="NONE", strAction:="NONE", intScholarshipID:=0, _
        'intSponsorID:=0, strStno:="NONE", intContractID:=0, strQtr:="NONE", strYear:="NONE", dtScholarshipDate:="01/01/1900", dblExpenses:=0, dblRevenue:=0, _
        'dblBalance:=0, strStatus:="NONE", strTranDescr:="NONE", strSource:="NONE", strImportFileName:="NONE", dtImportDate:="01/01/1900", strImportUser:="NONE", _
        'strStudentName:="NONE")
        '***********************************************
        '***********************************************

    End Sub


    '*** B. subCCSettleDataAction
    Public Sub subCCSettleDataAction(ByVal strAction As String, ByVal strMerchantNum As String, _
                ByVal intStoreNo As Integer, ByVal strCardType As String, ByVal dtSettleDate As Date, ByVal intBatchNo As Integer, _
                ByVal intItems As Integer, ByVal dblSalesAmount As Double, ByVal dblCreditAmount As Double, ByVal dblNetTotal As Double, _
                ByVal strImportFileName As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procCCSettleData"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@MerchantNum ", strMerchantNum)
        objCommand.Parameters.AddWithValue("@StoreNo", intStoreNo)
        objCommand.Parameters.AddWithValue("@CardType", strCardType)
        objCommand.Parameters.AddWithValue("@SettleDate", dtSettleDate)
        objCommand.Parameters.AddWithValue("@BatchNo", intBatchNo)
        objCommand.Parameters.AddWithValue("@Items", intItems)
        objCommand.Parameters.AddWithValue("@SalesAmount", dblSalesAmount)
        objCommand.Parameters.AddWithValue("@CreditAmount", dblCreditAmount)
        objCommand.Parameters.AddWithValue("@NetTotal", dblNetTotal)
        objCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
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

        frmImport.intRetExists = Convert.ToInt32(retValParam.Value)

        'Close the database connection...
        objConnection.Close()

        ''***********************************************
        ''******************* ACTION CODE ***************
        ''***********************************************
        'objScholarshipAction = New clsScholarship
        'Call objScholDetAction.subScholarshipAction(strAction:="NONE", intScholarshipID:=0, _
        'intSponsorID:=0, strStno:="NONE", intContractID:=0, strQtr:="NONE", strYear:="NONE", dtScholarshipDate:="01/01/1900", dblExpenses:=0, dblRevenue:=0, _
        'dblBalance:=0, strStatus:="NONE", strTranDescr:="NONE", strSource:="NONE", strImportFileName:="NONE", dtImportDate:="01/01/1900", strImportUser:="NONE", _
        'strStudentName:="NONE")
        '    '***********************************************
        '    '***********************************************

    End Sub

    ''*** B. subScholarshipReload
    'Public Sub subScholarshipReload()
    '    frmScholarship.MdiParent = frmMainMenu
    '    frmScholarship.Show()
    '    frmScholarship.txtExpenses.Text = Format(Val(frmScholarship.txtExpenses.Text), "c")
    '    frmScholarship.txtRevenue.Text = Format(Val(frmScholarship.txtRevenue.Text), "c")
    '    frmScholarship.txtBalance.Text = Format(Val(frmScholarship.txtBalance.Text), "c")
    '    frmScholarship.txtStno.Text = Format(Val(frmScholarship.txtStno.Text), "0######")
    '    frmScholarship.txtSSN.Text = Format(Val(frmScholarship.txtSSN.Text), "###-##-####")
    'End Sub
End Class
