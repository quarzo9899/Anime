using System.Collections.Generic;
namespace AnimeStream
{
    public class Episode {
        public int id { get; set; }
        public int season_id { get; set; }
        public int video_id { get; set; }
        public string number { get; set; }
        public string title { get; set; }
        public string thumbnail { get; set; }
        public string description { get; set; }
        public bool expired { get; set; }
        public bool seen { get; set; }
        public bool playable { get; set; }
        public int ondemand_type { get; set; }
        public int vod_mode { get; set; }
        public string videoLink { get; set; }
        public string show_title { get; set; }
        public int season_number { get; set; }
        public int show_id { get; set; }
        public int show_type { get; set; }
        public int views { get; set; }
        public int length { get; set; }
        public string video_type { get; set; }
        public string vast_url { get; set; }
        public string vast_config { get; set; }
        public bool is_rated { get; set; }
        public bool is_added_to_watchlist { get; set; }
        public bool is_shared { get; set; }
        public string embed_info { get; set; }
        public string source_type { get; set; }
        public string embed_info_sd { get; set; }
        public int video_shares { get; set; }
        public int video_likes { get; set; }
        public string midroll_timings { get; set; }
    }
    public class Anime {
        public int id { get; set; }
        public int show_id { get; set; }
        public int season_id { get; set; }
        public int show_type { get; set; }
        public int number { get; set; }
        public List<Episode> episodes { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string thumbnail { get; set; }
        public List<Episode> data { get; set; }

    }
    public class RootObject {
        public string result { get; set; }
        public string message { get; set; }
        public List<Anime> data { get; set; }
    }
}