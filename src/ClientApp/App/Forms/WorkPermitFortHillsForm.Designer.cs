using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class WorkPermitFortHillsForm : BaseForm, IWorkPermitFortHillsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitFortHillsForm));
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.buttonsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.printPreferencesButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveAndIssueButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.validateButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.warningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.infoProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.issuedToGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.groupComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltLabel48 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.numberOfWorkersTextBox = new Com.Suncor.Olt.Client.OltControls.OltIntegerBox();
            this.occupationComboBox = new Com.Suncor.Olt.Client.OltControls.OltEditableComboBox();
            this.occupationLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.issuedToSuncorCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.issuedToContractorCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.contractorComboBox = new Com.Suncor.Olt.Client.OltControls.OltEditableComboBox();
            this.oltLabel4 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLastModifiedDateAuthorHeader1 = new Com.Suncor.Olt.Client.OltControls.OltLastModifiedDateAuthorHeader();
            this.permitTypeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.permitTypeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.functionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.locationTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel15 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.functionalLocationTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.functionalLocationBrowseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.requestedStartGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.requestedStartTimeTimePickerWP = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.requestedStartDateDatePickerWP = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.workOrderNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.requestedEndDateGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.requestedEndTimeTimePickerWP = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.requestedEndDateDatePickerWP = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.oltGroupBox4 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.operationNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltGroupBox5 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.subOperationNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.permitNumberGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.permitNumberValue = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.permitNumberLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.documentLinksGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.documentLinksControl = new Com.Suncor.Olt.Client.Controls.DocumentLinksControl();
            this.priorityGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.priorityComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.typeOfWorkGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.extensioncommentsoltLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.extensionCommentsTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.emergencyMeetingPointTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.lockBoxNumberoltCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.coOrdConactNoTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.extensionTimePickerWP = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.extensionDatePickerWP = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.entensionoltLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.lockBoxNoIntegerBox = new Com.Suncor.Olt.Client.OltControls.OltIntegerBox();
            this.isolationNoIntegerBox = new Com.Suncor.Olt.Client.OltControls.OltIntegerBox();
            this.oltLabel16 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel7 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.jobCoordinatorTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel8 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel14 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.emergencyAssemblyAreaTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel20 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.equipmentIntegerBox = new Com.Suncor.Olt.Client.OltControls.OltIntegerBox();
            this.oltLabel45 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.emergencyContactNoTextBox = new Com.Suncor.Olt.Client.OltControls.OltIntegerBox();
            this.oltLabel46 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.contentPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.partFWorkSectionNotApplicableToJobCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabelLine6 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.partGWorkSectionNotApplicableToJobCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabelLine5 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.partEWorkSectionNotApplicableToJobCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabelLine4 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.partDWorkSectionNotApplicableToJobCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabelLine3 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.partCWorkSectionNotApplicableToJobCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabelLine2 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.permitAgreementIssuanceGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.addationalAuthorityContactInfoTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.areaAuthorityContactInfoTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.coAuthorizingIssuerContactInfoTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.permitIssuerContactinfoTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel5 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.addationalAuthorityTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel6 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel37 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.coAuthorizingIssuerTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel38 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel39 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.areaAuthorityTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel40 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel41 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.permitIssuerTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel43 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.fieldtourTblLayoutPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.oltPanel133 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.fieldTourConductedByTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltPanel134 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltPanel10 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.isFieldTourRequiredNoRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.isFieldTourRequiredYesRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.oltPanel135 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltLabel44 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.agreementAndSignaturePanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.permitAcceptorField = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.permitAcceptorLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.atmosphericMoniteringGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.testerNameoltTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltPanel9 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.continuousCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.frequencyPartGComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltPanel8 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.other2PartGTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.other2PartGCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltPanel7 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.other1PartGTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.other1PartGCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.coPpmPartGCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.h2sPpmPartGCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.so2PpmPartGCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.lelPartGCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oxygenPartGCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.controlOfHazardousenergyGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.nuclearSourceCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.electricallyIsolatedCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.doubleBlockedandBledCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.mechanicallyIsolatedCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.testBumpedCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.blindedOrBlankedCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.drainedAndDepressurisedCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.purgedorNeutralisedCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.receiverStafingRequirementsCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.workAuthorizationAndDocumentationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.oltPanel5 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.confinedSpaceCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.confinedSpaceClassComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltPanel6 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.othersPartETextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.othersPartECheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.electricalEncroachmentCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.fireProtectionAuthorizationCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.mSDSCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.industrialRadiographyCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.vehicleEntryCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.criticalOrSeriousLiftsCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.groundDisturbanceCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.safetyPrecautionsHazardousGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hazardsAndOrRequirementsTextBox = new Com.Suncor.Olt.Client.OltControls.OltSpellCheckTextBox(this.components);
            this.specialSafetyEquipmentRequirementGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.safetyGlovesCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.hearingProtectionCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.communicationDeviceCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.oltPanel2 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.other3TextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.other3CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltPanel3 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.other2TextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.other2CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltPanel4 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.other1TextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.other1CheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.faceShieldCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.fallProtectionCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.chargedFireHouseCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.coveredSewerCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.airPurifyingRespiratorCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.singalPersonCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.reflectiveStripsCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.monoGogglesCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.fireblanketCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.fireExtinguisherCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.sparkContainmentCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.fireWatchCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.standbyPersonCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.workingAloneCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.personalFlotationDeviceCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.airMoverCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.suppliedBreathingAirCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.confinedSpaceMoniterCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.bottleWatchCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.chemicalSuitCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.flameResistantWorkWearCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.currentSAPDescriptionGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.sapDescriptionTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.taskDescriptionGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.workAndScopeDescriptionTextBox = new Com.Suncor.Olt.Client.OltControls.OltSpellCheckTextBox(this.components);
            this.oltLabelLine1 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoProvider)).BeginInit();
            this.issuedToGroupBox.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            this.permitTypeGroupBox.SuspendLayout();
            this.functionalLocationGroupBox.SuspendLayout();
            this.requestedStartGroupBox.SuspendLayout();
            this.oltGroupBox1.SuspendLayout();
            this.requestedEndDateGroupBox.SuspendLayout();
            this.oltGroupBox4.SuspendLayout();
            this.oltGroupBox5.SuspendLayout();
            this.permitNumberGroupBox.SuspendLayout();
            this.documentLinksGroupBox.SuspendLayout();
            this.priorityGroupBox.SuspendLayout();
            this.typeOfWorkGroupBox.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.permitAgreementIssuanceGroupBox.SuspendLayout();
            this.fieldtourTblLayoutPanel.SuspendLayout();
            this.oltPanel133.SuspendLayout();
            this.oltPanel134.SuspendLayout();
            this.oltPanel10.SuspendLayout();
            this.oltPanel135.SuspendLayout();
            this.agreementAndSignaturePanel.SuspendLayout();
            this.atmosphericMoniteringGroupBox.SuspendLayout();
            this.oltPanel9.SuspendLayout();
            this.oltPanel8.SuspendLayout();
            this.oltPanel7.SuspendLayout();
            this.controlOfHazardousenergyGroupBox.SuspendLayout();
            this.workAuthorizationAndDocumentationGroupBox.SuspendLayout();
            this.oltPanel5.SuspendLayout();
            this.oltPanel6.SuspendLayout();
            this.safetyPrecautionsHazardousGroupBox.SuspendLayout();
            this.specialSafetyEquipmentRequirementGroupBox.SuspendLayout();
            this.oltPanel2.SuspendLayout();
            this.oltPanel3.SuspendLayout();
            this.oltPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.currentSAPDescriptionGroupBox.SuspendLayout();
            this.taskDescriptionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(712, 9);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "&Save && Close";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.printPreferencesButton);
            this.buttonsPanel.Controls.Add(this.saveAndIssueButton);
            this.buttonsPanel.Controls.Add(this.validateButton);
            this.buttonsPanel.Controls.Add(this.cancelButton);
            this.buttonsPanel.Controls.Add(this.saveButton);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 702);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(984, 40);
            this.buttonsPanel.TabIndex = 1;
            // 
            // printPreferencesButton
            // 
            this.printPreferencesButton.Location = new System.Drawing.Point(88, 9);
            this.printPreferencesButton.Name = "printPreferencesButton";
            this.printPreferencesButton.Size = new System.Drawing.Size(115, 23);
            this.printPreferencesButton.TabIndex = 11;
            this.printPreferencesButton.Text = "Printing Preferences";
            this.printPreferencesButton.UseVisualStyleBackColor = true;
            this.printPreferencesButton.Visible = false;
            // 
            // saveAndIssueButton
            // 
            this.saveAndIssueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAndIssueButton.Location = new System.Drawing.Point(808, 9);
            this.saveAndIssueButton.Name = "saveAndIssueButton";
            this.saveAndIssueButton.Size = new System.Drawing.Size(83, 23);
            this.saveAndIssueButton.TabIndex = 10;
            this.saveAndIssueButton.Text = "Save && Issue";
            this.saveAndIssueButton.UseVisualStyleBackColor = true;
            // 
            // validateButton
            // 
            this.validateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.validateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.validateButton.Location = new System.Drawing.Point(9, 9);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(75, 23);
            this.validateButton.TabIndex = 5;
            this.validateButton.Text = "&Validate";
            this.validateButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(897, 9);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
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
            // infoProvider
            // 
            this.infoProvider.ContainerControl = this;
            this.infoProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("infoProvider.Icon")));
            // 
            // issuedToGroupBox
            // 
            this.issuedToGroupBox.Controls.Add(this.groupComboBox);
            this.issuedToGroupBox.Controls.Add(this.oltLabel48);
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
            this.groupComboBox.Location = new System.Drawing.Point(838, 20);
            this.groupComboBox.MaxLength = 50;
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(96, 21);
            this.groupComboBox.TabIndex = 5;
            // 
            // oltLabel48
            // 
            this.oltLabel48.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel48.Location = new System.Drawing.Point(776, 17);
            this.oltLabel48.Name = "oltLabel48";
            this.oltLabel48.Size = new System.Drawing.Size(71, 29);
            this.oltLabel48.TabIndex = 5;
            this.oltLabel48.Text = "Requested By:";
            // 
            // numberOfWorkersTextBox
            // 
            this.numberOfWorkersTextBox.DecimalValue = null;
            this.numberOfWorkersTextBox.IntegerValue = null;
            this.numberOfWorkersTextBox.Location = new System.Drawing.Point(730, 20);
            this.numberOfWorkersTextBox.MaxLength = 3;
            this.numberOfWorkersTextBox.Name = "numberOfWorkersTextBox";
            this.numberOfWorkersTextBox.NumericValue = null;
            this.numberOfWorkersTextBox.Size = new System.Drawing.Size(30, 20);
            this.numberOfWorkersTextBox.TabIndex = 4;
            this.numberOfWorkersTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // occupationComboBox
            // 
            this.occupationComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.occupationComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.occupationComboBox.DropDownWidth = 250;
            this.occupationComboBox.FormattingEnabled = true;
            this.occupationComboBox.Location = new System.Drawing.Point(448, 20);
            this.occupationComboBox.MaxDropDownItems = 16;
            this.occupationComboBox.MaxLength = 35;
            this.occupationComboBox.Name = "occupationComboBox";
            this.occupationComboBox.Size = new System.Drawing.Size(190, 21);
            this.occupationComboBox.TabIndex = 3;
            // 
            // occupationLabel
            // 
            this.occupationLabel.AutoSize = true;
            this.occupationLabel.Location = new System.Drawing.Point(398, 24);
            this.occupationLabel.Name = "occupationLabel";
            this.occupationLabel.Size = new System.Drawing.Size(39, 13);
            this.occupationLabel.TabIndex = 1;
            this.occupationLabel.Text = "Craft :";
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.issuedToSuncorCheckBox);
            this.oltPanel1.Controls.Add(this.issuedToContractorCheckBox);
            this.oltPanel1.Controls.Add(this.contractorComboBox);
            this.oltPanel1.Location = new System.Drawing.Point(6, 18);
            this.oltPanel1.Name = "oltPanel1";
            this.oltPanel1.Size = new System.Drawing.Size(370, 25);
            this.oltPanel1.TabIndex = 0;
            // 
            // issuedToSuncorCheckBox
            // 
            this.issuedToSuncorCheckBox.AutoSize = true;
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
            this.oltLabel4.Location = new System.Drawing.Point(655, 24);
            this.oltLabel4.Name = "oltLabel4";
            this.oltLabel4.Size = new System.Drawing.Size(69, 13);
            this.oltLabel4.TabIndex = 3;
            this.oltLabel4.Text = "# Crew Size:";
            // 
            // oltLastModifiedDateAuthorHeader1
            // 
            this.oltLastModifiedDateAuthorHeader1.LastModifiedDate = new System.DateTime(((long)(0)));
            this.oltLastModifiedDateAuthorHeader1.Location = new System.Drawing.Point(9, 7);
            this.oltLastModifiedDateAuthorHeader1.Name = "oltLastModifiedDateAuthorHeader1";
            this.oltLastModifiedDateAuthorHeader1.Size = new System.Drawing.Size(621, 37);
            this.oltLastModifiedDateAuthorHeader1.TabIndex = 0;
            // 
            // permitTypeGroupBox
            // 
            this.permitTypeGroupBox.Controls.Add(this.permitTypeComboBox);
            this.permitTypeGroupBox.Location = new System.Drawing.Point(9, 103);
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
            this.permitTypeComboBox.TabIndex = 6;
            // 
            // functionalLocationGroupBox
            // 
            this.functionalLocationGroupBox.Controls.Add(this.locationTextBox);
            this.functionalLocationGroupBox.Controls.Add(this.oltLabel15);
            this.functionalLocationGroupBox.Controls.Add(this.functionalLocationTextBox);
            this.functionalLocationGroupBox.Controls.Add(this.functionalLocationBrowseButton);
            this.functionalLocationGroupBox.Location = new System.Drawing.Point(181, 103);
            this.functionalLocationGroupBox.Name = "functionalLocationGroupBox";
            this.functionalLocationGroupBox.Size = new System.Drawing.Size(458, 81);
            this.functionalLocationGroupBox.TabIndex = 4;
            this.functionalLocationGroupBox.TabStop = false;
            this.functionalLocationGroupBox.Text = "Functional Location / Equipment";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(79, 46);
            this.locationTextBox.MaxLength = 35;
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.OltAcceptsReturn = true;
            this.locationTextBox.OltTrimWhitespace = true;
            this.locationTextBox.Size = new System.Drawing.Size(356, 20);
            this.locationTextBox.TabIndex = 9;
            // 
            // oltLabel15
            // 
            this.oltLabel15.AutoSize = true;
            this.oltLabel15.Location = new System.Drawing.Point(8, 49);
            this.oltLabel15.Name = "oltLabel15";
            this.oltLabel15.Size = new System.Drawing.Size(51, 13);
            this.oltLabel15.TabIndex = 2;
            this.oltLabel15.Text = "Location:";
            // 
            // functionalLocationTextBox
            // 
            this.functionalLocationTextBox.Location = new System.Drawing.Point(6, 15);
            this.functionalLocationTextBox.Name = "functionalLocationTextBox";
            this.functionalLocationTextBox.OltAcceptsReturn = true;
            this.functionalLocationTextBox.OltTrimWhitespace = true;
            this.functionalLocationTextBox.ReadOnly = true;
            this.functionalLocationTextBox.Size = new System.Drawing.Size(351, 20);
            this.functionalLocationTextBox.TabIndex = 0;
            // 
            // functionalLocationBrowseButton
            // 
            this.functionalLocationBrowseButton.Location = new System.Drawing.Point(363, 13);
            this.functionalLocationBrowseButton.Name = "functionalLocationBrowseButton";
            this.functionalLocationBrowseButton.Size = new System.Drawing.Size(69, 23);
            this.functionalLocationBrowseButton.TabIndex = 8;
            this.functionalLocationBrowseButton.Text = "Browse...";
            this.functionalLocationBrowseButton.UseVisualStyleBackColor = true;
            this.functionalLocationBrowseButton.Click += new System.EventHandler(this.functionalLocationBrowseButton_Click);
            // 
            // requestedStartGroupBox
            // 
            this.requestedStartGroupBox.Controls.Add(this.requestedStartTimeTimePickerWP);
            this.requestedStartGroupBox.Controls.Add(this.requestedStartDateDatePickerWP);
            this.requestedStartGroupBox.Location = new System.Drawing.Point(645, 261);
            this.requestedStartGroupBox.Name = "requestedStartGroupBox";
            this.requestedStartGroupBox.Size = new System.Drawing.Size(206, 40);
            this.requestedStartGroupBox.TabIndex = 8;
            this.requestedStartGroupBox.TabStop = false;
            this.requestedStartGroupBox.Text = "Requested Start";
            // 
            // requestedStartTimeTimePickerWP
            // 
            this.requestedStartTimeTimePickerWP.Checked = true;
            this.requestedStartTimeTimePickerWP.CustomFormat = "HH:mm";
            this.requestedStartTimeTimePickerWP.Location = new System.Drawing.Point(133, 15);
            this.requestedStartTimeTimePickerWP.Margin = new System.Windows.Forms.Padding(0);
            this.requestedStartTimeTimePickerWP.Name = "requestedStartTimeTimePickerWP";
            this.requestedStartTimeTimePickerWP.ShowCheckBox = false;
            this.requestedStartTimeTimePickerWP.Size = new System.Drawing.Size(51, 21);
            this.requestedStartTimeTimePickerWP.TabIndex = 26;
            // 
            // requestedStartDateDatePickerWP
            // 
            this.requestedStartDateDatePickerWP.CustomFormat = "ddd MM/dd/yyyy";
            this.requestedStartDateDatePickerWP.Location = new System.Drawing.Point(7, 15);
            this.requestedStartDateDatePickerWP.Margin = new System.Windows.Forms.Padding(0);
            this.requestedStartDateDatePickerWP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.requestedStartDateDatePickerWP.Name = "requestedStartDateDatePickerWP";
            this.requestedStartDateDatePickerWP.PickerEnabled = true;
            this.requestedStartDateDatePickerWP.Size = new System.Drawing.Size(124, 21);
            this.requestedStartDateDatePickerWP.TabIndex = 25;
            // 
            // oltGroupBox1
            // 
            this.oltGroupBox1.Controls.Add(this.workOrderNumberTextBox);
            this.oltGroupBox1.Location = new System.Drawing.Point(857, 261);
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.Size = new System.Drawing.Size(95, 40);
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
            this.workOrderNumberTextBox.Size = new System.Drawing.Size(78, 20);
            this.workOrderNumberTextBox.TabIndex = 29;
            // 
            // requestedEndDateGroupBox
            // 
            this.requestedEndDateGroupBox.Controls.Add(this.requestedEndTimeTimePickerWP);
            this.requestedEndDateGroupBox.Controls.Add(this.requestedEndDateDatePickerWP);
            this.requestedEndDateGroupBox.Location = new System.Drawing.Point(645, 307);
            this.requestedEndDateGroupBox.Name = "requestedEndDateGroupBox";
            this.requestedEndDateGroupBox.Size = new System.Drawing.Size(206, 40);
            this.requestedEndDateGroupBox.TabIndex = 9;
            this.requestedEndDateGroupBox.TabStop = false;
            this.requestedEndDateGroupBox.Text = "Expires";
            // 
            // requestedEndTimeTimePickerWP
            // 
            this.requestedEndTimeTimePickerWP.Checked = true;
            this.requestedEndTimeTimePickerWP.CustomFormat = "HH:mm";
            this.requestedEndTimeTimePickerWP.Location = new System.Drawing.Point(133, 15);
            this.requestedEndTimeTimePickerWP.Margin = new System.Windows.Forms.Padding(0);
            this.requestedEndTimeTimePickerWP.Name = "requestedEndTimeTimePickerWP";
            this.requestedEndTimeTimePickerWP.ShowCheckBox = false;
            this.requestedEndTimeTimePickerWP.Size = new System.Drawing.Size(51, 21);
            this.requestedEndTimeTimePickerWP.TabIndex = 28;
            // 
            // requestedEndDateDatePickerWP
            // 
            this.requestedEndDateDatePickerWP.CustomFormat = "ddd MM/dd/yyyy";
            this.requestedEndDateDatePickerWP.Location = new System.Drawing.Point(7, 15);
            this.requestedEndDateDatePickerWP.Margin = new System.Windows.Forms.Padding(0);
            this.requestedEndDateDatePickerWP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.requestedEndDateDatePickerWP.Name = "requestedEndDateDatePickerWP";
            this.requestedEndDateDatePickerWP.PickerEnabled = true;
            this.requestedEndDateDatePickerWP.Size = new System.Drawing.Size(124, 21);
            this.requestedEndDateDatePickerWP.TabIndex = 27;
            // 
            // oltGroupBox4
            // 
            this.oltGroupBox4.Controls.Add(this.operationNumberTextBox);
            this.oltGroupBox4.Location = new System.Drawing.Point(857, 307);
            this.oltGroupBox4.Name = "oltGroupBox4";
            this.oltGroupBox4.Size = new System.Drawing.Size(95, 40);
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
            this.operationNumberTextBox.Size = new System.Drawing.Size(78, 20);
            this.operationNumberTextBox.TabIndex = 30;
            // 
            // oltGroupBox5
            // 
            this.oltGroupBox5.Controls.Add(this.subOperationNumberTextBox);
            this.oltGroupBox5.Location = new System.Drawing.Point(857, 353);
            this.oltGroupBox5.Name = "oltGroupBox5";
            this.oltGroupBox5.Size = new System.Drawing.Size(95, 40);
            this.oltGroupBox5.TabIndex = 12;
            this.oltGroupBox5.TabStop = false;
            this.oltGroupBox5.Text = "Sub Op #";
            // 
            // subOperationNumberTextBox
            // 
            this.subOperationNumberTextBox.Location = new System.Drawing.Point(7, 14);
            this.subOperationNumberTextBox.MaxLength = 4;
            this.subOperationNumberTextBox.Name = "subOperationNumberTextBox";
            this.subOperationNumberTextBox.OltAcceptsReturn = true;
            this.subOperationNumberTextBox.OltTrimWhitespace = true;
            this.subOperationNumberTextBox.Size = new System.Drawing.Size(78, 20);
            this.subOperationNumberTextBox.TabIndex = 31;
            // 
            // permitNumberGroupBox
            // 
            this.permitNumberGroupBox.Controls.Add(this.permitNumberValue);
            this.permitNumberGroupBox.Controls.Add(this.permitNumberLabel);
            this.permitNumberGroupBox.Location = new System.Drawing.Point(636, 7);
            this.permitNumberGroupBox.Name = "permitNumberGroupBox";
            this.permitNumberGroupBox.Size = new System.Drawing.Size(316, 37);
            this.permitNumberGroupBox.TabIndex = 27;
            this.permitNumberGroupBox.TabStop = false;
            this.permitNumberGroupBox.Text = "Permit Information";
            // 
            // permitNumberValue
            // 
            this.permitNumberValue.AutoSize = true;
            this.permitNumberValue.Location = new System.Drawing.Point(78, 15);
            this.permitNumberValue.Name = "permitNumberValue";
            this.permitNumberValue.Size = new System.Drawing.Size(0, 13);
            this.permitNumberValue.TabIndex = 1;
            // 
            // permitNumberLabel
            // 
            this.permitNumberLabel.AutoSize = true;
            this.permitNumberLabel.Location = new System.Drawing.Point(6, 15);
            this.permitNumberLabel.Name = "permitNumberLabel";
            this.permitNumberLabel.Size = new System.Drawing.Size(68, 13);
            this.permitNumberLabel.TabIndex = 0;
            this.permitNumberLabel.Text = "FH Permit #:";
            // 
            // documentLinksGroupBox
            // 
            this.documentLinksGroupBox.Controls.Add(this.documentLinksControl);
            this.documentLinksGroupBox.Location = new System.Drawing.Point(645, 103);
            this.documentLinksGroupBox.Name = "documentLinksGroupBox";
            this.documentLinksGroupBox.Size = new System.Drawing.Size(307, 152);
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
            this.documentLinksControl.Size = new System.Drawing.Size(286, 122);
            this.documentLinksControl.TabIndex = 11;
            // 
            // priorityGroupBox
            // 
            this.priorityGroupBox.Controls.Add(this.priorityComboBox);
            this.priorityGroupBox.Location = new System.Drawing.Point(9, 144);
            this.priorityGroupBox.Name = "priorityGroupBox";
            this.priorityGroupBox.Size = new System.Drawing.Size(166, 40);
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
            this.priorityComboBox.TabIndex = 7;
            // 
            // typeOfWorkGroupBox
            // 
            this.typeOfWorkGroupBox.Controls.Add(this.extensioncommentsoltLabel);
            this.typeOfWorkGroupBox.Controls.Add(this.extensionCommentsTextBox);
            this.typeOfWorkGroupBox.Controls.Add(this.emergencyMeetingPointTextBox);
            this.typeOfWorkGroupBox.Controls.Add(this.lockBoxNumberoltCheckBox);
            this.typeOfWorkGroupBox.Controls.Add(this.coOrdConactNoTextBox);
            this.typeOfWorkGroupBox.Controls.Add(this.extensionTimePickerWP);
            this.typeOfWorkGroupBox.Controls.Add(this.extensionDatePickerWP);
            this.typeOfWorkGroupBox.Controls.Add(this.entensionoltLabel);
            this.typeOfWorkGroupBox.Controls.Add(this.lockBoxNoIntegerBox);
            this.typeOfWorkGroupBox.Controls.Add(this.isolationNoIntegerBox);
            this.typeOfWorkGroupBox.Controls.Add(this.oltLabel16);
            this.typeOfWorkGroupBox.Controls.Add(this.oltLabel7);
            this.typeOfWorkGroupBox.Controls.Add(this.jobCoordinatorTextBox);
            this.typeOfWorkGroupBox.Controls.Add(this.oltLabel8);
            this.typeOfWorkGroupBox.Controls.Add(this.oltLabel14);
            this.typeOfWorkGroupBox.Controls.Add(this.emergencyAssemblyAreaTextBox);
            this.typeOfWorkGroupBox.Controls.Add(this.oltLabel20);
            this.typeOfWorkGroupBox.Controls.Add(this.equipmentIntegerBox);
            this.typeOfWorkGroupBox.Controls.Add(this.oltLabel45);
            this.typeOfWorkGroupBox.Controls.Add(this.emergencyContactNoTextBox);
            this.typeOfWorkGroupBox.Controls.Add(this.oltLabel46);
            this.typeOfWorkGroupBox.Location = new System.Drawing.Point(9, 207);
            this.typeOfWorkGroupBox.Name = "typeOfWorkGroupBox";
            this.typeOfWorkGroupBox.Size = new System.Drawing.Size(632, 180);
            this.typeOfWorkGroupBox.TabIndex = 7;
            this.typeOfWorkGroupBox.TabStop = false;
            this.typeOfWorkGroupBox.Text = "Type of Work";
            // 
            // extensioncommentsoltLabel
            // 
            this.extensioncommentsoltLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.extensioncommentsoltLabel.Location = new System.Drawing.Point(271, 135);
            this.extensioncommentsoltLabel.Name = "extensioncommentsoltLabel";
            this.extensioncommentsoltLabel.Size = new System.Drawing.Size(57, 29);
            this.extensioncommentsoltLabel.TabIndex = 46;
            this.extensioncommentsoltLabel.Text = "Extension Comments";
            // 
            // extensionCommentsTextBox
            // 
            this.extensionCommentsTextBox.Enabled = false;
            this.extensionCommentsTextBox.Location = new System.Drawing.Point(330, 130);
            this.extensionCommentsTextBox.MaxLength = 99;
            this.extensionCommentsTextBox.Multiline = true;
            this.extensionCommentsTextBox.Name = "extensionCommentsTextBox";
            this.extensionCommentsTextBox.OltAcceptsReturn = true;
            this.extensionCommentsTextBox.OltTrimWhitespace = true;
            this.extensionCommentsTextBox.Size = new System.Drawing.Size(296, 44);
            this.extensionCommentsTextBox.TabIndex = 45;
            this.extensionCommentsTextBox.Visible = false;
            // 
            // emergencyMeetingPointTextBox
            // 
            this.emergencyMeetingPointTextBox.Location = new System.Drawing.Point(473, 49);
            this.emergencyMeetingPointTextBox.MaxLength = 25;
            this.emergencyMeetingPointTextBox.Name = "emergencyMeetingPointTextBox";
            this.emergencyMeetingPointTextBox.OltAcceptsReturn = true;
            this.emergencyMeetingPointTextBox.OltTrimWhitespace = true;
            this.emergencyMeetingPointTextBox.Size = new System.Drawing.Size(147, 20);
            this.emergencyMeetingPointTextBox.TabIndex = 44;
            // 
            // lockBoxNumberoltCheckBox
            // 
            this.lockBoxNumberoltCheckBox.AutoSize = true;
            this.lockBoxNumberoltCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lockBoxNumberoltCheckBox.Location = new System.Drawing.Point(17, 105);
            this.lockBoxNumberoltCheckBox.Name = "lockBoxNumberoltCheckBox";
            this.lockBoxNumberoltCheckBox.Size = new System.Drawing.Size(108, 17);
            this.lockBoxNumberoltCheckBox.TabIndex = 18;
            this.lockBoxNumberoltCheckBox.Text = "Lock Box Number";
            this.lockBoxNumberoltCheckBox.UseVisualStyleBackColor = true;
            this.lockBoxNumberoltCheckBox.Value = null;
            // 
            // coOrdConactNoTextBox
            // 
            this.coOrdConactNoTextBox.Location = new System.Drawing.Point(317, 21);
            this.coOrdConactNoTextBox.MaxLength = 25;
            this.coOrdConactNoTextBox.Name = "coOrdConactNoTextBox";
            this.coOrdConactNoTextBox.OltAcceptsReturn = true;
            this.coOrdConactNoTextBox.OltTrimWhitespace = true;
            this.coOrdConactNoTextBox.Size = new System.Drawing.Size(110, 20);
            this.coOrdConactNoTextBox.TabIndex = 13;
            // 
            // extensionTimePickerWP
            // 
            this.extensionTimePickerWP.Checked = true;
            this.extensionTimePickerWP.CustomFormat = "HH:mm";
            this.extensionTimePickerWP.Enabled = false;
            this.extensionTimePickerWP.Location = new System.Drawing.Point(190, 143);
            this.extensionTimePickerWP.Margin = new System.Windows.Forms.Padding(0);
            this.extensionTimePickerWP.Name = "extensionTimePickerWP";
            this.extensionTimePickerWP.ShowCheckBox = false;
            this.extensionTimePickerWP.Size = new System.Drawing.Size(60, 21);
            this.extensionTimePickerWP.TabIndex = 24;
            // 
            // extensionDatePickerWP
            // 
            this.extensionDatePickerWP.CustomFormat = "ddd MM/dd/yyyy";
            this.extensionDatePickerWP.Enabled = false;
            this.extensionDatePickerWP.Location = new System.Drawing.Point(78, 143);
            this.extensionDatePickerWP.Margin = new System.Windows.Forms.Padding(0);
            this.extensionDatePickerWP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.extensionDatePickerWP.Name = "extensionDatePickerWP";
            this.extensionDatePickerWP.PickerEnabled = true;
            this.extensionDatePickerWP.Size = new System.Drawing.Size(110, 21);
            this.extensionDatePickerWP.TabIndex = 23;
            // 
            // entensionoltLabel
            // 
            this.entensionoltLabel.AutoSize = true;
            this.entensionoltLabel.Location = new System.Drawing.Point(15, 146);
            this.entensionoltLabel.Name = "entensionoltLabel";
            this.entensionoltLabel.Size = new System.Drawing.Size(61, 13);
            this.entensionoltLabel.TabIndex = 43;
            this.entensionoltLabel.Text = "Extension :";
            // 
            // lockBoxNoIntegerBox
            // 
            this.lockBoxNoIntegerBox.DecimalValue = null;
            this.lockBoxNoIntegerBox.IntegerValue = null;
            this.lockBoxNoIntegerBox.Location = new System.Drawing.Point(126, 104);
            this.lockBoxNoIntegerBox.MaxLength = 9;
            this.lockBoxNoIntegerBox.Name = "lockBoxNoIntegerBox";
            this.lockBoxNoIntegerBox.NumericValue = null;
            this.lockBoxNoIntegerBox.Size = new System.Drawing.Size(112, 20);
            this.lockBoxNoIntegerBox.TabIndex = 19;
            this.lockBoxNoIntegerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // isolationNoIntegerBox
            // 
            this.isolationNoIntegerBox.DecimalValue = null;
            this.isolationNoIntegerBox.IntegerValue = null;
            this.isolationNoIntegerBox.Location = new System.Drawing.Point(330, 104);
            this.isolationNoIntegerBox.MaxLength = 9;
            this.isolationNoIntegerBox.Name = "isolationNoIntegerBox";
            this.isolationNoIntegerBox.NumericValue = null;
            this.isolationNoIntegerBox.Size = new System.Drawing.Size(112, 20);
            this.isolationNoIntegerBox.TabIndex = 20;
            this.isolationNoIntegerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // oltLabel16
            // 
            this.oltLabel16.AutoSize = true;
            this.oltLabel16.Location = new System.Drawing.Point(251, 107);
            this.oltLabel16.Name = "oltLabel16";
            this.oltLabel16.Size = new System.Drawing.Size(75, 13);
            this.oltLabel16.TabIndex = 39;
            this.oltLabel16.Text = "Isolation No. :";
            // 
            // oltLabel7
            // 
            this.oltLabel7.AutoSize = true;
            this.oltLabel7.Location = new System.Drawing.Point(221, 25);
            this.oltLabel7.Name = "oltLabel7";
            this.oltLabel7.Size = new System.Drawing.Size(90, 13);
            this.oltLabel7.TabIndex = 30;
            this.oltLabel7.Text = "Co-Ord Contact :";
            // 
            // jobCoordinatorTextBox
            // 
            this.jobCoordinatorTextBox.Location = new System.Drawing.Point(107, 21);
            this.jobCoordinatorTextBox.MaxLength = 24;
            this.jobCoordinatorTextBox.Name = "jobCoordinatorTextBox";
            this.jobCoordinatorTextBox.OltAcceptsReturn = true;
            this.jobCoordinatorTextBox.OltTrimWhitespace = true;
            this.jobCoordinatorTextBox.Size = new System.Drawing.Size(99, 20);
            this.jobCoordinatorTextBox.TabIndex = 12;
            // 
            // oltLabel8
            // 
            this.oltLabel8.AutoSize = true;
            this.oltLabel8.Location = new System.Drawing.Point(15, 24);
            this.oltLabel8.Name = "oltLabel8";
            this.oltLabel8.Size = new System.Drawing.Size(91, 13);
            this.oltLabel8.TabIndex = 28;
            this.oltLabel8.Text = "Job Coordinator :";
            // 
            // oltLabel14
            // 
            this.oltLabel14.AutoSize = true;
            this.oltLabel14.Location = new System.Drawing.Point(336, 52);
            this.oltLabel14.Name = "oltLabel14";
            this.oltLabel14.Size = new System.Drawing.Size(135, 13);
            this.oltLabel14.TabIndex = 27;
            this.oltLabel14.Text = "Emergency Meeting Point :";
            // 
            // emergencyAssemblyAreaTextBox
            // 
            this.emergencyAssemblyAreaTextBox.Location = new System.Drawing.Point(160, 49);
            this.emergencyAssemblyAreaTextBox.MaxLength = 25;
            this.emergencyAssemblyAreaTextBox.Name = "emergencyAssemblyAreaTextBox";
            this.emergencyAssemblyAreaTextBox.OltAcceptsReturn = true;
            this.emergencyAssemblyAreaTextBox.OltTrimWhitespace = true;
            this.emergencyAssemblyAreaTextBox.Size = new System.Drawing.Size(168, 20);
            this.emergencyAssemblyAreaTextBox.TabIndex = 14;
            // 
            // oltLabel20
            // 
            this.oltLabel20.AutoSize = true;
            this.oltLabel20.Location = new System.Drawing.Point(15, 51);
            this.oltLabel20.Name = "oltLabel20";
            this.oltLabel20.Size = new System.Drawing.Size(141, 13);
            this.oltLabel20.TabIndex = 24;
            this.oltLabel20.Text = "Emergency Assembly Area :";
            // 
            // equipmentIntegerBox
            // 
            this.equipmentIntegerBox.DecimalValue = null;
            this.equipmentIntegerBox.IntegerValue = null;
            this.equipmentIntegerBox.Location = new System.Drawing.Point(362, 74);
            this.equipmentIntegerBox.MaxLength = 9;
            this.equipmentIntegerBox.Name = "equipmentIntegerBox";
            this.equipmentIntegerBox.NumericValue = null;
            this.equipmentIntegerBox.Size = new System.Drawing.Size(112, 20);
            this.equipmentIntegerBox.TabIndex = 17;
            this.equipmentIntegerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.equipmentIntegerBox.Visible = false;
            // 
            // oltLabel45
            // 
            this.oltLabel45.AutoSize = true;
            this.oltLabel45.Location = new System.Drawing.Point(283, 78);
            this.oltLabel45.Name = "oltLabel45";
            this.oltLabel45.Size = new System.Drawing.Size(75, 13);
            this.oltLabel45.TabIndex = 22;
            this.oltLabel45.Text = "Equipment # :";
            this.oltLabel45.Visible = false;
            // 
            // emergencyContactNoTextBox
            // 
            this.emergencyContactNoTextBox.DecimalValue = null;
            this.emergencyContactNoTextBox.IntegerValue = null;
            this.emergencyContactNoTextBox.Location = new System.Drawing.Point(155, 75);
            this.emergencyContactNoTextBox.MaxLength = 10;
            this.emergencyContactNoTextBox.Name = "emergencyContactNoTextBox";
            this.emergencyContactNoTextBox.NumericValue = null;
            this.emergencyContactNoTextBox.Size = new System.Drawing.Size(112, 20);
            this.emergencyContactNoTextBox.TabIndex = 16;
            this.emergencyContactNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // oltLabel46
            // 
            this.oltLabel46.AutoSize = true;
            this.oltLabel46.Location = new System.Drawing.Point(16, 78);
            this.oltLabel46.Name = "oltLabel46";
            this.oltLabel46.Size = new System.Drawing.Size(128, 13);
            this.oltLabel46.TabIndex = 20;
            this.oltLabel46.Text = "Emergency Conatct No. :";
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.Controls.Add(this.partFWorkSectionNotApplicableToJobCheckBox);
            this.contentPanel.Controls.Add(this.oltLabelLine6);
            this.contentPanel.Controls.Add(this.partGWorkSectionNotApplicableToJobCheckBox);
            this.contentPanel.Controls.Add(this.oltLabelLine5);
            this.contentPanel.Controls.Add(this.partEWorkSectionNotApplicableToJobCheckBox);
            this.contentPanel.Controls.Add(this.oltLabelLine4);
            this.contentPanel.Controls.Add(this.partDWorkSectionNotApplicableToJobCheckBox);
            this.contentPanel.Controls.Add(this.oltLabelLine3);
            this.contentPanel.Controls.Add(this.partCWorkSectionNotApplicableToJobCheckBox);
            this.contentPanel.Controls.Add(this.oltLabelLine2);
            this.contentPanel.Controls.Add(this.permitAgreementIssuanceGroupBox);
            this.contentPanel.Controls.Add(this.agreementAndSignaturePanel);
            this.contentPanel.Controls.Add(this.atmosphericMoniteringGroupBox);
            this.contentPanel.Controls.Add(this.controlOfHazardousenergyGroupBox);
            this.contentPanel.Controls.Add(this.workAuthorizationAndDocumentationGroupBox);
            this.contentPanel.Controls.Add(this.safetyPrecautionsHazardousGroupBox);
            this.contentPanel.Controls.Add(this.specialSafetyEquipmentRequirementGroupBox);
            this.contentPanel.Controls.Add(this.tableLayoutPanel1);
            this.contentPanel.Controls.Add(this.typeOfWorkGroupBox);
            this.contentPanel.Controls.Add(this.priorityGroupBox);
            this.contentPanel.Controls.Add(this.documentLinksGroupBox);
            this.contentPanel.Controls.Add(this.permitNumberGroupBox);
            this.contentPanel.Controls.Add(this.oltLabelLine1);
            this.contentPanel.Controls.Add(this.oltGroupBox5);
            this.contentPanel.Controls.Add(this.oltGroupBox4);
            this.contentPanel.Controls.Add(this.requestedEndDateGroupBox);
            this.contentPanel.Controls.Add(this.oltGroupBox1);
            this.contentPanel.Controls.Add(this.requestedStartGroupBox);
            this.contentPanel.Controls.Add(this.functionalLocationGroupBox);
            this.contentPanel.Controls.Add(this.permitTypeGroupBox);
            this.contentPanel.Controls.Add(this.oltLastModifiedDateAuthorHeader1);
            this.contentPanel.Controls.Add(this.issuedToGroupBox);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(984, 702);
            this.contentPanel.TabIndex = 0;
            // 
            // partFWorkSectionNotApplicableToJobCheckBox
            // 
            this.partFWorkSectionNotApplicableToJobCheckBox.AutoSize = true;
            this.partFWorkSectionNotApplicableToJobCheckBox.Location = new System.Drawing.Point(781, 1259);
            this.partFWorkSectionNotApplicableToJobCheckBox.Name = "partFWorkSectionNotApplicableToJobCheckBox";
            this.partFWorkSectionNotApplicableToJobCheckBox.Size = new System.Drawing.Size(167, 17);
            this.partFWorkSectionNotApplicableToJobCheckBox.TabIndex = 63;
            this.partFWorkSectionNotApplicableToJobCheckBox.Text = "Section Not Applicable To Job";
            this.partFWorkSectionNotApplicableToJobCheckBox.UseVisualStyleBackColor = true;
            this.partFWorkSectionNotApplicableToJobCheckBox.Value = null;
            // 
            // oltLabelLine6
            // 
            this.oltLabelLine6.Label = "PART F: Control Of Hazardous Energy And Safing Status";
            this.oltLabelLine6.Location = new System.Drawing.Point(15, 1259);
            this.oltLabelLine6.Name = "oltLabelLine6";
            this.oltLabelLine6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.oltLabelLine6.Size = new System.Drawing.Size(766, 13);
            this.oltLabelLine6.TabIndex = 62;
            this.oltLabelLine6.TabStop = false;
            // 
            // partGWorkSectionNotApplicableToJobCheckBox
            // 
            this.partGWorkSectionNotApplicableToJobCheckBox.AutoSize = true;
            this.partGWorkSectionNotApplicableToJobCheckBox.Location = new System.Drawing.Point(782, 1375);
            this.partGWorkSectionNotApplicableToJobCheckBox.Name = "partGWorkSectionNotApplicableToJobCheckBox";
            this.partGWorkSectionNotApplicableToJobCheckBox.Size = new System.Drawing.Size(167, 17);
            this.partGWorkSectionNotApplicableToJobCheckBox.TabIndex = 61;
            this.partGWorkSectionNotApplicableToJobCheckBox.Text = "Section Not Applicable To Job";
            this.partGWorkSectionNotApplicableToJobCheckBox.UseVisualStyleBackColor = true;
            this.partGWorkSectionNotApplicableToJobCheckBox.Value = null;
            // 
            // oltLabelLine5
            // 
            this.oltLabelLine5.Label = "PART G: Atmospheric Monitering";
            this.oltLabelLine5.Location = new System.Drawing.Point(16, 1375);
            this.oltLabelLine5.Name = "oltLabelLine5";
            this.oltLabelLine5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.oltLabelLine5.Size = new System.Drawing.Size(766, 13);
            this.oltLabelLine5.TabIndex = 60;
            this.oltLabelLine5.TabStop = false;
            // 
            // partEWorkSectionNotApplicableToJobCheckBox
            // 
            this.partEWorkSectionNotApplicableToJobCheckBox.AutoSize = true;
            this.partEWorkSectionNotApplicableToJobCheckBox.Location = new System.Drawing.Point(784, 1147);
            this.partEWorkSectionNotApplicableToJobCheckBox.Name = "partEWorkSectionNotApplicableToJobCheckBox";
            this.partEWorkSectionNotApplicableToJobCheckBox.Size = new System.Drawing.Size(167, 17);
            this.partEWorkSectionNotApplicableToJobCheckBox.TabIndex = 59;
            this.partEWorkSectionNotApplicableToJobCheckBox.Text = "Section Not Applicable To Job";
            this.partEWorkSectionNotApplicableToJobCheckBox.UseVisualStyleBackColor = true;
            this.partEWorkSectionNotApplicableToJobCheckBox.Value = null;
            // 
            // oltLabelLine4
            // 
            this.oltLabelLine4.Label = "PART E: Work Authorization And Or Documentation";
            this.oltLabelLine4.Location = new System.Drawing.Point(14, 1147);
            this.oltLabelLine4.Name = "oltLabelLine4";
            this.oltLabelLine4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.oltLabelLine4.Size = new System.Drawing.Size(766, 13);
            this.oltLabelLine4.TabIndex = 58;
            this.oltLabelLine4.TabStop = false;
            // 
            // partDWorkSectionNotApplicableToJobCheckBox
            // 
            this.partDWorkSectionNotApplicableToJobCheckBox.AutoSize = true;
            this.partDWorkSectionNotApplicableToJobCheckBox.Location = new System.Drawing.Point(782, 988);
            this.partDWorkSectionNotApplicableToJobCheckBox.Name = "partDWorkSectionNotApplicableToJobCheckBox";
            this.partDWorkSectionNotApplicableToJobCheckBox.Size = new System.Drawing.Size(167, 17);
            this.partDWorkSectionNotApplicableToJobCheckBox.TabIndex = 57;
            this.partDWorkSectionNotApplicableToJobCheckBox.Text = "Section Not Applicable To Job";
            this.partDWorkSectionNotApplicableToJobCheckBox.UseVisualStyleBackColor = true;
            this.partDWorkSectionNotApplicableToJobCheckBox.Value = null;
            // 
            // oltLabelLine3
            // 
            this.oltLabelLine3.Label = "PART D: Safety Precautions / Hazardous";
            this.oltLabelLine3.Location = new System.Drawing.Point(15, 988);
            this.oltLabelLine3.Name = "oltLabelLine3";
            this.oltLabelLine3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.oltLabelLine3.Size = new System.Drawing.Size(764, 13);
            this.oltLabelLine3.TabIndex = 56;
            this.oltLabelLine3.TabStop = false;
            // 
            // partCWorkSectionNotApplicableToJobCheckBox
            // 
            this.partCWorkSectionNotApplicableToJobCheckBox.AutoSize = true;
            this.partCWorkSectionNotApplicableToJobCheckBox.Location = new System.Drawing.Point(782, 704);
            this.partCWorkSectionNotApplicableToJobCheckBox.Name = "partCWorkSectionNotApplicableToJobCheckBox";
            this.partCWorkSectionNotApplicableToJobCheckBox.Size = new System.Drawing.Size(167, 17);
            this.partCWorkSectionNotApplicableToJobCheckBox.TabIndex = 55;
            this.partCWorkSectionNotApplicableToJobCheckBox.Text = "Section Not Applicable To Job";
            this.partCWorkSectionNotApplicableToJobCheckBox.UseVisualStyleBackColor = true;
            this.partCWorkSectionNotApplicableToJobCheckBox.Value = null;
            // 
            // oltLabelLine2
            // 
            this.oltLabelLine2.Label = "PART C: Special Safety Equipment Requirement";
            this.oltLabelLine2.Location = new System.Drawing.Point(13, 704);
            this.oltLabelLine2.Name = "oltLabelLine2";
            this.oltLabelLine2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.oltLabelLine2.Size = new System.Drawing.Size(766, 13);
            this.oltLabelLine2.TabIndex = 54;
            this.oltLabelLine2.TabStop = false;
            // 
            // permitAgreementIssuanceGroupBox
            // 
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.addationalAuthorityContactInfoTextBox);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.areaAuthorityContactInfoTextBox);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.coAuthorizingIssuerContactInfoTextBox);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.permitIssuerContactinfoTextBox);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.oltLabel5);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.addationalAuthorityTextBox);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.oltLabel6);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.oltLabel37);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.coAuthorizingIssuerTextBox);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.oltLabel38);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.oltLabel39);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.areaAuthorityTextBox);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.oltLabel40);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.oltLabel41);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.permitIssuerTextBox);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.oltLabel43);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.fieldtourTblLayoutPanel);
            this.permitAgreementIssuanceGroupBox.Controls.Add(this.label7);
            this.permitAgreementIssuanceGroupBox.Location = new System.Drawing.Point(14, 1484);
            this.permitAgreementIssuanceGroupBox.Name = "permitAgreementIssuanceGroupBox";
            this.permitAgreementIssuanceGroupBox.Size = new System.Drawing.Size(937, 185);
            this.permitAgreementIssuanceGroupBox.TabIndex = 49;
            this.permitAgreementIssuanceGroupBox.TabStop = false;
            this.permitAgreementIssuanceGroupBox.Text = "PART H";
            // 
            // addationalAuthorityContactInfoTextBox
            // 
            this.addationalAuthorityContactInfoTextBox.Location = new System.Drawing.Point(529, 110);
            this.addationalAuthorityContactInfoTextBox.MaxLength = 12;
            this.addationalAuthorityContactInfoTextBox.Name = "addationalAuthorityContactInfoTextBox";
            this.addationalAuthorityContactInfoTextBox.OltAcceptsReturn = true;
            this.addationalAuthorityContactInfoTextBox.OltTrimWhitespace = true;
            this.addationalAuthorityContactInfoTextBox.Size = new System.Drawing.Size(215, 20);
            this.addationalAuthorityContactInfoTextBox.TabIndex = 58;
            // 
            // areaAuthorityContactInfoTextBox
            // 
            this.areaAuthorityContactInfoTextBox.Location = new System.Drawing.Point(529, 59);
            this.areaAuthorityContactInfoTextBox.MaxLength = 12;
            this.areaAuthorityContactInfoTextBox.Name = "areaAuthorityContactInfoTextBox";
            this.areaAuthorityContactInfoTextBox.OltAcceptsReturn = true;
            this.areaAuthorityContactInfoTextBox.OltTrimWhitespace = true;
            this.areaAuthorityContactInfoTextBox.Size = new System.Drawing.Size(215, 20);
            this.areaAuthorityContactInfoTextBox.TabIndex = 57;
            // 
            // coAuthorizingIssuerContactInfoTextBox
            // 
            this.coAuthorizingIssuerContactInfoTextBox.Location = new System.Drawing.Point(529, 85);
            this.coAuthorizingIssuerContactInfoTextBox.MaxLength = 12;
            this.coAuthorizingIssuerContactInfoTextBox.Name = "coAuthorizingIssuerContactInfoTextBox";
            this.coAuthorizingIssuerContactInfoTextBox.OltAcceptsReturn = true;
            this.coAuthorizingIssuerContactInfoTextBox.OltTrimWhitespace = true;
            this.coAuthorizingIssuerContactInfoTextBox.Size = new System.Drawing.Size(215, 20);
            this.coAuthorizingIssuerContactInfoTextBox.TabIndex = 56;
            // 
            // permitIssuerContactinfoTextBox
            // 
            this.permitIssuerContactinfoTextBox.Location = new System.Drawing.Point(529, 34);
            this.permitIssuerContactinfoTextBox.MaxLength = 12;
            this.permitIssuerContactinfoTextBox.Name = "permitIssuerContactinfoTextBox";
            this.permitIssuerContactinfoTextBox.OltAcceptsReturn = true;
            this.permitIssuerContactinfoTextBox.OltTrimWhitespace = true;
            this.permitIssuerContactinfoTextBox.Size = new System.Drawing.Size(215, 20);
            this.permitIssuerContactinfoTextBox.TabIndex = 55;
            // 
            // oltLabel5
            // 
            this.oltLabel5.AutoSize = true;
            this.oltLabel5.Location = new System.Drawing.Point(438, 114);
            this.oltLabel5.Name = "oltLabel5";
            this.oltLabel5.Size = new System.Drawing.Size(83, 13);
            this.oltLabel5.TabIndex = 53;
            this.oltLabel5.Text = "CONTACT INFO";
            // 
            // addationalAuthorityTextBox
            // 
            this.addationalAuthorityTextBox.Location = new System.Drawing.Point(161, 111);
            this.addationalAuthorityTextBox.MaxLength = 25;
            this.addationalAuthorityTextBox.Name = "addationalAuthorityTextBox";
            this.addationalAuthorityTextBox.OltAcceptsReturn = true;
            this.addationalAuthorityTextBox.OltTrimWhitespace = true;
            this.addationalAuthorityTextBox.Size = new System.Drawing.Size(213, 20);
            this.addationalAuthorityTextBox.TabIndex = 52;
            // 
            // oltLabel6
            // 
            this.oltLabel6.AutoSize = true;
            this.oltLabel6.Location = new System.Drawing.Point(22, 115);
            this.oltLabel6.Name = "oltLabel6";
            this.oltLabel6.Size = new System.Drawing.Size(126, 13);
            this.oltLabel6.TabIndex = 51;
            this.oltLabel6.Text = "ADDTIONAL AUTHORITY";
            // 
            // oltLabel37
            // 
            this.oltLabel37.AutoSize = true;
            this.oltLabel37.Location = new System.Drawing.Point(437, 88);
            this.oltLabel37.Name = "oltLabel37";
            this.oltLabel37.Size = new System.Drawing.Size(83, 13);
            this.oltLabel37.TabIndex = 49;
            this.oltLabel37.Text = "CONTACT INFO";
            // 
            // coAuthorizingIssuerTextBox
            // 
            this.coAuthorizingIssuerTextBox.Location = new System.Drawing.Point(161, 85);
            this.coAuthorizingIssuerTextBox.MaxLength = 25;
            this.coAuthorizingIssuerTextBox.Name = "coAuthorizingIssuerTextBox";
            this.coAuthorizingIssuerTextBox.OltAcceptsReturn = true;
            this.coAuthorizingIssuerTextBox.OltTrimWhitespace = true;
            this.coAuthorizingIssuerTextBox.Size = new System.Drawing.Size(215, 20);
            this.coAuthorizingIssuerTextBox.TabIndex = 48;
            // 
            // oltLabel38
            // 
            this.oltLabel38.AutoSize = true;
            this.oltLabel38.Location = new System.Drawing.Point(18, 88);
            this.oltLabel38.Name = "oltLabel38";
            this.oltLabel38.Size = new System.Drawing.Size(135, 13);
            this.oltLabel38.TabIndex = 47;
            this.oltLabel38.Text = "CO-AUTHORIZING ISSUER";
            // 
            // oltLabel39
            // 
            this.oltLabel39.AutoSize = true;
            this.oltLabel39.Location = new System.Drawing.Point(437, 62);
            this.oltLabel39.Name = "oltLabel39";
            this.oltLabel39.Size = new System.Drawing.Size(83, 13);
            this.oltLabel39.TabIndex = 45;
            this.oltLabel39.Text = "CONTACT INFO";
            // 
            // areaAuthorityTextBox
            // 
            this.areaAuthorityTextBox.Location = new System.Drawing.Point(161, 59);
            this.areaAuthorityTextBox.MaxLength = 25;
            this.areaAuthorityTextBox.Name = "areaAuthorityTextBox";
            this.areaAuthorityTextBox.OltAcceptsReturn = true;
            this.areaAuthorityTextBox.OltTrimWhitespace = true;
            this.areaAuthorityTextBox.Size = new System.Drawing.Size(215, 20);
            this.areaAuthorityTextBox.TabIndex = 44;
            // 
            // oltLabel40
            // 
            this.oltLabel40.AutoSize = true;
            this.oltLabel40.Location = new System.Drawing.Point(20, 62);
            this.oltLabel40.Name = "oltLabel40";
            this.oltLabel40.Size = new System.Drawing.Size(95, 13);
            this.oltLabel40.TabIndex = 43;
            this.oltLabel40.Text = "AREA AUTHORITY";
            // 
            // oltLabel41
            // 
            this.oltLabel41.AutoSize = true;
            this.oltLabel41.Location = new System.Drawing.Point(437, 34);
            this.oltLabel41.Name = "oltLabel41";
            this.oltLabel41.Size = new System.Drawing.Size(83, 13);
            this.oltLabel41.TabIndex = 41;
            this.oltLabel41.Text = "CONTACT INFO";
            // 
            // permitIssuerTextBox
            // 
            this.permitIssuerTextBox.Location = new System.Drawing.Point(161, 34);
            this.permitIssuerTextBox.MaxLength = 25;
            this.permitIssuerTextBox.Name = "permitIssuerTextBox";
            this.permitIssuerTextBox.OltAcceptsReturn = true;
            this.permitIssuerTextBox.OltTrimWhitespace = true;
            this.permitIssuerTextBox.Size = new System.Drawing.Size(215, 20);
            this.permitIssuerTextBox.TabIndex = 40;
            // 
            // oltLabel43
            // 
            this.oltLabel43.AutoSize = true;
            this.oltLabel43.Location = new System.Drawing.Point(19, 37);
            this.oltLabel43.Name = "oltLabel43";
            this.oltLabel43.Size = new System.Drawing.Size(83, 13);
            this.oltLabel43.TabIndex = 39;
            this.oltLabel43.Text = "PERMIT ISSUER";
            // 
            // fieldtourTblLayoutPanel
            // 
            this.fieldtourTblLayoutPanel.ColumnCount = 3;
            this.fieldtourTblLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.fieldtourTblLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.fieldtourTblLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.fieldtourTblLayoutPanel.Controls.Add(this.oltPanel133, 0, 0);
            this.fieldtourTblLayoutPanel.Controls.Add(this.oltPanel134, 0, 0);
            this.fieldtourTblLayoutPanel.Controls.Add(this.oltPanel135, 0, 0);
            this.fieldtourTblLayoutPanel.Location = new System.Drawing.Point(14, 143);
            this.fieldtourTblLayoutPanel.Name = "fieldtourTblLayoutPanel";
            this.fieldtourTblLayoutPanel.RowCount = 1;
            this.fieldtourTblLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fieldtourTblLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.fieldtourTblLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.fieldtourTblLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.fieldtourTblLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.fieldtourTblLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.fieldtourTblLayoutPanel.Size = new System.Drawing.Size(902, 30);
            this.fieldtourTblLayoutPanel.TabIndex = 38;
            // 
            // oltPanel133
            // 
            this.oltPanel133.Controls.Add(this.fieldTourConductedByTextBox);
            this.oltPanel133.Location = new System.Drawing.Point(679, 3);
            this.oltPanel133.Name = "oltPanel133";
            this.oltPanel133.Size = new System.Drawing.Size(215, 24);
            this.oltPanel133.TabIndex = 44;
            // 
            // fieldTourConductedByTextBox
            // 
            this.fieldTourConductedByTextBox.Location = new System.Drawing.Point(0, 2);
            this.fieldTourConductedByTextBox.MaxLength = 12;
            this.fieldTourConductedByTextBox.Name = "fieldTourConductedByTextBox";
            this.fieldTourConductedByTextBox.OltAcceptsReturn = true;
            this.fieldTourConductedByTextBox.OltTrimWhitespace = true;
            this.fieldTourConductedByTextBox.Size = new System.Drawing.Size(215, 20);
            this.fieldTourConductedByTextBox.TabIndex = 56;
            // 
            // oltPanel134
            // 
            this.oltPanel134.Controls.Add(this.oltPanel10);
            this.oltPanel134.Location = new System.Drawing.Point(454, 3);
            this.oltPanel134.Name = "oltPanel134";
            this.oltPanel134.Size = new System.Drawing.Size(215, 24);
            this.oltPanel134.TabIndex = 43;
            // 
            // oltPanel10
            // 
            this.oltPanel10.Controls.Add(this.isFieldTourRequiredNoRadioButton);
            this.oltPanel10.Controls.Add(this.isFieldTourRequiredYesRadioButton);
            this.oltPanel10.Location = new System.Drawing.Point(58, 1);
            this.oltPanel10.Name = "oltPanel10";
            this.oltPanel10.Size = new System.Drawing.Size(98, 23);
            this.oltPanel10.TabIndex = 11;
            // 
            // isFieldTourRequiredNoRadioButton
            // 
            this.isFieldTourRequiredNoRadioButton.AutoSize = true;
            this.isFieldTourRequiredNoRadioButton.Location = new System.Drawing.Point(51, 3);
            this.isFieldTourRequiredNoRadioButton.Name = "isFieldTourRequiredNoRadioButton";
            this.isFieldTourRequiredNoRadioButton.Size = new System.Drawing.Size(38, 17);
            this.isFieldTourRequiredNoRadioButton.TabIndex = 1;
            this.isFieldTourRequiredNoRadioButton.TabStop = true;
            this.isFieldTourRequiredNoRadioButton.Text = "No";
            this.isFieldTourRequiredNoRadioButton.UseVisualStyleBackColor = true;
            // 
            // isFieldTourRequiredYesRadioButton
            // 
            this.isFieldTourRequiredYesRadioButton.AutoSize = true;
            this.isFieldTourRequiredYesRadioButton.Location = new System.Drawing.Point(3, 3);
            this.isFieldTourRequiredYesRadioButton.Name = "isFieldTourRequiredYesRadioButton";
            this.isFieldTourRequiredYesRadioButton.Size = new System.Drawing.Size(42, 17);
            this.isFieldTourRequiredYesRadioButton.TabIndex = 0;
            this.isFieldTourRequiredYesRadioButton.TabStop = true;
            this.isFieldTourRequiredYesRadioButton.Text = "Yes";
            this.isFieldTourRequiredYesRadioButton.UseVisualStyleBackColor = true;
            // 
            // oltPanel135
            // 
            this.oltPanel135.Controls.Add(this.oltLabel44);
            this.oltPanel135.Location = new System.Drawing.Point(3, 3);
            this.oltPanel135.Name = "oltPanel135";
            this.oltPanel135.Size = new System.Drawing.Size(440, 24);
            this.oltPanel135.TabIndex = 42;
            // 
            // oltLabel44
            // 
            this.oltLabel44.AutoSize = true;
            this.oltLabel44.Location = new System.Drawing.Point(16, 6);
            this.oltLabel44.Name = "oltLabel44";
            this.oltLabel44.Size = new System.Drawing.Size(378, 13);
            this.oltLabel44.TabIndex = 23;
            this.oltLabel44.Text = "Does the Receiver require a field tour before permitted work can commence ?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "PERMIT AGREEMENT - ISSUANCE";
            // 
            // agreementAndSignaturePanel
            // 
            this.agreementAndSignaturePanel.Controls.Add(this.permitAcceptorField);
            this.agreementAndSignaturePanel.Controls.Add(this.permitAcceptorLabel);
            this.agreementAndSignaturePanel.Location = new System.Drawing.Point(14, 1676);
            this.agreementAndSignaturePanel.Name = "agreementAndSignaturePanel";
            this.agreementAndSignaturePanel.Size = new System.Drawing.Size(940, 34);
            this.agreementAndSignaturePanel.TabIndex = 48;
            // 
            // permitAcceptorField
            // 
            this.permitAcceptorField.Location = new System.Drawing.Point(97, 5);
            this.permitAcceptorField.MaxLength = 30;
            this.permitAcceptorField.Name = "permitAcceptorField";
            this.permitAcceptorField.OltAcceptsReturn = false;
            this.permitAcceptorField.OltTrimWhitespace = true;
            this.permitAcceptorField.Size = new System.Drawing.Size(227, 20);
            this.permitAcceptorField.TabIndex = 35;
            // 
            // permitAcceptorLabel
            // 
            this.permitAcceptorLabel.AutoSize = true;
            this.permitAcceptorLabel.Location = new System.Drawing.Point(9, 8);
            this.permitAcceptorLabel.Name = "permitAcceptorLabel";
            this.permitAcceptorLabel.Size = new System.Drawing.Size(87, 13);
            this.permitAcceptorLabel.TabIndex = 35;
            this.permitAcceptorLabel.Text = "Permit Acceptor:";
            // 
            // atmosphericMoniteringGroupBox
            // 
            this.atmosphericMoniteringGroupBox.Controls.Add(this.testerNameoltTextBox);
            this.atmosphericMoniteringGroupBox.Controls.Add(this.oltLabel3);
            this.atmosphericMoniteringGroupBox.Controls.Add(this.oltPanel9);
            this.atmosphericMoniteringGroupBox.Controls.Add(this.oltPanel8);
            this.atmosphericMoniteringGroupBox.Controls.Add(this.oltPanel7);
            this.atmosphericMoniteringGroupBox.Controls.Add(this.coPpmPartGCheckBox);
            this.atmosphericMoniteringGroupBox.Controls.Add(this.h2sPpmPartGCheckBox);
            this.atmosphericMoniteringGroupBox.Controls.Add(this.so2PpmPartGCheckBox);
            this.atmosphericMoniteringGroupBox.Controls.Add(this.lelPartGCheckBox);
            this.atmosphericMoniteringGroupBox.Controls.Add(this.oxygenPartGCheckBox);
            this.atmosphericMoniteringGroupBox.Controls.Add(this.label6);
            this.atmosphericMoniteringGroupBox.Location = new System.Drawing.Point(14, 1389);
            this.atmosphericMoniteringGroupBox.Name = "atmosphericMoniteringGroupBox";
            this.atmosphericMoniteringGroupBox.Size = new System.Drawing.Size(937, 95);
            this.atmosphericMoniteringGroupBox.TabIndex = 46;
            this.atmosphericMoniteringGroupBox.TabStop = false;
            this.atmosphericMoniteringGroupBox.Text = "PART G";
            // 
            // testerNameoltTextBox
            // 
            this.testerNameoltTextBox.Location = new System.Drawing.Point(396, 34);
            this.testerNameoltTextBox.MaxLength = 12;
            this.testerNameoltTextBox.Name = "testerNameoltTextBox";
            this.testerNameoltTextBox.OltAcceptsReturn = true;
            this.testerNameoltTextBox.OltTrimWhitespace = true;
            this.testerNameoltTextBox.Size = new System.Drawing.Size(181, 20);
            this.testerNameoltTextBox.TabIndex = 66;
            // 
            // oltLabel3
            // 
            this.oltLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel3.Location = new System.Drawing.Point(311, 34);
            this.oltLabel3.Name = "oltLabel3";
            this.oltLabel3.Size = new System.Drawing.Size(82, 19);
            this.oltLabel3.TabIndex = 65;
            this.oltLabel3.Text = "Tester\'s Name :";
            this.oltLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // oltPanel9
            // 
            this.oltPanel9.Controls.Add(this.continuousCheckBox);
            this.oltPanel9.Controls.Add(this.oltLabel1);
            this.oltPanel9.Controls.Add(this.frequencyPartGComboBox);
            this.oltPanel9.Location = new System.Drawing.Point(14, 32);
            this.oltPanel9.Name = "oltPanel9";
            this.oltPanel9.Size = new System.Drawing.Size(277, 25);
            this.oltPanel9.TabIndex = 64;
            // 
            // continuousCheckBox
            // 
            this.continuousCheckBox.AutoSize = true;
            this.continuousCheckBox.Location = new System.Drawing.Point(184, 4);
            this.continuousCheckBox.Name = "continuousCheckBox";
            this.continuousCheckBox.Size = new System.Drawing.Size(80, 17);
            this.continuousCheckBox.TabIndex = 43;
            this.continuousCheckBox.Text = "Contineous";
            this.continuousCheckBox.UseVisualStyleBackColor = true;
            this.continuousCheckBox.Value = null;
            // 
            // oltLabel1
            // 
            this.oltLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltLabel1.Location = new System.Drawing.Point(4, 2);
            this.oltLabel1.Name = "oltLabel1";
            this.oltLabel1.Size = new System.Drawing.Size(65, 21);
            this.oltLabel1.TabIndex = 35;
            this.oltLabel1.Text = "Frequency :";
            this.oltLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frequencyPartGComboBox
            // 
            this.frequencyPartGComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frequencyPartGComboBox.FormattingEnabled = true;
            this.frequencyPartGComboBox.Items.AddRange(new object[] {
            "None",
            "2",
            "4",
            "6",
            "12"});
            this.frequencyPartGComboBox.Location = new System.Drawing.Point(76, 2);
            this.frequencyPartGComboBox.MaxLength = 50;
            this.frequencyPartGComboBox.Name = "frequencyPartGComboBox";
            this.frequencyPartGComboBox.Size = new System.Drawing.Size(71, 21);
            this.frequencyPartGComboBox.TabIndex = 34;
            // 
            // oltPanel8
            // 
            this.oltPanel8.Controls.Add(this.other2PartGTextBox);
            this.oltPanel8.Controls.Add(this.other2PartGCheckBox);
            this.oltPanel8.Location = new System.Drawing.Point(697, 61);
            this.oltPanel8.Name = "oltPanel8";
            this.oltPanel8.Size = new System.Drawing.Size(218, 25);
            this.oltPanel8.TabIndex = 42;
            // 
            // other2PartGTextBox
            // 
            this.other2PartGTextBox.Location = new System.Drawing.Point(73, 3);
            this.other2PartGTextBox.MaxLength = 15;
            this.other2PartGTextBox.Name = "other2PartGTextBox";
            this.other2PartGTextBox.OltAcceptsReturn = true;
            this.other2PartGTextBox.OltTrimWhitespace = true;
            this.other2PartGTextBox.ReadOnly = true;
            this.other2PartGTextBox.Size = new System.Drawing.Size(140, 20);
            this.other2PartGTextBox.TabIndex = 19;
            // 
            // other2PartGCheckBox
            // 
            this.other2PartGCheckBox.AutoSize = true;
            this.other2PartGCheckBox.Location = new System.Drawing.Point(3, 5);
            this.other2PartGCheckBox.Name = "other2PartGCheckBox";
            this.other2PartGCheckBox.Size = new System.Drawing.Size(72, 17);
            this.other2PartGCheckBox.TabIndex = 18;
            this.other2PartGCheckBox.Text = "Others2 :";
            this.other2PartGCheckBox.UseVisualStyleBackColor = true;
            this.other2PartGCheckBox.Value = null;
            // 
            // oltPanel7
            // 
            this.oltPanel7.Controls.Add(this.other1PartGTextBox);
            this.oltPanel7.Controls.Add(this.other1PartGCheckBox);
            this.oltPanel7.Location = new System.Drawing.Point(460, 60);
            this.oltPanel7.Name = "oltPanel7";
            this.oltPanel7.Size = new System.Drawing.Size(215, 25);
            this.oltPanel7.TabIndex = 41;
            // 
            // other1PartGTextBox
            // 
            this.other1PartGTextBox.Location = new System.Drawing.Point(70, 3);
            this.other1PartGTextBox.MaxLength = 15;
            this.other1PartGTextBox.Name = "other1PartGTextBox";
            this.other1PartGTextBox.OltAcceptsReturn = true;
            this.other1PartGTextBox.OltTrimWhitespace = true;
            this.other1PartGTextBox.ReadOnly = true;
            this.other1PartGTextBox.Size = new System.Drawing.Size(140, 20);
            this.other1PartGTextBox.TabIndex = 19;
            // 
            // other1PartGCheckBox
            // 
            this.other1PartGCheckBox.AutoSize = true;
            this.other1PartGCheckBox.Location = new System.Drawing.Point(2, 4);
            this.other1PartGCheckBox.Name = "other1PartGCheckBox";
            this.other1PartGCheckBox.Size = new System.Drawing.Size(72, 17);
            this.other1PartGCheckBox.TabIndex = 18;
            this.other1PartGCheckBox.Text = "Others1 :";
            this.other1PartGCheckBox.UseVisualStyleBackColor = true;
            this.other1PartGCheckBox.Value = null;
            // 
            // coPpmPartGCheckBox
            // 
            this.coPpmPartGCheckBox.AutoSize = true;
            this.coPpmPartGCheckBox.Location = new System.Drawing.Point(283, 66);
            this.coPpmPartGCheckBox.Name = "coPpmPartGCheckBox";
            this.coPpmPartGCheckBox.Size = new System.Drawing.Size(64, 17);
            this.coPpmPartGCheckBox.TabIndex = 39;
            this.coPpmPartGCheckBox.Text = "CO PPM";
            this.coPpmPartGCheckBox.UseVisualStyleBackColor = true;
            this.coPpmPartGCheckBox.Value = null;
            // 
            // h2sPpmPartGCheckBox
            // 
            this.h2sPpmPartGCheckBox.AutoSize = true;
            this.h2sPpmPartGCheckBox.Location = new System.Drawing.Point(196, 66);
            this.h2sPpmPartGCheckBox.Name = "h2sPpmPartGCheckBox";
            this.h2sPpmPartGCheckBox.Size = new System.Drawing.Size(68, 17);
            this.h2sPpmPartGCheckBox.TabIndex = 38;
            this.h2sPpmPartGCheckBox.Text = "H2S PPM";
            this.h2sPpmPartGCheckBox.UseVisualStyleBackColor = true;
            this.h2sPpmPartGCheckBox.Value = null;
            // 
            // so2PpmPartGCheckBox
            // 
            this.so2PpmPartGCheckBox.AutoSize = true;
            this.so2PpmPartGCheckBox.Location = new System.Drawing.Point(372, 65);
            this.so2PpmPartGCheckBox.Name = "so2PpmPartGCheckBox";
            this.so2PpmPartGCheckBox.Size = new System.Drawing.Size(69, 17);
            this.so2PpmPartGCheckBox.TabIndex = 40;
            this.so2PpmPartGCheckBox.Text = "SO2 PPM";
            this.so2PpmPartGCheckBox.UseVisualStyleBackColor = true;
            this.so2PpmPartGCheckBox.Value = null;
            // 
            // lelPartGCheckBox
            // 
            this.lelPartGCheckBox.AutoSize = true;
            this.lelPartGCheckBox.Location = new System.Drawing.Point(120, 65);
            this.lelPartGCheckBox.Name = "lelPartGCheckBox";
            this.lelPartGCheckBox.Size = new System.Drawing.Size(56, 17);
            this.lelPartGCheckBox.TabIndex = 37;
            this.lelPartGCheckBox.Text = "LEL %";
            this.lelPartGCheckBox.UseVisualStyleBackColor = true;
            this.lelPartGCheckBox.Value = null;
            // 
            // oxygenPartGCheckBox
            // 
            this.oxygenPartGCheckBox.AutoSize = true;
            this.oxygenPartGCheckBox.Location = new System.Drawing.Point(17, 65);
            this.oxygenPartGCheckBox.Name = "oxygenPartGCheckBox";
            this.oxygenPartGCheckBox.Size = new System.Drawing.Size(80, 17);
            this.oxygenPartGCheckBox.TabIndex = 36;
            this.oxygenPartGCheckBox.Text = "OXYGEN %";
            this.oxygenPartGCheckBox.UseVisualStyleBackColor = true;
            this.oxygenPartGCheckBox.Value = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(5, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "ATMOSPHERIC MONITERING";
            // 
            // controlOfHazardousenergyGroupBox
            // 
            this.controlOfHazardousenergyGroupBox.Controls.Add(this.nuclearSourceCheckBox);
            this.controlOfHazardousenergyGroupBox.Controls.Add(this.electricallyIsolatedCheckBox);
            this.controlOfHazardousenergyGroupBox.Controls.Add(this.label5);
            this.controlOfHazardousenergyGroupBox.Controls.Add(this.doubleBlockedandBledCheckBox);
            this.controlOfHazardousenergyGroupBox.Controls.Add(this.mechanicallyIsolatedCheckBox);
            this.controlOfHazardousenergyGroupBox.Controls.Add(this.testBumpedCheckBox);
            this.controlOfHazardousenergyGroupBox.Controls.Add(this.blindedOrBlankedCheckBox);
            this.controlOfHazardousenergyGroupBox.Controls.Add(this.drainedAndDepressurisedCheckBox);
            this.controlOfHazardousenergyGroupBox.Controls.Add(this.purgedorNeutralisedCheckBox);
            this.controlOfHazardousenergyGroupBox.Controls.Add(this.receiverStafingRequirementsCheckBox);
            this.controlOfHazardousenergyGroupBox.Location = new System.Drawing.Point(15, 1272);
            this.controlOfHazardousenergyGroupBox.Name = "controlOfHazardousenergyGroupBox";
            this.controlOfHazardousenergyGroupBox.Size = new System.Drawing.Size(936, 96);
            this.controlOfHazardousenergyGroupBox.TabIndex = 45;
            this.controlOfHazardousenergyGroupBox.TabStop = false;
            this.controlOfHazardousenergyGroupBox.Text = "PART F";
            // 
            // nuclearSourceCheckBox
            // 
            this.nuclearSourceCheckBox.AutoSize = true;
            this.nuclearSourceCheckBox.Location = new System.Drawing.Point(392, 63);
            this.nuclearSourceCheckBox.Name = "nuclearSourceCheckBox";
            this.nuclearSourceCheckBox.Size = new System.Drawing.Size(98, 17);
            this.nuclearSourceCheckBox.TabIndex = 43;
            this.nuclearSourceCheckBox.Text = "Nuclear Source";
            this.nuclearSourceCheckBox.UseVisualStyleBackColor = true;
            this.nuclearSourceCheckBox.Value = null;
            // 
            // electricallyIsolatedCheckBox
            // 
            this.electricallyIsolatedCheckBox.AutoSize = true;
            this.electricallyIsolatedCheckBox.Location = new System.Drawing.Point(11, 63);
            this.electricallyIsolatedCheckBox.Name = "electricallyIsolatedCheckBox";
            this.electricallyIsolatedCheckBox.Size = new System.Drawing.Size(118, 17);
            this.electricallyIsolatedCheckBox.TabIndex = 35;
            this.electricallyIsolatedCheckBox.Text = "Electrically Isolated";
            this.electricallyIsolatedCheckBox.UseVisualStyleBackColor = true;
            this.electricallyIsolatedCheckBox.Value = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(9, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(313, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "CONTROL OF HAZARDOUS ENERGY AND SAFING STATUS ";
            // 
            // doubleBlockedandBledCheckBox
            // 
            this.doubleBlockedandBledCheckBox.AutoSize = true;
            this.doubleBlockedandBledCheckBox.Location = new System.Drawing.Point(391, 38);
            this.doubleBlockedandBledCheckBox.Name = "doubleBlockedandBledCheckBox";
            this.doubleBlockedandBledCheckBox.Size = new System.Drawing.Size(142, 17);
            this.doubleBlockedandBledCheckBox.TabIndex = 36;
            this.doubleBlockedandBledCheckBox.Text = "Double Blocked and Bled";
            this.doubleBlockedandBledCheckBox.UseVisualStyleBackColor = true;
            this.doubleBlockedandBledCheckBox.Value = null;
            // 
            // mechanicallyIsolatedCheckBox
            // 
            this.mechanicallyIsolatedCheckBox.AutoSize = true;
            this.mechanicallyIsolatedCheckBox.Location = new System.Drawing.Point(10, 38);
            this.mechanicallyIsolatedCheckBox.Name = "mechanicallyIsolatedCheckBox";
            this.mechanicallyIsolatedCheckBox.Size = new System.Drawing.Size(128, 17);
            this.mechanicallyIsolatedCheckBox.TabIndex = 38;
            this.mechanicallyIsolatedCheckBox.Text = "Mechanically Isolated";
            this.mechanicallyIsolatedCheckBox.UseVisualStyleBackColor = true;
            this.mechanicallyIsolatedCheckBox.Value = null;
            // 
            // testBumpedCheckBox
            // 
            this.testBumpedCheckBox.AutoSize = true;
            this.testBumpedCheckBox.Location = new System.Drawing.Point(232, 63);
            this.testBumpedCheckBox.Name = "testBumpedCheckBox";
            this.testBumpedCheckBox.Size = new System.Drawing.Size(88, 17);
            this.testBumpedCheckBox.TabIndex = 37;
            this.testBumpedCheckBox.Text = "Test Bumped";
            this.testBumpedCheckBox.UseVisualStyleBackColor = true;
            this.testBumpedCheckBox.Value = null;
            // 
            // blindedOrBlankedCheckBox
            // 
            this.blindedOrBlankedCheckBox.AutoSize = true;
            this.blindedOrBlankedCheckBox.Location = new System.Drawing.Point(232, 38);
            this.blindedOrBlankedCheckBox.Name = "blindedOrBlankedCheckBox";
            this.blindedOrBlankedCheckBox.Size = new System.Drawing.Size(115, 17);
            this.blindedOrBlankedCheckBox.TabIndex = 39;
            this.blindedOrBlankedCheckBox.Text = "Blinded Or Blanked";
            this.blindedOrBlankedCheckBox.UseVisualStyleBackColor = true;
            this.blindedOrBlankedCheckBox.Value = null;
            // 
            // drainedAndDepressurisedCheckBox
            // 
            this.drainedAndDepressurisedCheckBox.AutoSize = true;
            this.drainedAndDepressurisedCheckBox.Location = new System.Drawing.Point(588, 38);
            this.drainedAndDepressurisedCheckBox.Name = "drainedAndDepressurisedCheckBox";
            this.drainedAndDepressurisedCheckBox.Size = new System.Drawing.Size(156, 17);
            this.drainedAndDepressurisedCheckBox.TabIndex = 42;
            this.drainedAndDepressurisedCheckBox.Text = "Drained And Depressurised";
            this.drainedAndDepressurisedCheckBox.UseVisualStyleBackColor = true;
            this.drainedAndDepressurisedCheckBox.Value = null;
            // 
            // purgedorNeutralisedCheckBox
            // 
            this.purgedorNeutralisedCheckBox.AutoSize = true;
            this.purgedorNeutralisedCheckBox.Location = new System.Drawing.Point(760, 38);
            this.purgedorNeutralisedCheckBox.Name = "purgedorNeutralisedCheckBox";
            this.purgedorNeutralisedCheckBox.Size = new System.Drawing.Size(130, 17);
            this.purgedorNeutralisedCheckBox.TabIndex = 40;
            this.purgedorNeutralisedCheckBox.Text = "Purged or Neutralised";
            this.purgedorNeutralisedCheckBox.UseVisualStyleBackColor = true;
            this.purgedorNeutralisedCheckBox.Value = null;
            // 
            // receiverStafingRequirementsCheckBox
            // 
            this.receiverStafingRequirementsCheckBox.AutoSize = true;
            this.receiverStafingRequirementsCheckBox.Location = new System.Drawing.Point(589, 63);
            this.receiverStafingRequirementsCheckBox.Name = "receiverStafingRequirementsCheckBox";
            this.receiverStafingRequirementsCheckBox.Size = new System.Drawing.Size(174, 17);
            this.receiverStafingRequirementsCheckBox.TabIndex = 41;
            this.receiverStafingRequirementsCheckBox.Text = "Receiver Stafing Requirements";
            this.receiverStafingRequirementsCheckBox.UseVisualStyleBackColor = true;
            this.receiverStafingRequirementsCheckBox.Value = null;
            // 
            // workAuthorizationAndDocumentationGroupBox
            // 
            this.workAuthorizationAndDocumentationGroupBox.Controls.Add(this.oltPanel5);
            this.workAuthorizationAndDocumentationGroupBox.Controls.Add(this.oltPanel6);
            this.workAuthorizationAndDocumentationGroupBox.Controls.Add(this.label3);
            this.workAuthorizationAndDocumentationGroupBox.Controls.Add(this.electricalEncroachmentCheckBox);
            this.workAuthorizationAndDocumentationGroupBox.Controls.Add(this.fireProtectionAuthorizationCheckBox);
            this.workAuthorizationAndDocumentationGroupBox.Controls.Add(this.mSDSCheckBox);
            this.workAuthorizationAndDocumentationGroupBox.Controls.Add(this.industrialRadiographyCheckBox);
            this.workAuthorizationAndDocumentationGroupBox.Controls.Add(this.vehicleEntryCheckBox);
            this.workAuthorizationAndDocumentationGroupBox.Controls.Add(this.criticalOrSeriousLiftsCheckBox);
            this.workAuthorizationAndDocumentationGroupBox.Controls.Add(this.groundDisturbanceCheckBox);
            this.workAuthorizationAndDocumentationGroupBox.Location = new System.Drawing.Point(15, 1160);
            this.workAuthorizationAndDocumentationGroupBox.Name = "workAuthorizationAndDocumentationGroupBox";
            this.workAuthorizationAndDocumentationGroupBox.Size = new System.Drawing.Size(936, 92);
            this.workAuthorizationAndDocumentationGroupBox.TabIndex = 43;
            this.workAuthorizationAndDocumentationGroupBox.TabStop = false;
            this.workAuthorizationAndDocumentationGroupBox.Text = "PART E";
            // 
            // oltPanel5
            // 
            this.oltPanel5.Controls.Add(this.confinedSpaceCheckBox);
            this.oltPanel5.Controls.Add(this.confinedSpaceClassComboBox);
            this.oltPanel5.Location = new System.Drawing.Point(7, 32);
            this.oltPanel5.Name = "oltPanel5";
            this.oltPanel5.Size = new System.Drawing.Size(200, 30);
            this.oltPanel5.TabIndex = 39;
            // 
            // confinedSpaceCheckBox
            // 
            this.confinedSpaceCheckBox.AutoSize = true;
            this.confinedSpaceCheckBox.Location = new System.Drawing.Point(2, 7);
            this.confinedSpaceCheckBox.Name = "confinedSpaceCheckBox";
            this.confinedSpaceCheckBox.Size = new System.Drawing.Size(101, 17);
            this.confinedSpaceCheckBox.TabIndex = 38;
            this.confinedSpaceCheckBox.Text = "Confined Space";
            this.confinedSpaceCheckBox.UseVisualStyleBackColor = true;
            this.confinedSpaceCheckBox.Value = null;
            // 
            // confinedSpaceClassComboBox
            // 
            this.confinedSpaceClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.confinedSpaceClassComboBox.FormattingEnabled = true;
            this.confinedSpaceClassComboBox.Location = new System.Drawing.Point(114, 5);
            this.confinedSpaceClassComboBox.Name = "confinedSpaceClassComboBox";
            this.confinedSpaceClassComboBox.Size = new System.Drawing.Size(50, 21);
            this.confinedSpaceClassComboBox.TabIndex = 37;
            // 
            // oltPanel6
            // 
            this.oltPanel6.Controls.Add(this.othersPartETextBox);
            this.oltPanel6.Controls.Add(this.othersPartECheckBox);
            this.oltPanel6.Location = new System.Drawing.Point(588, 62);
            this.oltPanel6.Name = "oltPanel6";
            this.oltPanel6.Size = new System.Drawing.Size(215, 24);
            this.oltPanel6.TabIndex = 38;
            // 
            // othersPartETextBox
            // 
            this.othersPartETextBox.Location = new System.Drawing.Point(57, 3);
            this.othersPartETextBox.MaxLength = 15;
            this.othersPartETextBox.Name = "othersPartETextBox";
            this.othersPartETextBox.OltAcceptsReturn = true;
            this.othersPartETextBox.OltTrimWhitespace = true;
            this.othersPartETextBox.ReadOnly = true;
            this.othersPartETextBox.Size = new System.Drawing.Size(140, 20);
            this.othersPartETextBox.TabIndex = 1;
            // 
            // othersPartECheckBox
            // 
            this.othersPartECheckBox.AutoSize = true;
            this.othersPartECheckBox.Location = new System.Drawing.Point(3, 5);
            this.othersPartECheckBox.Name = "othersPartECheckBox";
            this.othersPartECheckBox.Size = new System.Drawing.Size(54, 17);
            this.othersPartECheckBox.TabIndex = 0;
            this.othersPartECheckBox.Text = "Other";
            this.othersPartECheckBox.UseVisualStyleBackColor = true;
            this.othersPartECheckBox.Value = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(5, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "WORK AUTHORIZATION AND OR DOCUMENTATION ";
            // 
            // electricalEncroachmentCheckBox
            // 
            this.electricalEncroachmentCheckBox.AutoSize = true;
            this.electricalEncroachmentCheckBox.Location = new System.Drawing.Point(231, 66);
            this.electricalEncroachmentCheckBox.Name = "electricalEncroachmentCheckBox";
            this.electricalEncroachmentCheckBox.Size = new System.Drawing.Size(139, 17);
            this.electricalEncroachmentCheckBox.TabIndex = 0;
            this.electricalEncroachmentCheckBox.Text = "Electrical Encroachment";
            this.electricalEncroachmentCheckBox.UseVisualStyleBackColor = true;
            this.electricalEncroachmentCheckBox.Value = null;
            // 
            // fireProtectionAuthorizationCheckBox
            // 
            this.fireProtectionAuthorizationCheckBox.AutoSize = true;
            this.fireProtectionAuthorizationCheckBox.Location = new System.Drawing.Point(390, 39);
            this.fireProtectionAuthorizationCheckBox.Name = "fireProtectionAuthorizationCheckBox";
            this.fireProtectionAuthorizationCheckBox.Size = new System.Drawing.Size(166, 17);
            this.fireProtectionAuthorizationCheckBox.TabIndex = 0;
            this.fireProtectionAuthorizationCheckBox.Text = "Fire Protection Authorization ";
            this.fireProtectionAuthorizationCheckBox.UseVisualStyleBackColor = true;
            this.fireProtectionAuthorizationCheckBox.Value = null;
            // 
            // mSDSCheckBox
            // 
            this.mSDSCheckBox.AutoSize = true;
            this.mSDSCheckBox.Location = new System.Drawing.Point(390, 66);
            this.mSDSCheckBox.Name = "mSDSCheckBox";
            this.mSDSCheckBox.Size = new System.Drawing.Size(53, 17);
            this.mSDSCheckBox.TabIndex = 17;
            this.mSDSCheckBox.Text = "MSDS";
            this.mSDSCheckBox.UseVisualStyleBackColor = true;
            this.mSDSCheckBox.Value = null;
            // 
            // industrialRadiographyCheckBox
            // 
            this.industrialRadiographyCheckBox.AutoSize = true;
            this.industrialRadiographyCheckBox.Location = new System.Drawing.Point(8, 66);
            this.industrialRadiographyCheckBox.Name = "industrialRadiographyCheckBox";
            this.industrialRadiographyCheckBox.Size = new System.Drawing.Size(138, 17);
            this.industrialRadiographyCheckBox.TabIndex = 30;
            this.industrialRadiographyCheckBox.Text = "Industrial Radiography ";
            this.industrialRadiographyCheckBox.UseVisualStyleBackColor = true;
            this.industrialRadiographyCheckBox.Value = null;
            // 
            // vehicleEntryCheckBox
            // 
            this.vehicleEntryCheckBox.AutoSize = true;
            this.vehicleEntryCheckBox.Location = new System.Drawing.Point(798, 39);
            this.vehicleEntryCheckBox.Name = "vehicleEntryCheckBox";
            this.vehicleEntryCheckBox.Size = new System.Drawing.Size(88, 17);
            this.vehicleEntryCheckBox.TabIndex = 29;
            this.vehicleEntryCheckBox.Text = "Vehicle Entry";
            this.vehicleEntryCheckBox.UseVisualStyleBackColor = true;
            this.vehicleEntryCheckBox.Value = null;
            // 
            // criticalOrSeriousLiftsCheckBox
            // 
            this.criticalOrSeriousLiftsCheckBox.AutoSize = true;
            this.criticalOrSeriousLiftsCheckBox.Location = new System.Drawing.Point(588, 39);
            this.criticalOrSeriousLiftsCheckBox.Name = "criticalOrSeriousLiftsCheckBox";
            this.criticalOrSeriousLiftsCheckBox.Size = new System.Drawing.Size(137, 17);
            this.criticalOrSeriousLiftsCheckBox.TabIndex = 28;
            this.criticalOrSeriousLiftsCheckBox.Text = "Critical Or Serious Lifts ";
            this.criticalOrSeriousLiftsCheckBox.UseVisualStyleBackColor = true;
            this.criticalOrSeriousLiftsCheckBox.Value = null;
            // 
            // groundDisturbanceCheckBox
            // 
            this.groundDisturbanceCheckBox.AutoSize = true;
            this.groundDisturbanceCheckBox.Location = new System.Drawing.Point(232, 39);
            this.groundDisturbanceCheckBox.Name = "groundDisturbanceCheckBox";
            this.groundDisturbanceCheckBox.Size = new System.Drawing.Size(124, 17);
            this.groundDisturbanceCheckBox.TabIndex = 26;
            this.groundDisturbanceCheckBox.Text = "Ground Disturbance ";
            this.groundDisturbanceCheckBox.UseVisualStyleBackColor = true;
            this.groundDisturbanceCheckBox.Value = null;
            // 
            // safetyPrecautionsHazardousGroupBox
            // 
            this.safetyPrecautionsHazardousGroupBox.Controls.Add(this.label4);
            this.safetyPrecautionsHazardousGroupBox.Controls.Add(this.hazardsAndOrRequirementsTextBox);
            this.safetyPrecautionsHazardousGroupBox.Location = new System.Drawing.Point(14, 1000);
            this.safetyPrecautionsHazardousGroupBox.Name = "safetyPrecautionsHazardousGroupBox";
            this.safetyPrecautionsHazardousGroupBox.Size = new System.Drawing.Size(937, 141);
            this.safetyPrecautionsHazardousGroupBox.TabIndex = 42;
            this.safetyPrecautionsHazardousGroupBox.TabStop = false;
            this.safetyPrecautionsHazardousGroupBox.Text = "PART D";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "SAFETY PRECAUTIONS / HAZARDOUS";
            // 
            // hazardsAndOrRequirementsTextBox
            // 
            this.hazardsAndOrRequirementsTextBox.AcceptsTabAndReturn = true;
            this.hazardsAndOrRequirementsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hazardsAndOrRequirementsTextBox.Location = new System.Drawing.Point(3, 34);
            this.hazardsAndOrRequirementsTextBox.MaxLength = 2000;
            this.hazardsAndOrRequirementsTextBox.Name = "hazardsAndOrRequirementsTextBox";
            this.hazardsAndOrRequirementsTextBox.OltTrimWhitespace = true;
            this.hazardsAndOrRequirementsTextBox.ReadOnly = false;
            this.hazardsAndOrRequirementsTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.hazardsAndOrRequirementsTextBox.Size = new System.Drawing.Size(918, 101);
            this.hazardsAndOrRequirementsTextBox.TabIndex = 0;
            // 
            // specialSafetyEquipmentRequirementGroupBox
            // 
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.safetyGlovesCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.hearingProtectionCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.communicationDeviceCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.label2);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.oltPanel2);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.oltPanel3);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.oltPanel4);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.faceShieldCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.fallProtectionCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.chargedFireHouseCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.coveredSewerCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.airPurifyingRespiratorCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.singalPersonCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.reflectiveStripsCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.monoGogglesCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.fireblanketCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.fireExtinguisherCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.sparkContainmentCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.fireWatchCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.standbyPersonCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.workingAloneCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.personalFlotationDeviceCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.airMoverCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.suppliedBreathingAirCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.confinedSpaceMoniterCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.bottleWatchCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.chemicalSuitCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Controls.Add(this.flameResistantWorkWearCheckBox);
            this.specialSafetyEquipmentRequirementGroupBox.Location = new System.Drawing.Point(13, 719);
            this.specialSafetyEquipmentRequirementGroupBox.Name = "specialSafetyEquipmentRequirementGroupBox";
            this.specialSafetyEquipmentRequirementGroupBox.Size = new System.Drawing.Size(938, 260);
            this.specialSafetyEquipmentRequirementGroupBox.TabIndex = 41;
            this.specialSafetyEquipmentRequirementGroupBox.TabStop = false;
            this.specialSafetyEquipmentRequirementGroupBox.Text = "PART C";
            // 
            // safetyGlovesCheckBox
            // 
            this.safetyGlovesCheckBox.AutoSize = true;
            this.safetyGlovesCheckBox.Location = new System.Drawing.Point(354, 196);
            this.safetyGlovesCheckBox.Name = "safetyGlovesCheckBox";
            this.safetyGlovesCheckBox.Size = new System.Drawing.Size(93, 17);
            this.safetyGlovesCheckBox.TabIndex = 17;
            this.safetyGlovesCheckBox.Text = "Safety Gloves";
            this.safetyGlovesCheckBox.UseVisualStyleBackColor = true;
            this.safetyGlovesCheckBox.Value = null;
            // 
            // hearingProtectionCheckBox
            // 
            this.hearingProtectionCheckBox.AutoSize = true;
            this.hearingProtectionCheckBox.Location = new System.Drawing.Point(7, 196);
            this.hearingProtectionCheckBox.Name = "hearingProtectionCheckBox";
            this.hearingProtectionCheckBox.Size = new System.Drawing.Size(115, 17);
            this.hearingProtectionCheckBox.TabIndex = 7;
            this.hearingProtectionCheckBox.Text = "Hearing Protection";
            this.hearingProtectionCheckBox.UseVisualStyleBackColor = true;
            this.hearingProtectionCheckBox.Value = null;
            // 
            // communicationDeviceCheckBox
            // 
            this.communicationDeviceCheckBox.AutoSize = true;
            this.communicationDeviceCheckBox.Location = new System.Drawing.Point(645, 174);
            this.communicationDeviceCheckBox.Name = "communicationDeviceCheckBox";
            this.communicationDeviceCheckBox.Size = new System.Drawing.Size(133, 17);
            this.communicationDeviceCheckBox.TabIndex = 26;
            this.communicationDeviceCheckBox.Text = "Communication Device";
            this.communicationDeviceCheckBox.UseVisualStyleBackColor = true;
            this.communicationDeviceCheckBox.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(5, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "SPECIAL SAFETY EQUIPMENT REQUIREMENT";
            // 
            // oltPanel2
            // 
            this.oltPanel2.Controls.Add(this.other3TextBox);
            this.oltPanel2.Controls.Add(this.other3CheckBox);
            this.oltPanel2.Location = new System.Drawing.Point(645, 217);
            this.oltPanel2.Name = "oltPanel2";
            this.oltPanel2.Size = new System.Drawing.Size(215, 24);
            this.oltPanel2.TabIndex = 24;
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
            this.other3TextBox.TabIndex = 29;
            // 
            // other3CheckBox
            // 
            this.other3CheckBox.AutoSize = true;
            this.other3CheckBox.Location = new System.Drawing.Point(3, 4);
            this.other3CheckBox.Name = "other3CheckBox";
            this.other3CheckBox.Size = new System.Drawing.Size(54, 17);
            this.other3CheckBox.TabIndex = 28;
            this.other3CheckBox.Text = "Other";
            this.other3CheckBox.UseVisualStyleBackColor = true;
            this.other3CheckBox.Value = null;
            // 
            // oltPanel3
            // 
            this.oltPanel3.Controls.Add(this.other2TextBox);
            this.oltPanel3.Controls.Add(this.other2CheckBox);
            this.oltPanel3.Location = new System.Drawing.Point(354, 217);
            this.oltPanel3.Name = "oltPanel3";
            this.oltPanel3.Size = new System.Drawing.Size(215, 24);
            this.oltPanel3.TabIndex = 15;
            // 
            // other2TextBox
            // 
            this.other2TextBox.Location = new System.Drawing.Point(57, 3);
            this.other2TextBox.MaxLength = 15;
            this.other2TextBox.Name = "other2TextBox";
            this.other2TextBox.OltAcceptsReturn = true;
            this.other2TextBox.OltTrimWhitespace = true;
            this.other2TextBox.ReadOnly = true;
            this.other2TextBox.Size = new System.Drawing.Size(140, 20);
            this.other2TextBox.TabIndex = 19;
            // 
            // other2CheckBox
            // 
            this.other2CheckBox.AutoSize = true;
            this.other2CheckBox.Location = new System.Drawing.Point(3, 5);
            this.other2CheckBox.Name = "other2CheckBox";
            this.other2CheckBox.Size = new System.Drawing.Size(54, 17);
            this.other2CheckBox.TabIndex = 18;
            this.other2CheckBox.Text = "Other";
            this.other2CheckBox.UseVisualStyleBackColor = true;
            this.other2CheckBox.Value = null;
            // 
            // oltPanel4
            // 
            this.oltPanel4.Controls.Add(this.other1TextBox);
            this.oltPanel4.Controls.Add(this.other1CheckBox);
            this.oltPanel4.Location = new System.Drawing.Point(3, 217);
            this.oltPanel4.Name = "oltPanel4";
            this.oltPanel4.Size = new System.Drawing.Size(215, 24);
            this.oltPanel4.TabIndex = 7;
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
            this.other1TextBox.TabIndex = 9;
            // 
            // other1CheckBox
            // 
            this.other1CheckBox.AutoSize = true;
            this.other1CheckBox.Location = new System.Drawing.Point(3, 4);
            this.other1CheckBox.Name = "other1CheckBox";
            this.other1CheckBox.Size = new System.Drawing.Size(54, 17);
            this.other1CheckBox.TabIndex = 8;
            this.other1CheckBox.Text = "Other";
            this.other1CheckBox.UseVisualStyleBackColor = true;
            this.other1CheckBox.Value = null;
            // 
            // faceShieldCheckBox
            // 
            this.faceShieldCheckBox.AutoSize = true;
            this.faceShieldCheckBox.Location = new System.Drawing.Point(647, 36);
            this.faceShieldCheckBox.Name = "faceShieldCheckBox";
            this.faceShieldCheckBox.Size = new System.Drawing.Size(80, 17);
            this.faceShieldCheckBox.TabIndex = 20;
            this.faceShieldCheckBox.Text = "Face Shield";
            this.faceShieldCheckBox.UseVisualStyleBackColor = true;
            this.faceShieldCheckBox.Value = null;
            // 
            // fallProtectionCheckBox
            // 
            this.fallProtectionCheckBox.AutoSize = true;
            this.fallProtectionCheckBox.Location = new System.Drawing.Point(647, 59);
            this.fallProtectionCheckBox.Name = "fallProtectionCheckBox";
            this.fallProtectionCheckBox.Size = new System.Drawing.Size(94, 17);
            this.fallProtectionCheckBox.TabIndex = 21;
            this.fallProtectionCheckBox.Text = "Fall Protection";
            this.fallProtectionCheckBox.UseVisualStyleBackColor = true;
            this.fallProtectionCheckBox.Value = null;
            // 
            // chargedFireHouseCheckBox
            // 
            this.chargedFireHouseCheckBox.AutoSize = true;
            this.chargedFireHouseCheckBox.Location = new System.Drawing.Point(647, 82);
            this.chargedFireHouseCheckBox.Name = "chargedFireHouseCheckBox";
            this.chargedFireHouseCheckBox.Size = new System.Drawing.Size(121, 17);
            this.chargedFireHouseCheckBox.TabIndex = 22;
            this.chargedFireHouseCheckBox.Text = "Charged Fire House";
            this.chargedFireHouseCheckBox.UseVisualStyleBackColor = true;
            this.chargedFireHouseCheckBox.Value = null;
            // 
            // coveredSewerCheckBox
            // 
            this.coveredSewerCheckBox.AutoSize = true;
            this.coveredSewerCheckBox.Location = new System.Drawing.Point(647, 105);
            this.coveredSewerCheckBox.Name = "coveredSewerCheckBox";
            this.coveredSewerCheckBox.Size = new System.Drawing.Size(100, 17);
            this.coveredSewerCheckBox.TabIndex = 23;
            this.coveredSewerCheckBox.Text = "Covered Sewer";
            this.coveredSewerCheckBox.UseVisualStyleBackColor = true;
            this.coveredSewerCheckBox.Value = null;
            // 
            // airPurifyingRespiratorCheckBox
            // 
            this.airPurifyingRespiratorCheckBox.AutoSize = true;
            this.airPurifyingRespiratorCheckBox.Location = new System.Drawing.Point(647, 128);
            this.airPurifyingRespiratorCheckBox.Name = "airPurifyingRespiratorCheckBox";
            this.airPurifyingRespiratorCheckBox.Size = new System.Drawing.Size(137, 17);
            this.airPurifyingRespiratorCheckBox.TabIndex = 24;
            this.airPurifyingRespiratorCheckBox.Text = "Air Purifying Respirator";
            this.airPurifyingRespiratorCheckBox.UseVisualStyleBackColor = true;
            this.airPurifyingRespiratorCheckBox.Value = null;
            // 
            // singalPersonCheckBox
            // 
            this.singalPersonCheckBox.AutoSize = true;
            this.singalPersonCheckBox.Location = new System.Drawing.Point(647, 151);
            this.singalPersonCheckBox.Name = "singalPersonCheckBox";
            this.singalPersonCheckBox.Size = new System.Drawing.Size(90, 17);
            this.singalPersonCheckBox.TabIndex = 25;
            this.singalPersonCheckBox.Text = "Singal Person";
            this.singalPersonCheckBox.UseVisualStyleBackColor = true;
            this.singalPersonCheckBox.Value = null;
            // 
            // reflectiveStripsCheckBox
            // 
            this.reflectiveStripsCheckBox.AutoSize = true;
            this.reflectiveStripsCheckBox.Location = new System.Drawing.Point(647, 197);
            this.reflectiveStripsCheckBox.Name = "reflectiveStripsCheckBox";
            this.reflectiveStripsCheckBox.Size = new System.Drawing.Size(104, 17);
            this.reflectiveStripsCheckBox.TabIndex = 27;
            this.reflectiveStripsCheckBox.Text = "Reflective Strips";
            this.reflectiveStripsCheckBox.UseVisualStyleBackColor = true;
            this.reflectiveStripsCheckBox.Value = null;
            // 
            // monoGogglesCheckBox
            // 
            this.monoGogglesCheckBox.AutoSize = true;
            this.monoGogglesCheckBox.Location = new System.Drawing.Point(357, 36);
            this.monoGogglesCheckBox.Name = "monoGogglesCheckBox";
            this.monoGogglesCheckBox.Size = new System.Drawing.Size(93, 17);
            this.monoGogglesCheckBox.TabIndex = 10;
            this.monoGogglesCheckBox.Text = "Mono Goggles";
            this.monoGogglesCheckBox.UseVisualStyleBackColor = true;
            this.monoGogglesCheckBox.Value = null;
            // 
            // fireblanketCheckBox
            // 
            this.fireblanketCheckBox.AutoSize = true;
            this.fireblanketCheckBox.Location = new System.Drawing.Point(8, 105);
            this.fireblanketCheckBox.Name = "fireblanketCheckBox";
            this.fireblanketCheckBox.Size = new System.Drawing.Size(82, 17);
            this.fireblanketCheckBox.TabIndex = 3;
            this.fireblanketCheckBox.Text = "Fire Blanket";
            this.fireblanketCheckBox.UseVisualStyleBackColor = true;
            this.fireblanketCheckBox.Value = null;
            // 
            // fireExtinguisherCheckBox
            // 
            this.fireExtinguisherCheckBox.AutoSize = true;
            this.fireExtinguisherCheckBox.Location = new System.Drawing.Point(356, 82);
            this.fireExtinguisherCheckBox.Name = "fireExtinguisherCheckBox";
            this.fireExtinguisherCheckBox.Size = new System.Drawing.Size(106, 17);
            this.fireExtinguisherCheckBox.TabIndex = 12;
            this.fireExtinguisherCheckBox.Text = "Fire Extinguisher";
            this.fireExtinguisherCheckBox.UseVisualStyleBackColor = true;
            this.fireExtinguisherCheckBox.Value = null;
            // 
            // sparkContainmentCheckBox
            // 
            this.sparkContainmentCheckBox.AutoSize = true;
            this.sparkContainmentCheckBox.Location = new System.Drawing.Point(356, 105);
            this.sparkContainmentCheckBox.Name = "sparkContainmentCheckBox";
            this.sparkContainmentCheckBox.Size = new System.Drawing.Size(117, 17);
            this.sparkContainmentCheckBox.TabIndex = 13;
            this.sparkContainmentCheckBox.Text = "Spark Containment";
            this.sparkContainmentCheckBox.UseVisualStyleBackColor = true;
            this.sparkContainmentCheckBox.Value = null;
            // 
            // fireWatchCheckBox
            // 
            this.fireWatchCheckBox.AutoSize = true;
            this.fireWatchCheckBox.Location = new System.Drawing.Point(8, 82);
            this.fireWatchCheckBox.Name = "fireWatchCheckBox";
            this.fireWatchCheckBox.Size = new System.Drawing.Size(78, 17);
            this.fireWatchCheckBox.TabIndex = 2;
            this.fireWatchCheckBox.Text = "Fire Watch";
            this.fireWatchCheckBox.UseVisualStyleBackColor = true;
            this.fireWatchCheckBox.Value = null;
            // 
            // standbyPersonCheckBox
            // 
            this.standbyPersonCheckBox.AutoSize = true;
            this.standbyPersonCheckBox.Location = new System.Drawing.Point(356, 151);
            this.standbyPersonCheckBox.Name = "standbyPersonCheckBox";
            this.standbyPersonCheckBox.Size = new System.Drawing.Size(102, 17);
            this.standbyPersonCheckBox.TabIndex = 15;
            this.standbyPersonCheckBox.Text = "Standby Person";
            this.standbyPersonCheckBox.UseVisualStyleBackColor = true;
            this.standbyPersonCheckBox.Value = null;
            // 
            // workingAloneCheckBox
            // 
            this.workingAloneCheckBox.AutoSize = true;
            this.workingAloneCheckBox.Location = new System.Drawing.Point(356, 174);
            this.workingAloneCheckBox.Name = "workingAloneCheckBox";
            this.workingAloneCheckBox.Size = new System.Drawing.Size(95, 17);
            this.workingAloneCheckBox.TabIndex = 16;
            this.workingAloneCheckBox.Text = "Working Alone";
            this.workingAloneCheckBox.UseVisualStyleBackColor = true;
            this.workingAloneCheckBox.Value = null;
            // 
            // personalFlotationDeviceCheckBox
            // 
            this.personalFlotationDeviceCheckBox.AutoSize = true;
            this.personalFlotationDeviceCheckBox.Location = new System.Drawing.Point(8, 174);
            this.personalFlotationDeviceCheckBox.Name = "personalFlotationDeviceCheckBox";
            this.personalFlotationDeviceCheckBox.Size = new System.Drawing.Size(147, 17);
            this.personalFlotationDeviceCheckBox.TabIndex = 6;
            this.personalFlotationDeviceCheckBox.Text = "Personal Flotation Device";
            this.personalFlotationDeviceCheckBox.UseVisualStyleBackColor = true;
            this.personalFlotationDeviceCheckBox.Value = null;
            // 
            // airMoverCheckBox
            // 
            this.airMoverCheckBox.AutoSize = true;
            this.airMoverCheckBox.Location = new System.Drawing.Point(8, 151);
            this.airMoverCheckBox.Name = "airMoverCheckBox";
            this.airMoverCheckBox.Size = new System.Drawing.Size(72, 17);
            this.airMoverCheckBox.TabIndex = 5;
            this.airMoverCheckBox.Text = "Air Mover";
            this.airMoverCheckBox.UseVisualStyleBackColor = true;
            this.airMoverCheckBox.Value = null;
            // 
            // suppliedBreathingAirCheckBox
            // 
            this.suppliedBreathingAirCheckBox.AutoSize = true;
            this.suppliedBreathingAirCheckBox.Location = new System.Drawing.Point(8, 128);
            this.suppliedBreathingAirCheckBox.Name = "suppliedBreathingAirCheckBox";
            this.suppliedBreathingAirCheckBox.Size = new System.Drawing.Size(131, 17);
            this.suppliedBreathingAirCheckBox.TabIndex = 4;
            this.suppliedBreathingAirCheckBox.Text = "Supplied Breathing Air";
            this.suppliedBreathingAirCheckBox.UseVisualStyleBackColor = true;
            this.suppliedBreathingAirCheckBox.Value = null;
            // 
            // confinedSpaceMoniterCheckBox
            // 
            this.confinedSpaceMoniterCheckBox.AutoSize = true;
            this.confinedSpaceMoniterCheckBox.Location = new System.Drawing.Point(357, 59);
            this.confinedSpaceMoniterCheckBox.Name = "confinedSpaceMoniterCheckBox";
            this.confinedSpaceMoniterCheckBox.Size = new System.Drawing.Size(140, 17);
            this.confinedSpaceMoniterCheckBox.TabIndex = 11;
            this.confinedSpaceMoniterCheckBox.Text = "Confined Space Moniter";
            this.confinedSpaceMoniterCheckBox.UseVisualStyleBackColor = true;
            this.confinedSpaceMoniterCheckBox.Value = null;
            // 
            // bottleWatchCheckBox
            // 
            this.bottleWatchCheckBox.AutoSize = true;
            this.bottleWatchCheckBox.Location = new System.Drawing.Point(356, 128);
            this.bottleWatchCheckBox.Name = "bottleWatchCheckBox";
            this.bottleWatchCheckBox.Size = new System.Drawing.Size(88, 17);
            this.bottleWatchCheckBox.TabIndex = 14;
            this.bottleWatchCheckBox.Text = "Bottle Watch";
            this.bottleWatchCheckBox.UseVisualStyleBackColor = true;
            this.bottleWatchCheckBox.Value = null;
            // 
            // chemicalSuitCheckBox
            // 
            this.chemicalSuitCheckBox.AutoSize = true;
            this.chemicalSuitCheckBox.Location = new System.Drawing.Point(8, 59);
            this.chemicalSuitCheckBox.Name = "chemicalSuitCheckBox";
            this.chemicalSuitCheckBox.Size = new System.Drawing.Size(89, 17);
            this.chemicalSuitCheckBox.TabIndex = 1;
            this.chemicalSuitCheckBox.Text = "Chemical Suit";
            this.chemicalSuitCheckBox.UseVisualStyleBackColor = true;
            this.chemicalSuitCheckBox.Value = null;
            // 
            // flameResistantWorkWearCheckBox
            // 
            this.flameResistantWorkWearCheckBox.AutoSize = true;
            this.flameResistantWorkWearCheckBox.Location = new System.Drawing.Point(8, 36);
            this.flameResistantWorkWearCheckBox.Name = "flameResistantWorkWearCheckBox";
            this.flameResistantWorkWearCheckBox.Size = new System.Drawing.Size(159, 17);
            this.flameResistantWorkWearCheckBox.TabIndex = 0;
            this.flameResistantWorkWearCheckBox.Text = "Flame Resistant Work Wear";
            this.flameResistantWorkWearCheckBox.UseVisualStyleBackColor = true;
            this.flameResistantWorkWearCheckBox.Value = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.currentSAPDescriptionGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.taskDescriptionGroupBox, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 396);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(943, 303);
            this.tableLayoutPanel1.TabIndex = 40;
            // 
            // currentSAPDescriptionGroupBox
            // 
            this.currentSAPDescriptionGroupBox.Controls.Add(this.sapDescriptionTextBox);
            this.currentSAPDescriptionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentSAPDescriptionGroupBox.Location = new System.Drawing.Point(3, 166);
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
            this.sapDescriptionTextBox.Location = new System.Drawing.Point(4, 19);
            this.sapDescriptionTextBox.MaxLength = 8000;
            this.sapDescriptionTextBox.Multiline = true;
            this.sapDescriptionTextBox.Name = "sapDescriptionTextBox";
            this.sapDescriptionTextBox.OltAcceptsReturn = true;
            this.sapDescriptionTextBox.OltTrimWhitespace = true;
            this.sapDescriptionTextBox.ReadOnly = true;
            this.sapDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sapDescriptionTextBox.Size = new System.Drawing.Size(917, 108);
            this.sapDescriptionTextBox.TabIndex = 33;
            // 
            // taskDescriptionGroupBox
            // 
            this.taskDescriptionGroupBox.Controls.Add(this.label1);
            this.taskDescriptionGroupBox.Controls.Add(this.workAndScopeDescriptionTextBox);
            this.taskDescriptionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskDescriptionGroupBox.Location = new System.Drawing.Point(3, 3);
            this.taskDescriptionGroupBox.Name = "taskDescriptionGroupBox";
            this.taskDescriptionGroupBox.Size = new System.Drawing.Size(937, 157);
            this.taskDescriptionGroupBox.TabIndex = 0;
            this.taskDescriptionGroupBox.TabStop = false;
            this.taskDescriptionGroupBox.Text = "PART B";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "WORK SCOPE AND DESCRIPTION";
            // 
            // workAndScopeDescriptionTextBox
            // 
            this.workAndScopeDescriptionTextBox.AcceptsTabAndReturn = true;
            this.workAndScopeDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.workAndScopeDescriptionTextBox.Location = new System.Drawing.Point(3, 30);
            this.workAndScopeDescriptionTextBox.MaxLength = 8000;
            this.workAndScopeDescriptionTextBox.Name = "workAndScopeDescriptionTextBox";
            this.workAndScopeDescriptionTextBox.OltTrimWhitespace = true;
            this.workAndScopeDescriptionTextBox.ReadOnly = false;
            this.workAndScopeDescriptionTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.workAndScopeDescriptionTextBox.Size = new System.Drawing.Size(917, 123);
            this.workAndScopeDescriptionTextBox.TabIndex = 32;
            // 
            // oltLabelLine1
            // 
            this.oltLabelLine1.Label = "Task Description";
            this.oltLabelLine1.Location = new System.Drawing.Point(9, 627);
            this.oltLabelLine1.Name = "oltLabelLine1";
            this.oltLabelLine1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.oltLabelLine1.Size = new System.Drawing.Size(943, 13);
            this.oltLabelLine1.TabIndex = 13;
            this.oltLabelLine1.TabStop = false;
            // 
            // WorkPermitFortHillsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(984, 742);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.buttonsPanel);
            this.MaximumSize = new System.Drawing.Size(1000, 1400);
            this.MinimumSize = new System.Drawing.Size(1000, 716);
            this.Name = "WorkPermitFortHillsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.WorkPermitEdmontonForm_Shown);
            this.ResizeEnd += new System.EventHandler(this.WorkPermitEdmontonForm_ResizeEnd);
            this.buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoProvider)).EndInit();
            this.issuedToGroupBox.ResumeLayout(false);
            this.issuedToGroupBox.PerformLayout();
            this.oltPanel1.ResumeLayout(false);
            this.oltPanel1.PerformLayout();
            this.permitTypeGroupBox.ResumeLayout(false);
            this.functionalLocationGroupBox.ResumeLayout(false);
            this.functionalLocationGroupBox.PerformLayout();
            this.requestedStartGroupBox.ResumeLayout(false);
            this.oltGroupBox1.ResumeLayout(false);
            this.oltGroupBox1.PerformLayout();
            this.requestedEndDateGroupBox.ResumeLayout(false);
            this.oltGroupBox4.ResumeLayout(false);
            this.oltGroupBox4.PerformLayout();
            this.oltGroupBox5.ResumeLayout(false);
            this.oltGroupBox5.PerformLayout();
            this.permitNumberGroupBox.ResumeLayout(false);
            this.permitNumberGroupBox.PerformLayout();
            this.documentLinksGroupBox.ResumeLayout(false);
            this.priorityGroupBox.ResumeLayout(false);
            this.typeOfWorkGroupBox.ResumeLayout(false);
            this.typeOfWorkGroupBox.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.permitAgreementIssuanceGroupBox.ResumeLayout(false);
            this.permitAgreementIssuanceGroupBox.PerformLayout();
            this.fieldtourTblLayoutPanel.ResumeLayout(false);
            this.oltPanel133.ResumeLayout(false);
            this.oltPanel133.PerformLayout();
            this.oltPanel134.ResumeLayout(false);
            this.oltPanel10.ResumeLayout(false);
            this.oltPanel10.PerformLayout();
            this.oltPanel135.ResumeLayout(false);
            this.oltPanel135.PerformLayout();
            this.agreementAndSignaturePanel.ResumeLayout(false);
            this.agreementAndSignaturePanel.PerformLayout();
            this.atmosphericMoniteringGroupBox.ResumeLayout(false);
            this.atmosphericMoniteringGroupBox.PerformLayout();
            this.oltPanel9.ResumeLayout(false);
            this.oltPanel9.PerformLayout();
            this.oltPanel8.ResumeLayout(false);
            this.oltPanel8.PerformLayout();
            this.oltPanel7.ResumeLayout(false);
            this.oltPanel7.PerformLayout();
            this.controlOfHazardousenergyGroupBox.ResumeLayout(false);
            this.controlOfHazardousenergyGroupBox.PerformLayout();
            this.workAuthorizationAndDocumentationGroupBox.ResumeLayout(false);
            this.workAuthorizationAndDocumentationGroupBox.PerformLayout();
            this.oltPanel5.ResumeLayout(false);
            this.oltPanel5.PerformLayout();
            this.oltPanel6.ResumeLayout(false);
            this.oltPanel6.PerformLayout();
            this.safetyPrecautionsHazardousGroupBox.ResumeLayout(false);
            this.safetyPrecautionsHazardousGroupBox.PerformLayout();
            this.specialSafetyEquipmentRequirementGroupBox.ResumeLayout(false);
            this.specialSafetyEquipmentRequirementGroupBox.PerformLayout();
            this.oltPanel2.ResumeLayout(false);
            this.oltPanel2.PerformLayout();
            this.oltPanel3.ResumeLayout(false);
            this.oltPanel3.PerformLayout();
            this.oltPanel4.ResumeLayout(false);
            this.oltPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.currentSAPDescriptionGroupBox.ResumeLayout(false);
            this.currentSAPDescriptionGroupBox.PerformLayout();
            this.taskDescriptionGroupBox.ResumeLayout(false);
            this.taskDescriptionGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton saveButton;
        private OltPanel buttonsPanel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltButton cancelButton;
        //private OltComboBox flarePitEntryTypeComboBox;
        //private OltCheckBox flarePitEntryCheckBox;
        private OltButton validateButton;
        private System.Windows.Forms.ErrorProvider warningProvider;
        private ToolTip toolTip;
        private ErrorProvider infoProvider;
        private OltButton saveAndIssueButton;
        private OltButton printPreferencesButton;
        private OltPanel contentPanel;
        private OltGroupBox typeOfWorkGroupBox;
        private OltTextBox coOrdConactNoTextBox;
        private OltTimePicker extensionTimePickerWP;
        private OltDatePicker extensionDatePickerWP;
        private OltLabel entensionoltLabel;
        private OltIntegerBox lockBoxNoIntegerBox;
        private OltIntegerBox isolationNoIntegerBox;
        private OltLabel oltLabel16;
        private OltLabel oltLabel7;
        private OltTextBox jobCoordinatorTextBox;
        private OltLabel oltLabel8;
        private OltLabel oltLabel14;
        private OltTextBox emergencyAssemblyAreaTextBox;
        private OltLabel oltLabel20;
        private OltIntegerBox equipmentIntegerBox;
        private OltLabel oltLabel45;
        private OltIntegerBox emergencyContactNoTextBox;
        private OltLabel oltLabel46;
        private OltGroupBox priorityGroupBox;
        private OltComboBox priorityComboBox;
        private OltGroupBox documentLinksGroupBox;
        private Controls.DocumentLinksControl documentLinksControl;
        private OltGroupBox permitNumberGroupBox;
        private OltLabel permitNumberValue;
        private OltLabel permitNumberLabel;
        private OltGroupBox oltGroupBox5;
        private OltTextBox subOperationNumberTextBox;
        private OltGroupBox oltGroupBox4;
        private OltTextBox operationNumberTextBox;
        private OltGroupBox requestedEndDateGroupBox;
        private OltTimePicker requestedEndTimeTimePickerWP;
        private OltDatePicker requestedEndDateDatePickerWP;
        private OltGroupBox oltGroupBox1;
        private OltTextBox workOrderNumberTextBox;
        private OltGroupBox requestedStartGroupBox;
        private OltTimePicker requestedStartTimeTimePickerWP;
        private OltDatePicker requestedStartDateDatePickerWP;
        private OltGroupBox functionalLocationGroupBox;
        private OltTextBox locationTextBox;
        private OltLabel oltLabel15;
        private OltTextBox functionalLocationTextBox;
        private OltButton functionalLocationBrowseButton;
        private OltGroupBox permitTypeGroupBox;
        private OltComboBox permitTypeComboBox;
        private OltLastModifiedDateAuthorHeader oltLastModifiedDateAuthorHeader1;
        private OltGroupBox issuedToGroupBox;
        private OltComboBox groupComboBox;
        private OltLabel oltLabel48;
        private OltIntegerBox numberOfWorkersTextBox;
        private OltEditableComboBox occupationComboBox;
        private OltLabel occupationLabel;
        private OltPanel oltPanel1;
        private OltCheckBox issuedToSuncorCheckBox;
        private OltCheckBox issuedToContractorCheckBox;
        private OltEditableComboBox contractorComboBox;
        private OltLabel oltLabel4;
        private TableLayoutPanel tableLayoutPanel1;
        private OltGroupBox currentSAPDescriptionGroupBox;
        private OltTextBox sapDescriptionTextBox;
        private OltGroupBox taskDescriptionGroupBox;
        private Label label1;
        private OltSpellCheckTextBox workAndScopeDescriptionTextBox;
        private OltLabelLine oltLabelLine1;
        private OltGroupBox specialSafetyEquipmentRequirementGroupBox;
        private OltCheckBox safetyGlovesCheckBox;
        private OltCheckBox hearingProtectionCheckBox;
        private OltCheckBox communicationDeviceCheckBox;
        private Label label2;
        private OltPanel oltPanel2;
        private OltTextBox other3TextBox;
        private OltCheckBox other3CheckBox;
        private OltPanel oltPanel3;
        private OltTextBox other2TextBox;
        private OltCheckBox other2CheckBox;
        private OltPanel oltPanel4;
        private OltTextBox other1TextBox;
        private OltCheckBox other1CheckBox;
        private OltCheckBox faceShieldCheckBox;
        private OltCheckBox fallProtectionCheckBox;
        private OltCheckBox chargedFireHouseCheckBox;
        private OltCheckBox coveredSewerCheckBox;
        private OltCheckBox airPurifyingRespiratorCheckBox;
        private OltCheckBox singalPersonCheckBox;
        private OltCheckBox reflectiveStripsCheckBox;
        private OltCheckBox monoGogglesCheckBox;
        private OltCheckBox fireblanketCheckBox;
        private OltCheckBox fireExtinguisherCheckBox;
        private OltCheckBox sparkContainmentCheckBox;
        private OltCheckBox fireWatchCheckBox;
        private OltCheckBox standbyPersonCheckBox;
        private OltCheckBox workingAloneCheckBox;
        private OltCheckBox personalFlotationDeviceCheckBox;
        private OltCheckBox airMoverCheckBox;
        private OltCheckBox suppliedBreathingAirCheckBox;
        private OltCheckBox confinedSpaceMoniterCheckBox;
        private OltCheckBox bottleWatchCheckBox;
        private OltCheckBox chemicalSuitCheckBox;
        private OltCheckBox flameResistantWorkWearCheckBox;
        private OltGroupBox safetyPrecautionsHazardousGroupBox;
        private Label label4;
        private OltSpellCheckTextBox hazardsAndOrRequirementsTextBox;
        private OltGroupBox workAuthorizationAndDocumentationGroupBox;
        private OltPanel oltPanel5;
        private OltCheckBox confinedSpaceCheckBox;
        private OltComboBox confinedSpaceClassComboBox;
        private OltPanel oltPanel6;
        private OltTextBox othersPartETextBox;
        private OltCheckBox othersPartECheckBox;
        private Label label3;
        private OltCheckBox electricalEncroachmentCheckBox;
        private OltCheckBox fireProtectionAuthorizationCheckBox;
        private OltCheckBox mSDSCheckBox;
        private OltCheckBox industrialRadiographyCheckBox;
        private OltCheckBox vehicleEntryCheckBox;
        private OltCheckBox criticalOrSeriousLiftsCheckBox;
        private OltCheckBox groundDisturbanceCheckBox;
        private OltGroupBox controlOfHazardousenergyGroupBox;
        private OltCheckBox nuclearSourceCheckBox;
        private OltCheckBox electricallyIsolatedCheckBox;
        private Label label5;
        private OltCheckBox doubleBlockedandBledCheckBox;
        private OltCheckBox mechanicallyIsolatedCheckBox;
        private OltCheckBox testBumpedCheckBox;
        private OltCheckBox blindedOrBlankedCheckBox;
        private OltCheckBox drainedAndDepressurisedCheckBox;
        private OltCheckBox purgedorNeutralisedCheckBox;
        private OltCheckBox receiverStafingRequirementsCheckBox;
        private OltGroupBox atmosphericMoniteringGroupBox;
        private Label label6;
        private OltPanel agreementAndSignaturePanel;
        private OltTextBox permitAcceptorField;
        private OltLabel permitAcceptorLabel;
        private OltCheckBox lockBoxNumberoltCheckBox;
        private OltGroupBox permitAgreementIssuanceGroupBox;
        private OltTextBox addationalAuthorityContactInfoTextBox;
        private OltTextBox areaAuthorityContactInfoTextBox;
        private OltTextBox coAuthorizingIssuerContactInfoTextBox;
        private OltTextBox permitIssuerContactinfoTextBox;
        private OltLabel oltLabel5;
        private OltTextBox addationalAuthorityTextBox;
        private OltLabel oltLabel6;
        private OltLabel oltLabel37;
        private OltTextBox coAuthorizingIssuerTextBox;
        private OltLabel oltLabel38;
        private OltLabel oltLabel39;
        private OltTextBox areaAuthorityTextBox;
        private OltLabel oltLabel40;
        private OltLabel oltLabel41;
        private OltTextBox permitIssuerTextBox;
        private OltLabel oltLabel43;
        private OltTableLayoutPanel fieldtourTblLayoutPanel;
        private OltPanel oltPanel134;
        private OltPanel oltPanel135;
        private OltLabel oltLabel44;
        private Label label7;
        private OltCheckBox partCWorkSectionNotApplicableToJobCheckBox;
        private OltLabelLine oltLabelLine2;
        private OltCheckBox partDWorkSectionNotApplicableToJobCheckBox;
        private OltLabelLine oltLabelLine3;
        private OltCheckBox partEWorkSectionNotApplicableToJobCheckBox;
        private OltLabelLine oltLabelLine4;
        private OltCheckBox partFWorkSectionNotApplicableToJobCheckBox;
        private OltLabelLine oltLabelLine6;
        private OltCheckBox partGWorkSectionNotApplicableToJobCheckBox;
        private OltLabelLine oltLabelLine5;
        private OltComboBox frequencyPartGComboBox;
        private OltLabel oltLabel1;
        private OltCheckBox coPpmPartGCheckBox;
        private OltCheckBox h2sPpmPartGCheckBox;
        private OltCheckBox so2PpmPartGCheckBox;
        private OltCheckBox lelPartGCheckBox;
        private OltCheckBox oxygenPartGCheckBox;
        private OltPanel oltPanel8;
        private OltTextBox other2PartGTextBox;
        private OltCheckBox other2PartGCheckBox;
        private OltPanel oltPanel7;
        private OltTextBox other1PartGTextBox;
        private OltCheckBox other1PartGCheckBox;
        private OltPanel oltPanel9;
        private OltCheckBox continuousCheckBox;
        private OltTextBox testerNameoltTextBox;
        private OltLabel oltLabel3;
        private OltTextBox emergencyMeetingPointTextBox;
        private OltPanel oltPanel10;
        private OltRadioButton isFieldTourRequiredNoRadioButton;
        private OltRadioButton isFieldTourRequiredYesRadioButton;
        private OltPanel oltPanel133;
        private OltTextBox fieldTourConductedByTextBox;
        private OltTextBox extensionCommentsTextBox;
        private OltLabel extensioncommentsoltLabel;
    }
}