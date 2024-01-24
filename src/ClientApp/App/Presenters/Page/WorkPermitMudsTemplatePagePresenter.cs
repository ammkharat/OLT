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
    public class WorkPermitMudsTemplatePagePresenter : AbstractDeletableDomainPagePresenter<WorkPermitMudsTemplateDTO, WorkPermitMuds, IWorkPermitMudsDetails, IWorkPermitMudsTemplatePage>
    {
        private readonly IWorkPermitMudsService workPermitMudsService;
        private readonly IConfiguredDocumentLinkService configuredDocumentLinkService;

        private readonly IReportPrintManager<WorkPermitMuds> reportPrintManager;
        private readonly ILogService logService;
        private readonly IGasTestElementInfoService gasTestElementInfoService;

        public WorkPermitMudsTemplatePagePresenter()
            : base(new WorkPermitMudsMarkedTemplatePage())
        {
            workPermitMudsService = ClientServiceRegistry.Instance.GetService<IWorkPermitMudsService>();
            configuredDocumentLinkService = ClientServiceRegistry.Instance.GetService<IConfiguredDocumentLinkService>();
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();

            List<ConfiguredDocumentLink> configuredDocumentLinks = configuredDocumentLinkService.GetLinks(ConfiguredDocumentLinkLocation.WorkPermitMuds);
            if (configuredDocumentLinks.Count == 0)
            {
                page.Details.DisableConfiguredDocumentLinks();
            }
            else
            {
                page.Details.ConfiguredDocumentLinks = configuredDocumentLinks;    
            }
            
            SubscribeToEvents();
            
            //reportPrintManager = new ReportPrintManager<WorkPermitMuds, WorkPermitMudsReport, WorkPermitMudsReportAdapter>(
            //        new WorkPermitMudsPrintActions(workPermitMudsService, page));

            gasTestElementInfoService = ClientServiceRegistry.Instance.GetService<IGasTestElementInfoService>();
        }


        private void EnableViewAssociatedLogsButtonIfNecessary(bool hasSingleItemSelected)
        {
            page.Details.ViewAssociatedLogsEnabled = hasSingleItemSelected &&
                                                     (logService.CountOfLogsAssociatedToWorkPermitMuds(page.FirstSelectedItem.IdValue) > 0);
        }

        private void HandleViewAssociatedLogs()
        {
            List<LogDTO> logDtos = logService.QueryDTOsByWorkPermitMuds(page.FirstSelectedItem.IdValue);
            //page.ShowAssociatedLogForm(logDtos);

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
            page.Details.GastestButtonEvent += ViewGastest;

            page.Details.MarkAsTemplate += MarkAsTemplate;
            page.Details.RefreshAll += RefreshAll;

            page.Details.EditTemplate += EditTemplate; //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

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
            page.Details.ViewAttachment -= ViewAttachment;
            page.Details.GastestButtonEvent -= ViewGastest;

            page.Details.MarkAsTemplate -= MarkAsTemplate;
            page.Details.RefreshAll -= RefreshAll;

            page.Details.EditTemplate -= EditTemplate; //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(WorkPermitMuds item)
        {
            return new EditWorkPermitMudsHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(WorkPermitMuds item)
        {
            if (item.WorkPermitStatus == PermitRequestBasedWorkPermitStatus.Requested && item.Id != null && !item.UsePreviousPermitAnswered)
            {
                WorkPermitMuds previousDayPermit = workPermitMudsService.QueryPreviousDayIssuedPermitForSamePermitRequest(item);
                if (previousDayPermit != null && ShouldGoAheadWithTheCopyProcess(previousDayPermit))
                {
                    previousDayPermit.CopyContentsIntoNextDayPermit(ref item, userContext.User);
                }
                item.UsePreviousPermitAnswered = true;
            }
            return new WorkPermitMudsFormPresenter(item).View;
        }

        private bool ShouldGoAheadWithTheCopyProcess(WorkPermitMuds permit)
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
            //if (ClientSession.GetUserContext().SiteConfiguration.EnableWorkPermitSignature)
            //{
            //    WorkPermitMudsSign workPermitSign = new WorkPermitMudsSign(page.SelectedItems[0]);
            //    QueryStandardGasTestElementInfoList();
            //    workPermitSign.InitializeStandardGasTestElementInfoList(standardGasTestElementInfoList);

            //    DialogResult Result = workPermitSign.ShowDialog();
            //    if (Result == DialogResult.Yes)
            //    {
            //        PrintWithDialogFocus(Print);

            //    }
            //    return;
            //}
            //PrintWithDialogFocus(Print);
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

            List<WorkPermitMudsTemplateDTO> selectedItems = page.SelectedItems;
            bool hasSingleItemSelected = selectedItems.Count == 1;
            bool hasItemsSelected = selectedItems.Count > 0;

            IWorkPermitMudsDetails details = page.Details;

            details.DeleteVisible = hasSingleItemSelected ;
            //&& ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit;

            details.editVisible = false;

            details.editTemplateVisible =  hasSingleItemSelected ;
            //&& ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit;

            details.closeButtonVisible = false;
            details.printButtonVisible = false;
            details.printPreviewButtonVisible = false;
            details.editHistoryButtonVisible = false;
            details.viewAssociatedLogsButtonVisible = false;
            details.ScanButtonVisible = false;
            details.ViewAttachmentbuttonVisible = false;
            details.GasTestButtonVisible = false;
            details.documentLinksVisible = false;
            details.MarkTemplateEnabled = false;
            details.CloneEnabled = hasSingleItemSelected && (authorized.ToCloneWorkPermitWithNoRestriction(userRoleElements));


        }

        protected virtual void CloseWorkPermit(object sender, EventArgs e)
        {
            LockMultipleDomainObjects(Close, LockType.Edit);
        }

        private void Close(List<WorkPermitMuds> permits)
        {
            WorkPermitMudsCloseFormPresenter presenter = new WorkPermitMudsCloseFormPresenter(permits);
            presenter.Run(page.ParentForm);
        }

        protected override void Delete(WorkPermitMuds workPermit)
        {
            //if (page.TabText == StringResources.WorkPermitTemplates)
            //{
            //    workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
            //    workPermit.LastModifiedDateTime = Clock.Now;
            //    //var wp = workPermitMudsService.QueryByIdTemplate(workPermit.IdValue, workPermit.TemplateName, workPermit.Categories);
            //    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitMudsService.RemoveTemplate, workPermit);
            //}
            //else
            //{
                workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
                workPermit.LastModifiedDateTime = Clock.Now;
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitMudsService.Remove, workPermit);
            //}

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

                List<WorkPermitMudsTemplateDTO> permitDtos = page.SelectedItems;
                try
                {
                    workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
                    workPermit.LastModifiedDateTime = Clock.Now;
                    if (permitDtos.Count == 1)
                    {
                        workPermit.TemplateId = permitDtos[0].TemplateId;
                        ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitMudsService.RemoveTemplate, workPermit);
                    }

                }
                catch
                {
                    
                }
           
        }

        private void Clone(object sender, EventArgs args)
        {
            WorkPermitMuds workPermit = QueryForFirstSelectedItem();
            workPermit.ClonedFormDetailMuds = workPermit.PermitNumber.ToString(); // Added by Vibhor : DMND0011077 - Work Permit Clone History
            workPermit.ConvertToClone();


            // Added by Vibhor : to fix Muds Gast Test Bugs
            if (workPermit.GasTests.Elements.Count != 0)
            {
                workPermit.GasTests.GasTestFirstResultTime = null;
                
                for (int i = 0; i < workPermit.GasTests.Elements.Count; i++)
                {
                    workPermit.GasTests.Elements[i].ConfinedSpaceTestRequired = false;
                    workPermit.GasTests.Elements[i].ImmediateAreaTestRequired = false;
                }
                
            }

           
            
            //workPermit.GasTests.Elements[0].ImmediateAreaTestRequired = false;

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

            //page.OpenDocument(link.Link);    
        }

        private void HandleOpenDocumentLink()
        {
            ClientBackgroundWorker worker = new ClientBackgroundWorker();
            worker.DoWork += (sender, args) => workPermitMudsService.InsertUserReadDocumentLinkAssociation(page.FirstSelectedItem.IdValue, ClientSession.GetUserContext().User.IdValue);
            worker.RunWorkerAsync();            
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            //remoteEventRepeater.ServerWorkPermitMudsCreated += repeater_Created;
            remoteEventRepeater.ServerWorkPermitMudsTemplateCreated += repeater_Created;
            
           // remoteEventRepeater.ServerWorkPermitMudsUpdated += repeater_Updated;
           // remoteEventRepeater.ServerWorkPermitMudsRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            //remoteEventRepeater.ServerWorkPermitMudsCreated -= repeater_Created;
            remoteEventRepeater.ServerWorkPermitMudsTemplateCreated -= repeater_Created;
            
           // remoteEventRepeater.ServerWorkPermitMudsUpdated -= repeater_Updated;
           // remoteEventRepeater.ServerWorkPermitMudsRemoved -= repeater_Removed;
        }

        protected override WorkPermitMuds QueryByDto(WorkPermitMudsTemplateDTO dto)
        {
            return workPermitMudsService.QueryById(dto.IdValue);
        }

        private Visible<bool> CreateVisibleFromEditObject(TemplateStateMuds state, bool value)
        {
            if (TemplateStateMuds.Invisible == state)
            {
                return new Visible<bool>(VisibleState.Invisible, false);
            }
            return new Visible<bool>(VisibleState.Visible, value);
        }

        protected override void SetDetailData(IWorkPermitMudsDetails details, WorkPermitMuds permit)
        {
//            details.MostRecentEditHistory = editHistoryService.GetRecentEditHistoryforEdmontonPermitRequest(permit);
            if(permit == null) return;
            
            WorkPermitMudsTemplate template = permit.Template;

            // Informations de base
            details.PermitType = permit.WorkPermitType.Name;
            
            details.PermitStartDate = permit.StartDateTime.ToLongDateAndTimeString();
            details.PermitEndDate = permit.EndDateTime.ToLongDateAndTimeString();

            details.WorkPermitTemplate = permit.Template.DisplayName;
            details.WorkPermitNumber = permit.PermitNumber.ToString();
            details.FunctionalLocations = permit.FunctionalLocations;
            details.Trade = permit.Trade;
            details.CompanyName = permit.Company;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            details.CompanyName_1 = permit.Company_1;
            details.CompanyName_2 = permit.Company_2;
            details.RequestedByGroup = permit.RequestedByGroup == null ? string.Empty : permit.RequestedByGroup.Name;

            details.RequestedByGroupText = permit.RequestedByGroupText;

            details.WorkOrderNumber = permit.WorkOrderNumber;
            details.Description = permit.Description;

            details.NbTravail = permit.NbTravail;
            details.FormationCheck = permit.FormationCheck;
            details.NomsEnt = permit.NomsEnt;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            details.NomsEnt_1 = permit.NomsEnt_1;
            details.NomsEnt_2 = permit.NomsEnt_2;
            details.NomsEnt_3 = permit.NomsEnt_3;
            details.Surveilant = permit.Surveilant;

            details.RemplirLeFormulaireDeConditionData = permit.RemplirLeFormulaireDeCondition.Text ?? String.Empty;
            details.RemplirLeFormulaireDeCondition = CreateVisibleFromEditObject(template.RemplirLeFormulaireDeCondition, permit.RemplirLeFormulaireDeCondition.StateAsBool);

            details.AnalyseCritiqueDeLaTache = CreateVisibleFromEditObject(template.AnalyseCritiqueDeLaTache, permit.AnalyseCritiqueDeLaTache);
            details.Depressurises = CreateVisibleFromEditObject(template.Depressurises, permit.Depressurises);
            details.Vides = CreateVisibleFromEditObject(template.Vides, permit.Vides);
            details.ContournementDesGda = CreateVisibleFromEditObject(template.ContournementDesGda, permit.ContournementDesGda);
            details.Rinces = CreateVisibleFromEditObject(template.Rinces, permit.Rinces);
            details.NettoyesLaVapeur = CreateVisibleFromEditObject(template.NettoyesLaVapeur, permit.NettoyesLaVapeur);
            details.Purges = CreateVisibleFromEditObject(template.Purges, permit.Purges);
            details.Ventiles = CreateVisibleFromEditObject(template.Ventiles, permit.Ventiles);
            details.Aeres = CreateVisibleFromEditObject(template.Aeres, permit.Aeres);
            details.Energies = CreateVisibleFromEditObject(template.Energies, permit.Energies);
            
            details.Autres = CreateVisibleFromEditObject(template.Autres, permit.AutresCondition.StateAsBool);
            details.AutresCData = permit.AutresCondition.Text ?? String.Empty;

            details.InterrupteursEtVannesCadenassesData = permit.InterrupteursEtVannesCadenasses.Text ?? String.Empty;
            details.InterrupteursEtVannesCadenasses = CreateVisibleFromEditObject(template.InterrupteursEtVannesCadenasses, permit.InterrupteursEtVannesCadenasses.StateAsBool);

            details.VerrouillagesParTravailleurs = CreateVisibleFromEditObject(template.VerrouillagesParTravailleurs, permit.VerrouillagesParTravailleurs);
            details.SourcesDesenergisees = CreateVisibleFromEditObject(template.SourcesDesenergisees, permit.SourcesDesenergisees);
            details.DepartsLocauxTestes = CreateVisibleFromEditObject(template.DepartsLocauxTestes, permit.DepartsLocauxTestes);
            details.ConduitesDesaccouplees = CreateVisibleFromEditObject(template.ConduitesDesaccouplees, permit.ConduitesDesaccouplees);
            details.ObturateursInstallees = CreateVisibleFromEditObject(template.ObturateursInstallees, permit.ObturateursInstallees);
            details.PvciSuncorEffectuee = CreateVisibleFromEditObject(template.PvciSuncorEffectuee, permit.PvciSuncorEffectuee);
            details.PvciEntExtEffectuee = CreateVisibleFromEditObject(template.PvciEntExtEffectuee, permit.PvciEntExtEffectuee);
            details.Amiante = CreateVisibleFromEditObject(template.Amiante, permit.Amiante);
            details.AcideSulfurique = CreateVisibleFromEditObject(template.AcideSulfurique, permit.AcideSulfurique);
            details.Azote = CreateVisibleFromEditObject(template.Azote, permit.Azote);
            details.Caustique = CreateVisibleFromEditObject(template.Caustique, permit.Caustique);
            details.DioxydeDeSoufre = CreateVisibleFromEditObject(template.DioxydeDeSoufre, permit.DioxydeDeSoufre);
            details.Sbs = CreateVisibleFromEditObject(template.Sbs, permit.Sbs);
            details.Soufre = CreateVisibleFromEditObject(template.Soufre, permit.Soufre);
            details.EquipementsNonRinces = CreateVisibleFromEditObject(template.EquipementsNonRinces, permit.EquipementsNonRinces);
            details.Hydrocarbures = CreateVisibleFromEditObject(template.Hydrocarbures, permit.Hydrocarbures);
            details.HydrogeneSulfure = CreateVisibleFromEditObject(template.HydrogeneSulfure, permit.HydrogeneSulfure);
            details.MonoxydeCarbone = CreateVisibleFromEditObject(template.MonoxydeCarbone, permit.MonoxydeCarbone);
            details.Reflux = CreateVisibleFromEditObject(template.Reflux, permit.Reflux);
            details.ProduitsVolatilsUtilises = CreateVisibleFromEditObject(template.ProduitsVolatilsUtilises, permit.ProduitsVolatilsUtilises);
            details.Bacteries = CreateVisibleFromEditObject(template.Bacteries, permit.Bacteries);

            details.AppareilData = permit.Appareil.Text ?? String.Empty;
            details.Appareil = CreateVisibleFromEditObject(template.Appareil, permit.Appareil.StateAsBool);

            details.InterferencesEntreTravaux = CreateVisibleFromEditObject(template.InterferencesEntreTravaux, permit.InterferencesEntreTravaux);
            details.PiecesEnRotation = CreateVisibleFromEditObject(template.PiecesEnRotation, permit.PiecesEnRotation);
            details.IncendieExplosion = CreateVisibleFromEditObject(template.IncendieExplosion, permit.IncendieExplosion);
            details.ContrainteThermique = CreateVisibleFromEditObject(template.ContrainteThermique, permit.ContrainteThermique);
            details.Radiations = CreateVisibleFromEditObject(template.Radiations, permit.Radiations);
            details.Silice = CreateVisibleFromEditObject(template.Silice, permit.Silice);
            details.Vanadium = CreateVisibleFromEditObject(template.Vanadium, permit.Vanadium);
            details.AsphyxieIntoxication = CreateVisibleFromEditObject(template.AsphyxieIntoxication, permit.AsphyxieIntoxication);

            details.AutresRisquesData = permit.AutresRisques.Text ?? String.Empty;
            details.AutresRisques = CreateVisibleFromEditObject(template.AutresRisques, permit.AutresRisques.StateAsBool);

            details.ElectriciteVoltData = permit.Appareil.Text ?? String.Empty;
            details.ElectriciteVolt = CreateVisibleFromEditObject(template.ElectriciteVolt, permit.ElectriciteVolt.StateAsBool);

            details.TravailEnHauteur6EtPlus = CreateVisibleFromEditObject(template.TravailEnHauteur6EtPlus, permit.TravailEnHauteur6EtPlus);
            details.VapeurCondensat = CreateVisibleFromEditObject(template.VapeurCondensat, permit.VapeurCondensat); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            details.FeSValue = CreateVisibleFromEditObject(template.FeSValue, permit.FeSValue); 
            

            details.Electrisation = CreateVisibleFromEditObject(template.Electrisation, permit.Electrisation);
            details.LunettesMonocoques = CreateVisibleFromEditObject(template.LunettesMonocoques, permit.LunettesMonocoques);
            details.Visiere = CreateVisibleFromEditObject(template.Visiere, permit.Visiere);
            details.ProtectionAuditive = CreateVisibleFromEditObject(template.ProtectionAuditive, permit.ProtectionAuditive);
            //details.ManteauAntiEclaboussure = CreateVisibleFromEditObject(template.ManteauAntiEclaboussure, permit.ManteauAntiEclaboussure);
            details.CagouleIgnifuge = CreateVisibleFromEditObject(template.CagouleIgnifuge, permit.CagouleIgnifuge);
            details.Harnais2LiensDeRetenue = CreateVisibleFromEditObject(template.Harnais2LiensDeRetenue, permit.Harnais2LiensDeRetenue);
            //details.MasqueAntiPoussiere = CreateVisibleFromEditObject(template.MasqueAntiPoussiere, permit.MasqueAntiPoussiere);
            //details.FiltresParticules = CreateVisibleFromEditObject(template.FiltresParticules, permit.FiltresParticules);

            details.GantsData = permit.Gants.Text ?? String.Empty;
            details.Gants = CreateVisibleFromEditObject(template.Gants, permit.Gants.StateAsBool);

            details.MasqueACartouchesData = permit.MasqueACartouches.Text ?? String.Empty;
            details.MasqueACartouches = CreateVisibleFromEditObject(template.MasqueACartouches, permit.MasqueACartouches.StateAsBool);

            details.EpiAntiArcCatData = permit.EpiAntiArcCat.Text ?? String.Empty;
            details.EpiAntiArcCat = CreateVisibleFromEditObject(template.EpiAntiArcCat, permit.EpiAntiArcCat.StateAsBool);

            details.HabitCompletAntiEclaboussure = CreateVisibleFromEditObject(template.HabitCompletAntiEclaboussure, permit.HabitProtecteur.StateAsBool);
            details.HabitCompletAntiEclaboussureData = permit.HabitProtecteur.Text ?? String.Empty; ;

            //details.HabitCouvreToutJetable = CreateVisibleFromEditObject(template.HabitCouvreToutJetable, permit.HabitCouvreToutJetable);
            details.EpiAntiChoc = CreateVisibleFromEditObject(template.EpiAntiChoc, permit.EpiAntiChoc);
            //details.SystemeDAdductionDAir = CreateVisibleFromEditObject(template.SystemeDAdductionDAir, permit.SystemeDAdductionDAir);
            details.EcranDeflecteur = CreateVisibleFromEditObject(template.EcranDeflecteur, permit.EcranDeflecteur);
            details.MaltDesEquipements = CreateVisibleFromEditObject(template.MaltDesEquipements, permit.MaltDesEquipements);
            details.Rallonges = CreateVisibleFromEditObject(template.Rallonges, permit.Rallonges);
            details.ApprobationPourEquipDeLevage = CreateVisibleFromEditObject(template.ApprobationPourEquipDeLevage, permit.ApprobationPourEquipDeLevage);
            details.BarricadeRigide = CreateVisibleFromEditObject(template.BarricadeRigide, permit.BarricadeRigide);

            details.AutresEData = permit.AutresE.Text ?? String.Empty;
            details.AutresE = CreateVisibleFromEditObject(template.AutresE, permit.AutresE.StateAsBool);

            details.AlarmeDcsData = permit.AlarmeDcs.Text ?? String.Empty;
            details.AlarmeDcs = CreateVisibleFromEditObject(template.AlarmeDcs, permit.AlarmeDcs.StateAsBool);

            details.EchelleSecurisee = CreateVisibleFromEditObject(template.EchelleSecurisee, permit.EchelleSecurisee);
            details.EchafaudageApprouve = CreateVisibleFromEditObject(template.EchafaudageApprouve, permit.EchafaudageApprouve);
            details.PerimetreSecurite = CreateVisibleFromEditObject(template.PerimetreSecurite, permit.PerimetreSecurite);
            details.PerimetreSecuriteData = permit.PerimetreDeSecurityEquipementDePrevention.Text ?? String.Empty;
            details.Radio = CreateVisibleFromEditObject(template.Radio, permit.Radio);
            details.Signaleur = CreateVisibleFromEditObject(template.Signaleur, permit.Signaleur);
            
            details.DocumentLinks = permit.DocumentLinks;

            //details.OutilDeLaiton = CreateVisibleFromEditObject(template.OutilDeLaiton, permit.OutilDeLaiton);
            details.OutilDeLaiton = CreateVisibleFromEditObject(template.OutilManuelEquipementDePrevention, permit.OutilManuelEquipementDePrevention.StateAsBool);
            
            details.OutillageElectriqueCheckBox = CreateVisibleFromEditObject(template.OutilDeLaiton, permit.OutilDeLaiton);

            details.Soudage = CreateVisibleFromEditObject(template.Soudage, permit.Soudage);
            details.Traitement = CreateVisibleFromEditObject(template.Traitement, permit.Traitement);
            details.Cuissons = CreateVisibleFromEditObject(template.Cuissons, permit.Cuissons);
            details.Perçage = CreateVisibleFromEditObject(template.Perçage, permit.Perçage);
            details.Chaufferette = CreateVisibleFromEditObject(template.Chaufferette, permit.Chaufferette);
            details.Meulage = CreateVisibleFromEditObject(template.Meulage, permit.Meulage);
            details.Nettoyage = CreateVisibleFromEditObject(template.Nettoyage, permit.Nettoyage);
            details.TravauxDansZone = CreateVisibleFromEditObject(template.TravauxDansZone, permit.TravauxDansZone);
            details.Combustibles = CreateVisibleFromEditObject(template.Combustibles, permit.Combustibles);
            details.Ecran = CreateVisibleFromEditObject(template.Ecran, permit.Ecran);
            details.Boyau = CreateVisibleFromEditObject(template.Boyau, permit.Boyau);
            details.BoyauDe = CreateVisibleFromEditObject(template.BoyauDe, permit.BoyauDe);
            details.Couverture = CreateVisibleFromEditObject(template.Couverture, permit.Couverture);
            details.Extincteur = CreateVisibleFromEditObject(template.Extincteur, permit.Extincteur);
            details.Bouche = CreateVisibleFromEditObject(template.Bouche, permit.Bouche);
            details.RadioS = CreateVisibleFromEditObject(template.RadioS, permit.RadioS);
            details.Surveillant = CreateVisibleFromEditObject(template.Surveillant, permit.Surveillant);
            details.UtilisationMoteur = CreateVisibleFromEditObject(template.UtilisationMoteur, permit.UtilisationMoteur);
            details.NettoyageAu = CreateVisibleFromEditObject(template.NettoyageAu, permit.NettoyageAu);
            details.UtilisationElectronics = CreateVisibleFromEditObject(template.UtilisationElectronics, permit.UtilisationElectronics);
            details.Radiographie = CreateVisibleFromEditObject(template.Radiographie, permit.Radiographie);
            details.UtilisationOutlis = CreateVisibleFromEditObject(template.UtilisationOutlis, permit.UtilisationOutlis);
            details.UtilisationEquipments = CreateVisibleFromEditObject(template.UtilisationEquipments, permit.UtilisationEquipments);
            details.Demolition = CreateVisibleFromEditObject(template.Demolition, permit.Demolition);
            details.MhAutres = CreateVisibleFromEditObject(template.MhAutres, permit.MhAutres);
            details.Masque = CreateVisibleFromEditObject(template.MasqueSoudeur, permit.MasqueSoudeur);

            details.AutresTravauxData = permit.AutresTravaux.Text ?? String.Empty;
            details.AutresTravaux = CreateVisibleFromEditObject(template.AutresTravaux, permit.AutresTravaux.StateAsBool);

            details.ProcedureData = permit.Procedure.Text ?? String.Empty;
            details.Procedure = CreateVisibleFromEditObject(template.ProcedureEntretien, permit.Procedure.StateAsBool);

            details.EtiquetteData = permit.Etiquette.Text ?? String.Empty;
            details.Etiquette = CreateVisibleFromEditObject(template.EtiquettObturateur, permit.Etiquette.StateAsBool);

            details.AutresInstructionData = permit.AutresInstruction.Text ?? String.Empty;
            details.AutresInstruction = CreateVisibleFromEditObject(template.AutresInstruction, permit.AutresInstruction.StateAsBool);

            // signature section
            details.InstructionsSpeciales = permit.InstructionsSpeciales;
            details.SignatureOperateurSurLeTerrain = CreateVisibleFromEditObject(template.SignatureOperateurSurLeTerrain, permit.SignatureOperateurSurLeTerrain);
            details.DetectionDesGazs = CreateVisibleFromEditObject(template.DetectionDesGazs, permit.DetectionDesGazs);
            details.SignatureContremaitre = CreateVisibleFromEditObject(template.SignatureContremaitre, permit.SignatureContremaitre);
            details.SignatureAutorise = CreateVisibleFromEditObject(template.SignatureAutorise, permit.SignatureAutorise);
            details.NettoyageTransfertHorsSite = CreateVisibleFromEditObject(template.NettoyageTransfertHorsSite, permit.NettoyageTransfertHorsSite);

            // Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

            details.MudsAnswerTextBox = permit.MudsAnswerTextBox;
            details.MudsQuestionlabel = permit.MudsQuestionlabel;

            details.SetRequestDetails(
                permit.DataSource == DataSource.PERMIT_REQUEST,
                permit.RequestedDateTime,
                permit.RequestedByUser == null ? "" : permit.RequestedByUser.FullNameWithUserName,
                permit.Company,
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
                permit.Company_1,
                permit.Company_2,
                permit.Supervisor,
                permit.ExcavationNumber,
                permit.Attributes);


            // DMND0010609-OLT - Edmonton Work permit Scan
            IWorkPermitEdmontonService workPermitEdmontonService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            details.ViewAttachEnabled = workPermitEdmontonService.GetWorkpermitScan(Convert.ToString(permit.PermitNumber), Convert.ToInt32(userContext.Site.Id)).Count > 0;
            details.ViewScanEnabled = page.SelectedItems.Count==1 && userContext.UserRoleElements.HasRoleElement(RoleElement.WORKPERMIT_SCAN);
            // End DMND0010609-OLT - Edmonton Work permit Scan
        }

        //protected override WorkPermitMudsTemplateDTO CreateDTOFromDomainObject(WorkPermitMuds domainObject)
        //{
        //    return new WorkPermitMudsTemplateDTO(domainObject);
        //}

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_WorkPermit; }
        }

        protected override IList<WorkPermitMudsTemplateDTO> GetDtos(Range<Date> dateRange)
        {
            
                var username = ClientSession.GetUserContext().User.Username;
                return workPermitMudsService.QueryByDateRangeAndFlocsTemplate(dateRange, userContext.RootFlocSet, username);
            
          
            
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
        
        protected override bool IsItemInDateRange(WorkPermitMuds workPermit, Range<Date> range)
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
            get { return UserGridLayoutIdentifier.MudsWorkPermits; }
        }

         private void ViewAttachment(object sender, EventArgs e)
        {

            //WorkPermitMudsDTO workPermit = page.FirstSelectedItem;
            //IWorkPermitEdmontonService workPermitEdmontonService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            //List<WorkpermitScan> lst = workPermitEdmontonService.GetWorkpermitScan(Convert.ToString(workPermit.PermitNumber), Convert.ToInt32(userContext.Site.Id));
            //WorkPermitAttachment AttachementForm = new WorkPermitAttachment(lst);

            //if (lst != null && lst.Count > 0)
            //{

            //    AttachementForm.ShowDialog();
            //}
            //workPermit.Id
        }


         private void ViewGastest(object sender, EventArgs e)
         {
             QueryStandardGasTestElementInfoList();
             GasTestMudsForm gasTestMudsForm = new GasTestMudsForm();
             gasTestMudsForm.workpermitId = page.FirstSelectedItem.IdValue;
             gasTestMudsForm.permitnumber =Convert.ToString(page.FirstSelectedItem.PermitNumber);
             gasTestMudsForm.Permitstatus = page.FirstSelectedItem.Status;
             gasTestMudsForm.InitializeStandardGasTestElementInfoList(standardGasTestElementInfoList);
             gasTestMudsForm.ShowDialog();
         }

         private List<GasTestElementInfo> standardGasTestElementInfoList;
        
         private void QueryStandardGasTestElementInfoList()
         {

             standardGasTestElementInfoList = gasTestElementInfoService.QueryStandardElementInfosBySiteId(ClientSession.GetUserContext().SiteId);
         }
         private void MarkAsTemplate(object sender, EventArgs e)
         {
             //bool isWorkPermit = true;
             //MarkAsTemplateNameForm nameForm = new MarkAsTemplateNameForm(isWorkPermit);
             //nameForm.ShowDialog();
             //WorkPermitMuds workPermit = QueryForFirstSelectedItem();
             //workPermit.TemplateName = nameForm.WorkPermitTemplateName;
             //workPermit.Categories = nameForm.Category;


             //if (workPermit.TemplateName != string.Empty)
             //{
             //    workPermit.IsTemplate = true;
             //    workPermit.TemplateCreatedBy = ClientSession.GetUserContext().User.Username;

             //}
             //else
             //{
             //    workPermit.IsTemplate = false;

             //}

            
             
             //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitMudsService.Update, workPermit);
         }


         //protected override WorkPermitMuds QueryByDto(WorkPermitMudsTemplateDTO dto)
         //{
         //    throw new NotImplementedException();
         //}

         protected override WorkPermitMudsTemplateDTO CreateDTOFromDomainObject(WorkPermitMuds item)
         {
             return null;
         }

         private void RefreshAll(object sender, EventArgs e)
         {
             RefreshData();
         }

         private void EditTemplate(object sender, EventArgs e)
         {
             //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

             List<WorkPermitMudsTemplateDTO> permitDtos = page.SelectedItems;
             if (permitDtos.Count == 1)
             {
                 bool isWorkPermit = true;
                 MarkAsTemplateNameForm nameForm = new MarkAsTemplateNameForm(isWorkPermit);

                 nameForm.WorkPermitTemplateName = permitDtos[0].TemplateName;
                 nameForm.Category = permitDtos[0].Categories;
                 nameForm.Global = permitDtos[0].Global;

                 if (nameForm.Global)
                 {
                     nameForm.Individual = false;
                 }
                 else
                 {
                     nameForm.Individual = true;
                 }

                 nameForm.ShowDialog();

                 WorkPermitMuds workPermit = QueryForFirstSelectedItem();
                 workPermit.TemplateName = nameForm.WorkPermitTemplateName;
                 workPermit.Categories = nameForm.Category;
                 workPermit.Global = nameForm.Global;
                 workPermit.Individual = nameForm.Individual;

                 workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
                 workPermit.LastModifiedDateTime = Clock.Now;

                 var wp = workPermitMudsService.QueryByIdTemplate(workPermit.IdValue, workPermit.TemplateName, workPermit.Categories);

                 if (wp != null)
                 {
                     if (workPermit.TemplateName == wp._templateName && workPermit.Categories == wp._categories && nameForm.Save != false)
                     {
                         OltMessageBox.ShowError("Same Template Name and Category entry is already present. " +
                                                 "Cannot proceed further, please change the Temlate name and Category");
                     }
                 }
                 else
                 {
                     if (workPermit.TemplateName != string.Empty)
                     {
                         workPermit.TemplateId = permitDtos[0].TemplateId;
                         workPermit.IsTemplate = true;
                         workPermit.TemplateCreatedBy = ClientSession.GetUserContext().User.Username;
                         ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitMudsService.UpdateTemplate, workPermit);
                     }
                     else
                     {
                         workPermit.IsTemplate = false;
                     }
                 }


             }
         }
    }
}