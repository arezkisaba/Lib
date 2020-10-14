namespace Lib.Core.OnlineServices.TeamFoundationServer
{
    public class RunBuildBody
    {
        public Queue queue { get; set; }
        public Definition definition { get; set; }
        public Project project { get; set; }
        public string sourceBranch { get; set; }
        public string sourceVersion { get; set; }
        public string parameters { get; set; }
        public int reason { get; set; }
        public object[] demands { get; set; }

        public class Queue
        {
            public int id { get; set; }
        }

        public class Definition
        {
            public string id { get; set; }
        }

        public class Project
        {
            public string id { get; set; }
        }
    }
}
