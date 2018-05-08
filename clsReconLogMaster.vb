
Imports System.Data
Imports System.Data.SqlClient

'****************************************
'**** CLASS INDEX ***********************
'*** A. subReconLogMasterSelect
'*** B. subReconLogMasterAction
'****************************************
'****************************************


Public Class clsReconLogMaster
    Dim objConnection As New SqlConnection _
        (frmMainMenu.strSFSCon)

    '    '*** A. subReconLogMasterSelect
    Public Sub subReconLogMasterSelect(ByVal strBindTarget As String, ByVal strAction As String, ByVal intReconLogMasterID As Integer, ByVal strReconType As String, ByVal strReconDesc As String, ByVal strReconLevel As String, ByVal strReconciler As String, ByVal strFrequency As String)
        Dim objDataAdapter As New SqlDataAdapter
        Dim objDataSet As New DataSet
        Dim objDataView As DataView
        Dim objCurrencyManager As CurrencyManager


        'Dim DS As System.Data.DataSet

        'Set the SelectCommand properties...
        objDataAdapter.SelectCommand = New SqlCommand()
        objDataAdapter.SelectCommand.Connection = objConnection
        objDataAdapter.SelectCommand.CommandText = "procReconLogMaster"
        objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Action", strAction)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ReconLogMasterID", intReconLogMasterID)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ReconType", strReconType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ReconDesc", strReconType)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@ReconLevel", strReconLevel)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Reconciler", strReconDesc)
        objDataAdapter.SelectCommand.Parameters.AddWithValue("@Frequency", strFrequency)

        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objDataAdapter.Fill(objDataSet, "dsReconLogMaster")

        'Close the database connection...
        objConnection.Close()

        Select Case strBindTarget
            Case "frmSearch"
                'Set the DataGridView properties to bind it to the data...
                SearchMenu.grdDataList.DataSource = objDataSet
                SearchMenu.grdDataList.DataMember = "dsReconLogMaster"

                'Setup form title...
                SearchMenu.Text = "Recon Log Master Data Search"

                'Setup alternating rows style...
                SearchMenu.grdDataList.AutoGenerateColumns = True
                Dim objAlternatingCellStyle As New DataGridViewCellStyle()
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke
                SearchMenu.grdDataList.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

                'Setup column widths...
                SearchMenu.grdDataList.Columns(0).Visible = False
                SearchMenu.grdDataList.Columns(1).Width = 75
                SearchMenu.grdDataList.Columns(2).Width = 75
                SearchMenu.grdDataList.Columns(3).Width = 75
                SearchMenu.grdDataList.Columns(4).Width = 75
                SearchMenu.grdDataList.Columns(5).Width = 75
                SearchMenu.grdDataList.Columns(6).Visible = False
                SearchMenu.grdDataList.Columns(7).Visible = False

                'Setup column headers...
                SearchMenu.grdDataList.Columns(1).HeaderText = "Type"
                SearchMenu.grdDataList.Columns(2).HeaderText = "Description"
                SearchMenu.grdDataList.Columns(3).HeaderText = "Level"
                SearchMenu.grdDataList.Columns(4).HeaderText = "Reconciler"

            Case "frmReconLogMaster"
                'Inialize a new instance of the DataSet object
                objDataSet = New DataSet()

                'Fill the DataSet object with data.....

                objDataAdapter.Fill(objDataSet, "dsReconLogMaster")

                'Set the DataView object to the DatSet object..
                objDataView = New DataView(objDataSet.Tables("dsReconLogMaster"))

                'Set our CurrencyManager object to the DataView object...
                objCurrencyManager = CType(frmReconLogMaster.BindingContext(objDataView), CurrencyManager)

                'Clear any previous bindings...
                frmReconLogMaster.cboReconType.DataBindings.Clear()
                frmReconLogMaster.txtReconDesc.DataBindings.Clear()
                frmReconLogMaster.txtReconciler.DataBindings.Clear()


                'Add new bindings to the DataView object...
                frmReconLogMaster.cboReconType.DataBindings.Add("text", objDataView, "ReconType")
                frmReconLogMaster.txtReconDesc.DataBindings.Add("text", objDataView, "ReconDesc")
                frmReconLogMaster.cboReconLevel.DataBindings.Add("text", objDataView, "ReconLevel")
                frmReconLogMaster.txtReconciler.DataBindings.Add("text", objDataView, "Reconciler")
                frmReconLogMaster.cboFrequency.DataBindings.Add("text", objDataView, "Frequency")


        End Select
        '***********************************************
        '******************* ACTION CODE ***************
        '***********************************************
        'objReconLogMasterData = New clsReconLogMaster
        'Call objReconLogData.subReconLogSelect(strBindTarget:="frmSearch", strAction:="SEARCH-ALL", _
        'intRowID:=0, strReconType:="NONE",strReconDesc:="NONE",strMonth:="NONE", strQuarter:="NONE", intYear:=0, strReconciler:="NONE" _
        'dtStartDate:="01/01/1900",dtStopDate:="01/01/1900", intNumRecItems:=0, intSumRecItems:=0, strCreatedUser:=SystemInformation.UserName,dtCreatedDate:="01/01/1900")
        '***********************************************
        '***********************************************

    End Sub

    '*** B. subReconLogMasterAction
    Public Sub subReconLogMasterAction(ByVal strBindTarget As String, ByVal strAction As String, ByVal intReconLogMasterID As Integer, ByVal strReconType As String, ByVal strReconDesc As String, ByVal strReconLevel As String, ByVal strReconciler As String, ByVal strFrequency As String)
        Dim objCommand As SqlCommand = New SqlCommand()
        objCommand.Connection = objConnection
        objCommand.CommandText = "procReconLogMaster"
        objCommand.CommandType = CommandType.StoredProcedure

        'Set the paramaters
        objCommand.Parameters.AddWithValue("@Action", strAction)
        objCommand.Parameters.AddWithValue("@ReconLogMasterID", intReconLogMasterID)
        objCommand.Parameters.AddWithValue("@ReconType", strReconType)
        objCommand.Parameters.AddWithValue("@ReconDesc", strReconDesc)
        objCommand.Parameters.AddWithValue("@ReconLevel", strReconLevel)
        objCommand.Parameters.AddWithValue("@Reconciler", strReconciler)
        objCommand.Parameters.AddWithValue("@Frequency", strFrequency)


        'Open the database connection...
        objConnection.Open()

        'Fill the DataSet object with data...
        objCommand.ExecuteNonQuery()

        'Close the database connection...
        objConnection.Close()

        '        '***********************************************
        '        '******************* ACTION CODE ***************
        '        '***********************************************
        '        ' objReconLogMasterAction = New clsReconLogMaster
        '        'Call objReconLogMasterAction.subReconLogMasterAction(strAction:="DELETE", intReconLogMasterID:=0, strReconType:="NONE", strReconDesc:="NONE", strReconLevel:="NONE", strReconciler:="NONE", strFrequency:="NONE")
        '        '***********************************************
        '        '***********************************************
    End Sub
End Class


