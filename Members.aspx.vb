Imports System.Data.Odbc
Partial Class Members
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("loggedin") Is Nothing Then
            Response.Redirect("default.aspx")
        Else
            Dim cn As New OdbcConnection("dsn=hotriches;")
            cn.Open()
            Dim cmd As New OdbcCommand
            cmd.Connection = cn
            Dim safe_id As String = CStr(CInt(Session("id")))

            cmd.CommandText = "select page_credits, banner_credits from users where id = " & safe_id
            Dim dr As OdbcDataReader = cmd.ExecuteReader
            If Not dr.Read Then Throw New Exception("Invalid user data.")
            Dim pageCredits, bannerCredits As Integer
            pageCredits = CInt(dr(0))
            bannerCredits = CInt(dr(1))
            dr.Close()
            txtPageViewCreditsRemaining.Text = FormatNumber(pageCredits, 0)
            txtPageViewCreditsRemaining2.Text = FormatNumber(pageCredits, 0)
            txtBannerCreditsRemaining.Text = FormatNumber(bannerCredits, 0)
            txtBannerCreditsRemaining2.Text = FormatNumber(bannerCredits, 0)

            Dim tbl As New hrTable





            tbl.Headers.Clear()
            tbl.Rows.Clear()
            tbl.ColorMode = hrTable.ColorModes.Line
            cmd.CommandText = "select title, hits, hits_today, id from pages where `owner` = " & safe_id & " order by title asc"
            dr = cmd.ExecuteReader
            With tbl.Headers
                .Add("Page Name")
                .Add("Hits")
                .Add("Hits Today")
                .Add("Actions")
            End With
            While dr.Read
                Dim row As New Generic.List(Of String)
                row.Add(Server.HtmlEncode(CStr(dr(0))))
                row.Add(FormatNumber(dr(1), 0))
                row.Add(FormatNumber(dr(2), 0))
                Dim pid As String = CStr(dr(3))
                row.Add("<a target=""_blank"" href=""Page.aspx?id=" & pid & """>View</a> <a href=""Page-Edit.aspx?id=" & pid & """>Edit</a> <a href=""Page-Delete.aspx?id=" & pid & """>Delete</a>")
                tbl.Rows.Add(row)
            End While
            dr.Close()
            tbl.Footer = "<a href=""Page-Create.aspx"">Create New Page</a>"
            tblPages.Text = tbl.GetHTML







            tbl.Headers.Clear()
            tbl.Rows.Clear()
            tbl.ColorMode = hrTable.ColorModes.Line
            cmd.CommandText = "select name, enabled, hits, hits_today, id from sites where `owner` = " & safe_id & " order by name asc"
            dr = cmd.ExecuteReader
            With tbl.Headers
                .Add("Name")
                .Add("Status")
                .Add("Hits")
                .Add("Hits Today")
                .Add("Actions")
            End With
            While dr.Read
                Dim row As New Generic.List(Of String)
                row.Add(Server.HtmlEncode(CStr(dr(0))))
                If CInt(dr(1)) = 1 Then
                    row.Add("Enabled")
                Else
                    row.Add("On Hold")
                End If
                row.Add(FormatNumber(dr(2), 0))
                row.Add(FormatNumber(dr(3), 0))
                Dim pid As String = CStr(dr(4))
                row.Add("<a href=""Site-Edit.aspx?id=" & pid & """>Edit</a> <a href=""Site-Delete.aspx?id=" & pid & """>Delete</a>")
                tbl.Rows.Add(row)
            End While
            dr.Close()
            tbl.Footer = "<a href=""Site-Create.aspx"">Add New URL</a>"
            tblSites.Text = tbl.GetHTML






            Dim refCount As Integer = 0
            tbl.Headers.Clear()
            tbl.Rows.Clear()
            tbl.ColorMode = hrTable.ColorModes.Line
            cmd.CommandText = "select name, email, create_date, cast(lifetime_page_credits * 0.12 as char) from users where `referrer` = " & safe_id & " order by create_date desc"
            dr = cmd.ExecuteReader
            With tbl.Headers
                .Add("Name")
                .Add("E-Mail")
                .Add("Signup Date")
                .Add("Credits Earned*")
            End With
            While dr.Read
                refCount += 1
                Dim row As New Generic.List(Of String)
                row.Add(Server.HtmlEncode(CStr(dr(0))))
                row.Add(Server.HtmlEncode(CStr(dr(1)).Split("@"c)(0) & "@***"))
                Dim dt As Date = CDate(dr(2))
                row.Add(dt.Day.ToString & " " & MN(dt.Month) & " " & dt.Year.ToString)
                row.Add(FormatNumber(dr(3), 1))
                tbl.Rows.Add(row)
            End While
            dr.Close()
            tbl.Footer = "<i>* Denotes the credits you have earned by referring each user, not the total number of credits the user has earned.</i>"
            tblRefs.Text = tbl.GetHTML
            txtRefCount.Text = FormatNumber(refCount, 0) & " referrer" & CStr(IIf(refCount <> 1, "s", ""))
        End If
    End Sub

    Function MN(ByVal month As Integer) As String
        Select Case month
            Case 1 : Return "Jan"
            Case 2 : Return "Feb"
            Case 3 : Return "Mar"
            Case 4 : Return "Apr"
            Case 5 : Return "May"
            Case 6 : Return "Jun"
            Case 7 : Return "Jul"
            Case 8 : Return "Aug"
            Case 9 : Return "Sep"
            Case 10 : Return "Oct"
            Case 11 : Return "Nov"
            Case 12 : Return "Dec"
            Case Else : Return "Err"
        End Select
    End Function

End Class
