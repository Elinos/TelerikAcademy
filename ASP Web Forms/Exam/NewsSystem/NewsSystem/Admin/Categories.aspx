<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="NewsSystem.Admin.Categories" %>
<asp:Content ID="CategoriesContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:listview runat="server"  ID="ListViewCategories"
                  ItemType="NewsSystem.Models.Category" SelectMethod="ListViewCategories_GetData" DataKeyNames="ID"
                  InsertItemPosition="LastItem" UpdateMethod="ListViewCategories_UpdateItem" InsertMethod="ListViewCategories_InsertItem"
                  DeleteMethod="ListViewCategories_DeleteItem">
        <EmptyDataTemplate>
            <tr>
                <td>No Items</td>
            </tr>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <asp:LinkButton ID="lnkName" runat="server" CommandName="Sort" CommandArgument="Name" CssClass="btn btn-default">
                Sort by Name
            </asp:LinkButton>
            <table>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </table>
            <div>
                <asp:DataPager ID="DataPagerCategories" runat="server" PagedControlID="ListViewCategories" PageSize="5">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" ShowPreviousPageButton="True" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="True" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.Name %></td>
                <td>
                    <asp:Button CommandName="Edit" Text="Edit" runat="server"  CssClass="btn btn-info"/>
                </td>
                <td>
                    <asp:Button CommandName="Delete" Text="Delete" runat="server" CssClass="btn btn-danger"/>
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="tbNameEdit" name="tbNameEdit" placeholder="Name" CssClass="form-control" Text='<%#: BindItem.Name %>'></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="EditButton" CommandName="Update" Text="Save" runat="server" CssClass="btn btn-success" OnClick="EditButton_Click" />
                </td>
                <td>
                    <asp:Button CommandName="Cancel" Text="Cancel" runat="server" CssClass="btn btn-danger" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="tbName" />
                </td>
                <td>
                    <asp:Button ID="InsertButton" CommandName="Insert" Text="Save" runat="server"  CssClass="btn btn-info" OnClick="InsertButton_Click"/>
                </td>
                <td>
                    <asp:Button CommandName="Cancel" Text="Cancel" runat="server" CssClass="btn btn-danger" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:listview>
</asp:Content>
