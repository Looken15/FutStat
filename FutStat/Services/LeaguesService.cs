using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models.Leagues;
using FutStat.Repository;
using FutStat.Core;
using FutStat.Abstract;

namespace FutStat.Services
{
    public class LeaguesService : ILeaguesService
    {
        private readonly ILeaguesRepository leaguesRepository;
        public LeaguesService(ILeaguesRepository _leaguesRepository)
        {
            leaguesRepository = _leaguesRepository;
        }
        public List<League> GetTopLeagues()
        {
            var topLeagues = new List<League>();
            var leagues = leaguesRepository.GetLeagues();
            foreach (var i in Config.topLeaguesIds)
            {
                topLeagues.Add(leagues.First(x => x.LeagueId == i));
            }
            return topLeagues;
        }
    }
}
