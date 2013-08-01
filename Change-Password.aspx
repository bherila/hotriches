<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Change-Password.aspx.vb" Inherits="Change_Password" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Change Password</h1>
<p>
    <strong>
        <asp:Label ID="mc" runat="server" ForeColor="Brown" Text="Your passwords do not match!"
            Visible="False"></asp:Label></strong>&nbsp;</p>
    <p>
        <strong>New Password<br />
        </strong>
        <asp:TextBox ID="p1" runat="server" TextMode="Password"></asp:TextBox></p>
    <p>
        <strong>Confirm New Password<br />
        </strong>
        <asp:TextBox ID="p2" runat="server" TextMode="Password"></asp:TextBox></p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="OK" Width="75px" />
        <asp:Button ID="Button2" runat="server" Text="Cancel" UseSubmitBehavior="False" Width="75px" /></p>
</asp:Content>

