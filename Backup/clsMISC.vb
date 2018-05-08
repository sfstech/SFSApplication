Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subMISCSelect
'*** B. subMISCAction

'****************************************
'****************************************

Public Class clsMISC

    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subMISCSelect



    '*** B. subMISCAction
    Public Sub subMISCAction(ByVal strAction As String, ByVal dtMISCDate As Date, ByVal strMISCString As String, ByVal intMISCID As Integer, ByVal intPersonID As Integer, ByVal strCreateUser As String)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procMISC"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@MiscDate", dtMISCDate)
        objCommand.Parameters.AddWithValue("@MiscString", strMISCString)
        objCommand.Parameters.AddWithValue("@MiscID", intMISCID)
        objCommand.Parameters.AddWithValue("@PersonID", intPersonID)
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
        ' objMISCAction = New clsMISC
        'Call objMISCAction.subMISCAction(strAction:="CREATE-FAS-EXPORT", dtMISCDate:="01/01/1900", strMISCString:="NONE", intMISCID:=0, intPersonID:=0,  strCreateUser:="NONE")
        '***********************************************
        '***********************************************
    End Sub

End Class
