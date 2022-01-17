﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models;

namespace FutStat.Abstract
{
    public interface ITeamService
    {
        List<TeamCompetition> GetTeams(int competitionId);
        void ParseCompetition();
    }
}
