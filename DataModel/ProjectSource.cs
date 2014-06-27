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
<<<<<<< HEAD
        private static readonly HttpClient Client = new HttpClient();

        private const string ServiceUrl = "https://thematrixrevolutions.azurewebsites.net/api/projects";
        static ProjectSource()
        {
            Client.BaseAddress = new Uri("https://thematrixrevolutions.azurewebsites.net/api/projects");
        }

        public static async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "");
            HttpResponseMessage response = await Client.SendAsync(request);
=======

        public static async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/projects");
            HttpResponseMessage response = await CurrentClientSingleton.Client.SendAsync(request);
>>>>>>> origin/master
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Project[]>(jsonString);
        }

        public static async Task<Project> GetProjectsAsync(int id)
        {
<<<<<<< HEAD
            var request = new HttpRequestMessage(HttpMethod.Get, "/"+id);
            HttpResponseMessage response = await Client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
=======
            var request = new HttpRequestMessage(HttpMethod.Get, "api/projects/" + id);
            var response = await CurrentClientSingleton.Client.SendAsync(request);
            var jsonString = await response.Content.ReadAsStringAsync();
>>>>>>> origin/master
            return JsonConvert.DeserializeObject<Project>(jsonString);
        }

        public static async Task<bool> AddProjectAsync(Project p)
        {
<<<<<<< HEAD
            var jsonString = JsonConvert.SerializeObject(p);
            await Client.PostAsync(ServiceUrl, new StringContent(jsonString, Encoding.UTF8));
        }
        public static async Task UpdateProjectAsync(Project p)
        {
            var jsonString = JsonConvert.SerializeObject(p);
            var s = new StringContent(jsonString, Encoding.UTF8);
            await Client.PutAsync(String.Format("{0}/{1}", ServiceUrl, p.Id),s);
=======
            var request = new HttpRequestMessage(HttpMethod.Post, "api/projects")
            {
                Content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json")
            };
            var response = await CurrentClientSingleton.Client.SendAsync(request);

            return response.IsSuccessStatusCode;
>>>>>>> origin/master
        }

        public static async Task DeleteProject(int id)
        {
<<<<<<< HEAD
            var request = new HttpRequestMessage(HttpMethod.Delete, "/"+id);
            await Client.SendAsync(request);
=======
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/projects/" + id);
            await CurrentClientSingleton.Client.SendAsync(request);
>>>>>>> origin/master
        }
    }
}
