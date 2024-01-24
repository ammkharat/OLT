using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.FlocSet
{
    [TestFixture]
    public class RootFlocSetTest
    {
        [Test]
        public void ShouldReturnFullHierarciesOfFlocWhenDoingToString()
        {
            RootFlocSet rootFlocSet = new RootFlocSet(FunctionalLocationFixture.CreateNew("A-B-C-D1-E2-F3-TROY"));
            Assert.That(rootFlocSet.ToString(), Is.EqualTo("A-B-C-D1-E2-F3-TROY"));
        }

        [Test]
        public void ShouldReturnFullHierarciesOfFlocsWhenDoingToString()
        {
            string fullHierarchy1 = "A-B-C-D1-E2-F3";
            string fullHierarchy2 = "A-B-C-D1-Z2-Y3";

            List<FunctionalLocation> flocSet = new List<FunctionalLocation>
                {
                    FunctionalLocationFixture.CreateNew(fullHierarchy1),
                    FunctionalLocationFixture.CreateNew(fullHierarchy2)
                };
                
            RootFlocSet rootFlocSet = new RootFlocSet(flocSet);
            Assert.That(rootFlocSet.ToString(), Is.EqualTo(fullHierarchy1 + ", " + fullHierarchy2));
        }

    }
}
