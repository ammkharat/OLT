using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfinedSpaceForm : BaseForm, IConfinedSpaceView
    {
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action FormLoad;
        public event Action FunctionalLocationSelector;
        public event Action PreparationCheckChanged;
        public event Action<ConfiguredDocumentLink> ViewDocumentLinkClicked;

        public bool IsPreparation
        {
            get { return preparationCheckBox.Checked; }
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocationTextBox.Tag as FunctionalLocation; }
            set
            {
                if (value != null)
                {
                    functionalLocationTextBox.Text = value.FullHierarchyWithDescription;
                    functionalLocationTextBox.Tag = value;
                }
                else
                {
                    functionalLocationTextBox.Text = string.Empty;
                    functionalLocationTextBox.Tag = null;
                }
            }
        }

        public string ConfinedSpaceNumber
        {
            set { refNumberTextBox.Text = value; }
        }

        private Visible<T> CreateVisible<T>(T value)
        {
            return new Visible<T>(VisibleState.Visible, value);    
        }

        public bool H2S
        {
            get { return h2SBooleanControl.Value.Value; }
            set { h2SBooleanControl.Value = CreateVisible(value); }
        }

        public bool Hydrocarbure
        {
            get { return hydrocarbureBooleanControl.Value.Value; }
            set { hydrocarbureBooleanControl.Value = CreateVisible(value); }
        }

        public bool Ammoniaque
        {
            get { return ammoniaqueBooleanControl.Value.Value; }
            set { ammoniaqueBooleanControl.Value = CreateVisible(value); }
        }

        public TernaryString Corrosif
        {
            get { return corrosifDropDownControl.Value.Value; }
            set { corrosifDropDownControl.Value = CreateVisible(value); }
        }

        public List<string> CorrosifValues
        {
            set { corrosifDropDownControl.DataSource = value; }
        }

        public TernaryString Aromatique
        {
            get { return aromatiqueDropDownControl.Value.Value; }
            set { aromatiqueDropDownControl.Value = CreateVisible(value); }
        }

        public List<string> AromatiqueValues
        {
            set { aromatiqueDropDownControl.DataSource = value; }
        }

        public TernaryString AutresSubstances
        {
            get { return autresSubstancesDropDownControl.Value.Value; }
            set { autresSubstancesDropDownControl.Value = CreateVisible(value); }
        }

        public List<string> AutresSubstancesValues
        {
            set { autresSubstancesDropDownControl.DataSource = value; }
        }

        public bool ObtureOuDebranche
        {
            get { return obtureOuDeBrancheBooleanControl.Value.Value; }
            set { obtureOuDeBrancheBooleanControl.Value = CreateVisible(value); }
        }

        public bool DepressuriseEtVidange
        {
            get { return depressuriseEtVidangeBooleanControl.Value.Value; }
            set { depressuriseEtVidangeBooleanControl.Value = CreateVisible(value); }
        }

        public bool EnPresenceDeGazInerte
        {
            get { return enPresenceDeGazInerteBooleanControl.Value.Value; }
            set { enPresenceDeGazInerteBooleanControl.Value = CreateVisible(value); }
        }

        public bool PurgeALaVapeur
        {
            get { return purgeAlaVapeurBooleanControl.Value.Value; }
            set { purgeAlaVapeurBooleanControl.Value = CreateVisible(value); }
        }

        public TernaryString DessinsRequis
        {
            get { return dessinsRequisStringControl.Value.Value; }
            set { dessinsRequisStringControl.Value = CreateVisible(value); }
        }

        public bool PlanDeSauvetage
        {
            get { return planDeSauvetageBooleanControl.Value.Value; }
            set { planDeSauvetageBooleanControl.Value = CreateVisible(value); }
        }

        public bool CablesChauffantsMisHorsTension
        {
            get { return cablesChauffantsMisHorsTensionBooleanControl.Value.Value; }
            set { cablesChauffantsMisHorsTensionBooleanControl.Value = CreateVisible(value); }
        }

        public bool InterrupteursElectriquesVerrouilles
        {
            get { return interrupteursElectriquesVerrouillesBooleanControl.Value.Value; }
            set { interrupteursElectriquesVerrouillesBooleanControl.Value = CreateVisible(value); }
        }

        public bool PurgeParUnGazInerte
        {
            get { return purgeParGazInerteBooleanControl.Value.Value; }
            set { purgeParGazInerteBooleanControl.Value = CreateVisible(value); }
        }

        public bool RinceALeau
        {
            get { return rinceAlEauBooleanControl.Value.Value; }
            set { rinceAlEauBooleanControl.Value = CreateVisible(value); }
        }

        public bool VentilationMecanique
        {
            get { return ventilationMecaniqueBooleanControl.Value.Value; }
            set { ventilationMecaniqueBooleanControl.Value = CreateVisible(value); }
        }

        public bool BouchesDegoutProtegees
        {
            get { return bouchesDegoutProtegeesBooleanControl.Value.Value; }
            set { bouchesDegoutProtegeesBooleanControl.Value = CreateVisible(value); }
        }

        public bool PossibiliteDeSulfureDeFer
        {
            get { return possibiliteDeSulfuredeFerBooleanControl.Value.Value; }
            set { possibiliteDeSulfuredeFerBooleanControl.Value = CreateVisible(value); }
        }

        public bool AereVentile
        {
            get { return aereBooleanControl.Value.Value; }
            set { aereBooleanControl.Value = CreateVisible(value); }
        }

        public TernaryString AutreConditions
        {
            get { return autresConditionsDropDownControl.Value.Value; }
            set { autresConditionsDropDownControl.Value = CreateVisible(value); }
        }

        public List<string> AutreConditionsValues
        {
            set { autresConditionsDropDownControl.DataSource = value; }
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

        public bool VentilationNaturelle
        {
            get { return ventilationNaturelleBooleanControl.Value.Value; }
            set { ventilationNaturelleBooleanControl.Value = CreateVisible(value); }
        }

        public string InstructionsSpeciales
        {
            get { return instructionsSpecialesTextBox.Text; }
            set { instructionsSpecialesTextBox.Text = value; }
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

        public FunctionalLocation ShowFunctionalLocationSelector()
        {
            ISingleSelectFunctionalLocationSelectionForm functionalLocationSelectionForm =
                new SingleSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetLevelThreeAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level3));

            DialogResult result = functionalLocationSelectionForm.ShowDialog(this);
            return result == DialogResult.OK ? functionalLocationSelectionForm.SelectedFunctionalLocation : null;
        }

        public void OpenFileOrDirectoryOrWebsite(string path)
        {
            FileUtility.OpenFileOrDirectoryOrWebsite(path);
        }

        public void DisableConfiguredDocumentLinks()
        {
            configuredDocumentLinkComboBox.Enabled = false;
            viewConfiguredDocumentLinkButton.Enabled = false;
        }

        public ConfinedSpaceForm()
        {
            InitializeComponent();
            Load += ConfinedSpaceForm_Load;
            cancelButton.Click += cancelButton_Click;
            saveButton.Click += saveButton_Click;
            functionalLocationBrowseButton.Click += OnFunctionalLocationClick;
            preparationCheckBox.Click += OnPreparationChange;
            viewConfiguredDocumentLinkButton.Click += OnViewDocumentLinkClick;
        }

        private void OnViewDocumentLinkClick(object sender, EventArgs e)
        {
            if (ViewDocumentLinkClicked != null)
            {
                ConfiguredDocumentLink link = (ConfiguredDocumentLink) configuredDocumentLinkComboBox.SelectedItem;
                ViewDocumentLinkClicked(link);
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

        void saveButton_Click(object sender, EventArgs e)
        {
                if (SaveButtonClicked != null)
                {
                    SaveButtonClicked(sender, e);
                }
        }

        void cancelButton_Click(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        void ConfinedSpaceForm_Load(object sender, EventArgs e)
        {
            if (FormLoad != null)
            {
                FormLoad();
            }
        }
                
        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public void SetErrorForNoFunctionalLocation()
        {
            errorProvider.SetError(functionalLocationBrowseButton, StringResources.MontrealWorkPermit_FlocEmptyError);
        }

        public void SetErrorForStartDateTimeAfterEndDateTime()
        {
            errorProvider.SetError(startTimePicker, StringResources.StartDateBeforeEndDate);
        }

        public void SetErrorForEndDateMustBeonOrAfterTodayError()
        {
            errorProvider.SetError(endTimePicker, StringResources.DateCannotBeInThePast);
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

        public void SetErrorForAutreConditions()
        {
            autresConditionsDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MontrealWorkPermit_Autres));
        }

    }
}
