Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subBofASelect
'*** B. subBofAAction
'*** C. fncDateLookupAction
'*** D. subUSbankSelect
'*************************************** *
'****************************************

Public Class clsBankData
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subBofASelect
    ''' <summary>
    ''' procBankData
    ''' </summary>
    Public Sub subBofASelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal dtBankDate As Date, ByVal intAcctNum As Integer, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procBankData"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankDate", dtBankDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AcctNum", intAcctNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsBofAData")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsBofAData"

                'Setup form title...
                SearchMenu.Text = "Bank of America Data Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 100
                SearchMenu.grdDataList.Columns(1).Width = 100
                SearchMenu.grdDataList.Columns(2).Width = 100

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Bank Date"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Imported By"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Imported On"
            Case "frmBankData"
                'Set the DataGridView properties to bind it to the data...
                frmBankData.DataGridView1.DataSource = objDataSet
                frmBankData.DataGridView1.DataMember = "dsBofAData"

                'Setup form title...
                frmBankData.Text = "Bank of America Data Search"

                'Setup alternating rows style...
                frmBankData.DataGridView1.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmBankData.DataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmBankData.DataGridView1.Columns(0).Visible = False
                frmBankData.DataGridView1.Columns(1).Width = 50
                frmBankData.DataGridView1.Columns(2).Width = 50
                frmBankData.DataGridView1.Columns(3).Width = 200
                frmBankData.DataGridView1.Columns(4).Width = 50
                frmBankData.DataGridView1.Columns(5).Width = 100
                frmBankData.DataGridView1.Columns(6).Width = 100
                frmBankData.DataGridView1.Columns(7).Width = 320

                'Setup column headers...
                frmBankData.DataGridView1.Columns(1).HeaderText = "Type"
                frmBankData.DataGridView1.Columns(2).HeaderText = "BAI"
                frmBankData.DataGridView1.Columns(3).HeaderText = "Description"
                frmBankData.DataGridView1.Columns(4).HeaderText = "Amount"
                frmBankData.DataGridView1.Columns(5).HeaderText = "Customer Ref"
                frmBankData.DataGridView1.Columns(6).HeaderText = "Bank Ref"
                frmBankData.DataGridView1.Columns(7).HeaderText = "Bank Text"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objBankData = New clsBankData
        'Call objBankData.subBofASelect(strBindTarget:="frmSearch", strAction:="BofA-SELECT-ALL", dtBankDate:="01/01/1900",intAcctNum:="62045000", _
        'strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

    '*** C. fncDateLookupAction
    ''' <summary>
    ''' procDateCheck
    ''' </summary>
    Public Function fncDateLookupAction(ByVal strAction As String, ByVal dtLookupDate As Date, ByVal strLookupString As String) As Integer
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procDateCheck"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@LookupDate", dtLookupDate)
        objCommand.Parameters.AddWithValue("@LookupString", strLookupString)
        objCommand.Parameters.AddWithValue("@NumOfRows", 0)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        Dim intCount As Integer = objCommand.ExecuteScalar()

        'Close the database connection...
        objConnection.Close()

        Return intCount
        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objBankData = New clsBankData
        'Call objBankData.fncDateLookupAction(strAction:="BofA-BANK-IMPORT-CHECK", dtLookupDate:="01/01/1900", strLookupString:="NONE")
        '***********************************************
        '***********************************************
    End Function

    '*** D. subUSbankSelect
    ''' <summary>
    ''' procBankData
    ''' </summary>
    Public Sub subUSbankSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal dtBankDate As Date, ByVal intAcctNum As Integer, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procBankData"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BankDate", dtBankDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AcctNum", intAcctNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsUSbankData")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsUSbankData"

                'Setup form title...
                SearchMenu.Text = "US Bank Data Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 100
                SearchMenu.grdDataList.Columns(1).Width = 100
                SearchMenu.grdDataList.Columns(2).Width = 100

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Bank Date"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Imported By"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Imported On"
            Case "frmBankData"
                'Set the DataGridView properties to bind it to the data...
                frmBankData.DataGridView1.DataSource = objDataSet
                frmBankData.DataGridView1.DataMember = "dsUSbankData"

                'Setup form title...
                frmBankData.Text = "US Bank Data Search"

                'Setup alternating rows style...
                frmBankData.DataGridView1.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmBankData.DataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmBankData.DataGridView1.Columns(0).Visible = False
                frmBankData.DataGridView1.Columns(1).Width = 50
                frmBankData.DataGridView1.Columns(2).Width = 50
                frmBankData.DataGridView1.Columns(3).Width = 200
                frmBankData.DataGridView1.Columns(4).Width = 50
                frmBankData.DataGridView1.Columns(5).Width = 100
                frmBankData.DataGridView1.Columns(6).Width = 100
                frmBankData.DataGridView1.Columns(7).Width = 320

                'Setup column headers...
                frmBankData.DataGridView1.Columns(1).HeaderText = "Type"
                frmBankData.DataGridView1.Columns(2).HeaderText = "BAI"
                frmBankData.DataGridView1.Columns(3).HeaderText = "Description"
                frmBankData.DataGridView1.Columns(4).HeaderText = "Amount"
                frmBankData.DataGridView1.Columns(5).HeaderText = "Customer Ref"
                frmBankData.DataGridView1.Columns(6).HeaderText = "Bank Ref"
                frmBankData.DataGridView1.Columns(7).HeaderText = "Bank Text"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objBankData = New clsBankData
        'Call objBankData.subUSbankSelect(strBindTarget:="frmSearch", strAction:="USBANK-SELECT-ALL", dtBankDate:="01/01/1900",intAcctNum:="62045000", _
        'strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

End Class
