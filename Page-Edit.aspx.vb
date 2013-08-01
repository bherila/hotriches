
Partial Class Page_Edit
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Save()
    End Sub

    Function Save() As Boolean
        If TextBox2.Text.Length <= (15 * 1024) Then
            Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
            cn.Open()
            Dim cmd As New System.Data.Odbc.OdbcCommand
            cmd.Connection = cn
            cmd.CommandText = "update pages set title = '" & TextBox1.Text.Replace("'", "''") & "', html = '" & TextBox2.Text.Replace("'", "''") & "' where id = '" & Replace(Request("id"), "'", "''") & "' and owner = " & CStr(CInt(Session("id")))
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
            Label1.Visible = False
            Return True
        Else
            Label1.Text = "Your page is too big (" & FormatNumber(TextBox2.Text.Length / 1024, 2) & " KB) and could not be saved."
            Label1.Visible = True
            Return False
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
            cn.Open()
            Dim cmd As New System.Data.Odbc.OdbcCommand
            cmd.Connection = cn

            cmd.CommandText = "select title from pages where id = '" & Replace(Request("id"), "'", "''") & "' and owner = " & CStr(CInt(Session("id"))) & " limit 1"
            TextBox1.Text = CStr(cmd.ExecuteScalar())

            cmd.CommandText = "select cast(html as char) from pages where id = '" & Replace(Request("id"), "'", "''") & "' and owner = " & CStr(CInt(Session("id"))) & " limit 1"
            TextBox2.Text = CStr(cmd.ExecuteScalar)

            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("Members.aspx")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Save() Then _
            Response.Redirect("Members.aspx")
    End Sub
End Class
