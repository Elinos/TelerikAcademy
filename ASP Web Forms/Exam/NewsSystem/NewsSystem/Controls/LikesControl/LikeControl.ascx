<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LikeControl.ascx.cs" Inherits="LikesDemo.Controls.LikeControl" %>
<asp:UpdatePanel runat="server" ID="UpdatePanelLikes" CssClass="panel" ChildrenAsTriggers="true" UpdateMode="conditional">
    <ContentTemplate>
        <div class="like-control col-md-1">
            <div>Likes</div>
            <div>
                <asp:Button runat="server" ID="ButtonLike" Text="⇧" CommandName="Like" CommandArgument="<%# this.DataID %>" OnCommand="ButtonLike_Command" CssClass="btn btn-default glyphicon glyphicon-chevron-up" />
                <asp:Label runat="server" ID="LableLikesCount" CssClass="like-value"/>
                <asp:Button runat="server" ID="ButtonHate" Text="⇩" CommandName="Hate" CommandArgument="<%# this.DataID %>" OnCommand="ButtonLike_Command" CssClass="btn btn-default glyphicon glyphicon-chevron-down" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
