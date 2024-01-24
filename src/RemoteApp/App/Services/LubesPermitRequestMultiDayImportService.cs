using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Utilities;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class LubesPermitRequestMultiDayImportService : GenericPermitRequestMultiDayImportService<PermitRequestLubes>, ILubesPermitRequestMultiDayImportService
    {
        private readonly IPermitRequestLubesService service;

        public LubesPermitRequestMultiDayImportService() : base(DaoRegistry.GetDao<IPermitRequestLubesDao>())
        {
            service = new PermitRequestLubesService();
        }

        protected override List<PermitRequestLubes> ConvertWorkOrderDataToPermitRequests(List<WorkOrderImportData> importedDataList, User currentUser, Site site, out List<PermitRequestImportRejection> rejectList)
        {
            WorkOrderDataToPermitRequestDataConverter<PermitRequestLubes> item = 
                new WorkOrderDataToPermitRequestLubesDataConverter(new TimeService(), DaoRegistry.GetDao<IFunctionalLocationDao>(), DaoRegistry.GetDao<IPermitAttributeDao>(), 
                    DaoRegistry.GetDao<ICraftOrTradeDao>(), DaoRegistry.GetDao<IWorkPermitLubesGroupDao>(), site);
            return item.ConvertToPermitRequests(importedDataList, currentUser, site, out rejectList);
        }

        protected override PersistanceResult<PermitRequestLubes> CreateCrudOperations(Date @from, Date to, List<PermitRequestLubes> permitRequests, List<WorkOrderImportData> importedDataList, DateTime dateTimeAtSite, User user)
        {            
            List<PermitRequestLubes> allExisting = permitRequestDao.QueryByDateRangeAndDataSource(@from, to, DataSource.SAP);
            // Filter out the expired permit requests 
            allExisting = allExisting.FindAll(pr => !PermitRequestCompletionStatus.Expired.Equals(pr.CompletionStatus));

            LubesMergingPermitRequestPersistenceProcessor persistenceProcessor = 
                new LubesMergingPermitRequestPersistenceProcessor(allExisting.ConvertAll(t => (IMergeablePermitRequest) t), permitRequests.ConvertAll(t => (ISAPImportData) t), importedDataList, dateTimeAtSite, user);
            persistenceProcessor.Process();

            List<PermitRequestLubes> insertList = persistenceProcessor.InsertList.ConvertAll(i => (PermitRequestLubes) i);
            List<PermitRequestLubes> updateList = persistenceProcessor.UpdateList.ConvertAll(i => (PermitRequestLubes) i);
            List<PermitRequestLubes> deleteList = persistenceProcessor.DeleteList.ConvertAll(i => (PermitRequestLubes) i);

            return new PersistanceResult<PermitRequestLubes>(insertList, updateList, deleteList);
        }

        protected override List<NotifiedEvent> Insert(PermitRequestLubes permitRequest)
        {
            return service.Insert(permitRequest);
        }

        protected override List<NotifiedEvent> Update(PermitRequestLubes permitRequest)
        {
            return service.Update(permitRequest);
        }

        protected override List<NotifiedEvent> Remove(PermitRequestLubes permitRequest)
        {
            return service.Remove(permitRequest);
        }

        protected override void SetIsCompleteFlagOnPermitRequestUpdates(List<PermitRequestLubes> permitRequestList, DateTime dateTimeInSite)
        {
            foreach (PermitRequestLubes permitRequest in permitRequestList)
            {
                if (!PermitRequestCompletionStatus.Expired.Equals(permitRequest.CompletionStatus))
                {
                    permitRequest.CompletionStatus = permitRequest.Validate(dateTimeInSite);
                }
            }            
        }

        protected override int GetImportCountToReportToTheUser(List<WorkOrderImportData> importData, PersistanceResult<PermitRequestLubes> persistanceResult)
        {
            // don't include Updates where we set an existing permit to expired.
            return persistanceResult.Inserts.Count + persistanceResult.Updates.FindAll(update => update.CompletionStatus != PermitRequestCompletionStatus.Expired).Count;
        }
    }
}