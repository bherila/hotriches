<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Signup.aspx.vb" Inherits="Signup" title="HotRiches :: Sign Up" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Sign up for HotRiches</h1>
<p>
    We've made this process as simple and painless as possible. All we need is your
    full name and e-mail address, and you're done! Your password will be e-mailed to
    you, and you can change it once you log in.</p>
    <p>
        <strong>First and Last Name</strong><br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
            ID="valName" runat="server" ErrorMessage="Your full name is required." ControlToValidate="txtName" SetFocusOnError="True"></asp:RequiredFieldValidator></p>
    <p>
        <strong>E-Mail Address</strong><br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>&nbsp;<asp:CustomValidator
            ID="valEmail" runat="server" ErrorMessage="This e-mail cannot be used."></asp:CustomValidator></p>
    <p>
        <asp:Button ID="btnSubmit" runat="server" Text="Create Account" />&nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

