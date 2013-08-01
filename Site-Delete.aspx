<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Site-Delete.aspx.vb" Inherits="Site_Delete" title="HotRiches :: Delete Site" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Confirm URL Delete</h1>
<p>Are you sure you want to permanently remove this URL from your account? If you are,
    please type "yes" into the box below.</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Width="68px"></asp:TextBox>&nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Continue" />
        <asp:Button ID="Button2" runat="server" Text="Cancel" UseSubmitBehavior="False" /></p>

</asp:Content>

