using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStat.Models
{
    public class TeamCompetition
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
    }
}
