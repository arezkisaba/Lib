using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.ApiServices.TeamFoundationServer
{
    public interface ITeamFoundationServerService
    {
        Task<List<GetTeamProjectsResponse.Value>> GetTeamProjectsAsync(string apiVersion = "2.0");

        Task<CreateTeamProjectResponse> CreateTeamProjectAsync(CreateTeamProjectBody body, string apiVersion = "2.0");

        Task<List<BuildDefinitionResponseBase>> GetBuildDefinitionsAsync(string teamProjectName, string apiVersion = "2.0");

        Task<CreateBuildDefinitionResponse> CreateBuildDefinitionAsync(string teamProjectName, CreateBuildDefinitionBodyBase body, string apiVersion = "2.0");

        Task<List<ReleaseDefinitionResponseBase>> GetReleaseDefinitionsAsync(string teamProjectName, string apiVersion = "2.0");

        Task<CreateReleaseDefinitionResponse> CreateReleaseDefinitionAsync(string teamProjectName, CreateReleaseDefinitionBodyBase body, string apiVersion = "2.0");

        Task<RunBuildResponse> RunBuildAsync(string teamProjectName, RunBuildBody body, string apiVersion = "2.0");
    }
}
