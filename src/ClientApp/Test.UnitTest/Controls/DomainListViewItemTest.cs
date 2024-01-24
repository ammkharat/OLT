using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Controls
{
    [TestFixture]
    public class DomainListViewItemTest
    {
        [Test]
        public void DomainListViewItemShouldRepresentActionItem()
        {
            ActionItemDefinition testItem = ActionItemDefinitionFixture.CreateActionItemDefinition();
            DomainListViewItem<ActionItemDefinition> domainListViewItem = new DomainListViewItem<ActionItemDefinition>(testItem);

        }

        [Test]
        public void DomainListViewItemShouldRepresentTarget()
        {
            TargetDefinition testItem = TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndActiveTargetFixture();
            DomainListViewItem<TargetDefinition> domainListViewItem = new DomainListViewItem<TargetDefinition>(testItem);
        }
    }
}
