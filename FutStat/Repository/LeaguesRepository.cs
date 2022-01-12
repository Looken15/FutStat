using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models;
using FutStat.Models.Leagues;
using FutStat.Abstract;
using System.Data.Entity;

namespace FutStat.Repository
{
    public class LeaguesRepository : ILeaguesRepository
    {
        private readonly FutContext db;
        public LeaguesRepository()
        {
            db = new FutContext();
        }
        public IQueryable<League> GetLeagues()
        {
            return db.Leagues.Include(x => x.Country);
        }
    }
}
