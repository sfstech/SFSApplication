Imports Microsoft.Office.Interop

Public Class clsMenu

    Public Sub MenuHideAll()
        'Hide all menus on frmModuleMenu
        frmMainMenu.mnuEMP.Visible = False
        frmMainMenu.mnuIR.Visible = False
        frmMainMenu.mnuIRCC.Visible = False
        frmMainMenu.mnuELM.Visible = False
        frmMainMenu.mnuSYS.Visible = False
        frmMainMenu.mnuBANK.Visible = False
        frmMainMenu.mnuMERC.Visible = False
        frmMainMenu.mnuMISC.Visible = False
        frmMainMenu.mnuSTAFF.Visible = False
        frmMainMenu.mnuARC.Visible = False
        frmMainMenu.mnuESIG.Visible = False
        frmMainMenu.mnuWEBCC.Visible = False
        frmMainMenu.mnuPROC.Visible = False
        frmMainMenu.mnuRecon.Visible = False
        frmMainMenu.mnuJV.Visible = False
        frmMainMenu.mnuSchol.Visible = False
        frmMainMenu.mnuCashier.Visible = False
        frmMainMenu.mnuVENDX.Visible = False
        frmMainMenu.mnuGET.Visible = False
        frmMainMenu.mnuScholarship.Visible = False
        frmMainMenu.mnuDirdep.Visible = False
        frmMainMenu.mnuReports.Visible = False
        frmMainMenu.mnuSDBAdmin.Visible = False
        frmMainMenu.mnuIRS.Visible = False
        frmMainMenu.mnuOveraward.Visible = False
    End Sub

    'Show individual menu...
    Sub MenuShow(ByVal strModule As String)
        MenuHideAll()
        'Open selected menu...
        frmMainMenu.sspModuleLabel.Text = "Current Database: " & strModule
        Select Case strModule
            Case "Employee"
                frmMainMenu.mnuEMP.Visible = True
            Case "IR Deposit"
                frmMainMenu.mnuIR.Visible = True
            Case "IR Credit Card"
                frmMainMenu.mnuIRCC.Visible = True
            Case "ELM"
                frmMainMenu.mnuELM.Visible = True
            Case "System Admin"
                frmMainMenu.mnuSYS.Visible = True
            Case "Bank Data"
                frmMainMenu.mnuBANK.Visible = True
            Case "Merchant"
                frmMainMenu.mnuMERC.Visible = True
            Case "Staff"
                frmMainMenu.mnuSTAFF.Visible = True
            Case "Misc Payments"
                frmMainMenu.mnuMISC.Visible = True
            Case "ARC"
                frmMainMenu.mnuARC.Visible = True
            Case "E-Signatures"
                frmMainMenu.mnuESIG.Visible = True
            Case "Web Credit Card"
                frmMainMenu.mnuWEBCC.Visible = True
            Case "Procedures"
                frmMainMenu.mnuPROC.Visible = True
            Case "Reconciliation"
                frmMainMenu.mnuRecon.Visible = True
            Case "Journal Voucher"
                frmMainMenu.mnuJV.Visible = True
            Case "Scholarship Lookup"
                frmMainMenu.mnuSchol.Visible = True
            Case "Cashier"
                frmMainMenu.mnuCashier.Visible = True
            Case "Vendor Express"
                frmMainMenu.mnuVENDX.Visible = True
                'Case "GET"
                '    frmMainMenu.mnuGET.Visible = True
            Case "VA33 - Scholarship"
                frmMainMenu.mnuScholarship.Visible = True
            Case "Direct Deposit"
                frmMainMenu.mnuDirdep.Visible = True
            Case "Reports"
                frmMainMenu.mnuReports.Visible = True
            Case "SDB Admin"
                frmMainMenu.mnuSDBAdmin.Visible = True
            Case "Invoice Receivables"
                frmMainMenu.mnuIRS.Visible = True
            Case "Overawards"
                frmMainMenu.mnuOveraward.Visible = True
            Case Else
                MsgBox("Undefined strModule.  Please notify technical support.", MsgBoxStyle.Critical, "Menu Error")
                Application.Exit()
        End Select
    End Sub
    Sub subAddProcedure(ByVal strModule As String)

        Dim objSecurityCheck As clsSystem
        Dim strPassFail As String

        objSecurityCheck = New clsSystem

        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="PROC-ROLE-CHECK", strRole:=strModule)
        If strPassFail = "PASS" Then

            frmMainMenu.txtModule.Text = "PROC-ADD"
            frmMainMenu.txtAction.Text = strModule
            frmMainMenu.Text = strModule
            frmProcedure.MdiParent = frmMainMenu
            frmProcedure.Show()
            frmProcedure.Text = "Add Procedure"
        Else
            MsgBox("You are not authorized access this section of the system.  Please contact your system administrator for assistance.", vbCritical, "Access Denied")
        End If
    End Sub
    Sub subEditProcedure(ByVal strModule As String)

        Dim objSecurityCheck As clsSystem
        Dim strPassFail As String
        objSecurityCheck = New clsSystem

        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="PROC-ROLE-CHECK", strRole:=strModule)
        If strPassFail = "PASS" Then
            frmMainMenu.txtModule.Text = "PROC-SEARCH"
            frmMainMenu.txtAction.Text = strModule

            SearchMenu.MdiParent = frmMainMenu
            SearchMenu.Show()

            'Setup form title...
            SearchMenu.Text = strModule & " Procedure List"

            SearchMenu.grdDataList.EditMode = DataGridViewEditMode.EditProgrammatically
        Else
            MsgBox("You are not authorized access this section of the system.  Please contact your system administrator for assistance.", vbCritical, "Access Denied")
        End If
    End Sub
    Sub subReviewProcedure(ByVal strModule As String)

        Dim objSecurityCheck As clsSystem
        Dim strPassFail As String
        objSecurityCheck = New clsSystem

        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="PROC-ROLE-CHECK", strRole:=strModule)
        If strPassFail = "PASS" Then
            frmMainMenu.txtModule.Text = "PROC-SEARCH-REVIEW"
            frmMainMenu.txtAction.Text = strModule
            If strModule = "All" Then
                frmMainMenu.txtModule.Text = "PROC-SEARCH-REVIEW-ALL"
            End If

            SearchMenu.MdiParent = frmMainMenu
            SearchMenu.Show()

            'Setup form title...
            SearchMenu.Text = strModule & " Procedure List - Review"

            SearchMenu.grdDataList.EditMode = DataGridViewEditMode.EditProgrammatically
        Else
            MsgBox("You are not authorized access this section of the system.  Please contact your system administrator for assistance.", vbCritical, "Access Denied")
        End If
    End Sub
End Class
