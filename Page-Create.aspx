<%@ Page ValidateRequest="false" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Page-Create.aspx.vb" Inherits="Page_Create" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Create New Page</h1>
<p>HotRiches will store pages in your account for use with AutoSurf programs and other
    programs. We do not host images required by your page, and your page is limited
    to 15 KB in size. Your page must not reference anything illegal. We do not routeinly
    monitor the content of these pages, but will investigate complaints and high traffic
    pages. We reserve the right to delete your page at any time without notice.</p>
    <p>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#C00000" Text="Label"
            Visible="False"></asp:Label>&nbsp;</p>
    <p>
        <strong>Page Name</strong> (for internal use only within your account)<br />
        <asp:TextBox ID="TextBox1" runat="server">Untitled</asp:TextBox></p>
    <p>
        <strong>HTML Code<br />
            <asp:TextBox ID="TextBox2" runat="server" Font-Names="monospace" Height="250px" TextMode="MultiLine"
                Width="626px" Wrap="False">&lt;!DOCTYPE HTML PUBLIC &quot;-//W3C//DTD HTML 4.01 Transitional//EN&quot;
&quot;http://www.w3.org/TR/html4/loose.dtd&quot;&gt;
&lt;html&gt;
&lt;head&gt;
&lt;title&gt;Untitled Document&lt;/title&gt;
&lt;meta http-equiv=&quot;Content-Type&quot; content=&quot;text/html; charset=iso-8859-1&quot;&gt;
&lt;/head&gt;

&lt;body&gt;
&lt;/body&gt;
&lt;/html&gt;</asp:TextBox></strong></p>
    <p>
        <strong>
            <asp:Button ID="Button1" runat="server" Text="Create Page" /></strong>&nbsp;</p>
</asp:Content>

