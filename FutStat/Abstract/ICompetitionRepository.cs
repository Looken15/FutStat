using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models;

namespace FutStat.Abstract
{
    public interface ICompetitionRepository
    {
        IQueryable<Competition> GetCompetitions();
        Competition GetCompetition(int competitionId);
        void Add(Competition competition);
    }
}
