Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subDetailSelect    
'*** B. subDetailAction

'****************************************
'****************************************

Public Class clsReconDetail
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    ''*** A. subDetailSelect
    Public Sub subDetailSelect(ByVal strAction As String, ByVal strReconID As String, ByVal strDataSet1 As String, ByVal strDataSet2 As String, _
                              ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal strCreateUser As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
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


        ' FAS recon gets detail from a table loaded by frmReconMatch
        If strAction <> "SELECT-DETAIL-TRANS-FAS" Then
            'Open the database connection...
            objConnection.Open()

            'Fill the DataSet object with data...
            objDataAdapter.Fill(objDataSet, "dsReconDetail")

            frmReconDetail.grdDetDataTable = objDataSet.Tables("dsReconDetail")

            'Close the database connection...
            objConnection.Close()

        End If

        'Inialize and Bind to the correct form...
        'Select Case strAction
        '    Case "SELECT-HARBOR-TRANS"        'Or "SELECT-BOFA-TRANS"
        'Set the DataGridView properties to bind it to the data...
        If strAction <> "SELECT-DETAIL-TRANS-FAS" Then
            frmReconDetail.grdDataSets.DataSource = objDataSet
            frmReconDetail.grdDataSets.DataMember = "dsReconDetail"
        Else
            Dim strSELDRCR As String
            If frmReconMatch.MatchDBCode = 1 Then
                strSELDRCR = " and TranAmount > 0 "
            Else
                strSELDRCR = " and TranAmount < 0 "
            End If
            frmReconMatch.dvEXCELDataTable = frmReconMatch.EXCELDataTable.DefaultView
            frmReconMatch.dvEXCELDataTable.RowFilter = "Stno = " & frmReconMatch.intStno.ToString & strSELDRCR
            frmReconDetail.grdDataSets.DataSource = frmReconMatch.dvEXCELDataTable
            frmReconDetail.grdDetDataTable = frmReconMatch.dvEXCELDataTable.Table
        End If

        'Setup form title...
        'frmReconDetail.Text = "Select Application"   !!!  -do we need this yet?

        'Setup alternating rows style...
        frmReconDetail.grdDataSets.AutoGenerateColumns = True
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        frmReconDetail.grdDataSets.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        frmReconDetail.grdDataSets.EditMode = DataGridViewEditMode.EditProgrammatically
        'Setup column widths...
        frmReconDetail.grdDataSets.Columns(0).Width = 85
        frmReconDetail.grdDataSets.Columns(1).Width = 75
        frmReconDetail.grdDataSets.Columns(2).Width = 75
        frmReconDetail.grdDataSets.Columns(3).Width = 100
        frmReconDetail.grdDataSets.Columns(4).Width = 85            ' Amount - must be item 4
        frmReconDetail.grdDataSets.Columns(5).Visible = False       ' RowIdx - must be item 5  
        'frmReconDetail.grdDataSets.Columns(5).Width = 70
        'frmReconDetail.grdDataSets.Columns(6).Width = 70
        'frmReconDetail.grdDataSets.Columns(7).Visible = False

        If strAction = "SELECT-DETAIL-TRANS-STUDENT" Then
            frmReconDetail.grdDataSets.Columns(0).DefaultCellStyle.Format = "0000000"
        End If

        'Setup column headers...
        Select Case strAction
            Case "SELECT-DETAIL-TRANS"
                Select Case strDataSet2
                    Case "08"
                        frmReconDetail.grdDataSets.Columns(0).Width = 65
                        frmReconDetail.grdDataSets.Columns(1).Width = 125
                        frmReconDetail.grdDataSets.Columns(2).Width = 55
                        frmReconDetail.grdDataSets.Columns(3).Width = 95
                        frmReconDetail.grdDataSets.Columns(4).Width = 85
                        frmReconDetail.grdDataSets.Columns(5).Visible = False
                    Case "07", "21", "23"
                        frmReconDetail.grdDataSets.Columns(6).HeaderText = "Budget"
                        frmReconDetail.grdDataSets.Columns(7).HeaderText = "Ref2"
                        frmReconDetail.grdDataSets.Columns(8).HeaderText = "Ref3"
                        frmReconDetail.grdDataSets.Columns(9).HeaderText = "Descr"
                        frmReconDetail.grdDataSets.Columns(6).Width = 65
                        frmReconDetail.grdDataSets.Columns(7).Width = 65
                        frmReconDetail.grdDataSets.Columns(8).Width = 65
                        frmReconDetail.grdDataSets.Columns(9).Width = 200
                    Case "28", "30", "32", "34", "36"
                        frmReconDetail.grdDataSets.Columns(0).Width = 65
                        frmReconDetail.grdDataSets.Columns(1).Width = 125
                        frmReconDetail.grdDataSets.Columns(2).Width = 55
                        frmReconDetail.grdDataSets.Columns(3).Width = 95
                        frmReconDetail.grdDataSets.Columns(4).Width = 85
                        frmReconDetail.grdDataSets.Columns(5).Visible = True
                        frmReconDetail.grdDataSets.Columns(5).Width = 85
                    Case "11", "13", "17", "19", "43"
                        frmReconDetail.grdDataSets.Columns(6).HeaderText = "Ref2"
                        frmReconDetail.grdDataSets.Columns(7).HeaderText = "RevCode"
                        frmReconDetail.grdDataSets.Columns(8).HeaderText = "Budget"
                        frmReconDetail.grdDataSets.Columns(9).HeaderText = "Descr"
                        frmReconDetail.grdDataSets.Columns(6).Width = 65
                        frmReconDetail.grdDataSets.Columns(7).Width = 65
                        frmReconDetail.grdDataSets.Columns(8).Width = 65
                        frmReconDetail.grdDataSets.Columns(9).Width = 200
                        '    frmReconDetail.grdDataSets.Columns(4).HeaderText = "Amount"
                        '    'frmReconDetail.grdDataSets.Columns(5).HeaderText = "DS2 ADJ Amt"
                        '    'frmReconDetail.grdDataSets.Columns(6).HeaderText = "Balance"
                        'Case "B of A"
                        '    frmReconDetail.grdDataSets.Columns(0).HeaderText = "Customer Ref"
                        '    frmReconDetail.grdDataSets.Columns(1).HeaderText = "Description"
                        '    frmReconDetail.grdDataSets.Columns(2).HeaderText = "Date"
                        '    frmReconDetail.grdDataSets.Columns(3).HeaderText = "BAI Code"
                        '    frmReconDetail.grdDataSets.Columns(4).HeaderText = "Amount"
                        'Case "SDB"
                        '    frmReconDetail.grdDataSets.Columns(0).HeaderText = "Tran Date"
                        '    frmReconDetail.grdDataSets.Columns(1).HeaderText = "Confirmation"
                        '    frmReconDetail.grdDataSets.Columns(2).HeaderText = "StudentID"
                        '    frmReconDetail.grdDataSets.Columns(3).HeaderText = "Web User"
                        '    frmReconDetail.grdDataSets.Columns(4).HeaderText = "Amount"
                        'Case "FAS"
                        '    frmReconDetail.grdDataSets.Columns(0).HeaderText = "Tran Date"
                        '    frmReconDetail.grdDataSets.Columns(1).HeaderText = "Bank Code"
                        '    frmReconDetail.grdDataSets.Columns(2).HeaderText = "Acct Month"
                        '    frmReconDetail.grdDataSets.Columns(3).HeaderText = "Budget"
                        '    frmReconDetail.grdDataSets.Columns(4).HeaderText = "Amount"

                End Select
        End Select

        ' Set curency format
        frmReconDetail.grdDataSets.Columns(4).DefaultCellStyle.Format = "c"
        frmReconDetail.grdDataSets.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        '    '***********************************************
        '    '******************* ACTION CODE ***************
        '    '***********************************************
        '    'objAppLoginData = New clsAppLogin
        '    'Call objAppLoginData.subReconDetailSelect(strBindTarget:="frmReconDetail", strAction:="SELECT-DATES", _
        '    'intAppID:=0, intPersonID:=frmMainMenu.txtActionID.Text, strAppName:="NONE", strAppUserName:="NONE", _
        '    'strCreateUser:=SystemInformation.UserName, dtCreateDate:="01/01/1900")
        '    '***********************************************
        '    '***********************************************

    End Sub

    ''*** B. subDetailAction
    Public Sub subDetailAction(ByVal strAction As String, ByVal strDataSet As String, _
   ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal strCreateUser As String)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "[procReconDetail]"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@DataSet1", strDataSet)
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
        'objReconDetailData = New clsReconMatch
        'Call objReconDetailData.subDetailAction(strAction:="INSERTDATE", _
        'strDataSet:="tblDetailHarborSDB", dtStartDate:=calcdate, dtEndDate:="1/1/1900",  _
        'strCreateUser:=SystemInformation.UserName)

        '    '***********************************************
        '    '***********************************************
    End Sub

End Class

