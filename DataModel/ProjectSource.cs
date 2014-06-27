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

        public static async Task<Project> GetProjectAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/projects/" + id);
            var response = await CurrentClientSingleton.Client.SendAsync(request);
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Project>(jsonString);
        }

        public static async Task<IEnumerable<Ticket>> GetProjectTixAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/projects/" + id + "/tickets");
            var response = await CurrentClientSingleton.Client.SendAsync(request);
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Ticket[]>(jsonString);
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

        public static async Task<bool> UpdateProjectAsync(Project p)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "api/projects/" + p.Id)
            {
                Content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json")
            };
            var response = await CurrentClientSingleton.Client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        public static async Task DeleteProjectAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/projects/" + id);
            await CurrentClientSingleton.Client.SendAsync(request);
        }
    }
}