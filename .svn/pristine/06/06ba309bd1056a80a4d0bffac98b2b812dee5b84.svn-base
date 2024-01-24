using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class TargetAlertTest
    {
        [SetUp]
        public void TestSetup()
        {
            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void DeleteMe()
        {
            Int32 someValue = 0;
            long l = (long) someValue;
        }


        [Test]
        public void ShouldCalculateLosses()
        {
            decimal? maxValue = 100;
            decimal? minValue = 50;
            decimal? gapUnitValue = 1;

            // ActualValue exceeds max value
            decimal? actualValue = maxValue + 1;
            decimal? expectedResult = Math.Abs(actualValue.Value - maxValue.Value) * gapUnitValue;
            decimal? actualResult = TargetAlert.CalculateLosses(actualValue, null, maxValue, minValue, null, gapUnitValue);
            Assert.AreEqual(expectedResult, actualResult);

            //ActualValue exceeds min value
            actualValue = minValue - 1;
            expectedResult = Math.Abs(actualValue.Value - minValue.Value) * gapUnitValue;
            actualValue = TargetAlert.CalculateLosses(actualValue, null, maxValue, minValue, null, gapUnitValue);
            Assert.AreEqual(expectedResult, actualValue);
        }

        [Test]
        public void GetTargetThresholdEvaluationShouldReturnEvaluationUsingThresholdsAndOriginalExceedingValue()
        {
            decimal? gapUnitValue = null;
            decimal? nteMaximum = null;
            decimal? nteMinimum = null;
            decimal? maxValue = null;
            decimal? minValue = 10.0m;
            decimal? actualValue = 8.0m;
            decimal? originalExceedingValue = 9.0m;
            
            TargetAlert alert = TargetAlertFixture.CreateTargetAlertWithSpecifiedValues
                (nteMinimum, minValue, nteMaximum, maxValue, actualValue, originalExceedingValue, gapUnitValue);
            
            TargetThresholdEvaluation evaluation = alert.GetTargetThresholdEvaluationForOriginalExceedingValue();
            Assert.AreEqual(TargetThresholdExcessLevel.StandardMin, evaluation.ExcessLevel);
            Assert.AreEqual(10.0m, evaluation.ThresholdValue);
            Assert.AreEqual(9.0m, evaluation.ActualValueUsed);
            Assert.AreEqual(1.0m, evaluation.GapValue);
        }

        [Test]
        public void ShouldReturnNullWhenLossesEqualsZero()
        {
            decimal? maxValue = 100;
            decimal? minValue = 50;
            decimal? gapUnitValue = 1;

            //ActualValue is max
            decimal? actualValue = maxValue;
            decimal? expectedResult = null;
            decimal? actualResult = TargetAlert.CalculateLosses(actualValue, null, maxValue, minValue, null, gapUnitValue);
            Assert.AreEqual(expectedResult, actualResult);

            //ActualValue is min
            actualValue = minValue;
            expectedResult = null;
            actualResult = TargetAlert.CalculateLosses(actualValue, null, maxValue, minValue, null, gapUnitValue);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ShouldReturnNullWhenNotAllRequiredDataAreSupplied()
        {
            decimal? expected = null;

            decimal? actual = TargetAlert.CalculateLosses(null, 100, 70, 50, 10, 1);
            Assert.AreEqual(expected, actual);

            actual = TargetAlert.CalculateLosses(101, null, null, null, null, 1);
            Assert.AreEqual(expected, actual);

            actual = TargetAlert.CalculateLosses(101, 100, 70, 50, 10, null);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldCalculateLossesUsingActualValue()
        {
            decimal? nteMinimum = null;
            decimal? minValue = null;
            decimal? maxValue = 5.0m;
            decimal? nteMaximum = null;
            decimal? actualValue = 7.0m;
            decimal? originalExceedingValue = 8.0m;
            decimal? gapUnitValue = 3.0m;
            
            TargetAlert alert = TargetAlertFixture.CreateTargetAlertWithSpecifiedValues
                (nteMinimum, minValue, nteMaximum, maxValue, actualValue, originalExceedingValue, gapUnitValue);

            Assert.AreEqual(6.0m, alert.Losses);
        }

        [Test]
        public void ShouldReturnNullForLossesIfThereIsNoGapUnitValue()
        {
            decimal? nteMinimum = null;
            decimal? minValue = null;
            decimal? maxValue = 5.0m;
            decimal? nteMaximum = null;
            decimal? actualValue = 7.0m;
            decimal? originalExceedingValue = 8.0m;
            decimal? gapUnitValue = null;

            TargetAlert alert = TargetAlertFixture.CreateTargetAlertWithSpecifiedValues
                (nteMinimum, minValue, nteMaximum, maxValue, actualValue, originalExceedingValue, gapUnitValue);

            Assert.IsNull(alert.Losses);
        }
        
        [Test]
        public void ShouldUpdateActualValueWhenUpdatingNewEvaluation()
        {
            TargetAlert alert = NewAlert(true, true, TargetAlertStatus.Acknowledged);
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();

            TargetThresholdEvaluation evaluation = CreateEvaluation(TargetThresholdExcessLevel.None);
            alert.UpdateWithNewEvaluation(evaluation, definition, Clock.Now);
            Assert.AreEqual(evaluation.ActualValueUsed, alert.ActualValue);

            evaluation = CreateEvaluation(TargetThresholdExcessLevel.NeverToExceedMax);
            alert.UpdateWithNewEvaluation(evaluation, definition, Clock.Now);
            Assert.AreEqual(evaluation.ActualValueUsed, alert.ActualValue);
        }

        [Test]
        public void ShouldUpdateViolationValues()
        {
            const decimal MaxValue = 999333;

            // Alert is in an "acknowledged" state, requires a response, and is exceeding boundaries
            {
                TargetAlert alert = NewAlert(true, true, TargetAlertStatus.Acknowledged);
                TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();
                definition.MaxValue = MaxValue;

                TargetThresholdEvaluation evaluation = CreateEvaluation(TargetThresholdExcessLevel.NeverToExceedMax);
                alert.UpdateWithNewEvaluation(evaluation, definition, Clock.Now);

                Assert.AreEqual(MaxValue, alert.MaxAtEvaluation);
            }
    
            // Alert does not require a response and is exceeding boundaries
            {
                TargetAlert alert = NewAlert(true, false, TargetAlertStatus.StandardAlert);
                TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();
                definition.MaxValue = MaxValue;

                TargetThresholdEvaluation evaluation = CreateEvaluation(TargetThresholdExcessLevel.NeverToExceedMax);
                alert.UpdateWithNewEvaluation(evaluation, definition, Clock.Now);

                Assert.AreEqual(MaxValue, alert.MaxAtEvaluation);
            }

            // Alert does not exceed boundaries, so it shouldn't get updated.
            {
                TargetAlert alert = NewAlert(false, false, TargetAlertStatus.StandardAlert);
                TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();
                decimal? originalValue = definition.MaxValue;
                definition.MaxValue = MaxValue;

                TargetThresholdEvaluation evaluation = CreateEvaluation(TargetThresholdExcessLevel.None);
                alert.UpdateWithNewEvaluation(evaluation, definition, Clock.Now);

                Assert.AreEqual(originalValue, alert.MaxAtEvaluation);
            }
        }

        [Test]
        public void ShouldNotChangeOriginalExceedingValueWhenUpdatingWithNewEvaluation()
        {
            TargetAlert alert = NewAlert(true, true, TargetAlertStatus.Acknowledged);
            decimal? expectedOriginalValue = alert.OriginalExceedingValue;
            TargetThresholdEvaluation evaluation = CreateEvaluation(TargetThresholdExcessLevel.NeverToExceedMin);
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();
            alert.UpdateWithNewEvaluation(evaluation, definition, Clock.Now);
            Assert.AreEqual(expectedOriginalValue, alert.OriginalExceedingValue);
        }
                
        [Test]
        public void ShouldChangeStatusFromAcknowledgedToClosedIfNoLongerExceedingBoundary()
        {
            TargetAlert alert = NewAlert(true, true, TargetAlertStatus.Acknowledged);

            // Execute:
            alert.UpdateWithNewEvaluation(CreateEvaluation(TargetThresholdExcessLevel.None), null, Clock.Now);

            Assert.AreEqual(TargetAlertStatus.Closed, alert.Status);
        }

        [Test]
        public void ShouldChangeStatusFromStandardAlertToClosedIfNoLongerExceedingBoundaryAndDoesntRequireResponse()
        {
            TargetAlert alert = NewAlert(true, false, TargetAlertStatus.StandardAlert);

            // Execute:
            alert.UpdateWithNewEvaluation(CreateEvaluation(TargetThresholdExcessLevel.None), null, Clock.Now);

            Assert.AreEqual(TargetAlertStatus.Closed, alert.Status);
        }

        [Test]
        public void ShouldChangeStatusFromNteAlertToClosedIfNoLongerExceedingBoundaryAndDoesntRequireResponse()
        {
            TargetAlert alert = NewAlert(true, false, TargetAlertStatus.NeverToExceedAlert);

            // Execute:
            alert.UpdateWithNewEvaluation(CreateEvaluation(TargetThresholdExcessLevel.None), null, Clock.Now);

            Assert.AreEqual(TargetAlertStatus.Closed, alert.Status);
        }

        [Test]
        public void ShouldRetainAcknowledgedStatusIfStillExceedingBoundary()
        {
            TargetAlert alert = NewAlert(true, true, TargetAlertStatus.Acknowledged);
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();

            // Execute:
            alert.UpdateWithNewEvaluation(CreateEvaluation(TargetThresholdExcessLevel.StandardMax), definition, Clock.Now);

            Assert.AreEqual(TargetAlertStatus.Acknowledged, alert.Status);
        }

        [Test]
        public void ShouldRetainAlertStatusIfStillExceedingBoundaryAndRequiresResponse()
        {
            TargetAlert alert = NewAlert(true, true, TargetAlertStatus.StandardAlert);
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();

            // Execute:
            alert.UpdateWithNewEvaluation(CreateEvaluation(TargetThresholdExcessLevel.StandardMax), definition, Clock.Now);

            Assert.AreEqual(TargetAlertStatus.StandardAlert, alert.Status);
        }

        [Test]
        public void ShouldUpdateAlertStatusIfStillExceedingBoundaryAndRequiresResponse()
        {
            TargetAlert alert = NewAlert(true, true, TargetAlertStatus.StandardAlert);
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();

            // Execute:
            alert.UpdateWithNewEvaluation(CreateEvaluation(TargetThresholdExcessLevel.NeverToExceedMax), definition, Clock.Now);

            Assert.AreEqual(TargetAlertStatus.NeverToExceedAlert, alert.Status);
        }

        [Test]
        public void ShouldUpdateAlertStatusIfStillExceedingBoundaryAndDoesntRequireResponse()
        {
            TargetAlert alert = NewAlert(true, false, TargetAlertStatus.StandardAlert);
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();

            // Execute:
            alert.UpdateWithNewEvaluation(CreateEvaluation(TargetThresholdExcessLevel.NeverToExceedMax), definition, Clock.Now);

            Assert.AreEqual(TargetAlertStatus.NeverToExceedAlert, alert.Status);
        }

        [Test]
        public void ShouldAcknowledgeAlertIfStillInGapOnAcknowledge()
        {
            TargetAlert alert = CreateTargetAlertRequiringResponse();
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();

            alert.UpdateWithNewEvaluation(BrokeThresholdEvaluation(), definition, Clock.Now);
            Assert.AreEqual(TargetAlertStatus.StandardAlert, alert.Status);

            User user = UserFixture.CreateAdmin();
            DateTime dateTime = new DateTime(2006, 7, 4);
            // Execute:
            alert.Acknowledge(user, dateTime);

            Assert.AreEqual(TargetAlertStatus.Acknowledged, alert.Status);
        }

        [Test]
        public void ShouldCloseAlertIfNoLongerInGapOnAcknowledge()
        {
            TargetAlert alert = CreateTargetAlertRequiringResponse();
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();

            alert.UpdateWithNewEvaluation(WithinThresholdEvaluation(), definition, Clock.Now);
            Assert.AreEqual(TargetAlertStatus.StandardAlert, alert.Status);

            User user = UserFixture.CreateAdmin();
            DateTime dateTime = new DateTime(2006, 7, 4);
            // Execute:
            alert.Acknowledge(user, dateTime);

            Assert.AreEqual(TargetAlertStatus.Closed, alert.Status);
        }

        [Test]
        public void AcknowledgeShouldStoreAcknowledgeUserAndDateTimeIfAlertIsExceedingBoundaries()
        {
            User user = UserFixture.CreateAdmin();
            DateTime dateTime = new DateTime(2006, 12, 25);

            TargetAlert alert = NewAlert(true, true, TargetAlertStatus.StandardAlert);
            alert.Acknowledge(user, dateTime);
            
            Assert.AreEqual(user, alert.AcknowledgedUser);
            Assert.AreEqual(dateTime, alert.AcknowledgedDateTime);
        }

        [Test]
        public void AcknowledgeShouldStoreAcknowledgeUserAndDateTimeIfAlertIsNotExceedingBoundaries()
        {
            User user = UserFixture.CreateAdmin();
            DateTime dateTime = new DateTime(2006, 12, 25);

            TargetAlert alert = NewAlert(false, true, TargetAlertStatus.StandardAlert);
            
            alert.Acknowledge(user, dateTime);

            Assert.AreEqual(user, alert.AcknowledgedUser);
            Assert.AreEqual(dateTime, alert.AcknowledgedDateTime);
        }

        [Test]
        public void AcknowledgeShouldNotOverwriteAcknowledgeUserAndDateTimeIfAlertIsAlreadyAcknowledged()
        {
            User user = UserFixture.CreateAdmin();
            DateTime dateTime = new DateTime(2006, 12, 25);
            User user2 = UserFixture.CreateOperator();
            DateTime dateTime2 = new DateTime(2006, 12, 22);

            TargetAlert alert = NewAlert(false, true, TargetAlertStatus.StandardAlert);

            alert.Acknowledge(user, dateTime);
            
            alert.Acknowledge(user2, dateTime2);

            Assert.AreEqual(user, alert.AcknowledgedUser);
            Assert.AreEqual(dateTime, alert.AcknowledgedDateTime);
        }


        #region UpdateStatusWithNewTargetDefinitionOpModeTests

        private void UpdateStatusWithNewTargetDefinitionOpModeTest(TargetAlertStatus startingAlertStatus,
                                                  OperationalMode beforeTargetDefOpMode,
                                                  OperationalMode afterTargetDefOpMode,
                                                  TargetAlertStatus expectedAlertStatus)
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert(startingAlertStatus);

            alert.UpdateStatusWithNewTargetDefinitionOpMode(beforeTargetDefOpMode, afterTargetDefOpMode);

            TargetAlertStatus actual = alert.Status;
            Assert.AreEqual(expectedAlertStatus, actual);
        }

        [Test]
        public void ShouldChangeStatusToClearIfNotClosedWhenTargetDefinitionOperationModeChanges()
        {
            TargetAlertStatus startingAlertStatus = TargetAlertStatus.StandardAlert;
            OperationalMode beforeTargetDefOpMode = OperationalMode.Normal;
            OperationalMode afterTargetDefOpMode = OperationalMode.ShutDown;
            TargetAlertStatus expectedAlertStatus = TargetAlertStatus.Cleared;

            UpdateStatusWithNewTargetDefinitionOpModeTest(startingAlertStatus,
                                                         beforeTargetDefOpMode,
                                                         afterTargetDefOpMode,
                                                         expectedAlertStatus);
        }

        [Test]
        public void ShouldNotChangeStatusIfNoChangesInOperationalMode()
        {
            TargetAlertStatus startingAlertStatus = TargetAlertStatus.StandardAlert;
            OperationalMode beforeTargetDefOpMode = OperationalMode.Normal;
            OperationalMode afterTargetDefOpMode = beforeTargetDefOpMode;
            TargetAlertStatus expectedAlertStatus = startingAlertStatus;

            UpdateStatusWithNewTargetDefinitionOpModeTest(startingAlertStatus,
                                                          beforeTargetDefOpMode,
                                                          afterTargetDefOpMode,
                                                          expectedAlertStatus);
        }

        [Test]
        public void ShouldNotChangeStatusIfStatusIsClosed()
        {
            TargetAlertStatus startingAlertStatus = TargetAlertStatus.Closed;
            OperationalMode beforeTargetDefOpMode = OperationalMode.Normal;
            OperationalMode afterTargetDefOpMode = OperationalMode.ShutDown;
            TargetAlertStatus expectedAlertStatus = TargetAlertStatus.Closed;

            UpdateStatusWithNewTargetDefinitionOpModeTest(startingAlertStatus,
                                                          beforeTargetDefOpMode,
                                                          afterTargetDefOpMode,
                                                          expectedAlertStatus);
        }

        [Test]
        public void UpdateStatusWithTargetDefinitionIsActiveWhenInactiveShouldChangeStatusToCleared()
        {
            TargetAlert targetAlert = CreateTargetAlert(TargetAlertStatus.StandardAlert);
            targetAlert.UpdateStatusWithTargetDefinitionIsActive(false);
            Assert.AreEqual(TargetAlertStatus.Cleared, targetAlert.Status);
        }

        [Test]
        public void UpdateStatusWithTargetDefinitionIsActiveWhenActiveShouldNotChangeStatus()
        {
            TargetAlert targetAlert = CreateTargetAlert(TargetAlertStatus.StandardAlert);
            targetAlert.UpdateStatusWithTargetDefinitionIsActive(true);
            Assert.AreEqual(TargetAlertStatus.StandardAlert, targetAlert.Status);
        }

        #endregion

        private TargetAlert NewAlert(bool exceedingBoundaries, bool requiresResponse, TargetAlertStatus status)
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert(status);
            alert.ExceedingBoundaries = exceedingBoundaries;
            alert.RequiresResponse = requiresResponse;

            return alert;
        }

        private TargetAlert CreateTargetAlertRequiringResponse()
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert();
            alert.RequiresResponse = true;
            alert.Status = TargetAlertStatus.StandardAlert;
            return alert;
        }

        private TargetAlert CreateTargetAlert(TargetAlertStatus status)
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert();
            alert.Status = status;
            return alert;
        }

        private TargetThresholdEvaluation BrokeThresholdEvaluation()
        {
            return new TargetThresholdEvaluation(TargetThresholdExcessLevel.StandardMax, 3.0m, 2.0m, 1.0m);
        }

        private TargetThresholdEvaluation WithinThresholdEvaluation()
        {
            return new TargetThresholdEvaluation(2.0m);
        }

        private TargetThresholdEvaluation CreateEvaluation(TargetThresholdExcessLevel excessLevel)
        {
            return new TargetThresholdEvaluation(excessLevel, 320.0m, 4000.0m, 3680.0m);
        }
    }
}
