using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models.Teams;

namespace FutStat.Abstract
{
    public interface ITeamsService
    {
        List<Team> GetTeams(int leagueId);
        void AddLeagueTeams(int leagueId);
        ApiTeam.Rootobject GetTeamsFromApi(int leagueId, int season);
    }
}
