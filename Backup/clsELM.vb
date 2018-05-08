Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subElmSelect
'*** B. subElmAction
'*** C. fncGetStudentID
'*** D. fncGetFundsReleaseDate
'*** E. fncGetElmBatchNumber
'*** F. fncCheckElmFundsRelease
'*** G. subElmLoad
'****************************************
'****************************************

Public Class clsELM
    Public WithEvents objReconUWSDBData As clsUWSDB
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subElmSelect
    Public Sub subElmSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intSSN As Integer, ByVal intStudent_no As Integer, ByVal dtElmDate As Date, ByVal intBatchNum As Integer, ByVal strElmString As String, ByVal strCreateUser As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim DS As System.Data.DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procElm"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SSN", intSSN)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Student_no", intStudent_no)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ElmDate", dtElmDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BatchNum", intBatchNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ElmString", strElmString)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", strCreateUser)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsElm")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmELM-Student-Grid"
                'Set the DataGridView properties to bind it to the data...
                frmELM.grdElmData.DataSource = objDataSet
                frmELM.grdElmData.DataMember = "dsElm"

                'Setup alternating rows style...
                frmELM.grdElmData.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmELM.grdElmData.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmELM.grdElmData.Columns(0).Visible = False
                frmELM.grdElmData.Columns(1).Width = 68
                frmELM.grdElmData.Columns(2).Width = 58
                frmELM.grdElmData.Columns(3).Width = 125
                frmELM.grdElmData.Columns(4).Width = 58
                frmELM.grdElmData.Columns(5).Visible = False
                frmELM.grdElmData.Columns(6).Width = 58
                frmELM.grdElmData.Columns(7).Width = 68
                frmELM.grdElmData.Columns(8).Width = 58
                frmELM.grdElmData.Columns(9).Width = 68
                frmELM.grdElmData.Columns(10).Width = 85
                frmELM.grdElmData.Columns(11).Width = 58
                frmELM.grdElmData.Columns(12).Width = 68
                frmELM.grdElmData.Columns(13).Width = 85

                'Setup column headers...
                frmELM.grdElmData.Columns(1).HeaderText = "Release Date"
                frmELM.grdElmData.Columns(2).HeaderText = "Lender ID"
                frmELM.grdElmData.Columns(3).HeaderText = "Lender"
                frmELM.grdElmData.Columns(4).HeaderText = "Amount"
                frmELM.grdElmData.Columns(5).HeaderText = "Desc"
                frmELM.grdElmData.Columns(6).HeaderText = "Import User"
                frmELM.grdElmData.Columns(7).HeaderText = "Import Date"
                frmELM.grdElmData.Columns(8).HeaderText = "FAS Export User"
                frmELM.grdElmData.Columns(9).HeaderText = "FAS Export Date"
                frmELM.grdElmData.Columns(10).HeaderText = "File Name"
                frmELM.grdElmData.Columns(11).HeaderText = "SDB Export User"
                frmELM.grdElmData.Columns(12).HeaderText = "SDB Export Date"
                frmELM.grdElmData.Columns(13).HeaderText = "File Name"
            Case "frmELM-Lender-Grid"
                'Set the DataGridView properties to bind it to the data...
                frmELM.grdElmData.DataSource = objDataSet
                frmELM.grdElmData.DataMember = "dsElm"

                'Setup alternating rows style...
                frmELM.grdElmData.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmELM.grdElmData.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmELM.grdElmData.Columns(0).Visible = False
                frmELM.grdElmData.Columns(1).Width = 68
                frmELM.grdElmData.Columns(2).Width = 145
                frmELM.grdElmData.Columns(3).Width = 58
                frmELM.grdElmData.Columns(4).Width = 58
                frmELM.grdElmData.Columns(5).Width = 68
                frmELM.grdElmData.Columns(6).Width = 58
                frmELM.grdElmData.Columns(7).Width = 68
                frmELM.grdElmData.Columns(8).Width = 85
                frmELM.grdElmData.Columns(9).Width = 58
                frmELM.grdElmData.Columns(10).Width = 68
                frmELM.grdElmData.Columns(11).Width = 85
                frmELM.grdElmData.Columns(12).Visible = False
                frmELM.grdElmData.Columns(13).Visible = False

                'Setup column headers...
                frmELM.grdElmData.Columns(1).HeaderText = "Release Date"
                frmELM.grdElmData.Columns(2).HeaderText = "Desc"
                frmELM.grdElmData.Columns(3).HeaderText = "Amount"
                frmELM.grdElmData.Columns(4).HeaderText = "Import User"
                frmELM.grdElmData.Columns(5).HeaderText = "Import Date"
                frmELM.grdElmData.Columns(6).HeaderText = "FAS Export User"
                frmELM.grdElmData.Columns(7).HeaderText = "FAS Export Date"
                frmELM.grdElmData.Columns(8).HeaderText = "File Name"
                frmELM.grdElmData.Columns(9).HeaderText = "SDB Export User"
                frmELM.grdElmData.Columns(10).HeaderText = "SDB Export Date"
                frmELM.grdElmData.Columns(11).HeaderText = "File Name"
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsElm"

                'Setup form title...
                frmSearch.Text = "Select CT Data"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Width = 100
                frmSearch.grdDataList.Columns(1).Width = 50
                frmSearch.grdDataList.Columns(2).Width = 100
                frmSearch.grdDataList.Columns(3).Width = 100
                frmSearch.grdDataList.Columns(4).Width = 100
                frmSearch.grdDataList.Columns(5).Visible = False

                'Setup column headers...
                frmSearch.grdDataList.Columns(0).HeaderText = "Funds Release Date"
                frmSearch.grdDataList.Columns(1).HeaderText = "Batch #"
                frmSearch.grdDataList.Columns(2).HeaderText = "Amount"
                frmSearch.grdDataList.Columns(3).HeaderText = "Import User"
                frmSearch.grdDataList.Columns(4).HeaderText = "Import Date"
            Case "frmSearch-ELM-Batch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsElm"

                'Setup form title...
                frmSearch.Text = "ELM Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Width = 100
                frmSearch.grdDataList.Columns(1).Width = 50
                frmSearch.grdDataList.Columns(2).Width = 100
                frmSearch.grdDataList.Columns(3).Width = 100
                frmSearch.grdDataList.Columns(4).Visible = False


                'Setup column headers...
                frmSearch.grdDataList.Columns(0).HeaderText = "Import Date"
                frmSearch.grdDataList.Columns(1).HeaderText = "Batch #"
                frmSearch.grdDataList.Columns(2).HeaderText = "Total"
                frmSearch.grdDataList.Columns(3).HeaderText = "Amount"
            Case "frmSearch-ELM-Student"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsElm"

                'Setup form title...
                frmSearch.Text = "ELM Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Width = 100
                frmSearch.grdDataList.Columns(2).Width = 100
                frmSearch.grdDataList.Columns(3).Width = 100
                frmSearch.grdDataList.Columns(4).Width = 77

                'Setup column headers...
                frmSearch.grdDataList.Columns(1).HeaderText = "Student ID"
                frmSearch.grdDataList.Columns(2).HeaderText = "Last Name"
                frmSearch.grdDataList.Columns(3).HeaderText = "First Name"
                frmSearch.grdDataList.Columns(4).HeaderText = "Total"

            Case "frmSearch-ELM-Lender"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsElm"

                'Setup form title...
                frmSearch.Text = "ELM Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Width = 100
                frmSearch.grdDataList.Columns(1).Width = 300
                frmSearch.grdDataList.Columns(2).Visible = False

                'Setup column headers...
                frmSearch.grdDataList.Columns(0).HeaderText = "Lender ID"
                frmSearch.grdDataList.Columns(1).HeaderText = "Lender Name"

            Case "Update-Student_no"
                'Open the database connection...
                objConnection.Open()

                'Fill the DataSet object with data...
                DS = New System.Data.DataSet("dsElm")
                objDataAdapter.Fill(DS)

                'Close the database connection...
                objConnection.Close()

                Dim MyTable As DataTable
                Dim loop1, numrows As Integer

                MyTable = New DataTable
                MyTable = DS.Tables(0)

                numrows = MyTable.Rows.Count

                If numrows = 0 Then
                    MsgBox("No Records")
                Else
                    For loop1 = 0 To numrows - 1

                        'Do Stuff
                        'MsgBox("SSN = " & (MyTable.Rows(loop1).Item("SSN")))
                        'MsgBox("StudentID = " & fncGetStudentID(strAction:="GET-STNO", intSSN:=(MyTable.Rows(loop1).Item("SSN"))))
                        'Replaced this old way with new one
                        'subElmAction(strAction:="UPDATE-STUDENT_NO", intSSN:=(MyTable.Rows(loop1).Item("SSN")), intStudent_no:=fncGetStudentID(strAction:="GET-STNO", intSSN:=(MyTable.Rows(loop1).Item("SSN"))), dtElmDate:="01/01/1900", intBatchNum:=0, strElmString:="NONE", strCreateUser:="NONE")
                        subElmAction(strAction:="UPDATE-STUDENT_NO", intSSN:=(MyTable.Rows(loop1).Item("SSN")), intStudent_no:=fncGetUWSDBStudentID(intSSN:=(MyTable.Rows(loop1).Item("SSN"))), dtElmDate:="01/01/1900", intBatchNum:=0, strElmString:="NONE", strCreateUser:="NONE")
                    Next loop1
                End If
        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objElmData = New clsELM
        'Call objElmData.subElmSelect(strBindTarget:="NONE", strAction:="SELECT", intSSN:=0,intStudent_no:=0, _
        'dtElmDate:="01/01/1900", intBatchNum:=0, strElmString:="NONE", strCreateUser:="NONE")
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subElmAction
    Public Sub subElmAction(ByVal strAction As String, ByVal intSSN As Integer, ByVal intStudent_no As Integer, ByVal dtElmDate As Date, ByVal intBatchNum As Integer, ByVal strElmString As String, ByVal strCreateUser As String)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procElm"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@SSN", intSSN)
        objCommand.Parameters.AddWithValue("@Student_no", intStudent_no)
        objCommand.Parameters.AddWithValue("@ElmDate", dtElmDate)
        objCommand.Parameters.AddWithValue("@BatchNum", intBatchNum)
        objCommand.Parameters.AddWithValue("@ElmString", strElmString)
        objCommand.Parameters.AddWithValue("@UserName", strCreateUser)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objElmAction = New clsELM
        'Call objElmAction.subElmAction(strAction:="DELETE-tblELM_IMPORT", intSSN:=0, intStudent_no:=0, dtElmDate:="01/01/1900",intBatchNum:=0, strElmString:="NONE", strCreateUser:="NONE")
        '***********************************************
        '***********************************************
    End Sub

    '*** C. fncGetStudentID
    Public Function fncGetStudentID(ByVal strAction As String, ByVal intSSN As Integer) As Integer
        Dim intStudentID As Integer

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procUWSDB_Lookup"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SSN", intSSN)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsGetStudentID")

        'Close the database connection...
        objConnection.Close()

        'Get the student ID...
        If objDataSet.Tables("dsGetStudentID").Rows.Count = 0 Then
            'No match set student ID to 9999999...
            'ELM Note: These records are still submitted to SDB and dealt with later on an SDB exception report...
            intStudentID = 9999999
        Else
            intStudentID = objDataSet.Tables("dsGetStudentID").Rows(0).Item("student_no")
        End If

        'Next
        Cursor.Current = Cursors.Arrow
        Return intStudentID

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objGetStudentID = New clsELM
        'Call objGetStudentID.fncGetStudentID(strAction:="GET-STNO", intSSN:=000000000)
        '***********************************************
        '***********************************************

    End Function

    Public Function fncGetUWSDBStudentID(ByVal intSSN As Integer) As Integer

        Dim intStudentID As Integer
        Dim dblTest As Double = 0

        dblTest = CDbl(intSSN)

        If dblTest = 0 Then
            intStudentID = 9999999
            Return intStudentID
        End If

        Dim aa As New clsAliasAccount(frmMainMenu.SFS_Tech_U, frmMainMenu.SFS_Tech_P)
        aa.BeginImpersonation()

        objReconUWSDBData = New clsUWSDB
        Call objReconUWSDBData.subUWSDBSelect(strAction:="UWSDB-STUDENT-BY-SSN", intStno:=0, dblSSN:=dblTest, _
        intYear:=0, strQtr:="", intBudget:=0)

        aa.EndImpersonation()

        intStudentID = CInt(frmMainMenu.intUWSBDStno)

        If intStudentID = 0 Then
            intStudentID = 9999999
        End If

        Return intStudentID

    End Function

    '*** D. fncGetFundsReleaseDate
    Public Function fncGetFundsReleaseDate() As Date
        Dim dtFundsReleaseDate As Date

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procElm"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", "SELECT-FUNDS-RELEASE-DATE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SSN", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Student_no", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ElmDate", "01/01/1900")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BatchNum", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ElmString", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", SystemInformation.UserName)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsGetFundsReleaseDate")

        'Close the database connection...
        objConnection.Close()

        'Get the funds release date...
        If objDataSet.Tables("dsGetFundsReleaseDate").Rows.Count = 0 Then
            'No match set dtFundsReleaseDate to "01/01/1900"...
            dtFundsReleaseDate = "01/01/1900"
        Else
            dtFundsReleaseDate = objDataSet.Tables("dsGetFundsReleaseDate").Rows(0).Item("FundsReleaseDate")
        End If

        'Next
        Cursor.Current = Cursors.Arrow
        Return dtFundsReleaseDate

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objGetFundsReleaseDate = New clsELM
        'Call objGetFundsReleaseDate.fncGetFundsReleaseDate()
        '***********************************************
        '***********************************************

    End Function

    '*** E. fncGetElmBatchNumber
    Public Function fncGetElmBatchNumber(ByVal dtElmDate As Date) As Integer
        Dim intBatchNum As Integer

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procElm"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", "SELECT-LoanTran-ImportDate")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SSN", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Student_no", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ElmDate", dtElmDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BatchNum", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ElmString", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", SystemInformation.UserName)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsGetBatchNum")

        'Close the database connection...
        objConnection.Close()

        'Get the funds release date...
        If objDataSet.Tables("dsGetBatchNum").Rows.Count = 0 Then
            'No match set intBatchNum to 1...
            intBatchNum = 1
        Else
            'Find last batch number and increment it by one...
            Dim objDataAdapter2 As New SqlDataAdapter
            Dim objDataSet2 As New DataSet

            'Set the SelectCommand properties...
            objDataAdapter2.SelectCommand = New SqlCommand()
            objDataAdapter2.SelectCommand.Connection = objConnection
            objDataAdapter2.SelectCommand.CommandText = "procElm"
            objDataAdapter2.SelectCommand.CommandType = CommandType.StoredProcedure

            'Set the paramaters
            objDataAdapter2.SelectCommand.Parameters.AddWithValue("@Action", "SELECT-BATCH-NUM")
            objDataAdapter2.SelectCommand.Parameters.AddWithValue("@SSN", 0)
            objDataAdapter2.SelectCommand.Parameters.AddWithValue("@Student_no", 0)
            objDataAdapter2.SelectCommand.Parameters.AddWithValue("@ElmDate", dtElmDate)
            objDataAdapter2.SelectCommand.Parameters.AddWithValue("@BatchNum", 0)
            objDataAdapter2.SelectCommand.Parameters.AddWithValue("@ElmString", "NONE")
            objDataAdapter2.SelectCommand.Parameters.AddWithValue("@UserName", SystemInformation.UserName)

            'Open the database connection...
            objConnection.Open()

            'Fill the DataSet object with data...
            objDataAdapter2.Fill(objDataSet2, "dsGetBatchNum2")

            'Close the database connection...
            objConnection.Close()

            intBatchNum = objDataSet2.Tables("dsGetBatchNum2").Rows(0).Item("BatchNum") + 1
        End If

        'Next
        Cursor.Current = Cursors.Arrow
        Return intBatchNum

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objGetBatchNum = New clsELM
        'Call objGetBatchNum.fncGetElmBatchNumber(dtElmDate:="01/01/1900")
        '***********************************************
        '***********************************************

    End Function

    '*** F. fncCheckElmFundsRelease
    Public Function fncCheckElmFundsRelease(ByVal dtElmDate As Date) As String
        Dim strPassFail As String
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procElm"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", "SELECT-LoanTran-FundsDate")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SSN", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Student_no", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ElmDate", dtElmDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BatchNum", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ElmString", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", SystemInformation.UserName)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsCheckFundsDate")

        'Close the database connection...
        objConnection.Close()

        'Get the funds release date...
        If objDataSet.Tables("dsCheckFundsDate").Rows.Count = 0 Then
            'No match, first batch for that funds release date...
            strPassFail = "PASS"
        Else
            'Data for that funds release date has already been imported...
            'Ask user for permission to proceed...
            If MsgBox("Data containing a funds release date of " & dtElmDate & " was already imported by " & objDataSet.Tables("dsCheckFundsDate").Rows(0).Item("ImportUser") & " on " & objDataSet.Tables("dsCheckFundsDate").Rows(0).Item("ImportDate") & ".  Are you sure you want to continue?", vbYesNo, "Warning: Possibile Duplicate Data!") = vbYes Then
                strPassFail = "PASS"
            Else
                strPassFail = "FAIL"
            End If
        End If

        'Next
        Cursor.Current = Cursors.Arrow
        Return strPassFail

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objCheckElmFundsRelease = New clsELM
        'Call objCheckElmFundsRelease.fncCheckElmFundsRelease(dtElmDate:="01/01/1900")
        '***********************************************
        '***********************************************

    End Function

    '*** G. subElmLoad
    Public Sub subElmLoad(ByVal strAction As String, ByVal intID As Integer, ByVal strName As String, ByVal strAmt As String)
        'Open frmELM
        frmELM.MdiParent = frmMainMenu
        frmELM.Show()
        Select Case strAction
            Case "LOAD_LENDER"
                frmELM.txtdbModule.Text = "LENDER"
                frmELM.lblID.Text = "Lender ID:"
                frmELM.txtID.Text = intID
                frmELM.lblName.Text = "Lender:"
                frmELM.txtName.Text = strName
                frmELM.lblAmt.Text = "Total:"
                frmELM.txtAmt.Text = strAmt
                frmELM.grdElmData.EditMode = DataGridViewEditMode.EditProgrammatically
            Case "LOAD_STUDENT"
                frmELM.txtdbModule.Text = "STUDENT"
                frmELM.lblID.Text = "Student ID:"
                frmELM.txtID.Text = intID
                frmELM.lblName.Text = "Name:"
                frmELM.txtName.Text = strName
                frmELM.lblAmt.Text = "Total:"
                frmELM.txtAmt.Text = strAmt
                frmELM.grdElmData.EditMode = DataGridViewEditMode.EditProgrammatically
        End Select
        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objElmAction = New clsELM
        'Call objElmAction.subElmLoad(strAction:="LOAD_LENDER", intID:=0, strName:="NONE", strAmt:="NONE")
        '***********************************************
        '***********************************************
    End Sub
End Class
