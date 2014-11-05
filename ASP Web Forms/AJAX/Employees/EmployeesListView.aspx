<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesListView.aspx.cs" Inherits="Employees.EmployeesListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager" runat="server" />
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" class="panel" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:listview runat="server"  ID="ListViewEmployees"
                                      ItemType="Employees.Employee" SelectMethod="ListViewEmployees_GetData" DataKeyNames="EmployeeID"
                                      InsertItemPosition="LastItem" UpdateMethod="ListViewEmployees_UpdateItem" InsertMethod="ListViewEmployees_InsertItem">
                            <EmptyDataTemplate>
                                <tr>
                                    <td>No Items</td>
                                </tr>
                            </EmptyDataTemplate>
                            <LayoutTemplate>
                                <table>
                                    <tr>
                                        <th></th>
                                        <th></th>
                                        <th>
                                            <asp:LinkButton ID="lnkFirstName" runat="server" CommandName="Sort" CommandArgument="FirstName">
                                                First name
                                            </asp:LinkButton>
                                        </th>
                                        <th>
                                            <asp:LinkButton ID="lnkLastName" runat="server" CommandName="Sort" CommandArgument="LastName">
                                                Last name
                                            </asp:LinkButton>
                                        </th>
                                    </tr>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                </table>
                                <div>
                                    <asp:DataPager ID="DataPagerEmployees" runat="server" PagedControlID="ListViewEmployees" PageSize="3">
                                        <Fields>
                                            <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" />
                                            <asp:NumericPagerField />
                                            <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Button CommandName="Edit" Text="Edit" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button CommandName="Select" Text="Select" runat="server" />
                                    </td>
                                    <td><%#: Item.FirstName %></td>
                                    <td><%#: Item.LastName %></td>
                                </tr>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Button CommandName="Update" Text="Update" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button CommandName="Cancel" Text="Cancel" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="tbFirstNameEdit" name="tbFirstNameEdit" placeholder="First name" CssClass="form-control" Text='<%#: BindItem.FirstName %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="tbLastNameEdit" name="tbLastNameEdit" placeholder="First name" CssClass="form-control" Text='<%#: BindItem.LastName %>'></asp:TextBox>
                                    </td>
                                </tr>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Button CommandName="Insert" Text="Insert" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button CommandName="Cancel" Text="Cancel" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="tbFirstName" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="tbLastName" />
                                    </td>
                                </tr>
                            </InsertItemTemplate>
                            <SelectedItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Button CommandName="Edit" Text="Edit" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button CommandName="Select" Text="Select" runat="server" />
                                    </td>
                                    <td><%#: Item.FirstName %></td>
                                    <td><%#: Item.LastName %></td>
                                </tr>
                            </SelectedItemTemplate>
                        </asp:listview>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server">
                <ProgressTemplate>
                    <asp:Image ImageUrl="http://www.ictbookings.com/images/updating.gif" runat="server" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanelEmployeeOrders" runat="server" class="panel" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ListViewEmployees" EventName="SelectedIndexChanged" />
                </Triggers>
                <ContentTemplate>
                    <asp:GridView ID="GridViewOrders" runat="server" AllowPaging="True" AllowSorting="True"
                                  AutoGenerateColumns="False" DataSourceID="OrdersEntityDataSource">
                        <Columns>
                            <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID" />
                            <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" ReadOnly="True" SortExpression="OrderDate" />
                            <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" ReadOnly="True" SortExpression="ShipCountry" />
                            <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" ReadOnly="True" SortExpression="ShipCity" />
                            <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" ReadOnly="True" SortExpression="ShippedDate" />
                        </Columns>
                    </asp:GridView>
                    <asp:EntityDataSource ID="OrdersEntityDataSource" runat="server" ConnectionString="name=NorthwindEntities"
                                          DefaultContainerName="NorthwindEntities" EnableFlattening="False"
                                          EntitySetName="Orders" EntityTypeFilter="Order" 
                                          Select="it.[EmployeeID], it.[OrderID], it.[OrderDate], it.[ShippedDate], it.[ShipCity], it.[ShipCountry]"
                                          OrderBy="it.[OrderID]" Where="it.EmployeeID = @EmployeeID">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="ListViewEmployees" Type="Int32" Name="EmployeeID" />
                        </WhereParameters>
                    </asp:EntityDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
    </body>
</html>
