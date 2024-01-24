using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Clock = Com.Suncor.Olt.Common.Utility.Clock;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ActionItemDefinitionGenerator
    {
        private readonly ITargetDefinitionService targetDefinitionService;

        public ActionItemDefinitionGenerator(ITargetDefinitionService targetDefinitionService)
        {
            this.targetDefinitionService = targetDefinitionService;
        }

        public ActionItemDefinition BuildActionItemDefinition(TargetDefinition targetDefinition)
        {
            User user = targetDefinition.LastModifiedBy;
            DateTime currentTimeAtSite = Clock.Now;
            ISchedule schedule = targetDefinition.Schedule;

            bool startDateInFuture = schedule.StartDateTime > currentTimeAtSite;
            Date startDate = startDateInFuture ? schedule.StartDate : new Date(currentTimeAtSite);
            Time startTime = startDateInFuture ? schedule.StartTime : new Time(currentTimeAtSite);
            Time endTime = startDateInFuture ? schedule.EndTime : new Time(currentTimeAtSite);

            var functionalLocations = new List<FunctionalLocation> {targetDefinition.FunctionalLocation};

            Site site = targetDefinition.FunctionalLocation.Site;
            
            return new ActionItemDefinition(string.Empty,
                                            null,
                                            ActionItemDefinitionStatus.Approved,
                                            new SingleSchedule(startDate, startTime, endTime, site),
                                            CreateActionItemDefinitionDescription(targetDefinition),
                                            DataSource.TARGET,
                                            false,
                                            true,
                                            false,
                                            user,
                                            currentTimeAtSite,
                                            user,
                                            currentTimeAtSite,
                                            functionalLocations,
                                            new List<TargetDefinitionDTO>(),
                                            targetDefinition.CloneDocumentLinksForDBInsert(),
                                            OperationalMode.Normal,
                                            null,
                                            true, null,null,null,false,false,false,null);              //ayman visibility groups     //ayman custom fields DMND0010030
        }

        private readonly string REAPPROVING_TARGET_DEFINITION =
            StringResources.PreviouslyApprovedActionItemDefinitionFromTarget_Header +
            Environment.NewLine + StringResources.PreviouslyApprovedActionItemDefinitionFromTarget_DefinitionName +
            Environment.NewLine + StringResources.PreviouslyApprovedActionItemDefinitionFromTarget_Description +
            Environment.NewLine + StringResources.PreviouslyApprovedActionItemDefinitionFromTarget_PHTag +
            Environment.NewLine + StringResources.PreviouslyApprovedActionItemDefinitionFromTarget_Min +
            Environment.NewLine + StringResources.PreviouslyApprovedActionItemDefinitionFromTarget_Max +
            Environment.NewLine + StringResources.PreviouslyApprovedActionItemDefinitionFromTarget_Target +
            Environment.NewLine + StringResources.PreviouslyApprovedActionItemDefinitionFromTarget_NTESOLMin +
            Environment.NewLine + StringResources.PreviouslyApprovedActionItemDefinitionFromTarget_NTESOLMax;

        private readonly string NEWLY_APPROVED_TARGET_DEFINITION =
            StringResources.NewlyApprovedActionItemDefinitionFromTarget_Header +
            Environment.NewLine + StringResources.NewlyApprovedActionItemDefinitionFromTarget_DefinitionName +
            Environment.NewLine + StringResources.NewlyApprovedActionItemDefinitionFromTarget_Description +
            Environment.NewLine + StringResources.NewlyApprovedActionItemDefinitionFromTarget_PHTag +
            Environment.NewLine + StringResources.NewlyApprovedActionItemDefinitionFromTarget_Min +
            Environment.NewLine + StringResources.NewlyApprovedActionItemDefinitionFromTarget_Max +
            Environment.NewLine + StringResources.NewlyApprovedActionItemDefinitionFromTarget_Target +
            Environment.NewLine + StringResources.NewlyApprovedActionItemDefinitionFromTarget_NTESOLMin +
            Environment.NewLine + StringResources.NewlyApprovedActionItemDefinitionFromTarget_NTESOLMax;

        private string CreateActionItemDefinitionDescription(TargetDefinition targetDefinition)
        {
            TargetDefinitionHistory previouslyApproved = FindPreviouslyApproved(targetDefinition.Id.Value);

            if (previouslyApproved == null)
            {
                return string.Format(NEWLY_APPROVED_TARGET_DEFINITION, targetDefinition.Name,
                                     targetDefinition.Description,
                                     targetDefinition.TagInfo.Name, targetDefinition.TagInfo.Description,
                                     targetDefinition.MinValue.Format(),
                                     targetDefinition.MaxValue.Format(),
                                     targetDefinition.TargetValue.Title,
                                     targetDefinition.NeverToExceedMinimum.Format(),
                                     targetDefinition.NeverToExceedMaximum.Format());
            }
            return string.Format(REAPPROVING_TARGET_DEFINITION, targetDefinition.Name,
                                 targetDefinition.Description,
                                 targetDefinition.TagInfo.Name, targetDefinition.TagInfo.Description,
                                 previouslyApproved.MinValue, targetDefinition.MinValue.Format(),
                                 previouslyApproved.MaxValue, targetDefinition.MaxValue.Format(),
                                 previouslyApproved.TargetValue, targetDefinition.TargetValue.Title,
                                 previouslyApproved.NeverToExceedMinimum, targetDefinition.NeverToExceedMinimum.Format(),
                                 previouslyApproved.NeverToExceedMaximum, targetDefinition.NeverToExceedMaximum.Format());
        }

        /// <summary>
        /// Finds the Previously approved TargetDefinitionHistory for the currently Approved TargetDefinition
        /// </summary>
        /// <returns></returns>
        private TargetDefinitionHistory FindPreviouslyApproved(long targetDefinitionId)
        {
            List<TargetDefinitionHistory> targetDefinitionHistories = targetDefinitionService.GetHistory(targetDefinitionId);
            
            // The last approved History should coorespond to the current state if the TargetDefinition.
            int lastApprovedIndex =
                targetDefinitionHistories.FindLastIndex(history => !history.RequiresApproval);
            
            if (targetDefinitionHistories.Count == 1 || lastApprovedIndex == -1) return null;

            int secondToLastApprovedIndex = targetDefinitionHistories.FindLastIndex(lastApprovedIndex - 1,
                                                                                    history =>
                                                                                    !history.RequiresApproval);

            return (secondToLastApprovedIndex != -1 && secondToLastApprovedIndex < lastApprovedIndex) ? targetDefinitionHistories[secondToLastApprovedIndex] : null;
        }
    }
}
