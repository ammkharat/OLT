using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Utilities
{    
    public interface IPermitRequestPersistanceProcessor<T> where T : BasePermitRequest
    {
        void Process();
        List<T> DeleteList { get; }
        List<T> InsertList { get; }
        List<T> UpdateList { get; }
    }

    public abstract class AbstractPermitRequestPersistanceProcessor<T> : IPermitRequestPersistanceProcessor<T> where T : BasePermitRequest
    {
        protected readonly Date importFromDate;
        protected readonly Date importToDate;
        protected readonly IPermitRequestDao<T> permitRequestDao;
        private readonly List<T> incomingPermitRequests;
        private readonly List<WorkOrderImportData> completeIncomingWorkOrderList;

        private readonly List<T> updateList = new List<T>();
        private readonly List<T> insertList = new List<T>();
        protected readonly List<T> deleteList = new List<T>();

        protected AbstractPermitRequestPersistanceProcessor(Date importFromDate, Date importToDate, IPermitRequestDao<T> permitRequestDao, List<T> incomingPermitRequests, List<WorkOrderImportData> completeIncomingWorkOrderList)
        {
            this.importFromDate = importFromDate;
            this.importToDate = importToDate;
            this.permitRequestDao = permitRequestDao;
            this.incomingPermitRequests = incomingPermitRequests;
            this.completeIncomingWorkOrderList = completeIncomingWorkOrderList;
        }

        public void Process()
        {
            updateList.Clear();
            insertList.Clear();            

            foreach (T incomingPermitRequest in incomingPermitRequests)
            {
                ProcessPermitRequest(incomingPermitRequest);
            }

            PerformPostProcessStep();
        }

        protected virtual void PerformPostProcessStep()
        {            
            // Only implemented for now because Edmonton doesn't quite live up to this persistenceprocessor
        }

        protected abstract List<T> QueryExistingPermitRequests(T permitRequest);

        private void ProcessPermitRequest(T permitRequest)
        {
            List<T> existingRequests = QueryExistingPermitRequests(permitRequest);
                               
            if (existingRequests.Count > 0)
            {
                foreach (T existingRequest in existingRequests)
                {
                    if (existingRequest.IsModified)
                    {
                        existingRequest.UpdateIfModifiedFrom(permitRequest);
                    }
                    else
                    {
                        existingRequest.UpdateFrom(permitRequest);                        
                    }

                    updateList.Add(existingRequest);
                }
            }
            else
            {
                insertList.Add(permitRequest);
            }            
        }

        public List<T> BuildImportRemovalList(List<T> existingWorkOrderDataInOlt)
        {
            List<T> removalList = new List<T>();

            foreach (T item in existingWorkOrderDataInOlt)
            {
                IHasPermitKey match = completeIncomingWorkOrderList.Find(ipr => item.MatchesByPermitKey(ipr));

                if (match == null)
                {
                    removalList.Add(item);
                }
            }

            return removalList;
        }

        public List<T> UpdateList
        {
            get { return new List<T>(updateList); }
        }

        public List<T> InsertList
        {
            get { return new List<T>(insertList); }
        }

        public List<T> DeleteList
        {
            get { return new List<T>(deleteList); }
        }

    }
}