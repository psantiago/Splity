using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Splity.DataModel
{
    public static class CurrentClientSingleton
    {
        public static readonly HttpClient Client = new HttpClient();

        static CurrentClientSingleton()
        {
            Client.BaseAddress = new Uri("https://thematrixrevolutions.azurewebsites.net/");
        }
    }
}
