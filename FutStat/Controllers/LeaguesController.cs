using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FutStat.Models;
using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FutStat.Models.Seasons;
using FutStat.Models.Leagues;
using FutStat.Models.Countries;
using FutStat.Core.Enum;

namespace FutStat.Controllers
{
    public class LeaguesController : Controller
    {
        FutContext db = new FutContext();
        public ActionResult Index()
        {
            var leagues = db.Leagues.Include(x => x.Country).OrderBy(x => x.Id).Take(50);
            return View(leagues.ToList());
        }

        public async Task<ActionResult> AddFromApiAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/leagues"),
                Headers =
                {
                    { "x-rapidapi-host", "api-football-v1.p.rapidapi.com" },
                    { "x-rapidapi-key", "e9d60c869amshb73fa0fde2817ccp19f9a0jsnc2b582f09582" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                JObject answ = JObject.Parse(body);
                IList<JToken> result = answ["response"].Children().ToList();
                foreach (var item in result)
                {
                    var leagueJSON = item["league"];
                    var seasonsJSON = item["seasons"];
                    var countryJSON = item["country"];

                    var league = new League
                    {
                        LeagueId = int.Parse(leagueJSON["id"].ToString()),
                        Name = leagueJSON["name"].ToString(),
                        Type = (LeagueType)Enum.Parse(typeof(LeagueType), leagueJSON["type"].ToString()),
                        Logo = leagueJSON["logo"].ToString(),
                        Country = db.Countries.ToList().FirstOrDefault(x => x.Name == countryJSON["name"].ToString())
                    };
                    db.Leagues.Add(league);
                    foreach (var s in seasonsJSON.Children().ToList())
                    {
                        var season = new Season
                        {
                            Year = int.Parse(s["year"].ToString()),
                            Start = DateTime.Parse(s["start"].ToString()),
                            End = DateTime.Parse(s["end"].ToString()),
                            League = league,
                        };
                        db.Seasons.Add(season);
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}