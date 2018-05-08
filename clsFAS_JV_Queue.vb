'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subJVQueueSelect
'*** B. subJVQueueAction
'****************************************
'****************************************

Public Class clsFAS_JV_Queue
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subJVQueueSelect
    Public Sub subJVQueueSelect(ByVal strBindTarget As String, ByVal strAction As String, _
                                ByVal intRowID As Integer, ByVal strJVDate As String, _
                                ByVal strBudgetNumber As String, ByVal strAccountCode As String, _
                                ByVal dblAmount As Double, ByVal strDescription As String, _
                                ByVal strModule As String, ByVal strCreateUser As String)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procFAS_JV_Queue"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters...
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@JVDate", strJVDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AccountCode", strAccountCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Description", strDescription)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strModule)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsJVQueue")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmJV-Grid"
                'Set the DataGridView properties to bind it to the data...
                frmJV.grdDataList.DataSource = objDataSet
                frmJV.grdDataList.DataMember = "dsJVQueue"

                'Setup alternating rows style...
                frmJV.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmJV.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmJV.grdDataList.Columns(0).Visible = False
                frmJV.grdDataList.Columns(1).Width = 60
                frmJV.grdDataList.Columns(2).Width = 335
                frmJV.grdDataList.Columns(3).Width = 60
                frmJV.grdDataList.Columns(4).Width = 60
                frmJV.grdDataList.Columns(5).Width = 60
                frmJV.grdDataList.Columns(6).Width = 60
                frmJV.grdDataList.Columns(7).Width = 60

                'Setup column headers...
                frmJV.grdDataList.Columns(1).HeaderText = "Date"
                frmJV.grdDataList.Columns(2).HeaderText = "Description"
                frmJV.grdDataList.Columns(3).HeaderText = "Budget"
                frmJV.grdDataList.Columns(4).HeaderText = "Account"
                frmJV.grdDataList.Columns(5).HeaderText = "Amount"
                frmJV.grdDataList.Columns(6).HeaderText = "Module"
                frmJV.grdDataList.Columns(7).HeaderText = "CreateUser"

            Case "frmJV"

                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsJVQueue")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsJVQueue"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmExport.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmJV.txtCount.DataBindings.Clear()
                frmJV.txtTotal.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmJV.txtCount.DataBindings.Add("text", objDataView, "TotalCount")
                frmJV.txtTotal.DataBindings.Add("text", objDataView, "TotalAmount")

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objJVQueueData = New clsFAS_JV_Queue
        'Call objJVQueueData.subJVQueueSelect(strBindTarget:="frmJV-Grid", strAction:="SELECT-BY-CREATEUSER", _
        'intRowID:=0, strJVDate:="NONE",strBudgetNumber:="NONE", strAccountCode:="NONE", _
        'dblAmount:=0,strDescription:="NONE",strModule:="NONE",strCreateUser:=SystemInformation.UserName)
        '***********************************************
        '***********************************************

    End Sub

    '*** B. subJVQueueAction
    Public Sub subJVQueueAction(ByVal strAction As String, _
                                ByVal intRowID As Integer, ByVal strJVDate As String, _
                                ByVal strBudgetNumber As String, ByVal strAccountCode As String, _
                                ByVal dblAmount As Double, ByVal strDescription As String, _
                                ByVal strModule As String, ByVal strCreateUser As String)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procFAS_JV_Queue"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@JVDate", strJVDate)
        objCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objCommand.Parameters.AddWithValue("@AccountCode", strAccountCode)
        objCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objCommand.Parameters.AddWithValue("@Description", strDescription)
        objCommand.Parameters.AddWithValue("@Module", strModule)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objJVQueueData = New clsFAS_JV_Queue
        'Call objJVQueueData.subJVQueueAction(strAction:="ADD", _
        'intRowID:=0, strJVDate:=Me.txtJVDate.Text, strBudgetNumber:=Me.txtBudget.Text, strAccountCode:=Me.txtAccountCode.Text, _
        'dblAmount:=Me.txtAmount.Text, strDescription:=Me.txtDescription.Text, strModule:=Me.txtModule.Text, strCreateUser:=Me.txtCreateUser.Text)
        '***********************************************
        '***********************************************

    End Sub

End Class
