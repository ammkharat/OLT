using System;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ISecurityService
    {
        /// <summary>
        ///     Method for authenticating a credential for the Operator Log Tool
        /// </summary>
        /// <param name="username">the username</param>
        /// <param name="encryptedPassword">the encryptedPassword</param>
        /// <returns>A filled user object if authenticated, null otherwise</returns>
        [OperationContract]
        User Authenticate(string username, string encryptedPassword);

        [OperationContract]
        Version GetAssemblyVersion();
    }
}