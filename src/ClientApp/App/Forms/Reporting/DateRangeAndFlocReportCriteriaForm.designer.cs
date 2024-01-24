using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    partial class DateRangeAndFlocReportCriteriaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateRangeAndFlocReportCriteriaForm));
            this.runReportButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.startDateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.endRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.startRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.label2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.label1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.groupBox2 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocSelectionControl = new Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl();
            this.endDateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.startDateErrorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endDateErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // runReportButton
            // 
            resources.ApplyResources(this.runReportButton, "runReportButton");
            this.startDateErrorProvider.SetError(this.runReportButton, resources.GetString("runReportButton.Error"));
            this.endDateErrorProvider.SetError(this.runReportButton, resources.GetString("runReportButton.Error1"));
            this.startDateErrorProvider.SetIconAlignment(this.runReportButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("runReportButton.IconAlignment"))));
            this.endDateErrorProvider.SetIconAlignment(this.runReportButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("runReportButton.IconAlignment1"))));
            this.startDateErrorProvider.SetIconPadding(this.runReportButton, ((int)(resources.GetObject("runReportButton.IconPadding"))));
            this.endDateErrorProvider.SetIconPadding(this.runReportButton, ((int)(resources.GetObject("runReportButton.IconPadding1"))));
            this.runReportButton.Name = "runReportButton";
            this.runReportButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.startDateErrorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error"));
            this.endDateErrorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error1"));
            this.startDateErrorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.endDateErrorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment1"))));
            this.startDateErrorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding"))));
            this.endDateErrorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding1"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // startDateErrorProvider
            // 
            this.startDateErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.startDateErrorProvider, "startDateErrorProvider");
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.endRangeDatePicker);
            this.groupBox1.Controls.Add(this.startRangeDatePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.endDateErrorProvider.SetError(this.groupBox1, resources.GetString("groupBox1.Error"));
            this.startDateErrorProvider.SetError(this.groupBox1, resources.GetString("groupBox1.Error1"));
            this.endDateErrorProvider.SetIconAlignment(this.groupBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox1.IconAlignment"))));
            this.startDateErrorProvider.SetIconAlignment(this.groupBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox1.IconAlignment1"))));
            this.startDateErrorProvider.SetIconPadding(this.groupBox1, ((int)(resources.GetObject("groupBox1.IconPadding"))));
            this.endDateErrorProvider.SetIconPadding(this.groupBox1, ((int)(resources.GetObject("groupBox1.IconPadding1"))));
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // endRangeDatePicker
            // 
            resources.ApplyResources(this.endRangeDatePicker, "endRangeDatePicker");
            this.endRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.startDateErrorProvider.SetError(this.endRangeDatePicker, resources.GetString("endRangeDatePicker.Error"));
            this.endDateErrorProvider.SetError(this.endRangeDatePicker, resources.GetString("endRangeDatePicker.Error1"));
            this.startDateErrorProvider.SetIconAlignment(this.endRangeDatePicker, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("endRangeDatePicker.IconAlignment"))));
            this.endDateErrorProvider.SetIconAlignment(this.endRangeDatePicker, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("endRangeDatePicker.IconAlignment1"))));
            this.startDateErrorProvider.SetIconPadding(this.endRangeDatePicker, ((int)(resources.GetObject("endRangeDatePicker.IconPadding"))));
            this.endDateErrorProvider.SetIconPadding(this.endRangeDatePicker, ((int)(resources.GetObject("endRangeDatePicker.IconPadding1"))));
            this.endRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endRangeDatePicker.Name = "endRangeDatePicker";
            this.endRangeDatePicker.PickerEnabled = true;
            // 
            // startRangeDatePicker
            // 
            resources.ApplyResources(this.startRangeDatePicker, "startRangeDatePicker");
            this.startRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.startDateErrorProvider.SetError(this.startRangeDatePicker, resources.GetString("startRangeDatePicker.Error"));
            this.endDateErrorProvider.SetError(this.startRangeDatePicker, resources.GetString("startRangeDatePicker.Error1"));
            this.startDateErrorProvider.SetIconAlignment(this.startRangeDatePicker, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("startRangeDatePicker.IconAlignment"))));
            this.endDateErrorProvider.SetIconAlignment(this.startRangeDatePicker, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("startRangeDatePicker.IconAlignment1"))));
            this.startDateErrorProvider.SetIconPadding(this.startRangeDatePicker, ((int)(resources.GetObject("startRangeDatePicker.IconPadding"))));
            this.endDateErrorProvider.SetIconPadding(this.startRangeDatePicker, ((int)(resources.GetObject("startRangeDatePicker.IconPadding1"))));
            this.startRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startRangeDatePicker.Name = "startRangeDatePicker";
            this.startRangeDatePicker.PickerEnabled = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.startDateErrorProvider.SetError(this.label2, resources.GetString("label2.Error"));
            this.endDateErrorProvider.SetError(this.label2, resources.GetString("label2.Error1"));
            this.endDateErrorProvider.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.startDateErrorProvider.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment1"))));
            this.endDateErrorProvider.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.startDateErrorProvider.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding1"))));
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.startDateErrorProvider.SetError(this.label1, resources.GetString("label1.Error"));
            this.endDateErrorProvider.SetError(this.label1, resources.GetString("label1.Error1"));
            this.endDateErrorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.startDateErrorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment1"))));
            this.endDateErrorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.startDateErrorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding1"))));
            this.label1.Name = "label1";
            // 
            // buttonPanel
            // 
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Controls.Add(this.runReportButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.endDateErrorProvider.SetError(this.buttonPanel, resources.GetString("buttonPanel.Error"));
            this.startDateErrorProvider.SetError(this.buttonPanel, resources.GetString("buttonPanel.Error1"));
            this.startDateErrorProvider.SetIconAlignment(this.buttonPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonPanel.IconAlignment"))));
            this.endDateErrorProvider.SetIconAlignment(this.buttonPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonPanel.IconAlignment1"))));
            this.endDateErrorProvider.SetIconPadding(this.buttonPanel, ((int)(resources.GetObject("buttonPanel.IconPadding"))));
            this.startDateErrorProvider.SetIconPadding(this.buttonPanel, ((int)(resources.GetObject("buttonPanel.IconPadding1"))));
            this.buttonPanel.Name = "buttonPanel";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.flocSelectionControl);
            this.endDateErrorProvider.SetError(this.groupBox2, resources.GetString("groupBox2.Error"));
            this.startDateErrorProvider.SetError(this.groupBox2, resources.GetString("groupBox2.Error1"));
            this.endDateErrorProvider.SetIconAlignment(this.groupBox2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox2.IconAlignment"))));
            this.startDateErrorProvider.SetIconAlignment(this.groupBox2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox2.IconAlignment1"))));
            this.startDateErrorProvider.SetIconPadding(this.groupBox2, ((int)(resources.GetObject("groupBox2.IconPadding"))));
            this.endDateErrorProvider.SetIconPadding(this.groupBox2, ((int)(resources.GetObject("groupBox2.IconPadding1"))));
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // flocSelectionControl
            // 
            resources.ApplyResources(this.flocSelectionControl, "flocSelectionControl");
            this.startDateErrorProvider.SetError(this.flocSelectionControl, resources.GetString("flocSelectionControl.Error"));
            this.endDateErrorProvider.SetError(this.flocSelectionControl, resources.GetString("flocSelectionControl.Error1"));
            this.startDateErrorProvider.SetIconAlignment(this.flocSelectionControl, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("flocSelectionControl.IconAlignment"))));
            this.endDateErrorProvider.SetIconAlignment(this.flocSelectionControl, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("flocSelectionControl.IconAlignment1"))));
            this.endDateErrorProvider.SetIconPadding(this.flocSelectionControl, ((int)(resources.GetObject("flocSelectionControl.IconPadding"))));
            this.startDateErrorProvider.SetIconPadding(this.flocSelectionControl, ((int)(resources.GetObject("flocSelectionControl.IconPadding1"))));
            this.flocSelectionControl.Name = "flocSelectionControl";
            // 
            // endDateErrorProvider
            // 
            this.endDateErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.endDateErrorProvider, "endDateErrorProvider");
            // 
            // DateRangeAndFlocReportCriteriaForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "DateRangeAndFlocReportCriteriaForm";
            ((System.ComponentModel.ISupportInitialize)(this.startDateErrorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.endDateErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton runReportButton;
        private OltButton cancelButton;
        private System.Windows.Forms.ErrorProvider startDateErrorProvider;
        private OltGroupBox groupBox1;
        private OltLabel label1;
        private OltPanel buttonPanel;
        private OltLabel label2;
        private OltDatePicker startRangeDatePicker;
        private OltDatePicker endRangeDatePicker;
        private OltGroupBox groupBox2;
        private Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl flocSelectionControl;
        private System.Windows.Forms.ErrorProvider endDateErrorProvider;
    }
}