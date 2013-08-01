
Partial Class Page_Create
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        label1.visible = True
        Label1.Text = ""
        If TextBox2.Text.Length > (15 * 1024) Then
            Label1.Text = "Your page is too big (" & FormatNumber(TextBox2.Text.Length / 1024, 2) & " KB) and could not be saved."
        End If
        If Label1.Text = "" Then
            Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
            cn.Open()
            Dim cmd As New System.Data.Odbc.OdbcCommand
            cmd.Connection = cn
            cmd.CommandText = "insert into `pages` (`owner`, `hits`, `title`, `html`) values (" & CStr(CInt(Session("id"))) & ", 0, '" & TextBox1.Text.Replace("'", "''") & "', '" & TextBox2.Text.Replace("'", "''") & "')"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
            Response.Redirect("Members.aspx")
        End If
    End Sub
End Class
