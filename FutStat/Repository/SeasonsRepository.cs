using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Abstract;
using FutStat.Models.Seasons;
using System.Data.Entity;

namespace FutStat.Repository
{
    public class SeasonsRepository : BaseRepository, ISeasonsRepository
    {
        public IQueryable<Season> GetSeasons(int leagueId)
        {
            return db.Seasons.Include(x => x.League).Where(x => x.LeagueId == leagueId);
        }
    }
}
