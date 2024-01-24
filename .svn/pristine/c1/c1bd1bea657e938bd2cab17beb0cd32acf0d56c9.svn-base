using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class TargetDefinitionSummaryPresenterTest
    {
        TargetDefinition targetDefinition;
        TargetDefinitionSummaryPresenter presenter;
        MockTargetSummaryView view;

        [SetUp]
        public void SetUp()
        {
            targetDefinition = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(-99);
            targetDefinition.LastModifiedBy = UserFixture.CreateUser();

            view = new MockTargetSummaryView();
            presenter = new TargetDefinitionSummaryPresenter(view, targetDefinition);
        }

        [Test]
        public void ShouldLoadView()
        {
            // Execute:
            view.FireLoadViewEvent();

            Assert.AreEqual(StringResources.TargetDefinitionSummaryForm_SummaryLabel, view.SummaryLabel);
            Assert.AreEqual(StringResources.TargetDefinitionSummaryForm_NameLabel, view.NameLabel);
            Assert.AreEqual(targetDefinition.Name, view.TargetName);
            Assert.AreEqual(targetDefinition.Category.Name, view.CategoryName);
            Assert.AreEqual(targetDefinition.LastModifiedBy.FullNameWithUserName, view.Author);
            Assert.AreEqual(targetDefinition.FunctionalLocation.FullHierarchy, view.FunctionalLocationName);
            Assert.AreEqual(targetDefinition.FunctionalLocation.Description, view.FunctionalLocationDescription);
            AssertDescription(targetDefinition, view.Description);

            Assert.AreEqual(targetDefinition.TagInfo.Name, view.MeasurementTagName);
            Assert.AreEqual(targetDefinition.TagInfo.Units, view.MeasurementTagUnits);

            Assert.AreEqual(targetDefinition.NeverToExceedMaximum, view.NeverToExceedMaximum);
            Assert.AreEqual(targetDefinition.NeverToExceedMinimum, view.NeverToExceedMinimum);
            Assert.AreEqual(targetDefinition.MaxValue, view.MaxValue);
            Assert.AreEqual(targetDefinition.MinValue, view.MinValue);
            Assert.AreEqual(targetDefinition.TargetValue.Title, view.TargetValue);
        }

        [Test]
        public void ShouldBuildSummaryDescription()
        {
            string newComments = "newComments";
            string summaryDescription = presenter.SummaryDescription(newComments);

            StringAssert.StartsWith("New Comments: " + newComments, summaryDescription);
        }

        private void AssertDescription(TargetDefinition targetDefinition, string description)
        {
            StringAssert.Contains(targetDefinition.Name, description);
            StringAssert.Contains(targetDefinition.Category.Name, description);
            StringAssert.Contains(targetDefinition.LastModifiedBy.FullNameWithUserName, description);
            StringAssert.Contains(targetDefinition.FunctionalLocation.FullHierarchy, description);
            StringAssert.Contains(targetDefinition.TagInfo.Name, description);
            StringAssert.Contains(targetDefinition.NeverToExceedMaximum.Value.ToString(), description);
            StringAssert.Contains(targetDefinition.MaxValue.Value.ToString(), description);
            StringAssert.Contains(targetDefinition.MinValue.Value.ToString(), description);
            StringAssert.Contains(targetDefinition.NeverToExceedMinimum.Value.ToString(), description);
        }

        private class MockTargetSummaryView : ITargetSummaryView
        {
            public event EventHandler LoadView;

            private string summaryLabel;
            private string nameLabel;
            private string targetName;
            private string categoryName;
            private string author;
            private string functionalLocationName;
            private string functionalLocationDescription;
            private string description;

            private string measurementTagName;
            private string measurementTagUnits;

            private Nullable<decimal> neverToExceedMaximum;
            private Nullable<decimal> neverToExceedMinimum;
            private Nullable<decimal> maxValue;
            private Nullable<decimal> minValue;
            private string targetValue;

            public string SummaryLabel
            {
                get { return summaryLabel; }
                set { summaryLabel = value; }
            }

            public string NameLabel
            {
                get { return nameLabel; }
                set { nameLabel = value; }
            }

            public string TargetName
            {
                get { return targetName; }
                set { targetName = value; }
            }

            public string CategoryName
            {
                get { return categoryName; }
                set { categoryName = value; }
            }

            public string Author
            {
                get { return author; }
                set { author = value; }
            }

            public string FunctionalLocationName
            {
                get { return functionalLocationName; }
                set { functionalLocationName = value; }
            }

            public string FunctionalLocationDescription
            {
                get { return functionalLocationDescription; }
                set { functionalLocationDescription = value; }
            }

            public string Description
            {
                get { return description; }
                set { description = value; }
            }

            public string MeasurementTagName
            {
                get { return measurementTagName; }
                set { measurementTagName = value; }
            }

            public string MeasurementTagUnits
            {
                get { return measurementTagUnits; }
                set { measurementTagUnits = value; }
            }

            public Nullable<decimal> NeverToExceedMaximum
            {
                get { return neverToExceedMaximum; }
                set { neverToExceedMaximum = value; }
            }

            public Nullable<decimal> NeverToExceedMinimum
            {
                get { return neverToExceedMinimum; }
                set { neverToExceedMinimum = value; }
            }

            public Nullable<decimal> MaxValue
            {
                get { return maxValue; }
                set { maxValue = value; }
            }

            public Nullable<decimal> MinValue
            {
                get { return minValue; }
                set { minValue = value; }
            }

            public string TargetValue
            {
                get { return targetValue; }
                set { targetValue = value; }
            }

            public void FireLoadViewEvent()
            {
                if (LoadView != null) { LoadView(null, EventArgs.Empty); }
            }
        }
    }
}
