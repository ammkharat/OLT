using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    /// <summary>
    ///This is a test class for Com.Suncor.Olt.Common.Domain.TargetDefinition and is intended
    ///to contain All Com.Suncor.Olt.Common.Domain.TargetDefinition Unit Tests
    ///</summary>
    [TestFixture]
    public class TargetDefinitionTest
    {
        private TargetDefinition targetDefinition;

        [SetUp]
        public void SetUp()
        {
            targetDefinition =
                TargetDefinitionFixture.CreateATargetWithMaxValueOnlyRecurringDailyScheduleAndActiveTargetFixture();
            targetDefinition.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink(1));
        }

        [TearDown]
        public void Cleanup()
        {
        }

        [Test]
        public void ShouldBeSerializable()
        {
            Assert.IsTrue(targetDefinition.GetType().IsSerializable);
        }

        [Test]
        public void ShouldCreateStandardAlertFromDefinition()
        {
            // Execute:
            TargetThresholdEvaluation evaluation =
                new TargetThresholdEvaluation(TargetThresholdExcessLevel.StandardMax, 49.0m, -1.0m, 50.0m);
            DateTime now = DateTimeFixture.DateTimeNow;
            TargetAlert alert = targetDefinition.CreateTargetAlert(evaluation, now, UserFixture.CreateUser());

            AssertAlertCreatedFromDefinition(-1.0m, TargetAlertStatus.StandardAlert, alert, now);
        }

        [Test]
        public void ShouldCreateNeverToExceedAlertFromDefinition()
        {
            // Execute:
            TargetThresholdEvaluation evaluation =
                new TargetThresholdEvaluation(TargetThresholdExcessLevel.NeverToExceedMax, 997.0m, -3.0m, 1000.0m);
            DateTime now = DateTimeFixture.DateTimeNow;
            TargetAlert alert = targetDefinition.CreateTargetAlert(evaluation, now, UserFixture.CreateUser());

            AssertAlertCreatedFromDefinition(-3.0m, TargetAlertStatus.NeverToExceedAlert, alert, now);
        }

        [Test]
        public void ShouldIndicateExceedingBoundariesAfterEvaluatingNewReading()
        {
            Assert.AreEqual(false, IsExceedingBoundariesAfterEvaluatingNewReading(1.0m, 10.0m, 1.0m));
            Assert.AreEqual(false, IsExceedingBoundariesAfterEvaluatingNewReading(1.0m, 10.0m, 5.0m));
            Assert.AreEqual(false, IsExceedingBoundariesAfterEvaluatingNewReading(1.0m, 10.0m, 10.0m));

            Assert.AreEqual(true, IsExceedingBoundariesAfterEvaluatingNewReading(1.0m, 10.0m, 11.0m));
            Assert.AreEqual(true, IsExceedingBoundariesAfterEvaluatingNewReading(1.0m, 10.0m, 0.0m));
        }

        private static bool IsExceedingBoundariesAfterEvaluatingNewReading(decimal minValue, 
                                                                    decimal maxValue,
                                                                    decimal actualValue)
        {
            TargetDefinition definition = CreateTargetDefinition(minValue, maxValue);
            TargetThresholdEvaluation targetThresholdEvaluation = definition.EvaluateNewReadings(new List<decimal?>{actualValue});
            return targetThresholdEvaluation.AnyLimitExceeded;
        }

        private static TargetDefinition CreateTargetDefinition(decimal minValue, decimal maxValue)
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();
            definition.NeverToExceedMinimum = null;
            definition.MinValue = minValue;
            definition.MinValueFrequency = 1;
            definition.MaxValue = maxValue;
            definition.MaxValueFrequency = 1;
            definition.NeverToExceedMaximum = null;
            return definition;
        }

        private void AssertAlertCreatedFromDefinition(decimal expectedActualValue,
                                                      TargetAlertStatus expectedAlertStatus, TargetAlert alert, DateTime now)
        {
            Assert.AreEqual(targetDefinition.Id, alert.TargetDefinition.Id);
            Assert.AreEqual(expectedAlertStatus, alert.Status);
            Assert.AreEqual(targetDefinition.RequiresResponseWhenAlerted, alert.RequiresResponse);
            Assert.AreEqual(expectedActualValue, alert.ActualValue);
            Assert.IsTrue(alert.ExceedingBoundaries,
                          "A new alert would only be raised if reading is exceeding thresholds!");

            Assert.IsNotNull(alert.LastModifiedBy);
            Assert.AreEqual(now, alert.CreatedDateTime);
            Assert.AreEqual(now, alert.LastModifiedDateTime);

            Assert.AreEqual(targetDefinition.Name, alert.TargetName);
            Assert.AreEqual(targetDefinition.Description, alert.Description);
            Assert.AreEqual(targetDefinition.FunctionalLocation, alert.FunctionalLocation);
            Assert.AreEqual(targetDefinition.GapUnitValue, alert.GapUnitValue);
            Assert.AreEqual(targetDefinition.MaxValue, alert.MaxValue);
            Assert.AreEqual(targetDefinition.MinValue, alert.MinValue);
            Assert.AreEqual(targetDefinition.MaxValueFrequency, alert.MaxValueFrequency);
            Assert.AreEqual(targetDefinition.MinValueFrequency, alert.MinValueFrequency);
            Assert.AreEqual(targetDefinition.NeverToExceedMaxFrequency, alert.NeverToExceedMaxFrequency);
            Assert.AreEqual(targetDefinition.NeverToExceedMinFrequency, alert.NeverToExceedMinFrequency);
            Assert.AreEqual(targetDefinition.NeverToExceedMaximum, alert.NeverToExceedMaximum);
            Assert.AreEqual(targetDefinition.NeverToExceedMinimum, alert.NeverToExceedMinimum);
            Assert.AreEqual(targetDefinition.Category, alert.Category);
            Assert.AreEqual(targetDefinition.TagInfo, alert.Tag);
            Assert.AreEqual(targetDefinition.TargetValue, alert.TargetValue);
            Assert.AreEqual(targetDefinition.Schedule.Type, alert.CreatedByScheduleType);
            
            Assert.AreEqual(targetDefinition.DocumentLinks.Count, alert.DocumentLinks.Count);
            Assert.AreEqual(targetDefinition.DocumentLinks[0].TitleWithUrl, alert.DocumentLinks[0].TitleWithUrl);
            Assert.AreNotEqual(targetDefinition.DocumentLinks[0].Id, alert.DocumentLinks[0].Id);
        }

        [Test]
        public void ShouldGetReadTimesToEvaluateTarget()
        {
            targetDefinition.Schedule = CreateRecurringMinuteSchedule(15);
            ClearTargetThresholds(targetDefinition);
            targetDefinition.NeverToExceedMaximum = 234.0m;
            targetDefinition.NeverToExceedMaxFrequency = 3;

            // So, when we want to evaluate the target, we want to look at 3 readings, each one
            // 15 minutes apart -- that is, 30 minutes ago, 15 minutes ago, and now:
            DateTime now = new DateTime(2006, 4, 21, 13, 59, 59);
            List<DateTime> expectedReadTimes = new List<DateTime>(3)
                                                   {
                                                       now.AddMinutes(-2*15),
                                                       now.AddMinutes(-1*15),
                                                       now
                                                   };

            Assert.AreEqual(expectedReadTimes, targetDefinition.GetReadTimesToEvaluateTarget(now));
        }

        private static RecurringMinuteSchedule CreateRecurringMinuteSchedule(int frequency)
        {
            return new RecurringMinuteSchedule(new Date(2006, 1, 1), new Date(2006, 1, 1),
                                               Time.MIDNIGHT, Time.END_OF_DAY, frequency, SiteFixture.Sarnia());
        }

        private static void ClearTargetThresholds(TargetDefinition definition)
        {
            definition.NeverToExceedMaximum = null;
            definition.MaxValue = null;
            definition.MinValue = null;
            definition.NeverToExceedMinimum = null;
        }

        [Test]
        public void ShouldReturnTrueWhenGenerateActionItemIsTrueAndRequiresApprovalIsFalse()
        {
            targetDefinition.RequiresApproval = false;
            targetDefinition.GenerateActionItem = true;
            Assert.IsTrue(targetDefinition.AutoGenerateActionItemDefinitionRequired);
        }

        [Test]
        public void ShouldReturnFalseWhenGenerateActionItemIsFalse()
        {
            targetDefinition.RequiresApproval = false;
            targetDefinition.GenerateActionItem = false;
            Assert.IsFalse(targetDefinition.AutoGenerateActionItemDefinitionRequired);
        }

        [Test]
        public void ShouldReturnFalseWhenRequiresApprovalIsTrue()
        {
            targetDefinition.RequiresApproval = true;
            targetDefinition.GenerateActionItem = true;
            Assert.IsFalse(targetDefinition.AutoGenerateActionItemDefinitionRequired);
        }

        [Test]
        public void CreateTargetAlertShouldCreateAlertWithSamePriorityAsDefinition()
        {
            targetDefinition.Priority = Priority.Elevated;
            TargetThresholdEvaluation evaluation = 
                new TargetThresholdEvaluation(TargetThresholdExcessLevel.StandardMax, 5.0m, 2.0m, 1.0m);
            TargetAlert alert = targetDefinition.CreateTargetAlert(evaluation, DateTimeFixture.DateTimeNow, UserFixture.CreateUser());
            Assert.AreEqual(Priority.Elevated, alert.Priority);
        }

        [Test]
        public void ApproveShouldChangeStatusToApproved()
        {
            targetDefinition = CreateApprovableTargetDefinition();
            targetDefinition.WaitForApproval();
            targetDefinition.Approve(UserFixture.CreateSupervisor(), DateTimeFixture.DateTimeNow);
            Assert.AreEqual(TargetDefinitionStatus.Approved, targetDefinition.Status);
        }

        [Test]
        public void ApproveShouldMakeTargetDefinitionActive()
        {
            targetDefinition = CreateApprovableTargetDefinition();
            targetDefinition.IsActive = false;
            targetDefinition.Approve(UserFixture.CreateSupervisor(), DateTimeFixture.DateTimeNow);
            Assert.IsTrue(targetDefinition.IsActive);
        }

        [Test]
        public void ApproveShouldRecordLastModificationInformation()
        {
            User approver = UserFixture.CreateSupervisor();
            DateTime approvedDateTime = new DateTime(2001, 2, 3, 4, 5, 6);

            targetDefinition = CreateApprovableTargetDefinition();
            targetDefinition.Approve(approver, approvedDateTime);
            
            Assert.AreEqual(approvedDateTime, targetDefinition.LastModifiedDate);
            Assert.AreEqual(approver, targetDefinition.LastModifiedBy);
        }

        [ExpectedException(typeof(NotSupportedException))]
        [Test]
        public void ApproveShouldGuardAgainstApprovingNonPendingTargetDefinitions()
        {
            CreateApprovedTargetDefinition().Approve(UserFixture.CreateSupervisor(), DateTimeFixture.DateTimeNow);
        }

        [ExpectedException(typeof(NotSupportedException))]
        [Test]
        public void ApproveShouldGuardAgainstApprovingAlreadyActiveTargetDefinitions()
        {
            targetDefinition = CreateApprovableTargetDefinition();
            targetDefinition.IsActive = true;
            
            targetDefinition.Approve(UserFixture.CreateSupervisor(), DateTimeFixture.DateTimeNow);
        }

        [ExpectedException(typeof(NotSupportedException))]
        [Test]
        public void ApproveShouldGuardAgainstApprovingTargetDefinitionsNotRequiringApproval()
        {
            targetDefinition = CreateApprovableTargetDefinition();
            targetDefinition.RequiresApproval = false;
            
            targetDefinition.Approve(UserFixture.CreateSupervisor(), DateTimeFixture.DateTimeNow);
        }

        [Test]
        public void HasInvalidTagShouldSetStatusToInvalidTagAndMakeItInActive()
        {
            DateTime now = DateTimeFixture.DateTimeNow;

            User someUser = UserFixture.CreateRemoteAppUser();
            targetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            targetDefinition.Approve(UserFixture.CreateSAPUser(), now.AddMinutes(-1));

            targetDefinition.HasInvalidTag(someUser, now);
            Assert.AreEqual(TargetDefinitionStatus.InvalidTag, targetDefinition.Status);
            Assert.IsFalse(targetDefinition.IsActive);
            Assert.AreEqual(someUser.Id, targetDefinition.LastModifiedBy.Id);
            Assert.AreEqual(now, targetDefinition.LastModifiedDate);
        }

        [Test]
        public void HasValidTagShouldSetStatusToPending()
        {
            DateTime now = DateTimeFixture.DateTimeNow;

            User someUser = UserFixture.CreateRemoteAppUser();
            targetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            targetDefinition.HasInvalidTag(UserFixture.CreateSAPUser(), now.AddMinutes(-1));

            targetDefinition.HasValidTag(someUser, now);
            Assert.AreEqual(TargetDefinitionStatus.Pending, targetDefinition.Status);
            Assert.IsFalse(targetDefinition.IsActive);
            Assert.AreEqual(someUser.Id, targetDefinition.LastModifiedBy.Id);
            Assert.AreEqual(now, targetDefinition.LastModifiedDate);
        }

        private TargetDefinition CreateApprovedTargetDefinition()
        {
            TargetDefinition definition = CreateApprovableTargetDefinition();
            definition.Approve(UserFixture.CreateSupervisor(), DateTimeFixture.DateTimeNow);
            return definition;
        }

        private TargetDefinition CreateApprovableTargetDefinition()
        {
            targetDefinition.WaitForApproval();
            return targetDefinition;
        }
    }
}