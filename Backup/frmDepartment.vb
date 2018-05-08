Public Class frmDepartment
    Public WithEvents objDeptData As clsDepartment
    Public WithEvents objDeptAction As clsDepartment
    Public WithEvents objGetDeptID As clsDepartment
    Public WithEvents objAddDeptID As clsDepartment
    Public WithEvents objSecurityCheck As clsSystem

    Dim strPassFail As String

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmMainMenu.txtModule.Text = "DEPT-SEARCH"
        frmMainMenu.txtAction.Text = "ALL"

        'Set the parent of module menu screen and open it...
        frmSearch.MdiParent = frmMainMenu
        frmSearch.Show()
        frmSearch.grdDataList.EditMode = DataGridViewEditMode.EditProgrammatically
        Me.Close()

    End Sub

    Private Sub grdBudgetDisplay_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBudgetDisplay.CellClick
        subLoadMerchantGrid()
        grdBudgetDisplay.CurrentRow.Selected = True
    End Sub

    Private Sub frmDepartment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objDeptData = New clsDepartment
        Call objDeptData.subDeptSelect(strBindTarget:="frmDepartment-grdBudgetDisplay", strAction:="SELECT-BUDGET-BY-DEPTID", intDeptID:=frmMainMenu.txtActionID.Text, strDeptName:="NONE", _
        strBudgetNum:="NONE", strRevenueCode:="NONE", strTask:="NONE", strOption:="NONE", strProject:="NONE", _
        intBudgetID:=0, intMerchantID:=0, strMerchantNum:="NONE", strMerchantNumFull:="NONE", strMerchantType:="NONE", strMerchantDesc:="NONE", bitOptOut:="FALSE", _
        strCreateUser:="NONE", dtCreateDate:="01/01/1900", strprocess_type:="NONE", strprocess_type_desc:="NONE", strterminal_status:="NONE", strstatement_pref:="NONE")
    End Sub

    Private Sub btnEditDeptartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objSecurityCheck = New clsSystem

        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="MERC-ROLE-CHECK", strRole:="Edit - Dept")
        If strPassFail = "PASS" Then
            Dim strDeptName As String
            strDeptName = InputBox("Enter new department name:", "Department Change")
            If strDeptName <> Nothing Then
                Me.txtDeptName.Text = strDeptName
                objDeptAction = New clsDepartment
                Call objDeptAction.subDeptAction(strAction:="UPDATE-DEPARTMENT", intDeptID:=Me.txtDeptID.Text, strDeptName:=strDeptName, _
                strBudgetNum:="NONE", strRevenueCode:="NONE", strTask:="X", strOption:="X", strProject:="X", _
                intBudgetID:=0, intMerchantID:=0, strMerchantNum:="NONE", strMerchantNumFull:="NONE", strMerchantType:="NONE", strMerchantDesc:="NONE", btOptOut:="False", _
                strCreateUser:="NONE", stCreateDate:="01/01/1900", strprocess_type:="NONE", strprocess_type_desc:="NONE", strterminal_status:="NONE", strstatement_pref:="NONE")
            End If
        Else
            MsgBox("You are not authorized access this section of the system.  Please contact your system administrator for assistance.", vbCritical, "Access Denied")
        End If
    End Sub

    Private Sub btnAddDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objSecurityCheck = New clsSystem

        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="MERC-ROLE-CHECK", strRole:="Edit - Dept")
        If strPassFail = "PASS" Then
            Me.Close()
            objAddDeptID = New clsDepartment
            Call objAddDeptID.subAddDept()
        Else
            MsgBox("You are not authorized access this section of the system.  Please contact your system administrator for assistance.", vbCritical, "Access Denied")
        End If
    End Sub

    Private Sub btnEditBudget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objSecurityCheck = New clsSystem

        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="MERC-ROLE-CHECK", strRole:="Edit - Dept")
        If strPassFail = "PASS" Then
            If grdBudgetDisplay.Focus = True Then
                If grdBudgetDisplay.CurrentRow.Selected Then
                    Dim intRowValue As Integer = Val(grdBudgetDisplay.CurrentRow.Index)
                    frmBudget.MdiParent = frmMainMenu
                    frmBudget.Show()
                    frmBudget.txtAction.Text = "EDIT"
                    frmBudget.txtBudgetID.Text = (grdBudgetDisplay(0, intRowValue).Value)
                    frmBudget.txtDeptID.Text = (grdBudgetDisplay(1, intRowValue).Value)
                    frmBudget.txtDeptName.Text = Me.txtDeptName.Text
                    frmBudget.txtBudgetNum.Text = (grdBudgetDisplay(2, intRowValue).Value)
                    frmBudget.txtRevCode.Text = (grdBudgetDisplay(3, intRowValue).Value)
                    frmBudget.txtTask.Text = (grdBudgetDisplay(4, intRowValue).Value)
                    frmBudget.txtOption.Text = (grdBudgetDisplay(5, intRowValue).Value)
                    frmBudget.txtProject.Text = (grdBudgetDisplay(6, intRowValue).Value)
                    frmBudget.txtCreateUser.Text = (grdBudgetDisplay(7, intRowValue).Value)
                    frmBudget.txtCreateDate.Text = (grdBudgetDisplay(9, intRowValue).Value)
                    Me.Close()
                Else
                    MsgBox("You must select a budget to edit (click the budget grid) before proceding.", , "Missing Information")
                End If
            End If
        Else
            MsgBox("You are not authorized access this section of the system.  Please contact your system administrator for assistance.", vbCritical, "Access Denied")
        End If
    End Sub

    Private Sub btnAddBudget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objSecurityCheck = New clsSystem

        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="MERC-ROLE-CHECK", strRole:="Edit - Dept")
        If strPassFail = "PASS" Then
            frmBudget.MdiParent = frmMainMenu
            frmBudget.Show()
            frmBudget.txtAction.Text = "ADD"
            frmBudget.txtDeptID.Text = Me.txtDeptID.Text
            frmBudget.txtDeptName.Text = Me.txtDeptName.Text
            frmBudget.txtTask.Text = "*"
            frmBudget.txtOption.Text = "*"
            frmBudget.txtProject.Text = "*"
            frmBudget.txtCreateUser.Text = SystemInformation.UserName
            frmBudget.txtCreateDate.Text = (Format(Now(), "MM/dd/yyyy"))
            Me.Close()
        Else
            MsgBox("You are not authorized access this section of the system.  Please contact your system administrator for assistance.", vbCritical, "Access Denied")
        End If
    End Sub

    Private Sub btnEditMerchant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objSecurityCheck = New clsSystem

        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="MERC-ROLE-CHECK", strRole:="Edit - Dept")
        If strPassFail = "PASS" Then
            If grdMerchant.Focus = True Then
                If grdMerchant.CurrentRow.Selected Then
                    Dim intRowValue As Integer = Val(grdMerchant.CurrentRow.Index)
                    frmMainMenu.txtActionID.Text = (grdMerchant(11, intRowValue).Value)
                    frmMerchant.MdiParent = frmMainMenu
                    frmMerchant.Show()
                    frmMerchant.txtAction.Text = "EDIT"
                    frmMerchant.txtDeptID.Text = Me.txtDeptID.Text
                    frmMerchant.txtDeptName.Text = Me.txtDeptName.Text
                    frmMerchant.txtMerchantID.Text = (grdMerchant(0, intRowValue).Value)
                    frmMerchant.txtBudgetID.Text = (grdMerchant(1, intRowValue).Value)
                    frmMerchant.txtBudgetNum.Text = (grdMerchant(6, intRowValue).Value)
                    frmMerchant.txtMerchantNum.Text = (grdMerchant(2, intRowValue).Value)
                    frmMerchant.cboMerchantType.Text = (grdMerchant(3, intRowValue).Value)
                    frmMerchant.txtMerchantDesc.Text = (grdMerchant(4, intRowValue).Value)
                    If (grdMerchant(7, intRowValue).Value) = True Then
                        frmMerchant.ckOptOut.CheckState = CheckState.Checked
                    Else
                        frmMerchant.ckOptOut.CheckState = CheckState.Unchecked
                    End If
                    frmMerchant.txtCreateUser.Text = (grdMerchant(8, intRowValue).Value)
                    frmMerchant.txtCreateDate.Text = (grdMerchant(10, intRowValue).Value)
                    Me.Close()
                Else
                    MsgBox("You must select a merchant to edit (click the merchant grid) before proceding.", , "Missing Information")
                End If
            End If
        Else
            MsgBox("You are not authorized access this section of the system.  Please contact your system administrator for assistance.", vbCritical, "Access Denied")
        End If
    End Sub

    Private Sub btnAddMerchant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objSecurityCheck = New clsSystem

        strPassFail = objSecurityCheck.fncSecurityCheck(strAction:="MERC-ROLE-CHECK", strRole:="Edit - Dept")
        If strPassFail = "PASS" Then
            If grdBudgetDisplay.Focus = True Then
                If grdBudgetDisplay.CurrentRow.Selected Then
                    Dim intRowValue As Integer = Val(grdBudgetDisplay.CurrentRow.Index)
                    frmMerchant.MdiParent = frmMainMenu
                    frmMerchant.Show()
                    frmMerchant.txtAction.Text = "ADD"
                    frmMerchant.txtDeptID.Text = Me.txtDeptID.Text
                    frmMerchant.txtDeptName.Text = Me.txtDeptName.Text
                    frmMerchant.txtMerchantID.Text = 0
                    frmMerchant.txtBudgetID.Text = (grdBudgetDisplay(0, intRowValue).Value)
                    frmMerchant.txtBudgetNum.Text = (grdBudgetDisplay(2, intRowValue).Value)
                    frmMerchant.txtCreateUser.Text = SystemInformation.UserName
                    frmMerchant.txtCreateDate.Text = (Format(Now(), "MM/dd/yyyy"))

                    Me.Close()
                Else
                    MsgBox("You must select a budget to add (click the budget grid) before proceding.", , "Missing Information")
                End If
            End If
        Else
            MsgBox("You are not authorized access this section of the system.  Please contact your system administrator for assistance.", vbCritical, "Access Denied")
        End If
    End Sub
    Private Sub subLoadMerchantGrid()
        Dim intRowValue As Integer = Val(grdBudgetDisplay.CurrentRow.Index)
        Me.grpMerchants.Text = "Merchant data for budget (" & (grdBudgetDisplay(2, intRowValue).Value) & "):"

        objDeptData = New clsDepartment
        Call objDeptData.subDeptSelect(strBindTarget:="frmDepartment-grdMerchant", strAction:="SELECT-MERCHANT-BY-BUDGET", intDeptID:=frmMainMenu.txtActionID.Text, strDeptName:="NONE", _
        strBudgetNum:="NONE", strRevenueCode:="NONE", strTask:="NONE", strOption:="NONE", strProject:="NONE", _
        intBudgetID:=(grdBudgetDisplay(0, intRowValue).Value), intMerchantID:=0, strMerchantNum:="NONE", strMerchantNumFull:="NONE", strMerchantType:="NONE", strMerchantDesc:="NONE", bitOptOut:="FALSE", _
        strCreateUser:="NONE", dtCreateDate:="01/01/1900", strprocess_type:="NONE", strprocess_type_desc:="NONE", strterminal_status:="NONE", strstatement_pref:="NONE")
    End Sub


    Private Sub grdMerchant_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdMerchant.CellClick
        grdMerchant.CurrentRow.Selected = True
    End Sub
End Class