using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Abstract;
using FutStat.Models;
using System.Data.Entity;

namespace FutStat.Repository
{
    public class CompetitionRepository : BaseRepository, ICompetitionRepository
    {
        public IQueryable<Competition> GetCompetitions()
        {
            return db.Competitions.Include(x => x.Area);
        }

        public Competition GetCompetition(int competitionId)
        {
            return db.Competitions.FirstOrDefault(x => x.CompetitionId == competitionId);
        }

        public void Add(Competition competition)
        {
            db.Competitions.Add(competition);
            db.SaveChanges();
        }
    }
}
