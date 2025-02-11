using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Client.Forms;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class WorkPermitDetailsDenver : AbstractDetails, IWorkPermitDetails
    {
        public event EventHandler Approve;
        public event EventHandler Reject;
        public event EventHandler CloseWorkPermit;
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler Comment;
        public event EventHandler Print;
        public event EventHandler PrintPreview;
        public event EventHandler Clone;
        public event EventHandler Copy;
        public event EventHandler ExportAll;
        public event EventHandler RefreshAll;
        public event EventHandler ViewEditHistory;    
        public event EventHandler SetFilter;
        //Added by ppanigrahi
        public event EventHandler Extension;
        public event EventHandler Revalidation;

        public event EventHandler MarkAsTemplate;
        public event EventHandler UnMarkTemplate;

        private DomainListView<GasTestElementResultDTO> gasTestElementResultsGrid;
                
        public WorkPermitDetailsDenver()
        {
            InitializeComponent();
            InitializeGasTestResultsGrid();
            base.Dock = DockStyle.Fill;
            approveButton.Click += approveButton_Click;
            rejectButton.Click += rejectButton_Click;
            closeButton.Click += closeWorkPermitButton_Click;
            deleteButton.Click += deleteButton_Click;
            editButton.Click += editButton_Click;
            commentButton.Click += commentButton_Click;
            printButton.Click += printButton_Click;
            printPreviewButton.Click += printPreviewButton_Click;
            cloneButton.Click += cloneButton_Click;
            detailsPanel.MouseEnter += detailsPanel_MouseEnter;
            editHistoryButton.Click += editHistoryButton_Click;
            rangeButton.Click += showRangeButton_Click;

            marktemplateButton.Click += marktemplateButton_Click;
            

        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        public void HideDetailsPanel()
        {
            detailsPanel.Hide();
        }

        public void ShowDetailsPanel()
        {
            detailsPanel.Show();
        }
        
        private void InitializeGasTestResultsGrid()
        {
            gasTestElementResultsGrid = new DomainListView<GasTestElementResultDTO>(new GasTestElementResultDenverDTOListViewRenderer(), false)
                                            {
                                                Dock = DockStyle.Fill
                                            };
            gasTestElementResultsPanel.Controls.Add(gasTestElementResultsGrid);
        }

        private void detailsPanel_MouseEnter(object sender, EventArgs e)
        {
            detailsPanel.Focus();
        }

        private void cloneButton_Click(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone(this, e);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, e);
            }
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            if (Approve != null)
            {
                Approve(this, e);
            }
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            if (Reject != null)
            {
                Reject(this, e);
            }
        }

        private void closeWorkPermitButton_Click(object sender, EventArgs e)
        {
            if (CloseWorkPermit != null)
            {
                CloseWorkPermit(this, e);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(this, e);
            }
        }

        private void commentButton_Click(object sender, EventArgs e)
        {
            if (Comment != null)
            {
                Comment(this, e);
            }
        }
        
        private void printButton_Click(object sender, EventArgs e)
        {
            if (Print != null)
            {
                Print(this, e);
            }
        }
       
        private void printPreviewButton_Click(object sender, EventArgs e)
        {
            if (PrintPreview != null)
            {
                PrintPreview(this, e);
            }
        }
        
        private void refreshAllButton_Click(object sender, EventArgs e)
        {
            if (RefreshAll != null)
            {
                RefreshAll(this, e);
            }
        }

        private void exportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        private void editHistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        void showRangeButton_Click(object sender, EventArgs e)
        {
            if(SetFilter != null)
            {
                SetFilter(this, e);    
            }
        }

        
        #region Data Getters and Setters

        public Time GasTestsImmediateAreaTestTime
        {
            set { immediateAreaTestTimeEditor.Value = value; }
        }
        
        public Time GasTestsConfinedSpaceTestTime
        {
            set { confinedSpaceTestTimeEditor.Value = value; }
        }

        public Time GasTestsSystemEntryTestTime
        {
            set { systemEntryTestTimeEditor.Value = value; }            
        }

        public User Author
        {
            set {
                createdUserLabeLData.Text = value == null ? string.Empty : value.FullNameWithUserName;
            }
        }

        public User LastModifier
        {
            set {
                lastModifiedUserLabeLData.Text = value == null ? string.Empty : value.FullNameWithUserName;
            }
        }

        public User Approver
        {
            set {
                approvedByUserDataLabel.Text = value == null ? string.Empty : value.FullNameWithUserName;
            }
        }

        public DateTime LastModifiedDate
        {
            set { lastModifiedDateLabelData.Text = value.ToLongDateAndTimeString(); }
        }

        public List<DocumentLink> DocumentLinks
        {
            set { documentLinksControl.DataSource = value; }
        }

        public FunctionalLocation FunctionalLocation
        {
            set
            {
                functionalLocationTextBox.Text =
                    (value == null) ? string.Empty : value.FullHierarchyWithDescription;
            }
        }

        public WorkPermitType WorkPermitType
        {
            set
            {
                if (WorkPermitType.HOT.Equals(value))
                {
                    workPermitTypeHotRadioButton.Checked = true;
                }
                else
                {
                    workPermitTypeColdRadioButton.Checked = true;
                }
            }
        }

        public string PermitNumber
        {
            set { permitNumberLabelData.Text = value; }
        }

        public string WorkOrderNumber
        {
            set { workOrderNumberTextBox.Text = value; }
        }

        public ICraftOrTrade CraftOrTrade
        {
            set
            {
                if (value == null)
                {
                    craftOrTradeTextBox.Text = null;
                }
                else
                {
                    craftOrTradeTextBox.Text = value.Name;
                }
            }
        }

        public DateTime StartDateTime
        {
            set
            {
                if (value == DateTime.MinValue)
                {
                    DateTime now = Clock.Now;
                    startDatePicker.Value = now.ToDate();
                    startOltTimePicker.Value = now.ToTime();
                }
                else
                {
                    startDatePicker.Value = value.ToDate();
                    startOltTimePicker.Value = value.ToTime();
                }
            }
        }

        public bool StartTimeNotApplicable
        {
            set { startOltTimePicker.Checked = !value; }
        }

        public DateTime EndDateTime
        {
            set
            {
                if (value == DateTime.MinValue)
                {
                    DateTime now = Clock.Now;
                    endDatePicker.Value = now.ToDate();
                    endOltTimePicker.Value = now.ToTime();
                }
                else
                {
                    endDatePicker.Value = value.ToDate();
                    endOltTimePicker.Value = value.ToTime();
                }
            }
        }

        public string ContactName
        {
            set { contactPersonTextBox.Text = value; }
        }

        public string ContractorCompanyName
        {
            set { contractorNameTextBox.Text = value; }
        }

        public bool? CommunicationMethodByRadio
        {
            set
            {
                communicationMethodRadioRadioButton.Checked = value.GetValueOrDefault(false);
                communicationMethodOtherRadioButton.Checked = !value.GetValueOrDefault(true);
            }
        }

        public string CommunicationMethodRadioChannel
        {
            set { communicationRadioChannelTextBox.Text = value; }
        }

        public string CommunicationMethodRadioColor
        {
            set { communicationRadioColorTextBox.Text = value; }
        }

        public bool CommunicationMethodIsWorkPermitCommunicationNotApplicable
        {
            set { communicationMethodsNACheckBox.Checked = value; }
        }

        public string CommunicationMethodDescription
        {
            set { communicationOtherDescriptionTextBox.Text = value; }
        }

        public string WorkOrderDescription
        {
            set { workOrderDescriptionTextBox.Text = value; }
        }

        public string JobStepDescription
        {
            set { jobStepDescriptionTextBox.Text = value; }
        }


        public bool IsConfinedSpaceEntry
        {
            set { confinedSpaceEntryCheckBox.Checked = value; }
        }

        public bool IsBreathingAirOrSCBA
        {
            set { breathingAirSCBACheckBox.Checked = value; }
        }

        public bool IsHotTap
        {
            set { hotTapCheckBox.Checked = value; }
        }

        public bool IsBurnOrOpenFlame
        {
            set { burnOpenFlameCheckBox.Checked = value; }
        }

        public bool IsSystemEntry
        {
            set { systemEntryCheckBox.Checked = value; }
        }

        public bool IsCriticalLift
        {
            set { criticalLiftCheckBox.Checked = value; }
        }

        public bool IsElectricalWork
        {
            set { electricalWorkCheckBox.Checked = value; }
        }

        public bool IsAsbestos
        {
            set { asbestosCheckBox.Checked = value; }
        }

        public bool IsExcavation
        {
            set { excavationCheckBox.Checked = value; }
        }

        public bool IsRadiationRadiography
        {
            set { radiationRadiographyCheckBox.Checked = value; }
        }

        public bool IsRadiationSealed
        {
            set { radiationSealedCheckBox.Checked = value; }
        }

        public bool IsLeadAbatement
        {
            set { leadAbatementCheckBox.Checked = value; }
        }

        public bool IsInertConfinedSpaceEntry
        {
            set { inertCSECheckBox.Checked = value; }
        }

        public bool AdditionalIsBlankOrBlindLists
        {
            set { additionalBlankOrBlindListCheckBox.Checked = value; }
        }

        public bool AdditionalIsCriticalLift
        {
            set { additionalCriticalLiftCheckBox.Checked = value; }
        }

        public bool AdditionalIsExcavation
        {
            set { additionalExcavationCheckBox.Checked = value; }
        }

        public bool AdditionalIsFlareEntry
        {
            set { additionalFlareEntryCheckBox.Checked = value; }
        }

        public bool AdditionalIsHotTap
        {
            set { additionalHotTapCheckBox.Checked = value; }
        }

        public bool AdditionalIsMSDS
        {
            set { additionalMSDSCheckBox.Checked = value; }
        }

        public bool AdditionalIsPJSROrSafetyPause
        {
            set { additionalPJSROrSafetyPauseCheckBox.Checked = value; }
        }

        public bool AdditionalIsRoadClosure
        {
            set { additionalRoadClosureCheckBox.Checked = value; }
        }

        public bool AdditionalIsWaiverOrDeviation
        {
            set { additionalWaiverOrDeviation.Checked = value; }
        }

        public bool AdditionalIsRadiationApproval
        {
            set { additionalRadiationApprovalCheckBox.Checked = value; }
        }

        public bool AdditionalIsOnlineLeakRepairForm
        {
            set { additionalOnlineLeakRepairFormCheckBox.Checked = value; }
        }

        public bool AdditionalIsEnergizedElectricalForm
        {
            set { additionalEnergizedElectricalFormCheckBox.Checked = value; }
        }

        public bool AdditionalIsNotApplicable
        {
            set { additionalFormNotApplicableCheckBox.Checked = value; }
        }

        public bool ToolsIsAirTools
        {
            set { toolsAirToolsCheckBox.Checked = value; }
        }

        public bool ToolsIsCementSaw
        {
            set { toolsCementSawCheckBox.Checked = value; }
        }

        public bool ToolsIsCraneOrCarrydeck
        {
            set { toolsCraneOrCarrydeckCheckBox.Checked = value; }
        }

        public bool ToolsIsElectricTools
        {
            set { toolsElectricToolsCheckBox.Checked = value; }
        }

        public bool ToolsIsForklift
        {
            set { toolsForkliftCheckBox.Checked = value; }
        }

        public bool ToolsIsHandTools
        {
            set { toolsHandToolsCheckBox.Checked = value; }
        }

        public bool ToolsIsHeavyEquipment
        {
            set { toolsHeavyEquipmentCheckBox.Checked = value; }
        }

        public bool ToolsIsHEPAVacuum
        {
            set { toolsHEPAVacuumCheckBox.Checked = value; }
        }

        public bool ToolsIsHotTapMachine
        {
            set { toolsHotTapMachineCheckBox.Checked = value; }
        }

        public bool ToolsIsJackhammer
        {
            set { toolsJackhammerCheckBox.Checked = value; }
        }

        public bool ToolsIsLanda
        {
            set { toolsLandaCheckBox.Checked = value; }
        }

        public bool ToolsIsManlift
        {
            set { toolsManliftCheckBox.Checked = value; }
        }

        public bool ToolsIsPortLighting
        {
            set { toolsPortLightingCheckBox.Checked = value; }
        }

        public bool ToolsIsScaffolding
        {
            set { toolsScaffoldingCheckBox.Checked = value; }
        }

        public bool ToolsIsTamper
        {
            set { toolsTamperCheckBox.Checked = value; }
        }

        public bool ToolsIsTorch
        {
            set { toolsTorchCheckBox.Checked = value; }
        }

        public bool ToolsIsVacuumTruck
        {
            set { toolsVacuumTruckCheckBox.Checked = value; }
        }

        public bool ToolsIsVehicle
        {
            set { toolsVehicleCheckBox.Checked = value; }
        }

        public bool ToolsIsChemicals
        {
            set { toolsChemicalsCheckBox.Checked = value;  }
        }

        public bool ToolsIsWelder
        {
            set { toolsWelderCheckBox.Checked = value; }
        }

        public bool ToolsIsOtherTools
        {
            set { }  // set automatically by ToolsOtherToolsDescription
        }

        public string ToolsOtherToolsDescription
        {
            set { toolsOtherToolsDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool ToolsIsCompressor
        {
            set { toolsCompressorCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodNotApplicable
        {
            set { equipmentIsolationMethodNACheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodMudderPlugs
        {
            set { equipmentIsolationMethodMudderPlugsCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodSeparation
        {
            set { equipmentIsolationMethodSeparationCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodBlindedorBlanked
        {
            set { equipmentIsolationMethodBlindedOrBlankedCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodCarBer
        {
            set { equipmentIsolationMethodCarBerCheckBox.Checked = value; }
        }

        public string EquipmentIsolationMethodOtherDescription
        {
            set { equipmentIsolationMethodOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool EquipmentIsElectricalIsolationMethodNotApplicable
        {
            set { electricIsolationMethodNACheckBox.Checked = value; }
        }

        public bool EquipmentIsElectricalIsolationMethodLOTO
        {
            set { electricIsolationMethodLOTOCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodLOTO
        {
            set { equipmentIsolationMethodLOTOCheckBox.Checked = value; }
        }

        public bool EquipmentIsElectricalIsolationMethodWiring
        {
            set { electricIsolationMethodWiringDisconnectedCheckBox.Checked = value; }
        }

        public bool EquipmentIsPreviousContentsNotApplicable
        {
            set { equipmentPreviousContentsNACheckBox.Checked = value; }
        }

        public bool EquipmentIsPreviousContentsAcid
        {
            set { equipmentPreviousContentsAcidCheckBox.Checked = value; }
        }

        public bool EquipmentIsPreviousContentsCaustic
        {
            set { equipmentPreviousContentsCausticCheckBox.Checked = value; }
        }

        public bool EquipmentIsPreviousContentsH2S
        {
            set { equipmentPreviousContentsH2SCheckBox.Checked = value; }
        }

        public bool EquipmentIsPreviousContentsHydrocarbon
        {
            set { equipmentPreviousContentsHydrocarbonCheckBox.Checked = value; }
        }

        public string EquipmentPreviousContentsOtherDescription
        {
            set { equipmentPreviousContentsOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool EquipmentIsConditionNotApplicable
        {
            set { equipmentConditionNACheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionCleaned
        {
            set { equipmentConditionCleanedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionDepressured
        {
            set { equipmentConditionDepressuredCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionDrained
        {
            set { equipmentConditionDrainedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionH20Washed
        {
            set { equipmentConditionH20WashedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionNeutralized
        {
            set { equipmentConditionNeutralizedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionPurged
        {
            set { equipmentConditionPurgedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionVentilated
        {
            set { equipmentConditionVentilatedCheckBox.Checked = value; }
        }

        public string EquipmentConditionPurgedDescription
        {
            set { equipmentConditionPurgedMethodTextBox.Text = value; }
        }

        public bool EquipmentIsLeakingValvesNotApplicable
        {
            set { equipmentLeakingValvesNACheckBox.Checked = value; }
        }

        public bool? EquipmentIsLeakingValves
        {
            set
            {
                equipmentLeakingValvesYesRadioButton.Checked = value.GetValueOrDefault(false);
                equipmentLeakingValvesNoRadioButton.Checked = !value.GetValueOrDefault(true);
            }
        }

        public bool EquipmentIsStillContainsResidualNotApplicable
        {
            set { equipmentStillContainsResidualValvesNACheckBox.Checked = value; }
        }

        public bool? EquipmentIsStillContainsResidual
        {
            set
            {
                equipmentStillContainsResidualYesRadioButton.Checked = value.GetValueOrDefault(false);
                equipmentStillContainsResidualNoRadioButton.Checked = !value.GetValueOrDefault(true);
            }
        }

        public bool EquipmentIsTestBumpNotApplicable
        {
            set { equipmentElectricalTestBumpNACheckBox.Checked = value; }
        }

        public bool? EquipmentIsTestBump
        {
            set
            {
                equipmentElectricBumpTestYesRadioButton.Checked = value.GetValueOrDefault(false);
                equipmentElectricBumpTestNoRadioButton.Checked = !value.GetValueOrDefault(true);
            }
        }

        public bool EquipmentIsVentilationMethodNotApplicable
        {
            set { equipmentVentilationMethodNACheckBox.Checked = value; }
        }

        public bool EquipmentIsVentilationMethodForced
        {
            set { equipmentVentilationMethodForcedCheckBox.Checked = value; }
        }

        public bool EquipmentIsVentilationMethodLocalExhaust
        {
            set { equipmentVentilationMethodLocalExhaustCheckBox.Checked = value; }
        }

        public bool EquipmentIsVentilationMethodNaturalDraft
        {
            set { equipmentVentilationMethodNaturalDraftCheckBox.Checked = value; }
        }

        public bool RadiationIsSealedSourceIsolationNotApplicable
        {
            set { radiationSealedSourceIsolationNACheckBox.Checked = value; }
        }

        public bool RadiationIsSealedSourceIsolationLOTO
        {
            set { radiationSealedSourceIsolationLOTOCheckBox.Checked = value; }
        }

        public bool FireIsNotApplicable
        {
            set { fireConfinedSpaceNACheckBox.Checked = value; }
        }

        public bool FireIsC02Extinguisher
        {
            set { fireConfinedSpaceC02ExtinguisherCheckBox.Checked = value; }
        }

        public bool FireIsFireResistantTarp
        {
            set { fireConfinedSpaceFireResistantTarpCheckBox.Checked = value; }
        }

        public bool FireIsSparkContainment
        {
            set { fireConfinedSpaceSparkContainmentCheckBox.Checked = value; }
        }

        public bool FireIsSteamHose
        {
            set { fireConfinedSpaceSteamHoseCheckBox.Checked = value; }
        }

//        public bool FireIsThreeHundredABCorDryChemicalExtinguisher
//        {
//            set { fireConfinedSpace300ABCorDryChemicalExtinguisherCheckBox.Checked = value; }
//        }

//        public bool FireIsTwentyABCorDryChemicalExtinguisher
//        {
//            set { fireConfinedSpace20ABCorDryChemicalExtinguisherCheckBox.Checked = value; }
//        }

        public bool FireIsWaterHose
        {
            set { fireConfinedSpaceWaterHoseCheckBox.Checked = value; }
        }

        public string FireHoleWatchNumber
        {
            set { fireConfinedSpaceHoleWatchNumber.Text = value; }
        }

        public string FireFireWatchNumber
        {
            set { fireConfinedSpaceFireWatchNumber.Text = value; }
        }

        public string FireSpotterNumber
        {
            set { fireConfinedSpaceSpotterNumber.Text = value; }
        }

        public string FireOtherDescription
        {
            set { fireConfinedSpaceOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        #region Respiratory

        public bool RespiratoryIsNotApplicable
        {
            set { respiratoryProtectionRequirementsNACheckBox.Checked = value; }
        }

        public bool RespiratoryIsAirCartorAirLine
        {
            set { respiratoryProtectionRequirementsAirCartOrAirLineCheckBox.Checked = value; }
        }

        public bool RespiratoryIsFullFaceRespirator
        {
            set { respiratoryProtectionRequirementsFullFaceRespiratorCheckBox.Checked = value; }
        }

        public bool RespiratoryIsHalfFaceRespirator
        {
            set { respiratoryProtectionRequirementsHalfFaceRespiratorCheckBox.Checked = value; }
        }

        public bool RespiratoryIsAirHood
        {
            set { respiratoryProtectionRequirementsAirHoodCheckBox.Checked = value; }
        }

        public bool RespiratoryIsSCBA
        {
            set { respiratoryProtectionRequirementsSCBACheckBox.Checked = value; }
        }

        public string RespiratoryOtherDescription
        {
            set { respiratoryProtectionRequirementsOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public WorkPermitRespiratoryCartridgeType RespiratoryCartridgeType
        {
            set
            {
                respiratoryProtectionCartridgeTypeOVAG.Checked = WorkPermitRespiratoryCartridgeType.OV_AG.Equals(value);
                respiratoryProtectionCartridgeTypeOVAGHEPA.Checked = WorkPermitRespiratoryCartridgeType.OV_AG_HEPA.Equals(value);
                respiratoryProtectionCartridgeTypeHEPA.Checked = WorkPermitRespiratoryCartridgeType.HEPA.Equals(value);
                respiratoryProtectionCartridgeTypeAmmonia.Checked = WorkPermitRespiratoryCartridgeType.AMMONIA.Equals(value);
            }
        }

        #endregion

        #region SpecialEyeOrFaceProtection

        public bool SpecialPPEIsEyeOrFaceProtectionNotApplicable
        {
            set { specialEyeOrFaceProtectionNACheckBox.Checked = value; }
        }

        public bool SpecialPPEIsEyeOrFaceProtectionFaceshield
        {
            set { specialEyeOrFaceProtectionFaceshieldCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsEyeOrFaceProtectionGoggles
        {
            set { specialEyeOrFaceProtectionGogglesCheckBox.Checked = value; }
        }

        public string SpecialPPEEyeOrFaceProtectionOtherDescription
        {
            set { specialEyeOrFaceProtectionOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        #endregion

        #region SpecialHandProtection

        public bool SpecialPPEIsHandProtectionNotApplicable
        {
            set { specialHandProtectionNACheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionChemicalGloves
        {
            set { specialHandProtectionChemicalChemicalGlovesCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionHighVoltage
        {
            set { specialHandProtectionHighVoltageCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionNitrile
        {
            set { specialHandProtectionNitrileCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionWelding
        {
            set { specialHandProtectionWeldingCheckBox.Checked = value; }
        }

        public string SpecialPPEHandProtectionOtherDescription
        {
            set { specialHandProtectionOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        #endregion

        #region SpecialProtectiveClothingType

        public List<AcidClothingType> SpecialProtectiveClothingTypeAcidClothingTypeChoices
        {
            // TODO: This is not applicable to Denver..if the Clothing control had it's own presenter,
            //   we would not have to do this.
            set { }
        }

        public bool SpecialPPEIsProtectiveClothingTypeNotApplicable
        {
            set { protectiveClothingControl.IsNotApplicable = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeTyvekSuit
        {
            set { protectiveClothingControl.IsTyvekSuit = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeKapplerSuit
        {
            set { protectiveClothingControl.IsKapplerSuit = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeElectricalFlashGear
        {
            set { protectiveClothingControl.IsElectricalFlashGear = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeCorrosiveClothing
        {
            set { protectiveClothingControl.IsCorrosiveClothing = value; }
        }

        public string SpecialPPEProtectiveClothingTypeOtherDescription
        {
            set { protectiveClothingControl.OtherDescription = value; }
        }

        #endregion

        #region SpecialProtectiveFootwear

        public bool SpecialPPEIsProtectiveFootwearNotApplicable
        {
            set { specialProtectiveFootwearNACheckBox.Checked = value; }
        }

        public bool SpecialPPEIsProtectiveFootwearChemicalImperviousBoots
        {
            set { specialProtectiveFootwearChemicalImperviousBootsCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsProtectiveFootwearToeGuard
        {
            set { specialProtectiveFootwearToeGuardCheckBox.Checked = value; }
        }

        public string SpecialPPEProtectiveFootwearOtherDescription
        {
            set { specialProtectiveFootwearOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        #endregion

        #region SpecialRescueOrFall

        public bool SpecialPPEIsRescueOrFallNotApplicable
        {
            set { specialRescueOrFallNACheckBox.Checked = value; }
        }

        public bool SpecialPPEIsRescueOrFallBodyHarness
        {
            set { specialRescueOrFallBodyHarnessCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsRescueOrFallLifeline
        {
            set { specialRescueOrFallLifelineCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsRescueOrFallRescueDevice
        {
            set { specialRescueOrFallRescueDeviceCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsRescueOrFallYoYo
        {
            set { specialRescueOrFallYoYoCheckBox.Checked = value; }
        }

        public string SpecialPPERescueOrFallOtherDescription
        {
            set { specialRescueOrFallOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool SpecialPPEFallRestraint
        {
            set { specialFallRestraintCheckBox.Checked = value; }
        }

        public bool SpecialPPEFallSelfRetractingDevice
        {
            set { specialFallSelfRetractingDeviceCheckBox.Checked = value; }
        }        
        
        public bool? SpecialPPEFallTieoffRequired
        {
            set
            {
                specialFallTieoffRequiredYesRadioButton.Checked = value.GetValueOrDefault(false);
                specialFallTieoffRequiredNoRadioButton.Checked = !value.GetValueOrDefault(true);
            }
        }

        public string SpecialPPEFallOtherDescription
        {
            set { specialFallOtherCheckBoxTextBox.Text = value; }
        }


        #endregion

        public string SpecialPrecautionsOrConsiderations
        {
            set { specialPrecautionsOrConsiderationsDescriptionTextBox.Text = value; }
        }

        public bool? IsCoauthorizationRequired
        {
            set
            {
                coAuthorizationRequiredYesRadioButton.Checked = value.GetValueOrDefault(false);
                coAuthorizationRequiredNoRadioButton.Checked = !value.GetValueOrDefault(true);
            }
        }

        public string CoauthorizationDescription
        {
            set { coAuthorizationRequiredDescriptionTextBox.Text = value; }
        }


        public bool JobWorksiteIsLightingElectricalRequirementNotApplicable
        {
            set { jobSitePreparationLightingElectricalRequirementNACheckBox.Checked = value; }
        }

        public string JobWorksiteLightingElectricalRequirementOtherDescription
        {
            set { jobSitePreparationLightingElectricalRequirementOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool JobWorksiteIsLightingElectricalRequirementGeneratorLights
        {
            set { jobSitePreparationLightingElectricalRequirementGeneratorLightsCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsLightingElectricalRequirement110VWithGFCI
        {
            set { jobSitePreparationLightingElectricalRequirement110VWithGFCICheckBox.Checked = value; }
        }

        public bool JobWorksiteIsLightingElectricalRequirementLowVoltage12V
        {
            set { jobSitePreparationLightingElectricalRequirementLowVoltage12VCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsAreaPreparationNotApplicable
        {
            set { jobSitePreparationAreaPreparationNACheckBox.Checked = value; }
        }

        public string JobWorksiteAreaPreparationOtherDescription
        {
            set { jobSitePreparationAreaPreparationOtherDescriptionTextBoxCheckBOx.Text = value; }
        }

        public bool JobWorksiteIsAreaPreparationBoundaryRopeTape
        {
            set { jobSitePreparationAreaPreparationBoundaryRopeTapeCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsAreaPreparationNonEssentialEvac
        {
            set { jobSitePreparationAreaPreparationNonEssentialEvacCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsAreaPreparationBarricade
        {
            set { jobSitePreparationAreaPreparationBarricadeCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsAreaPreparationRadiationRope
        {
            set { jobSitePreparationAreaPreparationRadiationRopeCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsSewerIsolationMethodNotApplicable
        {
            set { jobSitePreparationSewerIsolationMethodNACheckBox.Checked = value; }
        }

        public string JobWorksiteSewerIsolationMethodOtherDescription
        {
            set { jobSitePreparationSewerIsolationMethodOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool JobWorksiteIsSewerIsolationMethodBlindedOrBlanked
        {
            set { jobSitePreparationSewerIsolationMethodBlindedOrBlankedCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsSewerIsolationMethodPlugged
        {
            set { jobSitePreparationSewerIsolationMethodPluggedCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsSewerIsolationMethodSealedOrCovered
        {
            set { jobSitePreparationSewerIsolationMethodSealedOrCoveredCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsSurroundingConditionsAffectOrContaminatedNotApplicable
        {
            set { jobSitePreparationSurroundingConditionsAffectOrContaminatedNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsSurroundingConditionsAffectOrContaminated
        {
            set
            {
                jobSitePreparationSurroundingConditionsAffectOrContaminatedYesRadioButton.Checked = value.GetValueOrDefault(false);
                jobSitePreparationSurroundingConditionsAffectOrContaminatedNoRadioButton.Checked = !value.GetValueOrDefault(true);
            }
        }
       
        public bool JobWorksiteIsBondingOrGroundingRequiredNotApplicable
        {
            set { jobSitePreparationBondingOrGroundingRequiredNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsBondingOrGroundingRequired
        {
            set
            {
                jobSitePreparationBondingOrGroundingRequiredYesRadioButton.Checked = value.GetValueOrDefault(false);
                jobSitePreparationBondingOrGroundingRequiredNoRadioButton.Checked = !value.GetValueOrDefault(true);
            }
        }

        public bool JobWorksiteIsFlowRequiredForJobNotApplicable
        {
            set { jobsitePreparationFlowRequiredForJobNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsFlowRequiredForJob
        {
            set
            {
                jobsitePreparationFlowRequiredForJobYesRadioButton.Checked = value.GetValueOrDefault(false);
                jobsitePreparationFlowRequiredForJobNoRadioButton.Checked = !value.GetValueOrDefault(true);
            }
        }

        #region Gas Tests

        public string GasTestsFrequencyOrDuration
        {
            set { gasTestFrequencyOrDurationTextBox.Text = value; }
        }

        public bool GasTestsConstantMonitoringRequired
        {
            set { gasTestConstantMonitoringRequiredCheckBox.Checked = value; }
        }

        public bool GasTestsForkliftNotUsed
        {
            set { gasTestForkliftNotUsedCheckBox.Checked = value; }
        }

        //public IGasTestElementDetails Oxygen
        //{
        //    get { return oxygenDetails; }
        //}

        //public IGasTestElementDetails LEL
        //{
        //    get { return lelDetails; }
        //}

        //public IGasTestElementDetails H2S
        //{
        //    get { return h2sDetails; }
        //}

        //public IGasTestElementDetails SO2
        //{
        //    get { return so2Details; }
        //}

        //public IGasTestElementDetails CO
        //{
        //    get { return coDetails; }
        //}

        //public IGasTestElementDetails Benzene
        //{
        //    get { return benzeneDetails; }
        //}

        //public IGasTestElementDetails Toluene
        //{
        //    get { return tolueneDetails; }
        //}

        //public IGasTestElementDetails Xylene
        //{
        //    get { return xyleneDetails; }
        //}

        //public IGasTestElementDetails Ammonia
        //{
        //    get { return ammoniaDetails; }
        //}

        //public IGasTestElementDetails Other
        //{
        //    get { return otherDetails; }
        //}

        #endregion Gas Tests

        #endregion IWorkPermitFormView Members

        public void ClearRequiredSpecialPrecautionsAndConsiderationsSection()
        {
        }

        public void SetRequiredSpecialPrecautionsComments()
        {
            ClearRequiredSpecialPrecautionsAndConsiderationsSection();
        }

        public bool ApproveEnabled
        {
            set { approveButton.Enabled = value; }
        }
        public bool RejectEnabled
        {
            set { rejectButton.Enabled = value; }
        }
        public bool CloseEnabled
        {
            set { closeButton.Enabled = value; }
        }
        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }
        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }
        
        public bool CommentEnabled
        {
            set { commentButton.Enabled = value;}
        }
        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }
        public bool PrintPreviewEnabled
        {
            set { printPreviewButton.Enabled = value; }
        }
        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }
        public bool CopyEnabled
        {
            set { }
        }
        public bool ViewEditHistoryEnabled
        {
            set { editHistoryButton.Enabled = value; }
        }

        public string ShowButtonText
        {
            get { return rangeButton.Text; }
        }

        public WidgetAppearance ShowButtonAppearance
        {
            get { return (WidgetAppearance) rangeButton.Tag; }
            set
            {
                if (value != null)
                {
                    rangeButton.Text = value.ShortText;
                    rangeButton.ToolTipText = value.LongText;
                    rangeButton.Image = value.Icon;
                    rangeButton.Tag = value;
                }
            }
        }

        public bool RefreshAllEnabled
        {
            set { refreshAllButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                editButton_Click(this, new EventArgs());
            }
        }

        public List<GasTestElementResultDTO> GasTestElementResults
        {
            set { gasTestElementResultsGrid.ItemList = value; }
        }

        public bool StartAndOrEndTimesFinalized
        {
            set 
            { 
                endDatePicker.Visible = value;
                endOltTimePicker.Visible = value;
            }
        }

        public Version WorkPermitVersion
        {
            set { }
        }

        public IWorkPermitDetails BindingTarget
        {
            get { return this; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }
        // DMND0010609-OLT - Edmonton Work permit Scan
      
         public event EventHandler ViewAttachment;
        public void MakeSeachWindowRequiredButtonsvisibleonly()
        {

            rangeButton.Visible = false;
            exportallButton.Visible = false;
            refreshAllButton.Visible = false;
            saveGridLayoutButton.Visible = false;

        }
        private void Scanbutton_Click(object sender, EventArgs e)
        {
            if (Convert.ToString((sender as System.Windows.Forms.ToolStripButton).Tag) == "Scan")
            {
                string permitNumber = permitNumberLabelData.Text;
                ScanWorkPermit Scanform = new ScanWorkPermit(permitNumber);
                Scanform.ShowDialog();
            }
            else
            {
                ScanWorkPermit Scanform = new ScanWorkPermit();
                Scanform.ShowDialog();
            }
        }

        private void viewAttachementbutton_Click(object sender, EventArgs e)
        {
            if (ViewAttachment != null)
            {
                ViewAttachment(this, e);
            }
        }
        public bool ViewAttachEnabled
        {
            set { viewAttachementbutton.Enabled = value; }
        }

        public bool ViewScanEnabled
        {
            set { Scanbutton.Enabled = value;  }
        }

        //Added by ppanigrahi
        public bool ExtensionEnable
        {
            set { }
        }
        public bool RevalidationButtonEnable
        {
            set { }
        }
        public bool ToolStripEnabled
        {

            set { }
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public bool MarkTemplateEnabled
        {
            set { marktemplateButton.Visible = value; }
        }
        public bool UnMarkTemplateEnabled
        {
            set {  }
        }

        private void marktemplateButton_Click(object sender, EventArgs e)
        {
            if (MarkAsTemplate != null)
            {
                MarkAsTemplate(this, e);
            }
        }
        private void unmarktemplateButton_Click(object sender, EventArgs e)
        {
            if (UnMarkTemplate != null)
            {
                UnMarkTemplate(this, e);
            }
        }




        public string TemplateName { get; set; }
        public bool IsTemplate { get; set; }
        public bool IsActiveTemplate { get; set; }

        public bool DeleteVisible
        {
            set { deleteButton.Visible = value; }
        }
        public bool editVisible
        {
            set { editButton.Visible = value; }
        }
        public bool closeButtonVisible
        {
            set { closeButton.Visible = value; }
        }
        public bool printButtonVisible
        {
            set { printButton.Visible = value; }
        }
        public bool printPreviewButtonVisible
        {
            set { printPreviewButton.Visible = value; }
        }
        public bool editHistoryButtonVisible
        {
            set { editHistoryButton.Visible = value; }
        }
        public bool approveButtonVisible
        {
            set { approveButton.Visible = value; }
        }
        public bool rejectButtonVisible
        {
            set { rejectButton.Visible = value; }
        }
        public bool commentButtonVisible
        {
            set { commentButton.Visible = value; }
        }




        public bool ScanbuttonButtonVisible
        {
            get { return Scanbutton.Visible; }
            set { Scanbutton.Visible = value; }
        }

        public bool copyButtonVisible
        {
            set { }
        }

        public bool ExtensionButtonVisible
        {
            set { }
        }

        public bool revalidationButtonVisible
        {
            set {  }
        }


        public bool viewAttachementbuttonVisible
        {
            set { viewAttachementbutton.Visible = value; }
        }

//Added By Vibhor : RITM0627539 - Denver Site upgrades


        public bool AdditionalPreExcavationAuthorization
        {
            
            set { precheck.Checked = value; }
        }

        public bool AdditionalSuspendedWorkPlatform
        {
            
            set { suspendcheck.Checked = value; }
        }

        public bool AdditionalHotTurnoverApproval
        {
            
            set { hotcheck.Checked = value; }
        }

        public bool AdditionalConfinedSpaceEntryAuthorizationForm
        {
            
            set { confinedcheck.Checked = value; }
        }

        public bool AdditionalPreExcavationAuthorizationForm
        {
            
            set { presecondcheck.Checked = value; }
        }

        public bool AdditionalSupplementalJobSiteSignInForm
        {
            
            set { suplementsecondcheck.Checked = value; }
        }

        public bool AdditionalSystemEntryGasTestLogFrom
        {
            
            set { systemsecondcheck.Checked = value; }
        }

        public bool AdditionalHeatStressMonitoringForm
        {
            
            set { heatsecondcheck.Checked = value; }
        }

        public bool AdditionalCriticalLiftApprovalForm
        {
            
            set { criticalsecondcheck.Checked = value; }
        }
        public bool AdditionalPjsrSecondSection
        {
            
            set { pjsrsecondcheck.Checked = value; }
        }

        public bool AdditionalDeviationRequestForm
        {
            
            set { deviationsecondcheck.Checked = value; }
        }

        public bool AdditionalRoadClosureform
        {
            
            set { roadseocndcheck.Checked = value; }
        }

        public bool AdditionalRadiographyApprovalForm
        {
            
            set { radiosecondcheck.Checked = value; }
        }

        public bool AdditionalConfinedSpaceEntryTrackingLog
        {
            
            set { confinedLogsecondcheck.Checked = value; }
        }

        public bool AdditionalFlareLineChecklists
        {
            
            set { flaresecondcheck.Checked = value; }
        }

        public bool AdditionalHotTurnoverApprovalForm
        {
            
            set { hotsecondcheck.Checked = value; }
        }

        public bool AdditionalIndustrialHygieneAreaRealTimeSamplingForm
        {
            
            set { industrialsecondcheck.Checked = value; }
        }

        public bool AdditionalCraneSuspendedWorkPlatformChecklist
        {
            
            set { cranesecondcheck.Checked = value; }
        }

        public bool AdditionalConfinedSpaceEntryAuthorizationFormSecondSection
        {
            
            set { confinedsecondcheck.Checked = value; }
        }

        public bool AdditionalNASecondSection
        {
            set { additionalFormSecondNA.Checked = value; }
        }


    }
}
