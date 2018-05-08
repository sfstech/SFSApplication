'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subScholDetSelect
'*** B. subScholDetAction
'****************************************
'****************************************
Public Class clsScholarshipDetails
    Dim objConnection As New SqlConnection _
       (frmMainMenu.strSFSCon)


    '*** A. subScholDetSelect
    Public Sub subScholDetSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intScholarshipID As Integer, _
                ByVal strTranType As String, ByVal strTranDescr As String, ByVal strBudgetNumber As String, ByVal dblAmount As Double, _
                ByVal strSDBExportUser As String, ByVal dtSDBExportDate As Date, _
                ByVal strSDBReportUser As String, ByVal dtSDBReportDate As Date, _
                ByVal strImportFileName As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date, _
                ByVal strFASExportUser As String, ByVal dtFASExportDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procScholarshipDetails"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ScholarshipID ", intScholarshipID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranType", strTranType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TranDescr", strTranDescr)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBExportUser", strSDBExportUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBExportDate", dtSDBExportDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBReportUser", strSDBReportUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SDBReportDate", dtSDBReportDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FASExportUser", strSDBExportUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FASExportDate", dtSDBExportDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsScholDet")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsScholDet"

                'Setup form title...
                frmSearch.Text = "ScholDet Data Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Width = 80
                frmSearch.grdDataList.Columns(2).Width = 80
                frmSearch.grdDataList.Columns(3).Width = 80
                frmSearch.grdDataList.Columns(4).Width = 80
                'frmSearch.grdDataList.Columns(5).Width = 120

                frmSearch.grdDataList.Columns(2).DefaultCellStyle.Format = "c"
            Case "frmScholarship"
                'Set the DataGridView properties to bind it to the data...
                frmScholarship.grdDataList.DataSource = objDataSet
                frmScholarship.grdDataList.DataMember = "dsScholDet"

                'Setup alternating rows style...
                frmScholarship.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmScholarship.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column headers...
                frmScholarship.grdDataList.Columns(1).HeaderText = "Import Date"
                frmScholarship.grdDataList.Columns(2).HeaderText = "Type"
                frmScholarship.grdDataList.Columns(3).HeaderText = "Budget"
                frmScholarship.grdDataList.Columns(4).HeaderText = "Description"
                frmScholarship.grdDataList.Columns(5).HeaderText = "Activity"
                frmScholarship.grdDataList.Columns(6).HeaderText = "Amount"

                'Setup column widths...
                frmScholarship.grdDataList.Columns(0).Visible = False
                frmScholarship.grdDataList.Columns(1).Width = 60
                frmScholarship.grdDataList.Columns(2).Width = 45
                frmScholarship.grdDataList.Columns(3).Width = 50
                frmScholarship.grdDataList.Columns(4).Width = 90
                frmScholarship.grdDataList.Columns(5).Width = 230
                frmScholarship.grdDataList.Columns(6).Width = 80

                frmScholarship.grdDataList.Columns(1).DefaultCellStyle.Format = "d"
                frmScholarship.grdDataList.Columns(6).DefaultCellStyle.Format = "c"
                frmScholarship.grdDataList.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Case "frmSearch-Schol-Detail"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsScholDet"

                'Setup form title...
                frmSearch.Text = "Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Width = 80
                frmSearch.grdDataList.Columns(2).Width = 30
                frmSearch.grdDataList.Columns(3).Width = 135
                frmSearch.grdDataList.Columns(4).Width = 80
                frmSearch.grdDataList.Columns(5).Width = 80
                frmSearch.grdDataList.Columns(6).Width = 80

                frmSearch.grdDataList.Columns(2).DefaultCellStyle.Format = "c"
            Case "frmExport-Grid"
                frmExport.grdDataList.DataSource = objDataSet
                frmExport.grdDataList.DataMember = "dsScholDet"
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


    '*** B. subScholDetAction
    Public Sub subScholDetAction(ByVal strAction As String, ByVal intScholarshipID As Integer, _
                ByVal strTranType As String, ByVal strTranDescr As String, ByVal strBudgetNumber As String, ByVal dblAmount As Double, _
                ByVal strSDBExportUser As String, ByVal dtSDBExportDate As Date, _
                ByVal strSDBReportUser As String, ByVal dtSDBReportDate As Date, _
                ByVal strImportFileName As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date, _
                ByVal strFASExportUser As String, ByVal dtFASExportDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procScholarshipDetails"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@ScholarshipID ", intScholarshipID)
        objCommand.Parameters.AddWithValue("@TranType", strTranType)
        objCommand.Parameters.AddWithValue("@TranDescr", strTranDescr)
        objCommand.Parameters.AddWithValue("@BudgetNumber", strBudgetNumber)
        objCommand.Parameters.AddWithValue("@Amount", dblAmount)
        objCommand.Parameters.AddWithValue("@SDBExportUser", strSDBExportUser)
        objCommand.Parameters.AddWithValue("@SDBExportDate", dtSDBExportDate)
        objCommand.Parameters.AddWithValue("@SDBReportUser", strSDBReportUser)
        objCommand.Parameters.AddWithValue("@SDBReportDate", dtSDBReportDate)
        objCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objCommand.Parameters.AddWithValue("@FASExportUser", strFASExportUser)
        objCommand.Parameters.AddWithValue("@FASExportDate", dtFASExportDate)


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
