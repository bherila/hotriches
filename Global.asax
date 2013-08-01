<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        Application("Hits") = 0
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
    
    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        On Error Resume Next
        Dim xp As New StatsXP
        xp.RegisterHitFromHTTPRequest(Request)
        Dim hits As Integer = Application("Hits")
        If hits = 1000 Then
            Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
            cn.Open()
            Dim cmd As New System.Data.Odbc.OdbcCommand
            cmd.Connection = cn
            cmd.CommandText = "truncate hotriches.pageviews"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
            hits = 0
        End If
        hits += 1
        Application.Lock()
        Application("Hits") = hits
        Application.UnLock()
    End Sub
    
       
</script>