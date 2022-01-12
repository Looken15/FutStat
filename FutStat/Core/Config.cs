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
        public const string apiPath = "https://api-football-v1.p.rapidapi.com/v3/";
        public const string apiHost = "api-football-v1.p.rapidapi.com";
        public const string apiHostName = "x-rapidapi-host";
        public const string apiKey = "e9d60c869amshb73fa0fde2817ccp19f9a0jsnc2b582f09582";
        public const string apiKeyName = "x-rapidapi-key";
        #endregion api

        #region leagues
        public static int[] topLeaguesIds = new int[] { 39, 140, 78, 135, 61, 94, 88, 71, 235, 180 };
        #endregion leagues
    }
}
