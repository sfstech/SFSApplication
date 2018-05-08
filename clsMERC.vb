Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subMERCSelect
'*** B. subMERCAction
'*** C. fncGetMercBatchNumber
'*** D. subGetMerchantNumber
'****************************************
'****************************************

Public Class clsMERC

    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subMERCSelect
    Public Sub subMERCSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal dtMercDate As Date, ByVal strMercString As String, ByVal intMerchantID As Integer, ByVal intPersonID As Integer, ByVal strCreateUser As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim DS As System.Data.DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procMerc"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure


        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MercDate", dtMercDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MercString", strMercString)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@MerchantID", intMerchantID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PersonID", intPersonID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@UserName", strCreateUser)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsMERC")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch-MERC-Batch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsMERC"

                'Setup form title...
                SearchMenu.Text = "Merchant Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Width = 100
                SearchMenu.grdDataList.Columns(1).Width = 50
                SearchMenu.grdDataList.Columns(2).Width = 100
                SearchMenu.grdDataList.Columns(3).Width = 100
                SearchMenu.grdDataList.Columns(4).Visible = False
                SearchMenu.grdDataList.Columns(5).Width = 100
                SearchMenu.grdDataList.Columns(6).Visible = False

                'Setup column headers...
                SearchMenu.grdDataList.Columns(0).HeaderText = "Date"
                SearchMenu.grdDataList.Columns(1).HeaderText = "Batch #"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Total"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(5).HeaderText = "CT File"
        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objMercData = New clsMerc
        'Call objMercData.subMERCSelect(strBindTarget:="NONE", strAction:="SELECT", dtMercDate:="01/01/1900", strMercString:="NONE", 
        'intMerchantID:=0,intPersonID:=0, strCreateUser:="NONE")
        '***********************************************
        '***********************************************
    End Sub


    '*** B. subMERCAction
    ''' <summary>
    ''' procMerc
    ''' </summary>

    Public Sub subMERCAction(ByVal strAction As String, ByVal dtMercDate As Date, ByVal strMercString As String, ByVal intMerchantID As Integer, ByVal intPersonID As Integer, ByVal strCreateUser As String)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procMerc"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@MercDate", dtMercDate)
        objCommand.Parameters.AddWithValue("@MercString", strMercString)
        objCommand.Parameters.AddWithValue("@MerchantID", intMerchantID)
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
        ' objMercAction = New clsMerc
        'Call objMercAction.subMercAction(strAction:="CREATE-FAS-EXPORT", dtMercDate:="01/01/1900", strMercString:="NONE", intMerchantID:=0, intPersonID:=0,  strCreateUser:="NONE")
        '***********************************************
        '***********************************************
    End Sub


    '*** D. subGetMerchantNumber
    Public Function fncGetMerchantNumber(ByVal strOldMerchantNumber As String) As String
        Dim strNewMerchantNumber As String
        Dim strPassFail As String
        'Dim txtMerchantNum As String

        'txtMerchantNum = "0"

        strPassFail = "Fail"
        'MsgBox(Microsoft.VisualBasic.Left(strOldMerchantNumber, 8))
        If Microsoft.VisualBasic.Left(strOldMerchantNumber, 8) = "60110141" And strPassFail = "Fail" Then
            strPassFail = "Pass"
            strNewMerchantNumber = "4" & Microsoft.VisualBasic.Right(strOldMerchantNumber, 7)
        End If

        If Microsoft.VisualBasic.Left(strOldMerchantNumber, 7) = "4301342" And strPassFail = "Fail" Then
            strPassFail = "Pass"
            strNewMerchantNumber = Microsoft.VisualBasic.Right(strOldMerchantNumber, 8)
        End If

        If Microsoft.VisualBasic.Left(strOldMerchantNumber, 3) = "800" And strPassFail = "Fail" Then
            strPassFail = "Pass"
            strNewMerchantNumber = "5" & Microsoft.VisualBasic.Right(strOldMerchantNumber, 7)
        End If

        If Microsoft.VisualBasic.Left(strOldMerchantNumber, 3) = "801" And strPassFail = "Fail" Then
            strPassFail = "Pass"
            strNewMerchantNumber = "5" & Microsoft.VisualBasic.Right(strOldMerchantNumber, 7)
        End If

        If Microsoft.VisualBasic.Left(strOldMerchantNumber, 3) = "802" And strPassFail = "Fail" Then
            strPassFail = "Pass"
            strNewMerchantNumber = "5" & Microsoft.VisualBasic.Right(strOldMerchantNumber, 7)
        End If

        'adding 803 per andrews request
        '6/14/2016
        If Microsoft.VisualBasic.Left(strOldMerchantNumber, 3) = "803" And strPassFail = "Fail" Then
            strPassFail = "Pass"
            strNewMerchantNumber = "5" & Microsoft.VisualBasic.Right(strOldMerchantNumber, 7)
        End If

        If Microsoft.VisualBasic.Left(strOldMerchantNumber, 3) = "070" And strPassFail = "Fail" Then
            strPassFail = "Pass"
            strNewMerchantNumber = "5" & Microsoft.VisualBasic.Right(strOldMerchantNumber, 7)
        End If

        If Microsoft.VisualBasic.Left(strOldMerchantNumber, 3) = "950" And strPassFail = "Fail" Then
            strPassFail = "Pass"
            strNewMerchantNumber = "5" & Microsoft.VisualBasic.Right(strOldMerchantNumber, 7)
        End If

        If Microsoft.VisualBasic.Left(strOldMerchantNumber, 3) = "546" And strPassFail = "Fail" Then
            strPassFail = "Pass"
            strNewMerchantNumber = "75" & Microsoft.VisualBasic.Mid(strOldMerchantNumber, 4, 6)
        End If

        If Microsoft.VisualBasic.Left(strOldMerchantNumber, 7) = "4301388" And strPassFail = "Fail" Then
            strPassFail = "Pass"
            strNewMerchantNumber = Microsoft.VisualBasic.Right(strOldMerchantNumber, 8)
        End If
        If Microsoft.VisualBasic.Len(strOldMerchantNumber) = 5 And strPassFail = "Fail" Then
            strPassFail = "Pass"
            strNewMerchantNumber = strOldMerchantNumber
        End If
        If strPassFail = "Pass" Then
            Return strNewMerchantNumber
        Else
            MsgBox("Error- can not create Merchant Abbrv")
            Return "ERR"
        End If

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objMercAction = New clsMerc
        'Call objMercAction.fncGetNewMerchantNumber(strOldMerchantNumber:=me.txtMerchantNumber.text)
        '***********************************************
        '***********************************************


    End Function
End Class
