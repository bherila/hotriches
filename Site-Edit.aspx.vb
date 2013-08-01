
Partial Class Site_Edit
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
        cn.Open()
        Dim cmd As New System.Data.Odbc.OdbcCommand
        cmd.Connection = cn
        cmd.CommandText = "update sites set lastcheck = Date_SUB(Now(), Interval 4 hour), name = '" & TextBox1.Text.Replace("'", "''") & "', enabled = "
        If CheckBox1.Checked Then
            cmd.CommandText &= "1"
        Else
            cmd.CommandText &= "0"
        End If
        cmd.CommandText &= " where id = '" & Replace(Request("id"), "'", "''") & "' and owner = " & CStr(CInt(Session("id")))
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()
        cn.Dispose()
        Response.Redirect("Members.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
            cn.Open()
            Dim cmd As New System.Data.Odbc.OdbcCommand
            cmd.Connection = cn

            cmd.CommandText = "select name from sites where id = '" & Replace(Request("id"), "'", "''") & "' and owner = " & CStr(CInt(Session("id"))) & " limit 1"
            TextBox1.Text = CStr(cmd.ExecuteScalar())

            cmd.CommandText = "select enabled from sites where id = '" & Replace(Request("id"), "'", "''") & "' and owner = " & CStr(CInt(Session("id"))) & " limit 1"
            If CInt(cmd.ExecuteScalar()) = 1 Then
                CheckBox1.Checked = True
            Else
                CheckBox1.Checked = False
            End If

            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("Members.aspx")
    End Sub
End Class
