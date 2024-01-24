using System;
using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    public class WorkOrderAdapter
    {
        #region MetaData

#pragma warning disable 1587
        // The data held in the user assignment object takes the form
        //
        // WorkOrderObj[n].WorkOrderNumber:                 Unique work order number
        // WorkOrderObj[n].ShortText:                       Short descriptive text
        // WorkOrderObj[n].FunctionalLocation:              Associated functional location
        // WorkOrderObj[n].EquipmentNumber:                 Optional Equipment number
        // WorkOrderObj[n].PlantID:                         Target Plant for work order

        // Each workOrder will have at least one operations record
        // WorkOrderObj[n].Operations[n].OperationNumber:   Unique operation number
        // WorkOrderObj[n].Operations[n].Suboperation:      Optional sub-operation number
        // WorkOrderObj[n].Operations[n].EarliestStartDate: 
        // WorkOrderObj[n].Operations[n].EarliestStartTime:
        // WorkOrderObj[n].Operations[n].EarliestFinishDate:
        // WorkOrderObj[n].Operations[n].EarliestFinishTime:
        // WorkOrderObj[n].Operations[n].LongText:          Optional long descriptive text maps to 
        // WorkOrderObj[n].Operations[n].WorkPermitType:    Optional work permit type ("HOT" or "COLD") . Blank implies work permit
        // WorkOrderObj[n].Operations[n].WorkPermitAttrib:  Indicator for the types of permit attributes
        /// Attributes: A=IsConfinedSpaceEntry, B=IsBurnOrOpenFlame, C=IsSystemEntry, D=IsBreathingAirOrSCBA, E=IsVehicleEntry, F=IsExcavation
        /// G=IsHotTap, H=IsAsbestos, I=IsCriticalLift, J=IsRadiationSealed, K=IsRadiationRadiography, L=IsElectricalSwitching
        /// M=IsEnergizedElectrical
        // WorkOrderObj[n].Operations[n].WorkCenterCode:      Work center for the associated operation 
        // WorkOrderObj[n].Operations[n].WorkCenterText:    Text description of the work center (e.g. Welder)
#pragma warning restore 1587

        #endregion
        private readonly ILog logger = LogManager.GetLogger(typeof(WorkOrderAdapter));

        private readonly WorkOrderDetails[] workOrderDetailsArray;

        private readonly IWorkPermitService workPermitService;
        private readonly IActionItemDefinitionService actionItemDefinitionService;
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly ISiteService siteService;
        private readonly IUserService userService;
        private readonly ITimeService timeService;
        private readonly ISiteConfigurationService siteConfigurationService;
        private readonly ICraftOrTradeService craftOrTradeService;
        private readonly IBusinessCategoryService businessCategoryService;
        private readonly IWorkPermitAutoAssignmentConfigurationService workPermitAutoAssignmentConfigurationService;
        private readonly IWorkAssignmentService workAssignmentService;

        private readonly User sapUser;

        public WorkOrderAdapter(WorkOrderDetails[] workOrderDetailsArray) :
            this(workOrderDetailsArray,
                GenericServiceRegistry.Instance.GetService<IWorkPermitService>(),
                GenericServiceRegistry.Instance.GetService<IActionItemDefinitionService>(),
                GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>(),
                GenericServiceRegistry.Instance.GetService<ISiteService>(),
                GenericServiceRegistry.Instance.GetService<IUserService>(),
                GenericServiceRegistry.Instance.GetService<ITimeService>(),
                GenericServiceRegistry.Instance.GetService<ISiteConfigurationService>(),
                GenericServiceRegistry.Instance.GetService<ICraftOrTradeService>(),
                GenericServiceRegistry.Instance.GetService<IBusinessCategoryService>(),
                GenericServiceRegistry.Instance.GetService<IWorkPermitAutoAssignmentConfigurationService>(),
                GenericServiceRegistry.Instance.GetService<IWorkAssignmentService>()
            )
        {
        }

        public WorkOrderAdapter(WorkOrderDetails[] workOrderDetailsArray,
            IWorkPermitService workPermitService,
            IActionItemDefinitionService actionItemDefinitionService,
            IFunctionalLocationService functionalLocationService,
            ISiteService siteService,
            IUserService userService,
            ITimeService timeService,
            ISiteConfigurationService siteConfigurationService,
            ICraftOrTradeService craftOrTradeService,
            IBusinessCategoryService businessCategoryService,
            IWorkPermitAutoAssignmentConfigurationService workPermitAutoAssignmentConfigurationService,
            IWorkAssignmentService workAssignmentService)
        {
            this.workOrderDetailsArray = workOrderDetailsArray;

            this.workPermitService = workPermitService;
            this.actionItemDefinitionService = actionItemDefinitionService;
            this.functionalLocationService = functionalLocationService;
            this.siteService = siteService;
            this.userService = userService;
            this.timeService = timeService;
            this.siteConfigurationService = siteConfigurationService;
            this.craftOrTradeService = craftOrTradeService;
            this.businessCategoryService = businessCategoryService;
            this.workPermitAutoAssignmentConfigurationService = workPermitAutoAssignmentConfigurationService;
            this.workAssignmentService = workAssignmentService;

            sapUser = userService.GetSAPUser();
        }

        public void IntegrateWorkOrdersToOperatorLogTool()
        {
            // Iterate through the notification collection and add to the OLT database
            // either automated Action Items of items for log import selection
            foreach (var details in workOrderDetailsArray)
            {
                Thread.CurrentThread.CurrentUICulture =
                    LanguageCode.GetCultureInfoFromSAPALanguageCode(details.LanguageCode);


                //ayman SAP Mapping
                if (details.PlantID == "7030" || details.PlantID == "7600")
                {
                    details.PlantID = "9991";
                }



                var site = siteService.QueryByPlantId(details.PlantID);
                if (!IsSiteInOlt(site, details))
                {
                    continue; // move on to the next WorkOrder
                }

                var functionalLocation = functionalLocationService.QueryByFullHierarchy(details.FunctionalLocation,
                    site.IdValue);
                if (!IsFunctionalLocationInOlt(details, functionalLocation))
                {
                    continue; // move on to the next WorkOrder
                }

                var allWorkAssignmentsForSite = workPermitAutoAssignmentConfigurationService.QueryBySite(site);
                IntegrateWorkOrderOperations(functionalLocation, allWorkAssignmentsForSite, details);
            }
        }

        private void IntegrateWorkOrderOperations(FunctionalLocation functionalLocation,
            List<AssignmentFlocConfiguration> allWorkAssignmentsForSite, WorkOrderDetails details)
        {
            foreach (var workOrderOperation in details.Operations)
            {
                var handleAsActionItemDefinition = HandleAsActionItemDefinition(workOrderOperation);

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("Processing Work Order <{0}>, Operation <{1}>, SubOperation<{2}> as an {3}",
                        details.WorkOrderNumber, workOrderOperation.OperationNumber, workOrderOperation.Suboperation,
                        handleAsActionItemDefinition ? "Action Item Definition" : "Work Permit");
                }

                try
                {
                    if (handleAsActionItemDefinition)
                    {
                        InsertOrUpdateActionItemDefinition(details, functionalLocation, workOrderOperation);
                    }
                    else
                    {
                        InsertOrUpdateWorkPermit(details, functionalLocation, workOrderOperation,
                            allWorkAssignmentsForSite);
                    }
                }
                catch (WorkOrderToOltObjectBuilderException e)
                {
                    logger.Error(e.Message); // continue on to the next Operation Line.
                }
            }
        }

        public static bool HandleAsActionItemDefinition(Operations workOrderOperation)
        {
            var workCentreIdentifier = workOrderOperation.WorkCenterName.ToUpper();
            return SAPWorkCentre.IsInWorkCentreList(workCentreIdentifier);
        }

        private void InsertOrUpdateWorkPermit(WorkOrderDetails workOrderDetail,
            FunctionalLocation functionalLocation,
            Operations workOrderOperation,
            List<AssignmentFlocConfiguration> allWorkAssignmentsForSite)
        {
            var workPermitBuilder = new WorkPermitBuilder(
                workOrderDetail,
                workOrderOperation,
                userService.GetSAPUser(),
                functionalLocation,
                allWorkAssignmentsForSite,
                timeService,
                siteConfigurationService, craftOrTradeService, functionalLocationService, workAssignmentService);

            var incomingWorkPermit = workPermitBuilder.Build();

            //ayman USPipeline workpermit
            if (incomingWorkPermit.FunctionalLocation.Site.Id == Site.USPipeline_ID
                || incomingWorkPermit.FunctionalLocation.Site.Id == Site.SELC_ID) //mangesh uspipeline to selc
            {
                var existingWorkPermit =
                workPermitService.QueryBySapOperationWorkOrderDetailsForUSPipeline(workOrderDetail.WorkOrderNumber,
                    workOrderOperation.OperationNumber,
                    workOrderOperation.Suboperation);


                if (existingWorkPermit == null)
                {
                    if (logger.IsDebugEnabled)
                    {
                        logger.DebugFormat(
                            "Did not find WorkOrder <{0}>, Operation <{1}>, SubOperation <{2}>  existing in the system already. Doing an Insert of a new WorkPermit.",
                            workOrderDetail.WorkOrderNumber, workOrderOperation.OperationNumber,
                            workOrderOperation.Suboperation);
                    }

                    var sapWorkOrderOperation = new SapWorkOrderOperation(null,
                        workOrderDetail.WorkOrderNumber,
                        workOrderOperation.OperationNumber,
                        workOrderOperation.Suboperation,
                        SapOperationType.WorkPermit);

                    if (logger.IsDebugEnabled)
                    {
                        var description = incomingWorkPermit.Specifics.JobStepDescription;

                        logger.DebugFormat(
                            "Inserting the new WorkPermit for WorkOrderNumber <{0}>, <{1}>, <{2}> using Description:" +
                            Environment.NewLine + "{3}",
                            workOrderDetail.WorkOrderNumber, workOrderOperation.OperationNumber,
                            workOrderOperation.Suboperation, description);
                    }

                    workPermitService.Insert(incomingWorkPermit, sapWorkOrderOperation);
                }
                else
                {
                    logger.DebugFormat(
                        "Found that WorkOrder <{0}>, Operation <{1}>, SubOperation <{2}>  exists in the system already.",
                        workOrderDetail.WorkOrderNumber, workOrderOperation.OperationNumber, workOrderOperation.Suboperation);

                    UpdateWorkPermit(incomingWorkPermit, existingWorkPermit);
                }
            }
            else
            {
                var existingWorkPermit =
                workPermitService.QueryBySapOperationWorkOrderDetails(workOrderDetail.WorkOrderNumber,
                    workOrderOperation.OperationNumber,
                    workOrderOperation.Suboperation);


                if (existingWorkPermit == null)
                {
                    if (logger.IsDebugEnabled)
                    {
                        logger.DebugFormat(
                            "Did not find WorkOrder <{0}>, Operation <{1}>, SubOperation <{2}>  existing in the system already. Doing an Insert of a new WorkPermit.",
                            workOrderDetail.WorkOrderNumber, workOrderOperation.OperationNumber,
                            workOrderOperation.Suboperation);
                    }

                    var sapWorkOrderOperation = new SapWorkOrderOperation(null,
                        workOrderDetail.WorkOrderNumber,
                        workOrderOperation.OperationNumber,
                        workOrderOperation.Suboperation,
                        SapOperationType.WorkPermit);

                    if (logger.IsDebugEnabled)
                    {
                        var description = incomingWorkPermit.Specifics.JobStepDescription;

                        logger.DebugFormat(
                            "Inserting the new WorkPermit for WorkOrderNumber <{0}>, <{1}>, <{2}> using Description:" +
                            Environment.NewLine + "{3}",
                            workOrderDetail.WorkOrderNumber, workOrderOperation.OperationNumber,
                            workOrderOperation.Suboperation, description);
                    }

                    workPermitService.Insert(incomingWorkPermit, sapWorkOrderOperation);
                }
                else
                {
                    logger.DebugFormat(
                        "Found that WorkOrder <{0}>, Operation <{1}>, SubOperation <{2}>  exists in the system already.",
                        workOrderDetail.WorkOrderNumber, workOrderOperation.OperationNumber, workOrderOperation.Suboperation);

                    UpdateWorkPermit(incomingWorkPermit, existingWorkPermit);
                }
            }

        }

        private void UpdateWorkPermit(WorkPermit incomingWorkPermit, WorkPermit existingWorkPermit)
        {
            var isNewWorkPermitDifferent = IsNewWorkPermitDifferent(existingWorkPermit, incomingWorkPermit);

            if (existingWorkPermit.Is(WorkPermitStatus.Pending) && existingWorkPermit.LastModifiedBy.Id == sapUser.Id &&
                isNewWorkPermitDifferent)
            {
                logger.DebugFormat("Work Permit {0} is being updated because info from SAP changed.",
                    existingWorkPermit.IdValue);
                var permitToUpdate = MergeWorkPermitsForUpdate(existingWorkPermit, incomingWorkPermit);
                workPermitService.Update(permitToUpdate);
            }
            else if (!isNewWorkPermitDifferent)
            {
                logger.InfoFormat("Work Permit {0} was not updated because it hasn't changed.", existingWorkPermit.Id);
            }
            else
            {
                logger.InfoFormat(
                    "Work Permit {0} was not updated via SAP because it has already been modified in OLT",
                    existingWorkPermit.Id);
            }
        }

        private bool IsNewWorkPermitDifferent(WorkPermit existingWorkPermit, WorkPermit incomingWorkPermit)
        {
            if (existingWorkPermit.Specifics.WorkOrderNumber.DoesNotEqual(incomingWorkPermit.Specifics.WorkOrderNumber))
                return true;
            if (
                existingWorkPermit.Specifics.WorkOrderDescription.DoesNotEqual(
                    incomingWorkPermit.Specifics.WorkOrderDescription))
                return true;
            if (
                existingWorkPermit.Specifics.JobStepDescription.DoesNotEqual(
                    incomingWorkPermit.Specifics.JobStepDescription))
                return true;
            if (existingWorkPermit.Specifics.StartDateTime.DoesNotEqual(incomingWorkPermit.Specifics.StartDateTime))
                return true;
            if (existingWorkPermit.Specifics.EndDateTime.DoesNotEqual(incomingWorkPermit.Specifics.EndDateTime))
                return true;
            if (
                existingWorkPermit.Specifics.FunctionalLocation.DoesNotEqual(
                    incomingWorkPermit.Specifics.FunctionalLocation))
                return true;

            if (existingWorkPermit.WorkPermitType.DoesNotEqual(incomingWorkPermit.WorkPermitType))
                return true;
            if (existingWorkPermit.Attributes.DoesNotEqual(incomingWorkPermit.Attributes))
                return true;
            if (existingWorkPermit.WorkPermitStatus.DoesNotEqual(incomingWorkPermit.WorkPermitStatus))
                return true;

            if (
                existingWorkPermit.WorkPermitTypeClassification.DoesNotEqual(
                    incomingWorkPermit.WorkPermitTypeClassification))
                return true;

            if (existingWorkPermit.Source.Id.DoesNotEqual(incomingWorkPermit.Source.Id))
                return true;

            if (existingWorkPermit.LastModifiedBy.DoesNotEqual(incomingWorkPermit.LastModifiedBy))
                return true;
            if (existingWorkPermit.CreatedBy.DoesNotEqual(incomingWorkPermit.CreatedBy))
                return true;

            if (
                existingWorkPermit.EquipmentPreparationCondition.DoesNotEqual(
                    incomingWorkPermit.EquipmentPreparationCondition))
                return true;
            if (existingWorkPermit.Specifics.CraftOrTrade.DoesNotEqual(incomingWorkPermit.Specifics.CraftOrTrade))
                return true;

            return false;
        }

        private void UpdateActionItemDefinition(ActionItemDefinition existingDefinition,
            ActionItemDefinition incomingActionItemDefinition)
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

        private bool IsNewActionItemDifferent(ActionItemDefinition existingDefinition,
            ActionItemDefinition incomingActionItemDefinition)
        {
            return existingDefinition.Description.DoesNotEqual(incomingActionItemDefinition.Description) ||
                   existingDefinition.Schedule.StartDate.DoesNotEqual(incomingActionItemDefinition.Schedule.StartDate) ||
                   existingDefinition.Schedule.StartTime.DoesNotEqual(incomingActionItemDefinition.Schedule.StartTime) ||
                   existingDefinition.Schedule.EndTime.DoesNotEqual(incomingActionItemDefinition.Schedule.EndTime);
        }

        private void InsertOrUpdateActionItemDefinition(WorkOrderDetails workOrderDetail,
            FunctionalLocation functionalLocation,
            Operations workOrderOperation)
        {
            if (Equals(functionalLocation.Type, FunctionalLocationType.Level1) ||
                Equals(functionalLocation.Type, FunctionalLocationType.Level2))
            {
                logger.WarnFormat(
                    "Work order {0} is ignored because the functional location, {1}, is at at invalid level.",
                    workOrderDetail.WorkOrderNumber, functionalLocation.FullHierarchy);

                return;
            }
            var builder = new ActionItemDefinitionBuilder(
                workOrderDetail,
                workOrderOperation,
                functionalLocation,
                timeService,
                userService.GetSAPUser(),
                businessCategoryService);

            var incomingActionItemDefinition = builder.BuildForSAPWorkOrder();

            var existingDefinition = actionItemDefinitionService.QueryBySapOperationWorkOrderDetails(
                workOrderDetail.WorkOrderNumber,
                workOrderOperation.OperationNumber,
                workOrderOperation.Suboperation);

            if (existingDefinition == null)
            {
                logger.DebugFormat(
                    "Did not find WorkOrder <{0}>, Operation <{1}>, SubOperation <{2}>  existing in the system already. Doing an Insert of a new ActionItemDefinition.",
                    workOrderDetail.WorkOrderNumber, workOrderOperation.OperationNumber, workOrderOperation.Suboperation);

                var sapWorkOrderOperation = new SapWorkOrderOperation(
                    null,
                    workOrderDetail.WorkOrderNumber,
                    workOrderOperation.OperationNumber,
                    workOrderOperation.Suboperation,
                    SapOperationType.ActionItemDefinition);

                AutoApproveActionItemDefinition(functionalLocation, incomingActionItemDefinition);

                logger.DebugFormat(
                    "Inserting the new ActionItemDefinition for WorkOrderNumber <{0}>, <{1}>, <{2}> using Description:" +
                    Environment.NewLine + "{3}",
                    workOrderDetail.WorkOrderNumber, workOrderOperation.OperationNumber, workOrderOperation.Suboperation,
                    incomingActionItemDefinition.Description);

                actionItemDefinitionService.Insert(incomingActionItemDefinition, sapWorkOrderOperation);
            }
            else
            {
                logger.DebugFormat(
                    "Found that WorkOrder <{0}>, Operation <{1}>, SubOperation <{2}>  exists in the system already.",
                    workOrderDetail.WorkOrderNumber, workOrderOperation.OperationNumber, workOrderOperation.Suboperation);

                UpdateActionItemDefinition(existingDefinition, incomingActionItemDefinition);
            }
        }

        private void AutoApproveActionItemDefinition(FunctionalLocation functionalLocation,
            ActionItemDefinition incomingActionItemDefinition)
        {
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


        private WorkPermit MergeWorkPermitsForUpdate(WorkPermit existingWorkPermit, WorkPermit incomingWorkPermit)
        {
            var currentTimeAtSite = timeService.GetTime(incomingWorkPermit.FunctionalLocation.Site.TimeZone);

            existingWorkPermit.WorkPermitType = incomingWorkPermit.WorkPermitType;

            if (logger.IsDebugEnabled)
            {
                if (string.Equals(existingWorkPermit.Specifics.JobStepDescription,
                    incomingWorkPermit.Specifics.JobStepDescription))
                {
                    logger.DebugFormat(
                        "Keeping JobStepsDescription for WorkPermit {0} as:" + Environment.NewLine + "{1}",
                        existingWorkPermit.Id, existingWorkPermit.Specifics.JobStepDescription);
                }
                else
                {
                    logger.DebugFormat(
                        "Changing JobStepsDescription for WorkPermit {0} from:" + Environment.NewLine + "{1}" +
                        Environment.NewLine + "" + Environment.NewLine + "To:" + Environment.NewLine + "{2}",
                        existingWorkPermit.Id, existingWorkPermit.Specifics.JobStepDescription,
                        incomingWorkPermit.Specifics.JobStepDescription);
                }
            }


            existingWorkPermit.Specifics = incomingWorkPermit.Specifics;
            existingWorkPermit.Attributes = incomingWorkPermit.Attributes;
            existingWorkPermit.LastModifiedBy = sapUser;
            existingWorkPermit.LastModifiedDate = currentTimeAtSite;

            return existingWorkPermit;
        }

        private ActionItemDefinition MergeActionItemDefinitionsForUpdate(ActionItemDefinition existingDefinition,
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

        private void MergeSchedule(ActionItemDefinition existingDefinition,
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

        private bool IsSiteInOlt(Site site, WorkOrderDetails details)
        {
            if (site == null)
            {
                logger.ErrorFormat("Work Order Adapter Error in {0}. No OLT Site was found for Plant Id: {1}.",
                    details.WorkOrderNumber, details.PlantID);
                return false;
            }
            return true;
        }

        private bool IsFunctionalLocationInOlt(WorkOrderDetails details, FunctionalLocation functionalLocation)
        {
            if (functionalLocation == null)
            {
                logger.ErrorFormat(
                    "Work Order Adapter Error in {0}. No OLT Functional Location was found for SAP FLOC: {1}.",
                    details.WorkOrderNumber, details.FunctionalLocation);
                return false;
            }
            return true;
        }
    }
}