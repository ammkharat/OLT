using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Exceptions;
using Com.Suncor.Olt.Remote.Integration;
using Com.Suncor.Olt.Remote.Utilities;
using Com.Suncor.Olt.Remote.Wcf;
using log4net;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.Services
{
    public abstract class GenericPermitRequestMultiDayImportService<T> where T : BasePermitRequest
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<GenericPermitRequestMultiDayImportService<T>>();

        private readonly WorkOrderImporter workOrderImporter;
        private readonly SAPWorkOrderToPersistableDataConverter workOrderConverter;

        private readonly ITimeService timeService;
        private readonly IWorkOrderImportDataDao importDataDao;
        private readonly IPlantDao plantDao;
        protected readonly IPermitRequestDao<T> permitRequestDao; 

        protected GenericPermitRequestMultiDayImportService(IPermitRequestDao<T> permitRequestDao)
        {
            importDataDao = DaoRegistry.GetDao<IWorkOrderImportDataDao>();
            plantDao = DaoRegistry.GetDao<IPlantDao>();
            this.permitRequestDao = permitRequestDao;

            timeService = new TimeService();

            workOrderImporter = new WorkOrderImporter(new WorkOrderImportSettings());
            workOrderConverter = new SAPWorkOrderToPersistableDataConverter();
        }

        public long GetNewBatchId()
        {
            return importDataDao.GetBatchId();
        }

        public WorkOrderDataImportResult Import(User user, Date importDate, long batchId, Site site)
        {
            try
            {
                List<Plant> plants = plantDao.QueryBySiteId(site.IdValue);

                List<WorkOrderRecordList> records = new List<WorkOrderRecordList>();
                foreach (Plant plant in plants)
                {
                    List<WorkOrderRecordList> workOrderRecordLists = workOrderImporter.ImportWorkOrders(importDate, plant.IdValue, null);
                    records.AddRange(workOrderRecordLists);
                }

                logger.Debug(string.Format("Permit Import: ({0}), {1} work order records were received from SAP.", importDate, records.Count));

                DateTime currentDateTime = timeService.GetTime(site.TimeZone);

                List<WorkOrderImportData> importDataList = workOrderConverter.Convert(records, user, batchId, currentDateTime, importDate);

                logger.Debug(string.Format(
                    "Permit Import: ({0}), {1} raw data records were created from the SAP work orders (but have not yet been processed for insert or update)", importDate,
                    importDataList.Count));

                importDataList.ForEach(importDataDao.Insert);
            }
            catch (WorkOrderSAPImportException sapImportException)
            {
                string message = string.Format(StringResources.PermitRequestImportServerError, sapImportException.HelpDeskErrorCode);
                return new WorkOrderDataImportResult(message);
            }
            catch (Exception e)
            {
                logger.Error(
                    "There was an unhandled exception while importing permit request data. Help desk error code: " + ErrorCodes.WebMethodsPermitRequestImportUnhandledException, e);
                string message = string.Format(StringResources.PermitRequestImportServerError, ErrorCodes.WebMethodsPermitRequestImportUnhandledException);

                return new WorkOrderDataImportResult(message);
            }

            WorkOrderDataImportResult result = new WorkOrderDataImportResult();
            return result;
        }

        protected virtual void SetIsCompleteFlagOnPermitRequestUpdates(List<T> permitRequestList, DateTime dateTimeInSite)
        {
            SetIsCompleteFlagOnPermitRequests(permitRequestList, dateTimeInSite);
        }

        private void SetIsCompleteFlagOnPermitRequests(List<T> permitRequestList, DateTime dateTimeInSite)
        {
            foreach (T request in permitRequestList)
            {
                request.CompletionStatus = request.Validate(dateTimeInSite);
            }
        }

        protected abstract List<T> ConvertWorkOrderDataToPermitRequests(List<WorkOrderImportData> importedDataList, User currentUser, Site site, out List<PermitRequestImportRejection> rejectList);

        protected abstract PersistanceResult<T> CreateCrudOperations(Date @from, Date to, List<T> permitRequests, List<WorkOrderImportData> importedDataList, DateTime dateTimeAtSite, User user);
        protected abstract List<NotifiedEvent> Insert(T permitRequest);
        protected abstract List<NotifiedEvent> Update(T permitRequest);
        protected abstract List<NotifiedEvent> Remove(T permitRequest);

        public PermitRequestPostFinalizeResult FinalizeImport(Date @from, Date to, long batchId, User currentUser, Site site)
        {
            DateTime dateTimeInSite = timeService.GetTime(site.TimeZone);
            List<WorkOrderImportData> importedDataList = importDataDao.QueryByBatchId(batchId);

            // There are duplicates because we import separately for each day, but many work orders span multiple days and will be returned multiple times for SAP.
            importedDataList = WorkOrderImportData.RemoveDuplicates(importedDataList);

            List<PermitRequestImportRejection> rejectList;
            List<T> permitRequests = ConvertWorkOrderDataToPermitRequests(importedDataList, currentUser, site, out rejectList);

            PersistanceResult<T> persistanceResult = CreateCrudOperations(@from, to, permitRequests, importedDataList, dateTimeInSite, currentUser);

            List<T> deletes = persistanceResult.Deletes;
            List<T> updates = persistanceResult.Updates;
            List<T> inserts = persistanceResult.Inserts;

            List<T> deletesThatHaveBeenSubmitted = new List<T>();
            List<T> deletesThatHaveNotBeenSubmitted = new List<T>();

            deletes.Classify(deletesThatHaveBeenSubmitted, deletesThatHaveNotBeenSubmitted, pr => pr.IsSubmitted);

            deletesThatHaveBeenSubmitted.ForEach(request =>
                {
                    request.LastModifiedDateTime = dateTimeInSite;
                    request.LastModifiedBy = currentUser;
                    request.CompletionStatus = PermitRequestCompletionStatus.Incomplete;
                    if (request.LastSubmittedDateTime.HasValue)
                    {
                        request.EndDate = new Date(request.LastSubmittedDateTime.Value);
                    }

                });

            updates.AddRange(deletesThatHaveBeenSubmitted);

            SetIsCompleteFlagOnPermitRequestUpdates(updates, dateTimeInSite);
            SetIsCompleteFlagOnPermitRequests(inserts, dateTimeInSite);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            inserts.ForEach(pr => notifiedEvents.AddRange(Insert(pr)));
            updates.ForEach(pr => notifiedEvents.AddRange(Update(pr)));

            deletesThatHaveNotBeenSubmitted.ForEach(permitRequestToRemove =>
                {
                    permitRequestToRemove.LastModifiedBy = currentUser;
                    permitRequestToRemove.LastModifiedDateTime = dateTimeInSite;
                });

            deletesThatHaveNotBeenSubmitted.ForEach(pr => notifiedEvents.AddRange(Remove(pr)));

            int numberOfInserts = inserts.Count;
            int numberOfUpdates = updates.Count;

            int importCountAfterFilteringOutDupes = GetImportCountToReportToTheUser(importedDataList, persistanceResult);

            logger.Debug(string.Format("Permit Import: ({0}), {1} were imported.", from, importCountAfterFilteringOutDupes));
            logger.Debug(string.Format("Permit Import: ({0}), {1} were inserted.", from, numberOfInserts));
            logger.Debug(string.Format("Permit Import: ({0}), {1} were updated.", from, numberOfUpdates));

            PermitRequestPostFinalizeResult result = new PermitRequestPostFinalizeResult(notifiedEvents, rejectList, importCountAfterFilteringOutDupes);
            return result;
        }

        // This method is a little weird. Montreal wants that import data field and I don't think we should retest since we took a long time to get that right. Lubes wants the post-merge number
        // that were actually persisted. I'm passing both variables in to let the implementer of the method choose what to use.
        protected virtual int GetImportCountToReportToTheUser(List<WorkOrderImportData> importData, PersistanceResult<T> persistanceResult)
        {
            return importData.Count;
        }

        public DateTime? GetLastImportDateTime(Site site)
        {
            return permitRequestDao.QueryLastImportDateTime();
        }
    }

    public class PersistanceResult<T>
    {
        public List<T> Inserts { get; private set; }
        public List<T> Updates { get; private set; }
        public List<T> Deletes { get; private set; }

        public PersistanceResult(List<T> inserts, List<T> updates, List<T> deletes)
        {
            Inserts = inserts;
            Updates = updates;
            Deletes = deletes;
        }
    }
}