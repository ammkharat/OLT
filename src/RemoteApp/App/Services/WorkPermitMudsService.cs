using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
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
    public class WorkPermitMudsService : IWorkPermitMudsService
    {
        private readonly IEditHistoryService editHistoryService;
        private readonly ILogService logService;
        private readonly IWorkPermitMudsDao workPermitMudsDao;
        private readonly IWorkPermitMudsDTODao workPermitMudsDtoDao;
        private readonly IWorkPermitMudsGroupDao workPermitMudsGroupDao;
        private readonly IConfinedSpaceMudsDao confinedSpaceDao;
        //Added by ppanigrahi
        private readonly ISiteDao siteDao;
        private readonly ITimeService timeService;
        //private readonly IWorkPermitFortHillsService wpservice;
        private readonly IBusinessCategoryService businessCategoryService;
        private readonly IActionItemDefinitionService actionItemDefinationService;
        private readonly IPermitRequestMudsService wpservice;
        private readonly IPermitRequestMudsDao permitRequestDao;
        public WorkPermitMudsService() : this(new EditHistoryService(), new LogService(),new ActionItemDefinitionService())
        {
        }

        public WorkPermitMudsService(IEditHistoryService editHistoryService, ILogService logService)
        {
            workPermitMudsDtoDao = DaoRegistry.GetDao<IWorkPermitMudsDTODao>();
            workPermitMudsDao = DaoRegistry.GetDao<IWorkPermitMudsDao>();
            workPermitMudsGroupDao = DaoRegistry.GetDao<IWorkPermitMudsGroupDao>();
            this.editHistoryService = editHistoryService;
            this.logService = logService;
            confinedSpaceDao = DaoRegistry.GetDao<IConfinedSpaceMudsDao>();
            //siteDao = DaoRegistry.GetDao<ISiteDao>();
            //timeService = new TimeService();
            //actionItemDefinationService=new ActionItemDefinitionService();
            // wpservice = new PermitRequestMudsService();
            // permitRequestDao = DaoRegistry.GetDao<IPermitRequestMudsDao>();
            //businessCategoryService=new BusinessCategoryService();
        }
        //Added by ppanigrahi
        public WorkPermitMudsService(IEditHistoryService editHistoryService, ILogService logService, IActionItemDefinitionService actionItemDefinationService)
        {
            workPermitMudsDtoDao = DaoRegistry.GetDao<IWorkPermitMudsDTODao>();
            workPermitMudsDao = DaoRegistry.GetDao<IWorkPermitMudsDao>();
            workPermitMudsGroupDao = DaoRegistry.GetDao<IWorkPermitMudsGroupDao>();
            this.editHistoryService = editHistoryService;
            this.logService = logService;
            confinedSpaceDao = DaoRegistry.GetDao<IConfinedSpaceMudsDao>();
            siteDao = DaoRegistry.GetDao<ISiteDao>();
            timeService = new TimeService();
            this.actionItemDefinationService = actionItemDefinationService;
            //actionItemDefinationService=new ActionItemDefinitionService();
           //  wpservice = new PermitRequestMudsService();
             permitRequestDao = DaoRegistry.GetDao<IPermitRequestMudsDao>();
             businessCategoryService=new BusinessCategoryService();
        }
        public List<NotifiedEvent> Insert(WorkPermitMuds workPermit)
        {
            return InsertWithUserReadDocumentLinkAssociation(workPermit, false);
        }

        public List<NotifiedEvent> InsertWithUserReadDocumentLinkAssociation(WorkPermitMuds workPermit,
            bool userReadDocumentLink)
        {
            var workPermitWithAnId = workPermitMudsDao.Insert(workPermit, null);

            if (userReadDocumentLink)
            {
                InsertUserReadDocumentLinkAssociation(workPermitWithAnId.IdValue,
                    workPermitWithAnId.LastModifiedBy.IdValue);
            }

            return TakeSnapshotAndNotifyEvents(workPermit, workPermitWithAnId);
        }

        public List<NotifiedEvent> InsertWithPermitRequestMudsAssociation(WorkPermitMuds workPermitMonreal,
            PermitRequestMuds permitRequestMuds)
        {
            var workPermitWithAnId = workPermitMudsDao.Insert(workPermitMonreal, permitRequestMuds.Id);
            return TakeSnapshotAndNotifyEvents(workPermitMonreal, workPermitWithAnId);
        }

        public bool DoesPermitRequestMudsAssociationExist(List<PermitRequestMudsDTO> submittedRequests,
            Date workPermitStartDate)
        {
            return workPermitMudsDao.DoesPermitRequestMudsAssociationExist(submittedRequests,
                workPermitStartDate);
        }

        public List<WorkPermitMudsDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet)
        {
            return workPermitMudsDtoDao.QueryByDateRangeAndFlocs(dateRange, flocSet);
        }
        public List<WorkPermitMudsTemplateDTO> QueryByDateRangeAndFlocsTemplate(Range<Date> dateRange, IFlocSet flocSet, string username)
        {
            return workPermitMudsDtoDao.QueryByDateRangeAndFlocsTemplate(dateRange, flocSet, username);
        }
        

        public List<NotifiedEvent> Update(WorkPermitMuds workPermit)
        {
            return UpdateWithUserReadDocumentLinkAssociation(workPermit, false);
        }

        public List<NotifiedEvent> InsertTemplate(WorkPermitMuds workPermit)
        {
            if (workPermit.IsTemplate)
            {
                workPermitMudsDao.InsertTemplate(workPermit);
            }

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitMudsTemplateCreate, workPermit));
            return notifiedEvents;

        }

        public List<NotifiedEvent> UpdateWithUserReadDocumentLinkAssociation(WorkPermitMuds workPermit,
            bool userReadDocumentLink)
        {
            if (workPermit.IsTemplate)
            {
                workPermitMudsDao.InsertTemplate(workPermit);
            }
            else
            {
                workPermitMudsDao.Update(workPermit);
                editHistoryService.TakeSnapshot(workPermit);

                if (userReadDocumentLink)
                {
                    InsertUserReadDocumentLinkAssociation(workPermit.IdValue, workPermit.LastModifiedBy.IdValue);
                }
            }
          

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitMudsUpdate, workPermit));
            return notifiedEvents;
        }

        public void InsertUserReadDocumentLinkAssociation(long workPermitId, long userId)
        {
            var userReadDocumentLinkAssociationAlreadyExists =
                workPermitMudsDao.HasUserReadAtLeastOneDocumentLink(userId, workPermitId);
            if (!userReadDocumentLinkAssociationAlreadyExists)
            {
                workPermitMudsDao.InsertWorkPermitMudsUserReadDocumentLinkAssociation(userId, workPermitId);
            }
        }

        public WorkPermitMuds QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitMuds permit)
        {
            return workPermitMudsDao.QueryPreviousDayIssuedPermitForSamePermitRequest(permit);
        }

        public List<NotifiedEvent> UpdateAndInsertLogs(List<WorkPermitMuds> workPermits,
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
                    notifiedEvents.AddRange(logService.InsertForWorkPermitMuds(associatedLog, permit));
                }
             //   PermitRequestMuds permitrequest = permitRequestDao.QueryById(permit.IdValue);
                if (permit.ActionItemCheckBoxclick && permit.WorkPermitType.IdValue == 1)
                {
                    GetAiObjectToInsert(permit, notifiedEvents);
                }

            }
            
            return notifiedEvents;
        }

        protected void GetAiObjectToInsert(WorkPermitMuds workPermit, List<NotifiedEvent> notifiedEvents)
        {
            Site currentSite = siteDao.QueryById(Site.MontrealSulphur_ID);
            var currentTimeAtSite = timeService.GetTime(currentSite.TimeZone);
            var name = string.Format("V�rification d�incendie pour permis  - {0}", workPermit.PermitNumber);
            var aIDescription =
               string.Format(
                   "Faire la v�rification d�incendie 60 minutes apr�s la fin des travaux � chaud");
            List<string> Sendmailto = new List<string>(0);
            List<FunctionalLocation> floc = new List<FunctionalLocation>();
            //FunctionalLocation floc = functionalLocationDao.QueryByFullHierarchy(importData.FunctionalLocation, site.IdValue);
            // List<DocumentLink> docLink = new List<DocumentLink>(0);
            var businessCategory = businessCategoryService.GetDefaultSAPWorkOrderCategory(currentSite.IdValue);
            WorkAssignment workAssignment = null;
            Date startDate= new Date(workPermit.StartDateTime);
            Time startTime = new Time(workPermit.StartDateTime).AddHours(1);
            Time endTime = new Time(workPermit.EndDateTime).AddHours(1);
            ISchedule schedule = new SingleSchedule(startDate, startTime, endTime, currentSite);
            floc = workPermit.FunctionalLocations;
            var actionItemDefinition =
               new ActionItemDefinition(name, businessCategory, ActionItemDefinitionStatus.Approved, schedule, aIDescription.TrimOrEmpty(), DataSource.PERMIT, false,true, true, true,workPermit.LastModifiedBy, workPermit.LastModifiedDateTime, workPermit.CreatedBy, workPermit.CreatedDateTime, floc, new List<Common.DTO.TargetDefinitionDTO>(), new List<DocumentLink>(), OperationalMode.Normal, workAssignment, false, null, null, null, false, false, false, Sendmailto,workPermit.IdValue);
            //var actionItemDefinition= new ActionItemDefinition(name,businessCategory,ActionItemDefinitionStatus.Approved,schedule,aIDescription.TrimOrEmpty(),DataSource.PERMIT,FALS,  );

            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.ActionItemDefinitionCreate, service.UpdateAndInsertActionItems, workPermit, actionItemDefinition);
            notifiedEvents.AddRange(UpdateAndInsertActionItems(workPermit, actionItemDefinition)); //|| add Action             
            // return notifiedEvents;
        }
        public List<NotifiedEvent> UpdateAndInsertActionItems(WorkPermitMuds workPermits, ActionItemDefinition actionItemDefinition)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            //foreach (WorkPermitMuds permit in workPermits)
            //{

            notifiedEvents.AddRange(actionItemDefinationService.Insert(actionItemDefinition, workPermits));

           //  }

            return notifiedEvents;
        }

        public WorkPermitMuds QueryById(long id)
        {
            return workPermitMudsDao.QueryById(id);
        }

        public WorkPermitMuds QueryByIdTemplate(long id, string templateName, string categories)
        {
            return workPermitMudsDao.QueryByIdTemplate(id, templateName, categories);
        }
        


        public List<NotifiedEvent> Remove(WorkPermitMuds workPermit)
        {
            
                workPermitMudsDao.Remove(workPermit);
            

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitMudsRemove, workPermit));
            return notifiedEvents;
        }

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public List<NotifiedEvent> RemoveTemplate(WorkPermitMuds workPermit)
        {
            workPermitMudsDao.RemoveTemplate(workPermit);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitMudsRemove, workPermit));
            return notifiedEvents;
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        public List<NotifiedEvent> UpdateTemplate(WorkPermitMuds workPermit)
        {
            if (workPermit.IsTemplate)
            {
                workPermitMudsDao.UpdateTemplate(workPermit);
            }

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitMudsUpdate, workPermit));
            return notifiedEvents;
        }

        public List<WorkPermitMudsGroup> QueryAllGroups()
        {
            return workPermitMudsGroupDao.QueryAll();
        }

        public void SaveWorkPermitGroups(List<WorkPermitMudsGroup> insertList,
            List<WorkPermitMudsGroup> updateList, List<WorkPermitMudsGroup> deleteList)
        {
            foreach (var groupToDelete in deleteList)
            {
                workPermitMudsGroupDao.Remove(groupToDelete);
            }

            foreach (var groupToUpdate in updateList)
            {
                workPermitMudsGroupDao.Update(groupToUpdate);
            }

            foreach (var groupToInsert in insertList)
            {
                workPermitMudsGroupDao.Insert(groupToInsert);
            }
        }

        public bool HasUserReadAtLeastOneDocumentLink(long userId, long workPermitMudsId)
        {
            return HasUserReadAtLeastOneDocumentLinkInEachPermit(userId, new List<long> {workPermitMudsId});
        }

        public bool HasUserReadAtLeastOneDocumentLinkInEachPermit(long userId, List<long> workPermitMudsIds)
        {
            foreach (var workPermitMudsId in workPermitMudsIds)
            {
                if (!workPermitMudsDao.HasUserReadAtLeastOneDocumentLink(userId, workPermitMudsId))
                {
                    return false;
                }
            }

            return true;
        }

        private List<NotifiedEvent> TakeSnapshotAndNotifyEvents(WorkPermitMuds workPermit,
            WorkPermitMuds workPermitWithAnId)
        {
            editHistoryService.TakeSnapshot(workPermit);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.WorkPermitMudsCreate,
                workPermitWithAnId));
            return notifiedEvents;
        }

        private string BuildAssociatedLogComments(Log log, WorkPermitMuds permit)
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


        //Adde by Mukesh for WOrkpermit Sign

        public WorkPermitMudSign GetWorkPermitSign(string WorkPermitId, int SiteId)
        {
            return workPermitMudsDao.GetWorkPermitSign(WorkPermitId, SiteId);
        }



        public void InserUpdateWorkPermitSign(WorkPermitMudSign workPermitSign)
        {
            workPermitMudsDao.InserUpdateWorkPermitSign(workPermitSign);
        }
    }
}