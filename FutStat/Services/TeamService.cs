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

        public List<Team> GetTeams(int competitionId)
        {
            return teamCompetitionRepository.GetTeamCompetitions().Where(x => x.CompetitionId == competitionId).Select(x => x.Team).ToList();
        }

        public LeagueStanding GetStanding(int competitionId)
        {
            var json = apiService.GetFromAPI($"competitions/{competitionId}/standings");
            var options = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            var standing = JsonConvert.DeserializeObject<LeagueStandingApi.Data>(json, options);

            var result = new LeagueStanding
            {
                Competition = competitionRepository.GetCompetition(competitionId),
                LastUpdated = standing.competition.lastUpdated,
            };
            var table = standing.standings.First(x => x.table.Count() != 0).table;
            foreach (var pos in table)
            {
                var resPos = new TablePosition
                {
                    Position = pos.position,
                    Team = teamRepository.GetTeam(pos.team.id),
                    PlayedGames = pos.playedGames,
                    Won = pos.won,
                    Draw = pos.draw,
                    Lost = pos.lost,
                    Points = pos.points,
                    GoalsFor = pos.goalsFor,
                    GoalsAgainst = pos.goalsAgainst,
                    GoalDifference = pos.goalDifference,
                };
                result.Positions.Add(resPos);
            }
            result.Positions = result.Positions.OrderBy(x => x.Position).ToList();
            return result;
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
