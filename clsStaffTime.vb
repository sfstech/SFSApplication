'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subStaffTimeSelect
'*** B. subStaffTimeAction
'*** C. subTimeSheetSetup
'****************************************
'****************************************

Public Class clsStaffTime
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '*** A. subStaffTimeSelect
    Public Sub subStaffTimeSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal dtStart As Date, _
        ByVal dtStop As Date, ByVal intRowID As Integer, ByVal intStaffID As Integer, _
        ByVal strWorkDay As String, ByVal dtWorkDate As Date, ByVal intHr_Regular As Integer, ByVal intHr_Vac As Integer, _
        ByVal intHr_Sick As Integer, ByVal intHr_OverTime As Integer, ByVal intHr_Other As Integer, _
        ByVal strHr_Other_Desc As String, ByVal intHr_Total As Integer, ByVal strCreateUser As String, _
        ByVal dtCreateDate As Date, ByVal strEmployeeSignOff As String, ByVal dtEmployeeSignOffDate As Date, _
        ByVal strSupervisorSignOff As String, ByVal dtSupervisorSignOffDate As Date, _
        ByVal strAcctSignOff As String, ByVal dtAcctSignOffDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager
        Dim DS As System.Data.DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procStaffTimeSheet"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters...
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StartDate", dtStart)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StopDate", dtStop)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StaffID", intStaffID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@WorkDay", strWorkDay)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@WorkDate", dtWorkDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hr_Regular", intHr_Regular)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hr_Sick", intHr_Sick)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hr_Vac", intHr_Vac)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hr_OverTime", intHr_OverTime)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hr_Other", intHr_Other)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hr_Other_Desc", strHr_Other_Desc)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Hr_Total", intHr_Total)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@EmployeeSignOff", strEmployeeSignOff)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@EmployeeSignOffDate", dtEmployeeSignOffDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SupervisorSignOff", strSupervisorSignOff)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SupervisorSignOffDate", dtSupervisorSignOffDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AcctSignOff", strAcctSignOff)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@AcctSignOffDate", dtAcctSignOffDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsStaffTime")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "Time-Sheet-Check"
                'Open the database connection...
                objConnection.Open()

                'Fill the DataSet object with data...
                DS = New System.Data.DataSet("dsStaffTime")
                objDataAdapter.Fill(DS)

                'Close the database connection...
                objConnection.Close()

                Dim MyTable As DataTable
                'Dim loop1 as Integer
                Dim numrows As Integer
                MyTable = New DataTable
                MyTable = DS.Tables(0)

                numrows = MyTable.Rows.Count

                If numrows = 0 Then
                    If DatePart(DateInterval.Weekday, dtStart) = 1 Or DatePart(DateInterval.Weekday, dtStart) = 7 Then
                        'Weekend - Do Nothing
                        'MsgBox("Weekend - Do Nothing")
                    Else
                        'MsgBox("Add Record")
                        Dim strWorkDayTemp As String
                        Select Case DatePart(DateInterval.Weekday, dtStart)
                            Case 2
                                strWorkDayTemp = "Monday"
                            Case 3
                                strWorkDayTemp = "Tuesday"
                            Case 4
                                strWorkDayTemp = "Wednesday"
                            Case 5
                                strWorkDayTemp = "Thursday"
                            Case 6
                                strWorkDayTemp = "Friday"
                            Case Else
                                strWorkDayTemp = "ERROR"
                        End Select

                        Call subStaffTimeAction(strAction:="INSERT", _
                        dtStart:="01/01/1900", dtStop:="01/01/1900", intRowID:=0, intStaffID:=frmStaffTimeSheet.txtStaffID.Text, strWorkDay:=strWorkDayTemp, _
                        dtWorkDate:=dtStart, intHr_Regular:=0, intHr_Sick:=0, intHr_Vac:=0, intHr_OverTime:=0, intHr_Other:=0, _
                        strHr_Other_Desc:="N/A", intHr_Total:=0, strCreateUser:=SystemInformation.UserName, _
                        dtCreateDate:="01/01/1900", strEmployeeSignOff:="NONE", dtEmployeeSignOffDate:="01/01/1900", _
                        strSupervisorSignOff:="NONE", dtSupervisorSignOffDate:="01/01/1900", strAcctSignOff:="NONE", _
                        dtAcctSignOffDate:="01/01/1900")

                    End If
                Else
                    'Already In System - Do Nothing
                    'MsgBox("Already In System - Do Nothing")
                End If
            Case "frmStaffTimeSheet-Grid"
                'Set the DataGridView properties to bind it to the data...
                frmStaffTimeSheet.dgvTimeSheet.DataSource = objDataSet
                frmStaffTimeSheet.dgvTimeSheet.DataMember = "dsStaffTime"

                'Setup alternating rows style...
                'frmStaffTimeSheet.dgvTimeSheet.AutoGenerateColumns = True
                'Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                'objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                'frmStaffTimeSheet.dgvTimeSheet.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmStaffTimeSheet.dgvTimeSheet.Columns(0).Visible = False
                frmStaffTimeSheet.dgvTimeSheet.Columns(1).Visible = False
                frmStaffTimeSheet.dgvTimeSheet.Columns(2).Width = 80
                frmStaffTimeSheet.dgvTimeSheet.Columns(3).Width = 80
                frmStaffTimeSheet.dgvTimeSheet.Columns(4).Width = 45
                frmStaffTimeSheet.dgvTimeSheet.Columns(5).Width = 45
                frmStaffTimeSheet.dgvTimeSheet.Columns(6).Width = 45
                frmStaffTimeSheet.dgvTimeSheet.Columns(7).Width = 45
                frmStaffTimeSheet.dgvTimeSheet.Columns(8).Width = 45
                frmStaffTimeSheet.dgvTimeSheet.Columns(9).Width = 90
                frmStaffTimeSheet.dgvTimeSheet.Columns(10).Width = 45
                frmStaffTimeSheet.dgvTimeSheet.Columns(11).Visible = False
                frmStaffTimeSheet.dgvTimeSheet.Columns(12).Visible = False
                frmStaffTimeSheet.dgvTimeSheet.Columns(13).Visible = False
                frmStaffTimeSheet.dgvTimeSheet.Columns(14).Visible = False
                frmStaffTimeSheet.dgvTimeSheet.Columns(15).Visible = False
                frmStaffTimeSheet.dgvTimeSheet.Columns(16).Visible = False
                frmStaffTimeSheet.dgvTimeSheet.Columns(17).Visible = False
                frmStaffTimeSheet.dgvTimeSheet.Columns(18).Visible = False

                'Setup column headers...
                frmStaffTimeSheet.dgvTimeSheet.Columns(2).HeaderText = "Day"
                frmStaffTimeSheet.dgvTimeSheet.Columns(3).HeaderText = "Date"
                frmStaffTimeSheet.dgvTimeSheet.Columns(4).HeaderText = "Reg"
                frmStaffTimeSheet.dgvTimeSheet.Columns(5).HeaderText = "Sick"
                frmStaffTimeSheet.dgvTimeSheet.Columns(6).HeaderText = "Vac"
                frmStaffTimeSheet.dgvTimeSheet.Columns(7).HeaderText = "OT"
                frmStaffTimeSheet.dgvTimeSheet.Columns(8).HeaderText = "Other"
                frmStaffTimeSheet.dgvTimeSheet.Columns(9).HeaderText = "Other Type (see above)"
                frmStaffTimeSheet.dgvTimeSheet.Columns(10).HeaderText = "Total"

                'Setup column locks...
                frmStaffTimeSheet.dgvTimeSheet.Columns(2).ReadOnly = True
                frmStaffTimeSheet.dgvTimeSheet.Columns(2).DefaultCellStyle.BackColor = Color.WhiteSmoke
                frmStaffTimeSheet.dgvTimeSheet.Columns(3).ReadOnly = True
                frmStaffTimeSheet.dgvTimeSheet.Columns(3).DefaultCellStyle.BackColor = Color.WhiteSmoke
                frmStaffTimeSheet.dgvTimeSheet.Columns(10).ReadOnly = True
                frmStaffTimeSheet.dgvTimeSheet.Columns(10).DefaultCellStyle.BackColor = Color.WhiteSmoke



        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objStaffTimeData = New clsStaffTime
        'Call objStaffTimeData.subStaffTimeSelect(strBindTarget:="frmSearch", strAction:="SEARCH-ALL", _
        'dtStart:="01/01/1900", dtStop:="01/01/1900", intRowID:=0,intStaffID:=0,strWorkDay:="NONE",_ 
        'dtWorkDate:="01/01/1900", intHr_Regular:=0,intHr_Sick:=0,intHr_OverTime:=0,intHr_Other:=0, _
        'strHr_Other_Desc:="N/A",intHr_Total:=0,strCreateUser:=SystemInformation.UserName, _
        'dtCreateDate:="01/01/1900", strEmployeeSignOff:= "NONE", dtEmployeeSignOffDate:= "01/01/1900", _
        'strSupervisorSignOff:="NONE",dtSupervisorSignOffDate:="01/01/1900", strAcctSignOff:="NONE", _
        'dtAcctSignOffDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub

    '*** B. subStaffTimeAction
    Public Sub subStaffTimeAction(ByVal strAction As String, ByVal dtStart As Date, _
        ByVal dtStop As Date, ByVal intRowID As Integer, ByVal intStaffID As Integer, _
        ByVal strWorkDay As String, ByVal dtWorkDate As Date, ByVal intHr_Regular As Integer, _
        ByVal intHr_Sick As Integer, ByVal intHr_Vac As Integer, ByVal intHr_OverTime As Integer, ByVal intHr_Other As Integer, _
        ByVal strHr_Other_Desc As String, ByVal intHr_Total As Integer, ByVal strCreateUser As String, _
        ByVal dtCreateDate As Date, ByVal strEmployeeSignOff As String, ByVal dtEmployeeSignOffDate As Date, _
        ByVal strSupervisorSignOff As String, ByVal dtSupervisorSignOffDate As Date, _
        ByVal strAcctSignOff As String, ByVal dtAcctSignOffDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procStaffTimeSheet"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@StartDate", dtStart)
        objCommand.Parameters.AddWithValue("@StopDate", dtStop)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@StaffID", intStaffID)
        objCommand.Parameters.AddWithValue("@WorkDay", strWorkDay)
        objCommand.Parameters.AddWithValue("@WorkDate", dtWorkDate)
        objCommand.Parameters.AddWithValue("@Hr_Regular", intHr_Regular)
        objCommand.Parameters.AddWithValue("@Hr_Sick", intHr_Sick)
        objCommand.Parameters.AddWithValue("@Hr_Vac", intHr_Vac)
        objCommand.Parameters.AddWithValue("@Hr_OverTime", intHr_OverTime)
        objCommand.Parameters.AddWithValue("@Hr_Other", intHr_Other)
        objCommand.Parameters.AddWithValue("@Hr_Other_Desc", strHr_Other_Desc)
        objCommand.Parameters.AddWithValue("@Hr_Total", intHr_Total)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        objCommand.Parameters.AddWithValue("@EmployeeSignOff", strEmployeeSignOff)
        objCommand.Parameters.AddWithValue("@EmployeeSignOffDate", dtEmployeeSignOffDate)
        objCommand.Parameters.AddWithValue("@SupervisorSignOff", strSupervisorSignOff)
        objCommand.Parameters.AddWithValue("@SupervisorSignOffDate", dtSupervisorSignOffDate)
        objCommand.Parameters.AddWithValue("@AcctSignOff", strAcctSignOff)
        objCommand.Parameters.AddWithValue("@AcctSignOffDate", dtAcctSignOffDate)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        ' objStaffTimeAction = New clsStaffTime
        'Call objStaffTimeAction.subStaffTimeAction(strAction:="SEARCH-ALL", _
        'dtStart:="01/01/1900", dtStop:="01/01/1900", intRowID:=0,intStaffID:=0,strWorkDay:="NONE",_ 
        'dtWorkDate:="01/01/1900", intHr_Regular:=0,intHr_Sick:=0,intHr_OverTime:=0,intHr_Other:=0, _
        'strHr_Other_Desc:="N/A",intHr_Total:=0,strCreateUser:=SystemInformation.UserName, _
        'dtCreateDate:="01/01/1900", strEmployeeSignOff:= "NONE", dtEmployeeSignOffDate:= "01/01/1900", _
        'strSupervisorSignOff:="NONE",dtSupervisorSignOffDate:="01/01/1900", strAcctSignOff:="NONE", _
        'dtAcctSignOffDate:="01/01/1900")
        '***********************************************
        '***********************************************
    End Sub
End Class
