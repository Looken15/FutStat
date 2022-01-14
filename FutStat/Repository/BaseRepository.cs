using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStat.Repository
{
    public class BaseRepository
    {
        public readonly FutContext db;
        public BaseRepository()
        {
            db = new FutContext();
        }
    }
}
