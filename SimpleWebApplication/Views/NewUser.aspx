<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="SimpleWebApplication.Views.NewUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New User</title>
    <style>
        input[type=text] {width: 250px;}
    </style>
</head>
<body>
    <h1>New User</h1>
    <form id="form1" runat="server">
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
            <asp:Button ID="btnInsert" runat="server" CausesValidation="True" Text="Insert" OnClick="BtnInsert_Click" />
            &nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" OnClick="BtnCancel_Click" />
        </div>
    </form>
</body>
</html>
