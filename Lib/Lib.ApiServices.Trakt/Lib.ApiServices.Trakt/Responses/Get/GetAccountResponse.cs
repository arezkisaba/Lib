using System;

namespace Lib.ApiServices.Trakt
{
    public class GetAccountResponse
    {
        public User user { get; set; }
        public Account account { get; set; }
        public Connections connections { get; set; }
        public Sharing_Text sharing_text { get; set; }

        public class User
        {
            public string username { get; set; }
            public bool _private { get; set; }
            public string name { get; set; }
            public bool vip { get; set; }
            public bool vip_ep { get; set; }
            public Ids ids { get; set; }
            public DateTime joined_at { get; set; }
            public string location { get; set; }
            public string about { get; set; }
            public string gender { get; set; }
            public int age { get; set; }
            public Images images { get; set; }
        }

        public class Ids
        {
            public string slug { get; set; }
        }

        public class Images
        {
            public Avatar avatar { get; set; }
        }

        public class Avatar
        {
            public string full { get; set; }
        }

        public class Account
        {
            public string timezone { get; set; }
            public bool time_24hr { get; set; }
            public string cover_image { get; set; }
        }

        public class Connections
        {
            public bool facebook { get; set; }
            public bool twitter { get; set; }
            public bool google { get; set; }
            public bool tumblr { get; set; }
            public bool medium { get; set; }
            public bool slack { get; set; }
        }

        public class Sharing_Text
        {
            public string watching { get; set; }
            public string watched { get; set; }
        }
    }
}
