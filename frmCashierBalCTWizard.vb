Public Class frmCashierBalCTWizard

    Public WithEvents objCashierWizData As clsCashierWizData

    Private Sub frmCashierCTWizard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        subFormInit()

    End Sub

    Private Sub subFormInit()

        objCashierWizData = New clsCashierWizData
        Call objCashierWizData.subCashierWizDataSelect(strBindTarget:="frmCashierBal-dtCT", strAction:="SELECT-WIZ-BY-TYPE", intCashierID:=frmCashierBalancing.intCashierRecPtr, _
                strWizType:="CT", mnyAmount:=0.0, intSequence:=0)

        Me.grdCTAmounts.Columns(0).DefaultCellStyle.Format = "N"
        Me.grdCTAmounts.Columns(0).Width = 182
        Me.grdCTAmounts.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        If grdCTAmounts.Rows.Count - 1 > 0 Then
            Me.tsBtnDel.Visible = True
        Else
            Me.tsBtnDel.Visible = False
        End If

    End Sub

    Private Sub grdCTAmounts_CellContentLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCTAmounts.CellLeave

        subAddAmounts()

    End Sub

    Private Sub subAddAmounts()
        Dim dblCTAmt As Double = 0
        Dim intRowIdx As Integer = 0
        Dim intCnt As Integer = 0
        For intRowIdx = 0 To grdCTAmounts.Rows.Count - 2
            If grdCTAmounts.Rows(intRowIdx).Cells(0).Value Is DBNull.Value Then
                ' MsgBox("OK")
            Else
                dblCTAmt = dblCTAmt + grdCTAmounts.Rows(intRowIdx).Cells(0).Value
                intCnt = intCnt + 1
            End If
        Next intRowIdx

        Me.txtTotal.Text = String.Format("{0:N}", dblCTAmt)
        Me.txtCount.Text = intCnt.ToString

    End Sub

    Private Sub grdCTAmounts_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCTAmounts.CellValueChanged
        subAddAmounts()
    End Sub

    Private Sub grdCTAmounts_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grdCTAmounts.RowsAdded
        subAddAmounts()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        frmCashierBalancing.dsCT.Tables("DataTable").Clear()
        Me.grdCTAmounts.DataSource = frmCashierBalancing.dsCT.Tables("DataTable").Copy()
        Me.grdCTAmounts.Columns(0).DefaultCellStyle.Format = "N"
        Me.grdCTAmounts.Columns(0).Width = 182
        Me.grdCTAmounts.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.grdCTAmounts.Rows(0).Cells(0).Value = 0
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
                strWizType:="CT", mnyAmount:=0.0, intSequence:=0)

        For intRowIdx = 0 To grdCTAmounts.Rows.Count - 2
            If grdCTAmounts.Rows(intRowIdx).Cells(0).Value Is DBNull.Value Then
                ' MsgBox("OK")
            Else
                Call objCashierWizData.subCashierWizAction(strAction:="ADD-WIZ-ITEM", intCashierID:=frmCashierBalancing.intCashierRecPtr, _
                strWizType:="CT", mnyAmount:=grdCTAmounts.Rows(intRowIdx).Cells(0).Value, intSequence:=intRowIdx)
            End If
        Next intRowIdx

        frmCashierBalancing.txtCTCnt.Text = Me.txtCount.Text
        frmCashierBalancing.txtCTAmt.Text = Me.txtTotal.Text
       

        Me.Close()

    End Sub

    Private Sub tsBtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnDel.Click
        If Val(Me.grdCTAmounts.ContainsFocus) = True Then

            Dim intRowValue As Integer = Val(Me.grdCTAmounts.CurrentRow.Index)

            Dim strAmt As String = String.Format("{0:C}", Me.grdCTAmounts.Rows(intRowValue).Cells(0).Value)
            Dim intSeq = Me.grdCTAmounts.Rows(intRowValue).Cells(1).Value

            Dim response As MsgBoxResult
            response = MsgBox("Are you sure you want to delete the CT for " & strAmt & " ?", MsgBoxStyle.YesNo, "Warning")

            If response = MsgBoxResult.Yes Then   ' User chose Yes.
                'Dim intRowID As Integer
                'intRowID = (Me.grdCTAmounts(0, intRowValue).Value) ' Get row ID to delete 
                'Dim intRecType As Integer
                'intRecType = (Me.grdCTAmounts(7, intRowValue).Value) ' Type - 1 align 2 adjust

                objCashierWizData = New clsCashierWizData
                Call objCashierWizData.subCashierWizAction(strAction:="DELETE-WIZ-BY-SEQ", intCashierID:=frmCashierBalancing.intCashierRecPtr, _
               strWizType:="CT", mnyAmount:=0.0, intSequence:=intSeq)
            Else
                MsgBox("Please select a CT to delete")
                Exit Sub
            End If
        End If

        subFormInit()

    End Sub
End Class