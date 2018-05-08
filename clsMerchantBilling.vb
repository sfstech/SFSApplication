Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subMercBillSelect
'*** B. subMercBillAction
'****************************************
'****************************************
Public Class clsMerchantBilling
    Dim objConnection As New SqlConnection _
       (frmMainMenu.strSFSCon)

    '*** A. subMercBillSelect
    Public Sub subMercBillSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal strMerchantNumFull As String, _
                                ByVal intProcessingMonth As Integer, ByVal intProcessingYear As Integer, ByVal strFeeType As String, _
                                ByVal dblFeeRate As Double, ByVal dblFeeAmt As Double, ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim DS As System.Data.DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procMercBilling"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strMerchantNumFull)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ProcessingMonth", intProcessingMonth)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ProcessingYear", intProcessingYear)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FeeType", strFeeType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@dblFeeRate", dblFeeRate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@dblFeeAmt", dblFeeAmt)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsMercBill")

        'Close the database connection...
        objConnection.Close()

        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmCashierActivity-ctrlNote"
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.DataSource = objDataSet
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.DataMember = "dsNote"


                'Setup alternating rows style...
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                'frmJV.CtrlNoteDisplay1.Width = 650
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(0).Visible = False
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(1).Width = 55
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(2).Visible = False
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(3).Visible = False
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(4).Width = 230
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(5).Width = 50
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(6).Width = 80


                'Setup column headers...
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(1).HeaderText = "Type"
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(4).HeaderText = "Note"
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(5).HeaderText = "User Name"
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(6).HeaderText = "Date"
           
        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objMercBillData = New clsMercBill
        'Call objMercBillData.subMercBillSelect(strBindTarget:="NONE", strAction:="NONE", intNoteID:=0, strNoteType:="NONE", strModule:="NONE", intModuleID:=0, strNoteDesc:="NONE", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subMercBillAction
    Public Sub subMercBillAction(ByVal strAction As String, ByVal strMerchantNumFull As String, _
                                ByVal intProcessingMonth As Integer, ByVal intProcessingYear As Integer, ByVal strFeeType As String, _
                                ByVal dblFeeRate As Double, ByVal dblFeeAmt As Double, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procMercBilling"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@MerchantNumFull", strMerchantNumFull)
        objCommand.Parameters.AddWithValue("@ProcessingMonth", intProcessingMonth)
        objCommand.Parameters.AddWithValue("@ProcessingYear", intProcessingYear)
        objCommand.Parameters.AddWithValue("@FeeType", strFeeType)
        objCommand.Parameters.AddWithValue("@FeeRate", dblFeeRate)
        objCommand.Parameters.AddWithValue("@FeeAmt", dblFeeAmt)
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

        SearchMenu.intRetExists = Convert.ToInt32(retValParam.Value)
        frmExport.intRetExists = Convert.ToInt32(retValParam.Value)
        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objMercBillAction = New clsMerchantBilling
        'Call objMercBillAction.subsubMercBillAction(strAction:="ADD", strMerchantNumFull:="NONE", intProcessingMonth:=0, intProcessingYear:=0, strFeeType:="NONE", dblFeeRate:=0.0, dblFeeAmt:=0.0, strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub
End Class
