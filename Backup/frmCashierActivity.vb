Imports System.Text.RegularExpressions
Public Class frmCashierActivity
    Public WithEvents objCashierData As clsCashier
    Public WithEvents objCashierDetData As clsCashierDetail
    Public WithEvents objSecurityCheck As clsSystem
    Public WithEvents objUserData As clsSystem
    Public WithEvents objUserAction As clsSystem
    Public WithEvents objNoteAction As clsNote
    Public WithEvents objReportAction As clsReport

    Public grdPmtCOHDataTable As DataTable
    Public grdPmtCatDataTable As DataTable
    Public grdPmtMethDataTable As DataTable
    Friend grdCTAmountsDataTable As DataTable
    'Public RowCat As DataRow

    Public intCashierRecPtr As Integer = 0     ' Record# pointer to Cashier record - if it = 0 then is a new record or user has changed cashier or date
    Public intCashierDetRecPtr As Integer = 0  ' Record of Cashier Detail record from Grid being modified or deleted
    Public intRetCashierRecNbr As Integer = 0  ' Returned (Record number or count) from procCashier on CHECK-EXISTS or Record number of added record ADD
    Public bitAddFlag As Boolean               ' indicates whether detail is being added - true or modified - false
    Dim bitEditModeFlag As Boolean             ' indicates edit mode for cashier record
    'Dim strHoldCashierNbr As String
    Dim intErrCnt As Integer                           ' indicates the number of validation errors on the form 
    Dim intStatus As Integer = 0               ' 0 = New , 1 = created , 
    Dim intValidRecFlag As Boolean = 0
    Dim intOverShortFlag As Integer             ' indicates whether over short record has been entered Used to indicate a Note is required
    Dim intSACountFlag As Integer             ' indicates whether there is a SA Payment Record and Count is zero
    Dim strSubmitError As String
    Dim strSaveActivityDate As String             ' save activity date for info if they change it to a record that already exists

    Friend dblChange(6) As Double
    'Friend intBill(6) As Integer
    Friend dblBill(6) As Double
    Friend ds As New DataSet("DataSetTemp")        'dataset for CT Wizard
    Friend dt As New DataTable("DataTable")        'table for CT Wizard
    Friend dsChk As New DataSet("DataSetChk")        'dataset for Check Wizard
    Friend dtChk As New DataTable("DataTableChk")        'table for Check Wizard
    Friend dblPassCashAmt As Double = 0

    Private Sub frmCashierActivity_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        subRefreshGrids()
    End Sub
    Private Sub frmCashierActivity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case frmMainMenu.txtModule.Text
            Case "CASHIER-CREATE", "CASHIER-SEARCH-ALL", "CASHIER-SEARCH-BY-DATE", "CASHIER-SEARCH-BY-CASHIER", "CASHIER-SEARCH-BY-AMT"
                subSetSecurityLevel()
        End Select

        Select Case frmMainMenu.txtModule.Text
            Case "CASHIER-CREATE"
                'Format screen
                Me.Text = "Create New Cashier Record"
                Me.tsWizard.Enabled = True
                Me.tsbtnEdit.Visible = False
                Me.tsbtnDel.Visible = False
                Me.tsbtnReport.Enabled = False
                Me.btnExit.Text = "CANCEL"
                Me.btnExit.Text = "Cancel"
                Me.btnAddCashOnHand.Enabled = False
                Me.btnAddPmtCat.Enabled = False
                Me.btnAddPmtMeth.Enabled = False

                ' Fill cashier combo box
                objUserData = New clsSystem
                Call objUserData.subUserSelect(strBindTarget:="frmCashierActivity-cb", strAction:="SELECT-CASHIER-ALL", _
                intUserID:=0, intPersonID:=0, strUserName:=SystemInformation.UserName, strPassword:="NONE", dtPasswordDate:="01/01/1900", _
                strStatus:="A", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
                ' initialize fields
                Me.cboCashier.Text = SystemInformation.UserName
                Me.txtCreatedBy.Text = SystemInformation.UserName
                Me.txtCreatedOn.Text = Format(System.DateTime.Now, "short date")
                ' Get cashier Deposit Slip
                subAddCashierRecord()
                'subGetCashierDepSlip()
                Me.txtDepositSlip.Text = fnGetCashierDepSlip()
                If Me.txtDepositSlip.Text = "9999" Then
                    Me.txtDepositSlip.Text = ""
                    Me.cboCashier.Text = ""
                Else
                    Me.cboCashier.Enabled = False
                End If
                Me.CtrlNoteDisplay1.Tag = "frmCashierActivity Cashier " & intCashierRecPtr
                objNoteAction = New clsNote
                Me.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=intCashierRecPtr) & " Total)"
            Case "CASHIER-SUBMIT"
                subEnableFormControls()
                subRefreshGrids()
                Me.CtrlNoteDisplay1.Tag = "frmCashierActivity Cashier " & intCashierRecPtr
                objNoteAction = New clsNote
                Me.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=intCashierRecPtr) & " Total)"
            Case "CASHIER-APPROVE"
                subRefreshGrids()
                Me.CtrlNoteDisplay1.Tag = "frmCashierActivity Cashier " & intCashierRecPtr
                objNoteAction = New clsNote
                Me.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=intCashierRecPtr) & " Total)"
            Case "CASHIER-VALIDATE"
                subRefreshGrids()
                Me.CtrlNoteDisplay1.Tag = "frmCashierActivity Cashier " & intCashierRecPtr
                objNoteAction = New clsNote
                Me.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=intCashierRecPtr) & " Total)"
            Case "CASHIER-SEARCH-ALL"
                Me.ErrProvCash.Clear()
                Me.tsbtnDel.Enabled = False
                Me.tsWizard.Enabled = False
                Me.cboCashier.Enabled = False
                Me.dtpActivityDate.Enabled = False
                Me.txtBagNbr.Enabled = False
                Me.txtDepositSlip.Enabled = False
                Me.btnAddCashOnHand.Enabled = False
                Me.btnAddPmtCat.Enabled = False
                Me.cbxSubmit.Enabled = False
                Me.btnAddPmtMeth.Enabled = False
                Me.btnGO.Enabled = False
                'Me.txtCreatedOn.Text.Substring(1, 8)
                Me.CtrlNoteDisplay1.Tag = "frmCashierActivity Cashier " & intCashierRecPtr
                objNoteAction = New clsNote
                Me.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=intCashierRecPtr) & " Total)"
            Case Else
                MsgBox("Load Event Error: (" & frmMainMenu.txtModule.Text & ")")
        End Select

        strSaveActivityDate = dtpActivityDate.Text

    End Sub

    Private Sub subSetSecurityLevel()

        If frmMainMenu.txtModule.Text = "CASHIER-CREATE" Then
            Exit Sub
        End If

        frmMainMenu.txtModule.Text = "CASHIER-SEARCH-ALL"  ' set to lowest level

        ' these selects should be in the order of highest level checked first
        Dim strPassFail As String
        objSecurityCheck = New clsSystem
        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="CASHIER-ROLE-CHECK", strRole:="Approve")
        If strPassFail = "PASS" Then
            frmMainMenu.txtModule.Text = "CASHIER-APPROVE"
            Exit Sub
        End If

        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="CASHIER-ROLE-CHECK", strRole:="Create")
        If strPassFail = "PASS" And Me.txtApprovedBy.Text = "" And Me.txtCreatedBy.Text = SystemInformation.UserName Then
            If Me.txtCreatedBy.Text = SystemInformation.UserName Then
                frmMainMenu.txtModule.Text = "CASHIER-SUBMIT"
                Exit Sub
            End If

        End If

    End Sub
    Private Sub subEnableFormControls()

        Me.tsbtnDel.Enabled = True
        Me.tsWizard.Enabled = True
        Me.cboCashier.Enabled = True
        Me.dtpActivityDate.Enabled = True
        Me.txtBagNbr.Enabled = True
        Me.txtDepositSlip.Enabled = True
        Me.btnAddCashOnHand.Enabled = True
        Me.btnAddPmtCat.Enabled = True
        Me.cbxSubmit.Enabled = True
        Me.btnAddPmtMeth.Enabled = True
        Me.btnGO.Enabled = True

        Select Case frmMainMenu.txtModule.Text
            Case "CASHIER-SUBMIT"
                Me.cboCashier.Enabled = False
        End Select

    End Sub
    'Private Sub subGetCashierDepSlip()
    '    objUserAction = New clsSystem
    '    Call objUserAction.subUserAction(strAction:="SELECT-CASHIER-NUMBER", intUserID:=0, intPersonID:=0, _
    '                strUserName:=Me.cboCashier.Text, strPassword:="NONE", dtPasswordDate:="01/01/1900", _
    '                strStatus:="N", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
    '    Me.txtDepositSlip.Text = String.Format(intRetCashierRecNbr)
    'End Sub
    Friend Function fnGetCashierDepSlip() As String
        objUserAction = New clsSystem
        Call objUserAction.subUserAction(strAction:="SELECT-CASHIER-NUMBER", intUserID:=0, intPersonID:=0, _
                    strUserName:=Me.cboCashier.Text, strPassword:="NONE", dtPasswordDate:="01/01/1900", _
                    strStatus:="N", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        Return String.Format(intRetCashierRecNbr)
        'Me.txtDepositSlip.Text = String.Format(intRetCashierRecNbr)
    End Function


    Private Sub ValidCashierCheck()

        If Me.cboCashier.Text = "" Then
            ErrProvCash.SetError(Me.cboCashier, "Cashier Cannot be blank, Please select a Cashier")
            intErrCnt += 1
        Else
            ErrProvCash.SetError(Me.cboCashier, "")
        End If

    End Sub
    Private Sub ValidDepSlipCheck()
        strSubmitError = ""
        Dim rexp_DepSlip As New Regex("([1][0][0-1]\d{4})")

        If rexp_DepSlip.IsMatch(Me.txtDepositSlip.Text) And Len(Me.txtDepositSlip.Text) = 7 Then
            ErrProvCash.SetError(Me.txtDepositSlip, "")
        Else
            strSubmitError = "You must enter a valid 7 digit Deposit Slip number - ex. 1014789"
            If Me.cbxSubmit.Checked = False Then
                MsgBox(strSubmitError, MsgBoxStyle.Exclamation, "Warning")
                strSubmitError = ""
            Else
                ErrProvCash.SetError(Me.txtDepositSlip, strSubmitError)
                intErrCnt += 1
            End If
        End If


    End Sub

    Private Sub ValidBagNbrCheck()

        Dim strTest As String
        Dim intFlag As Integer = 0
        Dim intRowIdx As Integer = 0
        For intRowIdx = 0 To grdPmtMethDataTable.Rows.Count - 1
            strTest = Me.grdPmtMeth.Rows(intRowIdx).Cells(2).Value.ToString.Trim
            If strTest = "Cash" Or strTest = "Manual (Check)" Then
                intFlag += 1
            End If
        Next intRowIdx

        If intFlag = 0 Then
            Exit Sub
        End If

        strSubmitError = ""
        Dim rexp_BagNbr As New Regex("(\d{6})")

        If rexp_BagNbr.IsMatch(Me.txtBagNbr.Text) And Len(Me.txtBagNbr.Text) = 6 Then
            ErrProvCash.SetError(Me.txtBagNbr, "")
        Else
            strSubmitError = "You must enter a valid 6 digit Deposit Bag number - ex. 123456"
            If Me.cbxSubmit.Checked = False Then
                MsgBox(strSubmitError, MsgBoxStyle.Exclamation, "Warning")
                strSubmitError = ""
            Else
                ErrProvCash.SetError(Me.txtBagNbr, strSubmitError)
                intErrCnt += 1
            End If
        End If

    End Sub


    Private Sub subRefreshGrids()

        subRefreshCashOnHandGrid()
        subRefreshPmtCatGrid()
        subRefreshPmtMethGrid()

    End Sub
    Private Sub subRefreshCashOnHandGrid()

        objCashierDetData = New clsCashierDetail
        Call objCashierDetData.subCashierDetSelect(strBindTarget:="frmCashierAct-Cash", strAction:="SELECT-DETAIL-COH", _
        intCashierDetailID:=intCashierRecPtr, intCashierTranID:=intCashierRecPtr, strType:="NONE", intTranCount:=0, mnyAmount:=0, _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")

        Dim dblPmtCOHTot As Double = 0
        Dim intRowIdx As Integer = 0
        For intRowIdx = 0 To grdPmtCOHDataTable.Rows.Count - 1
            dblPmtCOHTot = dblPmtCOHTot + grdPmtCOHDataTable.Rows(intRowIdx).Item(4)
            ' Me.grdCashOnHand.Rows(intRowIdx).Cells(3).Style.BackColor = Color.Pink
            If Me.grdCashOnHand.Rows(intRowIdx).Cells(3).Value = 0 Then
                Me.grdCashOnHand.Rows(intRowIdx).Cells(3).Style.ForeColor = Color.White
            Else
                Me.grdCashOnHand.Rows(intRowIdx).Cells(3).Style.ForeColor = Color.Black
            End If

        Next intRowIdx

        ' add cashLink, POP and Checks to Total
        'For intRowIdx = 0 To grdPmtMethDataTable.Rows.Count - 1
        '    If Me.grdPmtMeth.Rows(intRowIdx).Cells(1).Value = "CashLink" Or "POP" Or "Manual (Check)" Then
        '        dblPmtCOHTot = dblPmtCOHTot + grdPmtMethDataTable.Rows(intRowIdx).Item(4)
        '    End If
        'Next intRowIdx


        txtCashOnHandTot.Text = String.Format("{0:C}", dblPmtCOHTot)

    End Sub

    Private Sub subRefreshPmtCatGrid()
        Dim strTest As String
        objCashierDetData = New clsCashierDetail
        Call objCashierDetData.subCashierDetSelect(strBindTarget:="frmCashierAct-Cat", strAction:="SELECT-DETAIL-CAT", _
        intCashierDetailID:=intCashierRecPtr, intCashierTranID:=intCashierRecPtr, strType:="NONE", intTranCount:=0, mnyAmount:=0, _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")

        Dim dblPmtCatTot As Double = 0
        Dim intRowIdx As Integer = 0
        intOverShortFlag = 0
        intSACountFlag = 0
        For intRowIdx = 0 To grdPmtCatDataTable.Rows.Count - 1
            dblPmtCatTot = dblPmtCatTot + grdPmtCatDataTable.Rows(intRowIdx).Item(4)
            If Me.grdPmtCat.Rows(intRowIdx).Cells(3).Value = 0 Then
                Me.grdPmtCat.Rows(intRowIdx).Cells(3).Style.ForeColor = Color.White
            Else
                Me.grdPmtCat.Rows(intRowIdx).Cells(3).Style.ForeColor = Color.Black
            End If

            strTest = grdPmtCatDataTable.Rows(intRowIdx).Item(2).ToString.Trim
            If strTest = "Over" Or strTest = "Short" Then
                intOverShortFlag = 1
            End If
            If strTest = "SA Payment" Then
                If grdPmtCatDataTable.Rows(intRowIdx).Item(3).ToString = "0" Then
                    intSACountFlag = 1
                End If
            End If
        Next intRowIdx

        txtPmtCatTot.Text = String.Format("{0:C}", dblPmtCatTot)

    End Sub

    Private Sub subRefreshPmtMethGrid()

        objCashierDetData = New clsCashierDetail
        Call objCashierDetData.subCashierDetSelect(strBindTarget:="frmCashierAct-Meth", strAction:="SELECT-DETAIL-METH", _
        intCashierDetailID:=intCashierRecPtr, intCashierTranID:=intCashierRecPtr, strType:="NONE", intTranCount:=0, mnyAmount:=0, _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")

        Dim dblPmtMethTot As Double = 0
        Dim dblCashInBagTot As Double = 0
        Dim strTest As String
        Dim intRowIdx As Integer = 0
        For intRowIdx = 0 To grdPmtMethDataTable.Rows.Count - 1
            dblPmtMethTot = dblPmtMethTot + grdPmtMethDataTable.Rows(intRowIdx).Item(4)

            ' add *** Cash/Checks in bag tot here
            strTest = grdPmtMethDataTable.Rows(intRowIdx).Item(2).ToString.Trim
            If strTest = "Cash" Or strTest = "Manual (Check)" Then
                dblCashInBagTot = dblCashInBagTot + grdPmtMethDataTable.Rows(intRowIdx).Item(4)
            End If

            If Me.grdPmtMeth.Rows(intRowIdx).Cells(3).Value = 0 Then
                Me.grdPmtMeth.Rows(intRowIdx).Cells(3).Style.ForeColor = Color.White
            Else
                Me.grdPmtMeth.Rows(intRowIdx).Cells(3).Style.ForeColor = Color.Black
            End If
        Next intRowIdx

        txtCashInBag.Text = String.Format("{0:C}", dblCashInBagTot)
        txtPmtMethTot.Text = String.Format("{0:C}", dblPmtMethTot)

    End Sub

    Private Sub cboCashier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCashier.SelectedIndexChanged
        'subGetCashierDepSlip()
        Me.txtDepositSlip.Text = fnGetCashierDepSlip()
    End Sub

    Private Sub subValidateCashierRecord()
        'Me.Text = "Cashier Activity for " + Me.cboCashier.Text + " on " + Me.dtpActivityDate.Value.ToShortDateString
        If Me.cboCashier.Text <> "" And Me.txtBagNbr.Text <> "" And Me.txtDepositSlip.Text <> "" Then
            Me.btnAddPmtCat.Enabled = True
            Me.btnAddPmtMeth.Enabled = True
        End If

    End Sub

    Friend Function subCheckCashierExists() As Integer

        objCashierData = New clsCashier
        Call objCashierData.subCashierAction(strAction:="CHECK-EXISTS", _
             intCashierTranID:=0, dtTranDate:=Me.dtpActivityDate.Value, strDepositSlip:="NONE", _
             strBagNumber:="NONE", strCashierUserName:=Me.cboCashier.Text, strCreateUser:="NONE", _
             dtCreateDate:="01/01/1900", strApproveUser:="NONE", dtApproveDate:="01/01/1900", _
             strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSubmittedFlag:=0)

        Return intRetCashierRecNbr
    End Function

    Sub subAddCashierRecord()

        objCashierData = New clsCashier
        Call objCashierData.subCashierAction(strAction:="ADD", _
            intCashierTranID:=0, dtTranDate:=Me.dtpActivityDate.Value, strDepositSlip:=Me.txtDepositSlip.Text, _
            strBagNumber:=Me.txtBagNbr.Text, strCashierUserName:=Me.cboCashier.Text, strCreateUser:=SystemInformation.UserName, _
            dtCreateDate:=System.DateTime.Now, strApproveUser:="NONE", dtApproveDate:="01/01/1900", _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSubmittedFlag:=0)
        intCashierRecPtr = intRetCashierRecNbr

    End Sub
    'Sub subUpdateCashierRecord()

    '    objCashierData = New clsCashier
    '    Call objCashierData.subCashierAction(strAction:="UPDATE", _
    '        intCashierTranID:=Me.intCashierRecPtr, dtTranDate:=Me.dtpActivityDate.Value, strDepositSlip:=Me.txtDepositSlip.Text, _
    '        strBagNumber:=Me.txtBagNbr.Text, strCashierUserName:=Me.cboCashier.Text, strCreateUser:="NONE", _
    '        dtCreateDate:="01/01/1900", strApproveUser:="NONE", dtApproveDate:="01/01/1900", _
    '        strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSubmittedFlag:=0)

    'End Sub
    Private Sub btnAddCashOnHand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCashOnHand.Click


        'If frmMainMenu.txtModule.Text = "CASHIER-CREATE" Then
        '    bitAddFlag = True
        '    frmCashierCashWizard.ShowDialog()
        '    subRefreshCashOnHandGrid()
        'Else
        frmCashierDetail.cboType.Text = ""
        frmCashierDetail.txtAmount.Text = "" ' String.Format("{0:N}", 0)
        frmCashierDetail.txtCount.Text = ""
        frmCashierDetail.Text = "Cash on Hand - Transactions"
        bitAddFlag = True
        frmCashierDetail.ShowDialog()
        subRefreshCashOnHandGrid()
        'End If

    End Sub
    Private Sub grdCashOnHand_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCashOnHand.DoubleClick

        Dim intRowPtr As Integer = Val(grdCashOnHand.CurrentRow.Index)
        Dim intNbrRows As Integer = grdPmtCOHDataTable.Rows.Count - 1
        If intRowPtr > intNbrRows Then
            Exit Sub
        End If
        intCashierDetRecPtr = (grdCashOnHand(0, intRowPtr).Value)
        frmCashierDetail.cboType.Text = (grdCashOnHand(2, intRowPtr).Value)
        frmCashierDetail.txtCount.Text = (grdCashOnHand(3, intRowPtr).Value)
        frmCashierDetail.txtAmount.Text = String.Format("{0:N}", (grdCashOnHand(4, intRowPtr).Value))

        If frmCashierDetail.cboType.Text = "Tot Amt on Hand" And frmMainMenu.txtModule.Text = "CASHIER-CREATE" Then
            bitAddFlag = False
            frmCashierCashWizard.ShowDialog()
            subRefreshCashOnHandGrid()
        Else
            frmCashierDetail.Text = "Cash on Hand - Transactions"
            bitAddFlag = False
            frmCashierDetail.ShowDialog()
            subRefreshCashOnHandGrid()
        End If

    End Sub

    Private Sub btnAddPmtCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPmtCat.Click

        'intCashierRecPtr = 0
        frmCashierDetail.cboType.Text = ""
        frmCashierDetail.txtAmount.Text = "" ' String.Format("{0:N}", 0)
        frmCashierDetail.txtCount.Text = ""
        frmCashierDetail.Text = "Payment Category - Transactions"
        bitAddFlag = True
        frmCashierDetail.ShowDialog()
        subRefreshPmtCatGrid()

    End Sub

    Private Sub grdPmtCat_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPmtCat.DoubleClick
        Dim intRowPtr As Integer = Val(grdPmtCat.CurrentRow.Index)
        Dim intNbrRows As Integer = grdPmtCatDataTable.Rows.Count - 1
        If intRowPtr > intNbrRows Then
            Exit Sub
        End If
        intCashierDetRecPtr = (grdPmtCat(0, intRowPtr).Value)
        frmCashierDetail.cboType.Text = (grdPmtCat(2, intRowPtr).Value)
        frmCashierDetail.txtCount.Text = (grdPmtCat(3, intRowPtr).Value)
        frmCashierDetail.txtAmount.Text = String.Format("{0:N}", (grdPmtCat(4, intRowPtr).Value))

        Dim s As String = frmCashierDetail.cboType.Text
        Dim r As String = frmMainMenu.txtModule.Text

        If frmCashierDetail.cboType.Text = "CT             " And frmMainMenu.txtModule.Text = "CASHIER-CREATE" Then
            bitAddFlag = False
            frmCashierCTWizard.ShowDialog()
            subRefreshPmtCatGrid()
        Else
            frmCashierDetail.Text = "Payment Category - Transactions"
            bitAddFlag = False
            frmCashierDetail.ShowDialog()
            subRefreshPmtCatGrid()
        End If

    End Sub

    Private Sub btnAddPmtMeth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPmtMeth.Click


        frmCashierDetail.cboType.Text = ""
        frmCashierDetail.txtAmount.Text = "" 'String.Format("{0:N}", 0)
        frmCashierDetail.txtCount.Text = ""
        frmCashierDetail.Text = "Payment Method - Transactions"
        bitAddFlag = True
        frmCashierDetail.ShowDialog()
        subRefreshPmtMethGrid()

    End Sub

    Private Sub grdPmtMeth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPmtMeth.DoubleClick

        Dim intRowPtr As Integer = Val(grdPmtMeth.CurrentRow.Index)
        Dim intNbrRows As Integer = grdPmtMethDataTable.Rows.Count - 1
        If intRowPtr > intNbrRows Then
            Exit Sub
        End If
        intCashierDetRecPtr = (grdPmtMeth(0, intRowPtr).Value)
        frmCashierDetail.cboType.Text = (grdPmtMeth(2, intRowPtr).Value)
        frmCashierDetail.txtCount.Text = (grdPmtMeth(3, intRowPtr).Value)
        frmCashierDetail.txtAmount.Text = String.Format("{0:N}", (grdPmtMeth(4, intRowPtr).Value))

        If frmCashierDetail.cboType.Text = "Manual (Check) " And frmMainMenu.txtModule.Text = "CASHIER-CREATE" Then
            bitAddFlag = False
            frmCashierCheckWizard.ShowDialog()
            subRefreshPmtMethGrid()
        Else
            frmCashierDetail.Text = "Payment Method - Transactions"
            bitAddFlag = False
            frmCashierDetail.ShowDialog()
            subRefreshPmtMethGrid()
        End If

    End Sub

    Private Sub btnGO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGO.Click

        intErrCnt = 0
        ErrProvCash.SetError(Me.cboCashier, "")
        ErrProvCash.SetError(Me.dtpActivityDate, "")
        ErrProvCash.SetError(Me.txtDepositSlip, "")
        ErrProvCash.SetError(Me.txtBagNbr, "")
        ErrProvCash.SetError(Me.btnAddCashOnHand, "")
        ErrProvCash.SetError(Me.btnAddPmtCat, "")
        ErrProvCash.SetError(Me.btnAddPmtMeth, "")

        Select Case frmMainMenu.txtModule.Text
            Case "CASHIER-CREATE"
                ' Is cashier blank?
                Me.ValidCashierCheck()
                If intErrCnt > 0 Then
                    Exit Sub
                End If
                ' Is cashier record not Today?
                If (Me.dtpActivityDate.Value.Date <> System.DateTime.Now.Date) Or (Me.cboCashier.Text <> SystemInformation.UserName) Then
                    Dim intExists As Integer
                    intExists = Me.subCheckCashierExists()
                    If intExists <> 0 Then
                        ' ErrProvCash.SetError(Me.cboCashier, "A Record for " & Me.cboCashier.Text & " on " & Me.dtpActivityDate.Value.ToShortDateString & " already exists")
                        ErrProvCash.SetError(Me.dtpActivityDate, "A Record for " & Me.cboCashier.Text & " on " & Me.dtpActivityDate.Value.ToShortDateString & " already exists")
                        intErrCnt += 1
                    Else
                        ErrProvCash.SetError(Me.cboCashier, "")
                        ErrProvCash.SetError(Me.dtpActivityDate, "")
                    End If
                End If

                If intErrCnt > 0 Then
                    Exit Sub
                End If

                subCheckTotalsAndUpdate()
                'Me.subUpdateCashierRecord()
                'subSubmitRecord()
                'Me.Close()

            Case "CASHIER-SUBMIT"
                subCheckTotalsAndUpdate()
            Case "CASHIER-APPROVE"
                subCheckTotalsAndUpdate()
            Case "CASHIER-VALIDATE"
                'subLoadCashier()
            Case "CASHIER-SEARCH-ALL"
                Exit Sub
            Case Else
                MsgBox("Load Event Error: (" & frmMainMenu.txtModule.Text & ")")
        End Select
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Select Case frmMainMenu.txtModule.Text
            Case "CASHIER-CREATE"
                If Me.intCashierRecPtr <> 0 Then
                    Dim intResult As Integer
                    intResult = MsgBox("Are You sure you want Cancel this Cashier record and ALL its Transactions!", MessageBoxButtons.YesNo)
                    If intResult = DialogResult.Yes Then
                        subDeleteCashierRecord()
                    Else
                        Exit Sub
                    End If
                End If
        End Select
        Me.Close()

    End Sub

    Private Sub tsbtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDel.Click

        Dim intResult As Integer
        intResult = MsgBox("Are You sure you want to DELETE this Cashier record and ALL its Transactions!", MessageBoxButtons.OKCancel)
        If intResult = DialogResult.Cancel Then
            Exit Sub
        Else
            subDeleteCashierRecord()
            Me.Close()
        End If

    End Sub

    Private Sub subDeleteCashierRecord()

        objCashierData = New clsCashier
        Call objCashierData.subCashierAction(strAction:="DELETE", _
                     intCashierTranID:=intCashierRecPtr, dtTranDate:="01/01/1900", strDepositSlip:="NONE", _
                     strBagNumber:="NONE", strCashierUserName:=Me.cboCashier.Text, strCreateUser:="NONE", _
                     dtCreateDate:="01/01/1900", strApproveUser:="NONE", dtApproveDate:="01/01/1900", _
                     strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSubmittedFlag:=0)

    End Sub

    'Private Sub subSubmitRecord()

    '    If Me.cbxSubmit.Checked = True Then
    '        subCheckTotalsAndUpdate()
    '        MsgBox("Not yet - coming Soon - Play with + buttons, edit and delete! " & strSubmitError)
    '    End If
    'End Sub

    Private Sub tsbtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnReport.Click
        subPrintPmtReconReport()
    End Sub

    Private Sub subPrintPmtReconReport()
        objReportAction = New clsReport
        Call objReportAction.subReportOpen(intReportID:=0, strReportPath:="I:\groups\sfs\computing\VB-APPS\PRODUCTION\SFS\rptCashierDailyRecon.rpt", _
        strParameter1Name:="@TranDate", strParameter1Value:=Format(Me.dtpActivityDate.Value, "MM/dd/yy"), strParameter2Name:="@CashierTranID", strParameter2Value:=intCashierRecPtr, _
        strParameter3Name:="NONE", strParameter3Value:="NONE", strParameter4Name:="NONE", strParameter4Value:="NONE", _
        strParameter5Name:="NONE", strParameter5Value:="NONE", strParameter6Name:="NONE", strParameter6Value:="NONE", _
        strParameter7Name:="NONE", strParameter7Value:="NONE", strParameter8Name:="NONE", strParameter8Value:="NONE", _
        strParameter9Name:="NONE", strParameter9Value:="NONE", strParameter10Name:="NONE", strParameter10Value:="NONE", _
        strParameter11Name:="NONE", strParameter11Value:="NONE", strParameter12Name:="NONE", strParameter12Value:="NONE")
    End Sub


    Private Sub subCheckTotalsAndUpdate()


        If cbxSubmit.Checked = False Then
            Dim intResult As Integer
            intResult = MsgBox("Do you want to submit this for approval?", MessageBoxButtons.YesNo)
            If intResult = DialogResult.Yes Then
                cbxSubmit.Checked = True
            End If
        End If

        If strSaveActivityDate <> Me.dtpActivityDate.Text Then
            Dim intExists As Integer
            intExists = Me.subCheckCashierExists()
            If intExists <> 0 Then
                ' ErrProvCash.SetError(Me.cboCashier, "A Record for " & Me.cboCashier.Text & " on " & Me.dtpActivityDate.Value.ToShortDateString & " already exists")
                ErrProvCash.SetError(Me.dtpActivityDate, "A Record for " & Me.cboCashier.Text & " on " & Me.dtpActivityDate.Value.ToShortDateString & " already exists, " & "The original Date was " & strSaveActivityDate)
                Exit Sub
            Else
                ErrProvCash.SetError(Me.cboCashier, "")
                ErrProvCash.SetError(Me.dtpActivityDate, "")
            End If
        End If

        If Me.txtCashOnHandTot.Text = "$0.00" Or Me.txtPmtCatTot.Text = "$0.00" Or Me.txtPmtMethTot.Text = "$0.00" Then
            strSubmitError = " You need to enter transactions and the amounts need to match"
            'If Me.cbxSubmit.Checked = True Then
            ErrProvCash.SetError(Me.btnAddCashOnHand, strSubmitError)
            ErrProvCash.SetError(Me.btnAddPmtCat, strSubmitError)
            ErrProvCash.SetError(Me.btnAddPmtMeth, strSubmitError)
            Exit Sub
            'End If
        End If

        strSubmitError = ""
        Dim dblCOHTot As Double = Format(Me.txtCashOnHandTot.Text)
        Dim dblPmtCatTot As Double = Format(Me.txtPmtCatTot.Text)
        Dim dblPmtMethTot As Double = Format(Me.txtPmtMethTot.Text)

        If (dblCOHTot <> dblPmtCatTot) Or (dblCOHTot <> dblPmtMethTot) Then
            strSubmitError = "Net Amount Counted Total, Deposited to bank Total and Payment Method must be equal to Submit"
            If Me.cbxSubmit.Checked = False Then
                MsgBox(strSubmitError, MsgBoxStyle.Exclamation, "Warning")
                strSubmitError = ""
            Else
                ErrProvCash.SetError(Me.btnAddCashOnHand, strSubmitError)
                ErrProvCash.SetError(Me.btnAddPmtCat, strSubmitError)
                ErrProvCash.SetError(Me.btnAddPmtMeth, strSubmitError)
                intErrCnt += 1
            End If
        End If

        If Me.cbxSubmit.Checked = True And intOverShortFlag = 1 Then
            Dim intNoteCnt As Integer = 0
            objNoteAction = New clsNote
            intNoteCnt = objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=Me.intCashierRecPtr)
            If intNoteCnt = 0 Then
                MsgBox("You must Enter a Note if you are Over or Short ", MsgBoxStyle.Exclamation, "Error")
                intErrCnt += 1
            End If
        End If

        If frmMainMenu.txtAction.Text = "APPROVE" And intSACountFlag = 1 Then
            MsgBox("You must Enter a SA Payment Count ", MsgBoxStyle.Exclamation, "Error")
            intErrCnt += 1
        End If

        ' Is Deposit slip Valid
        Me.ValidDepSlipCheck()

        'Me.ValidBagNbrCheck()

        ' no errors - update - or no submit Save
        If intErrCnt > 0 Then
            Exit Sub
        End If

        Select Case frmMainMenu.txtModule.Text
            Case "CASHIER-CREATE"
                objCashierData = New clsCashier
                Call objCashierData.subCashierAction(strAction:="UPDATE", _
                    intCashierTranID:=Me.intCashierRecPtr, dtTranDate:=Me.dtpActivityDate.Value, strDepositSlip:=Me.txtDepositSlip.Text, _
                    strBagNumber:=Me.txtBagNbr.Text, strCashierUserName:=Me.cboCashier.Text, strCreateUser:="NONE", _
                    dtCreateDate:="01/01/1900", strApproveUser:="NONE", dtApproveDate:="01/01/1900", _
                    strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSubmittedFlag:=Me.cbxSubmit.CheckState)

                If Me.cbxSubmit.CheckState = CheckState.Checked Then
                    Dim response As MsgBoxResult
                    response = MsgBox("Do you want to print the Daily Payment Reconciliation Sheet ?", MsgBoxStyle.YesNo, "Printing Option")
                    If response = MsgBoxResult.Yes Then   ' User chose Yes.
                        subPrintPmtReconReport()
                    End If
                End If

            Case "CASHIER-SUBMIT"
                objCashierData = New clsCashier
                Call objCashierData.subCashierAction(strAction:="UPDATE", _
                    intCashierTranID:=intCashierRecPtr, dtTranDate:=Me.dtpActivityDate.Value, strDepositSlip:=Me.txtDepositSlip.Text, _
                    strBagNumber:=Me.txtBagNbr.Text, strCashierUserName:=Me.cboCashier.Text, strCreateUser:="NONE", _
                    dtCreateDate:="01/01/1900", strApproveUser:="NONE", dtApproveDate:="01/01/1900", _
                    strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSubmittedFlag:=Me.cbxSubmit.CheckState)

                Dim response As MsgBoxResult
                response = MsgBox("Do you want to print the Daily Payment Reconciliation Sheet ?", MsgBoxStyle.YesNo, "Printing Option")
                If response = MsgBoxResult.Yes Then   ' User chose Yes.
                    subPrintPmtReconReport()
                End If

            Case "CASHIER-APPROVE"
                objCashierData = New clsCashier
                Call objCashierData.subCashierAction(strAction:="UPDATE-TO-APPROVED", _
                    intCashierTranID:=intCashierRecPtr, dtTranDate:=Me.dtpActivityDate.Value, strDepositSlip:=Me.txtDepositSlip.Text, _
                    strBagNumber:=Me.txtBagNbr.Text, strCashierUserName:=Me.cboCashier.Text, strCreateUser:="NONE", _
                    dtCreateDate:="01/01/1900", strApproveUser:=SystemInformation.UserName, dtApproveDate:=System.DateTime.Now, _
                    strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSubmittedFlag:=Me.cbxSubmit.CheckState)
        End Select
        Me.Close()
    End Sub

    Private Sub cbxSubmit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxSubmit.CheckedChanged

        If Me.cbxSubmit.Checked = True Then
            Me.btnGO.Text = "Submit for Approval"
        Else
            Me.btnGO.Text = "Save"
        End If

    End Sub

    Private Sub tsWizard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsWizard.Click

        intCashierDetRecPtr = 0 ' this disables delete button
        frmCashierDetail.cboType.Enabled = False
        Me.btnAddCashOnHand.Enabled = True
        Me.btnAddPmtCat.Enabled = True
        Me.btnAddPmtMeth.Enabled = True

        frmCashierDetail.cboType.Text = "Manual (Check)"

        If frmCashierDetail.cboType.Text = "Manual (Check)" And frmMainMenu.txtModule.Text = "CASHIER-CREATE" Then
            bitAddFlag = True
            frmCashierCheckWizard.ShowDialog()
            subRefreshPmtMethGrid()
        Else

            frmCashierDetail.txtAmount.Text = "" 'String.Format("{0:N}", 0)
            frmCashierDetail.txtCount.Text = ""
            frmCashierDetail.Text = "Manual (Check)"
            bitAddFlag = True
            frmCashierDetail.ShowDialog()
            subRefreshPmtMethGrid()
        End If

        frmCashierDetail.cboType.Text = "POP"
        frmCashierDetail.txtAmount.Text = "" 'String.Format("{0:N}", 0)
        frmCashierDetail.txtCount.Text = ""
        frmCashierDetail.Text = "POP"
        bitAddFlag = True
        frmCashierDetail.ShowDialog()
        subRefreshPmtMethGrid()


        frmCashierDetail.cboType.Text = "CashLink"
        frmCashierDetail.txtAmount.Text = "" 'String.Format("{0:N}", 0)
        frmCashierDetail.txtCount.Text = ""
        frmCashierDetail.Text = "CashLink"
        bitAddFlag = True
        frmCashierDetail.ShowDialog()
        subRefreshPmtMethGrid()


        frmCashierDetail.cboType.Text = "Change Fund"
        frmCashierDetail.txtAmount.Text = "" 'String.Format("{0:N}", 0)
        frmCashierDetail.txtCount.Text = ""
        frmCashierDetail.Text = "Change Fund"
        bitAddFlag = True
        frmCashierDetail.ShowDialog()
        subRefreshCashOnHandGrid()

        frmCashierDetail.cboType.Text = "Tot Amt on Hand"

        If frmCashierDetail.cboType.Text = "Tot Amt on Hand" And frmMainMenu.txtModule.Text = "CASHIER-CREATE" Then
            bitAddFlag = True
            frmCashierCashWizard.ShowDialog()
            subRefreshCashOnHandGrid()
        Else
            frmCashierDetail.cboType.Text = "Tot Amt on Hand"
            frmCashierDetail.txtAmount.Text = "" 'String.Format("{0:N}", 0)
            frmCashierDetail.txtCount.Text = ""
            frmCashierDetail.Text = "Tot Amt on Hand"
            bitAddFlag = True
            frmCashierDetail.ShowDialog()
            subRefreshCashOnHandGrid()
        End If

        frmCashierDetail.cboType.Text = "Cash"
        frmCashierDetail.txtAmount.Text = String.Format("{0:N}", dblPassCashAmt)
        frmCashierDetail.txtCount.Text = ""
        frmCashierDetail.Text = "Cash"
        bitAddFlag = True
        frmCashierDetail.ShowDialog()
        subRefreshPmtMethGrid()


        frmCashierDetail.cboType.Text = "SA Payment"
        frmCashierDetail.txtAmount.Text = "" 'String.Format("{0:N}", 0)
        frmCashierDetail.txtCount.Text = ""
        frmCashierDetail.Text = "SA Payment"
        bitAddFlag = True
        frmCashierDetail.ShowDialog()
        subRefreshPmtCatGrid()

        frmCashierDetail.cboType.Text = "CT"

        If frmCashierDetail.cboType.Text = "CT" And frmMainMenu.txtModule.Text = "CASHIER-CREATE" Then
            bitAddFlag = True
            frmCashierCTWizard.ShowDialog()
            subRefreshPmtCatGrid()
        Else
            frmCashierDetail.txtAmount.Text = "" 'String.Format("{0:N}", 0)
            frmCashierDetail.txtCount.Text = ""
            frmCashierDetail.Text = "CT"
            bitAddFlag = True
            frmCashierDetail.ShowDialog()
            subRefreshPmtCatGrid()
        End If

        Me.tsWizard.Enabled = False
        frmCashierDetail.cboType.Enabled = True

    End Sub

   
End Class
