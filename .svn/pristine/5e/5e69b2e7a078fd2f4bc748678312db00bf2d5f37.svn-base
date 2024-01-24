using System.Diagnostics;
using Castle.DynamicProxy;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    public class StoredProcPerformanceInterceptor : IInterceptor
    {
        private readonly long thresholdInMilliseconds;
        private static readonly ILog logger = GenericLogManager.GetLogger<StoredProcPerformanceInterceptor>();

        public StoredProcPerformanceInterceptor(long thresholdInMilliseconds)
        {
            this.thresholdInMilliseconds = thresholdInMilliseconds;            
        }

        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > thresholdInMilliseconds)
            {
                logger.WarnFormat("{0}.{1} took {2}ms.", invocation.Method.DeclaringType, invocation.Method.Name, stopwatch.ElapsedMilliseconds);
            }
            else if (stopwatch.ElapsedMilliseconds > 2000)
            {
                logger.DebugFormat("{0}.{1} took {2}ms.", invocation.Method.DeclaringType, invocation.Method.Name, stopwatch.ElapsedMilliseconds);                
            }
        }
    }
}