using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStat.Core
{
    public static class Config
    {
        #region api
        public const string apiPath = "https://api.football-data.org/v2/";
        public const string apiKey = "a0525938c5404827ae0546c3d683ddcd";
        public const string apiName = "X-Auth-Token";
        #endregion api

        #region leagues
        public static string[] topLeaguesCodes = new string[] { "CL", "PL", "PD", "BL1", "SA", "FL1", "PPL", "DED", "BSA", "ELC", "EC", "CLI" };
        public static string[] cups = new string[] { "CL", "EC", "CLI" };
        #endregion leagues
    }
}
