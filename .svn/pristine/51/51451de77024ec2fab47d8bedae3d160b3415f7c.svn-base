using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ActionItemSubreportBuilder
    {
        private readonly IActionItemDefinitionService actionItemDefinitionService;
        private readonly IActionItemService actionItemService;
        private readonly IFunctionalLocationOperationalModeService operationalModeService;

        private readonly SiteConfiguration siteConfiguration;

        public ActionItemSubreportBuilder(
            IActionItemDefinitionService actionItemDefinitionService,
            IActionItemService actionItemService,
            IFunctionalLocationOperationalModeService operationalModeService,
            SiteConfiguration siteConfiguration)
        {
            this.actionItemDefinitionService = actionItemDefinitionService;
            this.actionItemService = actionItemService;
            this.operationalModeService = operationalModeService;
            this.siteConfiguration = siteConfiguration;
        }

        public List<ActionItemReportAdapter> GetActionItemReportAdapters(ShiftHandoverQuestionnaire questionnaire,
            UserShift nextShift)
        {
            List<ActionItemReportAdapter> actionItemReportAdapters;

            if (Clock.Now >= nextShift.StartDateTime)
            {
                actionItemReportAdapters = GetPastActionItemReportAdapters(questionnaire, nextShift);
            }
            else
            {
                var handoverAssignment = questionnaire.Assignment;
                List<ActionItemDefinition> actionItemDefinitions;

                if (handoverAssignment != null && handoverAssignment.UseWorkAssignmentForActionItemHandoverDisplay)
                {
                    actionItemDefinitions = actionItemDefinitionService
                        .QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(
                            questionnaire.Assignment, new RootFlocSet(questionnaire.FunctionalLocations), Clock.Now,
                            handoverAssignment.WriteWorkAssignmentVisibilityGroups.ConvertAll(
                                wavg => wavg.VisibilityGroupId));
                }
                else
                {
                    List<long> visibilityGroupIds = null;
                    if (handoverAssignment != null)
                    {
                        visibilityGroupIds =
                            handoverAssignment.ReadWorkAssignmentVisibilityGroups.ConvertAll(
                                wavg => wavg.VisibilityGroupId);
                    }

                    actionItemDefinitions =
                        actionItemDefinitionService.QueryActiveDtosByParentFunctionalLocations(

                            new RootFlocSet(questionnaire.FunctionalLocations), Clock.Now, visibilityGroupIds);
                }

                actionItemReportAdapters = GetFutureActionItemReportAdapters(questionnaire, nextShift,
                    actionItemDefinitions);
            }

            actionItemReportAdapters.Sort(adapter => adapter.GetRawStartDateTime());
            return actionItemReportAdapters;
        }

        private List<ActionItemReportAdapter> GetPastActionItemReportAdapters(ShiftHandoverQuestionnaire questionnaire,
            UserShift userShift)
        {
            var handoverAssignment = questionnaire.Assignment;
            List<ActionItemDTO> actionItemDtos;

            if (handoverAssignment != null && handoverAssignment.UseWorkAssignmentForActionItemHandoverDisplay)
            {
                actionItemDtos = actionItemService.QueryDTOsByParentFunctionalLocationsAndWorkAssignmentAndDateRange(
                    new RootFlocSet(questionnaire.FunctionalLocations), questionnaire.Assignment,
                    userShift.StartDateTime,
                    userShift.EndDateTime,
                    handoverAssignment.ReadWorkAssignmentVisibilityGroups.ConvertAll(wavg => wavg.VisibilityGroupId));
            }
            else
            {
                List<long> visibilityGroupIds = null;
                if (handoverAssignment != null)
                {
                    visibilityGroupIds =
                        handoverAssignment.ReadWorkAssignmentVisibilityGroups.ConvertAll(wavg => wavg.VisibilityGroupId);
                }

                actionItemDtos = actionItemService.QueryDTOsByParentFunctionalLocationsAndDateRange(
                    new RootFlocSet(questionnaire.FunctionalLocations), userShift.StartDateTime, userShift.EndDateTime,
                    visibilityGroupIds);
            }

            return
                actionItemDtos.ConvertAll(
                    actionItemDto =>
                        new ActionItemReportAdapter(questionnaire.IdValue.ToString(CultureInfo.InvariantCulture),
                            actionItemDto));
        }

        private List<ActionItemReportAdapter> GetFutureActionItemReportAdapters(
            ShiftHandoverQuestionnaire questionnaire, UserShift nextShift,
            List<ActionItemDefinition> actionItemDefinitions)
        {
            var actionItemReportAdapters = new List<ActionItemReportAdapter>();

            var preShiftPadding = siteConfiguration.PreShiftPaddingInMinutes;

            foreach (var actionItemDefinition in actionItemDefinitions)
            {
                var flocSets = GetFlocSets(actionItemDefinition, questionnaire);

                var nextInvokeDateTimes = actionItemDefinition.Schedule.NextInvokeDateTimes(nextShift.EndDateTime);
                nextInvokeDateTimes.RemoveAll(dateTime => dateTime < nextShift.StartDateTime);

                foreach (var invocationDateTime in nextInvokeDateTimes)
                {
                    foreach (var flocs in flocSets)
                    {
                        var startDateTime =
                            ScheduleHelper.GetScheduleInstanceStartDateTime(actionItemDefinition.Schedule,
                                invocationDateTime, preShiftPadding);
                        var endDateTime = ScheduleHelper.GetScheduleInstanceEndDateTime(actionItemDefinition.Schedule,
                            invocationDateTime, preShiftPadding);

                        var actionItemDto = new ActionItemDTO(-1,
                            startDateTime,
                            startDateTime,
                            endDateTime,
                            endDateTime,
                            actionItemDefinition.Status.IdValue,
                            actionItemDefinition.Priority,
                            actionItemDefinition.Category.Name,
                            actionItemDefinition.Source.IdValue,
                            actionItemDefinition.Description,
                            actionItemDefinition.Schedule.Type.Name,
                            new List<string> {flocs},
                            new List<string> {flocs},
                            actionItemDefinition.ResponseRequired,
                            actionItemDefinition.LastModifiedBy.IdValue,
                            actionItemDefinition.Name,
                            actionItemDefinition.Assignment != null ? actionItemDefinition.Assignment.Name : null,
                            actionItemDefinition.Assignment != null ? actionItemDefinition.Assignment.Id : null,
                            actionItemDefinition.WritableWorkAssignmentVisibilityGroups.ConvertAll(
                                wavg => wavg.VisibilityGroupName),actionItemDefinition.VisGroupsStartingWith,actionItemDefinition.IdValue,actionItemDefinition.Reading);           //ayman visibility group           ayman action item definition


                        actionItemReportAdapters.Add(
                            new ActionItemReportAdapter(questionnaire.IdValue.ToString(CultureInfo.InvariantCulture),
                                actionItemDto));
                    }
                }
            }

            return actionItemReportAdapters;
        }

        private List<string> GetFlocSets(ActionItemDefinition actionItemDefinition,
            ShiftHandoverQuestionnaire questionnaire)
        {
            var actionItemDefinitionFlocs = actionItemDefinition.FunctionalLocations;

            var flocSets = new List<string>();
            if (actionItemDefinition.CreateAnActionItemForEachFunctionalLocation)
            {
                foreach (var actionItemDefinitionFloc in actionItemDefinitionFlocs)
                {
                    if (
                        questionnaire.FunctionalLocations.Exists(
                            qf => qf.Id == actionItemDefinitionFloc.Id || qf.IsParentOf(actionItemDefinitionFloc)))
                    {
                        var flocOperationalModeDTO =
                            operationalModeService.GetByFunctionalLocationId(actionItemDefinitionFloc.IdValue);
                        if (flocOperationalModeDTO.OperationalMode.Equals(actionItemDefinition.OperationalMode))
                        {
                            flocSets.Add(actionItemDefinitionFloc.ToString());
                        }
                    }
                }
            }
            else
            {
                var atLeastOneFlocMatchesDefinitionOperationMode =
                    AtLeastOneFlocMatchesDefinitionOperationMode(actionItemDefinition.OperationalMode,
                        actionItemDefinitionFlocs);

                if (atLeastOneFlocMatchesDefinitionOperationMode)
                {
                    flocSets.Add(actionItemDefinitionFlocs.FullHierarchyListToString(true, true));
                }
            }
            return flocSets;
        }

        private bool AtLeastOneFlocMatchesDefinitionOperationMode(OperationalMode operationalMode,
            IEnumerable<FunctionalLocation> unitOrBelowFlocs)
        {
            foreach (var floc in unitOrBelowFlocs)
            {
                var flocOperationalModeDTO = operationalModeService.GetByFunctionalLocationId(floc.IdValue);
                if (flocOperationalModeDTO.OperationalMode.Equals(operationalMode))
                {
                    return true;
                }
            }

            return false;
        }
    }
}