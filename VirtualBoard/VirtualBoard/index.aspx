<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="VirtualBoard.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="40" Width="819px">
                <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="submit_author" HeaderText="Author" />
                    <asp:BoundField DataField="submit_problem" HeaderText="Problem" />
                    <asp:BoundField DataField="judge_status" HeaderText="Status" />
                    <asp:BoundField DataField="judge_remoteid" HeaderText="RemoteID" />
                    <asp:BoundField DataField="submit_time" HeaderText="UploadTime" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <br />
        </div>
        <div>
            <center>
            <iframe ID="ifr1" src="" runat="server" style="height: 900px; width: 95%; text-align: center; margin-top: 0px;" hspace="-100" ></iframe>
            <iframe ID="ifr2" src="" runat="server" style="height: 900px; width: 95%; text-align: center; margin-top: 0px;" hspace="-100" ></iframe>
            </center>
        </div>
    </form>
</body>
</html>
