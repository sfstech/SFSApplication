
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subMatchSelect    !!! - not yet - to be completed

'*** B. subMatchAction

'****************************************
'****************************************

Public Class clsReconMatchF

    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    ''*** A. subMatchSelect
    Public Sub subMatchSelectF(ByVal strAction As String, ByVal strReconID As String, ByVal strDataSet1 As String, ByVal strDataSet2 As String, _
                              ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal strCreateUser As String)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection

        objDataAdapter.SelectCommand.CommandText = "[procReconMatchF]"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters 
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ReconID", strReconID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DataSet1", strDataSet1)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@DataSet2", strDataSet2)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StartDate", dtStartDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@EndDate", dtEndDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        '    objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objDataAdapter.SelectCommand.CommandTimeout = 600

        'Open the database connection...
        objConnection.Open()
        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsReconMatch")
        'Close the database connection...
        objConnection.Close()

        Select Case strAction
            Case "SELECT-FAS-TRANS"
                frmReconMatch.grdFASDetTable = objDataSet.Tables("dsReconMatch")
            Case "SELECT-BANK-TRANS"
                frmReconMatch.grdBankDetTable = objDataSet.Tables("dsReconMatch")
            Case "SELECT-ADJ-MATCH-MASTER", "SELECT-ADJ-MATCH-SINGLE"
                frmReconMatch.grdMatchAdjTable = objDataSet.Tables("dsReconMatch")
            Case Else
                frmReconMatch.grdDataSets.EditMode = DataGridViewEditMode.EditProgrammatically
                frmReconMatch.grdDataTable = objDataSet.Tables("dsReconMatch")
        End Select


        'Inialize and Bind to the correct form...
        Select Case strAction
            
            Case "SELECT-DATES" ',  "CREATE-EMPTY-MATCH-TABLE"
                'Set the DataGridView properties to bind it to the data...
                frmReconMatch.grdDataSets.DataSource = objDataSet
                frmReconMatch.grdDataSets.DataMember = "dsReconMatch"

                'Setup form title...
                'frmReconMatch.Text = "Select Application"   !!!  -do we need this yet?

                'Setup alternating rows style...
                frmReconMatch.grdDataSets.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmReconMatch.grdDataSets.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
                frmReconMatch.grdDataSets.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Setup column widths...
                frmReconMatch.grdDataSets.Columns(0).Visible = False
                frmReconMatch.grdDataSets.Columns(1).Visible = False
                frmReconMatch.grdDataSets.Columns(2).Width = 77
                frmReconMatch.grdDataSets.Columns(3).Width = 100
                frmReconMatch.grdDataSets.Columns(4).Visible = False
                frmReconMatch.grdDataSets.Columns(5).Width = 98
                frmReconMatch.grdDataSets.Columns(6).Width = 98
                frmReconMatch.grdDataSets.Columns(7).Width = 98
                frmReconMatch.grdDataSets.Columns(8).Visible = False

                'Setup column headers...
                frmReconMatch.grdDataSets.Columns(2).HeaderText = "Date"
                frmReconMatch.grdDataSets.Columns(2).DefaultCellStyle.Format = "MM/dd/yyyy"
                frmReconMatch.grdDataSets.Columns(3).HeaderText = strDataSet1 & " Amt"
                frmReconMatch.grdDataSets.Columns(3).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(4).HeaderText = ""        ' strDataSet1 & " ADJ Amt"
                frmReconMatch.grdDataSets.Columns(4).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(5).HeaderText = strDataSet2 & " Amt"
                frmReconMatch.grdDataSets.Columns(5).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(6).HeaderText = " Reconciling Items"
                frmReconMatch.grdDataSets.Columns(6).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(7).HeaderText = "Transaction Match"
                frmReconMatch.grdDataSets.Columns(7).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        End Select

        '    '***********************************************
        '    '******************* ACTION CODE ***************
        '    '***********************************************
        '    'objAppLoginData = New clsAppLogin
        '    'Call objAppLoginData.subReconMatchSelect(strBindTarget:="frmReconMatch", strAction:="SELECT-DATES", _
        '    'intAppID:=0, intPersonID:=frmMainMenu.txtActionID.Text, strAppName:="NONE", strAppUserName:="NONE", _
        '    'strCreateUser:=SystemInformation.UserName, dtCreateDate:="01/01/1900")
        '    '***********************************************
        '    '***********************************************
        Cursor.Current = Cursors.Arrow

    End Sub

    ''*** B. subMatchAction
    Public Sub subMatchActionF(ByVal strAction As String, ByVal strReconID As String, ByVal strDataSet1 As String, ByVal strDataSet2 As String, _
   ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal strCreateUser As String)

        Cursor.Current = Cursors.WaitCursor
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "[procReconMatchF]"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@ReconID", strReconID)
        objCommand.Parameters.AddWithValue("@DataSet1", strDataSet1)
        objCommand.Parameters.AddWithValue("@DataSet2", strDataSet2)
        objCommand.Parameters.AddWithValue("@StartDate", dtStartDate)
        objCommand.Parameters.AddWithValue("@EndDate", dtEndDate)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)

        'Open the database connection...
        objConnection.Open()
        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '    '***********************************************
        '    '******************* ACTION CODE ***************
        ''    '***********************************************
        'objReconMatchData = New clsReconMatch
        'Call objReconMatchData.subMatchAction(strAction:="INSERTDATE", _
        'strDataSet1:="tblmatchHarborSDB", dtStartDate:=calcdate, dtEndDate:="1/1/1900",  _
        'strCreateUser:=SystemInformation.UserName)

        '    '***********************************************
        '    '***********************************************
        Cursor.Current = Cursors.Arrow
    End Sub



End Class