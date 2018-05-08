Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subNoteSelect
'*** B. subNoteAction
'*** C. fncNoteCount
'****************************************
'****************************************

Public Class clsNote
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subNoteSelect
    Public Sub subNoteSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intNoteID As Integer, ByVal strNoteType As String, ByVal strModule As String, ByVal intModuleID As String, ByVal strNoteDesc As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim DS As System.Data.DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procNote"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@NoteID", intNoteID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@NoteType", strNoteType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strModule)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ModuleID", intModuleID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@NoteDesc", strNoteDesc)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsNote")

        'Close the database connection...
        objConnection.Close()

        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmCashierActivity-ctrlNote"
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.DataSource = objDataSet
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.DataMember = "dsNote"


                'Setup alternating rows style...
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                'frmJV.CtrlNoteDisplay1.Width = 650
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(0).Visible = False
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(1).Width = 55
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(2).Visible = False
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(3).Visible = False
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(4).Width = 230
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(5).Width = 50
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(6).Width = 80


                'Setup column headers...
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(1).HeaderText = "Type"
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(4).HeaderText = "Note"
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(5).HeaderText = "User Name"
                frmCashierActivity.CtrlNoteDisplay1.grdNoteData.Columns(6).HeaderText = "Date"
            Case "frmCashierBalancing-Sel-Notes"
                frmCashierBalancing.grdNoteData.DataSource = objDataSet
                frmCashierBalancing.grdNoteData.DataMember = "dsNote"


                'Setup alternating rows style...
                frmCashierBalancing.grdNoteData.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmCashierBalancing.grdNoteData.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                'frmJV.Width = 650
                frmCashierBalancing.grdNoteData.Columns(0).Visible = False
                frmCashierBalancing.grdNoteData.Columns(1).Width = 55
                frmCashierBalancing.grdNoteData.Columns(2).Visible = False
                frmCashierBalancing.grdNoteData.Columns(3).Visible = False
                frmCashierBalancing.grdNoteData.Columns(4).Width = 230
                frmCashierBalancing.grdNoteData.Columns(5).Width = 50
                frmCashierBalancing.grdNoteData.Columns(6).Width = 80


                'Setup column headers...
                frmCashierBalancing.grdNoteData.Columns(1).HeaderText = "Type"
                frmCashierBalancing.grdNoteData.Columns(4).HeaderText = "Note"
                frmCashierBalancing.grdNoteData.Columns(5).HeaderText = "User Name"
                frmCashierBalancing.grdNoteData.Columns(6).HeaderText = "Date"
            Case "frmJV-ctrlNote"
                frmJV.CtrlNoteDisplay1.grdNoteData.DataSource = objDataSet
                frmJV.CtrlNoteDisplay1.grdNoteData.DataMember = "dsNote"


                'Setup alternating rows style...
                frmJV.CtrlNoteDisplay1.grdNoteData.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmJV.CtrlNoteDisplay1.grdNoteData.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                'frmJV.CtrlNoteDisplay1.Width = 650
                frmJV.CtrlNoteDisplay1.grdNoteData.Columns(0).Visible = False
                frmJV.CtrlNoteDisplay1.grdNoteData.Columns(1).Width = 55
                frmJV.CtrlNoteDisplay1.grdNoteData.Columns(2).Visible = False
                frmJV.CtrlNoteDisplay1.grdNoteData.Columns(3).Visible = False
                frmJV.CtrlNoteDisplay1.grdNoteData.Columns(4).Width = 230
                frmJV.CtrlNoteDisplay1.grdNoteData.Columns(5).Width = 50
                frmJV.CtrlNoteDisplay1.grdNoteData.Columns(6).Width = 80


                'Setup column headers...
                frmJV.CtrlNoteDisplay1.grdNoteData.Columns(1).HeaderText = "Type"
                frmJV.CtrlNoteDisplay1.grdNoteData.Columns(4).HeaderText = "Note"
                frmJV.CtrlNoteDisplay1.grdNoteData.Columns(5).HeaderText = "User Name"
                frmJV.CtrlNoteDisplay1.grdNoteData.Columns(6).HeaderText = "Date"


            Case "frmSponsor-ctrlNote"
                frmSponsor.CtrlNoteDisplay1.grdNoteData.DataSource = objDataSet
                frmSponsor.CtrlNoteDisplay1.grdNoteData.DataMember = "dsNote"


                'Setup alternating rows style...
                frmSponsor.CtrlNoteDisplay1.grdNoteData.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSponsor.CtrlNoteDisplay1.grdNoteData.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                'frmSponsor.CtrlNoteDisplay1.Width = 650
                frmSponsor.CtrlNoteDisplay1.grdNoteData.Columns(0).Visible = False
                frmSponsor.CtrlNoteDisplay1.grdNoteData.Columns(1).Width = 55
                frmSponsor.CtrlNoteDisplay1.grdNoteData.Columns(2).Visible = False
                frmSponsor.CtrlNoteDisplay1.grdNoteData.Columns(3).Visible = False
                frmSponsor.CtrlNoteDisplay1.grdNoteData.Columns(4).Width = 230
                frmSponsor.CtrlNoteDisplay1.grdNoteData.Columns(5).Width = 50
                frmSponsor.CtrlNoteDisplay1.grdNoteData.Columns(6).Width = 80


                'Setup column headers...
                frmSponsor.CtrlNoteDisplay1.grdNoteData.Columns(1).HeaderText = "Type"
                frmSponsor.CtrlNoteDisplay1.grdNoteData.Columns(4).HeaderText = "Note"
                frmSponsor.CtrlNoteDisplay1.grdNoteData.Columns(5).HeaderText = "User Name"
                frmSponsor.CtrlNoteDisplay1.grdNoteData.Columns(6).HeaderText = "Date"

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objNoteData = New clsNote
        'Call objNoteData.subNoteSelect(strBindTarget:="NONE", strAction:="NONE", intNoteID:=0, strNoteType:="NONE", strModule:="NONE", intModuleID:=0, strNoteDesc:="NONE", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subNoteAction
    Public Sub subNoteAction(ByVal strAction As String, ByVal intNoteID As Integer, ByVal strNoteType As String, ByVal strModule As String, ByVal intModuleID As String, ByVal strNoteDesc As String, ByVal strCreateUser As String, ByVal dtCreateDate As Date)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procNote"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@NoteID", intNoteID)
        objCommand.Parameters.AddWithValue("@NoteType", strNoteType)
        objCommand.Parameters.AddWithValue("@Module", strModule)
        objCommand.Parameters.AddWithValue("@ModuleID", intModuleID)
        objCommand.Parameters.AddWithValue("@NoteDesc", strNoteDesc)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objNoteAction = New clsNote
        'Call objNoteAction.subNoteAction(strAction:="ADD-NOTE", intNoteID:=0, strNoteType:="NONE", strModule:="NONE", intModuleID:=0, strNoteDesc:="NONE", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

    '*** C. fncNoteCount
    Public Function fncNoteCount(ByVal strModule As String, ByVal intModuleID As String) As Integer
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procNote"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", "SELECT-BY-MODULEID")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@NoteID", 0)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@NoteType", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Module", strModule)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ModuleID", intModuleID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@NoteDesc", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", "NONE")
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", "01/01/1900")


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsNoteCount")

        'Close the database connection...
        objConnection.Close()

        Return objDataSet.Tables("dsNoteCount").Rows.Count

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objNoteAction = New clsNote
        'Call objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=0)
        '***********************************************
        '***********************************************
    End Function
End Class
