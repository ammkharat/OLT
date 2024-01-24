namespace Com.Suncor.Olt.Client.Forms
{
    partial class TrainingBlockConfigurationForm
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
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.okButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.mainPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltTableLayoutPanel1 = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.oltGroupBox2 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocSelectionControl = new Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl();
            this.trainingBlockGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.deleteButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.editButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.newButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.trainingBlockTablePanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.buttonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.oltTableLayoutPanel1.SuspendLayout();
            this.oltGroupBox2.SuspendLayout();
            this.trainingBlockGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.okButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 570);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(940, 46);
            this.buttonPanel.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(853, 11);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.oltTableLayoutPanel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(940, 570);
            this.mainPanel.TabIndex = 1;
            // 
            // oltTableLayoutPanel1
            // 
            this.oltTableLayoutPanel1.ColumnCount = 2;
            this.oltTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.04721F));
            this.oltTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.95279F));
            this.oltTableLayoutPanel1.Controls.Add(this.oltGroupBox2, 1, 0);
            this.oltTableLayoutPanel1.Controls.Add(this.trainingBlockGroupBox, 0, 0);
            this.oltTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oltTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.oltTableLayoutPanel1.Name = "oltTableLayoutPanel1";
            this.oltTableLayoutPanel1.RowCount = 1;
            this.oltTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.oltTableLayoutPanel1.Size = new System.Drawing.Size(940, 570);
            this.oltTableLayoutPanel1.TabIndex = 0;
            // 
            // oltGroupBox2
            // 
            this.oltGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oltGroupBox2.Controls.Add(this.flocSelectionControl);
            this.oltGroupBox2.Location = new System.Drawing.Point(473, 3);
            this.oltGroupBox2.Name = "oltGroupBox2";
            this.oltGroupBox2.Size = new System.Drawing.Size(464, 564);
            this.oltGroupBox2.TabIndex = 1;
            this.oltGroupBox2.TabStop = false;
            this.oltGroupBox2.Text = "Training Block available for the following Functional Locations";
            // 
            // flocSelectionControl
            // 
            this.flocSelectionControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flocSelectionControl.Location = new System.Drawing.Point(3, 17);
            this.flocSelectionControl.Name = "flocSelectionControl";
            this.flocSelectionControl.Size = new System.Drawing.Size(458, 501);
            this.flocSelectionControl.TabIndex = 1;
            // 
            // trainingBlockGroupBox
            // 
            this.trainingBlockGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trainingBlockGroupBox.Controls.Add(this.deleteButton);
            this.trainingBlockGroupBox.Controls.Add(this.editButton);
            this.trainingBlockGroupBox.Controls.Add(this.newButton);
            this.trainingBlockGroupBox.Controls.Add(this.trainingBlockTablePanel);
            this.trainingBlockGroupBox.Location = new System.Drawing.Point(3, 3);
            this.trainingBlockGroupBox.Name = "trainingBlockGroupBox";
            this.trainingBlockGroupBox.Size = new System.Drawing.Size(464, 564);
            this.trainingBlockGroupBox.TabIndex = 0;
            this.trainingBlockGroupBox.TabStop = false;
            this.trainingBlockGroupBox.Text = "Training Block";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(383, 525);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Location = new System.Drawing.Point(302, 525);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit...";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newButton.Location = new System.Drawing.Point(221, 525);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 1;
            this.newButton.Text = "New...";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // trainingBlockTablePanel
            // 
            this.trainingBlockTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trainingBlockTablePanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.trainingBlockTablePanel.Location = new System.Drawing.Point(9, 20);
            this.trainingBlockTablePanel.Name = "trainingBlockTablePanel";
            this.trainingBlockTablePanel.Size = new System.Drawing.Size(449, 499);
            this.trainingBlockTablePanel.TabIndex = 0;
            // 
            // TrainingBlockConfigurationForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(940, 616);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "TrainingBlockConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Training Block";
            this.buttonPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.oltTableLayoutPanel1.ResumeLayout(false);
            this.oltGroupBox2.ResumeLayout(false);
            this.trainingBlockGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel buttonPanel;
        private OltControls.OltPanel mainPanel;
        private OltControls.OltTableLayoutPanel oltTableLayoutPanel1;
        private OltControls.OltGroupBox oltGroupBox2;
        private OltControls.OltGroupBox trainingBlockGroupBox;
        private OltControls.OltButton deleteButton;
        private OltControls.OltButton editButton;
        private OltControls.OltButton newButton;
        private OltControls.OltPanel trainingBlockTablePanel;
        private Controls.MultiSelectFunctionalLocationControl flocSelectionControl;
        private OltControls.OltButton okButton;
    }
}