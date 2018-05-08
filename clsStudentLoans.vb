'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subStudentLoanSelect
'*** B. subStudentLoanAction
'*** C. subStudentLoanReload
'****************************************
'****************************************
Public Class clsStudentLoans

    Dim objConnection As New SqlConnection _
       (frmMainMenu.strSFSCon)

    '*** A. subStudentLoanSelect
    Public Sub subStudentLoanSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intStno As Integer, _
                ByVal strQtr As String, ByVal intYear As Integer, ByVal dblAuthAmt As Double, ByVal strBudgetNbr As String, _
                ByVal strType As String, ByVal dblPmtAmt As Double)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procStudentLoan"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Stno", intStno)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Qtr", strQtr)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Year", intYear)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AuthAmt", dblAuthAmt)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetNbr", strBudgetNbr)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Type", strType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PmtAmt", dblPmtAmt)
        'objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        'objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportDate", dtImportDate)
        'objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportUser", strImportUser)


        objDataAdapter.SelectCommand.CommandTimeout = 600
        'Open the database connection...
        objConnection.Open()

        Cursor.Current = Cursors.WaitCursor

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsStdLoan")

        Cursor.Current = Cursors.Arrow

        frmReconMatch.ScholDataTable = objDataSet.Tables("dsStdLoan")
        'Close the database connection...
        objConnection.Close()

        frmReconMatch.grdDataSets.DataSource = objDataSet
        frmReconMatch.grdDataSets.DataMember = "dsStdLoan"

        'Setup form title...
        'frmReconMatch.Text = "Select Application"   !!!  -do we need this yet?

        'Setup alternating rows style...
        frmReconMatch.grdDataSets.AutoGenerateColumns = True
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        frmReconMatch.grdDataSets.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        frmReconMatch.grdDataSets.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Select Case strAction
            Case "STL-AUTH-FAS"

                'Setup column widths...
                frmReconMatch.grdDataSets.Columns(0).Visible = True
                frmReconMatch.grdDataSets.Columns(1).Visible = True
                frmReconMatch.grdDataSets.Columns(2).Visible = True
                frmReconMatch.grdDataSets.Columns(2).Width = 100
                'frmReconMatch.grdDataSets.Columns(3).Width = 100

                'Setup column headers...
                frmReconMatch.grdDataSets.Columns(0).HeaderText = "Stno"
                frmReconMatch.grdDataSets.Columns(0).DefaultCellStyle.Format = "0000000"
                frmReconMatch.grdDataSets.Columns(1).HeaderText = "Auth" & " Amt"
                frmReconMatch.grdDataSets.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(1).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(2).HeaderText = "Disb" & " Amt"
                frmReconMatch.grdDataSets.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(2).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(3).HeaderText = "Undisbursed Amt"
                frmReconMatch.grdDataSets.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(3).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(3).Width = 180
                'frmReconMatch.grdDataSets.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'frmReconMatch.grdDataSets.Columns(4).HeaderText = ""        ' strDataSet1 & " ADJ Amt"
                'frmReconMatch.grdDataSets.Columns(4).DefaultCellStyle.Format = "c"


        End Select
        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objSTLData = New clsStudentLoans
        'Call objSTLData.subStudentLoanSelect(strBindTarget:=" ", strAction:="STL-SDB-FAS", intStno:=0, strQtr:=cboQtr.Text, _
        'intYear:=CInt(cboYear.Text), dblAuthAmt:=0.0, strBudgetNbr:=Me.cboBudget.Text, strType:="STL")
        '***********************************************
        '***********************************************

    End Sub

    '*** A. subStudentLoanAction
    Public Sub subStudentLoanAction(ByVal strAction As String, ByVal intStno As Integer, _
                ByVal strQtr As String, ByVal intYear As Integer, ByVal dblAuthAmt As Double, ByVal strBudgetNbr As String, _
                ByVal strType As String, ByVal dblPmtAmt As Double)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procStudentLoan"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@Stno", intStno)
        objCommand.Parameters.AddWithValue("@Qtr", strQtr)
        objCommand.Parameters.AddWithValue("@Year", intYear)
        objCommand.Parameters.AddWithValue("@AuthAmt", dblAuthAmt)
        objCommand.Parameters.AddWithValue("@BudgetNbr", strBudgetNbr)
        objCommand.Parameters.AddWithValue("@Type", strType)
        objCommand.Parameters.AddWithValue("@PmtAmt", dblPmtAmt)

        'Create a SqlParameter object to hold the RETURN value, set the direction to ReturnValue and add to parameters
        Dim retValParam As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        retValParam.Direction = ParameterDirection.ReturnValue
        objCommand.Parameters.Add(retValParam)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        frmReconMatch.intRetExists = Convert.ToInt32(retValParam.Value)

        'Close the database connection...
        objConnection.Close()

    End Sub

End Class
