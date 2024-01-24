using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class WorkPermitFormSarnia : WorkPermitForm, IWorkPermitFormViewSarnia
    {
        /// <summary>
        ///     Constructor used for creating an work permit
        /// </summary>
        public WorkPermitFormSarnia() : this(null)
        {
        }

        /// <summary>
        ///     Constructor used for editing an work permit definition
        /// </summary>
        /// <param name="workPermit">work permit to edit</param>
        //public bool flag = false;
        public WorkPermitFormSarnia(WorkPermit workPermit)
        {
            InitializeComponent();
            PerformLayout();
            var presenter = new WorkPermitFormPresenter<IWorkPermitFormViewSarnia>(this, workPermit);
            Initialize();
            RegisterEventHandlersOnPresenter(presenter);
            RegisterEventHandlersOnForm();
            //if (JobWorksiteIsPermitReceiverFieldOrEquipmentOrientation == true)
            //{
            //    commentsRequiredForRequiredFieldOrientationImageLabel.Visible = true;
            //}
        }

        /// <summary>
        ///     Done so we don't get into a loop when editing date values
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
        ///     Done so we don't get into a loop when editing date values
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

        public void InitializeStandardGasTestElementInfoList(List<GasTestElementInfo> standardGasTestElementInfoList)
        {
            SuspendLayout();
            gasTestInfoExplorerBarContainerControl.SuspendLayout();
            gasTestElementInfoTableLayoutPanel.BuildGasTestElementControls(standardGasTestElementInfoList,
                ClientSession.GetUserContext().Site);
            gasTestInfoExplorerBarContainerControl.ResumeLayout();
            ResumeLayout();
        }

        public bool EquipmentConditionPurgedMethodTextBoxEnabled
        {
            set { ; } // do nothing intentionally
        }

        public void RegisterUIEventHandlers<T>(WorkPermitFormPresenter<T> presenter) where T : IWorkPermitFormView
        {
            burnOpenFlameCheckBox.CheckedChanged += presenter.HandleBurnOpenFlameCheckChanged;
            workPermitTypeHotRadioButton.CheckedChanged += presenter.HandleWorkPermitTypeHotCheckChanged;
            vehicleEntryCheckBox.CheckedChanged += presenter.HandleVehicleEntryCheckChanged;
            excavationCheckBox.CheckedChanged += presenter.HandleExcavationCheckChanged;
            confinedSpaceEntryCheckBox.CheckedChanged += presenter.HandleConfinedSpaceEntryCheckChanged;
            startDatePicker.ValueChanged += presenter.StartDatePickValueChanged;
            radiationRadiographyCheckBox.CheckedChanged += presenter.HandleRadiationRadiographyCheckChanged; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

            jobSitePreparationVestedBuddySystemInEffectYesRadioButton.CheckedChanged +=
                presenter.HandleVestedBuddySystemInEffectYesRadioButtonCheckChanged; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.CheckedChanged +=
                presenter.HandleequipmentIsHazardousEnergyIsolationRequiredYesRadioButtonCheckChanged; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

            equipmentIsHazardousEnergyIsolationRequiredNoRadioButton.CheckedChanged +=
                presenter.HandleequipmentIsHazardousEnergyIsolationRequiredNoRadioButtonCheckChanged; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

            asbestosHazardsConsideredNACheckBox.CheckedChanged +=
                presenter.HandleasbestosHazardsConsideredNACheckBoxCheckChanged; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

            freshAirCheckBox.CheckedChanged +=
                presenter.HandlefreshAirCheckBoxCheckChanged; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

            asbestosHazardsConsideredYesRadioButton.CheckedChanged +=
                presenter.HandleAsbestosHazardsConsideredYesRadioButtonCheckChanged; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButton.CheckedChanged +=
                presenter.HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButtonCheckChanged; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

            jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBox.CheckedChanged +=
                 presenter.HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBoxCheckChanged; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

            jobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButton.CheckedChanged +=
                 presenter.HandlejobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButtonCheckChanged; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 


            //DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
            
            equipmentLockOutMethodIndividualByOperationsRadioButton.CheckedChanged +=
                presenter.HandleequipmentLockOutMethodIndividualByOperationsRadioButtonCheckChanged;

            //END

            if (jobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButton.Checked == true)
            {
                commentsRequiredForRequiredFieldOrientationImageLabel.Visible = true;
            }
        }

        public bool RespiratoryCartridgeTypeTextBoxEnabled
        {
            get { return respiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox.Enabled; }
            set { respiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        public void SetInitialFocus()
        {
            workPermitTypeGroupBox.Focus();
        }

        public bool HasWorkAssignmentFunctionality
        {
            get { return true; }
        }

        #region event handlers for gui - Should be enabling / disabling only or setting caption label

        private void workPermitType_CheckedChanged(object sender, EventArgs e)
        {
            permitTypeLabelData.Text = workPermitTypeColdRadioButton.Checked
                ? StringResources.WorkPermitCold
                : StringResources.WorkPermitHot;
        }

        private void EquipmentConditionNaCheckBoxOnCheckedChanged(object sender, EventArgs e)
        {
            NACheckBox_CheckedChanged(sender, e);
        }

        public void communicationMethod_CheckedChanged(object sender, EventArgs e)
        {
            if (!communicationMethodsNACheckBox.Checked)
            {
                //enable channel&color if radio is clicked else enable other
                communicationMethodOtherRadioButton.Enabled = true;
                communicationMethodRadioRadioButton.Enabled = true;
                communicationOtherDescriptionTextBox.Enabled = !communicationMethodRadioRadioButton.Checked;

                communicationRadioChannelTextBox.Enabled = communicationMethodRadioRadioButton.Checked;
                communicationRadioChannelLabel.Enabled = communicationMethodRadioRadioButton.Checked;
                communicationRadioColorLabel.Enabled = communicationMethodRadioRadioButton.Checked;
                communicationRadioColorTextBox.Enabled = communicationMethodRadioRadioButton.Checked;
            }
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

        private void coAuthorizationRequired_CheckedChanged(object sender, EventArgs e)
        {
            coAuthorizationRequiredDescriptionTextBox.Enabled = coAuthorizationRequiredYesRadioButton.Checked;
        }

        /// <summary>
        ///     Controls All NA checkboxes that are contained withing a groupbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is OltCheckBox)
            {
                var oltCheckBox = (OltCheckBox) sender;

                SetGroupBoxItems(oltCheckBox);

                SetupSpecialPrecautionsCommentsArea(); //for certain boxes only
            }
        }

        protected override void DisableItemsThatShouldBeDisabled()
        {
            protectiveClothingControl.DisableItemsThatShouldBeDisabled();
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
            set { protectiveClothingControl.AcidClothingTypes = value; }
        }

        #endregion

        #region Authorization

        public void SetContractorFieldsToDefaultState()
        {
            workPermitContractorNameControl.InitializeToDefaultState();
        }

        #endregion

        /// <summary>
        ///     Form initialization code
        /// </summary>
        private void Initialize()
        {
            requiredSpecialPrecautionsOrConsiderationsGroupBox.Visible = false;
            requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Controls.Clear();
        }

        private void RegisterEventHandlersOnPresenter(WorkPermitFormPresenter<IWorkPermitFormViewSarnia> presenter)
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

            burnOpenFlameCheckBox.CheckedChanged += presenter.HandleOpenFlameChanged; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

            startDatePicker.ValueChanged += startDatePicker_ValueChanged;
            endDatePicker.ValueChanged += endDatePicker_ValueChanged;

            viewEditHistoryButton.Click += presenter.HandleViewEditHistoryButtonClick;

            respiratoryProtectionRequirementsHalfFaceRespiratorCheckBox.CheckedChanged +=
                presenter.RespiratoryProtectionRequirementsHalfFaceRespiratorCheckBox_CheckedChanged;
            respiratoryProtectionRequirementsFullFaceRespiratorCheckBox.CheckedChanged +=
                presenter.RespiratoryProtectionRequirementsFullFaceRespiratorCheckBox_CheckedChanged;

            additionalElectricalTextBoxCheckBox.CheckBox.CheckedChanged +=
                presenter.HandleAdditionalElectricalCheckChanged;
            equipmentLockOutMethodComplexGroupRadioButton.CheckedChanged +=
                presenter.HandleEquipmentLockOutMethodComplexGroupRadioButtonCheckChanged;
            equipmentLockOutMethodComplexGroupRadioButton.EnabledChanged +=
                presenter.HandleEquipmentLockOutMethodComplexGroupRadioButtonCheckChanged;
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
            

            //clicking yes should enable description field
            coAuthorizationRequiredYesRadioButton.CheckedChanged += coAuthorizationRequired_CheckedChanged;
            coAuthorizationRequiredNoRadioButton.CheckedChanged += coAuthorizationRequired_CheckedChanged;

            // click yes will enable other isolation fields
            equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.CheckedChanged +=
                equipmentIsHazardousEnergyIsolationRequired_CheckChanged;
            equipmentIsHazardousEnergyIsolationRequiredNoRadioButton.CheckedChanged +=
                equipmentIsHazardousEnergyIsolationRequired_CheckChanged;

            // lockout method affects eip number and comments
            equipmentLockOutMethodIndividualByWorkerRadioButton.CheckedChanged += equipmentLockOutMethod_CheckChanged;
            equipmentLockOutMethodIndividualByOperationsRadioButton.CheckedChanged +=
                equipmentLockOutMethod_CheckChanged;
            equipmentLockOutMethodComplexGroupRadioButton.CheckedChanged += equipmentLockOutMethod_CheckChanged;

            //clicking NA checkbox should disable All controls in hosted control except NA checkbox            
            equipmentStillContainsResidualValvesNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            equipmentLeakingValvesNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            equipmentPreviousContentsNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            equipmentIsHazardousEnergyIsolationRequiredNACheckBox.CheckedChanged +=
                equipmentIsHazardousEnergyIsolationRequiredNACheckBox_CheckChanged;
            asbestosHazardsConsideredNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobSitePreparationAreaPreparationNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobSitePreparationBondingOrGroundingRequiredNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobSitePreparationCriticalConditionsRemainJobSiteNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;

            jobSitePreparationControlRoomContactedNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;   // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            
            jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBox.CheckedChanged +=
                NACheckBox_CheckedChanged;
            jobSitePreparationSewerIsolationMethodNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            equipmentVentilationMethodNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobSitePreparationVestedBuddySystemInEffectNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobSitePreparationWeldingGroundWireInTestAreaNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            jobSitePreparationSurroundingConditionsAffectOrContaminatedNACheckBox.CheckedChanged +=
                NACheckBox_CheckedChanged;

            fireConfinedSpaceProtectionNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            respiratoryProtectionRequirementsNACheckBoxCheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            specialEyeOrFaceProtectionNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            specialProtectiveFootWearNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            specialProtectiveHandProtectionNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            specialProtectiveRescueAndFallNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;

//            equipmentConditionNACheckBox.CheckedChanged += NACheckBox_CheckedChanged;
            equipmentConditionNACheckBox.CheckedChanged += EquipmentConditionNaCheckBoxOnCheckedChanged;
            communicationMethodsNACheckBox.CheckedChanged += communicationMethodsNACheckBox_CheckedChanged;
            //Amit Shukla RITM0302870 Validation Workpermit on validate button click start
            communicationMethod_CheckedChanged(communicationMethodsNACheckBox, new EventArgs());
            

            //hook up the two buttons that expand or collapse All the groups
            expandAllGroupsButton.Click += expandAllGroupsButton_Click;
            collapseAllGroupsButton.Click += collapseAllGroupsButton_Click;

            //hook up the items that will cause the special comments textbox to appear or disappear
            equipmentEquipmentInServiceRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentEquipmentOutOfServiceRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentStillContainsResidualYesRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentStillContainsResidualNoRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentLeakingValvesNoRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentLeakingValvesYesRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            asbestosHazardsConsideredYesRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            asbestosHazardsConsideredNoRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentConditionsOfEIPSatisfiedYesRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;
            equipmentConditionsOfEIPSatisfiedNoRadioButton.CheckedChanged += commentsRadioButton_CheckedChanged;

            jobSitePreparationBondingOrGroundingRequiredYesRadioButton.CheckedChanged +=
                commentsRadioButton_CheckedChanged;
            jobSitePreparationBondingOrGroundingRequiredNoRadioButton.CheckedChanged +=
                commentsRadioButton_CheckedChanged;
            jobSitePreparationWeldingGroundWireInTestAreaYesRadioButton.CheckedChanged +=
                commentsRadioButton_CheckedChanged;
            jobSitePreparationWeldingGroundWireInTestAreaNoRadioButton.CheckedChanged +=
                commentsRadioButton_CheckedChanged;
            jobSitePreparationSurroundingConditionsAffectOrContaminatedNoRadioButton.CheckedChanged +=
                commentsRadioButton_CheckedChanged;
            jobSitePreparationSurroundingConditionsAffectOrContaminatedYesRadioButton.CheckedChanged +=
                commentsRadioButton_CheckedChanged;
            jobSitePreparationCriticalConditionsRemainJobSiteYesRadioButton.CheckedChanged +=
                commentsRadioButton_CheckedChanged;
            jobSitePreparationCriticalConditionsRemainJobSiteNoRadioButton.CheckedChanged +=
                commentsRadioButton_CheckedChanged;
            jobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButton.CheckedChanged +=
                commentsRadioButton_CheckedChanged;
            jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButton.CheckedChanged +=
                commentsRadioButton_CheckedChanged;

            //jobSitePreparationControlRoomContactedYesRadioButton.CheckedChanged +=// RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia  
            //    commentsRadioButton_CheckedChanged;
            //jobSitePreparationControlRoomContactedNoRadioButton.CheckedChanged +=     // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
            //    commentsRadioButton_CheckedChanged;

            //now we need handlers to manage the textchanged events
            equipmentInServiceCommentsTextBox.TextChanged += equipmentInServiceCommentsTextBox_Click;

            AsbestosHazardCommentsTextBox.TextChanged += AsbestosHazardCommentsTextBox_Click; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 

            stillContainsResidualCommentsTextBox.TextChanged += stillContainsResidualCommentsTextBox_Click;
            leakingValvesCommentsTextBox.TextChanged += leakingValvesCommentsTextBox_Click;
            equipmentLockOutMethodIndividualByWorkerCommentsTextBox.TextChanged +=
                equipmentLockOutMethodIndividualByWorkerCommentsTextBox_TextChanged;
            equipmentLockOutMethodIndividualByOperationsCommentsTextBox.TextChanged +=
                equipmentLockOutMethodIndividualByOperationsCommentsTextBox_TextChanged;
            equipmentConditionsOfEIPNotSatisfiedCommentsTextBox.TextChanged +=
                EquipmentConditionsOfEipNotSatisfiedCommentsTextBoxTextChanged;
            bondingGroundingNotRequiredCommentsTextBox.TextChanged += bondingGroundingNotRequiredCommentsTextBox_Click;
            weldingGroundWireNotWithinGasTestAreaCommentsTextBox.TextChanged +=
                weldingGroundWireNotWithinGasTestAreaCommentsTextBox_Click;
            surroundingConditionsAffectAreaCommentsTextBox.TextChanged +=
                surroundingConditionsAffectAreaCommentsTextBox_TextChanged;
            criticalConditionsCommentsTextBox.TextChanged += criticalConditionsCommentsTextBox_TextChanged;
            permitReceiverRequiresOrientationCommentsTextBox.TextChanged +=
                permitReceiverRequiresOrientationCommentsTextBox_Click;

            //then the 'click here to edit the textbox values' for the label images
            commentsRequiredForCriticalConditionsImageLabel.Click +=
                commentsRequiredForCriticalConditionsImageLabel_Click;

            commentsRequiredForEquipmentInServiceImageLabel.Click +=
                commentsRequiredForEquipmentInServiceImageLabel_Click;

            commentsRequiredForAsbestosHazardImageLabel.Click +=  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                commentsRequiredForAsbestosHazardImageLabel_Click;
            

            commentsRequiredForLeakingValvesImageLabel.Click += commentsRequiredForLeakingValvesImageLabel_Click;
            commentsRequiredForLockOutMethodIndividualByWorkerImageLabel.Click +=
                commentsRequiredForLockOutMethodIndividualByWorkerImageLabel_Click;
            commentsRequiredForLockOutMethodIndividualByOperationsImageLabel.Click +=
                commentsRequiredForLockOutMethodIndividualByOperationsImageLabel_Click;
            commentsRequiredForConditionsOfTheEIPSatisfiedImageLabel.Click +=
                commentsRequiredForConditionsOfTheEIPSatisfiedImageLabel_Click;
            commentsRequiredForNoBondingGroundingImageLabel.Click +=
                commentsRequiredForNoBondingGroundingImageLabel_Click;
            commentsRequiredForNoWeldingGroundWireImageLabel.Click +=
                commentsRequiredForNoWeldingGroundWireImageLabel_Click;
            commentsRequiredForRequiredFieldOrientationImageLabel.Click +=
                commentsRequiredForRequiredFieldOrientationImageLabel_Click;
            commentsRequiredForStillContainsResidualImageLabel.Click +=
                commentsRequiredForStillContainsResidualImageLabel_Click;
            commentsRequiredForSurroundingConditionsContaminatedImageLabel.Click +=
                commentsRequiredForSurroundingConditionsContaminatedImageLabel_Click;
        }

        private void SetupIconsRelatedToSpecialPrecautionsText(Control textBox, Label labelImage)
        {
            if (textBox.Text.IsNullOrEmptyOrWhitespace())
            {
                labelImage.Image = ResourcesResx.warningCommentsRequired;
                toolTip.SetToolTip(labelImage, StringResources.WorkPermitSpecialPrecautionWarningTooltip_CommentRequired);
            }
            else
            {
                var format = "{0} {1}";

                var toolTipText = string.Format(format, StringResources.WorkPermitSpecialPrecautionCommentTooltipPrefix,
                    textBox.Text);

                labelImage.Image = ResourcesResx.informationCommentsProvided;
                toolTip.SetToolTip(labelImage, toolTipText);
            }
        }

        /// <summary>
        ///     Setup the comments visibility and images given the state of yes/no values, Not appicable checkboxes,
        ///     and the contents of the comments textboxes
        /// </summary>
        private void SetupSpecialPrecautionsCommentsArea()
        {
            SetSpecialPrecautionsCommentsArea(permitReceiverRequiresOrientationCommentsPanel,
                commentsRequiredForRequiredFieldOrientationImageLabel,
                permitReceiverRequiresOrientationCommentsTextBox,

//DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes : condition modified
                ((equipmentIsHazardousEnergyIsolationRequiredNoRadioButton.Checked || 
                equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked) &&
                //(!equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked) &&
                jobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButton.Checked &&
                !jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBox.Checked
                ) ||

                (equipmentLockOutMethodIndividualByWorkerRadioButton.Checked && 
                equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked &&
                jobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButton.Checked && 
                !jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBox.Checked &&
                !equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked //&&
                //!equipmentIsHazardousEnergyIsolationRequiredNoRadioButton.Checked
                ) ||

                (equipmentLockOutMethodIndividualByOperationsRadioButton.Checked &&
                equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked &&
                (jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBox.Checked ||
                jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButton.Checked) &&
                !equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked //&&
                //!equipmentIsHazardousEnergyIsolationRequiredNoRadioButton.Checked
                ) ||

                (equipmentLockOutMethodComplexGroupRadioButton.Checked &&
                equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked &&
                (jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBox.Checked ||
                jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButton.Checked) &&
                !equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked //&&
                //!equipmentIsHazardousEnergyIsolationRequiredNoRadioButton.Checked
                )
                
                
                );
                

            SetSpecialPrecautionsCommentsArea(criticalConditionsCommentsPanel,
                commentsRequiredForCriticalConditionsImageLabel,
                criticalConditionsCommentsTextBox,
                jobSitePreparationCriticalConditionsRemainJobSiteYesRadioButton.Checked &&
                !jobSitePreparationCriticalConditionsRemainJobSiteNACheckBox.Checked);

            SetSpecialPrecautionsCommentsArea(surroundingConditionsAffectAreaCommentsPanel,
                commentsRequiredForSurroundingConditionsContaminatedImageLabel,
                surroundingConditionsAffectAreaCommentsTextBox,
                jobSitePreparationSurroundingConditionsAffectOrContaminatedYesRadioButton.Checked &&
                !jobSitePreparationSurroundingConditionsAffectOrContaminatedNACheckBox.Checked);

            SetSpecialPrecautionsCommentsArea(weldingGroundWireNotWithinGasTestAreaCommentsPanel,
                commentsRequiredForNoWeldingGroundWireImageLabel,
                weldingGroundWireNotWithinGasTestAreaCommentsTextBox,
                jobSitePreparationWeldingGroundWireInTestAreaNoRadioButton.Checked &&
                !jobSitePreparationWeldingGroundWireInTestAreaNACheckBox.Checked);

            SetSpecialPrecautionsCommentsArea(bondingGroundingNotRequiredCommentsPanel,
                commentsRequiredForNoBondingGroundingImageLabel,
                bondingGroundingNotRequiredCommentsTextBox,
                jobSitePreparationBondingOrGroundingRequiredNoRadioButton.Checked &&
                !jobSitePreparationBondingOrGroundingRequiredNACheckBox.Checked);

            SetSpecialPrecautionsCommentsArea(equipmentInServiceCommentsPanel,
                commentsRequiredForEquipmentInServiceImageLabel,
                equipmentInServiceCommentsTextBox,
                equipmentEquipmentInServiceRadioButton.Checked);


            SetSpecialPrecautionsCommentsArea(AsbestosHazardCommentsPanel,
                // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                commentsRequiredForAsbestosHazardImageLabel,
                AsbestosHazardCommentsTextBox,

                !asbestosHazardsConsideredNACheckBox.Checked &&
                !asbestosHazardsConsideredNoRadioButton.Checked &&
                asbestosHazardsConsideredYesRadioButton.Checked

                );

                //asbestosHazardsConsideredYesRadioButton.Checked //&& 
                ////!asbestosHazardsConsideredNoRadioButton.Checked //&&
                ////!asbestosHazardsConsideredNACheckBox.Checked  
                //);
            

            SetSpecialPrecautionsCommentsArea(stillContainsResidualCommentsPanel,
                commentsRequiredForStillContainsResidualImageLabel,
                stillContainsResidualCommentsTextBox,
                equipmentStillContainsResidualYesRadioButton.Checked &&
                !equipmentStillContainsResidualValvesNACheckBox.Checked);

            SetSpecialPrecautionsCommentsArea(leakingValvesCommentsPanel,
                commentsRequiredForLeakingValvesImageLabel,
                leakingValvesCommentsTextBox,
                equipmentLeakingValvesYesRadioButton.Checked && !equipmentLeakingValvesNACheckBox.Checked);

            SetSpecialPrecautionsCommentsArea(equipmentLockOutMethodIndividualByWorkerSpecialCommentsPanel,
                commentsRequiredForLockOutMethodIndividualByWorkerImageLabel,
                equipmentLockOutMethodIndividualByWorkerCommentsTextBox,
                !equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked &&
                equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked &&
                equipmentLockOutMethodIndividualByWorkerRadioButton.Checked);

            SetSpecialPrecautionsCommentsArea(equipmentLockOutMethodIndividualByOperationsSpecialCommentsPanel,
                commentsRequiredForLockOutMethodIndividualByOperationsImageLabel,
                equipmentLockOutMethodIndividualByOperationsCommentsTextBox,
                !equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked &&
                equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked &&
                equipmentLockOutMethodIndividualByOperationsRadioButton.Checked);

            SetSpecialPrecautionsCommentsArea(equipmentConditionsOfEIPNotSatisfiedCommentsPanel,
                commentsRequiredForConditionsOfTheEIPSatisfiedImageLabel,
                equipmentConditionsOfEIPNotSatisfiedCommentsTextBox,
                !equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked &&
                equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked &&
                equipmentLockOutMethodComplexGroupRadioButton.Checked &&
                equipmentConditionsOfEIPSatisfiedNoRadioButton.Checked);

            SetSpecialPrecautionsAreaVisibility();
        }

        /// <summary>
        ///     Set an individual panel and labelImage visibility based on the makeVisible boolean value;
        ///     Set the labelimage to a particular image based on the contents (or lack thereof) of the textbox
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="labelImage"></param>
        /// <param name="textBox"></param>
        /// <param name="makeVisible"></param>
        private void SetSpecialPrecautionsCommentsArea(Control panel, Label labelImage, Control textBox,
            bool makeVisible)
        {
            if (makeVisible)
            {
                requiredSpecialPrecautionsOrConsiderationsGroupBox.Visible = true;
                if (!requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Controls.Contains(panel))
                    requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Controls.Add(panel);
                if (panel.Name == "AsbestosHazardCommentsPanel")
                {
                    if (!requiredSpecialPrecautionsOrConsiderationsGroupBox.Controls.Contains(panel))
                        requiredSpecialPrecautionsOrConsiderationsGroupBox.Controls.Add(panel);
                }

                if (labelImage != null)
                {
                    labelImage.Visible = true;
                    SetupIconsRelatedToSpecialPrecautionsText(textBox, labelImage);
                }
                //if (panel.Name == "permitReceiverRequiresOrientationCommentsPanel")
                //{
                //    flag = true;
                //}
            }
            else //make not visible
            {                
                if (requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Controls.Contains(panel))
                    requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Controls.Remove(panel);
                if (panel.Name == "AsbestosHazardCommentsPanel")
                {
                    if (requiredSpecialPrecautionsOrConsiderationsGroupBox.Controls.Contains(panel))
                        requiredSpecialPrecautionsOrConsiderationsGroupBox.Controls.Remove(panel);
                }


                if (labelImage != null)
                {
                    labelImage.Visible = false;
                }
            }
        }
        /// <summary>
        ///     Set the visibility of the whole flow layout in the special precautions area if there are no
        ///     visible panels within it (otherwise we get a squished groupbox on the left)
        /// </summary>
        private void SetSpecialPrecautionsAreaVisibility()
        {
            if (requiredSpecialPrecautionsConsiderationsFlowLayoutPanel.Controls.Count > 0)
                requiredSpecialPrecautionsOrConsiderationsGroupBox.Visible = true;

            //set the zorder of the docked panels (top to bottom)
            equipmentInServiceCommentsPanel.SendToBack();
            stillContainsResidualCommentsPanel.SendToBack();
            leakingValvesCommentsPanel.SendToBack();
            equipmentLockOutMethodIndividualByWorkerSpecialCommentsPanel.SendToBack();
            equipmentLockOutMethodIndividualByOperationsSpecialCommentsPanel.SendToBack();
            equipmentConditionsOfEIPNotSatisfiedCommentsPanel.SendToBack();
            bondingGroundingNotRequiredCommentsPanel.SendToBack();
            weldingGroundWireNotWithinGasTestAreaCommentsPanel.SendToBack();
            surroundingConditionsAffectAreaCommentsPanel.SendToBack();
            criticalConditionsCommentsPanel.SendToBack();
            permitReceiverRequiresOrientationCommentsPanel.SendToBack();
            AsbestosHazardCommentsPanel.SendToBack(); // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        }

        private void commentsRequiredForCriticalConditionsImageLabel_Click(object sender, EventArgs e)
        {
            SetFocusToTextboxInSpecialPrecautionsArea(criticalConditionsCommentsTextBox);
        }

        private void commentsRequiredForSurroundingConditionsContaminatedImageLabel_Click(object sender, EventArgs e)
        {
            SetFocusToTextboxInSpecialPrecautionsArea(surroundingConditionsAffectAreaCommentsTextBox);
        }

        private void commentsRequiredForStillContainsResidualImageLabel_Click(object sender, EventArgs e)
        {
            SetFocusToTextboxInSpecialPrecautionsArea(stillContainsResidualCommentsTextBox);
        }

        private void commentsRequiredForRequiredFieldOrientationImageLabel_Click(object sender, EventArgs e)
        {
            SetFocusToTextboxInSpecialPrecautionsArea(permitReceiverRequiresOrientationCommentsTextBox);
            
        }

        private void commentsRequiredForNoWeldingGroundWireImageLabel_Click(object sender, EventArgs e)
        {
            SetFocusToTextboxInSpecialPrecautionsArea(weldingGroundWireNotWithinGasTestAreaCommentsTextBox);
        }

        private void commentsRequiredForNoBondingGroundingImageLabel_Click(object sender, EventArgs e)
        {
            SetFocusToTextboxInSpecialPrecautionsArea(bondingGroundingNotRequiredCommentsTextBox);
        }

        private void commentsRequiredForEquipmentInServiceImageLabel_Click(object sender, EventArgs e)
        {
            SetFocusToTextboxInSpecialPrecautionsArea(equipmentInServiceCommentsTextBox);
        }

        private void commentsRequiredForAsbestosHazardImageLabel_Click(object sender, EventArgs e) // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            SetFocusToTextboxInSpecialPrecautionsArea(AsbestosHazardCommentsTextBox);
        }

        private void commentsRequiredForLeakingValvesImageLabel_Click(object sender, EventArgs e)
        {
            SetFocusToTextboxInSpecialPrecautionsArea(leakingValvesCommentsTextBox);
        }

        private void commentsRequiredForLockOutMethodIndividualByWorkerImageLabel_Click(object sender, EventArgs e)
        {
            SetFocusToTextboxInSpecialPrecautionsArea(equipmentLockOutMethodIndividualByWorkerCommentsTextBox);
        }

        private void commentsRequiredForLockOutMethodIndividualByOperationsImageLabel_Click(object sender, EventArgs e)
        {
            SetFocusToTextboxInSpecialPrecautionsArea(equipmentLockOutMethodIndividualByOperationsCommentsTextBox);
        }

        private void commentsRequiredForConditionsOfTheEIPSatisfiedImageLabel_Click(object sender, EventArgs e)
        {
            SetFocusToTextboxInSpecialPrecautionsArea(equipmentConditionsOfEIPNotSatisfiedCommentsTextBox);
        }

        private void criticalConditionsCommentsTextBox_TextChanged(object sender, EventArgs e)
        {
            SetupIconsRelatedToSpecialPrecautionsText(criticalConditionsCommentsTextBox,
                commentsRequiredForCriticalConditionsImageLabel);
        }

        private void surroundingConditionsAffectAreaCommentsTextBox_TextChanged(object sender, EventArgs e)
        {
            SetupIconsRelatedToSpecialPrecautionsText(surroundingConditionsAffectAreaCommentsTextBox,
                commentsRequiredForSurroundingConditionsContaminatedImageLabel);
        }

        private void stillContainsResidualCommentsTextBox_Click(object sender, EventArgs e)
        {
            SetupIconsRelatedToSpecialPrecautionsText(stillContainsResidualCommentsTextBox,
                commentsRequiredForStillContainsResidualImageLabel);
        }

        private void leakingValvesCommentsTextBox_Click(object sender, EventArgs e)
        {
            SetupIconsRelatedToSpecialPrecautionsText(leakingValvesCommentsTextBox,
                commentsRequiredForLeakingValvesImageLabel);
        }

        private void equipmentLockOutMethodIndividualByWorkerCommentsTextBox_TextChanged(object sender, EventArgs e)
        {
            SetupIconsRelatedToSpecialPrecautionsText(equipmentLockOutMethodIndividualByWorkerCommentsTextBox,
                commentsRequiredForLockOutMethodIndividualByWorkerImageLabel);
        }

        private void equipmentLockOutMethodIndividualByOperationsCommentsTextBox_TextChanged(object sender, EventArgs e)
        {
            SetupIconsRelatedToSpecialPrecautionsText(equipmentLockOutMethodIndividualByOperationsCommentsTextBox,
                commentsRequiredForLockOutMethodIndividualByOperationsImageLabel);
        }

        private void EquipmentConditionsOfEipNotSatisfiedCommentsTextBoxTextChanged(object sender, EventArgs e)
        {
            SetupIconsRelatedToSpecialPrecautionsText(equipmentConditionsOfEIPNotSatisfiedCommentsTextBox,
                commentsRequiredForConditionsOfTheEIPSatisfiedImageLabel);
        }

        private void permitReceiverRequiresOrientationCommentsTextBox_Click(object sender, EventArgs e)
        {
            SetupIconsRelatedToSpecialPrecautionsText(permitReceiverRequiresOrientationCommentsTextBox,
                commentsRequiredForRequiredFieldOrientationImageLabel);
        }

        private void weldingGroundWireNotWithinGasTestAreaCommentsTextBox_Click(object sender, EventArgs e)
        {
            SetupIconsRelatedToSpecialPrecautionsText(weldingGroundWireNotWithinGasTestAreaCommentsTextBox,
                commentsRequiredForNoWeldingGroundWireImageLabel);
        }

        private void bondingGroundingNotRequiredCommentsTextBox_Click(object sender, EventArgs e)
        {
            SetupIconsRelatedToSpecialPrecautionsText(bondingGroundingNotRequiredCommentsTextBox,
                commentsRequiredForNoBondingGroundingImageLabel);
        }

        private void equipmentInServiceCommentsTextBox_Click(object sender, EventArgs e)
        {
            SetupIconsRelatedToSpecialPrecautionsText(equipmentInServiceCommentsTextBox,
                commentsRequiredForEquipmentInServiceImageLabel);
        }

        private void AsbestosHazardCommentsTextBox_Click(object sender, EventArgs e) // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            SetupIconsRelatedToSpecialPrecautionsText(AsbestosHazardCommentsTextBox,
                commentsRequiredForAsbestosHazardImageLabel);
        }

        

        private void commentsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetupSpecialPrecautionsCommentsArea();
        }

        private void equipmentIsHazardousEnergyIsolationRequired_CheckChanged(object sender, EventArgs e)
        {
            EnableDisableEnergyIsolationFields();
            if (!equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked &&
                equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked)
            {
                equipmentConditionNACheckBox.Checked = false;
                equipmentConditionNACheckBox.Enabled = false;
            }
            else
            {
                equipmentConditionNACheckBox.Enabled = true;
            }
        }

        private void equipmentLockOutMethod_CheckChanged(object sender, EventArgs e)
        {
            commentsRadioButton_CheckedChanged(sender, e);
            EnableDisableEnergyIsolationFields();
            equipmentConditionsOfEIPSatisfiedNoRadioButton.Checked = false;
            equipmentConditionsOfEIPSatisfiedYesRadioButton.Checked = false;
            if (equipmentLockOutMethodComplexGroupRadioButton.Checked)
            {
                equipmentConditionsOfEIPSatisfiedNACheckBox.Checked = false;
            }
            else
            {
                equipmentConditionsOfEIPSatisfiedNACheckBox.Checked = true;
            }
            equipmentConditionsOfEIPSatisfiedNACheckBox.Enabled = false;
        }

        private void EnableDisableEnergyIsolationFields()
        {
            var enableEnergyIsolationFields =
                !equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked &&
                equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked;
            lockOutMethodGroupBox.Enabled = enableEnergyIsolationFields;
            eipNumberGroupBox.Enabled = enableEnergyIsolationFields &&
                                        equipmentLockOutMethodComplexGroupRadioButton.Checked;
            conditionsOfEIPSatisfiedGroupBox.Enabled = enableEnergyIsolationFields &&
                                                       equipmentLockOutMethodComplexGroupRadioButton.Checked;
        }

        private void equipmentIsHazardousEnergyIsolationRequiredNACheckBox_CheckChanged(object sender, EventArgs e)
        {
            if (equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked)
            {
                equipmentConditionNACheckBox.Enabled = true;
            }
            else
            {
                equipmentConditionNACheckBox.Enabled =
                    !equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked;
            }

            NACheckBox_CheckedChanged(sender, e);
            EnableDisableEnergyIsolationFields();
        }

        #region Data Getters and Setters

        //        private bool IsAnImmediateAreaTestResultActive()
        //        {
        //            foreach (IGasTestElementDetails details in GasTestElementDetailsList)
        //            {
        //                if (details.ImmediateAreaTestRequired)
        //                    return true;
        //            }
        //            return false;
        //        }
        //
        //        private bool IsAConfinedSpaceTestResultActive()
        //        {
        //            foreach (IGasTestElementDetails details in GasTestElementDetailsList)
        //            {
        //                if (details.ConfinedSpaceTestRequired)
        //                    return true;
        //            }
        //            return false;
        //        }

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

        public DateTime EndDateTime
        {
            get
            {
                return
                    new DateTime(endDatePicker.Year, endDatePicker.Month, endDatePicker.Day, endOltTimePicker.Hour,
                        endOltTimePicker.Minute, 0);
            }
            set
            {
                endDatePicker.Value = value.ToDate();
                endOltTimePicker.Value = value.ToTime();
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

        public string CommunicationMethodRadioColor
        {
            get { return communicationRadioColorTextBox.Text; }
            set { communicationRadioColorTextBox.Text = value; }
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


        public bool AdditionalIsAsbestosHandling
        {
            get { return additionalAsbestosHandlingTextBoxCheckBox.CheckBoxChecked; }
            set { additionalAsbestosHandlingTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public string AdditionalAsbestosHandlingDescription
        {
            get { return additionalAsbestosHandlingTextBoxCheckBox.Text; }
            set { additionalAsbestosHandlingTextBoxCheckBox.Text = value; }
        }

        public bool AdditionalIsBlankOrBlindLists
        {
            get { return additionalBlankOrBlindListCheckBox.Checked; }
            set { additionalBlankOrBlindListCheckBox.Checked = value; }
        }

        public string AdditionalBurnOrOpenFlameAssessmentDescription
        {
            get { return additionalBurnOrOpenFlameAssessmentTextBoxCheckBox.Text; }
            set { additionalBurnOrOpenFlameAssessmentTextBoxCheckBox.Text = value; }
        }

        public bool AdditionalIsCriticalLift
        {
            get { return additionalCriticalLiftTextBoxCheckBox.CheckBoxChecked; }
            set { additionalCriticalLiftTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public string AdditionalCriticalLiftDescription
        {
            get { return additionalCriticalLiftTextBoxCheckBox.Text; }
            set { additionalCriticalLiftTextBoxCheckBox.Text = value; }
        }

        public string AdditionalCSEAssessmentOrAuthorizationDescription
        {
            get { return additionalCSEAssessmentAuthorizationTextBoxCheckBox.Text; }
            set { additionalCSEAssessmentAuthorizationTextBoxCheckBox.Text = value; }
        }

        public string AdditionalElectricalDescription
        {
            get { return additionalElectricalTextBoxCheckBox.Text; }
            set { additionalElectricalTextBoxCheckBox.Text = value; }
        }

        public string AdditionalExcavationDescription
        {
            get { return additionalExcavationTextBoxCheckBox.Text; }
            set { additionalExcavationTextBoxCheckBox.Text = value; }
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


        public bool AdditionalIsSpecialWasteDisposal
        {
            get { return additionalSpecialWasteDisposalCheckBox.Checked; }
            set { additionalSpecialWasteDisposalCheckBox.Checked = value; }
        }

        public bool AdditionalIsWaiverOrDeviation
        {
            get { return additionalWaiverOrDeviationTextBoxCheckBox.CheckBoxChecked; }
            set { additionalWaiverOrDeviationTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public string AdditionalWaiverOrDeviationDescription
        {
            get { return additionalWaiverOrDeviationTextBoxCheckBox.Text; }
            set { additionalWaiverOrDeviationTextBoxCheckBox.Text = value; }
        }

        public bool? EquipmentIsOutOfService
        {
            get
            {
                return GetNullableBooleanFromRadioButtons(equipmentEquipmentOutOfServiceRadioButton,
                    equipmentEquipmentInServiceRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(equipmentEquipmentOutOfServiceRadioButton,
                    equipmentEquipmentInServiceRadioButton,
                    value);
            }
        }
        //public bool? AsbestosHazardsConsidered
        //{
        //    get
        //    {
        //        return GetNullableBooleanFromRadioButtons(asbestosHazardsConsideredNoRadioButton,
        //            asbestosHazardsConsideredYesRadioButton);
        //    }
        //    set
        //    {
        //        AssignRadioButtonsFromNullableBoolean(asbestosHazardsConsideredNoRadioButton,
        //            asbestosHazardsConsideredYesRadioButton,
        //            value);
        //    }
        //}
        

        public bool EquipmentIsHazardousEnergyIsolationRequiredNotApplicable
        {
            get { return equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked; }
            set
            {
                equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked = value;
                EnableDisableEnergyIsolationFields();
            }
        }

        public bool? EquipmentIsHazardousEnergyIsolationRequired
        {
            get
            {
                return GetNullableBooleanFromRadioButtons(equipmentIsHazardousEnergyIsolationRequiredYesRadioButton,
                    equipmentIsHazardousEnergyIsolationRequiredNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(equipmentIsHazardousEnergyIsolationRequiredYesRadioButton,
                    equipmentIsHazardousEnergyIsolationRequiredNoRadioButton,
                    value);
                EnableDisableEnergyIsolationFields();
            }
        }

        public string EquipmentLockOutMethodComments
        {
            get
            {
                if (equipmentLockOutMethodIndividualByWorkerRadioButton.Checked)
                {
                    return equipmentLockOutMethodIndividualByWorkerCommentsTextBox.Text;
                }
                if (equipmentLockOutMethodIndividualByOperationsRadioButton.Checked)
                {
                    return equipmentLockOutMethodIndividualByOperationsCommentsTextBox.Text;
                }
                return null;
            }
            set
            {
                if (equipmentLockOutMethodIndividualByWorkerRadioButton.Checked)
                {
                    equipmentLockOutMethodIndividualByWorkerCommentsTextBox.Text = value;
                }
                else if (equipmentLockOutMethodIndividualByOperationsRadioButton.Checked)
                {
                    equipmentLockOutMethodIndividualByOperationsCommentsTextBox.Text = value;
                }
            }
        }

        public string EquipmentEnergyIsolationPlanNumber
        {
            get { return equipmentEIPNumberTextBox.Text; }
            set { equipmentEIPNumberTextBox.Text = value; }
        }

        public bool? EquipmentConditionsOfEIPSatisfied
        {
            get
            {
                return GetNullableBooleanFromRadioButtons(equipmentConditionsOfEIPSatisfiedYesRadioButton,
                    equipmentConditionsOfEIPSatisfiedNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(equipmentConditionsOfEIPSatisfiedYesRadioButton,
                    equipmentConditionsOfEIPSatisfiedNoRadioButton,
                    value);
            }
        }

        public string EquipmentConditionsOfEIPNotSatisfiedComments
        {
            get
            {
                if (equipmentConditionsOfEIPSatisfiedNoRadioButton.Checked)
                {
                    return equipmentConditionsOfEIPNotSatisfiedCommentsTextBox.Text;
                }
                return null;
            }
            set
            {
                if (equipmentConditionsOfEIPSatisfiedNoRadioButton.Checked)
                {
                    equipmentConditionsOfEIPNotSatisfiedCommentsTextBox.Text = value;
                }
            }
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

        public bool EquipmentIsConditionPurgedCheckbox
        {
            get { return equipmentConditionPurgedCheckBox.Checked; }
            set { equipmentConditionPurgedCheckBox.Checked = value; }
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

        public bool EquipmentIsConditionPurgedN2
        {
            get { return equipmentConditionPurgedN2CheckBox.Checked; }
            set { equipmentConditionPurgedN2CheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionPurgedSteamed
        {
            get { return equipmentConditionPurgedSteamedCheckBox.Checked; }
            set { equipmentConditionPurgedSteamedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionPurgedAir
        {
            get { return equipmentConditionPurgedAirCheckBox.Checked; }
            set { equipmentConditionPurgedAirCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionVentilated
        {
            get { return equipmentConditionVentilatedCheckBox.Checked; }
            set { equipmentConditionVentilatedCheckBox.Checked = value; }
        }

        public bool EquipmentIsConditionOther
        {
            get { return equipmentConditionOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
            set { } // set automatically be EquipmentConditionOtherDescription
        }

        public string EquipmentConditionOtherDescription
        {
            get { return equipmentConditionOtherDescriptionTextBoxCheckBox.Text; }
            set { equipmentConditionOtherDescriptionTextBoxCheckBox.Text = value; }
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


        public bool AsbestosHazardsConsideredNotApplicable
        {
            get { return asbestosHazardsConsideredNACheckBox.Checked; }
            set { asbestosHazardsConsideredNACheckBox.Checked = value; }
        }

        public bool? AsbestosHazardsConsidered
        {
            get
            {
                return GetNullableBooleanFromRadioButtons(asbestosHazardsConsideredYesRadioButton,
                    asbestosHazardsConsideredNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(asbestosHazardsConsideredYesRadioButton,
                    asbestosHazardsConsideredNoRadioButton,
                    value);
            }
        }

        public bool AsbestosHazardsConsideredYesRadioButtonChecked  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            get { return asbestosHazardsConsideredYesRadioButton.Checked; }
            set { asbestosHazardsConsideredYesRadioButton.Checked = value; }
        }

        public bool AsbestosHazardsConsideredNoRadioButtonChecked  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            get { return asbestosHazardsConsideredNoRadioButton.Checked; }
            set { asbestosHazardsConsideredNoRadioButton.Checked = value; }
        }

        public bool FireIsSparkContainment
        {
            get { return fireConfinedSpaceSparkContainmenteConfinedSpaceOrFireResistantTarpCheckBox.Checked; }
            set { fireConfinedSpaceSparkContainmenteConfinedSpaceOrFireResistantTarpCheckBox.Checked = value; }
        }

        //        NOTE: Mapped to one visual checkbox on the view, but has it's own table column.
        public bool FireIsFireResistantTarp
        {
            get { return fireConfinedSpaceSparkContainmenteConfinedSpaceOrFireResistantTarpCheckBox.Checked; }
            set { fireConfinedSpaceSparkContainmenteConfinedSpaceOrFireResistantTarpCheckBox.Checked = value; }
        }

        public bool FireIsSteamHose
        {
            get { return fireConfinedSpaceSteamHoseCheckBox.Checked; }
            set { fireConfinedSpaceSteamHoseCheckBox.Checked = value; }
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

        public bool RespiratoryIsNotApplicableEnableDisable         // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            get { return respiratoryProtectionRequirementsNACheckBoxCheckBox.Enabled; }
            set { respiratoryProtectionRequirementsNACheckBoxCheckBox.Enabled = value; }
        }

        public bool RespiratoryIsAirCartorAirLine
        {
            get { return respiratoryProtectionRequirementsAirCartOrAirLineCheckBox.Checked; }
            set { respiratoryProtectionRequirementsAirCartOrAirLineCheckBox.Checked = value; }
        }

        public bool RespiratoryIsAirHood
        {
            get { return respiratoryProtectionRequirementsAirHoodCheckBox.Checked; }
            set { respiratoryProtectionRequirementsAirHoodCheckBox.Checked = value; }
        }

        public bool RespiratoryIsDustMask
        {
            get { return respiratoryProtectionRequirementsDustMaskCheckBox.Checked; }
            set { respiratoryProtectionRequirementsDustMaskCheckBox.Checked = value; }
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

        public bool RespiratoryOtherCheckbox // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            get { return respiratoryProtectionRequirementsOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
            set { respiratoryProtectionRequirementsOtherDescriptionTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public bool IsHazardousEnergyIsolationChecked // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            get { return equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked; }
            set { equipmentIsHazardousEnergyIsolationRequiredYesRadioButton.Checked = value; }
        }


        public bool IsHazardousEnergyIsolationNoChecked // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            get { return equipmentIsHazardousEnergyIsolationRequiredNoRadioButton.Checked; }
            set { equipmentIsHazardousEnergyIsolationRequiredNoRadioButton.Checked = value; }
        }


        

        public bool ControlRoomsHasBeenContactedGroupBox // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            get { return jobSitePreparationControlRoomsHasBeenContactedGroupBox.Visible; }
            set { jobSitePreparationControlRoomsHasBeenContactedGroupBox.Visible = value; }
        }

        

        public string RespiratoryCartridgeTypeDescription
        {
            get { return respiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox.Text; }
            set { respiratoryProtectionRequirementsRespiratoryCartridgeTypeTextBox.Text = value; }
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

        public bool SpecialPPEIsHandProtectionChemicalNeoprene
        {
            get { return specialHandProtectionChemicalNeopreneCheckBox.Checked; }
            set { specialHandProtectionChemicalNeopreneCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionHighVoltage
        {
            get { return specialHandProtectionHighVoltageCheckBox.Checked; }
            set { specialHandProtectionHighVoltageCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionLeather
        {
            get { return specialHandProtectionLeatherCheckBox.Checked; }
            set { specialHandProtectionLeatherCheckBox.Checked = value; }
        }

        public bool SpecialPPEIsHandProtectionNaturalRubber
        {
            get { return specialHandProtectionNaturalRubberCheckBox.Checked; }
            set { specialHandProtectionNaturalRubberCheckBox.Checked = value; }
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
            get { return protectiveClothingControl.IsNotApplicable; }
            set { protectiveClothingControl.IsNotApplicable = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeAcidClothing
        {
            get { return protectiveClothingControl.IsAcidClothing; }
            set { protectiveClothingControl.IsAcidClothing = value; }
        }

        public AcidClothingType SpecialPPEProtectiveClothingTypeAcidClothingType
        {
            get { return protectiveClothingControl.AcidClothingType; }
            set { protectiveClothingControl.AcidClothingType = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeCausticWear
        {
            get { return protectiveClothingControl.IsCausticWear; }
            set { protectiveClothingControl.IsCausticWear = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypePaperCoveralls
        {
            get { return protectiveClothingControl.IsPaperCoveralls; }
            set { protectiveClothingControl.IsPaperCoveralls = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeRainCoat
        {
            get { return protectiveClothingControl.IsRainCoat; }
            set { protectiveClothingControl.IsRainCoat = value; }
        }

        public bool SpecialPPEIsProtectiveClothingTypeRainPants
        {
            get { return protectiveClothingControl.IsRainPants; }
            set { protectiveClothingControl.IsRainPants = value; }
        }

        public string SpecialPPEProtectiveClothingTypeOtherDescription
        {
            get { return protectiveClothingControl.OtherDescription; }
            set { protectiveClothingControl.OtherDescription = value; }
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

        public bool SpecialPPEIsProtectiveFootwearMetatarsalGuard
        {
            get { return specialProtectiveFootwearMetatarsalGuardCheckBox.Checked; }
            set { specialProtectiveFootwearMetatarsalGuardCheckBox.Checked = value; }
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

        public string SpecialPPERescueOrFallOtherDescription
        {
            get { return specialRescueOrFallOtherDescriptionTextBoxCheckBox.Text; }
            set { specialRescueOrFallOtherDescriptionTextBoxCheckBox.Text = value; }
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

        public bool JobWorksiteIsAreaPreparationBarricade
        {
            get { return jobSitePreparationAreaPreparationBarricadeCheckBox.Checked; }
            set { jobSitePreparationAreaPreparationBarricadeCheckBox.Checked = value; }
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


        //ayman Sarnia not applicable
        //Aarti INC0413392-Sarnia Glitch
        public bool JobWorksiteIsHazardousEnergyIsolationRequiredNotApplicable
        {

            get { return equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked; }
            set
            {
                if (PermitNumber == string.Empty && WorkPermitType == null)
                {
                    equipmentIsHazardousEnergyIsolationRequiredNACheckBox.Checked = value;
                }
                else
                {
                    value = value;
                }
            }


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
        public bool JobWorksiteIsAspestosRequiredNotApplicable 
        {
            get { return asbestosHazardsConsideredNACheckBox.Checked; }
            set
            {
                if (PermitNumber == string.Empty && WorkPermitType == null)
                {
                    asbestosHazardsConsideredNACheckBox.Checked = value;
                }
                else
                {
                    value = value;
                }
                    
               
            }
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
            //    asbestosHazardsConsideredNACheckBox.Checked = value;
            //    }
              
            //}
        }

        public bool JobWorksiteIsSewerIsolationMethodPlugged
        {
            get { return jobSitePreparationSewerIsolationMethodPluggedCheckBox.Checked; }
            set { jobSitePreparationSewerIsolationMethodPluggedCheckBox.Checked = value; }
        }

        public bool JobWorksiteIsPermitReceiverFieldOrEquipmentOrientationNotApplicable
        {
            get { return jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBox.Checked; }
            set { jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsPermitReceiverFieldOrEquipmentOrientation
        {
            get
            {
                return
                    GetNullableBooleanFromRadioButtons(
                        jobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButton,
                        jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(
                    jobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButton,
                    jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButton,
                    value);
                if (JobWorksiteIsPermitReceiverFieldOrEquipmentOrientation == true)
                {
                    
                }
            }
        }

        public bool? JobWorksiteIsControlRoomContactedOrNot
        {
            get
            {
                return
                    GetNullableBooleanFromRadioButtons(
                        jobSitePreparationControlRoomContactedYesRadioButton,
                        jobSitePreparationControlRoomContactedNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(
                    jobSitePreparationControlRoomContactedYesRadioButton,
                    jobSitePreparationControlRoomContactedNoRadioButton,
                    value);
            }
        }


        //public bool? jobSiteRoomContactedOrNOT
        //{
        //    get
        //    {
        //        return
        //            GetNullableBooleanFromRadioButtons(
        //                jobSitePreparationControlRoomContactedYesRadioButton,
        //                jobSitePreparationControlRoomContactedNoRadioButton);
        //    }
        //    set
        //    {
        //        AssignRadioButtonsFromNullableBoolean(
        //            jobSitePreparationControlRoomContactedYesRadioButton,
        //            jobSitePreparationControlRoomContactedNoRadioButton,
        //            value);
        //    }
        //}

        
        public bool JobWorksiteIsPermitReceiverFieldNObutton
        {
            get { return jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButton.Checked; }
            set { jobSitePreparationPermitReceiverFieldOrEquipmentOrientationNoRadioButton.Checked = value; }
        }
        public bool JobWorksiteIsVestedBuddySystemInEffectNotApplicable
        {
            get { return jobSitePreparationVestedBuddySystemInEffectNACheckBox.Checked; }
            set { jobSitePreparationVestedBuddySystemInEffectNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsVestedBuddySystemInEffect
        {
            get
            {
                return GetNullableBooleanFromRadioButtons(jobSitePreparationVestedBuddySystemInEffectYesRadioButton,
                    jobSitePreparationVestedBuddySystemInEffectNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(jobSitePreparationVestedBuddySystemInEffectYesRadioButton,
                    jobSitePreparationVestedBuddySystemInEffectNoRadioButton,
                    value);
            }
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

        public bool JobWorksiteIsCriticalConditionRemainJobSiteNotApplicable
        {
            get { return jobSitePreparationCriticalConditionsRemainJobSiteNACheckBox.Checked; }
            set { jobSitePreparationCriticalConditionsRemainJobSiteNACheckBox.Checked = value; }
        }

        public bool JobWorksiteIsControlRoomContactedNotApplicable  //ControlRoomContactedNotApplicable      // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            get { return jobSitePreparationControlRoomContactedNACheckBox.Checked; }
            set { jobSitePreparationControlRoomContactedNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsCriticalConditionRemainJobSite
        {
            get
            {
                return
                    GetNullableBooleanFromRadioButtons(jobSitePreparationCriticalConditionsRemainJobSiteYesRadioButton,
                        jobSitePreparationCriticalConditionsRemainJobSiteNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(jobSitePreparationCriticalConditionsRemainJobSiteYesRadioButton,
                    jobSitePreparationCriticalConditionsRemainJobSiteNoRadioButton,
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


        public bool AdditionalIsOtherItemDescription
        {
            get { return additionalOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
            set { } // this is set automatically by AdditionalOtherItemDescription
        }

        public string AdditionalOtherItemDescription
        {
            get { return additionalOtherDescriptionTextBoxCheckBox.Text; }
            set { additionalOtherDescriptionTextBoxCheckBox.Text = value; }
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
            get { return protectiveClothingControl.IsOtherItemDescription; }
        }


        public bool SpecialPPEIsProtectiveFootwearOtherItemDescription
        {
            get { return specialProtectiveFootwearOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }


        public bool SpecialPPEIsRescueOrFallOtherItemDescription
        {
            get { return specialRescueOrFallOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        public bool JobWorksiteIsAreaPreparationOtherItemDescription
        {
            get { return jobSitePreparationAreaPreparationOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        public bool JobWorksiteIsSewerIsolationMethodOtherItemDescription
        {
            get { return jobSitePreparationSewerIsolationMethodOtherDescriptionTextBoxCheckBox.CheckBoxChecked; }
        }

        public string EquipmentInServiceComments
        {
            get { return equipmentInServiceCommentsTextBox.Text; }
            set { equipmentInServiceCommentsTextBox.Text = value; }
        }

        public string EquipmentInAsbestosHazardPresentComments  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            get { return AsbestosHazardCommentsTextBox.Text; }
            set { AsbestosHazardCommentsTextBox.Text = value; }
        }

        public bool ControlRoomContactedYes  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            get { return jobSitePreparationControlRoomContactedYesRadioButton.Checked; }
            set { jobSitePreparationControlRoomContactedYesRadioButton.Checked = value; }
        }
        public bool ControlRoomContactedNo  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            get { return jobSitePreparationControlRoomContactedNoRadioButton.Checked; }
            set { jobSitePreparationControlRoomContactedNoRadioButton.Checked = value; }
        }

        

        public bool IsAsbestosHazardPanel  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            get { return AsbestosHazardCommentsPanel.Visible; }
            set { AsbestosHazardCommentsPanel.Visible = value; }
        }

        


        public string EquipmentStillContainsResidualComments
        {
            get { return stillContainsResidualCommentsTextBox.Text; }
            set { stillContainsResidualCommentsTextBox.Text = value; }
        }

        public string EquipmentLeakingValvesComments
        {
            get { return leakingValvesCommentsTextBox.Text; }
            set { leakingValvesCommentsTextBox.Text = value; }
        }

        public string JobWorksiteBondingGroundingNotRequiredComments
        {
            get { return bondingGroundingNotRequiredCommentsTextBox.Text; }
            set { bondingGroundingNotRequiredCommentsTextBox.Text = value; }
        }

        public string JobWorksiteWeldingGroundWireNotWithinGasTestAreaComments
        {
            get { return weldingGroundWireNotWithinGasTestAreaCommentsTextBox.Text; }
            set { weldingGroundWireNotWithinGasTestAreaCommentsTextBox.Text = value; }
        }

        public string JobWorksiteSurroundingConditionsAffectAreaComments
        {
            get { return surroundingConditionsAffectAreaCommentsTextBox.Text; }
            set { surroundingConditionsAffectAreaCommentsTextBox.Text = value; }
        }

        public string JobWorksiteCriticalConditionsComments
        {
            get { return criticalConditionsCommentsTextBox.Text; }
            set { criticalConditionsCommentsTextBox.Text = value; }
        }

        public string JobWorksitePermitReceiverRequiresOrientationComments
        {
            get { return permitReceiverRequiresOrientationCommentsTextBox.Text; }
            set { permitReceiverRequiresOrientationCommentsTextBox.Text = value; }
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

        public bool? IsControlRoomContacted     // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        {
            get
            {
                return GetNullableBooleanFromRadioButtons(jobSitePreparationControlRoomContactedYesRadioButton,
                    jobSitePreparationControlRoomContactedNoRadioButton);
            }
            set
            {
                ;
                //AssignRadioButtonsFromNullableBoolean(jobSitePreparationControlRoomContactedYesRadioButton,
                //    jobSitePreparationControlRoomContactedNoRadioButton,
                //    value);
            }
        }

        public string CoauthorizationDescription
        {
            get { return coAuthorizationRequiredDescriptionTextBox.Text; }
            set { coAuthorizationRequiredDescriptionTextBox.Text = value; }
        }

        internal override OltExplorerBar ExplorerBar
        {
            get { return explorerBarMain; }
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

        public override List<IGasTestElementDetails> GasTestElementDetailsList
        {
            get { return gasTestElementInfoTableLayoutPanel.GasTestElementDetailsList; }
        }

        public bool GasTestEventsEnabled
        {
            set { gasTestElementInfoTableLayoutPanel.GasTestEventsEnabled = value; }
        }

        #endregion Gas Tests

        public User Author
        {
            set { lastModifiedDateAuthorHeader.LastModifiedUser = value; }
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

        public WorkAssignment WorkAssignment
        {
            get
            {
                var assignment = (WorkAssignment) workAssignmentComboBox.SelectedItem;

                if (assignment == null || WorkAssignment.NoneWorkAssignment.Equals(assignment))
                {
                    return null;
                }

                return assignment;
            }
            set { workAssignmentComboBox.SelectedItem = value ?? WorkAssignment.NoneWorkAssignment; }
        }

        public List<WorkAssignment> WorkAssignmentSelectionList
        {
            set { workAssignmentComboBox.DataSource = value; }
        }

        public bool StartTimeNotApplicable
        {
            set { ; }
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
                    new DateTime(startDatePicker.Year, startDatePicker.Month, startDatePicker.Day,
                        startOltTimePicker.Hour,
                        startOltTimePicker.Minute, 0);
            }
            set
            {
                startDatePicker.Value = value.ToDate();
                startOltTimePicker.Value = value.ToTime();
            }
        }

        public DateTime StartTime
        {
            set { startOltTimePicker.Value = value.ToTime(); }
        }

        public bool IsConfinedSpaceEntry
        {
            get { return confinedSpaceEntryCheckBox.Checked; }
            set { confinedSpaceEntryCheckBox.Checked = value; }
        }


        public bool IsVehicleEntry
        {
            get { return vehicleEntryCheckBox.Checked; }
            set { vehicleEntryCheckBox.Checked = value; }
        }

        public bool IsBurnOrOpenFlame
        {
            get { return burnOpenFlameCheckBox.Checked; }
            set { burnOpenFlameCheckBox.Checked = value; }
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

        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        public bool IsFreshAir
        {
            get { return freshAirCheckBox.Checked; }
            set { freshAirCheckBox.Checked = value; }
        }
        //END

        public bool AdditionalIsBurnOrOpenFlameAssessment
        {
            get { return additionalBurnOrOpenFlameAssessmentTextBoxCheckBox.CheckBoxChecked; }
            set { additionalBurnOrOpenFlameAssessmentTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public bool AdditionalIsCSEAssessmentOrAuthorization
        {
            get { return additionalCSEAssessmentAuthorizationTextBoxCheckBox.CheckBoxChecked; }
            set { additionalCSEAssessmentAuthorizationTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public bool AdditionalIsElectrical
        {
            get { return additionalElectricalTextBoxCheckBox.CheckBoxChecked; }
            set { additionalElectricalTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public bool AdditionalIsExcavation
        {
            get { return additionalExcavationTextBoxCheckBox.CheckBoxChecked; }
            set { additionalExcavationTextBoxCheckBox.CheckBoxChecked = value; }
        }

        public bool EquipmentLockOutMethodEnabled
        {
            get { return lockOutMethodGroupBox.Enabled; }
        }

        public WorkPermitLockOutMethodType EquipmentLockOutMethod
        {
            get
            {
                if (equipmentLockOutMethodIndividualByWorkerRadioButton.Checked)
                {
                    return WorkPermitLockOutMethodType.INDIVIDUAL_BY_WORKER;
                }
                if (equipmentLockOutMethodIndividualByOperationsRadioButton.Checked)
                {
                    return WorkPermitLockOutMethodType.INDIVIDUAL_BY_OPERATIONS;
                }
                if (equipmentLockOutMethodComplexGroupRadioButton.Checked)
                {
                    return WorkPermitLockOutMethodType.COMPLEX_GROUP;
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    equipmentLockOutMethodIndividualByWorkerRadioButton.Checked = false;
                    equipmentLockOutMethodIndividualByOperationsRadioButton.Checked = false;
                    equipmentLockOutMethodComplexGroupRadioButton.Checked = false;
                }
                else if (Equals(value, WorkPermitLockOutMethodType.INDIVIDUAL_BY_WORKER))
                {
                    equipmentLockOutMethodIndividualByWorkerRadioButton.Checked = true;
                }
                else if (Equals(value, WorkPermitLockOutMethodType.INDIVIDUAL_BY_OPERATIONS))
                {
                    equipmentLockOutMethodIndividualByOperationsRadioButton.Checked = true;
                }
                else if (Equals(value, WorkPermitLockOutMethodType.COMPLEX_GROUP))
                {
                    equipmentLockOutMethodComplexGroupRadioButton.Checked = true;
                }
                EnableDisableEnergyIsolationFields();
            }
        }

        public bool FireIsNotApplicable
        {
            get { return fireConfinedSpaceProtectionNACheckBox.Checked; }
            set { fireConfinedSpaceProtectionNACheckBox.Checked = value; }
        }

        public bool FireIsFireResistantTarpOrFireIsSparkContainment
        {
            set { FireIsFireResistantTarp = FireIsSparkContainment = value; }
        }

        public bool FireIsTwentyABCorDryChemicalExtinguisher
        {
            get { return fireConfinedSpace20ABCorDryChemicalExtinguisherCheckBox.Checked; }
            set { fireConfinedSpace20ABCorDryChemicalExtinguisherCheckBox.Checked = value; }
        }

        public bool FireIsWatchmen
        {
            get { return fireConfinedSpaceWatchmenCheckBox.Checked; }
            set { fireConfinedSpaceWatchmenCheckBox.Checked = value; }
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

        public string SpecialPrecautionsOrConsiderations
        {
            get { return specialPrecautionsOrConsiderationsDescriptionTextBox.Text; }
            set { specialPrecautionsOrConsiderationsDescriptionTextBox.Text = value; }
        }

        public bool JobWorksiteIsSewerIsolationMethodNotApplicable
        {
            get { return jobSitePreparationSewerIsolationMethodNACheckBox.Checked; }
            set { jobSitePreparationSewerIsolationMethodNACheckBox.Checked = value; }
        }

        public bool JobWorksiteIsSewerIsolationMethodSealedOrCovered
        {
            get { return jobSitePreparationSewerIsolationMethodSealedOrCoveredCheckBox.Checked; }
            set
            {
                
                jobSitePreparationSewerIsolationMethodSealedOrCoveredCheckBox.Checked = value;
            }
        }

        public bool JobWorksiteIsWeldingGroundWireInTestAreaNotApplicable
        {
            get { return jobSitePreparationWeldingGroundWireInTestAreaNACheckBox.Checked; }
            set { jobSitePreparationWeldingGroundWireInTestAreaNACheckBox.Checked = value; }
        }

        public bool? JobWorksiteIsWeldingGroundWireInTestArea
        {
            get
            {
                return
                    GetNullableBooleanFromRadioButtons(jobSitePreparationWeldingGroundWireInTestAreaYesRadioButton,
                        jobSitePreparationWeldingGroundWireInTestAreaNoRadioButton);
            }
            set
            {
                AssignRadioButtonsFromNullableBoolean(jobSitePreparationWeldingGroundWireInTestAreaYesRadioButton,
                    jobSitePreparationWeldingGroundWireInTestAreaNoRadioButton,
                    value);
            }
        }

        #endregion IWorkPermitFormView Members

        //Start : // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        
        public bool CommentsRequiredForAsbestosHazardImageLabelVisible
        {
            get { return commentsRequiredForAsbestosHazardImageLabel.Visible; }
            set { commentsRequiredForAsbestosHazardImageLabel.Visible = value; }
        }

        public bool CommentsRequiredForHazardousEneryImageLabelVisible
        {
            get { return commentsRequiredForRequiredFieldOrientationImageLabel.Visible; }
            set { commentsRequiredForRequiredFieldOrientationImageLabel.Visible = value; }
        }
        public bool CommentsRequiredForHazardousEneryImageLabelEnableDisable
        {
            get { return commentsRequiredForRequiredFieldOrientationImageLabel.Enabled; }
            set { commentsRequiredForRequiredFieldOrientationImageLabel.Enabled = value; }
        }

        //END

//DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
        public bool EquipmentLockOutMethodComplexGroupRadioButtonChecked
        {
            get { return equipmentLockOutMethodComplexGroupRadioButton.Checked; }
            set { equipmentLockOutMethodComplexGroupRadioButton.Checked = value; }
        }
        public bool EquipmentLockOutMethodIndividualByOperationsRadioButtonChecked
        {
            get { return equipmentLockOutMethodIndividualByOperationsRadioButton.Checked; }
            set { equipmentLockOutMethodIndividualByOperationsRadioButton.Checked = value; }
        }
        public bool PermitReceiverRequiresOrientationCommentsPanelVisible
        {
            get { return permitReceiverRequiresOrientationCommentsPanel.Visible; }
            set { permitReceiverRequiresOrientationCommentsPanel.Visible = value; }
        }

        public bool EquipmentLockOutMethodIndividualByWorkerRadioButtonChecked
        {
            get { return equipmentLockOutMethodIndividualByWorkerRadioButton.Checked; }
            set { equipmentLockOutMethodIndividualByWorkerRadioButton.Checked = value; }
        }
        public bool JobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButtonChecked
        {
            get { return jobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButton.Checked; }
            set { jobSitePreparationPermitReceiverFieldOrEquipmentOrientationYesRadioButton.Checked = value; }
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public string TemplateName { get; set; }
        public bool IsTemplate { get; set; }
        public bool IsActiveTemplate { get; set; }
             
       
    }
}