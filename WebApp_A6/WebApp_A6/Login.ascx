<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="WebApp_A6.Login" %>

<table id="MyTable" cellpadding="4" runat="server">
    <tr>
        <td>User Name:</td>
        <td>
            <asp:TextBox ID="usernameEntry" runat="server" />
        </td>
    </tr>
    <tr>
        <td>Password:</td>
        <td>
            <asp:TextBox ID="passwordEntry" TextMode="password" runat="server" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="LogInButton" runat="server" Text="Log In" OnClick="LogInButton_Click" /></td>
    </tr>
</table>

<script language="C#" runat="server">
    public string UserName
    {
        get { return usernameEntry.Text; }
        set { usernameEntry.Text = value; }
    }
    public string Password
    {
        get { return passwordEntry.Text; }
        set { passwordEntry.Text = value; }
    }
</script>
