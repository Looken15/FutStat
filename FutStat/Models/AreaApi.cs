using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStat.Models
{
    public class AreaApi
    {
        public class Rootobject
        {
            public int count { get; set; }
            public Filters filters { get; set; }
            public apiArea[] areas { get; set; }
        }

        public class Filters
        {
        }

        public class apiArea
        {
            public int id { get; set; }
            public string name { get; set; }
            public string countryCode { get; set; }
            public string ensignUrl { get; set; }
            public int? parentAreaId { get; set; }
            public string parentArea { get; set; }
        }
    }
}
