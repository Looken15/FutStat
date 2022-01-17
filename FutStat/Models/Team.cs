using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStat.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LogoUrl { get; set; }
        public int Founded { get; set; }
        public string ClubColors { get; set; }
        public string Venue { get; set; }
    }
}
