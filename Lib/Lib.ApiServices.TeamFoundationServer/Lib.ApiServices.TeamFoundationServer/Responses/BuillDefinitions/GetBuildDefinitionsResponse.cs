namespace Lib.ApiServices.TeamFoundationServer
{
    public class GetBuildDefinitionsResponse
    {
        public int count { get; set; }
        public BuildDefinitionResponseBase[] value { get; set; }
    }
}
