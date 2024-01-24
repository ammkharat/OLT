using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class TargetValueTest
    {
        private Mockery mockery;
        private ITargetAction targetAction;

        [SetUp]
        public void SetUp()
        {
            mockery = new Mockery();
            targetAction = mockery.NewMock<ITargetAction>();
        }
        
        [Test]
        public void OnDoShouldInvokeActionForMinimize()
        {
            Expect.Once.On(targetAction).Method("DoForMinimize");
            TargetValue.CreateMinimizeTarget().Do(targetAction);
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnDoShouldInvokeActionForMaximize()
        {
            Expect.Once.On(targetAction).Method("DoForMaximize");
            TargetValue.CreateMaximizeTarget().Do(targetAction);
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnDoShouldInvokeActionForEmpty()
        {
            Expect.Once.On(targetAction).Method("DoForEmpty");
            TargetValue.CreateEmptyTarget().Do(targetAction);
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnDoShouldInvokeActionWithSpecifiedValue()
        {
            Expect.Once.On(targetAction).Method("DoWithSpecifiedValue").With(6.0m);
            TargetValue.CreateSpecifiedTarget(6.0m).Do(targetAction);
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnGetTitleShouldReturnMinForMinimize()
        {
            Assert.AreEqual("Minimize", TargetValue.CreateMinimizeTarget().Title);
        }

        [Test]
        public void OnGetTitleShouldReturnMaxForMaximize()
        {
            Assert.AreEqual("Maximize", TargetValue.CreateMaximizeTarget().Title);
        }

        [Test]
        public void OnGetTitleShouldReturnEmptyStringForEmpty()
        {
            Assert.AreEqual(string.Empty, TargetValue.CreateEmptyTarget().Title);
        }

        [Test][Ignore]
        public void OnGetTitleShouldReturnSpecifiedValue()
        {
            Assert.AreEqual((6.00m).ToString(), TargetValue.CreateSpecifiedTarget(6.00m).Title);
        }

        [Test]
        public void OnEqualsShouldEvaluateTwoMinimizesToBeEqual()
        {
            Assert.AreEqual(TargetValue.CreateMinimizeTarget(), TargetValue.CreateMinimizeTarget());
        }

        [Test]
        public void OnEqualsShouldEvaluateTwoMaximizesToBeEqual()
        {
            Assert.AreEqual(TargetValue.CreateMaximizeTarget(), TargetValue.CreateMaximizeTarget());
        }

        [Test]
        public void OnEqualsShouldEvaluateMinimizeAndMaximizeAsNotEqual()
        {
            Assert.AreNotEqual(TargetValue.CreateMinimizeTarget(), TargetValue.CreateMaximizeTarget());
        }

        [Test]
        public void OnEqualsShouldEvaluateSpecifiedTargetsAsEqualIfSpecifiedValuesEqual()
        {
            Assert.AreEqual(TargetValue.CreateSpecifiedTarget(6.0m), TargetValue.CreateSpecifiedTarget(6.0m));
        }

        [Test]
        public void OnEqualsShouldEvaluateSpecifiedTargetsAsNotEqualIfSpecifiedValuesNotEqual()
        {
            Assert.AreNotEqual(TargetValue.CreateSpecifiedTarget(7.0m), TargetValue.CreateSpecifiedTarget(6.0m));
        }

        [Test]
        public void OnEqualsShouldEvaluateSpecifiedTargetAsNotEqualToMinimize()
        {
            Assert.AreNotEqual(TargetValue.CreateSpecifiedTarget(0.0m), TargetValue.CreateMinimizeTarget());
        }

        [Test]
        public void OnEqualsShouldEvaluateSpecifiedTargetAsNotEqualToMaximize()
        {
            Assert.AreNotEqual(TargetValue.CreateSpecifiedTarget(0.0m), TargetValue.CreateMaximizeTarget());
        }

        [Test]
        public void OnEqualsShouldEvaluateEmptySpecifiedTargetAsNotEqualToNonEmptySpecifiedTarget()
        {
            Assert.AreNotEqual(TargetValue.CreateEmptyTarget(), TargetValue.CreateSpecifiedTarget(0.0m));
        }

        [Test]
        public void OnEqualsShouldEvaluateTwoEmptySpecifiedTargetsAsEqual()
        {
            Assert.AreEqual(TargetValue.CreateEmptyTarget(), TargetValue.CreateEmptyTarget());
        }
        
        [Test]
        public void ToStringShouldReturnAnEmptyStringForAnEmptyTarget()
        {
            Assert.AreEqual("", TargetValue.CreateEmptyTarget().ToString());
        }

        [Test][Ignore]
        public void ToStringShouldReturnAValueForSpecifiedTargetValue()
        {
            Assert.AreEqual("6.00", TargetValue.CreateSpecifiedTarget(6.0m).ToString());
        }

        [Test]
        public void ToStringShouldDisplayMinimizeForAMinimizeTargetValue()
        {
            Assert.AreEqual("Minimize", TargetValue.CreateMinimizeTarget().ToString());
        }

        [Test]
        public void ToStringShouldDisplayMaximizeForMaximizeTargetValue()
        {
            Assert.AreEqual("Maximize", TargetValue.CreateMaximizeTarget().ToString());
        }
    }
}
