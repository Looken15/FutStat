using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FutStat.Abstract;
using System.Web.Mvc;
using System.Text.Json;
using FutStat.Models;

namespace FutStat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompetitionService competitionService;
        private readonly ICompetitionRepository competitionRepository;
        private readonly IAreaRepository areaRepository;
        private readonly IApiService apiService;
        public HomeController(ICompetitionService _competitionService, IApiService _apiService, ICompetitionRepository _competitionRepository, IAreaRepository _areaRepository)
        {
            competitionService = _competitionService;
            apiService = _apiService;
            competitionRepository = _competitionRepository;
            areaRepository = _areaRepository;
        }
        public ActionResult Index()
        {
            var result = competitionService.GetTopCompetitions();
            return View(result);
        }
    }
}