using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;

namespace Com.Suncor.Olt.Remote.Utilities
{
    // IMPORTTODO: I think this can be deleted
    public class LubesWorkOrderToWorkPermitRequestDataConverter : WorkOrderToWorkPermitRequestDataConverter
    {
        private readonly IWorkPermitLubesGroupDao groupDao;

        public LubesWorkOrderToWorkPermitRequestDataConverter(ITimeService timeService,
                                                                 IFunctionalLocationDao functionalLocationDao,
                                                                 IPermitAttributeDao permitAttributeDao,
                                                                 ICraftOrTradeDao craftOrTradeDao,
                                                                 IWorkPermitLubesGroupDao groupDao) :
                                                                     base(
                                                                     timeService, functionalLocationDao,
                                                                     permitAttributeDao, craftOrTradeDao)
        {
            this.groupDao = groupDao;
        }

        protected override BasePermitRequest BuildPermitRequest(Operations operations, WorkOrderDetails details, FunctionalLocation floc,
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
           // WorkPermitLubesType permitType = WorkPermitLubesType.HOT_WORK; // IMPORTTODO // WorkOrderWorkPermitLubesTypeConverter.ToWorkPermitType(operations.WorkPermitType);

           // //PermitRequestLubes request = new PermitRequestLubesSAPImportData(
           // //    -1,
           // //    createdDateTime,
           // //    null,
           // //    endDate,
           // //    description,                
           // //    company,
           // //    createdBy,
           // //    createdDateTime,
           // //    null); // IMPORTTODO: what to do about this createdbyrole business?

            
            
           // request.WorkPermitType = permitType;
           // request.FunctionalLocation = floc;
           // request.Location = floc != null ? floc.Description : null;
           // request.Trade = trade;
           // //request.SAPWorkCentre = operations.WorkCenterName; IMPORTTODO - is there an equivalent to SAPWorkCentre in Lubes?

           // WorkPermitLubesGroup group = null; // details.Priority.IsNullOrEmptyOrWhitespace() ? null : WorkPermitLubesGroup.FindByPriority(details.Priority, groupDao.QueryAll()); IMPORTTODO
           // request.RequestedByGroup = group;

           // //if (group != null && group.DefaultToDayShiftOnSapImport)
           // //{
           // //    Time time = PermitRequestEdmonton.DefaultDayStart;
           // //    request.RequestedStartTimeDay = time;
           // //    request.RequestedStartTimeNight = null;

           // //    request.RequestedStartDate = startDateTime.ToDate();
           // //}
           // //else if (startDateTime != null)
           // //{
           //     Time time = new Time(startDateTime.Value);
           //     if (WorkPermitEdmonton.IsDayShift(time))
           //     {
           //         request.RequestedStartTimeDay = time;
           //     }
           //     else
           //     {
           //         request.RequestedStartTimeNight = time;
           //     }

           //     request.RequestedStartDate = new Date(startDateTime.Value);
           //// }


           // string[] attribs =
           //     WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(operations.WorkPermitAttrib);

           // // IMPORTTODO
           // //PermitRequestLubesAttributes attributes = new PermitRequestEdmontonAttributes(attribs);
           // //attributes.SetAttributesOnPermitRequest(request);

           ////request.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = !request.AtLeastOneAttributeInTheWorkersMinimumSafetyRequirementsSectionSectionIsSelected();   IMPORTTODO          

           // // IMPORTTODO
           // //if (WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK.Equals(request.WorkPermitType))
           // //{
           // //    request.GN59 = true;
           // //}

           // // IMPORTTODO ALL THIS STUFF!!!!
            
           // return request;

            return null;
        }

        protected override List<string> GetMissingImportFieldList(BasePermitRequest permitRequest)
        {
            return null;
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
    }
}
    