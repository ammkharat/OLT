using System;
using System.Text;
using System.Collections.Generic;
using log4net;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;


namespace Com.Suncor.Olt.Remote.Utilities
{
    public static class WorkOrderToActionItemDefinition
    {
        private static ILog logger;
        private static ITimeService timeService;
        private static User sapUser;
        public static void BuildActionItemDefinition(WorkOrderImportData importData, FunctionalLocation floc, ILog _logger, ITimeService _timeService1)
        {
            logger = _logger;
            timeService = _timeService1;

            if (floc != null)
                if (Equals(floc.Type, FunctionalLocationType.Level1) ||
                    Equals(floc.Type, FunctionalLocationType.Level2))
                {
                    logger.WarnFormat(
                        "Work order {0} is ignored because the functional location, {1}, is at at invalid level.",
                        importData.WorkOrderNumber, floc.FullHierarchy);
                    return;
                }
            IUserService userService = Common.Wcf.GenericServiceRegistry.Instance.GetService<IUserService>();
            sapUser = userService.GetSAPUser();

            IActionItemDefinitionService actionItemDefinitionService =
                Common.Wcf.GenericServiceRegistry.Instance.GetService<IActionItemDefinitionService>();

            var incomingActionItemDefinition = BuildForSAPWorkOrder(importData, floc);

            var existingDefinition = actionItemDefinitionService.QueryBySapOperationWorkOrderDetails(
            importData.WorkOrderNumber,
            importData.OperationNumber,
            importData.Suboperation);

            if (existingDefinition == null)
            {
                logger.DebugFormat(
                "Did not find WorkOrder <{0}>, Operation <{1}>, SubOperation <{2}>  existing in the system already. Doing an Insert of a new ActionItemDefinition.",
                importData.WorkOrderNumber, importData.OperationNumber, importData.Suboperation);

                var sapWorkOrderOperation = new SapWorkOrderOperation(
                null,
                importData.WorkOrderNumber,
                importData.OperationNumber,
                importData.Suboperation,
                SapOperationType.ActionItemDefinition);

                AutoApproveActionItemDefinition(floc, incomingActionItemDefinition);

                logger.DebugFormat(
                "Inserting the new ActionItemDefinition for WorkOrderNumber <{0}>, <{1}>, <{2}> using Description:" +
                Environment.NewLine + "{3}",
                importData.WorkOrderNumber, importData.OperationNumber, importData.Suboperation,
                incomingActionItemDefinition.Description);

                actionItemDefinitionService.Insert(incomingActionItemDefinition, sapWorkOrderOperation);
            }
            else
            {
                logger.DebugFormat(
                "Found that WorkOrder <{0}>, Operation <{1}>, SubOperation <{2}>  exists in the system already.",
                importData.WorkOrderNumber, importData.OperationNumber, importData.Suboperation);

                UpdateActionItemDefinition(existingDefinition, incomingActionItemDefinition, actionItemDefinitionService);
            }

        }


        private static ActionItemDefinition BuildForSAPWorkOrder(WorkOrderImportData importData, FunctionalLocation functionalLocation)
        {
            var description = BuildWorkOrderDescriptionForActionItemDefinition(importData);
            var site = functionalLocation.Site;
            var currentTimeAtSite = timeService.GetTime(site.TimeZone);
            var name = string.Format("{0}-{1}-{2}", importData.WorkOrderNumber, importData.OperationNumber,
                currentTimeAtSite.Millisecond);

            //set the start and end datetime
            DateTime startDateTime;
            var parsed = DateTimeExtensions.TryParse(importData.EarliestStartDate,
                importData.EarliestStartTime, out startDateTime);
            if (!parsed)
            {
                throw new WorkOrderToOltObjectBuilderException(
                    string.Format(
                        "Could not parse EarliestStartDate, {0}, and/or EarliestStartTime, {1}, into a Valid DateTime.",
                        importData.EarliestStartDate, importData.EarliestStartTime));
            }
            DateTime endDateTime;
            parsed = DateTimeExtensions.TryParse(importData.EarliestFinishDate,
                importData.EarliestFinishTime, out endDateTime);
            if (!parsed)
            {
                throw new WorkOrderToOltObjectBuilderException(
                    string.Format(
                        "Could not parse EarliestFinishDate, {0}, and/or EarliestFinishTime, {1}, into a Valid DateTime.",
                        importData.EarliestFinishDate, importData.EarliestFinishTime));
            }

            ISchedule schedule =
                new SingleSchedule(new Date(startDateTime), new Time(startDateTime), new Time(endDateTime), site);

            var flocList = new List<FunctionalLocation> { functionalLocation };

            IBusinessCategoryService businessCategoryService =
                Common.Wcf.GenericServiceRegistry.Instance.GetService<IBusinessCategoryService>();
            var businessCategory = businessCategoryService.GetDefaultSAPWorkOrderCategory(site.IdValue);

            var actionItemDefinition = new ActionItemDefinition(name,
                businessCategory,
                ActionItemDefinitionStatus.Pending,
                schedule,
                description,
                DataSource.SAP,
                true,
                false,
                false,
                sapUser,//createdBy,
                currentTimeAtSite,
                sapUser,//createdBy,
                currentTimeAtSite,
                flocList,
                new List<Common.DTO.TargetDefinitionDTO>(),
                new List<DocumentLink>(),
                OperationalMode.Normal,
                null,
                true, null, null,null,false,false,false,null);     //ayman custom fields DMND0010030

            return actionItemDefinition;
        }

        private static string BuildWorkOrderDescriptionForActionItemDefinition(WorkOrderImportData importData)
        {
            var sb = new StringBuilder();

            sb.Append(StringResources.ActionItemDefinitionWorkOrderDescriptionHeader);
            sb.AppendLine();

            if (importData.EquipmentNumber.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionEquipmentNumber,
                    importData.EquipmentNumber);
                sb.AppendLine();
            }
            if (importData.WorkOrderNumber.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionWorkOrderNumber,
                    importData.WorkOrderNumber);
                sb.AppendLine();
            }
            if (importData.OperationNumber.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionOperationNumber,
                    importData.OperationNumber);
                sb.AppendLine();
            }
            if (importData.Suboperation.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionSubOperationNumber,
                    importData.Suboperation);
                sb.AppendLine();
            }
            if (importData.ShortText.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionShortText,
                    importData.ShortText);
                sb.AppendLine();
            }

            if (importData.LongText.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionLongText,
                    importData.LongText);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        private static void AutoApproveActionItemDefinition(FunctionalLocation functionalLocation,
            ActionItemDefinition incomingActionItemDefinition)
        {
            ISiteConfigurationService siteConfigurationService =
                Common.Wcf.GenericServiceRegistry.Instance.GetService<ISiteConfigurationService>();

            var siteConfiguration = siteConfigurationService.QueryBySiteId(functionalLocation.Site.IdValue);

            if (siteConfiguration.AutoApproveWorkOrderActionItemDefinition)
            {
                //  AID Last Modified By and Last Modidifed Date should have been set earlier.
                incomingActionItemDefinition.Approve(incomingActionItemDefinition.LastModifiedBy,
                    incomingActionItemDefinition.LastModifiedDate);
            }
            else
            {
                incomingActionItemDefinition.WaitForApproval();
            }
        }

        private static void UpdateActionItemDefinition(ActionItemDefinition existingDefinition,
            ActionItemDefinition incomingActionItemDefinition, IActionItemDefinitionService actionItemDefinitionService)
        {
            var isNewActionItemDifferent = IsNewActionItemDifferent(existingDefinition, incomingActionItemDefinition);

            if (existingDefinition.Is(ActionItemDefinitionStatus.Pending) &&
                existingDefinition.LastModifiedBy.Id == sapUser.Id && isNewActionItemDifferent)
            {
                logger.DebugFormat("Action Item {0} is being updated because info from SAP changed.",
                    existingDefinition.IdValue);

                var definitionToInsert = MergeActionItemDefinitionsForUpdate(existingDefinition,
                    incomingActionItemDefinition);
                actionItemDefinitionService.Update(definitionToInsert);
            }
            else if (!isNewActionItemDifferent)
            {
                logger.InfoFormat("Work Permit {0} was not updated because it hasn't changed.", existingDefinition.Id);
            }

            else
            {
                logger.InfoFormat(
                    "Action Item Definition {0} was not updated via SAP because it has already been modified in OLT",
                    existingDefinition.Id);
            }
        }

        private static bool IsNewActionItemDifferent(ActionItemDefinition existingDefinition,
           ActionItemDefinition incomingActionItemDefinition)
        {
            return existingDefinition.Description.DoesNotEqual(incomingActionItemDefinition.Description) ||
                   existingDefinition.Schedule.StartDate.DoesNotEqual(incomingActionItemDefinition.Schedule.StartDate) ||
                   existingDefinition.Schedule.StartTime.DoesNotEqual(incomingActionItemDefinition.Schedule.StartTime) ||
                   existingDefinition.Schedule.EndTime.DoesNotEqual(incomingActionItemDefinition.Schedule.EndTime);
        }

        private static ActionItemDefinition MergeActionItemDefinitionsForUpdate(ActionItemDefinition existingDefinition,
            ActionItemDefinition
                incomingActionItemDefinition)
        {
            var currentTimeAtSite =
                timeService.GetTime(incomingActionItemDefinition.FunctionalLocations[0].Site.TimeZone);

            if (logger.IsDebugEnabled)
            {
                if (string.Equals(existingDefinition.Description, incomingActionItemDefinition.Description))
                {
                    logger.DebugFormat("Keeping Description for ActionItemDef <{0}> as:" + Environment.NewLine + "{1}",
                        existingDefinition.Id, existingDefinition.Description);
                }
                else
                {
                    logger.DebugFormat(
                        "Changing Description for ActionItemDef <{0}> from:" + Environment.NewLine + "{1}" +
                        Environment.NewLine + "" + Environment.NewLine + "To:" + Environment.NewLine + "{2}",
                        existingDefinition.Id, existingDefinition.Description,
                        incomingActionItemDefinition.Description);
                }
            }

            existingDefinition.Description = incomingActionItemDefinition.Description;

            MergeSchedule(existingDefinition, incomingActionItemDefinition);

            existingDefinition.FunctionalLocations = incomingActionItemDefinition.FunctionalLocations;
            existingDefinition.LastModifiedBy = sapUser;
            existingDefinition.LastModifiedDate = currentTimeAtSite;

            return existingDefinition;
        }

        private static void MergeSchedule(ActionItemDefinition existingDefinition,
            ActionItemDefinition incomingActionItemDefinition)
        {
            incomingActionItemDefinition.Schedule.LastInvokedDateTime =
                existingDefinition.Schedule.LastInvokedDateTime;

            var existingScheduleId = existingDefinition.Schedule.Id;

            if (existingScheduleId.HasValue)
            {
                incomingActionItemDefinition.Schedule.Id = existingScheduleId;
            }
            else
            {
                logger.InfoFormat(
                    "No Schedule was found on Existing Action Item {0}.  So, the Action Item's Schedule could not be updated.",
                    existingDefinition.Id);
            }
            existingDefinition.Schedule = incomingActionItemDefinition.Schedule;
        }

    }

    class WorkOrderToOltObjectBuilderException : Common.Exceptions.OLTException
    {
        public WorkOrderToOltObjectBuilderException(string message)
            : base(message)
        {
        }
    }
}
