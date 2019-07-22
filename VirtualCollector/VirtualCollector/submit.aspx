<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="submit.aspx.cs" Inherits="VirtualCollector.submit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Problem:<br />
            <asp:DropDownList ID="DropDownListProblems" runat="server">
                <asp:ListItem>A</asp:ListItem>
                <asp:ListItem>B</asp:ListItem>
                <asp:ListItem>C</asp:ListItem>
                <asp:ListItem>D</asp:ListItem>
                <asp:ListItem>E</asp:ListItem>
                <asp:ListItem>F</asp:ListItem>
                <asp:ListItem>G</asp:ListItem>
                <asp:ListItem>H</asp:ListItem>
                <asp:ListItem>I</asp:ListItem>
                <asp:ListItem>J</asp:ListItem>
                <asp:ListItem>K</asp:ListItem>
                <asp:ListItem>L</asp:ListItem>
                <asp:ListItem>M</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Code:<br />
            <asp:TextBox ID="TextboxCode" runat="server" TextMode="MultiLine" Height="357px" MaxLength="50000" Width="634px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
            <br />
            <br />
            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClick="ButtonDelete_Click" Visible="False" />
            <br />
            <br />
            <asp:Label ID="LabelUsrName" runat="server" Text="Label" Visible="False"></asp:Label>
            <br /><br />
            <h1><a href="board.aspx">榜单</a></h1>
            </h3>
        </div>
    </form>
</body>
</html>
