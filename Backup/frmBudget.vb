Public Class frmBudget
    Public WithEvents objDeptAction As clsDepartment

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Function fncDataCheck() As String
        Dim strStatus As String
        strStatus = "PASS"

        'Check Required Fields for Data...
        If Me.txtBudgetNum.Text = Nothing Then
            MsgBox("You must enter a budget number before proceeding.", MsgBoxStyle.Exclamation, "Missing Data")
            Me.txtBudgetNum.Focus()
            strStatus = "FAIL"
        ElseIf Me.txtRevCode.Text = Nothing Then
            MsgBox("You must enter the revenue code before proceeding.", MsgBoxStyle.Exclamation, "Missing Data")
            Me.txtRevCode.Focus()
            strStatus = "FAIL"
        ElseIf Me.txtTask.Text = Nothing Then
            Me.txtTask.Text = "*"
        ElseIf Me.txtOption.Text = Nothing Then
            Me.txtOption.Text = "*"
        ElseIf Me.txtProject.Text = Nothing Then
            Me.txtProject.Text = "*"
        Else
            strStatus = "PASS"
        End If
        Return strStatus
    End Function

    Private Sub btnSaveBudget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveBudget.Click
        If fncDataCheck() = "PASS" Then
            Select Case Me.txtAction.Text
                Case "ADD"
                    objDeptAction = New clsDepartment
                    Call objDeptAction.subDeptAction(strAction:="ADD-BUDGET", intDeptID:=Me.txtDeptID.Text, strDeptName:="NONE", _
                    strBudgetNum:=Me.txtBudgetNum.Text, strRevenueCode:=Me.txtRevCode.Text, strTask:=Me.txtTask.Text, strOption:=Me.txtOption.Text, strProject:=Me.txtProject.Text, _
                    intBudgetID:=0, intMerchantID:=0, strMerchantNum:="NONE", strMerchantNumFull:="NONE", strMerchantType:="NONE", strMerchantDesc:="NONE", btOptOut:="False", _
                    strCreateUser:=Me.txtCreateUser.Text, stCreateDate:="01/01/1900", strprocess_type:="NONE", strprocess_type_desc:="NONE", strterminal_status:="NONE", strstatement_pref:="NONE")

                    subLeaveForm()
                    Me.Close()

                Case "EDIT"
                    objDeptAction = New clsDepartment
                    Call objDeptAction.subDeptAction(strAction:="UPDATE-BUDGET", intDeptID:=Me.txtDeptID.Text, strDeptName:="NONE", _
                    strBudgetNum:=Me.txtBudgetNum.Text, strRevenueCode:=Me.txtRevCode.Text, strTask:=Me.txtTask.Text, strOption:=Me.txtOption.Text, strProject:=Me.txtProject.Text, _
                    intBudgetID:=Me.txtBudgetID.Text, intMerchantID:=0, strMerchantNum:="NONE", strMerchantNumFull:="NONE", strMerchantType:="NONE", strMerchantDesc:="NONE", btOptOut:="False", _
                    strCreateUser:="NONE", stCreateDate:="01/01/1900", strprocess_type:="NONE", strprocess_type_desc:="NONE", strterminal_status:="NONE", strstatement_pref:="NONE")

                    subLeaveForm()
                    Me.Close()
            End Select
        End If
    End Sub

    Private Sub subLeaveForm()
        'Re-Open frmDepartment
        frmMainMenu.txtActionID.Text = Me.txtDeptID.Text
        frmMainMenu.txtModule.Text = "DEPT-SEARCH"
        'Load frmDepartment...
        frmDepartment.MdiParent = frmMainMenu
        frmDepartment.Show()
        frmDepartment.Text = "Departments"
        frmDepartment.txtDeptID.Text = Me.txtDeptID.Text
        frmDepartment.txtDeptName.Text = Me.txtDeptName.Text
        frmDepartment.btnExit.ForeColor = Color.Red
        frmDepartment.grpMerchants.Text = "Click budget in grid above to view merchant data."
        frmDepartment.grdBudgetDisplay.EditMode = DataGridViewEditMode.EditProgrammatically
        frmDepartment.grdMerchant.EditMode = DataGridViewEditMode.EditProgrammatically
    End Sub

    Private Sub frmBudget_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        subLeaveForm()
    End Sub
End Class