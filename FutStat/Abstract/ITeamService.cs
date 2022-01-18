using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models;

namespace FutStat.Abstract
{
    public interface ITeamService
    {
        List<Team> GetTeams(int competitionId);
        LeagueStanding GetStanding(int competitionId);
        void ParseCompetition();
    }
}
