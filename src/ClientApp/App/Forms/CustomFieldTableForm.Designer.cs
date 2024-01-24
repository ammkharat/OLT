namespace Com.Suncor.Olt.Client.Forms
{
    partial class CustomFieldTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomFieldTableForm));
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.exportButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.closeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.dateSelectGroupBox = new System.Windows.Forms.GroupBox();
            this.fixedRangeRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.refreshButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.customRangeRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.fixedRangeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.endRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.fixedRangeTextLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.toLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.startRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.oltPanel2 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.disclaimerLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.gridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltPanel1.SuspendLayout();
            this.dateSelectGroupBox.SuspendLayout();
            this.oltPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.exportButton);
            this.oltPanel1.Controls.Add(this.closeButton);
            this.oltPanel1.Controls.Add(this.dateSelectGroupBox);
            resources.ApplyResources(this.oltPanel1, "oltPanel1");
            this.oltPanel1.Name = "oltPanel1";
            // 
            // exportButton
            // 
            resources.ApplyResources(this.exportButton, "exportButton");
            this.exportButton.Name = "exportButton";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // dateSelectGroupBox
            // 
            resources.ApplyResources(this.dateSelectGroupBox, "dateSelectGroupBox");
            this.dateSelectGroupBox.Controls.Add(this.fixedRangeRadioButton);
            this.dateSelectGroupBox.Controls.Add(this.refreshButton);
            this.dateSelectGroupBox.Controls.Add(this.customRangeRadioButton);
            this.dateSelectGroupBox.Controls.Add(this.fixedRangeComboBox);
            this.dateSelectGroupBox.Controls.Add(this.endRangeDatePicker);
            this.dateSelectGroupBox.Controls.Add(this.fixedRangeTextLabel);
            this.dateSelectGroupBox.Controls.Add(this.toLabel);
            this.dateSelectGroupBox.Controls.Add(this.startRangeDatePicker);
            this.dateSelectGroupBox.Name = "dateSelectGroupBox";
            this.dateSelectGroupBox.TabStop = false;
            // 
            // fixedRangeRadioButton
            // 
            resources.ApplyResources(this.fixedRangeRadioButton, "fixedRangeRadioButton");
            this.fixedRangeRadioButton.Name = "fixedRangeRadioButton";
            this.fixedRangeRadioButton.TabStop = true;
            this.fixedRangeRadioButton.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            resources.ApplyResources(this.refreshButton, "refreshButton");
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.UseVisualStyleBackColor = true;
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
            // endRangeDatePicker
            // 
            this.endRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.endRangeDatePicker, "endRangeDatePicker");
            this.endRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endRangeDatePicker.Name = "endRangeDatePicker";
            this.endRangeDatePicker.PickerEnabled = true;
            // 
            // fixedRangeTextLabel
            // 
            resources.ApplyResources(this.fixedRangeTextLabel, "fixedRangeTextLabel");
            this.fixedRangeTextLabel.Name = "fixedRangeTextLabel";
            // 
            // toLabel
            // 
            resources.ApplyResources(this.toLabel, "toLabel");
            this.toLabel.Name = "toLabel";
            // 
            // startRangeDatePicker
            // 
            this.startRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.startRangeDatePicker, "startRangeDatePicker");
            this.startRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startRangeDatePicker.Name = "startRangeDatePicker";
            this.startRangeDatePicker.PickerEnabled = true;
            // 
            // oltPanel2
            // 
            this.oltPanel2.Controls.Add(this.disclaimerLabel);
            this.oltPanel2.Controls.Add(this.gridPanel);
            resources.ApplyResources(this.oltPanel2, "oltPanel2");
            this.oltPanel2.Name = "oltPanel2";
            // 
            // disclaimerLabel
            // 
            resources.ApplyResources(this.disclaimerLabel, "disclaimerLabel");
            this.disclaimerLabel.Name = "disclaimerLabel";
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.BackColor = System.Drawing.Color.Peru;
            this.gridPanel.Name = "gridPanel";
            // 
            // CustomFieldTableForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oltPanel2);
            this.Controls.Add(this.oltPanel1);
            this.Name = "CustomFieldTableForm";
            this.oltPanel1.ResumeLayout(false);
            this.dateSelectGroupBox.ResumeLayout(false);
            this.dateSelectGroupBox.PerformLayout();
            this.oltPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel oltPanel1;
        private OltControls.OltPanel oltPanel2;
        private System.Windows.Forms.GroupBox dateSelectGroupBox;
        private OltControls.OltRadioButton fixedRangeRadioButton;
        private OltControls.OltButton refreshButton;
        private OltControls.OltRadioButton customRangeRadioButton;
        private OltControls.OltComboBox fixedRangeComboBox;
        private OltControls.OltDatePicker endRangeDatePicker;
        private OltControls.OltLabel fixedRangeTextLabel;
        private OltControls.OltLabel toLabel;
        private OltControls.OltDatePicker startRangeDatePicker;
        private OltControls.OltButton closeButton;
        private OltControls.OltPanel gridPanel;
        private OltControls.OltLabel disclaimerLabel;
        private OltControls.OltButton exportButton;
    }
}