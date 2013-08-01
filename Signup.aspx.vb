Imports System.Data.Odbc

Partial Class Signup
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Page.IsValid Then
            Dim cn As New OdbcConnection("dsn=hotriches;")
            cn.Open()
            Dim cmd As New OdbcCommand
            cmd.Connection = cn
            cmd.CommandText = "select word from bombness.wordlist where length(word) = 5 order by rand() limit 1"
            Dim password As String = String.Concat(CStr(cmd.ExecuteScalar), Math.Round(Rnd() * 100).ToString.Replace("0", "1")).ToLower


            Dim msg As New System.Text.StringBuilder

            Dim ui(4) As String
            ui(0) = txtEmail.Text
            ui(1) = txtName.Text
            ui(2) = password
            If (Not Session("referrer") Is Nothing) AndAlso (Len(CStr(Session("referrer"))) > 0) Then
                ui(3) = CStr(Session("referrer"))
            Else
                ui(3) = "1"
            End If
            'Dim guid As String = System.Guid.NewGuid.ToString("N")
            'Cache.Add("s_" & guid.ToLower, ui, Nothing, Now.AddHours(6), Nothing, CacheItemPriority.High, Nothing)

            cmd.CommandText = "insert into users (email, name, password, referrer, create_date) values ('" & ui(0).ToLower.Replace("'", "''") & "', '" & ui(1).Replace("'", "''") & "', '" & ui(2).ToLower.Replace("'", "''") & "', " & CStr(CInt(ui(3))) & ", NOW())"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "select id from users where email = '" & ui(0).Replace("'", "''") & "' and password = '" & ui(2).Replace("'", "''") & "' limit 1"


            With msg
                .Append("Dear ").Append(txtName.Text).AppendLine(",")

                .AppendLine(" ")
                .AppendLine("Welcome to HotRiches, the internet's newest, latest,")
                .AppendLine("and greatest marketing machine. We have the tools")
                .AppendLine("you need to give your site a jumpstart in the")
                .AppendLine("internet world.")

                .AppendLine(" ")
                .AppendLine("We have received a request to create an account with")
                .AppendLine("the following information:")
                .Append("     E-Mail Address: ").AppendLine(txtEmail.Text)
                .Append("     Full Name:      ").AppendLine(txtName.Text)
                .Append("     Password:       ").AppendLine(password)

                '.AppendLine(" ")
                '.AppendLine("If this information is correct, please click the link")
                '.AppendLine("below to create the account.")
                '.AppendLine()
                '.AppendLine("http://www.hotriches.com/Signup3.aspx?guid=" & guid)
                .AppendLine("You may now log in to your account at")
                .AppendLine("http://www.hotriches.com using your e-mail address")
                .AppendLine("and password.")
                .AppendLine(" ")
                .AppendLine("AOL Users Click Here:")
                .AppendLine("<a href=""http://www.hotriches.com"">http://www.hotriches.com</a>")

                .AppendLine(" ")
                .AppendLine("For fraud tracking purposes, this signup was")
                .Append("initiated by the person at IP address ").AppendLine(Request.UserHostAddress.ToString)

                .AppendLine("Best Regards,")
                .AppendLine("HotRiches.com System Attendant")
                .AppendLine("------------------------------------")
                .AppendLine("This message was automatically generated, and replies")
                .AppendLine("will not be answered.")

            End With

            Dim mm As New System.Net.Mail.MailMessage("system@hotriches.com", txtEmail.Text)
            mm.Subject = "Confirm your E-Mail Address on HotRiches.com"
            mm.Body = msg.ToString
            mm.IsBodyHtml = False
            Dim smtp As New System.Net.Mail.SmtpClient("localhost", 25)
            smtp.Credentials = New smtpSecurity
            smtp.Send(mm)

            cmd.Dispose()
            cn.Close()
            cn.Dispose()

            Response.Redirect("signup2.aspx")

        End If
    End Sub

    Protected Sub valEmail_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles valEmail.ServerValidate
        If txtEmail.Text.Length < 5 Then
            args.IsValid = False
            valEmail.ErrorMessage = "You must enter an e-mail address."
        Else
            Dim cn As New OdbcConnection("dsn=hotriches;")
            cn.Open()
            Dim cmd As New OdbcCommand
            cmd.Connection = cn
            valEmail.ErrorMessage = "An account already exists with this e-mail."
            cmd.CommandText = "select cast(count(*) as char) from users where email = '" & txtEmail.Text.Replace("'", "''") & "'"
            If CInt(cmd.ExecuteScalar) > 0 Then
                args.IsValid = False
            End If
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End If
    End Sub
End Class
