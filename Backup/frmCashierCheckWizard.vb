Public Class frmCashierCheckWizard

    Public WithEvents objCashierDetData As clsCashierDetail

    Private Sub frmCashierCHeckWizard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        subFormInit()

    End Sub

    Private Sub subFormInit()

        If frmCashierActivity.dtChk.Rows.Count = 0 Then
            'If frmCashierActivity.bitAddFlag = True Then  ' new record - table is not filled with data
            ' Create Column
            Dim cl1 As New DataColumn("Check Amount")
            cl1.DataType = GetType(Double)
            'Dim cl2 As New DataColumn("Column2")
            'cl2.DataType = GetType(String)
            ' Add column to table
            frmCashierActivity.dtChk.Columns.Add(cl1)
            'dtChk.Columns.Add(cl2)
            ' Add DataTable to DataSet
            frmCashierActivity.dsChk.Tables.Add(frmCashierActivity.dtChk)
            ' Step to add DataRow
            ' Create new row
            Dim dr As DataRow
            dr = frmCashierActivity.dsChk.Tables("DataTableChk").NewRow
            dr("Check Amount") = 0
            'dr("Column2") = "Welcome to vb.net Sample code"
            ' Add Row1
            frmCashierActivity.dsChk.Tables("DataTableChk").Rows.Add(dr)
            ' If you can use array of datarow.
            'Dim drArray(1) As DataRow

            'drArray(0) = dsChk.Tables(0).NewRow
            'drArray(0)("Check Amount") = 2
            ''drArray(0)("Column2") = "Show easy sample code"
            'dsChk.Tables("DataTableChk").Rows.Add(drArray(0))

            'drArray(1) = dsChk.Tables(0).NewRow
            'drArray(1)("Check Amount") = 3
            ''drArray(1)("Column2") = "Easy to understand"
            'dsChk.Tables("DataTableChk").Rows.Add(drArray(1))

            ' binddata to gridview
            Me.grdCCheckAmounts.DataSource = frmCashierActivity.dsChk.Tables("DataTableChk").Copy()
        End If

        Me.grdCCheckAmounts.Columns(0).DefaultCellStyle.Format = "N"
        Me.grdCCheckAmounts.Columns(0).Width = 182
        Me.grdCCheckAmounts.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


    End Sub

    Private Sub grdCCheckAmounts_CellContentLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCCheckAmounts.CellLeave

        subAddAmounts()

    End Sub

    Private Sub subAddAmounts()
        Dim dblCTAmt As Double = 0
        Dim intRowIdx As Integer = 0
        For intRowIdx = 0 To grdCCheckAmounts.Rows.Count - 1
            If grdCCheckAmounts.Rows(intRowIdx).Cells(0).Value Is DBNull.Value Then
                ' MsgBox("OK")
            Else
                dblCTAmt = dblCTAmt + grdCCheckAmounts.Rows(intRowIdx).Cells(0).Value
            End If
        Next intRowIdx

        Me.txtTotal.Text = String.Format("{0:N}", dblCTAmt)
        Me.txtCount.Text = grdCCheckAmounts.Rows.Count - 1

        'grdCCheckAmounts.Rows(0).Selected = True
        'grdCCheckAmounts.Rows(grdCCheckAmounts.Rows.Count - 1).Selected = True
    End Sub

    Private Sub grdCheckAmounts_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCCheckAmounts.CellValueChanged
        subAddAmounts()
    End Sub

    Private Sub grdCheckAmounts_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grdCCheckAmounts.RowsAdded
        subAddAmounts()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        frmCashierActivity.dsChk.Tables("DataTableChk").Clear()
        Me.grdCCheckAmounts.DataSource = frmCashierActivity.dsChk.Tables("DataTableChk").Copy()
        Me.grdCCheckAmounts.Columns(0).DefaultCellStyle.Format = "N"
        Me.grdCCheckAmounts.Columns(0).Width = 182
        Me.grdCCheckAmounts.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdCCheckAmounts.Rows(0).Cells(0).Value = 0
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Double.Parse(txtTotal.Text) = 0 And frmCashierActivity.bitAddFlag = True Then
            Me.Close()
            Exit Sub
        End If


        If frmCashierActivity.bitAddFlag = True Then
            objCashierDetData = New clsCashierDetail
            Call objCashierDetData.subCashierDetAction(strAction:="ADD", intCashierDetailID:=0, _
            intCashierTranID:=frmCashierActivity.intCashierRecPtr, strType:="Manual (Check)", intTranCount:=Integer.Parse(Me.txtCount.Text), mnyAmount:=Double.Parse(txtTotal.Text), _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")
        Else
            objCashierDetData = New clsCashierDetail
            Call objCashierDetData.subCashierDetAction(strAction:="UPDATE", intCashierDetailID:=frmCashierActivity.intCashierDetRecPtr, _
            intCashierTranID:=frmCashierActivity.intCashierRecPtr, strType:="Manual (Check)", intTranCount:=Integer.Parse(Me.txtCount.Text), mnyAmount:=Double.Parse(txtTotal.Text), _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")
        End If

        Me.Close()
    End Sub
End Class