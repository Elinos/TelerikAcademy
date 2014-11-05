<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1><%: this.Title %></h1>
        <h2>Most popular articles</h2>
    </div>

    <asp:ListView runat="server" ID="ListViewArticles" ItemType="NewsSystem.Models.Article" SelectMethod="ListViewArticles_GetData">
        <LayoutTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <h3>
                <asp:HyperLink NavigateUrl='<%# string.Format("~/ArticleDetails.aspx?id={0}", Item.ID) %>' runat="server" Text='<%#: Item.Title %>' /> <small><%#: Item.Category.Name %></small>
            </h3>
            <p>
            <%# Truncate(Item.Content, 300) %>
            </p>
            <p>Likes: <%#: Item.Likes.Count %></p>
            <div>
                <i>by <%#: Item.Author.UserName %></i>
                <i>created on: <%#: Item.DateCreated %></i>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <h2>All categories</h2>
    <asp:ListView runat="server" ID="ListViewCategories" ItemType="NewsSystem.Models.Category" SelectMethod="ListViewCategories_GetData">
        <LayoutTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <h3><%#: Item.Name %></h3>
                <asp:ListView runat="server" ID="LisViewCategoryArticles" DataSource="<%# GetArticles(Item.ID) %>" ItemType="NewsSystem.Models.Article">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <a runat="server" href='<%# string.Format("~/ArticleDetails.aspx?id={0}", Item.ID) %>'>
                                <strong runat="server"><%#: Item.Title %></strong> <i> by <%#: Item.Author.UserName %></i>
                            </a>
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No articles.
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
