using System;
using NUnit.Framework;
using System.Configuration;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class ConstantsTest
    {
        [Test]
        public void ShouldGetRemoteDBConnectionString()
        {
            ConfigurationManager.RefreshSection("connectionStrings");
            ConnectionStringSettingsCollection connectionStringSettingsCollection = ConfigurationManager.ConnectionStrings;

/*
            foreach (ConnectionStringSettings connectionStringSettings in connectionStringSettingsCollection)
            {
                Console.Out.WriteLine(connectionStringSettings.Name + ":" + connectionStringSettings.ConnectionString);
            }
*/

            Assert.AreEqual("ConnectionStringTest", Constants.OLT_REMOTE_APP_CONNECTION_STRING);
        }
    }
}
