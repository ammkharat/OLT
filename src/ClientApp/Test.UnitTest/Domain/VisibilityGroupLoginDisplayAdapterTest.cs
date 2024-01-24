using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain
{
    [TestFixture]
    public class VisibilityGroupLoginDisplayAdapterTest
    {
        [Test]
        public void ShouldDetermineIfAtLeastOneReadAndWriteMatch()
        {
            {
                List<VisibilityGroupLoginDisplayAdapter> adapters = new List<VisibilityGroupLoginDisplayAdapter>();
                adapters.Add(new VisibilityGroupLoginDisplayAdapter(1, "Group 1", false, true));
                adapters.Add(new VisibilityGroupLoginDisplayAdapter(1, "Group 2", true, false));
                adapters.Add(new VisibilityGroupLoginDisplayAdapter(1, "Group 3", false, false));
                adapters.Add(new VisibilityGroupLoginDisplayAdapter(1, "Group 4", true, true));
                adapters.Add(new VisibilityGroupLoginDisplayAdapter(1, "Group 5", true, false));

                bool atLeastOneHasMatchingReadWrite = VisibilityGroupLoginDisplayAdapter.ListHasAtLeastOneMatchingReadAndWrite(adapters);
                Assert.IsTrue(atLeastOneHasMatchingReadWrite);                
            }

            {
                List<VisibilityGroupLoginDisplayAdapter> adapters = new List<VisibilityGroupLoginDisplayAdapter>();
                adapters.Add(new VisibilityGroupLoginDisplayAdapter(1, "Group 1", false, true));
                adapters.Add(new VisibilityGroupLoginDisplayAdapter(1, "Group 2", true, false));
                adapters.Add(new VisibilityGroupLoginDisplayAdapter(1, "Group 3", false, false));
                adapters.Add(new VisibilityGroupLoginDisplayAdapter(1, "Group 4", false, true));
                adapters.Add(new VisibilityGroupLoginDisplayAdapter(1, "Group 5", true, false));

                bool atLeastOneHasMatchingReadWrite = VisibilityGroupLoginDisplayAdapter.ListHasAtLeastOneMatchingReadAndWrite(adapters);
                Assert.IsFalse(atLeastOneHasMatchingReadWrite);
            }
        }
    }
}
