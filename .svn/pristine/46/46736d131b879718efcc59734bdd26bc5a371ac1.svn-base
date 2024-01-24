using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.PriorityPage;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Services;
using DevExpress.Office.Utils;
using DevExpress.XtraRichEdit.API.Word;
using User = Microsoft.VisualBasic.ApplicationServices.User;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPagePresenter
    {
        private readonly IActionItemService actionItemService;
        private readonly IAuthorized authorized;
        private readonly IDirectiveService directiveService;
        private readonly IExcursionImportService excursionImportService;
        private readonly IExcursionResponseService excursionResponseService;
        private readonly IFormEdmontonService formEdmontonService;
        private readonly IFormOilsandsService formOilsandsService;

        private readonly ILogService logService;
        private readonly IObjectLockingService objectLockingService;
        private readonly IPriorityPage page;
        private readonly IPriorityPageSectionConfigurationService priorityPageSectionConfigurationService;
        private readonly IRemoteEventRepeater remoteEventRepeater;
        private readonly IShiftHandoverService shiftHandoverService;
        private readonly ISiteCommunicationService siteCommunicationService;
        private readonly ITargetAlertService targetAlertService;
        private readonly UserContext userContext;
        private readonly IWorkPermitEdmontonService workPermitEdmontonService;
        private readonly IWorkPermitLubesService workPermitLubesService;
        private readonly IWorkPermitMontrealService workPermitMontrealService;
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly IWorkPermitMudsService workPermitMudsService;//RITM0301321 - mangesh
        private readonly IWorkPermitFortHillsService workPermitFortHillsService;

        private int dataFetches;
        private PresenterContainer presenterContainer;

        public PriorityPagePresenter()
        {
            page = new PriorityPage();
            authorized = new Authorized();
            userContext = ClientSession.GetUserContext();
            var clientServiceRegistry = ClientServiceRegistry.Instance;

            remoteEventRepeater = clientServiceRegistry.RemoteEventRepeater;

            logService = clientServiceRegistry.GetService<ILogService>();
            actionItemService = clientServiceRegistry.GetService<IActionItemService>();
            targetAlertService = clientServiceRegistry.GetService<ITargetAlertService>();
            shiftHandoverService = clientServiceRegistry.GetService<IShiftHandoverService>();
            workPermitMontrealService = clientServiceRegistry.GetService<IWorkPermitMontrealService>();
            workPermitEdmontonService = clientServiceRegistry.GetService<IWorkPermitEdmontonService>();
            workPermitLubesService = clientServiceRegistry.GetService<IWorkPermitLubesService>();
            formEdmontonService = clientServiceRegistry.GetService<IFormEdmontonService>();
            formOilsandsService = clientServiceRegistry.GetService<IFormOilsandsService>();
            siteCommunicationService = clientServiceRegistry.GetService<ISiteCommunicationService>();
            directiveService = clientServiceRegistry.GetService<IDirectiveService>();
            priorityPageSectionConfigurationService =
                clientServiceRegistry.GetService<IPriorityPageSectionConfigurationService>();
            objectLockingService = clientServiceRegistry.GetService<IObjectLockingService>();
            excursionResponseService = clientServiceRegistry.GetService<IExcursionResponseService>();
            excursionImportService = clientServiceRegistry.GetService<IExcursionImportService>();
            functionalLocationService = clientServiceRegistry.GetService<IFunctionalLocationService>();
            workPermitMudsService = clientServiceRegistry.GetService<IWorkPermitMudsService>();//RITM0301321 - mangesh
            workPermitFortHillsService = clientServiceRegistry.GetService<IWorkPermitFortHillsService>();
            page.PageLoad += HandlePageLoad;
        }

        public IPriorityPage Page
        {
            get { return page; }
        }

        private void Page_Disposed(object sender, EventArgs e)
        {
            page.NodeClicked -= Page_NodeClicked;
            page.SectionConfigurationButtonClicked -= HandleSectionConfigurationButtonClicked;
        }


        private void HandlePageLoad()
        {
            page.SiteCommunications =
                siteCommunicationService.QueryBySiteAndDateTime(ClientSession.GetUserContext().SiteId, Clock.Now);

            CreateTreeAndQueryData();


            page.Disposed += Page_Disposed;
            page.NodeClicked += Page_NodeClicked;
            page.SectionConfigurationButtonClicked += HandleSectionConfigurationButtonClicked;
        }

        private PriorityPageSectionConfiguration GetSectionConfiguration(
            List<PriorityPageSectionConfiguration> configurations, PriorityPageSectionKey key)
        {
            return configurations.Find(c => c.SectionKey.Equals(key));
        }

        /// <summary>
        ///     The order of sections for ALL sites should be:
        ///     1. Daily Directives
        ///     2. Action Items
        ///     3. Target Alerts
        ///     4. Active Critical System Defeats (including Edmonton OP-14)
        ///     5. Shift Handover
        ///     6. Document Suggestions
        ///     7. Procedure Deviations
        ///     8. Forms
        ///     9. Safe Work Permits
        /// </summary>
        private void CreateTreeAndQueryData()
        {
            var tree = new PriorityPageTree();

            var configs = priorityPageSectionConfigurationService.QuerySectionConfigurations(userContext.User.IdValue);

            presenterContainer = new PresenterContainer(tree)
            {
                PriorityPageDirectiveSectionPresenter =
                    new PriorityPageDirectiveSectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        directiveService, GetSectionConfiguration(configs, PriorityPageSectionKey.Directive)),
                PriorityPageDirectiveLogSectionPresenter =
                    new PriorityPageDirectiveLogSectionPresenter(page, tree, authorized, userContext,
                        remoteEventRepeater, logService,
                        GetSectionConfiguration(configs, PriorityPageSectionKey.DirectiveLog)),
                PriorityPageActionItemSectionPresenter =
                    new PriorityPageActionItemSectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        actionItemService, GetSectionConfiguration(configs, PriorityPageSectionKey.ActionItem)),

                PriorityPageReadingSectionPresenter =
                    new PriorityPageReadingSectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        actionItemService, GetSectionConfiguration(configs, PriorityPageSectionKey.Reading)),            //ayman action item reading

                PriorityPageTargetAlertSectionPresenter =
                    new PriorityPageTargetAlertSectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        targetAlertService, GetSectionConfiguration(configs, PriorityPageSectionKey.TargetAlert)),
            };

            //if (userContext.SiteId == Site.EDMONTON_ID) { Last Min Change from Aditya removing if condution and this feture will be aplicable for all sites
            MergeDirectiveAndDailyDirective(tree);// DMND0005327( request no-10) Merge Directive and Daily Directive in one tree Node Amit Shukla
            // }
            AddCsdSection(tree, presenterContainer, configs);

            AddExcursionEventsSection(tree, presenterContainer, configs);

            AddShiftHandoverSection(tree, presenterContainer, configs);

            AddDocumentSuggestionSection(tree, presenterContainer, configs);

            AddProcedureDeviationSection(tree, presenterContainer, configs);

            AddFormSection(tree, presenterContainer, configs);

            AddPermitSection(tree, presenterContainer, configs);


            page.Disposed += (sender, args) => presenterContainer.PriorityPageDirectiveSectionPresenter.HandleDisposed();

            var dataFetchers = new List<DataFetcher>();










            // Daily Directive on blue strip
            var directiveLogsDataFetcher = new DataFetcher(this,                                     //ayman temp merge
                (pContainer, resultContainer) =>
                    resultContainer.LogPriorityPageDtos =
                        pContainer.PriorityPageDirectiveLogSectionPresenter.QueryDtos(),
                resultContainer =>
                    resultContainer.PresenterContainer.PriorityPageDirectiveLogSectionPresenter.LoadDtos(
                        resultContainer.LogPriorityPageDtos));









            var directivesDataFetcher = new DataFetcher(this,
                (pContainer, resultContainer) =>
                    resultContainer.DirectiveDtos = pContainer.PriorityPageDirectiveSectionPresenter.QueryDtos(),       //ayman testing
                resultContainer =>
                    resultContainer.PresenterContainer.PriorityPageDirectiveSectionPresenter.LoadDtos(
                        resultContainer.DirectiveDtos));

            var actionItemDataFetcher = new DataFetcher(this,
                (pContainer, resultContainer) =>
                    resultContainer.ActionItemDtos = pContainer.PriorityPageActionItemSectionPresenter.QueryDtos(),
                resultContainer =>
                    resultContainer.PresenterContainer.PriorityPageActionItemSectionPresenter.LoadDtos(
                        resultContainer.ActionItemDtos));

            var readingDataFetcher = new DataFetcher(this,                                           //ayman action item reading
                (pContainer, resultContainer) =>
                    resultContainer.ActionItemDtos = pContainer.PriorityPageReadingSectionPresenter.QueryDtos(),
                resultContainer =>
                    resultContainer.PresenterContainer.PriorityPageReadingSectionPresenter.LoadDtos(
                        resultContainer.ActionItemDtos));


            var shiftHandoverDataFetcher = new DataFetcher(this,
                (pContainer, resultContainer) =>
                    resultContainer.ShiftHandoverQuestionnairePriorityPageDtos =
                        pContainer.PriorityPageShiftHandoverSectionPresenter.QueryDtos(),
                resultContainer =>
                    resultContainer.PresenterContainer.PriorityPageShiftHandoverSectionPresenter.LoadDtos(
                        resultContainer.ShiftHandoverQuestionnairePriorityPageDtos));
            var targetAlertDataFetcher = new DataFetcher(this,
                (pContainer, resultContainer) =>
                    resultContainer.TargetAlertDtos = pContainer.PriorityPageTargetAlertSectionPresenter.QueryDtos(),
                resultContainer =>
                    resultContainer.PresenterContainer.PriorityPageTargetAlertSectionPresenter.LoadDtos(
                        resultContainer.TargetAlertDtos));

            dataFetchers.Add(directivesDataFetcher);







            dataFetchers.Add(directiveLogsDataFetcher); // Daily Directive on blue strip //ayman temp merge







            dataFetchers.Add(actionItemDataFetcher);
            dataFetchers.Add(readingDataFetcher);                           //ayman action item reading
            dataFetchers.Add(shiftHandoverDataFetcher);
            dataFetchers.Add(targetAlertDataFetcher);

            if (presenterContainer.PriorityPageWorkPermitEdmontonSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.WorkPermitEdmontonDtos =
                            pContainer.PriorityPageWorkPermitEdmontonSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageWorkPermitEdmontonSectionPresenter.LoadDtos(
                            resultContainer.WorkPermitEdmontonDtos)));
            }
            if (presenterContainer.PriorityPageWorkPermitFortHillsSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.WorkPermitFortHillsDtos =
                            pContainer.PriorityPageWorkPermitFortHillsSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageWorkPermitFortHillsSectionPresenter.LoadDtos(
                            resultContainer.WorkPermitFortHillsDtos)));
            }

            if (presenterContainer.PriorityPageWorkPermitMontrealSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.WorkPermitMontrealDtos =
                            pContainer.PriorityPageWorkPermitMontrealSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageWorkPermitMontrealSectionPresenter.LoadDtos(
                            resultContainer.WorkPermitMontrealDtos)));
            }

            if (presenterContainer.PriorityPageFormSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.FormDtos = pContainer.PriorityPageFormSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageFormSectionPresenter.LoadDtos(
                            resultContainer.FormDtos)));
            }

            if (presenterContainer.PriorityPageWorkPermitLubesSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.WorkPermitLubesDtos =
                            pContainer.PriorityPageWorkPermitLubesSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageWorkPermitLubesSectionPresenter.LoadDtos(
                            resultContainer.WorkPermitLubesDtos)));
            }

            if (presenterContainer.PriorityPageFormOilsandsSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.FormOilsandsDtos =
                            pContainer.PriorityPageFormOilsandsSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageFormOilsandsSectionPresenter.LoadDtos(
                            resultContainer.FormOilsandsDtos)));
            }

            if (presenterContainer.PriorityPageFormOP14SectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.FormOP14Dtos = pContainer.PriorityPageFormOP14SectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageFormOP14SectionPresenter.LoadDtos(
                            resultContainer.FormOP14Dtos)));
            }

            if (presenterContainer.PriorityPageLubesCsdSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.LubesCsdDtos = pContainer.PriorityPageLubesCsdSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageLubesCsdSectionPresenter.LoadDtos(
                            resultContainer.LubesCsdDtos)));
            }

            if (presenterContainer.PriorityPageMontrealCsdSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.MontrealCsdDtos = pContainer.PriorityPageMontrealCsdSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageMontrealCsdSectionPresenter.LoadDtos(
                            resultContainer.MontrealCsdDtos)));
            }

            if (presenterContainer.PriorityPageMontrealFormSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.MontrealFormDtos =
                            pContainer.PriorityPageMontrealFormSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageMontrealFormSectionPresenter.LoadDtos(
                            resultContainer.MontrealFormDtos)));
            }

            if (presenterContainer.PriorityPageLubesFormSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.LubesFormDtos =
                            pContainer.PriorityPageLubesFormSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageLubesFormSectionPresenter.LoadDtos(
                            resultContainer.LubesFormDtos)));
            }

            if (presenterContainer.PriorityPageExcursionEventSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.ExcursionEventPriorityPageDtos =
                            pContainer.PriorityPageExcursionEventSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageExcursionEventSectionPresenter.LoadDtos(
                            resultContainer.ExcursionEventPriorityPageDtos)));
            }

            if (presenterContainer.PriorityPageDocumentSuggestionSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.DocumentSuggestionDtos =
                            pContainer.PriorityPageDocumentSuggestionSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageDocumentSuggestionSectionPresenter.LoadDtos(
                            resultContainer.DocumentSuggestionDtos)));
            }

            if (presenterContainer.PriorityPageProcedureDeviationSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.ProcedureDeviationDtos =
                            pContainer.PriorityPageProcedureDeviationSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageProcedureDeviationSectionPresenter.LoadDtos(
                            resultContainer.ProcedureDeviationDtos)));
            }

            //RITM0268131 - mangesh
            if (presenterContainer.PriorityPageMudsTemporaryInstallationsSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.MudsTemporaryInstallationsDtos = pContainer.PriorityPageMudsTemporaryInstallationsSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageMudsTemporaryInstallationsSectionPresenter.LoadDtos(
                            resultContainer.MudsTemporaryInstallationsDtos)));
            }
            if (presenterContainer.PriorityPageMontrealSulphurFormSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.MudsTemporaryInstallationsDtos =
                            pContainer.PriorityPageMontrealSulphurFormSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageMontrealSulphurFormSectionPresenter.LoadDtos(
                            resultContainer.MudsTemporaryInstallationsDtos)));
            }

            //RITM0301321 - mangesh
            if (presenterContainer.PriorityPageWorkPermitMudsSectionPresenter != null)
            {
                dataFetchers.Add(new DataFetcher(this,
                    (pContainer, resultContainer) =>
                        resultContainer.WorkPermitMudsDtos =
                            pContainer.PriorityPageWorkPermitMudsSectionPresenter.QueryDtos(),
                    resultContainer =>
                        resultContainer.PresenterContainer.PriorityPageWorkPermitMudsSectionPresenter.LoadDtos(
                            resultContainer.WorkPermitMudsDtos)));
            }

            dataFetches = dataFetchers.Count;
            page.ViewEnabled = false;

            foreach (var dataFetcher in dataFetchers)
            {
                var backgroundHelper =
                    new BackgroundHelper<PresenterContainer, ResultContainer>(new ClientBackgroundWorker(), dataFetcher);
                backgroundHelper.Run(presenterContainer);
            }

            //Dharmesh  DMND0005327(Edmonton enh - II request no-10) Remove Directive Node -- Start 24May2017
            //  if (userContext.SiteId == Site.EDMONTON_ID) Last Min Change from Aditya removing if condution and this feture will be aplicable for all sites
            //  {
            RemoveDirectiveNode(tree);
            //  }
            //Dharmesh  DMND0005327(Edmonton enh - II request no-10) Remove Directive Node -- End 24May2017

        }

        ///*Amit Shukla Code Start */
        // DMND0005327( request no-10) Merge Directive and Daily Directive in one tree Node
        public void MergeDirectiveAndDailyDirective(PriorityPageTree Maintree)
        {

            // Node id of Deirective and Daily Directive
            //change parent id of all nodes Directive Tab to make it as id of daily directives
            long NodeidDirective = 0;
            long NodeidDailyDirective = 0;
            bool nodeDirectiveExistForMerge = false;
            //PriorityPageDataNode removeNode = new PriorityPageDataNode(0,PriorityPageNode ,);
            foreach (PriorityPageNode priorityPageNode in Maintree.Nodes)
            {
                if (priorityPageNode.GroupName.Trim() == StringResources.DirectiveTabText)
                {
                    NodeidDirective = priorityPageNode.NodeId;
                    nodeDirectiveExistForMerge = true;
                }
                if (nodeDirectiveExistForMerge && (priorityPageNode.GroupName.Trim() == StringResources.DailyDirectiveTabText))
                {
                    NodeidDailyDirective = priorityPageNode.NodeId;
                }
            }
            foreach (PriorityPageNode priorityPageNode in Maintree.Nodes)
            {
                if (priorityPageNode.ParentNodeId != null)
                {
                    if (priorityPageNode.ParentNodeId.Value == NodeidDailyDirective)
                    {
                        priorityPageNode.ParentNodeId = NodeidDirective;
                    }
                }
            }

        }
        /*Amit Shukla Code Start */

        //Dharmesh  DMND0005327(Edmonton enh - II request no-10) Remove Directive Node -- Start 24May2017
        public void RemoveDirectiveNode(PriorityPageTree tree)
        {
            long nodeidDailyDirective = 100000;
            bool nodeDirectiveExistForRemove = false;
            foreach (PriorityPageNode priorityPageNode in tree.Nodes)
            {
                if (priorityPageNode.GroupName.Trim() == StringResources.DirectiveTabText)
                {
                    nodeDirectiveExistForRemove = true;
                }
                if (nodeDirectiveExistForRemove && (priorityPageNode.GroupName.Trim() == StringResources.DailyDirectiveTabText))
                {
                    nodeidDailyDirective = priorityPageNode.NodeId;
                }
            }
            if (nodeidDailyDirective != 100000)
            {

                tree.Nodes.RemoveAt(Convert.ToInt16(nodeidDailyDirective)); // Removing Empty node Daily Directive 
            }

        }
        //Dharmesh  DMND0005327(Edmonton enh - II request no-10) Remove Directive Node -- End 24May2017



        private void AddExcursionEventsSection(PriorityPageTree tree, PresenterContainer presenterContainer,
            List<PriorityPageSectionConfiguration> configs)
        {
            presenterContainer.PriorityPageExcursionEventSectionPresenter =
                new PriorityPageExcursionEventSectionPresenter(page, tree, authorized, userContext,
                    remoteEventRepeater,
                    excursionResponseService,
                    GetSectionConfiguration(configs, PriorityPageSectionKey.ExcursionEvent),
                    functionalLocationService,
                    excursionImportService);
        }

        private void AddShiftHandoverSection(PriorityPageTree tree, PresenterContainer presenterContainer,
            List<PriorityPageSectionConfiguration> configs)
        {
            presenterContainer.PriorityPageShiftHandoverSectionPresenter =
                new PriorityPageShiftHandoverSectionPresenter(page, tree, authorized, userContext,
                    remoteEventRepeater, shiftHandoverService,
                    GetSectionConfiguration(configs, PriorityPageSectionKey.ShiftHandover));
        }

        private void AddPermitSection(PriorityPageTree tree, PresenterContainer presenterContainer,
            List<PriorityPageSectionConfiguration> configs)
        {
            if (userContext.SiteId == Site.MONTREAL_ID)
            {
                presenterContainer.PriorityPageWorkPermitMontrealSectionPresenter =
                    new PriorityPageWorkPermitMontrealSectionPresenter(page, tree, authorized, userContext,
                        remoteEventRepeater, workPermitMontrealService,
                        GetSectionConfiguration(configs, PriorityPageSectionKey.WorkPermitMontreal));
            }
            else if (userContext.SiteId == Site.EDMONTON_ID)
            {
                presenterContainer.PriorityPageWorkPermitEdmontonSectionPresenter =
                    new PriorityPageWorkPermitEdmontonSectionPresenter(page, tree, authorized, userContext,
                        remoteEventRepeater, workPermitEdmontonService,
                        GetSectionConfiguration(configs, PriorityPageSectionKey.WorkPermitEdmonton));
            }
            else if (userContext.SiteId == Site.FORT_HILLS_ID)
            {
                presenterContainer.PriorityPageWorkPermitFortHillsSectionPresenter =
                    new PriorityPageWorkPermitFortHillsSectionPresenter(page, tree, authorized, userContext,
                        remoteEventRepeater, workPermitFortHillsService,
                        GetSectionConfiguration(configs, PriorityPageSectionKey.WorkPermitFortHills));
            }
            else if (userContext.SiteId == Site.LUBES_ID)
            {
                presenterContainer.PriorityPageWorkPermitLubesSectionPresenter =
                    new PriorityPageWorkPermitLubesSectionPresenter(page, tree, authorized, userContext,
                        remoteEventRepeater, workPermitLubesService,
                        GetSectionConfiguration(configs, PriorityPageSectionKey.WorkPermitLubes));
            }
            //RITM0301321 - mangesh
            if (userContext.SiteId == Site.MontrealSulphur_ID)
            {
                presenterContainer.PriorityPageWorkPermitMudsSectionPresenter =
                    new PriorityPageWorkPermitMudsSectionPresenter(page, tree, authorized, userContext,
                        remoteEventRepeater, workPermitMudsService,
                        GetSectionConfiguration(configs, PriorityPageSectionKey.WorkPermitMuds));
            }
        }

        private void AddCsdSection(PriorityPageTree tree, PresenterContainer presenterContainer,
            List<PriorityPageSectionConfiguration> configs)
        {
            if (userContext.SiteId == Site.EDMONTON_ID)
            {
                presenterContainer.PriorityPageFormOP14SectionPresenter =
                    new PriorityPageFormOP14SectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.FormOP14));
            }

            //ayman generic forms   ... fixes...
            if (userContext.SiteId == Site.SARNIA_ID)
            {
                presenterContainer.PriorityPageFormOP14SectionPresenter =
                    new PriorityPageFormOP14SectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.FormOP14));
            }


            else if (userContext.SiteId == Site.LUBES_ID)
            {
                presenterContainer.PriorityPageLubesCsdSectionPresenter =
                    new PriorityPageLubesCsdSectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.LubesCsd));
            }
            else if (userContext.SiteId == Site.MONTREAL_ID)
            {
                presenterContainer.PriorityPageMontrealCsdSectionPresenter =
                    new PriorityPageMontrealCsdSectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.MontrealCsd));
            }
            //RITM0268131 - mangesh
            else if (userContext.SiteId == Site.MontrealSulphur_ID)
            {
                presenterContainer.PriorityPageMudsTemporaryInstallationsSectionPresenter =
                    new PriorityPageMudsTemporaryInstallationsSectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.MudsTemporaryInstallations));
            }

            //DMND0010261-SELC CSD EdmontonPipeline
            if (userContext.SiteId == Site.SELC_ID)
            {
                presenterContainer.PriorityPageFormOP14SectionPresenter =
                    new PriorityPageFormOP14SectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.FormOP14));
            }
        }


        private void AddDocumentSuggestionSection(PriorityPageTree tree, PresenterContainer presenterContainer, List<PriorityPageSectionConfiguration> configs)
        {
            if (userContext.IsWoodBuffaloRegionSite)
            {
                presenterContainer.PriorityPageDocumentSuggestionSectionPresenter =
                    new PriorityPageDocumentSuggestionSectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.DocumentSuggestion));
            }
        }

        private void AddProcedureDeviationSection(PriorityPageTree tree, PresenterContainer presenterContainer, List<PriorityPageSectionConfiguration> configs)
        {
            if (userContext.IsWoodBuffaloRegionSite)
            {
                presenterContainer.PriorityPageProcedureDeviationSectionPresenter =
                    new PriorityPageProcedureDeviationSectionPresenter(page, tree, authorized, userContext, remoteEventRepeater,
                        formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.ProcedureDeviation));
            }
        }

        private void AddFormSection(PriorityPageTree tree, PresenterContainer presenterContainer,
            List<PriorityPageSectionConfiguration> configs)
        {
            if (userContext.SiteId == Site.EDMONTON_ID)
            {
                presenterContainer.PriorityPageFormSectionPresenter =
                    new PriorityPageEdmontonFormSectionPresenter(page, tree, authorized, userContext,
                        remoteEventRepeater, formEdmontonService,
                        GetSectionConfiguration(configs, PriorityPageSectionKey.EdmontonForm));
            }


            //ayman generic forms
            else if (userContext.SiteId == Site.SARNIA_ID)
            {
                presenterContainer.PriorityPageFormSectionPresenter = new PriorityPageEdmontonFormSectionPresenter(page, tree, authorized, userContext, remoteEventRepeater, formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.EdmontonForm));
            }


            else if (userContext.SiteId == Site.OILSAND_ID || userContext.SiteId == Site.FORT_HILLS_ID || userContext.SiteId == Site.SITE_WIDE_SERVICES_ID //ayman forthills    ayman e&u
                    || userContext.SiteId == Site.VOYAGEUR_ID)   //mangesh - ETF
            {
                //presenterContainer.PriorityPageFormOilsandsSectionPresenter =
                //    new PriorityPageFormOilsandsSectionPresenter(page, tree, authorized, userContext,
                //        remoteEventRepeater, formOilsandsService,
                //        GetSectionConfiguration(configs, PriorityPageSectionKey.FormOilsands));
                //RITM0341710 - mangesh TODO: If fort hill have other forms (other than generic forms) then it should be union with generic form
                if (userContext.SiteId == Site.FORT_HILLS_ID)
                {
                    presenterContainer.PriorityPageFormSectionPresenter =
                        new PriorityPageEdmontonFormSectionPresenter(page, tree, authorized, userContext,
                            remoteEventRepeater, formEdmontonService,
                            GetSectionConfiguration(configs, PriorityPageSectionKey.EdmontonForm));
                }
                else
                {
                    presenterContainer.PriorityPageFormOilsandsSectionPresenter =
                    new PriorityPageFormOilsandsSectionPresenter(page, tree, authorized, userContext,
                        remoteEventRepeater, formOilsandsService,
                        GetSectionConfiguration(configs, PriorityPageSectionKey.FormOilsands));
                }
            }
            else if (userContext.SiteId == Site.MONTREAL_ID)
            {
                presenterContainer.PriorityPageMontrealFormSectionPresenter =
                    new PriorityPageMontrealFormSectionPresenter(page, tree, authorized, userContext,
                        remoteEventRepeater,
                        formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.MontrealForm));
            }
            else if (userContext.SiteId == Site.LUBES_ID)
            {
                presenterContainer.PriorityPageLubesFormSectionPresenter =
                    new PriorityPageLubesFormSectionPresenter(page, tree, authorized, userContext,
                        remoteEventRepeater,
                        formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.LubesForm));
            }
            //RITM0268131 - mangesh
            else if (userContext.SiteId == Site.MontrealSulphur_ID)
            {
                presenterContainer.PriorityPageMontrealSulphurFormSectionPresenter =
                    new PriorityPageMontrealSulphurFormSectionPresenter(page, tree, authorized, userContext,
                        remoteEventRepeater,
                        formEdmontonService, GetSectionConfiguration(configs, PriorityPageSectionKey.MudsTemporaryInstallations));
            }
        }

        private void Page_NodeClicked(PriorityPageDataNode node)
        {
            var isPopup = true;

            //ayman temp merge
            if (node.NodeData is DirectiveLogNodeData) // || node.NodeData is DirectiveNodeData)    testing
            {

                var presenter =
                            new PriorityPageDirectiveLogDetailsPresenter(node.NodeData.DomainObjectId, authorized,
                                remoteEventRepeater);
                presenter.Run(page.MainParentForm);
            }

            else if (node.NodeData is DirectiveNodeData)
            {
                new PriorityPageDirectiveDetailsPresenter(node.NodeData.DomainObjectId, authorized, remoteEventRepeater)
                    .Run(page.MainParentForm);
            }

            else if (node.NodeData is ActionItemNodeData)
            {
                var presenter =
                    new PriorityPageActionItemDetailsPresenter(node.NodeData.DomainObjectId, authorized,
                        actionItemService, formEdmontonService);
                presenter.Run(page.MainParentForm);
            }
            else if (node.NodeData is ShiftHandoverNodeData)
            {
                var presenter =
                    new PriorityPageShiftHandoverDetailsPresenter(node.NodeData.DomainObjectId, authorized,
                        remoteEventRepeater);
                presenter.Run(page.MainParentForm);
            }
            else if (node.NodeData is WorkPermitMontrealNodeData)
            {
                var presenter =
                    new PriorityPageWorkPermitMontrealDetailsPresenter(node.NodeData.DomainObjectId);
                presenter.Run(page.MainParentForm);
            }
            //RITM0301321 - mangesh
            else if (node.NodeData is WorkPermitMudsNodeData)
            {
                var presenter =
                    new PriorityPageWorkPermitMudsDetailsPresenter(node.NodeData.DomainObjectId);
                presenter.Run(page.MainParentForm);
            }
            else if (node.NodeData is WorkPermitEdmontonNodeData)
            {
                var presenter = new PriorityPageWorkPermitEdmontonDetailsPresenter(node.NodeData.DomainObjectId);
                presenter.Run(page.MainParentForm);
            }
            else if (node.NodeData is WorkPermitLubesNodeData)
            {
                var presenter = new PriorityPageWorkPermitLubesDetailsPresenter(node.NodeData.DomainObjectId);
                presenter.Run(page.MainParentForm);
            }
            else if (node.NodeData is TargetAlertNodeData)
            {
                var presenter =
                    new PriorityPageTargetAlertDetailsPresenter(node.NodeData.DomainObjectId, authorized,
                        remoteEventRepeater);
                presenter.Run(page.MainParentForm);
            }
            else if (node.NodeData is ExcursionEventNodeData)
            {
                var excursionNode = node.NodeData as ExcursionEventNodeData;
                DisplayExcursionResponseForm(excursionNode.Dto);
            }
            else if (node.NodeData is DocumentSuggestionNodeData)
            {
                var documentSuggestionNode = node.NodeData as DocumentSuggestionNodeData;
                DisplayDocumentSuggestionForm(documentSuggestionNode.Dto);
            }
            // TODO: add procedure deviation node data

//            else if (node.NodeData is DocumentSuggestionNodeData)
            //            {
            //                var documentSuggestionNode = node.NodeData as DocumentSuggestionNodeData;
            //                DisplayDocumentSuggestionForm(documentSuggestionNode.Dto);
            //            }
            else if (node.NodeData is FormNodeData)
            {
                var formNodeData = node.NodeData as FormNodeData;
                var multiGridPage = new MultiGridFormPage();

                var context = EdmontonContextFactory.GetContext(formEdmontonService, workPermitEdmontonService,
                    formNodeData.FormType, multiGridPage);
                var form = context.QueryByIdAndSiteId(formNodeData.DomainObjectId, userContext.SiteId);
                //ayman generic forms   

                //ayman Sarnia eip DMND0008992
                if (form is FormGN75B)
                {
                    DisplaySarniaFormGN75B(form as FormGN75B);
                }
                else
                {

                    var baseForm = form as BaseEdmontonForm;
                    if (baseForm == null)
                    {
                        throw new OLTException("Type {0} cannot be cast to a BaseEdmontonForm", form.GetType().FullName);
                    }

                    if (form is MontrealCsd)
                    {
                        DisplayMontrealCsdForm(form.IdValue);
                    }
                    else if (form is LubesCsdForm)
                    {
                        DisplayLubesCsdForm(form.IdValue);
                    }
                    else if (form is LubesAlarmDisableForm)
                    {
                        DisplayLubesAlarmDisableForm(form.IdValue);
                    }
                    else if (form is FormOP14)
                    {
                        DisplayOP14Form(form.IdValue, userContext.SiteId); //ayman generic forms     ,form.siteid
                    }
                    //RITM0268131 - mangesh
                    if (form is TemporaryInstallationsMUDS)
                    {
                        DisplayMudsTemporaryInstallationForm(form.IdValue);
                    }                    //generic template - mangesh
                    else if (form is FormGenericTemplate)
                    {
                        long formtypeid = ((FormGenericTemplate)(form)).FormTypeId;
                        DisplayGenericTemplateForm(form.IdValue, userContext.SiteId, formtypeid);
                    }
                    else
                    {
                        var overtimeForm = form as OvertimeForm;

                        var canEditEdmontonForm = ((overtimeForm != null &&
                                                    authorized.ToCreateOvertimeForm(userContext.UserRoleElements)) ||
                                                   authorized.ToEditEdmontonForm(userContext.UserRoleElements,
                                                       baseForm.FormStatus,
                                                       baseForm.FormType));

                        if (canEditEdmontonForm)
                        {
                            PagePresenterHelper.LockDatabaseObjectWhileInUse(context.Edit, form, form.ObjectIdentifier,
                                LockType.Edit, userContext.User, objectLockingService);
                        }
                        else
                        {
                            context.SelectedDomainObjectId = form.Id;
                            var presenter = new PriorityPageFormDetailsPresenter(baseForm, multiGridPage, context);
                            presenter.Run(page.MainParentForm);
                        }
                    }
                }
            }
            else if (node.NodeData is FormSarniaNodeData)
            {
                var formNodeData = node.NodeData as FormSarniaNodeData;
                var multiGridPage = new MultiGridFormPage();

                var context = EdmontonContextFactory.GetContext(formEdmontonService, workPermitEdmontonService,
                    formNodeData.FormType, multiGridPage);
                var form = context.QueryByIdAndSiteId(formNodeData.DomainObjectId, userContext.SiteId);
                //ayman generic forms   

                //ayman Sarnia eip DMND0008992
                if (form is FormGN75B)
                {
                    DisplaySarniaFormGN75B(form as FormGN75B);
                }
            }
            else if (node.NodeData is FormOP14NodeData)
            {
                if (ClientSession.GetUserContext().IsSelcSite)///DMND0010261-SELC CSD EdmontonPipeline
                {
                    DisplayPipelineOP14Form(node.NodeData.DomainObjectId, userContext.SiteId);
                }
                else
                {
                    DisplayOP14Form(node.NodeData.DomainObjectId, userContext.SiteId); //ayman generic forms     ,form.siteid
                }
               // DisplayOP14Form(node.NodeData.DomainObjectId, userContext.SiteId); //ayman generic forms
            }
            else if (node.NodeData is LubesCsdNodeData)
            {
                DisplayLubesCsdForm(node.NodeData.DomainObjectId);
            }
            else if (node.NodeData is FormOilsandsNodeData)
            {
                var formNodeData = (FormOilsandsNodeData)node.NodeData;
                if (formNodeData.FormType == OilsandsFormType.Training)
                {
                    var form = formOilsandsService.QueryFormOilsandsTrainingById(formNodeData.DomainObjectId);
                    if (authorized.ToEditForm(userContext, new FormOilsandsTrainingDTO(form))) // ayman enhance forms
                    {
                        var presenter = new FormOilsandsTrainingFormPresenter(form);
                        presenter.View.ShowDialog(page.MainParentForm);
                        presenter.View.Dispose();
                    }
                    else
                    {
                        var page = new MultiGridFormPage();

                        var contexts = new List<IMultiGridContext>();
                        contexts.Add(new PriorityPageOilsandsTrainingFormContext(form, formOilsandsService, page));

                        var presenter = new PriorityPageFormOilsandsTrainingDetailsPresenter(form, page, contexts);
                        presenter.Run(page.MainParentForm);
                    }
                }
            }
            else if (node.NodeData is MontrealCsdNodeData)
            {
                DisplayMontrealCsdForm(node.NodeData.DomainObjectId);
            }
            //RITM0268131 - mangesh
            else if (node.NodeData is MudsTemporaryInstallationsNodeData)
            {
                DisplayMudsTemporaryInstallationForm(node.NodeData.DomainObjectId);
            }
            else
            {
                isPopup = false;

                if (node.NodeData is WorkPermitNodeData)
                {
                    page.MainParentForm.SelectSectionAndItem(PageKey.WORK_PERMIT_PAGE, node.NodeData.DomainObjectId);
                }
            }

            if (isPopup)
            {
                page.Refocus();
            }
        }

        private void DisplayExcursionResponseForm(ExcursionEventPriorityPageDTO dto)
        {
            if (dto == null || dto.ExcursionCount == 0) return;

            var excursionIds = dto.ExcursionIds;

            var opmExcursionEditPackage =
                excursionResponseService.CreateEditPackage(excursionIds);
            var presenter = new EditExcursionResponsePresenter(new ExcursionResponseForm(), opmExcursionEditPackage);
            presenter.Run(page.MainParentForm);
        }

        private void DisplayDocumentSuggestionForm(DocumentSuggestionDTO dto)
        {
            var multiGridFormPage = new MultiGridFormPage();

            var form = formEdmontonService.QueryDocumentSuggestionFormById(dto.IdValue);
            var gridAndDetailsForm = new GridAndDetailsForm();
            IMultiGridContext documentSuggestionContext =
                new PriorityPageDocumentSuggestionFormContext(gridAndDetailsForm, form,
                    formEdmontonService, multiGridFormPage);

            if (form != null && dto.CanEdit() &&
                (authorized.ToEditFormDocumentSuggestion(userContext.UserRoleElements, userContext.SiteId) ||
                 authorized.ToApproveFormDocumentSuggestion(userContext.UserRoleElements, userContext.SiteId)))
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(documentSuggestionContext.Edit, form,
                    form.ObjectIdentifier,
                    LockType.Edit, userContext.User, objectLockingService);
            }
            else
            {
                var contexts = new List<IMultiGridContext>
                {
                    documentSuggestionContext
                };

                var presenter = new PriorityPageDocumentSuggestionDetailsPresenter(gridAndDetailsForm, multiGridFormPage,
                    contexts);
                presenter.Run(multiGridFormPage.MainParentForm);
            }
        }

        private void DisplayOP14Form(long formId, long siteid)             //ayman generic forms
        {
            var multiGridFormPage = new MultiGridFormPage();

            var form = formEdmontonService.QueryFormOP14ByIdAndSiteId(formId, siteid);         //ayman generic forms
            var gridAndDetailsForm = new GridAndDetailsForm();
            IMultiGridContext op14FormContext = new PriorityPageEdmontonOP14FormContext(gridAndDetailsForm, form,
                formEdmontonService, multiGridFormPage);

            if (form != null && authorized.ToEditFormOP14(userContext.UserRoleElements, form.FormStatus))
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(op14FormContext.Edit, form, form.ObjectIdentifier,
                    LockType.Edit, userContext.User, objectLockingService);
            }
            else
            {
                var contexts = new List<IMultiGridContext>
                {
                    op14FormContext
                };

                var presenter = new PriorityPageFormOP14DetailsPresenter(gridAndDetailsForm, multiGridFormPage,
                    contexts);
                presenter.Run(multiGridFormPage.MainParentForm);
            }
        }
        //DMND0010261-SELC CSD EdmontonPipeline
        private void DisplayPipelineOP14Form(long formId, long siteid)             
        {
            var multiGridFormPage = new MultiGridFormPage();

            var form = formEdmontonService.QueryFormOP14ByIdAndSiteId(formId, siteid);         
            var gridAndDetailsForm = new GridAndDetailsForm();
            IMultiGridContext op14FormContext = new CSDPipelineFormContext(formEdmontonService, multiGridFormPage);
               // new PriorityPageEdmontonOP14FormContext(gridAndDetailsForm, form,formEdmontonService, multiGridFormPage);

            if (form != null && authorized.ToEditFormOP14(userContext.UserRoleElements, form.FormStatus))
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(op14FormContext.Edit, form, form.ObjectIdentifier,
                    LockType.Edit, userContext.User, objectLockingService);
            }
            else
            {
                var contexts = new List<IMultiGridContext>
                {
                    op14FormContext
                };

                var presenter = new PriorityPagePipelineFormOP14DetailsPresenter(gridAndDetailsForm, multiGridFormPage,
                    contexts);
                presenter.Run(multiGridFormPage.MainParentForm);
            }
        }
        //End DMND0010261-SELC CSD EdmontonPipeline

        //generic template  mangesh
        private void DisplayGenericTemplateForm(long formId, long siteid, long formtypeid)
        {
            var multiGridFormPage = new MultiGridFormPage();
            var form = formEdmontonService.QueryFormGenericTemplateByIdAndSiteId(formId, siteid, formtypeid, userContext.Site.Plants[0].IdValue); //INC0251500 - mangesh
            var gridAndDetailsForm = new GridAndDetailsForm();
            IMultiGridContext opGenericTemplateFormContext = new PriorityPageEdmontonGenericTemplateFormContext(gridAndDetailsForm, form,
                formEdmontonService, multiGridFormPage, formtypeid, userContext.Site.Plants[0].IdValue); //INC0251500 - mangesh

            bool hasEdit = authorized.ToEditFormGenericTemplate(userContext.UserRoleElements, form.FormStatus,
                                form.FormType, ClientSession.GetUserContext().Site);
            bool hasCreate = authorized.ToCreateFormGenericTemplate(userContext.UserRoleElements, form.FormStatus,
                                form.FormType, ClientSession.GetUserContext().Site);
            bool hasApprove = authorized.ToApproveOrCloseFormGenericTemplate(userContext.UserRoleElements, form.FormStatus,
                                form.FormType, ClientSession.GetUserContext().Site);


            if ((hasEdit && userContext.User.IdValue == form.CreatedBy.IdValue) || hasEdit)
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(opGenericTemplateFormContext.Edit, form, form.ObjectIdentifier,
                    LockType.Edit, userContext.User, objectLockingService);
            }
            else if ((hasCreate && userContext.User.IdValue == form.CreatedBy.IdValue) || (hasApprove))//  && userContext.User.IdValue == form.CreatedBy.IdValue
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(opGenericTemplateFormContext.Edit, form, form.ObjectIdentifier,
                    LockType.Edit, userContext.User, objectLockingService);
            }
            else
            {
                var contexts = new List<IMultiGridContext>
                {
                    opGenericTemplateFormContext
                };

                var presenter = new PriorityPageFormGenericTemplateDetailsPresenter(gridAndDetailsForm, multiGridFormPage,
                    contexts, formtypeid);
                presenter.Run(multiGridFormPage.MainParentForm);
            }
        }


        //ayman Sarnia eip DMND0008992
        public void ShowEipTemplate(FormGN75B template)
        {
            var multiGridFormPage = new MultiGridFormPage();

            var newform = template;
            var gridAndDetailsForm = new GridAndDetailsForm();
            FormEdmontonGN75BDetails sarniaFormGN75Bdetails = new FormEdmontonGN75BDetails("Template #", "Work Scope");
            IMultiGridContext sarniaGN75BTemplateContext = new EdmontonGN75BTemplateContext(formEdmontonService, multiGridFormPage);
            if (newform != null)               //ayman Sarnia eip DMND0008992
            {
                var contexts = new List<IMultiGridContext>
                {
                    sarniaGN75BTemplateContext
                };

                var presenter = new FormGN75BSarniaTemplatePresenter(newform, true); // PriorityPageSarniaEipIssueDetailsPresenter(gridAndDetailsForm, multiGridFormPage, contexts);
                var dtos = newform; // (FormGN75B)formEdmontonService.QueryFormGN75BTemplateByIdAndSiteId(newform.IdValue,ClientSession.GetUserContext().SiteId);
                presenter.Run(multiGridFormPage.MainParentForm);
                //presenter.Run(multiGridFormPage.MainParentForm,dtos);
            }
        }

        //ayman Sarnia eip DMND0008992
        private void DisplaySarniaFormGN75B(FormGN75B form)
        {
            var multiGridFormPage = new MultiGridFormPage();

            var newform = formEdmontonService.QueryFormGN75BSarniaByIdAndSiteId(form.IdValue, ClientSession.GetUserContext().SiteId);
            var gridAndDetailsForm = new GridAndDetailsForm();
            FormEdmontonGN75BDetails sarniaFormGN75Bdetails = new FormEdmontonGN75BDetails("Issue #", "Work Scope");
            IMultiGridContext sarniaGN75BContext = new EdmontonGN75BSarniaEIPContext(formEdmontonService, multiGridFormPage);
            if (newform != null && authorized.ToEditEipIssue(userContext.UserRoleElements))               //ayman Sarnia eip DMND0008992
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(sarniaGN75BContext.Edit, newform,
                    newform.ObjectIdentifier,
                    LockType.Edit, userContext.User, objectLockingService);
            }
            else
            {
                var contexts = new List<IMultiGridContext>
                {
                    sarniaGN75BContext
                };

                var presenter = new PriorityPageSarniaEipIssueDetailsPresenter(gridAndDetailsForm, multiGridFormPage,
                    contexts);
                presenter.Run(multiGridFormPage.MainParentForm);
            }
        }




        private void DisplayMontrealCsdForm(long formId)
        {
            var multiGridFormPage = new MultiGridFormPage();

            var form = formEdmontonService.QueryMontrealCsdById(formId);
            var gridAndDetailsForm = new GridAndDetailsForm();
            IMultiGridContext montrealCsdContext = new PriorityPageMontrealCsdFormContext(gridAndDetailsForm, form,
                formEdmontonService, multiGridFormPage);

            if (form != null && authorized.ToEditMontrealCsd(userContext.UserRoleElements, form.FormStatus))
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(montrealCsdContext.Edit, form,
                    form.ObjectIdentifier,
                    LockType.Edit, userContext.User, objectLockingService);
            }
            else
            {
                var contexts = new List<IMultiGridContext>
                {
                    montrealCsdContext
                };

                var presenter = new PriorityPageMontrealCsdDetailsPresenter(gridAndDetailsForm, multiGridFormPage,
                    contexts);
                presenter.Run(multiGridFormPage.MainParentForm);
            }
        }

        //RITM0268131 - mangesh
        private void DisplayMudsTemporaryInstallationForm(long formId)
        {
            var multiGridFormPage = new MultiGridFormPage();
            var form = formEdmontonService.QueryMudsTemporaryInstallationsById(formId);
            var gridAndDetailsForm = new GridAndDetailsForm();
            IMultiGridContext mudsTiContext = new PriorityPageMudsTemporaryInstallationFormContext(gridAndDetailsForm, form,
                formEdmontonService, multiGridFormPage);
            bool hasEdit = authorized.ToEditMudsTemporaryInstallations(userContext.UserRoleElements, form.FormStatus);
            bool hasCreate = authorized.ToCreateMudsTemporaryInstallationsForm(userContext.UserRoleElements);
            bool hasApprove = authorized.ToApproveOrCloseMudsTemporaryInstallationsForms(userContext.UserRoleElements);

            if ((hasEdit && userContext.User.IdValue == form.CreatedBy.IdValue) || hasEdit)
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(mudsTiContext.Edit, form,
                                    form.ObjectIdentifier,
                                    LockType.Edit, userContext.User, objectLockingService);
            }
            else if ((hasCreate && userContext.User.IdValue == form.CreatedBy.IdValue) || (hasApprove))
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(mudsTiContext.Edit, form,
                                    form.ObjectIdentifier,
                                    LockType.Edit, userContext.User, objectLockingService);
            }
            else
            {
                var contexts = new List<IMultiGridContext>
                {
                    mudsTiContext
                };
                var presenter = new PriorityPageMUDSTemporaryInstallationsDetailsPresenter(gridAndDetailsForm, multiGridFormPage,
                    contexts);
                presenter.Run(multiGridFormPage.MainParentForm);
            }
        }


        private void DisplayLubesCsdForm(long formId)
        {
            var multiGridFormPage = new MultiGridFormPage();

            var form = formEdmontonService.QueryLubesCsdFormById(formId);
            var gridAndDetailsForm = new GridAndDetailsForm();
            IMultiGridContext lubesCsdContext = new PriorityPageLubesCsdFormContext(gridAndDetailsForm, form,
                formEdmontonService, multiGridFormPage);

            if (form != null && authorized.ToEditFormLubesCsd(userContext.UserRoleElements, form.FormStatus))
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(lubesCsdContext.Edit, form, form.ObjectIdentifier,
                    LockType.Edit, userContext.User, objectLockingService);
            }
            else
            {
                var contexts = new List<IMultiGridContext>
                {
                    lubesCsdContext
                };

                var presenter = new PriorityPageLubesCsdDetailsPresenter(gridAndDetailsForm, multiGridFormPage,
                    contexts);
                presenter.Run(multiGridFormPage.MainParentForm);
            }
        }

        private void DisplayLubesAlarmDisableForm(long formId)
        {
            var multiGridFormPage = new MultiGridFormPage();

            var form = formEdmontonService.QueryLubesAlarmDisableFormById(formId);
            var gridAndDetailsForm = new GridAndDetailsForm();
            IMultiGridContext lubesAlarmDisableContext = new PriorityPageLubesAlarmDisableFormContext(
                gridAndDetailsForm, form,
                formEdmontonService, multiGridFormPage);

            if (form != null && authorized.ToEditFormLubesAlarmDisable(userContext.UserRoleElements, form.FormStatus))
            {
                PagePresenterHelper.LockDatabaseObjectWhileInUse(lubesAlarmDisableContext.Edit, form,
                    form.ObjectIdentifier,
                    LockType.Edit, userContext.User, objectLockingService);
            }
            else
            {
                var contexts = new List<IMultiGridContext>
                {
                    lubesAlarmDisableContext
                };

                var presenter = new PriorityPageLubesAlarmDisableDetailsPresenter(gridAndDetailsForm, multiGridFormPage,
                    contexts);
                presenter.Run(multiGridFormPage.MainParentForm);
            }
        }

        private void HandleSectionConfigurationButtonClicked(PriorityPageSectionKey sectionKey)
        {
            var presenter = new PriorityPageSectionConfigurationFormPresenter(sectionKey, userContext.User);
            var result = presenter.RunAndReturnTheEditObject(page.MainParentForm);

            if (result.Result == DialogResult.OK)
            {
                var sectionConfigurationByKey = page.GetSectionConfigurationByKey(sectionKey);
                sectionConfigurationByKey.SectionConfiguration = result.Output;

                if (sectionKey.Equals(PriorityPageSectionKey.ShiftHandover) &&
                    !userContext.SiteConfiguration.ShowShiftHandoversByWorkAssignmentOnPriorityPage)
                // This is to avoid refreshing all the data if the site doesn't allow user configurable work assignment filters.
                {
                    CreateTreeAndQueryData();
                }
                else if (sectionKey.Equals(PriorityPageSectionKey.ActionItem) &&
                         !userContext.SiteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage)
                // This is to avoid refreshing all the data if the site doesn't allow user configurable work assignment filters.
                {
                    CreateTreeAndQueryData();
                }
                else
                {
                    if (presenter.PreferencesWereCleared)
                    {
                        page.ExpandSectionAndMarkAsNotHavingConfiguration(sectionKey);
                    }
                    else
                    {
                        page.MarkSectionAsHavingConfiguration(sectionKey);
                    }
                }
            }
        }

        private void CheckIfAllDataIsLoadedAndCleanUp(ResultContainer resultContainer)
        {
            lock (this)
            {
                dataFetches--;

                if (dataFetches == 0)
                {
                    page.Data = resultContainer.PresenterContainer.Tree.Nodes;
                    PerformPostDataLoadUIAdjustments();
                    page.ViewEnabled = true;
                }
            }
        }

        private void PerformPostDataLoadUIAdjustments()
        {
            page.CollapseConfiguredSectionNodes();
        }

        private class DataFetcher : ClientBackgroundingFriendly<PresenterContainer, ResultContainer>
        {
            private readonly PriorityPagePresenter presenter;
            private readonly Action<PresenterContainer, ResultContainer> query;
            private readonly Action<ResultContainer> setOnView;

            public DataFetcher(PriorityPagePresenter presenter, Action<PresenterContainer, ResultContainer> query,
                Action<ResultContainer> setOnView)
            {
                this.presenter = presenter;
                this.query = query;
                this.setOnView = setOnView;
            }

            public override bool ViewEnabled
            {
                set { }
            }

            public override ResultContainer DoWork(PresenterContainer presenterContainer)
            {
                var resultContainer = new ResultContainer(presenterContainer);
                query(presenterContainer, resultContainer);
                return resultContainer;
            }

            public override void WorkSuccessfullyCompleted(ResultContainer resultContainer)
            {
                setOnView(resultContainer);
                presenter.CheckIfAllDataIsLoadedAndCleanUp(resultContainer);
            }

            public override void OnError(Exception e)
            {
                throw new Exception("Error fetching priority page data", e);
            }
        }

        private class PresenterContainer
        {
            private readonly PriorityPageTree tree;

            public PresenterContainer(PriorityPageTree tree)
            {
                this.tree = tree;
            }

            public PriorityPageTree Tree
            {
                get { return tree; }
            }

            public PriorityPageExcursionEventSectionPresenter PriorityPageExcursionEventSectionPresenter { get; set; }

            public PriorityPageShiftHandoverSectionPresenter PriorityPageShiftHandoverSectionPresenter { get; set; }

            public PriorityPageTargetAlertSectionPresenter PriorityPageTargetAlertSectionPresenter { get; set; }

            public PriorityPageActionItemSectionPresenter PriorityPageActionItemSectionPresenter { get; set; }

            public PriorityPageReadingSectionPresenter PriorityPageReadingSectionPresenter { get; set; }   //ayman action item reding

            public PriorityPageDirectiveLogSectionPresenter PriorityPageDirectiveLogSectionPresenter { get; set; }

            public PriorityPageWorkPermitMontrealSectionPresenter PriorityPageWorkPermitMontrealSectionPresenter
            {
                get;
                set;
            }

            public PriorityPageEdmontonFormSectionPresenter PriorityPageFormSectionPresenter { get; set; }

            public PriorityPageFormOilsandsSectionPresenter PriorityPageFormOilsandsSectionPresenter { get; set; }

            public PriorityPageFormOP14SectionPresenter PriorityPageFormOP14SectionPresenter { get; set; }

            public PriorityPageLubesCsdSectionPresenter PriorityPageLubesCsdSectionPresenter { get; set; }

            public PriorityPageMontrealCsdSectionPresenter PriorityPageMontrealCsdSectionPresenter { get; set; }

            public PriorityPageWorkPermitEdmontonSectionPresenter PriorityPageWorkPermitEdmontonSectionPresenter
            {
                get;
                set;
            }
            public PriorityPageWorkPermitFortHillsSectionPresenter PriorityPageWorkPermitFortHillsSectionPresenter
            {
                get;
                set;
            }
            public PriorityPageWorkPermitLubesSectionPresenter PriorityPageWorkPermitLubesSectionPresenter { get; set; }

            public PriorityPageDirectiveSectionPresenter PriorityPageDirectiveSectionPresenter { get; set; }

            public PriorityPageMontrealFormSectionPresenter PriorityPageMontrealFormSectionPresenter { get; set; }

            public PriorityPageLubesFormSectionPresenter PriorityPageLubesFormSectionPresenter { get; set; }

            public PriorityPageDocumentSuggestionSectionPresenter PriorityPageDocumentSuggestionSectionPresenter { get; set; }

            public PriorityPageProcedureDeviationSectionPresenter PriorityPageProcedureDeviationSectionPresenter { get; set; }
            //RITM0268131 - mangesh
            public PriorityPageMudsTemporaryInstallationsSectionPresenter PriorityPageMudsTemporaryInstallationsSectionPresenter { get; set; }
            public PriorityPageMontrealSulphurFormSectionPresenter PriorityPageMontrealSulphurFormSectionPresenter { get; set; }

            public PriorityPageWorkPermitMudsSectionPresenter PriorityPageWorkPermitMudsSectionPresenter { get; set; } //RITM0301321 mangesh
        }

        private class ResultContainer
        {
            private readonly PresenterContainer presenterContainer;

            public ResultContainer(PresenterContainer presenterContainer)
            {
                this.presenterContainer = presenterContainer;
            }

            public PresenterContainer PresenterContainer
            {
                get { return presenterContainer; }
            }

            public List<TargetAlertDTO> TargetAlertDtos { get; set; }

            public List<ShiftHandoverQuestionnairePriorityPageDTO> ShiftHandoverQuestionnairePriorityPageDtos { get; set; }

            public List<ActionItemDTO> ActionItemDtos { get; set; }

            public List<LogPriorityPageDTO> LogPriorityPageDtos { get; set; }

            public List<DirectiveDTO> DirectiveDtos { get; set; }

            public List<WorkPermitEdmontonDTO> WorkPermitEdmontonDtos { get; set; }

            public List<WorkPermitFortHillsDTO> WorkPermitFortHillsDtos { get; set; }

            public List<WorkPermitMontrealDTO> WorkPermitMontrealDtos { get; set; }

            public List<WorkPermitLubesDTO> WorkPermitLubesDtos { get; set; }

            public List<LubesCsdFormDTO> LubesCsdDtos { get; set; }

            public List<FormEdmontonDTO> LubesFormDtos { get; set; }

            public List<MontrealCsdDTO> MontrealCsdDtos { get; set; }

            public List<FormEdmontonDTO> FormDtos { get; set; }

            public List<FormOilsandsPriorityPageDTO> FormOilsandsDtos { get; set; }

            public List<FormEdmontonOP14DTO> FormOP14Dtos { get; set; }

            public List<MontrealCsdDTO> MontrealFormDtos { get; set; }

            public List<ExcursionEventPriorityPageDTO> ExcursionEventPriorityPageDtos { get; set; }

            public List<DocumentSuggestionDTO> DocumentSuggestionDtos { get; set; }

            public List<ProcedureDeviationDTO> ProcedureDeviationDtos { get; set; }
            public List<TemporaryInstallationsMudsDTO> MudsTemporaryInstallationsDtos { get; set; } //RITM0268131 - mangesh 
            
            public List<WorkPermitMudsDTO> WorkPermitMudsDtos { get; set; } //RITM0301321 - mangesh
        }
    }

}
    
