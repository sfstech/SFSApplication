Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subAdjustSelect    

'*** B. subAdjustAction

'****************************************
'****************************************

Public Class clsReconAdjust
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    ''*** A. subAdjustSelect
    Public Sub subAdjustSelect(ByVal strAction As String, ByVal strReconID As String, ByVal intDetRowID As Integer, ByVal strDataSet As String, _
                              ByVal intType As Integer, ByVal dtTranDate As Date, ByVal mnyTranAmt As Double, _
                              ByVal intTranRowId As Integer, ByVal dtAdjDate As Date, ByVal mnyAdjAmt As Double, ByVal strDescr As String, _
                              ByVal strStatus As String, ByVal intCategoryID As Integer, ByVal strClearNextMonthFlag As String, _
                              ByVal strCreateUser As String, ByVal dtCreateDate As Date)


        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "[procReconAdjust]"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ReconID", strReconID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DetRowID", intDetRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DataSet", strDataSet)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Type", intType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranDate", dtTranDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranAmt", mnyTranAmt)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranRowId", intTranRowId)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AdjDate", dtAdjDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AdjAmt", mnyAdjAmt)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Descr", strDescr)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Status", strStatus)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CategoryID", intCategoryID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ClearNextMonthFlag", strClearNextMonthFlag)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        'objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsReconAdjust")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct form...
        Select Case strAction
            Case "SELECT-ADJUST"
                'Set the DataGridView properties to bind it to the data...
                frmReconAdjust.grdDataAdjust.DataSource = objDataSet
                frmReconAdjust.grdDataAdjust.DataMember = "dsReconAdjust"

                'Setup form title...
                'frmReconAdjust.Text = "Select Application"   !!!  -do we need this yet?

                'Setup alternating rows style...
                frmReconAdjust.grdDataAdjust.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmReconAdjust.grdDataAdjust.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmReconAdjust.grdDataAdjust.Columns(0).Visible = False
                frmReconAdjust.grdDataAdjust.Columns(1).Width = 46
                frmReconAdjust.grdDataAdjust.Columns(2).Visible = False
                frmReconAdjust.grdDataAdjust.Columns(3).Width = 25
                frmReconAdjust.grdDataAdjust.Columns(4).Width = 25
                frmReconAdjust.grdDataAdjust.Columns(5).Width = 65
                frmReconAdjust.grdDataAdjust.Columns(6).Width = 75
                frmReconAdjust.grdDataAdjust.Columns(7).Width = 25
                frmReconAdjust.grdDataAdjust.Columns(8).Width = 75
                frmReconAdjust.grdDataAdjust.Columns(9).Width = 90
                frmReconAdjust.grdDataAdjust.Columns(10).Width = 75
                frmReconAdjust.grdDataAdjust.Columns(11).Width = 60
                frmReconAdjust.grdDataAdjust.Columns(12).Width = 65

                'Setup column headers...

                frmReconAdjust.grdDataAdjust.Columns(0).HeaderText = ""
                frmReconAdjust.grdDataAdjust.Columns(1).HeaderText = "Recon ID"
                frmReconAdjust.grdDataAdjust.Columns(2).HeaderText = ""
                frmReconAdjust.grdDataAdjust.Columns(3).HeaderText = "Dataset"
                frmReconAdjust.grdDataAdjust.Columns(4).HeaderText = "Type"
                frmReconAdjust.grdDataAdjust.Columns(5).HeaderText = "Tran Date"
                frmReconAdjust.grdDataAdjust.Columns(6).HeaderText = "Tran Amt"
                frmReconAdjust.grdDataAdjust.Columns(7).HeaderText = "Tran Row ID"
                frmReconAdjust.grdDataAdjust.Columns(8).HeaderText = "ADJ Date"
                frmReconAdjust.grdDataAdjust.Columns(9).HeaderText = "ADJ Amt"
                frmReconAdjust.grdDataAdjust.Columns(10).HeaderText = "Descr"
                frmReconAdjust.grdDataAdjust.Columns(11).HeaderText = "Create User"
                frmReconAdjust.grdDataAdjust.Columns(12).HeaderText = "Create Date"

                ' Set curency format
                frmReconAdjust.grdDataAdjust.Columns(6).DefaultCellStyle.Format = "c"
                frmReconAdjust.grdDataAdjust.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconAdjust.grdDataAdjust.Columns(9).DefaultCellStyle.Format = "c"
                frmReconAdjust.grdDataAdjust.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Case "SELECT-DETAIL-ADJUST"
                'Set the DataGridView properties to bind it to the data...
                frmReconDetail.grdDetAdj.DataSource = objDataSet
                frmReconDetail.grdDetAdj.DataMember = "dsReconAdjust"

                frmReconDetail.grdAdjDataTable = objDataSet.Tables("dsReconAdjust")

                'Setup form title...
                'frmReconAdjust.Text = "Select Application"   !!!  -do we need this yet?

                'Setup alternating rows style...
                frmReconDetail.grdDetAdj.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmReconDetail.grdDetAdj.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmReconDetail.grdDetAdj.Columns(0).Visible = False
                frmReconDetail.grdDetAdj.Columns(1).Width = 65
                frmReconDetail.grdDetAdj.Columns(2).Visible = False
                frmReconDetail.grdDetAdj.Columns(3).Visible = False
                frmReconDetail.grdDetAdj.Columns(4).Width = 200
                frmReconDetail.grdDetAdj.Columns(5).Visible = False
                frmReconDetail.grdDetAdj.Columns(6).Visible = False
                frmReconDetail.grdDetAdj.Columns(7).Visible = False
                frmReconDetail.grdDetAdj.Columns(8).Width = 55
                frmReconDetail.grdDetAdj.Columns(8).Width = 75
                frmReconDetail.grdDetAdj.Columns(10).Width = 75
                frmReconDetail.grdDetAdj.Columns(11).Width = 25
                frmReconDetail.grdDetAdj.Columns(12).Width = 75

                'Setup column headers...

                frmReconDetail.grdDetAdj.Columns(0).HeaderText = ""
                frmReconDetail.grdDetAdj.Columns(1).HeaderText = "Date Adjusted"
                frmReconDetail.grdDetAdj.Columns(2).HeaderText = "Recon ID"
                frmReconDetail.grdDetAdj.Columns(3).HeaderText = ""
                frmReconDetail.grdDetAdj.Columns(4).HeaderText = "Descr"
                frmReconDetail.grdDetAdj.Columns(5).HeaderText = "Tran Date"
                frmReconDetail.grdDetAdj.Columns(6).HeaderText = "Data Set"
                frmReconDetail.grdDetAdj.Columns(7).HeaderText = "Type"
                frmReconDetail.grdDetAdj.Columns(8).HeaderText = "Create User"
                frmReconDetail.grdDetAdj.Columns(9).HeaderText = "ADJ Amt"
                frmReconDetail.grdDetAdj.Columns(10).HeaderText = "Tran Amt"
                frmReconDetail.grdDetAdj.Columns(11).HeaderText = "Tran Row ID"
                frmReconDetail.grdDetAdj.Columns(12).HeaderText = "Create Date"
                'frmReconDetail.grdDetAdj.Columns(11).CellStyle.BackColor.
                'frmReconDetail.grdDetAdj.Columns(11).DefaultCellStyle
                ' Set curency format
                frmReconDetail.grdDetAdj.Columns(9).DefaultCellStyle.Format = "c"
                frmReconDetail.grdDetAdj.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconDetail.grdDetAdj.Columns(10).DefaultCellStyle.Format = "c"
                frmReconDetail.grdDetAdj.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                frmReconDetail.grdDetAdj.EditMode = DataGridViewEditMode.EditProgrammatically

            Case "SELECT-BEG-BAL-ADJUST"
                'Set the DataGridView properties to bind it to the data...
                frmReconItems.grdBegBalItems.DataSource = objDataSet
                frmReconItems.grdBegBalItems.DataMember = "dsReconAdjust"
                frmReconItems.grdBegBalDataTable = objDataSet.Tables("dsReconAdjust")

                'Setup form title...
                'frmReconAdjust.Text = "Select Application"   !!!  -do we need this yet?

                'Setup alternating rows style...
                frmReconItems.grdBegBalItems.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmReconItems.grdBegBalItems.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmReconItems.grdBegBalItems.Columns(0).Visible = False
                frmReconItems.grdBegBalItems.Columns(1).Width = 67
                frmReconItems.grdBegBalItems.Columns(2).Visible = False
                frmReconItems.grdBegBalItems.Columns(3).Visible = False
                frmReconItems.grdBegBalItems.Columns(4).Width = 197
                frmReconItems.grdBegBalItems.Columns(5).Width = 67
                frmReconItems.grdBegBalItems.Columns(6).Visible = False
                frmReconItems.grdBegBalItems.Columns(7).Visible = False
                frmReconItems.grdBegBalItems.Columns(8).Visible = False
                frmReconItems.grdBegBalItems.Columns(9).Width = 75
                frmReconItems.grdBegBalItems.Columns(10).Width = 75
                frmReconItems.grdBegBalItems.Columns(11).Width = 25
                frmReconItems.grdBegBalItems.Columns(12).Width = 75
                frmReconItems.grdBegBalItems.Columns(13).Width = 75
                frmReconItems.grdBegBalItems.Columns(14).Width = 75
                frmReconItems.grdBegBalItems.Columns(15).Width = 75
                'Setup column headers...

                frmReconItems.grdBegBalItems.Columns(0).HeaderText = ""
                frmReconItems.grdBegBalItems.Columns(1).HeaderText = "Tran Date"
                frmReconItems.grdBegBalItems.Columns(2).HeaderText = "Recon ID"
                frmReconItems.grdBegBalItems.Columns(3).HeaderText = ""
                frmReconItems.grdBegBalItems.Columns(4).HeaderText = "Description"
                frmReconItems.grdBegBalItems.Columns(5).HeaderText = "Clear Date"
                frmReconItems.grdBegBalItems.Columns(6).HeaderText = "Data Set"
                frmReconItems.grdBegBalItems.Columns(7).HeaderText = "Type"
                frmReconItems.grdBegBalItems.Columns(8).HeaderText = "Create User"
                frmReconItems.grdBegBalItems.Columns(9).HeaderText = "Variance Amt"
                frmReconItems.grdBegBalItems.Columns(10).HeaderText = "Adj Amt"
                frmReconItems.grdBegBalItems.Columns(11).HeaderText = "Tran Row ID"
                frmReconItems.grdBegBalItems.Columns(12).HeaderText = "Create Date"
                frmReconItems.grdBegBalItems.Columns(13).HeaderText = "Status"
                frmReconItems.grdBegBalItems.Columns(14).HeaderText = "CategoryID"
                frmReconItems.grdBegBalItems.Columns(15).HeaderText = "Clear Next Mth"
                'frmReconItems.grdBegBalItems.Columns(11).CellStyle.BackColor.
                'frmReconItems.grdBegBalItems.Columns(11).DefaultCellStyle
                ' Set curency format
                frmReconItems.grdBegBalItems.Columns(9).DefaultCellStyle.Format = "c"
                frmReconItems.grdBegBalItems.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconItems.grdBegBalItems.Columns(10).DefaultCellStyle.Format = "c"
                frmReconItems.grdBegBalItems.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                frmReconItems.grdBegBalItems.EditMode = DataGridViewEditMode.EditProgrammatically

            Case "SELECT-RECON-ITEMS-ADJUST"
                'Set the DataGridView properties to bind it to the data...
                frmReconItems.grdReconItems.DataSource = objDataSet
                frmReconItems.grdReconItems.DataMember = "dsReconAdjust"

                frmReconItems.grdItemDataTable = objDataSet.Tables("dsReconAdjust")
                'Setup form title...
                'frmReconAdjust.Text = "Select Application"   !!!  -do we need this yet?

                'Setup alternating rows style...
                frmReconItems.grdReconItems.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmReconItems.grdReconItems.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmReconItems.grdReconItems.Columns(0).Visible = False
                frmReconItems.grdReconItems.Columns(1).Width = 67
                frmReconItems.grdReconItems.Columns(2).Visible = False
                frmReconItems.grdReconItems.Columns(3).Visible = False
                frmReconItems.grdReconItems.Columns(4).Width = 197
                frmReconItems.grdReconItems.Columns(5).Width = 67
                frmReconItems.grdReconItems.Columns(6).Visible = False
                frmReconItems.grdReconItems.Columns(7).Visible = False
                frmReconItems.grdReconItems.Columns(8).Visible = False
                frmReconItems.grdReconItems.Columns(9).Width = 75
                frmReconItems.grdReconItems.Columns(10).Width = 75
                frmReconItems.grdReconItems.Columns(11).Width = 25
                frmReconItems.grdReconItems.Columns(12).Width = 75
                frmReconItems.grdReconItems.Columns(13).Width = 75
                frmReconItems.grdReconItems.Columns(14).Width = 75
                frmReconItems.grdReconItems.Columns(15).Width = 75
                'Setup column headers...

                frmReconItems.grdReconItems.Columns(0).HeaderText = ""
                frmReconItems.grdReconItems.Columns(1).HeaderText = "Tran Date"
                frmReconItems.grdReconItems.Columns(2).HeaderText = "Recon ID"
                frmReconItems.grdReconItems.Columns(3).HeaderText = ""
                frmReconItems.grdReconItems.Columns(4).HeaderText = "Description"
                frmReconItems.grdReconItems.Columns(5).HeaderText = "Clear Date"
                frmReconItems.grdReconItems.Columns(6).HeaderText = "Data Set"
                frmReconItems.grdReconItems.Columns(7).HeaderText = "Type"
                frmReconItems.grdReconItems.Columns(8).HeaderText = "Create User"
                frmReconItems.grdReconItems.Columns(9).HeaderText = "Variance Amt"
                frmReconItems.grdReconItems.Columns(10).HeaderText = "Adj Amt"
                frmReconItems.grdReconItems.Columns(11).HeaderText = "Tran Row ID"
                frmReconItems.grdReconItems.Columns(12).HeaderText = "Create Date"
                frmReconItems.grdReconItems.Columns(13).HeaderText = "Status"
                frmReconItems.grdReconItems.Columns(14).HeaderText = "CategoryID"
                frmReconItems.grdReconItems.Columns(15).HeaderText = "Clear Next Mth"


                'frmReconItems.grdReconItems.Columns(11).CellStyle.BackColor.
                'frmReconItems.grdReconItems.Columns(11).DefaultCellStyle
                ' Set curency format
                frmReconItems.grdReconItems.Columns(9).DefaultCellStyle.Format = "c"
                frmReconItems.grdReconItems.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconItems.grdReconItems.Columns(10).DefaultCellStyle.Format = "c"
                frmReconItems.grdReconItems.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                frmReconItems.grdReconItems.EditMode = DataGridViewEditMode.EditProgrammatically

            Case "SELECT-DETAIL-ADJUST-STNO"
                'Set the DataGridView properties to bind it to the data...
                frmReconItems.grdReconItems.DataSource = objDataSet
                frmReconItems.grdReconItems.DataMember = "dsReconAdjust"
                frmReconItems.grdItemDataTable = objDataSet.Tables("dsReconAdjust")
                'Setup alternating rows style...
                frmReconItems.grdReconItems.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmReconItems.grdReconItems.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmReconItems.grdReconItems.Columns(0).Width = 70
                frmReconItems.grdReconItems.Columns(1).Width = 55
                frmReconItems.grdReconItems.Columns(2).Width = 30
                frmReconItems.grdReconItems.Columns(3).Width = 40
                frmReconItems.grdReconItems.Columns(4).Width = 40
                frmReconItems.grdReconItems.Columns(5).Width = 90
                frmReconItems.grdReconItems.Columns(6).Width = 80
                frmReconItems.grdReconItems.Columns(7).Width = 80
                frmReconItems.grdReconItems.Columns(8).Visible = False
                frmReconItems.grdReconItems.Columns(9).Visible = False
                frmReconItems.grdReconItems.Columns(10).Visible = False
                frmReconItems.grdReconItems.Columns(11).Width = 55
                frmReconItems.grdReconItems.Columns(12).Width = 150
                'Setup column headers...
                frmReconItems.grdReconItems.Columns(0).HeaderText = "Date"
                frmReconItems.grdReconItems.Columns(1).HeaderText = "Stno"
                frmReconItems.grdReconItems.Columns(2).HeaderText = "Qtr"
                frmReconItems.grdReconItems.Columns(3).HeaderText = "Year"
                frmReconItems.grdReconItems.Columns(4).HeaderText = "Tran Type"
                frmReconItems.grdReconItems.Columns(5).HeaderText = "Decription"
                frmReconItems.grdReconItems.Columns(6).HeaderText = "Amount"
                frmReconItems.grdReconItems.Columns(7).HeaderText = "Contract"
                frmReconItems.grdReconItems.Columns(8).HeaderText = "ScholarshipID"
                frmReconItems.grdReconItems.Columns(9).HeaderText = "Scholarship Details RowID"
                frmReconItems.grdReconItems.Columns(10).HeaderText = "Scholarship Details TranRowID"
                frmReconItems.grdReconItems.Columns(11).HeaderText = "User"
                frmReconItems.grdReconItems.Columns(12).HeaderText = "Comment or File"
                ' Set curency format
                frmReconItems.grdReconItems.Columns(6).DefaultCellStyle.Format = "c"
                frmReconItems.grdReconItems.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                frmReconItems.grdReconItems.EditMode = DataGridViewEditMode.EditProgrammatically
            Case "SELECT-DET-BEG-BAL-ADJUST-STNO", "SELECT-DET-BEG-BAL-ADJ-STNOALL"
                'Set the DataGridView properties to bind it to the data...
                frmReconItems.grdBegBalItems.DataSource = objDataSet
                frmReconItems.grdBegBalItems.DataMember = "dsReconAdjust"
                frmReconItems.grdBegBalDataTable = objDataSet.Tables("dsReconAdjust")

                'Setup alternating rows style...
                frmReconItems.grdBegBalItems.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmReconItems.grdBegBalItems.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmReconItems.grdBegBalItems.Columns(0).Width = 70
                frmReconItems.grdBegBalItems.Columns(1).Width = 55
                frmReconItems.grdBegBalItems.Columns(2).Width = 30
                frmReconItems.grdBegBalItems.Columns(3).Width = 40
                frmReconItems.grdBegBalItems.Columns(4).Width = 40
                frmReconItems.grdBegBalItems.Columns(5).Width = 90
                frmReconItems.grdBegBalItems.Columns(6).Width = 80
                frmReconItems.grdBegBalItems.Columns(7).Width = 80
                frmReconItems.grdBegBalItems.Columns(8).Visible = False
                frmReconItems.grdBegBalItems.Columns(9).Visible = False
                frmReconItems.grdBegBalItems.Columns(10).Visible = False
                frmReconItems.grdBegBalItems.Columns(11).Width = 55
                frmReconItems.grdBegBalItems.Columns(12).Width = 150
                'Setup column headers...
                frmReconItems.grdBegBalItems.Columns(0).HeaderText = "Date"
                frmReconItems.grdBegBalItems.Columns(1).HeaderText = "Stno"
                frmReconItems.grdBegBalItems.Columns(2).HeaderText = "Qtr"
                frmReconItems.grdBegBalItems.Columns(3).HeaderText = "Year"
                frmReconItems.grdBegBalItems.Columns(4).HeaderText = "Tran Type"
                frmReconItems.grdBegBalItems.Columns(5).HeaderText = "Decription"
                frmReconItems.grdBegBalItems.Columns(6).HeaderText = "Amount"
                frmReconItems.grdBegBalItems.Columns(7).HeaderText = "Contract"
                frmReconItems.grdBegBalItems.Columns(8).HeaderText = "ScholarshipID"
                frmReconItems.grdBegBalItems.Columns(9).HeaderText = "Scholarship Details RowID"
                frmReconItems.grdBegBalItems.Columns(10).HeaderText = "Scholarship Details TranRowID"
                frmReconItems.grdBegBalItems.Columns(11).HeaderText = "User"
                frmReconItems.grdBegBalItems.Columns(12).HeaderText = "Comment or File"
                ' Set curency format
                frmReconItems.grdBegBalItems.Columns(6).DefaultCellStyle.Format = "c"
                frmReconItems.grdBegBalItems.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                frmReconItems.grdReconItems.EditMode = DataGridViewEditMode.EditProgrammatically
            Case "SELECT-SUM-BEG-BAL-ADJUST", "SELECT-SUM-BEG-BAL-STNO"
                'Set the DataGridView properties to bind it to the data...
                frmReconMatch.txtBegBal.DataBindings.Clear()
                objDataView = New DataView(objDataSet.Tables("dsReconAdjust"))
                frmReconMatch.txtBegBal.DataBindings.Add("text", objDataView, "BEGBAL")
            Case "SELECT-RECONCAT"
                Dim dtc As DataTable = objDataSet.Tables("dsReconAdjust")
                frmReconItemAdd.cboCategory.DataSource = dtc
                frmReconItemAdd.cboCategory.DisplayMember = "ReconCat"
                frmReconItemAdd.cboCategory.ValueMember = "CategoryID"
        End Select

        '    '***********************************************
        '    '******************* ACTION CODE ***************
        '    '***********************************************
        'objReconAdj = New clsReconAdjust
        'Call objReconAdj.subAdjustSelect(strAction:="SELECT-ADJUST", strReconID:=frmReconMatch.MatchReconID, strDataSet:=frmReconMatch.MatchDataSet, _
        '                      intType:="0", dtTranDate:=frmReconMatch.DateTimePickerStart.Value, mnyTranAmt:=0, _
        '                      intTranRowId:=1, dtAdjDate:=frmReconMatch.DateTimePickerEnd.Value, mnyAdjAmt:=0, _
        '                      strDescr:="", strCreateUser:=SystemInformation.UserName, dtCreateDate:=System.DateTime.Now)

        '    '***********************************************
        '    '***********************************************

    End Sub

    ''*** B. subAdjustAction
    Public Sub subAdjustAction(ByVal strAction As String, ByVal strReconID As String, ByVal intDetRowID As Integer, ByVal strDataSet As String, _
                              ByVal intType As Integer, ByVal dtTranDate As Date, ByVal mnyTranAmt As Double, _
                              ByVal intTranRowId As Integer, ByVal dtAdjDate As Date, ByVal mnyAdjAmt As Double, ByVal strDescr As String, _
                              ByVal strStatus As String, ByVal intCategoryID As Integer, ByVal strClearNextMonthFlag As String, _
                              ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        '  

        ' add error checking
        '  if error check passes proceed
        ' - no pass then message box and skip code

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "[procReconAdjust]"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@ReconID", strReconID)
        objCommand.Parameters.AddWithValue("@DetRowID", intDetRowID)
        objCommand.Parameters.AddWithValue("@DataSet", strDataSet)
        objCommand.Parameters.AddWithValue("@Type", intType)
        objCommand.Parameters.AddWithValue("@TranDate", dtTranDate)
        objCommand.Parameters.AddWithValue("@TranAmt", mnyTranAmt)
        objCommand.Parameters.AddWithValue("@TranRowId", intTranRowId)
        objCommand.Parameters.AddWithValue("@AdjDate", dtAdjDate)
        objCommand.Parameters.AddWithValue("@AdjAmt", mnyAdjAmt)
        objCommand.Parameters.AddWithValue("@Descr", strDescr)
        objCommand.Parameters.AddWithValue("@Status", strStatus)
        objCommand.Parameters.AddWithValue("@CategoryID", intCategoryID)
        objCommand.Parameters.AddWithValue("@ClearNextMonthFlag", strClearNextMonthFlag)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '    '***********************************************
        '    '******************* ACTION CODE ***************
        ''    '***********************************************
        'objReconAdj = New clsReconAdjust
        'Call objReconAdj.subAdjustAction(strAction:="ADD", strReconID:=frmReconMatch.MatchReconID, strDataSet:=frmReconMatch.MatchDBCode, _
        '                      intType:=MatchTranType, dtTranDate:=Me.DateTimePickerFrom.Value, mnyTranAmt:=dblTranAmt, _
        '                      intTranRowId:=1, dtAdjDate:=Me.DateTimePickerADJ.Value, mnyAdjAmt:=dblAdjAmt, _
        '                      strDescr:=txtDescr.Text, strCreateUser:=SystemInformation.UserName, dtCreateDate:=System.DateTime.Now)


        '    '***********************************************
        '    '***********************************************
    End Sub

End Class