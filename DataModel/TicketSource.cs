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

        public static async Task<Ticket> GetTicketsAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/tickets/" + id);
            var response = await CurrentClientSingleton.Client.SendAsync(request);
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Ticket>(jsonString);
        }

        public static async Task<bool> AddTicketAsync(Ticket p)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/tickets")
            {
                Content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json")
            };
            var response = await CurrentClientSingleton.Client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> UpdateTicketAsync(Ticket p)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/tickets/" + p.Id)
            {
                Content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json")
            };
            var response = await CurrentClientSingleton.Client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        public static async Task DeleteTicket(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/tickets/" + id);
            await CurrentClientSingleton.Client.SendAsync(request);
        }
    }
}
