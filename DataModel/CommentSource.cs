using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Splity.Domain;

namespace Splity.DataModel
{
    class CommentSource
    {
        public static async Task<bool> AddCommentAsync(Comment p)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/comments")
            {
                Content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json")
            };
            var response = await CurrentClientSingleton.Client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}
