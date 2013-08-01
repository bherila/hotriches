Imports System.Data.Odbc

Partial Class Signup3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim guid As String = Request("guid")
        If guid Is Nothing Then
            msg.Text = "No GUID specified. Task aborted."
        Else
            Dim ui() As String
            Try
                ui = CType(Cache.Item("s_" & guid.ToLower), String())
                Cache.Remove("s_" & guid.ToLower)
                If ui Is Nothing Then
                    msg.Text = "GUID not found. Task aborted."
                Else
                    Try
                        Dim ok As Boolean = False
                        Dim cn As New OdbcConnection("dsn=hotriches;")
                        cn.Open()
                        Dim cmd As New OdbcCommand
                        cmd.Connection = cn
                        cmd.CommandText = "select id from users where email = '" & ui(0).Replace("'", "''") & "' and password = '" & ui(2).Replace("'", "''") & "' limit 1"
                        Dim dr As OdbcDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            msg.Text = "Internal error. Please sign up again."
                        Else
                            ok = True
                        End If
                        dr.Close()
                        If ok Then
                            cmd.CommandText = "insert into users (email, name, password, referrer, create_date) values ('" & ui(0).ToLower.Replace("'", "''") & "', '" & ui(1).Replace("'", "''") & "', '" & ui(2).ToLower.Replace("'", "''") & "', " & CStr(CInt(ui(3))) & ", NOW())"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "select id from users where email = '" & ui(0).Replace("'", "''") & "' and password = '" & ui(2).Replace("'", "''") & "' limit 1"

                            Session("loggedin") = 1
                            Session("id") = CInt(cmd.ExecuteScalar)
                            Session("name") = ui(1)
                            Session("email") = ui(0).ToLower
                            Session("password") = ui(2).ToLower

                            msg.Text = "<p>Your account was created successfully! You are now logged in.</p><p><a href=""members.aspx"">Continue &raquo;</a></p>"
                        End If
                        cmd.Dispose()
                        cn.Close()
                        cn.Dispose()
                    Catch ex As Exception
                        msg.Text = ex.ToString
                    End Try
                End If
            Catch ex As Exception
                msg.Text = "Invalid GUID object."
            End Try
        End If
    End Sub

End Class
