using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Abstract;
using FutStat.Models;
using FutStat.Core;
using System.Text.Json;
using Newtonsoft.Json;

namespace FutStat.Services
{
    public class TeamService : ITeamService
    {
        private IApiService apiService;
        private ITeamRepository teamRepository;
        private ITeamCompetitionRepository teamCompetitionRepository;
        private ICompetitionRepository competitionRepository;
        public TeamService(IApiService _apiService, ITeamRepository _teamRepository, ITeamCompetitionRepository _teamCompetitionRepository, ICompetitionRepository _competitionRepository)
        {
            apiService = _apiService;
            teamRepository = _teamRepository;
            teamCompetitionRepository = _teamCompetitionRepository;
            competitionRepository = _competitionRepository;
        }

        public List<TeamCompetition> GetTeams(int competitionId)
        {
            return teamCompetitionRepository.GetTeamCompetitions().Where(x => x.CompetitionId == competitionId).ToList();
        }

        public void ParseCompetition()
        {
            foreach (var competition in Config.topLeaguesCodes.Reverse().Take(2))
            {
                var json = apiService.GetFromAPI($"competitions/{competition}/teams");
                var options = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                //var comp = JsonSerializer.Deserialize<CompetitionTeamApi.Data>(json, options);
                var comp = JsonConvert.DeserializeObject<CompetitionTeamApi.Data>(json, options);
                var compId = competitionRepository.GetCompetition(comp.competition.id).Id;
                foreach (var team in comp.teams)
                {
                    var newTeam = new Team
                    {
                        TeamId = team.id,
                        FullName = team.name,
                        Name = team.shortName,
                        ShortName = team.tla,
                        LogoUrl = team.crestUrl,
                        Founded = team.founded,
                        ClubColors = team.clubColors,
                        Venue = team.venue,
                    };
                    teamRepository.Add(newTeam);

                    var newTeamCompetition = new TeamCompetition
                    {
                        TeamId = teamRepository.GetTeam(team.id).Id,
                        CompetitionId = compId
                    };
                    teamCompetitionRepository.Add(newTeamCompetition);
                }
            }
        }
    }
}
