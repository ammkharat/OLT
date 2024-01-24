using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.FortHills;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Integration;
using PermitRequestValidator = Com.Suncor.Olt.Common.Domain.Validation.FortHills.PermitRequestValidator;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class FortHillsWorkOrderToWorkPermitRequestDataConverter : WorkOrderToWorkPermitRequestDataConverter<PermitRequestFortHills>
    {
        private readonly IWorkPermitFortHillsGroupDao groupDao;
        private readonly IAreaLabelDao areaLabelDao;

        public FortHillsWorkOrderToWorkPermitRequestDataConverter(ITimeService timeService,
                                                                 IFunctionalLocationDao functionalLocationDao,
                                                                 ICraftOrTradeDao craftOrTradeDao,
                                                                 IWorkPermitFortHillsGroupDao groupDao,
                                                                 IAreaLabelDao areaLabelDao) :
                                                                     base(timeService, functionalLocationDao, craftOrTradeDao)
        {
            this.groupDao = groupDao;
            this.areaLabelDao = areaLabelDao;
        }

        protected override PermitRequestFortHills BuildPermitRequest(Operations operations, WorkOrderDetails details, FunctionalLocation floc,
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
            WorkPermitFortHillsType permitType = WorkOrderWorkPermitFortHillsTypeConverter.ToWorkPermitType(operations.WorkPermitType);

            PermitRequestFortHills request = new PermitRequestFortHillsSAPImportData(
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

            WorkPermitFortHillsGroup group = details.Priority.IsNullOrEmptyOrWhitespace() ? null : WorkPermitFortHillsGroup.FindByPriority(details.Priority, groupDao.QueryAll());
            request.Group = group;

           // AreaLabel areaLabel = details.PlannerGroup.IsNullOrEmptyOrWhitespace() ? null : areaLabelDao.QueryBySiteIdAndPlannerGroup(Site.FORT_HILLS_ID, details.PlannerGroup);
           // request.AreaLabel = areaLabel;

            //if (group != null && group.DefaultToDayShiftOnSapImport)
            //{
            //    Time time = WorkPermitFortHills.PermitDefaultDayStart;
            //    request.RequestedStartTime = time;
            //    request.RequestedEndTime = WorkPermitFortHills.NightShiftStartTime;

            //    request.RequestedStartDate = startDateTime.ToDate();
            //}
            //else 
                if (startDateTime != null)
            {
                Time time = new Time(startDateTime.Value);
                if (WorkPermitFortHills.IsDayShift(time))
                {
                    request.RequestedEndTime = WorkPermitFortHills.NightShiftStartTime;
                    request.RequestedStartTime = time;
                  //  request.RequestedStartTime = WorkPermitFortHills.DayShiftStartTime; //here we can make start time as startof shift day or night for sap imported data
                }
                else
                {
                    request.RequestedEndTime = WorkPermitFortHills.DayShiftStartTime;
                    request.RequestedStartTime = time;
                    //  request.RequestedStartTime = WorkPermitFortHills.NightShiftStartTime; //here we can make start time as startof shift day or night for sap imported data
                }

                request.RequestedStartDate = new Date(startDateTime.Value);
            }

            // below lines will be used to add extra fields imported from sap 
              string[] attribs = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(operations.WorkPermitAttrib);
            PermitRequestFortHillsAttributes attributes = new PermitRequestFortHillsAttributes(attribs);
            attributes.SetAttributesOnPermitRequest(request);
            return request;
        }

        protected override string BuildTrade(CraftOrTrade craftOrTrade, string workCenterText, string workCenterCode)
        {
            if (craftOrTrade != null)
            {
                return craftOrTrade.ListDisplayText;
            }

            CraftOrTrade temp = new CraftOrTrade(workCenterText, workCenterCode, Site.FORT_HILLS_ID);
            return temp.ListDisplayText;
        }

        protected override List<string> GetMissingImportFieldList(BasePermitRequest permitRequest)
        {
            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestFortHillsValidationDomainAdapter((PermitRequestFortHills) permitRequest), DataSource.SAP);
            validator.Validate();
            return validator.MissingImportFieldList;
        }
    }
}