using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Utilities;

namespace Com.Suncor.Olt.Remote.Services
{
    public class MontrealPermitRequestMultiDayImportService : GenericPermitRequestMultiDayImportService<PermitRequestMontreal>, IMontrealPermitRequestMultiDayImportService
    {
        private readonly IPermitRequestMontrealService service;

        public MontrealPermitRequestMultiDayImportService()
            : base(DaoRegistry.GetDao<IPermitRequestMontrealDao>())
        {
            service = new PermitRequestMontrealService();
        }

        protected override List<PermitRequestMontreal> ConvertWorkOrderDataToPermitRequests(List<WorkOrderImportData> importedDataList, User currentUser, Site site, out List<PermitRequestImportRejection> rejectList)
        {
            WorkOrderDataToPermitRequestDataConverter<PermitRequestMontreal> item = new MontrealWorkOrderToWorkPermitRequestDataConverter(new TimeService(), DaoRegistry.GetDao<IFunctionalLocationDao>(), DaoRegistry.GetDao<IPermitAttributeDao>(), DaoRegistry.GetDao<ICraftOrTradeDao>());
            return item.ConvertToPermitRequests(importedDataList, currentUser, site, out rejectList);
        }

        protected override PersistanceResult<PermitRequestMontreal> CreateCrudOperations(Date @from, Date to, List<PermitRequestMontreal> permitRequests, List<WorkOrderImportData> importedDataList, DateTime timeAtSite, User user)
        {
            MontrealPermitRequestPersistanceProcessor persistanceProcessor = new MontrealPermitRequestPersistanceProcessor(@from, to, permitRequestDao, permitRequests, importedDataList);
            persistanceProcessor.Process();
            return new PersistanceResult<PermitRequestMontreal>(persistanceProcessor.InsertList, persistanceProcessor.UpdateList, persistanceProcessor.DeleteList);
        }

        protected override List<NotifiedEvent> Insert(PermitRequestMontreal permitRequest)
        {
            return service.Insert(permitRequest);
        }

        protected override List<NotifiedEvent> Update(PermitRequestMontreal permitRequest)
        {
            return service.Update(permitRequest);
        }

        protected override List<NotifiedEvent> Remove(PermitRequestMontreal permitRequest)
        {
            return service.Remove(permitRequest);
        }
    }
}