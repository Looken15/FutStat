using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStat.Abstract
{
    public interface IApiService
    {
        string GetFromAPI(string endpoint);
    }
}
