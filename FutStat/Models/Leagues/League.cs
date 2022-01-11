using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FutStat.Core.Enum;
using FutStat.Models.Countries;

namespace FutStat.Models.Leagues
{
    public class League
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public LeagueType Type { get; set; }
        public string Logo { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }
    }
}