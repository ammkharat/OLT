using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
namespace Com.Suncor.Olt.Client.Forms
{
    partial class PermitRequestEdmontonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PermitRequestEdmontonForm));
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveAndCloseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.viewEditHistoryButton = new System.Windows.Forms.Button();
            this.submitAndCloseButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.validateButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.contentPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.priorityGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.priorityComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.documentLinksGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.documentLinksControl = new Com.Suncor.Olt.Client.Controls.DocumentLinksControl();
            this.oltGroupBox2 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.oltPanel20 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.selectFormGN1Button = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.gn1CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.gn1FormNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltPanel19 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.selectFormGN75AButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.gn75AFormNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.gn75ACheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltPanel18 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.selectFormGN6Button = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.gn6CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.gn6FormNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltPanel16 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.selectFormGN24Button = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.gn24FormNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.gn24CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltPanel9 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.selectFormGN59Button = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.gn59FormNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.gn59CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltPanel13 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.selectFormGN7Button = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.gn7CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.gn7FormNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.gn27Label = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.gn27ComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.gn11ComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.gn11Label = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.typeOfWorkGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.oltPanel22 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.roadAccessOnPermitComboBox = new Com.Suncor.Olt.Client.OltControls.OltEditableComboBox();
            this.oltLabel16 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.roadAccessOnPermitCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabel19 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.roadAccessOnPermitFormNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltPanel8 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.classOfClothingComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.alkylationEntryCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltPanel7 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.flarePitEntryTypeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.flarePitEntryCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltPanel6 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.specialWorkComboBox = new Com.Suncor.Olt.Client.OltControls.OltEditableComboBox();
            this.specialWorkTypeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltLabel47 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.specialWorkCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabel14 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.specialWorkFormNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltPanel5 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.vehicleEntryTotalNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltIntegerBox();
            this.oltLabel46 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.vehicleEntryTypeTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.vehicleEntryCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabel8 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltPanel4 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.rescuePlanFormNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.rescuePlanCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabel7 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltPanel3 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.confinedSpaceClassComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltLabel21 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.confinedSpaceCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabel5 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.confinedSpaceCardNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel6 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.hazardsAndOrRequirementsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.hazardsAndOrRequirementsTextBox = new Com.Suncor.Olt.Client.OltControls.OltSpellCheckTextBox(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.currentSAPDescriptionGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.sapDescriptionTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.taskDescriptionGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.descriptionTextBox = new Com.Suncor.Olt.Client.OltControls.OltSpellCheckTextBox(this.components);
            this.workersMinimumSafetyRequirementsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.oltPanel17 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.other4TextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.other4CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltPanel15 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.other3TextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.other3CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltPanel14 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.other2TextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.other2CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltPanel12 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.other1TextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.other1CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltPanel10 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.workersMonitorNumberCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.workersMonitorNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltPanel11 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.radioChannelNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.radioChannelNumberCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.airMoverCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.barriersSignsCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.airHornCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.mechVentilationComfortOnlyCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.asbestosMmfPrecautionsCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.airPurifyingRespiratorCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.breathingAirApparatusCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.dustMaskCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.lifeSupportSystemCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.safetyWatchCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.continuousGasMonitorCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.bumpTestMonitorPriorToUseCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.equipmentGroundedCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.fireBlanketCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.fireExtinguisherCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.fireMonitorMannedCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.fireWatchCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.sewersDrainsCoveredCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.steamHoseCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.highVoltagePPECheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.safetyHarnessLifelineCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.rubberSuitCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.rubberGlovesCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.rubberBootsCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.gogglesCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.faceShieldCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabelLine6 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.oltGroupBox6 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.areaComboBox = new Com.Suncor.Olt.Client.OltControls.OltEditableComboBox();
            this.oltPanel2 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.otherAreasAffectedNoRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.otherAreasAffectedYesRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.oltLabel11 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel13 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.personNotifiedTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltGroupBox5 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.subOperationNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltGroupBox4 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.operationNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltGroupBox3 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.requestedEndDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.workOrderNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.requestedStartGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.requestedStartNightCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.requestedStartTimeNightPicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.requestedStartDayCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.requestedStartTimeDayPicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.requestedStartDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.functionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.areaLabelComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltLabel9 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel15 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.locationTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.functionalLocationTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.functionalLocationBrowseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.permitTypeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.permitTypeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.lastModifiedDateAuthorHeader = new Com.Suncor.Olt.Client.OltControls.OltLastModifiedDateAuthorHeader();
            this.issuedToGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.groupComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.numberOfWorkersTextBox = new Com.Suncor.Olt.Client.OltControls.OltIntegerBox();
            this.occupationComboBox = new Com.Suncor.Olt.Client.OltControls.OltEditableComboBox();
            this.occupationLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.issuedToSuncorCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.issuedToContractorCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.contractorComboBox = new Com.Suncor.Olt.Client.OltControls.OltEditableComboBox();
            this.oltLabel4 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.warningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.priorityGroupBox.SuspendLayout();
            this.documentLinksGroupBox.SuspendLayout();
            this.oltGroupBox2.SuspendLayout();
            this.oltPanel20.SuspendLayout();
            this.oltPanel19.SuspendLayout();
            this.oltPanel18.SuspendLayout();
            this.oltPanel16.SuspendLayout();
            this.oltPanel9.SuspendLayout();
            this.oltPanel13.SuspendLayout();
            this.typeOfWorkGroupBox.SuspendLayout();
            this.oltPanel22.SuspendLayout();
            this.oltPanel8.SuspendLayout();
            this.oltPanel7.SuspendLayout();
            this.oltPanel6.SuspendLayout();
            this.oltPanel5.SuspendLayout();
            this.oltPanel4.SuspendLayout();
            this.oltPanel3.SuspendLayout();
            this.hazardsAndOrRequirementsGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.currentSAPDescriptionGroupBox.SuspendLayout();
            this.taskDescriptionGroupBox.SuspendLayout();
            this.workersMinimumSafetyRequirementsGroupBox.SuspendLayout();
            this.oltPanel17.SuspendLayout();
            this.oltPanel15.SuspendLayout();
            this.oltPanel14.SuspendLayout();
            this.oltPanel12.SuspendLayout();
            this.oltPanel10.SuspendLayout();
            this.oltPanel11.SuspendLayout();
            this.oltGroupBox6.SuspendLayout();
            this.oltPanel2.SuspendLayout();
            this.oltGroupBox5.SuspendLayout();
            this.oltGroupBox4.SuspendLayout();
            this.oltGroupBox3.SuspendLayout();
            this.oltGroupBox1.SuspendLayout();
            this.requestedStartGroupBox.SuspendLayout();
            this.functionalLocationGroupBox.SuspendLayout();
            this.permitTypeGroupBox.SuspendLayout();
            this.issuedToGroupBox.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(871, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveAndCloseButton
            // 
            this.saveAndCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAndCloseButton.Location = new System.Drawing.Point(679, 8);
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.Size = new System.Drawing.Size(81, 23);
            this.saveAndCloseButton.TabIndex = 0;
            this.saveAndCloseButton.Text = "&Save && Close";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
            // 
            // viewEditHistoryButton
            // 
            this.viewEditHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewEditHistoryButton.Location = new System.Drawing.Point(9, 8);
            this.viewEditHistoryButton.Name = "viewEditHistoryButton";
            this.viewEditHistoryButton.Size = new System.Drawing.Size(75, 23);
            this.viewEditHistoryButton.TabIndex = 4;
            this.viewEditHistoryButton.Text = "&History";
            this.viewEditHistoryButton.UseVisualStyleBackColor = true;
            // 
            // submitAndCloseButton
            // 
            this.submitAndCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitAndCloseButton.Location = new System.Drawing.Point(766, 8);
            this.submitAndCloseButton.Name = "submitAndCloseButton";
            this.submitAndCloseButton.Size = new System.Drawing.Size(99, 23);
            this.submitAndCloseButton.TabIndex = 1;
            this.submitAndCloseButton.Text = "S&ubmit && Close";
            this.submitAndCloseButton.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.validateButton);
            this.buttonPanel.Controls.Add(this.viewEditHistoryButton);
            this.buttonPanel.Controls.Add(this.saveAndCloseButton);
            this.buttonPanel.Controls.Add(this.submitAndCloseButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 648);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(984, 38);
            this.buttonPanel.TabIndex = 19;
            // 
            // validateButton
            // 
            this.validateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.validateButton.Location = new System.Drawing.Point(90, 8);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(75, 23);
            this.validateButton.TabIndex = 3;
            this.validateButton.Text = "&Validate";
            this.validateButton.UseVisualStyleBackColor = true;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.Controls.Add(this.priorityGroupBox);
            this.contentPanel.Controls.Add(this.documentLinksGroupBox);
            this.contentPanel.Controls.Add(this.oltGroupBox2);
            this.contentPanel.Controls.Add(this.typeOfWorkGroupBox);
            this.contentPanel.Controls.Add(this.hazardsAndOrRequirementsGroupBox);
            this.contentPanel.Controls.Add(this.tableLayoutPanel1);
            this.contentPanel.Controls.Add(this.workersMinimumSafetyRequirementsGroupBox);
            this.contentPanel.Controls.Add(this.workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            this.contentPanel.Controls.Add(this.oltLabelLine6);
            this.contentPanel.Controls.Add(this.oltGroupBox6);
            this.contentPanel.Controls.Add(this.oltGroupBox5);
            this.contentPanel.Controls.Add(this.oltGroupBox4);
            this.contentPanel.Controls.Add(this.oltGroupBox3);
            this.contentPanel.Controls.Add(this.oltGroupBox1);
            this.contentPanel.Controls.Add(this.requestedStartGroupBox);
            this.contentPanel.Controls.Add(this.functionalLocationGroupBox);
            this.contentPanel.Controls.Add(this.permitTypeGroupBox);
            this.contentPanel.Controls.Add(this.lastModifiedDateAuthorHeader);
            this.contentPanel.Controls.Add(this.issuedToGroupBox);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(984, 648);
            this.contentPanel.TabIndex = 0;
            // 
            // priorityGroupBox
            // 
            this.priorityGroupBox.Controls.Add(this.priorityComboBox);
            this.priorityGroupBox.Location = new System.Drawing.Point(9, 143);
            this.priorityGroupBox.Name = "priorityGroupBox";
            this.priorityGroupBox.Size = new System.Drawing.Size(166, 41);
            this.priorityGroupBox.TabIndex = 3;
            this.priorityGroupBox.TabStop = false;
            this.priorityGroupBox.Text = "Priority";
            // 
            // priorityComboBox
            // 
            this.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityComboBox.FormattingEnabled = true;
            this.priorityComboBox.Location = new System.Drawing.Point(9, 14);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(133, 21);
            this.priorityComboBox.TabIndex = 0;
            // 
            // documentLinksGroupBox
            // 
            this.documentLinksGroupBox.Controls.Add(this.documentLinksControl);
            this.documentLinksGroupBox.Location = new System.Drawing.Point(655, 102);
            this.documentLinksGroupBox.Name = "documentLinksGroupBox";
            this.documentLinksGroupBox.Size = new System.Drawing.Size(297, 130);
            this.documentLinksGroupBox.TabIndex = 5;
            this.documentLinksGroupBox.TabStop = false;
            this.documentLinksGroupBox.Text = "Document Links";
            // 
            // documentLinksControl
            // 
            this.documentLinksControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentLinksControl.DataSource = null;
            this.documentLinksControl.Location = new System.Drawing.Point(11, 20);
            this.documentLinksControl.Name = "documentLinksControl";
            this.documentLinksControl.ReadOnlyList = true;
            this.documentLinksControl.Size = new System.Drawing.Size(279, 104);
            this.documentLinksControl.TabIndex = 1;
            // 
            // oltGroupBox2
            // 
            this.oltGroupBox2.Controls.Add(this.oltPanel20);
            this.oltGroupBox2.Controls.Add(this.oltPanel19);
            this.oltGroupBox2.Controls.Add(this.oltPanel18);
            this.oltGroupBox2.Controls.Add(this.oltPanel16);
            this.oltGroupBox2.Controls.Add(this.oltPanel9);
            this.oltGroupBox2.Controls.Add(this.oltPanel13);
            this.oltGroupBox2.Controls.Add(this.gn27Label);
            this.oltGroupBox2.Controls.Add(this.gn27ComboBox);
            this.oltGroupBox2.Controls.Add(this.gn11ComboBox);
            this.oltGroupBox2.Controls.Add(this.gn11Label);
            this.oltGroupBox2.Location = new System.Drawing.Point(419, 211);
            this.oltGroupBox2.Name = "oltGroupBox2";
            this.oltGroupBox2.Size = new System.Drawing.Size(230, 209);
            this.oltGroupBox2.TabIndex = 7;
            this.oltGroupBox2.TabStop = false;
            this.oltGroupBox2.Text = "Form Requirements";
            // 
            // oltPanel20
            // 
            this.oltPanel20.Controls.Add(this.selectFormGN1Button);
            this.oltPanel20.Controls.Add(this.gn1CheckBox);
            this.oltPanel20.Controls.Add(this.gn1FormNumberTextBox);
            this.oltPanel20.Location = new System.Drawing.Point(4, 16);
            this.oltPanel20.Name = "oltPanel20";
            this.oltPanel20.Size = new System.Drawing.Size(222, 21);
            this.oltPanel20.TabIndex = 12;
            // 
            // selectFormGN1Button
            // 
            this.selectFormGN1Button.Location = new System.Drawing.Point(175, 0);
            this.selectFormGN1Button.Name = "selectFormGN1Button";
            this.selectFormGN1Button.Size = new System.Drawing.Size(27, 20);
            this.selectFormGN1Button.TabIndex = 3;
            this.selectFormGN1Button.Text = "...";
            this.selectFormGN1Button.UseVisualStyleBackColor = true;
            // 
            // gn1CheckBox
            // 
            this.gn1CheckBox.AutoSize = true;
            this.gn1CheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gn1CheckBox.Location = new System.Drawing.Point(5, 2);
            this.gn1CheckBox.Name = "gn1CheckBox";
            this.gn1CheckBox.Size = new System.Drawing.Size(92, 17);
            this.gn1CheckBox.TabIndex = 0;
            this.gn1CheckBox.Text = "GN-1 Form #:";
            this.gn1CheckBox.UseVisualStyleBackColor = true;
            this.gn1CheckBox.Value = null;
            // 
            // gn1FormNumberTextBox
            // 
            this.gn1FormNumberTextBox.Location = new System.Drawing.Point(103, 0);
            this.gn1FormNumberTextBox.MaxLength = 10;
            this.gn1FormNumberTextBox.Name = "gn1FormNumberTextBox";
            this.gn1FormNumberTextBox.OltAcceptsReturn = true;
            this.gn1FormNumberTextBox.OltTrimWhitespace = true;
            this.gn1FormNumberTextBox.ReadOnly = true;
            this.gn1FormNumberTextBox.Size = new System.Drawing.Size(70, 20);
            this.gn1FormNumberTextBox.TabIndex = 2;
            this.gn1FormNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // oltPanel19
            // 
            this.oltPanel19.Controls.Add(this.selectFormGN75AButton);
            this.oltPanel19.Controls.Add(this.gn75AFormNumberTextBox);
            this.oltPanel19.Controls.Add(this.gn75ACheckBox);
            this.oltPanel19.Location = new System.Drawing.Point(4, 131);
            this.oltPanel19.Name = "oltPanel19";
            this.oltPanel19.Size = new System.Drawing.Size(222, 21);
            this.oltPanel19.TabIndex = 12;
            // 
            // selectFormGN75AButton
            // 
            this.selectFormGN75AButton.Location = new System.Drawing.Point(175, 0);
            this.selectFormGN75AButton.Name = "selectFormGN75AButton";
            this.selectFormGN75AButton.Size = new System.Drawing.Size(27, 20);
            this.selectFormGN75AButton.TabIndex = 4;
            this.selectFormGN75AButton.Text = "...";
            this.selectFormGN75AButton.UseVisualStyleBackColor = true;
            // 
            // gn75AFormNumberTextBox
            // 
            this.gn75AFormNumberTextBox.Location = new System.Drawing.Point(103, 0);
            this.gn75AFormNumberTextBox.MaxLength = 10;
            this.gn75AFormNumberTextBox.Name = "gn75AFormNumberTextBox";
            this.gn75AFormNumberTextBox.OltAcceptsReturn = true;
            this.gn75AFormNumberTextBox.OltTrimWhitespace = true;
            this.gn75AFormNumberTextBox.ReadOnly = true;
            this.gn75AFormNumberTextBox.Size = new System.Drawing.Size(70, 20);
            this.gn75AFormNumberTextBox.TabIndex = 2;
            this.gn75AFormNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gn75ACheckBox
            // 
            this.gn75ACheckBox.AutoSize = true;
            this.gn75ACheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gn75ACheckBox.Location = new System.Drawing.Point(5, 2);
            this.gn75ACheckBox.Name = "gn75ACheckBox";
            this.gn75ACheckBox.Size = new System.Drawing.Size(105, 17);
            this.gn75ACheckBox.TabIndex = 0;
            this.gn75ACheckBox.Text = "GN-75A Form #:";
            this.gn75ACheckBox.UseVisualStyleBackColor = true;
            this.gn75ACheckBox.Value = null;
            // 
            // oltPanel18
            // 
            this.oltPanel18.Controls.Add(this.selectFormGN6Button);
            this.oltPanel18.Controls.Add(this.gn6CheckBox);
            this.oltPanel18.Controls.Add(this.gn6FormNumberTextBox);
            this.oltPanel18.Location = new System.Drawing.Point(4, 39);
            this.oltPanel18.Name = "oltPanel18";
            this.oltPanel18.Size = new System.Drawing.Size(222, 21);
            this.oltPanel18.TabIndex = 11;
            // 
            // selectFormGN6Button
            // 
            this.selectFormGN6Button.Location = new System.Drawing.Point(175, 0);
            this.selectFormGN6Button.Name = "selectFormGN6Button";
            this.selectFormGN6Button.Size = new System.Drawing.Size(27, 20);
            this.selectFormGN6Button.TabIndex = 3;
            this.selectFormGN6Button.Text = "...";
            this.selectFormGN6Button.UseVisualStyleBackColor = true;
            // 
            // gn6CheckBox
            // 
            this.gn6CheckBox.AutoSize = true;
            this.gn6CheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gn6CheckBox.Location = new System.Drawing.Point(5, 2);
            this.gn6CheckBox.Name = "gn6CheckBox";
            this.gn6CheckBox.Size = new System.Drawing.Size(92, 17);
            this.gn6CheckBox.TabIndex = 0;
            this.gn6CheckBox.Text = "GN-6 Form #:";
            this.gn6CheckBox.UseVisualStyleBackColor = true;
            this.gn6CheckBox.Value = null;
            // 
            // gn6FormNumberTextBox
            // 
            this.gn6FormNumberTextBox.Location = new System.Drawing.Point(103, 0);
            this.gn6FormNumberTextBox.MaxLength = 10;
            this.gn6FormNumberTextBox.Name = "gn6FormNumberTextBox";
            this.gn6FormNumberTextBox.OltAcceptsReturn = true;
            this.gn6FormNumberTextBox.OltTrimWhitespace = true;
            this.gn6FormNumberTextBox.ReadOnly = true;
            this.gn6FormNumberTextBox.Size = new System.Drawing.Size(70, 20);
            this.gn6FormNumberTextBox.TabIndex = 2;
            this.gn6FormNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // oltPanel16
            // 
            this.oltPanel16.Controls.Add(this.selectFormGN24Button);
            this.oltPanel16.Controls.Add(this.gn24FormNumberTextBox);
            this.oltPanel16.Controls.Add(this.gn24CheckBox);
            this.oltPanel16.Location = new System.Drawing.Point(4, 85);
            this.oltPanel16.Name = "oltPanel16";
            this.oltPanel16.Size = new System.Drawing.Size(222, 21);
            this.oltPanel16.TabIndex = 2;
            // 
            // selectFormGN24Button
            // 
            this.selectFormGN24Button.Location = new System.Drawing.Point(175, 0);
            this.selectFormGN24Button.Name = "selectFormGN24Button";
            this.selectFormGN24Button.Size = new System.Drawing.Size(27, 20);
            this.selectFormGN24Button.TabIndex = 4;
            this.selectFormGN24Button.Text = "...";
            this.selectFormGN24Button.UseVisualStyleBackColor = true;
            // 
            // gn24FormNumberTextBox
            // 
            this.gn24FormNumberTextBox.Location = new System.Drawing.Point(103, 0);
            this.gn24FormNumberTextBox.MaxLength = 10;
            this.gn24FormNumberTextBox.Name = "gn24FormNumberTextBox";
            this.gn24FormNumberTextBox.OltAcceptsReturn = true;
            this.gn24FormNumberTextBox.OltTrimWhitespace = true;
            this.gn24FormNumberTextBox.ReadOnly = true;
            this.gn24FormNumberTextBox.Size = new System.Drawing.Size(70, 20);
            this.gn24FormNumberTextBox.TabIndex = 2;
            this.gn24FormNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gn24CheckBox
            // 
            this.gn24CheckBox.AutoSize = true;
            this.gn24CheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gn24CheckBox.Location = new System.Drawing.Point(5, 2);
            this.gn24CheckBox.Name = "gn24CheckBox";
            this.gn24CheckBox.Size = new System.Drawing.Size(98, 17);
            this.gn24CheckBox.TabIndex = 0;
            this.gn24CheckBox.Text = "GN-24 Form #:";
            this.gn24CheckBox.UseVisualStyleBackColor = true;
            this.gn24CheckBox.Value = null;
            // 
            // oltPanel9
            // 
            this.oltPanel9.Controls.Add(this.selectFormGN59Button);
            this.oltPanel9.Controls.Add(this.gn59FormNumberTextBox);
            this.oltPanel9.Controls.Add(this.gn59CheckBox);
            this.oltPanel9.Location = new System.Drawing.Point(4, 108);
            this.oltPanel9.Name = "oltPanel9";
            this.oltPanel9.Size = new System.Drawing.Size(222, 21);
            this.oltPanel9.TabIndex = 0;
            // 
            // selectFormGN59Button
            // 
            this.selectFormGN59Button.Location = new System.Drawing.Point(175, 0);
            this.selectFormGN59Button.Name = "selectFormGN59Button";
            this.selectFormGN59Button.Size = new System.Drawing.Size(27, 20);
            this.selectFormGN59Button.TabIndex = 4;
            this.selectFormGN59Button.Text = "...";
            this.selectFormGN59Button.UseVisualStyleBackColor = true;
            // 
            // gn59FormNumberTextBox
            // 
            this.gn59FormNumberTextBox.Location = new System.Drawing.Point(103, 0);
            this.gn59FormNumberTextBox.MaxLength = 10;
            this.gn59FormNumberTextBox.Name = "gn59FormNumberTextBox";
            this.gn59FormNumberTextBox.OltAcceptsReturn = true;
            this.gn59FormNumberTextBox.OltTrimWhitespace = true;
            this.gn59FormNumberTextBox.ReadOnly = true;
            this.gn59FormNumberTextBox.Size = new System.Drawing.Size(70, 20);
            this.gn59FormNumberTextBox.TabIndex = 2;
            this.gn59FormNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gn59CheckBox
            // 
            this.gn59CheckBox.AutoSize = true;
            this.gn59CheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gn59CheckBox.Location = new System.Drawing.Point(5, 2);
            this.gn59CheckBox.Name = "gn59CheckBox";
            this.gn59CheckBox.Size = new System.Drawing.Size(98, 17);
            this.gn59CheckBox.TabIndex = 0;
            this.gn59CheckBox.Text = "GN-59 Form #:";
            this.gn59CheckBox.UseVisualStyleBackColor = true;
            this.gn59CheckBox.Value = null;
            // 
            // oltPanel13
            // 
            this.oltPanel13.Controls.Add(this.selectFormGN7Button);
            this.oltPanel13.Controls.Add(this.gn7CheckBox);
            this.oltPanel13.Controls.Add(this.gn7FormNumberTextBox);
            this.oltPanel13.Location = new System.Drawing.Point(4, 62);
            this.oltPanel13.Name = "oltPanel13";
            this.oltPanel13.Size = new System.Drawing.Size(222, 21);
            this.oltPanel13.TabIndex = 1;
            // 
            // selectFormGN7Button
            // 
            this.selectFormGN7Button.Location = new System.Drawing.Point(175, 0);
            this.selectFormGN7Button.Name = "selectFormGN7Button";
            this.selectFormGN7Button.Size = new System.Drawing.Size(27, 20);
            this.selectFormGN7Button.TabIndex = 3;
            this.selectFormGN7Button.Text = "...";
            this.selectFormGN7Button.UseVisualStyleBackColor = true;
            // 
            // gn7CheckBox
            // 
            this.gn7CheckBox.AutoSize = true;
            this.gn7CheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gn7CheckBox.Location = new System.Drawing.Point(5, 2);
            this.gn7CheckBox.Name = "gn7CheckBox";
            this.gn7CheckBox.Size = new System.Drawing.Size(92, 17);
            this.gn7CheckBox.TabIndex = 0;
            this.gn7CheckBox.Text = "GN-7 Form #:";
            this.gn7CheckBox.UseVisualStyleBackColor = true;
            this.gn7CheckBox.Value = null;
            // 
            // gn7FormNumberTextBox
            // 
            this.gn7FormNumberTextBox.Location = new System.Drawing.Point(103, 0);
            this.gn7FormNumberTextBox.MaxLength = 10;
            this.gn7FormNumberTextBox.Name = "gn7FormNumberTextBox";
            this.gn7FormNumberTextBox.OltAcceptsReturn = true;
            this.gn7FormNumberTextBox.OltTrimWhitespace = true;
            this.gn7FormNumberTextBox.ReadOnly = true;
            this.gn7FormNumberTextBox.Size = new System.Drawing.Size(70, 20);
            this.gn7FormNumberTextBox.TabIndex = 2;
            this.gn7FormNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gn27Label
            // 
            this.gn27Label.AutoSize = true;
            this.gn27Label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gn27Label.Location = new System.Drawing.Point(8, 186);
            this.gn27Label.Name = "gn27Label";
            this.gn27Label.Size = new System.Drawing.Size(37, 13);
            this.gn27Label.TabIndex = 7;
            this.gn27Label.Text = "GN-27";
            // 
            // gn27ComboBox
            // 
            this.gn27ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gn27ComboBox.FormattingEnabled = true;
            this.gn27ComboBox.Location = new System.Drawing.Point(49, 181);
            this.gn27ComboBox.Name = "gn27ComboBox";
            this.gn27ComboBox.Size = new System.Drawing.Size(84, 21);
            this.gn27ComboBox.TabIndex = 8;
            // 
            // gn11ComboBox
            // 
            this.gn11ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gn11ComboBox.FormattingEnabled = true;
            this.gn11ComboBox.Location = new System.Drawing.Point(49, 156);
            this.gn11ComboBox.Name = "gn11ComboBox";
            this.gn11ComboBox.Size = new System.Drawing.Size(84, 21);
            this.gn11ComboBox.TabIndex = 6;
            // 
            // gn11Label
            // 
            this.gn11Label.AutoSize = true;
            this.gn11Label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gn11Label.Location = new System.Drawing.Point(8, 161);
            this.gn11Label.Name = "gn11Label";
            this.gn11Label.Size = new System.Drawing.Size(37, 13);
            this.gn11Label.TabIndex = 5;
            this.gn11Label.Text = "GN-11";
            // 
            // typeOfWorkGroupBox
            // 
            this.typeOfWorkGroupBox.Controls.Add(this.oltPanel22);
            this.typeOfWorkGroupBox.Controls.Add(this.oltPanel8);
            this.typeOfWorkGroupBox.Controls.Add(this.oltPanel7);
            this.typeOfWorkGroupBox.Controls.Add(this.oltPanel6);
            this.typeOfWorkGroupBox.Controls.Add(this.oltPanel5);
            this.typeOfWorkGroupBox.Controls.Add(this.oltPanel4);
            this.typeOfWorkGroupBox.Controls.Add(this.oltPanel3);
            this.typeOfWorkGroupBox.Controls.Add(this.oltLabel6);
            this.typeOfWorkGroupBox.Location = new System.Drawing.Point(9, 211);
            this.typeOfWorkGroupBox.Name = "typeOfWorkGroupBox";
            this.typeOfWorkGroupBox.Size = new System.Drawing.Size(403, 214);
            this.typeOfWorkGroupBox.TabIndex = 6;
            this.typeOfWorkGroupBox.TabStop = false;
            this.typeOfWorkGroupBox.Text = "Type of Work";
            // 
            // oltPanel22
            // 
            this.oltPanel22.Controls.Add(this.roadAccessOnPermitComboBox);
            this.oltPanel22.Controls.Add(this.oltLabel16);
            this.oltPanel22.Controls.Add(this.roadAccessOnPermitCheckBox);
            this.oltPanel22.Controls.Add(this.oltLabel19);
            this.oltPanel22.Controls.Add(this.roadAccessOnPermitFormNumberTextBox);
            this.oltPanel22.Location = new System.Drawing.Point(6, 136);
            this.oltPanel22.Name = "oltPanel22";
            this.oltPanel22.Size = new System.Drawing.Size(391, 26);
            this.oltPanel22.TabIndex = 8;
            // 
            // roadAccessOnPermitComboBox
            // 
            this.roadAccessOnPermitComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.roadAccessOnPermitComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.roadAccessOnPermitComboBox.DropDownWidth = 250;
            this.roadAccessOnPermitComboBox.Enabled = false;
            this.roadAccessOnPermitComboBox.FormattingEnabled = true;
            this.roadAccessOnPermitComboBox.Location = new System.Drawing.Point(194, 2);
            this.roadAccessOnPermitComboBox.MaxDropDownItems = 16;
            this.roadAccessOnPermitComboBox.MaxLength = 35;
            this.roadAccessOnPermitComboBox.Name = "roadAccessOnPermitComboBox";
            this.roadAccessOnPermitComboBox.Size = new System.Drawing.Size(179, 21);
            this.roadAccessOnPermitComboBox.TabIndex = 7;
            // 
            // oltLabel16
            // 
            this.oltLabel16.AutoSize = true;
            this.oltLabel16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel16.Location = new System.Drawing.Point(148, 6);
            this.oltLabel16.Name = "oltLabel16";
            this.oltLabel16.Size = new System.Drawing.Size(35, 13);
            this.oltLabel16.TabIndex = 1;
            this.oltLabel16.Text = "Type:";
            this.oltLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // roadAccessOnPermitCheckBox
            // 
            this.roadAccessOnPermitCheckBox.AutoSize = true;
            this.roadAccessOnPermitCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roadAccessOnPermitCheckBox.Location = new System.Drawing.Point(3, 5);
            this.roadAccessOnPermitCheckBox.Name = "roadAccessOnPermitCheckBox";
            this.roadAccessOnPermitCheckBox.Size = new System.Drawing.Size(135, 17);
            this.roadAccessOnPermitCheckBox.TabIndex = 0;
            this.roadAccessOnPermitCheckBox.Text = "Road Access on Permit";
            this.roadAccessOnPermitCheckBox.UseVisualStyleBackColor = true;
            this.roadAccessOnPermitCheckBox.Value = null;
            // 
            // oltLabel19
            // 
            this.oltLabel19.AutoSize = true;
            this.oltLabel19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel19.Location = new System.Drawing.Point(163, 6);
            this.oltLabel19.Name = "oltLabel19";
            this.oltLabel19.Size = new System.Drawing.Size(46, 13);
            this.oltLabel19.TabIndex = 3;
            this.oltLabel19.Text = "Form #:";
            this.oltLabel19.Visible = false;
            // 
            // roadAccessOnPermitFormNumberTextBox
            // 
            this.roadAccessOnPermitFormNumberTextBox.Location = new System.Drawing.Point(208, 3);
            this.roadAccessOnPermitFormNumberTextBox.MaxLength = 10;
            this.roadAccessOnPermitFormNumberTextBox.Name = "roadAccessOnPermitFormNumberTextBox";
            this.roadAccessOnPermitFormNumberTextBox.OltAcceptsReturn = true;
            this.roadAccessOnPermitFormNumberTextBox.OltTrimWhitespace = true;
            this.roadAccessOnPermitFormNumberTextBox.ReadOnly = true;
            this.roadAccessOnPermitFormNumberTextBox.Size = new System.Drawing.Size(118, 20);
            this.roadAccessOnPermitFormNumberTextBox.TabIndex = 4;
            this.roadAccessOnPermitFormNumberTextBox.Visible = false;
            // 
            // oltPanel8
            // 
            this.oltPanel8.Controls.Add(this.classOfClothingComboBox);
            this.oltPanel8.Controls.Add(this.alkylationEntryCheckBox);
            this.oltPanel8.Controls.Add(this.oltLabel2);
            this.oltPanel8.Location = new System.Drawing.Point(6, 21);
            this.oltPanel8.Name = "oltPanel8";
            this.oltPanel8.Size = new System.Drawing.Size(284, 21);
            this.oltPanel8.TabIndex = 1;
            // 
            // classOfClothingComboBox
            // 
            this.classOfClothingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classOfClothingComboBox.FormattingEnabled = true;
            this.classOfClothingComboBox.Location = new System.Drawing.Point(196, 0);
            this.classOfClothingComboBox.Name = "classOfClothingComboBox";
            this.classOfClothingComboBox.Size = new System.Drawing.Size(61, 21);
            this.classOfClothingComboBox.TabIndex = 2;
            // 
            // alkylationEntryCheckBox
            // 
            this.alkylationEntryCheckBox.AutoSize = true;
            this.alkylationEntryCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.alkylationEntryCheckBox.Location = new System.Drawing.Point(3, 2);
            this.alkylationEntryCheckBox.Name = "alkylationEntryCheckBox";
            this.alkylationEntryCheckBox.Size = new System.Drawing.Size(101, 17);
            this.alkylationEntryCheckBox.TabIndex = 0;
            this.alkylationEntryCheckBox.Text = "Alkylation Entry";
            this.alkylationEntryCheckBox.UseVisualStyleBackColor = true;
            this.alkylationEntryCheckBox.Value = null;
            // 
            // oltLabel2
            // 
            this.oltLabel2.AutoSize = true;
            this.oltLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel2.Location = new System.Drawing.Point(102, 3);
            this.oltLabel2.Name = "oltLabel2";
            this.oltLabel2.Size = new System.Drawing.Size(91, 13);
            this.oltLabel2.TabIndex = 1;
            this.oltLabel2.Text = "Class of Clothing:";
            // 
            // oltPanel7
            // 
            this.oltPanel7.Controls.Add(this.flarePitEntryTypeComboBox);
            this.oltPanel7.Controls.Add(this.flarePitEntryCheckBox);
            this.oltPanel7.Controls.Add(this.oltLabel3);
            this.oltPanel7.Location = new System.Drawing.Point(6, 44);
            this.oltPanel7.Name = "oltPanel7";
            this.oltPanel7.Size = new System.Drawing.Size(258, 21);
            this.oltPanel7.TabIndex = 2;
            // 
            // flarePitEntryTypeComboBox
            // 
            this.flarePitEntryTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flarePitEntryTypeComboBox.FormattingEnabled = true;
            this.flarePitEntryTypeComboBox.Location = new System.Drawing.Point(149, 0);
            this.flarePitEntryTypeComboBox.Name = "flarePitEntryTypeComboBox";
            this.flarePitEntryTypeComboBox.Size = new System.Drawing.Size(50, 21);
            this.flarePitEntryTypeComboBox.TabIndex = 2;
            // 
            // flarePitEntryCheckBox
            // 
            this.flarePitEntryCheckBox.AutoSize = true;
            this.flarePitEntryCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flarePitEntryCheckBox.Location = new System.Drawing.Point(3, 2);
            this.flarePitEntryCheckBox.Name = "flarePitEntryCheckBox";
            this.flarePitEntryCheckBox.Size = new System.Drawing.Size(94, 17);
            this.flarePitEntryCheckBox.TabIndex = 0;
            this.flarePitEntryCheckBox.Text = "Flare Pit Entry";
            this.flarePitEntryCheckBox.UseVisualStyleBackColor = true;
            this.flarePitEntryCheckBox.Value = null;
            // 
            // oltLabel3
            // 
            this.oltLabel3.AutoSize = true;
            this.oltLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel3.Location = new System.Drawing.Point(102, 3);
            this.oltLabel3.Name = "oltLabel3";
            this.oltLabel3.Size = new System.Drawing.Size(35, 13);
            this.oltLabel3.TabIndex = 1;
            this.oltLabel3.Text = "Type:";
            // 
            // oltPanel6
            // 
            this.oltPanel6.Controls.Add(this.specialWorkComboBox);
            this.oltPanel6.Controls.Add(this.specialWorkTypeComboBox);
            this.oltPanel6.Controls.Add(this.oltLabel47);
            this.oltPanel6.Controls.Add(this.specialWorkCheckBox);
            this.oltPanel6.Controls.Add(this.oltLabel14);
            this.oltPanel6.Controls.Add(this.specialWorkFormNumberTextBox);
            this.oltPanel6.Location = new System.Drawing.Point(6, 164);
            this.oltPanel6.Name = "oltPanel6";
            this.oltPanel6.Size = new System.Drawing.Size(391, 46);
            this.oltPanel6.TabIndex = 6;
            // 
            // specialWorkComboBox
            // 
            this.specialWorkComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.specialWorkComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.specialWorkComboBox.DropDownWidth = 250;
            this.specialWorkComboBox.Enabled = false;
            this.specialWorkComboBox.FormattingEnabled = true;
            this.specialWorkComboBox.Location = new System.Drawing.Point(149, 0);
            this.specialWorkComboBox.MaxDropDownItems = 16;
            this.specialWorkComboBox.MaxLength = 35;
            this.specialWorkComboBox.Name = "specialWorkComboBox";
            this.specialWorkComboBox.Size = new System.Drawing.Size(226, 21);
            this.specialWorkComboBox.TabIndex = 5;
            // 
            // specialWorkTypeComboBox
            // 
            this.specialWorkTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specialWorkTypeComboBox.DropDownWidth = 300;
            this.specialWorkTypeComboBox.FormattingEnabled = true;
            this.specialWorkTypeComboBox.Location = new System.Drawing.Point(285, 24);
            this.specialWorkTypeComboBox.Name = "specialWorkTypeComboBox";
            this.specialWorkTypeComboBox.Size = new System.Drawing.Size(89, 21);
            this.specialWorkTypeComboBox.TabIndex = 2;
            this.specialWorkTypeComboBox.Visible = false;
            // 
            // oltLabel47
            // 
            this.oltLabel47.AutoSize = true;
            this.oltLabel47.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel47.Location = new System.Drawing.Point(102, 3);
            this.oltLabel47.Name = "oltLabel47";
            this.oltLabel47.Size = new System.Drawing.Size(35, 13);
            this.oltLabel47.TabIndex = 1;
            this.oltLabel47.Text = "Type:";
            // 
            // specialWorkCheckBox
            // 
            this.specialWorkCheckBox.AutoSize = true;
            this.specialWorkCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.specialWorkCheckBox.Location = new System.Drawing.Point(3, 2);
            this.specialWorkCheckBox.Name = "specialWorkCheckBox";
            this.specialWorkCheckBox.Size = new System.Drawing.Size(87, 17);
            this.specialWorkCheckBox.TabIndex = 0;
            this.specialWorkCheckBox.Text = "Special Work";
            this.specialWorkCheckBox.UseVisualStyleBackColor = true;
            this.specialWorkCheckBox.Value = null;
            // 
            // oltLabel14
            // 
            this.oltLabel14.AutoSize = true;
            this.oltLabel14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel14.Location = new System.Drawing.Point(102, 26);
            this.oltLabel14.Name = "oltLabel14";
            this.oltLabel14.Size = new System.Drawing.Size(46, 13);
            this.oltLabel14.TabIndex = 3;
            this.oltLabel14.Text = "Form #:";
            // 
            // specialWorkFormNumberTextBox
            // 
            this.specialWorkFormNumberTextBox.Location = new System.Drawing.Point(149, 23);
            this.specialWorkFormNumberTextBox.MaxLength = 10;
            this.specialWorkFormNumberTextBox.Name = "specialWorkFormNumberTextBox";
            this.specialWorkFormNumberTextBox.OltAcceptsReturn = true;
            this.specialWorkFormNumberTextBox.OltTrimWhitespace = true;
            this.specialWorkFormNumberTextBox.ReadOnly = true;
            this.specialWorkFormNumberTextBox.Size = new System.Drawing.Size(117, 20);
            this.specialWorkFormNumberTextBox.TabIndex = 4;
            // 
            // oltPanel5
            // 
            this.oltPanel5.Controls.Add(this.vehicleEntryTotalNumberTextBox);
            this.oltPanel5.Controls.Add(this.oltLabel46);
            this.oltPanel5.Controls.Add(this.vehicleEntryTypeTextBox);
            this.oltPanel5.Controls.Add(this.vehicleEntryCheckBox);
            this.oltPanel5.Controls.Add(this.oltLabel8);
            this.oltPanel5.Location = new System.Drawing.Point(6, 113);
            this.oltPanel5.Name = "oltPanel5";
            this.oltPanel5.Size = new System.Drawing.Size(391, 21);
            this.oltPanel5.TabIndex = 5;
            // 
            // vehicleEntryTotalNumberTextBox
            // 
            this.vehicleEntryTotalNumberTextBox.DecimalValue = null;
            this.vehicleEntryTotalNumberTextBox.IntegerValue = null;
            this.vehicleEntryTotalNumberTextBox.Location = new System.Drawing.Point(149, 0);
            this.vehicleEntryTotalNumberTextBox.MaxLength = 3;
            this.vehicleEntryTotalNumberTextBox.Name = "vehicleEntryTotalNumberTextBox";
            this.vehicleEntryTotalNumberTextBox.NumericValue = null;
            this.vehicleEntryTotalNumberTextBox.ReadOnly = true;
            this.vehicleEntryTotalNumberTextBox.Size = new System.Drawing.Size(40, 20);
            this.vehicleEntryTotalNumberTextBox.TabIndex = 2;
            this.vehicleEntryTotalNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // oltLabel46
            // 
            this.oltLabel46.AutoSize = true;
            this.oltLabel46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel46.Location = new System.Drawing.Point(190, 4);
            this.oltLabel46.Name = "oltLabel46";
            this.oltLabel46.Size = new System.Drawing.Size(35, 13);
            this.oltLabel46.TabIndex = 3;
            this.oltLabel46.Text = "Type:";
            // 
            // vehicleEntryTypeTextBox
            // 
            this.vehicleEntryTypeTextBox.Location = new System.Drawing.Point(225, 0);
            this.vehicleEntryTypeTextBox.MaxLength = 30;
            this.vehicleEntryTypeTextBox.Name = "vehicleEntryTypeTextBox";
            this.vehicleEntryTypeTextBox.OltAcceptsReturn = true;
            this.vehicleEntryTypeTextBox.OltTrimWhitespace = true;
            this.vehicleEntryTypeTextBox.ReadOnly = true;
            this.vehicleEntryTypeTextBox.Size = new System.Drawing.Size(148, 20);
            this.vehicleEntryTypeTextBox.TabIndex = 4;
            // 
            // vehicleEntryCheckBox
            // 
            this.vehicleEntryCheckBox.AutoSize = true;
            this.vehicleEntryCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.vehicleEntryCheckBox.Location = new System.Drawing.Point(3, 2);
            this.vehicleEntryCheckBox.Name = "vehicleEntryCheckBox";
            this.vehicleEntryCheckBox.Size = new System.Drawing.Size(88, 17);
            this.vehicleEntryCheckBox.TabIndex = 0;
            this.vehicleEntryCheckBox.Text = "Vehicle Entry";
            this.vehicleEntryCheckBox.UseVisualStyleBackColor = true;
            this.vehicleEntryCheckBox.Value = null;
            // 
            // oltLabel8
            // 
            this.oltLabel8.AutoSize = true;
            this.oltLabel8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel8.Location = new System.Drawing.Point(102, 4);
            this.oltLabel8.Name = "oltLabel8";
            this.oltLabel8.Size = new System.Drawing.Size(46, 13);
            this.oltLabel8.TabIndex = 1;
            this.oltLabel8.Text = "Total #:";
            // 
            // oltPanel4
            // 
            this.oltPanel4.Controls.Add(this.rescuePlanFormNumberTextBox);
            this.oltPanel4.Controls.Add(this.rescuePlanCheckBox);
            this.oltPanel4.Controls.Add(this.oltLabel7);
            this.oltPanel4.Location = new System.Drawing.Point(7, 90);
            this.oltPanel4.Name = "oltPanel4";
            this.oltPanel4.Size = new System.Drawing.Size(266, 21);
            this.oltPanel4.TabIndex = 4;
            // 
            // rescuePlanFormNumberTextBox
            // 
            this.rescuePlanFormNumberTextBox.Location = new System.Drawing.Point(149, 0);
            this.rescuePlanFormNumberTextBox.MaxLength = 10;
            this.rescuePlanFormNumberTextBox.Name = "rescuePlanFormNumberTextBox";
            this.rescuePlanFormNumberTextBox.OltAcceptsReturn = true;
            this.rescuePlanFormNumberTextBox.OltTrimWhitespace = true;
            this.rescuePlanFormNumberTextBox.ReadOnly = true;
            this.rescuePlanFormNumberTextBox.Size = new System.Drawing.Size(90, 20);
            this.rescuePlanFormNumberTextBox.TabIndex = 2;
            // 
            // rescuePlanCheckBox
            // 
            this.rescuePlanCheckBox.AutoSize = true;
            this.rescuePlanCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rescuePlanCheckBox.Location = new System.Drawing.Point(2, 2);
            this.rescuePlanCheckBox.Name = "rescuePlanCheckBox";
            this.rescuePlanCheckBox.Size = new System.Drawing.Size(84, 17);
            this.rescuePlanCheckBox.TabIndex = 0;
            this.rescuePlanCheckBox.Text = "Rescue Plan";
            this.rescuePlanCheckBox.UseVisualStyleBackColor = true;
            this.rescuePlanCheckBox.Value = null;
            // 
            // oltLabel7
            // 
            this.oltLabel7.AutoSize = true;
            this.oltLabel7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel7.Location = new System.Drawing.Point(102, 3);
            this.oltLabel7.Name = "oltLabel7";
            this.oltLabel7.Size = new System.Drawing.Size(46, 13);
            this.oltLabel7.TabIndex = 1;
            this.oltLabel7.Text = "Form #:";
            // 
            // oltPanel3
            // 
            this.oltPanel3.Controls.Add(this.confinedSpaceClassComboBox);
            this.oltPanel3.Controls.Add(this.oltLabel21);
            this.oltPanel3.Controls.Add(this.confinedSpaceCheckBox);
            this.oltPanel3.Controls.Add(this.oltLabel5);
            this.oltPanel3.Controls.Add(this.confinedSpaceCardNumberTextBox);
            this.oltPanel3.Location = new System.Drawing.Point(6, 67);
            this.oltPanel3.Name = "oltPanel3";
            this.oltPanel3.Size = new System.Drawing.Size(391, 21);
            this.oltPanel3.TabIndex = 3;
            // 
            // confinedSpaceClassComboBox
            // 
            this.confinedSpaceClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.confinedSpaceClassComboBox.FormattingEnabled = true;
            this.confinedSpaceClassComboBox.Location = new System.Drawing.Point(149, 0);
            this.confinedSpaceClassComboBox.Name = "confinedSpaceClassComboBox";
            this.confinedSpaceClassComboBox.Size = new System.Drawing.Size(50, 21);
            this.confinedSpaceClassComboBox.TabIndex = 2;
            // 
            // oltLabel21
            // 
            this.oltLabel21.AutoSize = true;
            this.oltLabel21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel21.Location = new System.Drawing.Point(102, 4);
            this.oltLabel21.Name = "oltLabel21";
            this.oltLabel21.Size = new System.Drawing.Size(36, 13);
            this.oltLabel21.TabIndex = 1;
            this.oltLabel21.Text = "Level:";
            // 
            // confinedSpaceCheckBox
            // 
            this.confinedSpaceCheckBox.AutoSize = true;
            this.confinedSpaceCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.confinedSpaceCheckBox.Location = new System.Drawing.Point(3, 3);
            this.confinedSpaceCheckBox.Name = "confinedSpaceCheckBox";
            this.confinedSpaceCheckBox.Size = new System.Drawing.Size(101, 17);
            this.confinedSpaceCheckBox.TabIndex = 0;
            this.confinedSpaceCheckBox.Text = "Confined Space";
            this.confinedSpaceCheckBox.UseVisualStyleBackColor = true;
            this.confinedSpaceCheckBox.Value = null;
            // 
            // oltLabel5
            // 
            this.oltLabel5.AutoSize = true;
            this.oltLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel5.Location = new System.Drawing.Point(222, 4);
            this.oltLabel5.Name = "oltLabel5";
            this.oltLabel5.Size = new System.Drawing.Size(46, 13);
            this.oltLabel5.TabIndex = 3;
            this.oltLabel5.Text = "Form #:";
            // 
            // confinedSpaceCardNumberTextBox
            // 
            this.confinedSpaceCardNumberTextBox.Location = new System.Drawing.Point(271, 0);
            this.confinedSpaceCardNumberTextBox.MaxLength = 10;
            this.confinedSpaceCardNumberTextBox.Name = "confinedSpaceCardNumberTextBox";
            this.confinedSpaceCardNumberTextBox.OltAcceptsReturn = true;
            this.confinedSpaceCardNumberTextBox.OltTrimWhitespace = true;
            this.confinedSpaceCardNumberTextBox.ReadOnly = true;
            this.confinedSpaceCardNumberTextBox.Size = new System.Drawing.Size(102, 20);
            this.confinedSpaceCardNumberTextBox.TabIndex = 4;
            // 
            // oltLabel6
            // 
            this.oltLabel6.AutoSize = true;
            this.oltLabel6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel6.Location = new System.Drawing.Point(254, 69);
            this.oltLabel6.Name = "oltLabel6";
            this.oltLabel6.Size = new System.Drawing.Size(36, 13);
            this.oltLabel6.TabIndex = 0;
            this.oltLabel6.Text = "Class:";
            // 
            // hazardsAndOrRequirementsGroupBox
            // 
            this.hazardsAndOrRequirementsGroupBox.Controls.Add(this.hazardsAndOrRequirementsTextBox);
            this.hazardsAndOrRequirementsGroupBox.Location = new System.Drawing.Point(12, 726);
            this.hazardsAndOrRequirementsGroupBox.Name = "hazardsAndOrRequirementsGroupBox";
            this.hazardsAndOrRequirementsGroupBox.Size = new System.Drawing.Size(937, 95);
            this.hazardsAndOrRequirementsGroupBox.TabIndex = 14;
            this.hazardsAndOrRequirementsGroupBox.TabStop = false;
            this.hazardsAndOrRequirementsGroupBox.Text = "Hazards And/Or Requirements";
            // 
            // hazardsAndOrRequirementsTextBox
            // 
            this.hazardsAndOrRequirementsTextBox.AcceptsTabAndReturn = true;
            this.hazardsAndOrRequirementsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hazardsAndOrRequirementsTextBox.Location = new System.Drawing.Point(3, 17);
            this.hazardsAndOrRequirementsTextBox.MaxLength = 2000;
            this.hazardsAndOrRequirementsTextBox.Name = "hazardsAndOrRequirementsTextBox";
            this.hazardsAndOrRequirementsTextBox.OltTrimWhitespace = true;
            this.hazardsAndOrRequirementsTextBox.ReadOnly = false;
            this.hazardsAndOrRequirementsTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.hazardsAndOrRequirementsTextBox.Size = new System.Drawing.Size(918, 72);
            this.hazardsAndOrRequirementsTextBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.currentSAPDescriptionGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.taskDescriptionGroupBox, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 426);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(943, 294);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // currentSAPDescriptionGroupBox
            // 
            this.currentSAPDescriptionGroupBox.Controls.Add(this.sapDescriptionTextBox);
            this.currentSAPDescriptionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentSAPDescriptionGroupBox.Location = new System.Drawing.Point(3, 157);
            this.currentSAPDescriptionGroupBox.Name = "currentSAPDescriptionGroupBox";
            this.currentSAPDescriptionGroupBox.Size = new System.Drawing.Size(937, 134);
            this.currentSAPDescriptionGroupBox.TabIndex = 1;
            this.currentSAPDescriptionGroupBox.TabStop = false;
            this.currentSAPDescriptionGroupBox.Text = "Current SAP Description";
            // 
            // sapDescriptionTextBox
            // 
            this.sapDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sapDescriptionTextBox.Location = new System.Drawing.Point(3, 17);
            this.sapDescriptionTextBox.MaxLength = 8000;
            this.sapDescriptionTextBox.Multiline = true;
            this.sapDescriptionTextBox.Name = "sapDescriptionTextBox";
            this.sapDescriptionTextBox.OltAcceptsReturn = true;
            this.sapDescriptionTextBox.OltTrimWhitespace = true;
            this.sapDescriptionTextBox.ReadOnly = true;
            this.sapDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sapDescriptionTextBox.Size = new System.Drawing.Size(917, 110);
            this.sapDescriptionTextBox.TabIndex = 69;
            // 
            // taskDescriptionGroupBox
            // 
            this.taskDescriptionGroupBox.Controls.Add(this.descriptionTextBox);
            this.taskDescriptionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskDescriptionGroupBox.Location = new System.Drawing.Point(3, 3);
            this.taskDescriptionGroupBox.Name = "taskDescriptionGroupBox";
            this.taskDescriptionGroupBox.Size = new System.Drawing.Size(937, 148);
            this.taskDescriptionGroupBox.TabIndex = 0;
            this.taskDescriptionGroupBox.TabStop = false;
            this.taskDescriptionGroupBox.Text = "Task Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.AcceptsTabAndReturn = true;
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.descriptionTextBox.Location = new System.Drawing.Point(3, 17);
            this.descriptionTextBox.MaxLength = 8000;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.OltTrimWhitespace = true;
            this.descriptionTextBox.ReadOnly = false;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(917, 125);
            this.descriptionTextBox.TabIndex = 65;
            // 
            // workersMinimumSafetyRequirementsGroupBox
            // 
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.label20);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.label19);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.label18);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.label8);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.oltPanel17);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.oltPanel15);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.oltPanel14);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.oltPanel12);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.oltPanel10);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.oltPanel11);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.airMoverCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.barriersSignsCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.airHornCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.mechVentilationComfortOnlyCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.asbestosMmfPrecautionsCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.airPurifyingRespiratorCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.breathingAirApparatusCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.dustMaskCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.lifeSupportSystemCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.safetyWatchCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.continuousGasMonitorCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.bumpTestMonitorPriorToUseCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.equipmentGroundedCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.fireBlanketCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.fireExtinguisherCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.fireMonitorMannedCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.fireWatchCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.sewersDrainsCoveredCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.steamHoseCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.highVoltagePPECheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.safetyHarnessLifelineCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.rubberSuitCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.rubberGlovesCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.rubberBootsCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.gogglesCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Controls.Add(this.faceShieldCheckBox);
            this.workersMinimumSafetyRequirementsGroupBox.Location = new System.Drawing.Point(9, 900);
            this.workersMinimumSafetyRequirementsGroupBox.Name = "workersMinimumSafetyRequirementsGroupBox";
            this.workersMinimumSafetyRequirementsGroupBox.Size = new System.Drawing.Size(938, 250);
            this.workersMinimumSafetyRequirementsGroupBox.TabIndex = 18;
            this.workersMinimumSafetyRequirementsGroupBox.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(721, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(142, 13);
            this.label20.TabIndex = 35;
            this.label20.Text = "Other Safety Equipment";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(459, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(136, 13);
            this.label19.TabIndex = 34;
            this.label19.Text = "Respiratory Protection";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(230, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(153, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Fire Protective Equipment";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(5, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Personal Protective Equipment";
            // 
            // oltPanel17
            // 
            this.oltPanel17.Controls.Add(this.other4TextBox);
            this.oltPanel17.Controls.Add(this.other4CheckBox);
            this.oltPanel17.Location = new System.Drawing.Point(721, 171);
            this.oltPanel17.Name = "oltPanel17";
            this.oltPanel17.Size = new System.Drawing.Size(215, 24);
            this.oltPanel17.TabIndex = 31;
            // 
            // other4TextBox
            // 
            this.other4TextBox.Location = new System.Drawing.Point(55, 2);
            this.other4TextBox.MaxLength = 15;
            this.other4TextBox.Name = "other4TextBox";
            this.other4TextBox.OltAcceptsReturn = true;
            this.other4TextBox.OltTrimWhitespace = true;
            this.other4TextBox.ReadOnly = true;
            this.other4TextBox.Size = new System.Drawing.Size(140, 20);
            this.other4TextBox.TabIndex = 1;
            // 
            // other4CheckBox
            // 
            this.other4CheckBox.AutoSize = true;
            this.other4CheckBox.Location = new System.Drawing.Point(3, 4);
            this.other4CheckBox.Name = "other4CheckBox";
            this.other4CheckBox.Size = new System.Drawing.Size(54, 17);
            this.other4CheckBox.TabIndex = 0;
            this.other4CheckBox.Text = "Other";
            this.other4CheckBox.UseVisualStyleBackColor = true;
            this.other4CheckBox.Value = null;
            // 
            // oltPanel15
            // 
            this.oltPanel15.Controls.Add(this.other3TextBox);
            this.oltPanel15.Controls.Add(this.other3CheckBox);
            this.oltPanel15.Location = new System.Drawing.Point(459, 217);
            this.oltPanel15.Name = "oltPanel15";
            this.oltPanel15.Size = new System.Drawing.Size(215, 24);
            this.oltPanel15.TabIndex = 24;
            // 
            // other3TextBox
            // 
            this.other3TextBox.Location = new System.Drawing.Point(55, 2);
            this.other3TextBox.MaxLength = 15;
            this.other3TextBox.Name = "other3TextBox";
            this.other3TextBox.OltAcceptsReturn = true;
            this.other3TextBox.OltTrimWhitespace = true;
            this.other3TextBox.ReadOnly = true;
            this.other3TextBox.Size = new System.Drawing.Size(140, 20);
            this.other3TextBox.TabIndex = 1;
            // 
            // other3CheckBox
            // 
            this.other3CheckBox.AutoSize = true;
            this.other3CheckBox.Location = new System.Drawing.Point(3, 4);
            this.other3CheckBox.Name = "other3CheckBox";
            this.other3CheckBox.Size = new System.Drawing.Size(54, 17);
            this.other3CheckBox.TabIndex = 0;
            this.other3CheckBox.Text = "Other";
            this.other3CheckBox.UseVisualStyleBackColor = true;
            this.other3CheckBox.Value = null;
            // 
            // oltPanel14
            // 
            this.oltPanel14.Controls.Add(this.other2TextBox);
            this.oltPanel14.Controls.Add(this.other2CheckBox);
            this.oltPanel14.Location = new System.Drawing.Point(230, 193);
            this.oltPanel14.Name = "oltPanel14";
            this.oltPanel14.Size = new System.Drawing.Size(215, 24);
            this.oltPanel14.TabIndex = 15;
            // 
            // other2TextBox
            // 
            this.other2TextBox.Location = new System.Drawing.Point(55, 2);
            this.other2TextBox.MaxLength = 15;
            this.other2TextBox.Name = "other2TextBox";
            this.other2TextBox.OltAcceptsReturn = true;
            this.other2TextBox.OltTrimWhitespace = true;
            this.other2TextBox.ReadOnly = true;
            this.other2TextBox.Size = new System.Drawing.Size(140, 20);
            this.other2TextBox.TabIndex = 1;
            // 
            // other2CheckBox
            // 
            this.other2CheckBox.AutoSize = true;
            this.other2CheckBox.Location = new System.Drawing.Point(3, 4);
            this.other2CheckBox.Name = "other2CheckBox";
            this.other2CheckBox.Size = new System.Drawing.Size(54, 17);
            this.other2CheckBox.TabIndex = 0;
            this.other2CheckBox.Text = "Other";
            this.other2CheckBox.UseVisualStyleBackColor = true;
            this.other2CheckBox.Value = null;
            // 
            // oltPanel12
            // 
            this.oltPanel12.Controls.Add(this.other1TextBox);
            this.oltPanel12.Controls.Add(this.other1CheckBox);
            this.oltPanel12.Location = new System.Drawing.Point(5, 193);
            this.oltPanel12.Name = "oltPanel12";
            this.oltPanel12.Size = new System.Drawing.Size(215, 24);
            this.oltPanel12.TabIndex = 7;
            // 
            // other1TextBox
            // 
            this.other1TextBox.Location = new System.Drawing.Point(55, 2);
            this.other1TextBox.MaxLength = 15;
            this.other1TextBox.Name = "other1TextBox";
            this.other1TextBox.OltAcceptsReturn = true;
            this.other1TextBox.OltTrimWhitespace = true;
            this.other1TextBox.ReadOnly = true;
            this.other1TextBox.Size = new System.Drawing.Size(140, 20);
            this.other1TextBox.TabIndex = 1;
            // 
            // other1CheckBox
            // 
            this.other1CheckBox.AutoSize = true;
            this.other1CheckBox.Location = new System.Drawing.Point(3, 4);
            this.other1CheckBox.Name = "other1CheckBox";
            this.other1CheckBox.Size = new System.Drawing.Size(54, 17);
            this.other1CheckBox.TabIndex = 0;
            this.other1CheckBox.Text = "Other";
            this.other1CheckBox.UseVisualStyleBackColor = true;
            this.other1CheckBox.Value = null;
            // 
            // oltPanel10
            // 
            this.oltPanel10.Controls.Add(this.workersMonitorNumberCheckBox);
            this.oltPanel10.Controls.Add(this.workersMonitorNumberTextBox);
            this.oltPanel10.Location = new System.Drawing.Point(459, 171);
            this.oltPanel10.Name = "oltPanel10";
            this.oltPanel10.Size = new System.Drawing.Size(245, 24);
            this.oltPanel10.TabIndex = 22;
            // 
            // workersMonitorNumberCheckBox
            // 
            this.workersMonitorNumberCheckBox.AutoSize = true;
            this.workersMonitorNumberCheckBox.Location = new System.Drawing.Point(3, 3);
            this.workersMonitorNumberCheckBox.Name = "workersMonitorNumberCheckBox";
            this.workersMonitorNumberCheckBox.Size = new System.Drawing.Size(118, 17);
            this.workersMonitorNumberCheckBox.TabIndex = 0;
            this.workersMonitorNumberCheckBox.Text = "Worker\'s Monitor #";
            this.workersMonitorNumberCheckBox.UseVisualStyleBackColor = true;
            this.workersMonitorNumberCheckBox.Value = null;
            // 
            // workersMonitorNumberTextBox
            // 
            this.workersMonitorNumberTextBox.Location = new System.Drawing.Point(125, 2);
            this.workersMonitorNumberTextBox.MaxLength = 10;
            this.workersMonitorNumberTextBox.Name = "workersMonitorNumberTextBox";
            this.workersMonitorNumberTextBox.OltAcceptsReturn = true;
            this.workersMonitorNumberTextBox.OltTrimWhitespace = true;
            this.workersMonitorNumberTextBox.ReadOnly = true;
            this.workersMonitorNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.workersMonitorNumberTextBox.TabIndex = 1;
            // 
            // oltPanel11
            // 
            this.oltPanel11.Controls.Add(this.radioChannelNumberTextBox);
            this.oltPanel11.Controls.Add(this.radioChannelNumberCheckBox);
            this.oltPanel11.Location = new System.Drawing.Point(721, 79);
            this.oltPanel11.Name = "oltPanel11";
            this.oltPanel11.Size = new System.Drawing.Size(215, 25);
            this.oltPanel11.TabIndex = 27;
            // 
            // radioChannelNumberTextBox
            // 
            this.radioChannelNumberTextBox.Location = new System.Drawing.Point(105, 2);
            this.radioChannelNumberTextBox.MaxLength = 10;
            this.radioChannelNumberTextBox.Name = "radioChannelNumberTextBox";
            this.radioChannelNumberTextBox.OltAcceptsReturn = true;
            this.radioChannelNumberTextBox.OltTrimWhitespace = true;
            this.radioChannelNumberTextBox.ReadOnly = true;
            this.radioChannelNumberTextBox.Size = new System.Drawing.Size(90, 20);
            this.radioChannelNumberTextBox.TabIndex = 1;
            // 
            // radioChannelNumberCheckBox
            // 
            this.radioChannelNumberCheckBox.AutoSize = true;
            this.radioChannelNumberCheckBox.Location = new System.Drawing.Point(3, 3);
            this.radioChannelNumberCheckBox.Name = "radioChannelNumberCheckBox";
            this.radioChannelNumberCheckBox.Size = new System.Drawing.Size(106, 17);
            this.radioChannelNumberCheckBox.TabIndex = 0;
            this.radioChannelNumberCheckBox.Text = "Radio Channel #";
            this.radioChannelNumberCheckBox.UseVisualStyleBackColor = true;
            this.radioChannelNumberCheckBox.Value = null;
            // 
            // airMoverCheckBox
            // 
            this.airMoverCheckBox.AutoSize = true;
            this.airMoverCheckBox.Location = new System.Drawing.Point(724, 36);
            this.airMoverCheckBox.Name = "airMoverCheckBox";
            this.airMoverCheckBox.Size = new System.Drawing.Size(72, 17);
            this.airMoverCheckBox.TabIndex = 25;
            this.airMoverCheckBox.Text = "Air Mover";
            this.airMoverCheckBox.UseVisualStyleBackColor = true;
            this.airMoverCheckBox.Value = null;
            // 
            // barriersSignsCheckBox
            // 
            this.barriersSignsCheckBox.AutoSize = true;
            this.barriersSignsCheckBox.Location = new System.Drawing.Point(724, 59);
            this.barriersSignsCheckBox.Name = "barriersSignsCheckBox";
            this.barriersSignsCheckBox.Size = new System.Drawing.Size(92, 17);
            this.barriersSignsCheckBox.TabIndex = 26;
            this.barriersSignsCheckBox.Text = "Barriers/Signs";
            this.barriersSignsCheckBox.UseVisualStyleBackColor = true;
            this.barriersSignsCheckBox.Value = null;
            // 
            // airHornCheckBox
            // 
            this.airHornCheckBox.AutoSize = true;
            this.airHornCheckBox.Location = new System.Drawing.Point(724, 105);
            this.airHornCheckBox.Name = "airHornCheckBox";
            this.airHornCheckBox.Size = new System.Drawing.Size(65, 17);
            this.airHornCheckBox.TabIndex = 28;
            this.airHornCheckBox.Text = "Air Horn";
            this.airHornCheckBox.UseVisualStyleBackColor = true;
            this.airHornCheckBox.Value = null;
            // 
            // mechVentilationComfortOnlyCheckBox
            // 
            this.mechVentilationComfortOnlyCheckBox.AutoSize = true;
            this.mechVentilationComfortOnlyCheckBox.Location = new System.Drawing.Point(724, 128);
            this.mechVentilationComfortOnlyCheckBox.Name = "mechVentilationComfortOnlyCheckBox";
            this.mechVentilationComfortOnlyCheckBox.Size = new System.Drawing.Size(178, 17);
            this.mechVentilationComfortOnlyCheckBox.TabIndex = 29;
            this.mechVentilationComfortOnlyCheckBox.Text = "Mech Ventilation - Comfort Only";
            this.mechVentilationComfortOnlyCheckBox.UseVisualStyleBackColor = true;
            this.mechVentilationComfortOnlyCheckBox.Value = null;
            // 
            // asbestosMmfPrecautionsCheckBox
            // 
            this.asbestosMmfPrecautionsCheckBox.AutoSize = true;
            this.asbestosMmfPrecautionsCheckBox.Location = new System.Drawing.Point(724, 151);
            this.asbestosMmfPrecautionsCheckBox.Name = "asbestosMmfPrecautionsCheckBox";
            this.asbestosMmfPrecautionsCheckBox.Size = new System.Drawing.Size(155, 17);
            this.asbestosMmfPrecautionsCheckBox.TabIndex = 30;
            this.asbestosMmfPrecautionsCheckBox.Text = "Asbestos/MMF Precautions";
            this.asbestosMmfPrecautionsCheckBox.UseVisualStyleBackColor = true;
            this.asbestosMmfPrecautionsCheckBox.Value = null;
            // 
            // airPurifyingRespiratorCheckBox
            // 
            this.airPurifyingRespiratorCheckBox.AutoSize = true;
            this.airPurifyingRespiratorCheckBox.Location = new System.Drawing.Point(462, 36);
            this.airPurifyingRespiratorCheckBox.Name = "airPurifyingRespiratorCheckBox";
            this.airPurifyingRespiratorCheckBox.Size = new System.Drawing.Size(137, 17);
            this.airPurifyingRespiratorCheckBox.TabIndex = 16;
            this.airPurifyingRespiratorCheckBox.Text = "Air Purifying Respirator";
            this.airPurifyingRespiratorCheckBox.UseVisualStyleBackColor = true;
            this.airPurifyingRespiratorCheckBox.Value = null;
            // 
            // breathingAirApparatusCheckBox
            // 
            this.breathingAirApparatusCheckBox.AutoSize = true;
            this.breathingAirApparatusCheckBox.Location = new System.Drawing.Point(462, 59);
            this.breathingAirApparatusCheckBox.Name = "breathingAirApparatusCheckBox";
            this.breathingAirApparatusCheckBox.Size = new System.Drawing.Size(141, 17);
            this.breathingAirApparatusCheckBox.TabIndex = 17;
            this.breathingAirApparatusCheckBox.Text = "Breathing Air Apparatus";
            this.breathingAirApparatusCheckBox.UseVisualStyleBackColor = true;
            this.breathingAirApparatusCheckBox.Value = null;
            // 
            // dustMaskCheckBox
            // 
            this.dustMaskCheckBox.AutoSize = true;
            this.dustMaskCheckBox.Location = new System.Drawing.Point(462, 82);
            this.dustMaskCheckBox.Name = "dustMaskCheckBox";
            this.dustMaskCheckBox.Size = new System.Drawing.Size(75, 17);
            this.dustMaskCheckBox.TabIndex = 18;
            this.dustMaskCheckBox.Text = "Dust Mask";
            this.dustMaskCheckBox.UseVisualStyleBackColor = true;
            this.dustMaskCheckBox.Value = null;
            // 
            // lifeSupportSystemCheckBox
            // 
            this.lifeSupportSystemCheckBox.AutoSize = true;
            this.lifeSupportSystemCheckBox.Location = new System.Drawing.Point(462, 105);
            this.lifeSupportSystemCheckBox.Name = "lifeSupportSystemCheckBox";
            this.lifeSupportSystemCheckBox.Size = new System.Drawing.Size(122, 17);
            this.lifeSupportSystemCheckBox.TabIndex = 19;
            this.lifeSupportSystemCheckBox.Text = "Life Support System";
            this.lifeSupportSystemCheckBox.UseVisualStyleBackColor = true;
            this.lifeSupportSystemCheckBox.Value = null;
            // 
            // safetyWatchCheckBox
            // 
            this.safetyWatchCheckBox.AutoSize = true;
            this.safetyWatchCheckBox.Location = new System.Drawing.Point(462, 128);
            this.safetyWatchCheckBox.Name = "safetyWatchCheckBox";
            this.safetyWatchCheckBox.Size = new System.Drawing.Size(92, 17);
            this.safetyWatchCheckBox.TabIndex = 20;
            this.safetyWatchCheckBox.Text = "Safety Watch";
            this.safetyWatchCheckBox.UseVisualStyleBackColor = true;
            this.safetyWatchCheckBox.Value = null;
            // 
            // continuousGasMonitorCheckBox
            // 
            this.continuousGasMonitorCheckBox.AutoSize = true;
            this.continuousGasMonitorCheckBox.Location = new System.Drawing.Point(462, 151);
            this.continuousGasMonitorCheckBox.Name = "continuousGasMonitorCheckBox";
            this.continuousGasMonitorCheckBox.Size = new System.Drawing.Size(140, 17);
            this.continuousGasMonitorCheckBox.TabIndex = 21;
            this.continuousGasMonitorCheckBox.Text = "Continuous Gas Monitor";
            this.continuousGasMonitorCheckBox.UseVisualStyleBackColor = true;
            this.continuousGasMonitorCheckBox.Value = null;
            // 
            // bumpTestMonitorPriorToUseCheckBox
            // 
            this.bumpTestMonitorPriorToUseCheckBox.AutoSize = true;
            this.bumpTestMonitorPriorToUseCheckBox.Location = new System.Drawing.Point(462, 197);
            this.bumpTestMonitorPriorToUseCheckBox.Name = "bumpTestMonitorPriorToUseCheckBox";
            this.bumpTestMonitorPriorToUseCheckBox.Size = new System.Drawing.Size(174, 17);
            this.bumpTestMonitorPriorToUseCheckBox.TabIndex = 23;
            this.bumpTestMonitorPriorToUseCheckBox.Text = "Bump Test Monitor Prior to Use";
            this.bumpTestMonitorPriorToUseCheckBox.UseVisualStyleBackColor = true;
            this.bumpTestMonitorPriorToUseCheckBox.Value = null;
            // 
            // equipmentGroundedCheckBox
            // 
            this.equipmentGroundedCheckBox.AutoSize = true;
            this.equipmentGroundedCheckBox.Location = new System.Drawing.Point(233, 36);
            this.equipmentGroundedCheckBox.Name = "equipmentGroundedCheckBox";
            this.equipmentGroundedCheckBox.Size = new System.Drawing.Size(126, 17);
            this.equipmentGroundedCheckBox.TabIndex = 8;
            this.equipmentGroundedCheckBox.Text = "Equipment Grounded";
            this.equipmentGroundedCheckBox.UseVisualStyleBackColor = true;
            this.equipmentGroundedCheckBox.Value = null;
            // 
            // fireBlanketCheckBox
            // 
            this.fireBlanketCheckBox.AutoSize = true;
            this.fireBlanketCheckBox.Location = new System.Drawing.Point(233, 59);
            this.fireBlanketCheckBox.Name = "fireBlanketCheckBox";
            this.fireBlanketCheckBox.Size = new System.Drawing.Size(82, 17);
            this.fireBlanketCheckBox.TabIndex = 9;
            this.fireBlanketCheckBox.Text = "Fire Blanket";
            this.fireBlanketCheckBox.UseVisualStyleBackColor = true;
            this.fireBlanketCheckBox.Value = null;
            // 
            // fireExtinguisherCheckBox
            // 
            this.fireExtinguisherCheckBox.AutoSize = true;
            this.fireExtinguisherCheckBox.Location = new System.Drawing.Point(233, 82);
            this.fireExtinguisherCheckBox.Name = "fireExtinguisherCheckBox";
            this.fireExtinguisherCheckBox.Size = new System.Drawing.Size(106, 17);
            this.fireExtinguisherCheckBox.TabIndex = 10;
            this.fireExtinguisherCheckBox.Text = "Fire Extinguisher";
            this.fireExtinguisherCheckBox.UseVisualStyleBackColor = true;
            this.fireExtinguisherCheckBox.Value = null;
            // 
            // fireMonitorMannedCheckBox
            // 
            this.fireMonitorMannedCheckBox.AutoSize = true;
            this.fireMonitorMannedCheckBox.Location = new System.Drawing.Point(233, 105);
            this.fireMonitorMannedCheckBox.Name = "fireMonitorMannedCheckBox";
            this.fireMonitorMannedCheckBox.Size = new System.Drawing.Size(124, 17);
            this.fireMonitorMannedCheckBox.TabIndex = 11;
            this.fireMonitorMannedCheckBox.Text = "Fire Monitor Manned";
            this.fireMonitorMannedCheckBox.UseVisualStyleBackColor = true;
            this.fireMonitorMannedCheckBox.Value = null;
            // 
            // fireWatchCheckBox
            // 
            this.fireWatchCheckBox.AutoSize = true;
            this.fireWatchCheckBox.Location = new System.Drawing.Point(233, 128);
            this.fireWatchCheckBox.Name = "fireWatchCheckBox";
            this.fireWatchCheckBox.Size = new System.Drawing.Size(78, 17);
            this.fireWatchCheckBox.TabIndex = 12;
            this.fireWatchCheckBox.Text = "Fire Watch";
            this.fireWatchCheckBox.UseVisualStyleBackColor = true;
            this.fireWatchCheckBox.Value = null;
            // 
            // sewersDrainsCoveredCheckBox
            // 
            this.sewersDrainsCoveredCheckBox.AutoSize = true;
            this.sewersDrainsCoveredCheckBox.Location = new System.Drawing.Point(233, 151);
            this.sewersDrainsCoveredCheckBox.Name = "sewersDrainsCoveredCheckBox";
            this.sewersDrainsCoveredCheckBox.Size = new System.Drawing.Size(139, 17);
            this.sewersDrainsCoveredCheckBox.TabIndex = 13;
            this.sewersDrainsCoveredCheckBox.Text = "Sewers/Drains Covered";
            this.sewersDrainsCoveredCheckBox.UseVisualStyleBackColor = true;
            this.sewersDrainsCoveredCheckBox.Value = null;
            // 
            // steamHoseCheckBox
            // 
            this.steamHoseCheckBox.AutoSize = true;
            this.steamHoseCheckBox.Location = new System.Drawing.Point(233, 174);
            this.steamHoseCheckBox.Name = "steamHoseCheckBox";
            this.steamHoseCheckBox.Size = new System.Drawing.Size(83, 17);
            this.steamHoseCheckBox.TabIndex = 14;
            this.steamHoseCheckBox.Text = "Steam Hose";
            this.steamHoseCheckBox.UseVisualStyleBackColor = true;
            this.steamHoseCheckBox.Value = null;
            // 
            // highVoltagePPECheckBox
            // 
            this.highVoltagePPECheckBox.AutoSize = true;
            this.highVoltagePPECheckBox.Location = new System.Drawing.Point(8, 174);
            this.highVoltagePPECheckBox.Name = "highVoltagePPECheckBox";
            this.highVoltagePPECheckBox.Size = new System.Drawing.Size(107, 17);
            this.highVoltagePPECheckBox.TabIndex = 6;
            this.highVoltagePPECheckBox.Text = "High Voltage PPE";
            this.highVoltagePPECheckBox.UseVisualStyleBackColor = true;
            this.highVoltagePPECheckBox.Value = null;
            // 
            // safetyHarnessLifelineCheckBox
            // 
            this.safetyHarnessLifelineCheckBox.AutoSize = true;
            this.safetyHarnessLifelineCheckBox.Location = new System.Drawing.Point(8, 151);
            this.safetyHarnessLifelineCheckBox.Name = "safetyHarnessLifelineCheckBox";
            this.safetyHarnessLifelineCheckBox.Size = new System.Drawing.Size(137, 17);
            this.safetyHarnessLifelineCheckBox.TabIndex = 5;
            this.safetyHarnessLifelineCheckBox.Text = "Safety Harness/Lifeline";
            this.safetyHarnessLifelineCheckBox.UseVisualStyleBackColor = true;
            this.safetyHarnessLifelineCheckBox.Value = null;
            // 
            // rubberSuitCheckBox
            // 
            this.rubberSuitCheckBox.AutoSize = true;
            this.rubberSuitCheckBox.Location = new System.Drawing.Point(8, 128);
            this.rubberSuitCheckBox.Name = "rubberSuitCheckBox";
            this.rubberSuitCheckBox.Size = new System.Drawing.Size(82, 17);
            this.rubberSuitCheckBox.TabIndex = 4;
            this.rubberSuitCheckBox.Text = "Rubber Suit";
            this.rubberSuitCheckBox.UseVisualStyleBackColor = true;
            this.rubberSuitCheckBox.Value = null;
            // 
            // rubberGlovesCheckBox
            // 
            this.rubberGlovesCheckBox.AutoSize = true;
            this.rubberGlovesCheckBox.Location = new System.Drawing.Point(8, 105);
            this.rubberGlovesCheckBox.Name = "rubberGlovesCheckBox";
            this.rubberGlovesCheckBox.Size = new System.Drawing.Size(96, 17);
            this.rubberGlovesCheckBox.TabIndex = 3;
            this.rubberGlovesCheckBox.Text = "Rubber Gloves";
            this.rubberGlovesCheckBox.UseVisualStyleBackColor = true;
            this.rubberGlovesCheckBox.Value = null;
            // 
            // rubberBootsCheckBox
            // 
            this.rubberBootsCheckBox.AutoSize = true;
            this.rubberBootsCheckBox.Location = new System.Drawing.Point(8, 82);
            this.rubberBootsCheckBox.Name = "rubberBootsCheckBox";
            this.rubberBootsCheckBox.Size = new System.Drawing.Size(91, 17);
            this.rubberBootsCheckBox.TabIndex = 2;
            this.rubberBootsCheckBox.Text = "Rubber Boots";
            this.rubberBootsCheckBox.UseVisualStyleBackColor = true;
            this.rubberBootsCheckBox.Value = null;
            // 
            // gogglesCheckBox
            // 
            this.gogglesCheckBox.AutoSize = true;
            this.gogglesCheckBox.Location = new System.Drawing.Point(8, 59);
            this.gogglesCheckBox.Name = "gogglesCheckBox";
            this.gogglesCheckBox.Size = new System.Drawing.Size(64, 17);
            this.gogglesCheckBox.TabIndex = 1;
            this.gogglesCheckBox.Text = "Goggles";
            this.gogglesCheckBox.UseVisualStyleBackColor = true;
            this.gogglesCheckBox.Value = null;
            // 
            // faceShieldCheckBox
            // 
            this.faceShieldCheckBox.AutoSize = true;
            this.faceShieldCheckBox.Location = new System.Drawing.Point(8, 36);
            this.faceShieldCheckBox.Name = "faceShieldCheckBox";
            this.faceShieldCheckBox.Size = new System.Drawing.Size(80, 17);
            this.faceShieldCheckBox.TabIndex = 0;
            this.faceShieldCheckBox.Text = "Face Shield";
            this.faceShieldCheckBox.UseVisualStyleBackColor = true;
            this.faceShieldCheckBox.Value = null;
            // 
            // workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox
            // 
            this.workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.AutoSize = true;
            this.workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Location = new System.Drawing.Point(774, 884);
            this.workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Name = "workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox";
            this.workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Size = new System.Drawing.Size(167, 17);
            this.workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.TabIndex = 17;
            this.workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Text = "Section Not Applicable To Job";
            this.workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.UseVisualStyleBackColor = true;
            this.workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Value = null;
            // 
            // oltLabelLine6
            // 
            this.oltLabelLine6.Label = "Workers Minimum Safety Requirements";
            this.oltLabelLine6.Location = new System.Drawing.Point(9, 885);
            this.oltLabelLine6.Name = "oltLabelLine6";
            this.oltLabelLine6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.oltLabelLine6.Size = new System.Drawing.Size(759, 16);
            this.oltLabelLine6.TabIndex = 16;
            this.oltLabelLine6.TabStop = false;
            // 
            // oltGroupBox6
            // 
            this.oltGroupBox6.Controls.Add(this.areaComboBox);
            this.oltGroupBox6.Controls.Add(this.oltPanel2);
            this.oltGroupBox6.Controls.Add(this.oltLabel11);
            this.oltGroupBox6.Controls.Add(this.oltLabel13);
            this.oltGroupBox6.Controls.Add(this.personNotifiedTextBox);
            this.oltGroupBox6.Location = new System.Drawing.Point(9, 827);
            this.oltGroupBox6.Name = "oltGroupBox6";
            this.oltGroupBox6.Size = new System.Drawing.Size(937, 52);
            this.oltGroupBox6.TabIndex = 15;
            this.oltGroupBox6.TabStop = false;
            this.oltGroupBox6.Text = "Other Areas and/or Units Affected";
            // 
            // areaComboBox
            // 
            this.areaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.areaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.areaComboBox.FormattingEnabled = true;
            this.areaComboBox.Location = new System.Drawing.Point(148, 22);
            this.areaComboBox.MaxLength = 50;
            this.areaComboBox.Name = "areaComboBox";
            this.areaComboBox.Size = new System.Drawing.Size(406, 21);
            this.areaComboBox.TabIndex = 2;
            // 
            // oltPanel2
            // 
            this.oltPanel2.Controls.Add(this.otherAreasAffectedNoRadioButton);
            this.oltPanel2.Controls.Add(this.otherAreasAffectedYesRadioButton);
            this.oltPanel2.Location = new System.Drawing.Point(9, 20);
            this.oltPanel2.Name = "oltPanel2";
            this.oltPanel2.Size = new System.Drawing.Size(98, 23);
            this.oltPanel2.TabIndex = 0;
            // 
            // otherAreasAffectedNoRadioButton
            // 
            this.otherAreasAffectedNoRadioButton.AutoSize = true;
            this.otherAreasAffectedNoRadioButton.Location = new System.Drawing.Point(51, 3);
            this.otherAreasAffectedNoRadioButton.Name = "otherAreasAffectedNoRadioButton";
            this.otherAreasAffectedNoRadioButton.Size = new System.Drawing.Size(38, 17);
            this.otherAreasAffectedNoRadioButton.TabIndex = 1;
            this.otherAreasAffectedNoRadioButton.TabStop = true;
            this.otherAreasAffectedNoRadioButton.Text = "No";
            this.otherAreasAffectedNoRadioButton.UseVisualStyleBackColor = true;
            // 
            // otherAreasAffectedYesRadioButton
            // 
            this.otherAreasAffectedYesRadioButton.AutoSize = true;
            this.otherAreasAffectedYesRadioButton.Location = new System.Drawing.Point(3, 3);
            this.otherAreasAffectedYesRadioButton.Name = "otherAreasAffectedYesRadioButton";
            this.otherAreasAffectedYesRadioButton.Size = new System.Drawing.Size(42, 17);
            this.otherAreasAffectedYesRadioButton.TabIndex = 0;
            this.otherAreasAffectedYesRadioButton.TabStop = true;
            this.otherAreasAffectedYesRadioButton.Text = "Yes";
            this.otherAreasAffectedYesRadioButton.UseVisualStyleBackColor = true;
            // 
            // oltLabel11
            // 
            this.oltLabel11.AutoSize = true;
            this.oltLabel11.Location = new System.Drawing.Point(111, 25);
            this.oltLabel11.Name = "oltLabel11";
            this.oltLabel11.Size = new System.Drawing.Size(34, 13);
            this.oltLabel11.TabIndex = 1;
            this.oltLabel11.Text = "Area:";
            // 
            // oltLabel13
            // 
            this.oltLabel13.AutoSize = true;
            this.oltLabel13.Location = new System.Drawing.Point(577, 25);
            this.oltLabel13.Name = "oltLabel13";
            this.oltLabel13.Size = new System.Drawing.Size(84, 13);
            this.oltLabel13.TabIndex = 3;
            this.oltLabel13.Text = "Person Notified:";
            // 
            // personNotifiedTextBox
            // 
            this.personNotifiedTextBox.Location = new System.Drawing.Point(664, 22);
            this.personNotifiedTextBox.MaxLength = 30;
            this.personNotifiedTextBox.Name = "personNotifiedTextBox";
            this.personNotifiedTextBox.OltAcceptsReturn = true;
            this.personNotifiedTextBox.OltTrimWhitespace = true;
            this.personNotifiedTextBox.Size = new System.Drawing.Size(255, 20);
            this.personNotifiedTextBox.TabIndex = 4;
            // 
            // oltGroupBox5
            // 
            this.oltGroupBox5.Controls.Add(this.subOperationNumberTextBox);
            this.oltGroupBox5.Location = new System.Drawing.Point(824, 345);
            this.oltGroupBox5.Name = "oltGroupBox5";
            this.oltGroupBox5.Size = new System.Drawing.Size(128, 45);
            this.oltGroupBox5.TabIndex = 12;
            this.oltGroupBox5.TabStop = false;
            this.oltGroupBox5.Text = "Sub Operation #";
            // 
            // subOperationNumberTextBox
            // 
            this.subOperationNumberTextBox.Location = new System.Drawing.Point(7, 15);
            this.subOperationNumberTextBox.MaxLength = 4;
            this.subOperationNumberTextBox.Name = "subOperationNumberTextBox";
            this.subOperationNumberTextBox.OltAcceptsReturn = true;
            this.subOperationNumberTextBox.OltTrimWhitespace = true;
            this.subOperationNumberTextBox.Size = new System.Drawing.Size(99, 20);
            this.subOperationNumberTextBox.TabIndex = 2;
            // 
            // oltGroupBox4
            // 
            this.oltGroupBox4.Controls.Add(this.operationNumberTextBox);
            this.oltGroupBox4.Location = new System.Drawing.Point(824, 290);
            this.oltGroupBox4.Name = "oltGroupBox4";
            this.oltGroupBox4.Size = new System.Drawing.Size(128, 45);
            this.oltGroupBox4.TabIndex = 11;
            this.oltGroupBox4.TabStop = false;
            this.oltGroupBox4.Text = "Operation #";
            // 
            // operationNumberTextBox
            // 
            this.operationNumberTextBox.Location = new System.Drawing.Point(7, 15);
            this.operationNumberTextBox.MaxLength = 4;
            this.operationNumberTextBox.Name = "operationNumberTextBox";
            this.operationNumberTextBox.OltAcceptsReturn = true;
            this.operationNumberTextBox.OltTrimWhitespace = true;
            this.operationNumberTextBox.Size = new System.Drawing.Size(99, 20);
            this.operationNumberTextBox.TabIndex = 1;
            // 
            // oltGroupBox3
            // 
            this.oltGroupBox3.Controls.Add(this.requestedEndDatePicker);
            this.oltGroupBox3.Location = new System.Drawing.Point(655, 345);
            this.oltGroupBox3.Name = "oltGroupBox3";
            this.oltGroupBox3.Size = new System.Drawing.Size(163, 52);
            this.oltGroupBox3.TabIndex = 9;
            this.oltGroupBox3.TabStop = false;
            this.oltGroupBox3.Text = "Requested End";
            // 
            // requestedEndDatePicker
            // 
            this.requestedEndDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.requestedEndDatePicker.Location = new System.Drawing.Point(7, 20);
            this.requestedEndDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.requestedEndDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.requestedEndDatePicker.Name = "requestedEndDatePicker";
            this.requestedEndDatePicker.PickerEnabled = true;
            this.requestedEndDatePicker.Size = new System.Drawing.Size(128, 21);
            this.requestedEndDatePicker.TabIndex = 0;
            // 
            // oltGroupBox1
            // 
            this.oltGroupBox1.Controls.Add(this.workOrderNumberTextBox);
            this.oltGroupBox1.Location = new System.Drawing.Point(824, 239);
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.Size = new System.Drawing.Size(128, 45);
            this.oltGroupBox1.TabIndex = 10;
            this.oltGroupBox1.TabStop = false;
            this.oltGroupBox1.Text = "Work Order #";
            // 
            // workOrderNumberTextBox
            // 
            this.workOrderNumberTextBox.Location = new System.Drawing.Point(7, 15);
            this.workOrderNumberTextBox.MaxLength = 12;
            this.workOrderNumberTextBox.Name = "workOrderNumberTextBox";
            this.workOrderNumberTextBox.OltAcceptsReturn = true;
            this.workOrderNumberTextBox.OltTrimWhitespace = true;
            this.workOrderNumberTextBox.Size = new System.Drawing.Size(99, 20);
            this.workOrderNumberTextBox.TabIndex = 0;
            // 
            // requestedStartGroupBox
            // 
            this.requestedStartGroupBox.Controls.Add(this.requestedStartNightCheckBox);
            this.requestedStartGroupBox.Controls.Add(this.requestedStartTimeNightPicker);
            this.requestedStartGroupBox.Controls.Add(this.requestedStartDayCheckBox);
            this.requestedStartGroupBox.Controls.Add(this.requestedStartTimeDayPicker);
            this.requestedStartGroupBox.Controls.Add(this.requestedStartDatePicker);
            this.requestedStartGroupBox.Location = new System.Drawing.Point(655, 239);
            this.requestedStartGroupBox.Name = "requestedStartGroupBox";
            this.requestedStartGroupBox.Size = new System.Drawing.Size(163, 104);
            this.requestedStartGroupBox.TabIndex = 8;
            this.requestedStartGroupBox.TabStop = false;
            this.requestedStartGroupBox.Text = "Requested Start";
            // 
            // requestedStartNightCheckBox
            // 
            this.requestedStartNightCheckBox.AutoSize = true;
            this.requestedStartNightCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.requestedStartNightCheckBox.Location = new System.Drawing.Point(7, 67);
            this.requestedStartNightCheckBox.Name = "requestedStartNightCheckBox";
            this.requestedStartNightCheckBox.Size = new System.Drawing.Size(51, 17);
            this.requestedStartNightCheckBox.TabIndex = 3;
            this.requestedStartNightCheckBox.Text = "Night";
            this.requestedStartNightCheckBox.UseVisualStyleBackColor = true;
            this.requestedStartNightCheckBox.Value = null;
            // 
            // requestedStartTimeNightPicker
            // 
            this.requestedStartTimeNightPicker.Checked = true;
            this.requestedStartTimeNightPicker.CustomFormat = "HH:mm";
            this.requestedStartTimeNightPicker.Location = new System.Drawing.Point(75, 65);
            this.requestedStartTimeNightPicker.Margin = new System.Windows.Forms.Padding(0);
            this.requestedStartTimeNightPicker.Name = "requestedStartTimeNightPicker";
            this.requestedStartTimeNightPicker.ShowCheckBox = false;
            this.requestedStartTimeNightPicker.Size = new System.Drawing.Size(60, 21);
            this.requestedStartTimeNightPicker.TabIndex = 4;
            // 
            // requestedStartDayCheckBox
            // 
            this.requestedStartDayCheckBox.AutoSize = true;
            this.requestedStartDayCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.requestedStartDayCheckBox.Location = new System.Drawing.Point(7, 44);
            this.requestedStartDayCheckBox.Name = "requestedStartDayCheckBox";
            this.requestedStartDayCheckBox.Size = new System.Drawing.Size(45, 17);
            this.requestedStartDayCheckBox.TabIndex = 1;
            this.requestedStartDayCheckBox.Text = "Day";
            this.requestedStartDayCheckBox.UseVisualStyleBackColor = true;
            this.requestedStartDayCheckBox.Value = null;
            // 
            // requestedStartTimeDayPicker
            // 
            this.requestedStartTimeDayPicker.Checked = true;
            this.requestedStartTimeDayPicker.CustomFormat = "HH:mm";
            this.requestedStartTimeDayPicker.Location = new System.Drawing.Point(75, 42);
            this.requestedStartTimeDayPicker.Margin = new System.Windows.Forms.Padding(0);
            this.requestedStartTimeDayPicker.Name = "requestedStartTimeDayPicker";
            this.requestedStartTimeDayPicker.ShowCheckBox = false;
            this.requestedStartTimeDayPicker.Size = new System.Drawing.Size(60, 21);
            this.requestedStartTimeDayPicker.TabIndex = 2;
            // 
            // requestedStartDatePicker
            // 
            this.requestedStartDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.requestedStartDatePicker.Location = new System.Drawing.Point(7, 19);
            this.requestedStartDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.requestedStartDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.requestedStartDatePicker.Name = "requestedStartDatePicker";
            this.requestedStartDatePicker.PickerEnabled = true;
            this.requestedStartDatePicker.Size = new System.Drawing.Size(129, 21);
            this.requestedStartDatePicker.TabIndex = 0;
            // 
            // functionalLocationGroupBox
            // 
            this.functionalLocationGroupBox.Controls.Add(this.areaLabelComboBox);
            this.functionalLocationGroupBox.Controls.Add(this.oltLabel9);
            this.functionalLocationGroupBox.Controls.Add(this.oltLabel15);
            this.functionalLocationGroupBox.Controls.Add(this.locationTextBox);
            this.functionalLocationGroupBox.Controls.Add(this.functionalLocationTextBox);
            this.functionalLocationGroupBox.Controls.Add(this.functionalLocationBrowseButton);
            this.functionalLocationGroupBox.Location = new System.Drawing.Point(181, 102);
            this.functionalLocationGroupBox.Name = "functionalLocationGroupBox";
            this.functionalLocationGroupBox.Size = new System.Drawing.Size(468, 103);
            this.functionalLocationGroupBox.TabIndex = 4;
            this.functionalLocationGroupBox.TabStop = false;
            this.functionalLocationGroupBox.Text = "Functional Location";
            // 
            // areaLabelComboBox
            // 
            this.areaLabelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaLabelComboBox.FormattingEnabled = true;
            this.areaLabelComboBox.Location = new System.Drawing.Point(78, 75);
            this.areaLabelComboBox.Name = "areaLabelComboBox";
            this.areaLabelComboBox.Size = new System.Drawing.Size(363, 21);
            this.areaLabelComboBox.TabIndex = 5;
            // 
            // oltLabel9
            // 
            this.oltLabel9.AutoSize = true;
            this.oltLabel9.Location = new System.Drawing.Point(6, 78);
            this.oltLabel9.Name = "oltLabel9";
            this.oltLabel9.Size = new System.Drawing.Size(71, 13);
            this.oltLabel9.TabIndex = 4;
            this.oltLabel9.Text = "Issuing Area:";
            // 
            // oltLabel15
            // 
            this.oltLabel15.AutoSize = true;
            this.oltLabel15.Location = new System.Drawing.Point(6, 45);
            this.oltLabel15.Name = "oltLabel15";
            this.oltLabel15.Size = new System.Drawing.Size(51, 13);
            this.oltLabel15.TabIndex = 2;
            this.oltLabel15.Text = "Location:";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(78, 42);
            this.locationTextBox.MaxLength = 35;
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.OltAcceptsReturn = true;
            this.locationTextBox.OltTrimWhitespace = true;
            this.locationTextBox.Size = new System.Drawing.Size(363, 20);
            this.locationTextBox.TabIndex = 3;
            // 
            // functionalLocationTextBox
            // 
            this.functionalLocationTextBox.Location = new System.Drawing.Point(6, 15);
            this.functionalLocationTextBox.Name = "functionalLocationTextBox";
            this.functionalLocationTextBox.OltAcceptsReturn = true;
            this.functionalLocationTextBox.OltTrimWhitespace = true;
            this.functionalLocationTextBox.ReadOnly = true;
            this.functionalLocationTextBox.Size = new System.Drawing.Size(352, 20);
            this.functionalLocationTextBox.TabIndex = 0;
            this.functionalLocationTextBox.TabStop = false;
            // 
            // functionalLocationBrowseButton
            // 
            this.functionalLocationBrowseButton.Location = new System.Drawing.Point(362, 13);
            this.functionalLocationBrowseButton.Name = "functionalLocationBrowseButton";
            this.functionalLocationBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.functionalLocationBrowseButton.TabIndex = 1;
            this.functionalLocationBrowseButton.Text = "Browse...";
            this.functionalLocationBrowseButton.UseVisualStyleBackColor = true;
            // 
            // permitTypeGroupBox
            // 
            this.permitTypeGroupBox.Controls.Add(this.permitTypeComboBox);
            this.permitTypeGroupBox.Location = new System.Drawing.Point(9, 102);
            this.permitTypeGroupBox.Name = "permitTypeGroupBox";
            this.permitTypeGroupBox.Size = new System.Drawing.Size(166, 40);
            this.permitTypeGroupBox.TabIndex = 2;
            this.permitTypeGroupBox.TabStop = false;
            this.permitTypeGroupBox.Text = "Permit Type";
            // 
            // permitTypeComboBox
            // 
            this.permitTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.permitTypeComboBox.FormattingEnabled = true;
            this.permitTypeComboBox.Location = new System.Drawing.Point(9, 14);
            this.permitTypeComboBox.Name = "permitTypeComboBox";
            this.permitTypeComboBox.Size = new System.Drawing.Size(133, 21);
            this.permitTypeComboBox.TabIndex = 0;
            // 
            // lastModifiedDateAuthorHeader
            // 
            this.lastModifiedDateAuthorHeader.LastModifiedDate = new System.DateTime(((long)(0)));
            this.lastModifiedDateAuthorHeader.Location = new System.Drawing.Point(9, 7);
            this.lastModifiedDateAuthorHeader.Name = "lastModifiedDateAuthorHeader";
            this.lastModifiedDateAuthorHeader.Size = new System.Drawing.Size(943, 34);
            this.lastModifiedDateAuthorHeader.TabIndex = 0;
            // 
            // issuedToGroupBox
            // 
            this.issuedToGroupBox.Controls.Add(this.groupComboBox);
            this.issuedToGroupBox.Controls.Add(this.oltLabel1);
            this.issuedToGroupBox.Controls.Add(this.numberOfWorkersTextBox);
            this.issuedToGroupBox.Controls.Add(this.occupationComboBox);
            this.issuedToGroupBox.Controls.Add(this.occupationLabel);
            this.issuedToGroupBox.Controls.Add(this.oltPanel1);
            this.issuedToGroupBox.Controls.Add(this.oltLabel4);
            this.issuedToGroupBox.Location = new System.Drawing.Point(9, 47);
            this.issuedToGroupBox.Name = "issuedToGroupBox";
            this.issuedToGroupBox.Size = new System.Drawing.Size(943, 49);
            this.issuedToGroupBox.TabIndex = 1;
            this.issuedToGroupBox.TabStop = false;
            this.issuedToGroupBox.Text = "Issued To";
            // 
            // groupComboBox
            // 
            this.groupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(840, 20);
            this.groupComboBox.MaxLength = 50;
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(80, 21);
            this.groupComboBox.TabIndex = 12;
            // 
            // oltLabel1
            // 
            this.oltLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel1.Location = new System.Drawing.Point(773, 17);
            this.oltLabel1.Name = "oltLabel1";
            this.oltLabel1.Size = new System.Drawing.Size(61, 28);
            this.oltLabel1.TabIndex = 11;
            this.oltLabel1.Text = "Requested By:";
            // 
            // numberOfWorkersTextBox
            // 
            this.numberOfWorkersTextBox.DecimalValue = null;
            this.numberOfWorkersTextBox.IntegerValue = null;
            this.numberOfWorkersTextBox.Location = new System.Drawing.Point(727, 20);
            this.numberOfWorkersTextBox.MaxLength = 3;
            this.numberOfWorkersTextBox.Name = "numberOfWorkersTextBox";
            this.numberOfWorkersTextBox.NumericValue = null;
            this.numberOfWorkersTextBox.Size = new System.Drawing.Size(33, 20);
            this.numberOfWorkersTextBox.TabIndex = 4;
            this.numberOfWorkersTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // occupationComboBox
            // 
            this.occupationComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.occupationComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.occupationComboBox.DropDownWidth = 250;
            this.occupationComboBox.FormattingEnabled = true;
            this.occupationComboBox.Location = new System.Drawing.Point(445, 20);
            this.occupationComboBox.MaxDropDownItems = 16;
            this.occupationComboBox.MaxLength = 35;
            this.occupationComboBox.Name = "occupationComboBox";
            this.occupationComboBox.Size = new System.Drawing.Size(190, 21);
            this.occupationComboBox.TabIndex = 3;
            // 
            // occupationLabel
            // 
            this.occupationLabel.AutoSize = true;
            this.occupationLabel.Location = new System.Drawing.Point(379, 24);
            this.occupationLabel.Name = "occupationLabel";
            this.occupationLabel.Size = new System.Drawing.Size(65, 13);
            this.occupationLabel.TabIndex = 2;
            this.occupationLabel.Text = "Occupation:";
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.issuedToSuncorCheckBox);
            this.oltPanel1.Controls.Add(this.issuedToContractorCheckBox);
            this.oltPanel1.Controls.Add(this.contractorComboBox);
            this.oltPanel1.Location = new System.Drawing.Point(6, 18);
            this.oltPanel1.Name = "oltPanel1";
            this.oltPanel1.Size = new System.Drawing.Size(370, 25);
            this.oltPanel1.TabIndex = 1;
            // 
            // issuedToSuncorCheckBox
            // 
            this.issuedToSuncorCheckBox.AutoSize = true;
            this.issuedToSuncorCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.issuedToSuncorCheckBox.Location = new System.Drawing.Point(3, 5);
            this.issuedToSuncorCheckBox.Name = "issuedToSuncorCheckBox";
            this.issuedToSuncorCheckBox.Size = new System.Drawing.Size(59, 17);
            this.issuedToSuncorCheckBox.TabIndex = 0;
            this.issuedToSuncorCheckBox.Text = "Suncor";
            this.issuedToSuncorCheckBox.UseVisualStyleBackColor = true;
            this.issuedToSuncorCheckBox.Value = null;
            // 
            // issuedToContractorCheckBox
            // 
            this.issuedToContractorCheckBox.AutoSize = true;
            this.issuedToContractorCheckBox.Location = new System.Drawing.Point(69, 5);
            this.issuedToContractorCheckBox.Name = "issuedToContractorCheckBox";
            this.issuedToContractorCheckBox.Size = new System.Drawing.Size(78, 17);
            this.issuedToContractorCheckBox.TabIndex = 1;
            this.issuedToContractorCheckBox.Text = "Contractor";
            this.issuedToContractorCheckBox.UseVisualStyleBackColor = true;
            this.issuedToContractorCheckBox.Value = null;
            // 
            // contractorComboBox
            // 
            this.contractorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.contractorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.contractorComboBox.DropDownWidth = 250;
            this.contractorComboBox.Enabled = false;
            this.contractorComboBox.FormattingEnabled = true;
            this.contractorComboBox.Location = new System.Drawing.Point(147, 3);
            this.contractorComboBox.MaxDropDownItems = 16;
            this.contractorComboBox.MaxLength = 35;
            this.contractorComboBox.Name = "contractorComboBox";
            this.contractorComboBox.Size = new System.Drawing.Size(200, 21);
            this.contractorComboBox.TabIndex = 2;
            // 
            // oltLabel4
            // 
            this.oltLabel4.AutoSize = true;
            this.oltLabel4.Location = new System.Drawing.Point(652, 24);
            this.oltLabel4.Name = "oltLabel4";
            this.oltLabel4.Size = new System.Drawing.Size(75, 13);
            this.oltLabel4.TabIndex = 10;
            this.oltLabel4.Text = "# of Workers:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // warningProvider
            // 
            this.warningProvider.ContainerControl = this;
            this.warningProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("warningProvider.Icon")));
            // 
            // PermitRequestEdmontonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 686);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.buttonPanel);
            this.MaximumSize = new System.Drawing.Size(1000, 1200);
            this.MinimumSize = new System.Drawing.Size(870, 38);
            this.Name = "PermitRequestEdmontonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Permit Request";
            this.buttonPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.priorityGroupBox.ResumeLayout(false);
            this.documentLinksGroupBox.ResumeLayout(false);
            this.oltGroupBox2.ResumeLayout(false);
            this.oltGroupBox2.PerformLayout();
            this.oltPanel20.ResumeLayout(false);
            this.oltPanel20.PerformLayout();
            this.oltPanel19.ResumeLayout(false);
            this.oltPanel19.PerformLayout();
            this.oltPanel18.ResumeLayout(false);
            this.oltPanel18.PerformLayout();
            this.oltPanel16.ResumeLayout(false);
            this.oltPanel16.PerformLayout();
            this.oltPanel9.ResumeLayout(false);
            this.oltPanel9.PerformLayout();
            this.oltPanel13.ResumeLayout(false);
            this.oltPanel13.PerformLayout();
            this.typeOfWorkGroupBox.ResumeLayout(false);
            this.typeOfWorkGroupBox.PerformLayout();
            this.oltPanel22.ResumeLayout(false);
            this.oltPanel22.PerformLayout();
            this.oltPanel8.ResumeLayout(false);
            this.oltPanel8.PerformLayout();
            this.oltPanel7.ResumeLayout(false);
            this.oltPanel7.PerformLayout();
            this.oltPanel6.ResumeLayout(false);
            this.oltPanel6.PerformLayout();
            this.oltPanel5.ResumeLayout(false);
            this.oltPanel5.PerformLayout();
            this.oltPanel4.ResumeLayout(false);
            this.oltPanel4.PerformLayout();
            this.oltPanel3.ResumeLayout(false);
            this.oltPanel3.PerformLayout();
            this.hazardsAndOrRequirementsGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.currentSAPDescriptionGroupBox.ResumeLayout(false);
            this.currentSAPDescriptionGroupBox.PerformLayout();
            this.taskDescriptionGroupBox.ResumeLayout(false);
            this.workersMinimumSafetyRequirementsGroupBox.ResumeLayout(false);
            this.workersMinimumSafetyRequirementsGroupBox.PerformLayout();
            this.oltPanel17.ResumeLayout(false);
            this.oltPanel17.PerformLayout();
            this.oltPanel15.ResumeLayout(false);
            this.oltPanel15.PerformLayout();
            this.oltPanel14.ResumeLayout(false);
            this.oltPanel14.PerformLayout();
            this.oltPanel12.ResumeLayout(false);
            this.oltPanel12.PerformLayout();
            this.oltPanel10.ResumeLayout(false);
            this.oltPanel10.PerformLayout();
            this.oltPanel11.ResumeLayout(false);
            this.oltPanel11.PerformLayout();
            this.oltGroupBox6.ResumeLayout(false);
            this.oltGroupBox6.PerformLayout();
            this.oltPanel2.ResumeLayout(false);
            this.oltPanel2.PerformLayout();
            this.oltGroupBox5.ResumeLayout(false);
            this.oltGroupBox5.PerformLayout();
            this.oltGroupBox4.ResumeLayout(false);
            this.oltGroupBox4.PerformLayout();
            this.oltGroupBox3.ResumeLayout(false);
            this.oltGroupBox1.ResumeLayout(false);
            this.oltGroupBox1.PerformLayout();
            this.requestedStartGroupBox.ResumeLayout(false);
            this.requestedStartGroupBox.PerformLayout();
            this.functionalLocationGroupBox.ResumeLayout(false);
            this.functionalLocationGroupBox.PerformLayout();
            this.permitTypeGroupBox.ResumeLayout(false);
            this.issuedToGroupBox.ResumeLayout(false);
            this.issuedToGroupBox.PerformLayout();
            this.oltPanel1.ResumeLayout(false);
            this.oltPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton cancelButton;
        private OltButton saveAndCloseButton;
        private System.Windows.Forms.Button viewEditHistoryButton;
        private ToolTip toolTip;
        private Button submitAndCloseButton;
        private OltPanel contentPanel;
        private OltPanel buttonPanel;
        private OltTextBox locationTextBox;
        private OltGroupBox functionalLocationGroupBox;
        private OltTextBox functionalLocationTextBox;
        private OltButton functionalLocationBrowseButton;
        private OltGroupBox permitTypeGroupBox;
        private OltComboBox permitTypeComboBox;
        private OltLastModifiedDateAuthorHeader lastModifiedDateAuthorHeader;
        private OltGroupBox issuedToGroupBox;
        private OltIntegerBox numberOfWorkersTextBox;
        private OltEditableComboBox occupationComboBox;
        private OltLabel occupationLabel;
        private OltPanel oltPanel1;
        private OltEditableComboBox contractorComboBox;
        private OltLabel oltLabel4;
        private OltGroupBox oltGroupBox5;
        private OltTextBox subOperationNumberTextBox;
        private OltGroupBox oltGroupBox4;
        private OltTextBox operationNumberTextBox;
        private OltGroupBox oltGroupBox3;
        private OltDatePicker requestedEndDatePicker;
        private OltGroupBox oltGroupBox1;
        private OltTextBox workOrderNumberTextBox;
        private OltGroupBox requestedStartGroupBox;
        private OltTimePicker requestedStartTimeDayPicker;
        private OltDatePicker requestedStartDatePicker;
        private OltTextBox sapDescriptionTextBox;
        private OltGroupBox oltGroupBox6;
        private OltPanel oltPanel2;
        private OltRadioButton otherAreasAffectedNoRadioButton;
        private OltRadioButton otherAreasAffectedYesRadioButton;
        private OltLabel oltLabel11;
        private OltLabel oltLabel13;
        private OltTextBox personNotifiedTextBox;
        private OltCheckBox workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox;
        private OltLabelLine oltLabelLine6;
        private OltGroupBox workersMinimumSafetyRequirementsGroupBox;
        private OltCheckBox airMoverCheckBox;
        private OltCheckBox barriersSignsCheckBox;
        private OltCheckBox airHornCheckBox;
        private OltCheckBox mechVentilationComfortOnlyCheckBox;
        private OltCheckBox asbestosMmfPrecautionsCheckBox;
        private OltCheckBox airPurifyingRespiratorCheckBox;
        private OltCheckBox breathingAirApparatusCheckBox;
        private OltCheckBox dustMaskCheckBox;
        private OltCheckBox lifeSupportSystemCheckBox;
        private OltCheckBox safetyWatchCheckBox;
        private OltCheckBox continuousGasMonitorCheckBox;
        private OltCheckBox bumpTestMonitorPriorToUseCheckBox;
        private OltCheckBox equipmentGroundedCheckBox;
        private OltCheckBox fireBlanketCheckBox;
        private OltCheckBox fireExtinguisherCheckBox;
        private OltCheckBox fireMonitorMannedCheckBox;
        private OltCheckBox fireWatchCheckBox;
        private OltCheckBox sewersDrainsCoveredCheckBox;
        private OltCheckBox steamHoseCheckBox;
        private OltCheckBox highVoltagePPECheckBox;
        private OltCheckBox safetyHarnessLifelineCheckBox;
        private OltCheckBox rubberSuitCheckBox;
        private OltCheckBox rubberGlovesCheckBox;
        private OltCheckBox rubberBootsCheckBox;
        private OltCheckBox gogglesCheckBox;
        private OltCheckBox faceShieldCheckBox;
        private ErrorProvider errorProvider;
        private OltCheckBox requestedStartNightCheckBox;
        private OltTimePicker requestedStartTimeNightPicker;
        private OltCheckBox requestedStartDayCheckBox;
        private OltCheckBox issuedToSuncorCheckBox;
        private OltCheckBox issuedToContractorCheckBox;
        private OltLabel oltLabel1;
        private ErrorProvider warningProvider;
        private OltGroupBox hazardsAndOrRequirementsGroupBox;
        private TableLayoutPanel tableLayoutPanel1;
        private OltGroupBox taskDescriptionGroupBox;
        private OltGroupBox currentSAPDescriptionGroupBox;
        private OltGroupBox typeOfWorkGroupBox;
        private OltPanel oltPanel8;
        private OltComboBox classOfClothingComboBox;
        private OltCheckBox alkylationEntryCheckBox;
        private OltLabel oltLabel2;
        private OltPanel oltPanel7;
        private OltComboBox flarePitEntryTypeComboBox;
        private OltCheckBox flarePitEntryCheckBox;
        private OltLabel oltLabel3;
        private OltPanel oltPanel6;
        private OltComboBox specialWorkTypeComboBox;
        private OltLabel oltLabel47;
        private OltCheckBox specialWorkCheckBox;
        private OltLabel oltLabel14;
        private OltTextBox specialWorkFormNumberTextBox;
        private OltPanel oltPanel5;
        private OltIntegerBox vehicleEntryTotalNumberTextBox;
        private OltLabel oltLabel46;
        private OltTextBox vehicleEntryTypeTextBox;
        private OltCheckBox vehicleEntryCheckBox;
        private OltLabel oltLabel8;
        private OltPanel oltPanel4;
        private OltTextBox rescuePlanFormNumberTextBox;
        private OltCheckBox rescuePlanCheckBox;
        private OltLabel oltLabel7;
        private OltPanel oltPanel3;
        private OltComboBox confinedSpaceClassComboBox;
        private OltLabel oltLabel21;
        private OltCheckBox confinedSpaceCheckBox;
        private OltLabel oltLabel5;
        private OltTextBox confinedSpaceCardNumberTextBox;
        private OltLabel oltLabel6;
        private OltGroupBox oltGroupBox2;
        private OltPanel oltPanel9;
        private OltCheckBox gn59CheckBox;
        private OltTextBox gn59FormNumberTextBox;
        private OltPanel oltPanel13;
        private OltCheckBox gn7CheckBox;
        private OltTextBox gn7FormNumberTextBox;
        private OltLabel gn27Label;
        private OltComboBox gn27ComboBox;
        private OltComboBox gn11ComboBox;
        private OltLabel gn11Label;
        private OltPanel oltPanel11;
        private OltTextBox radioChannelNumberTextBox;
        private OltCheckBox radioChannelNumberCheckBox;
        private OltPanel oltPanel10;
        private OltCheckBox workersMonitorNumberCheckBox;
        private OltTextBox workersMonitorNumberTextBox;
        private OltPanel oltPanel12;
        private OltTextBox other1TextBox;
        private OltCheckBox other1CheckBox;
        private OltPanel oltPanel14;
        private OltTextBox other2TextBox;
        private OltCheckBox other2CheckBox;
        private OltPanel oltPanel15;
        private OltTextBox other3TextBox;
        private OltCheckBox other3CheckBox;
        private OltPanel oltPanel17;
        private OltTextBox other4TextBox;
        private OltCheckBox other4CheckBox;
        private OltButton validateButton;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label8;
        private OltComboBox groupComboBox;
        private OltButton selectFormGN7Button;
        private OltButton selectFormGN59Button;
        private OltLabel oltLabel15;
        private OltGroupBox documentLinksGroupBox;
        private DocumentLinksControl documentLinksControl;
        private OltSpellCheckTextBox descriptionTextBox;
        private OltSpellCheckTextBox hazardsAndOrRequirementsTextBox;
        private OltGroupBox priorityGroupBox;
        private OltComboBox priorityComboBox;
        private OltEditableComboBox areaComboBox;
        private OltComboBox areaLabelComboBox;
        private OltLabel oltLabel9;
        private OltPanel oltPanel16;
        private OltButton selectFormGN24Button;
        private OltTextBox gn24FormNumberTextBox;
        private OltCheckBox gn24CheckBox;
        private OltPanel oltPanel18;
        private OltButton selectFormGN6Button;
        private OltCheckBox gn6CheckBox;
        private OltTextBox gn6FormNumberTextBox;
        private OltPanel oltPanel19;
        private OltButton selectFormGN75AButton;
        private OltTextBox gn75AFormNumberTextBox;
        private OltCheckBox gn75ACheckBox;
        private OltPanel oltPanel20;
        private OltButton selectFormGN1Button;
        private OltCheckBox gn1CheckBox;
        private OltTextBox gn1FormNumberTextBox;
        private OltPanel oltPanel22;
        private OltEditableComboBox roadAccessOnPermitComboBox;
        private OltLabel oltLabel16;
        private OltCheckBox roadAccessOnPermitCheckBox;
        private OltLabel oltLabel19;
        private OltTextBox roadAccessOnPermitFormNumberTextBox;
        private OltEditableComboBox specialWorkComboBox;
    }
}
