using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimeStream {
    public partial class Anime1 : System.Web.UI.Page {
        //animeData è una lista di Anime, ad es.un anime puà avere una versione ITA e una SUB-ITA quindi animeData conteerà 2 Anime , 
        //     dentro ogni anime ci sono tutte le informazioni necessarie per identificarle.


        //animeData[0].name = "Episodi In Italiano"

        //animeData[0].episodes è una lista di episodi quindi si possono ottenere i numeri degli episodi(animeData[0].episodes.Count 
        //      inoltre ogni episodio ha un immagine che volendo si può mettere a schermo e un titolo)

        //animeData[0].episodes[0].thumbnail	"https://static.vvvvid.it/img/thumbs/Dynit/TokyoGhoul/TokyoGhoul_S03Ep01-t.jpg"	
        //animeData[0].title = "I cacciatori"	
        protected void Page_Load(object sender, EventArgs e) {
            if (AnimeStream._default.vvvID == null || AnimeStream._default.vvvID.listAnime == null || Request.QueryString["id"] == null)
                Server.Transfer($"default.aspx");
            var vvvID = AnimeStream._default.vvvID;
            AnimeStream._default.vvvID = null;

            int animeID = int.Parse(Request.QueryString["id"]);
            vvvID.Anime = vvvID.listAnime[animeID];
            var animeData = GetAnimeData(vvvID);
            TextBox1.Text = vvvID.Anime.title;
        }

        private List<Anime> GetAnimeData(VVVID vvvID) {
            return vvvID.GetAnimeData(vvvID.Anime.show_id).data;
        }


        private void Play(VVVID vvvID, Anime anime, int nEpisodio) {
            var link = vvvID.GetLinks(anime, nEpisodio);
            Response.Redirect($"player.html?url={link}");
        }
    }
}