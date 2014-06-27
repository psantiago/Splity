using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Splity.DataModel;
using Splity.Domain;

namespace Splity.Data
{
    /// <summary>
    /// </summary>
    public sealed class TicketSource
    {

        public static async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/tickets");
            HttpResponseMessage response = await CurrentClientSingleton.Client.SendAsync(request);
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Ticket[]>(jsonString);
        }

        public static async Task<Ticket> GetTicketsAsync(int id)
        {
            //return await Task.Factory.StartNew(() => FakeData.GetSomeProjects().FirstOrDefault(i => i.Id == id));
            return null;
        }
    }
}
