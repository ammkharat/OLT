using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    public class WorkPermitBuilder
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (WorkPermitBuilder));

        private readonly List<AssignmentFlocConfiguration> allWorkAssignmentsForSite;

        private readonly ICraftOrTradeService craftOrTradeService;
        private readonly User createdByUser;
        private readonly FunctionalLocation functionalLocation;
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly ISiteConfigurationService siteConfigurationService;
        private readonly ITimeService timeService;
        private readonly IWorkAssignmentService workAssignmentService;
        private readonly WorkOrderDetails workOrderDetails;
        private readonly Operations workOrderOperation;

        public WorkPermitBuilder(WorkOrderDetails workOrderDetails, Operations workOrderOperation, User user,
            FunctionalLocation functionalLocation, List<AssignmentFlocConfiguration> allWorkAssignmentsForSite,
            ITimeService timeService, ISiteConfigurationService siteConfigurationService,
            ICraftOrTradeService craftOrTradeService, IFunctionalLocationService functionalLocationService,
            IWorkAssignmentService workAssignmentService)
        {
            this.workOrderDetails = workOrderDetails;
            this.workOrderOperation = workOrderOperation;
            this.functionalLocation = functionalLocation;
            this.allWorkAssignmentsForSite = allWorkAssignmentsForSite;

            this.timeService = timeService;
            this.siteConfigurationService = siteConfigurationService;
            this.craftOrTradeService = craftOrTradeService;
            this.functionalLocationService = functionalLocationService;
            this.workAssignmentService = workAssignmentService;

            createdByUser = user;
        }

        public WorkPermit Build()
        {
            var site = functionalLocation.Site;
            var currentTimeAtSite = timeService.GetTime(site.TimeZone);
            var siteConfiguration = siteConfigurationService.QueryBySiteId(site.IdValue);
            var dateTimeHandler = SiteSpecificHandlerFactory.GetDateTimeHandler(site);

            var workPermit = new WorkPermit(site);
            workPermit.InitializeWithSensibleDefaults(new UserSpecifiedCraftOrTrade(string.Empty),
                createdByUser, true, currentTimeAtSite, siteConfiguration, null,
                dateTimeHandler);

            var workPermitType = WorkOrderWorkPermitType.ToWorkPermitType(workOrderOperation.WorkPermitType);
            if (workPermitType == default(WorkPermitType))
            {
                throw new WorkOrderToOltObjectBuilderException(
                    string.Format("Could not convert Work Permit Type {0} to a known OLT Permit type.",
                        workOrderOperation.WorkPermitType));
            }

            workPermit.WorkPermitType = workPermitType;

            PopulateWorkPermitSpecifics(workPermit);
            workPermit.Attributes = WorkOrderWorkPermitAttribute.FromString(workOrderOperation.WorkPermitAttrib);

            //set the other properties
            workPermit.SetWorkPermitStatus(WorkPermitStatus.Pending);
            workPermit.WorkPermitTypeClassification = WorkPermitTypeClassification.SPECIFIC;
            workPermit.Source = DataSource.SAP;
            workPermit.EquipmentPreparationCondition.IsOutOfService = true;
            workPermit.LastModifiedBy = createdByUser;
            workPermit.LastModifiedDate = currentTimeAtSite;
            workPermit.SetCreatedBy(createdByUser, true);

            var workAssignmentDeterminator = new WorkPermitWorkAssignmentDeterminator(allWorkAssignmentsForSite,
                functionalLocationService);

            AssignmentFlocConfiguration assignmentConfiguration = null;

            try
            {
                assignmentConfiguration = workAssignmentDeterminator.GetWorkAssignment(functionalLocation);
            }
            catch (Exception e)
            {
                logger.Error(
                    "There was a fatal problem trying to determine the work assignment for a work permit with FLOC: " +
                    functionalLocation, e);
            }

            if (assignmentConfiguration != null)
            {
                workPermit.Specifics.WorkAssignment =
                    workAssignmentService.QueryById(assignmentConfiguration.WorkAssignmentId);
            }

            return workPermit;
        }

        private void PopulateWorkPermitSpecifics(WorkPermit workPermit)
        {
            var specifics = workPermit.Specifics;

            //set the start and end datetime
            DateTime startDateTime;
            var parsed = DateTimeExtensions.TryParse(workOrderOperation.EarliestStartDate,
                workOrderOperation.EarliestStartTime, out startDateTime);
            if (!parsed)
            {
                throw new WorkOrderToOltObjectBuilderException(
                    string.Format(
                        "Could not parse EarliestStartDate, {0}, and/or EarliestStartTime, {1}, into a Valid DateTime.",
                        workOrderOperation.EarliestStartDate, workOrderOperation.EarliestStartTime));
            }
            DateTime endDateTime;
            parsed = DateTimeExtensions.TryParse(workOrderOperation.EarliestFinishDate,
                workOrderOperation.EarliestFinishTime, out endDateTime);
            if (!parsed)
            {
                throw new WorkOrderToOltObjectBuilderException(
                    string.Format(
                        "Could not parse EarliestFinishDate, {0}, and/or EarliestFinishTime, {1}, into a Valid DateTime.",
                        workOrderOperation.EarliestFinishDate, workOrderOperation.EarliestFinishTime));
            }

            specifics.StartDateTime = startDateTime;
            specifics.EndDateTime = endDateTime;
            specifics.StartAndOrEndTimesFinalized = false;

            specifics.CraftOrTrade = FindOrCreateCraftOrTrade(workOrderOperation.WorkCenterName,
                workOrderOperation.WorkCenterText);

            specifics.WorkOrderNumber = workOrderDetails.WorkOrderNumber;
            specifics.WorkOrderDescription = BuildWorkOrderDescriptionForWorkPermit();
            specifics.JobStepDescription = workOrderOperation.LongText;

            specifics.FunctionalLocation = functionalLocation;
        }

        private ICraftOrTrade FindOrCreateCraftOrTrade(string workCenterCode, string workCenterText)
        {
            var systemCraftOrTrade = craftOrTradeService.QueryByWorkCenterOrName(workCenterCode, workCenterText,
                functionalLocation.Site.IdValue);

            if (systemCraftOrTrade == null) //cant find it
            {
                return new UserSpecifiedCraftOrTrade(workCenterText);
            }
            return systemCraftOrTrade;
        }

        public string BuildWorkOrderDescriptionForWorkPermit()
        {
            if (functionalLocation.Site.IdValue == Site.DENVER_ID)
            {
                return BuildWorkOrderDescriptionForWorkPermitForDenver();
            }
            if (functionalLocation.Site.IdValue == Site.USPipeline_ID 
                || functionalLocation.Site.IdValue == Site.SELC_ID)   //mangesh uspipeline to selc
            {
                return BuildWorkOrderDescriptionForWorkPermitForUSPipeline();             //ayman USPipeline workpermit
            }
            return BuildShortWorkOrderDescriptionForWorkPermit();
        }

        private string BuildShortWorkOrderDescriptionForWorkPermit()
        {
            var sb = new StringBuilder();

            if (workOrderDetails.ShortText.HasValue())
            {
                sb.AppendFormat(workOrderDetails.ShortText);
                sb.AppendLine();
            }
            if (workOrderDetails.EquipmentNumber.HasValue())
            {
                const string formatString = "{0}: {1}";
                sb.AppendFormat(formatString, StringResources.WorkPermitWorkOrderShortDescription_EquipmentNumber,
                    workOrderDetails.EquipmentNumber);
                sb.AppendLine();
            }
            if (workOrderOperation.OperationNumber.HasValue() || workOrderOperation.Suboperation.HasValue())
            {
                const string formatString = "{0}: {1}{2}{3}";

                var separator = "";
                if (workOrderOperation.OperationNumber.HasValue() && workOrderOperation.Suboperation.HasValue())
                {
                    separator = " / ";
                }
                sb.AppendFormat(formatString,
                    StringResources.WorkPermitWorkOrderShortDescription_OperationNumber,
                    workOrderOperation.OperationNumber,
                    separator,
                    workOrderOperation.Suboperation);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        //ayman USPipeline workpermit
        private string BuildWorkOrderDescriptionForWorkPermitForUSPipeline()
        {
            var sb = new StringBuilder();

            const string format = "{0}: {1}";

            sb.Append(StringResources.WorkPermitUSPipelineSAPDescription_Title);
            sb.AppendLine();

            if (workOrderDetails.EquipmentNumber.HasValue())
            {
                sb.AppendFormat(format, StringResources.WorkPermitUSPipelineSAPDescription_EquipmentNumber,
                    workOrderDetails.EquipmentNumber);
                sb.AppendLine();
            }
            if (workOrderOperation.OperationNumber.HasValue())
            {
                sb.AppendFormat(format, StringResources.WorkPermitUSPipelineSAPDescription_OperationNumber,
                    workOrderOperation.OperationNumber);
                sb.AppendLine();
            }
            if (workOrderOperation.Suboperation.HasValue())
            {
                sb.AppendFormat(format, StringResources.WorkPermitUSPipelineSAPDescription_SubOperationNumber,
                    workOrderOperation.Suboperation);
                sb.AppendLine();
            }
            if (workOrderDetails.ShortText.HasValue())
            {
                sb.AppendFormat(format, StringResources.WorkPermitUSPipelineSAPDescription_ShortTextDescription,
                    workOrderDetails.ShortText);
                sb.AppendLine();
            }

            return sb.ToString();
        }



        private string BuildWorkOrderDescriptionForWorkPermitForDenver()
        {
            var sb = new StringBuilder();

            const string format = "{0}: {1}";

            sb.Append(StringResources.WorkPermitDenverSAPDescription_Title);
            sb.AppendLine();

            if (workOrderDetails.EquipmentNumber.HasValue())
            {
                sb.AppendFormat(format, StringResources.WorkPermitDenverSAPDescription_EquipmentNumber,
                    workOrderDetails.EquipmentNumber);
                sb.AppendLine();
            }
            if (workOrderOperation.OperationNumber.HasValue())
            {
                sb.AppendFormat(format, StringResources.WorkPermitDenverSAPDescription_OperationNumber,
                    workOrderOperation.OperationNumber);
                sb.AppendLine();
            }
            if (workOrderOperation.Suboperation.HasValue())
            {
                sb.AppendFormat(format, StringResources.WorkPermitDenverSAPDescription_SubOperationNumber,
                    workOrderOperation.Suboperation);
                sb.AppendLine();
            }
            if (workOrderDetails.ShortText.HasValue())
            {
                sb.AppendFormat(format, StringResources.WorkPermitDenverSAPDescription_ShortTextDescription,
                    workOrderDetails.ShortText);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}