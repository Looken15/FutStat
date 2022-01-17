using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Abstract;
using FutStat.Models;
using FutStat.Core;

namespace FutStat.Services
{
    public class CompetitionService : ICompetitionService
    {
        private ICompetitionRepository competitionRepository;
        public CompetitionService(ICompetitionRepository _competitionRepository)
        {
            competitionRepository = _competitionRepository;
        }
        public List<Competition> GetTopCompetitions()
        {
            return competitionRepository
                .GetCompetitions()
                .Where(x => Config.topLeaguesCodes.Contains(x.Code))
                .ToList()
                .OrderBy(x => Array.IndexOf(Config.topLeaguesCodes, x.Code))
                .ToList();
        }
    }
}
