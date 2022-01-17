using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models;

namespace FutStat.Abstract
{
    public interface ITeamRepository
    {
        Team GetTeam(int teamId);
        IQueryable<Team> GetTeams();
        void Add(Team team);
    }
}
