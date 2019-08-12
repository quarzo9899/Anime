using System;
using System.Collections.Generic;
using System.Globalization;

namespace AnimeStream
{
    public partial class _default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Request.QueryString["connectionID"] == null || Request.QueryString["connectionID"] == "" || Request.QueryString["cookieValue"] == null || Request.QueryString["cookieValue"] == "") {
                    List<string> info = VVVID.GetConnectionInfo();
                    Response.Redirect($"default.aspx?connectionID={info[0]}&cookieValue={info[1]}");
                }
                string connectionID = Request.Params["connectionID"];
                string cookieValue = Request.Params["cookieValue"];
                if(!VVVID.TestConnectionInfo(connectionID, cookieValue)) {
                    List<string> info = VVVID.GetConnectionInfo();
                    Response.Redirect($"default.aspx?connectionID={info[0]}&cookieValue={info[1]}");
                }
            }
        }

        protected void AnimeIniziale_TextChanged(object sender, EventArgs e) {
            if (AnimeIniziale.Text == "" || !Char.IsLetter(AnimeIniziale.Text[0]))
                return;
            char c = char.ToLower(AnimeIniziale.Text[0], CultureInfo.InvariantCulture);
            string connectionID = Request.Params["connectionID"];
            string cookieValue = Request.Params["cookieValue"];
            List<Anime> listaAnime = VVVID.AnimeFilter(c, connectionID, cookieValue);
            AggiornaGallery(listaAnime);
        }

        private void AggiornaGallery(List<Anime> listaAnime) {
            string innerhtml = "<div class='row'>";
            for (int i = 0; i < listaAnime.Count; i++)
                innerhtml += $"<div class='col-6 col-sm-4 col-md-3 col-lg-2'><img id='{listaAnime[i].show_id}-{listaAnime[i].title.Replace("'", " ")}' alt = '' src='{listaAnime[i].thumbnail}' class='img-fluid' style='width:300px;margin:10px;' onclick='Image_click(this)'/></div>";
            innerhtml += "</div>";
            ltl_gallery.Text = innerhtml;
        }
    }
}