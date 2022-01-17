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
    public class AreaRepository : BaseRepository, IAreaRepository
    {
        public IQueryable<Area> GetAreas()
        {
            return db.Areas;
        }
        public Area GetArea(int areaId)
        {
            return db.Areas.FirstOrDefault(x => x.AreaId == areaId);
        }

        public void Add(Area area)
        {
            db.Areas.Add(area);
            db.SaveChanges();
        }
    }
}
