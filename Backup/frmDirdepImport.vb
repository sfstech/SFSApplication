Public Class frmDirdepImport
    Public WithEvents objDirdepData As clsDirdep
    Public WithEvents objDirdepAction As clsDirdep
    Public WithEvents objDirdepSelect As clsDirdep
    Public WithEvents objUserData As clsSystem
    Public WithEvents objGetCTFileName As clsExport
    Public WithEvents objGetSDBFileName As clsExport
    Public WithEvents objGetCTBatchNum As clsExport

    Private Sub frmDirdepImport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dtDirdepImport.Value = System.DateTime.Now

    End Sub


    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        'Call stored procedure...
        objDirdepAction = New clsDirdep
        Call objDirdepAction.subDirdepAction(strAction:="DELETE-tblDirdepImport_Temp", intRowID:=0, intTransactionCode:=0, dtTransactionDate:="01/01/1900", strDocumentNumber:="NONE", strBankCode:="NONE", _
        strDepositNumber:="NONE", strBudgetNumber:="NONE", intAmount:=0, strGLCode:="NONE", strTask:="*", strOption:="*", strProject:="*", strInvoiceNumber:="*", strPayeeName:="NONE", strCreateUser:="NONE", _
        dtCreateDate:="01/01/1900", strMercString:="NONE")

        'MessageBox.Show(dtDirdepImport.Value & " " & dtDirdepImport.Text)

        'Call stored procedure...
        'Pull in transactions from USbank import table
        Call objDirdepAction.subDirdepAction(strAction:="USBANK-SELECT-DIRDEP", intRowID:=0, intTransactionCode:=0, dtTransactionDate:=Format(Me.dtDirdepImport.Value, "MM/dd/yy"), strDocumentNumber:="NONE", _
        strBankCode:="NONE", strDepositNumber:="NONE", strBudgetNumber:="NONE", intAmount:=0, strGLCode:="NONE", strTask:="*", strOption:="*", strProject:="*", strInvoiceNumber:="*", strPayeeName:="NONE", _
        strCreateUser:="NONE", dtCreateDate:=Format(System.DateTime.Now, "short date"), strMercString:="NONE")
        'Call stored procedure...
        'Pull in transactions from BofA import table
        Call objDirdepAction.subDirdepAction(strAction:="BOFA-SELECT-DIRDEP", intRowID:=0, intTransactionCode:=0, dtTransactionDate:=Format(Me.dtDirdepImport.Value, "MM/dd/yy"), strDocumentNumber:="NONE", _
        strBankCode:="NONE", strDepositNumber:="NONE", strBudgetNumber:="NONE", intAmount:=0, strGLCode:="NONE", strTask:="*", strOption:="*", strProject:="*", strInvoiceNumber:="*", strPayeeName:="NONE", _
        strCreateUser:="NONE", dtCreateDate:=Format(System.DateTime.Now, "short date"), strMercString:="NONE")
        'Call stored procedure...


        'Dirdep CT Export
        Dim strCTNumber As String

        'Declare object so you can get the batch number...
        objGetCTBatchNum = New clsExport

        'Establish the CT File Name...
        objGetCTFileName = New clsExport
        strCTNumber = objGetCTFileName.fncGetCTFileName(strType:="SPACE-DELIMITED", dtCTDate:=System.DateTime.Now, _
        intSequence:=objGetCTBatchNum.fncGetCTBatchNumber(strModule:="DRDEP"))

        frmMainMenu.txtActionID.Text = strCTNumber


        ''Populate tblFAS_Export
        objDirdepAction = New clsDirdep
        Call objDirdepAction.subDirdepAction(strAction:="CREATE-FAS-EXPORT", intRowID:=0, intTransactionCode:=0, dtTransactionDate:="01/01/1900", strDocumentNumber:="NONE", strBankCode:="NONE", _
        strDepositNumber:="NONE", strBudgetNumber:="NONE", intAmount:=0, strGLCode:="NONE", strTask:="*", strOption:="*", strProject:="*", strInvoiceNumber:="*", strPayeeName:="NONE", _
        strCreateUser:=SystemInformation.UserName, dtCreateDate:=Format(System.DateTime.Now, "short date"), strMercString:=strCTNumber)

        'delete opt out departments
        objDirdepAction = New clsDirdep
        Call objDirdepAction.subDirdepAction(strAction:="DELETE-OPT-OUT", intRowID:=0, intTransactionCode:=0, dtTransactionDate:="01/01/1900", strDocumentNumber:="NONE", strBankCode:="NONE", _
        strDepositNumber:="NONE", strBudgetNumber:="NONE", intAmount:=0, strGLCode:="NONE", strTask:="*", strOption:="*", strProject:="*", strInvoiceNumber:="*", strPayeeName:="NONE", _
        strCreateUser:="NONE", dtCreateDate:=Format(System.DateTime.Now, "short date"), strMercString:=strCTNumber)


        'frmMainMenu.txtModule.Text = "DRDEP-CT-EXPORT"
        'Open(frmExport)
        frmExport.MdiParent = frmMainMenu
        frmExport.Show()
        frmExport.grdDataList.EditMode = DataGridViewEditMode.EditProgrammatically
        frmExport.Text = "Cash Transmittal"
        frmExport.btnGO.Visible = True
        frmExport.btnGO.Text = "Export"
        frmExport.btnGO.ForeColor = Color.Green
        frmExport.btnCancel.Visible = True
        frmExport.btnCancel.ForeColor = Color.Red
        frmExport.btnExit.Visible = False
        frmExport.btnReport.Visible = False
        frmExport.lblFileName.Text = "CT File:"
        frmExport.lblVerUser.Visible = False
        frmExport.txtVerUser.Visible = False
        frmExport.lblVerDate.Visible = False
        frmExport.txtVerDate.Visible = False
        frmExport.txtdbModule.Text = "DRDEP-CT-EXPORT"

        'Me.Close()





        'MsgBox("Import Complete!")
        Me.Close()
    End Sub



    Private Sub lblDirdepImportDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDirdepImportDate.Click

    End Sub
End Class