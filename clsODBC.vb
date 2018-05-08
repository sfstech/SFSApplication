Imports System.Data.Odbc

'****************************************
'**** CLASS INDEX ***********************
'*** A. subTestDSN
'****************************************
'****************************************
Public Class clsODBC

    Function subTestDSN(ByVal strDSNname As String) As String
        Dim strPassFail As String = "Pass"
        Try
            Dim conn As OdbcConnection = New OdbcConnection()
            conn.ConnectionString = "Dsn=" + strDSNname + ";" '  + "Uid=UserName;" + "Pwd=Secret;"
            conn.Open()
            conn.Close()
        Catch ex As Exception
            MsgBox("You need additional setup before proceeding - Contact SFS Computing.", MsgBoxStyle.Exclamation, "Missing ODBC Setup")
            strPassFail = "Fail"
        End Try
        Return strPassFail
    End Function
End Class
