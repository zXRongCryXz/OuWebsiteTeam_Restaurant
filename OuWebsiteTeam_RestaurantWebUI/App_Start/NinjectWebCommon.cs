[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OuWebsiteTeam_RestaurantWebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OuWebsiteTeam_RestaurantWebUI.App_Start.NinjectWebCommon), "Stop")]

namespace OuWebsiteTeam_RestaurantWebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using OuWebsiteTeam_RestaurantService.InterfaceEx.Module;
    using OuWebsiteTeam_RestaurantService.Models.Module;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Dependency - NP
            kernel.Bind<IRestaurantInfo>().To<RestaurantInfo>();
            kernel.Bind<IBanners>().To<Banners>();
            kernel.Bind<IFeedbacks>().To<Feedbacks>();
            kernel.Bind<IFoods>().To<Foods>();
            kernel.Bind<IBookTable>().To<BookTable>();
        }        
    }
}
