﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutStat.Models.Countries
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
    }
}