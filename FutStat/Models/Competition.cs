using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStat.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string LogoUrl { get; set; }
        public string Plan { get; set; }
        public string CurrentSeason { get; set; }
    }
}
