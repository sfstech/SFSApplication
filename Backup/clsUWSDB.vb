Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subUWSDBSelect    !!! - not yet - to be completed

'*** B. subUWSDBAction

'****************************************
'****************************************

Public Class clsUWSDB

    Dim objConnection As New SqlConnection _
    ("Data Source=SDBSQLC1DB1.admin.washington.edu;Initial Catalog=UWSDB;User Id=sfstech;Password=fJNaCh7A;Trusted_Connection=True;")

    Dim objConnectionJP As New SqlConnection _
   ("Data Source=SDBSQLC1DB1.admin.washington.edu;Initial Catalog=UWSDB;Integrated Security=SSPI")

    ''*** A. subMatchSelect
    Public Sub subUWSDBSelect(ByVal strAction As String, ByVal intStno As Integer, ByVal dblSSN As Double, ByVal intYear As String, ByVal strQtr As String, ByVal intBudget As String)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()


        If SystemInformation.UserName = "jcpeters" Then 'Or SystemInformation.UserName = "bradyma" Then
            objDataAdapter.SelectCommand.Connection = objConnectionJP
            '   MsgBox("using SSPI")
        Else
            objDataAdapter.SelectCommand.Connection = objConnection
        End If

        'objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandType = CommandType.Text
        objDataAdapter.SelectCommand.CommandTimeout = 600

        Select Case strAction
            Case "GET-AUTH-AMT"
                objDataAdapter.SelectCommand.CommandText = _
               "SELECT   dbo.student_1.student_no, dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_autho_amt, dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_disb_amt " _
              + "FROM dbo.sa_sf_awards_awards INNER JOIN " _
              + "     dbo.student_1 ON dbo.sa_sf_awards_awards.system_key = dbo.student_1.system_key " _
              + "WHERE (dbo.sa_sf_awards_awards.awrd_code_budget = " + intBudget.ToString + " ) AND (award_yr = " + intYear.ToString + " ) AND " _
              + "	   (dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_autho_amt > 0" _
              + "   or  dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_disb_amt  > 0  ) " _
              + " ORDER BY dbo.student_1.student_no"                    ' new lines - consider both amts - order by stno
                '   + "	    dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_autho_amt > 0"  ' old way
            Case "UWSDB-STUDENT-BY-SSN"
                objDataAdapter.SelectCommand.CommandText = "SELECT student_no, ss_no, student_name from dbo.student_1 where ss_no = '" + dblSSN.ToString + "'"
            Case "UWSDB-STUDENT-BY-STNO"
                objDataAdapter.SelectCommand.CommandText = "SELECT student_no, ss_no, student_name from dbo.student_1 where student_no = '" + intStno.ToString + "'"
            Case "UWSDB-STUDENT-BY-SSN-BAL"
                objDataAdapter.SelectCommand.CommandText = "SELECT student_no, ss_no, student_name, (tot_charge_amt + tot_refund_ck_amt - tot_pay_appl_aid) as Balance" _
                                                           + " FROM dbo.student_1 INNER JOIN dbo.sa_account ON dbo.student_1.system_key = dbo.sa_account.system_key" _
                                                           + " where ss_no = '" + dblSSN.ToString + "'"
        End Select

        'objDataAdapter.SelectCommand.CommandText = _
        '       "SELECT   dbo.student_1.student_no, dbo.sa_sf_awards_awards.sum_autho_amt, dbo.sa_sf_awards_awards.sum_disb_amt " _
        '      + "FROM dbo.sa_sf_awards_awards INNER JOIN " _
        '      + "     dbo.student_1 ON dbo.sa_sf_awards_awards.system_key = dbo.student_1.system_key " _
        '     + "WHERE (dbo.sa_sf_awards_awards.awrd_code_budget = 330320) AND (award_yr = 2009) AND " _
        '     + "	 dbo.sa_sf_awards_awards.sum_autho_amt > 0"


        'Open the database connection...
        objConnection.Open()
        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsUWSDBSelect")
        frmReconMatch.UWSDBDataTable = objDataSet.Tables("dsUWSDBSelect")
        objConnection.Close()

        Select Case strAction
            Case "UWSDB-STUDENT-BY-SSN", "UWSDB-STUDENT-BY-STNO"
                If frmReconMatch.UWSDBDataTable.Rows.Count > 0 Then
                    frmMainMenu.intUWSBDStno = frmReconMatch.UWSDBDataTable.Rows(0).Item(0)
                    frmMainMenu.dblUWSBDSSN = frmReconMatch.UWSDBDataTable.Rows(0).Item(1)
                    frmMainMenu.strUWSBDStudent_name = frmReconMatch.UWSDBDataTable.Rows(0).Item(2)
                    frmMainMenu.strUWSBDStudent_name = frmMainMenu.strUWSBDStudent_name.Replace("'", "`")
                Else
                    frmMainMenu.intUWSBDStno = 0
                    frmMainMenu.dblUWSBDSSN = 0
                    frmMainMenu.strUWSBDStudent_name = ""
                End If
            Case "UWSDB-STUDENT-BY-SSN-BAL"
                If frmReconMatch.UWSDBDataTable.Rows.Count > 0 Then
                    frmMainMenu.intUWSBDStno = frmReconMatch.UWSDBDataTable.Rows(0).Item(0)
                    frmMainMenu.dblUWSBDSSN = frmReconMatch.UWSDBDataTable.Rows(0).Item(1)
                    frmMainMenu.strUWSBDStudent_name = frmReconMatch.UWSDBDataTable.Rows(0).Item(2)
                    frmMainMenu.strUWSBDStudent_name = frmMainMenu.strUWSBDStudent_name.Replace("'", "`")
                    frmMainMenu.dblUWSBDBalance = frmReconMatch.UWSDBDataTable.Rows(0).Item(3)
                Else
                    frmMainMenu.intUWSBDStno = 0
                    frmMainMenu.dblUWSBDSSN = 0
                    frmMainMenu.strUWSBDStudent_name = ""
                End If

        End Select



    End Sub

End Class
