using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Template;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitMontrealForm : BaseForm, IWorkPermitMontrealFormView
    {
        public event Action FormLoad;
        public event Action WorkPermitTypeChanged;
        public event Action WorkPermitTemplateChanged;
        public event Action FunctionalLocationSelector;
        public event Action PreparationCheckChanged;
        public event EventHandler CancelButtonClicked;
        public event EventHandler SaveButtonClicked;
        public event Action ViewConfiguredDocumentLinkClicked;
        public event Action ConfinedSpaceButtonClicked;
        public event EventHandler StartOrEndDateTimeValueChanged;
        public event Action<string> AutresSubstancesTextValueChanged;
        public event Action DocumentLinkOpened;
        public event Action DocumentLinkAdded;

        public WorkPermitMontrealForm() 
        {
            InitializeComponent();

            requestDetailsControl.Visible = false;

            // Do this here instead of the designer because for some reason, the templatable controls
            // don't respond properly when the scroll bar appears/disappears.
            workPermitContentsPanel.AutoScroll = true;

            RegisterEventHandlersOnPresenter();
        }

        private void RegisterEventHandlersOnPresenter()
        {
            Load += WorkPermitMontrealFormLoad;

            permitTypeComboBox.SelectedValueChanged += OnSelectedWorkPermitTypeChange;
            permitTemplateComboBox.SelectedValueChanged += OnSelectedPermitTemplateChange;
            functionalLocationBrowseButton.Click += OnFunctionalLocationClick;

            preparationCheckBox.Click +=OnPreparationChange;

            saveButton.Click +=OnSaveAndCloseButton_Clicked;
            cancelButton.Click += OnCancelButton_Clicked;

            viewDocumentLinkButton.Click += OnViewDocumentLinkClick;
            confinedSpaceButton.Click += OnConfinedSpaceButtonClick;

            startDatePicker.ValueChanged += OnStartOrEndDateTimeValueChanged;
            startTimePicker.ValueChanged += OnStartOrEndDateTimeValueChanged;
            endDatePicker.ValueChanged += OnStartOrEndDateTimeValueChanged;
            endTimePicker.ValueChanged += OnStartOrEndDateTimeValueChanged;
            outilsPneumatiquesBooleanControl.CheckedChanged += outilsPneumatiquesBooleanControl_CheckedChanged;
            autresSubstancesDropDownControl.TextValueChanged += HandleAutresSubstancesDropDownControlTextValueChanged;

            documentLinksControl.LinkOpened += () => DocumentLinkOpened();
            documentLinksControl.LinkAdded += () => DocumentLinkAdded();
        }

      
       private void outilsPneumatiquesBooleanControl_CheckedChanged()
        {
            if (!ecranFacialBooleanControl.Checked)
            {
                ecranFacialBooleanControl.Checked = true;
            }
            else
            {
                ecranFacialBooleanControl.Checked = false;
            }
        }

        private void HandleAutresSubstancesDropDownControlTextValueChanged(string value)
        {
            if (AutresSubstancesTextValueChanged != null)
            {
                AutresSubstancesTextValueChanged(value);
            }
        }

        private void OnStartOrEndDateTimeValueChanged(object sender, EventArgs e)
        {
            if (StartOrEndDateTimeValueChanged != null)
            {
                StartOrEndDateTimeValueChanged(sender, e);
            }
        }

        private void OnConfinedSpaceButtonClick(object sender, EventArgs e)
        {
            if (ConfinedSpaceButtonClicked != null)
            {
                ConfinedSpaceButtonClicked();
            }
        }

        private void OnViewDocumentLinkClick(object sender, EventArgs e)
        {
            if (ViewConfiguredDocumentLinkClicked != null)
            {
                ViewConfiguredDocumentLinkClicked();
            }
        }

        void OnCancelButton_Clicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        void OnSaveAndCloseButton_Clicked(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, e);
            }
        }

        void OnPreparationChange(object sender, EventArgs e)
        {
            if (PreparationCheckChanged != null)
            {
                PreparationCheckChanged();
            }
        }

        void OnFunctionalLocationClick(object sender, EventArgs e)
        {
            if (FunctionalLocationSelector != null)
            {
                FunctionalLocationSelector();
            }
        }

        void OnSelectedPermitTemplateChange(object sender, EventArgs e)
        {
            if (WorkPermitTemplateChanged != null)
            {
                WorkPermitTemplateChanged();
            }
        }

        void OnSelectedWorkPermitTypeChange(object sender, EventArgs e)
        {
            if (WorkPermitTypeChanged != null)
            {
                WorkPermitTypeChanged();
            }
        }

        void WorkPermitMontrealFormLoad(object sender, EventArgs e)
        {
            if (FormLoad != null)
            {
                FormLoad();
            }
            HighlightGroupBoxes();
        }

        public List<ConfiguredDocumentLink> ConfiguredDocumentLinks
        {
            set
            {
                configuredDocumentLinkComboBox.Items.Clear();
                value.ForEach(link => configuredDocumentLinkComboBox.Items.Add(link));
                configuredDocumentLinkComboBox.SelectedIndex = 0;
            }
        }

        public ConfiguredDocumentLink SelectedConfiguredDocumentLink
        {
            get { return (ConfiguredDocumentLink)configuredDocumentLinkComboBox.SelectedItem; }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        private void HighlightGroupBoxes()
        {
            Color groupBoxTextColor = SystemColors.HotTrack;
            SetGroupBoxColor(basicInformationGroupBox, groupBoxTextColor);
            SetGroupBoxColor(substancesNormalementGroupBox, groupBoxTextColor);
            SetGroupBoxColor(conditionsGroupBox, groupBoxTextColor);
            SetGroupBoxColor(equipementsGroupBox, groupBoxTextColor);
            SetGroupBoxColor(protectionGroupBox, groupBoxTextColor);
            SetGroupBoxColor(autresGroupBox, groupBoxTextColor);
            SetGroupBoxColor(specialPrecautionsOrConsiderationsGroupBox, groupBoxTextColor);
        }

        private void SetGroupBoxColor(GroupBox groupBox, Color color)
        {
            List<Color> lstColour = new List<Color>();
            foreach (Control c in groupBox.Controls)
                lstColour.Add(c.ForeColor);

            groupBox.ForeColor = color; 

            int index = 0;
            foreach (Control c in groupBox.Controls)
            {
                c.ForeColor = lstColour[index];
                index++;
            }            
        }

        public List<CraftOrTrade> Trade
        {
            set
            {
                tradeComboBox.DataSource = value;
                tradeComboBox.DisplayMember = "Name";
            }
        }

        public List<WorkPermitMontrealType> PermitTypes
        {
            set
            {
                permitTypeComboBox.SelectedValueChanged -= OnSelectedWorkPermitTypeChange;

                permitTypeComboBox.DataSource = value;
                permitTypeComboBox.DisplayMember = "Name";

                permitTypeComboBox.SelectedValueChanged += OnSelectedWorkPermitTypeChange;
            }
        }

        public WorkPermitMontrealType SelectedPermitType
        {
            get
            {
                object selectedItem = permitTypeComboBox.SelectedItem;
                return (WorkPermitMontrealType)selectedItem;
            }
            set
            {
                permitTypeComboBox.SelectedValueChanged -= OnSelectedWorkPermitTypeChange;

                permitTypeComboBox.SelectedItem = value;

                permitTypeComboBox.SelectedValueChanged += OnSelectedWorkPermitTypeChange;
            }
        }

        public List<WorkPermitMontrealTemplate> PermitTemplates
        {
            set
            {
                permitTemplateComboBox.SelectedValueChanged -= OnSelectedPermitTemplateChange;

                permitTemplateComboBox.DataSource = value;
                permitTemplateComboBox.DisplayMember = "DisplayName";

                permitTemplateComboBox.SelectedValueChanged += OnSelectedPermitTemplateChange;
            }
        }

        public WorkPermitMontrealTemplate SelectedPermitTemplate
        {
            get
            {
                object selectedItem = permitTemplateComboBox.SelectedItem;
                return (WorkPermitMontrealTemplate) selectedItem;
            }
            set
            {
                permitTemplateComboBox.SelectedValueChanged -= OnSelectedPermitTemplateChange;

                permitTemplateComboBox.SelectedItem = value;

                permitTemplateComboBox.SelectedValueChanged += OnSelectedPermitTemplateChange;
            }
        }

        public string SelectedPermitTemplateName
        {
            get
            {
                if (permitTemplateTextBox.Visible)
                {
                    return permitTemplateTextBox.Text;
                }
                return string.Empty;
            }
            set { permitTemplateTextBox.Text = value; }
        }

        public List<WorkPermitMontrealGroup> RequestedByGroupValues
        {
            set
            {
                requestedByComboBox.DataSource = value;
                requestedByComboBox.DisplayMember = "Name";
            }
        }

        public WorkPermitMontrealGroup SelectedRequestedByGroup
        {
            get { return (WorkPermitMontrealGroup) requestedByComboBox.SelectedItem; }
            set { requestedByComboBox.SelectedItem = value; }
        }

        public List<FunctionalLocation> ShowFunctionalLocationSelector(List<FunctionalLocation> selectedFlocs)
        {
            IMultiSelectFunctionalLocationSelectionForm functionalLocationSelectionForm =
                new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetLevelThreeAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level3), true);

            DialogResult result = functionalLocationSelectionForm.ShowDialog(this, selectedFlocs);
            return result == DialogResult.OK ? new List<FunctionalLocation>(functionalLocationSelectionForm.UserSelectedFunctionalLocations) : null;
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            get { return functionalLocationTextBox.Tag as List<FunctionalLocation>; }
            set
            {
                if (value != null)
                {
                    string flocString = value.FullHierarchyListToString(false, false);
                    functionalLocationTextBox.TextWithEllipsis = flocString;
                    toolTip.SetToolTip(functionalLocationTextBox, flocString);
                    functionalLocationTextBox.Tag = value;
                }
                else
                {
                    functionalLocationTextBox.Text = string.Empty;
                    functionalLocationTextBox.Tag = null;
                    toolTip.RemoveAll();
                }
            }
        }



        public DateTime StartDateTime
        {
            get
            {
                Date date = startDatePicker.Value;
                Time time = startTimePicker.Value;
                
                return date.CreateDateTime(time);
            }
            set
            {
                startDatePicker.Value = new Date(value);
                startTimePicker.Value = new Time(value);
            }
        }

        public DateTime EndDateTime
        {
            get 
            { 
                Date date = endDatePicker.Value;
                Time time = endTimePicker.Value;
                
                return date.CreateDateTime(time);
            }
            set
            {
                endDatePicker.Value = new Date(value);
                endTimePicker.Value = new Time(value);
            }

        }

        public string SelectedTrade
        {
            get { return tradeComboBox.Text; }
            set { tradeComboBox.Text = value; }
        }

        public string Description
        {
            get { return descriptionTextBox.Text; }
            set { descriptionTextBox.Text = value; }
        }

        public string ReferenceNumber
        {
            set { refNumberTextBox.Text = value; }
        }

        public string WorkOrderNumber
        {
            get { return workOrderNumberTextBox.Text; }
            set { workOrderNumberTextBox.Text = value; }
        }

        #region get/set for stuff outside of basic
        public Visible<bool> H2S
        {
            get { return h2SBooleanControl.Value; }
            set { h2SBooleanControl.Value = value; }
        }

        public Visible<bool> Hydrocarbure
        {
            get { return hydrocarbureBooleanControl.Value; }
            set { hydrocarbureBooleanControl.Value = value; }
        }

        public Visible<bool> Ammoniaque
        {
            get { return ammoniaqueBooleanControl.Value; }
            set { ammoniaqueBooleanControl.Value = value; }
        }

        public Visible<TernaryString> Corrosif
        {
            get { return corrosifDropDownControl.Value; }
            set { corrosifDropDownControl.Value = value; }
        }

        public List<String> CorrosifValues
        {
            set { corrosifDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> Aromatique
        {
            get { return aromatiqueDropDownControl.Value; }
            set { aromatiqueDropDownControl.Value = value; }
        }

        public List<String> AromatiqueValues
        {
            set { aromatiqueDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> AutresSubstances
        {
            get { return autresSubstancesDropDownControl.Value; }
            set { autresSubstancesDropDownControl.Value = value; }
        }

        public List<String> AutresSubstancesValues
        {
            set { autresSubstancesDropDownControl.DataSource = value; }
        }

        public Visible<bool> ObtureOuDebranche
        {
            get { return obtureOuDeBrancheBooleanControl.Value; }
            set { obtureOuDeBrancheBooleanControl.Value = value; }
        }

        public Visible<bool> DepressuriseEtVidange
        {
            get { return depressuriseEtVidangeBooleanControl.Value; }
            set { depressuriseEtVidangeBooleanControl.Value = value; }
        }

        public Visible<bool> EnPreenceDeGazInerte
        {
            get { return enPresenceDeGazInerteBooleanControl.Value; }
            set { enPresenceDeGazInerteBooleanControl.Value = value; }
        }

        public Visible<bool> PurgeALaVapeur
        {
            get { return purgeAlaVapeurBooleanControl.Value; }
            set { purgeAlaVapeurBooleanControl.Value = value; }
        }

        public Visible<bool> RinceALeau
        {
            get { return rinceAlEauBooleanControl.Value; }
            set { rinceAlEauBooleanControl.Value = value; }
        }

        public Visible<bool> Excavation
        {
            get { return excavationBooleanControl.Value; }
            set { excavationBooleanControl.Value = value; }
        }

        public Visible<TernaryString> DessinsRequis
        {
            get { return dessinsRequisStringControl.Value; }
            set { dessinsRequisStringControl.Value = value; }
        }

        public Visible<bool> CablesChauffantsMisHorsTension
        {
            get { return cablesChauffantsMisHorsTensionBooleanControl.Value; }
            set { cablesChauffantsMisHorsTensionBooleanControl.Value = value; }
        }

        public Visible<bool> PompeOuVerinPneumatique
        {
            get { return pompeOuVerinPneumatiqueBooleanControl.Value; }
            set { pompeOuVerinPneumatiqueBooleanControl.Value = value; }
        }

        public Visible<bool> ChaineEtCadenasseOuScelle
        {
            get { return chaineCadenasseScelleBooleanControl.Value; }
            set { chaineCadenasseScelleBooleanControl.Value = value; }
        }

        public Visible<bool> InterrupteursElectriquesVerrouilles
        {
            get { return interrupteursElectriquesVerrouillesBooleanControl.Value; }
            set { interrupteursElectriquesVerrouillesBooleanControl.Value = value; }
        }

        public Visible<bool> PurgeParUnGazInerte
        {
            get { return purgeGazInerteBooleanControl.Value; }
            set { purgeGazInerteBooleanControl.Value = value; }
        }

        public Visible<bool> OutilsElectriquesOuABatteries
        {
            get { return outilsElectriquesBatteriesBooleanControl.Value; }
            set { outilsElectriquesBatteriesBooleanControl.Value = value; }
        }

        public Visible<TernaryString> BoiteEnergieZero
        {
            get { return boiteEnergieZeroStringControl.Value; }
            set { boiteEnergieZeroStringControl.Value = value; }
        }

        public Visible<bool> OutilsPneumatiques
        {
            get { return outilsPneumatiquesBooleanControl.Value; }
            set { outilsPneumatiquesBooleanControl.Value = value; }
        }

        public Visible<bool> MoteurACombustionInterne
        {
            get { return moteurCombustionInterneBooleanControl.Value; }
            set { moteurCombustionInterneBooleanControl.Value = value; }
        }

        public Visible<bool> TravauxSuperPoses
        {
            get { return travauxSuperposesBooleanControl.Value; }
            set { travauxSuperposesBooleanControl.Value = value; }
        }

        public Visible<TernaryString> FormulaireDespaceClosAffiche
        {
            get { return formulaireDespaceAfficheStringControl.Value; }
            set { formulaireDespaceAfficheStringControl.Value = value; }
        }

        public Visible<bool> ExisteIlUneAnalyseDeTache
        {
            get { return existeIlUneAnalyseDeTacheBooleanControl.Value; }
            set { existeIlUneAnalyseDeTacheBooleanControl.Value = value; }
        }

        public Visible<bool> PossibiliteDeSulfureDeFer
        {
            get { return possibiliteDeSulfuredeFerBooleanControl.Value; }
            set { possibiliteDeSulfuredeFerBooleanControl.Value = value; }
        }

        public Visible<bool> AereVentile
        {
            get { return aereBooleanControl.Value; }
            set { aereBooleanControl.Value = value; }
        }

        public Visible<bool> SoudureALelectricite
        {
            get { return soudureElectriciteBooleanControl.Value; }
            set { soudureElectriciteBooleanControl.Value = value; }
        }

        public Visible<bool> BrulageAAcetylene
        {
            get { return brulageAcetyleneBooleanControl.Value; }
            set { brulageAcetyleneBooleanControl.Value = value; }
        }

        public Visible<bool> Nacelle
        {
            get { return nacelleBooleanControl.Value; }
            set { nacelleBooleanControl.Value = value; }
        }

        public Visible<TernaryString> AutreConditions
        {
            get { return autresConditionsDropDownControl.Value; }
            set { autresConditionsDropDownControl.Value = value; }
        }

        public List<String> AutreConditionsValues
        {
            set { autresConditionsDropDownControl.DataSource = value; }
        }

        public Visible<bool> LunettesMonocoques
        {
            get { return lunettesMonocoquesBooleanControl.Value; }
            set { lunettesMonocoquesBooleanControl.Value = value; }
        }

        public Visible<bool> HarnaisDeSecurite
        {
            get { return harnaisDeSecuriteBooleanControl.Value; }
            set { harnaisDeSecuriteBooleanControl.Value = value; }
        }

        public Visible<bool> EcranFacial
        {
            get { return ecranFacialBooleanControl.Value; }
            set { ecranFacialBooleanControl.Value = value; }
        }

        public Visible<bool> ProtectionAuditive
        {
            get { return protectionAuditiveBooleanControl.Value; }
            set { protectionAuditiveBooleanControl.Value = value; }
        }

        public Visible<bool> Trepied
        {
            get { return trepiedBooleanControl.Value; }
            set { trepiedBooleanControl.Value = value; }
        }

        public Visible<bool> DispositifAntichute
        {
            get { return dispositifAntiChuteBooleanControl.Value; }
            set { dispositifAntiChuteBooleanControl.Value = value; }
        }

        public Visible<TernaryString> ProtectionRespiratoire
        {
            get { return protectionRespiratoireDropDownControl.Value; }
            set { protectionRespiratoireDropDownControl.Value = value; }
        }

        public List<string> ProtectionRespiratoireValues
        {
            set { protectionRespiratoireDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> Habits
        {
            get { return habitsDropDownControl.Value; }
            set { habitsDropDownControl.Value = value; }
        }

        public List<string> HabitsValues
        {
            set { habitsDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> AutreProtection
        {
            get { return autreProtectionDropDownControl.Value; }
            set { autreProtectionDropDownControl.Value = value; }
        }

        public List<string> AutreProtectionValues
        {
            set { autreProtectionDropDownControl.DataSource = value; }
        }

        public Visible<bool> Extincteur
        {
            get { return extincteurBooleanControl.Value; }
            set { extincteurBooleanControl.Value = value; }
        }

        public Visible<bool> BouchesDegoutProtegees
        {
            get { return bouchesDegoutProtegeesBooleanControl.Value; }
            set { bouchesDegoutProtegeesBooleanControl.Value = value; }
        }

        public Visible<bool> CouvertureAntiEtincelles
        {
            get { return couvetureAntiEtincellesBooleanControl.Value; }
            set { couvetureAntiEtincellesBooleanControl.Value = value; }
        }

        public Visible<bool> SurveillantPouretincelles
        {
            get { return surveillantPourEtincellesBooleanControl.Value; }
            set { surveillantPourEtincellesBooleanControl.Value = value; }
        }

        public Visible<bool> PareEtincelles
        {
            get { return pareEtincellesBooleanControl.Value; }
            set { pareEtincellesBooleanControl.Value = value; }
        }

        public Visible<bool> MiseAlaTerrePresDuLieuDeTravail
        {
            get { return miseALaTerePresDuLieuDeTravailBooleanControl.Value; }
            set { miseALaTerePresDuLieuDeTravailBooleanControl.Value = value; }
        }

        public Visible<bool> BoyauAVapeur
        {
            get { return boyauVapeurBooleanControl.Value; }
            set { boyauVapeurBooleanControl.Value = value; }
        }

        public Visible<TernaryString> AutresEquipementDincendie
        {
            get { return autresEquipementDincendieDropDownControl.Value; }
            set { autresEquipementDincendieDropDownControl.Value = value; }
        }

        public List<String> AutresEquipementDincendieValues
        {
            set { autresEquipementDincendieDropDownControl.DataSource = value; }
        }

        public Visible<bool> Ventulateur
        {
            get { return ventilateurBooleanControl.Value; }
            set { ventilateurBooleanControl.Value = value; }
        }

        public Visible<bool> Barrieres
        {
            get { return barrieresBooleanControl.Value; }
            set { barrieresBooleanControl.Value = value; }
        }

        public Visible<TernaryString> Surveillant
        {
            get { return surveillantDropDownControl.Value; }
            set { surveillantDropDownControl.Value = value; }
        }

        public List<String> SurveillantValues
        {
            set { surveillantDropDownControl.DataSource = value; }
        }

        public Visible<bool> RadioEmetteur
        {
            get { return radioEmetteurBooleanControl.Value; }
            set { radioEmetteurBooleanControl.Value = value; }
        }

        public Visible<bool> PerimetreDeSecurite
        {
            get { return perimetreDeSecuriteBooleanControl.Value; }
            set { perimetreDeSecuriteBooleanControl.Value = value; }
        }

        public Visible<TernaryString> DetectionContinueDesGaz
        {
            get { return detectionContinueDesGazDropDownControl.Value; }
            set { detectionContinueDesGazDropDownControl.Value = value; }
        }

        public List<String> DetectionContinueDesGazValues
        {
            set { detectionContinueDesGazDropDownControl.DataSource = value; }
        }

        public Visible<bool> KlaxonSonore
        {
            get { return klaxonSonoreBooleanControl.Value; }
            set { klaxonSonoreBooleanControl.Value = value; }
        }

        public Visible<bool> Localiser
        {
            get { return localiserBooleanControl.Value; }
            set { localiserBooleanControl.Value = value; }
        }

        public Visible<bool> Amiante
        {
            get { return amianteBooleanControl.Value; }
            set { amianteBooleanControl.Value = value; }
        }

        public Visible<TernaryString> AutreEquipementsSecurite
        {
            get { return autreSecuriteDropDownControl.Value; }
            set { autreSecuriteDropDownControl.Value = value; }
        }

        public List<String> AutreEquipementsSecuriteValues
        {
            set { autreSecuriteDropDownControl.DataSource = value; }
        }

        public string InstructionsSpeciales
        {
            get { return specialPrecautionsOrConsiderationsDescriptionTextBox.Text.EmptyToNull(); }
            set { specialPrecautionsOrConsiderationsDescriptionTextBox.Text = value; }
        }

        public Visible<bool> SignatureOperateurSurLeTerrain
        {
            get { return signatureOperateurBooleanControl.Value; }
            set { signatureOperateurBooleanControl.Value = value; }
        }

        public Visible<bool> DetectionDesGazs
        {
            get { return detectionDesGazsBooleanControl.Value; }
            set { detectionDesGazsBooleanControl.Value = value; }
        }

        public Visible<bool> SignatureContremaitre
        {
            get { return signatureContremaitreBooleanControl.Value; }
            set { signatureContremaitreBooleanControl.Value = value; }
        }

        public Visible<bool> SignatureAutorise
        {
            get { return signatureAutoriseBooleanControl.Value; }
            set { signatureAutoriseBooleanControl.Value = value; }
        }

        public Visible<bool> NettoyageTransfertHorsSite
        {
            get { return nettoyageTransfertHorsSiteTemplatableBooleanControl.Value; }
            set { nettoyageTransfertHorsSiteTemplatableBooleanControl.Value = value; }
        }

        public void PutInTemplateMode()
        {
            basicInformationGroupBox.Controls.ForEach<Control>(c => c.Visible = false);
            permitTypeLabel.Visible = true;
            permitTypeComboBox.Visible = true;
            permitTemplateNameLabel.Visible = true;
            permitTemplateTextBox.Visible = true;
            nonSaveAndDeleteButtonPanel.Visible = false;

            detectionDesGazsBooleanControl.Enabled = true;
            signatureContremaitreBooleanControl.Enabled = true;
            signatureAutoriseBooleanControl.Enabled = true;
            nettoyageTransfertHorsSiteTemplatableBooleanControl.Enabled = true;

            PutTemplatableControlsInTemplateMode(Controls);
        }

        public void TurnOnAutosetIndicatorsForDateTimes()
        {
            infoProvider.SetError(endTimePicker, StringResources.AutosetWorkPermitDateTimesInfoMessage);
        }

        public void TurnOffAutosetIndicatorsForDateTimes()
        {
            infoProvider.Clear();
        }

        private void PutTemplatableControlsInTemplateMode(Control.ControlCollection controls)
        {
            foreach(Control control in controls)
            {
                if (control is Panel || control is GroupBox)
                {
                    PutTemplatableControlsInTemplateMode(control.Controls);
                }
                else if (control is ITriStateControl)
                {
                    ITriStateControl triStateControl = (ITriStateControl) control;
                    triStateControl.TemplateMode = true;
                }

            }
        }
        public bool IsPreparation
        {
            get { return preparationCheckBox.Checked; }
            set { preparationCheckBox.Checked = value; }
        }

        public void DisableFieldsForPermitEdit(bool statusIsRequested)
        {
            permitTypeComboBox.Enabled = statusIsRequested;
            permitTemplateComboBox.Enabled = statusIsRequested;
        }

        #endregion

        #region Error message setters
        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public void SetErrorForNoPermitType()
        {
            errorProvider.SetError(permitTypeComboBox, StringResources.WorkPermit_PermitType_Not_Selected);
        }

        public void SetErrorForNoDescription()
        {
            errorProvider.SetError(descriptionTextBox, StringResources.WorkPermit_Description_Empty);
        }

        public void SetErrorForNoAlphaNumeric(string name)
        {
        }

        public void SetErrorForNoTrade()
        {
            errorProvider.SetError(tradeComboBox, StringResources.MontrealWorkPermit_Trade_Not_Selected);
        }

        public void SetErrorForNoFunctionalLocation()
        {
            errorProvider.SetError(functionalLocationBrowseButton, StringResources.MontrealWorkPermit_FlocEmptyError);
        }

        public void SetErrorForStartDateTimeAfterEndDateTime()
        {
            SetEndTimePickerError(StringResources.StartDateBeforeEndDate);
        }

        public void SetErrorForNoTemplateName()
        {
            errorProvider.SetError(permitTemplateTextBox, StringResources.MontrealWorkPermit_TemplateName_Empty);
        }

        public void SetErrorForNoSelectedTemplate()
        {
            errorProvider.SetError(permitTemplateComboBox, StringResources.MontrealWorkPermit_Template_Not_Selected);
        }

        public void SetErrorForTimeSpanTooLongForVehicleEntryType()
        {
            SetEndTimePickerError(StringResources.MontrealWorkPermit_TimeSpanError_VehicleEntry);
        }

        public void SetErrorForTimeSpanTooLongForDurationType()
        {
            SetEndTimePickerError(StringResources.MontrealWorkPermit_TimeSpanError_Duration);
        }

        public void SetErrorForTimeSpanTooLong()
        {
            SetEndTimePickerError(StringResources.MontrealWorkPermit_TimeSpanError);
        }

        public void SetErrorForEndDateMustBeonOrAfterTodayError()
        {
            SetEndTimePickerError(StringResources.DateCannotBeInThePast);
        }

        private void SetEndTimePickerError(string message)
        {
            infoProvider.Clear();  // get rid of the info icon so that the error icon doesn't conflict with it visually (bug #1887)
            errorProvider.SetError(endTimePicker, message);
        }

        public void SetErrorForCorrosif()
        {
            corrosifDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_Corrosif));
        }

        public void SetErrorForAromatique()
        {
            aromatiqueDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_Aromatique));
        }

        public void SetErrorForAutresSubstances()
        {
            autresSubstancesDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_Autres));
        }

        public void SetErrorForDessinsRequis()
        {
            dessinsRequisStringControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_DessinsRequis));
        }

        public void SetErrorForBoiteEnergieZero()
        {
            boiteEnergieZeroStringControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_BoiteEnergieZero));
        }

        public void SetErrorForFormulaireDespaceClosAffiche()
        {
            formulaireDespaceAfficheStringControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_FormulaireDespaceClosAffiche));
        }

        public void SetErrorForAutreConditions()
        {
            autresConditionsDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_Autres));
        }

        public void SetErrorForProtectionRespiratoire()
        {
            protectionRespiratoireDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_ProtectionResporatoire));
        }

        public void SetErrorForHabits()
        {
            habitsDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_Habits));
        }

        public void SetErrorForAutreProtection()
        {
            autreProtectionDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_Autres));
        }

        public void SetErrorForAutresEquipementDincendie()
        {
            autresEquipementDincendieDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_AutresEquipementDincendie));
        }

        public void SetErrorForSurveillant()
        {
            surveillantDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_Surveillant));
        }

        public void SetErrorForDetectionContinueDesGaz()
        {
            detectionContinueDesGazDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_DetectionContinueDesGaz));
        }

        public void SetErrorForAutreEquipementsSecurite()
        {
            autreSecuriteDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_Autres));
        }

        #endregion      

        public void SetRequestDetails(
            bool visible,
            DateTime? requestedDateTime, string requestedByUser,
            string company, string supervisor, string excavationNumber,
            List<PermitAttribute> attributes)
        {
            requestDetailsControl.Visible = visible;
            if (visible)
            {
                requestDetailsControl.SetFields(requestedDateTime, requestedByUser, company, supervisor, excavationNumber, attributes);
            }
        }

        public void OpenFileOrDirectoryOrWebsite(string path)
        {
            FileUtility.OpenFileOrDirectoryOrWebsite(path);
        }

        public bool ShowFieldOperatorUncheckedWarning()
        {
            DialogResult result = OltMessageBox.Show(this, StringResources.WalkDownSignatureWarningDialog_Text,
                                                     StringResources.WalkDownSignatureWarningDialog_Title,
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }

        public DialogResult ShowReviewDocumentLinksWarning()
        {
            return OltMessageBox.Show(this,
                StringResources.UnreadDocumentLinksOnSinglePermit,
                StringResources.UnreadDocumentLinksOnSinglePermit_Title,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
        }

        public DialogResult ShowFunctionalLocationsLengthWarning(string truncatedFlocString)
        {
            return OltMessageBox.Show(this,
                String.Format(StringResources.FunctionalLocationsWillNotFitInPrintoutWarningDialog_Text, truncatedFlocString),
                StringResources.FunctionalLocationsWillNotFitInPrintoutWarningDialog_Title,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
        }

        public void DisableConfiguredDocumentLinks()
        {
            configuredDocumentLinkComboBox.Enabled = false;
            viewDocumentLinkButton.Enabled = false;
        }
       public string ClonedFormDetailMontreal { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History

    }
}
