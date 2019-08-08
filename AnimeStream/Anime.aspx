<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anime.aspx.cs" Inherits="AnimeStream.Anime1" EnableEventValidation="False" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            Episodi
            <asp:DropDownList ID="ddl_tipo" runat="server" Height="16px" Width="119px" OnTextChanged="ddl_tipo_TextChanged" AutoPostBack="true">
            </asp:DropDownList>
        </div>
        <asp:GridView ID="ListGrid" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="335px" OnRowCommand="ListGrid_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("id") %>' ImageUrl='<%# Eval("thumb") %>' Width="50px" CommandName="play" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="title" HeaderText="Titolo" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
    </form>
</body>
</html>
