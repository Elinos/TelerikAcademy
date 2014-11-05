<%@ Page Title="Random Number" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RandomNumber.aspx.cs" Inherits="WebControls.RandomNumber" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <strong>With HTML Server Controls <br /></strong>
        <label for="tbMin">Min:</label>
        <input type="text" value="" runat="server" id="tbMin" />
        <label for="tbMax">Max:</label>
        <input type="text" value="" runat="server" id="tbMax"/>
        <input type="button" value="Get Random Number" runat="server" id="btnRandom" onserverclick="GetRandomNumber"/>
        <div>
            <span><strong>Result: </strong></span>
            <span runat="server" id="result"></span>
        </div>
    </div>
    <br />
    <div>
        <strong>With Web Server Controls <br /></strong>
        <asp:Label Text="Min:" runat="server" Font-Bold="true" />
        <asp:TextBox runat="server"  id="tbMinWeb"/>
        <asp:Label Text="Max:" runat="server" Font-Bold="true"/>
        <asp:TextBox runat="server"  id="tbMaxWeb"/>
        <asp:Button Text="Get Random Number" runat="server" ID="btnRandomWeb" OnClick="BtnRandomWebClick"/>
        <div>
            <span><strong>Result: </strong></span>
            <asp:Literal Text="" runat="server" ID="resultWeb" />
        </div>
    </div>
</asp:Content>
