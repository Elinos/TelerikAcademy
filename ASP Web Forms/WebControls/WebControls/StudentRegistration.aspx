<%@ Page Title="Student Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="WebControls.StudentRegistration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>Student Registration</h2>
    </div>
    <div class="row">
        <div class="form-group col-lg-4">
            <asp:Label Text="First Name" runat="server" ID="lblFirstName" />
            <asp:TextBox runat="server" ID="tbFirstName" CssClass="form-control"/>
        </div>
        <div class="col-lg-8">
            <asp:Panel runat="server" ID="panelSummary"></asp:Panel>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-lg-4">
            <asp:Label Text="Last Name" runat="server" ID="lblLastName" />
            <asp:TextBox runat="server" ID="tbLastName" CssClass="form-control"/>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-lg-4">
            <asp:Label Text="Faculty Number" runat="server" ID="lblFacultyNumber" />
            <asp:TextBox runat="server" ID="tbFacultyNumber" CssClass="form-control"/>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-lg-4">
            <asp:Label Text="University" runat="server" ID="lblUniversity" />
            <asp:DropDownList runat="server" ID="ddlUniversity" CssClass="form-control">
                <asp:ListItem Text="UNSS" />
                <asp:ListItem Text="NBU" />
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-lg-4">
            <asp:Label Text="Specialty" runat="server" ID="lblSpecialty" />
            <asp:DropDownList runat="server" ID="ddlSpecialty" CssClass="form-control">
                <asp:ListItem Text="Software Development" />
                <asp:ListItem Text="Economy" />
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-lg-4">
            <asp:Label Text="Courses" runat="server" ID="lblCourses"  />
            <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbCourses" CssClass="form-control">
                <asp:ListItem Text="Javascript" />
                <asp:ListItem Text="C#" />
                <asp:ListItem Text="Marketing" />
            </asp:ListBox>
        </div>
    </div>
    <asp:Button Text="Register" runat="server" ID="btnRegister" OnClick="btnRegister_Click" CssClass="btn btn-info"/>
</asp:Content>