Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

'****************************************
'**** CLASS INDEX ***********************   
'*** A. subOAEDWSelect    

'*** B. subOAEDWAction

'****************************************
'****************************************
Public Class clsOAEDW
    Dim objConnection As New SqlConnection _
        (frmMainMenu.UWSDB_DATASOURCE_SEC) '(frmMainMenu.UWSDB_DATASOURCE)
    '("Data Source=SDBSQLC1DB1.admin.washington.edu;Initial Catalog=UWSDB;User Id=sfstech;Password=password;Trusted_Connection=True;")

    Dim objConnectionJP As New SqlConnection(frmMainMenu.UWSDB_DATASOURCE_SEC)
    '("Data Source=SDBSQLC1DB1.admin.washington.edu;Initial Catalog=UWSDB;Integrated Security=SSPI")

    ''*** A. subMatchSelect
    Public Sub subOAEDWSelect(ByVal strAction As String, ByVal intStno As Integer, ByVal dblSSN As Double, ByVal intYear As String, ByVal strQtr As String, ByVal intBudget As String)


        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()

        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandType = CommandType.Text
        objDataAdapter.SelectCommand.CommandTimeout = 600

        Dim strChooseCol As String = ""

        Select Case strAction
            Case "OA-COLL-TUITION"
                strChooseCol = "dbo.sa_tuition_table.tuit_name"
            Case "OA-COLL-OAWARD"
                strChooseCol = "dbo.sys_tbl_63_nontuit_charges.nont_charge_name"
        End Select

        Select Case strAction
            Case "OA-AFFIX-AMT-BY-STNO"
                objDataAdapter.SelectCommand.CommandText = _
               "SELECT  convert(varchar, st.transact_date, 1) as TDATE,  apd.payd_charge_code as CHARGE, t63.nont_abbr_name as DESCRIPTION,  apd.payd_charge_amt as 'CHARGE $', " _
                + "apd.payd_distrib_amt as PAID , convert(varchar, apd.payd_due_date, 1) as DUE_CNCL, st.transact_user_id as 'BY' " _
                + "FROM student_1 s1 INNER JOIN " _
                + "sa_account_payment_distrib apd ON s1.system_key = apd.system_key INNER JOIN " _
                + "sys_tbl_63_nontuit_charges t63 ON apd.payd_charge_code = t63.table_key INNER JOIN " _
                + "sa_transaction st ON (s1.system_key = st.system_key and st.transact_rcd_code = payd_charge_code and st.debit_amount = apd.payd_charge_amt) " _
                + "WHERE st.trans_status_flg = 0 and 	 s1.student_no = '" + intStno.ToString + "' " _
             + "and LEFT(Cast( payd_charge_code as Char(10)),2) IN ('90', '91' ) " _
                + "and RIGHT(Cast( payd_charge_code as Char(10)),3) IN ('001', '005',  '010', '020', '030', '050',  '070', '080', '110', '120', '200',  '201', '202', '348','526', '678', '709', '714', '738', '740', '741', '526') " _
                + "and SUBSTRING(Cast( payd_charge_code as Char(10)),3,4) = '2014' "
            Case "UWSDB-STNO-NAME-BY-STNO"
                objDataAdapter.SelectCommand.CommandText = "SELECT student_no, student_name from dbo.student_1 where student_no = '" + intStno.ToString + "'"
            Case "OA-COLL-TUITION", "OA-COLL-OAWARD"
                objDataAdapter.SelectCommand.CommandText = "Select DISTINCT " _
                + "RIGHT('0000000' + CONVERT(VARCHAR, dbo.student_1.student_no), 7) AS StuNum" _
                + ", dbo.student_1.student_name " _
          + ", CONVERT(varchar,dbo.sa_account.c_status_date,101) AS StatDate" _
          + ", SUBSTRING(datename(month, dbo.sa_account.c_status_date),1,3)AS SMonth" _
                + ", YEAR(dbo.sa_account.c_status_date) AS SYear" _
                + ", RIGHT('0000000000' + CONVERT(VARCHAR,dbo.sa_account_payment_distrib.payd_charge_code), 10) AS ChargeCode" _
                + ", dbo.sys_tbl_63_nontuit_charges.nont_charge_name AS ChargeName63 , dbo.sa_tuition_table.tuit_name as tuitChargeName" _
       + ", dbo.sa_account.c_status_comment AS Comment" _
       + ", dbo.sa_account_payment_distrib.payd_charge_amt - dbo.sa_account_payment_distrib.payd_exempt_amt AS ChrgAmt" _
       + ", dbo.sa_account_payment_distrib.payd_charge_amt - dbo.sa_account_payment_distrib.payd_distrib_amt - dbo.sa_account_payment_distrib.payd_exempt_amt AS Unpaid" _
       + ", (dbo.sa_account_payment_distrib.payd_charge_amt - dbo.sa_account_payment_distrib.payd_exempt_amt) - (dbo.sa_account_payment_distrib.payd_charge_amt - dbo.sa_account_payment_distrib.payd_distrib_amt - dbo.sa_account_payment_distrib.payd_exempt_amt) AS AmtDue" _
                + " FROM dbo.sa_account INNER JOIN" _
                + " dbo.student_1 ON dbo.sa_account.system_key = dbo.student_1.system_key INNER JOIN" _
                + " dbo.sa_account_payment_distrib ON dbo.sa_account.system_key = dbo.sa_account_payment_distrib.system_key LEFT OUTER JOIN" _
                + " dbo.sa_tuition_table ON dbo.sa_account_payment_distrib.payd_charge_code = dbo.sa_tuition_table.tuit_charge_code LEFT OUTER JOIN" _
                + " dbo.sys_tbl_63_nontuit_charges ON dbo.sa_account_payment_distrib.payd_charge_code = dbo.sys_tbl_63_nontuit_charges.table_key" _
                + " WHERE     (dbo.sa_account.collect_stat_flg = '3') AND (dbo.sa_account.c_status_date <= GETDATE())" _
                + " AND (dbo.sa_account_payment_distrib.payd_charge_amt > dbo.sa_account_payment_distrib.payd_exempt_amt + dbo.sa_account_payment_distrib.payd_distrib_amt)" _
                + "	and " + strChooseCol + " IS NOT NULL" _
                + " ORDER BY StuNum, tuitChargeName, Comment, SYear, SMonth,  ChargeCode--, tuitChargeName, Comment"
                '-- 	  and dbo.sys_tbl_63_nontuit_charges.nont_charge_name IS NOT NULL



                '    objDataAdapter.SelectCommand.CommandText = "SELECT student_no, student_name from dbo.student_1 where ss_no = '" + dblSSN.ToString + "'"
                'Case "OA-COLL-TUITION"
                '    objDataAdapter.SelectCommand.CommandText = "SELECT student_no, student_name, (tot_charge_amt + tot_refund_ck_amt - tot_pay_appl_aid) as Balance" _
                '                                               + " FROM dbo.student_1 INNER JOIN dbo.sa_account ON dbo.student_1.system_key = dbo.sa_account.system_key" _
                '                                               + " where ss_no = '" + dblSSN.ToString + "'"

                'Case "UWSDB-STNO-CHECK-ADDR"
                '    objDataAdapter.SelectCommand.CommandText = "select  convert(char(10),t.transact_date,110) as 'transact_date',t.credit_amount, " _
                '                                            + " t.op_dat_ck_num,check_made_to_uw,op_dat_2d_name, op_dat_2d_line1,op_dat_2d_line2,op_dat_2d_city,op_dat_2d_state, " _
                '                                            + "op_dat_2d_zip, op_dat_2d_country " _
                '                                            + " from student_1 s, sa_transaction t where(s.system_key = t.system_key)" _
                '                                            + " and s.student_no= '" + intStno.ToString + "'" + " and t.transact_rcd_type=4 and t.op_dat_ck_num>''  and t.op_dat_addr_flg>0" _
                '                                            + " order by transact_date desc "

        End Select

        'Open the database connection...
        objConnection.Open()
        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsUWSDBSelect")
        frmOAQryTest.UWSDBDataTable = objDataSet.Tables("dsUWSDBSelect")
        objConnection.Close()

        Select Case strAction
            'Case "UWSDB-STUDENT-BY-SSN", "UWSDB-STUDENT-BY-STNO"
            '    If frmReconMatch.UWSDBDataTable.Rows.Count > 0 Then
            '        frmMainMenu.intUWSBDStno = frmReconMatch.UWSDBDataTable.Rows(0).Item(0)
            '        frmMainMenu.dblUWSBDSSN = frmReconMatch.UWSDBDataTable.Rows(0).Item(1)
            '        frmMainMenu.strUWSBDStudent_name = frmReconMatch.UWSDBDataTable.Rows(0).Item(2)
            '        frmMainMenu.strUWSBDStudent_name = frmMainMenu.strUWSBDStudent_name.Replace("'", "`")
            '    Else
            '        frmMainMenu.intUWSBDStno = 0
            '        frmMainMenu.dblUWSBDSSN = 0
            '        frmMainMenu.strUWSBDStudent_name = ""
            'End If
            Case "UWSDB-STNO-NAME-BY-STNO" ', "UWSDB-STNO-NAME-BY-SSN"
                If frmOAQryTest.UWSDBDataTable.Rows.Count > 0 Then
                    frmOAQryTest.intUWSBDStno = frmOAQryTest.UWSDBDataTable.Rows(0).Item(0)
                    frmOAQryTest.strUWSBDStudent_name = frmOAQryTest.UWSDBDataTable.Rows(0).Item(1)
                    frmOAQryTest.strUWSBDStudent_name = frmOAQryTest.strUWSBDStudent_name.Replace("'", "`")
                Else
                    frmOAQryTest.intUWSBDStno = 0
                    frmOAQryTest.strUWSBDStudent_name = ""
                End If
                '   frmMainMenu.dblUWSBDSSN = 0   '  Remove this line whwn SSN goes !!!***
                'Case "UWSDB-STUDENT-BY-SSN-BAL"
                '    If frmReconMatch.UWSDBDataTable.Rows.Count > 0 Then
                '        frmMainMenu.intUWSBDStno = frmReconMatch.UWSDBDataTable.Rows(0).Item(0)
                '        ' frmMainMenu.dblUWSBDSSN = frmReconMatch.UWSDBDataTable.Rows(0).Item(1)
                '        frmMainMenu.strUWSBDStudent_name = frmReconMatch.UWSDBDataTable.Rows(0).Item(1)
                '        frmMainMenu.strUWSBDStudent_name = frmMainMenu.strUWSBDStudent_name.Replace("'", "`")
                '        frmMainMenu.dblUWSBDBalance = frmReconMatch.UWSDBDataTable.Rows(0).Item(2)
                '    Else
                '        frmMainMenu.intUWSBDStno = 0
                '        frmMainMenu.dblUWSBDSSN = 0     '  Remove this line whwn SSN goes !!!***
                '        frmMainMenu.strUWSBDStudent_name = ""
                '    End If
            Case "OA-AFFIX-AMT-BY-STNO"
                frmOAQryTest.grdPmts.DataSource = objDataSet
                frmOAQryTest.grdPmts.DataMember = "dsUWSDBSelect"
                frmOAQryTest.grdPmts.Columns(0).Width = 77
            Case "OA-COLL-TUITION", "OA-COLL-OAWARD"
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsUWSDBSelect"

        End Select

    End Sub
    ' overloaded sub
    Sub subOAEDWSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intOAStno As Integer, ByVal strOACharge As String, ByVal dblOAChargeAmt As Double, ByVal dblOAPaidAmt As Double)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet

        Cursor.Current = Cursors.WaitCursor

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()

        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandType = CommandType.Text
        objDataAdapter.SelectCommand.CommandTimeout = 600


        Select Case strAction
            Case "OA-CHARGE-INFO"
                objDataAdapter.SelectCommand.CommandText = _
               "SELECT  s1.student_name as Name, convert(varchar, st.transact_date, 1) as TDATE,  apd.payd_charge_code as CHARGE, t63.nont_abbr_name as DESCRIPTION,  apd.payd_charge_amt as 'CHARGE $', " _
                + "apd.payd_distrib_amt as PAID , convert(varchar, apd.payd_due_date, 1) as DUE_CNCL, st.transact_user_id as 'BY' " _
                + "FROM student_1 s1 INNER JOIN " _
                + "sa_account_payment_distrib apd ON s1.system_key = apd.system_key INNER JOIN " _
                + "sys_tbl_63_nontuit_charges t63 ON apd.payd_charge_code = t63.table_key INNER JOIN " _
                + "sa_transaction st ON (s1.system_key = st.system_key and st.transact_rcd_code = payd_charge_code and st.debit_amount = apd.payd_charge_amt) " _
                + "WHERE st.trans_status_flg = 0 and 	 s1.student_no = '" + intOAStno.ToString + "' " _
                + " and  apd.payd_charge_code = '" + strOACharge + "' " + " and  apd.payd_charge_amt = '" + dblOAChargeAmt.ToString + "' " _
                + "and LEFT(Cast( payd_charge_code as Char(10)),2) IN ('90', '91' ) " _
                + "and RIGHT(Cast( payd_charge_code as Char(10)),3) IN ('001', '005',  '010', '020', '030', '050',  '070', '080', '110', '120', '200',  '201', '202', '348','526', '678', '709', '714', '738', '740', '741', '526') " _
                + "and SUBSTRING(Cast( payd_charge_code as Char(10)),3,4) = '2014' "


        End Select

        'Open the database connection...
        objConnection.Open()
        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsUWSDBSelect")
        objConnection.Close()


        Select Case strAction
            Case "OA-CHARGE-INFO"
                SearchMenu.UWSDBDataTable = objDataSet.Tables("dsUWSDBSelect")
                'frmSearch.grdDataList.DataSource = objDataSet
                'frmSearch.grdDataList.DataMember = "dsUWSDBSelect"
        End Select

    End Sub


End Class
