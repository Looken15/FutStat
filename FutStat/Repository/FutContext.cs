using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FutStat.Models;

namespace FutStat.Repository
{
    public class FutContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamCompetition> TeamCompetitions { get; set; }
    }
}