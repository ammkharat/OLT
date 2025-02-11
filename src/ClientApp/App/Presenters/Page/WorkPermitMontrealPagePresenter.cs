using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class WorkPermitMontrealPagePresenter : AbstractDeletableDomainPagePresenter<WorkPermitMontrealDTO, WorkPermitMontreal, IWorkPermitMontrealDetails, IWorkPermitMontrealPage>
    {
        private readonly IWorkPermitMontrealService workPermitMontrealService;
        private readonly IConfiguredDocumentLinkService configuredDocumentLinkService;

        private readonly IReportPrintManager<WorkPermitMontreal> reportPrintManager;
        private readonly ILogService logService;

        public WorkPermitMontrealPagePresenter() : base(new WorkPermitMontrealPage())
        {
            workPermitMontrealService = ClientServiceRegistry.Instance.GetService<IWorkPermitMontrealService>();
            configuredDocumentLinkService = ClientServiceRegistry.Instance.GetService<IConfiguredDocumentLinkService>();
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();

            List<ConfiguredDocumentLink> configuredDocumentLinks = configuredDocumentLinkService.GetLinks(ConfiguredDocumentLinkLocation.WorkPermitMontreal);
            if (configuredDocumentLinks.Count == 0)
            {
                page.Details.DisableConfiguredDocumentLinks();
            }
            else
            {
                page.Details.ConfiguredDocumentLinks = configuredDocumentLinks;    
            }
            
            SubscribeToEvents();

            reportPrintManager = new ReportPrintManager<WorkPermitMontreal, WorkPermitMontrealReport, WorkPermitMontrealReportAdapter>(
                    new WorkPermitMontrealPrintActions(workPermitMontrealService, page));
        }


        private void EnableViewAssociatedLogsButtonIfNecessary(bool hasSingleItemSelected)
        {
            page.Details.ViewAssociatedLogsEnabled = hasSingleItemSelected &&
                                                     (logService.CountOfLogsAssociatedToWorkPermitMontreal(page.FirstSelectedItem.IdValue) > 0);
        }

        private void HandleViewAssociatedLogs()
        {
            List<LogDTO> logDtos = logService.QueryDTOsByWorkPermitMontreal(page.FirstSelectedItem.IdValue);
            page.ShowAssociatedLogForm(logDtos);
        }
        private void SubscribeToEvents()
        {   
            page.Details.CloseWorkPermit += CloseWorkPermit;
            page.Details.Print += Print;
            page.Details.PrintPreview += PrintPreview;
            page.Details.ViewAssociatedLogs += HandleViewAssociatedLogs;

            page.Details.Clone += Clone;
            page.Details.ConfiguredDocumentLinkClicked += HandleConfiguredDocumentLinkClicked;
            page.Details.OpenDocumentLink += HandleOpenDocumentLink;
            page.Details.ViewAttachment += ViewAttachment;

            page.Details.MarkAsTemplate += MarkAsTemplate;
            page.Details.RefreshAll += RefreshAll;
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.CloseWorkPermit -= CloseWorkPermit;
            page.Details.Print -= Print;
            page.Details.PrintPreview -= PrintPreview;
            page.Details.Clone -= Clone;
            page.Details.ConfiguredDocumentLinkClicked -= HandleConfiguredDocumentLinkClicked;
            page.Details.OpenDocumentLink -= HandleOpenDocumentLink;
            page.Details.ViewAttachment += ViewAttachment;

            page.Details.MarkAsTemplate -= MarkAsTemplate;
            page.Details.RefreshAll -= RefreshAll;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(WorkPermitMontreal item)
        {
            return new EditWorkPermitMontrealHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(WorkPermitMontreal item)
        {
            if (item.WorkPermitStatus == PermitRequestBasedWorkPermitStatus.Requested && item.Id != null && !item.UsePreviousPermitAnswered)
            {
                WorkPermitMontreal previousDayPermit = workPermitMontrealService.QueryPreviousDayIssuedPermitForSamePermitRequest(item);
                if (previousDayPermit != null && ShouldGoAheadWithTheCopyProcess(previousDayPermit))
                {
                    previousDayPermit.CopyContentsIntoNextDayPermit(ref item, userContext.User);
                }
                item.UsePreviousPermitAnswered = true;
            }
            return new WorkPermitMontrealFormPresenter(item).View;
        }

        private bool ShouldGoAheadWithTheCopyProcess(WorkPermitMontreal permit)
        {
            string message =
                string.Format(
                    StringResources.WorkPermit_CopyFromPreviousPermit,
                    permit.PermitNumber, permit.IssuedDateTime.ToShortDateAndTimeStringOrEmptyString());

            DialogResult result = OltMessageBox.ShowCustomYesNo(
                page.ParentForm,
                message,
                StringResources.CopyWorkPermitFormTitle,
                MessageBoxIcon.Question,
                StringResources.Yes,
                StringResources.No);
            return result == DialogResult.Yes;
        }
        private void Print(object sender, EventArgs args)
        {
            PrintWithDialogFocus(Print);
        }

        private void Print()
        {
            reportPrintManager.PrintReport(ConvertAllTo(page.SelectedItems));
        }

        private void PrintPreview(object sender, EventArgs args)
        {
            reportPrintManager.PreviewReport(QueryForFirstSelectedItem());
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            List<WorkPermitMontrealDTO> selectedItems = page.SelectedItems;
            bool hasSingleItemSelected = selectedItems.Count == 1;
            bool hasItemsSelected = selectedItems.Count > 0;

            IWorkPermitMontrealDetails details = page.Details;
            WorkPermitMontreal workPermit = QueryForFirstSelectedItem();

            details.EditEnabled = hasSingleItemSelected && authorized.ToEditWorkPermit(userRoleElements, selectedItems[0]);
            details.DeleteEnabled = hasItemsSelected && authorized.ToDeleteWorkPermits(userRoleElements, selectedItems);
            details.CloseEnabled = hasItemsSelected && authorized.ToCloseWorkPermits(userRoleElements, selectedItems);
            details.CloneEnabled = hasSingleItemSelected && (authorized.ToCloneWorkPermitWithNoRestriction(userRoleElements));
            details.PrintEnabled = hasItemsSelected && authorized.ToPrintWorkPermits(userRoleElements, selectedItems);
            details.PrintPreviewEnabled = hasSingleItemSelected && authorized.ToPrintWorkPermit(userRoleElements, selectedItems[0]);


            details.ViewEditHistoryEnabled = hasSingleItemSelected;
            EnableViewAssociatedLogsButtonIfNecessary(hasSingleItemSelected);

            details.editTemplateVisible = false;


            // DMND0010609-OLT - Edmonton Work permit Scan
            IWorkPermitEdmontonService workPermitEdmontonService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            details.ViewAttachEnabled =selectedItems.Count==1 && workPermitEdmontonService.GetWorkpermitScan(Convert.ToString(selectedItems[0].PermitNumber), Convert.ToInt32(userContext.Site.Id)).Count > 0;
            details.ViewScanEnabled = page.SelectedItems.Count == 1 && userContext.UserRoleElements.HasRoleElement(RoleElement.WORKPERMIT_SCAN);
            // End DMND0010609-OLT - Edmonton Work permit Scan

            details.MarkTemplateEnabled = hasSingleItemSelected &&
                                              ClientSession.GetUserContext()
                                                  .SiteConfiguration.EnableTemplateFeatureForWorkPermit &&
                                              (authorized.ToCreateWorkPermits(userRoleElements))
                                              && workPermit.PermitNumber != null;

        }

        protected virtual void CloseWorkPermit(object sender, EventArgs e)
        {
            LockMultipleDomainObjects(Close, LockType.Edit);
        }

        private void Close(List<WorkPermitMontreal> permits)
        {
            WorkPermitMontrealCloseFormPresenter presenter = new WorkPermitMontrealCloseFormPresenter(permits);
            presenter.Run(page.ParentForm);
        }

        protected override void Delete(WorkPermitMontreal workPermit)
        {
            workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
            workPermit.LastModifiedDateTime = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitMontrealService.Remove, workPermit);
        }

        private void Clone(object sender, EventArgs args)
        {
            WorkPermitMontreal workPermit = QueryForFirstSelectedItem();
            workPermit.ConvertToClone();

            IForm form = CreateEditForm(workPermit);

            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        private void HandleConfiguredDocumentLinkClicked(ConfiguredDocumentLink link)
        {
            if (link == null)
            {
                return;
            }

            page.OpenDocument(link.Link);    
        }

        private void HandleOpenDocumentLink()
        {
            ClientBackgroundWorker worker = new ClientBackgroundWorker();
            worker.DoWork += (sender, args) => workPermitMontrealService.InsertUserReadDocumentLinkAssociation(page.FirstSelectedItem.IdValue, ClientSession.GetUserContext().User.IdValue);
            worker.RunWorkerAsync();            
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitMontrealCreated += repeater_Created;
            remoteEventRepeater.ServerWorkPermitMontrealUpdated += repeater_Updated;
            remoteEventRepeater.ServerWorkPermitMontrealRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerWorkPermitMontrealCreated -= repeater_Created;
            remoteEventRepeater.ServerWorkPermitMontrealUpdated -= repeater_Updated;
            remoteEventRepeater.ServerWorkPermitMontrealRemoved -= repeater_Removed;
        }

        protected override WorkPermitMontreal QueryByDto(WorkPermitMontrealDTO dto)
        {
            return workPermitMontrealService.QueryById(dto.IdValue);
        }

        private Visible<bool> CreateVisibleFromEditObject(TemplateState state, bool value)
        {
            if (TemplateState.Invisible == state)
            {
                return new Visible<bool>(VisibleState.Invisible, false);
            }
            return new Visible<bool>(VisibleState.Visible, value);
        }

        protected override void SetDetailData(IWorkPermitMontrealDetails details, WorkPermitMontreal permit)
        {
//            details.MostRecentEditHistory = editHistoryService.GetRecentEditHistoryforEdmontonPermitRequest(permit);

            WorkPermitMontrealTemplate template = permit.Template;

            // Informations de base
            details.PermitType = permit.WorkPermitType.Name;
            
            details.PermitStartDate = permit.StartDateTime.ToLongDateAndTimeString();
            details.PermitEndDate = permit.EndDateTime.ToLongDateAndTimeString();

            details.WorkPermitTemplate = permit.Template.DisplayName;
            details.WorkPermitNumber = permit.PermitNumber.ToString();
            details.FunctionalLocations = permit.FunctionalLocations;
            details.Trade = permit.Trade;
            details.RequestedByGroup = permit.RequestedByGroup == null ? string.Empty : permit.RequestedByGroup.Name;
            details.WorkOrderNumber = permit.WorkOrderNumber;
            details.Description = permit.Description;

            // Substances normalement � l'int�rieur de l'�quipement
            details.H2S = CreateVisibleFromEditObject(template.H2S, permit.H2S);
            details.Hydrocarbure = CreateVisibleFromEditObject(template.Hydrocarbure, permit.Hydrocarbure);
            details.Ammoniaque = CreateVisibleFromEditObject(template.Ammoniaque, permit.Ammoniaque);
            
            details.CorrosifData = permit.Corrosif.Text ?? String.Empty;
            details.Corrosif = CreateVisibleFromEditObject(template.Corrosif, permit.Corrosif.StateAsBool);

            details.AromatiqueData = permit.Aromatique.Text ?? String.Empty;
            details.Aromatique = CreateVisibleFromEditObject(template.Aromatique, permit.Aromatique.StateAsBool);

            details.AutresData = permit.AutresSubstances.Text ?? String.Empty;
            details.Autres = CreateVisibleFromEditObject(template.AutresSubstances, permit.AutresSubstances.StateAsBool);

            // Conditions et outils permis pour ce travail
            details.ObtureOuDebranche = CreateVisibleFromEditObject(template.ObtureOuDebranche, permit.ObtureOuDebranche);
            details.DepressuriseEtVidange = CreateVisibleFromEditObject(template.DepressuriseEtVidange, permit.DepressuriseEtVidange);
            details.EnPresenceDeGazInerte = CreateVisibleFromEditObject(template.EnPresenceDeGazInerte, permit.EnPresenceDeGazInerte);
            details.PurgeALaVapeur = CreateVisibleFromEditObject(template.PurgeALaVapeur, permit.PurgeALaVapeur);
            details.RinceALeau = CreateVisibleFromEditObject(template.RinceALeau, permit.RinceALeau);
            details.Excavation = CreateVisibleFromEditObject(template.Excavation, permit.Excavation);

            details.DessinsRequisData = permit.DessinsRequis.Text ?? String.Empty;
            details.DessinsRequis = CreateVisibleFromEditObject(template.DessinsRequis, permit.DessinsRequis.StateAsBool);

            details.CablesChauffantsMisHorsTension = CreateVisibleFromEditObject(template.CablesChauffantsMisHorsTension, permit.CablesChauffantsMisHorsTension);
            details.PompeOuVerinPneumatique = CreateVisibleFromEditObject(template.PompeOuVerinPneumatique, permit.PompeOuVerinPneumatique);

            details.ChaineEtCadenasseOuScelle = CreateVisibleFromEditObject(template.ChaineEtCadenasseOuScelle, permit.ChaineEtCadenasseOuScelle);
            details.InterrupteursElectriquesVerrouilles = CreateVisibleFromEditObject(template.InterrupteursElectriquesVerrouilles, permit.InterrupteursElectriquesVerrouilles);
            details.PurgeParUnGazInerte = CreateVisibleFromEditObject(template.PurgeParUnGazInerte, permit.PurgeParUnGazInerte);
            details.OutilsElectriquesOuABatteries = CreateVisibleFromEditObject(template.OutilsElectriquesOuABatteries, permit.OutilsElectriquesOuABatteries);

            details.BoiteEnergieZeroData = permit.BoiteEnergieZero.Text ?? String.Empty;
            details.BoiteEnergieZero = CreateVisibleFromEditObject(template.BoiteEnergieZero, permit.BoiteEnergieZero.StateAsBool);

            details.OutilsPneumatiques = CreateVisibleFromEditObject(template.OutilsPneumatiques, permit.OutilsPneumatiques);
            details.MoteurACombustionInterne = CreateVisibleFromEditObject(template.MoteurACombustionInterne, permit.MoteurACombustionInterne);
            details.TravauxSuperPoses = CreateVisibleFromEditObject(template.TravauxSuperPoses, permit.TravauxSuperPoses);

            details.FormulaireDespaceClosAfficheData = permit.FormulaireDespaceClosAffiche.Text ?? String.Empty;
            details.FormulaireDespaceClosAffiche = CreateVisibleFromEditObject(template.FormulaireDespaceClosAffiche, permit.FormulaireDespaceClosAffiche.StateAsBool);

            details.ExisteIlUneAnalyseDeTache = CreateVisibleFromEditObject(template.ExisteIlUneAnalyseDeTache, permit.ExisteIlUneAnalyseDeTache);
            details.PossibiliteDeSulfureDeFer = CreateVisibleFromEditObject(template.PossibiliteDeSulfureDeFer, permit.PossibiliteDeSulfureDeFer);
            details.AereVentile = CreateVisibleFromEditObject(template.AereVentile, permit.AereVentile);
            details.SoudureALelectricite = CreateVisibleFromEditObject(template.SoudureALelectricite, permit.SoudureALelectricite);
            details.BrulageAAcetylene = CreateVisibleFromEditObject(template.BrulageAAcetylene, permit.BrulageAAcetylene);
            details.Nacelle = CreateVisibleFromEditObject(template.Nacelle, permit.Nacelle);

            details.AutreConditionsData = permit.AutreConditions.Text ?? String.Empty;
            details.AutreConditions = CreateVisibleFromEditObject(template.AutreConditions, permit.AutreConditions.StateAsBool);

            // Equipements de protection individuelle
            details.LunettesMonocoques = CreateVisibleFromEditObject(template.LunettesMonocoques, permit.LunettesMonocoques);
            details.HarnaisDeSecurite = CreateVisibleFromEditObject(template.HarnaisDeSecurite, permit.HarnaisDeSecurite);
            details.EcranFacial = CreateVisibleFromEditObject(template.EcranFacial, permit.EcranFacial);
            details.ProtectionAuditive = CreateVisibleFromEditObject(template.ProtectionAuditive, permit.ProtectionAuditive);
            details.Trepied = CreateVisibleFromEditObject(template.Trepied, permit.Trepied);
            details.DispositifAntichute = CreateVisibleFromEditObject(template.DispositifAntichute, permit.DispositifAntichute);
            
            details.ProtectionRespiratoireData = permit.ProtectionRespiratoire.Text ?? String.Empty;
            details.ProtectionRespiratoire = CreateVisibleFromEditObject(template.ProtectionRespiratoire, permit.ProtectionRespiratoire.StateAsBool);

            details.HabitsData = permit.Habits.Text ?? String.Empty;
            details.Habits = CreateVisibleFromEditObject(template.Habits, permit.Habits.StateAsBool);

            details.AutreProtectionData = permit.AutreProtection.Text ?? String.Empty;
            details.AutreProtection = CreateVisibleFromEditObject(template.AutreProtection, permit.AutreProtection.StateAsBool);

            // Protection incendie
            details.Extincteur = CreateVisibleFromEditObject(template.Extincteur, permit.Extincteur);
            details.BouchesDegoutProtegees = CreateVisibleFromEditObject(template.BouchesDegoutProtegees, permit.BouchesDegoutProtegees);
            details.CouvertureAntiEtincelles = CreateVisibleFromEditObject(template.CouvertureAntiEtincelles, permit.CouvertureAntiEtincelles);
            details.SurveillantPouretincelles = CreateVisibleFromEditObject(template.SurveillantPouretincelles, permit.SurveillantPouretincelles);
            details.PareEtincelles = CreateVisibleFromEditObject(template.PareEtincelles, permit.PareEtincelles);
            details.MiseAlaTerrePresDuLieuDeTravail = CreateVisibleFromEditObject(template.MiseAlaTerrePresDuLieuDeTravail, permit.MiseAlaTerrePresDuLieuDeTravail);
            details.BoyauAVapeur = CreateVisibleFromEditObject(template.BoyauAVapeur, permit.BoyauAVapeur);

            details.AutresEquipementDincendieData = permit.AutresEquipementDincendie.Text ?? String.Empty;
            details.AutresEquipementDincendie = CreateVisibleFromEditObject(template.AutresEquipementDincendie, permit.AutresEquipementDincendie.StateAsBool);

            // Autres �quipements de s�curit�
            details.Ventulateur = CreateVisibleFromEditObject(template.Ventulateur, permit.Ventulateur);
            details.Barrieres = CreateVisibleFromEditObject(template.Barrieres, permit.Barrieres);

            details.SurveillantData = permit.Surveillant.Text ?? String.Empty;
            details.Surveillant = CreateVisibleFromEditObject(template.Surveillant, permit.Surveillant.StateAsBool);

            details.RadioEmetteur = CreateVisibleFromEditObject(template.RadioEmetteur, permit.RadioEmetteur);
            details.PerimetreDeSecurite = CreateVisibleFromEditObject(template.BoiteEnergieZero, permit.PerimetreDeSecurite);

            details.DetectionContinueDesGazData = permit.DetectionContinueDesGaz.Text ?? String.Empty;
            details.DetectionContinueDesGaz = CreateVisibleFromEditObject(template.DetectionContinueDesGaz, permit.DetectionContinueDesGaz.StateAsBool);

            details.KlaxonSonore = CreateVisibleFromEditObject(template.KlaxonSonore, permit.KlaxonSonore);
            details.Localiser = CreateVisibleFromEditObject(template.Localiser, permit.Localiser);
            details.Amiante = CreateVisibleFromEditObject(template.Amiante, permit.Amiante);

            details.AutreEquipementsSecuriteData = permit.AutreEquipementsSecurite.Text ?? String.Empty;
            details.AutreEquipementsSecurite = CreateVisibleFromEditObject(template.AutreEquipementsSecurite, permit.AutreEquipementsSecurite.StateAsBool);

            details.DocumentLinks = permit.DocumentLinks;

            // signature section
            details.InstructionsSpeciales = permit.InstructionsSpeciales;
            details.SignatureOperateurSurLeTerrain = CreateVisibleFromEditObject(template.SignatureOperateurSurLeTerrain, permit.SignatureOperateurSurLeTerrain);
            details.DetectionDesGazs = CreateVisibleFromEditObject(template.DetectionDesGazs, permit.DetectionDesGazs);
            details.SignatureContremaitre = CreateVisibleFromEditObject(template.SignatureContremaitre, permit.SignatureContremaitre);
            details.SignatureAutorise = CreateVisibleFromEditObject(template.SignatureAutorise, permit.SignatureAutorise);
            details.NettoyageTransfertHorsSite = CreateVisibleFromEditObject(template.NettoyageTransfertHorsSite, permit.NettoyageTransfertHorsSite);


            // DMND0010609-OLT - Edmonton Work permit Scan
            IWorkPermitEdmontonService workPermitEdmontonService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            details.ViewAttachEnabled = workPermitEdmontonService.GetWorkpermitScan(Convert.ToString(permit.PermitNumber), Convert.ToInt32(userContext.Site.Id)).Count > 0;
            details.ViewScanEnabled = page.SelectedItems.Count == 1 && userContext.UserRoleElements.HasRoleElement(RoleElement.WORKPERMIT_SCAN);
            // End DMND0010609-OLT - Edmonton Work permit Scan

            details.SetRequestDetails(
                permit.DataSource == DataSource.PERMIT_REQUEST,
                permit.RequestedDateTime,
                permit.RequestedByUser == null ? "" : permit.RequestedByUser.FullNameWithUserName,
                permit.Company,
                permit.Supervisor,
                permit.ExcavationNumber,
                permit.Attributes);
        }

        protected override WorkPermitMontrealDTO CreateDTOFromDomainObject(WorkPermitMontreal domainObject)
        {
            return new WorkPermitMontrealDTO(domainObject);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_WorkPermit; }
        }

        protected override IList<WorkPermitMontrealDTO> GetDtos(Range<Date> dateRange)
        {

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            if (page.TabText == StringResources.WorkPermitTemplates)
            {
                var username = ClientSession.GetUserContext().User.Username;
                return workPermitMontrealService.QueryByDateRangeAndFlocsTemplate(dateRange, userContext.RootFlocSet, username);
            }
            else
            {
                return workPermitMontrealService.QueryByDateRangeAndFlocs(dateRange, userContext.RootFlocSet); 
            }
            
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            Date now = Clock.DateNow;
            Date start = now.SubtractDays(userContext.SiteConfiguration.DaysToDisplayWorkPermitsBackwards);
            Date end = null;
            if (userContext.SiteConfiguration.DaysToDisplayWorkPermitsForwards > 0)
            {
                end = now.AddDays(userContext.SiteConfiguration.DaysToDisplayWorkPermitsForwards);
            }
            return new Range<Date>(start, end);
        }
        
        protected override bool IsItemInDateRange(WorkPermitMontreal workPermit, Range<Date> range)
        {
            if (workPermit.LastModifiedBy.Id == userContext.User.Id)
            {
                return true;
            }
            else
            {
                DateRange dateRange = new DateRange(range ?? GetDefaultDateRange());
                return dateRange.Overlaps(workPermit.StartDateTime, workPermit.EndDateTime);
            }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.MontrealWorkPermits; }
        }

        private void ViewAttachment(object sender, EventArgs e)
        {
            if (page.FirstSelectedItem == null)
                return;

            WorkPermitMontrealDTO workPermit = page.FirstSelectedItem;
            IWorkPermitEdmontonService workPermitEdmontonService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            List<WorkpermitScan> lst = workPermitEdmontonService.GetWorkpermitScan(Convert.ToString(workPermit.PermitNumber), Convert.ToInt32(userContext.Site.Id));
            WorkPermitAttachment AttachementForm = new WorkPermitAttachment(lst);

            if (lst != null && lst.Count > 0)
            {

                AttachementForm.ShowDialog();
            }
            //workPermit.Id
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        private void MarkAsTemplate(object sender, EventArgs e)
        {
            bool isWorkPermit = true;
            MarkAsTemplateNameForm nameForm = new MarkAsTemplateNameForm(isWorkPermit);
            nameForm.ShowDialog();
            WorkPermitMontreal workPermit = QueryForFirstSelectedItem();
            workPermit.TemplateName = nameForm.WorkPermitTemplateName;
            workPermit.Categories = nameForm.Category;
            workPermit.Global = nameForm.Global;
            workPermit.Individual = nameForm.Individual;

            var wp = workPermitMontrealService.QueryByIdTemplate(workPermit.IdValue, workPermit.TemplateName, workPermit.Categories);

            if (wp != null)
            {
                if (workPermit.TemplateName == wp._templateName && workPermit.Categories == wp._categories)
                {
                    OltMessageBox.ShowError("Same Template Name and Category entry is already present. " +
                                            "Cannot proceed further, please change the Temlate name and Category");
                }
            }
            else
            {
                if (workPermit.TemplateName != string.Empty && nameForm.Save == true)
                {
                    workPermit.IsTemplate = true;
                    workPermit.TemplateCreatedBy = ClientSession.GetUserContext().User.Username;
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitMontrealService.Update, workPermit);
                }
                else
                {
                    workPermit.IsTemplate = false;
                }
            }


        }

        private void RefreshAll(object sender, EventArgs e)
        {
            RefreshData();
        }

    }
}