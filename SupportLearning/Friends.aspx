<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="SupportLearning.Friends" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Friends Management</title>
    <style>
        .relationship-item {
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnShowFriends" runat="server" Text="Hiển thị bạn bè" OnClick="btnShowFriends_Click" />
            <asp:Button ID="btnShowNotFriends" runat="server" Text="Hiển thị chưa là bạn bè" OnClick="btnShowNotFriends_Click" />
            <asp:Label ID="lblResult" runat="server" Font-Bold="true"></asp:Label>
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                    <div class="relationship-item">
                        <strong><%# Eval("UserName") %></strong> - 
                        <span><%# Eval("FriendCode") %></span> - 
                        <span><%# Eval("RelationshipStatus") %></span>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
