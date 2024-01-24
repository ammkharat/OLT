using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    public class ActionItemDefinitionBuilder
    {
        private readonly IBusinessCategoryService businessCategoryService;
        private readonly FunctionalLocation functionalLocation;

        private readonly User sapUser;

        private readonly ITimeService timeService;
        private readonly WorkOrderDetails workOrderDetail;
        private readonly Operations workOrderOperation;

        public ActionItemDefinitionBuilder(
            WorkOrderDetails workOrderDetail,
            Operations workOrderOperation,
            FunctionalLocation functionalLocation,
            ITimeService timeService,
            User sapUser,
            IBusinessCategoryService businessCategoryService)
        {
            this.timeService = timeService;
            this.businessCategoryService = businessCategoryService;

            this.workOrderDetail = workOrderDetail;
            this.workOrderOperation = workOrderOperation;
            this.functionalLocation = functionalLocation;

            this.sapUser = sapUser;
        }

        /// <summary>
        ///     Create an action item definition from an existing work order operation
        /// </summary>
        public ActionItemDefinition BuildForSAPWorkOrder()
        {
            var description = BuildWorkOrderDescriptionForActionItemDefinition();

            var site = functionalLocation.Site;

            // TODO: Maybe this should be using suboperation number, not milliseconds.  
            // This combination should be unique unless you are doing an update of an existing operation.
            var currentTimeAtSite = timeService.GetTime(site.TimeZone);
            var name = string.Format("{0}-{1}-{2}", workOrderDetail.WorkOrderNumber, workOrderOperation.OperationNumber,
                currentTimeAtSite.Millisecond);

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

            ISchedule schedule =
                new SingleSchedule(new Date(startDateTime), new Time(startDateTime), new Time(endDateTime), site);

            var flocList = new List<FunctionalLocation> {functionalLocation};

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
                sapUser,
                currentTimeAtSite,
                sapUser,
                currentTimeAtSite,
                flocList,
                new List<TargetDefinitionDTO>(),
                new List<DocumentLink>(),
                OperationalMode.Normal,
                null,
                true, null, null,null,false,false,false,null);    //ayman visibility groups     //ayman custom fields DMND0010030

            return actionItemDefinition;
        }

        public string BuildWorkOrderDescriptionForActionItemDefinition()
        {
            var sb = new StringBuilder();

            sb.Append(StringResources.ActionItemDefinitionWorkOrderDescriptionHeader);
            sb.AppendLine();

            if (workOrderDetail.EquipmentNumber.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionEquipmentNumber,
                    workOrderDetail.EquipmentNumber);
                sb.AppendLine();
            }
            if (workOrderDetail.WorkOrderNumber.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionWorkOrderNumber,
                    workOrderDetail.WorkOrderNumber);
                sb.AppendLine();
            }
            if (workOrderOperation.OperationNumber.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionOperationNumber,
                    workOrderOperation.OperationNumber);
                sb.AppendLine();
            }
            if (workOrderOperation.Suboperation.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionSubOperationNumber,
                    workOrderOperation.Suboperation);
                sb.AppendLine();
            }
            if (workOrderDetail.ShortText.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionShortText,
                    workOrderDetail.ShortText);
                sb.AppendLine();
            }

            if (workOrderOperation.LongText.HasValue())
            {
                sb.AppendFormat(StringResources.ActionItemDefinitionWorkOrderDescriptionLongText,
                    workOrderOperation.LongText);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}