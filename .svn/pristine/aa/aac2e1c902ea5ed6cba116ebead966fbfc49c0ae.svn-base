using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ActionItemFixture
    {
        public static ActionItem Create()
        {
            return CreateAPendingActionItemWithIdPassedIn(9999);
        }
        
        public static ActionItem Create(Priority priority)
        {
            return Create(priority, null);
        }

        public static ActionItem Create(Priority priority, long? gn75BId)
        {
            return CreateAPendingActionItemWithIdPassedIn(8888, priority, gn75BId);
        }

        public static ActionItem Create(DateTime startDateTime, DateTime endDateTime)
        {
            return CreateActionItemWithStartAndEndDateTime(startDateTime, endDateTime);
        }

        public static ActionItem CreateAPendingActionItemWithFlocListAndNoId()
        {
            ActionItem actionItem = new ActionItem("<Action Item Name>",
                                                   "Test Action Item Instance Pending",
                                                   false,
                                                   ActionItemStatus.Current,
                                                   Priority.Normal, 
                                                   DataSource.MANUAL,
                                                   new DateTime(2005, 12, 12, 8, 0, 0),
                                                   new DateTime(2005, 12, 12, 16, 0, 0),
                                                   null,
                                                   ScheduleType.Single,
                                                   new List<FunctionalLocation>{FunctionalLocationFixture.GetAny_Equip1()},
                                                   BusinessCategoryFixture.GetEnvironmentalSafetyCategory(),
                                                   UserFixture.CreateOperatorGoofyInFortMcMurrySite(),
                                                   new DateTime(2005, 12, 11),
                                                   DocumentLinkFixture.CreateDocumentListOfTwo(),
                                                   null,
                                                   null,
                                                   null,
                                                   null,
                                                   null,0,null,null,null,string.Empty,null,false);     //ayman visibility groups         ayman action item definition     ayman action item reading

            return actionItem;
        }

        public static ActionItem CreateRespondNotRequiredWithShiftAdjustedDateTime(DateTime shiftAdjustedDateTime)
        {
            ActionItem actionItem = new ActionItem("Passed shift adjusted date time",
                                                   "Go on and get cleaned up",
                                                   false,
                                                   ActionItemStatus.Current,
                                                   Priority.Normal, 
                                                   DataSource.MANUAL,
                                                   shiftAdjustedDateTime,
                                                   shiftAdjustedDateTime,
                                                   shiftAdjustedDateTime,
                                                   ScheduleType.Single,
                                                   new List<FunctionalLocation>{FunctionalLocationFixture.GetAny_Equip1()},
                                                   BusinessCategoryFixture.GetEnvironmentalSafetyCategory(),
                                                   UserFixture.CreateOperatorGoofyInFortMcMurrySite(),
                                                   new DateTime(2005, 12, 11),
                                                   new List<DocumentLink>(), 
                                                   null,
                                                   null,
                                                   null,
                                                   null,
                                                   null,0,null,null,null,string.Empty,null,false);           //ayman visibility groups     ayman action item definition   ayman action item reading
            return actionItem;
        }

        public static ActionItem CreateACompleteActionItemWithFlocListAndNoId()
        {
            ActionItem actionItem = CreateAPendingActionItemWithFlocListAndNoId();
            actionItem.Description = "Test Action Item Instance Complete";
            actionItem.SetStatus(ActionItemStatus.Complete, actionItem.LastModifiedBy, actionItem.LastModifiedDate);

            return actionItem;
        }

        public static ActionItem CreateAIncompleteActionItemWithFlocListAndNoId()
        {
            ActionItem actionItem = CreateAPendingActionItemWithFlocListAndNoId();
            actionItem.Description = "Test Action Item Instance incomplete";
            actionItem.SetStatus(ActionItemStatus.Incomplete, actionItem.LastModifiedBy, actionItem.LastModifiedDate);

            return actionItem;
        }

        public static ActionItem CreateAPendingActionItemWithIdPassedIn(long id)
        {
            return CreateAPendingActionItemWithIdPassedIn(id, Priority.Normal);
        }

        private static ActionItem CreateAPendingActionItemWithIdPassedIn(long id, Priority priority)
        {
            return CreateAPendingActionItemWithIdPassedIn(id, priority, null);
        }

        private static ActionItem CreateAPendingActionItemWithIdPassedIn(long id, Priority priority, long? gn75BId)
        {
            ActionItem actionItem = new ActionItem("This is my name",
                                                   "Test Action Item Instance Pending",
                                                   false,
                                                   ActionItemStatus.Current,
                                                   priority,
                                                   DataSource.MANUAL,
                                                   new DateTime(2005, 12, 12, 8, 0, 0),
                                                   new DateTime(2005, 12, 12, 16, 0, 0),
                                                   null,
                                                   ScheduleType.Single,
                                                   new List<FunctionalLocation>{FunctionalLocationFixture.GetAny_Equip1()},
                                                   BusinessCategoryFixture.GetEnvironmentalSafetyCategory(),
                                                   UserFixture.CreateOperatorGoofyInFortMcMurrySite(),
                                                   new DateTime(2005, 12, 11),
                                                   new List<DocumentLink>(),
                                                   null,
                                                   null,
                                                   null,
                                                   gn75BId, null,0,null,null,null,string.Empty,null,false) { Id = id };                 //ayman visibility groups        ayman action item definition  ayman action item reading

            return actionItem;
        }

        public static ActionItem CreateAPendingResponseRequiredActionItemWithIdPassedIn(long id)
        {
            ActionItem actionItem = CreateAPendingActionItemWithIdPassedIn(id);
            actionItem.Description = "Test Action Item Instance Pending";
            actionItem.SetStatus(ActionItemStatus.Current, actionItem.LastModifiedBy, actionItem.LastModifiedDate);
            actionItem.ResponseRequired = true;

            return actionItem;
        }

        public static ActionItem CreatNewActionItemWithCreatedByActionItemDefinition()
        {
            return CreateNewActionItemWithCreatedByActionItemDefinition(ActionItemDefinitionFixture.CreateApprovedActionItemDefinitionForMcMurrayWithActionItemId(ActionItemDefinitionFixture.AID_FOR_LINKING_WITH_AI_ID));
        }

        public static ActionItem CreateNewActionItemWithCreatedByActionItemDefinition(ActionItemDefinition createdByActionItemDefinition)
        {
            return CreateNewActionItemWithCreatedByActionItemDefinition(createdByActionItemDefinition, null);
        }

        public static ActionItem CreateNewActionItemWithCreatedByActionItemDefinition(ActionItemDefinition createdByActionItemDefinition, DateTime? shiftAdjustedEndTime)
        {
            ActionItem actionItem = CreateAPendingActionItemWithFlocListAndNoId();

            return new ActionItem(actionItem.Name,
                                  actionItem.Description,
                                  actionItem.ResponseRequired,
                                  actionItem.Status,
                                  actionItem.Priority,
                                  actionItem.Source,
                                  actionItem.StartDateTime,
                                  actionItem.EndDateTime,
                                  shiftAdjustedEndTime,
                                  actionItem.CreatedByScheduleType,
                                  actionItem.FunctionalLocations,
                                  actionItem.Category,
                                  actionItem.LastModifiedBy,
                                  actionItem.LastModifiedDate,
                                  actionItem.DocumentLinks,
                                  actionItem.StatusModification,
                                  createdByActionItemDefinition,
                                  actionItem.Assignment,
                                  actionItem.AssociatedFormGn75BId,
                                  null,0,null,null,null,string.Empty,null,actionItem.Reading);              //ayman visibility groups          ayman action item definition   ayman action item reading
        }

        public static ActionItem CreateActionItemFromHSched(ActionItemDefinition createdByActionItemDefinition)
        {
            return new ActionItem("HSched Blending Instructions For: TK13 on 20060302 224200",
                                  "Volume: 8531, Rate: 502.75, Grade: LVB-87, Source: a source, Tank: TK13",
                                  true,
                                  ActionItemStatus.Incomplete,
                                  Priority.Normal,
                                  DataSource.SAP,
                                  new DateTime(2006, 3, 2, 22, 42, 00),
                                  new DateTime(2006, 4, 2, 15, 40, 00),
                                  null,
                                  ScheduleType.Single,
                                  new List<FunctionalLocation>{FunctionalLocationFixture.GetAny_Unit1()},
                                  BusinessCategoryFixture.GetProductionCategory(),
                                  UserFixture.CreateRemoteAppUser(),
                                  DateTimeFixture.DateTimeNow,
                                  new List<DocumentLink>{new DocumentLink(@"\\File015\SAP_Data\PB2\PSSP\FilePolling\Monitor\OLT\LinkedData\1.pdf", "HSched Details")}, 
                                  null,
                                  createdByActionItemDefinition,
                                  null,
                                  null,
                                  null,0,null,null,null,string.Empty,null,false);              //ayman visibility groups              ayman action item definition    action item reading
        }

        private static ActionItem CreateActionItemWithStartAndEndDateTime(DateTime startDateTime, DateTime endDateTime)
        {
            return new ActionItem("This is my name",
                                  "Test Action Item Instance Pending",
                                  false,
                                  ActionItemStatus.Current,
                                  Priority.Normal,
                                  DataSource.MANUAL,
                                  startDateTime,
                                  endDateTime,
                                  null,
                                  ScheduleType.Single,
                                  new List<FunctionalLocation>{FunctionalLocationFixture.GetAny_Equip1()},
                                  BusinessCategoryFixture.GetProductionCategory(),
                                  UserFixture.CreateOperatorGoofyInFortMcMurrySite(),
                                  new DateTime(2005, 12, 11),
                                  new List<DocumentLink>(),
                                  null,
                                  null,
                                  null,
                                  null,
                                  null,0,null,null,null,string.Empty,null,false);       //ayman visibility groups              ayman action item definition   ayman action item reading
        }
    }
}