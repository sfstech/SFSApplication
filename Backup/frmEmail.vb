Imports System.Net
Imports System.Net.Mail

Public Class frmEmail

    Dim intPwdErr As Integer  '  0 = mail was sent  1 = exception

    Sub subSendMessage()
        Try
            intPwdErr = 0
            Dim mail As New MailMessage()

            mail = New MailMessage()

            'set the addresses
            mail.From = New MailAddress(Me.txtFrom.Text)
            mail.To.Add(Me.txtTo.Text)

            Select Case frmMainMenu.strCallingForm
                Case "frmSDB_Admin_App"
                    mail.Bcc.Add(frmSDB_Admin_App.strSupEmail)
                Case "frmSDB_Admin_Main"
                    Dim strA = frmMainMenu.strSupEmail
                    mail.Bcc.Add(frmMainMenu.strSupEmail)
                Case Else
                    mail.Bcc.Add(Me.txtFrom.Text)
            End Select

            'If frmMainMenu.strCallingForm = "frmSDB_Admin_App" Then
            '    mail.Bcc.Add(frmSDB_Admin_App.strSupEmail)
            'Else
            '    mail.Bcc.Add(Me.txtFrom.Text)
            'End If

            'set the content
            mail.Subject = Me.txtSubject.Text
            mail.Body = Me.txtMessage.Text

            'attach file
            If IsDBNull(Me.txtAttachement.Text) = False And Me.txtAttachement.Text <> Nothing Then
                mail.Attachments.Add(New System.Net.Mail.Attachment(Me.txtAttachement.Text))
            End If

            'send the message
            Dim smtp As New SmtpClient("127.0.0.1")

            'to authenticate we set the username and password properites on the SmtpClient
            smtp.Host = "smtp.washington.edu"
            smtp.UseDefaultCredentials = False
            smtp.EnableSsl = True
            smtp.Credentials = New NetworkCredential(SystemInformation.UserName, Me.txtNebulaPassword.Text)
            smtp.Send(mail)

        Catch ex As Exception
            intPwdErr = 1
            MessageBox.Show("The SFS database is unable to submit your JV because you supplied an incorrect password. Please try again using the password you would use when accessing your e-mail (ie. Pine, Webpine, Thunderbird, Outlook)", "Incorrect Password")
        End Try


    End Sub 'Authenticate

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        'If IsDBNull(Me.txtNebulaPassword.Text) = True Then
        If Me.txtNebulaPassword.Text = "" Then
            MsgBox("You must enter your Nebula password before proceeding.")
            Me.txtNebulaPassword.Focus()
            Exit Sub
        Else
            subSendMessage()
            If intPwdErr = 0 Then
                MsgBox("Complete!")
                Me.Close()
            End If
        End If

    End Sub

    Private Sub frmEmail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.txtFrom.Text = SystemInformation.UserName & "@u.washington.edu"
        Me.txtFrom.Enabled = False
    End Sub
End Class