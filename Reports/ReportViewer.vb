Imports Microsoft.Reporting.WinForms

Public Class ReportViewer
    Dim _path As String = Nothing
    Friend _params As ReportParameter

    Public Overloads Sub ShowDialog(path As String)
        _path = path
    End Sub

    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' Me.rvSFS.RefreshReport()
        If _path IsNot Nothing Then

            rvSFS.ProcessingMode = ProcessingMode.Remote
            Dim sr As New ServerReport
            sr = rvSFS.ServerReport
            Dim rsURL As New Uri("http://sfssql1.admin.washington.edu/ReportServer")

            sr.ReportServerUrl = rsURL
            sr.ReportPath = _path

            If _params IsNot Nothing Then
                sr.SetParameters(New ReportParameter() {_params})
            End If
            rvSFS.RefreshReport()
        Else

            rvSFS.RefreshReport()
        End If



    End Sub

    Private Sub rvSFS_Load(sender As Object, e As EventArgs) Handles rvSFS.Load
     

    End Sub
End Class