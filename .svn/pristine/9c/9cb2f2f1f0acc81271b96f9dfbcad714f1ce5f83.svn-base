using System;
using System.Reflection;
using log4net;

namespace Com.Suncor.Olt.Common.Utility
{
    public class AssemblyUtil
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<AssemblyUtil>();

        public static bool IsDebugMode()
        {
            var isDebug = false;

#if DEBUG
            isDebug = true;
#endif

            return isDebug;
        }

        public static Type[] GetTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                logger.Info(String.Format("Cannot get types from {0}.", assembly.FullName), e);
                logger.Info("There loader exceptions are:");
                foreach (var loaderException in e.LoaderExceptions)
                {
                    logger.Info(loaderException.Message);
                }

                return Array.FindAll(e.Types, obj => obj != null);
            }
            catch (Exception e)
            {
                logger.Error(String.Format("Cannot get types from {0}.", assembly.FullName), e);
                throw;
            }
        }
    }
}