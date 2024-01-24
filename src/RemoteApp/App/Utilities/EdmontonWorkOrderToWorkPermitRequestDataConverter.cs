using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Integration;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class EdmontonWorkOrderToWorkPermitRequestDataConverter : WorkOrderToWorkPermitRequestDataConverter<PermitRequestEdmonton>
    {
        private readonly IWorkPermitEdmontonGroupDao groupDao;
        private readonly IAreaLabelDao areaLabelDao;

        public EdmontonWorkOrderToWorkPermitRequestDataConverter(ITimeService timeService,
                                                                 IFunctionalLocationDao functionalLocationDao,
                                                                 ICraftOrTradeDao craftOrTradeDao,
                                                                 IWorkPermitEdmontonGroupDao groupDao,
                                                                 IAreaLabelDao areaLabelDao) :
                                                                     base(timeService, functionalLocationDao, craftOrTradeDao)
        {
            this.groupDao = groupDao;
            this.areaLabelDao = areaLabelDao;
        }

        protected override PermitRequestEdmonton BuildPermitRequest(Operations operations, WorkOrderDetails details, FunctionalLocation floc,
                                                                DateTime? startDateTime, Date endDate,
                                                                string workOrderNumber, string operationNumber,
                                                                string subOperationNumber, string trade,
                                                                string description, string sapDescription,
                                                                string company, string supervisor, DataSource dataSource,
                                                                User lastImportedByUser, DateTime? lastImportedDateTime,
                                                                User lastSubmittedByUser,
                                                                DateTime? lastSubmittedDateTime, User createdBy,
                                                                DateTime createdDateTime, User lastModifiedBy,
                                                                DateTime lastModifiedDateTime)
        {
            WorkPermitEdmontonType permitType = WorkOrderWorkPermitEdmontonTypeConverter.ToWorkPermitType(operations.WorkPermitType);

            PermitRequestEdmonton request = new PermitRequestEdmontonSAPImportData(
                -1,
                createdDateTime,
                null,
                endDate,
                description,                
                company,
                createdBy,
                createdDateTime);

            request.AddWorkOrderSource(workOrderNumber, operationNumber, subOperationNumber);
            request.WorkPermitType = permitType;
            request.FunctionalLocation = floc;
            request.Location = floc != null ? floc.Description : null;
            request.Occupation = trade;
            request.SAPWorkCentre = operations.WorkCenterName;

            WorkPermitEdmontonGroup group = details.Priority.IsNullOrEmptyOrWhitespace() ? null : WorkPermitEdmontonGroup.FindByPriority(details.Priority, groupDao.QueryAll());
            request.Group = group;

            AreaLabel areaLabel = details.PlannerGroup.IsNullOrEmptyOrWhitespace() ? null : areaLabelDao.QueryBySiteIdAndPlannerGroup(Site.EDMONTON_ID, details.PlannerGroup);
            request.AreaLabel = areaLabel;

            if (group != null && group.DefaultToDayShiftOnSapImport)
            {
                Time time = WorkPermitEdmonton.PermitDefaultDayStart;
                request.RequestedStartTimeDay = time;
                request.RequestedStartTimeNight = null;

                request.RequestedStartDate = startDateTime.ToDate();
            }
            else if (startDateTime != null)
            {
                Time time = new Time(startDateTime.Value);
                if (WorkPermitEdmonton.IsDayShift(time))
                {
                    request.RequestedStartTimeDay = time;
                }
                else
                {
                    request.RequestedStartTimeNight = time;
                }

                request.RequestedStartDate = new Date(startDateTime.Value);
            }


            string[] attribs = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(operations.WorkPermitAttrib);

            PermitRequestEdmontonAttributes attributes = new PermitRequestEdmontonAttributes(attribs);
            attributes.SetAttributesOnPermitRequest(request);

            request.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = !request.AtLeastOneAttributeInTheWorkersMinimumSafetyRequirementsSectionSectionIsSelected();            

            if (WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK.Equals(request.WorkPermitType) && ! request.Group.Name.ToLower().Contains("turnaround"))
            {
                request.GN59 = true;
            }

            return request;
        }

        protected override string BuildTrade(CraftOrTrade craftOrTrade, string workCenterText, string workCenterCode)
        {
            if (craftOrTrade != null)
            {
                return craftOrTrade.ListDisplayText;
            }

            CraftOrTrade temp = new CraftOrTrade(workCenterText, workCenterCode, Site.EDMONTON_ID);
            return temp.ListDisplayText;
        }

        protected override List<string> GetMissingImportFieldList(BasePermitRequest permitRequest)
        {
            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter((PermitRequestEdmonton) permitRequest), DataSource.SAP);
            validator.Validate();
            return validator.MissingImportFieldList;
        }
    }
}