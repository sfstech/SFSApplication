Public Class frmCashierCashWizard

    Public WithEvents objCashierDetData As clsCashierDetail
    Dim intInit As Integer = 1    ' 1 is initialze or reset    
    Dim intErr As Integer = 0

    Private Sub frmCashierCashWizard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subGetCashierActivityAmounts()
        subClearAmounts()
        subCalcTotal()
    End Sub

    Private Sub subClearAmounts()

        Me.txt100.Text = String.Format("{0:N}", frmCashierActivity.dblBill(0))
        Me.txt50.Text = String.Format("{0:N}", frmCashierActivity.dblBill(1))
        Me.txt20.Text = String.Format("{0:N}", frmCashierActivity.dblBill(2))
        Me.txt10.Text = String.Format("{0:N}", frmCashierActivity.dblBill(3))
        Me.txt5.Text = String.Format("{0:N}", frmCashierActivity.dblBill(4))
        Me.txt1.Text = String.Format("{0:N}", frmCashierActivity.dblBill(5))
        Me.txtQtr.Text = frmCashierActivity.dblChange(0)
        Me.txtDime.Text = frmCashierActivity.dblChange(1)
        Me.txtNickel.Text = frmCashierActivity.dblChange(2)
        Me.txtPennies.Text = frmCashierActivity.dblChange(3)
        Me.txtOther.Text = frmCashierActivity.dblChange(4)
        Me.txtTotal.Text = "0.00"
        intInit = 0
    End Sub

    Private Sub subGetCashierActivityAmounts()

        Me.txtCashLink.Text = fnGetPmtMethAmt("CashLink       ")
        Me.txtPOP.Text = fnGetPmtMethAmt("POP            ")
        Me.txtCheck.Text = fnGetPmtMethAmt("Manual (Check) ")
        Me.txtNetCash.Text = fnGetPmtMethAmt("Cash           ")
        Me.txtChangeFund.Text = fnGetOnHandAmt("Change Fund    ")

    End Sub
    Private Function fnGetPmtMethAmt(ByVal strType As String) As String

        Dim dblPmtMethTot As Double = 0
        Dim intRowIdx As Integer = 0
        Dim strT As String
        For intRowIdx = 0 To frmCashierActivity.grdPmtMethDataTable.Rows.Count - 1
            strT = frmCashierActivity.grdPmtMeth.Rows(intRowIdx).Cells(2).Value
            If frmCashierActivity.grdPmtMeth.Rows(intRowIdx).Cells(2).Value = strType Then
                dblPmtMethTot = dblPmtMethTot + frmCashierActivity.grdPmtMethDataTable.Rows(intRowIdx).Item(4)
            End If
        Next intRowIdx

        'If dblPmtMethTot > 0 Then
        Return String.Format("{0:N}", dblPmtMethTot)
        'Else
        'Return 0
        'End If


    End Function

    Private Function fnGetOnHandAmt(ByVal strType As String) As String

        Dim dblCOMTot As Double = 0
        Dim intRowIdx As Integer = 0
        Dim strT As String
        For intRowIdx = 0 To frmCashierActivity.grdPmtCOHDataTable.Rows.Count - 1
            strT = frmCashierActivity.grdCashOnHand.Rows(intRowIdx).Cells(2).Value
            If frmCashierActivity.grdCashOnHand.Rows(intRowIdx).Cells(2).Value = strType Then
                dblCOMTot = dblCOMTot + frmCashierActivity.grdPmtCOHDataTable.Rows(intRowIdx).Item(4)
            End If
        Next intRowIdx

        'If dblCOMTot > 0 Then
        Return String.Format("{0:N}", dblCOMTot)
        'Else
        'Return 0
        'End If

    End Function

    
    Private Sub txt100_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt100.Leave
        If Len(txt100.Text) = 0 Then
            Me.txt100.Text = "0"
        End If
        If fnCheckIfNumber(Me.txt100.Text) Then
            txt100.Text = String.Format("{0:N}", Double.Parse(txt100.Text))
            subCalcTotal()
            frmCashierActivity.dblBill(0) = Double.Parse(txt100.Text)
        Else
            Me.txt100.Focus()
        End If

        If Not fnCheckIfValidAmt(Me.txt100.Text, 100) Then
            Me.txt100.Focus()
            Exit Sub
        End If


    End Sub

    Private Sub txt50_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt50.Leave
        If Len(txt50.Text) = 0 Then
            Me.txt50.Text = "0"
        End If
        If fnCheckIfNumber(Me.txt50.Text) Then
            txt50.Text = String.Format("{0:N}", Double.Parse(txt50.Text))
            subCalcTotal()
            frmCashierActivity.dblBill(1) = Double.Parse(txt50.Text)
        Else
            Me.txt50.Focus()
        End If

        If Not fnCheckIfValidAmt(Me.txt50.Text, 50) Then
            Me.txt50.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub txt20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt20.Leave
        If Len(txt20.Text) = 0 Then
            Me.txt20.Text = "0"
        End If
        If fnCheckIfNumber(Me.txt20.Text) Then
            txt20.Text = String.Format("{0:N}", Double.Parse(txt20.Text))
            subCalcTotal()
            frmCashierActivity.dblBill(2) = Double.Parse(txt20.Text)
        Else
            Me.txt20.Focus()
        End If

        If Not fnCheckIfValidAmt(Me.txt20.Text, 20) Then
            Me.txt20.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub txt10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt10.Leave
        If Len(txt10.Text) = 0 Then
            Me.txt10.Text = "0"
        End If
        If fnCheckIfNumber(Me.txt10.Text) Then
            txt10.Text = String.Format("{0:N}", Double.Parse(txt10.Text))
            subCalcTotal()
            frmCashierActivity.dblBill(3) = Double.Parse(txt10.Text)
        Else
            Me.txt10.Focus()
        End If

        If Not fnCheckIfValidAmt(Me.txt10.Text, 10) Then
            Me.txt10.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub txt5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt5.Leave
        If Len(txt5.Text) = 0 Then
            Me.txt5.Text = "0"
        End If
        If fnCheckIfNumber(Me.txt5.Text) Then
            txt5.Text = String.Format("{0:N}", Double.Parse(txt5.Text))
            subCalcTotal()
            frmCashierActivity.dblBill(4) = Double.Parse(txt5.Text)
        Else
            Me.txt5.Focus()
        End If

        If Not fnCheckIfValidAmt(Me.txt5.Text, 5) Then
            Me.txt5.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub txt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt1.Leave
        If Len(txt1.Text) = 0 Then
            Me.txt1.Text = "0"
        End If
        If fnCheckIfNumber(Me.txt1.Text) Then
            txt1.Text = String.Format("{0:N}", Double.Parse(txt1.Text))
            subCalcTotal()
            frmCashierActivity.dblBill(5) = Double.Parse(txt1.Text)
        Else
            Me.txt1.Focus()
        End If

        If Not fnCheckIfValidAmt(Me.txt1.Text, 1) Then
            Me.txt1.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub txtQtr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtr.Leave
        If Len(txtQtr.Text) = 0 Then
            Me.txtQtr.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtQtr.Text) Then
            txtQtr.Text = String.Format("{0:N}", Double.Parse(txtQtr.Text))
            subCalcTotal()
            frmCashierActivity.dblChange(0) = Double.Parse(txtQtr.Text)
        Else
            Me.txtQtr.Focus()
        End If

        If Not fnCheckIfValid(Me.txtQtr.Text, 0.25) Then
            Me.txtQtr.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub txtDime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDime.Leave
        If Len(txtDime.Text) = 0 Then
            Me.txtDime.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtDime.Text) Then
            txtDime.Text = String.Format("{0:N}", Double.Parse(txtDime.Text))
            subCalcTotal()
            frmCashierActivity.dblChange(1) = Double.Parse(txtDime.Text)
        Else
            Me.txtDime.Focus()
        End If

        If Not fnCheckIfValid(Me.txtDime.Text, 0.1) Then
            Me.txtDime.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub txtNickel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNickel.Leave
        If Len(txtNickel.Text) = 0 Then
            Me.txtNickel.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtNickel.Text) Then
            txtNickel.Text = String.Format("{0:N}", Double.Parse(txtNickel.Text))
            subCalcTotal()
            frmCashierActivity.dblChange(2) = Double.Parse(txtNickel.Text)
        Else
            Me.txtNickel.Focus()
        End If

        If Not fnCheckIfValid(Me.txtNickel.Text, 0.05) Then
            Me.txtNickel.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub txtPennies_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPennies.Leave
        If Len(txtPennies.Text) = 0 Then
            Me.txtPennies.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtPennies.Text) Then
            txtPennies.Text = String.Format("{0:N}", Double.Parse(txtPennies.Text))
            subCalcTotal()
            frmCashierActivity.dblChange(3) = Double.Parse(txtPennies.Text)
        Else
            Me.txtPennies.Focus()
        End If

    End Sub

    Private Sub txtOther_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOther.Leave
        If Len(txtOther.Text) = 0 Then
            Me.txtOther.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtOther.Text) Then
            txtOther.Text = String.Format("{0:N}", Double.Parse(txtOther.Text))
            subCalcTotal()
            frmCashierActivity.dblChange(4) = Double.Parse(txtOther.Text)
        Else
            Me.txtOther.Focus()
        End If

    End Sub

    Private Function fnCheckIfNumber(ByVal strTestText As String) As Boolean

        Dim dblTestAmt As Double

        Dim isNum As Boolean = Double.TryParse(strTestText, dblTestAmt)

        If Not isNum Then
            MsgBox(strTestText + " is not a number")
            Return False
        Else
            Return True
        End If

    End Function

    Private Function fnCheckIfValid(ByVal strTestText As String, ByVal dblMod As Double) As Boolean

        Dim t As Integer

        Dim dblTestAmt As Double = Double.Parse(strTestText)
        t = Math.Round(dblTestAmt * 100) Mod dblMod * 100
        
        If t <> 0 Then
            MsgBox(strTestText + " is not a possible number for this type of coin")
            Return False
        Else
            Return True
        End If

    End Function
    Private Function fnCheckIfValidAmt(ByVal strTestText As String, ByVal dblMod As Double) As Boolean

        Dim dblTestAmt As Double = Double.Parse(strTestText)

        If dblTestAmt = 0 Then
            Return True
        End If

        Dim t As Integer
        t = Math.Round(dblTestAmt * 100) Mod dblMod * 100

        If (t <> 0 Or dblTestAmt < dblMod) Then
            MsgBox(dblTestAmt.ToString + " is not a possible amount for " & dblMod.ToString & " dollar bills")
            Return False
        Else
            Return True
        End If

    End Function
    Private Sub subCalcTotal()

        If intInit = 1 Then
            Exit Sub
        End If

        Dim dblTotal As Double
        Dim dblNet As Double
        
        dblTotal = Double.Parse(txt100.Text) + Double.Parse(txt50.Text) + Double.Parse(txt20.Text) + Double.Parse(txt10.Text) + Double.Parse(txt5.Text) + Double.Parse(txt1.Text) _
                    + Double.Parse(txtQtr.Text) + Double.Parse(txtDime.Text) + Double.Parse(txtNickel.Text) + Double.Parse(txtPennies.Text) + Double.Parse(txtOther.Text) '+ Double.Parse(txtChangeFund.Text)
        Me.txtTotal.Text = String.Format("{0:N}", dblTotal)
        Me.txtTotalClone.Text = Me.txtTotal.Text

        dblNet = dblTotal
        dblTotal = dblTotal + Double.Parse(txtCheck.Text) + Double.Parse(txtPOP.Text) + Double.Parse(txtCashLink.Text)
        txtTotAmtOnHand.Text = String.Format("{0:N}", dblTotal)

        dblNet = dblNet + Double.Parse(Me.txtChangeFund.Text)
        Me.txtNetCash.Text = String.Format("{0:N}", dblNet)

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Double.Parse(txtTotal.Text) = 0 And frmCashierActivity.bitAddFlag = True Then
            Me.Close()
            Exit Sub
        End If

        frmCashierActivity.dblPassCashAmt = Double.Parse(txtNetCash.Text)

        If frmCashierActivity.bitAddFlag = True Then
            objCashierDetData = New clsCashierDetail
            Call objCashierDetData.subCashierDetAction(strAction:="ADD", intCashierDetailID:=0, _
            intCashierTranID:=frmCashierActivity.intCashierRecPtr, strType:="Tot Amt on Hand", intTranCount:=0, mnyAmount:=Double.Parse(txtTotAmtOnHand.Text), _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")
        Else
            objCashierDetData = New clsCashierDetail
            Call objCashierDetData.subCashierDetAction(strAction:="UPDATE", intCashierDetailID:=frmCashierActivity.intCashierDetRecPtr, _
            intCashierTranID:=frmCashierActivity.intCashierRecPtr, strType:="Tot Amt on Hand", intTranCount:=0, mnyAmount:=Double.Parse(txtTotAmtOnHand.Text), _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")
        End If

        Me.Close()
    End Sub

    'Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
    '    Dim I As Integer
    '    For I = 0 To 6
    '        frmCashierActivity.intBill(I) = 0
    '        frmCashierActivity.dblChange(I) = 0
    '    Next I
    '    intInit = 1
    '    subClearAmounts()
    'End Sub


    ' this is an invisible key in the lower left hand corner of the form that makes Enter act like tab when used with form property AcceptButton
    Private Sub btnTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTab.Click
        SendKeys.Send("{TAB}")
    End Sub

   
End Class