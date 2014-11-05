<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="NewsSystem.Admin.Articles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:listview runat="server"  ID="ListViewArticles"
                  ItemType="NewsSystem.Models.Article" DataKeyNames="ID"
                  SelectMethod="ListViewArticles_GetData"
                  UpdateMethod="ListViewArticles_UpdateItem"
                  DeleteMethod="ListViewArticles_DeleteItem"
                  OnSorting="ListViewArticles_Sorting">
        <EmptyDataTemplate>
            <tr>
                <td>No Items</td>
            </tr>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <div class="row">
                <asp:LinkButton ID="lnkTitle" runat="server" CommandName="Sort" CommandArgument="Title" CssClass="btn btn-default">
                    Sort by Title
                </asp:LinkButton>
                <asp:LinkButton ID="lnkDate" runat="server" CommandName="Sort" CommandArgument="DateCreated" CssClass="btn btn-default">
                    Sort by Date
                </asp:LinkButton>
                <asp:LinkButton ID="lnkCategory" runat="server" CommandName="Sort" CommandArgument="Category.Name" CssClass="btn btn-default">
                    Sort by Category
                </asp:LinkButton>
                <asp:LinkButton ID="lnkLikes" runat="server" CommandName="Sort" CommandArgument="Likes.Count" CssClass="btn btn-default">
                    Sort by Likes
                </asp:LinkButton>
            </div>
            <div class="row">
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </div>
            <div>
                <asp:DataPager ID="DataPagerArticles" runat="server" PagedControlID="ListViewArticles" PageSize="5">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="False" ShowPreviousPageButton="True" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="True" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <h3>
                <%#: Item.Title %>
                <asp:Button CommandName="Edit" Text="Edit" runat="server"  CssClass="btn btn-info"/>
                <asp:Button CommandName="Delete" Text="Delete" runat="server" CssClass="btn btn-danger"/>
            </h3>
            <p>Category: <%#: Item.Category.Name %></p>
            <p>
            <%# Truncate(Item.Content, 300) %>
            </p>
            <p>Likes count: <%#: Item.Likes.Count %></p>
            <div>
                <i>by <%#: Item.Author.UserName %></i>
                <i>created on: <%#: Item.DateCreated %></i>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="row">
                <asp:TextBox runat="server" ID="tbTitleEdit" name="tbTitleEdit" placeholder="Title" CssClass="form-control col-md-8" Text='<%#: BindItem.Title %>'></asp:TextBox>
                <asp:Button ID="UpdateButton" CommandName="Update" Text="Save" runat="server" CssClass="btn btn-success" OnClick="UpdateButton_Click" />
                <asp:Button CommandName="Cancel" Text="Cancel" runat="server" CssClass="btn btn-danger" />
            </div>
            <div class="form-group">
                <div class="col-lg-4">
                    <asp:DropDownList ID="ddlCategories" runat="server" DataTextField="Name" DataValueField="ID" AppendDataBoundItems="True"  SelectedValue="<%#: BindItem.CategoryID %>" SelectMethod="GetCategories" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
            <asp:TextBox TextMode="MultiLine" runat="server" ID="tbContentEdit" name="tbContentEdit" placeholder="Content" CssClass="form-control" Text='<%#: BindItem.Content %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:listview>
    <asp:UpdatePanel runat="server" ChildrenAsTriggers="true" UpdateMode="conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-offset-11" id="btnForNewArticle" runat="server">
                    <asp:LinkButton Text="Insert new Article" ID="LinkButtonInsert" runat="server" OnClick="LinkButtonInsert_Click" CssClass="btn btn-info"/>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="UpdatePanelInsertArticle" CssClass="panel" ChildrenAsTriggers="true" UpdateMode="conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="LinkButtonInsert" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:FormView runat="server" ID="FormViewInsertArticle" DefaultMode="Insert" ItemType="NewsSystem.Models.Article"
                          InsertMethod="FormViewIsertArticle_InsertItem" Visible="false">
                <InsertItemTemplate>
                    <h2>Create New Article</h2>
                    <div class="form-group">
                        <span>Title:</span>
                        <asp:TextBox runat="server" ID="TextBoxArticleTitleCreate" CssClass="form-control" placeholder="Enter article title ..." Text=" <%#: BindItem.Title %>">
                        </asp:TextBox>
                    </div>
                    <div class="form-group">
                        <span>Category:</span>
                        <asp:DropDownList runat="server" ID="DropDownListCategoriesCreate" DataTextField="Name"
                                          DataValueField="ID" ItemType="NewsSystem.Models.Category" CssClass="form-control"
                                          SelectedValue="<%#: BindItem.CategoryID %>" SelectMethod="DropDownListCategoriesCreate_GetData">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <span>Content:</span>
                        <asp:TextBox TextMode="MultiLine" CssClass="form-control" runat="server" ID="TextBoxContentCreate" placeholder="Enter article content ..." Text=" <%#: BindItem.Content %>">
                        </asp:TextBox>
                    </div>
                    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="btn btn-success" Text="Insert" CommandName="Insert" OnClick="LinkButtonCreate_Click"  />
                    <asp:LinkButton runat="server" ID="LinkButtonCancel" CssClass="btn btn-danger" Text="Cancel" CommandName="Cancel" PostBackUrl="~/Admin/Articles.aspx" />
                </InsertItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
