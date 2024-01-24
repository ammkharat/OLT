using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class DomainEventArgsTest
    {
        [Test]
        public void DomainEventArgsShouldHoldDomainObject()
        {
            ActionItemDefinition testItem = ActionItemDefinitionFixture.CreateActionItemDefinition();
            DomainEventArgs <ActionItemDefinition> eventArgs = new DomainEventArgs <ActionItemDefinition>(testItem);
            Assert.AreEqual(testItem, eventArgs.SelectedItem);
        }
    }
}