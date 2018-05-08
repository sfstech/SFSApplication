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
    'Public WithEvents objReconUWSDBData As clsUWSDB
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
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsElm"

                'Setup form title...
                SearchMenu.Text = "Select CT Data"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 100
                SearchMenu.grdDataList.Columns(1).Width = 50
                SearchMenu.grdDataList.Columns(2).Width = 100
                SearchMenu.grdDataList.Columns(3).Width = 100
                SearchMenu.grdDataList.Columns(4).Width = 100
                SearchMenu.grdDataList.Columns(5).Visible = False

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Funds Release Date"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Batch #"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Import User"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Import Date"
            Case "frmSearch-ELM-Batch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsElm"

                'Setup form title...
                SearchMenu.Text = "ELM Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 100
                SearchMenu.grdDataList.Columns(1).Width = 50
                SearchMenu.grdDataList.Columns(2).Width = 100
                SearchMenu.grdDataList.Columns(3).Width = 100
                SearchMenu.grdDataList.Columns(4).Visible = False


                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Import Date"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Batch #"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Total"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Amount"
            Case "frmSearch-ELM-Student"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsElm"

                'Setup form title...
                SearchMenu.Text = "ELM Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).Width = 100
                SearchMenu.grdDataList.Columns(2).Width = 100
                SearchMenu.grdDataList.Columns(3).Width = 100
                SearchMenu.grdDataList.Columns(4).Width = 77

                'Setup column headers...
                SearchMenu.grdDataList.Columns(1).HeaderText = "Student ID"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Last Name"
                SearchMenu.grdDataList.Columns(3).HeaderText = "First Name"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Total"

            Case "frmSearch-ELM-Lender"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsElm"

                'Setup form title...
                SearchMenu.Text = "ELM Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 100
                SearchMenu.grdDataList.Columns(1).Width = 300
                SearchMenu.grdDataList.Columns(2).Visible = False

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Lender ID"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Lender Name"

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

        'objReconUWSDBData = New clsUWSDB
        'Call objReconUWSDBData.subUWSDBSelect(strAction:="UWSDB-STUDENT-BY-SSN", intStno:=0, dblSSN:=dblTest, _
        'intYear:=0, strQtr:="", intBudget:=0)

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

    Public Function getTableELM() As DataTable
        Dim dt As DataTable = New DataTable("ELM")
        dt.Columns.Add("1")
        dt.Columns.Add("2")
        dt.Columns.Add("CL UNIQUE ID")
        dt.Columns.Add("CL LOAN SEQ #")
        dt.Columns.Add("BORR LAST NAME")
        dt.Columns.Add("BORR FIRST NAME")
        dt.Columns.Add("BORR MI")
        dt.Columns.Add("BORR SSN")
        dt.Columns.Add("BORR ADD 1")
        dt.Columns.Add("BORR ADD 2")
        dt.Columns.Add("BORR CITY")
        dt.Columns.Add("FILLER")
        dt.Columns.Add("BORR ST")
        dt.Columns.Add("BORR ZIP")
        dt.Columns.Add("BORR +4")
        dt.Columns.Add("DATE ADD LAST UPDATED")
        dt.Columns.Add("EFT AUTH CODE")
        dt.Columns.Add("PL/ALT STUD LAST NAME")
        dt.Columns.Add("PL/ALT STUD FIRST NAME")
        dt.Columns.Add("PL/ALT STUD MI")
        dt.Columns.Add("PL/ALT STUD SSN")
        dt.Columns.Add("SCHOOL ID")
        dt.Columns.Add("SCHOOL DESIGNATED BR/DIV CODE")
        dt.Columns.Add("SCHOOL USE ONLY")
        dt.Columns.Add("LN PER BEGIN DATE")
        dt.Columns.Add("LN PER END DATE")
        dt.Columns.Add("LOAN TYPE")
        dt.Columns.Add("ALT LN PROG TYPE CODE")
        dt.Columns.Add("LENDER ID")
        dt.Columns.Add("LENDER BR ID")
        dt.Columns.Add("LENDER USE ONLY")
        dt.Columns.Add("BORR CONF IND")
        dt.Columns.Add("FILLER2")
        dt.Columns.Add("FUNDS RELEASE DATE")
        dt.Columns.Add("DISB #")
        dt.Columns.Add("TOTAL # OF SCHED DISBS")
        dt.Columns.Add("GUARANTOR ID")
        dt.Columns.Add("GUAR USE ONLY")
        dt.Columns.Add("GUAR DATE")
        dt.Columns.Add("GUAR AMT")
        dt.Columns.Add("GROSS DISB AMT")
        dt.Columns.Add("ORIG FEE")
        dt.Columns.Add("GUAR FEE")
        dt.Columns.Add("NET DISB AMT")
        dt.Columns.Add("FUNDS DISB METH")
        dt.Columns.Add("CHECK #")
        dt.Columns.Add("LATE DISB IND")
        dt.Columns.Add("PREV RPTD IND")
        dt.Columns.Add("ERROR MSG 1")
        dt.Columns.Add("ERROR MSG 2")
        dt.Columns.Add("ERROR MSG 3")
        dt.Columns.Add("ERROR MSG 4")
        dt.Columns.Add("ERROR MSG 5")
        dt.Columns.Add("FEES PD")
        dt.Columns.Add("LENDER NAME")
        dt.Columns.Add("NET CANCEL AMT")
        dt.Columns.Add("DUNS SCHOOL ID")
        dt.Columns.Add("DUNS LENDER ID")
        dt.Columns.Add("DUNS GUAR ID")
        dt.Columns.Add("3")
        dt.Columns.Add("4")
        dt.Columns.Add("5")
        dt.Columns.Add("6")

        Return dt
    End Function
End Class
