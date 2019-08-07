using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;

namespace AnimeStream {
    public partial class _default : System.Web.UI.Page {
        public static VVVID vvvID;

        protected void Page_Load(object sender, EventArgs e) {
            vvvID = new VVVID();
        }

        public static List<Anime> listAnime;
        public static Anime anime;
        public static RootObject animeData;
        protected void AnimeIniziale_TextChanged(object sender, EventArgs e) {
            AnimeLista.Items.Clear();
            char c = char.ToLower(((TextBox)sender).Text[0], CultureInfo.InvariantCulture);
            listAnime = vvvID.AnimeFilter(c);
            //for (int k = 0; k < listAnime.Count; k++)
            //    AnimeLista.Items.Add(listAnime[k].title);
            AggiornaGallery();
            anime = listAnime[0];
            GetAnimeTipo();
            GetEpisodi();

        }

        protected void AnimeLista_TextChanged(object sender, EventArgs e) {
            anime = listAnime[AnimeLista.SelectedIndex];
            GetAnimeTipo();
            GetEpisodi();
        }


        private void GetAnimeTipo() {
            AnimeTipo.Items.Clear();
             animeData = vvvID.GetAnimeData(anime.show_id);
                foreach (Anime a in animeData.data)
                    AnimeTipo.Items.Add(a.name);    
        }

        private void GetEpisodi() {
            AnimeEpisodio.Items.Clear();
            vvvID.Anime = animeData.data[AnimeTipo.SelectedIndex];
            vvvID.Anime.title = anime.title;

            for (int i = 0; i < vvvID.Anime.episodes.Count; i++)
                if (vvvID.Anime.episodes[i].playable)
                    AnimeEpisodio.Items.Add($"{anime.title} {vvvID.Anime.episodes[i].number}");

        }

        protected void BtnStream_Click(object sender, EventArgs e) {
            vvvID.Anime = animeData.data[AnimeTipo.SelectedIndex];
            vvvID.Anime.title = anime.title;
            var link = vvvID.GetLinks(AnimeEpisodio.SelectedIndex);
            Response.Redirect($"player.html?url={link}");

        }

        protected void AnimeTipo_TextChanged(object sender, EventArgs e)
        { GetEpisodi(); }

        protected void Image_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        private void AggiornaGallery(){
            string innerhtml = "<div class='row'>";

            for(int i = 0; i < listAnime.Count; i++)
                innerhtml += $"<div class='col-6 col-sm-4 col-md-3 col-lg-2'><img id='{i}' alt = '' src='{listAnime[i].thumbnail}' class='img-fluid' style='width:300px;margin:10px;' onclick='Image_click(this)'/></div>";
            innerhtml += "</div>";
            ltl_gallery.Text = innerhtml;

            vvvID.listAnime = listAnime;
        }
    }
}