using System.Collections.Generic;

namespace Lib.Core.OnlineServices.Plex
{
    public partial class MovieDto
    {
        public string IdPlex { get; set; }

        public string Title { get; set; }
        
        public int? Year { get; set; }

        public bool IsCompleted { get; set; }

        public List<string> FilePaths { get; set; }
    }
}