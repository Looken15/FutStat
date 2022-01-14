using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models.Seasons;

namespace FutStat.Abstract
{
    public interface ISeasonsRepository
    {
        IQueryable<Season> GetSeasons(int leagueId);
    }
}
