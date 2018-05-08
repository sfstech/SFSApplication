
Public Class frmELM
    Public WithEvents objElmData As clsELM
    Public WithEvents objElmAction As clsELM

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmELM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case frmMainMenu.txtModule.Text
            Case "STUDENT"
                objElmData = New clsELM
                Call objElmData.subElmSelect(strBindTarget:="frmELM-Student-Grid", strAction:="ELM-STUDENT-DETAIL", intSSN:=0, intStudent_no:=frmMainMenu.txtActionID.Text, _
                dtElmDate:="01/01/1900", intBatchNum:=0, strElmString:="NONE", strCreateUser:="NONE")
            Case "LENDER"
                objElmData = New clsELM
                Call objElmData.subElmSelect(strBindTarget:="frmELM-Lender-Grid", strAction:="ELM-LENDER-DETAIL", intSSN:=0, intStudent_no:=frmMainMenu.txtActionID.Text, _
                dtElmDate:="01/01/1900", intBatchNum:=0, strElmString:="NONE", strCreateUser:="NONE")
        End Select

    End Sub

    
    Private Sub grdElmData_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdElmData.CellContentDoubleClick
        Dim intRowValue As Integer = Val(grdElmData.CurrentRow.Index)
        Dim intID As Integer
        Dim strName As String
        Dim strAmt As String

        Select Case Me.txtdbModule.Text
            Case "STUDENT"
                'Student to Lender...
                intID = (grdElmData(0, intRowValue).Value)
                strName = (grdElmData(3, intRowValue).Value)
                strAmt = (grdElmData(4, intRowValue).Value)
                frmMainMenu.txtActionID.Text = (grdElmData(0, intRowValue).Value)
                frmMainMenu.txtModule.Text = "LENDER"
                Me.Close()
                'Reload frmELM...
                objElmAction = New clsELM
                Call objElmAction.subElmLoad(strAction:="LOAD_LENDER", intID:=intID, strName:=strName, strAmt:=strAmt)

            Case "LENDER"
                'Lender to Student....
                intID = (grdElmData(0, intRowValue).Value)
                strName = (grdElmData(13, intRowValue).Value) & " " & (grdElmData(12, intRowValue).Value)
                strAmt = (grdElmData(3, intRowValue).Value)
                frmMainMenu.txtActionID.Text = (grdElmData(0, intRowValue).Value)
                frmMainMenu.txtModule.Text = "STUDENT"
                Me.Close()
                'Reload frmELM...
                objElmAction = New clsELM
                Call objElmAction.subElmLoad(strAction:="LOAD_STUDENT", intID:=intID, strName:=strName, strAmt:=strAmt)

        End Select
    End Sub
End Class