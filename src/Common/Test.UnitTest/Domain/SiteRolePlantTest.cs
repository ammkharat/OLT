using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class SiteRolePlantTest
    {
        [Test]
        public void ChoosePlantIdsShouldFilterByRole()
        {
            Site sarnia = SiteFixture.Sarnia();

            Role operatorRole = RoleFixture.CreateOperatorRole();
            Role supervisorRole = RoleFixture.CreateSupervisorRole();
            
            const long plantIdOne = 1000;
            const long plantIdTwo = 2000;

            List<SiteRolePlant> siteRolePlants = new List<SiteRolePlant>
                                                     {
                                                         new SiteRolePlant(sarnia, operatorRole, plantIdOne),
                                                         new SiteRolePlant(sarnia, supervisorRole, plantIdOne),
                                                         new SiteRolePlant(sarnia, supervisorRole, plantIdTwo)
                                                    };

            {
                List<long> plantIds = SiteRolePlant.ChoosePlantIds(operatorRole, siteRolePlants);
                Assert.AreEqual(1, plantIds.Count);
                Assert.AreEqual(plantIdOne, plantIds[0]);
            }

            {
                List<long> plantIds = SiteRolePlant.ChoosePlantIds(supervisorRole, siteRolePlants);
                Assert.AreEqual(2, plantIds.Count);
                Assert.IsTrue(plantIds.Exists(id => id == plantIdOne));
                Assert.IsTrue(plantIds.Exists(id => id == plantIdTwo));
            }
        }
    }
}
