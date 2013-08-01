<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">

</script>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN" "http://www.w3.org/TR/html4/frameset.dtd">
<html>
<head>
<title>HotRiches :: View and Earn</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
</head>

<frameset rows="80,*" frameborder="NO" border="0" framespacing="0">
  <frame src="ViewAndEarnTop.aspx?email=<%= Request("email") %>&id=<%= Request("id") %>" name="topFrame" scrolling="NO" noresize >
  <frame src="NextSite.aspx?email=<%= Request("email") %>&id=<%= Request("id") %>&random=<%= Rnd() %>" name="mainFrame">
</frameset>
<noframes><body>
</body></noframes>
</html>
