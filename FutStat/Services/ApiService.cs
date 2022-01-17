using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FutStat.Abstract;
using FutStat.Core;

namespace FutStat.Services
{
    public class ApiService : IApiService
    {
        public string GetFromAPIAsync(string endpoint)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(Config.apiName, Config.apiKey);
                client.BaseAddress = Config.apiPath;

                return client.DownloadString(endpoint);
            }
        }
    }
}