
Partial Class Page_Delete
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text.Trim(New Char() {" "c, """"c, "'"c}).ToLower = "yes" Then
            Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
            cn.Open()
            Dim cmd As New System.Data.Odbc.OdbcCommand
            cmd.Connection = cn
            cmd.CommandText = "delete from pages where id = '" & Replace(Request("id"), "'", "''") & "' and owner = " & CStr(CInt(Session("id"))) & " limit 1"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
            Response.Redirect("Members.aspx")
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("Members.aspx")
    End Sub
End Class
