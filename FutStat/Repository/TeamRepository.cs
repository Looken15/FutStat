using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Abstract;
using FutStat.Models;

namespace FutStat.Repository
{
    public class TeamRepository : BaseRepository, ITeamRepository
    {
        public Team GetTeam(int teamId)
        {
            return db.Teams.Where(x => x.TeamId == teamId).FirstOrDefault();
        }
        public IQueryable<Team> GetTeams()
        {
            return db.Teams;
        }
        public void Add(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
        }
    }
}
