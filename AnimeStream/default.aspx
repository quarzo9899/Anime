<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AnimeStream._default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/bootstrap-theme.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap-theme.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="Style/stile.css" />
    <link rel="shortcut icon" type="image/x-icon" href="img/pageicon.ico" />
 
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.js"></script>
    <script type="text/javascript">
        function Image_click(img) {
            var vars = {};
            var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
                vars[key] = value;
            });
            var id = img.id;
            var style = "top=200, left=200, width=520, height=600, status=no, menubar=no, resizable=no, toolbar=no, scrollbars=yes";
            var url = "Anime.aspx?animeInfo=" + id + "&connectionID=" + vars["connectionID"] + "&cookieValue=" + vars["cookieValue"];
            window.open(url, "", style);
        }
    </script>
    <meta id="vp" name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>QuaRzo Anime</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">
            <div class="content">
                <div class="header navbar">
                    <img class="img-fluid" alt="" src="img/qr.png" style="max-height: 130px;" />
                    <img class="img-fluid img-mid" alt="" src="img/scritta.png" style="max-height: 100px;" />
                    <h1 class="title-left">ANIME</h1>
                </div>
                <br />
                <div class="container text-center">
                    <div class="jumbotron search">
                        <div class="row text-center">
                            <div class="col-md-10">
                                <h1 class="h1-src" style="">Insersici l'iniziale dell'anime che vuoi guardare</h1>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="AnimeIniziale" runat="server" MaxLength="1" OnTextChanged="AnimeIniziale_TextChanged" AutoPostBack="true" CssClass="form-control box" />
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="container-fluid" runat="server">
                    <asp:Literal ID="ltl_gallery" runat="server"></asp:Literal>
                </div>
            </div>
            <footer>
                <hr />
                <div class="container text-center">
                    Designed by QuaRzo<br />
                    Copyright © All rights reserved<br />
                    <br />
                </div>
            </footer>
        </div>   
    </form>
</body>
</html>
