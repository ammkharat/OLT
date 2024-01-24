using System.Threading;
using Com.Suncor.Olt.Remote.Bootstrap;
using log4net;
using log4net.Config;

namespace App_Code
{
    public class Main
    {
        public static void AppInitialize()
        {
            XmlConfigurator.Configure();

            ILog logger = LogManager.GetLogger(typeof(Main));
            logger.Debug("Starting AppInitialize");
            int minThreads;
            int maxThreads;
            int completionPortThreads;

            ThreadPool.GetMinThreads(out minThreads, out completionPortThreads);
            logger.Debug("ThreadPool.MinThreads: " + minThreads);
            logger.Debug("ThreadPool.Completion Port Threads: " + completionPortThreads);
            ThreadPool.GetMaxThreads(out maxThreads, out completionPortThreads);
            logger.Debug("ThreadPool.MaxThreads: " + maxThreads);
            logger.Debug("Bootstrapping.");
            Bootstrapper.Bootstrap();
           
            logger.Debug("Done AppInitialize");
        }
    }
}