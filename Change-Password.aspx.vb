
Partial Class Change_Password
    Inherits System.Web.UI.Page

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("Members.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If p1.Text <> p2.Text Then
            mc.Visible = True
        Else
            Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
            cn.Open()
            Try
                Dim cmd As New System.Data.Odbc.OdbcCommand
                cmd.Connection = cn
                cmd.CommandText = "update users set password = '" & p1.Text.Replace("'", "''") & "' where id = " & CStr(CInt(Session("id")))
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Catch
            End Try
            cn.Close()
            cn.Dispose()
            Response.Redirect("Members.aspx")
        End If
    End Sub
End Class
