using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.Exceptions;
using Com.Suncor.Olt.Remote.Integration;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class FormGenericTemplateService : IFormGenericTemplateService
    {
        private readonly IDocumentSuggestionDTODao documentSuggestionDTODao;
        private readonly IDocumentSuggestionDao documentSuggestionDao;
        
        private readonly IEditHistoryService editHistoryService;
        private readonly IFormEdmontonDTODao formDtoDao;
        private readonly IFormGenericTemplateDao formGenericTemplateDao;
        private readonly IFormTemplateDao formTemplateDao;
        private readonly ILog logger = LogManager.GetLogger(typeof (FormEdmontonService));

        private readonly IFormEdmontonOP14DTODao op14DtoDao;
        private readonly ISiteService siteService;
        private readonly ITimeService timeService;
        private readonly IUserService userService;
        private readonly IWorkPermitEdmontonService workPermitEdmontonService;

        public FormGenericTemplateService(
            IFormGenericTemplateDao formGenericTemplateDao,
            IFormEdmontonDTODao formDtoDao,
            IFormEdmontonOP14DTODao op14DtoDao,
            IFormTemplateDao formTemplateDao,
            IEditHistoryService editHistoryService,
            ITimeService timeService,
            IUserService userService,
            ISiteService siteService,
            IDocumentSuggestionDao documentSuggestionDao,
            IDocumentSuggestionDTODao documentSuggestionDTODao
            )
        {
            this.formGenericTemplateDao = formGenericTemplateDao;
            
            this.formDtoDao = formDtoDao;
            this.op14DtoDao = op14DtoDao;
            
            this.formTemplateDao = formTemplateDao;

            this.editHistoryService = editHistoryService;
            

            this.timeService = timeService;
            this.userService = userService;
            this.siteService = siteService;

            this.documentSuggestionDao = documentSuggestionDao;
            this.documentSuggestionDTODao = documentSuggestionDTODao;

        }

        public FormGenericTemplateService()
            : this(
                DaoRegistry.GetDao<IFormGenericTemplateDao>(),
                DaoRegistry.GetDao<IFormEdmontonDTODao>(),
                DaoRegistry.GetDao<IFormEdmontonOP14DTODao>(),
                DaoRegistry.GetDao<IFormTemplateDao>(),
                new EditHistoryService(),
                new TimeService(),
                new UserService(),
                GenericServiceRegistry.Instance.GetService<ISiteService>(),
                DaoRegistry.GetDao<IDocumentSuggestionDao>(),
                DaoRegistry.GetDao<IDocumentSuggestionDTODao>())
        {
        }

        public List<FormGenericTemplateDTO> QueryFormGenericTemplateDTOs(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return formGenericTemplateDao.QueryFormGenericTemplate(flocSet, dateRange, formStasuses, includeAllDraftFormsRegardlessOfDateRange,1,0); //TODO 001
        }


        public List<FormGenericTemplateDTO> QueryAllRequiringApprovalByFunctionalLocationsAndDateRange(IFlocSet flocSet,
            DateRange dateRange,
            bool authorizedToViewOvertimeForms)
        {
            var dtos = new List<FormGenericTemplateDTO>();

           var formStatuses = new List<FormStatus> {FormStatus.Draft};    

            // Todo: This is done serially, consider parallel requests and add them to the List at the end?
            // might want to optimize this based on user's site
            dtos.AddRange(
                formGenericTemplateDao.QueryFormGenericTemplate(flocSet, dateRange, formStatuses, false, 1, 0) //TODO 001
                    .ConvertAll(dto => (FormGenericTemplateDTO)dto));

            dtos.Sort(SortByDateFromAscending());

            return dtos;
        }

        public List<FormTemplate> QueryFormTemplatesByFormType(EdmontonFormType formType, long SiteId)  
        {
            return formTemplateDao.QueryByFormType(formType,SiteId);   //ayman generic forms
        }

        public FormTemplate QueryFormTemplateByFormTypeAndKey(EdmontonFormType formType, string key)
        {
            return formTemplateDao.QueryByFormTypeAndKey(formType, key);
        }

        public List<FormTemplate> QueryFormTemplates(long siteId)
        {
            return formTemplateDao.QueryAll(siteId);
        }

        public void ReplaceFormTemplate(FormTemplate formTemplate, User user, DateTime now, long siteId)
        {
            formTemplateDao.Replace(formTemplate, user, now, siteId);
        }

        public FormGenericTemplate QueryFormGenericTemplateById(long id) 
        {
            return formGenericTemplateDao.QueryById(id);
        }
        
        public FormGenericTemplate QueryFormGenericTemplateByIdAndSiteId(long id, long siteid,long formtypeid, long plantid)  
        {
            return formGenericTemplateDao.QueryByIdAndSiteId(id, siteid, formtypeid, plantid);
        }

        //ayman Sarnia eip DMND0008992
        public List<FormApproval> QueryByFormSarniaEipIssueApproverByIdAndSiteId(long siteid, long formtypeid, long plantid)
        {
            return formGenericTemplateDao.QueryFormSarniaEipIssueApproverByIdAndSiteId(siteid, formtypeid, plantid);
        }
        //Added by ppanigrahi
        public List<FormApproval> QueryByFormSarniaCsdApproverByIdAndSiteId(long siteid, long formtypeid, long plantid)
        {
            return formGenericTemplateDao.QueryFormSarniaCsdApproverByIdAndSiteId(siteid, formtypeid, plantid);
        }

        public int Updatemailsentflag(long? Id, bool isMailSent)
        {
            int success = formGenericTemplateDao.Updatemailsentflag(Id, isMailSent);
         

            return success;
        }

        public List<FormApproval> QueryByFormOP14Id(long id)
        {

            return formGenericTemplateDao.QueryByFormOP14Id(id);

        }
        public List<FormApproval> QueryFormGenericTemplateEFormApproverByIdAndSiteId(long siteid, long formtypeid, long plantid)
        {
            return formGenericTemplateDao.QueryFormGenericTemplateEFormApproverByIdAndSiteId(siteid, formtypeid, plantid);
        }

        public List<NotifiedEvent> Insert(FormGenericTemplate form) 
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            var insertResult = formGenericTemplateDao.Insert(form);

            editHistoryService.TakeSnapshot(insertResult);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGenericTemplateCreate, form));
            return notifiedEvents;
        }
        
        //ayman generic forms
        public DocumentSuggestion QueryDocumentSuggestionFormByIdAndSiteId(long id,long siteid)
        {
            return documentSuggestionDao.QueryByIdAndSiteId(id,siteid);
        }
        
        public DocumentSuggestion QueryDocumentSuggestionFormById(long id)
        {
            return documentSuggestionDao.QueryById(id);
        }

        public List<DocumentSuggestionDTO> QueryDocumentSuggestionDtos(RootFlocSet flocSet, DateRange dateRange, long userId)
        {
            var dtos = new List<DocumentSuggestionDTO>();

            dtos.AddRange(documentSuggestionDTODao.QueryDocumentSuggestionDtos(flocSet, dateRange, userId));

            dtos.Sort(SortByCreatedDateDescending());

            return dtos;
        }

        public List<DocumentSuggestionDTO> QueryDocumentSuggestionsByFunctionalLocations(RootFlocSet flocSet,
            DateTime now, long userId)
        {
            var dtos = new List<DocumentSuggestionDTO>();

            dtos.AddRange(documentSuggestionDTODao.QueryDocumentSuggestionDtosThatAreNonDraftByFunctionalLocations(flocSet, now, userId));

            dtos.Sort(SortByDateFromDescending());

            return dtos;
        }

        public List<NotifiedEvent> InsertDocumentSuggestionForm(DocumentSuggestion form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            var insertedResult = documentSuggestionDao.Insert(form);

            editHistoryService.TakeSnapshot(insertedResult);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormDocumentSuggestionCreate,
                    insertedResult)
            };
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateDocumentSuggestionForm(DocumentSuggestion form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            documentSuggestionDao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormDocumentSuggestionUpdate, form)
            };
            return notifiedEvents;
        }

        public List<NotifiedEvent> DeleteDocumentSuggestionForm(DocumentSuggestion form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            documentSuggestionDao.Remove(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormDocumentSuggestionRemove, form)
            };
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(FormGenericTemplate form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            formGenericTemplateDao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGenericTemplateUpdate, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Remove(FormGenericTemplate form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            formGenericTemplateDao.Remove(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGenericTemplateRemove, form));
            return notifiedEvents;
        }
                                         
        public List<FormGenericTemplate> QueryAllFormGenericTemplatesThatAreApprovedAndAreMoreThan10DaysOutOfService(DateTime now)
        {
            return formGenericTemplateDao.QueryAllThatAreApprovedAndAreMoreThan10DaysOutOfService(now);
        }
        
        private Comparison<FormEdmontonDTO> SortByCreatedDateDescending()
        {
            return (dto1, dto2) => dto1.CreatedDateTime.CompareTo(dto2.CreatedDateTime)*-1;
        }

        private Comparison<FormEdmontonDTO> SortByDateFromDescending()
        {
            return (dto1, dto2) => dto1.ValidFrom.CompareTo(dto2.ValidFrom)*-1;
        }

        private Comparison<FormEdmontonDTO> SortByDateFromAscending()
        {
            return (dto1, dto2) => dto1.ValidFrom.CompareTo(dto2.ValidFrom);
        }

        

        

        private DateTime GetCurrentTimeAtSite(FunctionalLocation flocFromSite)
        {
            return GetCurrentTimeAtSite(flocFromSite.Site);
        }

        private DateTime GetCurrentTimeAtSite(Site site)
        {
            return timeService.GetTime(site.TimeZone);
        }

        
    }
}