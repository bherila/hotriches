Imports System.Data.Odbc
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnLogIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogIn.Click
        lblNo.Visible = False
        lblEmailed.Visible = False
        Dim cn As New OdbcConnection("dsn=hotriches;")
        cn.Open()
        Dim cmd As New OdbcCommand
        cmd.Connection = cn

        Dim lr As Boolean = False
        If txtPassword.Text.Length = 0 Then
            cmd.CommandText = "select password from users where email = '" & txtEmail.Text.ToLower.Replace("'", "''") & "'"
            Dim dr As OdbcDataReader = cmd.ExecuteReader
            If dr.Read Then
                dr.Close()
                Dim pwd As String = CStr(cmd.ExecuteScalar())
                Dim mm As New System.Net.Mail.MailMessage("system@hotriches.com", txtEmail.Text)
                mm.Subject = "HotRiches Forgotten Password"
                mm.Body = "Your password is:" & Environment.NewLine & pwd
                Dim smtp As New System.Net.Mail.SmtpClient("localhost", 25)
                smtp.Credentials = New smtpSecurity
                smtp.Send(mm)
                mm.Dispose()
                lblEmailed.Visible = True
            Else
                dr.Close()
                lblNoExist.Visible = True
            End If
        Else
            cmd.CommandText = "select id, name from users where email = '" & txtEmail.Text.ToLower.Replace("'", "''") & "' and password = '" & txtPassword.Text.ToLower.Replace("'", "''") & "'"
            Dim dr As OdbcDataReader = cmd.ExecuteReader
            If dr.Read Then
                Session("loggedin") = 1
                Session("id") = dr(0)
                Session("name") = dr(1)
                Session("email") = txtEmail.Text.ToLower
                Session("password") = txtPassword.Text.ToLower
                lr = True
            Else
                lblNo.Visible = True
            End If
            dr.Close()
        End If
        cmd.Dispose()
        cn.Close()
        cn.Dispose()

        pl.Visible = True
        If lr Then Response.Redirect("Members.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request("ref") IsNot Nothing Then
            Session("loggedin") = Nothing
            Try
                Session("referrer") = CInt(Request("ref"))
            Catch
            End Try
        End If
        If Session("loggedin") IsNot Nothing Then
            Response.Redirect("Members.aspx")
        End If
    End Sub
End Class
