using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models;

namespace FutStat.Models
{
    public class LeagueStanding
    {
        public LeagueStanding()
        {
            Positions = new List<TablePosition>();
        }
        public Competition Competition { get; set; }

        public DateTime LastUpdated { get; set; }

        public List<TablePosition> Positions { get; set; }
    }
}
