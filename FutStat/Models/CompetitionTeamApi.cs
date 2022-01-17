using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStat.Models
{
    public class CompetitionTeamApi
    {
        public class Data
        {
            public int count { get; set; }
            public Filters filters { get; set; }
            public apiCompetition competition { get; set; }
            public Season season { get; set; }
            public apiTeam[] teams { get; set; }
        }

        public class Filters
        {
        }

        public class apiCompetition
        {
            public int id { get; set; }
            public Area area { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string plan { get; set; }
            public DateTime lastUpdated { get; set; }
        }

        public class apiArea
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Season
        {
            public int id { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public int currentMatchday { get; set; }
            public object winner { get; set; }
        }

        public class apiTeam
        {
            public int id { get; set; }
            public apiArea area { get; set; }
            public string name { get; set; }
            public string shortName { get; set; }
            public string tla { get; set; }
            public string crestUrl { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public string website { get; set; }
            public string email { get; set; }
            public int founded { get; set; }
            public string clubColors { get; set; }
            public string venue { get; set; }
            public DateTime lastUpdated { get; set; }
        }

    }
}
