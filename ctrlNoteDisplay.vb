Public Class ctrlNoteDisplay
    Public WithEvents objNoteData As clsNote
    Public WithEvents objNoteAction As clsNote
    Dim strArrDescr() As String

    Private Sub ctrlNoteDisplay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        subRefreshGrid()
    End Sub

    Private Sub btnAddNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNote.Click

        objNoteAction = New clsNote
        Call objNoteAction.subNoteAction(strAction:="ADD-NOTE", intNoteID:=0, strNoteType:="NOTE", strModule:=strArrDescr(1), intModuleID:=strArrDescr(2), strNoteDesc:=InputBox("Please enter note:", "Add Note"), strCreateUser:=SystemInformation.UserName, dtCreateDate:=Format(System.DateTime.Now, "short date"))

        subRefreshGrid()
    End Sub

    Private Sub subRefreshGrid()
        strArrDescr = Me.Tag.Split(" ")

        objNoteData = New clsNote
        Call objNoteData.subNoteSelect(strBindTarget:=strArrDescr(0) & "-ctrlNote", strAction:="SELECT-BY-MODULEID", intNoteID:=0, strNoteType:="NONE", strModule:=strArrDescr(1), intModuleID:=strArrDescr(2), strNoteDesc:="NONE", strCreateUser:="NONE", dtCreateDate:="01/01/1900")

        Select Case strArrDescr(0)
            Case "frmCashierActivity"
                objNoteAction = New clsNote
                frmCashierActivity.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:=strArrDescr(1), intModuleID:=strArrDescr(2)) & " Total)"
            Case "frmJV"
                objNoteAction = New clsNote
                frmJV.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:=strArrDescr(1), intModuleID:=strArrDescr(2)) & " Total)"
            Case "frmCashierBalancing"
                objNoteAction = New clsNote
                frmCashierBalancing.TabPage2.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:=strArrDescr(1), intModuleID:=strArrDescr(2)) & " Total)"
                'Case "frmSponsor"
                '    objNoteAction = New clsNote
                '    frmSponsor.TabPage1.Text = "Notes (" & objNoteAction.fncNoteCount(strModule:=strArrDescr(1), intModuleID:=strArrDescr(2)) & " Total)"
        End Select
    End Sub

    Private Sub lblGrid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblGrid.GotFocus
        subRefreshGrid()
    End Sub
End Class
