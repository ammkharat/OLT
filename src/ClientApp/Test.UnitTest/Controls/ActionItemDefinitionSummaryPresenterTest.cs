using System;
using Com.Suncor.Olt.Common.Extension;
using NMock2;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Controls
{
    [TestFixture]
    public class ActionItemDefinitionSummaryPresenterTest
    {
        private Mockery mocks;
        private IActionItemDefinitionSummary viewMock;
        private ActionItemDefinitionSummaryPresenter presenter;
        private ActionItemDefinition actionItemDefinition;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            viewMock = mocks.NewMock<IActionItemDefinitionSummary>();
            Expect.Once.On(viewMock).EventAdd("Load", Is.Anything);
            actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            presenter = new ActionItemDefinitionSummaryPresenter(viewMock, actionItemDefinition);
        }

        [Test]
        public void ShouldLoadView()
        {
            Expect.Once.On(viewMock).SetProperty("Name").To(actionItemDefinition.Name);
            Expect.Once.On(viewMock).SetProperty("Category").To(actionItemDefinition.Category);
            Expect.Once.On(viewMock).SetProperty("Author").To(actionItemDefinition.LastModifiedBy.FullNameWithUserName);
            Expect.Once.On(viewMock).SetProperty("FunctionalLocations").To(actionItemDefinition.FunctionalLocations);
            Expect.Once.On(viewMock).SetProperty("Description")
                .To(TestUtil.IsStringContaining(actionItemDefinition.Name,
                actionItemDefinition.Category.Name,
                actionItemDefinition.Status.Name,
                actionItemDefinition.Schedule.RecurrencePatternString,
                actionItemDefinition.FunctionalLocations.FullHierarchyListToString(false, false),
                actionItemDefinition.LastModifiedBy.FullNameWithUserName));

            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldBuildSummaryDescription()
        {
            string newComments = "test comments";
            string summaryDescription = presenter.SummaryDescription(newComments);
            StringAssert.StartsWith("New Comments: " + newComments, summaryDescription);
            StringAssert.Contains(actionItemDefinition.Name, summaryDescription);
            StringAssert.Contains(actionItemDefinition.Category.Name, summaryDescription);
            StringAssert.Contains(actionItemDefinition.Status.Name, summaryDescription);
            StringAssert.Contains(actionItemDefinition.Schedule.RecurrencePatternString, summaryDescription);
            StringAssert.Contains(actionItemDefinition.FunctionalLocations.FullHierarchyListToString(false, false), summaryDescription);
            StringAssert.Contains(actionItemDefinition.LastModifiedBy.FullNameWithUserName, summaryDescription);
        }
    }
}
