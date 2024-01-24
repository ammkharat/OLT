using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Exceptions;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    /// <summary>
    /// This is the central place in the application to look for a database accessor based on a type,
    /// the type usually being a domain object.  The registry needs to be initialized when the application
    /// starts.
    /// </summary>
    public static class DaoRegistry
    {
        private static readonly Dictionary<string, IDao> daos = new Dictionary<string, IDao>();

        /// <summary>
        /// Registers a DataAccessObject for a domain object type
        /// </summary>
        /// <param name="dao">The DataAccessObject implementation </param>
        public static void RegisterDaoFor<T>(T dao) where T : IDao
        {
            string fullName = GenerateKey<T>();

            try
            {
                if (fullName != null) daos.Add(fullName, dao);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("DaoRegistry already contains the key", fullName, e);
            }
        }

        private static string GenerateKey<T>()
        {
            return typeof (T).FullName;
        }

        public static T GetDao<T>() where T : IDao
        {
            T result;

            string key = GenerateKey<T>();
            try
            {
                result = (T)daos[key];
            }
            catch (KeyNotFoundException e)
            {
                Type theDaoType = typeof(T);

                string message =
                    string.Format("The key '{0}' for type '{1}' was not found in the dictionary.", key,
                                  theDaoType.Name);

                throw new ApplicationException(message, e);
            }

            if (Equals(result, default(T)))
            {
                throw new NoRegisteredImplementationException(
                    string.Format("No Dao implementation found for {0}",
                                  typeof (T).FullName));
            }
            return result;
            
        }

        /// <summary>
        /// Clears All of the registered dao implementation in the registry
        /// </summary>
        public static void Clear()
        {
            daos.Clear();
        }
    }
}