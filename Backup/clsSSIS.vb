Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

'****************************************
'**** CLASS INDEX ***********************
'*** A. subSSISLaunch
'****************************************
'****************************************

Public Class clsSSIS
    Dim objConnection As New SqlConnection("Data Source=CORNELIUS_SFS.stdacc.washington.edu;Initial Catalog=msdb;Integrated Security=SSPI")

    '*** A. subSSISLaunch
    Public Sub subSSISLaunch(ByVal strJobName As String, ByVal strTempFile As String, ByVal strFilePath As String, ByVal strFileName As String)
        Dim objCommand As SqlCommand = New SqlCommand()
        'Dim intPauseCounter As Long
        objCommand.Connection = objConnection
        objCommand.CommandText = "sp_start_job"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@job_name", strJobName)

        If File.Exists(strTempFile) = True Then
            File.Delete(strTempFile)
        End If

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        Cursor.Current = Cursors.WaitCursor

        Do While File.Exists(strTempFile) = False
            'Loop until file has been created...
        Loop
        Dim intCounter As Long
        intCounter = 0
        Do While intCounter <> 99999999
            intCounter = intCounter + 1
        Loop
        MsgBox("Press any key to continue")
        If File.Exists(strFilePath & strFileName) = True Then
            'Delete Old File
            File.Delete(strFilePath & strFileName)
            MsgBox("Press any key to continue")
            'Copy File to Proper Location
            Do While File.Exists(strFilePath & strFileName) = True
                'Loop until file has been deleted...
                MsgBox("Press any key to continue")
            Loop
            File.Copy(strTempFile, strFilePath & strFileName)
            MsgBox("Press any key to continue")
        Else
            'Copy File to Proper Location
            File.Copy(strTempFile, strFilePath & strFileName)
            MsgBox("Press any key to continue")
        End If

        Cursor.Current = Cursors.Arrow
        If strJobName <> "FAS_JV_Export_Excel" Then
            MsgBox("File has been successfully exported to " & strFilePath & strFileName)
        End If

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objSSISAction = New clsSSIS
        'Call objSSISAction.subSSISLaunch(strJobName:="ELM_Roster_Export", strTempFile:="\\cornelius_sfs.stdacc.washington.edu\SFS_DTS\Test.xls", strFilePath:="I:\groups\sfs\computing\dbases\elm\data\Excel\", strFileName:="ElmRoster_" & CStr(grdDataList(4, intRowValue).Value) & ".xls")
        '***********************************************
        '***********************************************
    End Sub

End Class
