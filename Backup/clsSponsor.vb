Imports System.Data
Imports System.Data.SqlClient


Public Class clsSponsor
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subsponsorSelect
    Public Sub subSponsorSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intSponsorID As Integer, _
    ByVal strSponsorName As String, ByVal strAddressAttn As String, ByVal strAddress1 As String, ByVal strAddress2 As String, _
    ByVal strCity As String, ByVal strState As String, ByVal strZip As String, ByVal strCountry As String, ByVal intContactID As Integer, _
    ByVal strPhone As String, ByVal strFax As String, ByVal strBudgetNumber As String, ByVal strRevCode As String, ByVal strStatus As String, ByVal intSDBDisbMethod As Integer)
        ', ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procSponsor"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure


        'Set the paramaters...
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SponsorID", intSponsorID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SponsorName", strSponsorName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AddressAttn", strAddressAttn)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Address1", strAddress1)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Address2", strAddress2)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@City", strCity)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@State", strState)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Zip", strZip)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Country", strCity)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ContactID", intContactID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Phone", strPhone)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Fax", strFax)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RevCode", strRevCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Status", strStatus)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBDisbMethod", intSDBDisbMethod)
        'objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        'objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsSponsor")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsSponsor"

                'Setup form title...
                frmSearch.Text = "Sponsor Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Width = 185
                frmSearch.grdDataList.Columns(2).Width = 40
                frmSearch.grdDataList.Columns(3).Width = 140
                frmSearch.grdDataList.Columns(4).Width = 140
                frmSearch.grdDataList.Columns(5).Width = 75
                frmSearch.grdDataList.Columns(6).Width = 35
                frmSearch.grdDataList.Columns(7).Width = 70
                frmSearch.grdDataList.Columns(8).Width = 45
                frmSearch.grdDataList.Columns(9).Width = 55
                frmSearch.grdDataList.Columns(10).Width = 100
                frmSearch.grdDataList.Columns(11).Width = 100
                frmSearch.grdDataList.Columns(12).Width = 55
                '        'Setup column headers...
                frmSearch.grdDataList.Columns(1).HeaderText = "Sponsor Name"
                frmSearch.grdDataList.Columns(2).HeaderText = "Attn"
            Case "frmSearch-Recon"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsSponsor"

                'Setup form title...
                frmSearch.Text = "Sponsor Reconciliation Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Width = 185
                frmSearch.grdDataList.Columns(1).Width = 85
                'Setup column headers...
                frmSearch.grdDataList.Columns(0).HeaderText = "Sponsor Name"
                frmSearch.grdDataList.Columns(1).HeaderText = "Budget"
            Case "frmMainFields"
                frmMainMenu.intGlobSponsorID = objDataSet.Tables(0).Rows(0).Item(0)
                frmMainMenu.strGlobSponsorName = objDataSet.Tables(0).Rows(0).Item(1)
                frmMainMenu.strGlobSponsorBudget = objDataSet.Tables(0).Rows(0).Item(12)
                frmMainMenu.strGlobSponsorRevCode = objDataSet.Tables(0).Rows(0).Item(13)
                frmMainMenu.intGlobSponsorSDBDisbMethod = objDataSet.Tables(0).Rows(0).Item(15)
                ' MsgBox(" I'm Here - cls sponsor")
        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objsponsorData = New clsSponsor
        'Call objsponsorData.subsponsorSelect(strBindTarget:="frmSearch", ByVal strAction As String, ByVal intSponsorID As Integer, _
        'ByVal strSponsorName As String, ByVal strAddressAttn As String, ByVal strAddress1 As String, ByVal strAddress2 As String, _
        'ByVal strCity As String, ByVal strState As String, ByVal strZip As String, ByVal strCountry As String, ByVal intContactID As Integer, _
        'ByVal strPhone As String, ByVal strFax As String, ByVal strBudgetNumber As String, strRevCode As String, strStatus As String)
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subSponsorAction
    Public Sub subSponsorAction(ByVal strAction As String, ByVal intSponsorID As Integer, _
    ByVal strSponsorName As String, ByVal strAddressAttn As String, ByVal strAddress1 As String, ByVal strAddress2 As String, _
    ByVal strCity As String, ByVal strState As String, ByVal strZip As String, ByVal strCountry As String, ByVal intContactID As Integer, _
    ByVal strPhone As String, ByVal strFax As String, ByVal strBudgetNumber As String, ByVal strRevCode As String, ByVal strStatus As String, ByVal intSDBDisbMethod As Integer)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procSponsor"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters...
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@SponsorID", intSponsorID)
        objCommand.Parameters.AddWithValue("@SponsorName", strSponsorName)
        objCommand.Parameters.AddWithValue("@AddressAttn", strAddressAttn)
        objCommand.Parameters.AddWithValue("@Address1", strAddress1)
        objCommand.Parameters.AddWithValue("@Address2", strAddress2)
        objCommand.Parameters.AddWithValue("@City", strCity)
        objCommand.Parameters.AddWithValue("@State", strState)
        objCommand.Parameters.AddWithValue("@Zip", strZip)
        objCommand.Parameters.AddWithValue("@Country", strCountry)
        objCommand.Parameters.AddWithValue("@ContactID", intContactID)
        objCommand.Parameters.AddWithValue("@Phone", strPhone)
        objCommand.Parameters.AddWithValue("@Fax", strFax)
        objCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objCommand.Parameters.AddWithValue("@RevCode", strRevCode)
        objCommand.Parameters.AddWithValue("@Status", strStatus)
        objCommand.Parameters.AddWithValue("@SDBDisbMethod", intSDBDisbMethod)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objSponsorAction = New clsSponsor
        'Call objSponsorAction.subsponsorAction(ByVal strAction As String, ByVal intSponsorID As Integer, _
        'ByVal strSponsorName As String, ByVal strAddressAttn As String, ByVal strAddress1 As String, ByVal strAddress2 As String, _
        'ByVal strCity As String, ByVal strState As String, ByVal strZip As String, ByVal strCountry As String, ByVal intContactID As Integer, _
        'ByVal strPhone As String, ByVal strFax As String, ByVal strBudgetNumber As String)
        '***********************************************
        '***********************************************
    End Sub
End Class
