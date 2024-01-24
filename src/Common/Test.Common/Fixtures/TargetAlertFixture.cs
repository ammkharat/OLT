using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class TargetAlertFixture
    {
        public static TargetAlert CreateATargetAlert(TargetAlertStatus status)
        {
            return CreateATargetAlert(status, Priority.Normal);
        }

        public static TargetAlert CreateATargetAlert(TargetAlertStatus status, Priority priority)
        {
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1);

            TargetThresholdEvaluation evaluation = 
                    new TargetThresholdEvaluation(TargetThresholdExcessLevel.StandardMax, 1001, 999, 2);

            TargetAlert target = targetDefinition.CreateTargetAlert(evaluation, Clock.Now, UserFixture.CreateUser());

            target.TargetName = "Target Alert";
            target.NeverToExceedMaxFrequency = 1;
            target.NeverToExceedMinFrequency = 2;
            target.MaxValueFrequency = 3;
            target.MinValueFrequency = 4;
            target.NeverToExceedMinimum = 1.10m;
            target.MinValue = 2.20m;
            target.MaxValue = 3.30m;
            target.NeverToExceedMaximum = 4.40m;
            target.TargetValue = TargetValue.CreateSpecifiedTarget(3.00m);
            target.GapUnitValue = 10.01m;
            target.Status = status;
            target.Priority = priority;
            target.FunctionalLocation = FunctionalLocationFixture.GetAny_Unit1();
            target.Tag = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();
            target.Description = "Target Fixture Description";
            target.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            target.Category = TargetCategory.PROCESS;
            target.CreatedByScheduleType = ScheduleType.Single;

            return target;
        }

        public static TargetAlert CreateATargetAlert()
        {
            return CreateATargetAlert(TargetAlertStatus.StandardAlert);
        }

        public static TargetAlert CreateTargetAlertFromTargetDefinition(TargetDefinition targetDefinition)
        {
            TargetThresholdEvaluation evaluation =
                new TargetThresholdEvaluation(TargetThresholdExcessLevel.StandardMax, 1001, 999, 2);
            return targetDefinition.CreateTargetAlert(evaluation, Clock.Now, UserFixture.CreateUser());
        }
        
        public static TargetAlert CreateATargetWithNullMinValue()
        {
            TargetAlert alert = CreateATargetAlert();
            alert.MinValue = null;
            return alert;           
        }
      
        public static TargetAlert CreateSarniaTargetAlertWith3()
        {
            string targetName = "Target Name Id = 3";
            decimal? neverToExceedMaximum = 100;
            decimal? neverToExceedMinimum = 20;
            decimal? maxValue = 100;
            decimal? minValue = 20;
            int neverToExceedMaxFrequency = 1;
            int neverToExceedMinFrequency = 1;
            int maxValueFrequency = 100;
            int minValueFrequency = 1;
            TargetValue targetValue = TargetValue.CreateSpecifiedTarget(50);
            decimal? gapUnitValue = 50;
            TargetAlertStatus status = TargetAlertStatus.Acknowledged;
            Priority priority = Priority.Normal;
            bool exceedingBoundaries = true;
            bool requiresResponse = false;
            List<DocumentLink> documentLinks = new List<DocumentLink>();

            TagInfo tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetAny_Unit1();

            User lastModifiedBy = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            DateTime lastModifiedDateTime = new DateTime(2005, 1, 31);
            User acknowledgedUser = null;
            DateTime? acknowledgedDateTime = null;

            string description = "From Sarnia FLOC, Id = 3";
            DateTime createdDateTime = new DateTime(2005, 1, 19);
            TargetCategory category = TargetCategory.PROCESS;
            ScheduleType createdByScheduleType = ScheduleType.Single;
            decimal? actualValue = 150;
            decimal? originalExceedingValue = 150;

            TargetAlertStatus typeOfViolationStatusId = TargetAlertStatus.NeverToExceedAlert;
            DateTime lastViolatedDateTime = lastModifiedDateTime;
            decimal? maxAtEvaluation = maxValue;
            decimal? minAtEvaluation = minValue;
            decimal? nteMaxAtEvaluation = neverToExceedMaximum;
            decimal? nteMinAtEvaluation = neverToExceedMinimum;
            decimal? actualValueAtEvaluation = actualValue;

            TargetAlert ret = new TargetAlert(null,
                                              functionalLocation,
                                              tag,
                                              targetName,
                                              description,
                                              createdDateTime,
                                              lastModifiedBy,
                                              lastModifiedDateTime,
                                              acknowledgedUser,
                                              acknowledgedDateTime,
                                              neverToExceedMaximum,
                                              neverToExceedMinimum,
                                              maxValue,
                                              minValue,
                                              neverToExceedMaxFrequency,
                                              neverToExceedMinFrequency,
                                              maxValueFrequency,
                                              minValueFrequency,
                                              targetValue,
                                              gapUnitValue,
                                              actualValue,
                                              originalExceedingValue,
                                              createdByScheduleType,
                                              status,
                                              priority,
                                              category,
                                              exceedingBoundaries,
                                              requiresResponse,
                                              typeOfViolationStatusId,
                                              lastViolatedDateTime,
                                              maxAtEvaluation,
                                              minAtEvaluation,
                                              nteMaxAtEvaluation,
                                              nteMinAtEvaluation,
                                              actualValueAtEvaluation,
                                              documentLinks) {Id = 3};



            return ret;
        }

        public static TargetAlert CreateTargetAlertWithSpecifiedValues(decimal? nteMinimum, decimal? minValue, decimal? nteMaximum, decimal? maxValue, decimal? actualValue, decimal? originalExceedingValue, decimal? gapUnitValue)
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetAny_Equip1();
            TagInfo tag = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();
            TargetValue targetValue = TargetValue.CreateSpecifiedTarget(maxValue.GetValueOrDefault());

            return new TargetAlert(null,
                                  functionalLocation,
                                  tag,
                                  "Target: Name",
                                  "Target: Description",
                                  Clock.Now,
                                  UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                                  Clock.Now,
                                  null,
                                  null,
                                  nteMaximum,
                                  nteMinimum,
                                  maxValue,
                                  minValue,
                                  1,
                                  1,
                                  1,
                                  1,
                                  targetValue,
                                  gapUnitValue,
                                  actualValue,
                                  originalExceedingValue,
                                  ScheduleType.Single,
                                  TargetAlertStatus.StandardAlert,
                                  Priority.Normal,
                                  TargetCategory.PRODUCTION,
                                  true,
                                  false,
                                  TargetAlertStatus.StandardAlert, 
                                  Clock.Now,
                                  maxValue,
                                  minValue,
                                  nteMaximum,
                                  nteMinimum,
                                  actualValue,
                                  null);
        }
    }
}