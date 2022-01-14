using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FutStat.Models.Leagues;
using FutStat.Models.Countries;
using FutStat.Models.Seasons;
using FutStat.Models.Teams;

namespace FutStat.Repository
{
    public class FutContext : DbContext
    {
        public DbSet<League> Leagues { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}