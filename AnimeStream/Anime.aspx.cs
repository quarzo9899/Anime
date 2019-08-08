﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace AnimeStream
{
    public partial class Anime1 : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {

                if (Request.QueryString["connectionID"] == null || Request.QueryString["connectionID"] == "" || Request.QueryString["cookieValue"] == null || Request.QueryString["cookieValue"] == "" || Request.QueryString["id"] == null || Request.QueryString["id"] == "")
                {
                    List<string> info = VVVID.GetConnectionInfo();
                    Response.Redirect($"default.aspx?connectionID={info[0]}&cookieValue={info[1]}");
                }

                int animeID = int.Parse(Request.QueryString["id"]);
                string connectionID = Request.Params["connectionID"];
                string cookieValue = Request.Params["cookieValue"];
                var animeData = VVVID.GetAnimeData(animeID, connectionID, cookieValue);

                foreach (Anime a in animeData)
                {
                    ddl_tipo.Items.Add(a.name);
                }
                AggiornaGridLista(animeData[0]);
            }
        }

        private void Play(int nEpisodio, string showId, string seasonId) {
            string connectionID = Request.Params["connectionID"];
            string cookieValue = Request.Params["cookieValue"];
            var link = VVVID.GetLinks(connectionID, cookieValue, nEpisodio, showId, seasonId);
            Response.Write($"<script>window.open('player.html?url={link}')</script>");
        }

        private void AggiornaGridLista(Anime anime)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("thumb", typeof(string));
            dt.Columns.Add("title", typeof(string));
            dt.Columns.Add("epInfo", typeof(string));

            for (int i = 0; i < anime.episodes.Count; i++){
                // dt.Rows.Add(i, anime.episodes[i].thumbnail, anime.episodes[i].title);
                dt.Rows.Add(i, anime.episodes[i].thumbnail, anime.episodes[i].title ,anime.show_id + "-" + anime.episodes[i].season_id);

            }

            ListGrid.DataSource = dt;
            ListGrid.DataBind();
            dt.Clear();
        }

        protected void ddl_tipo_TextChanged(object sender, EventArgs e)
        {
            int animeID = int.Parse(Request.QueryString["id"]);
            string connectionID = Request.Params["connectionID"];
            string cookieValue = Request.Params["cookieValue"];
            var animeData = VVVID.GetAnimeData(animeID, connectionID, cookieValue);

            AggiornaGridLista(animeData[ddl_tipo.SelectedIndex]);
        }

        protected void ListGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "play")
            {
                string[] epInfo = ListGrid.Rows[0].Cells[2].Text.Split('-'); 
               Play(int.Parse(Convert.ToString(e.CommandArgument)), epInfo[0], epInfo[1]);
            }
        }
    }
}