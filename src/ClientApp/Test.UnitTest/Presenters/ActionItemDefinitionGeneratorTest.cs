using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;
using Clock = Com.Suncor.Olt.Common.Utility.Clock;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ActionItemDefinitionGeneratorTest
    {
        private TargetDefinition targetDefinition;
        private Mockery mocks;
        private ITargetDefinitionService mockService;
        private ActionItemDefinitionGenerator generator;


        public const string HAS_LAST_APPROVED_TARGET_DEFINITION = "HasLastApprovedSnapshot";
        public const string QUERY_LAST_APPROVED_TARGET_DEFINITION = "QueryLastApprovedSnapshot";


        [SetUp]
        public void SetUp()
        {
            targetDefinition = TargetDefinitionFixture.CreateATargetWithMaxValueOnlyRecurringDailyScheduleAndActiveTargetFixture();
            mocks = new Mockery();
            mockService = mocks.NewMock<ITargetDefinitionService>();
            generator = new ActionItemDefinitionGenerator(mockService);
            
            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {          
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldBuildAnActionItemDefinitionToFillTheFormWhenGeneratingAnActionItem()
        {
            Stub.On(mockService).Method("GetHistory").Will(Return.Value(new List<TargetDefinitionHistory>()));

            ActionItemDefinition actual = generator.BuildActionItemDefinition(targetDefinition);
            Assert.AreEqual("", actual.Name);
            Assert.AreEqual(ActionItemDefinitionStatus.Approved, actual.Status);
            Assert.AreEqual(false, actual.RequiresApproval);
            Assert.AreEqual(true, actual.Active);
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }


        [Test]
        public void ShouldSetStartDateToTargetDefinitionStartDateIfTargetDefinitionWillFireInTheFuture()
        {
            Stub.On(mockService).Method("GetHistory").Will(Return.Value(new List<TargetDefinitionHistory>()));

            Date expectedDate = new Date(Clock.Now).AddDays(1);
            Time expectedStartTime = new Time(1, 1, 1);
            Time expectedEndTime = new Time(2, 2, 2);
            SingleSchedule expected = new SingleSchedule(expectedDate, expectedStartTime, expectedEndTime, SiteFixture.Sarnia());
            targetDefinition.Schedule = expected;
            ActionItemDefinition actual = generator.BuildActionItemDefinition(targetDefinition);
            Assert.AreEqual(expected, actual.Schedule);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetStartDateToNowIfTargetDefinitionHasAlreadyFired()
        {
            Stub.On(mockService).Method("GetHistory").Will(Return.Value(new List<TargetDefinitionHistory>()));

            Clock.Freeze();
            Date startDate = new Date(Clock.Now.SubtractDays(1));
            targetDefinition.Schedule = new SingleSchedule(startDate, new Time(1, 1, 1), new Time(2, 2, 2), SiteFixture.Sarnia());
            ActionItemDefinition actual = generator.BuildActionItemDefinition(targetDefinition);
            Assert.AreEqual(new Date(Clock.Now), actual.Schedule.StartDate);
            Assert.AreEqual(new Time(Clock.Now), actual.Schedule.StartTime);
            Assert.AreEqual(new Time(Clock.Now), actual.Schedule.EndTime);
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldUseFunctionalLocationFromTargetDefinition()
        {
            Stub.On(mockService).Method("GetHistory").Will(Return.Value(new List<TargetDefinitionHistory>()));
            List<FunctionalLocation> expected = new List<FunctionalLocation> {targetDefinition.FunctionalLocation};
            ActionItemDefinition actual = generator.BuildActionItemDefinition(targetDefinition);
            Assert.AreEqual(expected, actual.FunctionalLocations);
        }

        [Test]
        public void ShouldUseDocumentLinksWithoutIdsFromTargetDefinition()
        {
            Stub.On(mockService).Method("GetHistory").Will(Return.Value(new List<TargetDefinitionHistory>()));
            targetDefinition.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink(2));
            
            ActionItemDefinition actualDefinition = generator.BuildActionItemDefinition(targetDefinition);
            Assert.AreEqual(targetDefinition.DocumentLinks.Count, actualDefinition.DocumentLinks.Count);
            Assert.AreEqual(targetDefinition.DocumentLinks[0].TitleWithUrl, actualDefinition.DocumentLinks[0].TitleWithUrl);
            Assert.AreNotEqual(targetDefinition.DocumentLinks[0].Id, actualDefinition.DocumentLinks[0].Id);
        }

        [Test]
        public void WhenApprovingATargetDefinitionForTheFirstTimeTheActionItemDefinitionDescriptionShouldShowJustTheNewValues()
        {
            List<TargetDefinitionHistory> targetDefHistories = new List<TargetDefinitionHistory> { targetDefinition.TakeSnapshot() };
            Expect.Once.On(mockService).Method("GetHistory").Will(Return.Value(targetDefHistories));
           
            string expected =
                string.Format("New Target Definition" +
                              Environment.NewLine + "Definition Name: {0}" +
                              Environment.NewLine + "Description: {1}" +
                              Environment.NewLine + "PH Tag: {2} ({3})" +
                              Environment.NewLine + "Min: {4}" +
                              Environment.NewLine + "Max: {5}" +
                              Environment.NewLine + "Target: {6}" +
                              Environment.NewLine + "NTE/SOL Min: {7}" +
                              Environment.NewLine + "NTE/SOL Max: {8}", 
                              targetDefinition.Name, 
                              targetDefinition.Description,
                              targetDefinition.TagInfo.Name, targetDefinition.TagInfo.Description, 
                              targetDefinition.MinValue.Format(),
                              targetDefinition.MaxValue.Format(),
                              targetDefinition.TargetValue.Title,
                              targetDefinition.NeverToExceedMinimum.Format(),
                              targetDefinition.NeverToExceedMaximum.Format());
            
            ActionItemDefinition actualDefinition = generator.BuildActionItemDefinition(targetDefinition);
            
            Assert.AreEqual(expected, actualDefinition.Description);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void WhenReApprovingATargetDefinitionTheActionItemDefinitionDescriptionShouldShowTheDifferencesBetweenTwoTargetDefinitions()
        {
            TargetDefinitionHistory snapshotAfterInsert = targetDefinition.TakeSnapshot();
            snapshotAfterInsert.MinValue = targetDefinition.MinValue + 10;
            snapshotAfterInsert.LastModifiedDate = snapshotAfterInsert.LastModifiedDate.SubtractDays(1);

            TargetDefinitionHistory snapshotAfterEdit = targetDefinition.TakeSnapshot();
            
            List<TargetDefinitionHistory> definitionHistories = new List<TargetDefinitionHistory>
                                                                    {
                                                                        snapshotAfterInsert,
                                                                        snapshotAfterEdit
                                                                    };

            Expect.Once.On(mockService).Method("GetHistory").Will(Return.Value(definitionHistories));

            string expected =
                string.Format("Changing Approved Target Definition" +
                              Environment.NewLine + "Definition Name: {0}" +
                              Environment.NewLine + "Description: {1}" +
                              Environment.NewLine + "PH Tag: {2} ({3})" +
                              Environment.NewLine + "Old Min: {4} New Min: {5}" +
                              Environment.NewLine + "Old Max: {6} New Max: {7}" +
                              Environment.NewLine + "Old Target: {8} New Target: {9}" +
                              Environment.NewLine + "Old NTE/SOL Min: {10}  New NTE/SOL Min: {11}" +
                              Environment.NewLine + "Old NTE/SOL Max: {12}  New NTE/SOL Max: {13}",
                              targetDefinition.Name,
                              targetDefinition.Description,
                              targetDefinition.TagInfo.Name, targetDefinition.TagInfo.Description,
                              snapshotAfterInsert.MinValue, targetDefinition.MinValue.Format(),
                              snapshotAfterInsert.MaxValue, targetDefinition.MaxValue.Format(),
                              snapshotAfterInsert.TargetValue, targetDefinition.TargetValue,
                              snapshotAfterInsert.NeverToExceedMinimum, targetDefinition.NeverToExceedMinimum.Format(),
                              snapshotAfterInsert.NeverToExceedMaximum, targetDefinition.NeverToExceedMaximum.Format());

            ActionItemDefinition actualDefinition = generator.BuildActionItemDefinition(targetDefinition);
            
            Assert.AreEqual(expected, actualDefinition.Description);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        
    }
}