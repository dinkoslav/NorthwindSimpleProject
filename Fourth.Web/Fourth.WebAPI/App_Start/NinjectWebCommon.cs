[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Fourth.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Fourth.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace Fourth.WebAPI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Database;
    using Data;
    using Data.DataHandlers.Interfaces;
    using Data.DataHandlers;
    using ApiServices.Interfaces;
    using ApiServices;
    using AutoMapper;
    using AutomapperProfiles;

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
                NinjectWebCommon.InitializeAutomapperConfig();
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
            kernel.Bind<NorthwindDbContext>().ToSelf();
            kernel.Bind<INorthwindData>().To<NorthwindData>().InRequestScope();
            kernel.Bind<IMapperService>().To<MapperService>().InRequestScope();

            kernel.Bind<ICustomerDataHandler>().To<CustomerDataHandler>();

            kernel.Bind<ICustomerService>().To<CustomerService>();
        }

        private static void InitializeAutomapperConfig()
        {
            Mapper.Initialize(NinjectWebCommon.AddProfilesToAutomapperConfig);
        }

        private static void AddProfilesToAutomapperConfig(IMapperConfigurationExpression config)
        {
            config.AddProfile(new CustomerProfile());
            config.AddProfile(new OrderProfile());
        }
    }
}
