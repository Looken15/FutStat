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
    public class LeaguesRepository : BaseRepository, ILeaguesRepository
    {
        public IQueryable<League> GetLeagues()
        {
            return db.Leagues.Include(x => x.Country);
        }

        public League GetLeague(int id)
        {
            return db.Leagues.FirstOrDefault(x => x.LeagueId == id);
        }
    }
}
