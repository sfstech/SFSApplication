Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************   
'*** A. subOACHGSelect    

'*** B. subOACHGAction

'****************************************
'****************************************
Public Class clsOACharges

    Dim objConnection As New SqlConnection _
     (frmMainMenu.strSFSCon)

    Public Sub subOACHGSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intOAStno As Integer, _
    ByVal strOACharge As String, ByVal dblOAChargeAmt As Double, ByVal dblOAPaidAmt As Double)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procOACharge"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure


        'Set the paramaters...
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OAStno", intOAStno)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OACharge", strOACharge)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OAChargeAmt", dblOAChargeAmt)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@OAPaidAmt", dblOAPaidAmt)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsOACharges")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsOACharges"

                'Setup form title...
                SearchMenu.Text = "Over Awards Charges Search"
            Case "frmSearch-OAtbl"
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsOACharges"
                SearchMenu.OADataTable = objDataSet.Tables("dsOACharges")
                'Setup alternating rows style...
                'frmSearch.grdDataList.AutoGenerateColumns = True
                'Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                'objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                'frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                'frmSearch.grdDataList.Columns(0).Visible = False
                'frmSearch.grdDataList.Columns(1).Width = 185
                'frmSearch.grdDataList.Columns(2).Width = 40
                'frmSearch.grdDataList.Columns(3).Width = 140
                'frmSearch.grdDataList.Columns(4).Width = 140
                'frmSearch.grdDataList.Columns(5).Width = 75
                'frmSearch.grdDataList.Columns(6).Width = 35
                'frmSearch.grdDataList.Columns(7).Width = 70
                'frmSearch.grdDataList.Columns(8).Width = 45
                'frmSearch.grdDataList.Columns(9).Width = 55
                'frmSearch.grdDataList.Columns(10).Width = 100
                'frmSearch.grdDataList.Columns(11).Width = 100
                'frmSearch.grdDataList.Columns(12).Width = 55
                ''        'Setup column headers...
                'frmSearch.grdDataList.Columns(1).HeaderText = "Sponsor Name"
                'frmSearch.grdDataList.Columns(2).HeaderText = "Attn"
                'Case "frmSearch-Recon"
                '    'Set the DataGridView properties to bind it to the data...
                '    frmSearch.grdDataList.DataSource = objDataSet
                '    frmSearch.grdDataList.DataMember = "dsSponsor"

                '    'Setup form title...
                '    frmSearch.Text = "Sponsor Reconciliation Search"

                '    'Setup alternating rows style...
                '    frmSearch.grdDataList.AutoGenerateColumns = True
                '    Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                '    objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                '    frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                '    'Setup column widths...
                '    frmSearch.grdDataList.Columns(0).Width = 185
                '    frmSearch.grdDataList.Columns(1).Width = 85
                '    'Setup column headers...
                '    frmSearch.grdDataList.Columns(0).HeaderText = "Sponsor Name"
                '    frmSearch.grdDataList.Columns(1).HeaderText = "Budget"
                'Case "frmMainFields"
                '    frmMainMenu.intGlobSponsorID = objDataSet.Tables(0).Rows(0).Item(0)
                '    frmMainMenu.strGlobSponsorName = objDataSet.Tables(0).Rows(0).Item(1)
                '    frmMainMenu.strGlobSponsorBudget = objDataSet.Tables(0).Rows(0).Item(12)
                '    frmMainMenu.strGlobSponsorRevCode = objDataSet.Tables(0).Rows(0).Item(13)
                '    frmMainMenu.intGlobSponsorSDBDisbMethod = objDataSet.Tables(0).Rows(0).Item(15)
                '    ' MsgBox(" I'm Here - cls sponsor")
        End Select




    End Sub


    Public Sub subOACHGAction(ByVal strAction As String, ByVal intOAStno As Integer, _
    ByVal strOACharge As String, ByVal dblOAChargeAmt As Double, ByVal dblOAPaidAmt As Double)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procOACharge"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters...
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@OAStno", intOAStno)
        objCommand.Parameters.AddWithValue("@OACharge", strOACharge)
        objCommand.Parameters.AddWithValue("@OAChargeAmt", dblOAChargeAmt)
        objCommand.Parameters.AddWithValue("@OAPaidAmt", dblOAPaidAmt)

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
