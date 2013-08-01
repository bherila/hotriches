
Partial Class Site_Create
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Session("loggedin") IsNot Nothing Then
            Label1.Text = ""
            Dim r As New gRegex()
            r.CheckURL(txtURL.Text, Label1.Text, True, Server, Cache)
            If Label1.Text <> "" Then
                Label1.Visible = True
            Else
                Label1.Visible = False
                'Do the Insert; the page is OK
                Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
                cn.Open()
                Dim cmd As New System.Data.Odbc.OdbcCommand()
                cmd.Connection = cn
                cmd.CommandText = "insert into sites (owner, enabled, name, url, hits, hits_today, lastcheck) values (" & CStr(CInt(Session("id"))) & ", 1, '" & txtName.Text.Replace("'", "''") & "', '" & txtURL.Text.Replace("'", "''") & "', 0, 0, NOW())"
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()
                cn.Dispose()
                Response.Redirect("Members.aspx")
            End If
        Else
            Response.Redirect("Default.aspx")
        End If
    End Sub

    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loggedin") Is Nothing Then Response.Redirect("Default.aspx")
    End Sub
End Class
