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

        public ActionResult Create()
        {
            var json = apiService.GetFromAPIAsync("competitions");
            var response = JsonSerializer.Deserialize<CompetitionApi.Rootobject>(json);
            foreach (var competition in response.competitions)
            {
                var newCompetition = new Competition
                {
                    CompetitionId = competition.id,
                    AreaId = areaRepository.GetArea(competition.area.id).Id,
                    Name = competition.name,
                    Code = competition.code,
                    LogoUrl = competition.emblemUrl,
                    Plan = competition.plan,
                    CurrentSeason = competition.currentSeason != null ? string.Concat(competition.currentSeason.startDate.Take(4)) : ""
                };
                competitionRepository.Add(newCompetition);
            }
            return View("Index");
        }
    }
}