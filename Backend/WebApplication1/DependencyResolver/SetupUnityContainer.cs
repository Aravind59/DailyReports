using DailyReports.Contracts.Interfaces;
using DailyReports.Service;
using Unity;
using Unity.Lifetime;

namespace DailyReports.DependencyResolver
{
    public static class SetupUnityContainerHelper
    {

        public static UnityContainer SetupUnityContainer()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IDailyReports, DailyReportsService>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<ISuppliers, SuppliersService>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IStationsService, StationsService>(new HierarchicalLifetimeManager());
           
            return unityContainer;
        }

    }
}