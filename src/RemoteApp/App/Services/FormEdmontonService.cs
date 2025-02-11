﻿using System;
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
    public class FormEdmontonService : IFormEdmontonService
    {
        private readonly IActionItemDefinitionService actionItemDefinitionService;
        private readonly IDocumentSuggestionDTODao documentSuggestionDTODao;
        private readonly IDocumentSuggestionDao documentSuggestionDao;
        private readonly IProcedureDeviationDTODao procedureDeviationDTODao;
        private readonly IProcedureDeviationDao procedureDeviationDao;
        private readonly IEditHistoryService editHistoryService;
        private readonly IFormEdmontonDTODao formDtoDao;
        private readonly IFormGN1Dao formGN1Dao;
        private readonly IFormGN24Dao formGN24Dao;
        private readonly IFormGN59Dao formGN59Dao;
        private readonly IFormGN6Dao formGN6Dao;
        private readonly IFormGN75ADao formGN75ADao;
        private readonly IFormGN75BDao formGN75BDao;
        private readonly IFormGN7Dao formGN7Dao;
        private readonly IFormOP14Dao formOP14Dao;
        private readonly IPermitAssessmentDTODao formPermitAssessmentDTODao;
        private readonly IPermitAssessmentDao formPermitAssessmentDao;
        private readonly IFormTemplateDao formTemplateDao;
        private readonly IFormEdmontonGN1DTODao gn1DTODao;
        private readonly IFormEdmontonGN24DTODao gn24DTODao;
        private readonly IFormEdmontonGN6DTODao gn6DTODao;
        private readonly IFormEdmontonGN75ADTODao gn75ADTODao;
        private readonly IFormEdmontonGN75BDTODao gn75BDTODao;
        private readonly ILog logger = LogManager.GetLogger(typeof(FormEdmontonService));

        private readonly ILubesAlarmDisableDao lubesAlarmDisableDao;
        private readonly ILubesAlarmDisableFormDTODao lubesAlarmDisableFormDTODao;
        private readonly IFormLubesCsdDao lubesCsdDao;
        private readonly ILubesCsdFormDTODao lubesCsdFormDTODao;

        //DMND0011225 OLT - CSD for WBR
        private readonly IGenericCsdDTODao genericCsdDTODao;
        private readonly IGenericCsdDao genericCsdDao;

        private readonly IMontrealCsdDTODao montrealCsdDTODao;
        private readonly IMontrealCsdDao montrealCsdDao;
        private readonly IOnPremisePersonnelDtoDao onPremisePersonnelDtoDao;

        private readonly IOnPremisePersonnelService onPremisePersonnelService;
        private readonly IFormEdmontonOP14DTODao op14DtoDao;
        private readonly IOvertimeFormDTODao overtimeFormDTODao;
        private readonly IOvertimeFormDao overtimeFormDao;
        private readonly IPermitRequestEdmontonService permitRequestEdmontonService;
        private readonly IShiftPatternService shiftPatternService;
        private readonly ISiteService siteService;
        private readonly IEdmontonSwipeCardReader swipeCardReader;
        private readonly ITimeService timeService;
        private readonly IUserService userService;
        private readonly IWorkPermitEdmontonService workPermitEdmontonService;

        private readonly IFormGenericTemplateDao opGenericTemplateDao;//generic template - mangesh

        //RITM0268131 - mangesh
        private readonly ITemporaryInstallationsMudsDao tempInstallationMudsDao;
        private readonly ITemporaryInstallationsMudsDTODao tempInstallationMudsDTODao;
        public FormEdmontonService(IFormGN7Dao formGN7Dao,
            IFormGN59Dao formGN59Dao,
            IFormOP14Dao formOP14Dao,
            IPermitAssessmentDao permitAssessmentDao,
            IPermitAssessmentDTODao permitAssessmentDTODao,
            IFormGN24Dao formGN24Dao,
            IFormGN6Dao formGN6Dao,
            IFormGN75ADao formGN75ADao,
            IFormGN75BDao formGN75BDao,
            IFormGN1Dao formGN1Dao,
            IOvertimeFormDao overtimeFormDao,
            IFormEdmontonDTODao formDtoDao,
            IFormEdmontonOP14DTODao op14DtoDao,
            IFormEdmontonGN24DTODao gn24DTODao,
            IFormEdmontonGN6DTODao gn6DTODao,
            IFormEdmontonGN75ADTODao gn75ADTODao,
            IFormEdmontonGN75BDTODao gn75BDTODao,
            IFormEdmontonGN1DTODao gn1DTODao,
            IOvertimeFormDTODao overtimeFormDTODao,
            IFormLubesCsdDao lubesCsdDao,
            ILubesCsdFormDTODao lubesCsdFormDTODao,
            ILubesAlarmDisableDao lubesAlarmDisableDao,
            ILubesAlarmDisableFormDTODao lubesAlarmDisableFormDTODao,
            IOnPremisePersonnelDtoDao onPremisePersonnelDtoDao,
            IFormTemplateDao formTemplateDao,
            IEditHistoryService editHistoryService,
            IPermitRequestEdmontonService permitRequestEdmontonService,
            IWorkPermitEdmontonService workPermitEdmontonService,
            ITimeService timeService,
            IUserService userService,
            IActionItemDefinitionService actionItemDefinitionService,
            IOnPremisePersonnelService onPremisePersonnelService,
            IEdmontonSwipeCardReader swipeCardReader,
            IShiftPatternService shiftPatternService,
            ISiteService siteService,
            IMontrealCsdDao montrealCsdDao,
            IMontrealCsdDTODao montrealCsdDTODao,
            IDocumentSuggestionDao documentSuggestionDao,
            IDocumentSuggestionDTODao documentSuggestionDTODao,
            IProcedureDeviationDao procedureDeviationDao,
            IProcedureDeviationDTODao procedureDeviationDTODao,
            IFormGenericTemplateDao opGenericTemplateDao,
            ITemporaryInstallationsMudsDao tempInstallationMudsDao, //RITM0268131 - mangesh
            ITemporaryInstallationsMudsDTODao tempInstallationMudsDTODao,//generic template - mangesh
            IGenericCsdDao genericCsdDao,
            IGenericCsdDTODao genericCsdDTODao) //DMND0011225 OLT - CSD for WBR
        {
            this.formGN7Dao = formGN7Dao;
            formPermitAssessmentDao = permitAssessmentDao;
            formPermitAssessmentDTODao = permitAssessmentDTODao;
            this.genericCsdDao = genericCsdDao; //DMND0011225 OLT - CSD for WBR
            this.genericCsdDTODao = genericCsdDTODao;
            this.montrealCsdDao = montrealCsdDao;
            this.montrealCsdDTODao = montrealCsdDTODao;
            this.formGN59Dao = formGN59Dao;
            this.formOP14Dao = formOP14Dao;
            this.formGN24Dao = formGN24Dao;
            this.formGN6Dao = formGN6Dao;
            this.formGN75ADao = formGN75ADao;
            this.formGN75BDao = formGN75BDao;
            this.formGN1Dao = formGN1Dao;
            this.overtimeFormDao = overtimeFormDao;

            this.formDtoDao = formDtoDao;
            this.op14DtoDao = op14DtoDao;
            this.gn24DTODao = gn24DTODao;
            this.gn6DTODao = gn6DTODao;
            this.gn75ADTODao = gn75ADTODao;
            this.gn75BDTODao = gn75BDTODao;
            this.gn1DTODao = gn1DTODao;

            this.lubesCsdDao = lubesCsdDao;
            this.lubesCsdFormDTODao = lubesCsdFormDTODao;

            this.lubesAlarmDisableDao = lubesAlarmDisableDao;
            this.lubesAlarmDisableFormDTODao = lubesAlarmDisableFormDTODao;

            this.overtimeFormDTODao = overtimeFormDTODao;
            this.onPremisePersonnelDtoDao = onPremisePersonnelDtoDao;

            this.formTemplateDao = formTemplateDao;

            this.editHistoryService = editHistoryService;
            this.permitRequestEdmontonService = permitRequestEdmontonService;
            this.workPermitEdmontonService = workPermitEdmontonService;

            this.timeService = timeService;
            this.userService = userService;
            this.actionItemDefinitionService = actionItemDefinitionService;

            this.onPremisePersonnelService = onPremisePersonnelService;
            this.swipeCardReader = swipeCardReader;
            this.shiftPatternService = shiftPatternService;
            this.siteService = siteService;

            this.documentSuggestionDao = documentSuggestionDao;
            this.documentSuggestionDTODao = documentSuggestionDTODao;

            this.procedureDeviationDao = procedureDeviationDao;
            this.procedureDeviationDTODao = procedureDeviationDTODao;

            //generic template - mangesh
            this.opGenericTemplateDao = opGenericTemplateDao;
            //RITM0268131 - mangesh
            this.tempInstallationMudsDao = tempInstallationMudsDao;
            this.tempInstallationMudsDTODao = tempInstallationMudsDTODao;
        }

        public FormEdmontonService()
            : this(DaoRegistry.GetDao<IFormGN7Dao>(),
                DaoRegistry.GetDao<IFormGN59Dao>(),
                DaoRegistry.GetDao<IFormOP14Dao>(),
                DaoRegistry.GetDao<IPermitAssessmentDao>(),
                DaoRegistry.GetDao<IPermitAssessmentDTODao>(),
                DaoRegistry.GetDao<IFormGN24Dao>(),
                DaoRegistry.GetDao<IFormGN6Dao>(),
                DaoRegistry.GetDao<IFormGN75ADao>(),
                DaoRegistry.GetDao<IFormGN75BDao>(),
                DaoRegistry.GetDao<IFormGN1Dao>(),
                DaoRegistry.GetDao<IOvertimeFormDao>(),
                DaoRegistry.GetDao<IFormEdmontonDTODao>(),
                DaoRegistry.GetDao<IFormEdmontonOP14DTODao>(),
                DaoRegistry.GetDao<IFormEdmontonGN24DTODao>(),
                DaoRegistry.GetDao<IFormEdmontonGN6DTODao>(),
                DaoRegistry.GetDao<IFormEdmontonGN75ADTODao>(),
                DaoRegistry.GetDao<IFormEdmontonGN75BDTODao>(),
                DaoRegistry.GetDao<IFormEdmontonGN1DTODao>(),
                DaoRegistry.GetDao<IOvertimeFormDTODao>(),
                DaoRegistry.GetDao<IFormLubesCsdDao>(),
                DaoRegistry.GetDao<ILubesCsdFormDTODao>(),
                DaoRegistry.GetDao<ILubesAlarmDisableDao>(),
                DaoRegistry.GetDao<ILubesAlarmDisableFormDTODao>(),
                DaoRegistry.GetDao<IOnPremisePersonnelDtoDao>(),
                DaoRegistry.GetDao<IFormTemplateDao>(),
                new EditHistoryService(),
                new PermitRequestEdmontonService(),
                new WorkPermitEdmontonService(),
                new TimeService(),
                new UserService(),
                new ActionItemDefinitionService(),
                GenericServiceRegistry.Instance.GetService<IOnPremisePersonnelService>(),
                new EdmontonSwipeCardReader(),
                GenericServiceRegistry.Instance.GetService<IShiftPatternService>(),
                GenericServiceRegistry.Instance.GetService<ISiteService>(),
                DaoRegistry.GetDao<IMontrealCsdDao>(),
                DaoRegistry.GetDao<IMontrealCsdDTODao>(),
                DaoRegistry.GetDao<IDocumentSuggestionDao>(),
                DaoRegistry.GetDao<IDocumentSuggestionDTODao>(),
                DaoRegistry.GetDao<IProcedureDeviationDao>(),
                DaoRegistry.GetDao<IProcedureDeviationDTODao>(),
                DaoRegistry.GetDao<IFormGenericTemplateDao>(),   //generic template - add IFormGenericTemplateDao - mangesh

            DaoRegistry.GetDao<ITemporaryInstallationsMudsDao>(), //RITM0268131 - mangesh
                DaoRegistry.GetDao<ITemporaryInstallationsMudsDTODao>(),

            DaoRegistry.GetDao<IGenericCsdDao>(), //DMND0011225 OLT - CSD for WBR
                DaoRegistry.GetDao<IGenericCsdDTODao>()
            )
        {
        }

        //ayman generic forms
        public FormGN7 QueryFormGN7ByIdAndSiteId(long id, long siteid)
        {
            return formGN7Dao.QueryByIdAndSiteId(id, siteid);
        }

        public FormGN7 QueryFormGN7ById(long id)
        {
            return formGN7Dao.QueryById(id);
        }

        //ayman generic forms
        public FormGN59 QueryFormGN59ByIdAndSiteId(long id, long siteid)
        {
            return formGN59Dao.QueryByIdAndSiteId(id, siteid);
        }


        public FormGN59 QueryFormGN59ById(long id)
        {
            return formGN59Dao.QueryById(id);
        }

        public List<FormEdmontonDTO> QueryFormGN7DTOs(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return formDtoDao.QueryFormGN7(flocSet, dateRange, formStasuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        public List<FormEdmontonDTO> QueryFormGN59DTOs(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return formDtoDao.QueryFormGN59(flocSet, dateRange, formStasuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        public List<FormEdmontonOP14DTO> QueryFormOP14DTOs(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return op14DtoDao.QueryFormOP14(flocSet, dateRange, formStasuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        //generic template - mangesh
        public List<FormGenericTemplateDTO> QueryFormGenericTemplateDTOs(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange,
            long formtypeid, long plantid)
        {
            return opGenericTemplateDao.QueryFormGenericTemplate(flocSet, dateRange, formStasuses, includeAllDraftFormsRegardlessOfDateRange, formtypeid, plantid);
        }

        //DMND0011225 OLT - CSD for WBR
        public List<GenericCsdDTO> QueryGenericCsdDTOs(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return genericCsdDTODao.QueryFormGenericCsd(flocSet, dateRange, formStasuses,
                includeAllDraftFormsRegardlessOfDateRange);
        }

        public List<MontrealCsdDTO> QueryMontrealCsdDTOs(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return montrealCsdDTODao.QueryFormMontrealCsd(flocSet, dateRange, formStasuses,
                includeAllDraftFormsRegardlessOfDateRange);
        }

        //RITM0268131 - mangesh
        public List<TemporaryInstallationsMudsDTO> QueryMudsTemporaryInstallationsDTOs(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStasuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return tempInstallationMudsDTODao.QueryFormMudsTemporaryInstallations(flocSet, dateRange, formStasuses,
                includeAllDraftFormsRegardlessOfDateRange);
        }
        public List<FormEdmontonDTO> QueryAllRequiringApprovalByFunctionalLocationsAndDateRange(IFlocSet flocSet,
   DateRange dateRange,
   bool authorizedToViewOvertimeForms)
        {
            var dtos = new List<FormEdmontonDTO>();

            var formStatuses = new List<FormStatus> { FormStatus.Draft };

            // Todo: This is done serially, consider parallel requests and add them to the List at the end?
            // might want to optimize this based on user's site
            dtos.AddRange(formDtoDao.QueryFormGN7(flocSet, dateRange, formStatuses, false));
            dtos.AddRange(formDtoDao.QueryFormGN59(flocSet, dateRange, formStatuses, false));
            dtos.AddRange(
                op14DtoDao.QueryFormOP14(flocSet, dateRange, formStatuses, false)
                    .ConvertAll(dto => (FormEdmontonDTO)dto));

            // not sure why this wasn't done for lubes csd's -- ask andrew if this is broken
            dtos.AddRange(
                montrealCsdDTODao.QueryFormMontrealCsd(flocSet, dateRange, formStatuses, false)
                    .ConvertAll(dto => (FormEdmontonDTO)dto));
            dtos.AddRange(
                gn24DTODao.QueryDTOs(flocSet, dateRange, formStatuses, false).ConvertAll(dto => (FormEdmontonDTO)dto));
            dtos.AddRange(
                gn6DTODao.QueryDTOs(flocSet, dateRange, formStatuses, false).ConvertAll(dto => (FormEdmontonDTO)dto));
            dtos.AddRange(
                gn75ADTODao.QueryDTOs(flocSet, dateRange, formStatuses, false).ConvertAll(dto => (FormEdmontonDTO)dto));
            dtos.AddRange(
                gn1DTODao.QueryDTOs(flocSet, dateRange, formStatuses, false).ConvertAll(dto => (FormEdmontonDTO)dto));

            //ayman Sarnia eip DMND0008992
            var formStatusesForSarnia = new List<FormStatus> { FormStatus.WaitingForApproval };    //ayman Sarnia eip DMND0008992
            dtos.AddRange(
                gn75BDTODao.QuerySarniaFormDTOsForPriorityScreen(flocSet, formStatusesForSarnia, 1).ConvertAll(dto => (FormEdmontonGN75BDTOforPriorityScreen)dto));

            //generic template - mangesh
            dtos.AddRange(
                opGenericTemplateDao.QueryFormGenericTemplate(flocSet, dateRange, formStatuses, false, 0, 0)//TODO 001
                    .ConvertAll(dto => (FormGenericTemplateDTO)dto));

            //DMND0011225 CSD for WBR
            dtos.AddRange(
                genericCsdDTODao.QueryFormGenericCsd(flocSet, dateRange, formStatuses, false)
                    .ConvertAll(dto => (FormEdmontonDTO)dto));

            if (authorizedToViewOvertimeForms)
            {
                dtos.AddRange(
                    overtimeFormDTODao.QueryWaitingApprovalDTOs(dateRange).ConvertAll(dto => (FormEdmontonDTO)dto));
            }

            dtos.Sort(SortByDateFromAscending());

            return dtos;
        }

        //DMND0011225 CSD for WBR
        public List<GenericCsdDTO> QueryAllGenericCsdsRequiringApprovalByFunctionalLocationsAndDateRange(
            IFlocSet flocSet, DateRange dateRange)
        {
            var dtos = new List<GenericCsdDTO>();

            var formStatuses = new List<FormStatus> { FormStatus.Draft };

            dtos.AddRange(
                genericCsdDTODao.QueryFormGenericCsd(flocSet, dateRange, formStatuses, false));

            dtos.Sort(SortByDateFromAscending());

            return dtos;
        }

        public List<MontrealCsdDTO> QueryAllMontrealCsdsRequiringApprovalByFunctionalLocationsAndDateRange(
            IFlocSet flocSet, DateRange dateRange)
        {
            var dtos = new List<MontrealCsdDTO>();

            var formStatuses = new List<FormStatus> { FormStatus.Draft };

            dtos.AddRange(
                montrealCsdDTODao.QueryFormMontrealCsd(flocSet, dateRange, formStatuses, false));

            dtos.Sort(SortByDateFromAscending());

            return dtos;
        }

        public List<FormEdmontonDTO> QueryAllLubesFormsRequiringApprovalByFunctionalLocationsAndDateRange(
            IFlocSet flocSet, DateRange dateRange)
        {
            var dtos = new List<FormEdmontonDTO>();

            var formStatuses = new List<FormStatus> { FormStatus.Draft };

            dtos.AddRange(lubesCsdFormDTODao.QueryFormCsd(flocSet, dateRange, formStatuses, false));
            dtos.AddRange(lubesAlarmDisableFormDTODao.QueryFormAlarmDisable(flocSet, dateRange, formStatuses, false));

            dtos.Sort(SortByDateFromAscending());

            return dtos;
        }

        public List<FormEdmontonOP14DTO> QueryFormOP14sThatAreApprovedByFunctionalLocations(IFlocSet flocSet,
            DateTime now)
        {
            var dtos = new List<FormEdmontonOP14DTO>();

            dtos.AddRange(op14DtoDao.QueryFormOP14sThatAreApprovedDraftExpiredByFunctionalLocations(flocSet, now));

            dtos.Sort(SortByDateFromDescending());

            return dtos;
        }

        //DMND0011225 OLT - CSD for WBR
        public List<GenericCsdDTO> QueryGenericCsdsThatAreApprovedByFunctionalLocations(IFlocSet flocSet,
            DateTime now)
        {
            var dtos = new List<GenericCsdDTO>();

            dtos.AddRange(
                genericCsdDTODao.QueryFormGenericCsdsThatAreApprovedDraftExpiredByFunctionalLocations(flocSet, now));

            dtos.Sort(SortByDateFromDescending());

            return dtos;
        }
        
        public List<MontrealCsdDTO> QueryMontrealCsdsThatAreApprovedByFunctionalLocations(IFlocSet flocSet,
            DateTime now)
        {
            var dtos = new List<MontrealCsdDTO>();

            dtos.AddRange(
                montrealCsdDTODao.QueryFormMontrealCsdsThatAreApprovedDraftExpiredByFunctionalLocations(flocSet, now));

            dtos.Sort(SortByDateFromDescending());

            return dtos;
        }

        //RITM0268131 - mangesh
        public List<TemporaryInstallationsMudsDTO> QueryMudsTemporaryInstallationsThatAreApprovedByFunctionalLocations(IFlocSet flocSet,
            DateTime now)
        {
            var dtos = new List<TemporaryInstallationsMudsDTO>();

            dtos.AddRange(
                tempInstallationMudsDTODao.QueryFormMudsTemporaryInstallationsThatAreApprovedDraftExpiredByFunctionalLocations(flocSet, now));

            dtos.Sort(SortByDateFromDescending());

            return dtos;
        }
        public List<LubesCsdFormDTO> QueryFormLubesCsdsThatAreApprovedByFunctionalLocations(IFlocSet flocSet,
                   DateTime now)
        {
            var dtos = new List<LubesCsdFormDTO>();

            dtos.AddRange(lubesCsdFormDTODao.QueryFormCsdsThatAreApprovedDraftExpiredByFunctionalLocations(flocSet, now));

            dtos.Sort(SortByDateFromDescending());

            return dtos;
        }

        public List<LubesCsdFormDTO> QueryFormLubesCsdsThatAreExpiredOrApprovedAndActiveByFunctionalLocations(
            IFlocSet flocSet,
            DateTime now)
        {
            return lubesCsdFormDTODao.QueryFormCsdsThatAreExpiredOrApprovedAndActiveByFunctionalLocations(flocSet, now);
        }

        public List<NotifiedEvent> InsertGN7(FormGN7 form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            var formWithAnId = formGN7Dao.Insert(form);

            editHistoryService.TakeSnapshot(formWithAnId);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN7Create, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateGN7(FormGN7 form, LabelAttributes attributesForHazardsLabel)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            formGN7Dao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            if (form.IsApproved())
            {
                notifiedEvents.AddRange(CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(form));
                notifiedEvents.AddRange(CheckAssociatedWorkPermitsAndMarkAsCompleteIfPossible(form,
                    attributesForHazardsLabel,
                    id => workPermitEdmontonService.QueryByFormGN7Id(id)));
            }

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN7Update, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> RemoveGN7(FormGN7 form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            formGN7Dao.Remove(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN7Remove, form));
            return notifiedEvents;
        }


        public List<FormTemplate> QueryFormTemplatesByFormType(EdmontonFormType formType, long SiteId)   //ayman generic forms
        {
            return formTemplateDao.QueryByFormType(formType, SiteId);   //ayman generic forms
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

        public List<NotifiedEvent> InsertGN59(FormGN59 form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            var insertResult = formGN59Dao.Insert(form);

            editHistoryService.TakeSnapshot(insertResult);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN59Create, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateGN59(FormGN59 form, LabelAttributes attributesForHazardsLabel)
        {
            var currentTimeAtSite = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            form.LastModifiedDateTime = currentTimeAtSite;
            formGN59Dao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();

            if (form.IsApproved())
            {
                notifiedEvents.AddRange(CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(form));
                notifiedEvents.AddRange(CheckAssociatedWorkPermitsAndMarkAsCompleteIfPossible(form,
                    attributesForHazardsLabel,
                    id => workPermitEdmontonService.QueryByFormGN59Id(id)));
            }
            else if (form.IsDraft())
            {
                notifiedEvents.AddRange(ChangeAssociatedPermitsFromPendingToRequested(form,
                    currentTimeAtSite,
                    id => workPermitEdmontonService.QueryByFormGN59Id(id)));
                notifiedEvents.AddRange(ChangePermitRequestStatusForDraftForm(form,
                    currentTimeAtSite,
                    id => permitRequestEdmontonService.QueryByFormGN59Id(id)));
            }

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN59Update, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> RemoveGN59(FormGN59 form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            formGN59Dao.Remove(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN59Remove, form));
            return notifiedEvents;
        }

        public FormOP14 QueryFormOP14ById(long id)
        {
            return formOP14Dao.QueryById(id);
        }

        //ayman generic forms
        public FormOP14 QueryFormOP14ByIdAndSiteId(long id, long siteid)
        {
            return formOP14Dao.QueryByIdAndSiteId(id, siteid);
        }

        //generic template - mangesh
        public FormGenericTemplate QueryFormGenericTemplateById(long id)
        {
            return opGenericTemplateDao.QueryById(id);
        }
        public FormGenericTemplate QueryFormGenericTemplateByIdAndSiteId(long id, long siteid, long formtypeid, long plantid)
        {
            return opGenericTemplateDao.QueryByIdAndSiteId(id, siteid, formtypeid, plantid); //TODO 001
        }
        //--


        //ayman generic forms
        public MontrealCsd QueryMontrealCsdByIdAndSiteId(long id, long siteid)
        {
            return montrealCsdDao.QueryById(id);
        }

        public MontrealCsd QueryMontrealCsdById(long id)
        {
            return montrealCsdDao.QueryById(id);
        }

        //DMND0011225 OLT - CSD for WBR
        public GenericCsd QueryGenericCsdByIdAndSiteId(long id, long siteid)
        {
            return genericCsdDao.QueryById(id);
        }

        public GenericCsd QueryGenericCsdById(long id)
        {
            return genericCsdDao.QueryById(id);
        }

        //RITM0268131 - mangesh
        public TemporaryInstallationsMUDS QueryMudsTemporaryInstallationsById(long id)
        {
            return tempInstallationMudsDao.QueryById(id);
        }
        public List<NotifiedEvent> InsertOP14(FormOP14 form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            var insertResult = formOP14Dao.Insert(form);

            editHistoryService.TakeSnapshot(insertResult);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormOP14Create, form));
            return notifiedEvents;
        }

        //generic template - mangesh
        public List<NotifiedEvent> InsertGenericTemplate(FormGenericTemplate form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            var insertResult = opGenericTemplateDao.Insert(form);

            editHistoryService.TakeSnapshot(insertResult);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGenericTemplateCreate, form));
            return notifiedEvents;
        }


        public List<NotifiedEvent> InsertOilsandsPermitAssessmentForm(PermitAssessment form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            var insertedResult = formPermitAssessmentDao.Insert(form);

            editHistoryService.TakeSnapshot(insertedResult);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormPermitAssessmentCreate,
                    insertedResult)
            };
            return notifiedEvents;
        }


        public List<NotifiedEvent> UpdateOilsandsPermitAssessmentForm(PermitAssessment form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            formPermitAssessmentDao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormPermitAssessmentUpdate, form));
            return notifiedEvents;
        }

        //ayman generic forms
        public DocumentSuggestion QueryDocumentSuggestionFormByIdAndSiteId(long id, long siteid)
        {
            return documentSuggestionDao.QueryByIdAndSiteId(id, siteid);
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

        //ayman generic forms
        public ProcedureDeviation QueryProcedureDeviationFormByIdAndSiteId(long id, long siteid)
        {
            return procedureDeviationDao.QueryByIdAndSiteId(id, siteid);
        }


        public ProcedureDeviation QueryProcedureDeviationFormById(long id)
        {
            return procedureDeviationDao.QueryById(id);
        }

        public List<ProcedureDeviationDTO> QueryProcedureDeviationDtos(RootFlocSet flocSet, DateRange dateRange, long userId)
        {
            var dtos = new List<ProcedureDeviationDTO>();

            dtos.AddRange(procedureDeviationDTODao.QueryProcedureDeviationDtos(flocSet, dateRange, userId));

            dtos.Sort(SortByCreatedDateDescending());

            return dtos;
        }

        public List<ProcedureDeviationDTO> QueryProcedureDeviationsByFunctionalLocations(RootFlocSet flocSet,
            DateTime now, long userId)
        {
            var dtos = new List<ProcedureDeviationDTO>();

            dtos.AddRange(procedureDeviationDTODao.QueryProcedureDeviationDtosThatAreNonDraftByFunctionalLocations(flocSet, now, userId));

            dtos.Sort(SortByDateFromDescending());

            return dtos;
        }

        public List<NotifiedEvent> InsertProcedureDeviationForm(ProcedureDeviation form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            var insertedResult = procedureDeviationDao.Insert(form);

            editHistoryService.TakeSnapshot(insertedResult);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormProcedureDeviationCreate,
                    insertedResult)
            };
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateProcedureDeviationForm(ProcedureDeviation form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            procedureDeviationDao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormProcedureDeviationUpdate, form)
            };
            return notifiedEvents;
        }

        public List<NotifiedEvent> DeleteProcedureDeviationForm(ProcedureDeviation form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            procedureDeviationDao.Remove(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormProcedureDeviationRemove, form)
            };
            return notifiedEvents;
        }

        //RITM0268131 - mangesh
        public List<NotifiedEvent> InsertMudsTemporaryInstallations(TemporaryInstallationsMUDS form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            var insertResult = tempInstallationMudsDao.Insert(form);

            editHistoryService.TakeSnapshot(insertResult);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormMudsTemporaryInstallationCreate, form));
            return notifiedEvents;
        }

        //DMND0011225 OLT - CSD for WBR
        public List<NotifiedEvent> InsertGenericCsd(GenericCsd form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            var insertResult = genericCsdDao.Insert(form);

            editHistoryService.TakeSnapshot(insertResult);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGenericCsdCreate, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> InsertMontrealCsd(MontrealCsd form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            var insertResult = montrealCsdDao.Insert(form);

            editHistoryService.TakeSnapshot(insertResult);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormMontrealCsdCreate, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateOP14(FormOP14 form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            formOP14Dao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormOP14Update, form));
            return notifiedEvents;
        }

        //generic template - mangesh
        public List<NotifiedEvent> UpdateGenericTemplate(FormGenericTemplate form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            opGenericTemplateDao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGenericTemplateUpdate, form));
            return notifiedEvents;
        }

        //DMND0011225 OLT - CSD for WBR
        public List<NotifiedEvent> UpdateGenericCsd(GenericCsd form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            genericCsdDao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGenericCsdUpdate, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateMontrealCsd(MontrealCsd form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            montrealCsdDao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormMontrealCsdUpdate, form));
            return notifiedEvents;
        }

        //RITM0268131 - mangesh
        public List<NotifiedEvent> UpdateMudsTemporaryInstallations(TemporaryInstallationsMUDS form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            tempInstallationMudsDao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormMudsTemporaryInstallationUpdate, form));
            return notifiedEvents;
        }
        public List<NotifiedEvent> RemoveOP14(FormOP14 form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            formOP14Dao.Remove(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormOP14Remove, form));
            return notifiedEvents;
        }

        //generic template - mangesh
        public List<NotifiedEvent> RemoveGenericTemplate(FormGenericTemplate form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            opGenericTemplateDao.Remove(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGenericTemplateRemove, form));
            return notifiedEvents;
        }

        //DMND0011225 OLT - CSD for WBR
        public List<NotifiedEvent> RemoveGenericCsd(GenericCsd form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            genericCsdDao.Remove(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGenericCsdRemove, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> RemoveMontrealCsd(MontrealCsd form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            montrealCsdDao.Remove(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormMontrealCsdRemove, form));
            return notifiedEvents;
        }

        //RITM0268131 - mangesh
        public List<NotifiedEvent> RemoveMudsTemporaryInstallations(TemporaryInstallationsMUDS form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            tempInstallationMudsDao.Remove(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormMudsTemporaryInstallationRemove, form));
            return notifiedEvents;
        }
        public List<FormOP14> QueryAllFormOP14sThatAreApprovedAndAreMoreThan10DaysOutOfService(DateTime now)
        {
            return formOP14Dao.QueryAllThatAreApprovedAndAreMoreThan10DaysOutOfService(now);
        }

        //DMND0011225 OLT - CSD for WBR
        public List<GenericCsd> QueryAllGenericCsdsThatAreApprovedAndAreMoreThan3DaysOutOfService(DateTime now)
        {
            return genericCsdDao.QueryAllThatAreApprovedAndAreMoreThan3DaysOutOfService(now);
        }

        public List<GenericCsd> QueryAllGenericCsdsThatAreApprovedAndAreMoreThan5DaysOutOfService(
            DateTime currentTimeAtSite)
        {
            return genericCsdDao.QueryAllThatAreApprovedAndAreMoreThan5DaysOutOfService(currentTimeAtSite);
        }


        public List<MontrealCsd> QueryAllMontrealCsdsThatAreApprovedAndAreMoreThan3DaysOutOfService(DateTime now)
        {
            return montrealCsdDao.QueryAllThatAreApprovedAndAreMoreThan3DaysOutOfService(now);
        }

        public List<MontrealCsd> QueryAllMontrealCsdsThatAreApprovedAndAreMoreThan5DaysOutOfService(
            DateTime currentTimeAtSite)
        {
            return montrealCsdDao.QueryAllThatAreApprovedAndAreMoreThan5DaysOutOfService(currentTimeAtSite);
        }

        public List<LubesCsdForm> QueryAllLubeCsdsThatAreApprovedAndAreMoreThan7DaysOutOfService(DateTime now)
        {
            return lubesCsdDao.QueryAllThatAreApprovedAndAreMoreThan7DaysOutOfService(now);
        }

        //ayman generic forms
        public FormGN24 QueryFormGN24ByIdAndSiteId(long id, long siteid)
        {
            return formGN24Dao.QueryByIdAndSiteId(id, siteid);
        }


        public FormGN24 QueryFormGN24ById(long id)
        {
            return formGN24Dao.QueryById(id);
        }

        public List<NotifiedEvent> InsertGN24(FormGN24 form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            formGN24Dao.Insert(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN24Create, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateGN24(FormGN24 form, LabelAttributes attributesForHazardsLabel)
        {
            var currentTimeAtSite = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            form.LastModifiedDateTime = currentTimeAtSite;
            formGN24Dao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();

            if (form.IsApproved())
            {
                notifiedEvents.AddRange(CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(form));
                notifiedEvents.AddRange(CheckAssociatedWorkPermitsAndMarkAsCompleteIfPossible(form,
                    attributesForHazardsLabel,
                    id => workPermitEdmontonService.QueryByFormGN24Id(id)));
            }
            else if (form.IsDraft())
            {
                notifiedEvents.AddRange(ChangeAssociatedPermitsFromPendingToRequested(form,
                    currentTimeAtSite,
                    id => workPermitEdmontonService.QueryByFormGN24Id(id)));
                notifiedEvents.AddRange(ChangePermitRequestStatusForDraftForm(form,
                    currentTimeAtSite,
                    id => permitRequestEdmontonService.QueryByFormGN24Id(id)));
            }

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN24Update, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> RemoveGN24(FormGN24 form, User currentUser)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            form.LastModifiedBy = currentUser;

            formGN24Dao.Remove(form);

            return new List<NotifiedEvent> { ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN24Remove, form) };
        }

        public List<FormEdmontonGN24DTO> QueryFormGN24DTOsByCriteria(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return gn24DTODao.QueryDTOs(flocSet, dateRange, formStatuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        public List<FormEdmontonGN6DTO> QueryFormGN6DTOsByCriteria(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return gn6DTODao.QueryDTOs(flocSet, dateRange, formStatuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        //ayman generic forms
        public FormGN6 QueryFormGN6ByIdAndSiteId(long id, long siteid)
        {
            return formGN6Dao.QueryByIdAndSiteId(id, siteid);
        }

        public FormGN6 QueryFormGN6ById(long id)
        {
            return formGN6Dao.QueryById(id);
        }

        public List<NotifiedEvent> InsertGN6(FormGN6 form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            formGN6Dao.Insert(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN6Create, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateGN6(FormGN6 form, LabelAttributes attributesForHazardsLabel)
        {
            var currentTimeAtSite = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            form.LastModifiedDateTime = currentTimeAtSite;
            formGN6Dao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();

            if (form.IsApproved())
            {
                notifiedEvents.AddRange(CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(form));
                notifiedEvents.AddRange(CheckAssociatedWorkPermitsAndMarkAsCompleteIfPossible(form,
                    attributesForHazardsLabel,
                    id => workPermitEdmontonService.QueryByFormGN6Id(id)));
            }
            else if (form.IsDraft())
            {
                notifiedEvents.AddRange(ChangeAssociatedPermitsFromPendingToRequested(form,
                    currentTimeAtSite,
                    id => workPermitEdmontonService.QueryByFormGN6Id(id)));
                notifiedEvents.AddRange(ChangePermitRequestStatusForDraftForm(form,
                    currentTimeAtSite,
                    id => permitRequestEdmontonService.QueryByFormGN6Id(id)));
            }

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN6Update, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> RemoveGN6(FormGN6 form, User user)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocations[0]);
            form.LastModifiedBy = user;

            formGN6Dao.Remove(form);

            return new List<NotifiedEvent> { ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN6Remove, form) };
        }

        public List<NotifiedEvent> InsertGN75A(FormGN75A form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocation);
            formGN75ADao.Insert(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75ACreate, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateGN75A(FormGN75A form, LabelAttributes attributesForHazardsLabel)
        {
            var currentTimeAtSite = GetCurrentTimeAtSite(form.FunctionalLocation);
            form.LastModifiedDateTime = currentTimeAtSite;
            formGN75ADao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();

            if (form.IsApproved())
            {
                notifiedEvents.AddRange(CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(form));
                notifiedEvents.AddRange(CheckAssociatedWorkPermitsAndMarkAsCompleteIfPossible(form,
                    attributesForHazardsLabel,
                    id => workPermitEdmontonService.QueryByFormGN75AId(id)));
            }
            else if (form.IsDraft())
            {
                notifiedEvents.AddRange(ChangeAssociatedPermitsFromPendingToRequested(form,
                    currentTimeAtSite,
                    id => workPermitEdmontonService.QueryByFormGN75AId(id)));
                notifiedEvents.AddRange(ChangePermitRequestStatusForDraftForm(form,
                    currentTimeAtSite,
                    id => permitRequestEdmontonService.QueryByFormGN75AId(id)));
            }

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75AUpdate, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> RemoveGN75A(FormGN75A form, User user)
        {
            var notifiedEvents = new List<NotifiedEvent>();

            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocation);
            form.LastModifiedBy = user;

            formGN75ADao.Remove(form);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75ARemove, form));
            return notifiedEvents;
        }

        //ayman generic forms
        public FormGN75A QueryFormGN75AByIdAndSiteId(long id, long siteid)
        {
            return formGN75ADao.QueryByIdAndSiteId(id, siteid);
        }

        public FormGN75A QueryFormGN75AById(long id)
        {
            return formGN75ADao.QueryById(id);
        }

        public List<FormEdmontonGN75ADTO> QueryFormGN75ADTOsByCriteria(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return gn75ADTODao.QueryDTOs(flocSet, dateRange, formStatuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        //ayman Sarnia eip - 3
        public List<NotifiedEvent> InsertGN75BSarnia(FormGN75B formGn75B, bool addDocumentLinkAssociation)
        {
           // formGN75BDao.Insert(formGn75B); //Aarti
            formGN75BDao.InsertFormGN75BSarnia(formGn75B);
            
            editHistoryService.TakeSnapshot(formGn75B);

            if (addDocumentLinkAssociation)
            {
                InsertGN75BUserReadDocumentLinkAssociationSarnia(formGn75B.IdValue, formGn75B.LastModifiedBy.IdValue);
            }


            var notifiedEvents = new List<NotifiedEvent>
                {
                    ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75BCreate, formGn75B)
                };
            return notifiedEvents;
        }

        public List<NotifiedEvent> InsertGN75B(FormGN75B formGn75B, bool addDocumentLinkAssociation)
        {
            formGN75BDao.Insert(formGn75B);
            editHistoryService.TakeSnapshot(formGn75B);

            if (addDocumentLinkAssociation)
            {
                InsertGN75BUserReadDocumentLinkAssociation(formGn75B.IdValue, formGn75B.LastModifiedBy.IdValue);
            }


            var notifiedEvents = new List<NotifiedEvent>
                {
                    ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75BCreate, formGn75B)
                };
            return notifiedEvents;
        }

       //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        public List<NotifiedEvent> InsertGN75BTemplateSarnia(FormGN75B formGn75B, bool addDocumentLinkAssociation)
        {
            formGN75BDao.InsertTemplate(formGn75B);
            editHistoryService.TakeSnapshot(formGn75B);

            if (addDocumentLinkAssociation)
            {
               InsertGN75BUserReadDocumentLinkAssociationTemplateSarnia(formGn75B.IdValue, formGn75B.LastModifiedBy.IdValue);
            }

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75BTemplateCreate, formGn75B)
            };

            return notifiedEvents;
        }

        
        //ayman Sarnia eip DMND0008992
        public List<NotifiedEvent> InsertGN75BTemplate(FormGN75B formGn75B, bool addDocumentLinkAssociation)
        {
            formGN75BDao.InsertTemplate(formGn75B);
            editHistoryService.TakeSnapshot(formGn75B);

            if (addDocumentLinkAssociation)
            {
                InsertGN75BUserReadDocumentLinkAssociation(formGn75B.IdValue, formGn75B.LastModifiedBy.IdValue);
                
            }

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75BTemplateCreate, formGn75B)
            };

            return notifiedEvents;
        }


        //ayman Sarnia eip DMND0008992
        public List<NotifiedEvent> UpdateSarniaGN75B(FormGN75B formGn75B, bool addDocumentLinkAssociation, string formType)
        {
            var currentTimeAtSite = GetCurrentTimeAtSite(formGn75B.FunctionalLocation);
            formGn75B.LastModifiedDateTime = currentTimeAtSite;

            formGn75B.SiteID = formGn75B.FunctionalLocation.Site.IdValue;   //ayman show closed form
            //INC0466688 - RE: OLT GN-75 Appendix B Forms Edmonton Refinery
            if (Site.EDMONTON_ID.Equals(formGn75B.SiteID))
            {
                formGN75BDao.Update(formGn75B);
            }
            formGN75BDao.UpdateSarnia(formGn75B, formType);
            editHistoryService.TakeSnapshot(formGn75B);

            if (addDocumentLinkAssociation)
            {
                InsertGN75BUserReadDocumentLinkAssociationSarnia(formGn75B.IdValue, formGn75B.LastModifiedBy.IdValue);
            }

            if (formGn75B.FormType.Name == "EIP Template")
            {
                var notifiedEvents = new List<NotifiedEvent>
                    {
                        ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75BTemplateUpdate, formGn75B)
                    };
                return notifiedEvents;
            }
            else
            {
                var notifiedEvents = new List<NotifiedEvent>
                    {
                        ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75BUpdate, formGn75B)
                    };
                return notifiedEvents;
            }
        }

        public List<NotifiedEvent> UpdateGN75B(FormGN75B formGn75B, bool addDocumentLinkAssociation)
        {
            var currentTimeAtSite = GetCurrentTimeAtSite(formGn75B.FunctionalLocation);
            formGn75B.LastModifiedDateTime = currentTimeAtSite;

            formGn75B.SiteID = formGn75B.FunctionalLocation.Site.IdValue;   //ayman show closed form

            formGN75BDao.Update(formGn75B);
            editHistoryService.TakeSnapshot(formGn75B);

            if (addDocumentLinkAssociation)
            {
                InsertGN75BUserReadDocumentLinkAssociation(formGn75B.IdValue, formGn75B.LastModifiedBy.IdValue);
            }

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75BUpdate, formGn75B)
            };

            return notifiedEvents;
        }
        
        public List<NotifiedEvent> RemoveGN75B(FormGN75B form, User user)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocation.Site);
            form.LastModifiedBy = user;

            if(form.FormType.Name == "EIP Template")
            {
                formGN75BDao.RemoveTemplate(form);
                return new List<NotifiedEvent> { ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75BTemplateRemove, form) };
            }
            else
            {
                if (form.FormType.Name == "EIP Issue")
                {
                    formGN75BDao.RemoveSarniaEip(form);           //ayman Sarnia eip - 3
                }
                else
                {
                    formGN75BDao.Remove(form);
                }
                return new List<NotifiedEvent> { ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN75BRemove, form) };
            }

        }

        //ayman generic forms
        public FormGN75B QueryFormGN75BByIdAndSiteId(long id, long siteid)
        {
            return formGN75BDao.QueryByIdAndSiteId(id, siteid);
        }

        //ayman Sarnia eip DMND0008992
        public FormGN75B QueryFormGN75BSarniaByIdAndSiteId(long id, long siteid)
        {
            return formGN75BDao.QuerySarniaFormByIdAndSiteId(id, siteid);
        }


        //ayman Sarnia eip DMND0008992
        public FormGN75B QueryFormGN75BTemplateByIdAndSiteId(long id, long siteid)
        {
            return formGN75BDao.QueryTemplateByIdAndSiteId(id, siteid);
        }

        //ayman Sarnia eip DMND0008992
        public List<FormEdmontonGN75BDTO> QueryApprovedTemplateToShowEipFormsQueryApprovedTemplateToShowEipForms(long id, long siteid)
        {
            return gn75BDTODao.QueryApprovedTemplateDTOs(id, siteid);
        }

        public FormGN75B QueryFormGN75BSarniaById(long id)
        {
            return formGN75BDao.QueryGN75BSarniaById(id);
        }

        public FormGN75B QueryFormGN75BById(long id)
        {
            return formGN75BDao.QueryById(id);
        }

        public List<FormEdmontonGN75BDTO> QueryFormGN75BDTOsByCriteria(IFlocSet flocSet, List<FormStatus> formStatuses, long siteId)
        {
            return gn75BDTODao.QueryDTOs(flocSet, formStatuses, siteId);
        }

        //ayman Sarnia eip DMND0008992
        public List<FormEdmontonGN75BDTO> QueryFormGN75BSarniaFormDTOsByCriteria(IFlocSet flocSet, List<FormStatus> formStatuses, long siteId)
        {
            return gn75BDTODao.QuerySarniaFormDTOs(flocSet, formStatuses, siteId);
        }

        //ayman Sarnia eip DMND0008992
        public List<FormEdmontonGN75BDTO> QueryFormGN75BTemplateDTOsByCriteria(IFlocSet flocSet, List<FormStatus> formStatuses)
        {
            return gn75BDTODao.QueryTemplateDTOs(flocSet, formStatuses);
        }

        public FormEdmontonGN75BDTO QueryFormGN75BDTOById(long id)
        {
            return gn75BDTODao.QueryById(id);
        }

        public List<long> QueryAllGN75AFormsAssociatedToFormGN75B(long gn75BFormId)
        {
            return formGN75BDao.QueryGn75AFormsAssociatedToFormGn75BById(gn75BFormId);
        }

        public bool GN75AIsAssociatedToAnIssuedWorkPermit(List<long> idsForSelectedItems)
        {
            foreach (var gn75AId in idsForSelectedItems)
            {
                var dtosOfAssociatedPermits =
                    workPermitEdmontonService.QueryDtosByFormGN75AId(gn75AId);

                if (dtosOfAssociatedPermits.Exists(dto => PermitRequestBasedWorkPermitStatus.Issued.Equals(dto.Status)))
                {
                    return true;
                }
            }

            return false;
        }

        public bool GN75BIsAssociatedToAGN75AOrActionItem(List<long> idsForSelectedItems)
        {
            foreach (var gn75BId in idsForSelectedItems)
            {
                var gn75AIds = QueryAllGN75AFormsAssociatedToFormGN75B(gn75BId);

                if (gn75AIds.Count > 0)
                {
                    return true;
                }

                var count = actionItemDefinitionService.QueryCountByGN75BId(gn75BId);

                if (count > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public List<NotifiedEvent> InsertGN1(FormGN1 form)
        {
            var lastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocation);
            form.LastModifiedDateTime = lastModifiedDateTime;
            form.TradeChecklists.ForEach(tc => tc.LastModifiedDateTime = lastModifiedDateTime);
            formGN1Dao.Insert(form);

            editHistoryService.TakeSnapshot(form);
            editHistoryService.TakeSnapshot(form.TradeChecklists);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN1Create, form));
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateGN1(FormGN1 form, LabelAttributes labelAttributes)
        {
            var currentTimeAtSite = GetCurrentTimeAtSite(form.FunctionalLocation);
            form.LastModifiedDateTime = currentTimeAtSite;
            form.TradeChecklists.ForEach(tc => tc.LastModifiedDateTime = currentTimeAtSite);
            formGN1Dao.Update(form);

            editHistoryService.TakeSnapshot(form);
            editHistoryService.TakeSnapshot(form.TradeChecklists);

            var allNotifiedEvents = new List<NotifiedEvent>();
            var workPermitEvents = new List<NotifiedEvent>();

            if (form.IsApproved())
            {
                allNotifiedEvents.AddRange(CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(form));
                workPermitEvents.AddRange(CheckAssociatedWorkPermitsAndMarkAsCompleteIfPossible(form,
                    labelAttributes,
                    id => workPermitEdmontonService.QueryByFormGN1Id(id)));
            }
            else if (form.IsDraft())
            {
                workPermitEvents.AddRange(ChangeAssociatedPermitsFromPendingToRequested(form,
                    currentTimeAtSite,
                    id => workPermitEdmontonService.QueryByFormGN1Id(id)));
                allNotifiedEvents.AddRange(ChangePermitRequestStatusForDraftForm(form,
                    currentTimeAtSite,
                    id => permitRequestEdmontonService.QueryByFormGN1Id(id)));
            }



            var cseRelatedWorkPermitEvents = MarkPermitAsRequestedIfCSELevelHasChangedOnForm(form,
                currentTimeAtSite);
            var newWorkPermitEventList = RemoveDuplicateWorkPermitEventsAndMakeOneList(
                workPermitEvents,
                cseRelatedWorkPermitEvents);

            allNotifiedEvents.AddRange(newWorkPermitEventList);

            allNotifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN1Update, form));
            return allNotifiedEvents;
        }

        public List<NotifiedEvent> InsertOvertimeForm(OvertimeForm overtimeForm)
        {
            overtimeFormDao.Insert(overtimeForm);
            editHistoryService.TakeSnapshot(overtimeForm);

            var events = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.OvertimeFormCreate, overtimeForm)
            };

            onPremisePersonnelService.InsertOnPremisePersonnel(overtimeForm);

            return events;
        }

        public List<NotifiedEvent> UpdateOvertimeForm(OvertimeForm overtimeForm)
        {
            var currentTimeAtSite = GetCurrentTimeAtSite(overtimeForm.FunctionalLocation);
            overtimeForm.LastModifiedDateTime = currentTimeAtSite;

            var oldOvertimeForm = overtimeFormDao.QueryById(overtimeForm.IdValue);

            overtimeFormDao.Update(overtimeForm);
            editHistoryService.TakeSnapshot(overtimeForm);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.OvertimeFormUpdate, overtimeForm)
            };

            if (overtimeForm.FormStatus == FormStatus.Cancelled)
            {
                onPremisePersonnelService.RemoveOnPremisePersonnel(overtimeForm);
            }
            else
            {
                onPremisePersonnelService.UpdateOnPremisePersonnel(oldOvertimeForm, overtimeForm);
            }

            return notifiedEvents;
        }

        public IList<OnPremisePersonnelSupervisorDTO> QueryOnPremisePersonnelSupervisorView(Range<DateTime> range,
            Site site)
        {
            var onPremisePersonnel =
                onPremisePersonnelDtoDao.QuerySupervisorViewDtos(range);

            try
            {
                // only read for swipe system if there are records to check against.
                var cardsFromSwipeCardSystem = onPremisePersonnel.Count > 0
                    ? swipeCardReader.GetCardsFromSwipeCardSystem(2)
                    : new List<EdmontonPerson>(0);

                var currentTimeAtSite = GetCurrentTimeAtSite(site);

                foreach (var dto in onPremisePersonnel)
                {
                    var cardEntryStatus =
                        OnPremisePersonnelService.CreateCardStatus(cardsFromSwipeCardSystem,
                            dto.PersonnelName,
                            currentTimeAtSite);
                    dto.CardEntryStatus = cardEntryStatus;
                }
            }
            catch (EdmontonCardSwipeSystemReadException ex)
            {
                logger.Warn("Issue reading card statuses. Setting all to Unknown.", ex);
            }
            return onPremisePersonnel;
        }

        public IList<OnPremisePersonnelAuditDTO> QueryOnPremisePersonnelAuditView(Range<Date> range)
        {
            return onPremisePersonnelDtoDao.QueryAuditViewDtos(range);
        }

        public IList<OnPremisePersonnelShiftReportDTO> QueryOnPremisePersonnelShiftReport(
            Range<DateTime> reportingPeriod)
        {
            var edmontonRefinerySite = siteService.QueryById(Site.EDMONTON_ID);
            var edmontonRefineryShiftPatterns =
                shiftPatternService.QueryBySite(edmontonRefinerySite).OrderBy(pattern => pattern.StartTime).ToList();
            return new List<OnPremisePersonnelShiftReportDTO>
            {
                new OnPremisePersonnelShiftReportDTO(reportingPeriod,
                    edmontonRefineryShiftPatterns,
                    onPremisePersonnelDtoDao.QueryOnPremisePersonnelShiftReportDetailDtos(reportingPeriod))
            };
        }

        public List<NotifiedEvent> InsertLubesCsd(LubesCsdForm lubesCsdForm)
        {
            lubesCsdForm.LastModifiedDateTime = GetCurrentTimeAtSite(lubesCsdForm.FunctionalLocation);
            var insertResult = lubesCsdDao.Insert(lubesCsdForm);

            editHistoryService.TakeSnapshot(insertResult);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormLubesCsdCreate, lubesCsdForm)
            };
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateLubesCsd(LubesCsdForm form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocation);
            lubesCsdDao.Update(form);

            editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormLubesCsdUpdate, form)
            };
            return notifiedEvents;
        }

        //ayman generic forms
        public LubesCsdForm QueryLubesCsdFormByIdAndSiteId(long id, long siteid)
        {
            return lubesCsdDao.QueryById(id);  // remove site id for lubes csd form
        }


        public LubesCsdForm QueryLubesCsdFormById(long id)
        {
            return lubesCsdDao.QueryById(id);
        }

        public List<NotifiedEvent> RemoveLubesCsdForm(LubesCsdForm form)
        {
            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocation);
            lubesCsdDao.Remove(form);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormLubesCsdRemove, form)
            };
            return notifiedEvents;
        }

        public IList<LubesCsdFormDTO> QueryLubesCsdFormDTOs(RootFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return lubesCsdFormDTODao.QueryFormCsd(flocSet, dateRange, formStatuses,
                includeAllDraftFormsRegardlessOfDateRange);
        }

        public List<NotifiedEvent> InsertLubesAlarmDisable(LubesAlarmDisableForm lubesAlarmDisableForm)
        {
            lubesAlarmDisableForm.LastModifiedDateTime = GetCurrentTimeAtSite(lubesAlarmDisableForm.FunctionalLocation);
            var insertResult = lubesAlarmDisableDao.Insert(lubesAlarmDisableForm);

            editHistoryService.TakeSnapshot(insertResult);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormLubesAlarmDisableCreate, lubesAlarmDisableForm)
            };
            return notifiedEvents;
        }

        public List<NotifiedEvent> UpdateLubesAlarmDisable(LubesAlarmDisableForm lubesAlarmDisableForm)
        {
            lubesAlarmDisableForm.LastModifiedDateTime = GetCurrentTimeAtSite(lubesAlarmDisableForm.FunctionalLocation);
            lubesAlarmDisableDao.Update(lubesAlarmDisableForm);

            editHistoryService.TakeSnapshot(lubesAlarmDisableForm);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormLubesAlarmDisableUpdate, lubesAlarmDisableForm)
            };
            return notifiedEvents;
        }

        public List<NotifiedEvent> RemoveLubesAlarmDisable(LubesAlarmDisableForm lubesAlarmDisableForm)
        {
            lubesAlarmDisableForm.LastModifiedDateTime = GetCurrentTimeAtSite(lubesAlarmDisableForm.FunctionalLocation);
            lubesAlarmDisableDao.Remove(lubesAlarmDisableForm);

            var notifiedEvents = new List<NotifiedEvent>
            {
                ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormLubesAlarmDisableRemove, lubesAlarmDisableForm)
            };
            return notifiedEvents;
        }

        //ayman generic forms
        public LubesAlarmDisableForm QueryLubesAlarmDisableFormByIdAndSiteId(long id, long siteid)
        {
            return lubesAlarmDisableDao.QueryById(id);    //ayman disable siteid
        }

        public LubesAlarmDisableForm QueryLubesAlarmDisableFormById(long id)
        {
            return lubesAlarmDisableDao.QueryById(id);
        }

        //ayman generic forms
        public PermitAssessment QueryPermitAssessmentFormByIdAndSiteId(long id, long siteid)
        {
            return formPermitAssessmentDao.QueryByIdAndSiteId(id, siteid);
        }


        public PermitAssessment QueryPermitAssessmentFormById(long id)
        {
            return formPermitAssessmentDao.QueryById(id);
        }

        public IList<EdmontonOvertimeFormDTO> QueryOvertimeFormsByCriteria(DateRange dateRange)
        {
            return overtimeFormDTODao.QueryDTOs(dateRange);
        }

        public List<NotifiedEvent> RemoveGN1(FormGN1 form, User user)
        {
            var notifiedEvents = new List<NotifiedEvent>();

            form.LastModifiedDateTime = GetCurrentTimeAtSite(form.FunctionalLocation);
            form.LastModifiedBy = user;

            formGN1Dao.Remove(form);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormGN1Remove, form));
            return notifiedEvents;
        }

        public List<FormEdmontonGN1DTO> QueryFormGN1DTOsByCriteria(IFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return gn1DTODao.QueryDTOs(flocSet, dateRange, formStatuses, includeAllDraftFormsRegardlessOfDateRange);
        }

        public List<TradeChecklistInfo> QueryFormGN1TradeChecklistDisplayItemsByFormGN1Id(long formGn1Id)
        {
            var gn1 = formGN1Dao.QueryById(formGn1Id);

            var result = new List<TradeChecklistInfo>();
            gn1.TradeChecklists.ForEach(tc => result.Add(new TradeChecklistInfo(tc)));
            return result;
        }


        //ayman generic forms
        public FormGN1 QueryFormGN1ByIdAndSiteId(long id, long siteid)
        {
            return formGN1Dao.QueryByIdAndSiteId(id, siteid);
        }

        public FormGN1 QueryFormGN1ById(long id)
        {
            return formGN1Dao.QueryById(id);
        }

        public int GetNextTradeChecklistSequenceNumber(long formGN1Id)
        {
            var maxSequenceNumber = formGN1Dao.GetMaxTradeChecklistSequenceNumber(formGN1Id);
            return maxSequenceNumber == null ? 1 : maxSequenceNumber.Value + 1;
        }

        public void InsertGN75BUserReadDocumentLinkAssociation(long formGN75BId, long userId)
        {
            
            var userReadDocumentLinkAssociationAlreadyExists = formGN75BDao.HasUserReadAtLeastOneDocumentLink(userId,
                formGN75BId);
            if (!userReadDocumentLinkAssociationAlreadyExists)
            {
                formGN75BDao.InsertUserReadDocumentLinkAssociation(userId, formGN75BId);
            }
        }

        //INC0453097 Aarti
        public void InsertGN75BUserReadDocumentLinkAssociationSarnia(long formGN75BSarniaId, long userId)
        {
            var userReadDocumentLinkAssociationAlreadyExists = formGN75BDao.HasUserReadAtLeastOneDocumentLinkSarnia(userId,
                formGN75BSarniaId);
            if (!userReadDocumentLinkAssociationAlreadyExists)
            {
                formGN75BDao.InsertUserReadDocumentLinkAssociationSarnia(userId, formGN75BSarniaId);
            }
        }

        //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        public void InsertGN75BUserReadDocumentLinkAssociationTemplateSarnia(long formGN75BTemplateId, long userId)
        {
            var userReadDocumentLinkAssociationAlreadyExists = formGN75BDao.HasUserReadAtLeastOneDocumentLinkTemplateSarnia(userId,
                formGN75BTemplateId);
            if (!userReadDocumentLinkAssociationAlreadyExists)
            {
                formGN75BDao.InsertUserReadDocumentLinkAssociationTemplateSarnia(userId, formGN75BTemplateId);
            }
        }

        public bool HasUserReadAtLeastOneDocumentLinkOnFormGN75B(long userId, long formGN75BId)
        {
            return formGN75BDao.HasUserReadAtLeastOneDocumentLink(userId, formGN75BId);
        }
        //INC0453097 Aarti
        public bool HasUserReadAtLeastOneDocumentLinkOnFormGN75BSarnia(long userId, long formGN75BSarniaId)
        {
            return formGN75BDao.HasUserReadAtLeastOneDocumentLinkSarnia(userId, formGN75BSarniaId);
        }

        //INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
        public bool HasUserReadAtLeastOneDocumentLinkOnFormGN75BTemplateSarnia(long userId, long formGN75BTemplateId)
        {
            return formGN75BDao.HasUserReadAtLeastOneDocumentLinkSarnia(userId, formGN75BTemplateId);
        }

        public bool HasUserReadAtLeastOneDocumentLinkOnEveryFormGN75BInList(long userId, List<long> formGN75BIdValues)
        {
            var totalForms = formGN75BIdValues.Count;
            var formsWithReadDocumentLinks = 0;

            foreach (var formId in formGN75BIdValues)
            {
                if (formGN75BDao.HasUserReadAtLeastOneDocumentLink(userId, formId))
                {
                    formsWithReadDocumentLinks++;
                }
            }

            return totalForms == formsWithReadDocumentLinks;
        }
        //INC0453097 Aarti
        public bool HasUserReadAtLeastOneDocumentLinkOnEveryFormGN75BInListSarnia(long userId, List<long> formGN75BSarniaIdValues)
        {
            var totalForms = formGN75BSarniaIdValues.Count;
            var formsWithReadDocumentLinks = 0;

            foreach (var formId in formGN75BSarniaIdValues)
            {
                if (formGN75BDao.HasUserReadAtLeastOneDocumentLinkSarnia(userId, formId))
                {
                    formsWithReadDocumentLinks++;
                }
            }

            return totalForms == formsWithReadDocumentLinks;
        }

        //ayman generic forms
        public OvertimeForm QueryOvertimeFormByIdAndSiteId(long id, long siteid)
        {
            return overtimeFormDao.QueryByIdAndSiteId(id, siteid);
        }

        public OvertimeForm QueryOvertimeFormById(long id)
        {
            return overtimeFormDao.QueryById(id);
        }

        public IList<LubesAlarmDisableFormDTO> QueryLubesAlarmDisableFormDTOs(RootFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            return lubesAlarmDisableFormDTODao.QueryFormAlarmDisable(flocSet, dateRange, formStatuses,
                includeAllDraftFormsRegardlessOfDateRange);
        }

        public List<PermitAssessmentDTO> QueryOilsandsPermitAssessmentDtos(RootFlocSet flocSet, DateRange dateRange)
        {
            return formPermitAssessmentDTODao.QueryPermitAssessmentDtos(flocSet, dateRange);
        }

        public string GetFormGN6WorkerResponsibilitiesText()
        {
            return formGN6Dao.WorkersResponsibilitiesTemplateText();
        }

        private Comparison<FormEdmontonDTO> SortByCreatedDateDescending()
        {
            return (dto1, dto2) => dto1.CreatedDateTime.CompareTo(dto2.CreatedDateTime) * -1;
        }

        private Comparison<FormEdmontonDTO> SortByDateFromDescending()
        {
            return (dto1, dto2) => dto1.ValidFrom.CompareTo(dto2.ValidFrom) * -1;
        }

        private Comparison<FormEdmontonDTO> SortByDateFromAscending()
        {
            return (dto1, dto2) => dto1.ValidFrom.CompareTo(dto2.ValidFrom);
        }

        private List<NotifiedEvent> CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(FormGN6 form)
        {
            var permitRequests = permitRequestEdmontonService.QueryByFormGN6Id(form.IdValue);
            return MarkAsCompleteIfPossible(permitRequests);
        }

        private List<NotifiedEvent> CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(FormGN7 form)
        {
            var permitRequests = permitRequestEdmontonService.QueryByFormGN7Id(form.IdValue);
            return MarkAsCompleteIfPossible(permitRequests);
        }

        private List<NotifiedEvent> CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(FormGN59 form)
        {
            var permitRequests = permitRequestEdmontonService.QueryByFormGN59Id(form.IdValue);
            return MarkAsCompleteIfPossible(permitRequests);
        }

        private List<NotifiedEvent> CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(FormGN24 form)
        {
            var permitRequests = permitRequestEdmontonService.QueryByFormGN24Id(form.IdValue);
            return MarkAsCompleteIfPossible(permitRequests);
        }

        private List<NotifiedEvent> CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(FormGN75A form)
        {
            var permitRequests = permitRequestEdmontonService.QueryByFormGN75AId(form.IdValue);
            return MarkAsCompleteIfPossible(permitRequests);
        }

        private List<NotifiedEvent> CheckAssociatedPermitRequestsAndMarkAsCompleteIfPossible(FormGN1 form)
        {
            var permitRequests = permitRequestEdmontonService.QueryByFormGN1Id(form.IdValue);
            return MarkAsCompleteIfPossible(permitRequests);
        }

        private List<NotifiedEvent> CheckAssociatedWorkPermitsAndMarkAsCompleteIfPossible(BaseEdmontonForm form,
            LabelAttributes attributesForHazardsLabel,
            QueryPermitsByFormIdDelegate queryPermitsByFormIdDelegate)
        {
            var permits = queryPermitsByFormIdDelegate(form.IdValue);
            return MarkAsCompleteIfPossible(permits, attributesForHazardsLabel);
        }

        private List<NotifiedEvent> MarkAsCompleteIfPossible(List<PermitRequestEdmonton> permitRequests)
        {
            var notifiedEvents = new List<NotifiedEvent>();

            var systemUser = userService.GetRemoteAppUser();
            DateTime? currentTimeAtSite = null;

            foreach (var permitRequest in permitRequests)
            {
                if (currentTimeAtSite == null)
                {
                    currentTimeAtSite = timeService.GetTime(permitRequest.FunctionalLocation.Site.TimeZone);
                }

                var permitRequestCompletionStatus = permitRequest.DetectIsComplete();
                if (PermitRequestCompletionStatus.Complete.Equals(permitRequestCompletionStatus))
                {
                    permitRequest.CompletionStatus = PermitRequestCompletionStatus.Complete;
                    permitRequest.LastModifiedDateTime = currentTimeAtSite.Value;
                    permitRequest.LastModifiedBy = systemUser;
                    notifiedEvents.AddRange(permitRequestEdmontonService.Update(permitRequest));
                }
            }

            return notifiedEvents;
        }

        private List<NotifiedEvent> MarkAsCompleteIfPossible(List<WorkPermitEdmonton> permits,
            LabelAttributes attributesForHazardsLabel)
        {
            var notifiedEvents = new List<NotifiedEvent>();

            var systemUser = userService.GetRemoteAppUser();
            DateTime? currentDateTimeAtSite = null;

            foreach (var permit in permits)
            {
                if (PermitRequestBasedWorkPermitStatus.Requested.Equals(permit.WorkPermitStatus))
                {
                    if (currentDateTimeAtSite == null)
                    {
                        currentDateTimeAtSite = timeService.GetTime(permit.FunctionalLocation.Site.TimeZone);
                    }

                    var validator =
                        new WorkPermitEdmontonValidator(new WorkPermitEdmontonValidationDomainAdapter(permit),
                            attributesForHazardsLabel);
                    validator.ValidateAndSetErrors(currentDateTimeAtSite.Value);

                    if (!validator.HasWarnings)
                    {
                        permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
                        permit.LastModifiedDateTime = currentDateTimeAtSite.Value;
                        permit.LastModifiedBy = systemUser;
                        notifiedEvents.AddRange(workPermitEdmontonService.Update(permit));
                    }
                }
            }

            return notifiedEvents;
        }

        private List<NotifiedEvent> ChangePermitRequestStatusForDraftForm(BaseEdmontonForm form,
            DateTime currentTimeAtSite,
            QueryPermitRequestsByFormIdDelegate queryPermitRequestsByFormIdDelegate)
        {
            var permitRequests = queryPermitRequestsByFormIdDelegate(form.IdValue);
            var notifiedEvents = new List<NotifiedEvent>();

            var systemUser = userService.GetRemoteAppUser();

            foreach (var permitRequest in permitRequests)
            {
                if (permitRequest.Group.IsTurnaround)
                {
                    permitRequest.CompletionStatus = PermitRequestCompletionStatus.ForReview;
                }
                else
                {
                    permitRequest.CompletionStatus = PermitRequestCompletionStatus.Incomplete;
                }

                permitRequest.LastModifiedBy = systemUser;
                permitRequest.LastModifiedDateTime = currentTimeAtSite;

                notifiedEvents.AddRange(permitRequestEdmontonService.Update(permitRequest));
            }

            return notifiedEvents;
        }

        private List<NotifiedEvent> ChangeAssociatedPermitsFromPendingToRequested(BaseEdmontonForm form,
            DateTime currentTimeAtSite,
            QueryPermitsByFormIdDelegate queryPermitsByFormIdDelegate)
        {
            var notifiedEvents = new List<NotifiedEvent>();
            var systemUser = userService.GetRemoteAppUser();

            var associatedPermits = queryPermitsByFormIdDelegate(form.IdValue);

            foreach (var permit in associatedPermits)
            {
                if (PermitRequestBasedWorkPermitStatus.Pending.Equals(permit.WorkPermitStatus))
                {
                    permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Requested;
                    permit.LastModifiedBy = systemUser;
                    permit.LastModifiedDateTime = currentTimeAtSite;

                    notifiedEvents.AddRange(workPermitEdmontonService.Update(permit));
                }
            }

            return notifiedEvents;
        }

        private List<NotifiedEvent> RemoveDuplicateWorkPermitEventsAndMakeOneList(List<NotifiedEvent> workPermitEvents,
            List<NotifiedEvent> cseRelatedWorkPermitEvents)
        {
            // Make a list based on the events from marking permits as requested becasue of the CSE level being different
            var singleList = new List<NotifiedEvent>(cseRelatedWorkPermitEvents);

            foreach (var workPermitEvent in workPermitEvents)
            {
                // if the event from a previous action isn't already in the CSE list, add it in. We want the CSE events to take precedence since those domain objects were touched after the others
                if (!singleList.Exists(e => e.DomainObject.IdValue == workPermitEvent.DomainObject.IdValue))
                {
                    singleList.Add(workPermitEvent);
                }
            }

            return singleList;
        }

        private List<NotifiedEvent> MarkPermitAsRequestedIfCSELevelHasChangedOnForm(FormGN1 form,
            DateTime currentTimeAtSite)
        {
            var associatedPermits = workPermitEdmontonService.QueryByFormGN1Id(form.IdValue);
            var notifiedEvents = new List<NotifiedEvent>();

            var systemUser = userService.GetRemoteAppUser();

            foreach (var permit in associatedPermits)
            {
                if (PermitRequestBasedWorkPermitStatus.Pending.Equals(permit.WorkPermitStatus))
                {
                    if (permit.ConfinedSpaceClass != null && !permit.ConfinedSpaceClass.Equals(form.CSELevel))
                    {
                        permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Requested;

                        permit.LastModifiedBy = systemUser;
                        permit.LastModifiedDateTime = currentTimeAtSite;

                        notifiedEvents.AddRange(workPermitEdmontonService.Update(permit));
                    }
                }
            }

            return notifiedEvents;
        }

        private DateTime GetCurrentTimeAtSite(FunctionalLocation flocFromSite)
        {
            return GetCurrentTimeAtSite(flocFromSite.Site);
        }

        private DateTime GetCurrentTimeAtSite(Site site)
        {
            return timeService.GetTime(site.TimeZone);
        }

        private delegate List<PermitRequestEdmonton> QueryPermitRequestsByFormIdDelegate(long formId);

        private delegate List<WorkPermitEdmonton> QueryPermitsByFormIdDelegate(long formId);

        /*RITM0265746 - Sarnia CSD marked as read start*/

        public void InsertFormOp14MarkAsRead(long id, long userId, DateTime datetimenow, long shiftId)
        {
            formOP14Dao.InsertFormOp14MarkAsRead(id, userId, datetimenow, shiftId);  
        }

        public List<ItemReadBy> UserMarkedFormOp14AsRead(long formOp14Id, long? userId, long shiftId)
        {
            return formOP14Dao.UserMarkedFormOp14AsRead(formOp14Id, userId, shiftId);
        }

        //Added By Vibhor : RITM0613645 : OLT - Mark as read tick mark for sarnia CSD

        public List<ItemReadBy> UserMarkedFormOp14AsReadOnPriorityPage(long formOp14Id, long? userId, long shiftId, Date date)
        {
            return formOP14Dao.UserMarkedFormOp14AsReadOnPriorityPage(formOp14Id, userId, shiftId, date);
        }

        //public List<CSDMarkAsReadReportItem> MarkedAsReadFormOp14Report(Date startDate, Date endDate)
        //{
        //    return formOP14Dao.GetFormOP14MarkedAsReadReport(startDate, endDate);
        //}
        //Added by ppanigrahi
        public List<NotifiedEvent> UpdateOP14Email(long Id, long sitId, int uid, int statusid)
        {
            formOP14Dao.UpdateEmail(Id, sitId, uid, statusid);
            //editHistoryService.TakeSnapshot(form);

            var notifiedEvents = new List<NotifiedEvent>();
            // notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormOP14Update, form));
            return notifiedEvents;
        }
       
        public long QueryUserId(string username)
        {

            return formOP14Dao.QueryByUserName(username);
        }

        public long QueryByFormOp14ApprovalId(long? Id, string approver)
        {

            return formOP14Dao.QueryByFormOp14ApprovalId(Id, approver);

        }
        
    }
}