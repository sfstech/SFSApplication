Imports System.Net
Imports System.Net.Mail

Public Class frmDirdepEmail

    Dim intPwdErr As Integer  '  0 = mail was sent  1 = exception

    Sub subSendMessage()
        Try
            intPwdErr = 0
            Dim mail As New MailMessage()

            mail = New MailMessage()

            'set the addresses
            mail.From = New MailAddress(Me.txtFrom.Text)
            mail.To.Add(Me.txtTo.Text)
            mail.Bcc.Add(Me.txtFrom.Text)

            'set the content
            mail.Subject = Me.txtSubject.Text
            mail.Body = Me.txtMessage.Text

            'attach file
            If IsDBNull(Me.txtAttachment.Text) = False Then
                mail.Attachments.Add(New System.Net.Mail.Attachment(Me.txtAttachment.Text))
            End If

            ''attach file
            'If IsDBNull(Me.txtAttachment.Text) = False And Me.txtAttachment.Text <> Nothing Then
            '    mail.Attachments.Add(New System.Net.Mail.Attachment(Me.txtAttachment.Text))
            'End If

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
            MessageBox.Show("The SFS database is unable to send the report(s) because you entered an incorrect password. Please try again using your email password (ie. Outlook)", "Incorrect Password")
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

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim strFilePath As String
        'Set the FolderBroswerDialog control properties...
        With OpenFileDialog1
            .Filter = "All files (*.*) | *.*"
            .FilterIndex = 1
            .Title = "Import Search"
            .FileName = ""

           
            strFilePath = "I:\groups\sfs\computing\transfer\dirdep\monthly reports"
               

            .InitialDirectory = strFilePath

        End With

        'Show the Open dialog and if the user clicks the Open button
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtAttachment.Text = OpenFileDialog1.FileName

        End If
    End Sub

    
   
    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        If Me.txtAttachment.Text = Nothing Then
            MsgBox("You must have a valid file Path to view file.", MsgBoxStyle.Exclamation, "Missing Data")
        Else
            System.Diagnostics.Process.Start(txtAttachment.Text)
        End If
    End Sub

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class