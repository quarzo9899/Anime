<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anime.aspx.cs" Inherits="AnimeStream.Anime1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/bootstrap-theme.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap-theme.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="Style/stile2.css" />

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta id="vp" name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>

    <style type="text/css">
    .Hide
    {
        display: none;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container-fluid">
            <asp:Label ID="lbl_titolo" runat="server" Text="" CssClass="h1"></asp:Label>
            <hr style="color:white"/><br />
            <div class="row">
                <div class="col-4 text-left"><h3>Episodi:</h3></div>
                <div class="col-8 text-left"><asp:DropDownList ID="ddl_tipo" runat="server" Height="16px" Width="119px" OnTextChanged="ddl_tipo_TextChanged" AutoPostBack="true" CssClass="drop"></asp:DropDownList></div>
            </div>
        </div>
        <br />
        <div class="list container-fluid text-center">
            <asp:GridView ID="ListGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="ListGrid_RowCommand" CssClass="mytab table table-striped table-dark">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("id") + "-" + Eval("epInfo")%>' ImageUrl='<%# Eval("thumb") %>' CommandName="play" Height="90px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="title" HeaderText="Titolo" >
                    <FooterStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        
    </form>

    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.js"></script>

</body>
</html>
