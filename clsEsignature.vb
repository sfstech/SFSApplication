Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subEsignatureSelect
'*** B. subEsignatureAction
'****************************************
'****************************************

Public Class clsEsignature
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subEsignatureSelect
    Public Sub subEsignatureSelect(ByVal strBindTarget As String, ByVal strAction As String, _
        ByVal intss_no As Integer, ByVal intsystem_key As Integer, _
        ByVal strLoanType As String, ByVal strSignedDate As String, _
        ByVal dtImport As Date, ByVal strImportUser As String, _
        ByVal dtSentToSDB As Date, ByVal strSentToSDBUser As String)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim DS As System.Data.DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procEsignature"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ss_no", intss_no)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@system_key", intsystem_key)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@LoanType", strLoanType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SignedDate", strSignedDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportDate", dtImport)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SentToSDBDate", dtSentToSDB)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SentToSDBUser", strSentToSDBUser)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsEsignature")

        'Close the database connection...
        objConnection.Close()

        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsEsignature"

                'Setup form title...
                SearchMenu.Text = "Select eMPN Data"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 80
                SearchMenu.grdDataList.Columns(1).Width = 80
                SearchMenu.grdDataList.Columns(2).Width = 80

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Import Date"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Import User"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Count"

            Case "frmExport-Grid"
                Dim strFileName As String


                'Get Calendar Month...
                If DatePart("m", Format(System.DateTime.Now, "short date")) <= 9 Then
                    strFileName = "esign_0" & DatePart("m", Format(System.DateTime.Now, "short date"))
                Else
                    strFileName = "esign_" & DatePart("m", Format(System.DateTime.Now, "short date"))
                End If

                'Get Calendar Day...
                If DatePart("d", Format(System.DateTime.Now, "short date")) <= 9 Then
                    strFileName = strFileName & "0" & DatePart("d", Format(System.DateTime.Now, "short date"))
                Else
                    strFileName = strFileName & DatePart("d", Format(System.DateTime.Now, "short date"))
                End If
                strFileName = strFileName & DatePart("yyyy", Format(System.DateTime.Now, "short date")) & ".dat"
                frmExport.txtFileName.Text = strFileName
                'Set the DataGridView properties to bind it to the data...
                frmExport.grdDataList.DataSource = objDataSet
                frmExport.grdDataList.DataMember = "dsEsignature"

                'Setup alternating rows style...
                frmExport.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmExport.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmExport.grdDataList.Columns(0).Width = 80
                frmExport.grdDataList.Columns(1).Width = 80
                frmExport.grdDataList.Columns(2).Width = 40
                frmExport.grdDataList.Columns(3).Width = 70
                frmExport.grdDataList.Columns(4).Width = 70
                frmExport.grdDataList.Columns(5).Width = 70
                frmExport.grdDataList.Columns(6).Width = 70
                frmExport.grdDataList.Columns(7).Width = 70

                'Setup column headers...
                frmExport.grdDataList.Columns(0).HeaderText = "SSN"
                frmExport.grdDataList.Columns(1).HeaderText = "System_Key"
                frmExport.grdDataList.Columns(2).HeaderText = "Loan Type"
                frmExport.grdDataList.Columns(3).HeaderText = "Signed Date"
                frmExport.grdDataList.Columns(4).HeaderText = "Import Date"
                frmExport.grdDataList.Columns(5).HeaderText = "Import User"
                frmExport.grdDataList.Columns(6).HeaderText = "Sent to SDB Date"
                frmExport.grdDataList.Columns(7).HeaderText = "Sent to SDB User"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objEsignatureData = New clsEsignature
        'Call objEsignatureData.subEsignatureSelect(strBindTarget:="frmSearch", strAction:="SELECT-UNEXPORTED", _
        'intss_no:=0, intsystem_key:=0, strLoanType:="?", strSignedDate:="00000000",  _
        'dtImport:="01/01/1900", strImportUser:="NONE", dtSentToSDB:="01/01/1900", strSentToSDBUser:="NONE")
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subEsignatureAction
    Public Sub subEsignatureAction(ByVal strAction As String, _
        ByVal intss_no As Integer, ByVal intsystem_key As Integer, _
        ByVal strLoanType As String, ByVal strSignedDate As String, _
        ByVal dtImport As Date, ByVal strImportUser As String, _
        ByVal dtSentToSDB As Date, ByVal strSentToSDBUser As String)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procEsignature"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@ss_no", intss_no)
        objCommand.Parameters.AddWithValue("@system_key", intsystem_key)
        objCommand.Parameters.AddWithValue("@LoanType", strLoanType)
        objCommand.Parameters.AddWithValue("@SignedDate", strSignedDate)
        objCommand.Parameters.AddWithValue("@ImportDate", dtImport)
        objCommand.Parameters.AddWithValue("@ImportUser", strImportUser)
        objCommand.Parameters.AddWithValue("@SentToSDBDate", dtSentToSDB)
        objCommand.Parameters.AddWithValue("@SentToSDBUser", strSentToSDBUser)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objEsignatureAction = New clsEsignature
        'Call objEsignatureAction.subEsignatureAction(strAction:="VERIFY", _
        'intss_no:=0, intsystem_key:=0, strLoanType:="?", strSignedDate:="00000000",  _
        'dtImport:="01/01/1900", strImportUser:="NONE", dtSentToSDB:="01/01/1900", strSentToSDBUser:="NONE")
        '***********************************************
        '***********************************************
    End Sub
End Class
