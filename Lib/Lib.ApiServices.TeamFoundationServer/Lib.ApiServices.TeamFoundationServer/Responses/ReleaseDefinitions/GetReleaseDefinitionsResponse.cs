namespace Lib.ApiServices.TeamFoundationServer
{
    public class GetReleaseDefinitionsResponse
    {
        public int count { get; set; }
        public ReleaseDefinitionResponseBase[] value { get; set; }
    }
}
