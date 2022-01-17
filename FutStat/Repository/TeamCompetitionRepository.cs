using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Abstract;
using FutStat.Models;
using System.Data.Entity;

namespace FutStat.Repository
{
    public class TeamCompetitionRepository : BaseRepository, ITeamCompetitionRepository
    {
        public IQueryable<TeamCompetition> GetTeamCompetitions()
        {
            return db.TeamCompetitions.Include(x => x.Team).Include(x => x.Competition);
        }
        public void Add(TeamCompetition teamCompetition)
        {
            db.TeamCompetitions.Add(teamCompetition);
            db.SaveChanges();
        }
    }
}
