﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FutStat.Models.Leagues;
using FutStat.Models.Countries;
using FutStat.Models.Seasons;

namespace FutStat.Models
{
    public class FutContext : DbContext
    {
        public DbSet<League> Leagues { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Season> Seasons { get; set; }
    }
}