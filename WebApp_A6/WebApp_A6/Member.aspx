<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WebApp_A6.About" %>
<%@ Register TagPrefix="login" TagName="LoginControl" src="~/Login.ascx" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="CheckCookie" runat="server" Text="Label"></asp:Label>
    <asp:MultiView ID="MultiView" runat="server" ActiveViewIndex="0">
        <%-- View Zero --%>
        <asp:View ID="LoginControlWindow" runat="server">
            <login:LoginControl ID="LoginTable" runat="server" />
        </asp:View>
        <%-- View One --%>
        <asp:View ID="AccountManagement" runat="server">
            <asp:Button ID="LogOutButton" runat="server" Text="Log Out" ForeColor="Red" OnClick="LogOutButton_Click"/>
        </asp:View>
        <%-- View Two --%>
        <asp:View ID="EmptyView" runat="server"></asp:View>
    </asp:MultiView>
</asp:Content>