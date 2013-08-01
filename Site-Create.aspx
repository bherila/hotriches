<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Site-Create.aspx.vb" Inherits="Site_Create" title="HotRiches :: Add New URL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Add New URL</h1>
<p>
    The HotRiches AutoHits system will send lots of hits to the URL you specify here.
    Each visitor will see your site for 30 seconds before moving on to another. Your
    page can be about anything, but must adhere to a certain set of rules.</p>
    <ul>
        <li>Your page cannot contain adult content.</li><li>Your page cannot be hate-related or inappropriate for anyone of any age.</li><li>Your page must not break out of frames.</li></ul>
    <p>
        If your page meets the above criteria, you may add it to the system. When you click
        continue, we will automatically check your page to make sure it conforms to our
        rules.</p>
    <p>
        <strong>We will re-check your page as many as 8 times per day to ensure that it still
            follows our rules. If your site is found to break the rules after acceptance, it
            will be disabled and you will be penalized 1,000 page view credits.</strong></p>
    <p>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Label"
            Visible="False"></asp:Label>&nbsp;</p>
    <p>
        <strong>Page Name</strong> (for internal display purposes)<br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></p>
    <p>
        <strong>Page URL<br />
            <asp:TextBox ID="txtURL" runat="server"></asp:TextBox></strong></p>
    <p>
        <strong>
            <asp:Button ID="Button1" runat="server" Text="Continue" /></strong>&nbsp;</p>
</asp:Content>

