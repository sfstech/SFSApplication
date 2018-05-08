Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subIRMasterSelect
'*** B. subIRMasterAction
Public Class clsIRMaster

    Public WithEvents objReconUWSDBData As clsUWSDB
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subIRMasterSelect
    Public Sub subIRMasterSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intIRID As Integer, ByVal strInvoiceNumber As String, ByVal dtInvoiceDate As Date, ByVal strCustomerName As String, _
                                 ByVal strAddressLine1 As String, ByVal strAddressLine2 As String, ByVal strAddressLine3 As String, ByVal strCity As String, ByVal strState As String, ByVal strZipCode As String, ByVal strCountry As String, _
                                 ByVal strBudget As String, ByVal dblAmount As Double, ByVal dblTax As Double, ByVal dblTotInvoiceAmt As Double, ByVal strGovernmentCode As String, _
                                 ByVal strImportFileName As String, ByVal dtImportDate As Date, ByVal strImportUser As String, ByVal strCPLoanNumber As String, _
                                 ByVal strExportFileName As String, ByVal dtExportDate As Date, ByVal strExportUser As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim DS As System.Data.DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procIRMaster"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@IRID", intIRID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@InvoiceNumber", strInvoiceNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@InvoiceDate", dtInvoiceDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerName", strCustomerName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AddressLine1", strAddressLine1)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AddressLine2", strAddressLine2)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AddressLine3", strAddressLine3)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@City", strCity)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@State", strState)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ZipCode", strZipCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Country", strCountry)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Budget", strBudget)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Tax", dblTax)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TotInvoiceAmt", dblTotInvoiceAmt)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@GovernmentCode", strGovernmentCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportDate", dtImportDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CPLoanNumber", strCPLoanNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ExportFileName", strExportFileName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ExportDate", dtExportDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ExportUser", strExportUser)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsIRMaster")

        'Close the database connection...
        objConnection.Close()

        ' Dim col As DataColumn


        Select Case strBindTarget
            Case "frmExport"
                'Set the DataGridView properties to bind it to the data...
                frmExport.grdDataList.DataSource = objDataSet
                frmExport.grdDataList.DataMember = "dsIRMaster"

                'Setup alternating rows style...
                frmExport.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmExport.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
                frmExport.grdDataList.Columns("InvoiceDate").DefaultCellStyle.Format = "MM/dd/yyyy"
                'col = New DataColumn("dist_tbl", System.Type.[GetType]("System.String"))
                'frmExport.grdDataList.Columns.Add(col)
                'col = New DataColumn("dist_index", System.Type.[GetType]("System.String"))
                'frmExport.grdDataList.Columns.Add(col)
                'Setup column widths...
                'frmELM.grdElmData.Columns(0).Visible = False
            Case "frmExportHoldTbl"
                frmExport.BudgetTbl = objDataSet.Tables(0)
            Case "frmSearch"
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsIRMaster"
            Case "frmIRBudgetcbo"
                frmIRBudget.cboDepartment.DataSource = objDataSet.Tables(0)
                'frmIRBudget.cboDepartment.SelectedValue = 0
                frmIRBudget.cboDepartment.DisplayMember = "DeptName"
                frmIRBudget.cboDepartment.ValueMember = "DeptID"
            Case "frmIRBudgetEdit"
                frmIRBudget.txtRevCode.Text = objDataSet.Tables(0).Rows(0).Item("RevenueCode")
                frmIRBudget.intDeptRec = objDataSet.Tables(0).Rows(0).Item("DeptID")
                frmIRBudget.cboDepartment.Text = objDataSet.Tables(0).Rows(0).Item("DeptName")
            Case "frmSearch-Pmt"
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsIRMaster"
                frmSearch.grdDataList.Columns("InvoiceNumber").Width = 85
                frmSearch.grdDataList.Columns("Budget").Width = 60
                frmSearch.grdDataList.Columns("Rev Code").Width = 60
                frmSearch.grdDataList.Columns("Tran Date").Width = 65
                frmSearch.grdDataList.Columns("Tran Date").DefaultCellStyle.Format = "MM/dd/yy"
                frmSearch.grdDataList.Columns("CT Date").Width = 65
                frmSearch.grdDataList.Columns("CT Date").DefaultCellStyle.Format = "MM/dd/yy"
                frmSearch.grdDataList.Columns("Principal").Width = 100
                frmSearch.grdDataList.Columns("Principal").DefaultCellStyle.Format = "c"
                frmSearch.grdDataList.Columns("Principal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmSearch.grdDataList.Columns("Interest").Width = 90
                frmSearch.grdDataList.Columns("Interest").DefaultCellStyle.Format = "c"
                frmSearch.grdDataList.Columns("Interest").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmSearch.grdDataList.Columns("Tax").Width = 80
                frmSearch.grdDataList.Columns("Tax").DefaultCellStyle.Format = "c"
                frmSearch.grdDataList.Columns("Tax").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmSearch.grdDataList.Columns("Late Charge").Width = 80
                frmSearch.grdDataList.Columns("Late Charge").DefaultCellStyle.Format = "c"
                frmSearch.grdDataList.Columns("Late Charge").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmSearch.grdDataList.Columns("Invoice Amt").Width = 80
                frmSearch.grdDataList.Columns("Invoice Amt").DefaultCellStyle.Format = "c"
                frmSearch.grdDataList.Columns("Invoice Amt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmSearch.grdDataList.Columns("Customer").Width = 200
                frmSearch.grdDataList.Columns("Department").Width = 200
            Case "frmSearch-No-Pmt"
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsIRMaster"
                frmSearch.grdDataList.Columns("InvoiceNumber").Width = 85
                frmSearch.grdDataList.Columns("Budget").Width = 60
                frmSearch.grdDataList.Columns("Invoice Amt").Width = 80
                frmSearch.grdDataList.Columns("Invoice Amt").DefaultCellStyle.Format = "c"
                frmSearch.grdDataList.Columns("Invoice Amt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmSearch.grdDataList.Columns("Customer").Width = 200

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objElmData = New clsELM
        'Call objElmData.subElmSelect(strBindTarget:="NONE", strAction:="SELECT", intSSN:=0,intStudent_no:=0, _
        'dtElmDate:="01/01/1900", intBatchNum:=0, strElmString:="NONE", strCreateUser:="NONE")
        '***********************************************
        '***********************************************
    End Sub


    '*** B. subIRMasterAction
    Public Sub subIRMasterAction(ByVal strAction As String, ByVal intIRID As Integer, ByVal strInvoiceNumber As String, ByVal dtInvoiceDate As Date, ByVal strCustomerName As String, _
                                 ByVal strAddressLine1 As String, ByVal strAddressLine2 As String, ByVal strAddressLine3 As String, ByVal strCity As String, ByVal strState As String, ByVal strZipCode As String, ByVal strCountry As String, _
                                 ByVal strBudget As String, ByVal dblAmount As Double, ByVal dblTax As Double, ByVal dblTotInvoiceAmt As Double, ByVal strGovernmentCode As String, _
                                 ByVal strImportFileName As String, ByVal dtImportDate As Date, ByVal strImportUser As String, ByVal strCPLoanNumber As String, _
                                 ByVal strExportFileName As String, ByVal dtExportDate As Date, ByVal strExportUser As String)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procIRMaster"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@IRID", intIRID)
        objCommand.Parameters.AddWithValue("@InvoiceNumber", strInvoiceNumber)
        objCommand.Parameters.AddWithValue("@InvoiceDate", dtInvoiceDate)
        objCommand.Parameters.AddWithValue("@CustomerName", strCustomerName)
        objCommand.Parameters.AddWithValue("@AddressLine1", strAddressLine1)
        objCommand.Parameters.AddWithValue("@AddressLine2", strAddressLine2)
        objCommand.Parameters.AddWithValue("@AddressLine3", strAddressLine3)
        objCommand.Parameters.AddWithValue("@City", strCity)
        objCommand.Parameters.AddWithValue("@State", strState)
        objCommand.Parameters.AddWithValue("@ZipCode", strZipCode)
        objCommand.Parameters.AddWithValue("@Country", strCountry)
        objCommand.Parameters.AddWithValue("@Budget", strBudget)
        objCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objCommand.Parameters.AddWithValue("@Tax", dblTax)
        objCommand.Parameters.AddWithValue("@TotInvoiceAmt", dblTotInvoiceAmt)
        objCommand.Parameters.AddWithValue("@GovernmentCode", strGovernmentCode)
        objCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objCommand.Parameters.AddWithValue("@ImportDate", dtImportDate)
        objCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objCommand.Parameters.AddWithValue("@CPLoanNumber", strCPLoanNumber)
        objCommand.Parameters.AddWithValue("@ExportFileName", strExportFileName)
        objCommand.Parameters.AddWithValue("@ExportDate", dtExportDate)
        objCommand.Parameters.AddWithValue("@ExportUser", strExportUser)

        'Create a SqlParameter object to hold the RETURN value, set the direction to ReturnValue and add to parameters
        Dim retValParam As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        retValParam.Direction = ParameterDirection.ReturnValue
        objCommand.Parameters.Add(retValParam)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        Select Case strAction
            Case "CHECK-INVOICE-EXISTS", "CHECK-BUDGET-EXISTS", "CHECK-PMT-FILE-EXISTS"
                frmImport.intInvoiceCnt = Convert.ToInt32(retValParam.Value)
            Case "CHECK-BUDGET-EXISTS-MAINT"
                frmIRBudget.intDeptRec = Convert.ToInt32(retValParam.Value)
            Case Else
                frmExport.intInvoiceCnt = Convert.ToInt32(retValParam.Value)
        End Select


        'If strAction = "CHECK-INVOICE-EXISTS" Or strAction = "CHECK-BUDGET-EXISTS" Or strAction = "CHECK-PMT-FILE-EXISTS" Or strAction = "CHECK-BUDGET-EXISTS-MAINT" Then
        '    frmImport.intInvoiceCnt = Convert.ToInt32(retValParam.Value)
        'Else
        '    frmExport.intInvoiceCnt = Convert.ToInt32(retValParam.Value)
        'End If

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
