<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsIntro._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>Enter your name:</div>
    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="ButtonHello" runat="server" 
                onclick="ButtonSayHello_Click" Text="Say Hello" />
    <br />
    <asp:Label ID="LabelGreeting" runat="server"></asp:Label>
</asp:Content>
