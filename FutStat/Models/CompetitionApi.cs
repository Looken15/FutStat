using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStat.Models
{
    public class CompetitionApi
    {

        public class Rootobject
        {
            public int count { get; set; }
            public Filters filters { get; set; }
            public apiCompetition[] competitions { get; set; }
        }

        public class Filters
        {
        }

        public class apiCompetition
        {
            public int id { get; set; }
            public apiArea area { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string emblemUrl { get; set; }
            public string plan { get; set; }
            public Currentseason currentSeason { get; set; }
            public int numberOfAvailableSeasons { get; set; }
            public DateTime lastUpdated { get; set; }
        }

        public class apiArea
        {
            public int id { get; set; }
            public string name { get; set; }
            public string countryCode { get; set; }
            public string ensignUrl { get; set; }
        }

        public class Currentseason
        {
            public int id { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public int? currentMatchday { get; set; }
            public Winner winner { get; set; }
        }

        public class Winner
        {
            public int id { get; set; }
            public string name { get; set; }
            public string shortName { get; set; }
            public string tla { get; set; }
            public string crestUrl { get; set; }
        }

    }
}
