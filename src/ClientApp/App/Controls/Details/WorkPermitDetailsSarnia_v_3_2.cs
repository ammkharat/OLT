using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class WorkPermitDetailsSarnia_v_3_2 : AbstractDetails, IWorkPermitDetails
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

        private DomainListView<DomainObjectChangeSet> recentEditHistoryGrid;
        private DomainListView<GasTestElementResultDTO> gasTestElementResultsGrid;

        public WorkPermitDetailsSarnia_v_3_2()
        {
            InitializeComponent();
            InitializeRecentEditHistoryGrid();
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
            copyButton.Click += copyButton_Click;
            detailsPanel.MouseEnter += detailsPanel_MouseEnter;
            editHistoryButton.Click += editHistoryButton_Click;
            rangeButton.Click += showRangeButton_Click;
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

        private void InitializeRecentEditHistoryGrid()
        {
            recentEditHistoryGrid = new DomainListView<DomainObjectChangeSet>(new DomainObjectChangeSetListViewRenderer(), false)
                                        {Dock = DockStyle.Fill};
            recentEditHistoryPanel.Controls.Add(recentEditHistoryGrid);
        }
        
        private void InitializeGasTestResultsGrid()
        {
            gasTestElementResultsGrid = new DomainListView<GasTestElementResultDTO>(new GasTestElementResulDTOListViewRenderer(), false)
                                            {Dock = DockStyle.Fill};
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
        
        private void copyButton_Click(object sender, EventArgs e)
        {
            if (Copy != null)
            {
                Copy(this, e);
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
            set { immediateAreaTestTimeUltraTimeEditor.Value = value; }
        }
        
        public Time GasTestsConfinedSpaceTestTime
        {
            set { confinedSpaceTestTimeUltraTimeEditor.Value = value; }
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

        public List<CraftOrTrade> CraftOrTradeChoices
        {
            set { workPermitCraftOrTradeControl.SystemCraftOrTradeChoices = value; }
        }

        public ICraftOrTrade CraftOrTrade
        {
            set { workPermitCraftOrTradeControl.WorkPermitCraftOrTrade = value; }
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

        public List<Contractor> ContractorChoices
        {
            set { workPermitContractorNameControl.Contractors = value; }
        }

        public string ContractorCompanyName
        {
            set { workPermitContractorNameControl.ContractorName = value; }
        }

        public bool? CommunicationMethodByRadio
        {
            set
            {
                if (value.HasValue)
                {
                    communicationMethodRadioRadioButton.Checked = value.Value;
                    communicationMethodOtherRadioButton.Checked = !value.Value;
                }
                else
                {
                    communicationMethodRadioRadioButton.Checked = false;
                    communicationMethodOtherRadioButton.Checked = false;
                }
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

        public bool IsVehicleEntry
        {
            set { vehicleEntryCheckBox.Checked = value; }
        }
        
        public bool IsBurnOrOpenFlame
        {
            set { burnOpenFlameCheckBox.Checked = value; }
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

        public bool AdditionalIsAsbestosHandling
        {
            set { additionalAsbestosHandlingTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public string AdditionalAsbestosHandlingDescription
        {
            set { additionalAsbestosHandlingTextBoxCheckBox.Text = value; }
        }

        public bool AdditionalIsBlankOrBlindLists
        {
            set { additionalBlankOrBlindListCheckBox.Checked = value; }
        }

        public bool AdditionalIsBurnOrOpenFlameAssessment
        {
            set { additionalBurnOrOpenFlameAssessmentTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public string AdditionalBurnOrOpenFlameAssessmentDescription
        {
            set { additionalBurnOrOpenFlameAssessmentTextBoxCheckBox.Text = value; }
        }

        public bool AdditionalIsCriticalLift
        {
            set { additionalCriticalLiftTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public string AdditionalCriticalLiftDescription
        {
            set { additionalCriticalLiftTextBoxCheckBox.Text = value; }
        }

        public bool AdditionalIsCSEAssessmentOrAuthorization
        {
            set { additionalCSEAssessmentAuthorizationTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public string AdditionalCSEAssessmentOrAuthorizationDescription
        {
            set { additionalCSEAssessmentAuthorizationTextBoxCheckBox.Text = value; }
        }

        public bool AdditionalIsElectrical
        {
            set { additionalElectricalTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public string AdditionalElectricalDescription
        {
            set { additionalElectricalTextBoxCheckBox.Text = value; }
        }

        public bool AdditionalIsExcavation
        {
            set { additionalExcavationTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public string AdditionalExcavationDescription
        {
            set { additionalExcavationTextBoxCheckBox.Text = value; }
        }

        public bool AdditionalIsMSDS
        {
            set { additionalMSDSCheckBox.Checked = value; }
        }

        public bool AdditionalIsPJSROrSafetyPause
        {
            set { additionalPJSROrSafetyPauseCheckBox.Checked = value; }
        }

        public bool AdditionalIsSpecialWasteDisposal
        {
            set { additionalSpecialWasteDisposalCheckBox.Checked = value; }
        }

        public bool AdditionalIsWaiverOrDeviation
        {
            set { additionalWaiverOrDeviationTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public string AdditionalWaiverOrDeviationDescription
        {
            set { additionalWaiverOrDeviationTextBoxCheckBox.Text = value; }
        }

        public string AdditionalOtherItemDescription
        {
            set { additionalOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool? EquipmentIsOutOfService
        {
            set
            {
                if (value.HasValue)
                {
                    equipmentEquipmentOutOfServiceRadioButton.Checked = value.Value;
                    equipmentEquipmentInServiceRadioButton.Checked = !value.Value;
                }
                else
                {
                    equipmentEquipmentOutOfServiceRadioButton.Checked = false;
                    equipmentEquipmentInServiceRadioButton.Checked = false;                 
                }
            }
        }

        public bool EquipmentIsAsbestosGasketsNotApplicable
        {
            set { asbestosGasketsNACheckBox.Checked = value; }
        }

        public bool? EquipmentIsAsbestosGaskets
        {
            set
            {
                asbestosGasketsYesRadioButton.Checked = value.GetValueOrDefault(false);
                asbestosGasketsNoRadioButton.Checked = !value.GetValueOrDefault(true);
            }
        }

        public bool EquipmentIsIsolationMethodNotApplicable
        {
            set { equipmentIsolationMethodNACheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodSeparation
        {
            set { equipmentIsolationMethodSeparationCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodBlindedorBlanked
        {
            set { equipmentIsolationMethodBlindedOrBlankedCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodBlockedIn
        {
            set { equipmentIsolationMethodBlockedInCheckBox.Checked = value; }
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
            set { equipmentConditionPurgedN2CheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionVentilated
        {
            set { equipmentConditionVentilatedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionPurgedN2
        {
            set { equipmentConditionPurgedN2CheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionPurgedSteamed
        {
            set { equipmentConditionPurgedSteamedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionPurgedAir
        {
            set { equipmentConditionPurgedAirCheckBox.Checked = value; }
        }

        public string EquipmentConditionOtherDescription
        {
            set { equipmentConditionOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool EquipmentIsLeakingValvesNotApplicable
        {
            set { equipmentLeakingValvesNACheckBox.Checked = value; }
        }

        public bool? EquipmentIsLeakingValves
        {
            set
            {
                if (value.HasValue)
                {
                    equipmentLeakingValvesYesRadioButton.Checked = value.Value;
                    equipmentLeakingValvesNoRadioButton.Checked = !value.Value;                
                }
                else
                {
                    equipmentLeakingValvesYesRadioButton.Checked = false;
                    equipmentLeakingValvesNoRadioButton.Checked = false;
                    
                }
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
                if (value.HasValue)
                {
                    equipmentStillContainsResidualYesRadioButton.Checked = value.Value;
                    equipmentStillContainsResidualNoRadioButton.Checked = !value.Value;
                }
                else
                {
                    equipmentStillContainsResidualYesRadioButton.Checked = false;
                    equipmentStillContainsResidualNoRadioButton.Checked = false;
                }
                    
            }
        }

        public bool? EquipmentIsTestBump
        {
            set { electricalBumpTestPerformedCheckBox.Checked = value.GetValueOrDefault(false); }
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

        public int? RadiationSealedSourceIsolationNumberOfSources
        {
            set { radiationSealedSourceIsolationNumberOfSourcesNumericBox.NumericValue = value; }
        }

        public bool RadiationIsSealedSourceIsolationLOTO
        {
            set { radiationSealedSourceIsolationLOTOCheckBox.Checked = value; }
        }

        public bool RadiationIsSealedSourceIsolationOpen
        {
            set { radiationSealedSourceIsolationOpenCheckBox.Checked = value; }
        }

        public bool FireIsNotApplicable
        {
            set { fireConfinedSpaceNACheckBox.Checked = value; }
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

        public bool FireIsTwentyABCorDryChemicalExtinguisher
        {
            set { fireConfinedSpace20ABCorDryChemicalExtinguisherCheckBox.Checked = value; }
        }
        
        public bool FireIsWatchmen
        {
            set { fireConfinedSpaceWatchmenCheckBox.Checked = value; }
        }

        public bool FireIsWaterHose
        {
            set { fireConfinedSpaceWaterHoseCheckBox.Checked = value; }
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

        public bool RespiratoryIsAirHood
        {
            set { respiratoryProtectionRequirementsAirHoodCheckBox.Checked = value; }
        }

        public bool RespiratoryIsDustMask
        {
            set { respiratoryProtectionRequirementsDustMaskCheckBox.Checked = value; }
        }

        public bool RespiratoryIsFullFaceRespirator
        {
            set { respiratoryProtectionRequirementsFullFaceRespiratorCheckBox.Checked = value; }
        }

        public bool RespiratoryIsHalfFaceRespirator
        {
            set { respiratoryProtectionRequirementsHalfFaceRespiratorCheckBox.Checked = value; }
        }

        public bool RespiratoryIsSCBA
        {
            set { respiratoryProtectionRequirementsSCBACheckBox.Checked = value; }
        }

        public string RespiratoryOtherDescription
        {
            set { respiratoryProtectionRequirementsOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public string RespiratoryCartridgeTypeDescription
        {
            set { respiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox.Text = value; }
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

        public bool SpecialPPEIsHandProtectionChemicalNeoprene
        {
            set { specialHandProtectionChemicalNeopreneCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionHighVoltage
        {
            set { specialHandProtectionHighVoltageCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionLeather
        {
            set { specialHandProtectionLeatherCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionNaturalRubber
        {
            set { specialHandProtectionNaturalRubberCheckBox.Checked = value; }
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

        public bool SpecialPPEIsProtectiveClothingTypeNotApplicable
        {
            set { protectiveClothingControl.IsNotApplicable = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeAcidClothing
        {
            set { protectiveClothingControl.IsAcidClothing = value; }
        }

        public List<AcidClothingType> SpecialProtectiveClothingTypeAcidClothingTypeChoices
        {
            set { protectiveClothingControl.AcidClothingTypes = value; }
        }

        public AcidClothingType SpecialPPEProtectiveClothingTypeAcidClothingType
        {
            set { protectiveClothingControl.AcidClothingType = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeCausticWear
        {
            set { protectiveClothingControl.IsCausticWear = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypePaperCoveralls
        {
            set { protectiveClothingControl.IsPaperCoveralls = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeRainCoat
        {
            set { protectiveClothingControl.IsRainCoat = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeRainPants
        {
            set { protectiveClothingControl.IsRainPants = value; }
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

        public bool SpecialPPEIsProtectiveFootwearMetatarsalGuard
        {
            set { specialProtectiveFootwearMetatarsalGuardCheckBox.Checked = value;  }
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

        public string SpecialPPERescueOrFallOtherDescription
        {
            set { specialRescueOrFallOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        #endregion

        public string SpecialPrecautionsOrConsiderations
        {
            set { specialPrecautionsOrConsiderationsDescriptionTextBox.Text = value; }
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

        public bool JobWorksiteIsAreaPreparationBarricade
        {
            set { jobSitePreparationAreaPreparationBarricadeCheckBox.Checked = value; }
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

        public bool JobWorksiteIsPermitReceiverFieldOrEquipmentOrientationNotApplicable
        {
            set { jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsPermitReceiverFieldOrEquipmentOrientation
        {
            set
            {
                if (value.HasValue)
                {
                    jobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButton.Checked = value.Value;
                    jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButton.Checked = !value.Value;
                }
                else
                {
                    jobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButton.Checked = false;
                    jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButton.Checked = false;
                }
            }
        }

        public bool JobWorksiteIsVestedBuddySystemInEffectNotApplicable
        {
            set { jobSitePreparationVestedBuddySystemInEffectNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsVestedBuddySystemInEffect
        {
            set
            {
                if (value.HasValue)
                {
                    jobSitePreparationVestedBuddySystemInEffectYesRadioButton.Checked = value.Value;
                    jobSitePreparationVestedBuddySystemInEffectNoRadioButton.Checked = !value.Value;
                }
                else
                {
                    jobSitePreparationVestedBuddySystemInEffectYesRadioButton.Checked = false;
                    jobSitePreparationVestedBuddySystemInEffectNoRadioButton.Checked = false;
                }
            }
        }

        public bool JobWorksiteIsSurroundingConditionsAffectOrContaminatedNotApplicable
        {
            set { jobSitePreparationSurroundingConditionsAffectOrContaminatedNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsSurroundingConditionsAffectOrContaminated
        {
            set
            {
                if (value.HasValue)
                {
                    jobSitePreparationSurroundingConditionsAffectOrContaminatedYesRadioButton.Checked = value.Value;
                    jobSitePreparationSurroundingConditionsAffectOrContaminatedNoRadioButton.Checked = !value.Value;
                }
                else
                {
                    jobSitePreparationSurroundingConditionsAffectOrContaminatedYesRadioButton.Checked = false;
                    jobSitePreparationSurroundingConditionsAffectOrContaminatedNoRadioButton.Checked = false;
                }
            }
        }

        public bool JobWorksiteIsCriticalConditionRemainJobSiteNotApplicable
        {
            set { jobSitePreparationCriticalConditionsRemainJobSiteNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsCriticalConditionRemainJobSite
        {
            set
            {
                if (value.HasValue)
                {
                    jobSitePreparationCriticalConditionsRemainJobSiteYesRadioButton.Checked = value.Value;
                    jobSitePreparationCriticalConditionsRemainJobSiteNoRadioButton.Checked = !value.Value;
                }
                else
                {
                    jobSitePreparationCriticalConditionsRemainJobSiteYesRadioButton.Checked = false;
                    jobSitePreparationCriticalConditionsRemainJobSiteNoRadioButton.Checked = false;
                }
            }
        }

        public bool JobWorksiteIsWeldingGroundWireInTestAreaNotApplicable
        {
            set { jobSitePreparationWeldingGroundWireInTestAreaNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsWeldingGroundWireInTestArea
        {
            set
            {
                if (value.HasValue)
                {
                    jobSitePreparationWeldingGroundWireInTestAreaYesRadioButton.Checked = value.Value;
                    jobSitePreparationWeldingGroundWireInTestAreaNoRadioButton.Checked = !value.Value;
                }
                else
                {
                    jobSitePreparationWeldingGroundWireInTestAreaYesRadioButton.Checked = false;
                    jobSitePreparationWeldingGroundWireInTestAreaNoRadioButton.Checked = false;
                }
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
                if (value.HasValue)
                {
                    jobSitePreparationBondingOrGroundingRequiredYesRadioButton.Checked = value.Value;
                    jobSitePreparationBondingOrGroundingRequiredNoRadioButton.Checked = !value.Value;
                }
                else
                {
                    jobSitePreparationBondingOrGroundingRequiredYesRadioButton.Checked = false;
                    jobSitePreparationBondingOrGroundingRequiredNoRadioButton.Checked = false;
                }
            }
        }

        public string JobWorksiteBondingGroundingNotRequiredComments
        {
            set
            {
                SetRequiredSpecialPrecautionsCommentText(bondingGroundingNotRequiredCommentsTextBox, value,
                                                                 bondingGroundingNotRequiredCommentsPanel);
            }
        }

        public string JobWorksiteWeldingGroundWireNotWithinGasTestAreaComments
        {
            set
            {
                SetRequiredSpecialPrecautionsCommentText(weldingGroundWireNotWithinGasTestAreaCommentsTextBox, value,
                                                                 weldingGroundWireNotWithinGasTestAreaCommentsPanel);
            }
        }


        public string JobWorksiteSurroundingConditionsAffectAreaComments
        {
            set
            {
                SetRequiredSpecialPrecautionsCommentText(surroundingConditionsAffectAreaCommentsTextBox, value,
                                                                 surroundingConditionsAffectAreaCommentsPanel);
            }
        }

        public string JobWorksiteCriticalConditionsComments
        {
            set
            {
                SetRequiredSpecialPrecautionsCommentText(criticalConditionsCommentsTextBox, value,
                                                                 criticalConditionsCommentsPanel);
            }
        }

        public string JobWorksitePermitReceiverRequiresOrientationComments
        {
            set
            {
                SetRequiredSpecialPrecautionsCommentText(permitReceiverRequiresOrientationCommentsTextBox, value,
                                                                 permitReceiverRequiresOrientationCommentsPanel);
            }
        }

        public bool? IsCoauthorizationRequired
        {
            set
            {
                if (value.HasValue)
                {
                    if (value.Value)
                        coAuthorizationRequiredYesRadioButton.Checked = true;
                    else
                        coAuthorizationRequiredNoRadioButton.Checked = true;
                }
                else
                {
                    coAuthorizationRequiredYesRadioButton.Checked = false;
                    coAuthorizationRequiredNoRadioButton.Checked = false;
                }

            }
        }

        public string CoauthorizationDescription
        {
            set { coAuthorizationRequiredDescriptionTextBox.Text = value; }
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
            requiredSpecialPrecautionsOrConsiderationsGroupBox.Visible = false;
            requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Controls.Clear();
            requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Visible = false;
        }

        public void SetRequiredSpecialPrecautionsComments()
        {
            ClearRequiredSpecialPrecautionsAndConsiderationsSection();

//            WorkPermitEquipmentPreparationCondition condition = workPermit.EquipmentPreparationCondition;

//            SetRequiredSpecialPrecautionsCommentText(
//                equipmentInServiceCommentsTextBox, 
//                condition.InServiceComments,
//                equipmentInServiceCommentsPanel, 
//                condition.IsOutOfService.HasValue && !condition.IsOutOfService.Value);

//            SetRequiredSpecialPrecautionsCommentText(
//                noElectricalTestBumpCommentsTextBox,
//                condition.NoElectricalTestBumpComments,
//                noElectricalTestBumpCommentsPanel,
//                !condition.IsTestBumpNotApplicable && condition.IsTestBump.HasValue && !condition.IsTestBump.Value);
//
//            SetRequiredSpecialPrecautionsCommentText(
//                stillContainsResidualCommentsTextBox,
//                condition.StillContainsResidualComments,
//                stillContainsResidualCommentsPanel,
//                condition.IsStillContainsResidual.HasValue && 
//                condition.IsStillContainsResidual.Value && 
//                !condition.IsStillContainsResidualNotApplicable);

//            SetRequiredSpecialPrecautionsCommentText(
//                leakingValvesCommentsTextBox,
//                condition.LeakingValvesComments,
//                leakingValvesCommentsPanel,
//                condition.IsLeakingValves.HasValue && 
//                condition.IsLeakingValves.Value && 
//                !condition.IsLeakingValvesNotApplicable);

//            WorkPermitJobWorksitePreparation worksitePreparation = workPermit.JobWorksitePreparation;
//
//            SetRequiredSpecialPrecautionsCommentText(
//                bondingGroundingNotRequiredCommentsTextBox,
//                worksitePreparation.BondingGroundingNotRequiredComments,
//                bondingGroundingNotRequiredCommentsPanel,
//                worksitePreparation.IsBondingOrGroundingRequired.HasValue && !worksitePreparation.IsBondingOrGroundingRequired.Value && !worksitePreparation.IsBondingOrGroundingRequiredNotApplicable);
//
//            SetRequiredSpecialPrecautionsCommentText(
//                weldingGroundWireNotWithinGasTestAreaCommentsTextBox,
//                worksitePreparation.WeldingGroundWireNotWithinGasTestAreaComments,
//                weldingGroundWireNotWithinGasTestAreaCommentsPanel,
//                worksitePreparation.IsWeldingGroundWireInTestArea.HasValue && !worksitePreparation.IsWeldingGroundWireInTestArea.Value && !worksitePreparation.IsWeldingGroundWireInTestAreaNotApplicable);
//
//            SetRequiredSpecialPrecautionsCommentText(
//                surroundingConditionsAffectAreaCommentsTextBox,
//                worksitePreparation.SurroundingConditionsAffectAreaComments,
//                surroundingConditionsAffectAreaCommentsPanel,
//                worksitePreparation.IsSurroundingConditionsAffectOrContaminated.HasValue &&
//                worksitePreparation.IsSurroundingConditionsAffectOrContaminated.Value &&
//                !worksitePreparation.IsSurroundingConditionsAffectOrContaminatedNotApplicable);
//
//            SetRequiredSpecialPrecautionsCommentText(
//                criticalConditionsCommentsTextBox,
//                worksitePreparation.CriticalConditionsComments,
//                criticalConditionsCommentsPanel,
//                worksitePreparation.IsCriticalConditionRemainJobSite.HasValue &&
//                worksitePreparation.IsCriticalConditionRemainJobSite.Value && 
//                !worksitePreparation.IsCriticalConditionRemainJobSiteNotApplicable);
//
//            SetRequiredSpecialPrecautionsCommentText(
//                permitReceiverRequiresOrientationCommentsTextBox,
//                worksitePreparation.PermitReceiverRequiresOrientationComments,
//                permitReceiverRequiresOrientationCommentsPanel,
//                worksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation.HasValue &&
//                worksitePreparation.IsPermitReceiverFieldOrEquipmentOrientation.Value && 
//                !worksitePreparation.IsPermitReceiverFieldOrEquipmentOrientationNotApplicable);
        }

        public string EquipmentInServiceComments
        {
            set 
            {
                SetRequiredSpecialPrecautionsCommentText(equipmentInServiceCommentsTextBox, value, equipmentInServiceCommentsPanel);
            }
        }


        public string EquipmentLeakingValvesComments
        {
            set
            {
                SetRequiredSpecialPrecautionsCommentText(leakingValvesCommentsTextBox, value, leakingValvesCommentsPanel);
            }
        }

        public string EquipmentStillContainsResidualComments
        {
            set
            {
                SetRequiredSpecialPrecautionsCommentText(stillContainsResidualCommentsTextBox, value, stillContainsResidualCommentsPanel);
            }
        }

        private void SetRequiredSpecialPrecautionsCommentText(TextBox control, string comments, Panel panel)
        {
            if (comments.HasValue())
            {                
                control.Text = comments;
                requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Controls.Add(panel);
                requiredSpecialPrecautionsOrConsiderationsGroupBox.Visible = true;
                requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Visible = true;
            }
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
            set { copyButton.Enabled = value; }
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

        public List<DomainObjectChangeSet> MostRecentEditHistory
        {
            set { recentEditHistoryGrid.ItemList = value; }
        }
        
        public List<GasTestElementResultDTO> GasTestElementResults
        {
            set { gasTestElementResultsGrid.ItemList = value; }
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
        public void MakeSeachWindowRequiredButtonsvisibleonly()
        {
        }
        public bool ViewAttachEnabled { set { } }
        public event EventHandler ViewAttachment;
        public bool ViewScanEnabled { set { } }
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

        public bool MarkTemplateEnabled { set { } }

        public bool UnMarkTemplateEnabled { set { } }

        public event EventHandler MarkAsTemplate;
        public event EventHandler UnMarkTemplate;

        public bool DeleteVisible
        {
            set { }
        }

        public bool editVisible
        {
            set { }
        }

        public bool closeButtonVisible
        {
            set { }
        }

        public bool printButtonVisible
        {
            set { }
        }

        public bool printPreviewButtonVisible
        {
            set { }
        }

        public bool editHistoryButtonVisible
        {
            set { }
        }

        public bool approveButtonVisible
        {
            set { }
        }

        public bool ScanbuttonButtonVisible
        {
            get { return ScanbuttonButtonVisible; }
            set { }
        }

        public bool rejectButtonVisible
        {
            set { }
        }

        public bool commentButtonVisible
        {
            set { }
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
            set { }
        }



        public bool viewAttachementbuttonVisible
        {
            set { }
        }
    }
}
