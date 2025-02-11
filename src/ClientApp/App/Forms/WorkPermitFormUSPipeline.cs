using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using ResourcesResx = Com.Suncor.Olt.Client.Properties.Resources;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitFormUSPipeline : WorkPermitForm, IWorkPermitFormViewUSPipeline
    {
        /// <summary>
        /// Constructor used for creating an work permit
        /// </summary>
        public WorkPermitFormUSPipeline() : this(null) { }

        /// <summary>
        /// Constructor used for editing an work permit definition
        /// </summary>
        /// <param name="workPermit">work permit to edit</param>
        public WorkPermitFormUSPipeline(WorkPermit workPermit)
        {
            InitializeComponent();
            PerformLayout();
            var presenter = new WorkPermitFormPresenter<IWorkPermitFormViewUSPipeline>(this, workPermit);
            RegisterEventHandlersOnPresenter(presenter);
            RegisterEventHandlersOnForm();
        }

        public void InitializeStandardGasTestElementInfoList(List<GasTestElementInfo> standardGasTestElementInfoList)
        {
            SuspendLayout();
            gasTestInfoExplorerBarContainerControl.SuspendLayout();
            gasTestElementInfoTableLayoutPanel.BuildGasTestElementControls(standardGasTestElementInfoList, ClientSession.GetUserContext().Site);
            gasTestInfoExplorerBarContainerControl.ResumeLayout();
            ResumeLayout();
        }

        public bool EquipmentConditionPurgedMethodTextBoxEnabled
        {
            set { equipmentConditionPurgedMethodTextBox.Enabled = value; }
        }

        private void RegisterEventHandlersOnPresenter(WorkPermitFormPresenter<IWorkPermitFormViewUSPipeline> presenter)
        {
            Load += presenter.HandleFormLoad;
            FormClosing += presenter.HandleFormClosing;

            cancelButton.Click += presenter.HandleCancelButtonClick;
            saveButton.Click += presenter.HandleSaveAndCloseButtonClick;

            validateButton.Click += presenter.HandleValidateButtonClick;
            functionalLocationButton.Click += presenter.HandleFunctionalLocationButtonClick;

            workPermitTypeColdRadioButton.CheckedChanged += presenter.OnWorkPermitTypeChanged;
            workPermitTypeHotRadioButton.CheckedChanged += presenter.OnWorkPermitTypeChanged;

            confinedSpaceEntryCheckBox.CheckedChanged += presenter.HandleWorkAttributesChanged;

            startDatePicker.ValueChanged += startDatePicker_ValueChanged;
            endDatePicker.ValueChanged += endDatePicker_ValueChanged;

            viewEditHistoryButton.Click += presenter.HandleViewEditHistoryButtonClick;

            endDateTimeNA.CheckedChanged += endDateTimeNA_CheckedChanged;
            inertCSECheckBox.CheckedChanged += presenter.HandleWorkAttributesChanged;

        }

        /// <summary>
        /// Done so we don't get into a loop when editing date values
        /// </summary>
        private bool StartDateValueChangedHandlerEnabled
        {
            set
            {
                if (value)
                {
                    startDatePicker.ValueChanged += startDatePicker_ValueChanged;
                }
                else
                {
                    startDatePicker.ValueChanged -= startDatePicker_ValueChanged;
                }
            }
        }

        /// <summary>
        /// Done so we don't get into a loop when editing date values
        /// </summary>
        private bool EndDateValueChangedHandlerEnabled
        {
            set
            {
                if (value)
                {
                    endDatePicker.ValueChanged += endDatePicker_ValueChanged;
                }
                else
                {
                    endDatePicker.ValueChanged -= endDatePicker_ValueChanged;
                }
            }
        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (startDatePicker.Value > endDatePicker.Value)
            {
                StartDateValueChangedHandlerEnabled = false;
                startDatePicker.Value = endDatePicker.Value;
                StartDateValueChangedHandlerEnabled = true;
            }
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (startDatePicker.Value > endDatePicker.Value)
            {
                EndDateValueChangedHandlerEnabled = false;
                endDatePicker.Value = startDatePicker.Value;
                EndDateValueChangedHandlerEnabled = true;
            }
        }

        public void RegisterEventHandlersOnForm()
        {
            //clicking hot or cold should update visual piece at top of form
            workPermitTypeColdRadioButton.CheckedChanged += workPermitType_CheckedChanged;
            workPermitTypeHotRadioButton.CheckedChanged += workPermitType_CheckedChanged;

            //clicking radio should disable other textbox..click other should disable band and color
            communicationMethodRadioRadioButton.CheckedChanged += communicationMethod_CheckedChanged;
            communicationMethodOtherRadioButton.CheckedChanged += communicationMethod_CheckedChanged;

            //special checkboxes should disable/enable associated textboxes
            equipmentConditionPurgedCheckBox.CheckedChanged += equipmentConditionPurgedCheckBox_CheckedChanged;

            //clicking yes should enable description field
            coAuthorizationRequiredYesRadioButton.CheckedChanged += coAuthorizationRequired_CheckedChanged;
            coAuthorizationRequiredNoRadioButton.CheckedChanged += coAuthorizationRequired_CheckedChanged;

            //clicking NA checkbox should disable All controls in hosted control except NA checkbox            
            equipmentElectricalTestBumpNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            equipmentStillContainsResidualValvesNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            equipmentLeakingValvesNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            equipmentPreviousContentsNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            equipmentIsolationMethodNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            electricIsolationMethodNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            equipmentConditionNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobSitePreparationAreaPreparationNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobSitePreparationBondingOrGroundingRequiredNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobsitePreparationFlowRequiredForJobNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobSitePreparationLightingElectricalRequirementNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobSitePreparationSewerIsolationMethodNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            equipmentVentilationMethodNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobSitePreparationSurroundingConditionsAffectOrContaminatedNACheckBox.CheckedChanged +=
                NACheckBox_CheckedChanged;
            radiationSealedSourceIsolationNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            fireConfinedSpaceProtectionNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            respiratoryProtectionRequirementsNACheckBoxCheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            specialEyeOrFaceProtectionNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            specialProtectiveFootWearNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            specialProtectiveHandProtectionNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            specialProtectiveRescueAndFallNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            specialProtectiveClothingNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            communicationMethodsNACheckBox.CheckedChanged += communicationMethodsNACheckBox_CheckedChanged;
            additionalNotApplicableCheckBox.CheckedChanged += NACheckBox_CheckedChanged;

            //hook up the two buttons that expand or collapse All the groups
            expandAllGroupsButton.Click += expandAllGroupsButton_Click;
            collapseAllGroupsButton.Click += collapseAllGroupsButton_Click;

            //hook up the items that will cause the special precautions comments textbox to be required or not
            equipmentElectricBumpTestYesRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentElectricBumpTestNoRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentStillContainsResidualYesRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentStillContainsResidualNoRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentLeakingValvesNoRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentLeakingValvesYesRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            jobSitePreparationSurroundingConditionsAffectOrContaminatedNoRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            jobSitePreparationSurroundingConditionsAffectOrContaminatedYesRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;                
            jobsitePreparationFlowRequiredForJobYesRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            jobsitePreparationFlowRequiredForJobNoRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            jobSitePreparationBondingOrGroundingRequiredYesRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            jobSitePreparationBondingOrGroundingRequiredNoRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;                

            //now we need handlers to manage the textchanged events
            specialPrecautionsOrConsiderationsDescriptionTextBox.TextChanged += HandleSpecialPrecautionsOrConsiderationsDescriptionTextBoxTextChanged;

            //hook up the 'click here to edit the textbox values' for the label images
            commentsRequiredForNoElectricTestBumpPerformedImageLabel.Click += HandleSpecialPrecautionsRequiredLabelClick;
            commentsRequiredForStillContainsResidualImageLabel.Click += HandleSpecialPrecautionsRequiredLabelClick;
            commentsRequiredForLeakingValvesImageLabel.Click += HandleSpecialPrecautionsRequiredLabelClick;
            commentsRequiredForSurroundingConditionsContaminatedImageLabel.Click += HandleSpecialPrecautionsRequiredLabelClick;
            commentsRequiredForFlowRequiredImageLabel.Click += HandleSpecialPrecautionsRequiredLabelClick;
            commentsRequiredForNoBondingGroundingImageLabel.Click += HandleSpecialPrecautionsRequiredLabelClick;
        }

        private void HandleSpecialPrecautionsOrConsiderationsDescriptionTextBoxTextChanged(object sender, EventArgs eventArgs)
        {
            SetupIconsRelatedToSpecialPrecautionsTextRequired(specialPrecautionsOrConsiderationsDescriptionTextBox, commentsRequiredForNoElectricTestBumpPerformedImageLabel);
            SetupIconsRelatedToSpecialPrecautionsTextRequired(specialPrecautionsOrConsiderationsDescriptionTextBox, commentsRequiredForStillContainsResidualImageLabel);
            SetupIconsRelatedToSpecialPrecautionsTextRequired(specialPrecautionsOrConsiderationsDescriptionTextBox, commentsRequiredForLeakingValvesImageLabel);
            SetupIconsRelatedToSpecialPrecautionsTextRequired(specialPrecautionsOrConsiderationsDescriptionTextBox, commentsRequiredForSurroundingConditionsContaminatedImageLabel);
            SetupIconsRelatedToSpecialPrecautionsTextRecommended(specialPrecautionsOrConsiderationsDescriptionTextBox, commentsRequiredForFlowRequiredImageLabel);
            SetupIconsRelatedToSpecialPrecautionsTextRecommended(specialPrecautionsOrConsiderationsDescriptionTextBox, commentsRequiredForNoBondingGroundingImageLabel);
        }

        private void commentsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetupSpecialPrecautionsCommentsArea();
        }

        private void SetupSpecialPrecautionsCommentsArea()
        {
            SetSpecialPrecautionsCommentsArea(
                                              commentsRequiredForNoElectricTestBumpPerformedImageLabel,
                                              specialPrecautionsOrConsiderationsDescriptionTextBox,
                                              equipmentElectricBumpTestNoRadioButton.Checked && !equipmentElectricalTestBumpNACheckBox.Checked,
                                              true);


            SetSpecialPrecautionsCommentsArea(
                                              commentsRequiredForStillContainsResidualImageLabel,
                                              specialPrecautionsOrConsiderationsDescriptionTextBox,
                                              equipmentStillContainsResidualYesRadioButton.Checked &&
                                              !equipmentStillContainsResidualValvesNACheckBox.Checked,
                                              true);

            SetSpecialPrecautionsCommentsArea(
                                              commentsRequiredForLeakingValvesImageLabel,
                                              specialPrecautionsOrConsiderationsDescriptionTextBox,
                                              equipmentLeakingValvesYesRadioButton.Checked && !equipmentLeakingValvesNACheckBox.Checked,
                                              true);

            SetSpecialPrecautionsCommentsArea(
                                              commentsRequiredForSurroundingConditionsContaminatedImageLabel,
                                              specialPrecautionsOrConsiderationsDescriptionTextBox,
                                              jobSitePreparationSurroundingConditionsAffectOrContaminatedYesRadioButton.Checked &&
                                              !jobSitePreparationSurroundingConditionsAffectOrContaminatedNACheckBox.Checked,
                                              true);

            SetSpecialPrecautionsCommentsArea(
                                              commentsRequiredForFlowRequiredImageLabel,
                                              specialPrecautionsOrConsiderationsDescriptionTextBox,
                                              jobsitePreparationFlowRequiredForJobYesRadioButton.Checked &&
                                              !jobsitePreparationFlowRequiredForJobNACheckBox.Checked,
                                              false);

            SetSpecialPrecautionsCommentsArea(
                                              commentsRequiredForNoBondingGroundingImageLabel,
                                              specialPrecautionsOrConsiderationsDescriptionTextBox,
                                              jobSitePreparationBondingOrGroundingRequiredNoRadioButton.Checked &&
                                              !jobSitePreparationBondingOrGroundingRequiredNACheckBox.Checked,
                                              false);
        }

        private void SetSpecialPrecautionsCommentsArea(Label labelImage, Control textBox, bool makeVisible, bool commentRequired)
        {
            if (makeVisible)
            {
                labelImage.Visible = true;

                if (commentRequired)
                {
                    SetupIconsRelatedToSpecialPrecautionsTextRequired(textBox, labelImage);
                }
                else
                {
                    SetupIconsRelatedToSpecialPrecautionsTextRecommended(textBox, labelImage);
                }
            }
            else
            {
                labelImage.Visible = false;
            }
        }

        private void SetupIconsRelatedToSpecialPrecautionsTextRequired(Control textBox, Label imageLabel)
        {
            SetupIconsRelatedToSpecialPrecautionsText(textBox, imageLabel, StringResources.WorkPermitSpecialPrecautionWarningTooltip_CommentRequired);
        }

        private void SetupIconsRelatedToSpecialPrecautionsTextRecommended(Control textBox, Label imageLabel)
        {
            SetupIconsRelatedToSpecialPrecautionsText(textBox, imageLabel, StringResources.WorkPermitSpecialPrecautionWarningTooltip_CommentRecommended);
        }

        private void SetupIconsRelatedToSpecialPrecautionsText(Control textBox, Label labelImage, string warningTooltipMessage)
        {
            if (textBox.Text.IsNullOrEmptyOrWhitespace())
            {
                labelImage.Image = ResourcesResx.warningCommentsRequired;
                toolTip.SetToolTip(labelImage, warningTooltipMessage);
            }
            else
            {
                const string format = "{0} {1}";
                string toolTipText = string.Format(format, StringResources.WorkPermitSpecialPrecautionCommentTooltipPrefix, textBox.Text);                                  
                labelImage.Image = ResourcesResx.informationCommentsProvided;
                toolTip.SetToolTip(labelImage, toolTipText);
            }
        }

        private void HandleSpecialPrecautionsRequiredLabelClick(object sender, EventArgs eventArgs)
        {
            SetFocusToSpecialPrecautionsTextBox();
        }

        public void SetFocusToSpecialPrecautionsTextBox()
        {
            SetFocusToTextboxInSpecialPrecautionsArea(specialPrecautionsOrConsiderationsDescriptionTextBox);
        }

        public void RegisterUIEventHandlers<T>(WorkPermitFormPresenter<T> presenter) where T : IWorkPermitFormView
        {
        }

        void endDateTimeNA_CheckedChanged(object sender, EventArgs e)
        {
            bool endDateTimeEnabled = !endDateTimeNA.Checked;
            endDatePicker.Enabled = endDateTimeEnabled;
            endOltTimePicker.Enabled = endDateTimeEnabled;

        }

        public bool StartAndOrEndTimesFinalized
        {
            set { endDateTimeNA.Checked = !value; }
            get { return !endDateTimeNA.Checked; }
        }

        #region Data Getters and Setters

        public Time GasTestsImmediateAreaTestTime
        {
            get { return gasTestElementInfoTableLayoutPanel.ImmediateAreaTime; }
            set { gasTestElementInfoTableLayoutPanel.ImmediateAreaTime = value; }
        }

        public Time GasTestsConfinedSpaceTestTime
        {
            get { return gasTestElementInfoTableLayoutPanel.ConfinedSpaceTime; }
            set { gasTestElementInfoTableLayoutPanel.ConfinedSpaceTime = value; }
        }

        public Time GasTestsSystemEntryTestTime
        {
            get { return gasTestElementInfoTableLayoutPanel.SystemEntryTime; }
            set { gasTestElementInfoTableLayoutPanel.SystemEntryTime = value; }            
        }

        public User Author
        {
            set { lastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public DateTime LastModifiedDate
        {
            set { lastModifiedDateAuthorHeader.LastModifiedDate = value; }
            get { return lastModifiedDateAuthorHeader.LastModifiedDate; }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return workPermitDocumentLinksControl.DataSource as List<DocumentLink>; }
            set { workPermitDocumentLinksControl.DataSource = value; }
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocationTextBox.Tag as FunctionalLocation; }
            set
            {
                if (value != null)
                {
                    toolTip.SetToolTip(functionalLocationTextBox, value.Description);
                    toolTip.SetToolTip(flocLabelData, value.Description);
                    functionalLocationTextBox.Text = value.FullHierarchyWithDescription;
                    functionalLocationTextBox.Tag = value;
                    flocLabelData.Text = value.FullHierarchyWithDescription;
                }
                else
                {
                    toolTip.RemoveAll();
                    functionalLocationTextBox.Text = string.Empty;
                    functionalLocationTextBox.Tag = value;
                    flocLabelData.Text = string.Empty;
                }
            }
        }

        public WorkPermitType WorkPermitType
        {
            get
            {
                if (workPermitTypeHotRadioButton.Checked || workPermitTypeColdRadioButton.Checked)
                {
                    if (workPermitTypeHotRadioButton.Checked) return WorkPermitType.HOT;
                    return WorkPermitType.COLD;
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    workPermitTypeHotRadioButton.Checked = false;
                    workPermitTypeColdRadioButton.Checked = false;
                    permitTypeLabelData.Text = StringResources.None;
                    return;
                }

                if (WorkPermitType.HOT.Equals(value))
                {
                    workPermitTypeHotRadioButton.Checked = true;
                    permitTypeLabelData.Text = StringResources.WorkPermitHot;
                }
                else
                {
                    workPermitTypeColdRadioButton.Checked = true;
                    permitTypeLabelData.Text = StringResources.WorkPermitCold;
                }
            }
        }

        public string PermitNumber
        {
            get { return permitNumberLabelData.Text; }
            set { permitNumberLabelData.Text = value; }
        }


        public string WorkOrderNumber
        {
            get { return workOrderNumberTextBox.Text; }
            set { workOrderNumberTextBox.Text = value; }
        }

        public ICraftOrTrade CraftOrTrade
        {
            get { return workPermitCraftOrTradeControl.WorkPermitCraftOrTrade; }
            set { workPermitCraftOrTradeControl.WorkPermitCraftOrTrade = value; }
        }

        public bool EnableCraftOrTradeRadio
        {
            set { workPermitCraftOrTradeControl.EnableRadio = value; }
        }

        public bool ToggleInputBoxEnabled
        {
            set { workPermitCraftOrTradeControl.ToggleInputBoxEnabled = value; }
        }

        public DateTime StartDateTime
        {
            get
            {
                return
                    new DateTime(startDatePicker.Year, startDatePicker.Month, startDatePicker.Day, startOltTimePicker.Hour,
                                 startOltTimePicker.Minute, 0);
            }
            set
            {
                startDatePicker.Value = value.ToDate();
                startOltTimePicker.Value = value.ToTime();
            }
        }

        public bool StartTimeNotApplicable
        {
            get { return !startOltTimePicker.Checked; }
            set { startOltTimePicker.Checked = !value; }
        }

        public DateTime? EndDateTime
        {
            get
            {
                return endDateTimeNA.Checked
                    ? null : (DateTime?)
                             new DateTime(endDatePicker.Year, endDatePicker.Month, endDatePicker.Day,
                                          endOltTimePicker.Hour, endOltTimePicker.Minute, 0);
            }
            set
            {
                if (value == null)
                {
                    endOltTimePicker.Enabled = false;
                    endDatePicker.Enabled = false;
                }
                else
                {
                    endOltTimePicker.Value = value.Value.ToTime();
                    endDatePicker.Value = value.Value.ToDate();
                }

            }
        }

        public string ContactName
        {
            get { return contactPersonTextBox.Text; }
            set { contactPersonTextBox.Text = value; }
        }

        public string ContractorCompanyName
        {
            get { return workPermitContractorNameControl.ContractorName; }
            set { workPermitContractorNameControl.ContractorName = value; }
        }

        public bool? CommunicationMethodByRadio
        {
            get
            {
                return GetNullableBooleanFromRadioButtons(communicationMethodRadioRadioButton,
                                                          communicationMethodOtherRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(communicationMethodRadioRadioButton,
                                                      communicationMethodOtherRadioButton,
                                                      value);
            }
        }

        public bool CommunicationMethodIsWorkPermitCommunicationNotApplicable
        {
            get { return communicationMethodsNACheckBox.Checked; }
            set { communicationMethodsNACheckBox.Checked = value; }
        }

        public string CommunicationMethodRadioChannel
        {
            get { return communicationRadioChannelTextBox.Text; }
            set { communicationRadioChannelTextBox.Text = value; }
        }

        public string CommunicationMethodDescription
        {
            get { return communicationOtherDescriptionTextBox.Text; }
            set { communicationOtherDescriptionTextBox.Text = value; }
        }

        public string WorkOrderDescription
        {
            get { return workOrderDescriptionTextBox.Text; }
            set { workOrderDescriptionTextBox.Text = value; }
        }

        public string JobStepDescription
        {
            get { return jobStepDescriptionTextBox.Text; }
            set { jobStepDescriptionTextBox.Text = value; }
        }

        public bool IsConfinedSpaceEntry
        {
            get { return confinedSpaceEntryCheckBox.Checked; }
            set { confinedSpaceEntryCheckBox.Checked = value; }
        }

        public bool IsBreathingAirOrSCBA
        {
            get { return breathingAirSCBACheckBox.Checked; }
            set { breathingAirSCBACheckBox.Checked = value; }
        }

        public bool IsElectricalWork
        {
            get { return electricalWorkCheckBox.Checked; }
            set { electricalWorkCheckBox.Checked = value; }
        }

        public bool IsVehicleEntry
        {
            get { return false; }
            set { }
        }

        public bool IsHotTap
        {
            get { return hotTapCheckBox.Checked; }
            set { hotTapCheckBox.Checked = value; }
        }

        public bool IsInertConfinedSpaceEntry
        {
            get { return inertCSECheckBox.Checked; }
            set { inertCSECheckBox.Checked = value; }
        }

        public bool IsLeadAbatement
        {
            get { return leadAbatementCheckBox.Checked; }
            set { leadAbatementCheckBox.Checked = value; }
        }

        public bool IsBurnOrOpenFlame
        {
            get { return burnOpenFlameCheckBox.Checked; }
            set { burnOpenFlameCheckBox.Checked = value; }
        }

        public bool IsSystemEntry
        {
            get { return systemEntryCheckBox.Checked; }
            set { systemEntryCheckBox.Checked = value; }
        }

        public bool IsCriticalLift
        {
            get { return criticalLiftCheckBox.Checked; }
            set { criticalLiftCheckBox.Checked = value; }
        }

        public bool IsAsbestos
        {
            get { return asbestosCheckBox.Checked; }
            set { asbestosCheckBox.Checked = value; }
        }

        public bool IsExcavation
        {
            get { return excavationCheckBox.Checked; }
            set { excavationCheckBox.Checked = value; }
        }

        public bool IsRadiationRadiography
        {
            get { return radiationRadiographyCheckBox.Checked; }
            set { radiationRadiographyCheckBox.Checked = value; }
        }

        public bool IsRadiationSealed
        {
            get { return radiationSealedCheckBox.Checked; }
            set { radiationSealedCheckBox.Checked = value; }
        }

        public bool AdditionalIsBlankOrBlindLists
        {
            get { return additionalBlankOrBlindListCheckBox.Checked; }
            set { additionalBlankOrBlindListCheckBox.Checked = value; }
        }

        public bool AdditionalIsCriticalLift
        {
            get { return additionalCriticalLiftCheckBox.Checked; }
            set { additionalCriticalLiftCheckBox.Checked = value; }
        }

        public bool AdditionalIsExcavation
        {
            get { return additionalExcavationCheckBox.Checked; }
            set { additionalExcavationCheckBox.Checked = value; }
        }

        public bool AdditionalIsFlareEntry
        {
            get { return additionalFlareEntryCheckBox.Checked; }
            set { additionalFlareEntryCheckBox.Checked = value; }
        }

        public bool AdditionalIsHotTap
        {
            get { return additionalHotTapCheckBox.Checked; }
            set { additionalHotTapCheckBox.Checked = value; }
        }

        public bool AdditionalIsMSDS
        {
            get { return additionalMSDSCheckBox.Checked; }
            set { additionalMSDSCheckBox.Checked = value; }
        }

        public bool AdditionalIsPJSROrSafetyPause
        {
            get { return additionalPJSROrSafetyPauseCheckBox.Checked; }
            set { additionalPJSROrSafetyPauseCheckBox.Checked = value; }
        }

        public bool AdditionalIsRoadClosure
        {
            get { return additionalRoadClosureCheckBox.Checked; }
            set { additionalRoadClosureCheckBox.Checked = value; }
        }

        public bool AdditionalIsWaiverOrDeviation
        {
            get { return additionalWaiverOrDeviation.Checked; }
            set { additionalWaiverOrDeviation.Checked = value; }
        }

        public bool AdditionalIsRadiationApproval
        {
            get { return radiationApprovalCheckbox.Checked; }
            set { radiationApprovalCheckbox.Checked = value; }
        }

        public bool AdditionalIsOnlineLeakRepairForm
        {
            get { return onlineLeakRepairFormCheckBox.Checked; }
            set { onlineLeakRepairFormCheckBox.Checked = value; }
        }

        public bool AdditionalIsEnergizedElectricalForm
        {
            get { return additionalEnergizedElectricalFormCheckBox.Checked; }
            set { additionalEnergizedElectricalFormCheckBox.Checked = value; }
        }

        public bool AdditionalIsNotApplicable
        {
            get { return additionalNotApplicableCheckBox.Checked; }
            set { additionalNotApplicableCheckBox.Checked = value; }
        }

        public bool ToolsIsAirTools
        {
            get { return toolsAirToolsCheckBox.Checked; }
            set { toolsAirToolsCheckBox.Checked = value; }
        }

        public bool ToolsIsCementSaw
        {
            get { return toolsCementSawCheckBox.Checked; }
            set { toolsCementSawCheckBox.Checked = value; }
        }

        public bool ToolsIsCraneOrCarrydeck
        {
            get { return toolsCraneOrCarrydeckCheckBox.Checked; }
            set { toolsCraneOrCarrydeckCheckBox.Checked = value; }
        }

        public bool ToolsIsElectricTools
        {
            get { return toolsElectricToolsCheckBox.Checked; }
            set { toolsElectricToolsCheckBox.Checked = value; }
        }

        public bool ToolsIsForklift
        {
            get { return toolsForkliftCheckBox.Checked; }
            set { toolsForkliftCheckBox.Checked = value; }
        }

        public bool ToolsIsHandTools
        {
            get { return toolsHandToolsCheckBox.Checked; }
            set { toolsHandToolsCheckBox.Checked = value; }
        }

        public bool ToolsIsHeavyEquipment
        {
            get { return toolsHeavyEquipmentCheckBox.Checked; }
            set { toolsHeavyEquipmentCheckBox.Checked = value; }
        }

        public bool ToolsIsHEPAVacuum
        {
            get { return toolsHEPAVacuumCheckBox.Checked; }
            set { toolsHEPAVacuumCheckBox.Checked = value; }
        }

        public bool ToolsIsHotTapMachine
        {
            get { return toolsHotTapMachineCheckBox.Checked; }
            set { toolsHotTapMachineCheckBox.Checked = value; }
        }

        public bool ToolsIsJackhammer
        {
            get { return toolsJackhammerCheckBox.Checked; }
            set { toolsJackhammerCheckBox.Checked = value; }
        }

        public bool ToolsIsLanda
        {
            get { return toolsLandaCheckBox.Checked; }
            set { toolsLandaCheckBox.Checked = value; }
        }

        public bool ToolsIsManlift
        {
            get { return toolsManliftCheckBox.Checked; }
            set { toolsManliftCheckBox.Checked = value; }
        }

        public bool ToolsIsPortLighting
        {
            get { return toolsPortLightingCheckBox.Checked; }
            set { toolsPortLightingCheckBox.Checked = value; }
        }

        public bool ToolsIsScaffolding
        {
            get { return toolsScaffoldingCheckBox.Checked; }
            set { toolsScaffoldingCheckBox.Checked = value; }
        }

        public bool ToolsIsTamper
        {
            get { return toolsTamperCheckBox.Checked; }
            set { toolsTamperCheckBox.Checked = value; }
        }

        public bool ToolsIsTorch
        {
            get { return toolsTorchCheckBox.Checked; }
            set { toolsTorchCheckBox.Checked = value; }
        }

        public bool ToolsIsVacuumTruck
        {
            get { return toolsVacuumTruckCheckBox.Checked; }
            set { toolsVacuumTruckCheckBox.Checked = value; }
        }

        public bool ToolsIsVehicle
        {
            get { return toolsVehicleCheckBox.Checked; }
            set { toolsVehicleCheckBox.Checked = value; }
        }

        public bool ToolsIsWelder
        {
            get { return toolsWelderCheckBox.Checked; }
            set { toolsWelderCheckBox.Checked = value; }
        }

        public bool ToolsIsChemicals
        {
            get { return toolsChemicalsCheckBox.Checked; }
            set { toolsChemicalsCheckBox.Checked = value; }
        }

        public bool ToolsIsOtherTools
        {
            get { return toolsOtherToolsDescriptionTextBoxCheckBox.CheckBoxChecked; }
            set { }  // set automatically by ToolsOtherToolsDescription
        }

        public string ToolsOtherToolsDescription
        {
            get { return toolsOtherToolsDescriptionTextBoxCheckBox.Text; }
            set { toolsOtherToolsDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool ToolsIsCompressor
        {
            get { return toolsCompressorCheckBox.Checked; }
            set { toolsCompressorCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodNotApplicable
        {
            get { return equipmentIsolationMethodNACheckBox.Checked; }
            set { equipmentIsolationMethodNACheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodMudderPlugs
        {
            get { return equipmentIsolationMethodMudderPlugsCheckBox.Checked; }
            set { equipmentIsolationMethodMudderPlugsCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodSeparation
        {
            get { return equipmentIsolationMethodSeparationCheckBox.Checked; }
            set { equipmentIsolationMethodSeparationCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodBlindedorBlanked
        {
            get { return equipmentIsolationMethodBlindedOrBlankedCheckBox.Checked; }
            set { equipmentIsolationMethodBlindedOrBlankedCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodCarBer
        {
            get { return equipmentIsolationMethodCarBerCheckBox.Checked; }
            set { equipmentIsolationMethodCarBerCheckBox.Checked = value; }
        }

        public string EquipmentIsolationMethodOtherDescription
        {
            get { return equipmentIsolationMethodOtherDescriptionTextBoxCheckBox.Text; }
            set { equipmentIsolationMethodOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool EquipmentIsElectricalIsolationMethodNotApplicable
        {
            get { return electricIsolationMethodNACheckBox.Checked; }
            set { electricIsolationMethodNACheckBox.Checked = value; }
        }

        public bool EquipmentIsElectricalIsolationMethodLOTO
        {
            get { return electricIsolationMethodLOTOCheckBox.Checked; }
            set { electricIsolationMethodLOTOCheckBox.Checked = value; }
        }

        public bool EquipmentIsIsolationMethodLOTO
        {
            get { return equipmentIsolationMethodLOTOCheckBox.Checked; }
            set { equipmentIsolationMethodLOTOCheckBox.Checked = value; }
        }

        public bool EquipmentIsElectricalIsolationMethodWiring
        {
            get { return electricIsolationMethodWiringDisconnectedCheckBox.Checked; }
            set { electricIsolationMethodWiringDisconnectedCheckBox.Checked = value; }
        }

        public bool EquipmentIsPreviousContentsNotApplicable
        {
            get { return equipmentPreviousContentsNACheckBox.Checked; }
            set { equipmentPreviousContentsNACheckBox.Checked = value; }
        }

        public bool EquipmentIsPreviousContentsAcid
        {
            get { return equipmentPreviousContentsAcidCheckBox.Checked; }
            set { equipmentPreviousContentsAcidCheckBox.Checked = value; }
        }

        public bool EquipmentIsPreviousContentsCaustic
        {
            get { return equipmentPreviousContentsCausticCheckBox.Checked; }
            set { equipmentPreviousContentsCausticCheckBox.Checked = value; }
        }

        public bool EquipmentIsPreviousContentsH2S
        {
            get { return equipmentPreviousContentsH2SCheckBox.Checked; }
            set { equipmentPreviousContentsH2SCheckBox.Checked = value; }
        }

        public bool EquipmentIsPreviousContentsHydrocarbon
        {
            get { return equipmentPreviousContentsHydrocarbonCheckBox.Checked; }
            set { equipmentPreviousContentsHydrocarbonCheckBox.Checked = value; }
        }

        public string EquipmentPreviousContentsOtherDescription
        {
            get { return equipmentPreviousContentsOtherDescriptionTextBoxCheckBox.Text; }
            set { equipmentPreviousContentsOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool EquipmentIsConditionNotApplicable
        {
            get { return equipmentConditionNACheckBox.Checked; }
            set { equipmentConditionNACheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionCleaned
        {
            get { return equipmentConditionCleanedCheckBox.Checked; }
            set { equipmentConditionCleanedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionDepressured
        {
            get { return equipmentConditionDepressuredCheckBox.Checked; }
            set { equipmentConditionDepressuredCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionDrained
        {
            get { return equipmentConditionDrainedCheckBox.Checked; }
            set { equipmentConditionDrainedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionH20Washed
        {
            get { return equipmentConditionH20WashedCheckBox.Checked; }
            set { equipmentConditionH20WashedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionNeutralized
        {
            get { return equipmentConditionNeutralizedCheckBox.Checked; }
            set { equipmentConditionNeutralizedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionPurged
        {
            get { return equipmentConditionPurgedCheckBox.Checked; }
            set { equipmentConditionPurgedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionVentilated
        {
            get { return equipmentConditionVentilatedCheckBox.Checked; }
            set { equipmentConditionVentilatedCheckBox.Checked = value; }
        }

        public string EquipmentConditionPurgedDescription
        {
            get { return equipmentConditionPurgedMethodTextBox.Text; }
            set { equipmentConditionPurgedMethodTextBox.Text = value; }
        }

        public bool EquipmentIsLeakingValvesNotApplicable
        {
            get { return equipmentLeakingValvesNACheckBox.Checked; }
            set { equipmentLeakingValvesNACheckBox.Checked = value; }
        }

        public bool? EquipmentIsLeakingValves
        {
            get
            {
                return GetNullableBooleanFromRadioButtons(equipmentLeakingValvesYesRadioButton,
                                                   equipmentLeakingValvesNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(equipmentLeakingValvesYesRadioButton,
                                                      equipmentLeakingValvesNoRadioButton,
                                                      value);
            }
        }

        public bool EquipmentIsStillContainsResidualNotApplicable
        {
            get { return equipmentStillContainsResidualValvesNACheckBox.Checked; }
            set { equipmentStillContainsResidualValvesNACheckBox.Checked = value; }
        }

        public bool? EquipmentIsStillContainsResidual
        {
            get
            {
                return
                    GetNullableBooleanFromRadioButtons(equipmentStillContainsResidualYesRadioButton,
                                                       equipmentStillContainsResidualNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(equipmentStillContainsResidualYesRadioButton,
                                                      equipmentStillContainsResidualNoRadioButton,
                                                      value);
            }
        }


        public bool EquipmentIsTestBumpNotApplicable
        {
            get { return equipmentElectricalTestBumpNACheckBox.Checked; }
            set { equipmentElectricalTestBumpNACheckBox.Checked = value; }
        }

        public bool? EquipmentIsTestBump
        {
            get
            {
                return GetNullableBooleanFromRadioButtons(equipmentElectricBumpTestYesRadioButton,
                                                          equipmentElectricBumpTestNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(equipmentElectricBumpTestYesRadioButton,
                                                      equipmentElectricBumpTestNoRadioButton,
                                                      value);
            }
        }

        public bool EquipmentIsVentilationMethodNotApplicable
        {
            get { return equipmentVentilationMethodNACheckBox.Checked; }
            set { equipmentVentilationMethodNACheckBox.Checked = value; }
        }

        public bool EquipmentIsVentilationMethodForced
        {
            get { return equipmentVentilationMethodForcedCheckBox.Checked; }
            set { equipmentVentilationMethodForcedCheckBox.Checked = value; }
        }

        public bool EquipmentIsVentilationMethodLocalExhaust
        {
            get { return equipmentVentilationMethodLocalExhaustCheckBox.Checked; }
            set { equipmentVentilationMethodLocalExhaustCheckBox.Checked = value; }
        }

        public bool EquipmentIsVentilationMethodNaturalDraft
        {
            get { return equipmentVentilationMethodNaturalDraftCheckBox.Checked; }
            set { equipmentVentilationMethodNaturalDraftCheckBox.Checked = value; }
        }

        public bool RadiationIsSealedSourceIsolationNotApplicable
        {
            get { return radiationSealedSourceIsolationNACheckBox.Checked; }
            set { radiationSealedSourceIsolationNACheckBox.Checked = value; }
        }

        public bool RadiationIsSealedSourceIsolationLOTO
        {
            get { return radiationSealedSourceIsolationLOTOCheckBox.Checked; }
            set { radiationSealedSourceIsolationLOTOCheckBox.Checked = value; }
        }

        public bool FireIsNotApplicable
        {
            get { return fireConfinedSpaceProtectionNACheckBox.Checked; }
            set { fireConfinedSpaceProtectionNACheckBox.Checked = value; }
        }

        public bool FireIsC02Extinguisher
        {
            get { return fireConfinedSpaceC02ExtinguisherCheckBox.Checked; }
            set { fireConfinedSpaceC02ExtinguisherCheckBox.Checked = value; }
        }

        public bool FireIsFireResistantTarp
        {
            get { return fireConfinedSpaceFireResistantTarpCheckBox.Checked; }
            set { fireConfinedSpaceFireResistantTarpCheckBox.Checked = value; }
        }

        public bool FireIsSparkContainment
        {
            get { return fireConfinedSpaceSparkContainmentCheckBox.Checked; }
            set { fireConfinedSpaceSparkContainmentCheckBox.Checked = value; }
        }

        public bool FireIsSteamHose
        {
            get { return fireConfinedSpaceSteamHoseCheckBox.Checked; }
            set { fireConfinedSpaceSteamHoseCheckBox.Checked = value; }
        }

//        public bool FireIsTwentyABCorDryChemicalExtinguisher
//        {
//            get { return fireConfinedSpace20ABCorDryChemicalExtinguisherCheckBox.Checked; }
//            set { fireConfinedSpace20ABCorDryChemicalExtinguisherCheckBox.Checked = value; }        
//        }

        public string FireHoleWatchNumber
        {
            get { return fireConfinedSpaceHoleWatchNumber.Text; }
            set { fireConfinedSpaceHoleWatchNumber.Text = value;  }
        }

        public string FireFireWatchNumber
        {
            get { return fireConfinedSpaceFireWatchNumber.Text; }
            set { fireConfinedSpaceFireWatchNumber.Text = value; }
        }

        public string FireSpotterNumber
        {
            get { return fireConfinedSpaceSpotterNumber.Text; }
            set { fireConfinedSpaceSpotterNumber.Text = value; }
        }

        public bool FireIsWaterHose
        {
            get { return fireConfinedSpaceWaterHoseCheckBox.Checked; }
            set { fireConfinedSpaceWaterHoseCheckBox.Checked = value; }
        }

        public string FireOtherDescription
        {
            get { return fireConfinedSpaceOtherDescriptionTextBoxCheckBox.Text; }
            set { fireConfinedSpaceOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool RespiratoryIsNotApplicable
        {
            get { return respiratoryProtectionRequirementsNACheckBoxCheckBox.Checked; }
            set { respiratoryProtectionRequirementsNACheckBoxCheckBox.Checked = value; }
        }

        public bool RespiratoryIsAirCartorAirLine
        {
            get { return respiratoryProtectionRequirementsAirCartOrAirLineCheckBox.Checked; }
            set { respiratoryProtectionRequirementsAirCartOrAirLineCheckBox.Checked = value; }
        }

        public bool RespiratoryIsFullFaceRespirator
        {
            get { return respiratoryProtectionRequirementsFullFaceRespiratorCheckBox.Checked; }
            set { respiratoryProtectionRequirementsFullFaceRespiratorCheckBox.Checked = value; }
        }

        public bool RespiratoryIsHalfFaceRespirator
        {
            get { return respiratoryProtectionRequirementsHalfFaceRespiratorCheckBox.Checked; }
            set { respiratoryProtectionRequirementsHalfFaceRespiratorCheckBox.Checked = value; }
        }

        public bool RespiratoryIsAirHood
        {
            get { return respiratoryProtectionRequirementsAirHoodCheckBox.Checked; }
            set { respiratoryProtectionRequirementsAirHoodCheckBox.Checked = value; }
        }

        public bool RespiratoryIsSCBA
        {
            get { return respiratoryProtectionRequirementsSCBACheckBox.Checked; }
            set { respiratoryProtectionRequirementsSCBACheckBox.Checked = value; }
        }

        public string RespiratoryOtherDescription
        {
            get { return respiratoryProtectionRequirementsOtherDescriptionTextBoxCheckBox.Text; }
            set { respiratoryProtectionRequirementsOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public WorkPermitRespiratoryCartridgeType RespiratoryCartridgeType
        {
            get
            {
                if (respiratoryProtectionCartridgeTypeOVAG.Checked) return WorkPermitRespiratoryCartridgeType.OV_AG;
                if (respiratoryProtectionCartridgeTypeOVAGHEPA.Checked) return WorkPermitRespiratoryCartridgeType.OV_AG_HEPA;
                if (respiratoryProtectionCartridgeTypeHEPA.Checked) return WorkPermitRespiratoryCartridgeType.HEPA;
                if (respiratoryProtectionCartridgeTypeAmmonia.Checked) return WorkPermitRespiratoryCartridgeType.AMMONIA;
                return null;
            }
            set
            {
                respiratoryProtectionCartridgeTypeOVAG.Checked = WorkPermitRespiratoryCartridgeType.OV_AG.Equals(value);
                respiratoryProtectionCartridgeTypeOVAGHEPA.Checked = WorkPermitRespiratoryCartridgeType.OV_AG_HEPA.Equals(value);
                respiratoryProtectionCartridgeTypeHEPA.Checked = WorkPermitRespiratoryCartridgeType.HEPA.Equals(value);
                respiratoryProtectionCartridgeTypeAmmonia.Checked = WorkPermitRespiratoryCartridgeType.AMMONIA.Equals(value);
            }
        }

        public bool SpecialPPEIsEyeOrFaceProtectionNotApplicable
        {
            get { return specialEyeOrFaceProtectionNACheckBox.Checked; }
            set { specialEyeOrFaceProtectionNACheckBox.Checked = value; }
        }

        public bool SpecialPPEIsEyeOrFaceProtectionFaceshield
        {
            get { return specialEyeOrFaceProtectionFaceshieldCheckBox.Checked; }
            set { specialEyeOrFaceProtectionFaceshieldCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsEyeOrFaceProtectionGoggles
        {
            get { return specialEyeOrFaceProtectionGogglesCheckBox.Checked; }
            set { specialEyeOrFaceProtectionGogglesCheckBox.Checked = value; }
        }

        public string SpecialPPEEyeOrFaceProtectionOtherDescription
        {
            get { return specialEyeOrFaceProtectionOtherDescriptionTextBoxCheckBox.Text; }
            set { specialEyeOrFaceProtectionOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool SpecialPPEIsHandProtectionNotApplicable
        {
            get { return specialProtectiveHandProtectionNACheckBox.Checked; }
            set { specialProtectiveHandProtectionNACheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionChemicalGloves
        {
            get { return specialHandProtectionChemicalGlovesCheckBox.Checked; }
            set { specialHandProtectionChemicalGlovesCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionHighVoltage
        {
            get { return specialHandProtectionHighVoltageCheckBox.Checked; }
            set { specialHandProtectionHighVoltageCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionNitrile
        {
            get { return specialHandProtectionNitrileCheckBox.Checked; }
            set { specialHandProtectionNitrileCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionWelding
        {
            get { return specialHandProtectionWeldingCheckBox.Checked; }
            set { specialHandProtectionWeldingCheckBox.Checked = value; }
        }

        public string SpecialPPEHandProtectionOtherDescription
        {
            get { return specialHandProtectionOtherDescriptionTextBoxCheckBox.Text; }
            set { specialHandProtectionOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeNotApplicable
        {
            get { return specialProtectiveClothingNACheckBox.Checked; }
            set { specialProtectiveClothingNACheckBox.Checked = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeTyvekSuit
        {
            get { return specialProtectiveClothingTyvekSuitCheckBox.Checked; }
            set { specialProtectiveClothingTyvekSuitCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeKapplerSuit
        {
            get { return specialProtectiveClothingKapplerSuitCheckBox.Checked; }
            set { specialProtectiveClothingKapplerSuitCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeElectricalFlashGear
        {
            get { return specialProtectiveClothingElectricalFlashGearCheckBox.Checked; }
            set { specialProtectiveClothingElectricalFlashGearCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeCorrosiveClothing
        {
            get { return specialProtectiveClothingCorrosiveClothingCheckBox.Checked; }
            set { specialProtectiveClothingCorrosiveClothingCheckBox.Checked = value; }
        }

        public string SpecialPPEProtectiveClothingTypeOtherDescription
        {
            get { return specialProtectiveClothingOtherDescriptonTextBoxCheckBox.Text; }
            set { specialProtectiveClothingOtherDescriptonTextBoxCheckBox.Text = value; }
        }

        public bool SpecialPPEIsProtectiveFootwearNotApplicable
        {
            get { return specialProtectiveFootWearNACheckBox.Checked; }
            set { specialProtectiveFootWearNACheckBox.Checked = value; }
        }

        public bool SpecialPPEIsProtectiveFootwearChemicalImperviousBoots
        {
            get { return specialProtectiveFootwearChemicalImperviousBootsCheckBox.Checked; }
            set { specialProtectiveFootwearChemicalImperviousBootsCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsProtectiveFootwearToeGuard
        {
            get { return specialProtectiveFootwearToeGuardCheckBox.Checked; }
            set { specialProtectiveFootwearToeGuardCheckBox.Checked = value; }
        }

        public string SpecialPPEProtectiveFootwearOtherDescription
        {
            get { return specialProtectiveFootwearOtherDescriptionTextBoxCheckBox.Text; }
            set { specialProtectiveFootwearOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool SpecialPPEIsRescueOrFallNotApplicable
        {
            get { return specialProtectiveRescueAndFallNACheckBox.Checked; }
            set { specialProtectiveRescueAndFallNACheckBox.Checked = value; }
        }
        public bool SpecialPPEIsRescueOrFallBodyHarness
        {
            get { return specialRescueOrFallBodyHarnessCheckBox.Checked; }
            set { specialRescueOrFallBodyHarnessCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsRescueOrFallLifeline
        {
            get { return specialRescueOrFallLifelineCheckBox.Checked; }
            set { specialRescueOrFallLifelineCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsRescueOrFallRescueDevice
        {
            get { return specialRescueOrFallRescueDeviceCheckBox.Checked; }
            set { specialRescueOrFallRescueDeviceCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsRescueOrFallYoYo
        {
            get { return specialRescueOrFallYoYoCheckBox.Checked; }
            set { specialRescueOrFallYoYoCheckBox.Checked = value; }
        }

        public string SpecialPPERescueOrFallOtherDescription
        {
            get { return specialRescueOrFallOtherDescriptionTextBoxCheckBox.Text; }
            set { specialRescueOrFallOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool? SpecialPPEFallTieoffRequired
        {
            get
            {
                if (specialFallTieoffRequiredYesRadioButton.Checked)
                {
                    return true;
                }
                else if (specialFallTieoffRequiredNoRadioButton.Checked)
                {
                    return false;
                }

                return null;
            }
            set
            {
                if (value != null)
                {
                    if (value.Value)
                    {
                        specialFallTieoffRequiredYesRadioButton.Checked = true;
                    }
                    else
                    {
                        specialFallTieoffRequiredNoRadioButton.Checked = true;
                    }
                }
            }
        }

        public bool SpecialPPEFallRestraint
        {
            get { return specialFallRestraintCheckBox.Checked; }
            set { specialFallRestraintCheckBox.Checked = value; }
        }

        public bool SpecialPPEFallSelfRetractingDevice
        {
            get { return specialFallSelfRetractingDeviceCheckBox.Checked; }
            set { specialFallSelfRetractingDeviceCheckBox.Checked = value; }
        }

        public string SpecialPPEFallOtherDescription
        {
            get { return specialFallOtherCheckBoxTextBox.Text; }
            set { specialFallOtherCheckBoxTextBox.Text = value; }
        }

        public string SpecialPrecautionsOrConsiderations
        {
            get { return specialPrecautionsOrConsiderationsDescriptionTextBox.Text; }
            set { specialPrecautionsOrConsiderationsDescriptionTextBox.Text = value; }
        }

        public bool? IsCoauthorizationRequired
        {
            get
            {
                return GetNullableBooleanFromRadioButtons(coAuthorizationRequiredYesRadioButton,
                                                          coAuthorizationRequiredNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(coAuthorizationRequiredYesRadioButton,
                                                      coAuthorizationRequiredNoRadioButton,
                                                      value);
            }
        }

        public string CoauthorizationDescription
        {
            get { return coAuthorizationRequiredDescriptionTextBox.Text; }
            set { coAuthorizationRequiredDescriptionTextBox.Text = value; }
        }


        public bool JobWorksiteIsLightingElectricalRequirementNotApplicable
        {
            get { return jobSitePreparationLightingElectricalRequirementNACheckBox.Checked; }
            set { jobSitePreparationLightingElectricalRequirementNACheckBox.Checked = value; }
        }

        public string JobWorksiteLightingElectricalRequirementOtherDescription
        {
            get { return jobSitePreparationLightingElectricalRequirementOtherDescriptionTextBoxCheckBox.Text; }
            set { jobSitePreparationLightingElectricalRequirementOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool JobWorksiteIsLightingElectricalRequirementGeneratorLights
        {
            get { return jobSitePreparationLightingElectricalRequirementGeneratorLightsCheckBox.Checked; }
            set { jobSitePreparationLightingElectricalRequirementGeneratorLightsCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsLightingElectricalRequirement110VWithGFCI
        {
            get { return jobSitePreparationLightingElectricalRequirement110VWithGFCICheckBox.Checked; }
            set { jobSitePreparationLightingElectricalRequirement110VWithGFCICheckBox.Checked = value; }
        }

        public bool JobWorksiteIsLightingElectricalRequirementLowVoltage12V
        {
            get { return jobSitePreparationLightingElectricalRequirementLowVoltage12VCheckBox.Checked; }
            set { jobSitePreparationLightingElectricalRequirementLowVoltage12VCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsAreaPreparationNotApplicable
        {
            get { return jobSitePreparationAreaPreparationNACheckBox.Checked; }
            set { jobSitePreparationAreaPreparationNACheckBox.Checked = value; }
        }

        public string JobWorksiteAreaPreparationOtherDescription
        {
            get { return jobSitePreparationAreaPreparationOtherDescriptionTextBoxCheckBox.Text; }
            set { jobSitePreparationAreaPreparationOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool JobWorksiteIsAreaPreparationBoundaryRopeTape
        {
            get { return jobSitePreparationAreaPreparationBoundaryRopeTapeCheckBox.Checked; }
            set { jobSitePreparationAreaPreparationBoundaryRopeTapeCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsAreaPreparationRadiationRope
        {
            get { return jobSitePreparationAreaPreparationRadiationRopeCheckBox.Checked; }
            set { jobSitePreparationAreaPreparationRadiationRopeCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsAreaPreparationNonEssentialEvac
        {
            get { return jobSitePreparationAreaPreparationNonEssentialEvacCheckBox.Checked; }
            set { jobSitePreparationAreaPreparationNonEssentialEvacCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsAreaPreparationBarricade
        {
            get { return jobSitePreparationAreaPreparationBarricadeCheckBox.Checked; }
            set { jobSitePreparationAreaPreparationBarricadeCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsSewerIsolationMethodNotApplicable
        {
            get { return jobSitePreparationSewerIsolationMethodNACheckBox.Checked; }
            set { jobSitePreparationSewerIsolationMethodNACheckBox.Checked = value; }
        }

        public string JobWorksiteSewerIsolationMethodOtherDescription
        {
            get { return jobSitePreparationSewerIsolationMethodOtherDescriptionTextBoxCheckBox.Text; }
            set { jobSitePreparationSewerIsolationMethodOtherDescriptionTextBoxCheckBox.Text = value; }
        }

        public bool JobWorksiteIsSewerIsolationMethodBlindedOrBlanked
        {
            get { return jobSitePreparationSewerIsolationMethodBlindedOrBlankedCheckBox.Checked; }
            set { jobSitePreparationSewerIsolationMethodBlindedOrBlankedCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsSewerIsolationMethodPlugged
        {
            get { return jobSitePreparationSewerIsolationMethodPluggedCheckBox.Checked; }
            set { jobSitePreparationSewerIsolationMethodPluggedCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsSewerIsolationMethodSealedOrCovered
        {
            get { return jobSitePreparationSewerIsolationMethodSealedOrCoveredCheckBox.Checked; }
            set { jobSitePreparationSewerIsolationMethodSealedOrCoveredCheckBox.Checked = value; }
        }


        public bool JobWorksiteIsSurroundingConditionsAffectOrContaminatedNotApplicable
        {
            get { return jobSitePreparationSurroundingConditionsAffectOrContaminatedNACheckBox.Checked; }
            set { jobSitePreparationSurroundingConditionsAffectOrContaminatedNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsSurroundingConditionsAffectOrContaminated
        {
            get
            {
                return
                    GetNullableBooleanFromRadioButtons(
                        jobSitePreparationSurroundingConditionsAffectOrContaminatedYesRadioButton,
                        jobSitePreparationSurroundingConditionsAffectOrContaminatedNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(
                    jobSitePreparationSurroundingConditionsAffectOrContaminatedYesRadioButton,
                    jobSitePreparationSurroundingConditionsAffectOrContaminatedNoRadioButton,
                    value);
            }
        }

        public bool JobWorksiteIsBondingOrGroundingRequiredNotApplicable
        {
            get { return jobSitePreparationBondingOrGroundingRequiredNACheckBox.Checked; }
            set { jobSitePreparationBondingOrGroundingRequiredNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsBondingOrGroundingRequired
        {
            get
            {
                return
                    GetNullableBooleanFromRadioButtons(jobSitePreparationBondingOrGroundingRequiredYesRadioButton,
                                                       jobSitePreparationBondingOrGroundingRequiredNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(jobSitePreparationBondingOrGroundingRequiredYesRadioButton,
                                                      jobSitePreparationBondingOrGroundingRequiredNoRadioButton,
                                                      value);
            }
        }

        public bool JobWorksiteIsFlowRequiredForJobNotApplicable
        {
            get { return jobsitePreparationFlowRequiredForJobNACheckBox.Checked; }
            set { jobsitePreparationFlowRequiredForJobNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsFlowRequiredForJob
        {
            get
            {
                return GetNullableBooleanFromRadioButtons(jobsitePreparationFlowRequiredForJobYesRadioButton,
                                                          jobsitePreparationFlowRequiredForJobNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(jobsitePreparationFlowRequiredForJobYesRadioButton,
                                                      jobsitePreparationFlowRequiredForJobNoRadioButton,
                                                      value);
            }
        }

        public bool EquipmentIsIsolationMethodOtherItem
        {
            get { return equipmentIsolationMethodOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        public bool EquipmentIsPreviousContentsOtherItem
        {
            get { return equipmentPreviousContentsOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        public bool FireIsOtherItemDescription
        {
            get { return fireConfinedSpaceOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        public bool RespiratoryIsOtherItemDescription
        {
            get { return respiratoryProtectionRequirementsOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        public bool SpecialPPEIsEyeOrFaceOtherItemDescription
        {
            get { return specialEyeOrFaceProtectionOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        public bool SpecialPPEIsHandProtectionOtherItemDescription
        {
            get { return specialHandProtectionOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        public bool SpecialPPEIsProtectiveClothingOtherItemDescription
        {
            get { return specialProtectiveClothingOtherDescriptonTextBoxCheckBox.CheckBoxChecked; }
        }


        public bool SpecialPPEIsProtectiveFootwearOtherItemDescription
        {
            get { return specialProtectiveFootwearOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }


        public bool SpecialPPEIsRescueOrFallOtherItemDescription
        {
            get { return specialRescueOrFallOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }


        public bool JobWorksiteIsLightingElectricalRequirementOtherItemDescription
        {
            get { return jobSitePreparationLightingElectricalRequirementOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        public bool JobWorksiteIsAreaPreparationOtherItemDescription
        {
            get { return jobSitePreparationAreaPreparationOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        public bool JobWorksiteIsSewerIsolationMethodOtherItemDescription
        {
            get { return jobSitePreparationSewerIsolationMethodOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        #region Gas Tests

        public string GasTestsFrequencyOrDuration
        {
            get { return gasTestFrequencyOrDurationTextBox.Text; }
            set { gasTestFrequencyOrDurationTextBox.Text = value; }
        }

        public bool GasTestsConstantMonitoringRequired
        {
            get { return gasTestConstantMonitoringRequiredCheckBox.Checked; }
            set { gasTestConstantMonitoringRequiredCheckBox.Checked = value; }
        }

        public bool GasTestsForkliftNotUsed
        {
            get { return gasTestForkliftNotUsedCheckBox.Checked; }
            set { gasTestForkliftNotUsedCheckBox.Checked = value; }
        }

        public override List<IGasTestElementDetails> GasTestElementDetailsList
        {
            get
            {
                return gasTestElementInfoTableLayoutPanel.GasTestElementDetailsList;
            }
        }

        public bool GasTestEventsEnabled
        {
            set {  }
        }

        internal override OltExplorerBar ExplorerBar
        {
            get { return explorerBarMain; }
        }

        #endregion Gas Tests

        #endregion IWorkPermitFormView Members

        public bool RespiratoryCartridgeTypeTextBoxEnabled
        {
            // TODO: This is not applicable to USPipeline.  We should remove this from the IWorkPermitFormView interface,
            //  as it is Sarnia specific.
            get { return false;  } // return respiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox.Enabled; }
            set {  } //respiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        #region event handlers for gui - Should be enabling / disabling only or setting caption label

        private void workPermitType_CheckedChanged(object sender, EventArgs e)
        {
            permitTypeLabelData.Text = workPermitTypeColdRadioButton.Checked ? StringResources.WorkPermitCold : StringResources.WorkPermitHot;
        }

        public void communicationMethod_CheckedChanged(object sender, EventArgs e)
        {
            //enable channel&color if radio is clicked else enable other
            communicationMethodOtherRadioButton.Enabled = true;
            communicationMethodRadioRadioButton.Enabled = true;
            communicationOtherDescriptionTextBox.Enabled = !communicationMethodRadioRadioButton.Checked;

            communicationRadioChannelTextBox.Enabled = communicationMethodRadioRadioButton.Checked;
            communicationRadioChannelLabel.Enabled = communicationMethodRadioRadioButton.Checked;
        }

        private void coAuthorizationRequired_CheckedChanged(object sender, EventArgs e)
        {
            coAuthorizationRequiredDescriptionTextBox.Enabled = coAuthorizationRequiredYesRadioButton.Checked;
        }

        private void equipmentConditionPurgedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            equipmentConditionPurgedMethodTextBox.Enabled = equipmentConditionPurgedCheckBox.Checked;
        }

        private void communicationMethodsNACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (communicationMethodsNACheckBox.Checked)
            {
                NACheckBox_CheckedChanged(sender, e);
            }
            else
            {
                communicationMethod_CheckedChanged(sender, e);
            }
        }

        /// <summary>
        /// Controls All NA checkboxes that are contained withing a groupbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is OltCheckBox)
            {
                var oltCheckBox = (OltCheckBox)sender;

                SetGroupBoxItems(oltCheckBox);

                SetupSpecialPrecautionsCommentsArea(); //for certain boxes only
            }
        }

        protected override void DisableItemsThatShouldBeDisabled()
        {
            equipmentConditionPurgedCheckBox_CheckedChanged(this, new EventArgs());
        }


        #endregion  event handlers for gui - Should be enabling / disabling only

        #region IWorkPermitFormView Members DataLists

        public List<CraftOrTrade> CraftOrTrades
        {
            get { return workPermitCraftOrTradeControl.SystemCraftOrTradeChoices; }
            set { workPermitCraftOrTradeControl.SystemCraftOrTradeChoices = value; }
        }

        public List<Contractor> Contractors
        {
            set { workPermitContractorNameControl.Contractors = value; }
        }

        public IList<AcidClothingType> AcidClothingTypes
        {
            // TODO: If the acid control could have it's own presenter, we wouldn't need to do this.
            set { }
        }

        #endregion

        #region Authorization

        public void SetContractorFieldsToDefaultState()
        {
            workPermitContractorNameControl.InitializeToDefaultState();
        }

        #endregion

        public void SetInitialFocus()
        {
            workPermitTypeGroupBox.Focus();
        }

        public bool HasWorkAssignmentFunctionality
        {
            get { return false; }
        }

        public WorkAssignment WorkAssignment
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public List<WorkAssignment> WorkAssignmentSelectionList
        {
            set { throw new NotImplementedException(); }
        }


        public bool ControlRoomsHasBeenContactedGroupBox
        {
            
            get; set;
        }

        public bool IsFreshAir
        {
            get;
            set;
        }

       
        public bool IsHazardousEnergyIsolationChecked
        {
            get;
            set;
        }

        public bool JobWorksiteIsPermitReceiverFieldNObutton
        {
            get;
            set;
        }

        public bool JobWorksiteIsPermitReceiverFieldOrEquipmentOrientationNotApplicable
        {
            get;
            set;
        }

        public bool AsbestosHazardsConsideredYesRadioButtonChecked
        {
            get;
            set;
        }

        public bool IsAsbestosHazardPanel
        {
            get;
            set;
        }

        public bool EquipmentIsHazardousEnergyIsolationRequiredNotApplicable
        {
            get; set; }

//DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
        public bool FireIsTwentyABCorDryChemicalExtinguisher
        {
            get;
            set;
        }
//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

        public string TemplateName { get; set; }
        public bool IsTemplate { get; set; }
        public bool IsActiveTemplate { get; set; }
    }
}