using System;
using System.Configuration;
using Castle.DynamicProxy;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Caching;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using log4net;

namespace Com.Suncor.Olt.Remote.Bootstrap
{
    public class Bootstrapper
    {
        private const string SqlServerKey = "SqlServer";
        private static readonly ILog logger = GenericLogManager.GetLogger<Bootstrapper>();

        private static readonly CacheInterceptorSelector cacheInterceptorSelector = new CacheInterceptorSelector();

        private static readonly ProxyGenerationOptions cachingProxyGenerationOptions = new ProxyGenerationOptions
        {
            Selector = cacheInterceptorSelector
        };

        private static readonly ProxyGenerator proxyGenerator =
            new ProxyGenerator(new DefaultProxyBuilder(new ModuleScope(false, true)));

        private static bool activated;

        private static readonly string storedProcPerformanceThreshold =
            ConfigurationManager.AppSettings.Get("StoredProcPerformanceThreshold");

        private static readonly DistributedCacheImplementationFactory cacheFactory =
            new DistributedCacheImplementationFactory();

        private static CachingTypeEnum CachingType
        {
            get { return cacheFactory.IsDistributedCache ? CachingTypeEnum.Distributed : CachingTypeEnum.None; }
        }

        private static long? StoredProcThreshold
        {
            get
            {
                if (string.IsNullOrEmpty(storedProcPerformanceThreshold))
                    return null;

                long threshold;

                if (long.TryParse(storedProcPerformanceThreshold, out threshold) == false)
                    return null;

                return threshold;
            }
        }

        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings[SqlServerKey].ConnectionString; }
        }

        /// <summary>
        ///     Bootstrap the service by loading all the Data access objects and Services. Called by Global.asax
        /// </summary>
        public static void Bootstrap()
        {
            logger.DebugFormat("Bootstrapping Remote Application @ {0}", DateTime.Now);
            if (!activated)
            {
                Clock.Disable();
                BootstrapDaos();
                activated = true;
            }
        }

        /// <summary>
        ///     Register new Data access classes into the DaoRegistry hashtable
        /// </summary>
        public static void BootstrapDaos()
        {
            try
            {
                // TODO: Clean this up.  Why not use an IOC container?

                logger.Debug("Starting to bootstrap daos");

                DaoRegistry.Clear();

                var connectionString = ConnectionString;

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPlantDao>(connectionString, new PlantDao()));

                DaoRegistry.RegisterDaoFor<ITimeDao>(new TimeDao(ConfigurationManager.AppSettings.Get("ServerTimeZone")));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISiteDao>(connectionString, new SiteDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFunctionalLocationDao>(connectionString,
                    new FunctionalLocationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IShiftPatternDao>(connectionString, new ShiftPatternDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRoleElementDao>(connectionString, new RoleElementDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRoleDao>(connectionString, new RoleDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IScheduleDao>(connectionString, new ScheduleDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IObjectLockDao>(connectionString, new ObjectLockDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDocumentLinkDao>(connectionString, new DocumentLinkDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IUserPrintPreferenceDao>(connectionString,
                    new UserPrintPreferenceDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IUserPreferencesDao>(connectionString,
                    new UserPreferencesDao()));

                DaoRegistry.RegisterDaoFor(
                    CreateManagedDao<IUserWorkPermitDefaultTimePreferencesDao>(connectionString,
                        new UserWorkPermitDefaultTimePreferencesDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IUserDao>(connectionString, new UserDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IUserDTODao>(connectionString, new UserDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IUserGridLayoutDao>(connectionString,
                    new UserGridLayoutDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IBusinessCategoryDao>(
                    connectionString, new BusinessCategoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITagDao>(connectionString, new TagDao()));

                //
                //  Note - must be registered after ISiteDao and ITagDao
                //
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITagGroupDao>(connectionString, new TagGroupDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICommentDao>(connectionString, new CommentDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IActionItemDTODao>(connectionString, new ActionItemDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IActionItemDefinitionDTODao>(connectionString,
                    new ActionItemDefinitionDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogDTODao>(connectionString, new LogDTODao()));




                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISummaryLogCustomFieldEntryHistoryDao>(connectionString,
                    new SummaryLogCustomFieldEntryHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISummaryLogCustomFieldEntryDao>(connectionString,
                    new SummaryLogCustomFieldEntryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogCustomFieldEntryHistoryDao>(connectionString,
                    new LogCustomFieldEntryHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogCustomFieldEntryDao>(connectionString,
                    new LogCustomFieldEntryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogDefinitionCustomFieldEntryHistoryDao>(connectionString,
                    new LogDefinitionCustomFieldEntryHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogDefinitionCustomFieldEntryDao>(connectionString,
                    new LogDefinitionCustomFieldEntryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISummaryLogDTODao>(connectionString, new SummaryLogDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDetailedLogReportDTODao>(connectionString,
                    new DetailedLogReportDTODao()));



                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICustomFieldTrendReportDTODao>(connectionString,
                    new CustomFieldTrendReportDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISAPNotificationDTODao>(connectionString,
                    new SAPNotificationDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICraftOrTradeDao>(connectionString, new CraftOrTradeDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFunctionalLocationInfoDao>(connectionString,
                    new FunctionalLocationInfoDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFunctionalLocationDTODao>(connectionString,
                    new FunctionalLocationDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkAssignmentVisibilityGroupDao>(connectionString,
                    new WorkAssignmentVisibilityGroupDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IVisibilityGroupDao>(connectionString,
                    new VisibilityGroupDao()));

                // NOTE - must be registered before IUserShiftAssignmentDao
                // NOTE - must be registered after FunctionalLocationDao
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkAssignmentDao>(connectionString,
                    new WorkAssignmentDao()));

                var workAssignmentDtoDao = CreateManagedDao<IWorkAssignmentDTODao>(connectionString,
                    new WorkAssignmentDTODao());
                DaoRegistry.RegisterDaoFor(workAssignmentDtoDao);

                DaoRegistry.RegisterDaoFor(
                    CreateManagedDao<ITargetDefinitionReadWriteTagConfigurationDao>(connectionString,
                        new TargetDefinitionReadWriteTagConfigurationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IScadaConfigurationDao>(connectionString,
                    new ScadaConfigurationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITargetDefinitionDTODao>(connectionString,
                    new TargetDefinitionDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITargetDefinitionDao>(connectionString,
                    new TargetDefinitionDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITargetDefinitionStateDao>(connectionString,
                    new TargetDefinitionStateDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITargetAlertDao>(connectionString, new TargetAlertDao()));
                // Make sure this comes after Comment registration:
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITargetAlertResponseDao>(connectionString,
                    new TargetAlertResponseDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITargetAlertDTODao>(connectionString,
                    new TargetAlertDTODao()));


                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICustomFieldGroupWorkAssignmentDao>(connectionString,
                    new CustomFieldGroupWorkAssignmentDao()));


                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICustomFieldDropDownValueDao>(connectionString,
              new CustomFieldDropDownValueDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICustomFieldDao>(connectionString, new CustomFieldDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICustomFieldGroupDao>(connectionString,
new CustomFieldGroupDao()));

                //has to be after shift, schedule, functional location, action item category, postion, user, site, target defintion dto, comment, and documentlink
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IActionItemDefinitionDao>(connectionString,  new ActionItemDefinitionDao()));


                //
                //  Has to be after IActionItemDefinitionDao, IFunctionalLocationDao, IDocumentLinkDao,
                //
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IActionItemCustomFieldEntryDao>(connectionString, new ActionItemCustomFieldEntryDao())); //ayman custom fields DMND0010030

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IActionItemDao>(connectionString, new ActionItemDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IGasTestElementInfoDao>(connectionString,
                    new GasTestElementInfoDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IGasTestElementDao>(connectionString,
                    new GasTestElementDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitDTODao>(connectionString, new WorkPermitDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitDao>(connectionString, new WorkPermitDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogReadDao>(connectionString, new LogReadDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISummaryLogReadDao>(connectionString,
                    new SummaryLogReadDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogFunctionalLocationDao>(connectionString,
                    new LogFunctionalLocationDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogDefinitionFunctionalLocationDao>(connectionString,
                    new LogDefinitionFunctionalLocationDao
                        ()));

          
                

                // has to be before LogDao registration
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogDefinitionDao>(connectionString, new LogDefinitionDao()));


                //has to be after functional location and user registration
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogDao>(connectionString, new LogDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISummaryLogDao>(connectionString, new SummaryLogDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogDefinitionDTODao>(connectionString,
                    new LogDefinitionDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISAPNotificationDao>(connectionString,
                    new SAPNotificationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IEventSinkDao>(connectionString, new EventSinkDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISapWorkOrderOperationDao>(connectionString,
                    new SapWorkOrderOperationDao()));

                DaoRegistry.RegisterDaoFor(
                    CreateManagedDao<IFunctionalLocationOperationalModeDTODao>(connectionString,
                        new FunctionalLocationOperationalModeDTODao()));

                DaoRegistry.RegisterDaoFor(
                    CreateManagedDao<IFunctionalLocationOperationalModeDao>(connectionString,
                        new FunctionalLocationOperationalModeDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IGasTestElementInfoDTODao>(connectionString,
                    new GasTestElementInfoDTODao()));

                DaoRegistry.RegisterDaoFor(
                    CreateManagedDao<ITargetDefinitionAutoReApprovalConfigurationDao>(connectionString,
                        new TargetDefinitionAutoReApprovalConfigurationDao()));






                DaoRegistry.RegisterDaoFor(
                    CreateManagedDao<IActionItemDefinitionAutoReApprovalConfigurationDao>(connectionString,
                        new ActionItemDefinitionAutoReApprovalConfigurationDao()));





                //
                // Must be AFTER TargetDefinitionAutoReApprovalConfigurationDao and
                // ActionItemDefinitionAutoReApprovalConfiguration
                //
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISiteConfigurationDao>(connectionString,
                    new SiteConfigurationDao()));

                // NOTE: Must be registered AFTER SiteDao.
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IContractorDao>(connectionString, new ContractorDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IUserLoginHistoryFunctionalLocationDao>(connectionString,
                    new UserLoginHistoryFunctionalLocationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IUserLoginHistoryDao>(connectionString,
                    new UserLoginHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IActionItemDefinitionHistoryDao>(connectionString,
                    new ActionItemDefinitionHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogHistoryDao>(connectionString, new LogHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISummaryLogHistoryDao>(connectionString,
                    new SummaryLogHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitHistoryDao>(connectionString,
                    new WorkPermitHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITargetDefinitionHistoryDao>(connectionString,
                    new TargetDefinitionHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IGasTestElementInfoConfigurationHistoryDao>(
                    connectionString, new GasTestElementInfoConfigurationHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogDefinitionHistoryDao>(connectionString,
                    new LogDefinitionHistoryDao()));

                DaoRegistry.RegisterDaoFor(
                    CreateManagedDao<IFunctionalLocationOperationalModeHistoryDao>(connectionString,
                        new FunctionalLocationOperationalModeHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRestrictionReasonCodeDao>(connectionString,
                    new RestrictionReasonCodeDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRestrictionDefinitionDao>(connectionString,
                    new RestrictionDefinitionDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRestrictionDefinitionDTODao>(connectionString,
                    new RestrictionDefinitionDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRestrictionDefinitionHistoryDao>(connectionString,
                    new RestrictionDefinitionHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRestrictionLocationWorkAssignmentDao>(connectionString,
                    new RestrictionLocationWorkAssignmentDao()));
                DaoRegistry.RegisterDaoFor(
                    CreateManagedDao<IRestrictionLocationItemReasonCodeAssociationDao>(connectionString,
                        new RestrictionLocationItemReasonCodeAssociationDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRestrictionLocationItemDao>(connectionString,
                    new RestrictionLocationItemDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRestrictionLocationDao>(connectionString,
                    new RestrictionLocationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDeviationAlertResponseReasonCodeAssignmentDao>(
                    connectionString, new DeviationAlertResponseReasonCodeAssignmentDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDeviationAlertResponseDao>(connectionString,
                    new DeviationAlertResponseDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDeviationAlertResponseHistoryDao>(connectionString,
                    new DeviationAlertResponseHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDeviationAlertDTODao>(connectionString,
                    new DeviationAlertDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDeviationAlertReportDTODao>(connectionString,
                    new DeviationAlertReportDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDeviationAlertDao>(connectionString,
                    new DeviationAlertDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IQuestionnaireSectionQuestionDao>(connectionString,
                    new QuestionnaireSectionQuestionDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IQuestionnaireSectionDao>(connectionString,
                    new QuestionnaireSectionDao()));


                DaoRegistry.RegisterDaoFor(CreateManagedDao<IQuestionnaireConfigurationDao>(connectionString,
                    new QuestionnaireConfigurationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IBusinessCategoryFLOCAssociationDao>(connectionString,
                    new BusinessCategoryFLOCAssociationDao()));


                DaoRegistry.RegisterDaoFor(CreateManagedDao<IShiftHandoverQuestionDao>(connectionString,
                    new ShiftHandoverQuestionDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IShiftHandoverConfigurationWorkAssignmentDao>(
                    connectionString, new ShiftHandoverConfigurationWorkAssignmentDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IShiftHandoverConfigurationDTODao>(
                    connectionString, new ShiftHandoverConfigurationDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IShiftHandoverConfigurationDao>(connectionString,
                    new ShiftHandoverConfigurationDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IShiftHandoverEmailConfigurationDao>(connectionString,
                    new ShiftHandoverEmailConfigurationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IShiftHandoverAnswerDao>(connectionString,
                    new ShiftHandoverAnswerDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IShiftHandoverAnswerHistoryDao>(connectionString,
                    new ShiftHandoverAnswerHistoryDao()));

                DaoRegistry.RegisterDaoFor(
                    CreateManagedDao<IShiftHandoverQuestionnaireCokerCardConfigurationDao>(connectionString,
                        new ShiftHandoverQuestionnaireCokerCardConfigurationDao()));




                DaoRegistry.RegisterDaoFor(CreateManagedDao<IShiftHandoverQuestionnaireHistoryDao>(connectionString,
                    new ShiftHandoverQuestionnaireHistoryDao()));

                var shiftHandoverQuestionnaireDao =
                    CreateManagedDao<IShiftHandoverQuestionnaireDao>(connectionString,
                        new ShiftHandoverQuestionnaireDao());
                DaoRegistry.RegisterDaoFor(shiftHandoverQuestionnaireDao);

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IShiftHandoverQuestionnaireDTODao>(connectionString,
                    new ShiftHandoverQuestionnaireDTODao
                        ()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IQuestionnaireReadDao>(connectionString,
                    new QuestionnaireReadDao()));





                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogTemplateWorkAssignmentDao>(
                    connectionString, new LogTemplateWorkAssignmentDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogTemplateDao>(connectionString, new LogTemplateDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogTemplateDTODao>(connectionString,
                    new LogTemplateDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILabAlertDefinitionDao>(connectionString,
                    new LabAlertDefinitionDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILabAlertDefinitionDTODao>(connectionString,
                    new LabAlertDefinitionDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILabAlertDefinitionHistoryDao>(connectionString,
                    new LabAlertDefinitionHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILabAlertResponseDao>(connectionString,
                    new LabAlertResponseDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILabAlertDao>(connectionString, new LabAlertDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILabAlertDTODao>(connectionString, new LabAlertDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRoleDisplayConfigurationDao>(connectionString,
                    new RoleDisplayConfigurationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICokerCardConfigurationWorkAssignmentDao>(connectionString,
                    new CokerCardConfigurationWorkAssignmentDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICokerCardConfigurationDrumDao>(connectionString,
                    new CokerCardConfigurationDrumDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICokerCardConfigurationCycleStepDao>(connectionString,
                    new CokerCardConfigurationCycleStepDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICokerCardConfigurationDao>(connectionString,
                    new CokerCardConfigurationDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICokerCardCycleStepEntryDao>(connectionString,
                    new CokerCardCycleStepEntryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICokerCardDrumEntryDao>(connectionString,
                    new CokerCardDrumEntryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICokerCardDao>(connectionString, new CokerCardDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICokerCardDTODao>(connectionString, new CokerCardDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICokerCardCycleStepEntryDTODao>(connectionString,
                    new CokerCardCycleStepEntryDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICokerCardDrumEntryHistoryDao>(connectionString,
                    new CokerCardDrumEntryHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ICokerCardHistoryDao>(connectionString,
                    new CokerCardHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRolePermissionDao>(connectionString,
                    new RolePermissionDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILogGuidelineDao>(connectionString, new LogGuidelineDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitMontrealGroupDao>(connectionString,
                    new WorkPermitMontrealGroupDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitAttributeDao>(connectionString,
                    new PermitAttributeDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitMontrealTemplateDao>(connectionString,
                    new WorkPermitMontrealTemplateDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitMontrealDao>(connectionString,
                    new WorkPermitMontrealDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitMontrealDTODao>(connectionString,
                    new WorkPermitMontrealDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestMontrealDao>(connectionString,
                    new PermitRequestMontrealDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestMontrealDTODao>(connectionString,
                    new PermitRequestMontrealDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestMontrealHistoryDao>(connectionString,
                    new PermitRequestMontrealHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IConfinedSpaceDao>(connectionString, new ConfinedSpaceDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IConfinedSpaceDTODao>(connectionString,
                    new ConfinedSpaceDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IConfinedSpaceHistoryDao>(connectionString,
                    new ConfinedSpaceHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitMontrealHistoryDao>(connectionString,
                    new WorkPermitMontrealHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDropdownValueDao>(connectionString, new DropdownValueDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IConfiguredDocumentLinkDao>(connectionString,
                    new ConfiguredDocumentLinkDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IAreaLabelDao>(connectionString, new AreaLabelDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormTemplateDao>(connectionString, new FormTemplateDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITrainingBlockDao>(connectionString, new TrainingBlockDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormApprovalDao>(connectionString, new FormApprovalDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN7Dao>(connectionString, new FormGN7Dao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN59Dao>(connectionString, new FormGN59Dao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitAssessmentAnswerDao>(connectionString,
                    new PermitAssessmentAnswerDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitAssessmentDao>(connectionString,
                    new PermitAssessmentDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitAssessmentDTODao>(connectionString,
                    new PermitAssessmentDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISafeWorkPermitAssessmentReportDTODao>(connectionString,
                    new SafeWorkPermitAssessmentReportDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormOP14Dao>(connectionString, new FormOP14Dao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IMontrealCsdDao>(connectionString, new MontrealCsdDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN24Dao>(connectionString, new FormGN24Dao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN6Dao>(connectionString, new FormGN6Dao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN75ADao>(connectionString, new FormGN75ADao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITradeChecklistDao>(connectionString,
                    new TradeChecklistDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN1Dao>(connectionString, new FormGN1Dao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOnPremiseContractorDao>(connectionString,
                    new OnPremiseContractorDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOvertimeFormDao>(connectionString, new OvertimeFormDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormLubesCsdDao>(connectionString, new FormLubesCsdDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormOvertimeFormHistoryDao>(connectionString,
                    new FormOvertimeFormHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN7HistoryDao>(connectionString,
                    new FormGN7HistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN59HistoryDao>(connectionString,
                    new FormGN59HistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormOP14HistoryDao>(connectionString,
                    new FormOP14HistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IMontrealCsdHistoryDao>(connectionString,
                    new MontrealCsdHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN24HistoryDao>(connectionString,
                    new FormGN24HistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN6HistoryDao>(connectionString,
                    new FormGN6HistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN75AHistoryDao>(connectionString,
                    new FormGN75AHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN75BHistoryDao>(connectionString,
                    new FormGN75BHistoryDao()));





                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN75BIsolationDao>(connectionString,
                  new FormGN75BIsolationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN75BDevicePositionDao>(connectionString,
                    new FormGN75BDevicePositionDao()));             //ayman Sarnia eip DMND0008992


                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN75BDao>(connectionString, new FormGN75BDao()));


                // DMND0011225 CSD for WBR
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IGenericCsdDao>(connectionString, new GenericCsdDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IGenericCsdHistoryDao>(connectionString,
                    new GenericCsdHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IGenericCsdDTODao>(connectionString,
                    new GenericCsdDTODao()));


                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITradeChecklistHistoryDao>(connectionString,
                    new TradeChecklistHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGN1HistoryDao>(connectionString,
                    new FormGN1HistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormEdmontonDTODao>(connectionString,
                    new FormEdmontonDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormEdmontonOP14DTODao>(connectionString,
                    new FormEdmontonOP14DTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IMontrealCsdDTODao>(connectionString,
                    new MontrealCsdDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormEdmontonGN24DTODao>(connectionString,
                    new FormEdmontonGN24DTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormEdmontonGN6DTODao>(connectionString,
                    new FormEdmontonGN6DTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormEdmontonGN75ADTODao>(connectionString,
                    new FormEdmontonGN75ADTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormEdmontonGN75BDTODao>(connectionString,
                    new FormEdmontonGN75BDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOvertimeFormDTODao>(connectionString,
                    new OvertimeFormDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormEdmontonGN1DTODao>(connectionString,
                    new FormEdmontonGN1DTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILubesCsdFormDTODao>(connectionString,
                    new LubesCsdFormDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormLubesCsdHistoryDao>(connectionString,
                    new FormLubesCsdHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILubesAlarmDisableDao>(connectionString,
                    new LubesAlarmDisableDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILubesAlarmDisableFormDTODao>(connectionString,
                    new LubesAlarmDisableFormDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ILubesAlarmDisableHistoryDao>(connectionString,
                    new LubesAlarmDisableHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormOilsandsTrainingDTODao>(connectionString,
                    new FormOilsandsTrainingDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormOilsandsPriorityPageDTODao>(connectionString,
                    new FormOilsandsPriorityPageDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormOilsandsTrainingItemDao>(connectionString,
                    new FormOilsandsTrainingItemDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormOilsandsTrainingDao>(connectionString,
                    new FormOilsandsTrainingDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormOilsandsTrainingHistoryDao>(connectionString,
                    new FormOilsandsTrainingHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormOilsandsTrainingReportDTODao>(connectionString,
                    new FormOilsandsTrainingReportDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitEdmontonGroupDao>(connectionString,
                    new WorkPermitEdmontonGroupDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitEdmontonDao>(connectionString,
                    new WorkPermitEdmontonDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitEdmontonDTODao>(connectionString,
                    new WorkPermitEdmontonDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitEdmontonHazardDTODao>(connectionString,
                    new WorkPermitEdmontonHazardDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitEdmontonHistoryDao>(connectionString,
                    new WorkPermitEdmontonHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestEdmontonWorkOrderSourceDao>(connectionString,
                    new PermitRequestEdmontonWorkOrderSourceDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestEdmontonDao>(connectionString,
                    new PermitRequestEdmontonDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestEdmontonDTODao>(connectionString,
                    new PermitRequestEdmontonDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestEdmontonHistoryDao>(connectionString,
                    new PermitRequestEdmontonHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestEdmontonSAPImportDataDao>(connectionString,
                    new PermitRequestEdmontonSAPImportDataDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISiteConfigurationDefaultsDao>(connectionString,
                    new SiteConfigurationDefaultsDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IRoleElementTemplateDao>(connectionString,
                    new RoleElementTemplateDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestLubesWorkOrderSourceDao>(connectionString,
                    new PermitRequestLubesWorkOrderSourceDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitLubesGroupDao>(connectionString,
                    new WorkPermitLubesGroupDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitLubesDao>(connectionString,
                    new WorkPermitLubesDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitLubesDTODao>(connectionString,
                    new WorkPermitLubesDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitLubesHistoryDao>(connectionString,
                    new WorkPermitLubesHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestLubesDao>(connectionString,
                    new PermitRequestLubesDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestLubesDTODao>(connectionString,
                    new PermitRequestLubesDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestLubesHistoryDao>(connectionString,
                    new PermitRequestLubesHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkOrderImportDataDao>(connectionString,
                    new WorkOrderImportDataDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISapAutoImportConfigurationDao>(connectionString,
                    new SapAutoImportConfigurationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISiteCommunicationDao>(connectionString,
                    new SiteCommunicationDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISiteCommunicationDTODao>(connectionString,
                    new SiteCommunicationDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPropertyDao>(connectionString, new PropertyDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IEventDao>(connectionString, new EventDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDirectiveDao>(connectionString, new DirectiveDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDirectiveDTODao>(connectionString, new DirectiveDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDirectiveHistoryDao>(connectionString,
                    new DirectiveHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDirectiveReadDao>(connectionString, new DirectiveReadDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IShiftHandoverQuestionnaireAssociationDao>(
                    connectionString, new ShiftHandoverQuestionnaireAssociationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPriorityPageSectionConfigurationDao>(connectionString,
                    new PriorityPageSectionConfigurationDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IEdmontonPersonDao>(connectionString,
                    new EdmontonPersonDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOnPremisePersonnelDtoDao>(connectionString,
                    new OnPremisePersonnelDtoDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOpmExcursionDao>(connectionString, new OpmExcursionDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOpmToeDefinitionDao>(connectionString,
                    new OpmToeDefinitionDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOpmExcursionResponseDao>(connectionString,
                    new OpmExcursionResponseDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOpmToeDefinitionCommentDao>(connectionString,
                    new OpmToeDefinitionCommentDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOpmExcursionResponseDTODao>(connectionString,
                    new OpmExcursionResponseDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOpmExcursionEventPriorityPageDTODao>(connectionString,
                    new OpmExcursionEventPriorityPageDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IExcursionResponseHistoryDao>(connectionString,
                    new ExcursionResponseHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOpmToeDefinitionCommentHistoryDao>(connectionString,
                    new OpmToeDefinitionCommentHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IOpmExcursionImportStatusDTODao>(connectionString,
                    new OpmExcursionImportStatusDTODao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitAssessmentAnswerHistoryDao>(connectionString,
                    new PermitAssessmentAnswerHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitAssessmentHistoryDao>(connectionString,
                    new PermitAssessmentHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDocumentSuggestionDao>(connectionString,
                    new DocumentSuggestionDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDocumentSuggestionDTODao>(connectionString,
                    new DocumentSuggestionDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IDocumentSuggestionHistoryDao>(connectionString,
                    new DocumentSuggestionHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IProcedureDeviationCauseDeterminationDao>(connectionString,
                    new ProcedureDeviationCauseDeterminationDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IProcedureDeviationDao>(connectionString,
                    new ProcedureDeviationDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IProcedureDeviationDTODao>(connectionString,
                    new ProcedureDeviationDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IProcedureDeviationHistoryDao>(connectionString,
                    new ProcedureDeviationHistoryDao()));
                //Added by mangesh on 15 Nov.16 as Added new Special Work 
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ISpecialWorkDao>(connectionString, new SpecialWorkDao()));

                //generic template -mangesh
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGenericTemplateDao>(connectionString, new FormGenericTemplateDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IFormGenericTemplateHistoryDao>(connectionString, new FormGenericTemplateHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IGenericTemplateApprovalDao>(connectionString, new GenericTemplateApprovalDao()));

                //OLT Administrator list - mangesh
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IAdministratorListDao>(connectionString, new AdministratorListDao()));

                //RITM0268131 - mangesh
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITemporaryInstallationsMudsDao>(connectionString, new TemporaryInstallationsMudsDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITemporaryInstallationsMudsDTODao>(connectionString, new TemporaryInstallationsMudsDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<ITemporaryInstallationsMudsHistoryDao>(connectionString, new TemporaryInstallationsMudsHistoryDao()));

                /* DMND0009632 - Fort Hills OLT - E-Permit Development*/
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitFortHillsGroupDao>(connectionString, new WorkPermitFortHillsGroupDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitFortHillsDao>(connectionString, new WorkPermitFortHillsDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitFortHillsDTODao>(connectionString,new WorkPermitFortHillsDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitFortHillsHazardDTODao>(connectionString,new WorkPermitFortHillsHazardDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitFortHillsHistoryDao>(connectionString,new WorkPermitFortHillsHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestFortHillsWorkOrderSourceDao>(connectionString,new PermitRequestFortHillsWorkOrderSourceDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestFortHillsDao>(connectionString,new PermitRequestFortHillsDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestFortHillsDTODao>(connectionString,new PermitRequestFortHillsDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestFortHillsHistoryDao>(connectionString,new PermitRequestFortHillsHistoryDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestFortHillsSAPImportDataDao>(connectionString,new PermitRequestFortHillsSAPImportDataDao()));



                //RITM0301321 mangesh
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitMudsTemplateDao>(connectionString, new WorkPermitMudsTemplateDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitMudsGroupDao>(connectionString, new WorkPermitMudsGroupDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitMudsDao>(connectionString, new WorkPermitMudsDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitMudsDTODao>(connectionString, new WorkPermitMudsDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IWorkPermitMudsHistoryDao>(connectionString, new WorkPermitMudsHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IConfinedSpaceMudsDao>(connectionString, new ConfinedSpaceMudsDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IConfinedSpaceMudsDTODao>(connectionString,
                    new ConfinedSpaceMudsDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IConfinedSpaceMudsHistoryDao>(connectionString,
                    new ConfinedSpaceMudsHistoryDao()));

                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestMudsDao>(connectionString,
                    new PermitRequestMudsDao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestMudsDTODao>(connectionString,
                    new PermitRequestMudsDTODao()));
                DaoRegistry.RegisterDaoFor(CreateManagedDao<IPermitRequestMudsHistoryDao>(connectionString,
                    new PermitRequestMudsHistoryDao()));

                logger.Debug("Complete bootstrapping daos");
            }
            catch (Exception e)
            {
                logger.Error("Error bootstrapping daos: " + e.Message, e);
                throw;
            }
        }

        /// <summary>
        ///     Clears the registry and resets the activated flag (will cause Bootstrapper logic to rerun when it is called)
        /// </summary>
        public static void Reset()
        {
            activated = false;
            DaoRegistry.Clear();
            Clock.Enable();
        }

        public static TIDao CreateManagedDao<TIDao>(string connectionString, TIDao dao) where TIDao : class, IDao
        {
            TIDao wrappedDao = null;
            try
            {
                var cachingType = CachingType;

                var storedProcDaoInterceptor = new StoredProcDaoInterceptor(connectionString);

                if (cachingType == CachingTypeEnum.Distributed)
                {
                    var cache = cacheFactory.GetCache();
                    // this will attempt to connect to the caching server on the first usage.

                    IInterceptor[] interceptors;
                    if (StoredProcThreshold.HasValue)
                    {
                        interceptors = new IInterceptor[]
                        {
                            new CacheQueryByIdInterceptor(cache),
                            new CacheQueryInterceptor(cache),
                            new CacheQueryAllBySiteIdInterceptor(cache),
                            new CacheQueryListByIdInterceptor(cache),
                            new CacheInsertOrUpdateInterceptor(cache),
                            new CacheRemoveInterceptor(cache),
                            new CacheHistoryInterceptor(cache),
                            new CacheHistoryInsertInterceptor(cache),
                            new CacheQueryAllInterceptor(cache),
                            new CacheQueryListInterceptor(cache),
                            new StoredProcPerformanceInterceptor(StoredProcThreshold.Value),
                            storedProcDaoInterceptor
                        };
                    }
                    else
                    {
                        interceptors = new IInterceptor[]
                        {
                            new CacheQueryByIdInterceptor(cache),
                            new CacheQueryInterceptor(cache),
                            new CacheQueryAllBySiteIdInterceptor(cache),
                            new CacheQueryListByIdInterceptor(cache),
                            new CacheInsertOrUpdateInterceptor(cache),
                            new CacheRemoveInterceptor(cache),
                            new CacheHistoryInterceptor(cache),
                            new CacheHistoryInsertInterceptor(cache),
                            new CacheQueryAllInterceptor(cache),
                            new CacheQueryListInterceptor(cache),
                            storedProcDaoInterceptor
                        };
                    }

                    wrappedDao = proxyGenerator.CreateInterfaceProxyWithTarget(dao, cachingProxyGenerationOptions,
                        interceptors);
                }
                if (cachingType == CachingTypeEnum.None)
                {
                    IInterceptor[] interceptors;

                    if (StoredProcThreshold.HasValue)
                    {
                        interceptors = new IInterceptor[]
                        {
                            new StoredProcPerformanceInterceptor(StoredProcThreshold.Value),
                            storedProcDaoInterceptor
                        };
                    }
                    else
                    {
                        interceptors = new IInterceptor[]
                        {
                            storedProcDaoInterceptor
                        };
                    }

                    wrappedDao = proxyGenerator.CreateInterfaceProxyWithTarget(dao, interceptors);
                }

                return wrappedDao;
            }
            catch (Exception)
            {
                logger.ErrorFormat("Could not create Castle Dynamic Proxy for {0}", typeof (TIDao).FullName);
                throw;
            }
        }

        private enum CachingTypeEnum
        {
            None,
            Distributed
        }
    }
}