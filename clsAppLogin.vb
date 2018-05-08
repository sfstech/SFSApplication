Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subAppLoginSelect

'*** B. subAppAction

'****************************************
'****************************************

Public Class clsAppLogin
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subAppLoginSelect
    Public Sub subAppLoginSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intAppID As Integer, _
    ByVal intPersonID As Integer, ByVal strAppName As String, ByVal strAppUserName As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "[procAppLogin]"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AppID", intAppID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@PersonID", intPersonID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AppName", strAppName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AppUserName", strAppUserName)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsAppLogin")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct form...
        Select Case strBindTarget
            Case "frmStaff"
                'Set the DataGridView properties to bind it to the data...
                frmStaff.grdAppLogin.DataSource = objDataSet
                frmStaff.grdAppLogin.DataMember = "dsAppLogin"

                'Setup form title...
                frmStaff.Text = "Select Application"

                'Setup alternating rows style...
                frmStaff.grdAppLogin.AutoGenerateColumns = True
                'Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                'objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                'frmStaff.grdAppLogin.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmStaff.grdAppLogin.Columns(0).Visible = False
                frmStaff.grdAppLogin.Columns(1).Visible = False
                frmStaff.grdAppLogin.Columns(2).Width = 110
                frmStaff.grdAppLogin.Columns(3).Width = 85
                frmStaff.grdAppLogin.Columns(4).Visible = False
                frmStaff.grdAppLogin.Columns(5).Visible = False


                'Setup column headers...
                frmStaff.grdAppLogin.Columns(2).HeaderText = "Application"
                frmStaff.grdAppLogin.Columns(3).HeaderText = "User Name"

               
        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objAppLoginData = New clsAppLogin
        'Call objAppLoginData.subAppLoginSelect(strBindTarget:="frmStaff", strAction:="SELECT-APP", _
        'intAppID:=0, intPersonID:=frmMainMenu.txtActionID.Text, strAppName:="NONE", strAppUserName:="NONE", _
        'strCreateUser:=SystemInformation.UserName, dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************

    End Sub

    ''*** B. subAppAction
    Public Sub subAppAction(ByVal strAction As String, ByVal intAppID As Integer, _
   ByVal intPersonID As Integer, ByVal strAppName As String, ByVal strAppUserName As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "[procAppLogin]"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@AppID", intAppID)
        objCommand.Parameters.AddWithValue("@PersonID", intPersonID)
        objCommand.Parameters.AddWithValue("@AppName", strAppName)
        objCommand.Parameters.AddWithValue("@AppUserName", strAppUserName)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '    '***********************************************
        '    '******************* ACTION CODE ***************
        ''    '***********************************************
        'objAppLoginData = New clsAppLogin
        'Call objAppLoginData.subAppAction(strAction:="ADD", _
        'intAppID:=0, intPersonID:=frmMainMenu.txtActionID.Text, strAppName:=Me.cboAppName.Text, strAppUserName:=Me.txtAppUserName.Text, _
        'strCreateUser:=SystemInformation.UserName, dtCreateDate:=System.DateTime.Now)

        '    '***********************************************
        '    '***********************************************
    End Sub

   
End Class