using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class DateRangeSelectorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateRangeSelectorForm));
            this.fixedRangeRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.customRangeRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.fixedRangeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.fixedRangeTextLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.startRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.toLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.endRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.selectButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.dateSelectGroupBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateSelectGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // fixedRangeRadioButton
            // 
            resources.ApplyResources(this.fixedRangeRadioButton, "fixedRangeRadioButton");
            this.fixedRangeRadioButton.Name = "fixedRangeRadioButton";
            this.fixedRangeRadioButton.TabStop = true;
            this.fixedRangeRadioButton.UseVisualStyleBackColor = true;
            // 
            // customRangeRadioButton
            // 
            resources.ApplyResources(this.customRangeRadioButton, "customRangeRadioButton");
            this.customRangeRadioButton.Name = "customRangeRadioButton";
            this.customRangeRadioButton.TabStop = true;
            this.customRangeRadioButton.UseVisualStyleBackColor = true;
            // 
            // fixedRangeComboBox
            // 
            this.fixedRangeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fixedRangeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.fixedRangeComboBox, "fixedRangeComboBox");
            this.fixedRangeComboBox.Name = "fixedRangeComboBox";
            // 
            // fixedRangeTextLabel
            // 
            resources.ApplyResources(this.fixedRangeTextLabel, "fixedRangeTextLabel");
            this.fixedRangeTextLabel.Name = "fixedRangeTextLabel";
            // 
            // startRangeDatePicker
            // 
            this.startRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.startRangeDatePicker, "startRangeDatePicker");
            this.startRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startRangeDatePicker.Name = "startRangeDatePicker";
            this.startRangeDatePicker.PickerEnabled = true;
            // 
            // toLabel
            // 
            resources.ApplyResources(this.toLabel, "toLabel");
            this.toLabel.Name = "toLabel";
            // 
            // endRangeDatePicker
            // 
            this.endRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.endRangeDatePicker, "endRangeDatePicker");
            this.endRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endRangeDatePicker.Name = "endRangeDatePicker";
            this.endRangeDatePicker.PickerEnabled = true;
            // 
            // selectButton
            // 
            resources.ApplyResources(this.selectButton, "selectButton");
            this.selectButton.Name = "selectButton";
            this.selectButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // dateSelectGroupBox
            // 
            this.dateSelectGroupBox.Controls.Add(this.fixedRangeRadioButton);
            this.dateSelectGroupBox.Controls.Add(this.customRangeRadioButton);
            this.dateSelectGroupBox.Controls.Add(this.fixedRangeComboBox);
            this.dateSelectGroupBox.Controls.Add(this.endRangeDatePicker);
            this.dateSelectGroupBox.Controls.Add(this.fixedRangeTextLabel);
            this.dateSelectGroupBox.Controls.Add(this.toLabel);
            this.dateSelectGroupBox.Controls.Add(this.startRangeDatePicker);
            resources.ApplyResources(this.dateSelectGroupBox, "dateSelectGroupBox");
            this.dateSelectGroupBox.Name = "dateSelectGroupBox";
            this.dateSelectGroupBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.selectButton);
            this.panel1.Controls.Add(this.cancelButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // DateRangeSelectorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dateSelectGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DateRangeSelectorForm";
            this.dateSelectGroupBox.ResumeLayout(false);
            this.dateSelectGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltRadioButton fixedRangeRadioButton;
        private OltRadioButton customRangeRadioButton;
        private OltComboBox fixedRangeComboBox;
        private OltLabel fixedRangeTextLabel;
        private OltDatePicker startRangeDatePicker;
        private OltLabel toLabel;
        private OltDatePicker endRangeDatePicker;
        private OltButton selectButton;
        private OltButton cancelButton;
        private System.Windows.Forms.GroupBox dateSelectGroupBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}