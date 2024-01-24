using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class WorkPermitBinderTest
    {
        private readonly long SARNIA_SITE_ID = SiteFixture.Sarnia().Id.Value;
        private readonly long DENVER_SITE_ID = SiteFixture.Denver().Id.Value;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
        }

        private class TestBasicWorkPermitModel
        {
            [SarniaWorkPermit, DenverWorkPermit]
            public string Activity { get; set; }

            [SarniaWorkPermit, DenverWorkPermit]
            public DateTime DateTime { get; set; }

            [SarniaWorkPermit, DenverWorkPermit]
            public int NumberOfWorkers { get; set; }

            [SarniaWorkPermit, DenverWorkPermit]
            public long? NumberOfSupervisors { get; set; }

            [SarniaWorkPermit]
            public bool SarniaOnlyProperty { get; set; }

            [DenverWorkPermit]
            public bool DenverOnlyProperty { get; set; }

            public bool NotApplicableToAnySite { get; set; }
        }

        private class TestBasicWorkPermitView
        {
            public string Activity { get; set; }
            public DateTime DateTime { get; set; }
            public int NumberOfWorkers { get; set; }
            public long? NumberOfSupervisors { get; set; }
            public bool SarniaOnlyProperty { get; set; }
            public bool DenverOnlyProperty { get; set; }
            public bool NotApplicableToAnySite { get; set; }
        }

        private class TestBasicWorkPermitModelWithOneProperty
        {
            [SarniaWorkPermit]
            public string PocketProtector { get; set; }
        }

        private class TestBasicWorkPermitModelWithSetterPreCondition
        {
            public bool IsActivityRequired { get; set; }

            [SarniaWorkPermit("IsActivityRequired")]
            public string Activity { get; set; }
        }

        private class TestBasicWorkPermitModelWithNegatedSetterPreCondition
        {
            public bool IsActivityNotApplicable { get; set; }

            [SarniaWorkPermit("!IsActivityNotApplicable")]
            public string Activity { get; set; }
        }

        private class TestBasicWorkPermitModelWithUndefinedSetterPreCondition
        {
            [SarniaWorkPermit("FraggleRock")]
            public string Activity { get; set; }
        }

        private class TestBasicWorkPermitViewWithMissingProperty
        {
        }

        private class TestWorkPermitModelWithGroup
        {
            [SarniaWorkPermit]
            public string Description { get; set; }

            [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
            public TestWorkPermitGroupShoes Shoes { get; set; }
        }

        private class TestWorkPermitModelWithAliasedGroup
        {
            [SarniaWorkPermit]
            public string Description { get; set; }

            [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
            public TestWorkPermitGroupHats Hats { get; set; }

            [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
            public TestWorkPermitGroupShoes Shoes { get; set; }
        }

        private class TestWorkPermitGroupShoes
        {
            [SarniaWorkPermit]
            public bool IsSteelToed { get; set; }
        }

        [Alias("BrainProtector")]
        private class TestWorkPermitGroupHats
        {
            [SarniaWorkPermit]
            public string Material { get; set; }
        }

        private class TestWorkPermitViewWithGroups
        {
            public string Description { get; set; }
            public bool IsSteelToed { get; set; }
            public string BrainProtectorMaterial { get; set; }
        }

        private class TestWorkPermitModelWithOrdering
        {
            [SarniaWorkPermit(WorkPermitAttribute.Ordering.FourthSet, "IsUnderwearApplicable")]
            public bool IsSkinApplicable { get; set; }

            [SarniaWorkPermit(WorkPermitAttribute.Ordering.SecondSet, "IsAnythingApplicable")]
            public bool IsClothingApplicable { get; set; }

            [SarniaWorkPermit(WorkPermitAttribute.Ordering.ThirdSet, "IsClothingApplicable")]
            public bool IsUnderwearApplicable { get; set; }

            [SarniaWorkPermit(WorkPermitAttribute.Ordering.FirstSet)]
            public bool IsAnythingApplicable { get; set; }
        }

        private class TestWorkPermitViewWithOrdering
        {
            public bool IsSkinApplicable { get; set; }
            public bool IsClothingApplicable { get; set; }
            public bool IsUnderwearApplicable { get; set; }
            public bool IsAnythingApplicable { get; set; }
        }

        private class TestWorkPermitModelDefaultValues
        {
            public bool ReturnFalse { get { return false;  } }

            [SarniaWorkPermit("ReturnFalse")]
            public bool BooleanProperty { get; set; }
            [SarniaWorkPermit("ReturnFalse")]
            public bool? NullableBooleanProperty { get; set; }
            [SarniaWorkPermit("ReturnFalse")]
            public string StringProperty { get; set; }
        }

        private class TestWorkPermitViewDefaultValues
        {
            public bool BooleanProperty { get; set; }
            public bool? NullableBooleanProperty { get; set; }
            public string StringProperty { get; set; }
        }

        [Test]
        public void ToModelForDenverShouldMapApplicableViewObjectPropertiesOnToModel()
        {
            var model = new TestBasicWorkPermitModel();
            var view = new TestBasicWorkPermitView
                           {
                               Activity = "My Activity",
                               DateTime = Clock.Now,
                               NumberOfWorkers = 1,
                               NumberOfSupervisors = null,
                               SarniaOnlyProperty = true,
                               DenverOnlyProperty = true,
                               NotApplicableToAnySite = true
                           };

            new WorkPermitBinder(DENVER_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);

            Assert.AreEqual("My Activity", model.Activity);
            Assert.AreEqual(Clock.Now, model.DateTime);
            Assert.AreEqual(1, model.NumberOfWorkers);
            Assert.AreEqual(null, model.NumberOfSupervisors);
            Assert.IsFalse(model.SarniaOnlyProperty);
            Assert.IsTrue(model.DenverOnlyProperty);
            Assert.IsFalse(model.NotApplicableToAnySite);
        }

        [Test]
        public void ToModelForSarniaShouldMapApplicableViewObjectPropertiesOnToModel()
        {
            var model = new TestBasicWorkPermitModel();
            var view = new TestBasicWorkPermitView
                           {
                               Activity = "My Activity",
                               DateTime = Clock.Now,
                               NumberOfWorkers = 1,
                               NumberOfSupervisors = null,
                               SarniaOnlyProperty = true,
                               DenverOnlyProperty = true,
                               NotApplicableToAnySite = true
                           };


            new WorkPermitBinder(SARNIA_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);

            Assert.AreEqual("My Activity", model.Activity);
            Assert.AreEqual(Clock.Now, model.DateTime);
            Assert.AreEqual(1, model.NumberOfWorkers);
            Assert.AreEqual(null, model.NumberOfSupervisors);
            Assert.IsTrue(model.SarniaOnlyProperty);
            Assert.IsFalse(model.DenverOnlyProperty);
            Assert.IsFalse(model.NotApplicableToAnySite);
        }

        [Test]
        public void ToModelShouldHaveItsGroupsSetFromViewUsingGroupAlias()
        {
            var view = new TestWorkPermitViewWithGroups
                           {
                               Description = "Work Permit With Groups",
                               BrainProtectorMaterial = "Bowler Hat",
                               IsSteelToed = true
                           };
            var model = new TestWorkPermitModelWithAliasedGroup
                            {
                                Hats = new TestWorkPermitGroupHats(),
                                Shoes = new TestWorkPermitGroupShoes()
                            };

            new WorkPermitBinder(SARNIA_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);

            Assert.AreEqual("Work Permit With Groups", model.Description);
            Assert.IsTrue(model.Shoes.IsSteelToed);
            Assert.AreEqual("Bowler Hat", model.Hats.Material);
        }

        [Test]
        public void ToModelShouldNegateSetterConditionMethodIfPrefixedWithExclamationMarkAndNotSetIfEvaluatesToFalse()
        {
            var model = new TestBasicWorkPermitModelWithNegatedSetterPreCondition
                            {
                                IsActivityNotApplicable = true
                            };

            var view = new TestBasicWorkPermitView
                           {
                               Activity = "My Activity",
                           };

            new WorkPermitBinder(SARNIA_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);
            Assert.AreEqual(null, model.Activity);
        }

        [Test]
        public void ToModelShouldNegateSetterConditionMethodIfPrefixedWithExclamationMarkAndSetOnlyIfEvalutesToTrue()
        {
            var model = new TestBasicWorkPermitModelWithNegatedSetterPreCondition
                            {
                                IsActivityNotApplicable = false
                            };

            var view = new TestBasicWorkPermitView
                           {
                               Activity = "My Activity",
                           };

            new WorkPermitBinder(SARNIA_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);
            Assert.AreEqual("My Activity", model.Activity);
        }

        [Test]
        public void ToModelShouldNotSetPropertyIfSpecifiedSetterConditionMethodEvaluatesToFalse()
        {
            var model = new TestBasicWorkPermitModelWithSetterPreCondition
                            {
                                IsActivityRequired = false
                            };

            var view = new TestBasicWorkPermitView
                           {
                               Activity = "My Activity",
                           };

            new WorkPermitBinder(SARNIA_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);
            Assert.AreEqual(null, model.Activity);
        }

        [Test]
        public void ToModelShouldOnlySetPropertyIfSpecifiedSetterConditionMethodEvaluatesToTrue()
        {
            var model = new TestBasicWorkPermitModelWithSetterPreCondition
                            {
                                IsActivityRequired = true
                            };
            var view = new TestBasicWorkPermitView
                           {
                               Activity = "My Activity",
                           };

            new WorkPermitBinder(SARNIA_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);
            Assert.AreEqual("My Activity", model.Activity);
        }

        [Test]
        public void ToModelShouldSetViewPropertiesInOrder()
        {
            var view = new TestWorkPermitViewWithOrdering
                           {
                               IsAnythingApplicable = true,
                               IsClothingApplicable = true,
                               IsUnderwearApplicable = false,
                               IsSkinApplicable = true
                           };

            var model = new TestWorkPermitModelWithOrdering();

            new WorkPermitBinder(SARNIA_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);

            Assert.IsTrue(model.IsAnythingApplicable);
            Assert.IsTrue(model.IsClothingApplicable);
            Assert.IsFalse(model.IsUnderwearApplicable);
            Assert.IsFalse(model.IsSkinApplicable);
        }

        [Test]
        public void ToModelShouldShouldMapGroupingsFromModel()
        {
            var view = new TestWorkPermitViewWithGroups
                           {
                               Description = "Work Permit With Groups",
                               IsSteelToed = true
                           };
            var model = new TestWorkPermitModelWithGroup
                            {
                                Shoes = new TestWorkPermitGroupShoes()
                            };

            new WorkPermitBinder(SARNIA_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);

            Assert.AreEqual("Work Permit With Groups", model.Description);
            Assert.IsTrue(model.Shoes.IsSteelToed);
        }

        [Test,
         ExpectedException(typeof (WorkPermitBinderException), ExpectedMessage =
                 "Could not find property 'PocketProtector' on 'TestBasicWorkPermitViewWithMissingProperty'.")]
        public void ToModelShouldThrowExceptionIfNoCorrespondingPropertyFoundOnView()
        {
            var model = new TestBasicWorkPermitModelWithOneProperty();
            var view = new TestBasicWorkPermitViewWithMissingProperty();
            new WorkPermitBinder(SARNIA_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);
        }

        [Test,
         ExpectedException(typeof (WorkPermitBinderException), ExpectedMessage =
                 "Could not find pre-setter property 'FraggleRock' on 'TestBasicWorkPermitModelWithUndefinedSetterPreCondition'."
             )]
        public void ToModelShouldThrowExceptionIfSetterConditionIsNotFound()
        {
            var model = new TestBasicWorkPermitModelWithUndefinedSetterPreCondition();
            var view = new TestBasicWorkPermitView();
            new WorkPermitBinder(SARNIA_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);
        }

        [Test, ExpectedException(typeof(WorkPermitBinderException), ExpectedMessage =
         "Could not find property 'PocketProtector' on 'TestBasicWorkPermitViewWithMissingProperty'.")]
        public void ToViewShouldThrowExceptionIfNoPropertyFoundToSetOnView()
        {
            var model = new TestBasicWorkPermitModelWithOneProperty();
            var view = new TestBasicWorkPermitViewWithMissingProperty();
            new WorkPermitBinder(SARNIA_SITE_ID).ToView(model, view, Common.Utility.Constants.CURRENT_VERSION);
        }
        [Test]
        public void ToViewForDenverShouldMapApplicableDomainObjectPropertiesOnToView()
        {
            var view = new TestBasicWorkPermitView();
            var model = new TestBasicWorkPermitModel
                            {
                                Activity = "My Activity",
                                DateTime = Clock.Now,
                                NumberOfWorkers = 1,
                                NumberOfSupervisors = null,
                                SarniaOnlyProperty = true,
                                DenverOnlyProperty = true,
                                NotApplicableToAnySite = true
                            };

            new WorkPermitBinder(DENVER_SITE_ID).ToView(model, view, Common.Utility.Constants.CURRENT_VERSION);

            Assert.AreEqual("My Activity", view.Activity);
            Assert.AreEqual(Clock.Now, view.DateTime);
            Assert.AreEqual(1, view.NumberOfWorkers);
            Assert.AreEqual(null, view.NumberOfSupervisors);
            Assert.IsFalse(view.SarniaOnlyProperty);
            Assert.IsTrue(view.DenverOnlyProperty);
            Assert.IsFalse(view.NotApplicableToAnySite);
        }

        [Test]
        public void ToViewForSarniaShouldMapApplicableDomainObjectPropertiesOnToView()
        {
            var view = new TestBasicWorkPermitView();
            var model = new TestBasicWorkPermitModel
                            {
                                Activity = "My Activity",
                                DateTime = Clock.Now,
                                NumberOfWorkers = 1,
                                NumberOfSupervisors = null,
                                SarniaOnlyProperty = true,
                                DenverOnlyProperty = true,
                                NotApplicableToAnySite = true
                            };

            new WorkPermitBinder(SARNIA_SITE_ID).ToView(model, view, Common.Utility.Constants.CURRENT_VERSION);

            Assert.AreEqual("My Activity", view.Activity);
            Assert.AreEqual(Clock.Now, view.DateTime);
            Assert.AreEqual(1, view.NumberOfWorkers);
            Assert.AreEqual(null, view.NumberOfSupervisors);
            Assert.IsTrue(view.SarniaOnlyProperty);
            Assert.IsFalse(view.DenverOnlyProperty);
            Assert.IsFalse(view.NotApplicableToAnySite);
        }

        [Test]
        public void ToViewShouldShouldMapGroupingsFromModel()
        {
            var view = new TestWorkPermitViewWithGroups();
            var shoes = new TestWorkPermitGroupShoes
                            {
                                IsSteelToed = true
                            };
            var model = new TestWorkPermitModelWithGroup
                            {
                                Description = "Work Permit With Groups",
                                Shoes = shoes
                            };

            new WorkPermitBinder(SARNIA_SITE_ID).ToView(model, view, Common.Utility.Constants.CURRENT_VERSION);

            Assert.AreEqual("Work Permit With Groups", view.Description);
            Assert.IsTrue(view.IsSteelToed);
        }

        [Test]
        public void ToViewShouldShouldMapGroupingsFromModelUsingGroupAlias()
        {
            var view = new TestWorkPermitViewWithGroups();
            var shoes = new TestWorkPermitGroupShoes
                            {
                                IsSteelToed = true
                            };
            var hats = new TestWorkPermitGroupHats
                           {
                               Material = "Fleece"
                           };
            var model = new TestWorkPermitModelWithAliasedGroup
                            {
                                Description = "Work Permit With Groups",
                                Shoes = shoes,
                                Hats = hats
                            };

            new WorkPermitBinder(SARNIA_SITE_ID).ToView(model, view, Common.Utility.Constants.CURRENT_VERSION);

            Assert.AreEqual("Work Permit With Groups", view.Description);
            Assert.IsTrue(view.IsSteelToed);
            Assert.AreEqual("Fleece", view.BrainProtectorMaterial);
        }

        [Test]
        public void ToModelShouldDefaultPropertyValueToStandardDefaultValues()
        {
            var model = new TestWorkPermitModelDefaultValues();                        
            var view = new TestWorkPermitViewDefaultValues
            {
                BooleanProperty = true,
                NullableBooleanProperty = true,
                StringProperty = "Fraggles"
            };

            new WorkPermitBinder(SARNIA_SITE_ID).ToModel(view, model, Common.Utility.Constants.CURRENT_VERSION);

            Assert.IsFalse(model.BooleanProperty);
            Assert.IsFalse(model.NullableBooleanProperty.Value);
            Assert.IsNull(model.StringProperty);
            // Note: This doesn't work for other datatypes such as DateTime etc.
            //   Should add this behavior when needed.
        }
    }
}