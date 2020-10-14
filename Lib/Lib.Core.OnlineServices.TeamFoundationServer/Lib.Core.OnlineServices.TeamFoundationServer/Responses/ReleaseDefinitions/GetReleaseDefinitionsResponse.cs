namespace Lib.Core.OnlineServices.TeamFoundationServer
{
    public class GetReleaseDefinitionsResponse
    {
        public int count { get; set; }
        public ReleaseDefinitionResponseBase[] value { get; set; }
    }
}
