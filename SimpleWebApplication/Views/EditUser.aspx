<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="SimpleWebApplication.Views.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Edit user ID: <asp:Label ID="UserIdLabel" runat="server" Text=""></asp:Label></h1>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Name" />
            <br />
            <asp:TextBox ID="NameTextBox" runat="server" />
            <br />
            <asp:Label ID="EmailLabel" runat="server" Text="Email" />
            <br />
            <asp:TextBox ID="EmailTextBox" runat="server" />
            <br />
            <asp:Label ID="FirstNameLabel" runat="server" Text="FirstName" />
            <br />
            <asp:TextBox ID="FirstNameTextBox" runat="server" />
            <br />
            <asp:Label ID="LastNameLabel" runat="server" Text="LastName" />
            <br />
            <asp:TextBox ID="LastNameTextBox" runat="server" />
            <br /><br />
            <asp:Button ID="btnUpdate" runat="server" CausesValidation="True" Text="Update" OnClick="BtnUpdate_Click" />
            &nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" OnClick="BtnCancel_Click" />
        </div>
    </form>
</body>
</html>
