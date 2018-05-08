'Import Data and SqlClient namespaces...
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subTuitionDistSelect
'*** B. subTuitionDistAction
'****************************************
'****************************************
Public Class clsTuitionDistrib
    Dim objConnection As New SqlConnection _
       (frmMainMenu.strSFSCon)


    '*** A. subTuitionDistSelect
    Public Sub subTuitionDistSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intfiscal_year As Integer, _
                ByVal inttuit_year As Integer, ByVal inttuit_quarter As Integer, ByVal inttuit_branch As Integer, _
                ByVal inttuit_tbl_no As Integer, _
                ByVal inttuit_distr_tbl_no As Integer, ByVal strtuit_name_OPB As String, _
                ByVal strdtbl_budget_descr As String, ByVal intindex1 As Integer, ByVal dbldtbl_distr_prcn As Double, _
                ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        'Dim objDataView As DataView
        'Dim objCurrencyManager As CurrencyManager

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procTuitionDist"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@fiscal_year", intfiscal_year)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@tuit_year", inttuit_year)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@tuit_quarter", inttuit_quarter)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@tuit_branch", inttuit_branch)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@tuit_tbl_no", inttuit_tbl_no)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@tuit_distr_tbl_no", inttuit_distr_tbl_no)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@tuit_name_OPB", strtuit_name_OPB)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@dtbl_budget_descr", strdtbl_budget_descr)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@index1", intindex1)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@dtbl_distr_prcn", dbldtbl_distr_prcn)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsTuitionDist")

        'Close the database connection...
        objConnection.Close()


        'Inialize and Bind to the correct from...
        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                frmSearch.grdDataList.DataSource = objDataSet
                frmSearch.grdDataList.DataMember = "dsTuitionDist"

                'Setup form title...
                frmSearch.Text = "Tuition Distribution Data Search"

                'Setup alternating rows style...
                frmSearch.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                frmSearch.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                frmSearch.grdDataList.Columns(0).Visible = False
                frmSearch.grdDataList.Columns(1).Width = 80
                frmSearch.grdDataList.Columns(2).Width = 80
                frmSearch.grdDataList.Columns(3).Width = 80
                frmSearch.grdDataList.Columns(4).Width = 80
                frmSearch.grdDataList.Columns(5).Width = 120

        End Select

        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objTuitionDistData = New clsTuitionDist
        'Call objTuitionDistData.subTuitionDistSelect(strBindTarget:="frmSearch", strAction:="CHECK-EXISTS", _
        '             inttuit_year:=0, inttuit_quarter:=0, intfiscal_year:=0, _
        '             inttuit_branch:=0, inttuit_tbl_no:=0, inttuit_distr_tbl_no:="NONE", strtuit_name_OPB:="NONE", _
        '             strdtbl_budget_descr:="NONE", intindex1:=0, dbldtbl_distr_prcn:=0, _
        '             strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '***********************************************
        '***********************************************

    End Sub


    '*** B. subTuitionDistAction
    Public Sub subTuitionDistAction(ByVal strAction As String, ByVal intfiscal_year As Integer, _
                ByVal inttuit_year As Integer, ByVal inttuit_quarter As Integer, ByVal inttuit_branch As Integer, _
                ByVal inttuit_tbl_no As Integer, _
                ByVal inttuit_distr_tbl_no As Integer, ByVal strtuit_name_OPB As String, _
                ByVal strdtbl_budget_descr As String, ByVal intindex1 As Integer, ByVal dbldtbl_distr_prcn As Double, _
                ByVal strCreateUser As String, ByVal dtCreateDate As Date)

        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procTuitionDist"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@fiscal_year", intfiscal_year)
        objCommand.Parameters.AddWithValue("@tuit_year", inttuit_year)
        objCommand.Parameters.AddWithValue("@tuit_quarter", inttuit_quarter)
        objCommand.Parameters.AddWithValue("@tuit_branch", inttuit_branch)
        objCommand.Parameters.AddWithValue("@tuit_tbl_no", inttuit_tbl_no)
        objCommand.Parameters.AddWithValue("@tuit_distr_tbl_no", inttuit_distr_tbl_no)
        objCommand.Parameters.AddWithValue("@tuit_name_OPB", strtuit_name_OPB)
        objCommand.Parameters.AddWithValue("@dtbl_budget_descr", strdtbl_budget_descr)
        objCommand.Parameters.AddWithValue("@index1", intindex1)
        objCommand.Parameters.AddWithValue("@dtbl_distr_prcn", dbldtbl_distr_prcn)
        objCommand.Parameters.AddWithValue("@CreateUser", strCreateUser)
        objCommand.Parameters.AddWithValue("@CreateDate", dtCreateDate)
        'Create a SqlParameter object to hold the RETURN value, set the direction to ReturnValue and add to parameters
        Dim retValParam As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        retValParam.Direction = ParameterDirection.ReturnValue
        objCommand.Parameters.Add(retValParam)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        frmImport.intRetExists = Convert.ToInt32(retValParam.Value)

        'Close the database connection...
        objConnection.Close()

        '    '***********************************************
        '    '******************* ACTION CODE ***************
        '    '***********************************************
        'objTuitionDistData = New clsTuitionDist
        'Call objTuitionDistribData.subTuitionDistAction(strAction:="CHECK-EXISTS", _
        '             inttuit_year:=0, inttuit_quarter:=0, intfiscal_year:=0, _
        '             inttuit_branch:=0, inttuit_tbl_no:=0, inttuit_distr_tbl_no:="NONE", strtuit_name_OPB:="NONE", _
        '             strdtbl_budget_descr:="NONE", intindex1:=0, dbldtbl_distr_prcn:=0, _
        '             strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        '    '***********************************************
        '    '***********************************************

    End Sub
End Class
