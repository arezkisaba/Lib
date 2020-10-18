using Newtonsoft.Json;
using System;

namespace Lib.ApiServices.TeamFoundationServer
{
    public class BuildDefinitionResponseBase
    {
        public string quality { get; set; }
        public _Links _links { get; set; }
        public Authoredby authoredBy { get; set; }
        public string uri { get; set; }
        [JsonProperty("type")]
        public string TYPE { get; set; }
        public int revision { get; set; }
        public DateTime createdDate { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Project project { get; set; }
        public Queue queue { get; set; }
        public Repository repository { get; set; }

        public class _Links
        {
            public Self self { get; set; }
            public Web web { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Web
        {
            public string href { get; set; }
        }

        public class Authoredby
        {
            public string id { get; set; }
            public string displayName { get; set; }
            public string uniqueName { get; set; }
            public string url { get; set; }
            public string imageUrl { get; set; }
        }

        public class Pool
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Project
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public string state { get; set; }
            public int revision { get; set; }
        }

        public class Queue
        {
            public Pool pool { get; set; }
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Repository
        {
            public string name { get; set; }
            public string type { get; set; }
            public string defaultBranch { get; set; }
            public string clean { get; set; }
            public bool checkoutSubmodules { get; set; }
        }
    }
}
