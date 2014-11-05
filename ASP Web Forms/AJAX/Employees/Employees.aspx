<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Employees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Employees</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager" runat="server" />
            <div>
                <h1>Employees Data:</h1>
                <asp:GridView ID="GridViewEmployees" runat="server" AllowPaging="True" AllowSorting="True"
                              AutoGenerateColumns="False" DataSourceID="EmployeesEntity" DataKeyNames="EmployeeID"
                              OnSelectedIndexChanging="GridViewEmployees_SelectedIndexChanging">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" SortExpression="EmployeeID" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" ReadOnly="True" SortExpression="LastName" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" ReadOnly="True" SortExpression="FirstName" />
                    </Columns>
                </asp:GridView>
                <asp:EntityDataSource ID="EmployeesEntity" runat="server" ConnectionString="name=NorthwindEntities"
                                      DefaultContainerName="NorthwindEntities" EnableFlattening="False" EntitySetName="Employees"
                                      EntityTypeFilter="Employee" Select="it.[EmployeeID], it.[LastName], it.[FirstName]"
                                      OrderBy="it.[EmployeeID]">
                </asp:EntityDataSource>
                <asp:UpdateProgress ID="UpdateProgress" runat="server">
                    <ProgressTemplate>
                        <asp:Image ImageUrl="http://www.ictbookings.com/images/updating.gif" runat="server" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanelEmployeeOrders" runat="server" class="panel" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridViewEmployees" EventName="SelectedIndexChanged" />
                    </Triggers>
                    <ContentTemplate>
                        <h1>Orders Data:</h1>
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
                                <asp:ControlParameter ControlID="GridViewEmployees" Type="Int32" Name="EmployeeID" />
                            </WhereParameters>
                        </asp:EntityDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </body>
</html>
