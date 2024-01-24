using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitMontrealFormPresenter : AddEditBaseFormPresenter<IWorkPermitMontrealFormView, WorkPermitMontreal>
    {
        private readonly ICraftOrTradeService craftOrTradeService;
        private readonly IDropdownValueService dropdownValueService;
        private readonly IWorkPermitMontrealService service;
        private readonly IWorkPermitMontrealTemplateService workPermitTemplateService;
        private readonly IConfiguredDocumentLinkService configuredDocumentLinkService;

        private bool userHasViewedDocumentLinksInAnOlderSession;
        private bool userHasViewedDocumentLinksInThisSession;

        private List<DocumentLink> originalDocumentLinks;

        private DateTime originalStartDateTime;
        private DateTime originalEndDateTime;

        private List<WorkPermitMontrealTemplate> possibleTemplates;
        private bool formLoadComplete;

        private List<ShiftPattern> allShifts;
        private List<CraftOrTrade> craftOrTrades;
        private List<WorkPermitMontrealGroup> groups;
        private List<ConfiguredDocumentLink> configuredDocumentLinks;
        private List<DropdownValue> dropdownValues;

        private TernaryString savedDessinsRequisValue = new TernaryString(false, null);

        public WorkPermitMontrealFormPresenter() : this(null)
        {
        }

        public WorkPermitMontrealFormPresenter(WorkPermitMontreal editObject) : base(new WorkPermitMontrealForm(), editObject)
        {
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            service = clientServiceRegistry.GetService<IWorkPermitMontrealService>();
            workPermitTemplateService = clientServiceRegistry.GetService<IWorkPermitMontrealTemplateService>();

            craftOrTradeService = clientServiceRegistry.GetService<ICraftOrTradeService>();
            dropdownValueService = clientServiceRegistry.GetService<IDropdownValueService>();
            configuredDocumentLinkService = clientServiceRegistry.GetService<IConfiguredDocumentLinkService>();

            SubscribeToViewEvents();
        }

        private static void HandleOldTemplateVersionsOnEditAndClone(WorkPermitMontreal editObject,
                                                                    List<WorkPermitMontrealTemplate> workPermitMontrealTemplates)
        {
            if (editObject != null && editObject.Template.Id != null &&
                workPermitMontrealTemplates.DoesNotHave(t => t.IdValue == editObject.Template.IdValue))
            {
                // add the "deleted" or "inactive" template to the list with a name that reflects the fact that it's old
                editObject.Template.Name += String.Format(" ({0})", StringResources.MontrealWorkPermitTemplatesOldVersion);
                workPermitMontrealTemplates.Add(editObject.Template);

                // change the current template's (who has the same template number) name to indicate that it's the active one.
                WorkPermitMontrealTemplate currentActiveTemplate = workPermitMontrealTemplates.Find(t => t.TemplateNumber == editObject.Template.TemplateNumber && t.IsActive);
                currentActiveTemplate.Name += String.Format(" ({0})", StringResources.MontrealWorkPermitTemplatesCurrentVersion);
            }
        }

        private void SubscribeToViewEvents()
        {
            view.FormLoad += HandleFormLoad;
            view.WorkPermitTypeChanged += HandleSelectedWorkPermitTypeChange;
            view.WorkPermitTemplateChanged += HandleSelectedPermitTemplateChange;
            view.FunctionalLocationSelector += HandleFunctionalLocationClick;

            view.PreparationCheckChanged += HandlePreparationChange;

            view.ViewConfiguredDocumentLinkClicked += HandleViewConfiguredConfiguredDocumentLinkClicked;
            view.ConfinedSpaceButtonClicked += HandleConfinedSpaceButtonClicked;
            view.StartOrEndDateTimeValueChanged += HandleStartOrEndDateTimeValueChanged;

            view.AutresSubstancesTextValueChanged += HandleAutresSubstancesTextValueChanged;
            view.DocumentLinkOpened += HandleDocumentLinkOpened;
            view.DocumentLinkAdded += HandleDocumentLinkAdded;
        }

        private void HandleDocumentLinkOpened()
        {
            // if we are editing an existing permit, save the fact the user read a document link now so that it remembers even if they hit cancel
            if (editObject != null && editObject.Id != null)
            {
                ClientBackgroundWorker worker = new ClientBackgroundWorker();
                worker.DoWork += (sender, args) => service.InsertUserReadDocumentLinkAssociation(editObject.IdValue, userContext.User.IdValue);
                worker.RunWorkerAsync();
            }

            userHasViewedDocumentLinksInThisSession = true;
        }

        private void HandleDocumentLinkAdded()
        {
            userHasViewedDocumentLinksInThisSession = true;
        }

        private void HandleAutresSubstancesTextValueChanged(string value)
        {
            if (value != null && value.ToLower().Contains("vapeur"))
            {
                if (view.Habits.VisibleState == VisibleState.Visible && (!view.Habits.Value.HasValue || (view.Habits.Value.HasValue && !view.Habits.Value.Text.ToLower().Contains("manchons"))))
                {
                    view.Habits = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "Manchons"));
                }
            }
        }

        private void HandleStartOrEndDateTimeValueChanged(object sender, EventArgs e)
        {
            if (view.IsPreparation)
            {
                view.IsPreparation = false;
            }

            view.TurnOffAutosetIndicatorsForDateTimes();
        }

        private void SaveValuesInSession()
        {
            SessionStore sessionStore = ClientSession.GetInstance().GetSessionStore();
            if (view.IsPreparation)
            {
                sessionStore.SetValue(SessionStoreKey.WorkPermitMontrealPreparationCheckboxIsTicked, true);
                sessionStore.ClearValue(SessionStoreKey.WorkPermitMontrealStartDateTime);
                sessionStore.ClearValue(SessionStoreKey.WorkPermitMontrealEndDateTime);
            }
            else
            {
                sessionStore.ClearValue(SessionStoreKey.WorkPermitMontrealPreparationCheckboxIsTicked);

                // only save the dates if the user has actually changed them
                if (!originalStartDateTime.Equals(view.StartDateTime) || !originalEndDateTime.Equals(view.EndDateTime))
                {
                    sessionStore.SetValue(SessionStoreKey.WorkPermitMontrealStartDateTime, view.StartDateTime);
                    sessionStore.SetValue(SessionStoreKey.WorkPermitMontrealEndDateTime, view.EndDateTime);
                }
            }
        }

        private void RestoreStartAndEndDateTimeValuesFromSession()
        {
            SessionStore sessionStore = ClientSession.GetInstance().GetSessionStore();
            DateTime? savedStartDateTime = (DateTime?)sessionStore.GetValue(SessionStoreKey.WorkPermitMontrealStartDateTime);
            DateTime? savedEndDateTime = (DateTime?)sessionStore.GetValue(SessionStoreKey.WorkPermitMontrealEndDateTime);
            bool? savedPreparationCheckboxIsTicked = (bool?)sessionStore.GetValue(SessionStoreKey.WorkPermitMontrealPreparationCheckboxIsTicked);

            if (savedPreparationCheckboxIsTicked != null && savedPreparationCheckboxIsTicked.HasValue && savedPreparationCheckboxIsTicked.Value)
            {
                view.IsPreparation = true;
                HandlePreparationChange();
                view.TurnOnAutosetIndicatorsForDateTimes();
            }
            else
            {
                bool turnOnAutosetIndicators = false;
                if (savedStartDateTime != null && savedStartDateTime.HasValue)
                {
                    view.StartDateTime = savedStartDateTime.Value;
                    turnOnAutosetIndicators = true;
                }

                if (savedEndDateTime != null && savedEndDateTime.HasValue)
                {
                    view.EndDateTime = savedEndDateTime.Value;
                    turnOnAutosetIndicators = true;
                }

                if (turnOnAutosetIndicators)
                {
                    view.TurnOnAutosetIndicatorsForDateTimes();
                }
            }
        }

        protected override void SaveOrUpdate(bool shouldCloseForm)
        {
            if (!IsVehicleEntryOrLongDurationPermit)
            {
                SaveValuesInSession();
            }

            if (ShouldShowReviewDocumentLinksWarning())
            {
                DialogResult result = view.ShowReviewDocumentLinksWarning();
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            List<FunctionalLocation> functionalLocations = view.FunctionalLocations;
            if (WorkPermitMontrealReportAdapter.WillTruncateFunctionalLocations(functionalLocations))
            {
                DialogResult result = view.ShowFunctionalLocationsLengthWarning(WorkPermitMontrealReportAdapter.TruncatedFunctionalLocations(functionalLocations));
                if (result == DialogResult.OK)
                {
                    AskIfFieldOperatorShouldBeSelected();
                    base.SaveOrUpdate(shouldCloseForm);
                }
            }
            else
            {
                AskIfFieldOperatorShouldBeSelected();
                base.SaveOrUpdate(shouldCloseForm);
            }
        }

        private bool ShouldShowReviewDocumentLinksWarning()
        {
            return view.DocumentLinks.Count > 0 && !userHasViewedDocumentLinksInAnOlderSession && !userHasViewedDocumentLinksInThisSession && !UserHasAddedADocumentLinkInThisSession();
        }

        private bool UserHasReadDocumentLinks()
        {
            return view.DocumentLinks.Count > 0 && (userHasViewedDocumentLinksInAnOlderSession || userHasViewedDocumentLinksInThisSession || UserHasAddedADocumentLinkInThisSession());
        }

        private bool UserHasAddedADocumentLinkInThisSession()
        {
            List<string> urls = originalDocumentLinks.ConvertAll(link => link.Url);

            if (view.DocumentLinks.Exists(documentLink => !urls.Contains(documentLink.Url)))
            {
                return true;
            }

            return false;
        }

        protected bool IsVehicleEntryOrLongDurationPermit
        {
            get { return WorkPermitMontrealType.VEHICLE_ENTRY.Equals(view.SelectedPermitType) || view.SelectedPermitType.IsOneOf(WorkPermitMontrealType.DURATION_PERMIT_TYPES); }
        }


        /// <summary>
        /// If the field operator (SignatureOperateurSurLeTerrain) is visible and unchecked, check a field key fields to see if any of them are checked.  
        /// If so, then prompt the user with a message asking if they want the Field Operator to get checked automatically.
        /// </summary>
        private void AskIfFieldOperatorShouldBeSelected()
        {
            if (view.SignatureOperateurSurLeTerrain.VisibleState == VisibleState.Visible &&
                view.SignatureOperateurSurLeTerrain.Value == false &&
                (view.BoiteEnergieZero.Value.HasValue || view.ObtureOuDebranche.Value ||
                 view.DepressuriseEtVidange.Value || view.ChaineEtCadenasseOuScelle.Value || view.InterrupteursElectriquesVerrouilles.Value))
            {
                bool shouldAutoCheckFieldOperatorForUser = view.ShowFieldOperatorUncheckedWarning();
                if (shouldAutoCheckFieldOperatorForUser)
                {
                    view.SignatureOperateurSurLeTerrain = new Visible<bool>(VisibleState.Visible, true);
                }
            }
        }

        private void HandleConfinedSpaceButtonClicked()
        {
            SelectConfinedSpacePresenter presenter = new SelectConfinedSpacePresenter();
            DialogResultAndOutput<ConfinedSpaceDTO> dialogResultAndOutput = presenter.Run(view);

            if (dialogResultAndOutput.Result == DialogResult.OK &&
                dialogResultAndOutput.Output != null &&
                view.FormulaireDespaceClosAffiche.VisibleState == VisibleState.Visible)
            {
                view.FormulaireDespaceClosAffiche = CreateVisibleFromEditObject(
                    view.SelectedPermitTemplate.FormulaireDespaceClosAffiche,
                    new TernaryString(true, dialogResultAndOutput.Output.ConfinedSpaceNumber.ToString()));
            }
        }

        private void HandleViewConfiguredConfiguredDocumentLinkClicked()
        {
            ConfiguredDocumentLink configuredDocumentLink = view.SelectedConfiguredDocumentLink;
            if (configuredDocumentLink != null)
            {
                view.OpenFileOrDirectoryOrWebsite(configuredDocumentLink.Link);
            }
        }

        protected override bool ValidateViewHasError()
        {
            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            validator.ValidateUserFormAndSetErrors(view);
            return validator.HasErrors;
        }

        private void UpdateEditObjectFromView()
        {
            long? id = IsEdit ? editObject.Id : null;

            WorkPermitMontrealTemplate workPermitMontrealTemplate = view.SelectedPermitTemplate;

            User editUser = userContext.User;
            DateTime now = Clock.Now;

            if (IsEdit)
            {
                PermitRequestBasedWorkPermitStatus status = editObject.WorkPermitStatus;
                if (status == PermitRequestBasedWorkPermitStatus.Requested)
                {
                    status = PermitRequestBasedWorkPermitStatus.Pending;
                }
                
                editObject = new WorkPermitMontreal(editObject.IdValue, editObject.PermitNumber,
                                                    editObject.DataSource, status, view.SelectedPermitType, 
                                                    workPermitMontrealTemplate, view.StartDateTime, view.EndDateTime,
                                                    view.FunctionalLocations, editObject.WorkOrderNumber,
                                                    view.SelectedTrade,
                                                    view.Description, editObject.CreatedDateTime, editObject.CreatedBy, now, editUser, view.SelectedRequestedByGroup, editObject.IssuedDateTime);
            }
            else
            {
                editObject = new WorkPermitMontreal(DataSource.MANUAL, PermitRequestBasedWorkPermitStatus.Pending, view.SelectedPermitType,
                                                    workPermitMontrealTemplate,
                                                    view.StartDateTime, view.EndDateTime, view.FunctionalLocations, view.WorkOrderNumber,
                                                    view.SelectedTrade,
                                                    view.Description, now, editUser, now, editUser, view.SelectedRequestedByGroup, null);
            }
            editObject.Id = id;

            editObject.H2S = view.H2S.Value;
            editObject.Hydrocarbure = view.Hydrocarbure.Value;
            editObject.Ammoniaque = view.Ammoniaque.Value;
            editObject.Corrosif = view.Corrosif.Value;
            editObject.Aromatique = view.Aromatique.Value;
            editObject.AutresSubstances = view.AutresSubstances.Value;

            editObject.ClonedFormDetailMontreal = view.ClonedFormDetailMontreal; // Added by Vibhor : DMND0011077 - Work Permit Clone History

            editObject.ObtureOuDebranche = view.ObtureOuDebranche.Value;
            editObject.DepressuriseEtVidange = view.DepressuriseEtVidange.Value;
            editObject.EnPresenceDeGazInerte = view.EnPreenceDeGazInerte.Value;
            editObject.PurgeALaVapeur = view.PurgeALaVapeur.Value;
            editObject.RinceALeau = view.RinceALeau.Value;
            editObject.Excavation = view.Excavation.Value;

            editObject.DessinsRequis = view.DessinsRequis.Value;

            editObject.CablesChauffantsMisHorsTension = view.CablesChauffantsMisHorsTension.Value;
            editObject.PompeOuVerinPneumatique = view.PompeOuVerinPneumatique.Value;
            editObject.ChaineEtCadenasseOuScelle = view.ChaineEtCadenasseOuScelle.Value;
            editObject.InterrupteursElectriquesVerrouilles = view.InterrupteursElectriquesVerrouilles.Value;
            editObject.PurgeParUnGazInerte = view.PurgeParUnGazInerte.Value;
            editObject.OutilsElectriquesOuABatteries = view.OutilsElectriquesOuABatteries.Value;

            editObject.BoiteEnergieZero = view.BoiteEnergieZero.Value;

            editObject.OutilsPneumatiques = view.OutilsPneumatiques.Value;
            editObject.MoteurACombustionInterne = view.MoteurACombustionInterne.Value;
            editObject.TravauxSuperPoses = view.TravauxSuperPoses.Value;
            editObject.FormulaireDespaceClosAffiche = view.FormulaireDespaceClosAffiche.Value;

            editObject.ExisteIlUneAnalyseDeTache = view.ExisteIlUneAnalyseDeTache.Value;
            editObject.PossibiliteDeSulfureDeFer = view.PossibiliteDeSulfureDeFer.Value;
            editObject.AereVentile = view.AereVentile.Value;
            editObject.SoudureALelectricite = view.SoudureALelectricite.Value;
            editObject.BrulageAAcetylene = view.BrulageAAcetylene.Value;
            editObject.Nacelle = view.Nacelle.Value;
            editObject.AutreConditions = view.AutreConditions.Value;

            editObject.LunettesMonocoques = view.LunettesMonocoques.Value;
            editObject.HarnaisDeSecurite = view.HarnaisDeSecurite.Value;
            editObject.EcranFacial = view.EcranFacial.Value;
            editObject.ProtectionAuditive = view.ProtectionAuditive.Value;
            editObject.Trepied = view.Trepied.Value;
            editObject.DispositifAntichute = view.DispositifAntichute.Value;
            editObject.ProtectionRespiratoire = view.ProtectionRespiratoire.Value;
            editObject.Habits = view.Habits.Value;
            editObject.AutreProtection = view.AutreProtection.Value;

            editObject.Extincteur = view.Extincteur.Value;
            editObject.BouchesDegoutProtegees = view.BouchesDegoutProtegees.Value;
            editObject.CouvertureAntiEtincelles = view.CouvertureAntiEtincelles.Value;
            editObject.SurveillantPouretincelles = view.SurveillantPouretincelles.Value;
            editObject.PareEtincelles = view.PareEtincelles.Value;
            editObject.MiseAlaTerrePresDuLieuDeTravail = view.MiseAlaTerrePresDuLieuDeTravail.Value;
            editObject.BoyauAVapeur = view.BoyauAVapeur.Value;
            editObject.AutresEquipementDincendie = view.AutresEquipementDincendie.Value;

            editObject.Ventulateur = view.Ventulateur.Value;
            editObject.Barrieres = view.Barrieres.Value;
            editObject.Surveillant = view.Surveillant.Value;
            editObject.RadioEmetteur = view.RadioEmetteur.Value;
            editObject.PerimetreDeSecurite = view.PerimetreDeSecurite.Value;

            editObject.DetectionContinueDesGaz = view.DetectionContinueDesGaz.Value;

            editObject.KlaxonSonore = view.KlaxonSonore.Value;
            editObject.Localiser = view.Localiser.Value;
            editObject.Amiante = view.Amiante.Value;
            editObject.AutreEquipementsSecurite = view.AutreEquipementsSecurite.Value;

            editObject.InstructionsSpeciales = view.InstructionsSpeciales;
            editObject.SignatureOperateurSurLeTerrain = view.SignatureOperateurSurLeTerrain.Value;
            editObject.DetectionDesGazs = view.DetectionDesGazs.Value;
            editObject.SignatureContremaitre = view.SignatureContremaitre.Value;
            editObject.SignatureAutorise = view.SignatureAutorise.Value;
            editObject.NettoyageTransfertHorsSite = view.NettoyageTransfertHorsSite.Value;

            editObject.DocumentLinks = view.DocumentLinks;
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.InsertWithUserReadDocumentLinkAssociation, editObject, UserHasReadDocumentLinks());
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateWithUserReadDocumentLinkAssociation, editObject, UserHasReadDocumentLinks());
        }

        private void UpdateViewFromTemplate(WorkPermitMontrealTemplate template)
        {
            WithTheSavingAndReplacingOfDessinsRequis(template, delegate
                                                                   {
                                                                       new WorkPermitMontrealTemplateViewMapper(view, template).MapTemplateToView();
                                                                   });
        }

        // Sometimes the dessins requis value comes from the excavation number in the permit request, so as the user flips through templates (some
        // of which don't have this field) we want to maintain the value in the textbox.
        private void WithTheSavingAndReplacingOfDessinsRequis(WorkPermitMontrealTemplate template, Action action)
        {
            if (IsEdit && view.DessinsRequis.Value.HasValue)
            {
                savedDessinsRequisValue = view.DessinsRequis.Value;
            }

            action();

            if (savedDessinsRequisValue.HasValue)
            {
                view.DessinsRequis = CreateVisibleFromEditObject(template.DessinsRequis, savedDessinsRequisValue);
            }
        }

        private Visible<bool> CreateVisibleFromEditObject(TemplateState state, bool value)
        {
            if (TemplateState.Invisible == state)
            {
                return new Visible<bool>(VisibleState.Invisible, false);
            }
            return new Visible<bool>(VisibleState.Visible, value);
        }
        
        private Visible<TernaryString> CreateVisibleFromEditObject(TemplateState state, TernaryString value)
        {
            if (state == TemplateState.Invisible)
            {
                return new Visible<TernaryString>(VisibleState.Invisible, new TernaryString(false, null));
            }
            return new Visible<TernaryString>(VisibleState.Visible, value);
        }

        private void UpdateViewFromEditObject()
        {
            WorkPermitMontrealTemplate template = editObject.Template;

            view.SelectedPermitType = editObject.WorkPermitType;
            view.SelectedPermitTemplate = editObject.Template;
            view.FunctionalLocations = editObject.FunctionalLocations ?? new List<FunctionalLocation>();
            view.SelectedTrade = editObject.Trade;
            view.Description = editObject.Description;
            view.StartDateTime = editObject.StartDateTime;
            view.EndDateTime = editObject.EndDateTime;
            view.WorkOrderNumber = editObject.WorkOrderNumber;
            view.SelectedRequestedByGroup = editObject.RequestedByGroup;
            view.ClonedFormDetailMontreal = editObject.ClonedFormDetailMontreal; // Added by Vibhor : DMND0011077 - Work Permit Clone History

            if (editObject.PermitNumber.HasValue)
            {
                view.ReferenceNumber = editObject.PermitNumber.Value.ToString();
            }

            #region start of update
            view.H2S = CreateVisibleFromEditObject(template.H2S, editObject.H2S);
            view.Hydrocarbure = CreateVisibleFromEditObject(template.Hydrocarbure, editObject.Hydrocarbure);

            view.Ammoniaque = CreateVisibleFromEditObject(template.Ammoniaque, editObject.Ammoniaque);
            view.Corrosif = CreateVisibleFromEditObject(template.Corrosif, editObject.Corrosif);
            view.Aromatique = CreateVisibleFromEditObject(template.Aromatique, editObject.Aromatique);
            view.AutresSubstances = CreateVisibleFromEditObject(template.AutresSubstances, editObject.AutresSubstances);

            view.ObtureOuDebranche = CreateVisibleFromEditObject(template.ObtureOuDebranche, editObject.ObtureOuDebranche);
            view.DepressuriseEtVidange = CreateVisibleFromEditObject(template.DepressuriseEtVidange, editObject.DepressuriseEtVidange);
            view.EnPreenceDeGazInerte = CreateVisibleFromEditObject(template.EnPresenceDeGazInerte, editObject.EnPresenceDeGazInerte);
            view.PurgeALaVapeur = CreateVisibleFromEditObject(template.PurgeALaVapeur, editObject.PurgeALaVapeur);
            view.RinceALeau = CreateVisibleFromEditObject(template.RinceALeau, editObject.RinceALeau);
            view.Excavation = CreateVisibleFromEditObject(template.Excavation, editObject.Excavation);

            view.DessinsRequis = CreateVisibleFromEditObject(template.DessinsRequis, editObject.DessinsRequis);

            view.CablesChauffantsMisHorsTension = CreateVisibleFromEditObject(template.CablesChauffantsMisHorsTension, editObject.CablesChauffantsMisHorsTension);
            view.PompeOuVerinPneumatique = CreateVisibleFromEditObject(template.PompeOuVerinPneumatique, editObject.PompeOuVerinPneumatique);
            view.ChaineEtCadenasseOuScelle = CreateVisibleFromEditObject(template.ChaineEtCadenasseOuScelle, editObject.ChaineEtCadenasseOuScelle);
            view.InterrupteursElectriquesVerrouilles =
                CreateVisibleFromEditObject(template.InterrupteursElectriquesVerrouilles,
                                            editObject.InterrupteursElectriquesVerrouilles);
            view.PurgeParUnGazInerte = CreateVisibleFromEditObject(template.PurgeParUnGazInerte, editObject.PurgeParUnGazInerte);
            view.OutilsElectriquesOuABatteries = CreateVisibleFromEditObject(template.OutilsElectriquesOuABatteries, editObject.OutilsElectriquesOuABatteries);

            view.BoiteEnergieZero = CreateVisibleFromEditObject(template.BoiteEnergieZero, editObject.BoiteEnergieZero);

            view.OutilsPneumatiques = CreateVisibleFromEditObject(template.OutilsPneumatiques, editObject.OutilsPneumatiques);
            view.MoteurACombustionInterne = CreateVisibleFromEditObject(template.MoteurACombustionInterne, editObject.MoteurACombustionInterne);
            view.TravauxSuperPoses = CreateVisibleFromEditObject(template.TravauxSuperPoses, editObject.TravauxSuperPoses);
            view.FormulaireDespaceClosAffiche = CreateVisibleFromEditObject(template.FormulaireDespaceClosAffiche, editObject.FormulaireDespaceClosAffiche);

            view.ExisteIlUneAnalyseDeTache = CreateVisibleFromEditObject(template.ExisteIlUneAnalyseDeTache, editObject.ExisteIlUneAnalyseDeTache);
            view.PossibiliteDeSulfureDeFer = CreateVisibleFromEditObject(template.PossibiliteDeSulfureDeFer, editObject.PossibiliteDeSulfureDeFer);
            view.AereVentile = CreateVisibleFromEditObject(template.AereVentile, editObject.AereVentile);
            view.SoudureALelectricite = CreateVisibleFromEditObject(template.SoudureALelectricite, editObject.SoudureALelectricite);
            view.BrulageAAcetylene = CreateVisibleFromEditObject(template.BrulageAAcetylene, editObject.BrulageAAcetylene);
            view.Nacelle = CreateVisibleFromEditObject(template.Nacelle, editObject.Nacelle);
            view.AutreConditions = CreateVisibleFromEditObject(template.AutreConditions, editObject.AutreConditions);

            view.LunettesMonocoques = CreateVisibleFromEditObject(template.LunettesMonocoques, editObject.LunettesMonocoques);
            view.HarnaisDeSecurite = CreateVisibleFromEditObject(template.HarnaisDeSecurite, editObject.HarnaisDeSecurite);
            view.EcranFacial = CreateVisibleFromEditObject(template.EcranFacial, editObject.EcranFacial);
            view.ProtectionAuditive = CreateVisibleFromEditObject(template.ProtectionAuditive, editObject.ProtectionAuditive);
            view.Trepied = CreateVisibleFromEditObject(template.Trepied, editObject.Trepied);
            view.DispositifAntichute = CreateVisibleFromEditObject(template.DispositifAntichute, editObject.DispositifAntichute);
            view.ProtectionRespiratoire = CreateVisibleFromEditObject(template.ProtectionRespiratoire, editObject.ProtectionRespiratoire);
            view.Habits = CreateVisibleFromEditObject(template.Habits, editObject.Habits);
            view.AutreProtection = CreateVisibleFromEditObject(template.AutreProtection, editObject.AutreProtection);

            view.Extincteur = CreateVisibleFromEditObject(template.Extincteur, editObject.Extincteur);
            view.BouchesDegoutProtegees = CreateVisibleFromEditObject(template.BouchesDegoutProtegees, editObject.BouchesDegoutProtegees);
            view.CouvertureAntiEtincelles = CreateVisibleFromEditObject(template.CouvertureAntiEtincelles, editObject.CouvertureAntiEtincelles);
            view.SurveillantPouretincelles = CreateVisibleFromEditObject(template.SurveillantPouretincelles, editObject.SurveillantPouretincelles);
            view.PareEtincelles = CreateVisibleFromEditObject(template.PareEtincelles, editObject.PareEtincelles);
            view.MiseAlaTerrePresDuLieuDeTravail = CreateVisibleFromEditObject(template.MiseAlaTerrePresDuLieuDeTravail, editObject.MiseAlaTerrePresDuLieuDeTravail);
            view.BoyauAVapeur = CreateVisibleFromEditObject(template.BoyauAVapeur, editObject.BoyauAVapeur);
            view.AutresEquipementDincendie = CreateVisibleFromEditObject(template.AutresEquipementDincendie, editObject.AutresEquipementDincendie);

            view.Ventulateur = CreateVisibleFromEditObject(template.Ventulateur, editObject.Ventulateur);
            view.Barrieres = CreateVisibleFromEditObject(template.Barrieres, editObject.Barrieres);
            view.Surveillant = CreateVisibleFromEditObject(template.Surveillant, editObject.Surveillant);
            view.RadioEmetteur = CreateVisibleFromEditObject(template.RadioEmetteur, editObject.RadioEmetteur);
            view.PerimetreDeSecurite = CreateVisibleFromEditObject(template.BoiteEnergieZero, editObject.PerimetreDeSecurite);

            view.DetectionContinueDesGaz = CreateVisibleFromEditObject(template.DetectionContinueDesGaz, editObject.DetectionContinueDesGaz);

            view.KlaxonSonore = CreateVisibleFromEditObject(template.KlaxonSonore, editObject.KlaxonSonore);
            view.Localiser = CreateVisibleFromEditObject(template.Localiser, editObject.Localiser);
            view.Amiante = CreateVisibleFromEditObject(template.Amiante, editObject.Amiante);
            view.AutreEquipementsSecurite = CreateVisibleFromEditObject(template.AutreEquipementsSecurite, editObject.AutreEquipementsSecurite);

            // this is always viewable (TemplateState.Default)
            view.InstructionsSpeciales = editObject.InstructionsSpeciales;
            view.SignatureOperateurSurLeTerrain = CreateVisibleFromEditObject(template.SignatureOperateurSurLeTerrain, editObject.SignatureOperateurSurLeTerrain);
            view.DetectionDesGazs = CreateVisibleFromEditObject(template.DetectionDesGazs, editObject.DetectionDesGazs);
            view.SignatureContremaitre = CreateVisibleFromEditObject(template.SignatureContremaitre, editObject.SignatureContremaitre);
            view.SignatureAutorise = CreateVisibleFromEditObject(template.SignatureAutorise, editObject.SignatureAutorise);
            view.NettoyageTransfertHorsSite = CreateVisibleFromEditObject(template.NettoyageTransfertHorsSite, editObject.NettoyageTransfertHorsSite);

            view.DocumentLinks = editObject.DocumentLinks;
            #endregion

            view.SetRequestDetails(
                editObject.DataSource == DataSource.PERMIT_REQUEST,
                editObject.RequestedDateTime,
                editObject.RequestedByUser == null ? "" : editObject.RequestedByUser.FullNameWithUserName,
                editObject.Company,
                editObject.Supervisor,
                editObject.ExcavationNumber,
                editObject.Attributes);
        }

        private void UpdateViewWithDefaults()
        {
            SetStartAndEndDateTimesInCurrentShift();
            view.DocumentLinks = new List<DocumentLink>();
            view.SetRequestDetails(false, null, null, null, null, null, new List<PermitAttribute>());
        }

        private void HandleFormLoad()
        {
            LoadData(new List<Action> { QueryCraftOrTrades, QueryGroups, QueryConfiguredDocumentLinks, QueryDropdownValues, QueryTemplates, QueryShifts, QueryUserHasViewedDocumentLinks });
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.CreateOrEditWorkPermitFormTitle);

            view.Trade = craftOrTrades;
            view.RequestedByGroupValues = groups;

            if (configuredDocumentLinks.Count == 0)
            {
                view.DisableConfiguredDocumentLinks();
            }
            else
            {
                view.ConfiguredDocumentLinks = configuredDocumentLinks;
            }

            SetDropdownValues(dropdownValues);

            SetDefaultListOfPermitTypes();
            SetDefaultListOfPermitTemplates();

            if (IsEdit)
            {
                bool statusIsRequested = editObject.WorkPermitStatus.Id == PermitRequestBasedWorkPermitStatus.Requested.Id;
                if (statusIsRequested)
                {
                    UpdateTemplateListBasedOnPermitType(editObject.WorkPermitType);
                }
                UpdateViewFromEditObject();
                view.DisableFieldsForPermitEdit(statusIsRequested);
            }
            else if (IsClone)
            {
                UpdateTemplateListBasedOnPermitType(editObject.WorkPermitType);
                UpdateViewFromEditObject();

                // Do not clone any Details from the "Detials de le demande" section
                view.SetRequestDetails(false, null, null, null, null, null, new List<PermitAttribute>());

                SetStartAndEndDateTimesInCurrentShift();
                if (editObject.WorkPermitType == WorkPermitMontrealType.VEHICLE_ENTRY)
                {
                    view.EndDateTime = view.StartDateTime.AddHours(1);
                }
            }
            else
            {
                UpdateViewWithDefaults();
            }

            if (!IsClone && !(IsEdit && IsVehicleEntryOrLongDurationPermit))
            {
                RestoreStartAndEndDateTimeValuesFromSession();
            }

            // Save the original start/end times. Later, if these have changed, we'll save them as a user session preference.
            originalStartDateTime = view.StartDateTime;
            originalEndDateTime = view.EndDateTime;

            originalDocumentLinks = new List<DocumentLink>(view.DocumentLinks);

            formLoadComplete = true;            
        }

        private void QueryShifts()
        {
            IShiftPatternService shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();
            allShifts = shiftPatternService.QueryBySite(userContext.Site);
        }

        private void QueryTemplates()
        {
            List<WorkPermitMontrealTemplate> workPermitMontrealTemplates = workPermitTemplateService.QueryAllNotDeleted().FindAll(t => t.IsActive);

            // In the case of a Clone or an Edit we may need to show an old Template version if it exists
            HandleOldTemplateVersionsOnEditAndClone(editObject, workPermitMontrealTemplates);

            possibleTemplates = workPermitMontrealTemplates;
            possibleTemplates.Sort(WorkPermitMontrealTemplate.CompareByTemplateNumber);
        }

        private void QueryUserHasViewedDocumentLinks()
        {
            if (editObject != null && editObject.Id != null)
            {
                userHasViewedDocumentLinksInAnOlderSession = service.HasUserReadAtLeastOneDocumentLink(userContext.User.IdValue, editObject.IdValue);
            }
            else
            {
                userHasViewedDocumentLinksInAnOlderSession = false;
            }            
        }

        private void QueryCraftOrTrades()
        {
            craftOrTrades = craftOrTradeService.QueryBySite(userContext.Site);
            craftOrTrades.Insert(0, CraftOrTrade.EMPTY);
        }

        private void QueryGroups()
        {
            groups = service.QueryAllGroups();
            groups.Insert(0, WorkPermitMontrealGroup.EMPTY);
        }

        private void QueryConfiguredDocumentLinks()
        {
            configuredDocumentLinks = configuredDocumentLinkService.GetLinks(ConfiguredDocumentLinkLocation.WorkPermitMontreal);
        }

        private void QueryDropdownValues()
        {
            dropdownValues = dropdownValueService.QueryAll(Site.MONTREAL_ID);
        }

        private void SetDropdownValues(List<DropdownValue> dropdownValues)
        {
            view.ProtectionRespiratoireValues = WorkPermitMontrealDropDownValueKeys.ProtectionRespiratoireDropdownValues(dropdownValues);
            view.AromatiqueValues = WorkPermitMontrealDropDownValueKeys.AromatiqueDropdownValues(dropdownValues);
            view.AutreConditionsValues = WorkPermitMontrealDropDownValueKeys.AutresConditionsDropdownValues(dropdownValues);
            view.AutreEquipementsSecuriteValues =
                WorkPermitMontrealDropDownValueKeys.AutreSecuriteDropdownValues(dropdownValues);
            view.AutreProtectionValues = WorkPermitMontrealDropDownValueKeys.AutreProtectionDropdownValues(dropdownValues);
            view.AutresEquipementDincendieValues =
                WorkPermitMontrealDropDownValueKeys.AutresEquipementDIncendieDropdownValues(dropdownValues);
            view.AutresSubstancesValues = WorkPermitMontrealDropDownValueKeys.AutresSubstancesDropdownValues(dropdownValues);
            view.CorrosifValues = WorkPermitMontrealDropDownValueKeys.CorrosifDropdownValues(dropdownValues);
            view.DetectionContinueDesGazValues =
                WorkPermitMontrealDropDownValueKeys.DetectionContinueDesGazDropdownValues(dropdownValues);
            view.HabitsValues = WorkPermitMontrealDropDownValueKeys.HabitsRespiratoireDropdownValues(dropdownValues);
            view.SurveillantValues = WorkPermitMontrealDropDownValueKeys.SurveillantDropdownValues(dropdownValues);
        }

        private void SetDefaultListOfPermitTemplates()
        {
            List<WorkPermitMontrealTemplate> templates = new List<WorkPermitMontrealTemplate>(possibleTemplates);
            templates.Insert(0, WorkPermitMontrealTemplate.NULL);
            view.PermitTemplates = templates;
        }

        private void SetDefaultListOfPermitTypes()
        {
            List<WorkPermitMontrealType> workPermitTypes = new List<WorkPermitMontrealType>(WorkPermitMontrealType.All);
            workPermitTypes.Insert(0, WorkPermitMontrealType.NULL);
            view.PermitTypes = workPermitTypes;
        }

        private void SetStartAndEndDateTimesInCurrentShift()
        {
            UserShift userShift = userContext.UserShift;
            DateTime shiftStartDateTime = userShift.StartDateTime;
            DateTime shiftEndDateTime = userShift.EndDateTime;
            DateTime currentDateTime = Clock.Now;

            DateTime startDateTime = currentDateTime >= shiftStartDateTime ? currentDateTime : shiftStartDateTime;
            DateTime endDateTime = currentDateTime >= shiftEndDateTime ? currentDateTime : shiftEndDateTime;

            view.StartDateTime = startDateTime;
            view.EndDateTime = endDateTime;
        }

        private void HandleSelectedPermitTemplateChange()
        {
            if (formLoadComplete)
            {
                WorkPermitMontrealTemplate selectedTemplate = view.SelectedPermitTemplate;
                if (selectedTemplate == WorkPermitMontrealTemplate.NULL)
                {
                    SetDefaultListOfPermitTypes();
                }
                else
                {
                    WorkPermitMontrealType workPermitType = selectedTemplate.WorkPermitType;
                    view.SelectedPermitType = workPermitType;
                }
                UpdateViewFromTemplate(selectedTemplate);
            }
        }

        private void HandleSelectedWorkPermitTypeChange()
        {
            if (formLoadComplete)
            {
                UpdateTemplateListBasedOnPermitType(view.SelectedPermitType);

                if (view.SelectedPermitType == WorkPermitMontrealType.VEHICLE_ENTRY)
                {
                    view.StartDateTime = Clock.Now;
                    view.EndDateTime = view.StartDateTime.AddHours(1);
                }
            }
        }

        private void UpdateTemplateListBasedOnPermitType(WorkPermitMontrealType selectedPermitType)
        {
            if (selectedPermitType == WorkPermitMontrealType.NULL)
            {
                SetDefaultListOfPermitTemplates();
            }
            else
            {
                List<WorkPermitMontrealTemplate> workPermitMontrealTemplates =
                    possibleTemplates.FindAll(t => t.WorkPermitType == selectedPermitType);
                workPermitMontrealTemplates.Insert(0, WorkPermitMontrealTemplate.NULL);

                view.PermitTemplates = workPermitMontrealTemplates;    
                    
            }
            UpdateViewFromTemplate(WorkPermitMontrealTemplate.NULL);
        }

        private void HandleFunctionalLocationClick()
        {
            List<FunctionalLocation> selectedFlocs = view.ShowFunctionalLocationSelector(view.FunctionalLocations);
            if (selectedFlocs != null)
            {
                view.FunctionalLocations = selectedFlocs;
            }
        }

        private void HandlePreparationChange()
        {
            view.StartOrEndDateTimeValueChanged -= HandleStartOrEndDateTimeValueChanged;
            SetStartAndEndDateTimes();
            view.StartOrEndDateTimeValueChanged += HandleStartOrEndDateTimeValueChanged;
        }

        private void SetStartAndEndDateTimes()
        {
            if (view.IsPreparation && view.SelectedPermitType != WorkPermitMontrealType.VEHICLE_ENTRY)
            {
                UserShift nextShift = userContext.UserShift.ChooseNextShift(allShifts);
                view.StartDateTime = nextShift.StartDateTime;
                view.EndDateTime = nextShift.EndDateTime;
            }
            else if (view.SelectedPermitType == WorkPermitMontrealType.VEHICLE_ENTRY)
            {
                DateTime currentDateTime = Clock.Now;
                view.StartDateTime = currentDateTime;
                view.EndDateTime = currentDateTime.AddHours(1);
            }
            else
            {
                SetStartAndEndDateTimesInCurrentShift();
            }
            
        }
    }
}