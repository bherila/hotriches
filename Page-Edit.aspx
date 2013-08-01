<%@ Page ValidateRequest="false" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Page-Edit.aspx.vb" Inherits="Page_Edit" title="HotRiches :: Edit Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Edit Page</h1>
<p>
    Use this form to edit your page hosted on HotRiches. Remember, it is limited to
    15 KB in size.</p>
    <p>
        <strong>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#C00000" Text="Label"
                Visible="False"></asp:Label></strong>&nbsp;</p>
    <p>
        <strong>Page Name<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></strong></p>
    <p>
        <strong>HTML Code<br />
            <asp:TextBox ID="TextBox2" runat="server" Font-Names="monospace" Height="250px" TabIndex="1"
                TextMode="MultiLine" Width="626px" Wrap="False">&lt;!DOCTYPE HTML PUBLIC &quot;-//W3C//DTD HTML 4.01 Transitional//EN&quot;
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
            <asp:Button ID="Button1" runat="server" Text="Save" TabIndex="2" />
            <asp:Button ID="Button3" runat="server" Text="Save and Exit" TabIndex="3" UseSubmitBehavior="False" />
            <asp:Button ID="Button2" runat="server" Text="Discard and Exit" UseSubmitBehavior="False" TabIndex="4" /></strong></p>
</asp:Content>

