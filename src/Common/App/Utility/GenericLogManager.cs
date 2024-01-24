using System;
using Com.Suncor.Olt.Common.Extension;
using log4net;

namespace Com.Suncor.Olt.Common.Utility
{
    public static class GenericLogManager
    {
        public static ILog GetLogger<T>()
        {
            return GetLogger(typeof (T));
        }

        private static ILog GetLogger(Type type)
        {
            try
            {
                return LogManager.GetLogger(CreateLoggerNameString(type));
            }
            catch (Exception)
            {
                return LogManager.GetLogger(type);
            }
        }

        public static string CreateLoggerNameString(Type type)
        {
            var genericArguments = type.GetGenericArguments();
            if (genericArguments.Length == 0)
            {
                return type.FullName;
            }

            var results = genericArguments.ConvertAll(g => CreateLoggerNameString(g));

            return string.Format("{0}.{1}<{2}>", type.Namespace, type.Name, results.BuildCommaSeparatedList());
        }
    }
}