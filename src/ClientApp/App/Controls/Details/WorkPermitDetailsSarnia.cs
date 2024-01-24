using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class WorkPermitDetailsSarnia : AbstractDetails, IWorkPermitDetails
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

        public event EventHandler ViewAttachment; 

        public WorkPermitDetailsSarnia()
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
            copyButton.Click += copyButton_Click;
            detailsPanel.MouseEnter += detailsPanel_MouseEnter;
            editHistoryButton.Click += editHistoryButton_Click;
            rangeButton.Click += showRangeButton_Click;
            //Added by ppanigrahi
            ExtensionButton.Click += ExtensionButtonClicked;
            revalidationButton.Click += RevalidationButtonClicked;

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
        //Added by ppanigrahi
        private void ExtensionButtonClicked(object sender, EventArgs e)
        {
            if (Extension != null)
            {
                Extension(this, e);
            }
        }
        //Added by ppanigrahi
        private void RevalidationButtonClicked(object sender, EventArgs e)
        {
            if (Revalidation != null)
            {
                Revalidation(this, e);
            }
        }
        //Added by ppanigrahi
        public bool ExtensionEnable
        {
            set { ExtensionButton.Enabled = value; }
        }
        public bool RevalidationButtonEnable
        {
            set { revalidationButton.Enabled = value; }
        }

        public bool ToolStripEnabled
        {

            set { toolStrip1.Enabled = value; }
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

        public WorkAssignment WorkAssignment
        {
            set
            {
                workAssignmentTextBox.Text = value != null ? value.DisplayName : WorkAssignment.NoneWorkAssignment.DisplayName;             
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

        public bool IsFreshAir
        {
            set { freshAirCheckBox.Checked = value; }
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

        public bool AdditionalIsOtherItemDescription
        {
            set { }  // this is set automatically by AdditionalOtherItemDescription
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


        public bool EquipmentIsConditionNotApplicable
        {
            set { equipmentConditionNACheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionCleaned
        {
            set { equipmentConditionCleanedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionPurgedCheckbox  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            set { equipmentConditionPurgedCheckBox.Checked = value; }
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

        public bool EquipmentIsConditionOther
        {
            set { }  // set automatically be EquipmentConditionOtherDescription
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

        public bool EquipmentIsHazardousEnergyIsolationRequiredNotApplicable
        {
            set { equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked = value; }
        }

        public bool? EquipmentIsHazardousEnergyIsolationRequired
        {
            set
            {
                bool isApplicable = !equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked;
                equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked = isApplicable && value.HasValue && value.Value;
                equipmentIsHazardousEnergyIsolationRequiredNoRadioButton.Checked = isApplicable && value.HasValue && !value.Value;
                //equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked = isApplicable;
                //equipmentIsHazardousEnergyIsolationRequiredNoRadioButton.Checked = isApplicable;
            }
        }

        public string EquipmentLockOutMethodComments
        {
            set { SetRequiredSpecialPrecautionsCommentText(equipmentLockOutMethodCommentsTextBox, value, equipmentLockOutMethodCommentsPanel); }
        }

        public string EquipmentEnergyIsolationPlanNumber
        {
            set { eipNumberTextBox.Text = value; }
        }

        public bool? EquipmentConditionsOfEIPSatisfied
        {
            set
            {
                bool isApplicable = 
                    !equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked &&
                    equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked &&
                    equipmentLockOutMethodComplexGroupRadioButton.Checked;
                equipmentConditionsOfEIPSatisfiedNACheckBox.Checked = !isApplicable;
                equipmentConditionsOfEIPSatisfiedYesRadioButton.Checked = isApplicable && value.HasValue && value.Value;
                equipmentConditionsOfEIPSatisfiedNoRadioButton.Checked = isApplicable && value.HasValue && !value.Value;
            }
        }

        public WorkPermitLockOutMethodType EquipmentLockOutMethod
        {
            set
            {
                equipmentLockOutMethodIndividualByWorkerRadioButton.Checked = value != null && Equals(value, WorkPermitLockOutMethodType.INDIVIDUAL_BY_WORKER);
                equipmentLockOutMethodIndividualByOperationsRadioButton.Checked = value != null && Equals(value, WorkPermitLockOutMethodType.INDIVIDUAL_BY_OPERATIONS);
                equipmentLockOutMethodComplexGroupRadioButton.Checked = value != null && Equals(value, WorkPermitLockOutMethodType.COMPLEX_GROUP);
            }
        }

        public string EquipmentConditionsOfEIPNotSatisfiedComments
        {
            set { SetRequiredSpecialPrecautionsCommentText(equipmentConditionsOfEIPNotSatisfiedCommentsTextBox, value, equipmentConditionsOfEIPNotSatisfiedCommentsPanel); }
        }

        public bool AsbestosHazardsConsideredNotApplicable
        {
            set { asbestosHazardsConsideredNACheckBox.Checked = value; }
        }

        public bool? AsbestosHazardsConsidered
        {
            set
            {
                bool isApplicable = !asbestosHazardsConsideredNACheckBox.Checked;
                asbestosHazardsConsideredYesRadioButton.Checked = isApplicable && value.HasValue && value.Value;
                asbestosHazardsConsideredNoRadioButton.Checked = isApplicable && value.HasValue && !value.Value;
                //asbestosHazardsConsideredYesRadioButton.Checked = isApplicable;
                //asbestosHazardsConsideredNoRadioButton.Checked = isApplicable;
            }
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

        public bool? JobWorksiteIsControlRoomContactedOrNot
        {
            set
            {
                if (value.HasValue)
                {
                    jobSitePreparationControlRoomContactedYesRadioButton.Checked = value.Value;
                    jobSitePreparationControlRoomContactedNoRadioButton.Checked = !value.Value;
                }
                else
                {
                    jobSitePreparationControlRoomContactedYesRadioButton.Checked = false;
                    jobSitePreparationControlRoomContactedNoRadioButton.Checked = false;
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


        public bool JobWorksiteIsControlRoomContactedNotApplicable  //ControlRoomContactedNotApplicable       // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            set { jobSitePreparationControlRoomContactedNACheckBox.Checked = value; }
        }

        public bool ControlRoomsHasBeenContactedGroupBox // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            get { return jobSitePreparationControlRoomsHasBeenContactedGroupBox.Visible; }
            set { jobSitePreparationControlRoomsHasBeenContactedGroupBox.Visible = value; }
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

        public bool? IsControlRoomContacted
        {
            set
            {
                if (value.HasValue)
                {
                    if (value.Value)
                        jobSitePreparationControlRoomContactedYesRadioButton.Checked = true;
                    else
                        jobSitePreparationControlRoomContactedNoRadioButton.Checked = true;
                }
                else
                {
                    jobSitePreparationControlRoomContactedYesRadioButton.Checked = false;
                    jobSitePreparationControlRoomContactedNoRadioButton.Checked = false;
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
        }

        public string EquipmentInServiceComments
        {
            set 
            {
                SetRequiredSpecialPrecautionsCommentText(equipmentInServiceCommentsTextBox, value, equipmentInServiceCommentsPanel);
            }
        }

        public string EquipmentInAsbestosHazardPresentComments  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            set
            {
                
                SetRequiredSpecialPrecautionsCommentText(AsbestosHazardCommentsTextBox, value, AsbestosHazardPanel);
            }
        }

        //public string EquipmentInHazardousEnergyIsolationComments  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        //{
        //    set
        //    {
        //        SetRequiredSpecialPrecautionsCommentText(HazardousEnergyCommentsTextBox, value, HazardousEnergyPanel);
        //    }
        //}

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

                ReorderPanels();
            }
        }

        private void ReorderPanels()
        {
            List<Control> controls = new List<Control>();
            foreach (Control control in requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Controls)
            {
                controls.Add(control);
            }

            controls.Sort(SortControlsByTag);

            requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Controls.Clear();
            foreach (Control control in controls)
            {
                requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Controls.Add(control);
            }
        }

        public int SortControlsByTag(Control x, Control y)
        {
            int xTag = GetSortValue(x);
            int yTag = GetSortValue(y);
            return xTag.CompareTo(yTag);
        }

        private static int GetSortValue(Control x)
        {
            int sortValue = 999;
            if (x != null && x.Tag is int)
            {
                sortValue = (int) x.Tag;
            }
            return sortValue;
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
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
        // Start Code has been Added to fix the issue for INC0356247 --Mukesh
        //ayman Sarnia not applicable
        //Aarti INC0413392-Sarnia Glitch
        public bool JobWorksiteIsHazardousEnergyIsolationRequiredNotApplicable { get; set;
            //get { return equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked; }
            //set { equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked = value; }
            //get
            //{
            //    if (ClientSession.GetUserContext().Site.Id != Common.Domain.Site.SARNIA_ID)
            //    {
            //        return equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked;
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}
            //set
            //{
            //    if (ClientSession.GetUserContext().Site.Id != Common.Domain.Site.SARNIA_ID)
            //    {
            //        equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked = value;
            //    }
            //}
        }

        //ayman Sarnia not applicable
        //Aarti INC0413392-Sarnia Glitch
        public bool JobWorksiteIsAspestosRequiredNotApplicable { get; set;
            //get { return asbestosHazardsConsideredNACheckBox.Checked; }
            //set { asbestosHazardsConsideredNACheckBox.Checked = value; }
            //get
            //{
            //    if (ClientSession.GetUserContext().Site.Id != Common.Domain.Site.SARNIA_ID)
            //    {
            //        return asbestosHazardsConsideredNACheckBox.Checked;
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}
            //set
            //{
            //    if (ClientSession.GetUserContext().Site.Id != Common.Domain.Site.SARNIA_ID)
            //    {
            //        asbestosHazardsConsideredNACheckBox.Checked = value;
            //    }
            //}
        }
       

        //End Code has been Added to fix the issue for INC0356247 --Mukesh

        private void radiationRadiographyCheckBox_CheckedChanged(object sender, EventArgs e)   // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            //if (radiationRadiographyCheckBox.Checked == true && ClientSession.GetUserContext().Site.Id == Common.Domain.Site.SARNIA_ID)
            //{
            //    jobSitePreparationControlRoomsHasBeenContactedGroupBox.Visible = true;
            //}
            //else
            //{
            //    jobSitePreparationControlRoomsHasBeenContactedGroupBox.Visible = false;  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            //}
        }

        //public bool CommentsPanelVisiblity
        //{
        //    get { return permitReceiverRequiresOrientationCommentsPanel.Visible; }
        //    set { ; }
        //}

        // DMND0010609-OLT - Edmonton Work permit Scan
        public void MakeSeachWindowRequiredButtonsvisibleonly()
        {

            rangeButton.Visible = false;
            exportallButton.Visible = false;
            refreshAllButton.Visible = false;
            saveGridLayoutButton.Visible = false;
            
        }
        private void Scanbutton_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(permitNumberLabelData.Text) != "")
            {
                string permitNumber = permitNumberLabelData.Text;
                ScanWorkPermit Scanform = new ScanWorkPermit(permitNumber);
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
            set { Scanbutton.Enabled = value; }
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public bool MarkTemplateEnabled
        {
            set { marktemplateButton.Visible = value; }
        }
        public bool UnMarkTemplateEnabled
        {
            set { }
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
        public bool copyButtonVisible
        {
            set { copyButton.Visible = value; }
        }

        public bool ExtensionButtonVisible
        {
            set { ExtensionButton.Visible = value; }
        }
        public bool revalidationButtonVisible
        {
            set { revalidationButton.Visible = value; }
        }
        public bool ScanbuttonButtonVisible
        {
            get { return Scanbutton.Visible; }
            set { Scanbutton.Visible = value; }
        }

        public bool viewAttachementbuttonVisible
        {
            set { viewAttachementbutton.Visible = value; }
        }

    }
}
