Imports System.Text.RegularExpressions
Imports Microsoft.Reporting.WinForms

Public Class frmCashierBalancing
    Public WithEvents objCashierData As clsCashier
    Public WithEvents objCashierDetData As clsCashierDetail
    Public WithEvents objSecurityCheck As clsSystem
    Public WithEvents objUserData As clsSystem
    Public WithEvents objUserAction As clsSystem
    Public WithEvents objNoteAction As clsNote
    Public WithEvents objNoteData As clsNote
    Public WithEvents objReportAction As clsReport

    Dim strOrigCash As String
    Dim strPmtOrigVal(11) As String           ' original value when form is loaded - values changed to zero will be deleted
    Dim strPmtDescr(11) As String           ' original value when form is loaded - values changed to zero will be deleted
    Dim intPmtDetRecs(11) As Integer    ' detail record pointers for updating records
    Dim intOverShortFlag As Integer           ' indicates whether over short record has been entered Used to indicate a Note is required
    Dim intSACountFlag As Integer             ' indicates whether there is a SA Payment Record and Count is zero
    Public grdPmtsCatDataTable As DataTable
    Dim strSaveActivityDate As String             ' save activity date for info if they change it to a record that already exists
    Dim strSubmitError As String
    Dim intErrCnt As Integer                           ' indicates the number of validation errors on the form 
    Public intCashierRecPtr As Integer = 0     ' Record# pointer to Cashier record - if it = 0 then is a new record or user has changed cashier or date
    '  Public intCashierDetRecPtr As Integer = 0  ' Record of Cashier Detail record from Grid being modified or deleted
    Public intRetCashierRecNbr As Integer = 0  ' Returned (Record number or count) from procCashier on CHECK-EXISTS or Record number of added record ADD
    Friend dblChange(6) As Double
    Friend dblBill(6) As Double
    Friend dsCT As New DataSet("DataSetTemp")        'dataset for CT Wizard
    Friend dtCT As New DataTable("DataTable")        'table for CT Wizard
    Friend dsChk As New DataSet("DataSetChk")        'dataset for Check Wizard
    Friend dtChk As New DataTable("DataTableChk")        'table for Check Wizard
    Friend dsCA As New DataSet("DataSetTemp")        'dataset for Cash Wizard
    Friend dtCA As New DataTable("DataTable")        'table for Cash Wizard


    Private Sub frmCashierBalancing_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        subRefreshGrids()
        ' set values coming in - test against changes when saved
        strPmtOrigVal(1) = Me.txtSAPmtCnt.Text : strPmtDescr(1) = "SA Payment Count"  ' descc not used - count value is part of payment record 
        strPmtOrigVal(2) = Me.txtSAPmtAmt.Text : strPmtDescr(2) = "SA Payment"
        strPmtOrigVal(3) = Me.txtCTCnt.Text : strPmtDescr(3) = "CT Count"   ' descc not used - count value is part of payment record 
        strPmtOrigVal(4) = Me.txtCTAmt.Text : strPmtDescr(4) = "CT"
        strPmtOrigVal(5) = Me.txtOverShortAmt.Text : strPmtDescr(5) = "over-short"
        strPmtOrigVal(6) = Me.txtPoPVirtualMerchCnt.Text : strPmtDescr(6) = "POP Count" ' descc not used - count value is part of payment record 
        strPmtOrigVal(7) = Me.txtPoPVirtualMerch.Text : strPmtDescr(7) = "POP"
        strPmtOrigVal(8) = Me.txtlCashLink.Text : strPmtDescr(8) = "CashLink"
        strPmtOrigVal(9) = Me.txtManualCheckCnt.Text : strPmtDescr(9) = "Manual (Check)Count"   ' descc not used - count value is part of payment record 
        strPmtOrigVal(10) = Me.txtManualCheck.Text : strPmtDescr(10) = "Manual (Check)"
        strPmtOrigVal(11) = Me.txtCash.Text : strPmtDescr(11) = "Cash"

    End Sub
    'Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        GetNextControl(DirectCast(sender, TextBox), True)
    '    End If
    'End Sub



    Private Sub frmCashierBalancing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'objNoteAction = New clsNote
        'Me.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=intCashierRecPtr) & " Total)"

        frmMainMenu.strCallingForm = "Cashier Balancing"
        ' done in wizard form
        'Array.Clear(frmMainMenu.dblBill, 0, frmMainMenu.dblBill.Length)
        'Array.Clear(frmMainMenu.dblChange, 0, frmMainMenu.dblChange.Length)

        Select Case frmMainMenu.txtModule.Text
            Case "BALANCING-CREATE", "CASHIER-CREATE", "CASHIER-BAL-SEARCH-ALL", "CASHIER-SEARCH-BY-DATE", "CASHIER-SEARCH-BY-CASHIER", "CASHIER-SEARCH-BY-AMT", "CASHIER-BAL-SEARCH-BY-NOTES"
                subSetSecurityLevel()
        End Select

        Select Case frmMainMenu.txtModule.Text
            Case "BALANCING-CREATE" ', "CASHIER-SEARCH-ALL", "CASHIER-SEARCH-BY-DATE", "CASHIER-SEARCH-BY-CASHIER", "CASHIER-SEARCH-BY-AMT"
                'Format screen
                Me.Text = "Create New Cashier Record"
                Me.tsbtnEdit.Visible = False
                Me.tsbtnDel.Visible = False
                Me.tsbtnReport.Enabled = False
                Me.btnExit.Text = "CANCEL"
                Me.btnExit.Text = "Cancel"

                Me.cboCashier.Enabled = True
                Me.txtlCashLink.Enabled = True
                Me.txtManualCheck.Enabled = True
                Me.txtManualCheckCnt.Enabled = True
                Me.txtOverShortAmt.Enabled = True
                Me.txtPoPVirtualMerch.Enabled = True
                Me.txtPoPVirtualMerchCnt.Enabled = True
                Me.txtSAPmtAmt.Enabled = True
                Me.txtSAPmtCnt.Enabled = True
                ' Me.txtPmtCatTot.Enabled = True
                'Me.txtPmtMethTot.Enabled = True
                Me.txtCTAmt.Enabled = True
                Me.txtCTCnt.Enabled = True
                Me.txtCash.Enabled = True

                ' Fill cashier combo box
                objUserData = New clsSystem
                Call objUserData.subUserSelect(strBindTarget:="frmCashierBalancing-cb", strAction:="SELECT-CASHIER-ALL", _
                intUserID:=0, intPersonID:=0, strUserName:=SystemInformation.UserName, strPassword:="NONE", dtPasswordDate:="01/01/1900", _
                strStatus:="A", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
                ' initialize fields
                Me.cboCashier.Text = SystemInformation.UserName
                Me.txtCreatedBy.Text = SystemInformation.UserName
                Me.txtCreatedOn.Text = Format(System.DateTime.Now, "short date")
                ' Get cashier Deposit Slip
                subAddCashierRecord()  '  Add record here !!!!!!!
                'subGetCashierDepSlip()
                Me.txtDepositSlip.Text = fnGetCashierDepSlip()
                If Me.txtDepositSlip.Text = "9999" Then
                    Me.txtDepositSlip.Text = ""
                    Me.cboCashier.Text = ""
                Else
                    Me.cboCashier.Enabled = False
                End If

                ' Me.CtrlNoteDisplay1.Tag = "frmCashierActivity Cashier " & intCashierRecPtr
                'objNoteAction = New clsNote
                'Me.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=intCashierRecPtr) & " Total)"
                'Me.txtCTAmt.ReadOnly = True
            Case "CASHIER-BAL-SUBMIT"
                '  subEnableFormControls()
                subRefreshGrids()
                '  Me.CtrlNoteDisplay1.Tag = "frmCashierActivity Cashier " & intCashierRecPtr
                '   objNoteAction = New clsNote
                '   Me.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=intCashierRecPtr) & " Total)"
            Case "CASHIER-BAL-APPROVE"
                subRefreshGrids()
                '   Me.CtrlNoteDisplay1.Tag = "frmCashierActivity Cashier " & intCashierRecPtr
                'objNoteAction = New clsNote
                'Me.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=intCashierRecPtr) & " Total)"
            Case "CASHIER-BAL-SEARCH-ALL", "CASHIER-BAL-SEARCH-BY-DATE", "CASHIER-BAL-SEARCH-BY-CASHIER", "CASHIER-BAL-SEARCH-BY-AMT", "CASHIER-BAL-SEARCH-BY-NOTES"
                Me.ErrProvCash.Clear()
                Me.tsbtnDel.Enabled = False
                Me.cboCashier.Enabled = False
                Me.dtpActivityDate.Enabled = False
                Me.txtBagNbr.Enabled = False
                Me.txtDepositSlip.Enabled = False
                Me.cbxSubmit.Enabled = False
                Me.btnGO.Enabled = False

                Me.txtlCashLink.Enabled = False
                Me.txtManualCheck.Enabled = False
                Me.txtManualCheckCnt.Enabled = False
                Me.txtOverShortAmt.Enabled = False
                Me.txtPoPVirtualMerch.Enabled = False
                Me.txtPoPVirtualMerchCnt.Enabled = False
                Me.txtSAPmtAmt.Enabled = False
                Me.txtSAPmtCnt.Enabled = False
                Me.txtPmtCatTot.Enabled = False
                Me.txtPmtMethTot.Enabled = False
                Me.txtCTAmt.Enabled = False
                Me.txtCTCnt.Enabled = False
                Me.txtCash.Enabled = False



                ' Me.txtCreatedOn.Text.Substring(1, 8)
                'Me.CtrlNoteDisplay1.Tag = "frmCashierActivity Cashier " & intCashierRecPtr

            Case Else
                MsgBox("Load Event Error: (" & frmMainMenu.txtModule.Text & ")")
        End Select



        strSaveActivityDate = dtpActivityDate.Text
        subDisplayNotes()

        'Select Case frmMainMenu.txtModule.Text
        '    Case "BALANCING-CREATE" ', "CASHIER-SEARCH-ALL", "CASHIER-SEARCH-BY-DATE", "CASHIER-SEARCH-BY-CASHIER", "CASHIER-SEARCH-BY-AMT"
        '        MsgBox("YOU MADE IT") ' subSetSecurityLevel()
        'End Select

    End Sub

    Private Sub subDisplayNotes()
        '     Me.CtrlNoteDisplay1.Tag = "frmCashierActivity Cashier " & intCashierRecPtr
        objNoteAction = New clsNote
        Me.TabPage3.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=intCashierRecPtr) & " Total)"

        objNoteData = New clsNote
        Call objNoteData.subNoteSelect(strBindTarget:="frmCashierBalancing-Sel-Notes", strAction:="SELECT-BY-MODULEID", intNoteID:=0, strNoteType:="NONE", strModule:="Cashier", intModuleID:=intCashierRecPtr, strNoteDesc:="NONE", strCreateUser:="NONE", dtCreateDate:="01/01/1900")

    End Sub


    Private Sub subSetSecurityLevel()

        If frmMainMenu.txtModule.Text = "BALANCING-CREATE" Then
            Exit Sub
        End If

        Dim strT As String = frmMainMenu.txtModule.Text
        frmMainMenu.txtModule.Text = "CASHIER-BAL-SEARCH-ALL"  ' set to lowest level

        ' these selects should be in the order of highest level checked first
        Dim strPassFail As String
        objSecurityCheck = New clsSystem
        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="CASHIER-ROLE-CHECK", strRole:="Approve")
        If strPassFail = "PASS" Then
            frmMainMenu.txtModule.Text = "CASHIER-BAL-APPROVE"
            Exit Sub
        End If

        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="CASHIER-ROLE-CHECK", strRole:="Create")
        If strPassFail = "PASS" And Me.txtApprovedBy.Text = "" And Me.txtCreatedBy.Text = SystemInformation.UserName Then
            If Me.txtCreatedBy.Text = SystemInformation.UserName Then
                frmMainMenu.txtModule.Text = "CASHIER-BAL-SUBMIT"
                Exit Sub
            End If

        End If

    End Sub

    Private Sub subRefreshGrids()

        '   subRefreshCashOnHandGrid()
        subRefreshPmtCatGrid()
        ' subRefreshPmtMethGrid()

    End Sub
    Private Sub subRefreshPmtCatGrid()
        Dim strTest As String
        objCashierDetData = New clsCashierDetail
        Call objCashierDetData.subCashierDetSelect(strBindTarget:="frmCashierBal-Det-All", strAction:="SELECT-DETAIL-ALL", _
        intCashierDetailID:=intCashierRecPtr, intCashierTranID:=intCashierRecPtr, strType:="NONE", intTranCount:=0, mnyAmount:=0, _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")

        Dim dblPmtCatTot As Double = 0
        Dim dblPmtTot As Double = 0
        Dim dblDeposit As Double
        Dim intRowIdx As Integer = 0
        intOverShortFlag = 0
        intSACountFlag = 0
        intPmtDetRecs = New Integer() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        For intRowIdx = 0 To grdPmtsCatDataTable.Rows.Count - 1
            'dblPmtCatTot = dblPmtCatTot + grdPmtsCatDataTable.Rows(intRowIdx).Item(4)
            'If Me.grdPmtsCatDataTable.Rows(intRowIdx).Item(3).Value = 0 Then
            '    Me.grdPmtsCatDataTable.Rows(intRowIdx).Cells(3).Style.ForeColor = Color.White
            'Else
            '    Me.grdPmtsCatDataTable.Rows(intRowIdx).Cells(3).Style.ForeColor = Color.Black
            'End If

            strTest = grdPmtsCatDataTable.Rows(intRowIdx).Item(2).ToString.Trim

            Select Case strTest
                Case "SA Payment"
                    Me.txtSAPmtAmt.Text = String.Format("{0:N}", grdPmtsCatDataTable.Rows(intRowIdx).Item("TranAmount"))
                    Me.txtSAPmtCnt.Text = grdPmtsCatDataTable.Rows(intRowIdx).Item("TranCount").ToString
                    Me.intPmtDetRecs(2) = grdPmtsCatDataTable.Rows(intRowIdx).Item("CashierDetailID").ToString
                Case "CT"
                    Me.txtCTAmt.Text = String.Format("{0:N}", grdPmtsCatDataTable.Rows(intRowIdx).Item("TranAmount"))
                    Me.txtCTCnt.Text = grdPmtsCatDataTable.Rows(intRowIdx).Item("TranCount").ToString
                    Me.intPmtDetRecs(4) = grdPmtsCatDataTable.Rows(intRowIdx).Item("CashierDetailID").ToString
                Case "Over", "Short"
                    Me.txtOverShortAmt.Text = String.Format("{0:N}", grdPmtsCatDataTable.Rows(intRowIdx).Item("TranAmount"))
                    Me.intPmtDetRecs(5) = grdPmtsCatDataTable.Rows(intRowIdx).Item("CashierDetailID").ToString
                Case "POP"
                    Me.txtPoPVirtualMerch.Text = String.Format("{0:N}", grdPmtsCatDataTable.Rows(intRowIdx).Item("TranAmount"))
                    Me.txtPoPVirtualMerchCnt.Text = grdPmtsCatDataTable.Rows(intRowIdx).Item("TranCount").ToString
                    Me.intPmtDetRecs(7) = grdPmtsCatDataTable.Rows(intRowIdx).Item("CashierDetailID").ToString
                Case "CashLink"
                    Me.txtlCashLink.Text = String.Format("{0:N}", grdPmtsCatDataTable.Rows(intRowIdx).Item("TranAmount"))
                    Me.intPmtDetRecs(8) = grdPmtsCatDataTable.Rows(intRowIdx).Item("CashierDetailID").ToString
                Case "Manual (Check)"
                    Me.txtManualCheck.Text = String.Format("{0:N}", grdPmtsCatDataTable.Rows(intRowIdx).Item("TranAmount"))
                    '   Me.txtManualCheck.Text = grdPmtsCatDataTable.Rows(intRowIdx).Item("TranAmount").ToString
                    Me.txtManualCheckCnt.Text = grdPmtsCatDataTable.Rows(intRowIdx).Item("TranCount").ToString
                    Me.intPmtDetRecs(10) = grdPmtsCatDataTable.Rows(intRowIdx).Item("CashierDetailID").ToString
                Case "Cash"
                    Me.txtCash.Text = String.Format("{0:N}", grdPmtsCatDataTable.Rows(intRowIdx).Item("TranAmount"))
                    Me.intPmtDetRecs(11) = grdPmtsCatDataTable.Rows(intRowIdx).Item("CashierDetailID").ToString
            End Select

            If strTest = "Over" Or strTest = "Short" Then
                intOverShortFlag = 1
            End If
            'If strTest = "SA Payment" Then
            '    If grdPmtsCatDataTable.Rows(intRowIdx).Item(3).ToString = "0" Then
            '        intSACountFlag = 1
            '    End If
            'End If
        Next intRowIdx
        If Me.txtSAPmtAmt.Text = "" Then Me.txtSAPmtAmt.Text = "0.00"
        If Me.txtSAPmtCnt.Text = "" Then Me.txtSAPmtCnt.Text = "0"
        If Me.txtCTAmt.Text = "" Then Me.txtCTAmt.Text = "0.00"
        If Me.txtCTCnt.Text = "" Then Me.txtCTCnt.Text = "0"
        If Me.txtOverShortAmt.Text = "" Then Me.txtOverShortAmt.Text = "0.00"
        If Me.txtPoPVirtualMerch.Text = "" Then Me.txtPoPVirtualMerch.Text = "0.00"
        If Me.txtPoPVirtualMerchCnt.Text = "" Then Me.txtPoPVirtualMerchCnt.Text = "0"
        If Me.txtlCashLink.Text = "" Then Me.txtlCashLink.Text = "0.00"
        If Me.txtManualCheck.Text = "" Then Me.txtManualCheck.Text = "0.00"
        If Me.txtManualCheckCnt.Text = "" Then Me.txtManualCheckCnt.Text = "0"
        If Me.txtCash.Text = "" Then Me.txtCash.Text = "0.00"

        dblPmtCatTot = Double.Parse(Me.txtSAPmtAmt.Text) + Double.Parse(Me.txtCTAmt.Text) + Double.Parse(Me.txtOverShortAmt.Text)
        dblPmtTot = Double.Parse(Me.txtPoPVirtualMerch.Text) + Double.Parse(Me.txtlCashLink.Text) + Double.Parse(Me.txtManualCheck.Text) + Double.Parse(Me.txtCash.Text)
        dblDeposit = Double.Parse(Me.txtManualCheck.Text) + Double.Parse(Me.txtCash.Text)

        Me.txtPmtCatTot.Text = String.Format("{0:N}", dblPmtCatTot)
        Me.txtPmtMethTot.Text = String.Format("{0:N}", dblPmtTot)
        Me.txtCashInBag.Text = String.Format("{0:N}", dblDeposit)

    End Sub
    Sub subAddCashierRecord()

        objCashierData = New clsCashier
        Call objCashierData.subCashierAction(strAction:="ADD", _
            intCashierTranID:=0, dtTranDate:=Me.dtpActivityDate.Value, strDepositSlip:=Me.txtDepositSlip.Text, _
            strBagNumber:=Me.txtBagNbr.Text, strCashierUserName:=Me.cboCashier.Text, strCreateUser:=SystemInformation.UserName, _
            dtCreateDate:=System.DateTime.Now, strApproveUser:="NONE", dtApproveDate:="01/01/1900", _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSubmittedFlag:=0)
        intCashierRecPtr = intRetCashierRecNbr

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

    Friend Function fnGetCashierDepSlip() As String
        objUserAction = New clsSystem
        Call objUserAction.subUserAction(strAction:="SELECT-BAL-CASHIER-NUM", intUserID:=0, intPersonID:=0, _
                    strUserName:=Me.cboCashier.Text, strPassword:="NONE", dtPasswordDate:="01/01/1900", _
                    strStatus:="N", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        Return String.Format(intRetCashierRecNbr)
        'Me.txtDepositSlip.Text = String.Format(intRetCashierRecNbr)
    End Function

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Dim strT As String = frmMainMenu.txtModule.Text
        Select Case frmMainMenu.txtModule.Text
            Case "BALANCING-CREATE"
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

    Private Sub ValidCashierCheck()

        If Me.cboCashier.Text = "" Then
            ErrProvCash.SetError(Me.cboCashier, "Cashier Cannot be blank, Please select a Cashier")
            intErrCnt += 1
        Else
            ErrProvCash.SetError(Me.cboCashier, "")
        End If

    End Sub

    Private Sub btnGO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGO.Click

        'MsgBox(" Nothing was saved yet")
        'Me.Close()    '  Remove this 

        intErrCnt = 0
        ErrProvCash.SetError(Me.cboCashier, "")
        ErrProvCash.SetError(Me.dtpActivityDate, "")
        ErrProvCash.SetError(Me.txtDepositSlip, "")
        ErrProvCash.SetError(Me.txtBagNbr, "")
        ErrProvCash.SetError(Me.txtCash, "")
        ErrProvCash.SetError(Me.txtlCashLink, "")
        ErrProvCash.SetError(Me.txtManualCheck, "")
        ErrProvCash.SetError(Me.txtManualCheckCnt, "")
        ErrProvCash.SetError(Me.txtOverShortAmt, "")
        ErrProvCash.SetError(Me.txtPoPVirtualMerch, "")
        ErrProvCash.SetError(Me.txtPoPVirtualMerchCnt, "")
        ErrProvCash.SetError(Me.txtSAPmtAmt, "")
        ErrProvCash.SetError(Me.txtSAPmtCnt, "")
        ErrProvCash.SetError(Me.txtPmtCatTot, "")
        ErrProvCash.SetError(Me.txtPmtMethTot, "")
        ErrProvCash.SetError(Me.txtCTAmt, "")
        ErrProvCash.SetError(Me.txtCTCnt, "")
        ErrProvCash.SetError(Me.txtCash, "")
        Select Case frmMainMenu.txtModule.Text
            Case "BALANCING-CREATE"
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

                'subSubmitRecord()
                'Me.Close()

            Case "CASHIER-BAL-SUBMIT"
                subCheckTotalsAndUpdate()
            Case "CASHIER-BAL-APPROVE"
                subCheckTotalsAndUpdate()
            Case "CASHIER-VALIDATE"
                'subLoadCashier()
            Case "CASHIER-SEARCH-ALL"
                Exit Sub
            Case Else
                MsgBox("Load Event Error: (" & frmMainMenu.txtModule.Text & ")")
        End Select

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

    Private Sub cbxSubmit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxSubmit.CheckedChanged

        If Me.cbxSubmit.Checked = True Then
            Me.btnGO.Text = "Submit for Approval"
        Else
            Me.btnGO.Text = "Save"
        End If

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

        If Me.txtPmtCatTot.Text = "0.00" Or Me.txtPmtMethTot.Text = "0.00" Then
            strSubmitError = " You need to enter amounts and the Totals need to match"
            'If Me.cbxSubmit.Checked = True Then
            ErrProvCash.SetError(Me.txtPmtCatTot, strSubmitError)
            ErrProvCash.SetError(Me.txtPmtMethTot, strSubmitError)
            Exit Sub
            'End If
        End If

        strSubmitError = ""
        Dim dblPmtCatTot As Double = Format(Me.txtPmtCatTot.Text)
        Dim dblPmtMethTot As Double = Format(Me.txtPmtMethTot.Text)

        If (dblPmtMethTot <> dblPmtCatTot) Then
            strSubmitError = "M725 Total Receipts and Payment Total must be equal to Submit"
            If Me.cbxSubmit.Checked = False Then
                MsgBox(strSubmitError, MsgBoxStyle.Exclamation, "Warning")
                strSubmitError = ""
            Else
                ErrProvCash.SetError(Me.txtPmtCatTot, strSubmitError)
                ErrProvCash.SetError(Me.txtPmtMethTot, strSubmitError)
                intErrCnt += 1
            End If
        End If

        If Me.cbxSubmit.Checked = True And Me.txtOverShortAmt.Text <> "0.00" Then
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

        If (Me.txtCash.Text <> "0.00" Or Me.txtManualCheck.Text <> "0.00") Then
            Me.ValidBagNbrCheck()
        End If

        ' no errors - update - or no submit Save
        If intErrCnt > 0 Then
            Exit Sub
        End If

        Select Case frmMainMenu.txtModule.Text
            Case "BALANCING-CREATE"
                objCashierData = New clsCashier
                Call objCashierData.subCashierAction(strAction:="UPDATE", _
                    intCashierTranID:=Me.intCashierRecPtr, dtTranDate:=Me.dtpActivityDate.Value, strDepositSlip:=Me.txtDepositSlip.Text, _
                    strBagNumber:=Me.txtBagNbr.Text, strCashierUserName:=Me.cboCashier.Text, strCreateUser:="NONE", _
                    dtCreateDate:="01/01/1900", strApproveUser:="NONE", dtApproveDate:="01/01/1900", _
                    strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSubmittedFlag:=Me.cbxSubmit.CheckState)

                subUpdateDetailRecords()

            Case "CASHIER-BAL-SUBMIT"
                subUpdateDetailRecords()
                objCashierData = New clsCashier
                Call objCashierData.subCashierAction(strAction:="UPDATE", _
                    intCashierTranID:=intCashierRecPtr, dtTranDate:=Me.dtpActivityDate.Value, strDepositSlip:=Me.txtDepositSlip.Text, _
                    strBagNumber:=Me.txtBagNbr.Text, strCashierUserName:=Me.cboCashier.Text, strCreateUser:="NONE", _
                    dtCreateDate:="01/01/1900", strApproveUser:="NONE", dtApproveDate:="01/01/1900", _
                    strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSubmittedFlag:=Me.cbxSubmit.CheckState)

                'Dim response As MsgBoxResult
                'response = MsgBox("Do you want to print the Daily Payment Reconciliation Sheet ?", MsgBoxStyle.YesNo, "Printing Option")
                'If response = MsgBoxResult.Yes Then   ' User chose Yes.
                '    subPrintPmtReconReport()
                'End If

            Case "CASHIER-BAL-APPROVE"
                subUpdateDetailRecords()

                objCashierData = New clsCashier
                Call objCashierData.subCashierAction(strAction:="UPDATE-TO-APPROVED", _
                    intCashierTranID:=intCashierRecPtr, dtTranDate:=Me.dtpActivityDate.Value, strDepositSlip:=Me.txtDepositSlip.Text, _
                    strBagNumber:=Me.txtBagNbr.Text, strCashierUserName:=Me.cboCashier.Text, strCreateUser:="NONE", _
                    dtCreateDate:="01/01/1900", strApproveUser:=SystemInformation.UserName, dtApproveDate:=System.DateTime.Now, _
                    strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSubmittedFlag:=Me.cbxSubmit.CheckState)
        End Select
        Me.Close()
    End Sub

    Private Sub ValidBagNbrCheck()

        Dim strTest As String

        strSubmitError = ""
        Dim rexp_BagNbr As New Regex("(\d{8})")

        If rexp_BagNbr.IsMatch(Me.txtBagNbr.Text) And Len(Me.txtBagNbr.Text) = 8 Then
            ErrProvCash.SetError(Me.txtBagNbr, "")
        Else
            strSubmitError = "You must enter a valid 8 digit Deposit Bag number - ex. 12345678"
            If Me.cbxSubmit.Checked = False Then
                MsgBox(strSubmitError, MsgBoxStyle.Exclamation, "Warning")
                strSubmitError = ""
            Else
                ErrProvCash.SetError(Me.txtBagNbr, strSubmitError)
                intErrCnt += 1
            End If
        End If

    End Sub

    Private Sub subAllNewDetailRecords()
        If Double.Parse(Me.txtSAPmtAmt.Text) <> 0 Then
            fnUpdateDetailRecord(Single.Parse(Me.txtSAPmtCnt.Text), strPmtDescr(1), Double.Parse(Me.txtSAPmtAmt.Text), Me.intPmtDetRecs(1))
        End If
        If Double.Parse(Me.txtCTAmt.Text) <> 0 Then
            fnUpdateDetailRecord(Single.Parse(Me.txtCTCnt.Text), strPmtDescr(4), Double.Parse(Me.txtCTAmt.Text), Me.intPmtDetRecs(4))
        End If
    End Sub

    Private Sub subUpdateDetailRecords()
        If Me.txtSAPmtAmt.Text <> strPmtOrigVal(2) Or Me.txtSAPmtCnt.Text <> strPmtOrigVal(1) Then
            fnUpdateDetailRecord(Single.Parse(Me.txtSAPmtCnt.Text), Me.strPmtDescr(2), Double.Parse(Me.txtSAPmtAmt.Text), Me.intPmtDetRecs(2))
        End If
        If Me.txtCTAmt.Text <> strPmtOrigVal(4) Or Me.txtCTCnt.Text <> strPmtOrigVal(3) Then
            fnUpdateDetailRecord(Single.Parse(Me.txtCTCnt.Text), Me.strPmtDescr(4), Double.Parse(Me.txtCTAmt.Text), Me.intPmtDetRecs(4))
        End If
        If Me.txtOverShortAmt.Text <> strPmtOrigVal(5) Then
            If Double.Parse(Me.txtOverShortAmt.Text) > 0 Then
                fnUpdateDetailRecord(0, "Over", Double.Parse(Me.txtOverShortAmt.Text), Me.intPmtDetRecs(5))
            Else
                fnUpdateDetailRecord(0, "Short", Double.Parse(Me.txtOverShortAmt.Text), Me.intPmtDetRecs(5))
            End If
        End If
        If Me.txtPoPVirtualMerch.Text <> strPmtOrigVal(7) Or Me.txtPoPVirtualMerchCnt.Text <> strPmtOrigVal(6) Then
            fnUpdateDetailRecord(Single.Parse(Me.txtPoPVirtualMerchCnt.Text), Me.strPmtDescr(7), Double.Parse(Me.txtPoPVirtualMerch.Text), Me.intPmtDetRecs(7))
        End If
        If Me.txtlCashLink.Text <> strPmtOrigVal(8) Then
            fnUpdateDetailRecord(0, Me.strPmtDescr(8), Double.Parse(Me.txtlCashLink.Text), Me.intPmtDetRecs(8))
        End If
        If Me.txtManualCheck.Text <> strPmtOrigVal(10) Or Me.txtManualCheckCnt.Text <> strPmtOrigVal(9) Then
            fnUpdateDetailRecord(Single.Parse(Me.txtManualCheckCnt.Text), Me.strPmtDescr(10), Double.Parse(Me.txtManualCheck.Text), Me.intPmtDetRecs(10))
        End If
        If Me.txtCash.Text <> strPmtOrigVal(11) Then
            fnUpdateDetailRecord(0, Me.strPmtDescr(11), Double.Parse(Me.txtCash.Text), Me.intPmtDetRecs(11))
        End If
        ErrProvCash.SetError(Me.txtCash, "")
        ErrProvCash.SetError(Me.txtlCashLink, "")
        ErrProvCash.SetError(Me.txtManualCheck, "")
        ErrProvCash.SetError(Me.txtManualCheckCnt, "")
        ErrProvCash.SetError(Me.txtOverShortAmt, "")
        ErrProvCash.SetError(Me.txtPoPVirtualMerch, "")
        ErrProvCash.SetError(Me.txtPoPVirtualMerchCnt, "")
        ErrProvCash.SetError(Me.txtSAPmtAmt, "")
        ErrProvCash.SetError(Me.txtSAPmtCnt, "")
        ErrProvCash.SetError(Me.txtPmtCatTot, "")
        ErrProvCash.SetError(Me.txtPmtMethTot, "")
        ErrProvCash.SetError(Me.txtCTAmt, "")
        ErrProvCash.SetError(Me.txtCTCnt, "")
        ErrProvCash.SetError(Me.txtCash, "")
    End Sub
    Private Function fnUpdateDetailRecord(ByVal intCount As Integer, ByVal strPmtDescr As String, ByVal dblPmtAmt As Double, ByVal intCashierDetPtr As Integer) As Boolean

        If intCashierDetPtr = 0 Then
            objCashierDetData = New clsCashierDetail
            Call objCashierDetData.subCashierDetAction(strAction:="ADD", intCashierDetailID:=intCashierDetPtr, _
            intCashierTranID:=Me.intCashierRecPtr, strType:=strPmtDescr, intTranCount:=intCount, mnyAmount:=dblPmtAmt, _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")
        Else
            objCashierDetData = New clsCashierDetail
            Call objCashierDetData.subCashierDetAction(strAction:="UPDATE", intCashierDetailID:=intCashierDetPtr, _
            intCashierTranID:=Me.intCashierRecPtr, strType:=strPmtDescr, intTranCount:=intCount, mnyAmount:=dblPmtAmt, _
            strFASVerifyUser:="NONE", dtFASVerifyDate:="01/01/1900", strSDBVerifyUser:="NONE", dtSDBVerifyDate:="01/01/1900")
        End If

    End Function

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
    Private Sub subCalcTotal()

        'If intInit = 1 Then
        '    Exit Sub\  
        'End If

        Dim dblTotal As Double
        Dim dblPmts As Double
        Dim dblDeposit As Double
        dblTotal = Double.Parse(Me.txtSAPmtAmt.Text) + Double.Parse(Me.txtCTAmt.Text) + Double.Parse(Me.txtOverShortAmt.Text)
        Me.txtPmtCatTot.Text = String.Format("{0:N}", dblTotal)
        ' Me.txtTotalClone.Text = Me.txtTotal.Text

        'dblNet = dblTotal
        dblPmts = Double.Parse(Me.txtPoPVirtualMerch.Text) + Double.Parse(Me.txtlCashLink.Text) + Double.Parse(Me.txtManualCheck.Text) + Double.Parse(Me.txtCash.Text)
        Me.txtPmtMethTot.Text = String.Format("{0:N}", dblPmts)

        dblDeposit = Double.Parse(Me.txtManualCheck.Text) + Double.Parse(Me.txtCash.Text)
        Me.txtCashInBag.Text = String.Format("{0:N}", dblDeposit)

    End Sub

    Private Sub txtSAPmtAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSAPmtAmt.Leave
        If Len(Me.txtSAPmtAmt.Text) = 0 Then
            Me.txtSAPmtAmt.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtSAPmtAmt.Text) Then
            Me.txtSAPmtAmt.Text = String.Format("{0:N}", Double.Parse(Me.txtSAPmtAmt.Text))
            subCalcTotal()
            ' frmCashierActivity.dblChange(4) = Double.Parse(Me.txtSAPmtAmt.Text)
        Else
            Me.txtSAPmtAmt.Focus()
        End If
    End Sub

    Private Sub txtCTAmt_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTAmt.DoubleClick
        frmMainMenu.strCallingForm = "Cashier Balancing"
        frmCashierBalCTWizard.ShowDialog()

    End Sub

    Private Sub txtCTAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTAmt.Leave
        If Len(Me.txtCTAmt.Text) = 0 Then
            Me.txtCTAmt.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtCTAmt.Text) Then
            Me.txtCTAmt.Text = String.Format("{0:N}", Double.Parse(Me.txtCTAmt.Text))
            subCalcTotal()
            '  frmCashierActivity.dblChange(4) = Double.Parse(Me.txtCTAmt.Text)
        Else
            Me.txtCTAmt.Focus()
        End If
    End Sub

    Private Sub txtOverShortAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOverShortAmt.Leave
        If Len(Me.txtOverShortAmt.Text) = 0 Then
            Me.txtOverShortAmt.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtOverShortAmt.Text) Then
            Me.txtOverShortAmt.Text = String.Format("{0:N}", Double.Parse(Me.txtOverShortAmt.Text))
            subCalcTotal()
            '  frmCashierActivity.dblChange(4) = Double.Parse(Me.txtOverShortAmt.Text)
        Else
            Me.txtOverShortAmt.Focus()
        End If
    End Sub

    Private Sub txtPoPVirtualMerch_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPoPVirtualMerch.Leave
        If Len(Me.txtPoPVirtualMerch.Text) = 0 Then
            Me.txtPoPVirtualMerch.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtPoPVirtualMerch.Text) Then
            Me.txtPoPVirtualMerch.Text = String.Format("{0:N}", Double.Parse(Me.txtPoPVirtualMerch.Text))
            subCalcTotal()
            ' frmCashierActivity.dblChange(4) = Double.Parse(Me.txtPoPVirtualMerch.Text)
        Else
            Me.txtPoPVirtualMerch.Focus()
        End If
    End Sub

    Private Sub txtlCashLink_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlCashLink.Leave
        If Len(Me.txtlCashLink.Text) = 0 Then
            Me.txtlCashLink.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtlCashLink.Text) Then
            Me.txtlCashLink.Text = String.Format("{0:N}", Double.Parse(Me.txtlCashLink.Text))
            subCalcTotal()
            ' frmCashierActivity.dblChange(4) = Double.Parse(Me.txtPoPVirtualMerch.Text)
        Else
            Me.txtlCashLink.Focus()
        End If
    End Sub

    Private Sub txtManualCheck_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtManualCheck.DoubleClick
        frmMainMenu.strCallingForm = "Cashier Balancing"
        frmCashierBalCheckWizard.ShowDialog()

    End Sub



    Private Sub txtManualCheck_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtManualCheck.Leave
        If Len(Me.txtManualCheck.Text) = 0 Then
            Me.txtManualCheck.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtManualCheck.Text) Then
            Me.txtManualCheck.Text = String.Format("{0:N}", Double.Parse(Me.txtManualCheck.Text))
            subCalcTotal()
            ' frmCashierActivity.dblChange(4) = Double.Parse(Me.txtPoPVirtualMerch.Text)
        Else
            Me.txtManualCheck.Focus()
        End If
    End Sub

    Private Sub txtCash_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCash.DoubleClick
        '  frmMainMenu.strCallingForm = "Cashier Balancing"
        frmCashierBalCashWizard.ShowDialog()
    End Sub

    Private Sub txtCash_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCash.Leave
        If Len(Me.txtCash.Text) = 0 Then
            Me.txtCash.Text = "0"
        End If
        If fnCheckIfNumber(Me.txtCash.Text) Then
            Me.txtCash.Text = String.Format("{0:N}", Double.Parse(Me.txtCash.Text))
            subCalcTotal()
            ' frmCashierActivity.dblChange(4) = Double.Parse(Me.txtPoPVirtualMerch.Text)
        Else
            Me.txtCash.Focus()
        End If
    End Sub



    Private Sub tsbtnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbtnDel.Click
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




    Private Sub btnAddNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNote.Click
        objNoteAction = New clsNote
        Call objNoteAction.subNoteAction(strAction:="ADD-NOTE", intNoteID:=0, strNoteType:="Note", strModule:="Cashier", intModuleID:=intCashierRecPtr, strNoteDesc:=InputBox("Please enter note:", "Add Note"), strCreateUser:=SystemInformation.UserName, dtCreateDate:=Format(System.DateTime.Now, "short date"))
        Me.TabPage3.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:="Cashier", intModuleID:=intCashierRecPtr) & " Total)"
        subDisplayNotes()
    End Sub

    Private Sub tsRptSummary_Click(sender As Object, e As EventArgs) Handles tsRptSummary.Click
        Dim rv As New ReportViewer
        rv.ShowDialog("/SFS/Cashier/Deposit Slip Cash and Check Summary")
        Dim p As New ReportParameter("depositSlip", txtDepositSlip.Text)
        rv._params = p
        rv.Show()
    End Sub
End Class