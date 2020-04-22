using Practice5.WebUI.Repositories;
using Practice5.WebUI.Repositories.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Practice5.WebUI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IFlowerRepository, FlowerRepository>();
            container.RegisterType<IPlantationRepository, PlantationRepository>();
            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}