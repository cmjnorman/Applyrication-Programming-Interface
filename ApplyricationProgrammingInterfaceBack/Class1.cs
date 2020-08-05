using System;
using System.IO;
using System.Net.Http;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ApplyricationProgrammingInterfaceBack
{
    public class API
    {
        public static Uri GetUrl(string artist, string title)
        {
            artist = artist.Replace(" ", "%20");
            title = title.Replace(" ", "%20");
            var urlString = "http://api.chartlyrics.com/apiv1.asmx/SearchLyricDirect?artist=" + artist + "&song=" + title;
            return new Uri(urlString);
        }

        public static string GetLyric(Uri url)
        {
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetAsync(url).Result;
                var xml = XDocument.Parse(data.Content.ReadAsStringAsync().Result);
                using (var sr = new StringReader(xml.ToString()))
                {
                    var serializer = new XmlSerializer(typeof(LyricObject));
                    var lyric = (LyricObject)serializer.Deserialize(sr);
                    return lyric.Lyric;
                }
            }
        }
    }

    [Serializable, XmlRoot(Namespace = "http://api.chartlyrics.com/", ElementName = "GetLyricResult")]
    public class LyricObject
    {
        [XmlElement("LyricSong")]
        public string LyricSong { get; set; }
        [XmlElement("LyricArtist")]
        public string LyricArtist { get; set; }
        [XmlElement("Lyric")]
        public string Lyric { get; set; }
    }
}
