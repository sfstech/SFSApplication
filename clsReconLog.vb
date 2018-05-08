Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subReconLogSelect
'*** B. subReconLogAction
'****************************************
'****************************************



Public Class clsReconLog
    Dim objConnection As New SqlConnection _
    (frmMainMenu.strSFSCon)

    '    '*** A. subReconLogSelect
    Public Sub subReconLogSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, ByVal strReconType As String, ByVal strReconDesc As String, ByVal strMonth As String, ByVal strQuarter As String, ByVal intYear As Integer, ByVal strReconciler As String, ByVal dtStartDate As Date, ByVal dtStopDate As Date, ByVal intNumRecItems As Integer, ByVal intSumRecItems As Integer, ByVal strCreatedUser As String, ByVal dtCreatedDate As Date, ByVal strApproveUser As String, ByVal dtApproveDate As Date, ByVal strFilePath As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager


        'Dim DS As System.Data.DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procReconLog"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@RowID", intRowID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ReconType", strReconType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ReconDesc", strReconDesc)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Month", strMonth)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Quarter", strQuarter)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Year", intYear)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Reconciler", strReconciler)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StartDate", dtStartDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@StopDate", dtStopDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@NumRecItems", intNumRecItems)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@SumRecItems", intSumRecItems)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreatedUser", strCreatedUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@CreatedDate", dtCreatedDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ApproveUser", strApproveUser)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ApproveDate", dtApproveDate)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@FilePath", strFilePath)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsReconLog")

        'Close the database connection...
        objConnection.Close()

        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsReconLog"

                'Setup form title...
                SearchMenu.Text = "Recon Log Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).Width = 65
                SearchMenu.grdDataList.Columns(2).Width = 65
                SearchMenu.grdDataList.Columns(3).Width = 65
                SearchMenu.grdDataList.Columns(4).Width = 55
                SearchMenu.grdDataList.Columns(5).Width = 45
                SearchMenu.grdDataList.Columns(6).Visible = False
                SearchMenu.grdDataList.Columns(7).Visible = False
                SearchMenu.grdDataList.Columns(8).Visible = False
                SearchMenu.grdDataList.Columns(9).Width = 40
                SearchMenu.grdDataList.Columns(10).Width = 60
                SearchMenu.grdDataList.Columns(11).Width = 65
                SearchMenu.grdDataList.Columns(12).Width = 65
                SearchMenu.grdDataList.Columns(13).Visible = False
                SearchMenu.grdDataList.Columns(14).Visible = False
                SearchMenu.grdDataList.Columns(15).Width = 65

                'Setup column headers...
                SearchMenu.grdDataList.Columns(1).HeaderText = "Type"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Description"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Month"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Quarter"
                SearchMenu.grdDataList.Columns(5).HeaderText = "Year"
                SearchMenu.grdDataList.Columns(9).HeaderText = "Count"
                SearchMenu.grdDataList.Columns(10).HeaderText = "Amount"
                SearchMenu.grdDataList.Columns(11).HeaderText = "Prepared By"
                SearchMenu.grdDataList.Columns(12).HeaderText = "Prepared On"
                SearchMenu.grdDataList.Columns(15).HeaderText = "File Path"

            Case "frmReconLog"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....

                objDataAdapter.Fill(objDataSet, "dsReconLog")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsReconLog"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmReconLog.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmReconLog.cboReconType.DataBindings.Clear()
                frmReconLog.cboReconDesc.DataBindings.Clear()
                frmReconLog.cboMonth.DataBindings.Clear()
                frmReconLog.cboQuarter.DataBindings.Clear()
                frmReconLog.cboYear.DataBindings.Clear()
                frmReconLog.cboReconciler.DataBindings.Clear()
                frmReconLog.dtStartDate.DataBindings.Clear()
                frmReconLog.dtSTopDate.DataBindings.Clear()
                frmReconLog.txtNumRecItems.DataBindings.Clear()
                frmReconLog.txtSumRecItems.DataBindings.Clear()
                frmReconLog.txtCreatedUser.DataBindings.Clear()
                frmReconLog.dtCreatedDate.DataBindings.Clear()
                frmReconLog.txtApproveUser.DataBindings.Clear()
                frmReconLog.dtApproveDate.DataBindings.Clear()
                frmReconLog.txtFilePath.DataBindings.Clear()

                'Add new bindings to the DataView object...
                frmReconLog.cboReconType.DataBindings.Add("text", objDataView, "ReconType")
                frmReconLog.cboReconDesc.DataBindings.Add("text", objDataView, "ReconDesc")
                frmReconLog.cboMonth.DataBindings.Add("text", objDataView, "Month")
                frmReconLog.cboQuarter.DataBindings.Add("text", objDataView, "Quarter")
                frmReconLog.cboYear.DataBindings.Add("text", objDataView, "Year")
                frmReconLog.cboReconciler.DataBindings.Add("text", objDataView, "Reconciler")
                frmReconLog.dtStartDate.DataBindings.Add("text", objDataView, "StartDate")
                frmReconLog.dtSTopDate.DataBindings.Add("text", objDataView, "StopDate")
                frmReconLog.txtNumRecItems.DataBindings.Add("text", objDataView, "NumRecItems")
                frmReconLog.txtSumRecItems.DataBindings.Add("text", objDataView, "SumRecItems")
                frmReconLog.txtCreatedUser.DataBindings.Add("text", objDataView, "CreatedUser")
                frmReconLog.dtCreatedDate.DataBindings.Add("text", objDataView, "CreatedDate")
                frmReconLog.txtApproveUser.DataBindings.Add("text", objDataView, "ApproveUser")
                frmReconLog.dtApproveDate.DataBindings.Add("text", objDataView, "ApproveDate")
                frmReconLog.txtFilePath.DataBindings.Add("text", objDataView, "FilePath")

            Case "frmReconLog-cbtype"
                'frmReconLog.cboReconType.DataBindings.Clear()
                frmReconLog.cboReconType.DataSource = objDataSet.Tables("dsReconLog")
                frmReconLog.cboReconType.DisplayMember = "ReconType"
                frmReconLog.cboReconType.ValueMember = "ReconType"

            Case "frmReconLog-cbdesc"
                'frmReconLog.cboReconType.DataBindings.Clear()
                frmReconLog.cboReconDesc.DataSource = objDataSet.Tables("dsReconLog")
                frmReconLog.cboReconDesc.DisplayMember = "ReconDesc"
                frmReconLog.cboReconDesc.ValueMember = "ReconDesc"

            Case "frmReconLog-cbreconciler"
                'frmReconLog.cboReconType.DataBindings.Clear()
                frmReconLog.cboReconciler.DataSource = objDataSet.Tables("dsReconLog")
                frmReconLog.cboReconciler.DisplayMember = "Reconciler"
                frmReconLog.cboReconciler.ValueMember = "Reconciler"
        End Select
        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objReconLogData = New clsReconLog
        'Call objReconLogData.subReconLogSelect(strBindTarget:="frmSearch", strAction:="SEARCH-ALL", _
        'intRowID:=0, strReconType:="NONE",strReconDesc:="NONE",strMonth:="NONE", strQuarter:="NONE", intYear:=0, strReconciler:="NONE" _
        'dtStartDate:="01/01/1900",dtStopDate:="01/01/1900", intNumRecItems:=0, intSumRecItems:=0, strCreatedUser:=SystemInformation.UserName,dtCreatedDate:="01/01/1900")
        '***********************************************
        '***********************************************

    End Sub

    '*** B. subReconLogAction
    Public Sub subReconLogAction(ByVal strBindTarget As String, ByVal strAction As String, ByVal intRowID As Integer, ByVal strReconType As String, ByVal strReconDesc As String, ByVal strMonth As String, ByVal strQuarter As String, ByVal intYear As Integer, ByVal strReconciler As String, ByVal dtStartDate As Date, ByVal dtStopDate As Date, ByVal intNumRecItems As Integer, ByVal intSumRecItems As Integer, ByVal strCreatedUser As String, ByVal dtCreatedDate As Date, ByVal strApproveUser As String, ByVal dtApproveDate As Date, ByVal strFilePath As String)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procReconLog"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@RowID", intRowID)
        objCommand.Parameters.AddWithValue("@ReconType", strReconType)
        objCommand.Parameters.AddWithValue("@ReconDesc", strReconDesc)
        objCommand.Parameters.AddWithValue("@Month", strMonth)
        objCommand.Parameters.AddWithValue("@Quarter", strQuarter)
        objCommand.Parameters.AddWithValue("@Year", intYear)
        objCommand.Parameters.AddWithValue("@Reconciler", strReconciler)
        objCommand.Parameters.AddWithValue("@StartDate", dtStartDate)
        objCommand.Parameters.AddWithValue("@StopDate", dtStopDate)
        objCommand.Parameters.AddWithValue("@NumRecItems", intNumRecItems)
        objCommand.Parameters.AddWithValue("@SumRecItems", intSumRecItems)
        objCommand.Parameters.AddWithValue("@CreatedUser", strCreatedUser)
        objCommand.Parameters.AddWithValue("@CreatedDate", dtCreatedDate)
        objCommand.Parameters.AddWithValue("@ApproveUser", strApproveUser)
        objCommand.Parameters.AddWithValue("@ApproveDate", dtApproveDate)
        objCommand.Parameters.AddWithValue("@FilePath", strFilePath)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '        '***********************************************
        '        '******************* ACTION CODE ***************
        '        '***********************************************
        '        ' objReconLogAction = New clsReconLog
        '        'Call objReconLogAction.subReconLogAction(strAction:="DELETE-tblELM_IMPORT", intSSN:=0, intStudent_no:=0, dtElmDate:="01/01/1900",intBatchNum:=0, strElmString:="NONE", strCreateUser:="NONE")
        '        '***********************************************
        '        '***********************************************
    End Sub
End Class
