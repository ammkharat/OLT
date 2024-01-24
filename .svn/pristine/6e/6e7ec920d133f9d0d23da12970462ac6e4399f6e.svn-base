using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class TargetDefinitionFixture
    {
        public const long TARGET_DEFINITION_FOR_ADDING_COMMENTS_ID = 5;
        public const long TARGET_DEFINITION_WITH_2_COMMENTS_ID = 7;

        public static TargetDefinition CreateATargetWithRecurringDailyScheduleAndPendingTargetFixture()
        {
            TargetDefinition target = CreateTargetDefinition();
            target.Id = 1;
            target.Name = UniqueName("RECP");
            target.Schedule = RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            target.WaitForApproval();

            target.LastModifiedDate = DateTimeFixture.DateTimeNow;
            target.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            return target;
        }

        public static TargetDefinition CreateTargetDefinitionWithDefaultValuesForView(User currentUser)
        {
            TargetDefinition ret = new TargetDefinition
                (
                string.Empty, // Name
                string.Empty, // Description
                TargetCategory.PROCESS,
                TargetDefinitionStatus.Pending,
                null, // TagInfo
                null, // Schedule
                null, // NeverToExceedMinimum
                null, // NeverToExceedMaximum
                null, // PreApprovedNeverToExceedMinimum
                null, // PreApprovedNeverToExceedMaximum
                1, // NeverToExceedMinimumFrequency
                1, // NeverToExceedMaximumFrequuency
                null, // MaxValue
                null, // MinValue
                null, // PreApprovedMinValue
                null, // PreApprovedMaxValue
                1, // MaxValueFrequency
                1, // MinValueFrequency
                TargetValue.CreateEmptyTarget(), // TargetValue
                null, // GapUnitValue
                null, // FunctionalLocation
                false, // GenerateActionItem
                true, // IsAlertRequired
                true, // RequiresApproval
                false, // RequiresResponseWhenAlerted
                new List<TargetDefinitionDTO>(),
                currentUser, // LastModifiedBy
                DateTimeFixture.DateTimeNow, // LastModifiedDate
                false, // IsActive
                OperationalMode.Normal, //Operational Mode
                TargetDefinitionReadWriteTagConfiguration.CreateDefault(),
                WorkAssignment.NoneWorkAssignment
                );
            return ret;
        }

        public static TargetDefinition CreateTargetDefinition()
        {
            return CreateTargetDefinition(true);
        }


        public static TargetDefinition CreateTargetDefinition(bool requiresApproval, Site site)
        {
            TargetDefinition target = new TargetDefinition
                (
                UniqueName("CT"),
                "Target Fixture Description",
                TargetCategory.PROCESS,
                TargetDefinitionStatus.Pending,
                TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC(),
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000(site),
                1.10m,
                4.40m,
                new decimal?(), //null, //2.34, //
                100.00m,
                2,
                1,
                3.30m,
                2.20m,
                1.00m,
                100.0m,
                3,
                4,
                TargetValue.CreateSpecifiedTarget(3.0m),
                10.01m,
                FunctionalLocationFixture.GetAny_Unit1(),
                false,
                false,
                requiresApproval,
                true,
                new List<TargetDefinitionDTO>(),
                UserFixture.CreateUserWithGivenId(1),
                DateTimeFixture.DateTimeNow,
                false,
                OperationalMode.Normal,
                TargetDefinitionReadWriteTagConfiguration.CreateDefault(),
                WorkAssignment.NoneWorkAssignment) { Id = 1 };

            return target;
        }
        
        public static TargetDefinition CreateTargetDefinition(bool requiresApproval)
        {
            TargetDefinition target = new TargetDefinition
                (
                UniqueName("CT"),
                "Target Fixture Description",
                TargetCategory.PROCESS,
                TargetDefinitionStatus.Pending,
                TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC(),
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000(),
                1.10m,
                4.40m,
                new decimal?(), //null, //2.34, //
                100.00m,
                2,
                1,
                3.30m,
                2.20m,
                1.00m,
                100.0m,
                3,
                4,
                TargetValue.CreateSpecifiedTarget(3.0m),
                10.01m,
                FunctionalLocationFixture.GetAny_Unit1(),
                false,
                false,
                requiresApproval,
                true,
                new List<TargetDefinitionDTO>(),
                UserFixture.CreateUserWithGivenId(1),
                DateTimeFixture.DateTimeNow,
                false,
                OperationalMode.Normal,
                TargetDefinitionReadWriteTagConfiguration.CreateDefault(),
                WorkAssignment.NoneWorkAssignment) {Id = 1};

            return target;
        }
        
        public static TargetDefinition CreateTargetDefinition(string name, DateTime lastModifiedDateTime)
        {
            TargetDefinition target = CreateTargetDefinition(false);
            target.Name = name;
            target.LastModifiedDate = lastModifiedDateTime;
            return target;
        }

        private static TargetDefinition CreateUnSetTargetDefinition()
        {
            TargetDefinition target = new TargetDefinition
                (
                UniqueName("CT"),
                "Target Fixture Description",
                TargetCategory.PROCESS,
                TargetDefinitionStatus.Pending,
                TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC(),
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000(),
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                TargetValue.CreateEmptyTarget(),
                null,
                FunctionalLocationFixture.GetAny_Unit1(),
                false,
                false,
                true,
                false,
                new List<TargetDefinitionDTO>(),
                UserFixture.CreateUserWithGivenId(1),
                DateTimeFixture.DateTimeNow,
                false,
                OperationalMode.Normal,
                TargetDefinitionReadWriteTagConfiguration.CreateDefault(),
                WorkAssignment.NoneWorkAssignment) {Id = 1};

            return target;
        }

        public static TargetDefinition CreateTargetDefinitionWithGivenId(long? id)
        {
            TargetDefinition target = CreateTargetDefinition();
            target.Id = id;
            return target;
        }
        public static TargetDefinition CreateTargetWithoutIdAndConfigurationSetToNone()
        {
            TargetDefinition targetDefinition = CreateTargetDefinitionWithoutId();
            targetDefinition.ReadWriteTagsConfiguration.MaxValue.Direction = TagDirection.None;
            targetDefinition.MaxValue = -88m;
            targetDefinition.ReadWriteTagsConfiguration.MinValue.Direction = TagDirection.None;
            targetDefinition.MinValue = -77m;
            targetDefinition.ReadWriteTagsConfiguration.TargetValue.Direction = TagDirection.None;
            targetDefinition.TargetValue = TargetValue.CreateSpecifiedTarget(-66m);
            targetDefinition.ReadWriteTagsConfiguration.GapUnitValue.Direction = TagDirection.None;
            targetDefinition.GapUnitValue = -55m;
            return targetDefinition;
        }

        public static TargetDefinition CreateTargetWithoutIdAndConfigurationSetToRead()
        {
            TargetDefinition targetDefinition = CreateTargetDefinitionWithoutId();
            targetDefinition.ReadWriteTagsConfiguration.MaxValue.Direction = TagDirection.Read;
            targetDefinition.ReadWriteTagsConfiguration.MaxValue.Tag = TagInfoFixture.CreateMockTagForDenver(13, "32TI350.PV");
            targetDefinition.MaxValue = 0.0m;
            targetDefinition.ReadWriteTagsConfiguration.MinValue.Direction = TagDirection.Read;
            targetDefinition.ReadWriteTagsConfiguration.MinValue.Tag = TagInfoFixture.CreateMockTagForDenver(14, "31FC007.PV");
            targetDefinition.MinValue = 3700m;
            targetDefinition.ReadWriteTagsConfiguration.TargetValue.Direction = TagDirection.Read;
            targetDefinition.ReadWriteTagsConfiguration.TargetValue.Tag = TagInfoFixture.CreateMockTagForDenver(15, "F21008.CV");
            targetDefinition.TargetValue = TargetValue.CreateSpecifiedTarget(6950m);
            targetDefinition.ReadWriteTagsConfiguration.GapUnitValue.Direction = TagDirection.Read;
            targetDefinition.ReadWriteTagsConfiguration.GapUnitValue.Tag = TagInfoFixture.CreateMockTagForDenver(16, "MH1234.CV");
            targetDefinition.GapUnitValue = 42m;
            return targetDefinition;
        }

        public static TargetDefinition CreateTargetWithoutIdAndConfigurationSetToWrite(decimal valueToWrite)
        {
            TargetDefinition targetDefinition = CreateTargetDefinitionWithoutId();
            SetReadWriteTagConfigurationsToWrite(targetDefinition, valueToWrite);
            targetDefinition.Approve(targetDefinition.LastModifiedBy, targetDefinition.LastModifiedDate);
            return targetDefinition;
        }

        public static void SetReadWriteTagConfigurationsToWrite(TargetDefinition targetDefinition, decimal valueToWrite)
        {
            targetDefinition.ReadWriteTagsConfiguration.MaxValue.Direction = TagDirection.Write;
            targetDefinition.ReadWriteTagsConfiguration.MaxValue.Tag = TagInfoFixture.CreateMockTagForDenver(13, "32TI350.PV");
            targetDefinition.MaxValue = valueToWrite;
            targetDefinition.ReadWriteTagsConfiguration.MinValue.Direction = TagDirection.Write;
            targetDefinition.ReadWriteTagsConfiguration.MinValue.Tag = TagInfoFixture.CreateMockTagForDenver(14, "31FC007.PV");
            targetDefinition.MinValue = valueToWrite;
            targetDefinition.ReadWriteTagsConfiguration.TargetValue.Direction = TagDirection.Write;
            targetDefinition.ReadWriteTagsConfiguration.TargetValue.Tag = TagInfoFixture.CreateMockTagForDenver(15, "F21008.CV");
            targetDefinition.TargetValue = TargetValue.CreateSpecifiedTarget(valueToWrite);
            targetDefinition.ReadWriteTagsConfiguration.GapUnitValue.Direction = TagDirection.Write;
            targetDefinition.ReadWriteTagsConfiguration.GapUnitValue.Tag = TagInfoFixture.CreateMockTagForDenver(16, "MH1234.CV");
            targetDefinition.GapUnitValue = valueToWrite;
        }


        public static TargetDefinition CreateTargetDefinitionWithoutId()
        {
            TargetDefinition target = CreateTargetDefinition();
            target.Id = null;
            return target;
        }

        public static TargetDefinition CreateATargetWithRecurringDailyScheduleAndActiveTargetFixture()
        {
            TargetDefinition target = CreateTargetDefinition();
            target.FunctionalLocation = FunctionalLocationFixture.GetAny_Unit1();
            target.Schedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();

            target.Approve(target.LastModifiedBy, target.LastModifiedDate);
            return target;
        }

        public static TargetDefinition CreateATargetWithMaxValueOnlyRecurringDailyScheduleAndActiveTargetFixture()
        {
            TargetDefinition target = CreateUnSetTargetDefinition();
            target.Name = UniqueName("MAX");
            target.MaxValueFrequency = 2;
            target.MaxValue = 3.4m;

            target.GapUnitValue = 4.01m;

            target.Approve(target.LastModifiedBy, target.LastModifiedDate);
            target.Category = TargetCategory.PROCESS;
            target.FunctionalLocation = FunctionalLocationFixture.GetAny_Unit1();

            target.TagInfo = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();

            target.Schedule = RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            target.Description = "Target Fixture ";
            return target;
        }

        public static TargetDefinition CreateATargetWithRecurringDailyScheduleAndPendingTargetFixtureWithTestDescription
            ()
        {
            TargetDefinition target = CreateTargetDefinition();
            target.Name = UniqueName("RECD");
            target.NeverToExceedMaxFrequency = 1;
            target.NeverToExceedMinFrequency = 2;
            target.MaxValueFrequency = 3;
            target.MinValueFrequency = 4;
            target.NeverToExceedMinimum = 1.1m;
            target.MinValue = 2.2m;
            target.MaxValue = 3.3m;
            target.NeverToExceedMaximum = 4.4m;

            target.TargetValue = TargetValue.CreateSpecifiedTarget(3.0m);
            target.GapUnitValue = 10.01m;


            target.Description = "Test Description";
            target.WaitForApproval();
            target.Category = TargetCategory.PROCESS;
            target.FunctionalLocation = FunctionalLocationFixture.GetAny_Unit1();

            target.TagInfo = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();

            target.Schedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();

            return target;
        }

        public static TargetDefinition CreateProcessCategoryTarget()
        {
            TargetDefinition target =
                CreateATargetWithRecurringDailyScheduleAndPendingTargetFixtureWithTestDescription();
            target.Category = TargetCategory.PROCESS;
            return target;
        }

        public static TargetDefinition CreateProductControlCategoryTarget()
        {
            TargetDefinition target =
                CreateATargetWithRecurringDailyScheduleAndPendingTargetFixtureWithTestDescription();
            target.Category = TargetCategory.PRODUCTION;
            return target;
        }

        public static TargetDefinition CreateATargetWithRecurringWeeklySchedule()
        {
            TargetDefinition target = CreateTargetDefinition();
            target.Schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            return target;
        }

        public static TargetDefinition CreateATargetWithRecurringHourlyScheduleOfEverySixHours()
        {
            TargetDefinition target = CreateTargetDefinition();
            target.Schedule = RecurringMonthlyScheduleFixture.CreateHourlyScheduleEverySixHours();
            return target;
        }

        public static TargetDefinition CreateATargetWithRecurringMinuteScheduleOfEveryTenMinutes()
        {
            TargetDefinition target = CreateTargetDefinition();
            target.Schedule =
                RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12AndDec21In2002();
            return target;
        }

        public static TargetDefinition
            CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToAnotherTarget(long associatedTargetId)
        {
            TargetDefinition target = CreateTargetDefinition();
            target.Schedule = RecurringMonthlyScheduleFixture.CreateHourlyScheduleEverySixHours();

            TargetDefinition targetWithId = CreateTargetDefinitionWithGivenId(associatedTargetId);

            List<TargetDefinitionDTO> associatedTargetDtos = new List<TargetDefinitionDTO>
                                                                           {new TargetDefinitionDTO(targetWithId)};

            target.AssociatedTargetDTOs = associatedTargetDtos;
            return target;
        }

        public static TargetDefinition
            CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToMulipleTargetsAnotherTarget(
            long[] associatedTargetIds)
        {
            TargetDefinition target = CreateTargetDefinition();
            target.Schedule = RecurringMonthlyScheduleFixture.CreateHourlyScheduleEverySixHours();

            List<TargetDefinitionDTO> associatedDtos = new List<TargetDefinitionDTO>();
            foreach (long t in associatedTargetIds)
            {
                TargetDefinition targetWithId = CreateTargetDefinitionWithGivenId(t);
                associatedDtos.Add(new TargetDefinitionDTO(targetWithId));
            }
            target.AssociatedTargetDTOs = associatedDtos;
            return target;
        }

        public static TargetDefinition CreateTargetDefintion(long? childId)
        {
            TargetDefinition targetDefintion = CreateATargetWithGenerateActionItemTrue();
            targetDefintion.Id = childId;
            return targetDefintion;
        }

        public static TargetDefinition CreateParentTargetDefintion(long id,
                                                                   List<long> associatedTargetIds)
        {
            TargetDefinition child0TargetDefintion = CreateATargetWithGenerateActionItemTrue();
            child0TargetDefintion.Id = id;

            child0TargetDefintion.AssociatedTargetDTOs =
                TargetDefinitionDTOFixture.CreateTargetDefinitionDTOList(associatedTargetIds);
            return child0TargetDefintion;
        }


        public static TargetDefinition CreateATargetWithGenerateActionItemTrue()
        {
            TargetDefinition target = CreateTargetDefinition();
            target.Id = 1;

            target.GenerateActionItem = true;
            target.LastModifiedDate = new DateTime(2005, 10, 10);
            target.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            target.Approve(target.LastModifiedBy, target.LastModifiedDate);
            return target;
        }

        public static TargetDefinition CreateATargetWithGenerateActionItemFalse()
        {
            TargetDefinition target = CreateTargetDefinition();
            target.Id = 1;
            target.GenerateActionItem = false;
            target.LastModifiedDate = new DateTime(2005, 10, 10);
            target.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            target.Approve(target.LastModifiedBy, target.LastModifiedDate);
            return target;
        }

        public static List<long> CreateAssociatedTargetIdList(long[] ids)
        {
            List<long> associatedTargets = new List<long>();
            foreach (long t in ids)
            {
                associatedTargets.Add(t);
            }
            return associatedTargets;
        }

        public static TargetDefinition TargetDefinitionWithTwoChildrenInDb()
        {
            TargetDefinition parentTarget = CreateTargetDefinitionWithGivenId(8);
            long[] associadedIds = {9, 10};
            parentTarget.AssociatedTargetDTOs = TargetDefinitionDTOFixture.CreateTargetDefinitionDTOList(associadedIds);
            return parentTarget;
        }

        public static TargetDefinition CreateTargetDefinition(ISchedule schedule, DateTime lastModifiedDate)
        {
            TargetDefinition targetDefinition = CreateTargetDefinition();
            targetDefinition.Schedule = schedule;
            targetDefinition.LastModifiedDate = lastModifiedDate;
            return targetDefinition;
        }

        public static TargetDefinition CreateTargetDefinition(TargetDefinitionStatus status, bool requiresApproval)
        {
            TargetDefinition targetDefinition = CreateTargetDefinition();
            targetDefinition.Status = status;
            targetDefinition.RequiresApproval = requiresApproval;

            if (requiresApproval)
                targetDefinition.IsActive = false;

            return targetDefinition;
        }

        public static TargetDefinition CloneTargetDefinitionOneLevelDeep(TargetDefinition templateDef)
        {
            string name = templateDef.Name;
            decimal? neverToExceedMinimum = templateDef.NeverToExceedMinimum;
            decimal? neverToExceedMaximum = templateDef.NeverToExceedMaximum;
            decimal? preApprovedNeverToExceedMinimum = templateDef.PreApprovedNeverToExceedMinimum;
            decimal? preApprovedNeverToExceedMaximum = templateDef.PreApprovedNeverToExceedMaximum;
            int? neverToExceedMinimumFrequency = templateDef.NeverToExceedMinFrequency;
            int? neverToExceedMaximumFrequency = templateDef.NeverToExceedMaxFrequency;
            decimal? maxValue = templateDef.MaxValue;
            decimal? minValue = templateDef.MinValue;
            decimal? preApprovedMaxValue = templateDef.PreApprovedMaxValue;
            decimal? preApprovedMinValue = templateDef.PreApprovedMinValue;
            int? maxValueFrequency = templateDef.MaxValueFrequency;
            int? minValueFrequency = templateDef.MinValueFrequency;
            TargetValue targetValue = TargetValue.CreateEmptyTarget();
            decimal? gapUnitValue = templateDef.GapUnitValue;
            string description = templateDef.Description;
            TargetCategory category = templateDef.Category;
            TagInfo tagInfo = new TagInfo(templateDef.TagInfo.Id, templateDef.TagInfo.SiteId, templateDef.TagInfo.Name, templateDef.TagInfo.Description, templateDef.TagInfo.Units, false,templateDef.TagInfo.ScadaConnectionInfoId);
            bool generateActionItem = templateDef.GenerateActionItem;
            ISchedule schedule  = templateDef.Schedule;

            bool isAlertRequired = templateDef.IsAlertRequired;
            bool requiresResponseWhenAlerted = templateDef.RequiresResponseWhenAlerted;
            bool isActive = templateDef.IsActive;
            bool requiresApproval = templateDef.RequiresApproval;
            FunctionalLocation functionalLocation = templateDef.FunctionalLocation;
            const bool deleted = false;
            TargetDefinitionStatus status = templateDef.Status;
            Priority priority = templateDef.Priority;
            User lastModifiedBy = templateDef.LastModifiedBy;
            DateTime lastModifiedDate = templateDef.LastModifiedDate;
            List<Comment> comments = new List<Comment>(templateDef.Comments);
            List <TargetDefinitionDTO> associatedTargetDtos = new List <TargetDefinitionDTO>( templateDef.AssociatedTargetDTOs);
            OperationalMode operationalMode = templateDef.OperationalMode;
            List <DocumentLink> documentLinks = new List <DocumentLink>( templateDef.DocumentLinks);
            TargetDefinitionReadWriteTagConfiguration readWriteTagsConfiguration  = templateDef.ReadWriteTagsConfiguration;
            WorkAssignment assignment = templateDef.Assignment;

            TargetDefinition clonedTargetDef = new TargetDefinition(name,
                                                                    description,category,
                                                                    status,
                                                                    tagInfo,
                                                                    schedule,
                                                                    neverToExceedMinimum,
                                                                    neverToExceedMaximum,
                                                                    preApprovedNeverToExceedMinimum,
                                                                    preApprovedNeverToExceedMaximum,
                                                                    neverToExceedMinimumFrequency,
                                                                    neverToExceedMaximumFrequency,
                                                                    maxValue,
                                                                    minValue,
                                                                    preApprovedMinValue,
                                                                    preApprovedMaxValue,
                                                                    maxValueFrequency,
                                                                    minValueFrequency,
                                                                    targetValue,
                                                                    gapUnitValue,
                                                                    functionalLocation,
                                                                    generateActionItem,
                                                                    isAlertRequired,
                                                                    requiresApproval,
                                                                    requiresResponseWhenAlerted,
                                                                    associatedTargetDtos,
                                                                    lastModifiedBy,
                                                                    lastModifiedDate,
                                                                    isActive,
                                                                    operationalMode,
                                                                    readWriteTagsConfiguration,
                                                                    documentLinks,
                                                                    assignment)
                                                   {
                                                       Id = templateDef.Id,
                                                       
                                                       Priority = priority,
                                                       Deleted = deleted,
                                                       Comments = comments
                                                   };

            return clonedTargetDef;
        }

        private static long nameCounter;

        private static string UniqueName(string suffix)
        {
            nameCounter = nameCounter + 1;
            return DateTimeFixture.DateTimeNow.Ticks + nameCounter + suffix;
        }

        public static TargetDefinition CreateApprovedTargetDefinition(TagInfo tagInfo, TargetDefinitionReadWriteTagConfiguration readWriteTagConfiguration, 
                                                                      bool isActive, bool isAlertRequired, decimal? minValue, decimal? maxValue, decimal? neverToExceedMax, decimal? nevertoExceedMin, int? maxValueFrequency, int? minValueFrequency)
        {
            TargetDefinition target = new TargetDefinition
                (
                UniqueName("CT"),
                "Target Fixture Description",
                TargetCategory.PROCESS,
                TargetDefinitionStatus.Approved,
                tagInfo,
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000(),
                nevertoExceedMin,
                neverToExceedMax,
                new decimal?(), //null, //2.34, //
                100.00m,
                2,
                1,
                maxValue,
                minValue,
                1.00m,
                100.0m,
                maxValueFrequency,
                minValueFrequency,
                TargetValue.CreateSpecifiedTarget(3.0m),
                10.01m,
                FunctionalLocationFixture.GetAny_Unit1(),
                false,
                isAlertRequired,
                false,
                true,
                new List<TargetDefinitionDTO>(),
                UserFixture.CreateUserWithGivenId(1),
                DateTimeFixture.DateTimeNow,
                isActive,
                OperationalMode.Normal,
                readWriteTagConfiguration,
                WorkAssignment.NoneWorkAssignment) { Id = 1 };
            return target;
        }
    }
}