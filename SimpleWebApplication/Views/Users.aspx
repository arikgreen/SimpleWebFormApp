<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="SimpleWebApplication.Views.Users" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Users List</h1>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gridUserList" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID"
                CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gridUserList_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="30" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <%--<asp:SqlDataSource ID="SimpleAppSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SimpleAppDbConnectionString %>" SelectCommand="SELECT [UserID], [Name], [Email], [FirstName], [LastName] FROM [Users]"></asp:SqlDataSource>--%>
        </div>
        <div style="margin-top: 1rem;">
            <asp:Button ID="btnNewUser" runat="server" Text="New User" OnClick="BtnNewUser_Click" />&nbsp;
            <asp:Button ID="btnEditUser" runat="server" Text="Edit User" OnClick="BtnEditUser_Click" />&nbsp;
            <asp:Button ID="btnDeleteUser" runat="server" Text="Delete User" OnClick="BtnDeleteUser_Click" />
        </div>
    </form>
</body>
</html>
