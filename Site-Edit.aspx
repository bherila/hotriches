<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Site-Edit.aspx.vb" Inherits="Site_Edit" title="HotRiches :: Edit Site" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Edit URL</h1>
<p>You cannot change the URL of this page reference, but you can rename it. If you need to change the URL, you will need to <a href="Site-Delete.aspx?id=<%= Request("id") %>">delete this site</a>.</p>
    <p>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Label"
            Visible="False"></asp:Label>&nbsp;</p>
    <p>
        <strong>Page Name<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></strong></p>
    <p>
        <asp:CheckBox ID="CheckBox1" runat="server" Font-Bold="True" Text="Enabled" /><br />
        This URL will only receive traffic from HotRiches if the box above is checked.</p>
    <p>
        <strong>
            <asp:Button ID="Button1" runat="server" Text="Save" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" UseSubmitBehavior="False" /></strong></p>
</asp:Content>

