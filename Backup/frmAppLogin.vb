Public Class frmAppLogin

    Public WithEvents objAppLoginData As clsAppLogin

    Private Sub ToolStripButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSave.Click

        If fncDataCheck() = "PASS" Then

            Select Case frmStaff.txtAppAction.Text

                Case "ADD-APP"
                    objAppLoginData = New clsAppLogin
                    Call objAppLoginData.subAppAction(strAction:="ADD", _
                    intAppID:=0, intPersonID:=frmMainMenu.txtActionID.Text, strAppName:=Me.cboAppName.Text, strAppUserName:=Me.txtAppUserName.Text, _
                    strCreateUser:=SystemInformation.UserName, dtCreateDate:=System.DateTime.Now)
                    Me.Close()

                Case "EDIT-APP"
                    objAppLoginData = New clsAppLogin
                    Call objAppLoginData.subAppAction(strAction:="UPDATE", _
                    intAppID:=txtAppID.Text, intPersonID:=frmMainMenu.txtActionID.Text, strAppName:=Me.cboAppName.Text, strAppUserName:=Me.txtAppUserName.Text, _
                    strCreateUser:=SystemInformation.UserName, dtCreateDate:=System.DateTime.Now)
                    Me.Close()

                Case Else
                    MsgBox("Unknown action parameter (" & frmMainMenu.txtModule.Text & ").  Please contact your system administrator.", MsgBoxStyle.Critical, "Error")
            End Select

        End If
    End Sub

    Private Function fncDataCheck() As String
        Dim strStatus As String

        'Check Required Fields for Data...
        If Me.cboAppName.Text = Nothing Then
            MsgBox("You must Select an Application name before proceeding.", MsgBoxStyle.Exclamation, "Missing Data")
            Me.cboAppName.Focus()
            strStatus = "FAIL"
        ElseIf Me.txtAppUserName.Text = Nothing Then
            MsgBox("You must enter a User Login name before proceeding.", MsgBoxStyle.Exclamation, "Missing Data")
            Me.txtAppUserName.Focus()
            strStatus = "FAIL"
        Else
            strStatus = "PASS"
        End If
        Return strStatus
    End Function

    Private Sub ToolStripButtonDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonDel.Click

        Dim response As MsgBoxResult
        response = MsgBox("Are you sure you want to delete this item ?", MsgBoxStyle.YesNo, "Warning")

        If response = MsgBoxResult.Yes Then   ' User chose Yes.

            objAppLoginData = New clsAppLogin
            Call objAppLoginData.subAppAction(strAction:="DELETE", _
            intAppID:=txtAppID.Text, intPersonID:=frmMainMenu.txtActionID.Text, strAppName:=Me.cboAppName.Text, strAppUserName:=Me.txtAppUserName.Text, _
            strCreateUser:=SystemInformation.UserName, dtCreateDate:=System.DateTime.Now)
            Me.Close()

        End If
    End Sub

    Private Sub frmAppLogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmStaff.loadAppLoginData()
    End Sub

    Private Sub frmAppLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'testing vss
        If frmStaff.txtAppAction.Text = "ADD-APP" Then
            ToolStripButtonDel.Visible = False
            Me.txtAppID.Text = ""
            Me.cboAppName.Text = ""
            Me.txtAppUserName.Text = ""
        Else
            ToolStripButtonDel.Visible = True
        End If


    End Sub

End Class