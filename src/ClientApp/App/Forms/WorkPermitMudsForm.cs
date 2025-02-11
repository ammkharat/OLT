﻿using System;
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
    public partial class WorkPermitMudsForm : BaseForm, IWorkPermitMudsFormView
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
        //public event Action<string> AutresSubstancesTextValueChanged;
        public event Action DocumentLinkOpened;
        public event Action DocumentLinkAdded;

        public event Action UtilisationElectronicsChanged;
        List<GasTestElementInfo> standardGasTestElementInfoList1;
        public WorkPermitMudsForm()
        {
            InitializeComponent();
            travauxDansZoneBooleanControl.Label = "Travaux dans la zone permissive\r\n" +
                                                  "1-Aucun surveillant Incendie. 2-Aucun radio.\r\n" +
                                                  "3-Aucune détection de gaz effectuée par l’opération";
            //remplirLeFormulaireDeConditionStringControl.


            outilDeLaitonDropDownControl.Visible = false;
            //this.Text = "Permis de travail";
            requestDetailsControl.Visible = false;

            // Do this here instead of the designer because for some reason, the templatable controls
            // don't respond properly when the scroll bar appears/disappears.
            workPermitContentsPanel.AutoScroll = true;

            RegisterEventHandlersOnPresenter();

// Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

            oltQuestionLabel.Text = ClientSession.GetUserContext().SiteConfiguration.SetWorkPermitQuestionForMudsSite;

        }


        private void RegisterEventHandlersOnPresenter()
        {
            Load += WorkPermitMudsFormLoad;
//Added By Vibhor : RITM0556998 - To lock the scroll for Dropdown. When any dropdown value is selected, lock its value for mouse scroll.

            permitTypeComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            permitTemplateComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            requestedByComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            companyComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            companyComboBox_1.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            companyComboBox_2.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            autresTravauxDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            autresInstructionDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            autresConditionsDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            appareilDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            electriciteVoltDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            autresRisquesDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            appareilRespiratoireDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            gantsDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            epiAntiArcCatDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            habitProtecteurDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            perimetreSecuriteDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            autresEquipmentsPreventionDropDownControl.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);


            permitTypeComboBox.SelectedValueChanged += OnSelectedWorkPermitTypeChange;
            permitTypeComboBox.SelectedIndexChanged += OnSelectedWorkPermitTypeChange;

            permitTemplateComboBox.SelectedValueChanged += OnSelectedPermitTemplateChange;

            functionalLocationBrowseButton.Click += OnFunctionalLocationClick;

            preparationCheckBox.Click += OnPreparationChange;

            saveButton.Click += OnSaveAndCloseButton_Clicked;
            cancelButton.Click += OnCancelButton_Clicked;

            viewDocumentLinkButton.Click += OnViewDocumentLinkClick;
            confinedSpaceButton.Click += OnConfinedSpaceButtonClick;

            startDatePicker.ValueChanged += OnStartOrEndDateTimeValueChanged;
            startTimePicker.ValueChanged += OnStartOrEndDateTimeValueChanged;
            endDatePicker.ValueChanged += OnStartOrEndDateTimeValueChanged;
            endTimePicker.ValueChanged += OnStartOrEndDateTimeValueChanged;

            //autresSubstancesDropDownControl.TextValueChanged += HandleAutresSubstancesDropDownControlTextValueChanged;

            documentLinksControl.LinkOpened += () => DocumentLinkOpened();
            documentLinksControl.LinkAdded += () => DocumentLinkAdded();
            
            utilisationElectronicsBooleanControl.CheckedChanged += utilisationElectronicsBooleanControl_CheckedChanged;
        }

        void utilisationElectronicsBooleanControl_CheckedChanged()
        {
            if (UtilisationElectronicsChanged != null)
            {
                UtilisationElectronicsChanged();
            }
        }

       

        //private void HandleAutresSubstancesDropDownControlTextValueChanged(string value)
        //{
        //    if (AutresSubstancesTextValueChanged != null)
        //    {
        //        AutresSubstancesTextValueChanged(value);
        //    }
        //}

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
                var a = gasTestElementInfoTableLayoutPanel.GasTestElementDetailsList;
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
            if (Convert.ToString(permitTypeComboBox.SelectedItem) == WorkPermitMudsType.ELEVATED_HOT.ToString())
            {
                eHotGroupBox.Enabled = true;
                modHotGroupBox.Enabled = false;
                surveilantTextBox.Visible = true;
                surveilantLabel.Visible = true;
                EnbaleGasTest(true);

            }
            else if (Convert.ToString(permitTypeComboBox.SelectedItem) == WorkPermitMudsType.MODERATE_HOT.ToString())
            {
                eHotGroupBox.Enabled = false;
                modHotGroupBox.Enabled = true;
                surveilantTextBox.Visible = false;
                surveilantLabel.Visible = false;
                EnbaleGasTest(false);
            }
            else
            {
                eHotGroupBox.Enabled = false;
                modHotGroupBox.Enabled = false;
            }

            outilDeLaitonDropDownControl.Visible = false;
        }
        
        void WorkPermitMudsFormLoad(object sender, EventArgs e)
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
                //tradeComboBox.DataSource = value;
                //tradeComboBox.DisplayMember = "Name";
            }
        }

        public List<WorkPermitMudsType> PermitTypes
        {
            set
            {
                permitTypeComboBox.SelectedValueChanged -= OnSelectedWorkPermitTypeChange;

                permitTypeComboBox.DataSource = value;
                permitTypeComboBox.DisplayMember = "Name";

                permitTypeComboBox.SelectedValueChanged += OnSelectedWorkPermitTypeChange;
            }
        }

        public WorkPermitMudsType SelectedPermitType
        {
            get
            {
                object selectedItem = permitTypeComboBox.SelectedItem;
                return (WorkPermitMudsType)selectedItem;
            }
            set
            {
                permitTypeComboBox.SelectedValueChanged -= OnSelectedWorkPermitTypeChange;

                permitTypeComboBox.SelectedItem = value;

                permitTypeComboBox.SelectedValueChanged += OnSelectedWorkPermitTypeChange;
            }
        }

        public List<WorkPermitMudsTemplate> PermitTemplates
        {
            set
            {
                permitTemplateComboBox.SelectedValueChanged -= OnSelectedPermitTemplateChange;

                permitTemplateComboBox.DataSource = value;
                permitTemplateComboBox.DisplayMember = "DisplayName";

                permitTemplateComboBox.SelectedValueChanged += OnSelectedPermitTemplateChange;
            }
        }
        
        public WorkPermitMudsTemplate SelectedPermitTemplate
        {
            get
            {
                
                object selectedItem = permitTemplateComboBox.SelectedItem;
                return (WorkPermitMudsTemplate)selectedItem;
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

        public List<WorkPermitMudsGroup> RequestedByGroupValues
        {
            set
            {
                requestedByComboBox.DataSource = value;
                requestedByComboBox.DisplayMember = "Name";
            }
        }

        public WorkPermitMudsGroup SelectedRequestedByGroup
        {
            get { return (WorkPermitMudsGroup)requestedByComboBox.SelectedItem; }
            set { requestedByComboBox.SelectedItem = value; }
        }

        public string SelectedRequestedByGroupText
        {
            get { return requestedByComboBox.Text; }
            set { requestedByComboBox.Text = value; }
        }

        public List<FunctionalLocation> ShowFunctionalLocationSelector(List<FunctionalLocation> selectedFlocs)
        {
            IMultiSelectFunctionalLocationSelectionForm functionalLocationSelectionForm =
                new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1), true);

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
            //TODO
            //get { return tradeComboBox.Text; }
            //set { tradeComboBox.Text = value; }
            get { return ""; }
            set { value = value; }
        }

        public string Company
        {
            get { return companyComboBox.Text.EmptyToNull(); }
            set { companyComboBox.Text = value; }
        }

        public List<Contractor> AllCompanies
        {
            set
            {
                companyComboBox.DataSource = value;
                companyComboBox.DisplayMember = "CompanyName";
            }
        }

// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public string Company_1
        {
            get { return companyComboBox_1.Text.EmptyToNull(); }
            set { companyComboBox_1.Text = value; }
        }

        public List<Contractor> AllCompanies_1
        {
            set
            {
                companyComboBox_1.DataSource = value;
                companyComboBox_1.DisplayMember = "CompanyName_1";
            }
        }

        public string Company_2
        {
            get { return companyComboBox_2.Text.EmptyToNull(); }
            set { companyComboBox_2.Text = value; }
        }

        public List<Contractor> AllCompanies_2
        {
            set
            {
                companyComboBox_2.DataSource = value;
                companyComboBox_2.DisplayMember = "CompanyName_2";
            }
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

        public string NbTravail
        {
            get { return nbTravailTextbox.Text; }
            set { nbTravailTextbox.Text = value; }
        }

        public bool FormationCheck
        {
            get { return formationCheckBox.Checked; }
            set { formationCheckBox.Checked = value; }
        }

        public string NomsEnt
        {
            get { return nomsTextBox.Text; }
            set { nomsTextBox.Text = value; }
        }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public string NomsEnt_1
        {
            get { return nomsTextBox_1.Text; }
            set { nomsTextBox_1.Text = value; }
        }
        public string NomsEnt_2
        {
            get { return nomsTextBox_2.Text; }
            set { nomsTextBox_2.Text = value; }
        }
        public string NomsEnt_3
        {
            get { return nomsTextBox_3.Text; }
            set { nomsTextBox_3.Text = value; }
        }


        public string Surveilant
        {
            get { return surveilantTextBox.Text; }
            set { surveilantTextBox.Text = value; }
        }

        #region get/set for stuff outside of basic

        public Visible<TernaryString> RemplirLeFormulaireDeCondition
        {
            get { return remplirLeFormulaireDeConditionStringControl.Value; }
            set { remplirLeFormulaireDeConditionStringControl.Value = value; }
        }
        //public Visible<bool> RemplirLeFormulaireDeConditionValue
        //{

        //}
        public Visible<bool> AnalyseCritiqueDeLaTache
        {
            get { return analyseCritiqueDeLaTacheBooleanControl.Value; }
            set { analyseCritiqueDeLaTacheBooleanControl.Value = value; }
        }
        public Visible<bool> Depressurises
        {
            get { return depressurisesBooleanControl.Value; }
            set { depressurisesBooleanControl.Value = value; }
        }
        public Visible<bool> Vides
        {
            get { return videsBooleanControl.Value; }
            set { videsBooleanControl.Value = value; }
        }
        public Visible<bool> ContournementDesGda
        {
            get { return contournementDesGdaBooleanControl.Value; }
            set { contournementDesGdaBooleanControl.Value = value; }
        }
        public Visible<bool> Rinces
        {
            get { return rincesBooleanControl.Value; }
            set { rincesBooleanControl.Value = value; }
        }
        public Visible<bool> NettoyesLaVapeur
        {
            get { return nettoyesLaVapeurBooleanControl.Value; }
            set { nettoyesLaVapeurBooleanControl.Value = value; }
        }
        public Visible<bool> Purges
        {
            get { return purgesBooleanControl.Value; }
            set { purgesBooleanControl.Value = value; }
        }
        public Visible<bool> Ventiles
        {
            get { return ventilesBooleanControl.Value; }
            set { ventilesBooleanControl.Value = value; }
        }
        public Visible<bool> Aeres
        {
            get { return aeresBooleanControl.Value; }
            set { aeresBooleanControl.Value = value; }
        }
        public Visible<bool> Energies // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        {
            get { return energieBooleanControl.Value; }
            set { energieBooleanControl.Value = value; }
        }
        
        public Visible<TernaryString> InterrupteursEtVannesCadenasses
        {
            get { return interrupteursEtVannesCadenassesStringControl.Value; }
            set { interrupteursEtVannesCadenassesStringControl.Value = value; }
        }
        public Visible<bool> VerrouillagesParTravailleurs
        {
            get { return verrouillagesParTravailleursBooleanControl.Value; }
            set { verrouillagesParTravailleursBooleanControl.Value = value; }
        }
        public Visible<bool> SourcesDesenergisees
        {
            get { return sourcesDesenergiseesBooleanControl.Value; }
            set { sourcesDesenergiseesBooleanControl.Value = value; }
        }
        public Visible<bool> DepartsLocauxTestes
        {
            get { return departsLocauxTestesBooleanControl.Value; }
            set { departsLocauxTestesBooleanControl.Value = value; }
        }
        public Visible<bool> ConduitesDesaccouplees
        {
            get { return conduitesDesaccoupleesBooleanControl.Value; }
            set { conduitesDesaccoupleesBooleanControl.Value = value; }
        }
        public Visible<bool> ObturateursInstallees
        {
            get { return obturateursInstalleesBooleanControl.Value; }
            set { obturateursInstalleesBooleanControl.Value = value; }
        }
        public Visible<bool> PvciSuncorEffectuee
        {
            get { return pvciSuncorEffectueeBooleanControl.Value; }
            set { pvciSuncorEffectueeBooleanControl.Value = value; }
        }
        public Visible<bool> PvciEntExtEffectuee
        {
            get { return pvciEntExtEffectueeBooleanControl.Value; }
            set { pvciEntExtEffectueeBooleanControl.Value = value; }
        }
        public Visible<bool> Amiante
        {
            get { return amianteBooleanControl.Value; }
            set { amianteBooleanControl.Value = value; }
        }
        public Visible<bool> AcideSulfurique
        {
            get { return acideSulfuriqueBooleanControl.Value; }
            set { acideSulfuriqueBooleanControl.Value = value; }
        }
        public Visible<bool> Azote
        {
            get { return azoteBooleanControl.Value; }
            set { azoteBooleanControl.Value = value; }
        }
        public Visible<bool> Caustique
        {
            get { return caustiqueBooleanControl.Value; }
            set { caustiqueBooleanControl.Value = value; }
        }
        public Visible<bool> DioxydeDeSoufre
        {
            get { return dioxydeDeSoufreBooleanControl.Value; }
            set { dioxydeDeSoufreBooleanControl.Value = value; }
        }
        public Visible<bool> Sbs
        {
            get { return sBSBooleanControl.Value; }
            set { sBSBooleanControl.Value = value; }
        }
        public Visible<bool> Soufre
        {
            get { return soufreBooleanControl.Value; }
            set { soufreBooleanControl.Value = value; }
        }
        public Visible<bool> EquipementsNonRinces
        {
            get { return equipementsNonRincesBooleanControl.Value; }
            set { equipementsNonRincesBooleanControl.Value = value; }
        }
        public Visible<bool> Hydrocarbures
        {
            get { return hydrocarburesBooleanControl.Value; }
            set { hydrocarburesBooleanControl.Value = value; }
        }
        public Visible<bool> HydrogeneSulfure
        {
            get { return hydrogeneSulfureBooleanControl.Value; }
            set { hydrogeneSulfureBooleanControl.Value = value; }
        }
        public Visible<bool> MonoxydeCarbone
        {
            get { return monoxydeCarboneBooleanControl.Value; }
            set { monoxydeCarboneBooleanControl.Value = value; }
        }
        public Visible<bool> Reflux
        {
            get { return refluxBooleanControl.Value; }
            set { refluxBooleanControl.Value = value; }
        }
        public Visible<bool> ProduitsVolatilsUtilises
        {
            get { return produitsVolatilsUtilisesBooleanControl.Value; }
            set { produitsVolatilsUtilisesBooleanControl.Value = value; }
        }
        public Visible<bool> Bacteries
        {
            get { return bacteriesBooleanControl.Value; }
            set { bacteriesBooleanControl.Value = value; }
        }
       
        public Visible<bool> InterferencesEntreTravaux
        {
            get { return interferencesEntreTravauxBooleanControl.Value; }
            set { interferencesEntreTravauxBooleanControl.Value = value; }
        }
        public Visible<bool> PiecesEnRotation
        {
            get { return piecesEnRotationBooleanControl.Value; }
            set { piecesEnRotationBooleanControl.Value = value; }
        }
        public Visible<bool> IncendieExplosion
        {
            get { return incendieExplosionBooleanControl.Value; }
            set { incendieExplosionBooleanControl.Value = value; }
        }
        public Visible<bool> ContrainteThermique
        {
            get { return contrainteThermiqueBooleanControl.Value; }
            set { contrainteThermiqueBooleanControl.Value = value; }
        }
        public Visible<bool> Radiations
        {
            get { return radiationsBooleanControl.Value; }
            set { radiationsBooleanControl.Value = value; }
        }
        public Visible<bool> Silice
        {
            get { return siliceBooleanControl.Value; }
            set { siliceBooleanControl.Value = value; }
        }
        public Visible<bool> Vanadium
        {
            get { return vanadiumBooleanControl.Value; }
            set { vanadiumBooleanControl.Value = value; }
        }
        public Visible<bool> AsphyxieIntoxication
        {
            get { return asphyxieIntoxicationBooleanControl.Value; }
            set { asphyxieIntoxicationBooleanControl.Value = value; }
        }
        
        public Visible<bool> TravailEnHauteur6EtPlus
        {
            get { return travailEnHauteur6EtPlusBooleanControl.Value; }
            set { travailEnHauteur6EtPlusBooleanControl.Value = value; }
        }
		// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

        public Visible<bool> VapeurCondensat
        {
            get { return VapeurCondensattemplatableBooleanControl1.Value; }
            set { VapeurCondensattemplatableBooleanControl1.Value = value; }
        }

        public Visible<bool> FeSValue
        {
            get { return FeS.Value; }
            set { FeS.Value = value; }
        }

        public Visible<bool> Electrisation
        {
            get { return electrisationBooleanControl.Value; }
            set { electrisationBooleanControl.Value = value; }
        }
        public Visible<bool> LunettesMonocoques
        {
            get { return lunettes_MonocoquesBooleanControl.Value; }
            set { lunettes_MonocoquesBooleanControl.Value = value; }
        }
        public Visible<bool> Visiere
        {
            get { return visiereBooleanControl.Value; }
            set { visiereBooleanControl.Value = value; }
        }
        public Visible<bool> ProtectionAuditive
        {
            get { return protection_AuditiveBooleanControl.Value; }
            set { protection_AuditiveBooleanControl.Value = value; }
        }
        
        public Visible<bool> CagouleIgnifuge
        {
            get { return cagouleIgnifugeBooleanControl.Value; }
            set { cagouleIgnifugeBooleanControl.Value = value; }
        }
        public Visible<bool> Harnais2LiensDeRetenue
        {
            get { return harnais2LiensDeRetenueBooleanControl.Value; }
            set { harnais2LiensDeRetenueBooleanControl.Value = value; }
        }

        //public Visible<TernaryString> MasqueACartouches
        //{
        //    get { return masqueACartouchesStringControl.Value; }
        //    set { masqueACartouchesStringControl.Value = value; }
        //}

        public Visible<bool> EpiAntiChoc
        {
            get { return ePIAntiChocBooleanControl.Value; }
            set { ePIAntiChocBooleanControl.Value = value; }
        }
        
        public Visible<bool> EcranDeflecteur
        {
            get { return ecranDeflecteurBooleanControl.Value; }
            set { ecranDeflecteurBooleanControl.Value = value; }
        }
        public Visible<bool> MaltDesEquipements
        {
            get { return mALTDesEquipementsBooleanControl.Value; }
            set { mALTDesEquipementsBooleanControl.Value = value; }
        }
        public Visible<bool> Rallonges
        {
            get { return rallongesBooleanControl.Value; }
            set { rallongesBooleanControl.Value = value; }
        }
        public Visible<bool> ApprobationPourEquipDeLevage
        {
            get { return approbationPourEquipDeLevageBooleanControl.Value; }
            set { approbationPourEquipDeLevageBooleanControl.Value = value; }
        }
        public Visible<bool> BarricadeRigide
        {
            get { return barricadeRigideBooleanControl.Value; }
            set { barricadeRigideBooleanControl.Value = value; }
        }
       
        public Visible<TernaryString> AlarmeDcs
        {
            get { return alarmeDCSStringControl.Value; }
            set { alarmeDCSStringControl.Value = value; }
        }
        public Visible<bool> EchelleSecurisee
        {
            get { return echelleSecuriseeBooleanControl.Value; }
            set { echelleSecuriseeBooleanControl.Value = value; }
        }
        public Visible<bool> EchafaudageApprouve
        {
            get { return echafaudageApprouveBooleanControl.Value; }
            set { echafaudageApprouveBooleanControl.Value = value; }
        }

       
        public Visible<bool> Radio
        {
            get { return radioBooleanControl.Value; }
            set { radioBooleanControl.Value = value; }
        }

        public Visible<bool> EffondrementEnsevelissement
        {
            get { return effondrementEnsevelissementBooleanControl.Value; }
            set { effondrementEnsevelissementBooleanControl.Value = value; }
        }

     
        public Visible<TernaryString> AutresConditions
        {
            get { return autresConditionsDropDownControl.Value; }
            set { autresConditionsDropDownControl.Value = value; }
        }

        public List<String> AutresConditionsValues
        {
            set { autresConditionsDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> AutresRisques
        {
            get { return autresRisquesDropDownControl.Value; }
            set { autresRisquesDropDownControl.Value = value; }
        }

        public List<String> AutresRisquesValues
        {
            set { autresRisquesDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> ElectronicVoltRisques
        {
            get { return electriciteVoltDropDownControl.Value; }
            set { electriciteVoltDropDownControl.Value = value; }
        }

        public List<String> ElectronicVoltRisquesValues
        {
            set { electriciteVoltDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> GantsEquipementDeProtection
        {
            get { return gantsDropDownControl.Value; }
            set { gantsDropDownControl.Value = value; }
        }

        public List<String> GantsEquipementDeProtectionValues
        {
            set { gantsDropDownControl.DataSource = value; }
        }
        
        public Visible<TernaryString> HabitProtecteurEquipementDeProtection
        {
            get { return habitProtecteurDropDownControl.Value; }
            set { habitProtecteurDropDownControl.Value = value; }
        }

        public List<String> HabitProtecteurEquipementDeProtectionValues
        {
            set { habitProtecteurDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> EpiAntiArcCatProtecteurEquipementDeProtection
        {
            get { return epiAntiArcCatDropDownControl.Value; }
            set { epiAntiArcCatDropDownControl.Value = value; }
        }

        public List<String> EpiAntiArcCatProtecteurEquipementDeProtectionValues
        {
            set { epiAntiArcCatDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> AppareilProtecteurEquipementDeProtection
        {
            get { return appareilDropDownControl.Value; }
            set { appareilDropDownControl.Value = value; }
        }

        public List<String> AppareilProtecteurEquipementDeProtectionValues
        {
            set { appareilDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> AutresEquipementDePrevention
        {
            get { return autresEquipmentsPreventionDropDownControl.Value; }
            set { autresEquipmentsPreventionDropDownControl.Value = value; }
        }

        public List<String> AutresEquipementDePreventionValues
        {
            set { autresEquipmentsPreventionDropDownControl.DataSource = value; }
        }

        // This is for OutilManuelEquipementDePrevention
        public Visible<bool> OutilDeLaiton // Outillage électrique/ à batterie
        {
            get { return OutillageElectriqueBooleanControl.Value; }
            set { OutillageElectriqueBooleanControl.Value = value; }
        }


        public Visible<bool> OutilDeLaitonPrevention
        {
            get { return outilDeLaitonBooleanControl.Value; }
            set { outilDeLaitonBooleanControl.Value = value; }
        }
        


        //This is for outilDeLaitonDropDownControl
        public Visible<TernaryString> OutilManuelEquipementDePrevention
        {
            get { return outilDeLaitonDropDownControl.Value; }
            set { outilDeLaitonDropDownControl.Value = value; }
        }

        public List<String> OutilManuelEquipementDePreventionValues
        {
            set { outilDeLaitonDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> PerimetreDeSecurityEquipementDePrevention
        {
            get { return perimetreSecuriteDropDownControl.Value; }
            set { perimetreSecuriteDropDownControl.Value = value; }
        }

        public List<String> PerimetreDeSecurityEquipementDePreventionValues
        {
            set { perimetreSecuriteDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> AppareilEquipementDePrevention  
        {
            get { return appareilRespiratoireDropDownControl.Value; }
            set { appareilRespiratoireDropDownControl.Value = value; }
        }

        public List<String> AppareilEquipementDePreventionValues
        {
            set { appareilRespiratoireDropDownControl.DataSource = value; }
        }

        public Visible<TernaryString> AutresTravaux
        {
            get { return autresTravauxDropDownControl.Value; }
            set { autresTravauxDropDownControl.Value = value; }
        }

        public List<String> AutresTravauxValues
        {
            set { autresTravauxDropDownControl.DataSource = value; }
        }
        
        public Visible<TernaryString> AutresInstruction
        {
            get { return autresInstructionDropDownControl.Value; }
            set { autresInstructionDropDownControl.Value = value; }
        }
        public List<String> AutresInstructionValues
        {
            set { autresInstructionDropDownControl.DataSource = value; }
        }

        public Visible<bool> MhAutres //Autres Instruction if no DDl - currently is visible false
        {
            get { return mhAutresBooleanControl.Value; }
            set { mhAutresBooleanControl.Value = value; }
        }

        public Visible<TernaryString> ProcedureEntretien
        {
            get { return procedureStringControl.Value; }
            set { procedureStringControl.Value = value; }
        }
        public Visible<TernaryString> EtiquettObturateur
        {
            get { return etiquetteStringControl.Value; }
            set { etiquetteStringControl.Value = value; }
        }
        public Visible<bool> MasqueSoudeur
        {
            get { return masqueBooleanControl.Value; }
            set { masqueBooleanControl.Value = value; }
        }
        
        //E Hot and M Hot controls

        public Visible<bool> Soudage
        {
            get { return soudageBooleanControl.Value; }
            set { soudageBooleanControl.Value = value; }
        }
        public Visible<bool> Traitement
        {
            get { return traitementBooleanControl.Value; }
            set { traitementBooleanControl.Value = value; }
        }
        public Visible<bool> Cuissons
        {
            get { return cuissonsBooleanControl.Value; }
            set { cuissonsBooleanControl.Value = value; }
        }
        public Visible<bool> Perçage
        {
            get { return perçageBooleanControl.Value; }
            set { perçageBooleanControl.Value = value; }
        }
        public Visible<bool> Chaufferette
        {
            get { return chaufferetteBooleanControl.Value; }
            set { chaufferetteBooleanControl.Value = value; }
        }
        public Visible<bool> Meulage
        {
            get { return meulageBooleanControl.Value; }
            set { meulageBooleanControl.Value = value; }
        }
        public Visible<bool> Nettoyage
        {
            get { return nettoyageBooleanControl.Value; }
            set { nettoyageBooleanControl.Value = value; }
        }
        public Visible<bool> TravauxDansZone
        {
            get { return travauxDansZoneBooleanControl.Value; }
            set { travauxDansZoneBooleanControl.Value = value; }
        }
        public Visible<bool> Combustibles
        {
            get { return combustiblesBooleanControl.Value; }
            set { combustiblesBooleanControl.Value = value; }
        }
        public Visible<bool> Ecran
        {
            get { return ecranBooleanControl.Value; }
            set { ecranBooleanControl.Value = value; }
        }
        public Visible<bool> Boyau
        {
            get { return boyauBooleanControl.Value; }
            set { boyauBooleanControl.Value = value; }
        }
        public Visible<bool> BoyauDe
        {
            get { return boyauDeBooleanControl.Value; }
            set { boyauDeBooleanControl.Value = value; }
        }
        public Visible<bool> Couverture
        {
            get { return couvertureBooleanControl.Value; }
            set { couvertureBooleanControl.Value = value; }
        }
        public Visible<bool> Extincteur
        {
            get { return extincteurBooleanControl.Value; }
            set { extincteurBooleanControl.Value = value; }
        }
        public Visible<bool> Bouche
        {
            get { return boucheBooleanControl.Value; }
            set { boucheBooleanControl.Value = value; }
        }
        public Visible<bool> RadioS
        {
            get { return radioSBooleanControl.Value; }
            set { radioSBooleanControl.Value = value; }
        }
        public Visible<bool> Surveillant
        {
            get { return surveillantBooleanControl.Value; }
            set { surveillantBooleanControl.Value = value; }
        }

        //M Hot
        public Visible<bool> UtilisationMoteur
        {
            get { return utilisationMoteurBooleanControl.Value; }
            set { utilisationMoteurBooleanControl.Value = value; }
        }
        public Visible<bool> NettoyageAu
        {
            get { return nettoyageAUBooleanControl.Value; }
            set { nettoyageAUBooleanControl.Value = value; }
        }
        public Visible<bool> UtilisationElectronics
        {
            get { return utilisationElectronicsBooleanControl.Value; }
            set { utilisationElectronicsBooleanControl.Value = value; }
        }
        public Visible<bool> Radiographie
        {
            get { return radiographieBooleanControl.Value; }
            set { radiographieBooleanControl.Value = value; }
        }
        public Visible<bool> UtilisationOutlis
        {
            get { return utilisationOutlisBooleanControl.Value; }
            set { utilisationOutlisBooleanControl.Value = value; }
        }
        //public Visible<bool> UtilisationEquipments
        //{
        //    get { return utilisationEquipmentsBooleanControl.Value; }
        //    set { utilisationEquipmentsBooleanControl.Value = value; }
        //}
        public Visible<bool> Demolition
        {
            get { return demolitionBooleanControl.Value; }
            set { demolitionBooleanControl.Value = value; }
        }
        


        public Visible<bool> Signaleur
        {
            get { return signaleurBooleanControl.Value; }
            set { signaleurBooleanControl.Value = value; }
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
            foreach (Control control in controls)
            {
                if (control is Panel || control is GroupBox)
                {
                    PutTemplatableControlsInTemplateMode(control.Controls);
                }
                else if (control is ITriStateControl)
                {
                    ITriStateControl triStateControl = (ITriStateControl)control;
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
            //permitTypeComboBox.Enabled = statusIsRequested;
            //permitTemplateComboBox.Enabled = statusIsRequested;
        }

        public void DisablePermitType(bool value)
        {
            //permitTypeComboBox.Enabled = value;
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
            //errorProvider.SetError(tradeComboBox, StringResources.MontrealWorkPermit_Trade_Not_Selected);
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


        #endregion



        public void SetErrorForAutresTravexElev()
        {
            autresTravauxDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_AutresElev));
        }

        public void SetErrorForAutresTravexMod()
        {
            autresInstructionDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_AutresMod));
        }

        public void SetErrorForRemplir()
        {
            remplirLeFormulaireDeConditionStringControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_Remplir));
        }

        public void SetErrorForRemplirForNumeric()
        {
            remplirLeFormulaireDeConditionStringControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError_Numeric,
                                                 StringResources.MudsWorkPermit_Remplir));
        }

        public void SetErrorForProcedureEnt()
        {
            procedureStringControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_ProcedureEn));
        }

        public void SetErrorForAutresCondition()
        {
            autresConditionsDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_AutresCondition));
        }

        public void SetErrorForFco()
        {
            interrupteursEtVannesCadenassesStringControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_Fco));
        }

        public void SetErrorForEtiquette()
        {
            etiquetteStringControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_Etiquette));
        }

        public void SetErrorForAutresAppVehicleComb()
        {
            appareilDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_AppareilVehicle));
        }

        public void SetErrorForElectricVolt()
        {
            electriciteVoltDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_ElectricVolt));
        }

        public void SetErrorForAutresRisque()
        {
            autresRisquesDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_AutresRisque));
        }

        public void SetErrorForAppreilResp()
        {
            appareilRespiratoireDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_AppreilResp));
        }

        public void SetErrorForGants()
        {
            gantsDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_Gants));
        }

        public void SetErrorForEpiAnti()
        {
            epiAntiArcCatDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_EPI));
        }

        public void SetErrorForHabitP()
        {
            habitProtecteurDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_HabitP));
        }

        public void SetErrorForAlrmeDcs()
        {
            alarmeDCSStringControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_AlarmeDCS));
        }

        public void SetErrorForOutilManuel()
        {
            outilDeLaitonDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_OutilManuel));
        }

        public void SetErrorForPerimetereSecurities()
        {
            perimetreSecuriteDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_PerimetreDeSec));
        }

        public void SetErrorForAutresDePrevention()
        {
            autresEquipmentsPreventionDropDownControl.SetError(errorProvider,
                                   string.Format(StringResources.WorkPermit_TernaryStringError,
                                                 StringResources.MudsWorkPermit_AutresPrevention));
        }



        public void SetRequestDetails(
            bool visible,
            DateTime? requestedDateTime, string requestedByUser,
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            string company, string company_1, string company_2, string supervisor, string excavationNumber,
            List<PermitAttribute> attributes)
        {
            requestDetailsControl.Visible = false; //visible; //made it false by-default - remove false - if want in future
            if (visible)
            {
               // requestDetailsControl.SetFields(requestedDateTime, requestedByUser, company, supervisor, excavationNumber, attributes);
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

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            endDatePicker.Value = startDatePicker.Value;

        }

        public string ClonedFormDetailMuds { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History

//Added By Vibhor : RITM0556998 - To lock the scroll for Dropdown. When any dropdown value is selected, lock its value for mouse scroll.
        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        

        public void InitializeStandardGasTestElementInfoList(List<GasTestElementInfo> standardGasTestElementInfoList)
        {
            SuspendLayout();
            //gasTestInfoExplorerBarContainerControl.SuspendLayout();
            gasTestElementInfoTableLayoutPanel.showonlyFirstColum = true;
            gasTestElementInfoTableLayoutPanel.BuildGasTestElementControls(standardGasTestElementInfoList, ClientSession.GetUserContext().Site);
            //gasTestInfoExplorerBarContainerControl.ResumeLayout();
            ResumeLayout();
            standardGasTestElementInfoList1 = standardGasTestElementInfoList;
            gasTestElementInfoTableLayoutPanel.DisbaleFirstTime = false;
            
        }

        public  List<GasTestElementDetailsMuds> GasTestElementDetailsList
        {
            get
            {
                return gasTestElementInfoTableLayoutPanel.GasTestElementDetailsList;
            }
        }

        public Time FirtTestResult
        {
            set
            {
                 gasTestElementInfoTableLayoutPanel.ImmediateAreaTime=value;
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

        public void EnbaleGasTest(bool val)
        {
            if(!val)
            {
                gasTestTestResultsGroupBox.Enabled = false;
                gasTestElementInfoTableLayoutPanel.ImmediateAreaTime = null;
                gasTestElementInfoTableLayoutPanel.ConfinedSpaceTime = null;
                gasTestElementInfoTableLayoutPanel.ThirdResultTime = null;
                gasTestElementInfoTableLayoutPanel.FourthResultTime = null;
                foreach(GasTestElementDetailsMuds Details in GasTestElementDetailsList)
                {
                    Details.ConfinedSpaceTestRequired = false;
                    Details.ImmediateAreaTestRequired = false;
                    Details.ThirdTestRequired = false;
                    Details.FourthTestRequired = false;
                    Details.ThirdTestResult = null;
                    Details.FourthTestResult = null;
                    Details.ConfinedSpaceTestResult = null;
                    Details.ImmediateAreaTestResult=null ;
                }
            }
            else
            {
                gasTestTestResultsGroupBox.Enabled = true;
                
            }
        }

        public string MudsAnswerTextBox
        {
            get { return oltQuestionAnswerTextBox.Text.EmptyToNull(); }
            set { oltQuestionAnswerTextBox.Text = value; }
        }

        public string MudsQuestionlabel
        {
            get { return ClientSession.GetUserContext().SiteConfiguration.SetWorkPermitQuestionForMudsSite; }
            set { oltQuestionLabel.Text = value; }
           // ClientSession.GetUserContext().SiteConfiguration.SetWorkPermitQuestionForMudsSite; 
        }
        
    }
}
