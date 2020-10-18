using System;

namespace Lib.ApiServices.Rss
{
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "rss", Namespace = "", IsNullable = false)]
    public class GetResponse
    {
        [System.Xml.Serialization.XmlElementAttribute("channel")]
        public RssChannel channel { get; set; }
        
        public partial class RssChannel
        {
            public string title { get; set; }

            public string description { get; set; }

            public string copyright { get; set; }

            public string link { get; set; }

            public string pubDate { get; set; }

            public string language { get; set; }

            [System.Xml.Serialization.XmlElementAttribute("item")]
            public RssChannelItem[] item { get; set; }
        }

        public partial class RssChannelItem
        {
            public string title { get; set; }

            public string description { get; set; }

            public string link { get; set; }

            public string pubDate { get; set; }
        }
    }
}
