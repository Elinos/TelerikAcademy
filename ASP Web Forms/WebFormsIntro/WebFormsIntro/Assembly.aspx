<%@ Page Title="Assembly" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Assembly.aspx.cs" Inherits="WebFormsIntro.AssemblyInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Current Assembly:</h2>
    <asp:Label runat="server" ID="LabelAssembly" OnLoad="Assembly_Load"></asp:Label>
</asp:Content>
