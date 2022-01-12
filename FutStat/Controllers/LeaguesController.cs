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
using FutStat.Services;
using FutStat.Abstract;

namespace FutStat.Controllers
{
    public class LeaguesController : Controller
    {
        private readonly ILeaguesService leaguesService;
        public LeaguesController(ILeaguesService _leaguesService)
        {
            leaguesService = _leaguesService;
        }
        public ActionResult Index()
        {
            return View(leaguesService.GetTopLeagues());
        }
    }
}