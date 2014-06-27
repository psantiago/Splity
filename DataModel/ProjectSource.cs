using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Splity.DataModel;
using Newtonsoft.Json.Serialization;
using Splity.Domain;

namespace Splity.Data
{
    /// <summary>
    /// </summary>
    public sealed class ProjectSource
    {

        public static async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/projects");
            HttpResponseMessage response = await CurrentClientSingleton.Client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Project[]>(jsonString);
        }

        public static async Task<Project> GetProjectsAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/projects/" + id);
            var response = await CurrentClientSingleton.Client.SendAsync(request);
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Project>(jsonString);
        }

        public static async Task AddProjectAsync(Project p)
        {
            var jsonString = JsonConvert.SerializeObject(p);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/project");
            await Client.SendAsync(request);
        }

        public static async Task DeleteProject(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/project/" + id);
            await Client.SendAsync(request);
        }
    }
}
