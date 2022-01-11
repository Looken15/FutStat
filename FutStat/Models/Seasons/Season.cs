using System;
using FutStat.Models.Leagues;

namespace FutStat.Models.Seasons
{
    public class Season
    {
        public int Id { get; set; }
        public int Year { get; set; }

        public int LeagueId { get; set; }
        public League League { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}