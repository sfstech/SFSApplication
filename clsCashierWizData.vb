Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subCashierDetSelect
'*** B. subCashierDetAction
'****************************************
'****************************************

Public Class clsCashierWizData
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)


    '*** A. subCashierSelect
    Public Sub subCashierWizDataSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intCashierID As Integer, _
                                   ByVal strWizType As String, ByVal mnyAmount As Double, ByVal intSequence As Integer)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procCashierWizData"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CashierID ", intCashierID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@WizType ", strWizType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", mnyAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Sequence ", intSequence)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsCashierWiz")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmCashierBal-dtChk"
                frmCashierBalancing.dtChk = objDataSet.Tables("dsCashierWiz")
                'Set the DataGridView properties to bind it to the Check data...
                frmCashierBalCheckWizard.grdCCheckAmounts.DataSource = objDataSet
                frmCashierBalCheckWizard.grdCCheckAmounts.DataMember = "dsCashierWiz"
                frmCashierBalCheckWizard.grdCCheckAmounts.EditMode = DataGridViewEditMode.EditOnEnter
            Case "frmCashierBal-dtCT"
                frmCashierBalancing.dtCT = objDataSet.Tables("dsCashierWiz")
                'Set the DataGridView properties to bind it to the CT data...
                frmCashierBalCTWizard.grdCTAmounts.DataSource = objDataSet
                frmCashierBalCTWizard.grdCTAmounts.DataMember = "dsCashierWiz"
                frmCashierBalCTWizard.grdCTAmounts.EditMode = DataGridViewEditMode.EditOnEnter
            Case "frmCashierBal-dtCA"
                frmCashierBalancing.dtCA = objDataSet.Tables(0)
                'There is no  DataGridView in the Balancing Cash Wizard...
           
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
    Public Sub subCashierWizAction(ByVal strAction As String, ByVal intCashierID As Integer, _
                                   ByVal strWizType As String, ByVal mnyAmount As Double, ByVal intSequence As Integer)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procCashierWizData"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@CashierID ", intCashierID)
        objCommand.Parameters.AddWithValue("@WizType ", strWizType)
        objCommand.Parameters.AddWithValue("@Amount", mnyAmount)
        objCommand.Parameters.AddWithValue("@Sequence ", intSequence)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '    '***********************************************
        '    '******************* ACTION CODE ***************
        '    '***********************************************
        'objCashierWizData = New clsCashierWizData
        'Call objCashierWizData.subCashierWizAction(strAction:="ADD-WIZ-ITEM", intCashierID:=frmCashierBalancing.intCashierRecPtr, _
        '        strWizType:="CK", mnyAmount:=grdCCheckAmounts.Rows(intRowIdx).Cells(0).Value, intSequence:=intRowIdx)
        '    '***********************************************
        '    '***********************************************

    End Sub
End Class
