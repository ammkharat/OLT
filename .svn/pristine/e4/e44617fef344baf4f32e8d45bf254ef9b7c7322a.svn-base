using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.DataAccess.DTO;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WorkPermitMontrealService : IWorkPermitMontrealService
    {
        private readonly IEditHistoryService editHistoryService;
        private readonly ILogService logService;
        private readonly IWorkPermitMontrealDao workPermitMontrealDao;
        private readonly IWorkPermitMontrealDTODao workPermitMontrealDtoDao;
        private readonly IWorkPermitMontrealGroupDao workPermitMontrealGroupDao;

        public WorkPermitMontrealService() : this(new EditHistoryService(), new LogService())
        {
        }

        public WorkPermitMontrealService(IEditHistoryService editHistoryService, ILogService logService)
        {
            workPermitMontrealDtoDao = DaoRegistry.GetDao<IWorkPermitMontrealDTODao>();
            workPermitMontrealDao = DaoRegistry.GetDao<IWorkPermitMontrealDao>();
            workPermitMontrealGroupDao = DaoRegistry.GetDao<IWorkPermitMontrealGroupDao>();
            this.editHistoryService = editHistoryService;
            this.logService = logService;
        }

        public List<NotifiedEvent> Insert(WorkPermitMontreal workPermit)
        {
            return InsertWithUserReadDocumentLinkAssociation(workPermit, false);
        }

        public List<NotifiedEvent> InsertWithUserReadDocumentLinkAssociation(WorkPermitMontreal workPermit,
            bool userReadDocumentLink)
        {
            var workPermitWithAnId = workPermitMontrealDao.Insert(workPermit, null);

            if (userReadDocumentLink)
            {
                InsertUserReadDocumentLinkAssociation(workPermitWithAnId.IdValue,
                    workPermitWithAnId.LastModifiedBy.IdValue);
            }

            return TakeSnapshotAndNotifyEvents(workPermit, workPermitWithAnId);
        }

        public List<NotifiedEvent> InsertWithPermitRequestMontrealAssociation(WorkPermitMontreal workPermitMonreal,
            PermitRequestMontreal permitRequestMontreal)
        {
            var workPermitWithAnId = workPermitMontrealDao.Insert(workPermitMonreal, permitRequestMontreal.Id);
            return TakeSnapshotAndNotifyEvents(workPermitMonreal, workPermitWithAnId);
        }

        public bool DoesPermitRequestMontrealAssociationExist(List<PermitRequestMontrealDTO> submittedRequests,
            Date workPermitStartDate)
        {
            return workPermitMontrealDao.DoesPermitRequestMontrealAssociationExist(submittedRequests,
                workPermitStartDate);
        }

        public List<WorkPermitMontrealDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet)
        {
            return workPermitMontrealDtoDao.QueryByDateRangeAndFlocs(dateRange, flocSet);
        }
        public List<WorkPermitMontrealDTO> QueryByDateRangeAndFlocsTemplate(Range<Date> dateRange, IFlocSet flocSet, string username)
        {
            return workPermitMontrealDtoDao.QueryByDateRangeAndFlocsForTemplate(dateRange, flocSet, username);
        }

        public List<NotifiedEvent> Update(WorkPermitMontreal workPermit)
        {
            return UpdateWithUserReadDocumentLinkAssociation(workPermit, false);
        }

        public List<NotifiedEvent> UpdateWithUserReadDocumentLinkAssociation(WorkPermitMontreal workPermit,
            bool userReadDocumentLink)
        {
            if (workPermit.IsTemplate)
            {
                workPermitMontrealDao.InsertTemplate(workPermit);
            }
            else
            {
                workPermitMontrealDao.Update(workPermit);
                editHistoryService.TakeSnapshot(workPermit);

                if (userReadDocumentLink)
                {
                    InsertUserReadDocumentLinkAssociation(workPermit.IdValue, workPermit.LastModifiedBy.IdValue);
                }
            }

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitMontrealUpdate, workPermit));
            return notifiedEvents;
        }

        public WorkPermitMontreal QueryByIdTemplate(long id, string templateName, string categories)
        {
            return workPermitMontrealDao.QueryByIdTemplate(id, templateName, categories);
        }

        public void InsertUserReadDocumentLinkAssociation(long workPermitId, long userId)
        {
            var userReadDocumentLinkAssociationAlreadyExists =
                workPermitMontrealDao.HasUserReadAtLeastOneDocumentLink(userId, workPermitId);
            if (!userReadDocumentLinkAssociationAlreadyExists)
            {
                workPermitMontrealDao.InsertWorkPermitMontrealUserReadDocumentLinkAssociation(userId, workPermitId);
            }
        }

        public WorkPermitMontreal QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitMontreal permit)
        {
            return workPermitMontrealDao.QueryPreviousDayIssuedPermitForSamePermitRequest(permit);
        }

        public List<NotifiedEvent> UpdateAndInsertLogs(List<WorkPermitMontreal> workPermits,
            Dictionary<long, Log> permitIdToAssociatedLogMap)
        {
            var notifiedEvents = new List<NotifiedEvent>();

            foreach (var permit in workPermits)
            {
                notifiedEvents.AddRange(Update(permit));

                if (permitIdToAssociatedLogMap.ContainsKey(permit.IdValue))
                {
                    var associatedLog = permitIdToAssociatedLogMap[permit.IdValue];
                    var text = BuildAssociatedLogComments(associatedLog, permit);
                    associatedLog.PlainTextComments = text;
                    associatedLog.RtfComments = text;
                    notifiedEvents.AddRange(logService.InsertForWorkPermitMontreal(associatedLog, permit));
                }
            }

            return notifiedEvents;
        }

        public WorkPermitMontreal QueryById(long id)
        {
            return workPermitMontrealDao.QueryById(id);
        }

        public List<NotifiedEvent> Remove(WorkPermitMontreal workPermit)
        {
            workPermitMontrealDao.Remove(workPermit);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitMontrealRemove, workPermit));
            return notifiedEvents;
        }

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public List<NotifiedEvent> RemoveTemplate(WorkPermitMontreal workPermit)
        {
            workPermitMontrealDao.RemoveTemplate(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitMontrealRemove, workPermit));
            return notifiedEvents;
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        public List<NotifiedEvent> UpdateTemplate(WorkPermitMontreal workPermit)
        {
            if (workPermit.IsTemplate)
            {
                workPermitMontrealDao.UpdateTemplate(workPermit);
            }

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitMontrealUpdate, workPermit));
            return notifiedEvents;
        }

        public List<WorkPermitMontrealGroup> QueryAllGroups()
        {
            return workPermitMontrealGroupDao.QueryAll();
        }

        public void SaveWorkPermitGroups(List<WorkPermitMontrealGroup> insertList,
            List<WorkPermitMontrealGroup> updateList, List<WorkPermitMontrealGroup> deleteList)
        {
            foreach (var groupToDelete in deleteList)
            {
                workPermitMontrealGroupDao.Remove(groupToDelete);
            }

            foreach (var groupToUpdate in updateList)
            {
                workPermitMontrealGroupDao.Update(groupToUpdate);
            }

            foreach (var groupToInsert in insertList)
            {
                workPermitMontrealGroupDao.Insert(groupToInsert);
            }
        }

        public bool HasUserReadAtLeastOneDocumentLink(long userId, long workPermitMontrealId)
        {
            return HasUserReadAtLeastOneDocumentLinkInEachPermit(userId, new List<long> {workPermitMontrealId});
        }

        public bool HasUserReadAtLeastOneDocumentLinkInEachPermit(long userId, List<long> workPermitMontrealIds)
        {
            foreach (var workPermitMontrealId in workPermitMontrealIds)
            {
                if (!workPermitMontrealDao.HasUserReadAtLeastOneDocumentLink(userId, workPermitMontrealId))
                {
                    return false;
                }
            }

            return true;
        }

        private List<NotifiedEvent> TakeSnapshotAndNotifyEvents(WorkPermitMontreal workPermit,
            WorkPermitMontreal workPermitWithAnId)
        {
            editHistoryService.TakeSnapshot(workPermit);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitMontrealCreate,
                workPermitWithAnId));
            return notifiedEvents;
        }

        private string BuildAssociatedLogComments(Log log, WorkPermitMontreal permit)
        {
            var builder = new StringBuilder();

            builder.Append(permit.DescriptionForLog());

            if (log.PlainTextComments.HasValue())
            {
                builder.AppendLine(string.Format(
                    StringResources.WorkPermitEdmontonAndLubesAndMontrealCloseCommentForLog, log.PlainTextComments));
            }

            return builder.ToString();
        }
    }
}