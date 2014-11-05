<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SavedText.aspx.cs" Inherits="SavedText.SavedText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:TextBox runat="server" ID="TextBoxInput"/>
                <asp:Button Text="Enter" runat="server" ID="ButtonEnter" OnClick="ButtonEnter_Click" />
                <div>
                    <asp:Label Text="" runat="server" ID="LabelOutput"/>
                </div>
            </div>
        </form>
    </body>
</html>
