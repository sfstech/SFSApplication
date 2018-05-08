Public Class frmCashierDetail

    Public WithEvents objCashierDetData As clsCashierDetail

    Dim intErrCnt As Integer
    Dim dblTestAmt As Double

    Private Sub frmCashierDetail_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.txtAmount.Focus()
    End Sub

    Private Sub frmCashierDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cboType.Text = Me.cboType.Text.Trim  ' trim off spaces from grid
        If frmCashierActivity.intCashierDetRecPtr = 0 Then
            Me.btnDelete.Visible = False
        Else
            Me.btnDelete.Visible = True
        End If

        subSetScreenVisibleItems()

        Me.cboType.Items.Clear()
        Select Case Me.Text
            Case "Cash on Hand - Transactions"
                Me.cboType.Items.Add("Tot Amt on Hand")
                Me.cboType.Items.Add("Change Fund")
            Case "Payment Method - Transactions"
                Me.cboType.Items.Add("CashLink")
                Me.cboType.Items.Add("Cash")
                Me.cboType.Items.Add("Manual (Check)")
                Me.cboType.Items.Add("POP")
                '    Me.cboType.Items.Add("Credit Card")
            Case "Payment Category - Transactions"
                Me.cboType.Items.Add("SA Payment")
                Me.cboType.Items.Add("CT")
                Me.cboType.Items.Add("Over")
                Me.cboType.Items.Add("Short")
                '    Me.cboType.Items.Add("Collection")
        End Select

        ErrProvCashDet.SetError(Me.cboType, "")
        ErrProvCashDet.SetError(Me.txtCount, "")
        ErrProvCashDet.SetError(Me.txtAmount, "")

    End Sub
    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged

        subSetScreenVisibleItems()
        
    End Sub

    Sub subSetScreenVisibleItems()

        Me.lblKnowCount.Visible = False
        Me.lblKnowCount2.Visible = False
        Me.cboKnowCount.Visible = False

        Select Case Me.cboType.Text
            Case "SA Payment"
                '   If frmMainMenu.txtModule.Text = "CASHIER-APPROVE" Then
                
                Me.lblKnowCount.Visible = True
                Me.lblKnowCount2.Visible = True
                Me.cboKnowCount.Visible = True
                If Me.txtCount.Text <> "" Then
                    If Integer.Parse(Me.txtCount.Text) > 0 Then
                        Me.cboKnowCount.Text = "Yes"
                        Me.txtCount.Visible = True
                        Me.lblCount.Visible = True
                    Else
                        Me.cboKnowCount.Text = "No"
                        Me.txtCount.Visible = False
                        Me.lblCount.Visible = False
                    End If
                Else
                    Me.cboKnowCount.Text = "No"
                    Me.txtCount.Visible = False
                    Me.lblCount.Visible = False
                End If
               
                'Else
                'Me.txtCount.Visible = False
                'Me.lblCount.Visible = False
                '   End If
            Case "Manual (Check)", "POP", "CT"
                Me.txtCount.Visible = True
                Me.lblCount.Visible = True
            Case "Change Fund"
                Me.txtCount.Visible = False
                Me.lblCount.Visible = False
                Me.txtAmount.Text = "-300.00"
            Case Else
                Me.txtCount.Visible = False
                Me.lblCount.Visible = False
               
        End Select

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click, btnGo.Click

        intErrCnt = 0
        ErrProvCashDet.SetError(Me.cboType, "")
        ErrProvCashDet.SetError(Me.txtAmount, "")
        ErrProvCashDet.SetError(Me.txtCount, "")

        subValidateType()
        subValidateAmount()
        subValidateCount()
        If intErrCnt > 0 Then
            Exit Sub
        End If

        If frmCashierActivity.bitAddFlag = True Then
            objCashierDetData = New clsCashierDetail
            Call objCashierDetData.subCashierDetAction(strAction:="ADD", intCashierDetailID:=frmCashierActivity.intCashierDetRecPtr, _
            intCashierTranID:=frmCashierActivity.intCashierRecPtr, strType:=Me.cboType.Text, intTranCount:=Integer.Parse(Me.txtCount.Text), mnyAmount:=dblTestAmt, _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")
        Else
            objCashierDetData = New clsCashierDetail
            Call objCashierDetData.subCashierDetAction(strAction:="UPDATE", intCashierDetailID:=frmCashierActivity.intCashierDetRecPtr, _
            intCashierTranID:=frmCashierActivity.intCashierRecPtr, strType:=Me.cboType.Text, intTranCount:=Integer.Parse(Me.txtCount.Text), mnyAmount:=dblTestAmt, _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")
        End If

        Me.Close()
    End Sub
    Private Sub subValidateType()
        If Me.cboType.Text = "" Then
            ' ErrProvCash.SetError(Me.dtpActivityDate, "Cannot leave textbox blank")
            ErrProvCashDet.SetError(Me.cboType, "Type Cannot be blank, Please select a Type")
            intErrCnt += 1
        End If

        If frmCashierActivity.bitAddFlag = True Then
            Select Case Me.cboType.Text
                Case "Tot Amt on Hand", "Change Fund"
                    If (fnCheckOnHandExists("Change Fund    ") = True And Me.cboType.Text = "Change Fund") Or _
                       (fnCheckOnHandExists("Tot Amt on Hand") = True And Me.cboType.Text = "Tot Amt on Hand") Then
                        subSetTypeExistErr()
                        Exit Sub
                    End If
                Case "SA Payment", "CT", "Over", "Short", "Collection"
                    If (fnCheckPmtCatExists("SA Payment     ") = True And Me.cboType.Text = "SA Payment") Or _
                       (fnCheckPmtCatExists("CT             ") = True And Me.cboType.Text = "CT") Or _
                       (fnCheckPmtCatExists("Over           ") = True And Me.cboType.Text = "Over") Or _
                       (fnCheckPmtCatExists("Short          ") = True And Me.cboType.Text = "Short") Or _
                       (fnCheckPmtCatExists("Collection     ") = True And Me.cboType.Text = "Collection") Then
                        subSetTypeExistErr()
                        Exit Sub
                    End If
                Case "CashLink", "Cash", "Manual (Check)", "POP", "Credit Card"
                    If (fnCheckPmtMethExists("CashLink       ") = True And Me.cboType.Text = "CashLink") Or _
                       (fnCheckPmtMethExists("Cash           ") = True And Me.cboType.Text = "Cash") Or _
                       (fnCheckPmtMethExists("Manual (Check) ") = True And Me.cboType.Text = "Manual (Check)") Or _
                       (fnCheckPmtMethExists("POP            ") = True And Me.cboType.Text = "POP") Or _
                       (fnCheckPmtMethExists("Credit Card    ") = True And Me.cboType.Text = "Credit Card") Then
                        subSetTypeExistErr()
                        Exit Sub
                    End If
            End Select
        End If

    End Sub

    Private Sub subSetTypeExistErr()
        ErrProvCashDet.SetError(Me.cboType, Me.cboType.Text + " already exists on Cashier Activity screen")
        intErrCnt += 1
    End Sub

    Private Function fnCheckPmtMethExists(ByVal strType As String) As Boolean

        Dim dblPmtMethTot As Double = 0
        Dim intRowIdx As Integer = 0
        Dim strT As String
        For intRowIdx = 0 To frmCashierActivity.grdPmtMethDataTable.Rows.Count - 1
            strT = frmCashierActivity.grdPmtMeth.Rows(intRowIdx).Cells(2).Value
            If frmCashierActivity.grdPmtMeth.Rows(intRowIdx).Cells(2).Value = strType Then
                Return True
            End If
        Next intRowIdx

        Return False

    End Function

    Private Function fnCheckPmtCatExists(ByVal strType As String) As Boolean

        Dim dblPmtMethTot As Double = 0
        Dim intRowIdx As Integer = 0
        Dim strT As String
        For intRowIdx = 0 To frmCashierActivity.grdPmtCatDataTable.Rows.Count - 1
            strT = frmCashierActivity.grdPmtCat.Rows(intRowIdx).Cells(2).Value
            If frmCashierActivity.grdPmtCat.Rows(intRowIdx).Cells(2).Value = strType Then
                Return True
            End If
        Next intRowIdx

        Return False

    End Function

    Private Function fnCheckOnHandExists(ByVal strType As String) As Boolean

        Dim dblCOMTot As Double = 0
        Dim intRowIdx As Integer = 0
        Dim strT As String
        For intRowIdx = 0 To frmCashierActivity.grdPmtCOHDataTable.Rows.Count - 1
            strT = frmCashierActivity.grdCashOnHand.Rows(intRowIdx).Cells(2).Value
            If frmCashierActivity.grdCashOnHand.Rows(intRowIdx).Cells(2).Value = strType Then
                Return True
            End If
        Next intRowIdx

        Return False
    End Function

    Private Sub subValidateAmount()

        If Me.txtAmount.Text = "" Then
            ' ErrProvCash.SetError(Me.dtpActivityDate, "Cannot leave textbox blank")
            ErrProvCashDet.SetError(Me.txtAmount, "Please enter an amount")
            intErrCnt += 1
            Exit Sub
        End If

        Dim isNum As Boolean = Double.TryParse(Me.txtAmount.Text, dblTestAmt)

        If Not isNum Then
            ErrProvCashDet.SetError(Me.txtAmount, "Not a number")
            intErrCnt += 1
            Exit Sub
        End If

        dblTestAmt = txtAmount.Text
        If dblTestAmt = 0 Then
            ' ErrProvCash.SetError(Me.dtpActivityDate, "Cannot leave textbox blank")
            ErrProvCashDet.SetError(Me.txtAmount, "Please enter an amount")
            intErrCnt += 1
            Exit Sub
        Else
            ErrProvCashDet.SetError(Me.txtAmount, "")
            Select Case Me.cboType.Text
                Case "Short"
                    dblTestAmt = System.Math.Abs(dblTestAmt) * -1
                Case "Collection"
                    dblTestAmt = System.Math.Abs(dblTestAmt) * -1
                Case "Change Fund"
                    dblTestAmt = System.Math.Abs(dblTestAmt) * -1
                Case Else
                    dblTestAmt = System.Math.Abs(dblTestAmt)
            End Select
        End If
    End Sub
    Private Sub subValidateCount()

        If Me.txtCount.Text = "" Then
            Me.txtCount.Text = 0
        End If


        Dim intTest As Integer
        Dim isNum As Boolean = Integer.TryParse(Me.txtCount.Text, intTest)

        If Not isNum Then
            ErrProvCashDet.SetError(Me.txtCount, "Not a number")
            intErrCnt += 1
            Exit Sub
        End If


        Select Case Me.cboType.Text
            Case "SA Payment"
                '  If frmMainMenu.txtModule.Text = "CASHIER-APPROVE" Then
                If Me.txtCount.Text = 0 And Me.cboKnowCount.Text = "Yes" Then
                    ErrProvCashDet.SetError(Me.txtCount, "Please enter a count")
                    intErrCnt += 1
                    Exit Sub
                End If
                '  End If
            Case "Manual (Check)", "POP", "CT"
                If Me.txtCount.Text = 0 Then
                    ErrProvCashDet.SetError(Me.txtCount, "Please enter a count")
                    intErrCnt += 1
                    Exit Sub
                End If
        End Select
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        objCashierDetData = New clsCashierDetail
        Call objCashierDetData.subCashierDetAction(strAction:="DELETE", intCashierDetailID:=frmCashierActivity.intCashierDetRecPtr, _
        intCashierTranID:=frmCashierActivity.intCashierRecPtr, strType:="NONE", intTranCount:=0, mnyAmount:=0, _
        strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")

        If Me.cboType.Text = "CT" Then
            frmCashierActivity.ds.Tables("DataTable").Clear()
        End If

        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub cboKnowCount_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboKnowCount.SelectedValueChanged

        If Me.cboKnowCount.Text = "Yes" Then
            Me.txtCount.Visible = True
            Me.lblCount.Visible = True
        Else
            Me.txtCount.Visible = False
            Me.lblCount.Visible = False
            Me.txtCount.Text = "0"
        End If
    End Sub
End Class