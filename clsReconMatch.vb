




Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subMatchSelect    !!! - not yet - to be completed

'*** B. subMatchAction

'****************************************
'****************************************

Public Class clsReconMatch

    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    ''*** A. subMatchSelect
    Public Sub subMatchSelect(ByVal strAction As String, ByVal strReconID As String, ByVal strDataSet1 As String, ByVal strDataSet2 As String, _
                              ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal strCreateUser As String)

        'If frmReconMatch.txtdbModule.Text = "GET" Then
        '    objConnection.Close()
        '    subGETUWSDBDataset2()
        '    Exit Sub
        'End If

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection

        'If frmReconMatch.txtdbModule.Text = "GET" Then
        '    objDataAdapter.SelectCommand.CommandText = " SELECT * From fnRecon72_GET"
        '    objDataAdapter.SelectCommand.ExecuteNonQuery()

        'End If

        objDataAdapter.SelectCommand.CommandText = "[procReconMatch]"
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
        objDataAdapter.SelectCommand.CommandTimeout = 1000

        'Open the database connection...
        objConnection.Open()
        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsReconMatch")
        frmReconMatch.grdDataSets.EditMode = DataGridViewEditMode.EditProgrammatically
        frmReconMatch.grdDataTable = objDataSet.Tables("dsReconMatch")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct form...
        Select Case strAction
            Case "SELECT-DATES"
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

            Case "SELECT-STNO", "SELECT-STNO-WITH-RECON"

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
                If strAction = "SELECT-STNO-WITH-RECON" Then
                    frmReconMatch.grdDataSets.Columns(6).Width = 98
                    frmReconMatch.grdDataSets.Columns(7).Width = 98
                Else
                    frmReconMatch.grdDataSets.Columns(6).Visible = False
                    frmReconMatch.grdDataSets.Columns(7).Width = 196
                End If
                frmReconMatch.grdDataSets.Columns(8).Visible = False
                frmReconMatch.grdDataSets.Columns(9).Visible = False
                'Setup column headers...
                frmReconMatch.grdDataSets.Columns(2).HeaderText = "Stno"
                frmReconMatch.grdDataSets.Columns(2).DefaultCellStyle.Format = "0000000"
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
    Public Sub subMatchAction(ByVal strAction As String, ByVal strReconID As String, ByVal strDataSet1 As String, ByVal strDataSet2 As String, _
   ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal strCreateUser As String)

        Cursor.Current = Cursors.WaitCursor
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "[procReconMatch]"
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

    'Private Sub subGETUWSDBDataset2()

    '    Dim aa As New clsAliasAccount(frmMainMenu.SFS_Tech_U, frmMainMenu.SFS_Tech_P)

    '    aa.BeginImpersonation()

    '    Dim objConnection As New SqlConnection _
    '    (frmMainMenu.UWSDB_DATASOURCE_SEC)
    '    '("Data Source=SDBSQLC1DB1.admin.washington.edu;Initial Catalog=UWSDB;User Id=sfstech;Password=password;Trusted_Connection=True;")

    '    Dim objCommand As SqlCommand = New SqlCommand
    '    objCommand.Connection = objConnection
    '    objConnection.Open()
    '    objCommand.CommandText = " SELECT dbo.student_1.student_no from  dbo.student_1 where student_no > 0"
    '    'objCommand.CommandText = " SELECT * From fnRecon72_GET"
    '    objCommand.ExecuteNonQuery()
    '    aa.EndImpersonation()


    '    ' Start here tomorrow......
    '    'objDataAdapter.SelectCommand.CommandType = CommandType.Text
    '    'objDataAdapter.SelectCommand.CommandText = "SELECT   COUNT(dbo.student_1.student_no) from dbo.student_1 "




    '    '       objCommand.CommandText = "SELECT     dbo.student_1.student_no, dbo.sa_sf_awards_awards.awrd_code_budget, dbo.sa_sf_awards_awards.sum_autho_amt " _
    '    '  + " , dbo.sa_sf_awards_awards.award_yr FROM dbo.sa_sf_awards_awards INNER JOIN " _
    '    '   + " dbo.student_1 ON dbo.sa_sf_awards_awards.system_key = dbo.student_1.system_key " _
    '    '   + " WHERE (dbo.sa_sf_awards_awards.awrd_code_budget = 330320) AND (award_yr = 2009) AND " _
    '    '+ " dbo.sa_sf_awards_awards.sum_autho_amt > 0"


    '    'Dim intRet As Integer = 0
    '    'objCommand.CommandText = "SELECT   COUNT(dbo.student_1.student_no) from dbo.student_1 "
    '    ''     objCommand.CommandText = "SELECT   COUNT(dbo.Student_2.system_key) from Student_2 "
    '    ''intRet = objCommand.ExecuteNonQuery()
    '    'intRet = objCommand.ExecuteScalar()

    '    'aa.EndImpersonation()



    'End Sub

End Class
