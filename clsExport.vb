Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subCTSelect
'*** B. subCTAction
'*** C. fncGetCTFileName
'*** D. subSDBSelect
'*** E. fncGetMaxSDBExportID
'*** F. fncGetSDBFileName
'*** G. subSDBAction
'****************************************
'****************************************

Public Class clsExport
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subCTSelect
    ''' <summary>
    ''' procFAS_Export
    ''' </summary>
    ''' <param name="strBindTarget"></param>
    ''' <param name="strAction"></param>
    ''' <param name="strModule"></param>
    ''' <param name="strFileName"></param>
    ''' <param name="strUserName"></param>
    ''' <param name="dtCreateDate"></param>
    ''' <remarks></remarks>
    Public Sub subCTSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal strModule As String, ByVal strFileName As String, ByVal strUserName As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procFAS_Export"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters...
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strModule)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FileName", strFileName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", strUserName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsCashTransmittal")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "HoldTable"
                frmVendorExpress.HoldTable = objDataSet.Tables(0)
            Case "frmReport-Param1-CT-Listing"
                frmReportMenu.cboParam1.DataSource = objDataSet.Tables("dsCashTransmittal")
                frmReportMenu.cboParam1.DisplayMember = "CTName"
                frmReportMenu.cboParam1.ValueMember = "CTName"
                'Case "frmReport-Param2-CT-Listing"
                '    frmReportMenu.cboParam2.DataSource = objDataSet.Tables("dsCashTransmittal")
                '    frmReportMenu.cboParam2.DisplayMember = "CTName"
                '    frmReportMenu.cboParam2.ValueMember = "CTName"

            Case "Export-XML"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsCashTransmittal")
                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsCashTransmittal"))

                objDataSet.Tables("dsCashTransmittal").WriteXml("C:\test\Data.xml")
            Case "Export-TXT"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsCashTransmittal")
                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsCashTransmittal"))

                objDataSet.Tables("dsCashTransmittal").WriteXml("C:\test\Data.txt")

            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsCashTransmittal"

                'Setup form title...
                SearchMenu.Text = "CT Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 100
                SearchMenu.grdDataList.Columns(0).HeaderText = "File Name"

                SearchMenu.grdDataList.Columns(1).Width = 80
                SearchMenu.grdDataList.Columns(1).HeaderText = "Module"

                SearchMenu.grdDataList.Columns(2).Width = 80
                SearchMenu.grdDataList.Columns(2).HeaderText = "Amount"

                SearchMenu.grdDataList.Columns(3).Width = 80
                SearchMenu.grdDataList.Columns(3).HeaderText = "Create User"

                SearchMenu.grdDataList.Columns(4).Width = 80
                SearchMenu.grdDataList.Columns(4).HeaderText = "Create Date"

                SearchMenu.grdDataList.Columns(5).Width = 80
                SearchMenu.grdDataList.Columns(5).HeaderText = "FAS Ver Date"

                SearchMenu.grdDataList.Columns(6).Visible = False

                'Setup column headers...

            Case "frmExport"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsCashTransmittal")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsCashTransmittal"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmExport.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmExport.txtFileName.DataBindings.Clear()
                frmExport.txtNumberOfTran.DataBindings.Clear()
                frmExport.txtTotalAmount.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmExport.txtFileName.DataBindings.Add("text", objDataView, "CTName")
                frmExport.txtNumberOfTran.DataBindings.Add("text", objDataView, "TotalCount")
                frmExport.txtTotalAmount.DataBindings.Add("text", objDataView, "TotalAmount")
                frmExport.txtCreateUser.DataBindings.Add("text", objDataView, "CreateUser")
                frmExport.txtCreateDate.DataBindings.Add("text", objDataView, "CreateDate")
                frmExport.txtVerUser.DataBindings.Add("text", objDataView, "FASVerUser")
                frmExport.txtVerDate.DataBindings.Add("text", objDataView, "FASVerDate")

            Case "frmExport-Grid"
                'Set the DataGridView properties to bind it to the data...
                frmExport.grdDataList.DataSource = objDataSet
                frmExport.grdDataList.DataMember = "dsCashTransmittal"

                'Setup alternating rows style...
                frmExport.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmExport.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmExport.grdDataList.Columns(0).Visible = False
                frmExport.grdDataList.Columns(1).Width = 25
                frmExport.grdDataList.Columns(2).Width = 75
                frmExport.grdDataList.Columns(3).Width = 25
                frmExport.grdDataList.Columns(4).Width = 60
                frmExport.grdDataList.Columns(5).Width = 60
                frmExport.grdDataList.Columns(6).Width = 60
                frmExport.grdDataList.Columns(7).Visible = False
                frmExport.grdDataList.Columns(8).Width = 50
                frmExport.grdDataList.Columns(9).Visible = False
                frmExport.grdDataList.Columns(10).Visible = False
                frmExport.grdDataList.Columns(11).Visible = False
                frmExport.grdDataList.Columns(12).Visible = False
                frmExport.grdDataList.Columns(13).Width = 250
                frmExport.grdDataList.Columns(14).Visible = False
                frmExport.grdDataList.Columns(15).Visible = False
                frmExport.grdDataList.Columns(16).Visible = False
                frmExport.grdDataList.Columns(17).Visible = False
                frmExport.grdDataList.Columns(18).Visible = False
                frmExport.grdDataList.Columns(19).Visible = False

                'Setup column headers...
                frmExport.grdDataList.Columns(1).HeaderText = "TC"
                frmExport.grdDataList.Columns(2).HeaderText = "Doc #"
                frmExport.grdDataList.Columns(3).HeaderText = "BC"
                frmExport.grdDataList.Columns(4).HeaderText = "Deposit #"
                frmExport.grdDataList.Columns(5).HeaderText = "Budget #"
                frmExport.grdDataList.Columns(6).HeaderText = "Amount"
                frmExport.grdDataList.Columns(8).HeaderText = "GL"
                frmExport.grdDataList.Columns(13).HeaderText = "Description"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objCTData = New clsExport
        'Call objCTData.subCTSelect(strBindTarget:="frmExport", strAction:="SELECT-CT-FILENAME", _
        'strModule:="ELM", strFileName:="F0903012.CSH", strUserName:=SystemInformation.UserName, dtCreateDate:=01/01/1900)
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subCTAction
    ''' <summary>
    ''' procFAS_Export
    ''' </summary>
    ''' <param name="strBindTarget"></param>
    ''' <param name="strAction"></param>
    ''' <param name="strModule"></param>
    ''' <param name="strFileName"></param>
    ''' <param name="strUserName"></param>
    ''' <param name="dtCreateDate"></param>
    ''' <remarks></remarks>
    Public Sub subCTAction(ByVal strBindTarget As String, ByVal strAction As String, ByVal strModule As String, ByVal strFileName As String, ByVal strUserName As String, ByVal dtCreateDate As Date)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procFAS_Export"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@Module", strModule)
        objCommand.Parameters.AddWithValue("@FileName", strFileName)
        objCommand.Parameters.AddWithValue("@UserName", strUserName)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)


        'objCTAction = New clsExport
        'Call objCTAction.subCTAction(strBindTarget:="NONE", strAction:="DELETE-CT-NO-SEND", _
        'strModule:="MERC", strFileName:="NONE", strUserName:=SystemInformation.UserName)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objCTAction = New clsExport
        'Call objCTAction.subCTAction(strBindTarget:="NONE", strAction:="DELETE-CT-NO-SEND", _
        'strModule:="ELM", strFileName:="F0903012.CSH", strUserName:=SystemInformation.UserName, dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

    '*** C. fncGetCTFileName
    Public Function fncGetCTFileName(ByVal strType As String, ByVal dtCTDate As Date, ByVal intSequence As Integer) As String
        '*****************************************************************
        '** UNIVERSITY OF WASHINGTON                                    **
        '** TC30 Cash Transmittal Naming Convention                     **
        '*****************************************************************
        '** Example (F0701031.CSH)                                      **
        '** F = Type (F = Space Delimited / C = Fixed)                  **
        '** 07 = Accounting Month                                       **
        '** 01 = Calendar Month                                         **
        '** 03 = Calendar Day                                           **
        '** 1 = Sequence Number                                         **
        '** .CSH = Required File Extension                              **
        '*****************************************************************

        Dim strCTNumber As String
        Dim strFormatType As String
        Dim strAccountingMonth As String
        Dim strCalendarMonth As String
        Dim strCalendarDay As String

        'Get Type...
        Select Case strType
            Case "SPACE-DELIMITED"
                strFormatType = "F"
            Case "FIXED"
                strFormatType = "C"
            Case Else
                strFormatType = "ERROR"
        End Select

        'Get Accounting Month...
        '*****************************************************************
        '** Accounting month starts at 01 in July of odd numbered years **
        '** and increments through 24 through June of odd numbered year **
        '*****************************************************************
        Select Case (DatePart("m", dtCTDate))
            Case 1
                'January
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "19"
                Else
                    strAccountingMonth = "07"
                End If
            Case 2
                'February
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "20"
                Else
                    strAccountingMonth = "08"
                End If
            Case 3
                'March
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "21"
                Else
                    strAccountingMonth = "09"
                End If
            Case 4
                'April
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "22"
                Else
                    strAccountingMonth = "10"
                End If
            Case 5
                'May
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "23"
                Else
                    strAccountingMonth = "11"
                End If
            Case 6
                'June
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "24"
                Else
                    strAccountingMonth = "12"
                End If
            Case 7
                'July
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "01"
                Else
                    strAccountingMonth = "13"
                End If
            Case 8
                'August
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "02"
                Else
                    strAccountingMonth = "14"
                End If
            Case 9
                'September
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "03"
                Else
                    strAccountingMonth = "15"
                End If
            Case 10
                'October
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "04"
                Else
                    strAccountingMonth = "16"
                End If
            Case 11
                'November
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "05"
                Else
                    strAccountingMonth = "17"
                End If
            Case 12
                'December
                If (DatePart("yyyy", dtCTDate) Mod 2) > 0 Then
                    strAccountingMonth = "06"
                Else
                    strAccountingMonth = "18"
                End If
            Case Else
                strAccountingMonth = "??"
        End Select

        'Get Calendar Month...
        If DatePart("m", dtCTDate) <= 9 Then
            strCalendarMonth = "0" & DatePart("m", dtCTDate)
        Else
            strCalendarMonth = DatePart("m", dtCTDate)
        End If

        'Get Calendar Day...
        If DatePart("d", dtCTDate) <= 9 Then
            strCalendarDay = "0" & DatePart("d", dtCTDate)
        Else
            strCalendarDay = DatePart("d", dtCTDate)
        End If
        'jjea adding this call here to make sure that the method gets called
        'the module doesn't matter because you can create  three files in a day and if they are for different modules then all would have the same sequence
        intSequence = fncGetCTBatchNumber("")

        strCTNumber = strFormatType & strAccountingMonth & strCalendarMonth & strCalendarDay & intSequence & ".CSH"

        Return strCTNumber
    End Function

    '*** D. subSDBSelect
    ''' <summary>
    ''' procSDB_Export
    ''' </summary>
    ''' <param name="strBindTarget"></param>
    ''' <param name="strAction"></param>
    ''' <param name="intID"></param>
    ''' <param name="strFileName"></param>
    ''' <param name="strUserName"></param>
    ''' <remarks></remarks>
    Public Sub subSDBSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intID As Integer, ByVal strFileName As String, ByVal strUserName As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procSDB_Export"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters...
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@intID", intID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FileName", strFileName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", strUserName)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsSDBExport")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsSDBExport"

                'Setup form title...
                SearchMenu.Text = "SDB Export Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = 80
                SearchMenu.grdDataList.Columns(1).Visible = 80
                SearchMenu.grdDataList.Columns(2).Width = 80
                SearchMenu.grdDataList.Columns(3).Width = 80
                SearchMenu.grdDataList.Columns(4).Width = 80
                SearchMenu.grdDataList.Columns(5).Width = 80
                SearchMenu.grdDataList.Columns(6).Visible = False
                SearchMenu.grdDataList.Columns(7).Visible = False

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "File Name"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Module"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Create User"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Create Date"
                SearchMenu.grdDataList.Columns(5).HeaderText = "SDB Ver User"

            Case "frmSearch-SDB-Verfiy"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsSDBExport"

                'Setup form title...
                SearchMenu.Text = "SDB Export Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = 80
                SearchMenu.grdDataList.Columns(1).Visible = 80
                SearchMenu.grdDataList.Columns(2).Width = 80
                SearchMenu.grdDataList.Columns(3).Width = 80
                SearchMenu.grdDataList.Columns(4).Width = 80
                SearchMenu.grdDataList.Columns(5).Width = 80

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "File Name"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Module"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Create User"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Create Date"
                SearchMenu.grdDataList.Columns(5).HeaderText = "SDB Ver User"

            Case "frmExport"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....
                objDataAdapter.Fill(objDataSet, "dsSDBExport")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsSDBExport"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmExport.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmExport.txtFileName.DataBindings.Clear()
                frmExport.txtNumberOfTran.DataBindings.Clear()
                frmExport.txtTotalAmount.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmExport.txtFileName.DataBindings.Add("text", objDataView, "FileName")
                frmExport.txtNumberOfTran.DataBindings.Add("text", objDataView, "NumOfRecords")
                frmExport.txtTotalAmount.DataBindings.Add("text", objDataView, "TotalAmt")
                frmExport.txtCreateUser.DataBindings.Add("text", objDataView, "CreateUser")
                frmExport.txtCreateDate.DataBindings.Add("text", objDataView, "CreateDate")
                frmExport.txtVerUser.DataBindings.Add("text", objDataView, "SDBVerUser")
                frmExport.txtVerDate.DataBindings.Add("text", objDataView, "SDBVerDate")

            Case "frmExport-Grid"
                'NOT WORKING
                'Set the DataGridView properties to bind it to the data...
                frmExport.grdDataList.DataSource = objDataSet
                frmExport.grdDataList.DataMember = "dsSDBExport"

                'Setup alternating rows style...
                frmExport.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmExport.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmExport.grdDataList.Columns(0).Visible = False
                frmExport.grdDataList.Columns(1).Visible = False

                frmExport.grdDataList.Columns(2).Width = 169
                frmExport.grdDataList.Columns(2).HeaderText = "Student Name"

                frmExport.grdDataList.Columns(3).Width = 55
                frmExport.grdDataList.Columns(3).HeaderText = "Student ID"

                frmExport.grdDataList.Columns(4).Width = 55
                frmExport.grdDataList.Columns(4).HeaderText = "Budget #"

                frmExport.grdDataList.Columns(5).Width = 64
                frmExport.grdDataList.Columns(5).HeaderText = "WIN Amt"

                frmExport.grdDataList.Columns(6).Width = 64
                frmExport.grdDataList.Columns(6).HeaderText = "SPR Amt"

                frmExport.grdDataList.Columns(7).Width = 64
                frmExport.grdDataList.Columns(7).HeaderText = "SUM Amt"

                frmExport.grdDataList.Columns(8).Width = 64
                frmExport.grdDataList.Columns(8).HeaderText = "AUT Amt"

                frmExport.grdDataList.Columns(9).Width = 64
                frmExport.grdDataList.Columns(9).HeaderText = "Total Amt"


        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objSDBData = New clsExport
        'Call objSDBData.subSDBSelect(strBindTarget:="frmExport", strAction:="SELECT-SDB-ALL", _
        'intID:=0, strFileName:="NONE", strUserName:=SystemInformation.UserName)
        '***********************************************
        '***********************************************
    End Sub

    '*** E. fncGetMaxSDBExportID
    Public Function fncGetMaxSDBExportID() As Integer
        Dim intExportID As Integer
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procSDB_Export"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", "MAX-EXPORTID-BYUSER")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@intID", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FileName", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", SystemInformation.UserName)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsGetExportID")

        'Close the database connection...
        objConnection.Close()

        'Get the Export ID...
        If objDataSet.Tables("dsGetExportID").Rows.Count = 0 Then
            'No match set intExportID to 0...
            intExportID = 0
        Else
            intExportID = objDataSet.Tables("dsGetExportID").Rows(0).Item("MaxExportID")
        End If

        Return intExportID

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objGetExportID= New clsExport
        'Call objGetExportID.fncGetMaxSDBExportID()
        '***********************************************
        '***********************************************

    End Function

    '*** F. fncGetSDBFileName
    Public Function fncGetSDBFileName(ByVal dtSDBDate As Date, ByVal intSequence As Integer, ByVal strModule As String) As String
        Dim strSDBFileName As String
        Dim strCalendarMonth As String
        Dim strCalendarDay As String
        Dim strCalendarYear As String

        'Get Calendar Month...
        If DatePart("m", dtSDBDate) <= 9 Then
            strCalendarMonth = "0" & DatePart("m", dtSDBDate)
        Else
            strCalendarMonth = DatePart("m", dtSDBDate)
        End If

        'Get Calendar Day...
        If DatePart("d", dtSDBDate) <= 9 Then
            strCalendarDay = "0" & DatePart("d", dtSDBDate)
        Else
            strCalendarDay = DatePart("d", dtSDBDate)
        End If

        'Get Calendar Year...
        strCalendarYear = Right(DatePart("yyyy", dtSDBDate), 2)

        strSDBFileName = strModule & strCalendarMonth & strCalendarDay & strCalendarYear & intSequence & ".dat"

        Return strSDBFileName
    End Function

    '***  fncGetSDBSeqNbr
    Public Function fncGetSDBSeqNbr(ByVal strSDBDate As String, ByVal strModule As String) As Integer
        Dim intSeqNum As Integer

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procSDB_Export"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        strSDBDate = strSDBDate.Replace("/", "")
        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", "SELECT-SEQ-NBR")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@intID", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FileName", strModule)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", strSDBDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsGetSeqNum")

        intSeqNum = objDataSet.Tables("dsGetSeqNum").Rows(0).Item("SeqNum") + 1

        'Close the database connection...
        objConnection.Close()

        Return intSeqNum
    End Function
    '*** G. subSDBAction
    Public Sub subSDBAction(ByVal strBindTarget As String, ByVal strAction As String, ByVal intID As Integer, ByVal strFileName As String, ByVal strUserName As String)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procSDB_Export"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@intID", intID)
        objCommand.Parameters.AddWithValue("@FileName", strFileName)
        objCommand.Parameters.AddWithValue("@UserName", strUserName)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objSDBAction = New clsExport
        'Call objSDBAction.subSDBAction(strBindTarget:="NONE", strAction:="DELETE-CT-NO-SEND", _
        'intID:=0, strFileName:="F0903012.CSH", strUserName:=SystemInformation.UserName)
        '***********************************************
        '***********************************************
    End Sub


    '*** H. fncGetCTBatchNumber
    Public Function fncGetCTBatchNumber(ByVal strModule As String) As Integer
        Dim intBatchNum As Integer

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procFAS_Export"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", "GET-BATCH-NUM")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strModule)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FileName", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", SystemInformation.UserName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", "01/01/1900")

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsGetBatchNum")

        'Close the database connection...
        objConnection.Close()
        intBatchNum = 0

        If objDataSet.Tables("dsGetBatchNum").Rows.Count = 0 Then
            'No match set intBatchNum to 1...
            intBatchNum = 1
        ElseIf (objDataSet.Tables("dsGetBatchNum").Rows.Count > 9) Then
            MsgBox("Sequence limit met for the day")
        Else
            Dim MyTable As DataTable = New DataTable
            MyTable = objDataSet.Tables("dsGetBatchNum")
       
            Dim rowIndex, value As Integer
            Dim dbValues As New ArrayList

            'add all values from database into an arraylist
            For rowIndex = 0 To MyTable.Rows.Count - 1
                dbValues.Add(MyTable.Rows(rowIndex).Item("BatchNum"))
            Next rowIndex

            'search values 1 through 9 in the database values and return any that is not found
            For value = 1 To 9
                If (dbValues.Contains(value) = False) Then
                    intBatchNum = value
                    Return intBatchNum
                End If
            Next value

        End If

        'Next
        'Cursor.Current = Cursors.Arrow
        Return intBatchNum

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objGetCTBatchNum = New clsExport
        'Call objGetCTBatchNum.fncGetCTBatchNumber(strModule:="MISC")
        '***********************************************
        '***********************************************

    End Function


End Class
