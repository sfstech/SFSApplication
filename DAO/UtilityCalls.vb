Imports System.Data.SqlClient

Public Class UtilityCalls
    ''' <summary>
    ''' gets parameters  from parameters table
    ''' used for global date for example
    ''' </summary>
    ''' <param name="paramname"></param>
    ''' <param name="processname"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function getParameter(paramname As String, processname As String) As String
        Dim result As String = ""
        Try

            Using connection As New SqlConnection(My.Settings.SFSConnectionString)
                Dim command As New SqlCommand()
                Dim reader As SqlDataReader
                command.CommandText = "select parameter_value from dbo.tblAppParameters where parameter_name = @paramname and process_name = @processname"
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@paramname", paramname)
                command.Parameters.AddWithValue("@processname", processname)
                command.Connection = connection
                command.Connection.Open()
                reader = command.ExecuteReader()
                If reader.HasRows Then
                    If reader.Read Then
                        result = reader.GetString(0)

                        reader.Close()
                    End If
                End If
                command.Connection.Close()
            End Using

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        Return result
    End Function
    ''' <summary>
    ''' Deletes record from specified table at specified rowid
    ''' </summary>
    ''' <param name="table"></param>
    ''' <param name="rowid"></param>
    ''' <remarks></remarks>
    Shared Sub deleteRecord(table As String, rowid As Integer)
        Try

            Using connection As New SqlConnection(My.Settings.SFSConnectionString)
                Dim command As New SqlCommand()
                Dim reader As SqlDataReader
                command.CommandText = "delete from " + table + " where rowid = @rowid"
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@rowid", rowid)
                command.Connection = connection
                command.Connection.Open()
                reader = command.ExecuteReader()
                command.Connection.Close()
            End Using

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' gets list of reports from the specified folder
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function getReports(path As String) As DataTable
        Dim result As DataTable = Nothing
        Dim uri As New Uri("http://sfssql1.admin.washington.edu/Reports/Pages/Report.aspx?ItemPath=")
        Dim query As String = "SELECT path, name FROM reportserver.dbo.Catalog  WHERE Type = 2 AND path = @path"
        Try
            Using connection As New SqlConnection(My.Settings.ReportingServices)
                Dim command As New SqlCommand()
                Dim sa As New SqlDataAdapter(query, connection)
                command.CommandText = query
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@path", path)
                command.Connection = connection
                command.Connection.Open()
                sa.Fill(result)
                If result.HasErrors Then
                    Return result
                End If
                command.Connection.Close()
            End Using

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        Return result
    End Function
End Class
