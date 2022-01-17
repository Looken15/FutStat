using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using FutStat.Abstract;
using FutStat.Services;
using FutStat.Repository;

namespace FutStat.IoC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            #region api
            container.RegisterType<IApiService, ApiService>();
            #endregion

            #region areas
            container.RegisterType<IAreaRepository, AreaRepository>();
            #endregion

            #region competitions
            container.RegisterType<ICompetitionRepository, CompetitionRepository>();
            container.RegisterType<ICompetitionService, CompetitionService>();
            #endregion

            return container;
        }
    }
}
