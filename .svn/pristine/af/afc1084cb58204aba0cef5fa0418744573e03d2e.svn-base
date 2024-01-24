using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures

{
    public class ActionItemDefinitionFixture
    {
        public const long ACTION_ITEM_DEFINITION_FOR_ADDING_COMMENTS_ID = 20;
        public const long ACTION_ITEM_DEFINITION_WITH_2_COMMENTS_ID = 21;
        public const long AID_FOR_LINKING_WITH_AI_ID = 35;

        public static ActionItemDefinition CreateActionItemDefinition()
        {
            return CreatePendingActionItemDefinitionForMcMurrayWithActionItemId(1);
        }

        public static ActionItemDefinition CreateActionItemDefinition(long id)
        {
            return CreatePendingActionItemDefinitionForMcMurrayWithActionItemId(id);
        }

        public static ActionItemDefinition CreateActionItemDefinition(BusinessCategory category)
        {
            ActionItemDefinition ret = CreateActionItemDefinition();
            ret.Category = category;
            return ret;
        }

        public static ActionItemDefinition CreateAPendingActionItemDefinitionWithFLOCList()
        {
            ActionItemDefinition ai = CreateAPendingActionItemDefinitionWithFLOCListAndNoID();
            ai.Id = 1;
            return ai;
        }

        public static ActionItemDefinition CreateAnApprovedActionItemDefinitionWithFLOCList()
        {
            ActionItemDefinition ai = CreateAPendingActionItemDefinitionWithFLOCListAndNoID();
            ai.Id = 1;
            ai.Status = ActionItemDefinitionStatus.Approved;
            ai.RequiresApproval = false;
            ai.Active = true;
            return ai;
        }


        public static ActionItemDefinition CreateAPendingActionItemDefinitionWithFLOCListAndNoID()
        {
            var actionItemDefinition =
                new ActionItemDefinition(RandomName(),
                                         BusinessCategoryFixture.GetEnvironmentalSafetyCategory(),
                                         ActionItemDefinitionStatus.Pending,
                                         SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM(),
                                         "Test Action Item Instance Pending",
                                         DataSource.MANUAL,
                                         true, // RequiresApproval
                                         false, // IsActive
                                         true,
                                         UserFixture.CreateOperatorGoofyInFortMcMurrySite(),
                                         new DateTime(2005, 12, 11),
                                         UserFixture.CreateOperatorGoofyInFortMcMurrySite(),
                                         new DateTime(2005, 12, 11),
                                         FunctionalLocationFixture.GetListWith3Units(),
                                         TargetDefinitionDTOFixture.CreateTargetDefinitionDTOList(),
                                         DocumentLinkFixture.CreateDocumentListOfTwo(),
                                         OperationalMode.Normal,
                                         null,
                                         true, null,null,null,false,false,false,null);   //ayman visibility groups      //ayman custom fields DMND0010030
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateActionItemDefinitionWithoutId()
        {
            return CreateActionItemDefinitionWithoutId(DateTimeFixture.DateTimeNow);
        }

        public static ActionItemDefinition CreateActionItemDefinitionWithoutId(DateTime now)
        {
            var actionItemDefinition =
                new ActionItemDefinition(RandomName(),
                                         BusinessCategoryFixture.GetEnvironmentalSafetyCategory(),
                                         ActionItemDefinitionStatus.Pending,
                                         SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM(),
                                         "This is the first action item",
                                         DataSource.MANUAL,
                                         true,
                                         false,
                                         true,
                                         UserFixture.CreateSupervisor(),
                                         now,
                                         UserFixture.CreateSupervisor(),
                                         now,
                                         new List<FunctionalLocation>(),
                                         new List<TargetDefinitionDTO>(),
                                         new List<DocumentLink>(),
                                         OperationalMode.Normal,
                                         null,
                                         true, null, null,null,false,false,false,null);  //ayman visibility groups       //ayman custom fields DMND0010030

            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateProcessActionItemDefinitionWithoutId()
        {
            var actionItemDefinition =
                new ActionItemDefinition(RandomName(),
                                         BusinessCategoryFixture.GetUnitGuidelineProcessCategory(),
                                         ActionItemDefinitionStatus.Pending,
                                         SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM(),
                                         "This is the first action item",
                                         DataSource.MANUAL,
                                         true, // RequiresApproval
                                         false, // IsActive
                                         true,
                                         UserFixture.CreateSupervisor(),
                                         new DateTime(2005, 11, 17, 14, 25, 00),
                                         UserFixture.CreateSupervisor(),
                                         new DateTime(2005, 11, 17, 14, 25, 00),
                                         new List<FunctionalLocation>(),
                                         new List<TargetDefinitionDTO>(),
                                         new List<DocumentLink>(),
                                         OperationalMode.Normal,
                                         null,
                                         true, null, null,null,false,false,false,null);    //ayman visibility groups     //ayman custom fields DMND0010030

            return actionItemDefinition;
        }

        public static ActionItemDefinition CreatePendingActionItemDefinitionForDenver()
        {
            ActionItemDefinition actionItemDefinition = CreateActionItemDefinitionWithoutId();
            actionItemDefinition.FunctionalLocations.Add(
                FunctionalLocationFixture.GetAny_Unit1());
            actionItemDefinition.Id = 1;
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreatePendingActionItemDefinitionForMcMurrayWithActionItemId(
            long actionItemId)
        {
            ActionItemDefinition actionItemDefinition = CreateActionItemDefinitionWithoutId();
            actionItemDefinition.FunctionalLocations.Add(
                FunctionalLocationFixture.GetAny_Unit1());
            actionItemDefinition.Id = actionItemId;
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreatePendingProcessActionItemDefinitionForMcMurrayWithActionItemId(
            long actionItemId)
        {
            ActionItemDefinition actionItemDefinition = CreateProcessActionItemDefinitionWithoutId();
            actionItemDefinition.Id = actionItemId;
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateApprovedActionItemDefinitionForMcMurrayWithActionItemId(
            long actionItemId)
        {
            ActionItemDefinition actionItemDefinition = CreateActionItemDefinitionWithoutId();
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.GetAny_Unit1());
            actionItemDefinition.Id = actionItemId;
            actionItemDefinition.Approve(actionItemDefinition.LastModifiedBy, actionItemDefinition.LastModifiedDate);
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateApprovedProcessActionItemDefinitionForMcMurrayWithActionItemId(
            long actionItemId)
        {
            ActionItemDefinition actionItemDefinition = CreateProcessActionItemDefinitionWithoutId();
            actionItemDefinition.Id = actionItemId;

            actionItemDefinition.Approve(actionItemDefinition.LastModifiedBy, actionItemDefinition.LastModifiedDate);

            return actionItemDefinition;
        }

        public static List<ActionItemDefinition> CreateActionItemDefinitionList(int listSize)
        {
            var actionItems = new List<ActionItemDefinition>();
            for (int i = 1; i <= listSize; i++)
            {
                actionItems.Add(CreatePendingActionItemDefinitionForMcMurrayWithActionItemId(i));
            }
            return actionItems;
        }

        public static ActionItemDefinition CreateProcessCategoryActionItemDefinitionFortMcMurrayWithNoID()
        {
            ActionItemDefinition actionItemDefinition = CreateActionItemDefinitionWithoutId();
            actionItemDefinition.Category = BusinessCategoryFixture.GetUnitGuidelineProcessCategory();
            actionItemDefinition.FunctionalLocations.Add(
                FunctionalLocationFixture.GetAny_Unit1());
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateProductionControlCategoryActionItemDefinitionFortMcMurrayWithNoID()
        {
            ActionItemDefinition actionItemDefinition = CreateActionItemDefinitionWithoutId();

            actionItemDefinition.Category = BusinessCategoryFixture.GetProductionCategory();

            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateWithLinkedTargetDefinition()
        {
            ActionItemDefinition actionItemDefinition = CreateActionItemDefinition();
            actionItemDefinition.TargetDefinitionDTOs.Add(
                new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinition()));
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateWithNoLinkedTargetDefinition()
        {
            ActionItemDefinition actionItemDefinition = CreateActionItemDefinition();
            actionItemDefinition.TargetDefinitionDTOs.Clear();
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateWithWithIdMulitpleFLOCs(long actionItemId)
        {
            ActionItemDefinition actionItemDefinition = CreateActionItemDefinitionWithoutId();
            actionItemDefinition.Id = actionItemId;

            actionItemDefinition.Approve(actionItemDefinition.LastModifiedBy, actionItemDefinition.LastModifiedDate);

            actionItemDefinition.FunctionalLocations =
                FunctionalLocationFixture.CreateNewListOfNewItems(3);
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateApprovedActionItemDefinition(long id)
        {
            ActionItemDefinition actionItemDefinition = CreateActionItemDefinition();
            actionItemDefinition.Id = id;
            actionItemDefinition.Approve(actionItemDefinition.LastModifiedBy, actionItemDefinition.LastModifiedDate);
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateApprovedActionItemDefinitionWithLinkedTargetDefinitionForMcMurrayWithId
            (long id)
        {
            ActionItemDefinition actionItemDefinition = CreateWithLinkedTargetDefinition();
            actionItemDefinition.Id = id;
            actionItemDefinition.Approve(actionItemDefinition.LastModifiedBy, actionItemDefinition.LastModifiedDate);
            return actionItemDefinition;
        }

        public static string RandomName()
        {
            return "AID " + DateTimeFixture.DateTimeNow; //datetime used specifically to get unique name
        }

        public static ActionItemDefinition CreateActionItemDefinition(ISchedule schedule, DateTime lastModifiedDate)
        {
            ActionItemDefinition actionItemDefinition = CreateActionItemDefinition();
            actionItemDefinition.Schedule = schedule;
            actionItemDefinition.LastModifiedDate = lastModifiedDate;
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateActionItemDefinitionWithDefaultValuesForView(User currentUser)
        {
            var ret = new ActionItemDefinition
                (
                string.Empty,
                BusinessCategoryFixture.GetUnitGuidelineProcessCategory(),
                ActionItemDefinitionStatus.Pending,
                null,
                string.Empty,
                DataSource.MANUAL,
                true, // RequiresApproval
                false, // IsActive
                false, // ResponseRequires
                currentUser,
                DateTimeFixture.DateTimeNow,
                currentUser,
                DateTimeFixture.DateTimeNow,
                new List<FunctionalLocation>(),
                new List<TargetDefinitionDTO>(),
                new List<DocumentLink>(),
                OperationalMode.Normal,
                null,
                true, null, null,null,false,false,false,null);    //ayman visibility groups     //ayman custom fields DMND0010030
            return ret;
        }

        public static ActionItemDefinition CreateSAPActionItemDefinitionWithId()
        {
            ActionItemDefinition ret = CreateActionItemDefinition();
            ret.Source = DataSource.SAP;
            return ret;
        }

        public static ActionItemDefinition CloneActionItemDefinitionOneLevelDeep(ActionItemDefinition originalAID)
        {
            string name = originalAID.Name;
            BusinessCategory actionItemCategory = originalAID.Category;
            ActionItemDefinitionStatus actionItemDefinitionStatus = originalAID.Status;
            ISchedule schedule = originalAID.Schedule;
            string description = originalAID.Description;
            DataSource source = originalAID.Source;
            bool requiresApproval = originalAID.RequiresApproval;
            bool active = originalAID.Active;
            bool responseRequired = originalAID.ResponseRequired;
            User lastModifiedBy = originalAID.LastModifiedBy;
            DateTime lastModifiedDate = originalAID.LastModifiedDate;
            User createdBy = originalAID.CreatedBy;
            DateTime createdDateTime = originalAID.CreatedDateTime;
            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation>(originalAID.FunctionalLocations);
            List<TargetDefinitionDTO> targetDefinitionDTOs = new List<TargetDefinitionDTO>(originalAID.TargetDefinitionDTOs);
            List<DocumentLink> documentLinks = new List<DocumentLink>(originalAID.DocumentLinks);
            OperationalMode operationalMode = originalAID.OperationalMode;

            return new ActionItemDefinition(name,
                                            actionItemCategory,
                                            actionItemDefinitionStatus,
                                            schedule,
                                            description,
                                            source,
                                            requiresApproval,
                                            active,
                                            responseRequired,
                                            lastModifiedBy,
                                            lastModifiedDate,
                                            createdBy,
                                            createdDateTime,
                                            functionalLocations,
                                            targetDefinitionDTOs,
                                            documentLinks,
                                            operationalMode,
                                            null,
                                            true, null, null,null,false,false,false,null);     //ayman visibility groups     //ayman custom fields DMND0010030
        }

        public static ActionItemDefinition CreateActionItemDefinitionFromHSched()
        {
            ActionItemDefinition actionItemDefinition = CreateActionItemDefinition();
            actionItemDefinition.Id = null;
            actionItemDefinition.Name = "HSched Blending Instructions For: TK13 on 20060302 224200";
            actionItemDefinition.Category = BusinessCategoryFixture.GetProductionCategory();
            actionItemDefinition.Status = ActionItemDefinitionStatus.Approved;
            var startDate = new Date(2006, 3, 2);
            var startTime = new Time(22, 42, 00);
            var endTime = new Time(15, 40, 00);
            actionItemDefinition.Schedule = new SingleSchedule(startDate, startTime, endTime, SiteFixture.Sarnia());
            actionItemDefinition.Description = "Volume: 8531, Rate: 502.75, Grade: LVB-87, Source: a source, Tank: TK13";
            actionItemDefinition.Source = DataSource.SAP;
            actionItemDefinition.RequiresApproval = false;
            actionItemDefinition.Active = true;
            actionItemDefinition.ResponseRequired = true;
            actionItemDefinition.LastModifiedBy = UserFixture.CreateRemoteAppUser();
            actionItemDefinition.LastModifiedDate = DateTimeFixture.DateTimeNow;
            actionItemDefinition.FunctionalLocations =
                new List<FunctionalLocation> {FunctionalLocationFixture.GetAny_Unit1()};
            actionItemDefinition.DocumentLinks =
                new List<DocumentLink>
                    {
                        new DocumentLink(
                            @"\\File015\SAP_Data\PB2\PSSP\FilePolling\Monitor\OLT\LinkedData\1.pdf",
                            "HSched Details")
                    };
            actionItemDefinition.TargetDefinitionDTOs = new List<TargetDefinitionDTO>();
            return actionItemDefinition;
        }

        public static ActionItemDefinition CreateActionItemDefinitionWithSpecificDatesAndScheduleType(
            long id, Date startDate, Time startTime, Date endDate, Time endTime, ScheduleType scheduleType)
        {
            ISchedule schedule = null;

            if (ScheduleType.Single == scheduleType)
            {
                schedule = new SingleSchedule(1, startDate, startTime, endTime, null, SiteFixture.Sarnia());    
            }
            else if (ScheduleType.Daily == scheduleType)
            {
                schedule = new RecurringDailySchedule(204, startDate, endDate, startTime, endTime, 1, null, SiteFixture.Sarnia());
            }
            else
            {
                throw new NotImplementedException("That type of schedule isn't implemented in the fixture. Go ahead and add it.");
            }

            ActionItemDefinition def = CreateActionItemDefinition(schedule, Clock.Now);
            def.Id = id;

            return def;
        }
    }
}