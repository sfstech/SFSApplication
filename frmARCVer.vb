Public Class frmARCVer
    Public WithEvents objARCExternalData As clsARC
    Public WithEvents objARCExternalAction As clsARC

    Private Sub frmARCVer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        subRefreshListBox()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click
        objARCExternalAction = New clsARC
        Call objARCExternalAction.subARCExternalAction(strBindTarget:="NONE", strAction:="VERIFY", _
        strBatchID:=Me.lstInternal.SelectedItem(0), strTransmissionDepositID:=Me.lstExternal.SelectedItem(0), strBankNumber:="NONE", strAccountNum:="NONE", strCheckNumber:="NONE", _
        dblAmount:=0.0, strTransactionType:="NONE", dtRecdDate:="01/01/1900", strCreateUser:="NONE", dtCreateDate:="01/01/1900")

        subRefreshListBox()

        MsgBox("Verfication Complete!")
    End Sub

    Private Sub subRefreshListBox()
        objARCExternalData = New clsARC
        Call objARCExternalData.subARCExternalSelect(strBindTarget:="frmARCVer", strAction:="SELECT-UNVERIFIED", _
        strBatchID:="NONE", strTransmissionDepositID:="NONE", strBankNumber:="NONE", strAccountNum:="NONE", strCheckNumber:="NONE", _
        dblAmount:=0.0, strTransactionType:="NONE", dtRecdDate:="01/01/1900", strCreateUser:="NONE", dtCreateDate:="01/01/1900")

        'objARCInternalData = New clsARC
        Call objARCExternalData.subARCInternalSelect(strBindTarget:="frmARCVer", strAction:="SELECT-UNVERIFIED", _
        strBatchID:="NONE", strBankNumber:="NONE", strAccountNum:="NONE", strCheckNumber:="NONE", _
        dblAmount:=0.0, strTransactionType:="NONE", dtCaptureTime:="01/01/1900", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
    End Sub
End Class