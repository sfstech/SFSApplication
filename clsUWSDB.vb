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
    (frmMainMenu.UWSDB_DATASOURCE_SEC) '(frmMainMenu.UWSDB_DATASOURCE)
    '("Data Source=SDBSQLC1DB1.admin.washington.edu;Initial Catalog=UWSDB;User Id=sfstech;Password=password;Trusted_Connection=True;")

    Dim objConnectionJP As New SqlConnection(frmMainMenu.UWSDB_DATASOURCE_SEC)
    '("Data Source=SDBSQLC1DB1.admin.washington.edu;Initial Catalog=UWSDB;Integrated Security=SSPI")

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
            Case "UWSDB-STNO-NAME-BY-STNO"
                objDataAdapter.SelectCommand.CommandText = "SELECT student_no, student_name from dbo.student_1 where student_no = '" + intStno.ToString + "'"
            Case "UWSDB-STNO-NAME-BY-SSN"
                objDataAdapter.SelectCommand.CommandText = "SELECT student_no, student_name from dbo.student_1 where ss_no = '" + dblSSN.ToString + "'"
            Case "UWSDB-STUDENT-BY-SSN-BAL"
                objDataAdapter.SelectCommand.CommandText = "SELECT student_no, student_name, (tot_charge_amt + tot_refund_ck_amt - tot_pay_appl_aid) as Balance" _
                                                           + " FROM dbo.student_1 INNER JOIN dbo.sa_account ON dbo.student_1.system_key = dbo.sa_account.system_key" _
                                                           + " where ss_no = '" + dblSSN.ToString + "'"

            Case "UWSDB-STNO-CHECK-ADDR"
                objDataAdapter.SelectCommand.CommandText = "select  convert(char(10),t.transact_date,110) as 'transact_date',t.credit_amount, " _
                                                        + " t.op_dat_ck_num,check_made_to_uw,op_dat_2d_name, op_dat_2d_line1,op_dat_2d_line2,op_dat_2d_city,op_dat_2d_state, " _
                                                        + "op_dat_2d_zip, op_dat_2d_country " _
                                                        + " from student_1 s, sa_transaction t where(s.system_key = t.system_key)" _
                                                        + " and s.student_no= '" + intStno.ToString + "'" + " and t.transact_rcd_type=4 and t.op_dat_ck_num>''  and t.op_dat_addr_flg>0" _
                                                        + " order by transact_date desc "
                                                        
            Case "UWSDB-CASH-OVER-10K"
                objDataAdapter.SelectCommand.CommandText = "SELECT  RIGHT('0000000' + CONVERT(VARCHAR,student_1.student_no), 7) AS Student_Number, " _
                                                        + " REPLACE(student_1.student_name_lowc,',',', ') AS Student_Name, " _
                                                        + " count(sa_transaction.credit_amount) AS Num_Payments, " _
                                                        + " sum(sa_transaction.credit_amount) AS Cash_Payments, " _
                                                        + " max(CONVERT(varchar,sa_transaction.transact_date,102)) AS Last_Payment " _
                                                        + " FROM sa_transaction INNER JOIN student_1 ON sa_transaction.system_key = student_1.system_key " _
                                                        + " WHERE   ((sa_transaction.transact_rcd_type = 2) AND (sa_transaction.transact_rcd_code = 1)) AND  " _
                                                        + " ((sa_transaction.transact_date >= '6/18/2014') AND (sa_transaction.transact_date <= getdate())) " _
                                                        + " GROUP BY student_1.student_no, student_1.student_name_lowc " _
                                                        + " HAVING   (student_1.student_no <> 0) AND SUM(sa_transaction.credit_amount) >= 10000 " _
                                                        + " ORDER BY max(sa_transaction.transact_date) DESC "

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
            Case "UWSDB-STNO-NAME-BY-STNO", "UWSDB-STNO-NAME-BY-SSN"
                If frmReconMatch.UWSDBDataTable.Rows.Count > 0 Then
                    frmMainMenu.intUWSBDStno = frmReconMatch.UWSDBDataTable.Rows(0).Item(0)
                    frmMainMenu.strUWSBDStudent_name = frmReconMatch.UWSDBDataTable.Rows(0).Item(1)
                    frmMainMenu.strUWSBDStudent_name = frmMainMenu.strUWSBDStudent_name.Replace("'", "`")
                    'frmMainMenu.strUWSBDvisa_type = frmReconMatch.UWSDBDataTable.Rows(0).Item(2)
                Else
                    frmMainMenu.intUWSBDStno = 0
                    frmMainMenu.strUWSBDStudent_name = ""
                End If
                frmMainMenu.dblUWSBDSSN = 0   '  Remove this line whwn SSN goes !!!***
            Case "UWSDB-STUDENT-BY-SSN-BAL"
                If frmReconMatch.UWSDBDataTable.Rows.Count > 0 Then
                    frmMainMenu.intUWSBDStno = frmReconMatch.UWSDBDataTable.Rows(0).Item(0)
                    ' frmMainMenu.dblUWSBDSSN = frmReconMatch.UWSDBDataTable.Rows(0).Item(1)
                    frmMainMenu.strUWSBDStudent_name = frmReconMatch.UWSDBDataTable.Rows(0).Item(1)
                    frmMainMenu.strUWSBDStudent_name = frmMainMenu.strUWSBDStudent_name.Replace("'", "`")
                    frmMainMenu.dblUWSBDBalance = frmReconMatch.UWSDBDataTable.Rows(0).Item(2)
                Else
                    frmMainMenu.intUWSBDStno = 0
                    frmMainMenu.dblUWSBDSSN = 0     '  Remove this line whwn SSN goes !!!***
                    frmMainMenu.strUWSBDStudent_name = ""
                End If
            Case "UWSDB-STNO-CHECK-ADDR", "UWSDB-CASH-OVER-10K"
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsUWSDBSelect"
        End Select



    End Sub

    Public Sub subUWSDBSel_STL(ByVal strAction As String, ByVal intStno As Integer, ByVal strChrgCd As String, ByVal intYear As String, ByVal strQtr As String, ByVal intBudget As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandType = CommandType.Text
        objDataAdapter.SelectCommand.CommandTimeout = 600

        Select Case strAction
            Case "STL-AUTH-DISB-AMT", "OA-AUTH-DISB-AMT"
                objDataAdapter.SelectCommand.CommandText = _
               "SELECT   dbo.student_1.student_no, SUM(dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_autho_amt), SUM(dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_disb_amt), " _
              + "( SUM(dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_autho_amt) - SUM(dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_disb_amt)) " _
              + "FROM dbo.sa_sf_awards_awards INNER JOIN " _
              + "     dbo.student_1 ON dbo.sa_sf_awards_awards.system_key = dbo.student_1.system_key " _
              + "WHERE (dbo.sa_sf_awards_awards.awrd_code_budget IN( " + intBudget.ToString + ") ) AND (award_yr = " + intYear.ToString + " ) AND " _
              + "	   (dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_autho_amt > 0" _
              + "   or  dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_disb_amt  > 0  ) " _
              + " Group by dbo.student_1.student_no" _
              + " ORDER BY dbo.student_1.student_no"                    ' new lines - consider both amts - order by stno
            Case "STL-AUTH-AFFIX-AMT"
                objDataAdapter.SelectCommand.CommandText = _
                "BEGIN " _
                + "SELECT 	s1.student_no as student_no, SUM(payd_distrib_amt) as payd_charge_amt, payd_due_date, student_name INTO #AFFIX " _
                + "FROM  Sa_account_payment_distrib apd " _
                + "INNER JOIN  Student_1 s1 ON apd.system_key = s1.system_key " _
                + "LEFT OUTER JOIN Sys_tbl_63_nontuit_charges nc ON apd.payd_charge_code = nc.table_key " _
                + "WHERE	(apd.payd_charge_code IN (" + strChrgCd + ")) " _
                + "GROUP BY student_no, payd_due_date, student_name " _
                + "ORDER BY student_no, payd_due_date, student_name " _
                + "SELECT   dbo.student_1.student_no,   SUM(dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_autho_amt) as SumAuth   INTO #AUTH " _
                + "FROM dbo.sa_sf_awards_awards INNER JOIN dbo.student_1 ON dbo.sa_sf_awards_awards.system_key = dbo.student_1.system_key " _
                + "WHERE (dbo.sa_sf_awards_awards.awrd_code_budget IN (" + intBudget.ToString + ") AND (award_yr = " + intYear.ToString + " ) " _
                + "AND ((dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_autho_amt > 0   or  dbo.sa_sf_awards_awards." + strQtr.ToLower() + "_disb_amt  > 0  ) ) ) " _
                + "Group by dbo.student_1.student_no " _
                + "ORDER BY dbo.student_1.student_no " _
                + "Select #AUTH.student_no, #AUTH.SumAuth, IsNull(#AFFIX.payd_charge_amt, 0) as Affix, 0.00 as 'Charge Cancelled' " _
                + ", (IsNull(#AFFIX.payd_charge_amt, 0) - #AUTH.SumAuth)  as Charge , #AFFIX.payd_due_date, #AFFIX.student_name " _
                + "from  #AUTH left outer join #AFFIX on #AUTH.student_no = #AFFIX.student_no " _
                + "DROP table #AUTH  DROP table #AFFIX " _
                + "END "
        End Select
        'Open the database connection...
        objConnection.Open()
        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsUWSDBSelect")
        'frmReconMatch.UWSDBDataTable = objDataSet.Tables("dsUWSDBSelect")
        objConnection.Close()

        frmReconMatch.grdDataSets.DataSource = objDataSet
        frmReconMatch.grdDataSets.DataMember = "dsUWSDBSelect"

        'Setup form title...
        'frmReconMatch.Text = "Select Application"   !!!  -do we need this yet?

        'Setup alternating rows style...
        frmReconMatch.grdDataSets.AutoGenerateColumns = True
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        frmReconMatch.grdDataSets.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        frmReconMatch.grdDataSets.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Select Case strAction
            Case "OA-AUTH-DISB-AMT"
                frmOAQryTest.grdPmts.DataSource = objDataSet
                frmOAQryTest.grdPmts.DataMember = "dsUWSDBSelect"
            Case "STL-AUTH-DISB-AMT"

                'Setup column widths...
                frmReconMatch.grdDataSets.Columns(0).Visible = True
                frmReconMatch.grdDataSets.Columns(1).Visible = True
                frmReconMatch.grdDataSets.Columns(2).Visible = True
                frmReconMatch.grdDataSets.Columns(2).Width = 100
                'frmReconMatch.grdDataSets.Columns(3).Width = 100

                'Setup column headers...
                frmReconMatch.grdDataSets.Columns(0).HeaderText = "Stno"
                frmReconMatch.grdDataSets.Columns(0).DefaultCellStyle.Format = "0000000"
                frmReconMatch.grdDataSets.Columns(1).HeaderText = "Auth" & " Amt"
                frmReconMatch.grdDataSets.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(1).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(2).HeaderText = "Disb" & " Amt"
                frmReconMatch.grdDataSets.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(2).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(3).HeaderText = "Undisbursed Amt"
                frmReconMatch.grdDataSets.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(3).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(3).Width = 180
                'frmReconMatch.grdDataSets.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'frmReconMatch.grdDataSets.Columns(4).HeaderText = ""        ' strDataSet1 & " ADJ Amt"
                'frmReconMatch.grdDataSets.Columns(4).DefaultCellStyle.Format = "c"
            Case "STL-AUTH-AFFIX-AMT"
                'Setup column widths...
                frmReconMatch.grdDataSets.Columns(0).Visible = True
                frmReconMatch.grdDataSets.Columns(1).Visible = True
                frmReconMatch.grdDataSets.Columns(2).Visible = True
                frmReconMatch.grdDataSets.Columns(2).Width = 95
                'frmReconMatch.grdDataSets.Columns(3).Width = 100

                'Setup column headers...
                frmReconMatch.grdDataSets.Columns(0).HeaderText = "Stno"
                frmReconMatch.grdDataSets.Columns(0).DefaultCellStyle.Format = "0000000"
                frmReconMatch.grdDataSets.Columns(1).HeaderText = "Auth" & " Amt"
                frmReconMatch.grdDataSets.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(1).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(2).HeaderText = "Affix" & " Amt"
                frmReconMatch.grdDataSets.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(2).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(3).HeaderText = "Charge Cancelled"
                frmReconMatch.grdDataSets.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(3).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(3).Width = 100
                frmReconMatch.grdDataSets.Columns(4).HeaderText = "Charge"
                frmReconMatch.grdDataSets.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                frmReconMatch.grdDataSets.Columns(4).DefaultCellStyle.Format = "c"
                frmReconMatch.grdDataSets.Columns(5).Width = 100
                frmReconMatch.grdDataSets.Columns(6).Width = 300
                '   frmReconMatch.grdDataSets.Columns(4).Width = 120
        End Select
    End Sub

End Class
