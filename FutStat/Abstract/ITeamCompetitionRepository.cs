using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models;

namespace FutStat.Abstract
{
    public interface ITeamCompetitionRepository
    {
        IQueryable<TeamCompetition> GetTeamCompetitions();
        void Add(TeamCompetition teamCompetition);
    }
}
