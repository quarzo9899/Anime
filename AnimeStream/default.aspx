<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AnimeStream._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/bootstrap-theme.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap-theme.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="Style/stile.css" />
 
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.js"></script>

    <meta id="vp" name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="header navbar">
            <img class="img-fluid" alt="" src="img/qr.png" style="max-height: 120px;" />
            <img class="img-fluid" alt="" src="img/scritta.png" style="max-height: 100px;" />
            <h1 style="color:white; font-family:'Eras ITC'; font-size:80px;">ANIME</h1>
        </div>
        <br />
        <div class="container text-center">

            <div class="jumbotron search">
                <div class="row text-center">
                    <div class="col-md-10"><h1 style="color:white; font-family:Arial;">Insersici l'iniziale dell'anime che vuoi guardare</h1></div>
                    <div class="col-md-2"><asp:TextBox ID="AnimeIniziale" runat="server" MaxLength="1" OnTextChanged="AnimeIniziale_TextChanged" AutoPostBack="true" CssClass="form-control box"/></div>
                </div>
                
            </div>
        </div>
        <br />
        <div class="container-fluid" runat="server">
             <asp:Literal ID="ltl_gallery" runat="server"></asp:Literal>
        </div>
           
            <asp:DropDownList ID="AnimeLista" runat="server" OnTextChanged="AnimeLista_TextChanged" AutoPostBack="true" />
            <br />
            <asp:DropDownList ID="AnimeTipo" runat="server" AutoPostBack="true" OnTextChanged="AnimeTipo_TextChanged" />
            <br />
            <asp:DropDownList ID="AnimeEpisodio" runat="server" AutoPostBack="true" />
            <br />
            <br />
            <asp:Button ID="BtnStream" runat="server" Text="Play" OnClick="BtnStream_Click" />

        
    </form>

    <script type="text/javascript">
        function Image_click(img) {
            var id = img.id;
            window.location.replace("Anime.aspx?id=" + id);
        }
    </script>
</body>
</html>
