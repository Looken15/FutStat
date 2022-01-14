using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models.Teams;
using FutStat.Abstract;
using System.Data.Entity;

namespace FutStat.Repository
{
    public class TeamsRepository : BaseRepository, ITeamsRepository
    {
        public IQueryable<Team> GetTeams()
        {
            return db.Teams
                           .Include(x => x.League)
                           .Include(x => x.Country);
        }
        public void Add(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
        }
    }
}
