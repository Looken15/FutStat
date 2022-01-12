using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models.Leagues;

namespace FutStat.Abstract
{
    public interface ILeaguesService
    {
        List<League> GetTopLeagues();
    }
}
