<%@ Page Title="Summator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summator.aspx.cs" Inherits="SummatorInASPWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Summator</h1>
    <div class="form-group">
        <asp:Label ID="lblFirstNumber" runat="server" Text="First Number"></asp:Label>
        <asp:TextBox ID="tbFirstNumber" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="lblSecondNumber" runat="server" Text="Second Number"></asp:Label>
        <asp:TextBox ID="tbSecondNumber" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:Button ID="btnSum" runat="server" Text="Sum" OnClick="btnSum_Click" CssClass="btn btn-info" />
    <div class="form-group">
        <asp:Label ID="lblResult" runat="server" Text="Result"></asp:Label>
        <asp:TextBox ID="tbResult" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
</asp:Content>
