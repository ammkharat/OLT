using System.Diagnostics;
using Castle.DynamicProxy;
using log4net;

namespace Com.Suncor.Olt.Remote.Caching
{
    internal static class InvocationExtensions
    {
        internal static void LogAndProceed(this IInvocation invocation, ILog logger, string cachingKey, Stopwatch stopwatch)
        {
            if (logger.IsDebugEnabled)
            {
                stopwatch.Start();
            }

            // the invocation that is being timed.
            invocation.Proceed();

            if (logger.IsDebugEnabled)
            {
                stopwatch.Stop();
                logger.DebugFormat("Pulling {0} from database took {1}ms.", cachingKey, stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();
            }
        }
    }
}