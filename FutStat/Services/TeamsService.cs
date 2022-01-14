using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Abstract;
using FutStat.Models.Teams;
using Newtonsoft.Json;

namespace FutStat.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly IApiService apiService;
        private readonly ITeamsRepository teamsRepository;
        private readonly ILeaguesRepository leaguesRepository;
        public TeamsService(IApiService _apiService, ITeamsRepository _teamsRepository, ILeaguesRepository _leaguesRepository)
        {
            apiService = _apiService;
            teamsRepository = _teamsRepository;
            leaguesRepository = _leaguesRepository;
        }
        public List<Team> GetTeams(int leagueId)
        {
            AddLeagueTeams(leagueId);
            var trueLeagueId = leaguesRepository.GetLeague(leagueId).Id;
            return teamsRepository.GetTeams().Where(x => x.LeagueId == trueLeagueId).ToList();
        }

        public void AddLeagueTeams(int leagueId)
        {
            var trueLeagueId = leaguesRepository.GetLeague(leagueId).Id;
            if (teamsRepository.GetTeams().Where(x => x.LeagueId == trueLeagueId).Count() == 0)
            {
                var teams = GetTeamsFromApi(leagueId, DateTime.Now.Year - 1);
                foreach (var team in teams.response.Select(x => x.team))
                {
                    var newTeam = new Team
                    {
                        TeamId = team.id,
                        Name = team.name,
                        Logo = team.logo,
                        Founded = (short)team.founded,
                        IsNational = team.national,
                        LeagueId = leaguesRepository.GetLeague(leagueId).Id,
                        CountryId = leaguesRepository.GetLeague(leagueId).CountryId.Value,
                    };
                    teamsRepository.Add(newTeam);
                }
            }
        }

        public ApiTeam.Rootobject GetTeamsFromApi(int leagueId, int season)
        {
            var result = apiService.GetFromAPIAsync($"teams?league={leagueId}&season={season}");
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<ApiTeam.Rootobject>(result, settings);
        }
    }
}
