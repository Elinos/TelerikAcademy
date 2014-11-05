<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Browser.aspx.cs" Inherits="Browser.Browser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <div>
                    Your Browser is:
                    <asp:Label Text="" runat="server" ID="LabelBrowser" />
                </div>
                <div>
                    Your IP Address is:
                    <asp:Label Text="" runat="server" ID="LabelIpAddress" />
                </div>
            </div>
        </form>
    </body>
</html>
