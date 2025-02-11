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
using System.Linq;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitMudsFormPresenter : AddEditBaseFormPresenter<IWorkPermitMudsFormView, WorkPermitMuds>
    {
        private readonly ICraftOrTradeService craftOrTradeService;
        private readonly IContractorService contractorService;
        private readonly IDropdownValueService dropdownValueService;
        private readonly IWorkPermitMudsService service;
        private readonly IWorkPermitMudsTemplateService workPermitTemplateService;
        private readonly IConfiguredDocumentLinkService configuredDocumentLinkService;

        private bool _utilisationElectronics = false;

        private bool userHasViewedDocumentLinksInAnOlderSession;
        private bool userHasViewedDocumentLinksInThisSession;

        private List<DocumentLink> originalDocumentLinks;

        private DateTime originalStartDateTime;
        private DateTime originalEndDateTime;

        private List<WorkPermitMudsTemplate> possibleTemplates;
        private bool formLoadComplete;

        private List<ShiftPattern> allShifts;
        private List<CraftOrTrade> craftOrTrades;
        private List<Contractor> contractors;
        private List<WorkPermitMudsGroup> groups;
        private List<ConfiguredDocumentLink> configuredDocumentLinks;
        private List<DropdownValue> dropdownValues;

        private TernaryString savedDessinsRequisValue = new TernaryString(false, null);

        private TernaryString interrupteursEtVannesCadenasses = new TernaryString(false, null);
        private TernaryString remplirLeFormulaireDeCondition = new TernaryString(false, null);
        private Visible<bool> travailEnHauteur6EtPlus = new Visible<bool>(VisibleState.Visible, false);

        private Visible<bool> analyseCritiqueDeLaTache = new Visible<bool>(VisibleState.Visible, false);// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        private TernaryString procedureEntretien = new TernaryString(false, null);// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        
        
        private Visible<bool> vapeurCondensat = new Visible<bool>(VisibleState.Visible, false); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

        private Visible<bool> feSValue = new Visible<bool>(VisibleState.Visible, false); 
        
        private Visible<bool> echafaudageApprouve = new Visible<bool>(VisibleState.Visible, false);
        
        private Visible<bool> outilDeLaitonPrevention = new Visible<bool>(VisibleState.Visible, false);

        private Visible<bool> echelleSecurisee = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> harnais2LiensDeRetenue = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> radio = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> signaleur = new Visible<bool>(VisibleState.Visible, false);
        private TernaryString perimetreSecurite = new TernaryString(false, null);
        private TernaryString appareil = new TernaryString(false, null);
        private Visible<bool> barricadeRigide = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> utilisationMoteur = new Visible<bool>(VisibleState.Visible, false);
        private TernaryString alarmeDcs = new TernaryString(false, null);
        private Visible<bool> approbationPourEquipDeLevage = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> lunettesMonocoques = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> sbs = new Visible<bool>(VisibleState.Visible, false);
        private TernaryString electriciteVolt = new TernaryString(false, null);
        private Visible<bool> electrisation = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> nettoyageAu = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> utilisationElectronics = new Visible<bool>(VisibleState.Visible, false);
        private TernaryString outillageElectrique = new TernaryString(false, null);
        private Visible<bool> radiographie = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> radiations = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> utilisationOutlis = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> utilisationEquipments = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> soudage = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> incendieExplosion = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> visiere = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> protectionAuditive = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> traitement = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> cuissons = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> per�age = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> chaufferette = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> nettoyage = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> travauxDansZone = new Visible<bool>(VisibleState.Visible, false);
        private Visible<bool> verrouillagesParTravailleurs = new Visible<bool>(VisibleState.Visible, false);
        private List<GasTestElementInfo> standardGasTestElementInfoList;
        private readonly IGasTestElementInfoService gasTestElementInfoService;

        private readonly IDictionary<GasTestElementDetailsMuds, GasTestElement> detailsToGasTestElementTable;

        public WorkPermitMudsFormPresenter()
            : this(null)
        {
        }

        public WorkPermitMudsFormPresenter(WorkPermitMuds editObject)
            : base(new WorkPermitMudsForm(), editObject)
        {
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            service = clientServiceRegistry.GetService<IWorkPermitMudsService>();
            workPermitTemplateService = clientServiceRegistry.GetService<IWorkPermitMudsTemplateService>();

            craftOrTradeService = clientServiceRegistry.GetService<ICraftOrTradeService>();
            contractorService = clientServiceRegistry.GetService<IContractorService>();
            //contractorService = ClientServiceRegistry.Instance.GetService<IContractorService>();
            dropdownValueService = clientServiceRegistry.GetService<IDropdownValueService>();
            configuredDocumentLinkService = clientServiceRegistry.GetService<IConfiguredDocumentLinkService>();
            gasTestElementInfoService = clientServiceRegistry.GetService<IGasTestElementInfoService>();
            SubscribeToViewEvents();

            //view.ProtectionAuditive = new Visible<bool>(VisibleState.Visible, true); ;
            detailsToGasTestElementTable = new Dictionary<GasTestElementDetailsMuds, GasTestElement>();
            QueryStandardGasTestElementInfoList();
        }

        private static void HandleOldTemplateVersionsOnEditAndClone(WorkPermitMuds editObject,
                                                                    List<WorkPermitMudsTemplate> workPermitMudsTemplates)
        {
            if (editObject != null && editObject.Template.Id != null &&
                workPermitMudsTemplates.DoesNotHave(t => t.IdValue == editObject.Template.IdValue))
            {
                // add the "deleted" or "inactive" template to the list with a name that reflects the fact that it's old
                editObject.Template.Name += String.Format(" ({0})", StringResources.MontrealWorkPermitTemplatesOldVersion);
                workPermitMudsTemplates.Add(editObject.Template);

                // change the current template's (who has the same template number) name to indicate that it's the active one.
                WorkPermitMudsTemplate currentActiveTemplate = workPermitMudsTemplates.Find(t => t.TemplateNumber == editObject.Template.TemplateNumber && t.IsActive);
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

            //view.AutresSubstancesTextValueChanged += HandleAutresSubstancesTextValueChanged;
            view.DocumentLinkOpened += HandleDocumentLinkOpened;
            view.DocumentLinkAdded += HandleDocumentLinkAdded;

            view.UtilisationElectronicsChanged += HandleUtilisationElectronicsChange;
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

        //private void HandleAutresSubstancesTextValueChanged(string value)
        //{
        //    if (value != null && value.ToLower().Contains("vapeur"))
        //    {
        //        if (view.Habits.VisibleState == VisibleState.Visible && (!view.Habits.Value.HasValue || (view.Habits.Value.HasValue && !view.Habits.Value.Text.ToLower().Contains("manchons"))))
        //        {
        //            view.Habits = new Visible<TernaryString>(VisibleState.Visible, new TernaryString(true, "Manchons"));
        //        }
        //    }
        //}

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
                sessionStore.SetValue(SessionStoreKey.WorkPermitMudsPreparationCheckboxIsTicked, true);
                sessionStore.ClearValue(SessionStoreKey.WorkPermitMudsStartDateTime);
                sessionStore.ClearValue(SessionStoreKey.WorkPermitMudsEndDateTime);
            }
            else
            {
                sessionStore.ClearValue(SessionStoreKey.WorkPermitMudsPreparationCheckboxIsTicked);

                // only save the dates if the user has actually changed them
                if (!originalStartDateTime.Equals(view.StartDateTime) || !originalEndDateTime.Equals(view.EndDateTime))
                {
                    sessionStore.SetValue(SessionStoreKey.WorkPermitMudsStartDateTime, view.StartDateTime);
                    sessionStore.SetValue(SessionStoreKey.WorkPermitMudsEndDateTime, view.EndDateTime);
                }
            }
        }

        private void RestoreStartAndEndDateTimeValuesFromSession()
        {
            SessionStore sessionStore = ClientSession.GetInstance().GetSessionStore();
            DateTime? savedStartDateTime = (DateTime?)sessionStore.GetValue(SessionStoreKey.WorkPermitMudsStartDateTime);
            DateTime? savedEndDateTime = (DateTime?)sessionStore.GetValue(SessionStoreKey.WorkPermitMudsEndDateTime);
            bool? savedPreparationCheckboxIsTicked = (bool?)sessionStore.GetValue(SessionStoreKey.WorkPermitMudsPreparationCheckboxIsTicked);

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
            if (WorkPermitMudsReportAdapter.WillTruncateFunctionalLocations(functionalLocations))  //TODO Report part
            {
                DialogResult result = view.ShowFunctionalLocationsLengthWarning(WorkPermitMudsReportAdapter.TruncatedFunctionalLocations(functionalLocations));
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
            get { return false; }
        }


        /// <summary>
        /// If the field operator (SignatureOperateurSurLeTerrain) is visible and unchecked, check a field key fields to see if any of them are checked.  
        /// If so, then prompt the user with a message asking if they want the Field Operator to get checked automatically.
        /// </summary>
        private void AskIfFieldOperatorShouldBeSelected()
        {
            if (view.SignatureOperateurSurLeTerrain.VisibleState == VisibleState.Visible &&
                view.SignatureOperateurSurLeTerrain.Value == false
                //&& (view.BoiteEnergieZero.Value.HasValue || view.ObtureOuDebranche.Value ||
                // view.DepressuriseEtVidange.Value || view.ChaineEtCadenasseOuScelle.Value || view.InterrupteursElectriquesVerrouilles.Value)
                )
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
            SelectConfinedSpaceMudsPresenter presenter = new SelectConfinedSpaceMudsPresenter();
            DialogResultAndOutput<ConfinedSpaceMudsDTO> dialogResultAndOutput = presenter.Run(view);

            if (dialogResultAndOutput.Result == DialogResult.OK &&
                dialogResultAndOutput.Output != null &&
                view.RemplirLeFormulaireDeCondition.VisibleState == VisibleState.Visible)
            {
                view.RemplirLeFormulaireDeCondition = CreateVisibleFromEditObject(
                    view.SelectedPermitTemplate.RemplirLeFormulaireDeCondition,
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
            WorkPermitMudsValidator validator = new WorkPermitMudsValidator(view);
            validator.ValidateUserFormAndSetErrors(view);
            bool hasError1=!ValidateGasTest();

            if (validator.warning && !validator.HasErrors)
            {
                DialogResult result = OltMessageBox.Show(Form.ActiveForm, "Avertissement Texte manquant voulez-vous sauvegarder?" ,
                   "Alerte", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }

            return validator.HasErrors || hasError1;
        }

        private void UpdateEditObjectFromView()
        {
            long? id = IsEdit ? editObject.Id : null;

            WorkPermitMudsTemplate workPermitMudsTemplate = view.SelectedPermitTemplate;

            User editUser = userContext.User;
            DateTime now = Clock.Now;
           
            if (IsEdit)
            {
                PermitRequestBasedWorkPermitStatus status = editObject.WorkPermitStatus;
                if (status == PermitRequestBasedWorkPermitStatus.Requested)
                {
                    status = PermitRequestBasedWorkPermitStatus.Pending;
                }
                if (status == PermitRequestBasedWorkPermitStatus.Signed)
                {
                    status = PermitRequestBasedWorkPermitStatus.Pending;
                }

                editObject = new WorkPermitMuds(editObject.IdValue, editObject.PermitNumber,
                                                    editObject.DataSource, status, view.SelectedPermitType,
                                                    workPermitMudsTemplate, view.StartDateTime, view.EndDateTime,
                                                    view.FunctionalLocations, editObject.WorkOrderNumber,
                                                    view.SelectedTrade,
                                                    view.Description, editObject.CreatedDateTime, editObject.CreatedBy, now, editUser, view.SelectedRequestedByGroup, editObject.IssuedDateTime,
                                                    view.SelectedRequestedByGroupText,
                                                    view.NbTravail, view.FormationCheck, view.NomsEnt, view.NomsEnt_1, view.NomsEnt_2, view.NomsEnt_3, view.Surveilant); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            }
            else
            {
                editObject = new WorkPermitMuds(DataSource.MANUAL, PermitRequestBasedWorkPermitStatus.Pending, view.SelectedPermitType,
                                                    workPermitMudsTemplate,
                                                    view.StartDateTime, view.EndDateTime, view.FunctionalLocations, view.WorkOrderNumber,
                                                    view.SelectedTrade,
                                                    view.Description, now, editUser, now, editUser, view.SelectedRequestedByGroup, null
                                                    , view.SelectedRequestedByGroupText,
                                                    view.NbTravail, view.FormationCheck, view.NomsEnt, view.NomsEnt_1, view.NomsEnt_2, view.NomsEnt_3, view.Surveilant); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            }

            editObject.Id = id;
            editObject.Company = view.Company;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            editObject.Company_1 = view.Company_1;
            editObject.Company_2 = view.Company_2;
            editObject.RemplirLeFormulaireDeCondition = view.RemplirLeFormulaireDeCondition.Value;
            editObject.AnalyseCritiqueDeLaTache = view.AnalyseCritiqueDeLaTache.Value;
            editObject.Depressurises = view.Depressurises.Value;
            editObject.Vides = view.Vides.Value;
            editObject.ContournementDesGda = view.ContournementDesGda.Value;
            editObject.Rinces = view.Rinces.Value;
            editObject.ClonedFormDetailMuds = view.ClonedFormDetailMuds; // Added by Vibhor : DMND0011077 - Work Permit Clone History
            editObject.NettoyesLaVapeur = view.NettoyesLaVapeur.Value;
            editObject.Purges = view.Purges.Value;
            editObject.Ventiles = view.Ventiles.Value;
            editObject.Aeres = view.Aeres.Value;
            editObject.Energies = view.Energies.Value; // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            
            editObject.ProcedureEntretien = view.ProcedureEntretien.Value;
            editObject.AutresConditions = view.AutresConditions.Value;
            editObject.InterrupteursEtVannesCadenasses = view.InterrupteursEtVannesCadenasses.Value;
            editObject.VerrouillagesParTravailleurs = view.VerrouillagesParTravailleurs.Value;
            editObject.SourcesDesenergisees = view.SourcesDesenergisees.Value;
            editObject.DepartsLocauxTestes = view.DepartsLocauxTestes.Value;
            editObject.ConduitesDesaccouplees = view.ConduitesDesaccouplees.Value;
            editObject.ObturateursInstallees = view.ObturateursInstallees.Value;
            editObject.EtiquettObturateur = view.EtiquettObturateur.Value;
            editObject.PvciSuncorEffectuee = view.PvciSuncorEffectuee.Value;
            editObject.PvciEntExtEffectuee = view.PvciEntExtEffectuee.Value;
            editObject.Amiante = view.Amiante.Value;
            editObject.AcideSulfurique = view.AcideSulfurique.Value;
            editObject.Azote = view.Azote.Value;
            editObject.Caustique = view.Caustique.Value;
            editObject.DioxydeDeSoufre = view.DioxydeDeSoufre.Value;
            editObject.Sbs = view.Sbs.Value;
            editObject.Soufre = view.Soufre.Value;
            editObject.EquipementsNonRinces = view.EquipementsNonRinces.Value;
            editObject.Hydrocarbures = view.Hydrocarbures.Value;
            editObject.HydrogeneSulfure = view.HydrogeneSulfure.Value;
            editObject.MonoxydeCarbone = view.MonoxydeCarbone.Value;
            editObject.Reflux = view.Reflux.Value;
            editObject.ProduitsVolatilsUtilises = view.ProduitsVolatilsUtilises.Value;
            editObject.Bacteries = view.Bacteries.Value;
            editObject.Appareil = view.AppareilProtecteurEquipementDeProtection.Value; //veh
            editObject.AppareilEquipementDePrevention = view.AppareilEquipementDePrevention.Value; // resp
            editObject.InterferencesEntreTravaux = view.InterferencesEntreTravaux.Value;
            editObject.PiecesEnRotation = view.PiecesEnRotation.Value;
            editObject.IncendieExplosion = view.IncendieExplosion.Value;
            editObject.ContrainteThermique = view.ContrainteThermique.Value;
            editObject.Radiations = view.Radiations.Value;
            editObject.Silice = view.Silice.Value;
            editObject.Vanadium = view.Vanadium.Value;
            editObject.AsphyxieIntoxication = view.AsphyxieIntoxication.Value;
            editObject.AutresRisques = view.AutresRisques.Value;
            editObject.ElectriciteVolt = view.ElectronicVoltRisques.Value;
            editObject.ElectronicVoltRisques = view.ElectronicVoltRisques.Value;
            //editObject.OutillageElectrique = view.OutillageElectrique.Value;
            editObject.TravailEnHauteur6EtPlus = view.TravailEnHauteur6EtPlus.Value;
            editObject.VapeurCondensat = view.VapeurCondensat.Value; // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            editObject.FeSValue = view.FeSValue.Value;
            

            editObject.AnalyseCritiqueDeLaTache = view.AnalyseCritiqueDeLaTache.Value; // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            editObject.ProcedureEntretien = view.ProcedureEntretien.Value; // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            
            editObject.Electrisation = view.Electrisation.Value;
            editObject.LunettesMonocoques = view.LunettesMonocoques.Value;
            editObject.Visiere = view.Visiere.Value;
            editObject.ProtectionAuditive = view.ProtectionAuditive.Value;
            editObject.CagouleIgnifuge = view.CagouleIgnifuge.Value;
            editObject.Harnais2LiensDeRetenue = view.Harnais2LiensDeRetenue.Value;
            editObject.Gants = view.GantsEquipementDeProtection.Value;
            editObject.GantsEquipementDeProtection = view.GantsEquipementDeProtection.Value;
            //editObject.MasqueACartouches = view.MasqueACartouches.Value;
            //editObject.MasqueACartouchesValue = view.MasqueACartouchesValue.Value;
            editObject.EpiAntiArcCat = view.EpiAntiArcCatProtecteurEquipementDeProtection.Value;
            editObject.EpiAntiArcCatProtecteurEquipementDeProtection = view.EpiAntiArcCatProtecteurEquipementDeProtection.Value;
            editObject.EpiAntiChoc = view.EpiAntiChoc.Value;
            editObject.HabitProtecteurEquipementDeProtection = view.HabitProtecteurEquipementDeProtection.Value;
            editObject.EcranDeflecteur = view.EcranDeflecteur.Value;
            editObject.MaltDesEquipements = view.MaltDesEquipements.Value;
            editObject.Rallonges = view.Rallonges.Value;
            editObject.ApprobationPourEquipDeLevage = view.ApprobationPourEquipDeLevage.Value;
            editObject.BarricadeRigide = view.BarricadeRigide.Value;
            editObject.AutresE = view.AutresEquipementDePrevention.Value;
            editObject.AutresEquipementDePrevention = view.AutresEquipementDePrevention.Value;
            editObject.AlarmeDcs = view.AlarmeDcs.Value;
            editObject.EchelleSecurisee = view.EchelleSecurisee.Value;
            editObject.EchafaudageApprouve = view.EchafaudageApprouve.Value;

            editObject.OutilDeLaitonPrevention = view.OutilDeLaitonPrevention.Value;

            editObject.OutilDeLaiton = view.OutilDeLaiton.Value;
            editObject.OutilManuelEquipementDePrevention = view.OutilManuelEquipementDePrevention.Value;
            editObject.PerimetreDeSecurityEquipementDePrevention = view.PerimetreDeSecurityEquipementDePrevention.Value;
            editObject.Radio = view.Radio.Value;
            editObject.EffondrementEnsevelissement = view.EffondrementEnsevelissement.Value;
            editObject.Signaleur = view.Signaleur.Value;
            editObject.InstructionsSpeciales = view.InstructionsSpeciales;

// Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

            editObject.MudsAnswerTextBox = view.MudsAnswerTextBox;
            editObject.MudsQuestionlabel = view.MudsQuestionlabel;

            editObject.SignatureOperateurSurLeTerrain = view.SignatureOperateurSurLeTerrain.Value;
            editObject.DetectionDesGazs = view.DetectionDesGazs.Value;
            editObject.SignatureContremaitre = view.SignatureContremaitre.Value;
            editObject.SignatureAutorise = view.SignatureAutorise.Value;
            editObject.NettoyageTransfertHorsSite = view.NettoyageTransfertHorsSite.Value;
            editObject.Soudage = view.Soudage.Value;
            editObject.Traitement = view.Traitement.Value;
            editObject.Cuissons = view.Cuissons.Value;
            editObject.Per�age = view.Per�age.Value;
            editObject.Chaufferette = view.Chaufferette.Value;
            editObject.Meulage = view.Meulage.Value;
            editObject.Nettoyage = view.Nettoyage.Value;
            editObject.AutresTravaux = view.AutresTravaux.Value;
            editObject.TravauxDansZone = view.TravauxDansZone.Value;
            editObject.Combustibles = view.Combustibles.Value;
            editObject.Ecran = view.Ecran.Value;
            editObject.Boyau = view.Boyau.Value;
            editObject.BoyauDe = view.BoyauDe.Value;
            editObject.Couverture = view.Couverture.Value;
            editObject.Extincteur = view.Extincteur.Value;
            editObject.Bouche = view.Bouche.Value;
            editObject.RadioS = view.RadioS.Value;
            editObject.Surveillant = view.Surveillant.Value;
            editObject.UtilisationMoteur = view.UtilisationMoteur.Value;
            editObject.NettoyageAu = view.NettoyageAu.Value;
            editObject.UtilisationElectronics = view.UtilisationElectronics.Value;
            editObject.Radiographie = view.Radiographie.Value;
            editObject.UtilisationOutlis = view.UtilisationOutlis.Value;
            //editObject.UtilisationEquipments = view.UtilisationEquipments.Value;
            editObject.Demolition = view.Demolition.Value;
            editObject.AutresInstruction = view.AutresInstruction.Value;
            
            editObject.MasqueSoudeur = view.MasqueSoudeur.Value;
            editObject.DocumentLinks = view.DocumentLinks;
            editObject.PerimetreDeSecurityEquipementDePrevention = view.PerimetreDeSecurityEquipementDePrevention.Value;
            editObject.GasTests = new WorkPermitGasTests();
            //editObject.GasTests.GasTestFirstResultTime=view.tab

            if (editObject.WorkPermitType == WorkPermitMudsType.ELEVATED_HOT)
            {
                SaveWorkItemGasTests(editObject.GasTests);
            }
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

        private void UpdateViewFromTemplate(WorkPermitMudsTemplate template)
        {
            WithTheSavingAndReplacingOfDessinsRequis(template, delegate
                                                                   {
                                                                       new WorkPermitMudsTemplateViewMapper(view, template).MapTemplateToView();
                                                                   });
        }
        

        // Sometimes the dessins requis value comes from the excavation number in the permit request, so as the user flips through templates (some
        // of which don't have this field) we want to maintain the value in the textbox.
        private void WithTheSavingAndReplacingOfDessinsRequis(WorkPermitMudsTemplate template, Action action)
        {
            FromPermitRequest();

            action();

            MergePermitRequest(template);
            //selectedPermitType == WorkPermitMudsType.NULL

        }

        private void FromPermitRequest()
        {
            //if (IsEdit && view.DessinsRequis.Value.HasValue)
            //{
            //    savedDessinsRequisValue = view.DessinsRequis.Value;
            //}

            if (IsEdit && view.InterrupteursEtVannesCadenasses.Value.StateAsBool)
            {
                interrupteursEtVannesCadenasses = view.InterrupteursEtVannesCadenasses.Value;
            }

            if (IsEdit && view.AnalyseCritiqueDeLaTache.Value) // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            {
                analyseCritiqueDeLaTache = view.AnalyseCritiqueDeLaTache;
            }
            if (IsEdit && view.ProcedureEntretien.Value.StateAsBool) // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            {
                procedureEntretien = view.ProcedureEntretien.Value;
            }


            if (IsEdit && view.RemplirLeFormulaireDeCondition.Value.StateAsBool)
            {
                remplirLeFormulaireDeCondition = view.RemplirLeFormulaireDeCondition.Value;
            }
            if (IsEdit && view.TravailEnHauteur6EtPlus.Value)
            {
                travailEnHauteur6EtPlus = view.TravailEnHauteur6EtPlus;
            }
            if (IsEdit && view.VapeurCondensat.Value) // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            {
                vapeurCondensat = view.VapeurCondensat;
            }

            if (IsEdit && view.FeSValue.Value) // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            {
                feSValue = view.FeSValue;
            }
            

            if (IsEdit && view.EchafaudageApprouve.Value)
            {
                echafaudageApprouve = view.EchafaudageApprouve;
            }

            if (IsEdit && view.OutilDeLaitonPrevention.Value)
            {
                outilDeLaitonPrevention = view.OutilDeLaitonPrevention;
            }

            if (IsEdit && view.EchelleSecurisee.Value)
            {
                echelleSecurisee = view.EchelleSecurisee;
            }
            if (IsEdit && view.Harnais2LiensDeRetenue.Value)
            {
                harnais2LiensDeRetenue = view.Harnais2LiensDeRetenue;
            }
            if (IsEdit && view.Radio.Value)
            {
                radio = view.Radio;
            }
            if (IsEdit && view.Signaleur.Value)
            {
                signaleur = view.Signaleur;
            }
            if (IsEdit && view.PerimetreDeSecurityEquipementDePrevention.Value.StateAsBool)
            {
                perimetreSecurite = view.PerimetreDeSecurityEquipementDePrevention.Value;
            }
            if (IsEdit && view.AppareilProtecteurEquipementDeProtection.Value.StateAsBool) //To check for Appareil/V�hicule � combustion: Nacelle
            {
                appareil = view.AppareilProtecteurEquipementDeProtection.Value;
            }
            if (IsEdit && view.BarricadeRigide.Value)
            {
                barricadeRigide = view.BarricadeRigide;
            }
            if (IsEdit && view.UtilisationMoteur.Value)
            {
                utilisationMoteur = view.UtilisationMoteur;
            }
            if (IsEdit && view.AlarmeDcs.Value.StateAsBool)
            {
                alarmeDcs = view.AlarmeDcs.Value;
            }
            if (IsEdit && view.ApprobationPourEquipDeLevage.Value)
            {
                approbationPourEquipDeLevage = view.ApprobationPourEquipDeLevage;
            }
            if (IsEdit && view.LunettesMonocoques.Value)
            {
                lunettesMonocoques = view.LunettesMonocoques;
            }
            if (IsEdit && view.Sbs.Value)
            {
                sbs = view.Sbs;
            }
            if (IsEdit && view.ElectronicVoltRisques.Value.StateAsBool)
            {
                electriciteVolt = view.ElectronicVoltRisques.Value;
            }
            if (IsEdit && view.Electrisation.Value)
            {
                electrisation = view.Electrisation;
            }
            if (IsEdit && view.NettoyageAu.Value)
            {
                nettoyageAu = view.NettoyageAu;
            }
            if (IsEdit && view.UtilisationElectronics.Value)
            {
                utilisationElectronics = view.UtilisationElectronics;
            }
            if (IsEdit && view.OutilManuelEquipementDePrevention.Value.StateAsBool) // To chk for Outillage �lectrique/ � batterie
            {
                outillageElectrique = view.OutilManuelEquipementDePrevention.Value;
            }
            if (IsEdit && view.Radiographie.Value)
            {
                radiographie = view.Radiographie;
            }
            if (IsEdit && view.Radiations.Value)
            {
                radiations = view.Radiations;
            }
            if (IsEdit && view.UtilisationOutlis.Value)
            {
                utilisationOutlis = view.UtilisationOutlis;
            }
            //if (IsEdit && view.UtilisationEquipments.Value)
            //{
            //    utilisationEquipments = view.UtilisationEquipments;
            //}
            if (IsEdit && view.Soudage.Value)
            {
                soudage = view.Soudage;
            }
            if (IsEdit && view.IncendieExplosion.Value)
            {
                incendieExplosion = view.IncendieExplosion;
            }
            if (IsEdit && view.Visiere.Value)
            {
                visiere = view.Visiere;
            }

            //to make default value = true;
            //if (IsEdit && view.ProtectionAuditive.Value)
            //{
            //    protectionAuditive = view.ProtectionAuditive;
            //}

            
            protectionAuditive = new Visible<bool>(VisibleState.Visible, true); ;

            if (IsEdit && view.Traitement.Value)
            {
                traitement = view.Traitement;
            }
            if (IsEdit && view.Cuissons.Value)
            {
                cuissons = view.Cuissons;
            }
            if (IsEdit && view.Per�age.Value)
            {
                per�age = view.Per�age;
            }
            if (IsEdit && view.Chaufferette.Value)
            {
                chaufferette = view.Chaufferette;
            }
            if (IsEdit && view.Nettoyage.Value)
            {
                nettoyage = view.Nettoyage;
            }
            if (IsEdit && view.TravauxDansZone.Value)
            {
                travauxDansZone = view.TravauxDansZone;
            }

            if (IsEdit && view.VerrouillagesParTravailleurs.Value)
            {
                verrouillagesParTravailleurs = view.VerrouillagesParTravailleurs;
            }
        }

        private void MergePermitRequest(WorkPermitMudsTemplate template)
        {
            if (interrupteursEtVannesCadenasses.StateAsBool)
            {
                view.InterrupteursEtVannesCadenasses = CreateVisibleFromEditObject(template.InterrupteursEtVannesCadenasses, interrupteursEtVannesCadenasses);
            }
            if (remplirLeFormulaireDeCondition.StateAsBool)
            {
                view.RemplirLeFormulaireDeCondition = CreateVisibleFromEditObject(template.RemplirLeFormulaireDeCondition, remplirLeFormulaireDeCondition);
            }
            if (travailEnHauteur6EtPlus.Value) // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            {
                view.TravailEnHauteur6EtPlus = CreateVisibleFromEditObject(template.TravailEnHauteur6EtPlus, travailEnHauteur6EtPlus.Value);
            }

            if (analyseCritiqueDeLaTache.Value) // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            {
                view.AnalyseCritiqueDeLaTache = CreateVisibleFromEditObject(template.AnalyseCritiqueDeLaTache, analyseCritiqueDeLaTache.Value);
            }

            if (procedureEntretien.StateAsBool)
            {
                view.ProcedureEntretien = CreateVisibleFromEditObject(template.ProcedureEntretien, procedureEntretien);
            }

            if (vapeurCondensat.Value)  // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            {
                view.VapeurCondensat = CreateVisibleFromEditObject(template.VapeurCondensat, vapeurCondensat.Value);
            }

            if (feSValue.Value)  
            {
                view.FeSValue = CreateVisibleFromEditObject(template.FeSValue, feSValue.Value);
            }

            if (echafaudageApprouve.Value)
            {
                view.EchafaudageApprouve = CreateVisibleFromEditObject(template.EchafaudageApprouve, echafaudageApprouve.Value);
            }

            if (echafaudageApprouve.Value)
            {
                view.OutilDeLaitonPrevention = CreateVisibleFromEditObject(template.OutilDeLaitonPrevention, outilDeLaitonPrevention.Value);
            }


            if (echelleSecurisee.Value)
            {
                view.EchelleSecurisee = CreateVisibleFromEditObject(template.EchelleSecurisee, echelleSecurisee.Value);
            }
            if (harnais2LiensDeRetenue.Value)
            {
                view.Harnais2LiensDeRetenue = CreateVisibleFromEditObject(template.Harnais2LiensDeRetenue, harnais2LiensDeRetenue.Value);
            }
            if (radio.Value)
            {
                view.Radio = CreateVisibleFromEditObject(template.Radio, radio.Value);
            }
            if (signaleur.Value)
            {
                view.Signaleur = CreateVisibleFromEditObject(template.Signaleur, signaleur.Value);
            }
            if (perimetreSecurite.StateAsBool)
            {
                view.PerimetreDeSecurityEquipementDePrevention = CreateVisibleFromEditObject(template.PerimetreDeSecurityEquipementDePrevention, perimetreSecurite);
            }
            if (appareil.StateAsBool) //TO check
            {
                view.AppareilProtecteurEquipementDeProtection = CreateVisibleFromEditObject(template.AppareilEquipementDePrevention, appareil);

                
            }
            if (barricadeRigide.Value)
            {
                view.BarricadeRigide = CreateVisibleFromEditObject(template.BarricadeRigide, barricadeRigide.Value);
            }
            if (utilisationMoteur.Value)
            {
                view.UtilisationMoteur = CreateVisibleFromEditObject(template.UtilisationMoteur, utilisationMoteur.Value);
            }
            if (alarmeDcs.StateAsBool)
            {
                view.AlarmeDcs = CreateVisibleFromEditObject(template.AlarmeDcs, alarmeDcs);
            }
            if (approbationPourEquipDeLevage.Value)
            {
                view.ApprobationPourEquipDeLevage = CreateVisibleFromEditObject(template.ApprobationPourEquipDeLevage, approbationPourEquipDeLevage.Value);
            }
            if (lunettesMonocoques.Value)
            {
                view.LunettesMonocoques = CreateVisibleFromEditObject(template.LunettesMonocoques, lunettesMonocoques.Value);
            }
            if (sbs.Value)
            {
                view.Sbs = CreateVisibleFromEditObject(template.Sbs, sbs.Value);
            }
            if (electriciteVolt.StateAsBool)
            {
                view.ElectronicVoltRisques = CreateVisibleFromEditObject(template.ElectronicVoltRisques, electriciteVolt);
            }
            if (electrisation.Value)
            {
                view.Electrisation = CreateVisibleFromEditObject(template.Electrisation, electrisation.Value);
            }
            if (nettoyageAu.Value)
            {
                view.NettoyageAu = CreateVisibleFromEditObject(template.NettoyageAu, nettoyageAu.Value);
            }
            if (utilisationElectronics.Value)
            {
                view.UtilisationElectronics = CreateVisibleFromEditObject(template.UtilisationElectronics, utilisationElectronics.Value);
            }
            if (outillageElectrique.StateAsBool) //To check
            {
                view.OutilManuelEquipementDePrevention = CreateVisibleFromEditObject(template.OutilManuelEquipementDePrevention, outillageElectrique);
            }
            if (radiographie.Value)
            {
                view.Radiographie = CreateVisibleFromEditObject(template.Radiographie, radiographie.Value);
            }
            if (radiations.Value)
            {
                view.Radiations = CreateVisibleFromEditObject(template.Radiations, radiations.Value);
            }
            if (utilisationOutlis.Value)
            {
                view.UtilisationOutlis = CreateVisibleFromEditObject(template.UtilisationOutlis, utilisationOutlis.Value);
            }
            //if (utilisationEquipments.Value)
            //{
            //    view.UtilisationEquipments = CreateVisibleFromEditObject(template.UtilisationEquipments, utilisationEquipments.Value);
            //}
            if (soudage.Value)
            {
                view.Soudage = CreateVisibleFromEditObject(template.Soudage, soudage.Value);
            }
            if (incendieExplosion.Value)
            {
                view.IncendieExplosion = CreateVisibleFromEditObject(template.IncendieExplosion, incendieExplosion.Value);
            }
            if (visiere.Value)
            {
                view.Visiere = CreateVisibleFromEditObject(template.Visiere, visiere.Value);
            }
            if (protectionAuditive.Value)
            {
                //view.ProtectionAuditive = CreateVisibleFromEditObject(template.ProtectionAuditive, protectionAuditive.Value);
                view.ProtectionAuditive = new Visible<bool>(VisibleState.Visible, true); ;
            }
            if (traitement.Value)
            {
                view.Traitement = CreateVisibleFromEditObject(template.Traitement, traitement.Value);
            }
            if (cuissons.Value)
            {
                view.Cuissons = CreateVisibleFromEditObject(template.Cuissons, cuissons.Value);
            }
            if (per�age.Value)
            {
                view.Per�age = CreateVisibleFromEditObject(template.Per�age, per�age.Value);
            }
            if (chaufferette.Value)
            {
                view.Chaufferette = CreateVisibleFromEditObject(template.Chaufferette, chaufferette.Value);
            }
            if (nettoyage.Value)
            {
                view.Nettoyage = CreateVisibleFromEditObject(template.Nettoyage, nettoyage.Value);
            }
            if (travauxDansZone.Value)
            {
                view.TravauxDansZone = CreateVisibleFromEditObject(template.TravauxDansZone, travauxDansZone.Value);
            }
            if (verrouillagesParTravailleurs.Value)
            {
                view.VerrouillagesParTravailleurs = CreateVisibleFromEditObject(template.VerrouillagesParTravailleurs, verrouillagesParTravailleurs.Value);
            }
            
        }

        private void WithTheSavingAndReplacingOfDessinsRequis(List<WorkPermitMudsTemplate> template, Action action)
        {
            action();
        }

        private Visible<bool> CreateVisibleFromEditObject(TemplateStateMuds state, bool value)
        {
            if (TemplateStateMuds.Invisible == state)
            {
                return new Visible<bool>(VisibleState.Invisible, false);
            }
            return new Visible<bool>(VisibleState.Visible, value);
        }

        private Visible<TernaryString> CreateVisibleFromEditObject(TemplateStateMuds state, TernaryString value)
        {
            if (state == TemplateStateMuds.Invisible)
            {
                return new Visible<TernaryString>(VisibleState.Invisible, new TernaryString(false, null));
            }
            return new Visible<TernaryString>(VisibleState.Visible, value);
        }

        private void UpdateViewFromEditObject()
        {
            WorkPermitMudsTemplate template = editObject.Template;
            view.ClonedFormDetailMuds = editObject.ClonedFormDetailMuds; // Added by Vibhor : DMND0011077 - Work Permit Clone History
            view.SelectedPermitType = editObject.WorkPermitType;
            view.SelectedPermitTemplate = editObject.Template;
            view.FunctionalLocations = editObject.FunctionalLocations ?? new List<FunctionalLocation>();
            view.SelectedTrade = editObject.Trade;
            view.Description = editObject.Description;
            view.StartDateTime = editObject.StartDateTime;
            view.EndDateTime = editObject.EndDateTime;
            view.WorkOrderNumber = editObject.WorkOrderNumber;
            view.SelectedRequestedByGroup = editObject.RequestedByGroup;

            view.NbTravail = editObject.NbTravail;
            view.FormationCheck = editObject.FormationCheck;
            view.NomsEnt = editObject.NomsEnt;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            view.NomsEnt_1 = editObject.NomsEnt_1;
            view.NomsEnt_2 = editObject.NomsEnt_2;
            view.NomsEnt_3 = editObject.NomsEnt_3;

            view.Surveilant = editObject.Surveilant;
            

            view.SelectedRequestedByGroupText = editObject.RequestedByGroupText;


            view.Company = editObject.Company;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            view.Company_1 = editObject.Company_1;
            view.Company_2 = editObject.Company_2;

            if (editObject.PermitNumber.HasValue)
            {
                view.ReferenceNumber = editObject.PermitNumber.Value.ToString();
            }

            #region start of update

            view.RemplirLeFormulaireDeCondition = CreateVisibleFromEditObject(template.RemplirLeFormulaireDeCondition, editObject.RemplirLeFormulaireDeCondition);
            view.AnalyseCritiqueDeLaTache = CreateVisibleFromEditObject(template.AnalyseCritiqueDeLaTache, editObject.AnalyseCritiqueDeLaTache);
            view.Depressurises = CreateVisibleFromEditObject(template.Depressurises, editObject.Depressurises);
            view.Vides = CreateVisibleFromEditObject(template.Vides, editObject.Vides);
            view.ContournementDesGda = CreateVisibleFromEditObject(template.ContournementDesGda, editObject.ContournementDesGda);
            view.Rinces = CreateVisibleFromEditObject(template.Rinces, editObject.Rinces);
            view.NettoyesLaVapeur = CreateVisibleFromEditObject(template.NettoyesLaVapeur, editObject.NettoyesLaVapeur);
            view.Purges = CreateVisibleFromEditObject(template.Purges, editObject.Purges);
            view.Ventiles = CreateVisibleFromEditObject(template.Ventiles, editObject.Ventiles);
            view.Aeres = CreateVisibleFromEditObject(template.Aeres, editObject.Aeres);
            view.Energies = CreateVisibleFromEditObject(template.Energies, editObject.Energies);
            
            //view.ProcedureEntretien = CreateVisibleFromEditObject(template.ProcedureEntretien, editObject.ProcedureEntretien);
            view.ProcedureEntretien = CreateVisibleFromEditObject(template.ProcedureEntretien, editObject.Procedure);
            view.AutresConditions = CreateVisibleFromEditObject(template.AutresConditions, editObject.AutresCondition);
            view.InterrupteursEtVannesCadenasses = CreateVisibleFromEditObject(template.InterrupteursEtVannesCadenasses, editObject.InterrupteursEtVannesCadenasses);
            view.VerrouillagesParTravailleurs = CreateVisibleFromEditObject(template.VerrouillagesParTravailleurs, editObject.VerrouillagesParTravailleurs);
            view.SourcesDesenergisees = CreateVisibleFromEditObject(template.SourcesDesenergisees, editObject.SourcesDesenergisees);
            view.DepartsLocauxTestes = CreateVisibleFromEditObject(template.DepartsLocauxTestes, editObject.DepartsLocauxTestes);
            view.ConduitesDesaccouplees = CreateVisibleFromEditObject(template.ConduitesDesaccouplees, editObject.ConduitesDesaccouplees);
            view.ObturateursInstallees = CreateVisibleFromEditObject(template.ObturateursInstallees, editObject.ObturateursInstallees);
            view.EtiquettObturateur = CreateVisibleFromEditObject(template.EtiquettObturateur, editObject.Etiquette);
            view.PvciSuncorEffectuee = CreateVisibleFromEditObject(template.PvciSuncorEffectuee, editObject.PvciSuncorEffectuee);
            view.PvciEntExtEffectuee = CreateVisibleFromEditObject(template.PvciEntExtEffectuee, editObject.PvciEntExtEffectuee);
            view.Amiante = CreateVisibleFromEditObject(template.Amiante, editObject.Amiante);
            view.AcideSulfurique = CreateVisibleFromEditObject(template.AcideSulfurique, editObject.AcideSulfurique);
            view.Azote = CreateVisibleFromEditObject(template.Azote, editObject.Azote);
            view.Caustique = CreateVisibleFromEditObject(template.Caustique, editObject.Caustique);
            view.DioxydeDeSoufre = CreateVisibleFromEditObject(template.DioxydeDeSoufre, editObject.DioxydeDeSoufre);
            view.Sbs = CreateVisibleFromEditObject(template.Sbs, editObject.Sbs);
            view.Soufre = CreateVisibleFromEditObject(template.Soufre, editObject.Soufre);
            view.EquipementsNonRinces = CreateVisibleFromEditObject(template.EquipementsNonRinces, editObject.EquipementsNonRinces);
            view.Hydrocarbures = CreateVisibleFromEditObject(template.Hydrocarbures, editObject.Hydrocarbures);
            view.HydrogeneSulfure = CreateVisibleFromEditObject(template.HydrogeneSulfure, editObject.HydrogeneSulfure);
            view.MonoxydeCarbone = CreateVisibleFromEditObject(template.MonoxydeCarbone, editObject.MonoxydeCarbone);
            view.Reflux = CreateVisibleFromEditObject(template.Reflux, editObject.Reflux);
            view.ProduitsVolatilsUtilises = CreateVisibleFromEditObject(template.ProduitsVolatilsUtilises, editObject.ProduitsVolatilsUtilises);
            view.Bacteries = CreateVisibleFromEditObject(template.Bacteries, editObject.Bacteries);
            view.AppareilEquipementDePrevention = CreateVisibleFromEditObject(template.MasqueACartouches, editObject.MasqueACartouches);
            view.InterferencesEntreTravaux = CreateVisibleFromEditObject(template.InterferencesEntreTravaux, editObject.InterferencesEntreTravaux);
            view.PiecesEnRotation = CreateVisibleFromEditObject(template.PiecesEnRotation, editObject.PiecesEnRotation);
            view.IncendieExplosion = CreateVisibleFromEditObject(template.IncendieExplosion, editObject.IncendieExplosion);
            view.ContrainteThermique = CreateVisibleFromEditObject(template.ContrainteThermique, editObject.ContrainteThermique);
            view.Radiations = CreateVisibleFromEditObject(template.Radiations, editObject.Radiations);
            view.Silice = CreateVisibleFromEditObject(template.Silice, editObject.Silice);
            view.Vanadium = CreateVisibleFromEditObject(template.Vanadium, editObject.Vanadium);
            view.AsphyxieIntoxication = CreateVisibleFromEditObject(template.AsphyxieIntoxication, editObject.AsphyxieIntoxication);
            view.AutresRisques = CreateVisibleFromEditObject(template.AutresRisques, editObject.AutresRisques);
            view.ElectronicVoltRisques = CreateVisibleFromEditObject(template.ElectriciteVolt, editObject.ElectriciteVolt);
           // view.OutilManuelEquipementDePrevention = CreateVisibleFromEditObject(template.OutilManuelEquipementDePrevention, editObject.OutilManuelEquipementDePrevention);
            view.TravailEnHauteur6EtPlus = CreateVisibleFromEditObject(template.TravailEnHauteur6EtPlus, editObject.TravailEnHauteur6EtPlus);

            view.AnalyseCritiqueDeLaTache = CreateVisibleFromEditObject(template.AnalyseCritiqueDeLaTache, editObject.AnalyseCritiqueDeLaTache); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            view.ProcedureEntretien = CreateVisibleFromEditObject(template.ProcedureEntretien, editObject.ProcedureEntretien);// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            view.VapeurCondensat = CreateVisibleFromEditObject(template.VapeurCondensat, editObject.VapeurCondensat); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            view.FeSValue = CreateVisibleFromEditObject(template.FeSValue, editObject.FeSValue);
            
            
            view.Electrisation = CreateVisibleFromEditObject(template.Electrisation, editObject.Electrisation);
            view.LunettesMonocoques = CreateVisibleFromEditObject(template.LunettesMonocoques, editObject.LunettesMonocoques);
            view.Visiere = CreateVisibleFromEditObject(template.Visiere, editObject.Visiere);
            view.ProtectionAuditive = CreateVisibleFromEditObject(template.ProtectionAuditive, editObject.ProtectionAuditive);
            view.CagouleIgnifuge = CreateVisibleFromEditObject(template.CagouleIgnifuge, editObject.CagouleIgnifuge);
            view.Harnais2LiensDeRetenue = CreateVisibleFromEditObject(template.Harnais2LiensDeRetenue, editObject.Harnais2LiensDeRetenue);
            view.GantsEquipementDeProtection = CreateVisibleFromEditObject(template.GantsEquipementDeProtection, editObject.Gants);
            //view.Mas = CreateVisibleFromEditObject(template.MasqueACartouches, editObject.MasqueACartouches);
            //view.MasqueACartouchesValue = CreateVisibleFromEditObject(template.MasqueACartouchesValue, editObject.MasqueACartouchesValue);
            view.EpiAntiArcCatProtecteurEquipementDeProtection = CreateVisibleFromEditObject(template.EpiAntiArcCatProtecteurEquipementDeProtection, editObject.EpiAntiArcCat);
            view.EpiAntiChoc = CreateVisibleFromEditObject(template.EpiAntiChoc, editObject.EpiAntiChoc);
            view.HabitProtecteurEquipementDeProtection = CreateVisibleFromEditObject(template.HabitProtecteurEquipementDeProtection, editObject.HabitProtecteur);
            view.EcranDeflecteur = CreateVisibleFromEditObject(template.EcranDeflecteur, editObject.EcranDeflecteur);
            view.MaltDesEquipements = CreateVisibleFromEditObject(template.MaltDesEquipements, editObject.MaltDesEquipements);
            view.Rallonges = CreateVisibleFromEditObject(template.Rallonges, editObject.Rallonges);
            view.ApprobationPourEquipDeLevage = CreateVisibleFromEditObject(template.ApprobationPourEquipDeLevage, editObject.ApprobationPourEquipDeLevage);
            view.BarricadeRigide = CreateVisibleFromEditObject(template.BarricadeRigide, editObject.BarricadeRigide);
            view.AutresEquipementDePrevention = CreateVisibleFromEditObject(template.AutresEquipementDePrevention, editObject.AutresE);
            view.AlarmeDcs = CreateVisibleFromEditObject(template.AlarmeDcs, editObject.AlarmeDcs);
            view.EchelleSecurisee = CreateVisibleFromEditObject(template.EchelleSecurisee, editObject.EchelleSecurisee);
            view.EchafaudageApprouve = CreateVisibleFromEditObject(template.EchafaudageApprouve, editObject.EchafaudageApprouve);

            view.OutilDeLaitonPrevention = CreateVisibleFromEditObject(template.OutilDeLaitonPrevention, editObject.OutilDeLaitonPrevention);

            view.UtilisationElectronics = CreateVisibleFromEditObject(template.UtilisationElectronics, editObject.UtilisationElectronics);
            _utilisationElectronics = view.UtilisationElectronics.Value;

            
            view.OutilDeLaiton = CreateVisibleFromEditObject(template.OutilDeLaiton, editObject.OutilDeLaiton);
            view.OutilManuelEquipementDePrevention = CreateVisibleFromEditObject(template.OutilManuelEquipementDePrevention, editObject.OutilManuelEquipementDePrevention);
            view.PerimetreDeSecurityEquipementDePrevention = CreateVisibleFromEditObject(template.PerimetreDeSecurityEquipementDePrevention, editObject.PerimetreDeSecurityEquipementDePrevention);
            
            view.Radio = CreateVisibleFromEditObject(template.Radio, editObject.Radio);
            view.EffondrementEnsevelissement = CreateVisibleFromEditObject(template.EffondrementEnsevelissement, editObject.EffondrementEnsevelissement);
            view.Signaleur = CreateVisibleFromEditObject(template.Signaleur, editObject.Signaleur);
            view.InstructionsSpeciales = editObject.InstructionsSpeciales;

// Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

            view.MudsAnswerTextBox = editObject.MudsAnswerTextBox;
            view.MudsQuestionlabel = editObject.MudsQuestionlabel;

            view.SignatureOperateurSurLeTerrain = CreateVisibleFromEditObject(template.SignatureOperateurSurLeTerrain, editObject.SignatureOperateurSurLeTerrain);
            view.DetectionDesGazs = CreateVisibleFromEditObject(template.DetectionDesGazs, editObject.DetectionDesGazs);
            view.SignatureContremaitre = CreateVisibleFromEditObject(template.SignatureContremaitre, editObject.SignatureContremaitre);
            view.SignatureAutorise = CreateVisibleFromEditObject(template.SignatureAutorise, editObject.SignatureAutorise);
            view.NettoyageTransfertHorsSite = CreateVisibleFromEditObject(template.NettoyageTransfertHorsSite, editObject.NettoyageTransfertHorsSite);
            
            view.Soudage = CreateVisibleFromEditObject(template.Soudage, editObject.Soudage);
            view.Traitement = CreateVisibleFromEditObject(template.Traitement, editObject.Traitement);
            view.Cuissons = CreateVisibleFromEditObject(template.Cuissons, editObject.Cuissons);
            view.Per�age = CreateVisibleFromEditObject(template.Per�age, editObject.Per�age);
            view.Chaufferette = CreateVisibleFromEditObject(template.Chaufferette, editObject.Chaufferette);
            view.Meulage = CreateVisibleFromEditObject(template.Meulage, editObject.Meulage);
            view.Nettoyage = CreateVisibleFromEditObject(template.Nettoyage, editObject.Nettoyage);
            view.AutresTravaux = CreateVisibleFromEditObject(template.AutresTravaux, editObject.AutresTravaux);
            view.TravauxDansZone = CreateVisibleFromEditObject(template.TravauxDansZone, editObject.TravauxDansZone);
            view.Combustibles = CreateVisibleFromEditObject(template.Combustibles, editObject.Combustibles);
            view.Ecran = CreateVisibleFromEditObject(template.Ecran, editObject.Ecran);
            view.Boyau = CreateVisibleFromEditObject(template.Boyau, editObject.Boyau);
            view.BoyauDe = CreateVisibleFromEditObject(template.BoyauDe, editObject.BoyauDe);
            view.Couverture = CreateVisibleFromEditObject(template.Couverture, editObject.Couverture);
            view.Extincteur = CreateVisibleFromEditObject(template.Extincteur, editObject.Extincteur);
            view.Bouche = CreateVisibleFromEditObject(template.Bouche, editObject.Bouche);
            view.RadioS = CreateVisibleFromEditObject(template.RadioS, editObject.RadioS);
            view.Surveillant = CreateVisibleFromEditObject(template.Surveillant, editObject.Surveillant);
            view.UtilisationMoteur = CreateVisibleFromEditObject(template.UtilisationMoteur, editObject.UtilisationMoteur);
            view.NettoyageAu = CreateVisibleFromEditObject(template.NettoyageAu, editObject.NettoyageAu);
           
            //view.UtilisationElectronics = CreateVisibleFromEditObject(template.UtilisationElectronics, editObject.UtilisationElectronics);
            //_utilisationElectronics = view.UtilisationElectronics.Value;

            
            view.Radiographie = CreateVisibleFromEditObject(template.Radiographie, editObject.Radiographie);
            view.UtilisationOutlis = CreateVisibleFromEditObject(template.UtilisationOutlis, editObject.UtilisationOutlis);
            //view.UtilisationEquipments = CreateVisibleFromEditObject(template.UtilisationEquipments, editObject.UtilisationEquipments);
            view.Demolition = CreateVisibleFromEditObject(template.Demolition, editObject.Demolition);
            view.AutresInstruction = CreateVisibleFromEditObject(template.AutresInstruction, editObject.AutresInstruction);

            

            view.AppareilProtecteurEquipementDeProtection = CreateVisibleFromEditObject(template.Appareil, editObject.Appareil);
            view.MasqueSoudeur = CreateVisibleFromEditObject(template.MasqueSoudeur, editObject.MasqueSoudeur);

            view.DocumentLinks = editObject.DocumentLinks;
            #endregion

            view.SetRequestDetails(
                editObject.DataSource == DataSource.PERMIT_REQUEST,
                editObject.RequestedDateTime,
                editObject.RequestedByUser == null ? "" : editObject.RequestedByUser.FullNameWithUserName,
                editObject.Company,
            // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
                editObject.Company_1,
                editObject.Company_2,
                editObject.Supervisor,
                editObject.ExcavationNumber,
                editObject.Attributes);

            if (editObject.WorkPermitType == WorkPermitMudsType.ELEVATED_HOT)
            LoadWorkItemGasTests(editObject);
        }

        private void UpdateViewWithDefaults()
        {
            SetStartAndEndDateTimesInCurrentShift();
            view.DocumentLinks = new List<DocumentLink>();
            view.SetRequestDetails(false, null, null, null,null, null, null, null, new List<PermitAttribute>()); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        }

        private void HandleFormLoad()
        {
            LoadData(new List<Action> { QueryCraftOrTrades, QueryGroups, QueryConfiguredDocumentLinks, QueryDropdownValues, QueryTemplates, QueryShifts, QueryUserHasViewedDocumentLinks, QueryContractors });
        }

        protected override void AfterDataLoad()
        {
            //Added for as test

            view.InitializeStandardGasTestElementInfoList(standardGasTestElementInfoList);



            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.CreateOrEditWorkPermitFormTitle);

            view.Trade = craftOrTrades;
            view.AllCompanies = contractors;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            view.AllCompanies_1 =new List<Contractor>(contractors);
            view.AllCompanies_2 =new List<Contractor>(contractors);
            
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
                if (statusIsRequested) view.DisablePermitType(!statusIsRequested);
            }
            else if (IsClone)
            {
                UpdateTemplateListBasedOnPermitType(editObject.WorkPermitType);
                UpdateViewFromEditObject();

                // Do not clone any Details from the "Detials de le demande" section
                view.SetRequestDetails(false, null, null, null, null, null, null, null, new List<PermitAttribute>());// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

                SetStartAndEndDateTimesInCurrentShift();
            }
            else
            {
                UpdateViewWithDefaults();
            }

            if (!IsClone && !(IsEdit && IsVehicleEntryOrLongDurationPermit))
            {
                //RestoreStartAndEndDateTimeValuesFromSession(); //Commented by Vibhor : INC0545790 - OLT: UDS: Work Permit data issue
            }

            // Save the original start/end times. Later, if these have changed, we'll save them as a user session preference.
            originalStartDateTime = view.StartDateTime;
            originalEndDateTime = view.EndDateTime;

            originalDocumentLinks = new List<DocumentLink>(view.DocumentLinks);

            formLoadComplete = true;

            //HandleSelectedPermitTemplateChange();
        }

        private void QueryShifts()
        {
            IShiftPatternService shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();
            allShifts = shiftPatternService.QueryBySite(userContext.Site);
        }

        private void QueryTemplates()
        {
            List<WorkPermitMudsTemplate> workPermitMudsTemplates = workPermitTemplateService.QueryAllNotDeleted().FindAll(t => t.IsActive);

            // In the case of a Clone or an Edit we may need to show an old Template version if it exists
            HandleOldTemplateVersionsOnEditAndClone(editObject, workPermitMudsTemplates);

            possibleTemplates = workPermitMudsTemplates;
            possibleTemplates.Sort(WorkPermitMudsTemplate.CompareByTemplateNumber);
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
            groups.Insert(0, WorkPermitMudsGroup.EMPTY);
        }

        private void QueryConfiguredDocumentLinks()
        {
            configuredDocumentLinks = configuredDocumentLinkService.GetLinks(ConfiguredDocumentLinkLocation.WorkPermitMuds);
        }

        private void QueryDropdownValues()
        {
            dropdownValues = dropdownValueService.QueryAll(Site.MontrealSulphur_ID);
        }

        private void QueryContractors()
        {
            contractors = contractorService.QueryBySite(userContext.Site);
            contractors.Sort((x, y) => string.Compare(x.CompanyName, y.CompanyName, StringComparison.Ordinal));
            contractors.Insert(0, Contractor.EMPTY);
        }

        private void SetDropdownValues(List<DropdownValue> dropdownValues)
        {
            view.AutresConditionsValues = WorkPermitMudsDropDownValueKeys.AutresConditionsDropdownValues(dropdownValues);
            view.AutresRisquesValues = WorkPermitMudsDropDownValueKeys.AutresRisquesDropdownValues(dropdownValues);
            view.ElectronicVoltRisquesValues = WorkPermitMudsDropDownValueKeys.ElectronicVoltRisquesDropdownValues(dropdownValues);
            view.GantsEquipementDeProtectionValues = WorkPermitMudsDropDownValueKeys.GantsEquipementDeProtectionDropdownValues(dropdownValues);
            view.HabitProtecteurEquipementDeProtectionValues = WorkPermitMudsDropDownValueKeys.HabitProtecteurEquipementDeProtectionDropdownValues(dropdownValues);
            view.EpiAntiArcCatProtecteurEquipementDeProtectionValues = WorkPermitMudsDropDownValueKeys.EpiAntiArcCatProtecteurEquipementDeProtectionDropdownValues(dropdownValues);
            //view.AppareilProtecteurEquipementDeProtectionValues = WorkPermitMudsDropDownValueKeys.AppareilProtecteurEquipementDeProtectionDropdownValues(dropdownValues); //appr vehicle combustion
            view.OutilManuelEquipementDePreventionValues = WorkPermitMudsDropDownValueKeys.OutilManuelEquipementDePreventionDropdownValues(dropdownValues);
            view.PerimetreDeSecurityEquipementDePreventionValues = WorkPermitMudsDropDownValueKeys.PerimetreDeSecurityEquipementDePreventionDropdownValues(dropdownValues);
            view.AutresConditionsValues = WorkPermitMudsDropDownValueKeys.AutresTravauxDropdownValues(dropdownValues);
            view.AutresEquipementDePreventionValues = WorkPermitMudsDropDownValueKeys.AppareilEquipementDePreventionDropdownValues(dropdownValues); //E1. d prevention
            //view.AppareilEquipementDePreventionValues = WorkPermitMudsDropDownValueKeys.AutresEquipementDePreventionDropdownValues(dropdownValues);  //Eq. d prot. personn

            view.AppareilProtecteurEquipementDeProtectionValues = WorkPermitMudsDropDownValueKeys.AutresEquipementDePreventionDropdownValues(dropdownValues); //appr vehicle combustion
            view.AppareilEquipementDePreventionValues = WorkPermitMudsDropDownValueKeys.AppareilProtecteurEquipementDeProtectionDropdownValues(dropdownValues);  //Eq. d prot. personn
        }

        private void SetDefaultListOfPermitTemplates()
        {
            List<WorkPermitMudsTemplate> templates = new List<WorkPermitMudsTemplate>(possibleTemplates);
            templates.Insert(0, WorkPermitMudsTemplate.NULL);
            view.PermitTemplates = templates;
        }

        private void SetDefaultListOfPermitTypes()
        {
            //bool statusIsRequested = editObject.WorkPermitStatus.Id == PermitRequestBasedWorkPermitStatus.Requested.Id;
            //if (!statusIsRequested)
            //{
                List<WorkPermitMudsType> workPermitTypes = new List<WorkPermitMudsType>(WorkPermitMudsType.All);
                workPermitTypes.Insert(0, WorkPermitMudsType.NULL);
                view.PermitTypes = workPermitTypes;
            //}
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
                WorkPermitMudsTemplate selectedTemplate = view.SelectedPermitTemplate;
                if (selectedTemplate.Equals(WorkPermitMudsTemplate.NULL))
                {
                    //SetDefaultListOfPermitTypes();
                }
                else
                {
                    WorkPermitMudsType workPermitType = selectedTemplate.WorkPermitType;

                    //WorkPermitMudsTemplate workPermitMudsTemplates = workPermitTemplateService.QueryByIdToMapPermit(selectedTemplate.ID, editObject.IdValue);
                    
                    view.SelectedPermitType = workPermitType;


                    //List<WorkPermitMudsType> workPermitTypeA = selectedTemplate.WorkPermitType;
                    //view.SelectedPermitType = workPermitType;
                }
                UpdateViewFromTemplate(selectedTemplate);

                view.ProtectionAuditive = new Visible<bool>(VisibleState.Visible, true); ;
            }
        }

        private void HandleSelectedWorkPermitTypeChange()
        {
            if (formLoadComplete)
            {
                UpdateTemplateListBasedOnPermitType(view.SelectedPermitType);
            }
        }

        private void UpdateTemplateListBasedOnPermitType(WorkPermitMudsType selectedPermitType)
        {
            if (selectedPermitType == WorkPermitMudsType.NULL)
            {   
                SetDefaultListOfPermitTemplates();
            }
            else
            {
                List<WorkPermitMudsTemplate> workPermitMudsTemplates =
                    possibleTemplates.FindAll(t => t.WorkPermitType == selectedPermitType);
                workPermitMudsTemplates.Insert(0, WorkPermitMudsTemplate.NULL);

                view.PermitTemplates = workPermitMudsTemplates;
            }
            UpdateViewFromTemplate(WorkPermitMudsTemplate.NULL);
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

        private void HandleUtilisationElectronicsChange()
        {
            view.OutilDeLaiton = view.UtilisationElectronics.Value == true || 
                utilisationElectronics.Value == true || _utilisationElectronics == true
                ? new Visible<bool>(VisibleState.Visible, true)
                : new Visible<bool>(VisibleState.Visible, false);

           // view.OutilDeLaiton = CreateVisibleFromEditObject(VisibleState.Visible, editObject.OutilDeLaiton);
        }

        private void SetStartAndEndDateTimes()
        {
            if (view.IsPreparation)
            {
                UserShift nextShift = userContext.UserShift.ChooseNextShift(allShifts);
                view.StartDateTime = nextShift.StartDateTime;
                view.EndDateTime = nextShift.EndDateTime;
            }
            else
            {
                SetStartAndEndDateTimesInCurrentShift();
            }

            //SetStartAndEndDateTimesInCurrentShift();
        }
        //Gas test Added

        private void QueryStandardGasTestElementInfoList()
        {
           
            standardGasTestElementInfoList = gasTestElementInfoService.QueryStandardElementInfosBySiteId(ClientSession.GetUserContext().SiteId);
        }

        private void SaveWorkItemGasTests(WorkPermitGasTests gasTests)
        {

            gasTests.GasTestFirstResultTime = view.FirtTestResult;
            if (view.ClonedFormDetailMuds == null || view.ClonedFormDetailMuds == "")
            {

                gasTests.GasTestSecondResultTime = view.SecondTestResult;

                gasTests.GasTestThirdResultTime = view.ThirdTestResult;

                gasTests.GasTestFourthResultTime = view.FourthTestResult;
            }

            List<GasTestElementDetailsMuds> gasTestElementDetailsList = view.GasTestElementDetailsList;
          // gasTests= new WorkPermitGasTests();
            foreach (GasTestElementDetailsMuds details in gasTestElementDetailsList)
            {
                GasTestElement element;
                if (detailsToGasTestElementTable.Keys.Contains(details) == false)
                {
                    GasTestElementInfo info;
                    if (details.IsStandard)
                    {
                        long? detailElementInfoId = details.GasTestElementInfoId;
                        info = FindStandardGasTestElementInfoById(detailElementInfoId);
                    }
                    else
                    {
                        Site site = ClientSession.GetUserContext().Site;
                        info = GasTestElementInfo.CreateOtherGasTestElementInfo(site);
                        //info = GasTestElementInfo.CreateOtherGasTestElementInfo_Other(site);
                    }
                    element = GasTestElement.CreateGasTestElement(info);
                    detailsToGasTestElementTable.Add(details, element);
                }
                else
                {
                    element = detailsToGasTestElementTable[details];
                }

                SaveGasTestElement(details, element);
                gasTests.Elements.Add(element);
                //if (element.HasData() && gasTests.Elements.Contains(element) == false)
                //{
                //    gasTests.Elements.Add(element);
                //}
                //else if (element.HasData() == false && gasTests.Elements.Contains(element))
                //{
                //    gasTests.Elements.Remove(element);
                //}
                
            }
        }

        private void SaveGasTestElement(GasTestElementDetailsMuds details, GasTestElement element)
        {
            element.ImmediateAreaTestResult = details.ImmediateAreaTestResult;
            element.ImmediateAreaTestRequired = details.ImmediateAreaTestRequired;
           // element.ConfinedSpaceTestResult = details.ConfinedSpaceTestResult;
           // element.ConfinedSpaceTestRequired = details.ConfinedSpaceTestRequired;
            element.SystemEntryTestResult = details.SystemEntryTestResult;
            element.SystemEntryTestNotApplicable = details.SystemEntryTestNotApplicable;
            if (view.ClonedFormDetailMuds != null || view.ClonedFormDetailMuds != "")
            {
                element.ConfinedSpaceTestRequired = false;
                element.ConfinedSpaceTestResult = null;
                element.ThirdTestRequired = false;
                element.ThirdTestResult = null;
                element.FourthTestResult=null;
                element.FourthTestRequired = false;
            }
            if (element.ElementInfo.IsStandard == false)
            {
                element.ElementInfo.OtherLimits = details.Limits;
                element.ElementInfo.Name = details.ElementName;
                element.ElementInfo.Name = details.ElementNameOther;  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

            }
        }

        private GasTestElementInfo FindStandardGasTestElementInfoById(long? elementInfoId)
        {
            foreach (GasTestElementInfo standardInfo in standardGasTestElementInfoList)
            {
                if (standardInfo.Id == elementInfoId)
                {
                    return standardInfo;
                }
            }
            throw new ApplicationException("Invalid Standard Gas Test Element Info Id : " + elementInfoId);
        }


        #region Load WorkItem - GasTests

        public void LoadWorkItemGasTests(WorkPermitMuds workPermit)
        {
           // view.GasTestEventsEnabled = false;
            if(workPermit.GasTests.GasTestFirstResultTime!=null)
            view.FirtTestResult = workPermit.GasTests.GasTestFirstResultTime;

            if (workPermit.GasTests.GasTestSecondResultTime != null)
            view.SecondTestResult = workPermit.GasTests.GasTestSecondResultTime;

            if (workPermit.GasTests.GasTestThirdResultTime != null)
            view.ThirdTestResult = workPermit.GasTests.GasTestThirdResultTime;

            if (workPermit.GasTests.GasTestFourthResultTime != null)
            view.FourthTestResult = workPermit.GasTests.GasTestFourthResultTime;

            WorkPermitGasTests gasTests = workPermit.GasTests;
            detailsToGasTestElementTable.Clear();
            List<GasTestElementDetailsMuds> detailsList = view.GasTestElementDetailsList;
            foreach (GasTestElementDetailsMuds details in view.GasTestElementDetailsList)
            {
                
              
                GasTestElement element = FindOrCreateGasTestElementForDetails(gasTests.Elements, details);
                LoadGasTestElement(details, element, workPermit);
                detailsToGasTestElementTable.Add(details, element);
            }

           // view.GasTestEventsEnabled = true;
        }

        private readonly List<string> _listElement = new List<string>();
        private bool has = false;

        private GasTestElement FindOrCreateGasTestElementForDetails(IEnumerable<GasTestElement> elementList, GasTestElementDetailsMuds gasTestElementDetails)
        {
            long? gasTestElementInfoId = gasTestElementDetails.GasTestElementInfoId;

            foreach (GasTestElement element in elementList)
            {

                if (gasTestElementDetails.IsStandard)
                {
                    if (element.ElementInfo.Id == gasTestElementInfoId)
                    {
                        return element;
                    }
                }
                else if (element.ElementInfo.Id == null ||
                        (element.ElementInfo.IsStandard == false && gasTestElementInfoId == null) ||
                        element.ElementInfo.Id == gasTestElementInfoId)
                {
                    //return element;
                    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                    if (_listElement.Count == 0)
                    {
                        _listElement.Add(Convert.ToString(element.ElementInfo.Name));
                        return element;
                    }

                    has = _listElement.Any(s => s == Convert.ToString(element.ElementInfo.Name));
                    if (!has) return element;


                }
            }

            if (gasTestElementInfoId == null)
            {
                Site site = ClientSession.GetUserContext().Site;
                GasTestElementInfo otherInfo = GasTestElementInfo.CreateOtherGasTestElementInfo(site);
                return GasTestElement.CreateGasTestElement(otherInfo);
            }
            GasTestElementInfo info = FindStandardGasTestElementInfoById(gasTestElementInfoId);
            return GasTestElement.CreateGasTestElement(info);
        }

        private static void LoadGasTestElement(GasTestElementDetailsMuds details, GasTestElement element, WorkPermitMuds workPermit)
        {
            
            details.ElementName = element.ElementInfo.Name;
            details.ElementNameOther = element.ElementInfo.Name; 
            //details.Limits = new GasTestElementLimitFormatter().ToLimitWithUnits(element, workPermit.WorkPermitType, WorkPermitMuds.Attributes);
            details.GasTestElementInfoId = element.ElementInfo.Id;
            details.IsStandard = element.ElementInfo.IsStandard;
            details.ImmediateAreaTestResult =  element.ImmediateAreaTestResult;
            details.ImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
            details.ConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
            details.ConfinedSpaceTestResult = element.ConfinedSpaceTestResult;
           details.ThirdTestRequired = element.ThirdTestRequired;
           details.ThirdTestResult = element.ThirdTestResult;

            details.FourthTestRequired = element.FourthTestRequired;
            details.FourthTestResult = element.FourthTestResult;
        }

        #endregion Load Work Item - Gas Tests


        public bool ValidateGasTest()
        {
            bool result = true;
           
          List<GasTestElementDetailsMuds> lst=  view.GasTestElementDetailsList;
          foreach (GasTestElementDetailsMuds Contrl in lst)
            {
                Contrl.ClearWarningMessages();
                if (Contrl.ImmediateAreaTestRequired && Contrl.ImmediateAreaTestResult.HasValue)
                {
                    GasTestElementInfo info = standardGasTestElementInfoList.FindById(Contrl.GasTestElementInfoId);
                    GasLimitRange range = info.GetLimitRange(WorkPermitType.HOT, new WorkPermitAttributes());
                    if (Contrl.ImmediateAreaTestResult.OutsideOf(range))
                   {
                       Contrl.SetImmediateAreaResultAlertMessage("Outside Range");
                       result = false;
                   }
                }
             
            }

           // bool returnResult = result || resultError;

            return result;
        }

    }
}