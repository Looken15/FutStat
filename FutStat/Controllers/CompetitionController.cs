using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FutStat.Models;
using FutStat.Abstract;

namespace FutStat.Controllers
{
    public class CompetitionController : Controller
    {
        private ITeamService teamService;
        public CompetitionController(ITeamService _teamService)
        {
            teamService = _teamService;
        }
        public ActionResult Index(int Id)
        {
            var result = teamService.GetTeams(Id);
            return View(result);
        }
    }
}