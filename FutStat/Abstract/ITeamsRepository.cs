using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models.Teams;

namespace FutStat.Abstract
{
    public interface ITeamsRepository
    {
        IQueryable<Team> GetTeams();
        void Add(Team team);
    }
}
