Public Class frmBankData
    Public WithEvents objARCExternalData As clsARC
    Public WithEvents objARCInternalData As clsARC
    Public WithEvents objBankData As clsBankData

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmBankData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case frmMainMenu.txtModule.Text
            Case "BofA-SEARCH-5000"
                objBankData = New clsBankData
                Call objBankData.subBofASelect(strBindTarget:="frmBankData", strAction:="BofA-SELECT-DATE", dtBankDate:=frmMainMenu.txtActionID.Text, intAcctNum:="62045000", _
                strCreateUser:="NONE", dtCreateDate:="01/01/1900")
            Case "BofA-SEARCH-1903"
                objBankData = New clsBankData
                Call objBankData.subBofASelect(strBindTarget:="frmBankData", strAction:="BofA-SELECT-DATE", dtBankDate:=frmMainMenu.txtActionID.Text, intAcctNum:="76961903", _
                strCreateUser:="NONE", dtCreateDate:="01/01/1900")
            Case "BofA-SEARCH-2015"
                objBankData = New clsBankData
                Call objBankData.subBofASelect(strBindTarget:="frmBankData", strAction:="BofA-SELECT-DATE", dtBankDate:=frmMainMenu.txtActionID.Text, intAcctNum:="62042015", _
                strCreateUser:="NONE", dtCreateDate:="01/01/1900")
            Case "BofA-SEARCH-0904"
                objBankData = New clsBankData
                Call objBankData.subBofASelect(strBindTarget:="frmBankData", strAction:="BofA-SELECT-DATE", dtBankDate:=frmMainMenu.txtActionID.Text, intAcctNum:="68480904", _
                strCreateUser:="NONE", dtCreateDate:="01/01/1900")
            Case "ARC-EXTERNAL-SEARCH"
                objARCExternalData = New clsARC
                Call objARCExternalData.subARCExternalSelect(strBindTarget:="frmBankData", strAction:="SELECT-BY-DEPOSITID", _
                strBatchID:="NONE", strTransmissionDepositID:=frmMainMenu.txtActionID.Text, strBankNumber:="NONE", strAccountNum:="NONE", strCheckNumber:="NONE", _
                dblAmount:=0.0, strTransactionType:="NONE", dtRecdDate:="01/01/1900", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
            Case "ARC-INTERNAL-SEARCH"
                objARCInternalData = New clsARC
                Call objARCInternalData.subARCInternalSelect(strBindTarget:="frmBankData", strAction:="SELECT-BY-BATCHID", _
                strBatchID:=frmMainMenu.txtActionID.Text, strBankNumber:="NONE", strAccountNum:="NONE", strCheckNumber:="NONE", _
                dblAmount:=0.0, strTransactionType:="NONE", dtCaptureTime:="01/01/1900", strCreateUser:="NONE", dtCreateDate:="01/01/1900")
        End Select
    End Sub
End Class