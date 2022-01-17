using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStat.Models
{
    public class Area
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string FlagUrl { get; set; }
        public int? ParentAreaId { get; set; }
    }
}
