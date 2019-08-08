using System;
using System.Collections.Generic;
using System.Data;
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
        private static List<Anime> animeData;
        private static VVVID vvvID;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                if (AnimeStream._default.vvvID == null || AnimeStream._default.vvvID.listAnime == null || Request.QueryString["id"] == null)
                Response.Redirect("default.aspx");
                vvvID = AnimeStream._default.vvvID;
                //AnimeStream._default.vvvID = null;

                int animeID = int.Parse(Request.QueryString["id"]);
                vvvID.Anime = vvvID.listAnime[animeID];
                animeData = GetAnimeData(vvvID);
                lbl_titolo.Text = vvvID.Anime.title;
            
                foreach (Anime a in animeData)
                {
                    ddl_tipo.Items.Add(a.name);
                }

                AggiornaGridLista(0);
            }
        }

        private List<Anime> GetAnimeData(VVVID vvvID) {
            return vvvID.GetAnimeData(vvvID.Anime.show_id).data;
        }


        private void Play(Anime anime, int nEpisodio) {
            var link = vvvID.GetLinks(anime, nEpisodio);
            Response.Write($"<script>window.open('player.html?url={link}')</script>");
        }

        private void AggiornaGridLista(int index)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("thumb", typeof(string));
            dt.Columns.Add("title", typeof(string));

            for (int i = 0; i < animeData[index].episodes.Count; i++){
                dt.Rows.Add(i, animeData[index].episodes[i].thumbnail, animeData[0].episodes[i].title);
            }

            ListGrid.DataSource = dt;
            ListGrid.DataBind();
            dt.Clear();
        }

        protected void ddl_tipo_TextChanged(object sender, EventArgs e)
        {
            AggiornaGridLista(ddl_tipo.SelectedIndex);
        }

        protected void ListGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "play")
            {
                Play(animeData[ddl_tipo.SelectedIndex], int.Parse(Convert.ToString(e.CommandArgument)));
            }
        }
    }
}