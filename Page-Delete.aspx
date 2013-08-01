<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Page-Delete.aspx.vb" Inherits="Page_Delete" title="HotRiches :: Delete Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Confirm Page Delete</h1>
<p>Are you sure you want to permanently remove this page from your account? If you are,
    please type "yes" into the box below.</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Width="68px"></asp:TextBox>&nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Continue" />
        <asp:Button ID="Button2" runat="server" Text="Cancel" UseSubmitBehavior="False" /></p>

</asp:Content>

