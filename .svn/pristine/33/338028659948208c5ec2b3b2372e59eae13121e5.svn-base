using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class RoleElementTemplateValuesContainerTest
    {
        [Test]
        public void ShouldGetRoleValuesInThisListNotInThatList()
        {
            RoleElementTemplateValuesContainer thisOne = new RoleElementTemplateValuesContainer();
            RoleElementTemplateValuesContainer thatOne = new RoleElementTemplateValuesContainer();

            Role adminRole = RoleFixture.CreateAdministratorRole();

            thisOne.Add(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_LOG));
            thisOne.Add(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_ACTIONITEM));
            thisOne.Add(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_TARGETDEFINITION));

            thatOne.Add(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_LOG));
            thatOne.Add(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_TARGETDEFINITION));
            thatOne.Add(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_COKER_CARD));

            {
                List<RoleElementTemplateValue> result = thisOne.GetItemsInThisThatAreNotIn(thatOne);
                Assert.That(result.Count, Is.EqualTo(1));
                Assert.That(result[0], Is.EqualTo(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_ACTIONITEM)));

            }
            {
                List<RoleElementTemplateValue> result = thatOne.GetItemsInThisThatAreNotIn(thisOne);
                Assert.That(result.Count, Is.EqualTo(1));
                Assert.That(result[0], Is.EqualTo(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_COKER_CARD)));
            }
        }

        [Test]
        public void ShouldGetRoleValuesInThisListNotInThatList_VaryRole()
        {
            RoleElementTemplateValuesContainer thisOne = new RoleElementTemplateValuesContainer();
            RoleElementTemplateValuesContainer thatOne = new RoleElementTemplateValuesContainer();

            Role adminRole = RoleFixture.CreateAdministratorRole();
            Role engineerRole = RoleFixture.CreateEngineeringSupportRole();

            thisOne.Add(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_LOG));
            thisOne.Add(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_TARGETDEFINITION));

            thatOne.Add(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_TARGETDEFINITION));
            thatOne.Add(new RoleElementTemplateValue(engineerRole, RoleElement.VIEW_LOG));

            {
                List<RoleElementTemplateValue> result = thisOne.GetItemsInThisThatAreNotIn(thatOne);
                Assert.That(result.Count, Is.EqualTo(1));
                Assert.That(result[0], Is.EqualTo(new RoleElementTemplateValue(adminRole, RoleElement.VIEW_LOG)));

            }
            {
                List<RoleElementTemplateValue> result = thatOne.GetItemsInThisThatAreNotIn(thisOne);
                Assert.That(result.Count, Is.EqualTo(1));
                Assert.That(result[0], Is.EqualTo(new RoleElementTemplateValue(engineerRole, RoleElement.VIEW_LOG)));
            }
        }
    }
}
