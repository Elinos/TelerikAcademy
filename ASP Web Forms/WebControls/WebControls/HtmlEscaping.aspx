<%@ Page Title="Html Escaping" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HtmlEscaping.aspx.cs" Inherits="WebControls.HtmlEscaping" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <strong>Enter text:</strong>
        <asp:TextBox runat="server" ID="tbOne" OnTextChanged="tbOne_TextChanged" AutoPostBack="true"/>
    </div>
    <br />
    <div>
        <strong>Result:</strong>
        <asp:TextBox runat="server" ID="tbResult" />
        <asp:Label Text="" runat="server" ID="lblResult"/>
    </div>
</asp:Content>
