Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subWEBCCSelect
'*** B. subWEBCCAction
'****************************************
'****************************************


Public Class clsWEBCC
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subWEBCCSelect
    Public Sub subWEBCCSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal strStudentID As String, ByVal strLName As String, ByVal strFName As String, ByVal intClass As Integer, ByVal strMajor As String, ByVal strBranch As String, ByVal strPath As String, ByVal strxLevel As String, ByVal amtCredit As Double, ByVal amtDebit As Double, ByVal strTransDate As String, ByVal strTransCode As String, ByVal strConfirmationNum As String, ByVal strWebUser As String, ByVal strImportFileName As String, ByVal strImportUser As String, ByVal strImportDate As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim DS As System.Data.DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procERGO_WEBCC"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StudentID", strStudentID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@LName", strLName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FName", strFName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Class", intClass)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Major", strMajor)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Branch", strBranch)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Path", strPath)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@xLevel", strxLevel)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Credit", amtCredit)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Debit", amtDebit)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TransDate", strTransDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@TransCode", strTransCode)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ConfirmationNum", strConfirmationNum)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@WebUser", strWebUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportFileName", strImportFileName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportDate", strImportDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsWEBCC")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmExport"
                'Set the DataGridView properties to bind it to the data...
                frmExport.grdDataList.DataSource = objDataSet
                frmExport.grdDataList.DataMember = "dsWEBCC"

                'Setup alternating rows style...
                frmExport.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmExport.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                ''Setup column widths...
                'frmExport.grdDataList.Columns(0).Width = 80
                'frmExport.grdDataList.Columns(1).Width = 80
                'frmExport.grdDataList.Columns(2).Width = 40
                'frmExport.grdDataList.Columns(3).Width = 70
                'frmExport.grdDataList.Columns(4).Width = 70
                'frmExport.grdDataList.Columns(5).Width = 70
                'frmExport.grdDataList.Columns(6).Width = 70
                'frmExport.grdDataList.Columns(7).Width = 70

                ''Setup column headers...
                'frmExport.grdDataList.Columns(0).HeaderText = "SSN"
                'frmExport.grdDataList.Columns(1).HeaderText = "System_Key"
                'frmExport.grdDataList.Columns(2).HeaderText = "Loan Type"
                'frmExport.grdDataList.Columns(3).HeaderText = "Signed Date"
                'frmExport.grdDataList.Columns(4).HeaderText = "Import Date"
                'frmExport.grdDataList.Columns(5).HeaderText = "Import User"
                'frmExport.grdDataList.Columns(6).HeaderText = "Sent to SDB Date"
                'frmExport.grdDataList.Columns(7).HeaderText = "Sent to SDB User"
            Case "frmSearch-By-TranDate"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsWEBCC"

                'Setup form title...
                SearchMenu.Text = "Select Extract Data"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 60
                SearchMenu.grdDataList.Columns(1).Width = 40
                SearchMenu.grdDataList.Columns(2).Width = 65
                SearchMenu.grdDataList.Columns(3).Width = 65
                SearchMenu.grdDataList.Columns(4).Width = 65
                SearchMenu.grdDataList.Columns(5).Width = 125
                SearchMenu.grdDataList.Columns(6).Width = 60
                SearchMenu.grdDataList.Columns(7).Width = 60

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Tran Date"
                SearchMenu.grdDataList.Columns(1).HeaderText = "# of Tran"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Credits"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Debits"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Total"
                SearchMenu.grdDataList.Columns(5).HeaderText = "File Name"
                SearchMenu.grdDataList.Columns(6).HeaderText = "Imported By"
                SearchMenu.grdDataList.Columns(7).HeaderText = "Import Date"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objWEBCC = New clsWEBCC
        'Call objWEBCC.subWEBCCSelect(strBindTarget:="NONE", strAction:="SELECT", strStudentID:="NONE", _
        'strLName:="NONE", strFName:="NONE", intClass:=0, strMajor:="NONE", strBranch:="NONE", strPath:="NONE", _
        'strxLevel:="NONE", amtCredit:=0, amtDebit:=0, strTransDate:="NONE", strTransCode:="NONE", _
        'strConfirmationNum:="NONE", strWebUser:="NONE", strImportFileName:="NONE", strImportUser:="NONE", _
        'strImportDate:="NONE")
        '***********************************************
        '***********************************************
    End Sub
End Class
