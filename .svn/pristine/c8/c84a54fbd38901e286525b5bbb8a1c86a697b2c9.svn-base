using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client
{
    [TestFixture]
    public class ClientVersioningTest
    {
        [Ignore]
        [Test]
        public void TestClientIsGettingAVersionNumberFromBuildNumber()
        {
            string buildNumber = ConfigurationManager.AppSettings["BuildNumber"];
            
            if (!buildNumber.StartsWith("$("))
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

                string versionString = versionInfo.FileMajorPart + "." + versionInfo.FileMinorPart + "." + versionInfo.FileBuildPart;
                    
                Assert.AreEqual(buildNumber, versionString);                
                
            }
            
        }
    }
}
