<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cookies.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Label Text="Please log in!" runat="server" ID="LabelLogin" />
                <asp:Button Text="Login" runat="server" ID="ButtonLogin" OnClick="ButtonLogin_Click" />
            </div>
        </form>
    </body>
</html>
