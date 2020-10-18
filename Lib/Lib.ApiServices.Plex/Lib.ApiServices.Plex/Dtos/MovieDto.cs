using System.Collections.Generic;

namespace Lib.ApiServices.Plex
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
