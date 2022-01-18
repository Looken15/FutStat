using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStat.Models
{
    public class TablePosition
    {
        public int Position { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int PlayedGames { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int Points { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
    }
}
