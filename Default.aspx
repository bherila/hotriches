<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="HotRiches :: The Internet Traffic Machine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="664" cellpadding="0" cellspacing="0" border="0">
<tr>
<td align="left" valign="top" style="padding-right: 10px;">
        <asp:Panel ID="pl" runat="server" BackColor="OldLace" BorderColor="#C00000" BorderStyle="Solid"
            BorderWidth="2px" Height="50px" Width="447px" Visible="False">
        <asp:Label ID="lblNo" runat="server" Text="<b>Your login failed. </b><br>Did you forget your password? If so, just enter your e-mail address, leaving the password field blank, and we'll e-mail your password to you."
            Visible="False" Width="100%"></asp:Label><asp:Label ID="lblNoExist" runat="server"
                Text="<b>Your login failed.</b><br>The e-mail you entered has not been registered in our database."
                Visible="False" Width="100%"></asp:Label>
        <asp:Label ID="lblEmailed" runat="server" Text='<b>Forgot your password?</b><br>We have e-mailed your password to you.'
            Visible="False" Width="100%"></asp:Label></asp:Panel>
    <p>
        Tired of all the AutoHits programs that don't work? Do you want real traffic
       on your site? HotRiches can help!</p>
    <p>
        HotRiches has an advanced new system that automatically checks and approves your
        pages. All kinds of ads are allowed, but adult content is not. If you don't have a web host, that's fine - <strong>we'll host your page for you FREE!</strong></p>
<ul>
    <li>Make money while you sleep with <a href="http://www.bombness.com/ben/pt.htm"
        target="_blank">advertisements</a>.</li>
    <li>View pages in a secure environment. HotRiches automatically blocks all sorts of
        malicious content.</li>
    <li>Generous 4:5 credit ratio.</li>
    <li>30 second timer ensures your pages always load.</li>
</ul>
    <p>
        You can view pages on HotRiches through the traditional web browser interface, or
        download our secure viewer that <strong>automatically blocks popups, active-x controls,
            java applets, flash, background sounds, and more!</strong>
    </p>
    <p>
        And, with the <strong>HotRiches Screensaver</strong>, you can view sites and earn
        credits while you're away from your computer! (Coming soon)&nbsp;</p>
    <p align="center"><b>So what are you waiting for?</b></p>        
    <p align="center" style="font-size: 24px; font-weight: bold;"><a href="signup.aspx">Sign Up Now!</a></p>
</td>
<td width="200" align="right" valign="top">
    <table bgcolor="#eeeeee" width="200" cellpadding="5" cellspacing="0" border="0" style="border: 1px solid gray;">
    <tr>
    <td align="center" colspan="2"><b>Members</b></td>
    </tr>
    <tr>
    <td align="center" colspan="2"><p>Please use this form to sign in to your account.</p></td>
    </tr>

    <tr>
    <td align="left" nowrap>
        E-Mail:</td>
    <td align="left"><asp:TextBox ID="txtEmail" runat="server" Width="75px"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="left" nowrap>Password:</td>
    <td align="left"><asp:TextBox ID="txtPassword" runat="server" Width="75px" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
    <td>&nbsp;</td>
    <td align="left">
    <p><asp:Button runat="server" text="Log In" ID="btnLogIn" UseSubmitBehavior="True" />&nbsp;</p></td>
    </tr>

    </table>
    <br />
    <table bgcolor="#eeeeee" width="200" cellpadding="5" cellspacing="0" border="0" style="border: 1px solid gray;">
    <tr>
    <td width="200" align="center" colspan="2"><b>New Users</b></td>
    </tr>
    <tr>
    <td align="center" colspan="2"><p>HotRiches is a free service! Click the link below to sign up now.</p>
    <p><a href="signup.aspx" target="_top"><b>Sign Up Now!</b></a></p></td>
    </tr>
    </table>
   
</td>
</tr>
</table>
</asp:Content>

