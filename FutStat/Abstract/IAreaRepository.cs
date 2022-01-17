using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutStat.Models;

namespace FutStat.Abstract
{
    public interface IAreaRepository
    {
        IQueryable<Area> GetAreas();
        Area GetArea(int areaId);
        void Add(Area area);
    }
}
