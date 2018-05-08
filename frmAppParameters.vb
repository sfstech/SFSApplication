Public Class frmAppParameters

    Private Sub frmAppParameters_Load(sender As Object, e As EventArgs) Handles MyBase.Load      
        Me.TblAppParametersTableAdapter.Fill(Me.ApplicationParameters.tblAppParameters)
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        dgvAppParameters.EndEdit()
        TblAppParametersTableAdapter.Update(Me.ApplicationParameters.tblAppParameters)
    End Sub
End Class