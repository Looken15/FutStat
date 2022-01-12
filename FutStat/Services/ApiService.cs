using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FutStat.Core;

namespace FutStat.Services
{
    public class ApiService
    {
        public async Task<string> GetFromAPIAsync(string endpoint)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(Config.apiPath + endpoint),
                Headers =
                {
                    { Config.apiHostName, Config.apiHost },
                    { Config.apiKeyName, Config.apiKey },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
