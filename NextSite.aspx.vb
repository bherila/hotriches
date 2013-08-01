
Partial Class NextSite
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("<center>")
        Response.Flush()
        Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
        cn.Open()
        Dim cmd As New System.Data.Odbc.OdbcCommand
        cmd.Connection = cn

        'Get UserID
        Dim userID As Integer = -1
        If Len(Request("id")) > 0 Then
            Try
                userID = CInt(Request("id"))
            Catch ex As Exception
                userID = -1
            End Try
        End If
        If (userID = -1) AndAlso (Len(Request("email")) > 0) Then
            cmd.CommandText = "select id from users where email = '" & Replace(Request("email"), "'", "''") & "' limit 1"
            Try
                userID = CInt(cmd.ExecuteScalar)
            Catch ex As Exception
                userID = -1
            End Try
        End If
        If userID < 0 Then
            txt.Text = "Invalid User ID."
        Else
            cmd.CommandText = "select cast(page_credits as char) from users where id = " & userID.ToString
            Dim rv As Object = cmd.ExecuteScalar
            If IsDBNull(rv) Then
                txt.Text = "User Not Found."
            Else
                Session("credits") = CDbl(rv)
                Dim ip As String = Request.UserHostAddress.ToString.Replace("'", "''")
                cmd.CommandText = "select cast(ts as char) from ip_control where ip = '" & ip & "'"
                rv = cmd.ExecuteScalar
                If rv Is Nothing OrElse IsDBNull(rv) Then
                    cmd.CommandText = "insert into ip_control (ip, ts, h) values ('" & ip & "', NOW(), 0)"
                    cmd.ExecuteNonQuery()
                    rv = DateTime.MinValue
                Else
                    rv = StrToDate(CStr(rv))
                End If
                Dim LastPage As DateTime = CType(rv, DateTime) ' StrToDate(CStr(rv))
                If Now.Subtract(LastPage).TotalSeconds > 25 Then
                    cmd.CommandText = "update ip_control set ts = NOW(), h = h + 1 where ip = '" & ip & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "update users set ts = NOW(), lifetime_page_credits = lifetime_page_credits + 0.8, page_credits = page_credits + 0.8 where id = " & userID.ToString
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "select id, owner, url, lastcheck from sites where (not id in (select sid from pageviews where uid = " & userID.ToString & " and now() < exp)) and owner in (select id from users where page_credits > 0 and id <> " & userID.ToString & ") order by rand()"
                    Dim dr As Data.Odbc.OdbcDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Dim id, owner, url As String
                        Dim lastcheck As DateTime
                        id = CStr(dr(0))
                        owner = CStr(dr(1))
                        url = CStr(dr(2))
                        Try
                            lastcheck = CType(dr(3), DateTime)
                        Catch
                            lastcheck = Now()
                        End Try
                        dr.Close()
                        cmd.CommandText = "insert into pageviews (uid, sid, exp) values (" & userID.ToString & ", " & id.ToLower & ", '" & DateToStr(Now.AddMinutes(5)) & "')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "update sites set hits = hits + 1, HITS_TODAY = HITS_TODAY + 1 where id = " & id
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "update users set page_credits = page_credits - 1 where id = " & owner
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "select id from users where referrer = " & owner
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            cmd.CommandText = "update users set page_credits = page_credits + 0.1 where id = " & CStr(dr(0))
                            dr.Close()
                            cmd.ExecuteNonQuery()
                        Else
                            dr.Close()
                        End If
                        If Now.Subtract(lastcheck).TotalHours > 3 Then
                            Dim r As New gRegex
                            If r.CheckURL(url, Server, Cache) = False Then
                                txt.Text = "HotRiches has just detected that this site breaks our terms! You will still get credit for viewing the site, but the site will not be shown. The site has been disabled."
                                cmd.CommandText = "update sites set enabled = 0 where id = " & id
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "update users set page_credits = page_credits - 1000 where id = " & owner
                                cmd.ExecuteNonQuery()
                                cmd.Dispose()
                                cn.Close()
                                cn.Dispose()
                                Exit Sub
                            Else
                                cmd.CommandText = "update sites set lastcheck = now() where id = " & id.ToString
                                cmd.ExecuteNonQuery()
                            End If
                        End If
                        cmd.Dispose()
                        cn.Close()
                        cn.Dispose()
                        Response.Clear()
                        Response.Write("<iframe src=""" & url.Replace("""", """""") & """ width=""100%"" height=""100%""></iframe>")
                        Response.End()
                        Exit Sub
                    Else
                        dr.Close()
                        txt.Text = "There are no sites to view at this time. Keep waiting! Remember, HotRiches only displays a site a maximum of once every 5 minutes."
                    End If
                Else
                    txt.Text = "You are surfing too fast, or you are trying to surf from multiple accounts on the same IP. Don't be a cheater!"
                End If
            End If
        End If
        cmd.Dispose()
        cn.Close()
        cn.Dispose()
    End Sub

    Function StrToDate(ByVal str As String) As DateTime
        Try
            Dim pts() As String = str.Split(" "c) 'Split the date from the time
            Dim dp() As String = pts(0).Split("-"c) 'Split the date apart
            Dim tp() As String = pts(1).Split(":"c) 'Split the time apart
            Return New DateTime(CInt(dp(0)), CInt(dp(1)), CInt(dp(2)), CInt(tp(0)), CInt(tp(1)), CInt(tp(2)))
        Catch
            Return DateTime.MinValue
        End Try
    End Function

    Function DateToStr(ByVal dat As DateTime) As String
        Return dat.Year & "-" & dat.Month.ToString.PadLeft(2, "0"c) & "-" & dat.Day.ToString.PadLeft(2, "0"c) & " " & dat.Hour.ToString.PadLeft(2, "0"c) & ":" & dat.Minute.ToString.PadLeft(2, "0"c) & ":" & dat.Second.ToString.PadLeft(2, "0"c)
    End Function


End Class
