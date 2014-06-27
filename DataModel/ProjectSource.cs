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

        public static async Task<bool> AddProjectAsync(Project p)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/projects")
            {
                Content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json")
            };
            var response = await CurrentClientSingleton.Client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        public static async Task DeleteProject(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/projects/" + id);
            await CurrentClientSingleton.Client.SendAsync(request);
        }
    }
}
