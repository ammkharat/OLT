using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ImportPermitRequestMultiDayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportPermitRequestMultiDayForm));
            this.importButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.fromDateGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.startRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.lastImportDateTimeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.lastImportLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.toDateGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.endRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.fromDateGroupBox.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.toDateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // importButton
            // 
            resources.ApplyResources(this.importButton, "importButton");
            this.errorProvider.SetError(this.importButton, resources.GetString("importButton.Error"));
            this.errorProvider.SetIconAlignment(this.importButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("importButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.importButton, ((int)(resources.GetObject("importButton.IconPadding"))));
            this.importButton.Name = "importButton";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error"));
            this.errorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // fromDateGroupBox
            // 
            resources.ApplyResources(this.fromDateGroupBox, "fromDateGroupBox");
            this.fromDateGroupBox.Controls.Add(this.startRangeDatePicker);
            this.errorProvider.SetError(this.fromDateGroupBox, resources.GetString("fromDateGroupBox.Error"));
            this.errorProvider.SetIconAlignment(this.fromDateGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("fromDateGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.fromDateGroupBox, ((int)(resources.GetObject("fromDateGroupBox.IconPadding"))));
            this.fromDateGroupBox.Name = "fromDateGroupBox";
            this.fromDateGroupBox.TabStop = false;
            // 
            // startRangeDatePicker
            // 
            resources.ApplyResources(this.startRangeDatePicker, "startRangeDatePicker");
            this.startRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.errorProvider.SetError(this.startRangeDatePicker, resources.GetString("startRangeDatePicker.Error"));
            this.errorProvider.SetIconAlignment(this.startRangeDatePicker, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("startRangeDatePicker.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.startRangeDatePicker, ((int)(resources.GetObject("startRangeDatePicker.IconPadding"))));
            this.startRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startRangeDatePicker.Name = "startRangeDatePicker";
            this.startRangeDatePicker.PickerEnabled = true;
            // 
            // buttonPanel
            // 
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Controls.Add(this.importButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.errorProvider.SetError(this.buttonPanel, resources.GetString("buttonPanel.Error"));
            this.errorProvider.SetIconAlignment(this.buttonPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonPanel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.buttonPanel, ((int)(resources.GetObject("buttonPanel.IconPadding"))));
            this.buttonPanel.Name = "buttonPanel";
            // 
            // lastImportDateTimeLabel
            // 
            resources.ApplyResources(this.lastImportDateTimeLabel, "lastImportDateTimeLabel");
            this.errorProvider.SetError(this.lastImportDateTimeLabel, resources.GetString("lastImportDateTimeLabel.Error"));
            this.errorProvider.SetIconAlignment(this.lastImportDateTimeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lastImportDateTimeLabel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.lastImportDateTimeLabel, ((int)(resources.GetObject("lastImportDateTimeLabel.IconPadding"))));
            this.lastImportDateTimeLabel.Name = "lastImportDateTimeLabel";
            // 
            // lastImportLabelData
            // 
            resources.ApplyResources(this.lastImportLabelData, "lastImportLabelData");
            this.errorProvider.SetError(this.lastImportLabelData, resources.GetString("lastImportLabelData.Error"));
            this.errorProvider.SetIconAlignment(this.lastImportLabelData, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lastImportLabelData.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.lastImportLabelData, ((int)(resources.GetObject("lastImportLabelData.IconPadding"))));
            this.lastImportLabelData.Name = "lastImportLabelData";
            this.lastImportLabelData.UseMnemonic = false;
            // 
            // toDateGroupBox
            // 
            resources.ApplyResources(this.toDateGroupBox, "toDateGroupBox");
            this.toDateGroupBox.Controls.Add(this.endRangeDatePicker);
            this.errorProvider.SetError(this.toDateGroupBox, resources.GetString("toDateGroupBox.Error"));
            this.errorProvider.SetIconAlignment(this.toDateGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("toDateGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.toDateGroupBox, ((int)(resources.GetObject("toDateGroupBox.IconPadding"))));
            this.toDateGroupBox.Name = "toDateGroupBox";
            this.toDateGroupBox.TabStop = false;
            // 
            // endRangeDatePicker
            // 
            resources.ApplyResources(this.endRangeDatePicker, "endRangeDatePicker");
            this.endRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.errorProvider.SetError(this.endRangeDatePicker, resources.GetString("endRangeDatePicker.Error"));
            this.errorProvider.SetIconAlignment(this.endRangeDatePicker, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("endRangeDatePicker.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.endRangeDatePicker, ((int)(resources.GetObject("endRangeDatePicker.IconPadding"))));
            this.endRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endRangeDatePicker.Name = "endRangeDatePicker";
            this.endRangeDatePicker.PickerEnabled = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // ImportPermitRequestMultiDayForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.toDateGroupBox);
            this.Controls.Add(this.lastImportLabelData);
            this.Controls.Add(this.lastImportDateTimeLabel);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.fromDateGroupBox);
            this.MaximizeBox = false;
            this.Name = "ImportPermitRequestMultiDayForm";
            this.fromDateGroupBox.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.toDateGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton importButton;
        private OltButton cancelButton;
        private OltGroupBox fromDateGroupBox;
        private OltPanel buttonPanel;
        private OltDatePicker startRangeDatePicker;
        private OltLabelData lastImportLabelData;
        private OltLabel lastImportDateTimeLabel;
        private OltGroupBox toDateGroupBox;
        private OltDatePicker endRangeDatePicker;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}