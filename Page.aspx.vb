
Partial Class Page
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim html As String '= Cache.Item("pg" & Request("id"))
        'If html Is Nothing Then
        Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
        cn.Open()
        Dim cmd As New System.Data.Odbc.OdbcCommand
        cmd.Connection = cn
        cmd.CommandText = "update pages set hits = hits + 1, hits_today = hits_today + 1 where id = '" & Replace(Request("id"), "'", "''") & "' limit 1"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "select cast(html as char) from pages where id = '" & Replace(Request("id"), "'", "''") & "' limit 1"
        html = CStr(cmd.ExecuteScalar)
        cmd.Dispose()
        cn.Close()
        cn.Dispose()
        'Cache.Add("pg" & Request("id"), html, Nothing, Now.AddMinutes(5), Nothing, CacheItemPriority.Normal, Nothing)
        'End If
        If Len(html) > 0 Then
            Response.Clear()
            Response.Write(html)
            Response.End()
        Else
            Response.Redirect("Default.aspx")
        End If
    End Sub

End Class
