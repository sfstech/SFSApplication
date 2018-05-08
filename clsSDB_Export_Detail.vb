

Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subSDBExportDetSelect
'*** B. subSDBExportDetAction
'****************************************
'****************************************
Public Class clsSDB_Export_Detail
    Dim objConnection As New SqlConnection _
       (frmMainMenu.strSFSCon)


    '*** A. subSDBExportDetSelect
    Public Sub subSDBExportDetSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intExportID As Integer, _
                ByVal strStudentName As String, ByVal intStudentID As Integer, ByVal strBudgetNum As String, ByVal strAmount_WIN As String, _
                ByVal strAmount_SPR As String, ByVal strAmount_SUM As String, _
                ByVal strAmount_AUT As String, ByVal strModule As String)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procSDB_Export_Det"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ExportID ", intExportID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StudentName", strStudentName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StudentID", intStudentID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetNum", strBudgetNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount_WIN", strAmount_WIN)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount_SPR", strAmount_SPR)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount_SUM", strAmount_SUM)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount_AUT", strAmount_AUT)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strModule)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsSDBExpDet")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsSDBExpDet"

                'Setup form title...
                SearchMenu.Text = "ScholDet Data Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).Width = 80
                SearchMenu.grdDataList.Columns(2).Width = 80
                SearchMenu.grdDataList.Columns(3).Width = 80
                SearchMenu.grdDataList.Columns(4).Width = 80
                'frmSearch.grdDataList.Columns(5).Width = 120

                SearchMenu.grdDataList.Columns(2).DefaultCellStyle.Format = "c"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objScholDetData = New clsScholarshipDetails
        'Call objScholDetAction.subScholDetSelect(strAction:="CASH-TRANSMITTAL-SENT", _
        'intScholarshipID:=0, strTranType:="N/A", strTranDescr:="NONE", strBudgetNumber:="NONE", _
        'dblAmount:=0, strSDBExportUser:="NONE", _
        'dtSDBExportDate:="01/01/1900", strSDBReportUser:="NONE", _
        'dtSDBReportDate:="01/01/1900", strImportFileName:="NONE", _
        'strCreateUser:="NONE", dtCreateDate:="01/01/1900", _
        'strFASExportUser:=SystemInformation.UserName, dtFASExportDate:="01/01/1900")
        '***********************************************
        '***********************************************

    End Sub


    '*** B. subSDBExportDet
    Public Sub subSDBExportDetAction(ByVal strAction As String, ByVal intExportID As Integer, _
                ByVal strStudentName As String, ByVal intStudentID As Integer, ByVal strBudgetNum As String, ByVal strAmount_WIN As String, _
                ByVal strAmount_SPR As String, ByVal strAmount_SUM As String, _
                ByVal strAmount_AUT As String, ByVal strModule As String)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procSDB_Export_Det"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@ExportID ", intExportID)
        objCommand.Parameters.AddWithValue("@StudentName", strStudentName)
        objCommand.Parameters.AddWithValue("@StudentID", intStudentID)
        objCommand.Parameters.AddWithValue("@BudgetNum", strBudgetNum)
        objCommand.Parameters.AddWithValue("@Amount_WIN", strAmount_WIN)
        objCommand.Parameters.AddWithValue("@Amount_SPR", strAmount_SPR)
        objCommand.Parameters.AddWithValue("@Amount_SUM", strAmount_SUM)
        objCommand.Parameters.AddWithValue("@Amount_AUT", strAmount_AUT)
        objCommand.Parameters.AddWithValue("@Module", strModule)


        Cursor.Current = Cursors.WaitCursor
        objCommand.CommandTimeout = 600
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        Cursor.Current = Cursors.Arrow

        ''***********************************************
        ''******************* ACTION CODE ***************
        ''***********************************************
        'subScholDetAction = New clsScholarshipDetails
        'Call subScholDetAction.subScholDetAction(strAction:="CREATE-SDB-EXPORT", _
        'intScholarshipID:=0, strTranType:="N/A", strTranDescr:="NONE", strBudgetNumber:="NONE" _
        'dblAmount:=0, strSDBExportUser:="NONE", dtSDBExportDate:="01/01/1900", _
        'strSDBReportUser:="NONE", dtSDBReportDate:="01/01/1900", strImportFileName:="NONE", _
        'strCreateUser:="NONE", dtCreateDate:="01/01/1900", strFASExportUser:="NONE", dtFASExportDate: ="01/01/1900")
        '    '***********************************************
        '    '***********************************************

    End Sub

End Class


