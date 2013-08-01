<%@ Page Language="VB" %><script runat="server">
                             Dim creds As String = "0"
                             Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
                                 Dim cn As New System.Data.Odbc.OdbcConnection("dsn=hotriches;")
                                 cn.Open()
                                 Dim cmd As New System.Data.Odbc.OdbcCommand
                                 cmd.Connection = cn
                                 cmd.CommandText = "select page_credits from users where id = " & CStr(CInt(Request("id"))) & " or email = '" & Replace(Request("email"), "'", "''") & "' limit 1"
                                 creds = CStr(CInt(cmd.ExecuteScalar))
                                 cmd.Dispose()
                                 cn.Close()
                                 cn.Dispose()
                             End Sub
</script><html><head><title>HotRiches :: Top Bar</title><meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"><link rel="stylesheet" href="ViewAndEarnTop.css" /><script>var uid=<%= Request("id") %>; var uemail="<%= Request("email") %>"; var credits=<%= (Creds) %>;</script><script language="javascript" src="ViewAndEarnTop.js"></script></head><body scroll="no" onLoad="setInterval('secnd();', 1000);"><table width="100%" height="80"  border="0" cellpadding="0" cellspacing="0"><tr><td><table width="100%"  border="0" cellspacing="0" cellpadding="5"><tr><td><div id="txtTimer" style="font-weight: bold;">Next page in 30 seconds</div></td><td align="right"><input name="btnPause" type="button" id="btnPause" value="Pause" onClick="pauseResume();"> <input name="btnAcct" type="button" id="btnAcct" value="Return to Account" onClick="top.location.href='Members.aspx';"></td></tr><tr><td><div id="txtCredits">Account Credits: <%= Creds %></div></td><td align="right"><input name="btnOpen" type="button" id="btnOpen" value="Open Site in New Window" onClick="openSite();"></td></tr></table></td><td width="468" align="right" valign="middle">
<IFRAME FRAMEBORDER=0 MARGINWIDTH=0 MARGINHEIGHT=0 SCROLLING=NO WIDTH=468 HEIGHT=60 SRC="http://adserving.budsinc.com/imp?z=4&s=9642&t=3&r=1"></IFRAME>
<script src="http://svc.statsxp.com/statsxp.js" language="javascript" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
  var xpSiteID = 6,
  xpHTTPMethod = "<%= Request.HttpMethod %>",
  xpHTTPStatus= 200,
  xp1="Surf-Bar",
  xp2="",
  xp3="",
  xp4="",
  xp5="",
  xpNoActiveX = 1;
  StatsXP();
</script>
</td></tr></table></body></html>