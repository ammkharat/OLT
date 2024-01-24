using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class MontrealWorkOrderToWorkPermitRequestDataConverter : WorkOrderDataToPermitRequestDataConverter<PermitRequestMontreal>
    {
        public MontrealWorkOrderToWorkPermitRequestDataConverter(ITimeService timeService, IFunctionalLocationDao functionalLocationDao, IPermitAttributeDao permitAttributeDao,
                                                                 ICraftOrTradeDao craftOrTradeDao) :
                                                                     base(timeService, functionalLocationDao, permitAttributeDao, craftOrTradeDao)
        {
        }

        protected override PermitRequestMontreal BuildPermitRequest(WorkOrderImportData importData, FunctionalLocation functionalLocation, DateTime? startDateTime, Date endDate, string workOrderNumber,
                                                                string operationNumber, string subOperationNumber, string trade, string workCenterCode, string description, string sapDescription, string company, string supervisor,
                                                                DataSource dataSource, User lastImportedByUser, DateTime? lastImportedDateTime, User lastSubmittedByUser, DateTime? lastSubmittedDateTime,
                                                                User createdBy, DateTime createdDateTime, User lastModifiedBy, DateTime lastModifiedDateTime)
        {
            List<PermitAttribute> attributes = GetAttributes(functionalLocation, importData.WorkPermitAttrib);

            string excavationNumber = string.Empty;
            
            string workOrderOperationWorkPermitType = importData.WorkPermitType;
            workOrderOperationWorkPermitType = workOrderOperationWorkPermitType.Replace(@"\", string.Empty);
            
            WorkPermitMontrealType permitType = WorkOrderWorkPermitMontrealTypeConverter.ToWorkPermitMontrealType(workOrderOperationWorkPermitType);

            List<FunctionalLocation> flocs = functionalLocation == null
                                                 ? new List<FunctionalLocation>()
                                                 : new List<FunctionalLocation> { functionalLocation };

            PermitRequestMontreal request = new PermitRequestMontreal(
                null,
                permitType,
                flocs,
                startDateTime.HasValue ? new Date(startDateTime.Value) : null,
                endDate,
                workOrderNumber,
                operationNumber,
                subOperationNumber,
                trade,
                description,
                sapDescription,
                company,
                supervisor,
                excavationNumber,
                dataSource,
                lastImportedByUser,
                lastImportedDateTime,
                lastSubmittedByUser,
                lastSubmittedDateTime,
                createdBy,
                createdDateTime,
                lastModifiedBy,
                lastModifiedDateTime,
                null,
                null);

            request.Attributes.AddRange(attributes);

            return request;
        }

        protected override List<string> GetMissingImportFieldList(PermitRequestMontreal permitRequest)
        {
            List<string> fieldList = CreateMissingImportFieldListForCommonFields(permitRequest);

            if (permitRequest.WorkPermitType == null)
            {
                fieldList.Add(StringResources.PermitRequestFieldName_WorkPermitType);
            }

            if (permitRequest.Trade == null)
            {
                fieldList.Add(StringResources.PermitRequestFieldName_Trade);
            }

            if (permitRequest.StartDate == null)
            {
                fieldList.Add(StringResources.PermitRequestFieldName_StartDate);
            }

            return fieldList;

        }
    }
}