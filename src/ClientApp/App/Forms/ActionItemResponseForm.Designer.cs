using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
namespace Com.Suncor.Olt.Client.Forms
{
    partial class ActionItemResponseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionItemResponseForm));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.importCustomFieldsButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.scrollingPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.lastModifiedPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltLastModifiedDateAuthorHeader = new Com.Suncor.Olt.Client.OltControls.OltLastModifiedDateAuthorHeader();
            this.shiftGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.shiftLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tableLayoutPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltDGVImage = new Com.Suncor.Olt.Client.OltControls.OltDataGridView();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionActionItemDef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ImageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oltTableLayoutPanelActionItemDef = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.txtName = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.txtDescription = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltbtnbrowse = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.txtFilePath = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel4 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltCmbImageType = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltLabel5 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltbtnAdd = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltLabelActionItemDefImagesTitle = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.RestTableLayoutPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.oltLabelLine1 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.commentOnlyCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.CategoryGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.categoryLabelValue = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.reasonCodeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltGroupBox2 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.commentTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.actionItemNameGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.actionItemLabelValue = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.functionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.functionalLocationListBox = new Com.Suncor.Olt.Client.Controls.FunctionalLocationListBox();
            this.detailsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.customFieldPhTagLegendControl = new Com.Suncor.Olt.Client.Controls.CustomFieldPhTagLegendControl();
            this.oltGroupBox6 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.detailCommentsTextbox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.createLogCheckBox = new System.Windows.Forms.CheckBox();
            this.makeLogAnOperatingEngineerCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.customFieldsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltTableLayoutPanel1 = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.customFieldControl = new Com.Suncor.Olt.Client.Controls.CustomFieldTableLayoutPanel();
            this.customFieldAreaGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.customFieldsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.panel1 = new System.Windows.Forms.Panel();
            this.submitButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.flocColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProviderImage = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.scrollingPanel.SuspendLayout();
            this.lastModifiedPanel.SuspendLayout();
            this.shiftGroupBox.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oltDGVImage)).BeginInit();
            this.oltTableLayoutPanelActionItemDef.SuspendLayout();
            this.RestTableLayoutPanel.SuspendLayout();
            this.CategoryGroupBox.SuspendLayout();
            this.oltGroupBox1.SuspendLayout();
            this.oltGroupBox2.SuspendLayout();
            this.actionItemNameGroupBox.SuspendLayout();
            this.functionalLocationGroupBox.SuspendLayout();
            this.oltGroupBox6.SuspendLayout();
            this.customFieldsPanel.SuspendLayout();
            this.oltTableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderImage)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // importCustomFieldsButton
            // 
            resources.ApplyResources(this.importCustomFieldsButton, "importCustomFieldsButton");
            this.errorProviderImage.SetIconAlignment(this.importCustomFieldsButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("importCustomFieldsButton.IconAlignment"))));
            this.errorProvider.SetIconAlignment(this.importCustomFieldsButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("importCustomFieldsButton.IconAlignment1"))));
            this.importCustomFieldsButton.Name = "importCustomFieldsButton";
            this.importCustomFieldsButton.UseVisualStyleBackColor = true;
            // 
            // scrollingPanel
            // 
            resources.ApplyResources(this.scrollingPanel, "scrollingPanel");
            this.scrollingPanel.Controls.Add(this.lastModifiedPanel);
            this.scrollingPanel.Controls.Add(this.tableLayoutPanel);
            this.scrollingPanel.Name = "scrollingPanel";
            // 
            // lastModifiedPanel
            // 
            resources.ApplyResources(this.lastModifiedPanel, "lastModifiedPanel");
            this.lastModifiedPanel.Controls.Add(this.oltLastModifiedDateAuthorHeader);
            this.lastModifiedPanel.Controls.Add(this.shiftGroupBox);
            this.lastModifiedPanel.Name = "lastModifiedPanel";
            // 
            // oltLastModifiedDateAuthorHeader
            // 
            resources.ApplyResources(this.oltLastModifiedDateAuthorHeader, "oltLastModifiedDateAuthorHeader");
            this.oltLastModifiedDateAuthorHeader.LastModifiedDate = new System.DateTime(((long)(0)));
            this.oltLastModifiedDateAuthorHeader.Name = "oltLastModifiedDateAuthorHeader";
            this.oltLastModifiedDateAuthorHeader.TabStop = false;
            // 
            // shiftGroupBox
            // 
            resources.ApplyResources(this.shiftGroupBox, "shiftGroupBox");
            this.shiftGroupBox.Controls.Add(this.shiftLabelData);
            this.shiftGroupBox.Name = "shiftGroupBox";
            this.shiftGroupBox.TabStop = false;
            // 
            // shiftLabelData
            // 
            resources.ApplyResources(this.shiftLabelData, "shiftLabelData");
            this.shiftLabelData.Name = "shiftLabelData";
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.oltPanel1, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.RestTableLayoutPanel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.customFieldsPanel, 0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // oltPanel1
            // 
            resources.ApplyResources(this.oltPanel1, "oltPanel1");
            this.oltPanel1.Controls.Add(this.oltDGVImage);
            this.oltPanel1.Controls.Add(this.oltTableLayoutPanelActionItemDef);
            this.oltPanel1.Controls.Add(this.oltLabelActionItemDefImagesTitle);
            this.oltPanel1.Name = "oltPanel1";
            // 
            // oltDGVImage
            // 
            this.oltDGVImage.AllowUserToAddRows = false;
            this.oltDGVImage.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.oltDGVImage, "oltDGVImage");
            this.oltDGVImage.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.oltDGVImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oltDGVImage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Remove,
            this.Type,
            this.ImageName,
            this.DescriptionActionItemDef,
            this.Column3,
            this.ImageId,
            this.Action});
            this.oltDGVImage.Name = "oltDGVImage";
            this.oltDGVImage.RowHeadersVisible = false;
            this.oltDGVImage.StandardTab = true;
            this.oltDGVImage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oltDGVImage_CellClick);
            // 
            // Remove
            // 
            this.Remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Remove, "Remove");
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Text = "Remove";
            this.Remove.UseColumnTextForButtonValue = true;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.DataPropertyName = "Types";
            resources.ApplyResources(this.Type, "Type");
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // ImageName
            // 
            this.ImageName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ImageName.DataPropertyName = "Name";
            resources.ApplyResources(this.ImageName, "ImageName");
            this.ImageName.Name = "ImageName";
            // 
            // DescriptionActionItemDef
            // 
            this.DescriptionActionItemDef.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DescriptionActionItemDef.DataPropertyName = "Description";
            resources.ApplyResources(this.DescriptionActionItemDef, "DescriptionActionItemDef");
            this.DescriptionActionItemDef.Name = "DescriptionActionItemDef";
            this.DescriptionActionItemDef.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "ImagePath";
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ImageId
            // 
            this.ImageId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ImageId.DataPropertyName = "Id";
            resources.ApplyResources(this.ImageId, "ImageId");
            this.ImageId.Name = "ImageId";
            this.ImageId.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.DataPropertyName = "Action";
            resources.ApplyResources(this.Action, "Action");
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // oltTableLayoutPanelActionItemDef
            // 
            resources.ApplyResources(this.oltTableLayoutPanelActionItemDef, "oltTableLayoutPanelActionItemDef");
            this.oltTableLayoutPanelActionItemDef.Controls.Add(this.txtName, 1, 1);
            this.oltTableLayoutPanelActionItemDef.Controls.Add(this.txtDescription, 1, 1);
            this.oltTableLayoutPanelActionItemDef.Controls.Add(this.oltLabel2, 2, 0);
            this.oltTableLayoutPanelActionItemDef.Controls.Add(this.oltbtnbrowse, 4, 1);
            this.oltTableLayoutPanelActionItemDef.Controls.Add(this.txtFilePath, 3, 1);
            this.oltTableLayoutPanelActionItemDef.Controls.Add(this.oltLabel3, 3, 0);
            this.oltTableLayoutPanelActionItemDef.Controls.Add(this.oltLabel4, 0, 0);
            this.oltTableLayoutPanelActionItemDef.Controls.Add(this.oltCmbImageType, 0, 1);
            this.oltTableLayoutPanelActionItemDef.Controls.Add(this.oltLabel5, 0, 0);
            this.oltTableLayoutPanelActionItemDef.Controls.Add(this.oltbtnAdd, 5, 1);
            this.oltTableLayoutPanelActionItemDef.Name = "oltTableLayoutPanelActionItemDef";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.OltAcceptsReturn = true;
            this.txtName.OltTrimWhitespace = true;
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.OltAcceptsReturn = true;
            this.txtDescription.OltTrimWhitespace = true;
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // oltbtnbrowse
            // 
            resources.ApplyResources(this.oltbtnbrowse, "oltbtnbrowse");
            this.oltbtnbrowse.Name = "oltbtnbrowse";
            this.oltbtnbrowse.UseVisualStyleBackColor = true;
            this.oltbtnbrowse.Click += new System.EventHandler(this.oltbtnbrowse_Click);
            // 
            // txtFilePath
            // 
            resources.ApplyResources(this.txtFilePath, "txtFilePath");
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.OltAcceptsReturn = true;
            this.txtFilePath.OltTrimWhitespace = true;
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // oltLabel3
            // 
            resources.ApplyResources(this.oltLabel3, "oltLabel3");
            this.oltLabel3.Name = "oltLabel3";
            // 
            // oltLabel4
            // 
            resources.ApplyResources(this.oltLabel4, "oltLabel4");
            this.oltLabel4.Name = "oltLabel4";
            // 
            // oltCmbImageType
            // 
            resources.ApplyResources(this.oltCmbImageType, "oltCmbImageType");
            this.oltCmbImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oltCmbImageType.FormattingEnabled = true;
            this.oltCmbImageType.Items.AddRange(new object[] {
            resources.GetString("oltCmbImageType.Items")});
            this.oltCmbImageType.Name = "oltCmbImageType";
            this.oltCmbImageType.SelectedIndexChanged += new System.EventHandler(this.oltCmbImageType_SelectedIndexChanged);
            // 
            // oltLabel5
            // 
            resources.ApplyResources(this.oltLabel5, "oltLabel5");
            this.oltLabel5.Name = "oltLabel5";
            // 
            // oltbtnAdd
            // 
            resources.ApplyResources(this.oltbtnAdd, "oltbtnAdd");
            this.oltbtnAdd.Name = "oltbtnAdd";
            this.oltbtnAdd.UseVisualStyleBackColor = true;
            this.oltbtnAdd.Click += new System.EventHandler(this.oltbtnAdd_Click);
            // 
            // oltLabelActionItemDefImagesTitle
            // 
            resources.ApplyResources(this.oltLabelActionItemDefImagesTitle, "oltLabelActionItemDefImagesTitle");
            this.oltLabelActionItemDefImagesTitle.Name = "oltLabelActionItemDefImagesTitle";
            this.oltLabelActionItemDefImagesTitle.TabStop = false;
            // 
            // RestTableLayoutPanel
            // 
            resources.ApplyResources(this.RestTableLayoutPanel, "RestTableLayoutPanel");
            this.RestTableLayoutPanel.Controls.Add(this.oltLabelLine1, 0, 4);
            this.RestTableLayoutPanel.Controls.Add(this.commentOnlyCheckBox, 1, 2);
            this.RestTableLayoutPanel.Controls.Add(this.CategoryGroupBox, 0, 6);
            this.RestTableLayoutPanel.Controls.Add(this.oltGroupBox1, 0, 2);
            this.RestTableLayoutPanel.Controls.Add(this.oltGroupBox2, 0, 3);
            this.RestTableLayoutPanel.Controls.Add(this.actionItemNameGroupBox, 0, 5);
            this.RestTableLayoutPanel.Controls.Add(this.functionalLocationGroupBox, 1, 5);
            this.RestTableLayoutPanel.Controls.Add(this.detailsLabelLine, 1, 1);
            this.RestTableLayoutPanel.Controls.Add(this.customFieldPhTagLegendControl, 1, 0);
            this.RestTableLayoutPanel.Controls.Add(this.oltGroupBox6, 0, 8);
            this.RestTableLayoutPanel.Controls.Add(this.createLogCheckBox, 0, 9);
            this.RestTableLayoutPanel.Controls.Add(this.makeLogAnOperatingEngineerCheckBox, 1, 9);
            this.RestTableLayoutPanel.Name = "RestTableLayoutPanel";
            // 
            // oltLabelLine1
            // 
            this.RestTableLayoutPanel.SetColumnSpan(this.oltLabelLine1, 2);
            resources.ApplyResources(this.oltLabelLine1, "oltLabelLine1");
            this.oltLabelLine1.Name = "oltLabelLine1";
            this.oltLabelLine1.TabStop = false;
            // 
            // commentOnlyCheckBox
            // 
            resources.ApplyResources(this.commentOnlyCheckBox, "commentOnlyCheckBox");
            this.commentOnlyCheckBox.Name = "commentOnlyCheckBox";
            this.commentOnlyCheckBox.UseVisualStyleBackColor = true;
            this.commentOnlyCheckBox.Value = null;
            // 
            // CategoryGroupBox
            // 
            resources.ApplyResources(this.CategoryGroupBox, "CategoryGroupBox");
            this.CategoryGroupBox.Controls.Add(this.categoryLabelValue);
            this.CategoryGroupBox.Name = "CategoryGroupBox";
            this.CategoryGroupBox.TabStop = false;
            // 
            // categoryLabelValue
            // 
            resources.ApplyResources(this.categoryLabelValue, "categoryLabelValue");
            this.categoryLabelValue.Name = "categoryLabelValue";
            // 
            // oltGroupBox1
            // 
            this.oltGroupBox1.Controls.Add(this.reasonCodeComboBox);
            resources.ApplyResources(this.oltGroupBox1, "oltGroupBox1");
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.TabStop = false;
            // 
            // reasonCodeComboBox
            // 
            this.reasonCodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reasonCodeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.reasonCodeComboBox, "reasonCodeComboBox");
            this.reasonCodeComboBox.Name = "reasonCodeComboBox";
            // 
            // oltGroupBox2
            // 
            resources.ApplyResources(this.oltGroupBox2, "oltGroupBox2");
            this.RestTableLayoutPanel.SetColumnSpan(this.oltGroupBox2, 2);
            this.oltGroupBox2.Controls.Add(this.commentTextBox);
            this.oltGroupBox2.Name = "oltGroupBox2";
            this.oltGroupBox2.TabStop = false;
            // 
            // commentTextBox
            // 
            resources.ApplyResources(this.commentTextBox, "commentTextBox");
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.OltAcceptsReturn = true;
            this.commentTextBox.OltTrimWhitespace = true;
            // 
            // actionItemNameGroupBox
            // 
            resources.ApplyResources(this.actionItemNameGroupBox, "actionItemNameGroupBox");
            this.actionItemNameGroupBox.Controls.Add(this.actionItemLabelValue);
            this.actionItemNameGroupBox.Name = "actionItemNameGroupBox";
            this.actionItemNameGroupBox.TabStop = false;
            // 
            // actionItemLabelValue
            // 
            resources.ApplyResources(this.actionItemLabelValue, "actionItemLabelValue");
            this.actionItemLabelValue.Name = "actionItemLabelValue";
            // 
            // functionalLocationGroupBox
            // 
            resources.ApplyResources(this.functionalLocationGroupBox, "functionalLocationGroupBox");
            this.functionalLocationGroupBox.Controls.Add(this.functionalLocationListBox);
            this.functionalLocationGroupBox.Name = "functionalLocationGroupBox";
            this.RestTableLayoutPanel.SetRowSpan(this.functionalLocationGroupBox, 2);
            this.functionalLocationGroupBox.TabStop = false;
            // 
            // functionalLocationListBox
            // 
            resources.ApplyResources(this.functionalLocationListBox, "functionalLocationListBox");
            this.functionalLocationListBox.Name = "functionalLocationListBox";
            this.functionalLocationListBox.ReadOnly = true;
            // 
            // detailsLabelLine
            // 
            resources.ApplyResources(this.detailsLabelLine, "detailsLabelLine");
            this.RestTableLayoutPanel.SetColumnSpan(this.detailsLabelLine, 2);
            this.detailsLabelLine.Name = "detailsLabelLine";
            this.detailsLabelLine.TabStop = false;
            // 
            // customFieldPhTagLegendControl
            // 
            resources.ApplyResources(this.customFieldPhTagLegendControl, "customFieldPhTagLegendControl");
            this.customFieldPhTagLegendControl.Name = "customFieldPhTagLegendControl";
            // 
            // oltGroupBox6
            // 
            resources.ApplyResources(this.oltGroupBox6, "oltGroupBox6");
            this.RestTableLayoutPanel.SetColumnSpan(this.oltGroupBox6, 2);
            this.oltGroupBox6.Controls.Add(this.detailCommentsTextbox);
            this.oltGroupBox6.Name = "oltGroupBox6";
            this.oltGroupBox6.TabStop = false;
            // 
            // detailCommentsTextbox
            // 
            resources.ApplyResources(this.detailCommentsTextbox, "detailCommentsTextbox");
            this.detailCommentsTextbox.Name = "detailCommentsTextbox";
            this.detailCommentsTextbox.OltAcceptsReturn = true;
            this.detailCommentsTextbox.OltTrimWhitespace = true;
            this.detailCommentsTextbox.ReadOnly = true;
            this.detailCommentsTextbox.TabStop = false;
            // 
            // createLogCheckBox
            // 
            resources.ApplyResources(this.createLogCheckBox, "createLogCheckBox");
            this.createLogCheckBox.Checked = true;
            this.createLogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createLogCheckBox.Name = "createLogCheckBox";
            this.createLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // makeLogAnOperatingEngineerCheckBox
            // 
            resources.ApplyResources(this.makeLogAnOperatingEngineerCheckBox, "makeLogAnOperatingEngineerCheckBox");
            this.makeLogAnOperatingEngineerCheckBox.Name = "makeLogAnOperatingEngineerCheckBox";
            this.makeLogAnOperatingEngineerCheckBox.UseVisualStyleBackColor = true;
            this.makeLogAnOperatingEngineerCheckBox.Value = null;
            // 
            // customFieldsPanel
            // 
            resources.ApplyResources(this.customFieldsPanel, "customFieldsPanel");
            this.customFieldsPanel.Controls.Add(this.oltTableLayoutPanel1);
            this.customFieldsPanel.Controls.Add(this.customFieldsLabelLine);
            this.customFieldsPanel.Name = "customFieldsPanel";
            // 
            // oltTableLayoutPanel1
            // 
            resources.ApplyResources(this.oltTableLayoutPanel1, "oltTableLayoutPanel1");
            this.oltTableLayoutPanel1.Controls.Add(this.customFieldControl, 0, 1);
            this.oltTableLayoutPanel1.Controls.Add(this.customFieldAreaGroupBox, 0, 0);
            this.oltTableLayoutPanel1.Name = "oltTableLayoutPanel1";
            // 
            // customFieldControl
            // 
            resources.ApplyResources(this.customFieldControl, "customFieldControl");
            this.customFieldControl.Name = "customFieldControl";
            // 
            // customFieldAreaGroupBox
            // 
            resources.ApplyResources(this.customFieldAreaGroupBox, "customFieldAreaGroupBox");
            this.customFieldAreaGroupBox.Name = "customFieldAreaGroupBox";
            this.customFieldAreaGroupBox.TabStop = false;
            // 
            // customFieldsLabelLine
            // 
            resources.ApplyResources(this.customFieldsLabelLine, "customFieldsLabelLine");
            this.customFieldsLabelLine.Name = "customFieldsLabelLine";
            this.customFieldsLabelLine.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.importCustomFieldsButton);
            this.panel1.Controls.Add(this.submitButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Name = "panel1";
            // 
            // submitButton
            // 
            resources.ApplyResources(this.submitButton, "submitButton");
            this.submitButton.Name = "submitButton";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // errorProviderImage
            // 
            this.errorProviderImage.ContainerControl = this;
            // 
            // ActionItemResponseForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.scrollingPanel);
            this.Name = "ActionItemResponseForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.scrollingPanel.ResumeLayout(false);
            this.scrollingPanel.PerformLayout();
            this.lastModifiedPanel.ResumeLayout(false);
            this.shiftGroupBox.ResumeLayout(false);
            this.shiftGroupBox.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.oltPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oltDGVImage)).EndInit();
            this.oltTableLayoutPanelActionItemDef.ResumeLayout(false);
            this.oltTableLayoutPanelActionItemDef.PerformLayout();
            this.RestTableLayoutPanel.ResumeLayout(false);
            this.RestTableLayoutPanel.PerformLayout();
            this.CategoryGroupBox.ResumeLayout(false);
            this.CategoryGroupBox.PerformLayout();
            this.oltGroupBox1.ResumeLayout(false);
            this.oltGroupBox2.ResumeLayout(false);
            this.oltGroupBox2.PerformLayout();
            this.actionItemNameGroupBox.ResumeLayout(false);
            this.actionItemNameGroupBox.PerformLayout();
            this.functionalLocationGroupBox.ResumeLayout(false);
            this.oltGroupBox6.ResumeLayout(false);
            this.oltGroupBox6.PerformLayout();
            this.customFieldsPanel.ResumeLayout(false);
            this.customFieldsPanel.PerformLayout();
            this.oltTableLayoutPanel1.ResumeLayout(false);
            this.oltTableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ErrorProvider errorProvider;
        private ColumnHeader flocColumnHeader;
        private OltPanel scrollingPanel;
        private OltTableLayoutPanel tableLayoutPanel;
        private OltTableLayoutPanel RestTableLayoutPanel;
        private OltCheckBox commentOnlyCheckBox;
        private OltGroupBox functionalLocationGroupBox;
        private Controls.FunctionalLocationListBox functionalLocationListBox;
        private OltGroupBox oltGroupBox6;
        private OltTextBox detailCommentsTextbox;
        private OltGroupBox CategoryGroupBox;
        private OltLabel categoryLabelValue;
        private OltLabelLine detailsLabelLine;
        private OltGroupBox oltGroupBox1;
        private OltComboBox reasonCodeComboBox;
        private OltGroupBox oltGroupBox2;
        private OltTextBox commentTextBox;
        private OltGroupBox actionItemNameGroupBox;
        private OltLabel actionItemLabelValue;
        private OltLabelLine oltLabelLine1;
        private OltPanel customFieldsPanel;
        private OltLabelLine customFieldsLabelLine;
        private OltPanel lastModifiedPanel;
        private OltLastModifiedDateAuthorHeader oltLastModifiedDateAuthorHeader;
        private OltGroupBox shiftGroupBox;
        private OltLabel shiftLabelData;
        private Panel panel1;
        private OltButton importCustomFieldsButton;
        private OltButton submitButton;
        private OltButton cancelButton;
        private Controls.CustomFieldPhTagLegendControl customFieldPhTagLegendControl;
        private OltTableLayoutPanel oltTableLayoutPanel1;
        private Controls.CustomFieldTableLayoutPanel customFieldControl;
        private OltGroupBox customFieldAreaGroupBox;
        private CheckBox createLogCheckBox;
        private OltCheckBox makeLogAnOperatingEngineerCheckBox;
        private OltPanel oltPanel1;
        private OltDataGridView oltDGVImage;
        private DataGridViewButtonColumn Remove;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn ImageName;
        private DataGridViewTextBoxColumn DescriptionActionItemDef;
        private DataGridViewLinkColumn Column3;
        private DataGridViewTextBoxColumn ImageId;
        private DataGridViewTextBoxColumn Action;
        private OltTableLayoutPanel oltTableLayoutPanelActionItemDef;
        private OltTextBox txtName;
        private OltTextBox txtDescription;
        private OltLabel oltLabel2;
        private OltButton oltbtnbrowse;
        private OltTextBox txtFilePath;
        private OltLabel oltLabel3;
        private OltLabel oltLabel4;
        private OltComboBox oltCmbImageType;
        private OltLabel oltLabel5;
        private OltButton oltbtnAdd;
        private OltLabelLine oltLabelActionItemDefImagesTitle;
        private OpenFileDialog openFileDialog1;
        private ErrorProvider errorProviderImage;
    }
}
