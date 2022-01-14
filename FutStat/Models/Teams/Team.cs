using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models.Countries;
using FutStat.Models.Leagues;

namespace FutStat.Models.Teams
{
    public class Team
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public short Founded { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public bool IsNational { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int LeagueId { get; set; }
        public League League { get; set; }

    }
}
