<%@ Page Title="Lifecycle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lifecycle.aspx.cs" Inherits="WebFormsIntro.Lifecycle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="ButtonOK" Text="OK" runat="server"
            OnInit="ButtonOK_Init" OnLoad="ButtonOK_Load" OnClick="ButtonOK_Click"
            OnPreRender="ButtonOK_PreRender" OnUnload="ButtonOK_Unload" />
</asp:Content>
