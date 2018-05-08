Public Class frmCashierBalCheckWizard
    Public WithEvents objCashierWizData As clsCashierWizData

    Private Sub frmCashierCHeckWizard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        subFormInit()

    End Sub

    Private Sub subFormInit()
        Dim T As Integer = frmCashierBalancing.dtChk.Rows.Count

        objCashierWizData = New clsCashierWizData
        Call objCashierWizData.subCashierWizDataSelect(strBindTarget:="frmCashierBal-dtChk", strAction:="SELECT-WIZ-BY-TYPE", intCashierID:=frmCashierBalancing.intCashierRecPtr, _
                strWizType:="CK", mnyAmount:=0.0, intSequence:=0)

        Me.grdCCheckAmounts.Columns(0).DefaultCellStyle.Format = "N"
        Me.grdCCheckAmounts.Columns(0).Width = 182
        Me.grdCCheckAmounts.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        If grdCCheckAmounts.Rows.Count - 1 > 0 Then
            Me.tsBtnCKDel.Visible = True
        Else
            Me.tsBtnCKDel.Visible = False
        End If

    End Sub

    Private Sub grdCCheckAmounts_CellContentLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCCheckAmounts.CellLeave

        subAddAmounts()

    End Sub

    Private Sub subAddAmounts()
        Dim dblCTAmt As Double = 0
        Dim intRowIdx As Integer = 0
        Dim intCnt As Integer = 0
        For intRowIdx = 0 To grdCCheckAmounts.Rows.Count - 2
            If grdCCheckAmounts.Rows(intRowIdx).Cells(0).Value Is DBNull.Value Then
                ' MsgBox("OK")
            Else
                dblCTAmt = dblCTAmt + grdCCheckAmounts.Rows(intRowIdx).Cells(0).Value
                intCnt = intCnt + 1
            End If
        Next intRowIdx

        Me.txtTotal.Text = String.Format("{0:N}", dblCTAmt)
        Me.txtCount.Text = intCnt.ToString

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
        frmCashierBalancing.dsChk.Tables("DataTableChk").Clear()
        Me.grdCCheckAmounts.DataSource = frmCashierBalancing.dsChk.Tables("DataTableChk").Copy()
        Me.grdCCheckAmounts.Columns(0).DefaultCellStyle.Format = "N"
        Me.grdCCheckAmounts.Columns(0).Width = 182
        Me.grdCCheckAmounts.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdCCheckAmounts.Rows(0).Cells(0).Value = 0
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Double.Parse(txtTotal.Text) = 0 Then ' And frmCashierBalancing.bitAddFlag = True Then
            Me.Close()
            Exit Sub
        End If

        Dim dblCKAmt As Double = 0
        Dim intRowIdx As Integer = 0
        objCashierWizData = New clsCashierWizData
        Call objCashierWizData.subCashierWizAction(strAction:="DELETE-WIZ-BY-ID-TYPE", intCashierID:=frmCashierBalancing.intCashierRecPtr, _
                strWizType:="CK", mnyAmount:=0.0, intSequence:=0)

        For intRowIdx = 0 To grdCCheckAmounts.Rows.Count - 2
            If grdCCheckAmounts.Rows(intRowIdx).Cells(0).Value Is DBNull.Value Then
                ' MsgBox("OK")
            Else
                Call objCashierWizData.subCashierWizAction(strAction:="ADD-WIZ-ITEM", intCashierID:=frmCashierBalancing.intCashierRecPtr, _
                strWizType:="CK", mnyAmount:=grdCCheckAmounts.Rows(intRowIdx).Cells(0).Value, intSequence:=intRowIdx)
            End If
        Next intRowIdx

        'Me.txtTotal.Text = String.Format("{0:N}", dblCKAmt)
        'Me.txtCount.Text = grdCCheckAmounts.Rows.Count - 1



        frmCashierBalancing.txtManualCheckCnt.Text = Me.txtCount.Text
        frmCashierBalancing.txtManualCheck.Text = Me.txtTotal.Text

        Me.Close()
    End Sub

   
    Private Sub tsBtnCKDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnCKDel.Click
        If Val(Me.grdCCheckAmounts.ContainsFocus) = True Then

            Dim intRowValue As Integer = Val(Me.grdCCheckAmounts.CurrentRow.Index)

            Dim strAmt As String = String.Format("{0:C}", Me.grdCCheckAmounts.Rows(intRowValue).Cells(0).Value)
            Dim intSeq = Me.grdCCheckAmounts.Rows(intRowValue).Cells(1).Value

            Dim response As MsgBoxResult
            response = MsgBox("Are you sure you want to delete the Check for " & strAmt & " ?", MsgBoxStyle.YesNo, "Warning")

            If response = MsgBoxResult.Yes Then   ' User chose Yes.
                'Dim intRowID As Integer
                'intRowID = (Me.grdCTAmounts(0, intRowValue).Value) ' Get row ID to delete 
                'Dim intRecType As Integer
                'intRecType = (Me.grdCTAmounts(7, intRowValue).Value) ' Type - 1 align 2 adjust

                objCashierWizData = New clsCashierWizData
                Call objCashierWizData.subCashierWizAction(strAction:="DELETE-WIZ-BY-SEQ", intCashierID:=frmCashierBalancing.intCashierRecPtr, _
               strWizType:="CK", mnyAmount:=0.0, intSequence:=intSeq)
            Else
                MsgBox("Please select a Check to delete")
                Exit Sub
            End If
        End If

        subFormInit()
    End Sub
End Class