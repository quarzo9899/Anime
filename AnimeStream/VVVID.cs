using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AnimeStream {
    public class VVVID  {
        private static string WebRequest(string url, String cookieValue) {
            CookieContainer _cookieContainer = new CookieContainer();
            if(cookieValue != null)
                _cookieContainer.Add(new Cookie("JSESSIONID", cookieValue, "/", "www.vvvvid.it"));
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:67.0) Gecko/20100101 Firefox/67.0";
            webRequest.CookieContainer = _cookieContainer;
            using (Stream s = webRequest.GetResponse().GetResponseStream())
                using (StreamReader sr = new StreamReader(s))
                    return sr.ReadToEnd();
        }

        public static List<string> GetConnectionInfo() {
            CookieContainer _cookieContainer = new CookieContainer();
            string response;
            var connectionInfo = new List<String>();

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create("https://www.vvvvid.it/user/login");
            webRequest.Method = "GET";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:67.0) Gecko/20100101 Firefox/67.0";
            webRequest.CookieContainer = _cookieContainer;
            using (Stream s = webRequest.GetResponse().GetResponseStream())
                using (StreamReader sr = new StreamReader(s))
                    response = sr.ReadToEnd();
            var b = _cookieContainer.GetCookies(new Uri("http://www.vvvvid.it"))[0].Value;
            connectionInfo.Add(response.Split(new[] { "\"conn_id\":\"" }, StringSplitOptions.None)[1].Split('\"')[0]);
            connectionInfo.Add(_cookieContainer.GetCookies(new Uri("http://www.vvvvid.it"))[0].Value);
            return connectionInfo;
        }

        public static List<Anime> AnimeFilter(char c, String _connectionId, String cookieValue) {
            String urlFirst15 = "https://www.vvvvid.it/vvvvid/ondemand/anime/channel/10003/last?filter=" + c + "&conn_id=" + _connectionId; //Questo link mostra solo i primi 15 anime
            String urlLast = "https://www.vvvvid.it/vvvvid/ondemand/anime/channel/10003?filter=" + c + "&conn_id=" + _connectionId; //Questo link mostra i restanti anime
            string response = WebRequest(urlFirst15, cookieValue);
            RootObject animeFirst15 = JsonConvert.DeserializeObject<RootObject>(response);
            response = WebRequest(urlLast, cookieValue);
            RootObject animeLast = JsonConvert.DeserializeObject<RootObject>(response);
            if (animeLast.data != null) return animeFirst15.data.ToArray().Union(animeLast.data.ToArray()).ToList();
            return animeFirst15.data.ToArray().ToList();
        }

        public static List<Anime> GetAnimeData(int idAnime, String _connectionId, String cookieValue) {
            string url = $"https://www.vvvvid.it/vvvvid/ondemand/{idAnime}/seasons/?conn_id={_connectionId}";
            string response = WebRequest(url, cookieValue);
            List<Anime> animeData = JsonConvert.DeserializeObject<RootObject>(response).data;
            return animeData;
        }

        public static string GetLinks(String _connectionId, String cookieValue, int episodioNumero, string showId, string seasonId) {
            string url = $"http://www.vvvvid.it/vvvvid/ondemand/{showId}/season/{seasonId}?conn_id={_connectionId}";
            string response = WebRequest(url, cookieValue);
            Anime animeData = JsonConvert.DeserializeObject<Anime>(response);
            string EpisodeUrlDec = animeData.data[episodioNumero].embed_info;
            string linkVideo = DecodeManifestLink(EpisodeUrlDec).Replace("manifest.f4m", "master.m3u8").Replace("/z/", "/i/").Replace("http:", "https:");
            if (animeData.data[episodioNumero].video_type == "video/kenc") {
                url = $"https://www.vvvvid.it/kenc?action=kt&conn_id={_connectionId}&url={linkVideo}";
                response = WebRequest(url, cookieValue);
                RootObject kenc = JsonConvert.DeserializeObject<RootObject>(response);
                linkVideo += '?' + DecodeManifestLink(kenc.message).Replace("manifest.f4m", "master.m3u8").Replace("/z/", "/i/").Replace("http:", "https:");
            }
            return linkVideo;
        }

        private static string DecodeManifestLink(string h)  {
            var g = "MNOPIJKL89+/4567UVWXQRSTEFGHABCDcdefYZabstuvopqr0123wxyzklmnghij";
            var m = h.Select(c => g.IndexOf(c)).ToArray();
            for (var i = m.Length * 2 - 1; i >= 0; i--)
                m[i % m.Length] ^= m[(i + 1) % m.Length];
            var sb = new StringBuilder(m.Length * 3 / 4);
            for (int i = 0; i < m.Length; i++)
                if (i % 4 != 0)
                    sb.Append((char)((m[i - 1] << (i % 4) * 2 & 255) + (m[i] >> (3 - i % 4) * 2)));
            if (m.Length % 4 == 1)
                sb.Append((char)(m.Last() << 2));
            return sb.ToString();
        }
    }
}