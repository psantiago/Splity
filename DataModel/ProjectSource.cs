using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Splity.Domain;

namespace Splity.Data
{
    /// <summary>
    /// </summary>
    public sealed class ProjectSource
    {
        private static readonly HttpClient Client = new HttpClient();

        static ProjectSource()
        {
            Client.BaseAddress = new Uri("https://thematrixrevolutions.azurewebsites.net/");
        }

        public static async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/tickets");
            HttpResponseMessage response = await Client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Project[]>(jsonString);
        }

        public static async Task<Project> GetProjectsAsync(int id)
        {
            return await Task.Factory.StartNew(() => FakeData.GetSomeProjects().FirstOrDefault(i => i.Id == id));
        }
    }
}
