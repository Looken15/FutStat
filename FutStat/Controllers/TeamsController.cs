using FutStat.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutStat.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamsService teamsService;
        public TeamsController(ITeamsService _teamsService)
        {
            teamsService = _teamsService;
        }
        public ActionResult Index(int leagueId)
        {
            var teams = teamsService.GetTeams(leagueId);
            return View(teams);
        }
    }
}