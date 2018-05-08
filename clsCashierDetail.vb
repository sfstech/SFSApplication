'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subCashierDetSelect
'*** B. subCashierDetAction
'****************************************
'****************************************

Public Class clsCashierDetail
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)


    '*** A. subCashierSelect
    Public Sub subCashierDetSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intCashierTranID As Integer, _
                                   ByVal intCashierDetailID As Integer, ByVal strType As String, ByVal intTranCount As Integer, _
                                   ByVal mnyAmount As Double, ByVal strFASVerifyUser As String, ByVal dtFASVerifyDate As Date, _
                                   ByVal strSDBVerifyUser As String, ByVal dtSDBVerifyDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procCashierDetail"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CashierDetailID ", intCashierDetailID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CashierTranID ", intCashierTranID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranType", strType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranCount", intTranCount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranAmount", mnyAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FASVerifyUser", strFASVerifyUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FASVerifyDate", dtFASVerifyDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBVerifyUser", strSDBVerifyUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBVerifyDate", dtSDBVerifyDate)
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsCashierDet")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmCashierBal-Det-All"
                frmCashierBalancing.grdPmtsCatDataTable = objDataSet.Tables("dsCashierDet")
                'Set the DataGridView properties to bind it to the data...
                'frmCashierActivity.grdCashOnHand.DataSource = objDataSet
                'frmCashierActivity.grdCashOnHand.DataMember = "dsCashierDet"
                'frmCashierActivity.grdCashOnHand.EditMode = DataGridViewEditMode.EditProgrammatically
            Case "frmCashierAct-Cash"

                frmCashierActivity.grdPmtCOHDataTable = objDataSet.Tables("dsCashierDet")
                'Set the DataGridView properties to bind it to the data...
                frmCashierActivity.grdCashOnHand.DataSource = objDataSet
                frmCashierActivity.grdCashOnHand.DataMember = "dsCashierDet"
                frmCashierActivity.grdCashOnHand.EditMode = DataGridViewEditMode.EditProgrammatically
                'Setup column description,  widths and format ...
                frmCashierActivity.grdCashOnHand.Columns(0).Visible = False
                frmCashierActivity.grdCashOnHand.Columns(1).Visible = False
                frmCashierActivity.grdCashOnHand.Columns(2).HeaderText = "Type"
                frmCashierActivity.grdCashOnHand.Columns(2).Width = 260
                frmCashierActivity.grdCashOnHand.Columns(3).HeaderText = "Count"
                frmCashierActivity.grdCashOnHand.Columns(3).Width = 40
                frmCashierActivity.grdCashOnHand.Columns(4).HeaderText = "Amount"
                frmCashierActivity.grdCashOnHand.Columns(4).Width = 100
                frmCashierActivity.grdCashOnHand.Columns(4).DefaultCellStyle.Format = "c"
                frmCashierActivity.grdCashOnHand.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Case "frmCashierAct-Cat"

                frmCashierActivity.grdPmtCatDataTable = objDataSet.Tables("dsCashierDet")
                'Set the DataGridView properties to bind it to the data...
                frmCashierActivity.grdPmtCat.DataSource = objDataSet
                frmCashierActivity.grdPmtCat.DataMember = "dsCashierDet"
                frmCashierActivity.grdPmtCat.EditMode = DataGridViewEditMode.EditProgrammatically
                'Setup column description,  widths and format ...
                frmCashierActivity.grdPmtCat.Columns(0).Visible = False
                frmCashierActivity.grdPmtCat.Columns(1).Visible = False
                frmCashierActivity.grdPmtCat.Columns(2).HeaderText = "Type"
                frmCashierActivity.grdPmtCat.Columns(2).Width = 260
                frmCashierActivity.grdPmtCat.Columns(3).HeaderText = "Count"
                frmCashierActivity.grdPmtCat.Columns(3).Width = 40
                frmCashierActivity.grdPmtCat.Columns(4).HeaderText = "Amount"
                frmCashierActivity.grdPmtCat.Columns(4).Width = 100
                frmCashierActivity.grdPmtCat.Columns(4).DefaultCellStyle.Format = "c"
                frmCashierActivity.grdPmtCat.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Case "frmCashierAct-Meth"
                frmCashierActivity.grdPmtMethDataTable = objDataSet.Tables("dsCashierDet")
                'Set the DataGridView properties to bind it to the data...
                frmCashierActivity.grdPmtMeth.DataSource = objDataSet
                frmCashierActivity.grdPmtMeth.DataMember = "dsCashierDet"
                frmCashierActivity.grdPmtMeth.EditMode = DataGridViewEditMode.EditProgrammatically
                'Setup column description,  widths and format ...
                frmCashierActivity.grdPmtMeth.Columns(0).Visible = False
                frmCashierActivity.grdPmtMeth.Columns(1).Visible = False
                frmCashierActivity.grdPmtMeth.Columns(2).HeaderText = "Type"
                frmCashierActivity.grdPmtMeth.Columns(2).Width = 260
                frmCashierActivity.grdPmtMeth.Columns(3).HeaderText = "Count"
                frmCashierActivity.grdPmtMeth.Columns(3).Width = 40
                frmCashierActivity.grdPmtMeth.Columns(4).HeaderText = "Amount"
                frmCashierActivity.grdPmtMeth.Columns(4).Width = 100
                frmCashierActivity.grdPmtMeth.Columns(4).DefaultCellStyle.Format = "c"
                frmCashierActivity.grdPmtMeth.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Case "frmSearch"
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsCashierDet"
                'Setup form title...
                SearchMenu.Text = "Cashier Data Search by Amount"
                'Setup column description,  widths and format ...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).HeaderText = "TranDate"
                SearchMenu.grdDataList.Columns(1).Width = 85
                SearchMenu.grdDataList.Columns(2).Visible = False
                SearchMenu.grdDataList.Columns(3).Visible = False
                SearchMenu.grdDataList.Columns(4).HeaderText = "Cashier Name"
                SearchMenu.grdDataList.Columns(4).Width = 180
                SearchMenu.grdDataList.Columns(5).Visible = False
                SearchMenu.grdDataList.Columns(6).Visible = False
                SearchMenu.grdDataList.Columns(7).Visible = False
                SearchMenu.grdDataList.Columns(8).Visible = False
                SearchMenu.grdDataList.Columns(9).Visible = False
                SearchMenu.grdDataList.Columns(10).Visible = False
                SearchMenu.grdDataList.Columns(11).HeaderText = "Type"
                SearchMenu.grdDataList.Columns(11).Width = 180
                SearchMenu.grdDataList.Columns(12).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(12).Width = 95
                SearchMenu.grdDataList.Columns(12).DefaultCellStyle.Format = "c"
                SearchMenu.grdDataList.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Case "frmExport"
                frmExport.grdDataList.DataSource = ""
                frmExport.grdDataList.DataMember = ""
                frmExport.grdDataList.DataSource = objDataSet
                frmExport.grdDataList.DataMember = "dsCashierDet"
                'Setup form title...
                frmExport.Text = "Cashier Data Not Verified"
                frmExport.grdDataList.Columns(0).Visible = False
                frmExport.grdDataList.Columns(1).Width = 100
                frmExport.grdDataList.Columns(2).Width = 100
                frmExport.grdDataList.Columns(3).Visible = False
                frmExport.grdDataList.Columns(4).Width = 100
                frmExport.grdDataList.Columns(5).Visible = False
                frmExport.grdDataList.Columns(6).Visible = False
                frmExport.grdDataList.Columns(7).Visible = False
                frmExport.grdDataList.Columns(8).Visible = False
                frmExport.grdDataList.Columns(9).Visible = False
                frmExport.grdDataList.Columns(10).Visible = False
                frmExport.grdDataList.Columns(11).Visible = False
                frmExport.grdDataList.Columns(12).Width = 100
                frmExport.grdDataList.Columns(13).Width = 100
                frmExport.grdDataList.Columns(13).DefaultCellStyle.Format = "c"
                frmExport.grdDataList.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmExport.grdDataList.Columns(14).Visible = False
        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objCashierDetData = New clsCashierDetail
        'Call objCashierDetData.subCashierDetSelect(strBindTarget:="frmCashierAct-Cat", strAction:="SELECT-DEAIL-CAT", _
        'intCashierTranID:=0, strType:="NONE", intTranCount:=0, mnyAmount:=0)
        '***********************************************
        '***********************************************

    End Sub


    '*** B. subCashierDetAction
    Public Sub subCashierDetAction(ByVal strAction As String, ByVal intCashierTranID As Integer, _
                                   ByVal intCashierDetailID As Integer, ByVal strType As String, _
                                   ByVal intTranCount As Integer, ByVal mnyAmount As Double, _
                                   ByVal strFASVerifyUser As String, ByVal dtFASVerifyDate As Date, _
                                   ByVal strSDBVerifyUser As String, ByVal dtSDBVerifyDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procCashierDetail"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@CashierDetailID ", intCashierDetailID)
        objCommand.Parameters.AddWithValue("@CashierTranID ", intCashierTranID)
        objCommand.Parameters.AddWithValue("@TranType", strType)
        objCommand.Parameters.AddWithValue("@TranCount", intTranCount)
        objCommand.Parameters.AddWithValue("@TranAmount", mnyAmount)
        objCommand.Parameters.AddWithValue("@FASVerifyUser", strFASVerifyUser)
        objCommand.Parameters.AddWithValue("@FASVerifyDate", dtFASVerifyDate)
        objCommand.Parameters.AddWithValue("@SDBVerifyUser", strSDBVerifyUser)
        objCommand.Parameters.AddWithValue("@SDBVerifyDate", dtSDBVerifyDate)
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '    '***********************************************
        '    '******************* ACTION CODE ***************
        '    '***********************************************
        'objCashierDetData = New clsCashierDetail
        'Call objCashierDetData.subCashierDetAction( strAction:="ADD", _
        'intCashierTranID:=7, strType:="NONE", intTranCount:=0, mnyAmount:=0)
        '    '***********************************************
        '    '***********************************************

    End Sub

End Class

