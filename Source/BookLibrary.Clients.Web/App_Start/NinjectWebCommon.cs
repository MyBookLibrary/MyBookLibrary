using System;
using System.Web;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using BookLibrary.Data.Provider.Contracts;
using BookLibrary.Data.Provider;
using BookLibrary.Data.Provider.Operations;
using BookLibrary.Data.Services.Contracts;
using BookLibrary.Data.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BookLibrary.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BookLibrary.App_Start.NinjectWebCommon), "Stop")]

namespace BookLibrary.App_Start
{
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
            Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(Kernel);
                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Expose the kernal to be used in other project classes
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel Kernel { get; private set; }
        
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Data provider
            kernel.Bind<IBookLibraryDbContext>().To<BookLibraryDbContext>().InRequestScope();
            kernel.Bind<IEfDbContextSaveChanges>().To<EfDbContextSaveChanges>();
            kernel.Bind(typeof(IEfCrudOperatons<>)).To(typeof(EfCrudOperatons<>));

            // Auth services
            // TODO

            // Data services
            kernel.Bind<IAuthorService>().To<AuthorService>();
            kernel.Bind<IBookService>().To<BookService>();
        }
    }
}
