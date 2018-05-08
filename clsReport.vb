Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.SqlClient

Public Class clsReport

    Dim objConnection As New SqlConnection _
        (frmMainMenu.strSFSCon)

    Public Sub subExportRosterToExcel()
        'ELM Roster Excel Export
        frmMainMenu.txtModule.Text = "ELM-SEARCH"
        frmMainMenu.txtAction.Text = "BATCH"

        'Set the parent of module menu screen and open it...
        SearchMenu.MdiParent = frmMainMenu
        SearchMenu.Show()
        SearchMenu.grdDataList.EditMode = DataGridViewEditMode.EditProgrammatically
        frmReportMenu.Close()
    End Sub

    Public Sub subExportMERCRosterToExcel()
        'ELM Roster Excel Export
        frmMainMenu.txtModule.Text = "MERC-SEARCH"
        frmMainMenu.txtAction.Text = "BATCH"

        'Set the parent of module menu screen and open it...
        SearchMenu.MdiParent = frmMainMenu
        SearchMenu.Show()
        SearchMenu.grdDataList.EditMode = DataGridViewEditMode.EditProgrammatically
        frmReportMenu.Close()
    End Sub

    Public Sub subReportSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal strModule As String, ByVal intReportID As Integer)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager


        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procReport"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strModule)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ReportID", intReportID)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsReport")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmReportMenu"
                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsReport"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmReportMenu.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmReportMenu.lstReport.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmReportMenu.lstReport.DataSource = objDataSet.Tables("dsReport")
                frmReportMenu.lstReport.DisplayMember = "ReportName"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objReportData = New clsReport
        'Call objReportData.subReportSelect(strBindTarget:="frmReportMenu", strAction:="SELECT-ELM-REPORTS", strModule:="ELM", intReportID:=0)
        '***********************************************
        '***********************************************
    End Sub

    Public Sub subReportOpen(ByVal intReportID As String, ByVal strReportPath As String, _
        ByVal strParameter1Name As String, ByVal strParameter1Value As String, _
        ByVal strParameter2Name As String, ByVal strParameter2Value As String, _
        ByVal strParameter3Name As String, ByVal strParameter3Value As String, _
        ByVal strParameter4Name As String, ByVal strParameter4Value As String, _
        ByVal strParameter5Name As String, ByVal strParameter5Value As String, _
        ByVal strParameter6Name As String, ByVal strParameter6Value As String, _
        ByVal strParameter7Name As String, ByVal strParameter7Value As String, _
        ByVal strParameter8Name As String, ByVal strParameter8Value As String, _
        ByVal strParameter9Name As String, ByVal strParameter9Value As String, _
        ByVal strParameter10Name As String, ByVal strParameter10Value As String, _
        ByVal strParameter11Name As String, ByVal strParameter11Value As String, _
        ByVal strParameter12Name As String, ByVal strParameter12Value As String)

        'Set the parent of module menu screen and open it...
        SearchMenu.MdiParent = frmMainMenu
        frmReportViewer.Show()

        Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        '*************************************

        'Declare variables needed to pass the parameters to the viewer control.
        Dim paramFields As New CrystalDecisions.Shared.ParameterFields
        Dim paramField As New CrystalDecisions.Shared.ParameterField
        Dim discreteVal As New CrystalDecisions.Shared.ParameterDiscreteValue

        If strParameter1Name <> "NONE" Then
            ' The first parameter is a discrete parameter with multiple values.
            ' Set the name of the parameter field, this must match a parameter in the report.
            paramField.ParameterFieldName = strParameter1Name
            '*** SETTING THE FIRST DISCRETE VALUE & PASS IT TO THE PARAMETER ***
            discreteVal.Value = strParameter1Value
            paramField.CurrentValues.Add(discreteVal)
            '*** ADDING THE PARAMETER TO THE PARAMETER FIELDS COLLECTION ***
            paramFields.Add(paramField)
        End If

        If strParameter2Name <> "NONE" Then
            '*** PASSING A SECOND PARAMETER (DISCRETE VALUE) ***
            paramField = New CrystalDecisions.Shared.ParameterField
            paramField.ParameterFieldName = strParameter2Name
            discreteVal = New CrystalDecisions.Shared.ParameterDiscreteValue
            discreteVal.Value = strParameter2Value
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)
        End If

        If strParameter3Name <> "NONE" Then
            '*** PASSING A THIRD PARAMETER (DISCRETE VALUE) ***
            paramField = New CrystalDecisions.Shared.ParameterField
            paramField.ParameterFieldName = strParameter3Name
            discreteVal = New CrystalDecisions.Shared.ParameterDiscreteValue
            discreteVal.Value = strParameter3Value
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)
        End If

        If strParameter4Name <> "NONE" Then
            '*** PASSING A FOURTH PARAMETER (DISCRETE VALUE) ***
            paramField = New CrystalDecisions.Shared.ParameterField
            paramField.ParameterFieldName = strParameter4Name
            discreteVal = New CrystalDecisions.Shared.ParameterDiscreteValue
            discreteVal.Value = strParameter4Value
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)
        End If

        If strParameter5Name <> "NONE" Then
            '*** PASSING A FOURTH PARAMETER (DISCRETE VALUE) ***
            paramField = New CrystalDecisions.Shared.ParameterField
            paramField.ParameterFieldName = strParameter5Name
            discreteVal = New CrystalDecisions.Shared.ParameterDiscreteValue
            discreteVal.Value = strParameter5Value
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)
        End If

        If strParameter6Name <> "NONE" Then
            '*** PASSING A FOURTH PARAMETER (DISCRETE VALUE) ***
            paramField = New CrystalDecisions.Shared.ParameterField
            paramField.ParameterFieldName = strParameter6Name
            discreteVal = New CrystalDecisions.Shared.ParameterDiscreteValue
            discreteVal.Value = strParameter6Value
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)
        End If

        If strParameter7Name <> "NONE" Then
            '*** PASSING A FOURTH PARAMETER (DISCRETE VALUE) ***
            paramField = New CrystalDecisions.Shared.ParameterField
            paramField.ParameterFieldName = strParameter7Name
            discreteVal = New CrystalDecisions.Shared.ParameterDiscreteValue
            discreteVal.Value = strParameter7Value
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)
        End If

        If strParameter8Name <> "NONE" Then
            '*** PASSING A FOURTH PARAMETER (DISCRETE VALUE) ***
            paramField = New CrystalDecisions.Shared.ParameterField
            paramField.ParameterFieldName = strParameter8Name
            discreteVal = New CrystalDecisions.Shared.ParameterDiscreteValue
            discreteVal.Value = strParameter8Value
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)
        End If

        If strParameter9Name <> "NONE" Then
            '*** PASSING A FOURTH PARAMETER (DISCRETE VALUE) ***
            paramField = New CrystalDecisions.Shared.ParameterField
            paramField.ParameterFieldName = strParameter9Name
            discreteVal = New CrystalDecisions.Shared.ParameterDiscreteValue
            discreteVal.Value = strParameter9Value
            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)
        End If

        ' put code  here and test - then publish - Andrew test?  - test 

        If InStr(strReportPath, "UWSDB") <= 0 Then
            frmReportViewer.CrystalReportViewer1.ReportSource = strReportPath    'objReport
            frmReportViewer.CrystalReportViewer1.ParameterFieldInfo = paramFields
            frmReportViewer.CrystalReportViewer1.Show()
            frmReportViewer.CrystalReportViewer1.DisplayGroupTree = False
            Exit Sub
        Else
            MsgBox(" ALL UWSDB Reports have been retired - Contact Computing Unit")
        End If

    End Sub
    ''  ****************UWSDB Reports have been retired ******************************

    ''This code will be used for Crystal reports accessing tables in the data warehouse via sfstech
    '' reports will have UWSDB somewhere in the report name

    ''*** DON'T FORGET TO ALWAYS ADD THE PARAMETER TO THE PARAMFIELDS AFTER ENTERING THE VALUE *** IT MUST BE ADDED AFTER EACH NEW PARAMETER ***
    ''*** SET THE PARAMETER FIELDS COLLECTION INTO THE VIEWER CONTROL ***

    'Dim logonInfo As New CrystalDecisions.Shared.TableLogOnInfo()
    'Dim objTable As CrystalDecisions.CrystalReports.Engine.Table
    'Dim objReport As New ReportDocument()
    'Dim strTablename As String

    'Dim rptSub As ReportDocument
    'Dim rptSubDoc As ReportDocument

    '    Application.DoEvents()
    '    objReport.Load(strReportPath) 'you assign full path with file name here

    '' set the logon information for each table.
    '    For Each objTable In objReport.Database.Tables
    '        strTablename = objTable.Name.ToString
    '' get the TableLogOnInfo object.
    '        logonInfo = objTable.LogOnInfo
    '' set the server or ODBC data source name, database name,
    '' user ID, and password.  Note tbl is the naming convention for SFS database
    ''Dim strT As String = strTablename.Substring(0, 4)
    '        If strTablename.Substring(0, 3) = "tbl" Or strTablename.Substring(0, 4) = "proc" Then
    '            logonInfo.ConnectionInfo.ServerName = frmMainMenu.SFS_Server_Name
    '            logonInfo.ConnectionInfo.DatabaseName = frmMainMenu.SFS_DB_Name
    '        Else
    ''  Dim strT As String = strTablename.Substring(0, 3)
    '            logonInfo.ConnectionInfo.ServerName = frmMainMenu.UWSDB_Server_Name
    '            logonInfo.ConnectionInfo.DatabaseName = frmMainMenu.UWSDB_DB_Name
    ''testing
    '            logonInfo.ConnectionInfo.UserID = frmMainMenu.SFS_Tech_U
    '            logonInfo.ConnectionInfo.Password = frmMainMenu.SFS_Tech_P
    '        End If
    '        objTable.ApplyLogOnInfo(logonInfo)

    '    Next objTable
    '' set the logon information for each table for subreports
    '    If strReportPath = frmMainMenu.SFS_PRODUCTION_FOLDER & "rptUWSDB_ReconBudgetReport.rpt" Or strReportPath = frmMainMenu.SFS_PRODUCTION_FOLDER & "rptUWSDB_ReconBudget_Report.rpt" Then
    '        For Each rptSub In objReport.Subreports
    '            rptSubDoc = objReport.OpenSubreport(rptSub.Name)
    '            For Each objTable In rptSubDoc.Database.Tables
    '                strTablename = objTable.Name.ToString
    '' get the TableLogOnInfo object.
    '                logonInfo = objTable.LogOnInfo
    '' set the server or ODBC data source name, database name,
    '' user ID, and password.  Note tbl is the naming convention for SFS database
    '                If strTablename.Substring(0, 3) = "tbl" Then
    '                    logonInfo.ConnectionInfo.ServerName = frmMainMenu.SFS_Server_Name
    '                    logonInfo.ConnectionInfo.DatabaseName = frmMainMenu.SFS_DB_Name
    '                Else
    '                    logonInfo.ConnectionInfo.ServerName = frmMainMenu.UWSDB_Server_Name
    '                    logonInfo.ConnectionInfo.DatabaseName = frmMainMenu.UWSDB_DB_Name
    '                End If
    '                logonInfo.ConnectionInfo.UserID = frmMainMenu.SFS_Tech_U
    '                logonInfo.ConnectionInfo.Password = frmMainMenu.SFS_Tech_P
    '' Apply the connection information to the table.
    '                objTable.ApplyLogOnInfo(logonInfo)
    '            Next objTable
    '        Next
    '    End If

    '    frmReportViewer.CrystalReportViewer1.ReportSource = objReport
    ''frmReportViewer.TopLevel = False
    '    frmReportViewer.CrystalReportViewer1.ParameterFieldInfo = paramFields
    '    frmReportViewer.CrystalReportViewer1.Show()
    '    frmReportViewer.CrystalReportViewer1.DisplayGroupTree = False

    'End Sub
    Private Sub subCrystalSecure()



    End Sub


    Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs)
        e.Handled = True
    End Sub

    Public Sub subReportOpenSingle(ByVal intReportID As String, ByVal strReportPath As String)

        Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'Set the parent of module menu screen and open it...
        SearchMenu.MdiParent = frmMainMenu
        frmReportViewer.Show()

        'Dim strReportPath As String
        Dim cr As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        cr.Load(strReportPath)
        'frmReportViewer.CrystalReportViewer1.LogOnInfo.r()
        frmReportViewer.CrystalReportViewer1.ReportSource = strReportPath
        frmReportViewer.CrystalReportViewer1.Refresh()
        frmReportViewer.CrystalReportViewer1.DisplayGroupTree = False

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objReportAction = New clsReport
        'Call objReportAction.subReportOpen(intReportID:=0, strReportPath:="I:\groups\sfs\dbases\SFS\Reports\rptCTSummary.rpt")
        '***********************************************
        '***********************************************
    End Sub
End Class
