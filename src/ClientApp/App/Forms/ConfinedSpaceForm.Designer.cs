using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfinedSpaceForm
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
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.viewConfiguredDocumentLinkButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.configuredDocumentLinkComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.basicInformationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.refNumberTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.preparationCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.functionalLocationTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.functionalLocationBrowseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltLabel6 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel5 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.endTimePicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.endDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.startTimePicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.startDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.conditionsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.ventilationNaturelleBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.bouchesDegoutProtegeesBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.ventilationMecaniqueBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.planDeSauvetageBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.autresConditionsDropDownControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableDropDownControl();
            this.dessinsRequisStringControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableStringControl();
            this.cablesChauffantsMisHorsTensionBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.purgeParGazInerteBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.obtureOuDeBrancheBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.interrupteursElectriquesVerrouillesBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.depressuriseEtVidangeBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.enPresenceDeGazInerteBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.purgeAlaVapeurBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.possibiliteDeSulfuredeFerBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.aereBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.rinceAlEauBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.specialPrecautionsOrConsiderationsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.instructionsSpecialesTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.substancesNormalementGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.autresSubstancesDropDownControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableDropDownControl();
            this.aromatiqueDropDownControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableDropDownControl();
            this.corrosifDropDownControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableDropDownControl();
            this.hydrocarbureBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.ammoniaqueBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.h2SBooleanControl = new Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.basicInformationGroupBox.SuspendLayout();
            this.conditionsGroupBox.SuspendLayout();
            this.specialPrecautionsOrConsiderationsGroupBox.SuspendLayout();
            this.substancesNormalementGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // oltLabel1
            // 
            this.oltLabel1.AutoSize = true;
            this.oltLabel1.Location = new System.Drawing.Point(8, 408);
            this.oltLabel1.Name = "oltLabel1";
            this.oltLabel1.Size = new System.Drawing.Size(132, 13);
            this.oltLabel1.TabIndex = 9;
            this.oltLabel1.Text = "Documents de Référence:";
            // 
            // viewConfiguredDocumentLinkButton
            // 
            this.viewConfiguredDocumentLinkButton.Location = new System.Drawing.Point(417, 404);
            this.viewConfiguredDocumentLinkButton.Name = "viewConfiguredDocumentLinkButton";
            this.viewConfiguredDocumentLinkButton.Size = new System.Drawing.Size(75, 23);
            this.viewConfiguredDocumentLinkButton.TabIndex = 5;
            this.viewConfiguredDocumentLinkButton.Text = "Afficher";
            this.viewConfiguredDocumentLinkButton.UseVisualStyleBackColor = true;
            // 
            // configuredDocumentLinkComboBox
            // 
            this.configuredDocumentLinkComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.configuredDocumentLinkComboBox.FormattingEnabled = true;
            this.configuredDocumentLinkComboBox.Location = new System.Drawing.Point(142, 405);
            this.configuredDocumentLinkComboBox.Name = "configuredDocumentLinkComboBox";
            this.configuredDocumentLinkComboBox.Size = new System.Drawing.Size(269, 21);
            this.configuredDocumentLinkComboBox.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(907, 405);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Fermer";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(819, 405);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Enregistrer";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // basicInformationGroupBox
            // 
            this.basicInformationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.basicInformationGroupBox.Controls.Add(this.oltLabel3);
            this.basicInformationGroupBox.Controls.Add(this.refNumberTextBox);
            this.basicInformationGroupBox.Controls.Add(this.preparationCheckBox);
            this.basicInformationGroupBox.Controls.Add(this.oltLabel2);
            this.basicInformationGroupBox.Controls.Add(this.functionalLocationTextBox);
            this.basicInformationGroupBox.Controls.Add(this.functionalLocationBrowseButton);
            this.basicInformationGroupBox.Controls.Add(this.oltLabel6);
            this.basicInformationGroupBox.Controls.Add(this.oltLabel5);
            this.basicInformationGroupBox.Controls.Add(this.endTimePicker);
            this.basicInformationGroupBox.Controls.Add(this.endDatePicker);
            this.basicInformationGroupBox.Controls.Add(this.startTimePicker);
            this.basicInformationGroupBox.Controls.Add(this.startDatePicker);
            this.basicInformationGroupBox.Location = new System.Drawing.Point(3, 4);
            this.basicInformationGroupBox.Name = "basicInformationGroupBox";
            this.basicInformationGroupBox.Size = new System.Drawing.Size(1006, 83);
            this.basicInformationGroupBox.TabIndex = 0;
            this.basicInformationGroupBox.TabStop = false;
            this.basicInformationGroupBox.Text = "Informations de base";
            // 
            // oltLabel3
            // 
            this.oltLabel3.AutoSize = true;
            this.oltLabel3.Location = new System.Drawing.Point(637, 21);
            this.oltLabel3.Name = "oltLabel3";
            this.oltLabel3.Size = new System.Drawing.Size(35, 13);
            this.oltLabel3.TabIndex = 7;
            this.oltLabel3.Text = "Ref #";
            // 
            // refNumberTextBox
            // 
            this.refNumberTextBox.Location = new System.Drawing.Point(676, 17);
            this.refNumberTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.refNumberTextBox.MaxLength = 50;
            this.refNumberTextBox.Name = "refNumberTextBox";
            this.refNumberTextBox.OltAcceptsReturn = true;
            this.refNumberTextBox.OltTrimWhitespace = true;
            this.refNumberTextBox.ReadOnly = true;
            this.refNumberTextBox.Size = new System.Drawing.Size(87, 20);
            this.refNumberTextBox.TabIndex = 8;
            this.refNumberTextBox.Text = "EC";
            // 
            // preparationCheckBox
            // 
            this.preparationCheckBox.AutoSize = true;
            this.preparationCheckBox.BackColor = System.Drawing.Color.Yellow;
            this.preparationCheckBox.Location = new System.Drawing.Point(536, 19);
            this.preparationCheckBox.Name = "preparationCheckBox";
            this.preparationCheckBox.Size = new System.Drawing.Size(82, 17);
            this.preparationCheckBox.TabIndex = 6;
            this.preparationCheckBox.Text = "Préparation";
            this.preparationCheckBox.UseVisualStyleBackColor = false;
            this.preparationCheckBox.Value = null;
            // 
            // oltLabel2
            // 
            this.oltLabel2.AutoSize = true;
            this.oltLabel2.Location = new System.Drawing.Point(10, 53);
            this.oltLabel2.Name = "oltLabel2";
            this.oltLabel2.Size = new System.Drawing.Size(88, 13);
            this.oltLabel2.TabIndex = 9;
            this.oltLabel2.Text = "Poste technique:";
            // 
            // functionalLocationTextBox
            // 
            this.functionalLocationTextBox.Location = new System.Drawing.Point(98, 49);
            this.functionalLocationTextBox.Name = "functionalLocationTextBox";
            this.functionalLocationTextBox.OltAcceptsReturn = true;
            this.functionalLocationTextBox.OltTrimWhitespace = true;
            this.functionalLocationTextBox.ReadOnly = true;
            this.functionalLocationTextBox.Size = new System.Drawing.Size(274, 20);
            this.functionalLocationTextBox.TabIndex = 10;
            this.functionalLocationTextBox.TabStop = false;
            // 
            // functionalLocationBrowseButton
            // 
            this.functionalLocationBrowseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.functionalLocationBrowseButton.Location = new System.Drawing.Point(377, 48);
            this.functionalLocationBrowseButton.Name = "functionalLocationBrowseButton";
            this.functionalLocationBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.functionalLocationBrowseButton.TabIndex = 11;
            this.functionalLocationBrowseButton.Text = "&Parcourir...";
            this.functionalLocationBrowseButton.UseVisualStyleBackColor = true;
            // 
            // oltLabel6
            // 
            this.oltLabel6.AutoSize = true;
            this.oltLabel6.Location = new System.Drawing.Point(294, 21);
            this.oltLabel6.Name = "oltLabel6";
            this.oltLabel6.Size = new System.Drawing.Size(13, 13);
            this.oltLabel6.TabIndex = 3;
            this.oltLabel6.Text = "à";
            // 
            // oltLabel5
            // 
            this.oltLabel5.AutoSize = true;
            this.oltLabel5.Location = new System.Drawing.Point(45, 21);
            this.oltLabel5.Name = "oltLabel5";
            this.oltLabel5.Size = new System.Drawing.Size(50, 13);
            this.oltLabel5.TabIndex = 0;
            this.oltLabel5.Text = "Valide du";
            // 
            // endTimePicker
            // 
            this.endTimePicker.Checked = true;
            this.endTimePicker.CustomFormat = "HH:mm";
            this.endTimePicker.Location = new System.Drawing.Point(453, 17);
            this.endTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowCheckBox = false;
            this.endTimePicker.Size = new System.Drawing.Size(60, 21);
            this.endTimePicker.TabIndex = 5;
            // 
            // endDatePicker
            // 
            this.endDatePicker.CustomFormat = "ddd yyyy-MM-dd";
            this.endDatePicker.Location = new System.Drawing.Point(323, 17);
            this.endDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.endDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.PickerEnabled = true;
            this.endDatePicker.Size = new System.Drawing.Size(126, 21);
            this.endDatePicker.TabIndex = 4;
            // 
            // startTimePicker
            // 
            this.startTimePicker.Checked = true;
            this.startTimePicker.CustomFormat = "HH:mm";
            this.startTimePicker.Location = new System.Drawing.Point(219, 17);
            this.startTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowCheckBox = false;
            this.startTimePicker.Size = new System.Drawing.Size(60, 21);
            this.startTimePicker.TabIndex = 4;
            // 
            // startDatePicker
            // 
            this.startDatePicker.CustomFormat = "ddd yyyy-MM-dd";
            this.startDatePicker.Location = new System.Drawing.Point(98, 17);
            this.startDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.startDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.PickerEnabled = true;
            this.startDatePicker.Size = new System.Drawing.Size(118, 21);
            this.startDatePicker.TabIndex = 2;
            // 
            // conditionsGroupBox
            // 
            this.conditionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conditionsGroupBox.Controls.Add(this.ventilationNaturelleBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.bouchesDegoutProtegeesBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.ventilationMecaniqueBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.planDeSauvetageBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.autresConditionsDropDownControl);
            this.conditionsGroupBox.Controls.Add(this.dessinsRequisStringControl);
            this.conditionsGroupBox.Controls.Add(this.cablesChauffantsMisHorsTensionBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.purgeParGazInerteBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.obtureOuDeBrancheBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.interrupteursElectriquesVerrouillesBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.depressuriseEtVidangeBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.enPresenceDeGazInerteBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.purgeAlaVapeurBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.possibiliteDeSulfuredeFerBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.aereBooleanControl);
            this.conditionsGroupBox.Controls.Add(this.rinceAlEauBooleanControl);
            this.conditionsGroupBox.Location = new System.Drawing.Point(3, 150);
            this.conditionsGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.conditionsGroupBox.Name = "conditionsGroupBox";
            this.conditionsGroupBox.Size = new System.Drawing.Size(1006, 154);
            this.conditionsGroupBox.TabIndex = 2;
            this.conditionsGroupBox.TabStop = false;
            this.conditionsGroupBox.Text = "Conditions et outils permis pour ce travail";
            // 
            // ventilationNaturelleBooleanControl
            // 
            this.ventilationNaturelleBooleanControl.Label = "Ventilation naturelle";
            this.ventilationNaturelleBooleanControl.Location = new System.Drawing.Point(649, 107);
            this.ventilationNaturelleBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.ventilationNaturelleBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.ventilationNaturelleBooleanControl.Name = "ventilationNaturelleBooleanControl";
            this.ventilationNaturelleBooleanControl.Size = new System.Drawing.Size(136, 17);
            this.ventilationNaturelleBooleanControl.TabIndex = 15;
            this.ventilationNaturelleBooleanControl.TemplateMode = false;
            // 
            // bouchesDegoutProtegeesBooleanControl
            // 
            this.bouchesDegoutProtegeesBooleanControl.Label = "Bouches d\'égout protégées";
            this.bouchesDegoutProtegeesBooleanControl.Location = new System.Drawing.Point(649, 17);
            this.bouchesDegoutProtegeesBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.bouchesDegoutProtegeesBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.bouchesDegoutProtegeesBooleanControl.Name = "bouchesDegoutProtegeesBooleanControl";
            this.bouchesDegoutProtegeesBooleanControl.Size = new System.Drawing.Size(199, 17);
            this.bouchesDegoutProtegeesBooleanControl.TabIndex = 11;
            this.bouchesDegoutProtegeesBooleanControl.TemplateMode = false;
            // 
            // ventilationMecaniqueBooleanControl
            // 
            this.ventilationMecaniqueBooleanControl.Label = "Ventilation mécanique";
            this.ventilationMecaniqueBooleanControl.Location = new System.Drawing.Point(330, 107);
            this.ventilationMecaniqueBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.ventilationMecaniqueBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.ventilationMecaniqueBooleanControl.Name = "ventilationMecaniqueBooleanControl";
            this.ventilationMecaniqueBooleanControl.Size = new System.Drawing.Size(150, 17);
            this.ventilationMecaniqueBooleanControl.TabIndex = 10;
            this.ventilationMecaniqueBooleanControl.TemplateMode = false;
            // 
            // planDeSauvetageBooleanControl
            // 
            this.planDeSauvetageBooleanControl.Label = "Plan de sauvetage";
            this.planDeSauvetageBooleanControl.Location = new System.Drawing.Point(6, 129);
            this.planDeSauvetageBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.planDeSauvetageBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.planDeSauvetageBooleanControl.Name = "planDeSauvetageBooleanControl";
            this.planDeSauvetageBooleanControl.Size = new System.Drawing.Size(117, 17);
            this.planDeSauvetageBooleanControl.TabIndex = 5;
            this.planDeSauvetageBooleanControl.TemplateMode = false;
            // 
            // autresConditionsDropDownControl
            // 
            this.autresConditionsDropDownControl.DropDownWidth = 175;
            this.autresConditionsDropDownControl.Label = "Autre conditions";
            this.autresConditionsDropDownControl.Location = new System.Drawing.Point(649, 80);
            this.autresConditionsDropDownControl.Margin = new System.Windows.Forms.Padding(0);
            this.autresConditionsDropDownControl.MinimumSize = new System.Drawing.Size(226, 22);
            this.autresConditionsDropDownControl.Name = "autresConditionsDropDownControl";
            this.autresConditionsDropDownControl.Size = new System.Drawing.Size(330, 22);
            this.autresConditionsDropDownControl.TabIndex = 14;
            this.autresConditionsDropDownControl.TemplateMode = false;
            // 
            // dessinsRequisStringControl
            // 
            this.dessinsRequisStringControl.Label = "Dessins requis";
            this.dessinsRequisStringControl.Location = new System.Drawing.Point(6, 104);
            this.dessinsRequisStringControl.Margin = new System.Windows.Forms.Padding(0);
            this.dessinsRequisStringControl.MinimumSize = new System.Drawing.Size(226, 22);
            this.dessinsRequisStringControl.Name = "dessinsRequisStringControl";
            this.dessinsRequisStringControl.Size = new System.Drawing.Size(305, 22);
            this.dessinsRequisStringControl.TabIndex = 4;
            this.dessinsRequisStringControl.TemplateMode = false;
            this.dessinsRequisStringControl.TextBoxMaxLength = 32767;
            this.dessinsRequisStringControl.TextBoxWidth = 150;
            // 
            // cablesChauffantsMisHorsTensionBooleanControl
            // 
            this.cablesChauffantsMisHorsTensionBooleanControl.Label = "Câbles chauffants mis hors tension";
            this.cablesChauffantsMisHorsTensionBooleanControl.Location = new System.Drawing.Point(330, 17);
            this.cablesChauffantsMisHorsTensionBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.cablesChauffantsMisHorsTensionBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.cablesChauffantsMisHorsTensionBooleanControl.Name = "cablesChauffantsMisHorsTensionBooleanControl";
            this.cablesChauffantsMisHorsTensionBooleanControl.Size = new System.Drawing.Size(199, 17);
            this.cablesChauffantsMisHorsTensionBooleanControl.TabIndex = 6;
            this.cablesChauffantsMisHorsTensionBooleanControl.TemplateMode = false;
            // 
            // purgeParGazInerteBooleanControl
            // 
            this.purgeParGazInerteBooleanControl.Label = "Purgé par un gaz inerte";
            this.purgeParGazInerteBooleanControl.Location = new System.Drawing.Point(330, 61);
            this.purgeParGazInerteBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.purgeParGazInerteBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.purgeParGazInerteBooleanControl.Name = "purgeParGazInerteBooleanControl";
            this.purgeParGazInerteBooleanControl.Size = new System.Drawing.Size(145, 17);
            this.purgeParGazInerteBooleanControl.TabIndex = 8;
            this.purgeParGazInerteBooleanControl.TemplateMode = false;
            // 
            // obtureOuDeBrancheBooleanControl
            // 
            this.obtureOuDeBrancheBooleanControl.Label = "Obturé ou débranché";
            this.obtureOuDeBrancheBooleanControl.Location = new System.Drawing.Point(6, 17);
            this.obtureOuDeBrancheBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.obtureOuDeBrancheBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.obtureOuDeBrancheBooleanControl.Name = "obtureOuDeBrancheBooleanControl";
            this.obtureOuDeBrancheBooleanControl.Size = new System.Drawing.Size(135, 17);
            this.obtureOuDeBrancheBooleanControl.TabIndex = 0;
            this.obtureOuDeBrancheBooleanControl.TemplateMode = false;
            // 
            // interrupteursElectriquesVerrouillesBooleanControl
            // 
            this.interrupteursElectriquesVerrouillesBooleanControl.Label = "Interrupteurs électriques verrouillés";
            this.interrupteursElectriquesVerrouillesBooleanControl.Location = new System.Drawing.Point(330, 39);
            this.interrupteursElectriquesVerrouillesBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.interrupteursElectriquesVerrouillesBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.interrupteursElectriquesVerrouillesBooleanControl.Name = "interrupteursElectriquesVerrouillesBooleanControl";
            this.interrupteursElectriquesVerrouillesBooleanControl.Size = new System.Drawing.Size(204, 17);
            this.interrupteursElectriquesVerrouillesBooleanControl.TabIndex = 7;
            this.interrupteursElectriquesVerrouillesBooleanControl.TemplateMode = false;
            // 
            // depressuriseEtVidangeBooleanControl
            // 
            this.depressuriseEtVidangeBooleanControl.Label = "Dépressurisé et vidangé";
            this.depressuriseEtVidangeBooleanControl.Location = new System.Drawing.Point(6, 39);
            this.depressuriseEtVidangeBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.depressuriseEtVidangeBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.depressuriseEtVidangeBooleanControl.Name = "depressuriseEtVidangeBooleanControl";
            this.depressuriseEtVidangeBooleanControl.Size = new System.Drawing.Size(148, 17);
            this.depressuriseEtVidangeBooleanControl.TabIndex = 1;
            this.depressuriseEtVidangeBooleanControl.TemplateMode = false;
            // 
            // enPresenceDeGazInerteBooleanControl
            // 
            this.enPresenceDeGazInerteBooleanControl.Label = "En présence de gaz inerte";
            this.enPresenceDeGazInerteBooleanControl.Location = new System.Drawing.Point(6, 61);
            this.enPresenceDeGazInerteBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.enPresenceDeGazInerteBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.enPresenceDeGazInerteBooleanControl.Name = "enPresenceDeGazInerteBooleanControl";
            this.enPresenceDeGazInerteBooleanControl.Size = new System.Drawing.Size(157, 17);
            this.enPresenceDeGazInerteBooleanControl.TabIndex = 2;
            this.enPresenceDeGazInerteBooleanControl.TemplateMode = false;
            // 
            // purgeAlaVapeurBooleanControl
            // 
            this.purgeAlaVapeurBooleanControl.Label = "Purgé à la vapeur";
            this.purgeAlaVapeurBooleanControl.Location = new System.Drawing.Point(6, 83);
            this.purgeAlaVapeurBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.purgeAlaVapeurBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.purgeAlaVapeurBooleanControl.Name = "purgeAlaVapeurBooleanControl";
            this.purgeAlaVapeurBooleanControl.Size = new System.Drawing.Size(117, 17);
            this.purgeAlaVapeurBooleanControl.TabIndex = 3;
            this.purgeAlaVapeurBooleanControl.TemplateMode = false;
            // 
            // possibiliteDeSulfuredeFerBooleanControl
            // 
            this.possibiliteDeSulfuredeFerBooleanControl.Label = "Possibilité de sulfure de fer";
            this.possibiliteDeSulfuredeFerBooleanControl.Location = new System.Drawing.Point(649, 39);
            this.possibiliteDeSulfuredeFerBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.possibiliteDeSulfuredeFerBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.possibiliteDeSulfuredeFerBooleanControl.Name = "possibiliteDeSulfuredeFerBooleanControl";
            this.possibiliteDeSulfuredeFerBooleanControl.Size = new System.Drawing.Size(161, 17);
            this.possibiliteDeSulfuredeFerBooleanControl.TabIndex = 12;
            this.possibiliteDeSulfuredeFerBooleanControl.TemplateMode = false;
            // 
            // aereBooleanControl
            // 
            this.aereBooleanControl.Label = "Aéré/ventilé (1 heure minimum)";
            this.aereBooleanControl.Location = new System.Drawing.Point(649, 61);
            this.aereBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.aereBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.aereBooleanControl.Name = "aereBooleanControl";
            this.aereBooleanControl.Size = new System.Drawing.Size(182, 17);
            this.aereBooleanControl.TabIndex = 13;
            this.aereBooleanControl.TemplateMode = false;
            // 
            // rinceAlEauBooleanControl
            // 
            this.rinceAlEauBooleanControl.Label = "Rincé à l\'eau";
            this.rinceAlEauBooleanControl.Location = new System.Drawing.Point(330, 83);
            this.rinceAlEauBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.rinceAlEauBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.rinceAlEauBooleanControl.Name = "rinceAlEauBooleanControl";
            this.rinceAlEauBooleanControl.Size = new System.Drawing.Size(100, 17);
            this.rinceAlEauBooleanControl.TabIndex = 9;
            this.rinceAlEauBooleanControl.TemplateMode = false;
            // 
            // specialPrecautionsOrConsiderationsGroupBox
            // 
            this.specialPrecautionsOrConsiderationsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specialPrecautionsOrConsiderationsGroupBox.Controls.Add(this.instructionsSpecialesTextBox);
            this.specialPrecautionsOrConsiderationsGroupBox.Location = new System.Drawing.Point(3, 304);
            this.specialPrecautionsOrConsiderationsGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.specialPrecautionsOrConsiderationsGroupBox.Name = "specialPrecautionsOrConsiderationsGroupBox";
            this.specialPrecautionsOrConsiderationsGroupBox.Size = new System.Drawing.Size(1006, 85);
            this.specialPrecautionsOrConsiderationsGroupBox.TabIndex = 3;
            this.specialPrecautionsOrConsiderationsGroupBox.TabStop = false;
            this.specialPrecautionsOrConsiderationsGroupBox.Text = "Instructions spéciales";
            // 
            // instructionsSpecialesTextBox
            // 
            this.instructionsSpecialesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.instructionsSpecialesTextBox.Location = new System.Drawing.Point(6, 17);
            this.instructionsSpecialesTextBox.MaxLength = 500;
            this.instructionsSpecialesTextBox.Multiline = true;
            this.instructionsSpecialesTextBox.Name = "instructionsSpecialesTextBox";
            this.instructionsSpecialesTextBox.OltAcceptsReturn = true;
            this.instructionsSpecialesTextBox.OltTrimWhitespace = true;
            this.instructionsSpecialesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.instructionsSpecialesTextBox.Size = new System.Drawing.Size(996, 58);
            this.instructionsSpecialesTextBox.TabIndex = 0;
            // 
            // substancesNormalementGroupBox
            // 
            this.substancesNormalementGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.substancesNormalementGroupBox.Controls.Add(this.autresSubstancesDropDownControl);
            this.substancesNormalementGroupBox.Controls.Add(this.aromatiqueDropDownControl);
            this.substancesNormalementGroupBox.Controls.Add(this.corrosifDropDownControl);
            this.substancesNormalementGroupBox.Controls.Add(this.hydrocarbureBooleanControl);
            this.substancesNormalementGroupBox.Controls.Add(this.ammoniaqueBooleanControl);
            this.substancesNormalementGroupBox.Controls.Add(this.h2SBooleanControl);
            this.substancesNormalementGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.substancesNormalementGroupBox.Location = new System.Drawing.Point(3, 90);
            this.substancesNormalementGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.substancesNormalementGroupBox.Name = "substancesNormalementGroupBox";
            this.substancesNormalementGroupBox.Size = new System.Drawing.Size(1006, 59);
            this.substancesNormalementGroupBox.TabIndex = 1;
            this.substancesNormalementGroupBox.TabStop = false;
            this.substancesNormalementGroupBox.Text = "Substances normalement à l\'intérieur de l\'équipement";
            // 
            // autresSubstancesDropDownControl
            // 
            this.autresSubstancesDropDownControl.AutoSize = true;
            this.autresSubstancesDropDownControl.DropDownWidth = 200;
            this.autresSubstancesDropDownControl.Label = "Autres";
            this.autresSubstancesDropDownControl.Location = new System.Drawing.Point(649, 33);
            this.autresSubstancesDropDownControl.Margin = new System.Windows.Forms.Padding(0);
            this.autresSubstancesDropDownControl.MinimumSize = new System.Drawing.Size(226, 22);
            this.autresSubstancesDropDownControl.Name = "autresSubstancesDropDownControl";
            this.autresSubstancesDropDownControl.Size = new System.Drawing.Size(331, 22);
            this.autresSubstancesDropDownControl.TabIndex = 5;
            this.autresSubstancesDropDownControl.TemplateMode = false;
            // 
            // aromatiqueDropDownControl
            // 
            this.aromatiqueDropDownControl.AutoSize = true;
            this.aromatiqueDropDownControl.DropDownWidth = 200;
            this.aromatiqueDropDownControl.Label = "Aromatique";
            this.aromatiqueDropDownControl.Location = new System.Drawing.Point(649, 11);
            this.aromatiqueDropDownControl.Margin = new System.Windows.Forms.Padding(0);
            this.aromatiqueDropDownControl.MinimumSize = new System.Drawing.Size(226, 22);
            this.aromatiqueDropDownControl.Name = "aromatiqueDropDownControl";
            this.aromatiqueDropDownControl.Size = new System.Drawing.Size(331, 22);
            this.aromatiqueDropDownControl.TabIndex = 4;
            this.aromatiqueDropDownControl.TemplateMode = false;
            // 
            // corrosifDropDownControl
            // 
            this.corrosifDropDownControl.AutoSize = true;
            this.corrosifDropDownControl.DropDownWidth = 200;
            this.corrosifDropDownControl.Label = "Corrosif";
            this.corrosifDropDownControl.Location = new System.Drawing.Point(330, 33);
            this.corrosifDropDownControl.Margin = new System.Windows.Forms.Padding(0);
            this.corrosifDropDownControl.MinimumSize = new System.Drawing.Size(226, 22);
            this.corrosifDropDownControl.Name = "corrosifDropDownControl";
            this.corrosifDropDownControl.Size = new System.Drawing.Size(303, 22);
            this.corrosifDropDownControl.TabIndex = 3;
            this.corrosifDropDownControl.TemplateMode = false;
            // 
            // hydrocarbureBooleanControl
            // 
            this.hydrocarbureBooleanControl.Label = "Hydrocarbure";
            this.hydrocarbureBooleanControl.Location = new System.Drawing.Point(6, 36);
            this.hydrocarbureBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.hydrocarbureBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.hydrocarbureBooleanControl.Name = "hydrocarbureBooleanControl";
            this.hydrocarbureBooleanControl.Size = new System.Drawing.Size(100, 17);
            this.hydrocarbureBooleanControl.TabIndex = 1;
            this.hydrocarbureBooleanControl.TemplateMode = false;
            // 
            // ammoniaqueBooleanControl
            // 
            this.ammoniaqueBooleanControl.Label = "Ammoniaque";
            this.ammoniaqueBooleanControl.Location = new System.Drawing.Point(330, 14);
            this.ammoniaqueBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.ammoniaqueBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.ammoniaqueBooleanControl.Name = "ammoniaqueBooleanControl";
            this.ammoniaqueBooleanControl.Size = new System.Drawing.Size(100, 17);
            this.ammoniaqueBooleanControl.TabIndex = 2;
            this.ammoniaqueBooleanControl.TemplateMode = false;
            // 
            // h2SBooleanControl
            // 
            this.h2SBooleanControl.Label = "H²S";
            this.h2SBooleanControl.Location = new System.Drawing.Point(6, 14);
            this.h2SBooleanControl.Margin = new System.Windows.Forms.Padding(0);
            this.h2SBooleanControl.MinimumSize = new System.Drawing.Size(100, 17);
            this.h2SBooleanControl.Name = "h2SBooleanControl";
            this.h2SBooleanControl.Size = new System.Drawing.Size(100, 17);
            this.h2SBooleanControl.TabIndex = 0;
            this.h2SBooleanControl.TemplateMode = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ConfinedSpaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1012, 439);
            this.Controls.Add(this.oltLabel1);
            this.Controls.Add(this.viewConfiguredDocumentLinkButton);
            this.Controls.Add(this.configuredDocumentLinkComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.basicInformationGroupBox);
            this.Controls.Add(this.conditionsGroupBox);
            this.Controls.Add(this.specialPrecautionsOrConsiderationsGroupBox);
            this.Controls.Add(this.substancesNormalementGroupBox);
            this.MinimumSize = new System.Drawing.Size(1020, 38);
            this.Name = "ConfinedSpaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Espace Clos";
            this.basicInformationGroupBox.ResumeLayout(false);
            this.basicInformationGroupBox.PerformLayout();
            this.conditionsGroupBox.ResumeLayout(false);
            this.specialPrecautionsOrConsiderationsGroupBox.ResumeLayout(false);
            this.specialPrecautionsOrConsiderationsGroupBox.PerformLayout();
            this.substancesNormalementGroupBox.ResumeLayout(false);
            this.substancesNormalementGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltGroupBox basicInformationGroupBox;
        private OltLabel oltLabel3;
        private OltTextBox refNumberTextBox;
        private OltCheckBox preparationCheckBox;
        private OltLabel oltLabel2;
        private OltTextBox functionalLocationTextBox;
        private OltButton functionalLocationBrowseButton;
        private OltLabel oltLabel6;
        private OltLabel oltLabel5;
        private OltTimePicker endTimePicker;
        private OltDatePicker endDatePicker;
        private OltTimePicker startTimePicker;
        private OltDatePicker startDatePicker;
        private OltGroupBox conditionsGroupBox;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableDropDownControl autresConditionsDropDownControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableStringControl dessinsRequisStringControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl cablesChauffantsMisHorsTensionBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl purgeParGazInerteBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl obtureOuDeBrancheBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl interrupteursElectriquesVerrouillesBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl depressuriseEtVidangeBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl enPresenceDeGazInerteBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl purgeAlaVapeurBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl possibiliteDeSulfuredeFerBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl aereBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl rinceAlEauBooleanControl;
        private OltGroupBox specialPrecautionsOrConsiderationsGroupBox;
        private OltTextBox instructionsSpecialesTextBox;
        private OltGroupBox substancesNormalementGroupBox;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableDropDownControl autresSubstancesDropDownControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableDropDownControl aromatiqueDropDownControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableDropDownControl corrosifDropDownControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl hydrocarbureBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl ammoniaqueBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl h2SBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl ventilationMecaniqueBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl planDeSauvetageBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl ventilationNaturelleBooleanControl;
        private Com.Suncor.Olt.Client.Controls.Template.TemplatableBooleanControl bouchesDegoutProtegeesBooleanControl;
        private OltButton saveButton;
        private OltButton cancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltButton viewConfiguredDocumentLinkButton;
        private OltComboBox configuredDocumentLinkComboBox;
        private OltLabel oltLabel1;

    }
}