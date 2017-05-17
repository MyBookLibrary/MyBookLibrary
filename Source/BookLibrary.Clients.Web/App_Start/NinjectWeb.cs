using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BookLibrary.App_Start.NinjectWeb), "Start")]

namespace BookLibrary.App_Start
{
    

    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
