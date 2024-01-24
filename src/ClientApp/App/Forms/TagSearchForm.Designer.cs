using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class TagSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagSearchForm));
            this.searchResultsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.readWriteStatusPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.tagWriteStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.tagReadStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.tagReadStatusLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.tagWriteStatusLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.selectButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.searchPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.likeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.criteriaValueTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.CriteriaLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.criteriaComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.searchButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.criteriaValueErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tagReadStatusToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tagWriteStatusToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.readWriteStatusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagWriteStatusPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagReadStatusPictureBox)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaValueErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // searchResultsPanel
            // 
            resources.ApplyResources(this.searchResultsPanel, "searchResultsPanel");
            this.searchResultsPanel.Name = "searchResultsPanel";
            // 
            // readWriteStatusPanel
            // 
            this.readWriteStatusPanel.BackColor = System.Drawing.SystemColors.Control;
            this.readWriteStatusPanel.Controls.Add(this.tagWriteStatusPictureBox);
            this.readWriteStatusPanel.Controls.Add(this.tagReadStatusPictureBox);
            this.readWriteStatusPanel.Controls.Add(this.tagReadStatusLabel);
            this.readWriteStatusPanel.Controls.Add(this.tagWriteStatusLabel);
            resources.ApplyResources(this.readWriteStatusPanel, "readWriteStatusPanel");
            this.readWriteStatusPanel.Name = "readWriteStatusPanel";
            // 
            // tagWriteStatusPictureBox
            // 
            resources.ApplyResources(this.tagWriteStatusPictureBox, "tagWriteStatusPictureBox");
            this.tagWriteStatusPictureBox.Name = "tagWriteStatusPictureBox";
            this.tagWriteStatusPictureBox.TabStop = false;
            // 
            // tagReadStatusPictureBox
            // 
            resources.ApplyResources(this.tagReadStatusPictureBox, "tagReadStatusPictureBox");
            this.tagReadStatusPictureBox.Name = "tagReadStatusPictureBox";
            this.tagReadStatusPictureBox.TabStop = false;
            // 
            // tagReadStatusLabel
            // 
            resources.ApplyResources(this.tagReadStatusLabel, "tagReadStatusLabel");
            this.tagReadStatusLabel.Name = "tagReadStatusLabel";
            this.tagReadStatusLabel.UseMnemonic = false;
            // 
            // tagWriteStatusLabel
            // 
            resources.ApplyResources(this.tagWriteStatusLabel, "tagWriteStatusLabel");
            this.tagWriteStatusLabel.Name = "tagWriteStatusLabel";
            this.tagWriteStatusLabel.UseMnemonic = false;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.selectButton);
            this.buttonPanel.Controls.Add(this.readWriteStatusPanel);
            this.buttonPanel.Controls.Add(this.cancelButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // selectButton
            // 
            resources.ApplyResources(this.selectButton, "selectButton");
            this.selectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.selectButton.Name = "selectButton";
            this.selectButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.likeLabel);
            this.searchPanel.Controls.Add(this.criteriaValueTextBox);
            this.searchPanel.Controls.Add(this.CriteriaLabel);
            this.searchPanel.Controls.Add(this.criteriaComboBox);
            this.searchPanel.Controls.Add(this.searchButton);
            resources.ApplyResources(this.searchPanel, "searchPanel");
            this.searchPanel.Name = "searchPanel";
            // 
            // likeLabel
            // 
            resources.ApplyResources(this.likeLabel, "likeLabel");
            this.likeLabel.Name = "likeLabel";
            // 
            // criteriaValueTextBox
            // 
            resources.ApplyResources(this.criteriaValueTextBox, "criteriaValueTextBox");
            this.criteriaValueTextBox.Name = "criteriaValueTextBox";
            this.criteriaValueTextBox.OltAcceptsReturn = true;
            this.criteriaValueTextBox.OltTrimWhitespace = true;
            // 
            // CriteriaLabel
            // 
            resources.ApplyResources(this.CriteriaLabel, "CriteriaLabel");
            this.CriteriaLabel.Name = "CriteriaLabel";
            this.CriteriaLabel.UseMnemonic = false;
            // 
            // criteriaComboBox
            // 
            this.criteriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.criteriaComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.criteriaComboBox, "criteriaComboBox");
            this.criteriaComboBox.Name = "criteriaComboBox";
            // 
            // searchButton
            // 
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.Name = "searchButton";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // criteriaValueErrorProvider
            // 
            this.criteriaValueErrorProvider.ContainerControl = this;
            // 
            // TagSearchForm
            // 
            this.AcceptButton = this.searchButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchResultsPanel);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.searchPanel);
            this.Name = "TagSearchForm";
            this.readWriteStatusPanel.ResumeLayout(false);
            this.readWriteStatusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagWriteStatusPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagReadStatusPictureBox)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaValueErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltPanel searchResultsPanel;
        private OltPanel buttonPanel;
        private OltButton cancelButton;
        private OltButton selectButton;
        private OltPanel searchPanel;
        private OltTextBox criteriaValueTextBox;
        private OltLabelData CriteriaLabel;
        private OltComboBox criteriaComboBox;
        private OltButton searchButton;
        private ErrorProvider criteriaValueErrorProvider;
        private OltLabelData tagWriteStatusLabel;
        private OltLabelData tagReadStatusLabel;
        private System.Windows.Forms.PictureBox tagReadStatusPictureBox;
        private System.Windows.Forms.PictureBox tagWriteStatusPictureBox;
        private System.Windows.Forms.ToolTip tagReadStatusToolTip;
        private System.Windows.Forms.ToolTip tagWriteStatusToolTip;
        private OltPanel readWriteStatusPanel;
        private OltLabel likeLabel;

    }
}