'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

'****************************************
'**** CLASS INDEX ***********************
'*** A. subFileTransfer
'*** B. subFileTransferAction
'****************************************
'****************************************

Public Class clsFileTransfer
    Dim objConnection As New SqlConnection _
        (frmMainMenu.strSFSCon)

    '*** A. subFileTransfer
    Public Sub subFileTransfer(ByVal strSource As String, ByVal strDestination As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        File.Copy(strSource, strDestination)
        File.Delete(strSource)

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objFileTransfer = New clsFileTransfer
        'Call objFileTransfer.subFileTransfer(strSource:="ssss", strDestination:="sssss", strCreateUser:=SystemInformation.UserName,dtCreateDate:=Format(System.DateTime.Now, "short date"))
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subFileTransferAction
    Public Sub subFileTransferAction(ByVal strAction As String, ByVal intRowID As Integer, _
        ByVal strSource As String, ByVal strDestination As String, _
        ByVal strTransferUser As String, ByVal dtTransferDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procFileTransfer"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@Source", strSource)
        objCommand.Parameters.AddWithValue("@Destination", strDestination)
        objCommand.Parameters.AddWithValue("@TransferUser", strTransferUser)
        objCommand.Parameters.AddWithValue("@TransferDate", dtTransferDate)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objFileTransferAction = New clsFileTransfer
        '        Call subFileTransferAction(strAction:="UPDATE-LOG", intRowID:=0, strSource:=strPathFileName, _
        '            strDestination:=\\nebula2\uw\groups\sfs\invoices\ct\" & strFileNameFull, strCreateUser:=SystemInformation.UserName, dtCreateDate:=Format(System.DateTime.Now, "short date"))
        '***********************************************
        '***********************************************
    End Sub

End Class
