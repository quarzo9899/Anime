using System;
using System.Globalization;
using System.Web.UI.WebControls;

namespace AnimeStream
{
    public partial class _default : System.Web.UI.Page {
        public static VVVID vvvID;

        protected void Page_Load(object sender, EventArgs e)
        {  vvvID = new VVVID(); }

        protected void AnimeIniziale_TextChanged(object sender, EventArgs e) {
            char c = char.ToLower(AnimeIniziale.Text[0], CultureInfo.InvariantCulture);
            vvvID.AnimeFilter(c);
            AggiornaGallery();
        }

        private void AggiornaGallery() {
            if (vvvID.listAnime == null)
                return;

            string innerhtml = "<div class='row'>";
            for (int i = 0; i < vvvID.listAnime.Count; i++)
                innerhtml += $"<div class='col-6 col-sm-4 col-md-3 col-lg-2'><img id='{i}' alt = '' src='{vvvID.listAnime[i].thumbnail}' class='img-fluid' style='width:300px;margin:10px;' onclick='Image_click(this)'/></div>";
            innerhtml += "</div>";
            ltl_gallery.Text = innerhtml;

        }
    }
}