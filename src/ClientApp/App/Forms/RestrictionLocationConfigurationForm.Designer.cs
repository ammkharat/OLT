namespace Com.Suncor.Olt.Client.Forms
{
    partial class RestrictionLocationConfigurationForm
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.removeWorkAssignmentButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addWorkAssignmentButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.workAssignmentsForThisLocation = new Com.Suncor.Olt.Client.OltControls.OltListBox();
            this.allAvailableWorkAssignmentsListBox = new Com.Suncor.Olt.Client.OltControls.OltListBox();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.functionalLocationBrowseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.functionalLocationTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltGroupBox3 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.itemReasonCodePanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltPanel4 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.selectReasonCodesButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltGroupBox2 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.locationItemTreeView = new Com.Suncor.Olt.Client.Controls.LocationItemTreeView();
            this.oltPanel3 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.renameItemButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.moveItemButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.removeItemButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addItemButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.locationGroupBox = new System.Windows.Forms.GroupBox();
            this.locationDisplayLabel = new System.Windows.Forms.Label();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltTabControl1 = new Com.Suncor.Olt.Client.OltControls.OltTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.oltGroupBox1.SuspendLayout();
            this.oltGroupBox3.SuspendLayout();
            this.oltPanel4.SuspendLayout();
            this.oltGroupBox2.SuspendLayout();
            this.oltPanel3.SuspendLayout();
            this.locationGroupBox.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oltTabControl1)).BeginInit();
            this.oltTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.oltLabel2);
            this.ultraTabPageControl1.Controls.Add(this.oltLabel1);
            this.ultraTabPageControl1.Controls.Add(this.removeWorkAssignmentButton);
            this.ultraTabPageControl1.Controls.Add(this.addWorkAssignmentButton);
            this.ultraTabPageControl1.Controls.Add(this.workAssignmentsForThisLocation);
            this.ultraTabPageControl1.Controls.Add(this.allAvailableWorkAssignmentsListBox);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(868, 508);
            // 
            // oltLabel2
            // 
            this.oltLabel2.AutoSize = true;
            this.oltLabel2.Location = new System.Drawing.Point(381, 15);
            this.oltLabel2.Name = "oltLabel2";
            this.oltLabel2.Size = new System.Drawing.Size(130, 13);
            this.oltLabel2.TabIndex = 16;
            this.oltLabel2.Text = "Assigned to this Location:";
            // 
            // oltLabel1
            // 
            this.oltLabel1.AutoSize = true;
            this.oltLabel1.Location = new System.Drawing.Point(11, 15);
            this.oltLabel1.Name = "oltLabel1";
            this.oltLabel1.Size = new System.Drawing.Size(228, 13);
            this.oltLabel1.TabIndex = 15;
            this.oltLabel1.Text = "Work Assignments not assigned to a Location:";
            // 
            // removeWorkAssignmentButton
            // 
            this.removeWorkAssignmentButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.removeWorkAssignmentButton.Location = new System.Drawing.Point(338, 235);
            this.removeWorkAssignmentButton.Name = "removeWorkAssignmentButton";
            this.removeWorkAssignmentButton.Size = new System.Drawing.Size(30, 23);
            this.removeWorkAssignmentButton.TabIndex = 14;
            this.removeWorkAssignmentButton.Text = "<";
            this.removeWorkAssignmentButton.UseVisualStyleBackColor = true;
            // 
            // addWorkAssignmentButton
            // 
            this.addWorkAssignmentButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addWorkAssignmentButton.Location = new System.Drawing.Point(338, 190);
            this.addWorkAssignmentButton.Name = "addWorkAssignmentButton";
            this.addWorkAssignmentButton.Size = new System.Drawing.Size(30, 23);
            this.addWorkAssignmentButton.TabIndex = 13;
            this.addWorkAssignmentButton.Text = ">";
            this.addWorkAssignmentButton.UseVisualStyleBackColor = true;
            // 
            // workAssignmentsForThisLocation
            // 
            this.workAssignmentsForThisLocation.BackColor = System.Drawing.Color.White;
            this.workAssignmentsForThisLocation.DisplayMember = "Name";
            this.workAssignmentsForThisLocation.FormattingEnabled = true;
            this.workAssignmentsForThisLocation.Location = new System.Drawing.Point(384, 34);
            this.workAssignmentsForThisLocation.Name = "workAssignmentsForThisLocation";
            this.workAssignmentsForThisLocation.ReadOnly = false;
            this.workAssignmentsForThisLocation.ScrollAlwaysVisible = true;
            this.workAssignmentsForThisLocation.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.workAssignmentsForThisLocation.Size = new System.Drawing.Size(310, 394);
            this.workAssignmentsForThisLocation.Sorted = true;
            this.workAssignmentsForThisLocation.TabIndex = 12;
            // 
            // allAvailableWorkAssignmentsListBox
            // 
            this.allAvailableWorkAssignmentsListBox.BackColor = System.Drawing.Color.White;
            this.allAvailableWorkAssignmentsListBox.DisplayMember = "Name";
            this.allAvailableWorkAssignmentsListBox.FormattingEnabled = true;
            this.allAvailableWorkAssignmentsListBox.Location = new System.Drawing.Point(11, 34);
            this.allAvailableWorkAssignmentsListBox.Name = "allAvailableWorkAssignmentsListBox";
            this.allAvailableWorkAssignmentsListBox.ReadOnly = false;
            this.allAvailableWorkAssignmentsListBox.ScrollAlwaysVisible = true;
            this.allAvailableWorkAssignmentsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.allAvailableWorkAssignmentsListBox.Size = new System.Drawing.Size(310, 394);
            this.allAvailableWorkAssignmentsListBox.Sorted = true;
            this.allAvailableWorkAssignmentsListBox.TabIndex = 11;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.oltGroupBox1);
            this.ultraTabPageControl2.Controls.Add(this.oltGroupBox3);
            this.ultraTabPageControl2.Controls.Add(this.oltGroupBox2);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 29);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(868, 508);
            // 
            // oltGroupBox1
            // 
            this.oltGroupBox1.Controls.Add(this.functionalLocationBrowseButton);
            this.oltGroupBox1.Controls.Add(this.functionalLocationTextBox);
            this.oltGroupBox1.Location = new System.Drawing.Point(526, 9);
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.Size = new System.Drawing.Size(334, 58);
            this.oltGroupBox1.TabIndex = 19;
            this.oltGroupBox1.TabStop = false;
            this.oltGroupBox1.Text = "Functional Location";
            // 
            // functionalLocationBrowseButton
            // 
            this.functionalLocationBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.functionalLocationBrowseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.functionalLocationBrowseButton.Location = new System.Drawing.Point(258, 24);
            this.functionalLocationBrowseButton.Name = "functionalLocationBrowseButton";
            this.functionalLocationBrowseButton.Size = new System.Drawing.Size(70, 23);
            this.functionalLocationBrowseButton.TabIndex = 18;
            this.functionalLocationBrowseButton.Text = "Browse...";
            this.functionalLocationBrowseButton.UseVisualStyleBackColor = true;
            // 
            // functionalLocationTextBox
            // 
            this.functionalLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionalLocationTextBox.Location = new System.Drawing.Point(11, 26);
            this.functionalLocationTextBox.MaxLength = 150;
            this.functionalLocationTextBox.Name = "functionalLocationTextBox";
            this.functionalLocationTextBox.OltAcceptsReturn = true;
            this.functionalLocationTextBox.OltTrimWhitespace = true;
            this.functionalLocationTextBox.Size = new System.Drawing.Size(241, 20);
            this.functionalLocationTextBox.TabIndex = 17;
            // 
            // oltGroupBox3
            // 
            this.oltGroupBox3.Controls.Add(this.itemReasonCodePanel);
            this.oltGroupBox3.Controls.Add(this.oltPanel4);
            this.oltGroupBox3.Location = new System.Drawing.Point(526, 76);
            this.oltGroupBox3.Name = "oltGroupBox3";
            this.oltGroupBox3.Size = new System.Drawing.Size(334, 381);
            this.oltGroupBox3.TabIndex = 18;
            this.oltGroupBox3.TabStop = false;
            this.oltGroupBox3.Text = "Reason codes for Location";
            // 
            // itemReasonCodePanel
            // 
            this.itemReasonCodePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemReasonCodePanel.Location = new System.Drawing.Point(11, 20);
            this.itemReasonCodePanel.Name = "itemReasonCodePanel";
            this.itemReasonCodePanel.Size = new System.Drawing.Size(317, 308);
            this.itemReasonCodePanel.TabIndex = 11;
            // 
            // oltPanel4
            // 
            this.oltPanel4.Controls.Add(this.selectReasonCodesButton);
            this.oltPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.oltPanel4.Location = new System.Drawing.Point(3, 338);
            this.oltPanel4.Name = "oltPanel4";
            this.oltPanel4.Size = new System.Drawing.Size(328, 40);
            this.oltPanel4.TabIndex = 10;
            // 
            // selectReasonCodesButton
            // 
            this.selectReasonCodesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectReasonCodesButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.selectReasonCodesButton.Location = new System.Drawing.Point(214, 9);
            this.selectReasonCodesButton.Name = "selectReasonCodesButton";
            this.selectReasonCodesButton.Size = new System.Drawing.Size(95, 23);
            this.selectReasonCodesButton.TabIndex = 7;
            this.selectReasonCodesButton.Text = "Select Codes...";
            this.selectReasonCodesButton.UseVisualStyleBackColor = true;
            // 
            // oltGroupBox2
            // 
            this.oltGroupBox2.Controls.Add(this.locationItemTreeView);
            this.oltGroupBox2.Controls.Add(this.oltPanel3);
            this.oltGroupBox2.Location = new System.Drawing.Point(13, 9);
            this.oltGroupBox2.Name = "oltGroupBox2";
            this.oltGroupBox2.Size = new System.Drawing.Size(471, 448);
            this.oltGroupBox2.TabIndex = 0;
            this.oltGroupBox2.TabStop = false;
            this.oltGroupBox2.Text = "Location List Items";
            // 
            // locationItemTreeView
            // 
            this.locationItemTreeView.HideSelection = false;
            this.locationItemTreeView.Location = new System.Drawing.Point(10, 25);
            this.locationItemTreeView.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.locationItemTreeView.Name = "locationItemTreeView";
            this.locationItemTreeView.SelectedItem = null;
            this.locationItemTreeView.Size = new System.Drawing.Size(448, 370);
            this.locationItemTreeView.TabIndex = 10;
            // 
            // oltPanel3
            // 
            this.oltPanel3.Controls.Add(this.renameItemButton);
            this.oltPanel3.Controls.Add(this.moveItemButton);
            this.oltPanel3.Controls.Add(this.removeItemButton);
            this.oltPanel3.Controls.Add(this.addItemButton);
            this.oltPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.oltPanel3.Location = new System.Drawing.Point(3, 405);
            this.oltPanel3.Name = "oltPanel3";
            this.oltPanel3.Size = new System.Drawing.Size(465, 40);
            this.oltPanel3.TabIndex = 9;
            // 
            // renameItemButton
            // 
            this.renameItemButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.renameItemButton.Location = new System.Drawing.Point(374, 9);
            this.renameItemButton.Name = "renameItemButton";
            this.renameItemButton.Size = new System.Drawing.Size(81, 23);
            this.renameItemButton.TabIndex = 8;
            this.renameItemButton.Text = "Rename...";
            this.renameItemButton.UseVisualStyleBackColor = true;
            // 
            // moveItemButton
            // 
            this.moveItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveItemButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.moveItemButton.Location = new System.Drawing.Point(210, 9);
            this.moveItemButton.Name = "moveItemButton";
            this.moveItemButton.Size = new System.Drawing.Size(81, 23);
            this.moveItemButton.TabIndex = 7;
            this.moveItemButton.Text = "Move...";
            this.moveItemButton.UseVisualStyleBackColor = true;
            this.moveItemButton.Visible = false;
            // 
            // removeItemButton
            // 
            this.removeItemButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.removeItemButton.Location = new System.Drawing.Point(110, 9);
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(81, 23);
            this.removeItemButton.TabIndex = 5;
            this.removeItemButton.Text = "Remove";
            this.removeItemButton.UseVisualStyleBackColor = true;
            // 
            // addItemButton
            // 
            this.addItemButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addItemButton.Location = new System.Drawing.Point(20, 9);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(81, 23);
            this.addItemButton.TabIndex = 3;
            this.addItemButton.Text = "Add...";
            this.addItemButton.UseVisualStyleBackColor = true;
            // 
            // locationGroupBox
            // 
            this.locationGroupBox.Controls.Add(this.locationDisplayLabel);
            this.locationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.locationGroupBox.Name = "locationGroupBox";
            this.locationGroupBox.Size = new System.Drawing.Size(485, 39);
            this.locationGroupBox.TabIndex = 1;
            this.locationGroupBox.TabStop = false;
            this.locationGroupBox.Text = "Restriction Location";
            // 
            // locationDisplayLabel
            // 
            this.locationDisplayLabel.AutoSize = true;
            this.locationDisplayLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.locationDisplayLabel.Location = new System.Drawing.Point(6, 17);
            this.locationDisplayLabel.Name = "locationDisplayLabel";
            this.locationDisplayLabel.Size = new System.Drawing.Size(60, 13);
            this.locationDisplayLabel.TabIndex = 0;
            this.locationDisplayLabel.Text = "<location>";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelButton.Location = new System.Drawing.Point(801, 9);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 629);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(888, 40);
            this.buttonPanel.TabIndex = 7;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveButton.Location = new System.Drawing.Point(720, 9);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // oltTabControl1
            // 
            this.oltTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.oltTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.oltTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.oltTabControl1.Location = new System.Drawing.Point(12, 81);
            this.oltTabControl1.Name = "oltTabControl1";
            this.oltTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.oltTabControl1.Size = new System.Drawing.Size(870, 538);
            this.oltTabControl1.TabIndex = 9;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Work Assignments";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Location / Reason Codes";
            this.oltTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(868, 508);
            // 
            // RestrictionLocationConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 669);
            this.Controls.Add(this.oltTabControl1);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.locationGroupBox);
            this.Name = "RestrictionLocationConfigurationForm";
            this.Text = "Configure Restriction Location";
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.oltGroupBox1.ResumeLayout(false);
            this.oltGroupBox1.PerformLayout();
            this.oltGroupBox3.ResumeLayout(false);
            this.oltPanel4.ResumeLayout(false);
            this.oltGroupBox2.ResumeLayout(false);
            this.oltPanel3.ResumeLayout(false);
            this.locationGroupBox.ResumeLayout(false);
            this.locationGroupBox.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oltTabControl1)).EndInit();
            this.oltTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox locationGroupBox;
        private System.Windows.Forms.Label locationDisplayLabel;
        private OltControls.OltButton cancelButton;
        private OltControls.OltPanel buttonPanel;
        private OltControls.OltTabControl oltTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private OltControls.OltButton removeWorkAssignmentButton;
        private OltControls.OltButton addWorkAssignmentButton;
        private OltControls.OltListBox workAssignmentsForThisLocation;
        private OltControls.OltListBox allAvailableWorkAssignmentsListBox;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private OltControls.OltGroupBox oltGroupBox2;
        private OltControls.OltPanel oltPanel3;
        private OltControls.OltGroupBox oltGroupBox3;
        private OltControls.OltPanel oltPanel4;
        private OltControls.OltButton selectReasonCodesButton;
        private OltControls.OltGroupBox oltGroupBox1;
        private OltControls.OltButton functionalLocationBrowseButton;
        private OltControls.OltTextBox functionalLocationTextBox;
        private OltControls.OltButton renameItemButton;
        private OltControls.OltButton saveButton;
        private Controls.LocationItemTreeView locationItemTreeView;
        private OltControls.OltPanel itemReasonCodePanel;
        private OltControls.OltLabel oltLabel2;
        private OltControls.OltLabel oltLabel1;
        private OltControls.OltButton moveItemButton;
        private OltControls.OltButton removeItemButton;
        private OltControls.OltButton addItemButton;
    }
}