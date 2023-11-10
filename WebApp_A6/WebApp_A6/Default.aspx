<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp_A6._Default" %>
<%@ Register TagPrefix="login" TagName="LoginControl" src="~/Login.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
       <h3>Information Hub</h3>
        <p>The purpose of this web application is to serve as a one stop shop for a user's inquiries.</p>
        <h3>TODO:</h3>
       <ul>
           <li>Implement account management</li>
           <li>Describe overall web app functionality</li>
           <li>How users can subscribe (point to member page?</li>
       </ul>

        <h3><asp:Label ID="Output" runat="server" /></h3>
    </main>

</asp:Content>
