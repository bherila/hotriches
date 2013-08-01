<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Members.aspx.vb" Inherits="Members" title="HotRiches :: Members Area" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>
        HotRiches Today</h1>
        <ul>
        <li>You have 
            <asp:Literal ID="txtPageViewCreditsRemaining" runat="server"></asp:Literal>&nbsp;page view credits remaining.</li><li>You have 
            <asp:Literal ID="txtBannerCreditsRemaining" runat="server"></asp:Literal>&nbsp;banner credits remaining.</li>
            <li><a href="Change-Password.aspx">Click here to change your password</a></li>
        </ul>
        <h1>Traffic Exchange</h1>
        <ul>
            <li><b>Two Ways to Surf!</b>
            <ol>
            <li>(Recommended) <a href="Download.aspx">Download HotRiches Viewer (spyware free, for windows only)</a> - <a href="Download.aspx">More Info</a></li><li>Your surf URL is Your surf link is <a href="http://www.hotriches.com/ViewAndEarn.aspx?id=<%= Session("id") %>" target="_blank">http://www.hotriches.com/ViewAndEarn.aspx?id=<%= Session("id") %></a>. Be sure to use an ad blocker for optimal surfing!</li></ol>
            </li>
            <li>You have <asp:Literal ID="txtPageViewCreditsRemaining2" runat="server"></asp:Literal> page view credits remaining.</li></ul>
        <asp:Literal runat="server" ID="tblSites"></asp:Literal>
        <h1>Hosted Pages</h1>
        <p>You can store HTML pages (up to 15 KB each) on our servers, and link to them for free.</p>
        <asp:Literal runat="server" ID="tblPages"></asp:Literal>
        <h1>Banner Exchange (Coming Soon)</h1>
        <ul>
            <li>Click here to get your HTML codes</li><li>You have <asp:Literal ID="txtBannerCreditsRemaining2" runat="server"></asp:Literal> banner credits remaining</li></ul>
        <asp:Literal runat="server" ID="tblBanners"></asp:Literal>
        <h1>Referral Center</h1>
        <ul>
            <li>You have <asp:Literal ID="txtRefCount" runat="server"></asp:Literal></li>
            <li>Your referral link is <a href="http://www.hotriches.com?ref=<%= Server.URLEncode(Session("id")) %>">http://www.hotriches.com?ref=<%= Server.URLEncode(Session("id")) %></a></li></ul>
        <asp:Literal runat="server" ID="tblRefs"></asp:Literal>
</asp:Content>

