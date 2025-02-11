﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.Office.Utils;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfinedSpaceFormMuds : BaseForm, IConfinedSpaceViewMuds
    {
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action FormLoad;
        public event Action FunctionalLocationSelector;
        public event Action PreparationCheckChanged;
        public event Action<ConfiguredDocumentLink> ViewDocumentLinkClicked;
        public event Action<ConfiguredDocumentLink> ViewPssClicked;
        public event Action WorkPermitTypeChanged;
       // public event Action   OnSelectedWorkPermitTypeChange;
       // public event Action  OnSelectedWorkPermitTypeChange;
        List<GasTestElementInfo> standardGasTestElementInfoList1;

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
        //--- New attributes

        public bool SO2
        {
            get { return so2BooleanControl.Value.Value; }
            set { so2BooleanControl.Value = CreateVisible(value); }
        }
        public bool NH3
        {
            get { return nh3BooleanControl.Value.Value; }
            set { nh3BooleanControl.Value = CreateVisible(value); }
        }
        public bool AcideSulfurique
        {
            get { return acidicSFBooleanControl.Value.Value; }
            set { acidicSFBooleanControl.Value = CreateVisible(value); }
        }
        public bool CO
        {
            get { return coBooleanControl.Value.Value; }
            set { coBooleanControl.Value = CreateVisible(value); }
        }
        public bool Azote
        {
            get { return azoteBooleanControl.Value.Value; }
            set { azoteBooleanControl.Value = CreateVisible(value); }
        }
        public bool Reflux
        {
            get { return refluxBooleanControl.Value.Value; }
            set { refluxBooleanControl.Value = CreateVisible(value); }
        }
        public bool NaOH
        {
            get { return naOhBooleanControl.Value.Value; }
            set { naOhBooleanControl.Value = CreateVisible(value); }
        }
        public bool SBS
        {
            get { return sbsBooleanControl.Value.Value; }
            set { sbsBooleanControl.Value = CreateVisible(value); }
        }
        public bool Soufre
        {
            get { return soufreBooleanControl.Value.Value; }
            set { soufreBooleanControl.Value = CreateVisible(value); }
        }
        public bool Amiante
        {
            get { return amianteBooleanControl.Value.Value; }
            set { amianteBooleanControl.Value = CreateVisible(value); }
        }
        public bool Bacteries
        {
            get { return bacteriesBooleanControl.Value.Value; }
            set { bacteriesBooleanControl.Value = CreateVisible(value); }
        }

        public bool Depressurise
        {
            get { return depressuriseBooleanControl.Value.Value; }
            set { depressuriseBooleanControl.Value = CreateVisible(value); }
        }
        public bool Rince
        {
            get { return rinceBooleanControl.Value.Value; }
            set { rinceBooleanControl.Value = CreateVisible(value); }
        }
        public bool Obture
        {
            get { return obtureBooleanControl.Value.Value; }
            set { obtureBooleanControl.Value = CreateVisible(value); }
        }
        public bool Nettoyes
        {
            get { return nettoyesBooleanControl.Value.Value; }
            set { nettoyesBooleanControl.Value = CreateVisible(value); }
        }
        public bool Purge
        {
            get { return purgeBooleanControl.Value.Value; }
            set { purgeBooleanControl.Value = CreateVisible(value); }
        }
        public bool Vide
        {
            get { return videBooleanControl.Value.Value; }
            set { videBooleanControl.Value = CreateVisible(value); }
        }
        public bool Dessins 
        {
            get { return dessinsBooleanControl.Value.Value; }
            set { dessinsBooleanControl.Value = CreateVisible(value); }
        }
        public bool DetectionDeGaz
        {
            get { return detectionGazBooleanControl.Value.Value; }
            set { detectionGazBooleanControl.Value = CreateVisible(value); }
        }
        public bool PSS
        {
            get { return pssBooleanControl.Value.Value; }
            set { pssBooleanControl.Value = CreateVisible(value); }
        }
        public bool VentilationEn
        {
            get { return ventillationBooleanControl.Value.Value; }
            set { ventillationBooleanControl.Value = CreateVisible(value); }
        }
        public bool VentilationForce
        {
            get { return ventilationForceBooleanControl.Value.Value; }
            set { ventilationForceBooleanControl.Value = CreateVisible(value); }
        }
        public bool Harnis
        {
            get { return harnisBooleanControl.Value.Value; }
            set { harnisBooleanControl.Value = CreateVisible(value); }
        }
        
        //-----
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
        //Added by ppanigrahi

        
        //private void OnSelectedWorkPermitTypeChange(object sender, EventArgs e)
        //{
        //    if (WorkPermitTypeChanged != null)
        //    {
        //        WorkPermitTypeChanged();
        //    }
        //    if (Convert.ToString(permitTypeComboBox.SelectedItem) == WorkPermitMudsType.ELEVATED_HOT.ToString())
        //    {

        //        EnbaleGasTest(true);

        //    }
        //    if(Convert.ToString(permitTypeComboBox.SelectedItem) == WorkPermitMudsType.MODERATE_HOT.ToString())
        //    {
               
        //        EnbaleGasTest(false);
        //    }
        //}

        public Time FirtTestResult
        {
            set
            {
                gasTestElementInfoTableLayoutPanel.ImmediateAreaTime = value;
            }
            get
            {
                return gasTestElementInfoTableLayoutPanel.ImmediateAreaTime;
            }
        }

        public Time SecondTestResult
        {
            set
            {
                gasTestElementInfoTableLayoutPanel.ConfinedSpaceTime = value;
            }
            get
            {
                return gasTestElementInfoTableLayoutPanel.ConfinedSpaceTime;
            }
        }


        public Time ThirdTestResult
        {
            set
            {
                gasTestElementInfoTableLayoutPanel.ThirdResultTime = value;
            }
            get
            {
                return gasTestElementInfoTableLayoutPanel.ThirdResultTime;
            }
        }

        public Time FourthTestResult
        {
            set
            {
                gasTestElementInfoTableLayoutPanel.FourthResultTime = value;
            }
            get
            {
                return gasTestElementInfoTableLayoutPanel.FourthResultTime;
            }
        }

        public FunctionalLocation ShowFunctionalLocationSelector()
        {
            ISingleSelectFunctionalLocationSelectionForm functionalLocationSelectionForm =
                new SingleSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1));

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

        public ConfinedSpaceFormMuds()
        {
            InitializeComponent();
            Load += ConfinedSpaceFormMuds_Load;
            cancelButton.Click += cancelButton_Click;
            saveButton.Click += saveButton_Click;
            functionalLocationBrowseButton.Click += OnFunctionalLocationClick;
            preparationCheckBox.Click += OnPreparationChange;
            viewConfiguredDocumentLinkButton.Click += OnViewDocumentLinkClick;
            viewPSSLinkButton.Click += OnViewPssClick;
            //permitTypeComboBox.SelectedValueChanged +=OnSelectedWorkPermitTypeChange;
            //permitTypeComboBox.SelectedIndexChanged +=OnSelectedWorkPermitTypeChange;
        }

        private void OnViewDocumentLinkClick(object sender, EventArgs e)
        {
            if (ViewDocumentLinkClicked != null)
            {
                ConfiguredDocumentLink link = (ConfiguredDocumentLink) configuredDocumentLinkComboBox.SelectedItem;
                ViewDocumentLinkClicked(link);
            }
        }

        private void OnViewPssClick(object sender, EventArgs e)
        {
            ////if (ViewPssClicked != null)
            ////{
            ////    ConfiguredDocumentLink link = (ConfiguredDocumentLink)configuredDocumentLinkComboBox.SelectedItem;
            ////    ViewPssClicked(link);
            ////}


            //OpenFileDialog openFileDialog1 = new OpenFileDialog
            //{
            //    InitialDirectory = @"C:\", // can change directory
            //    Title = "Browse Files",

            //    CheckFileExists = true,
            //    CheckPathExists = true,

            //    DefaultExt = "txt",
            //    Filter = "pdf files (*.pdf)|*.pdf",
            //    FilterIndex = 2,
            //    RestoreDirectory = true,

            //    ReadOnlyChecked = true,
            //    ShowReadOnly = true
            //};

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    pssPath.Text = openFileDialog1.FileName;
            //}  
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

        void ConfinedSpaceFormMuds_Load(object sender, EventArgs e)
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

        private void gasTestElementInfoTableLayoutPanel_Load(object sender, EventArgs e)
        {

        }
        //Added by ppanigrahi
        public string ClonedFormDetailMuds { get; set; }

        //public List<WorkPermitMudsType> PermitTypes
        //{
        //    set
        //    {
        //        permitTypeComboBox.SelectedValueChanged -=OnSelectedWorkPermitTypeChange ;

        //        permitTypeComboBox.DataSource = value;
        //        permitTypeComboBox.DisplayMember = "Name";

        //        permitTypeComboBox.SelectedValueChanged += OnSelectedWorkPermitTypeChange;
        //    }
        //}

        //public WorkPermitMudsType SelectedPermitType
        //{
        //    get
        //    {
        //        object selectedItem = permitTypeComboBox.SelectedItem;
        //        return (WorkPermitMudsType)selectedItem;
        //    }
        //    set
        //    {
        //        permitTypeComboBox.SelectedValueChanged -= OnSelectedWorkPermitTypeChange;

        //        permitTypeComboBox.SelectedItem = value;

        //        permitTypeComboBox.SelectedValueChanged += OnSelectedWorkPermitTypeChange;
        //    }
        //}
        public void InitializeStandardGasTestElementInfoList(List<GasTestElementInfo> standardGasTestElementInfoList)
        {
            SuspendLayout();
            //gasTestInfoExplorerBarContainerControl.SuspendLayout();
            gasTestElementInfoTableLayoutPanel.showonlyFirstColum = true;
            gasTestElementInfoTableLayoutPanel.BuildGasTestElementControls(standardGasTestElementInfoList,
                ClientSession.GetUserContext().Site);
            //gasTestInfoExplorerBarContainerControl.ResumeLayout();
            ResumeLayout();
            standardGasTestElementInfoList1 = standardGasTestElementInfoList;
            gasTestElementInfoTableLayoutPanel.DisbaleFirstTime = false;
        }

        public List<GasTestElementDetailsMuds> GasTestElementDetailsList
        {
            get
            {
                return gasTestElementInfoTableLayoutPanel.GasTestElementDetailsList;
            }
        }
        public void EnbaleGasTest(bool val)
        {
            if (!val)
            {
                gasTestTestResultsGroupBox.Enabled = false;
                gasTestElementInfoTableLayoutPanel.ImmediateAreaTime = null;
                gasTestElementInfoTableLayoutPanel.ConfinedSpaceTime = null;
                gasTestElementInfoTableLayoutPanel.ThirdResultTime = null;
                gasTestElementInfoTableLayoutPanel.FourthResultTime = null;
                foreach (GasTestElementDetailsMuds Details in GasTestElementDetailsList)
                {
                    Details.ConfinedSpaceTestRequired = false;
                    Details.ImmediateAreaTestRequired = false;
                    Details.ThirdTestRequired = false;
                    Details.FourthTestRequired = false;
                    Details.ThirdTestResult = null;
                    Details.FourthTestResult = null;
                    Details.ConfinedSpaceTestResult = null;
                    Details.ImmediateAreaTestResult = null;
                }
            }
            else
            {
                gasTestTestResultsGroupBox.Enabled = true;

            }
        }

       

    }
}
