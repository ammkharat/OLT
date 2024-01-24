using System;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class TargetDefinitionStateTest
    {
        [Test]
        public void NoChangeToTagsShouldNotChangeAnythingOnState()
        {
            DateTime now = Clock.Now;
            TargetDefinitionState targetDefinitionState = new TargetDefinitionState(null, true, now);
            targetDefinitionState.Update(new TagChangedState());
            Assert.That(targetDefinitionState.IsExceedingBoundary, Is.EqualTo(true));
            Assert.That(targetDefinitionState.LastSuccessfulTagAccess, Is.EqualTo(now));
        }

        [Test]
        public void ChangingTheReadTagWillResetState()
        {
            DateTime now = Clock.Now;
            TargetDefinitionState targetDefinitionState = new TargetDefinitionState(null, true, now);
            targetDefinitionState.Update(new TagChangedState{ TagHasChanged = true});
            Assert.That(targetDefinitionState.IsExceedingBoundary, Is.EqualTo(false));
            Assert.That(targetDefinitionState.LastSuccessfulTagAccess, Is.Null);
        }

        [Test]
        public void ChangingOneOfTheWriteTagsWillOnlyResetLastAccessAndNotChangeIsExceedingBoundary()
        {
            DateTime now = Clock.Now;
            TargetDefinitionState targetDefinitionState = new TargetDefinitionState(null, true, now);
            targetDefinitionState.Update(new TagChangedState { ReadWriteTagConfigurationHasChanged = true});
            Assert.That(targetDefinitionState.IsExceedingBoundary, Is.EqualTo(true));
            Assert.That(targetDefinitionState.LastSuccessfulTagAccess, Is.Null);
        }

    }
}