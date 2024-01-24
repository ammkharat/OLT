namespace Com.Suncor.Olt.Client.Forms
{
    partial class AddEditTrainingBlockForm
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
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltPanel2 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.functionalLocationsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocSelectionControl = new Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl();
            this.oltPanel3 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.clearFlocsButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.trainingCodeTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.trainingBlockNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.trainingCodeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.trainingBlockLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.oltPanel1.SuspendLayout();
            this.oltPanel2.SuspendLayout();
            this.functionalLocationsGroupBox.SuspendLayout();
            this.oltPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.saveButton);
            this.oltPanel1.Controls.Add(this.cancelButton);
            this.oltPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.oltPanel1.Location = new System.Drawing.Point(0, 546);
            this.oltPanel1.Name = "oltPanel1";
            this.oltPanel1.Size = new System.Drawing.Size(660, 45);
            this.oltPanel1.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(492, 10);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(573, 10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // oltPanel2
            // 
            this.oltPanel2.Controls.Add(this.functionalLocationsGroupBox);
            this.oltPanel2.Controls.Add(this.trainingCodeTextBox);
            this.oltPanel2.Controls.Add(this.trainingBlockNameTextBox);
            this.oltPanel2.Controls.Add(this.trainingCodeLabel);
            this.oltPanel2.Controls.Add(this.trainingBlockLabel);
            this.oltPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oltPanel2.Location = new System.Drawing.Point(0, 0);
            this.oltPanel2.Name = "oltPanel2";
            this.oltPanel2.Size = new System.Drawing.Size(660, 546);
            this.oltPanel2.TabIndex = 1;
            // 
            // functionalLocationsGroupBox
            // 
            this.functionalLocationsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionalLocationsGroupBox.Controls.Add(this.flocSelectionControl);
            this.functionalLocationsGroupBox.Controls.Add(this.oltPanel3);
            this.functionalLocationsGroupBox.Location = new System.Drawing.Point(15, 96);
            this.functionalLocationsGroupBox.Name = "functionalLocationsGroupBox";
            this.functionalLocationsGroupBox.Size = new System.Drawing.Size(584, 434);
            this.functionalLocationsGroupBox.TabIndex = 4;
            this.functionalLocationsGroupBox.TabStop = false;
            this.functionalLocationsGroupBox.Text = "Training Block available for the following Functional Locations";
            // 
            // flocSelectionControl
            // 
            this.flocSelectionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flocSelectionControl.Location = new System.Drawing.Point(3, 17);
            this.flocSelectionControl.Name = "flocSelectionControl";
            this.flocSelectionControl.Size = new System.Drawing.Size(578, 371);
            this.flocSelectionControl.TabIndex = 1;
            // 
            // oltPanel3
            // 
            this.oltPanel3.Controls.Add(this.clearFlocsButton);
            this.oltPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.oltPanel3.Location = new System.Drawing.Point(3, 388);
            this.oltPanel3.Name = "oltPanel3";
            this.oltPanel3.Size = new System.Drawing.Size(578, 43);
            this.oltPanel3.TabIndex = 0;
            // 
            // clearFlocsButton
            // 
            this.clearFlocsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearFlocsButton.Location = new System.Drawing.Point(497, 7);
            this.clearFlocsButton.Name = "clearFlocsButton";
            this.clearFlocsButton.Size = new System.Drawing.Size(75, 23);
            this.clearFlocsButton.TabIndex = 4;
            this.clearFlocsButton.Text = "Clear All";
            this.clearFlocsButton.UseVisualStyleBackColor = true;
            // 
            // trainingCodeTextBox
            // 
            this.trainingCodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trainingCodeTextBox.Location = new System.Drawing.Point(94, 60);
            this.trainingCodeTextBox.MaxLength = 100;
            this.trainingCodeTextBox.Name = "trainingCodeTextBox";
            this.trainingCodeTextBox.OltAcceptsReturn = true;
            this.trainingCodeTextBox.OltTrimWhitespace = true;
            this.trainingCodeTextBox.Size = new System.Drawing.Size(505, 20);
            this.trainingCodeTextBox.TabIndex = 3;
            // 
            // trainingBlockNameTextBox
            // 
            this.trainingBlockNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trainingBlockNameTextBox.Location = new System.Drawing.Point(94, 23);
            this.trainingBlockNameTextBox.MaxLength = 100;
            this.trainingBlockNameTextBox.Name = "trainingBlockNameTextBox";
            this.trainingBlockNameTextBox.OltAcceptsReturn = true;
            this.trainingBlockNameTextBox.OltTrimWhitespace = true;
            this.trainingBlockNameTextBox.Size = new System.Drawing.Size(505, 20);
            this.trainingBlockNameTextBox.TabIndex = 2;
            // 
            // trainingCodeLabel
            // 
            this.trainingCodeLabel.AutoSize = true;
            this.trainingCodeLabel.Location = new System.Drawing.Point(12, 63);
            this.trainingCodeLabel.Name = "trainingCodeLabel";
            this.trainingCodeLabel.Size = new System.Drawing.Size(77, 13);
            this.trainingCodeLabel.TabIndex = 1;
            this.trainingCodeLabel.Text = "Training Code:";
            // 
            // trainingBlockLabel
            // 
            this.trainingBlockLabel.AutoSize = true;
            this.trainingBlockLabel.Location = new System.Drawing.Point(12, 26);
            this.trainingBlockLabel.Name = "trainingBlockLabel";
            this.trainingBlockLabel.Size = new System.Drawing.Size(76, 13);
            this.trainingBlockLabel.TabIndex = 0;
            this.trainingBlockLabel.Text = "Training Block:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddEditTrainingBlockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(660, 591);
            this.Controls.Add(this.oltPanel2);
            this.Controls.Add(this.oltPanel1);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "AddEditTrainingBlockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEditTrainingBlockForm";
            this.oltPanel1.ResumeLayout(false);
            this.oltPanel2.ResumeLayout(false);
            this.oltPanel2.PerformLayout();
            this.functionalLocationsGroupBox.ResumeLayout(false);
            this.oltPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel oltPanel1;
        private OltControls.OltPanel oltPanel2;
        private OltControls.OltLabel trainingCodeLabel;
        private OltControls.OltLabel trainingBlockLabel;
        private OltControls.OltTextBox trainingCodeTextBox;
        private OltControls.OltTextBox trainingBlockNameTextBox;
        private OltControls.OltButton saveButton;
        private OltControls.OltButton cancelButton;
        private OltControls.OltGroupBox functionalLocationsGroupBox;
        private Controls.MultiSelectFunctionalLocationControl flocSelectionControl;
        private OltControls.OltPanel oltPanel3;
        private OltControls.OltButton clearFlocsButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}