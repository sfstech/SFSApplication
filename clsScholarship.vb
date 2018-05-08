'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subScholarshipSelect
'*** B. subScholarshipAction
'*** C. subScholarshipReload
'****************************************
'****************************************

Public Class clsScholarship

    Dim objConnection As New SqlConnection _
       (frmMainMenu.strSFSCon)

    '*** A. subScholarshipSelect
    ''' <summary>
    ''' procScholarship
    ''' </summary>
    Public Sub subScholarshipSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intScholarshipID As Integer, _
                ByVal intSponsorID As Integer, ByVal strStno As String, ByVal intContractID As Integer, ByVal strQtr As String, _
                ByVal strYear As String, ByVal dtScholarshipDate As Date, ByVal dblExpenses As Double, ByVal dblRevenue As Double, _
                ByVal dblBalance As Double, ByVal strStatus As String, ByVal strTranDescr As String, _
                ByVal strSource As String, ByVal strImportFileName As String, ByVal dtImportDate As Date, ByVal strImportUser As String, _
                ByVal strStudentName As String)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procScholarship"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ScholarshipID ", intScholarshipID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SponsorID", intSponsorID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Stno", strStno)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ContractID", intContractID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Qtr", strQtr)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Year", strYear)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ScholarshipDate", dtScholarshipDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Expenses", dblExpenses)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Revenue", dblRevenue)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Balance", dblBalance)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Status", strStatus)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranDescr", strTranDescr)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Source", strSource)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportDate", dtImportDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StudentName", strStudentName)

        objDataAdapter.SelectCommand.CommandTimeout = 600
        'Open the database connection...
        objConnection.Open()

        Cursor.Current = Cursors.WaitCursor

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsScholarship")

        Cursor.Current = Cursors.Arrow

        frmReconMatch.ScholDataTable = objDataSet.Tables("dsScholarship")
        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmScholarship"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....

                objDataAdapter.Fill(objDataSet, "dsScholarship")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsScholarship"))

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

            Case "frmScholarship-grdHistory"

                'Set the DataGridView properties to bind it to the data...
                frmScholarship.grdHistory.DataSource = objDataSet
                frmScholarship.grdHistory.DataMember = "dsScholarship"

                'Setup alternating rows style...
                frmScholarship.grdHistory.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmScholarship.grdHistory.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmScholarship.grdHistory.Columns(0).Visible = False
                frmScholarship.grdHistory.Columns(1).Visible = False
                frmScholarship.grdHistory.Columns(2).Visible = False
                frmScholarship.grdHistory.Columns(2).Visible = False
                frmScholarship.grdHistory.Columns(3).Visible = False
                frmScholarship.grdHistory.Columns(4).Width = 130
                frmScholarship.grdHistory.Columns(5).Width = 60
                frmScholarship.grdHistory.Columns(6).Width = 60
                frmScholarship.grdHistory.Columns(7).Width = 155   '255
                frmScholarship.grdHistory.Columns(8).Width = 50

                frmScholarship.grdHistory.Columns(9).DefaultCellStyle.Format = "c"
                frmScholarship.grdHistory.Columns(1).DefaultCellStyle.Format = "0000000"

            Case "frmSearch-Schol-Detail"
                'Set the DataGridView properties to bind it to the data...
          
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsScholarship"

                'Setup form title...
                SearchMenu.Text = "Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).DefaultCellStyle.Format = "0000000"
                SearchMenu.grdDataList.Columns(1).Width = 50
                SearchMenu.grdDataList.Columns(2).Width = 65
                SearchMenu.grdDataList.Columns(2).Visible = False
                SearchMenu.grdDataList.Columns(3).Width = 180
                SearchMenu.grdDataList.Columns(4).Width = 65
                SearchMenu.grdDataList.Columns(5).Width = 30
                SearchMenu.grdDataList.Columns(6).Width = 40
                SearchMenu.grdDataList.Columns(7).Width = 85 '125

                SearchMenu.grdDataList.Columns(8).Width = 50

                SearchMenu.grdDataList.Columns(9).DefaultCellStyle.Format = "c"
                'jjea changed column name to Revenue from Expenses
                SearchMenu.grdDataList.Columns(9).HeaderText = "Revenue"
                'row count
                SearchMenu.intRecCount = SearchMenu.grdDataList.RowCount

            Case "frmSearch-RoomBoard-Update"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsScholarship"

                'Setup form title...
                SearchMenu.Text = "Room and Board Update"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 65 ' Stno
                SearchMenu.grdDataList.Columns(1).Width = 65
                SearchMenu.grdDataList.Columns(2).Width = 30
                SearchMenu.grdDataList.Columns(3).Width = 37
                SearchMenu.grdDataList.Columns(4).Width = 70
                SearchMenu.grdDataList.Columns(5).Width = 100
                SearchMenu.grdDataList.Columns(6).Width = 65 ' amount
                SearchMenu.grdDataList.Columns(7).Width = 65
                SearchMenu.grdDataList.Columns(8).Width = 65
                SearchMenu.grdDataList.Columns(9).Width = 65

                SearchMenu.grdDataList.Columns(0).DefaultCellStyle.Format = "0000000"
                SearchMenu.grdDataList.Columns(6).DefaultCellStyle.Format = "c"

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
            Case "frmImport-grid"
                frmImport.DataGridView1.DataSource = objDataSet
                frmImport.DataGridView1.DataMember = "dsScholarship"
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


    '*** B. subScholarshipAction
    ''' <summary>
    ''' procScholarship
    ''' </summary>
    Public Sub subScholarshipAction(ByVal strAction As String, ByVal intScholarshipID As Integer, _
                ByVal intSponsorID As Integer, ByVal strStno As String, ByVal intContractID As Integer, ByVal strQtr As String, _
                ByVal strYear As String, ByVal dtScholarshipDate As Date, ByVal dblExpenses As Double, ByVal dblRevenue As Double, _
                ByVal dblBalance As Double, ByVal strStatus As String, ByVal strTranDescr As String, _
                ByVal strSource As String, ByVal strImportFileName As String, ByVal dtImportDate As Date, ByVal strImportUser As String, _
                ByVal strStudentName As String)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procScholarship"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@ScholarshipID ", intScholarshipID)
        objCommand.Parameters.AddWithValue("@SponsorID", intSponsorID)
        objCommand.Parameters.AddWithValue("@Stno", strStno)
        objCommand.Parameters.AddWithValue("@ContractID", intContractID)
        objCommand.Parameters.AddWithValue("@Qtr", strQtr)
        objCommand.Parameters.AddWithValue("@Year", strYear)
        objCommand.Parameters.AddWithValue("@ScholarshipDate", dtScholarshipDate)
        objCommand.Parameters.AddWithValue("@Expenses", dblExpenses)
        objCommand.Parameters.AddWithValue("@Revenue", dblRevenue)
        objCommand.Parameters.AddWithValue("@Balance", dblBalance)
        objCommand.Parameters.AddWithValue("@Status", strStatus)
        objCommand.Parameters.AddWithValue("@TranDescr", strTranDescr)
        objCommand.Parameters.AddWithValue("@Source", strSource)
        objCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objCommand.Parameters.AddWithValue("@ImportDate", dtImportDate)
        objCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objCommand.Parameters.AddWithValue("@StudentName", strStudentName)

        'Create a SqlParameter object to hold the RETURN value, set the direction to ReturnValue and add to parameters
        Dim retValParam As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        retValParam.Direction = ParameterDirection.ReturnValue
        objCommand.Parameters.Add(retValParam)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        frmScholarshipNew.intRetExists = Convert.ToInt32(retValParam.Value)

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

    '*** B. subScholarshipReload
    Public Sub subScholarshipReload()
        frmScholarship.MdiParent = frmMainMenu
        frmScholarship.Show()
        frmScholarship.txtExpenses.Text = Format(Val(frmScholarship.txtExpenses.Text), "c")
        frmScholarship.txtRevenue.Text = Format(Val(frmScholarship.txtRevenue.Text), "c")
        frmScholarship.txtBalance.Text = Format(Val(frmScholarship.txtBalance.Text), "c")
        frmScholarship.txtStno.Text = Format(Val(frmScholarship.txtStno.Text), "0######")
        frmScholarship.txtSSN.Text = Format(Val(frmScholarship.txtSSN.Text), "###-##-####")
    End Sub


End Class
