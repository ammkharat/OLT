namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConvertLogBasedDirectivesIntoNewDirectivesForm
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
            this.acceptCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.continueButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.explanationLabel = new DevExpress.XtraEditors.LabelControl();
            this.oltGroupBox3 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.removeFunctionalLocationButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.functionalLocationListBox = new Com.Suncor.Olt.Client.Controls.FunctionalLocationListBox();
            this.addFunctionalLocationButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonPanel.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            this.oltGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // acceptCheckBox
            // 
            this.acceptCheckBox.AutoSize = true;
            this.acceptCheckBox.Location = new System.Drawing.Point(232, 220);
            this.acceptCheckBox.Name = "acceptCheckBox";
            this.acceptCheckBox.Size = new System.Drawing.Size(87, 17);
            this.acceptCheckBox.TabIndex = 1;
            this.acceptCheckBox.Text = "Let\'s do this.";
            this.acceptCheckBox.UseVisualStyleBackColor = true;
            this.acceptCheckBox.Value = null;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.continueButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 266);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(584, 46);
            this.buttonPanel.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(497, 11);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // continueButton
            // 
            this.continueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.continueButton.Location = new System.Drawing.Point(416, 11);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 0;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.oltGroupBox3);
            this.oltPanel1.Controls.Add(this.explanationLabel);
            this.oltPanel1.Controls.Add(this.acceptCheckBox);
            this.oltPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oltPanel1.Location = new System.Drawing.Point(0, 0);
            this.oltPanel1.Name = "oltPanel1";
            this.oltPanel1.Size = new System.Drawing.Size(584, 266);
            this.oltPanel1.TabIndex = 0;
            // 
            // explanationLabel
            // 
            this.explanationLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.explanationLabel.Location = new System.Drawing.Point(68, 151);
            this.explanationLabel.Name = "explanationLabel";
            this.explanationLabel.Size = new System.Drawing.Size(433, 39);
            this.explanationLabel.TabIndex = 2;
            this.explanationLabel.Text = "If you check the following box and click Continue, log-based directives [data onl" +
    "y for the functional locations selected above] in {0} will be converted to the n" +
    "ewer directives infrastructure.";
            // 
            // oltGroupBox3
            // 
            this.oltGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oltGroupBox3.Controls.Add(this.removeFunctionalLocationButton);
            this.oltGroupBox3.Controls.Add(this.functionalLocationListBox);
            this.oltGroupBox3.Controls.Add(this.addFunctionalLocationButton);
            this.oltGroupBox3.Location = new System.Drawing.Point(68, 30);
            this.oltGroupBox3.Name = "oltGroupBox3";
            this.oltGroupBox3.Size = new System.Drawing.Size(433, 101);
            this.oltGroupBox3.TabIndex = 3;
            this.oltGroupBox3.TabStop = false;
            this.oltGroupBox3.Text = "Functional Locations";
            // 
            // removeFunctionalLocationButton
            // 
            this.removeFunctionalLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeFunctionalLocationButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.removeFunctionalLocationButton.Location = new System.Drawing.Point(336, 54);
            this.removeFunctionalLocationButton.Name = "removeFunctionalLocationButton";
            this.removeFunctionalLocationButton.Size = new System.Drawing.Size(91, 23);
            this.removeFunctionalLocationButton.TabIndex = 2;
            this.removeFunctionalLocationButton.Text = "Remove";
            this.removeFunctionalLocationButton.UseVisualStyleBackColor = true;
            // 
            // functionalLocationListBox
            // 
            this.functionalLocationListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionalLocationListBox.Location = new System.Drawing.Point(6, 20);
            this.functionalLocationListBox.Name = "functionalLocationListBox";
            this.functionalLocationListBox.ReadOnly = false;
            this.functionalLocationListBox.Size = new System.Drawing.Size(309, 69);
            this.functionalLocationListBox.TabIndex = 0;
            // 
            // addFunctionalLocationButton
            // 
            this.addFunctionalLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addFunctionalLocationButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addFunctionalLocationButton.Location = new System.Drawing.Point(336, 25);
            this.addFunctionalLocationButton.Name = "addFunctionalLocationButton";
            this.addFunctionalLocationButton.Size = new System.Drawing.Size(91, 23);
            this.addFunctionalLocationButton.TabIndex = 1;
            this.addFunctionalLocationButton.Text = "Add...";
            this.addFunctionalLocationButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ConvertLogBasedDirectivesIntoNewDirectivesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(584, 312);
            this.Controls.Add(this.oltPanel1);
            this.Controls.Add(this.buttonPanel);
            this.MaximumSize = new System.Drawing.Size(600, 350);
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "ConvertLogBasedDirectivesIntoNewDirectivesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convert Log Based Directives into New Directives";
            this.buttonPanel.ResumeLayout(false);
            this.oltPanel1.ResumeLayout(false);
            this.oltPanel1.PerformLayout();
            this.oltGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltCheckBox acceptCheckBox;
        private OltControls.OltPanel buttonPanel;
        private OltControls.OltButton cancelButton;
        private OltControls.OltButton continueButton;
        private OltControls.OltPanel oltPanel1;
        private DevExpress.XtraEditors.LabelControl explanationLabel;
        private OltControls.OltGroupBox oltGroupBox3;
        private OltControls.OltButton removeFunctionalLocationButton;
        private Controls.FunctionalLocationListBox functionalLocationListBox;
        private OltControls.OltButton addFunctionalLocationButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}