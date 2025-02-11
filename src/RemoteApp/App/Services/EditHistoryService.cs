using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class EditHistoryService : IEditHistoryService
    {
        private const int MAX_RECENT_HISTORY_COUNT = 5;

        private readonly IActionItemDefinitionHistoryDao actionItemDefinitionHistoryDao;
        private readonly ICokerCardConfigurationDao cokerCardConfigurationDao;
        private readonly ICokerCardHistoryDao cokerCardHistoryDao;
        private readonly IConfinedSpaceHistoryDao confinedSpaceHistoryDao;
        private readonly ICustomFieldDao customFieldDao;
        private readonly IDeviationAlertResponseHistoryDao deviationAlertResponseHistoryDao;
        private readonly IDirectiveHistoryDao directiveHistoryDao;
        private readonly IDocumentSuggestionHistoryDao documentSuggestionHistoryDao;
        private readonly IProcedureDeviationHistoryDao procedureDeviationHistoryDao;
        private readonly IExcursionResponseHistoryDao excursionResponseHistoryDao;
        private readonly IFunctionalLocationOperationalModeHistoryDao flocOpModeHistoryDao;
        private readonly IFormGN1HistoryDao formGN1HistoryDao;
        private readonly IFormGN24HistoryDao formGN24HistoryDao;
        private readonly IFormGN59HistoryDao formGN59HistoryDao;
        private readonly IFormGN6HistoryDao formGN6HistoryDao;
        private readonly IFormGN75AHistoryDao formGN75AHistoryDao;
        private readonly IFormGN75BHistoryDao formGN75BHistoryDao;
        private readonly IFormGN7HistoryDao formGN7HistoryDao;
        private readonly ILubesAlarmDisableHistoryDao formLubesAlarmDisableHistoryDao;
        private readonly IFormLubesCsdHistoryDao formLubesCsdHistoryDao;
        private readonly IFormOP14HistoryDao formOP14HistoryDao;
        private readonly IFormGenericTemplateHistoryDao formGenericTemplateHistoryDao;//generic template - mangesh
        private readonly IFormOilsandsTrainingHistoryDao formOilsandsTrainingHistoryDao;
        private readonly IFormOvertimeFormHistoryDao formOvertimeFormHistoryDao;
        private readonly IGasTestElementInfoConfigurationHistoryDao gasTestElementInfoConfigurationHistoryDao;
        private readonly ILabAlertDefinitionHistoryDao labAlertDefinitionHistoryDao;
        private readonly ILogDefinitionHistoryDao logDefinitionHistoryDao;
        private readonly ILogHistoryDao logHistoryDao;
        private readonly IMontrealCsdHistoryDao montrealCsdHistoryDao;
        private readonly IGenericCsdHistoryDao genericCsdHistoryDao; // //DMND0011225 CSD for WBR
        private readonly IOpmToeDefinitionCommentHistoryDao opmToeDefinitionCommentHistoryDao;
        private readonly IPermitAssessmentHistoryDao permitAssessmentHistoryDao;
        private readonly IPermitRequestEdmontonHistoryDao permitRequestEdmontonHistoryDao;
        private readonly IPermitRequestMontrealHistoryDao permitRequestHistoryDao;
        private readonly IPermitRequestLubesHistoryDao permitRequestLubesHistoryDao;
        private readonly IShiftHandoverQuestionnaireHistoryDao questionnaireHistoryDao;
        private readonly IRestrictionDefinitionHistoryDao restrictionDefinitionHistoryDao;
        private readonly ISummaryLogHistoryDao summaryLogHistoryDao;
        private readonly ITargetDefinitionHistoryDao targetDefinitionHistoryDao;
        private readonly ITradeChecklistHistoryDao tradeChecklistHistoryDao;
        private readonly IWorkPermitEdmontonHistoryDao workPermitEdmontonHistoryDao;
        private readonly IWorkPermitHistoryDao workPermitHistoryDao;
        private readonly IWorkPermitLubesHistoryDao workPermitLubesHistoryDao;
        private readonly IWorkPermitMontrealHistoryDao workPermitMontrealHistoryDao;
        private readonly ITemporaryInstallationsMudsHistoryDao temporaryInstallationsHistoryDao; //RITM0268131 - mangesh
        private readonly IPermitRequestFortHillsHistoryDao permitRequestFortHillsHistoryDao;
        private readonly IWorkPermitFortHillsHistoryDao workPermitFortHillsHistoryDao;
        private readonly IWorkPermitMudsHistoryDao workPermitMudsHistoryDao; //RITM0301321 mangesh
        private readonly IConfinedSpaceMudsHistoryDao confinedSpaceMudsHistoryDao; //RITM0301321 - mangesh
        private readonly IPermitRequestMudsHistoryDao permitRequestMudsHistoryDao;

        public EditHistoryService()
            : this(DaoRegistry.GetDao<IActionItemDefinitionHistoryDao>(),
                DaoRegistry.GetDao<ILogHistoryDao>(),
                DaoRegistry.GetDao<ISummaryLogHistoryDao>(),
                DaoRegistry.GetDao<IWorkPermitHistoryDao>(),
                DaoRegistry.GetDao<IWorkPermitMontrealHistoryDao>(),
                DaoRegistry.GetDao<ITargetDefinitionHistoryDao>(),
                DaoRegistry.GetDao<IRestrictionDefinitionHistoryDao>(),
                DaoRegistry.GetDao<IDeviationAlertResponseHistoryDao>(),
                DaoRegistry.GetDao<ILogDefinitionHistoryDao>(),
                DaoRegistry.GetDao<IGasTestElementInfoConfigurationHistoryDao>(),
                DaoRegistry.GetDao<IFunctionalLocationOperationalModeHistoryDao>(),
                DaoRegistry.GetDao<IShiftHandoverQuestionnaireHistoryDao>(),
                DaoRegistry.GetDao<ILabAlertDefinitionHistoryDao>(),
                DaoRegistry.GetDao<ICokerCardHistoryDao>(),
                DaoRegistry.GetDao<ICokerCardConfigurationDao>(),
                DaoRegistry.GetDao<IPermitRequestMontrealHistoryDao>(),
                DaoRegistry.GetDao<IConfinedSpaceHistoryDao>(),
                DaoRegistry.GetDao<IWorkPermitEdmontonHistoryDao>(),
                DaoRegistry.GetDao<IPermitRequestEdmontonHistoryDao>(),
                DaoRegistry.GetDao<IFormOvertimeFormHistoryDao>(),
                DaoRegistry.GetDao<IFormGN7HistoryDao>(),
                DaoRegistry.GetDao<IFormGN59HistoryDao>(),
                DaoRegistry.GetDao<IFormOP14HistoryDao>(),
                DaoRegistry.GetDao<IFormGenericTemplateHistoryDao>(),//generic template - mangesh
                DaoRegistry.GetDao<IFormGN24HistoryDao>(),
                DaoRegistry.GetDao<IFormGN6HistoryDao>(),
                DaoRegistry.GetDao<IFormGN75AHistoryDao>(),
                DaoRegistry.GetDao<IFormGN75BHistoryDao>(),
                DaoRegistry.GetDao<IFormGN1HistoryDao>(),
                DaoRegistry.GetDao<ITradeChecklistHistoryDao>(),
                DaoRegistry.GetDao<IFormOilsandsTrainingHistoryDao>(),
                DaoRegistry.GetDao<ICustomFieldDao>(),
                DaoRegistry.GetDao<IWorkPermitLubesHistoryDao>(),
                DaoRegistry.GetDao<IPermitRequestLubesHistoryDao>(),
                DaoRegistry.GetDao<IDirectiveHistoryDao>(),
                DaoRegistry.GetDao<IFormLubesCsdHistoryDao>(),
                DaoRegistry.GetDao<ILubesAlarmDisableHistoryDao>(),
                DaoRegistry.GetDao<IMontrealCsdHistoryDao>(),
                DaoRegistry.GetDao<IExcursionResponseHistoryDao>(),
                DaoRegistry.GetDao<IOpmToeDefinitionCommentHistoryDao>(),
                DaoRegistry.GetDao<IPermitAssessmentHistoryDao>(),
                DaoRegistry.GetDao<IDocumentSuggestionHistoryDao>(),
                DaoRegistry.GetDao<IProcedureDeviationHistoryDao>(),
                DaoRegistry.GetDao<ITemporaryInstallationsMudsHistoryDao>(),
                DaoRegistry.GetDao<IPermitRequestFortHillsHistoryDao>(),
                DaoRegistry.GetDao<IWorkPermitMudsHistoryDao>(), //RITM0301321 mangesh
                DaoRegistry.GetDao<IConfinedSpaceMudsHistoryDao>(), //RITM0301321 - mangesh
                DaoRegistry.GetDao<IPermitRequestMudsHistoryDao>(),  //RITM0301321 - mangesh
                DaoRegistry.GetDao<IWorkPermitFortHillsHistoryDao>()
            )
        {
        }

        public EditHistoryService(IActionItemDefinitionHistoryDao actionItemDefinitionHistoryDao,
            ILogHistoryDao logHistoryDao, ISummaryLogHistoryDao summaryLogHistoryDao,
            IWorkPermitHistoryDao workPermitHistoryDao, IWorkPermitMontrealHistoryDao workPermitMontrealHistoryDao,
            ITargetDefinitionHistoryDao targetDefinitionHistoryDao,
            IRestrictionDefinitionHistoryDao restrictionDefinitionHistoryDao,
            IDeviationAlertResponseHistoryDao deviationAlertResponseHistoryDao,
            ILogDefinitionHistoryDao logDefinitionHistoryDao,
            IGasTestElementInfoConfigurationHistoryDao gasTestElementInfoConfigurationHistoryDao,
            IFunctionalLocationOperationalModeHistoryDao flocOpModeHistoryDao,
            IShiftHandoverQuestionnaireHistoryDao questionnaireHistoryDao,
            ILabAlertDefinitionHistoryDao labAlertDefinitionHistoryDao, ICokerCardHistoryDao cokerCardHistoryDao,
            ICokerCardConfigurationDao cokerCardConfigurationDao,
            IPermitRequestMontrealHistoryDao permitRequestHistoryDao, IConfinedSpaceHistoryDao confinedSpaceHistoryDao,
            IWorkPermitEdmontonHistoryDao workPermitEdmontonHistoryDao,
            IPermitRequestEdmontonHistoryDao permitRequestEdmontonHistoryDao,
            IFormOvertimeFormHistoryDao formOvertimeHistoryDao, IFormGN7HistoryDao formGN7HistoryDao,
            IFormGN59HistoryDao formGN59HistoryDao, IFormOP14HistoryDao formOP14HistoryDao,
            IFormGenericTemplateHistoryDao formGenericTemplateHistoryDao, // generic template - mangesh
            IFormGN24HistoryDao formGN24HistoryDao, IFormGN6HistoryDao formGN6HistoryDao,
            IFormGN75AHistoryDao formGN75AHistoryDao, IFormGN75BHistoryDao formGN75BHistoryDao,
            IFormGN1HistoryDao formGN1HistoryDao, ITradeChecklistHistoryDao tradeChecklistHistoryDao,
            IFormOilsandsTrainingHistoryDao formOilsandsTrainingHistoryDao, ICustomFieldDao customFieldDao,
            IWorkPermitLubesHistoryDao workPermitLubesHistoryDao,
            IPermitRequestLubesHistoryDao permitRequestLubesHistoryDao, IDirectiveHistoryDao directiveHistoryDao,
            IFormLubesCsdHistoryDao formLubesCsdHistoryDao, ILubesAlarmDisableHistoryDao formLubesAlarmDisableHistoryDao,
            IMontrealCsdHistoryDao montrealCsdHistoryDao, IExcursionResponseHistoryDao excursionResponseHistoryDao,
            IOpmToeDefinitionCommentHistoryDao opmToeDefinitionCommentHistoryDao,
            IPermitAssessmentHistoryDao permitAssessmentHistoryDao,
            IDocumentSuggestionHistoryDao documentSuggestionHistoryDao,
            IProcedureDeviationHistoryDao procedureDeviationHistoryDao,
            ITemporaryInstallationsMudsHistoryDao temporaryInstallationsHistoryDao, 
            IPermitRequestFortHillsHistoryDao permitRequestFortHillsHistoryDao, 
            IWorkPermitMudsHistoryDao workPermitMudsHistoryDao , //RITM0301321 mangesh
            IConfinedSpaceMudsHistoryDao confinedSpaceMudsHistoryDao,  //RITM0301321 mangesh
            IPermitRequestMudsHistoryDao permitRequestMudsHistoryDao, //RITM0301321 mangesh
            IWorkPermitFortHillsHistoryDao workPermitFortHillsHistoryDao
            )
            
        {
            this.actionItemDefinitionHistoryDao = actionItemDefinitionHistoryDao;
            this.logHistoryDao = logHistoryDao;
            this.summaryLogHistoryDao = summaryLogHistoryDao;
            this.workPermitHistoryDao = workPermitHistoryDao;
            this.workPermitMontrealHistoryDao = workPermitMontrealHistoryDao;
            this.targetDefinitionHistoryDao = targetDefinitionHistoryDao;
            this.restrictionDefinitionHistoryDao = restrictionDefinitionHistoryDao;
            this.deviationAlertResponseHistoryDao = deviationAlertResponseHistoryDao;
            this.logDefinitionHistoryDao = logDefinitionHistoryDao;
            this.gasTestElementInfoConfigurationHistoryDao = gasTestElementInfoConfigurationHistoryDao;
            this.flocOpModeHistoryDao = flocOpModeHistoryDao;
            this.questionnaireHistoryDao = questionnaireHistoryDao;
            this.labAlertDefinitionHistoryDao = labAlertDefinitionHistoryDao;
            this.cokerCardHistoryDao = cokerCardHistoryDao;
            this.cokerCardConfigurationDao = cokerCardConfigurationDao;
            this.permitRequestHistoryDao = permitRequestHistoryDao;
            this.confinedSpaceHistoryDao = confinedSpaceHistoryDao;
            this.workPermitEdmontonHistoryDao = workPermitEdmontonHistoryDao;
            this.permitRequestEdmontonHistoryDao = permitRequestEdmontonHistoryDao;
            formOvertimeFormHistoryDao = formOvertimeHistoryDao;
            this.formGN7HistoryDao = formGN7HistoryDao;
            this.formGN59HistoryDao = formGN59HistoryDao;
            this.formOP14HistoryDao = formOP14HistoryDao;
            this.formGenericTemplateHistoryDao = formGenericTemplateHistoryDao;// generic template - mangesh
            this.formGN24HistoryDao = formGN24HistoryDao;
            this.formGN6HistoryDao = formGN6HistoryDao;
            this.formGN75AHistoryDao = formGN75AHistoryDao;
            this.formGN75BHistoryDao = formGN75BHistoryDao;
            this.formGN1HistoryDao = formGN1HistoryDao;
            this.tradeChecklistHistoryDao = tradeChecklistHistoryDao;
            this.formOilsandsTrainingHistoryDao = formOilsandsTrainingHistoryDao;
            this.customFieldDao = customFieldDao;
            this.workPermitLubesHistoryDao = workPermitLubesHistoryDao;
            this.permitRequestLubesHistoryDao = permitRequestLubesHistoryDao;
            this.directiveHistoryDao = directiveHistoryDao;
            this.formLubesCsdHistoryDao = formLubesCsdHistoryDao;
            this.formLubesAlarmDisableHistoryDao = formLubesAlarmDisableHistoryDao;
            this.montrealCsdHistoryDao = montrealCsdHistoryDao;
            this.excursionResponseHistoryDao = excursionResponseHistoryDao;
            this.opmToeDefinitionCommentHistoryDao = opmToeDefinitionCommentHistoryDao;
            this.permitAssessmentHistoryDao = permitAssessmentHistoryDao;
            this.documentSuggestionHistoryDao = documentSuggestionHistoryDao;
            this.procedureDeviationHistoryDao = procedureDeviationHistoryDao;
            this.temporaryInstallationsHistoryDao = temporaryInstallationsHistoryDao;
            this.permitRequestFortHillsHistoryDao = permitRequestFortHillsHistoryDao;
            this.workPermitMudsHistoryDao = workPermitMudsHistoryDao; //RITM0301321 mangesh
            this.confinedSpaceMudsHistoryDao = confinedSpaceMudsHistoryDao; //RITM0301321 mangesh
            this.permitRequestMudsHistoryDao = permitRequestMudsHistoryDao; //RITM0301321 mangesh
            this.workPermitFortHillsHistoryDao = workPermitFortHillsHistoryDao;
        }

        public List<DomainObjectChangeSet> GetEditHistoryForTargetDefinition(long targetDefinitionId)
        {
            var snapshots = targetDefinitionHistoryDao.GetById(targetDefinitionId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForRestrictionDefinition(long definitionId)
        {
            var snapshots = restrictionDefinitionHistoryDao.GetById(definitionId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForDeviationAlertResponse(long responseId)
        {
            var snapshots = deviationAlertResponseHistoryDao.GetById(responseId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForActionItemDefinition(long actionItemDefinitionId)
        {
            var snapshots = actionItemDefinitionHistoryDao.GetById(actionItemDefinitionId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForLog(long logId)
        {
            var snapshots = logHistoryDao.GetById(logId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForSummaryLog(long summaryLogId)
        {
            var snapshots = summaryLogHistoryDao.GetById(summaryLogId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForLogDefinition(long logDefinitionId)
        {
            var snapshots = logDefinitionHistoryDao.QueryByLogDefinitionId(logDefinitionId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForWorkPermit(long workPermitId)
        {
            var snapshots = workPermitHistoryDao.GetById(workPermitId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForMontrealWorkPermit(long permitId)
        {
            var snapshots = workPermitMontrealHistoryDao.GetById(permitId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        //RITM0301321 mangesh
        public List<DomainObjectChangeSet> GetEditHistoryForMudsWorkPermit(long permitId)
        {
            var snapshots = workPermitMudsHistoryDao.GetById(permitId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistory(Site gasTestElementInfoConfigHistorySite)
        {
            var snapshots =
                gasTestElementInfoConfigurationHistoryDao.QueryAllBySiteId(gasTestElementInfoConfigHistorySite.IdValue);
            return ConvertSnapshotsToDividedChangeSetsAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForShiftHandoverQuestionnaire(long questionnaireId)
        {
            var snapshots = questionnaireHistoryDao.GetById(questionnaireId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForLabAlertDefinition(long labAlertDefinitionId)
        {
            var snapshots = labAlertDefinitionHistoryDao.GetById(labAlertDefinitionId);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForCokerCard(long cokerCardId)
        {
            var snapShots = cokerCardHistoryDao.GetById(cokerCardId);
            return ConvertSnapShotToChangeSetAndReverse(snapShots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForMontrealPermitRequest(long permitRequestId)
        {
            var histories = permitRequestHistoryDao.GetById(permitRequestId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForConfinedSpace(long confinedSpaceId)
        {
            var confinedSpaceHistories = confinedSpaceHistoryDao.GetById(confinedSpaceId);
            return ConvertSnapShotToChangeSetAndReverse(confinedSpaceHistories);
        }

        //RITM0301321 - mangesh
        public List<DomainObjectChangeSet> GetEditHistoryForConfinedSpaceMuds(long confinedSpaceMudsId)
        {
            var confinedSpaceHistoriesMuds = confinedSpaceMudsHistoryDao.GetById(confinedSpaceMudsId);
            return ConvertSnapShotToChangeSetAndReverse(confinedSpaceHistoriesMuds);
        }
        public List<DomainObjectChangeSet> GetEditHistoryForMudsPermitRequest(long permitRequestId)
        {
            var histories = permitRequestMudsHistoryDao.GetById(permitRequestId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForEdmontonPermit(long permitId)
        {
            var histories = workPermitEdmontonHistoryDao.GetById(permitId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForEdmontonPermitRequest(long permitRequestId)
        {
            var histories = permitRequestEdmontonHistoryDao.GetById(permitRequestId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForFormGn24(long formId)
        {
            var histories = formGN24HistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForFormGn6(long formId)
        {
            var histories = formGN6HistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryFormGn7(long formId)
        {
            var histories = formGN7HistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForFormGn59(long formId)
        {
            var histories = formGN59HistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForOvertimeForm(long formId)
        {
            var histories = formOvertimeFormHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForFormOp14(long formId)
        {
            var histories = formOP14HistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        //generic template - mangesh
        public List<DomainObjectChangeSet> GetEditHistoryForFormGenericTemplate(long formId)
        {
            var histories = formGenericTemplateHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        //RITM0268131 - mangesh
        public List<DomainObjectChangeSet> GetEditHistoryForFormTemporaryInstallations(long formId)
        {
            var histories = temporaryInstallationsHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForMontrealCsd(long formId)
        {
            var histories = montrealCsdHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForFormGN75A(long formId)
        {
            var histories = formGN75AHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        //Aarti INC0548411
        public List<DomainObjectChangeSet> GetEditHistoryForFormGN75B(long formId,long siteId)
        {
            var histories = formGN75BHistoryDao.GetById(formId,siteId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForFormGN1(long formId)
        {
            var histories = formGN1HistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForTradeChecklist(long formId)
        {
            var histories = tradeChecklistHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForOilsandsTrainingForm(long formId)
        {
            var histories = formOilsandsTrainingHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForOilsandsPermitAssessmentForm(long formId)
        {
            var histories = permitAssessmentHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForDocumentSuggestion(long formId)
        {
            var histories = documentSuggestionHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForProcedureDeviation(long formId)
        {
            var histories = procedureDeviationHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public void TakeSnapshot(ProcedureDeviation form)
        {
            procedureDeviationHistoryDao.Insert(form.TakeSnapshot());
        }

        public List<DomainObjectChangeSet> GetEditHistoryForLubesWorkPermit(long permitId)
        {
            var histories = workPermitLubesHistoryDao.GetById(permitId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForLubesPermitRequest(long permitRequestId)
        {
            var histories = permitRequestLubesHistoryDao.GetById(permitRequestId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForLubesCsdForm(long formId)
        {
            var histories = formLubesCsdHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForLubesAlarmDisableForm(long formId)
        {
            var histories = formLubesAlarmDisableHistoryDao.GetById(formId);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForDirective(long id)
        {
            var histories = directiveHistoryDao.GetById(id);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForExcursionResponse(long id)
        {
            var histories = excursionResponseHistoryDao.GetById(id);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForOpmToeDefinitionComment(string toeName)
        {
            var histories = opmToeDefinitionCommentHistoryDao.GetByToeName(toeName);
            return ConvertSnapShotToChangeSetAndReverse(histories);
        }

        public List<DomainObjectChangeSet> GetRecentEditHistoryForLog(long logId)
        {
            return ApplyGetRecentHistoryPolicy(GetEditHistoryForLog(logId));
        }

        public List<DomainObjectChangeSet> GetRecentEditHistoryForSummaryLog(long summaryLogId)
        {
            return ApplyGetRecentHistoryPolicy(GetEditHistoryForSummaryLog(summaryLogId));
        }

        public void TakeSnapshot(OvertimeForm overtimeForm)
        {
            var formOvertimeFormHistory = overtimeForm.TakeSnapshot();

            formOvertimeFormHistoryDao.Insert(formOvertimeFormHistory);
        }

        public void TakeSnapshot(LubesAlarmDisableForm lubesAlarmDisableForm)
        {
            formLubesAlarmDisableHistoryDao.Insert(lubesAlarmDisableForm.TakeSnapshot());
        }

        public void TakeSnapshot(ActionItemDefinition actionItemDefinition)
        {
            actionItemDefinitionHistoryDao.Insert(actionItemDefinition.TakeSnapshot());
        }

        public void TakeSnapshot(Log log)
        {
            var customFields = customFieldDao.QueryByCustomFieldGroupsForLogs(log.IdValue);
            logHistoryDao.Insert(log.TakeSnapshot(customFields));
        }

        public void TakeSnapshot(SummaryLog summaryLog)
        {
            var customFields = customFieldDao.QueryByCustomFieldGroupsForSummaryLogs(summaryLog.IdValue);
            summaryLogHistoryDao.Insert(summaryLog.TakeSnapshot(customFields));
        }

        public void TakeSnapshot(LogDefinition logDefinition)
        {
            var customFields =
                customFieldDao.QueryByCustomFieldGroupsForLogDefinitions(logDefinition.IdValue);
            logDefinitionHistoryDao.Insert(logDefinition.TakeSnapshot(customFields));
        }

        public void TakeSnapshot(TargetDefinition targetDefinition)
        {
            targetDefinitionHistoryDao.Insert(targetDefinition.TakeSnapshot());
        }

        public void TakeSnapshot(RestrictionDefinition definition)
        {
            restrictionDefinitionHistoryDao.Insert(definition.TakeSnapshot());
        }

        public void TakeSnapshot(DeviationAlertResponse response)
        {
            deviationAlertResponseHistoryDao.Insert(response.TakeSnapshot());
        }

        public void TakeSnapshot(List<GasTestElementInfoDTO> gasTestElementInfoDtoList, DateTime lastModifiedDateTime,
            User lastModifiedUser, long siteId)
        {
            foreach (var dto in gasTestElementInfoDtoList)
            {
                gasTestElementInfoConfigurationHistoryDao.Insert(
                    dto.TakeSnapshot(lastModifiedDateTime, lastModifiedUser), siteId);
            }
        }

        public void TakeSnapshot(WorkPermit workPermit)
        {
            workPermitHistoryDao.Insert(new WorkPermitSnapshotTaker(workPermit).CreateWorkPermitHistorySnapshot());
        }

        public void TakeSnapshot(WorkPermitMontreal workPermitMontreal)
        {
            workPermitMontrealHistoryDao.Insert(
                new WorkPermitMontrealSnapshotTaker(workPermitMontreal).CreateWorkPermitMontrealHistorySnapshot());
        }

        //RITM0301321 mangesh
        public void TakeSnapshot(WorkPermitMuds workPermitMuds)
        {
            workPermitMudsHistoryDao.Insert(
                new WorkPermitMudsSnapshotTaker(workPermitMuds).CreateWorkPermitMudsHistorySnapshot());
        }

        public void TakeSnapshot(FunctionalLocationOperationalMode flocOpMode, User lastModifiedUser)
        {
            var flocOpModeHistory =
                new FunctionalLocationOperationalModeHistory(flocOpMode.IdValue,
                    flocOpMode.OperationalMode,
                    flocOpMode.AvailabilityReason,
                    flocOpMode.LastModifiedDateTime,
                    lastModifiedUser);
            flocOpModeHistoryDao.Insert(flocOpModeHistory);
        }


        public void TakeSnapshot(ShiftHandoverQuestionnaire questionnaire)
        {
            questionnaireHistoryDao.Insert(questionnaire.TakeSnapshot());
        }


        public void TakeSnapshot(LabAlertDefinition labAlertDefinition)
        {
            labAlertDefinitionHistoryDao.Insert(labAlertDefinition.TakeSnapshot());
        }

        public void TakeSnapshot(CokerCard cokerCard, List<CokerCardCycleStepEntry> previousEntries)
        {
            var configuration = cokerCardConfigurationDao.QueryById(cokerCard.ConfigurationId);
            cokerCardHistoryDao.Insert(cokerCard.TakeSnapshot(configuration, previousEntries));
        }

        public void TakeSnapshot(PermitRequestMontreal permitRequest)
        {
            permitRequestHistoryDao.Insert(permitRequest.TakeSnapshot());
        }

        public void TakeSnapshot(ConfinedSpace confinedSpace)
        {
            confinedSpaceHistoryDao.Insert(confinedSpace.TakeSnapshot());
        }

        //RITM0301321 - mangesh
        public void TakeSnapshot(ConfinedSpaceMuds confinedSpace)
        {
            confinedSpaceMudsHistoryDao.Insert(confinedSpace.TakeSnapshot());
        }
        public void TakeSnapshot(PermitRequestMuds permitRequest)
        {
            permitRequestMudsHistoryDao.Insert(permitRequest.TakeSnapshot());
        }

        public void TakeSnapshot(PermitRequestEdmonton permitRequest)
        {
            permitRequestEdmontonHistoryDao.Insert(permitRequest.TakeSnapshot());
        }

        public void TakeSnapshot(WorkPermitEdmonton permit)
        {
            workPermitEdmontonHistoryDao.Insert(permit.TakeSnapshot());
        }

        public void TakeSnapshot(FormGN7 form)
        {        }

        public void TakeSnapshot(FormGN59 form)
        {
            formGN59HistoryDao.Insert(form.TakeSnapshot());
        }

        public void TakeSnapshot(FormOP14 form)
        {
            formOP14HistoryDao.Insert(form.TakeSnapshot());
        }

        //Generic Template - mangesh
        public void TakeSnapshot(FormGenericTemplate form)
        {
            formGenericTemplateHistoryDao.Insert(form.TakeSnapshot());
        }

        //RITM0268131 - mangesh
        public void TakeSnapshot(TemporaryInstallationsMUDS form)
        {
            temporaryInstallationsHistoryDao.Insert(form.TakeSnapshot());
        }

        //DMND0011225 CSD for WBR
        public void TakeSnapshot(GenericCsd form)
        {
            genericCsdHistoryDao.Insert(form.TakeSnapshot());
        }

        public void TakeSnapshot(MontrealCsd form)
        {
            montrealCsdHistoryDao.Insert(form.TakeSnapshot());
        }


        public void TakeSnapshot(FormGN24 form)
        {
            formGN24HistoryDao.Insert(form.TakeSnapshot());
        }

        public void TakeSnapshot(FormGN6 form)
        {
            formGN6HistoryDao.Insert(form.TakeSnapshot());
        }

        public void TakeSnapshot(FormGN75A form)
        {
            formGN75AHistoryDao.Insert(form.TakeSnapshot());
        }

        //Aarti INC0548411
        public void TakeSnapshot(FormGN75B form)
        {
            formGN75BHistoryDao.Insert(form.TakeSnapshot(),form.SiteID);
        }

        public void TakeSnapshot(FormGN1 form)
        {
            formGN1HistoryDao.Insert(form.TakeSnapshot());
        }

        public void TakeSnapshot(List<TradeChecklist> tradeChecklist)
        {
            tradeChecklist.ForEach(tc => tradeChecklistHistoryDao.Insert(tc.TakeSnapshot()));
        }

        public void TakeSnapshot(FormOilsandsTraining form)
        {
            formOilsandsTrainingHistoryDao.Insert(form.TakeSnapshot());
        }

        public void TakeSnapshot(WorkPermitLubes workPermit)
        {
            workPermitLubesHistoryDao.Insert(workPermit.TakeSnapshot());
        }

        public void TakeSnapshot(PermitRequestLubes permitRequest)
        {
            permitRequestLubesHistoryDao.Insert(permitRequest.TakeSnapshot());
        }

        public void TakeSnapshot(Directive directive)
        {
            directiveHistoryDao.Insert(directive.TakeSnapshot());
        }

        public void TakeSnapshot(OpmToeDefinitionComment opmToeDefinitionComment)
        {
            opmToeDefinitionCommentHistoryDao.Insert(opmToeDefinitionComment.TakeSnapshot());
        }

        public void TakeSnapshot(OpmExcursionResponse excursionResponse)
        {
            excursionResponseHistoryDao.Insert(excursionResponse.TakeSnapshot());
        }

        public void TakeSnapshot(LubesCsdForm form)
        {
            formLubesCsdHistoryDao.Insert(form.TakeSnapshot());
        }

        public void TakeSnapshot(PermitAssessment form)
        {
            permitAssessmentHistoryDao.Insert(form.TakeSnapshot());
        }

        public void TakeSnapshot(DocumentSuggestion form)
        {
            documentSuggestionHistoryDao.Insert(form.TakeSnapshot());
        }

        private List<DomainObjectChangeSet> ConvertSnapShotToChangeSetAndReverse<T>(List<T> snapshots)
            where T : IHistorySnapshot
        {
            var changeSets = snapshots.ConvertToChangeSet();
            changeSets.Reverse();
            return changeSets;
        }

        private List<DomainObjectChangeSet> ConvertSnapshotsToDividedChangeSetsAndReverse(
            IEnumerable<GasTestElementInfoConfigurationHistory> snapshots)
        {
            var groupedSnapshots = GroupSnapshots(snapshots);
            var changeSets = groupedSnapshots.ConvertGasTestElementInfoConfigurationHistories();
            changeSets.Reverse();
            return changeSets;
        }

        private static List<GasTestElementInfoConfigurationHistoryList> GroupSnapshots(
            IEnumerable<GasTestElementInfoConfigurationHistory> snapshots)
        {
            IDictionary<IHistorySnapshot, GasTestElementInfoConfigurationHistoryList> groups =
                new Dictionary<IHistorySnapshot, GasTestElementInfoConfigurationHistoryList>();

            foreach (var history in snapshots)
            {
                IHistorySnapshot key =
                    new GasTestElementInfoConfigurationHistoryList(history.LastModifiedDate, history.LastModifiedBy);

                if (!groups.ContainsKey(key))
                {
                    groups[key] =
                        new GasTestElementInfoConfigurationHistoryList(history.LastModifiedDate,
                            history.LastModifiedBy);
                }
                groups[key].Add(history);
            }

            return new List<GasTestElementInfoConfigurationHistoryList>(groups.Values);
        }

        private static List<DomainObjectChangeSet> ApplyGetRecentHistoryPolicy(List<DomainObjectChangeSet> changeSets)
        {
            return changeSets.First(MAX_RECENT_HISTORY_COUNT);
        }

        public void TakeSnapshot(PermitRequestFortHills permitRequest)
        {
            permitRequestFortHillsHistoryDao.Insert(permitRequest.TakeSnapshot());
        }

        public void TakeSnapshot(WorkPermitFortHills permit)
        {
            workPermitFortHillsHistoryDao.Insert(permit.TakeSnapshot());
        }


        public List<DomainObjectChangeSet> GetEditHistoryForWorkPermitSign(string workPermitnumber)
        {
            var snapshots = workPermitHistoryDao.GetBySignId(workPermitnumber);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

        public List<DomainObjectChangeSet> GetEditHistoryForWorkPermitMudsSign(string workPermitnumber)
        {
            var snapshots = workPermitMudsHistoryDao.GetBySignId(workPermitnumber);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }
        //Added by ppanigrahi
        public List<DomainObjectChangeSet> GetEditHistoryForConfinedSpaceMudsSign(string confinespacenumber)
        {
            var snapshots = confinedSpaceMudsHistoryDao.GetBySignId(confinespacenumber);
            return ConvertSnapShotToChangeSetAndReverse(snapshots);
        }

    }
}