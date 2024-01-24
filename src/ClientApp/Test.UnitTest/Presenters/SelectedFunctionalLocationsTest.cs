using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class SelectedFunctionalLocationsTest
    {
        [Test]
        public void ShouldRemoveExistingFlocWhenParentFlocIsSelected()
        {
            FunctionalLocation floc2 = FunctionalLocationFixture.CreateNew("SR1-PLT2");
            FunctionalLocation floc3 = FunctionalLocationFixture.CreateNew("SR1-PLT3");

            var selectedFunctionalLocations = new SelectedFunctionalLocations(new List<FunctionalLocation>
                                                                                  {
                                                                                      floc2,
                                                                                      floc3
                                                                                  });

            FunctionalLocation floc1 = FunctionalLocationFixture.CreateNew("SR1");

            selectedFunctionalLocations.AddSelectedFunctionalLocation(floc1);
            
            Assert.That(selectedFunctionalLocations.Has(floc1), Is.True);
            Assert.That(selectedFunctionalLocations.Has(floc2), Is.False);
        }

        [Test]
        public void ShouldHaveExistingFloc()
        {
            FunctionalLocation floc2 = FunctionalLocationFixture.CreateNew("SR1-PLT2");
            FunctionalLocation floc3 = FunctionalLocationFixture.CreateNew("SR1-PLT3");

            var selectedFunctionalLocations = new SelectedFunctionalLocations(new List<FunctionalLocation>
                                                                                  {
                                                                                      floc2,
                                                                                      floc3
                                                                                  });

            FunctionalLocation floc = FunctionalLocationFixture.CreateNew(floc2.IdValue, floc2.FullHierarchy);
            Assert.That(selectedFunctionalLocations.Has(floc));
        }

        [Test]
        public void ShouldRemoveExistingFloc()
        {
            FunctionalLocation floc2 = FunctionalLocationFixture.CreateNew("SR1-PLT2");
            FunctionalLocation floc3 = FunctionalLocationFixture.CreateNew("SR1-PLT3");

            var selectedFunctionalLocations = new SelectedFunctionalLocations(new List<FunctionalLocation>
                                                                                  {
                                                                                      floc2,
                                                                                      floc3
                                                                                  });
            
            Assert.That(selectedFunctionalLocations.ToReadOnlyList.Count, Is.EqualTo(2));

            selectedFunctionalLocations.RemoveSelectedFunctionalLocation(floc2);
            Assert.That(selectedFunctionalLocations.ToReadOnlyList.Count, Is.EqualTo(1));
        }

    }
}
