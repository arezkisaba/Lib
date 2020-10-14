using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Lib.Core.OnlineServices.TeamFoundationServer
{
    public class TeamFoundationServerService : ITeamFoundationServerService
    {
        private HttpService _httpService;

        public TeamFoundationServerService(
            string url)
        {
            _httpService = new HttpService(url, ExchangeFormat.Json);
            _httpService.SetJsonSerializerSettings(new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

        public async Task<List<GetTeamProjectsResponse.Value>> GetTeamProjectsAsync(string apiVersion = "2.0")
        {
            var responseObject = await _httpService.GetAsync<GetTeamProjectsResponse>($"_apis/projects?api-version={apiVersion}");
            return responseObject.value.ToList();
        }

        public async Task<CreateTeamProjectResponse> CreateTeamProjectAsync(CreateTeamProjectBody body, string apiVersion = "2.0")
        {
            return await _httpService.PostAsync<CreateTeamProjectResponse>($"_apis/projects?api-version={apiVersion}", body);
        }

        public async Task<List<BuildDefinitionResponseBase>> GetBuildDefinitionsAsync(string teamProjectName, string apiVersion = "2.0")
        {
            teamProjectName = teamProjectName.Replace(" ", "%20");
            
            var responseObject = await _httpService.GetAsync<GetBuildDefinitionsResponse>($"{teamProjectName}/_apis/build/definitions?api-version={apiVersion}");
            return responseObject.value.ToList();
        }

        public async Task<CreateBuildDefinitionResponse> CreateBuildDefinitionAsync(string teamProjectName, CreateBuildDefinitionBodyBase body, string apiVersion = "2.0")
        {
            teamProjectName = teamProjectName.Replace(" ", "%20");

            return await _httpService.PostAsync<CreateBuildDefinitionResponse>($"{teamProjectName}/_apis/build/definitions?api-version={apiVersion}", body);
        }

        public async Task<List<ReleaseDefinitionResponseBase>> GetReleaseDefinitionsAsync(string teamProjectName, string apiVersion = "2.0")
        {
            teamProjectName = teamProjectName.Replace(" ", "%20");
            
            var responseObject = await _httpService.GetAsync<GetReleaseDefinitionsResponse>($"{teamProjectName}/_apis/release/definitions?api-version={apiVersion}");
            return responseObject.value.ToList();
        }

        public async Task<CreateReleaseDefinitionResponse> CreateReleaseDefinitionAsync(string teamProjectName, CreateReleaseDefinitionBodyBase body, string apiVersion = "2.0")
        {
            teamProjectName = teamProjectName.Replace(" ", "%20");

            return await _httpService.PostAsync<CreateReleaseDefinitionResponse>($"{teamProjectName}/_apis/release/definitions?api-version={apiVersion}", body);
        }

        public async Task<RunBuildResponse> RunBuildAsync(string teamProjectName, RunBuildBody body, string apiVersion = "2.0")
        {
            teamProjectName = teamProjectName.Replace(" ", "%20");

            return await _httpService.PostAsync<RunBuildResponse>($"{teamProjectName}/_apis/build/builds?api-version={apiVersion}", body);
        }
    }
}
