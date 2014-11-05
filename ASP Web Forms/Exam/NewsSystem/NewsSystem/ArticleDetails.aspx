<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleDetails.aspx.cs" Inherits="NewsSystem.ArticleDetails" %>

<%@ Register Src="~/Controls/LikesControl/LikeControl.ascx" TagPrefix="uc" TagName="LikeControl" %>

<asp:Content ID="ArticleDetailsContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <LoggedInTemplate>
            <asp:FormView runat="server" ID="FormViewArticleDetails" ItemType="NewsSystem.Models.Article" SelectMethod="FormViewArticleDetails_GetItem">
                <ItemTemplate>
                    <uc:LikeControl runat="server" id="LikeControl"
                                    LikesValue="<%# GetLikesValue(Item) %>"
                                    OnLike="LikeControl_Like"
                                    DataID="<%# Item.ID %>"
                                    UserVote="<%# GetUserVote(Item) %>" />
                    <h2>
                        <%#: Item.Title %><small>Category: <%#: Item.Category.Name %></small>
                    </h2>
                    <p><%#: Item.Content %></p>
                    <p>
                        <span>Author: <%#: Item.Author.UserName %></span>
                        <span class="pull-right"><%#: Item.DateCreated %></span>
                    </p>
                </ItemTemplate>
            </asp:FormView>
        </LoggedInTemplate>
        <AnonymousTemplate>
            <asp:FormView runat="server" ID="FormViewArticleDetails" ItemType="NewsSystem.Models.Article" SelectMethod="FormViewArticleDetails_GetItem">
                <ItemTemplate>
                    <h2>
                        <%#: Item.Title %><small>Category: <%#: Item.Category.Name %></small>
                    </h2>
                    <p><%#: Item.Content %></p>
                    <p>
                        <span>Author: <%#: Item.Author.UserName %></span>
                        <span class="pull-right"><%#: Item.DateCreated %></span>
                    </p>
                </ItemTemplate>
            </asp:FormView>
        </AnonymousTemplate>
    </asp:LoginView>
</asp:Content>
