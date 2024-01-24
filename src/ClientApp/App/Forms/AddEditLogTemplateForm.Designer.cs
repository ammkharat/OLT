using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class AddEditLogTemplateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditLogTemplateForm));
            this.commentCategoryGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.nameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.siteGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.siteLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.guidelinesGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.logTemplateTextTextBox = new Com.Suncor.Olt.Client.Controls.RichTextEditor();
            this.workAssignmentGroupBox = new System.Windows.Forms.GroupBox();
            this.assignmentGridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.workAssignmentButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.appliesToGroupBox = new System.Windows.Forms.GroupBox();
            this.appliesToDirectivesCheckBox = new System.Windows.Forms.CheckBox();
            this.appliesToSummaryLogsCheckBox = new System.Windows.Forms.CheckBox();
            this.appliesToLogsCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commentCategoryGroupBox.SuspendLayout();
            this.siteGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.guidelinesGroupBox.SuspendLayout();
            this.workAssignmentGroupBox.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.appliesToGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // commentCategoryGroupBox
            // 
            resources.ApplyResources(this.commentCategoryGroupBox, "commentCategoryGroupBox");
            this.commentCategoryGroupBox.Controls.Add(this.nameTextBox);
            this.errorProvider.SetError(this.commentCategoryGroupBox, resources.GetString("commentCategoryGroupBox.Error"));
            this.errorProvider.SetIconAlignment(this.commentCategoryGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("commentCategoryGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.commentCategoryGroupBox, ((int)(resources.GetObject("commentCategoryGroupBox.IconPadding"))));
            this.commentCategoryGroupBox.Name = "commentCategoryGroupBox";
            this.commentCategoryGroupBox.TabStop = false;
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.errorProvider.SetError(this.nameTextBox, resources.GetString("nameTextBox.Error"));
            this.errorProvider.SetIconAlignment(this.nameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nameTextBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.nameTextBox, ((int)(resources.GetObject("nameTextBox.IconPadding"))));
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.OltAcceptsReturn = false;
            this.nameTextBox.OltTrimWhitespace = true;
            // 
            // siteGroupBox
            // 
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Controls.Add(this.siteLabelData);
            this.errorProvider.SetError(this.siteGroupBox, resources.GetString("siteGroupBox.Error"));
            this.errorProvider.SetIconAlignment(this.siteGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("siteGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.siteGroupBox, ((int)(resources.GetObject("siteGroupBox.IconPadding"))));
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // siteLabelData
            // 
            resources.ApplyResources(this.siteLabelData, "siteLabelData");
            this.errorProvider.SetError(this.siteLabelData, resources.GetString("siteLabelData.Error"));
            this.errorProvider.SetIconAlignment(this.siteLabelData, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("siteLabelData.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.siteLabelData, ((int)(resources.GetObject("siteLabelData.IconPadding"))));
            this.siteLabelData.Name = "siteLabelData";
            this.siteLabelData.UseMnemonic = false;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.errorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error"));
            this.errorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.errorProvider.SetError(this.saveButton, resources.GetString("saveButton.Error"));
            this.errorProvider.SetIconAlignment(this.saveButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("saveButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.saveButton, ((int)(resources.GetObject("saveButton.IconPadding"))));
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // guidelinesGroupBox
            // 
            resources.ApplyResources(this.guidelinesGroupBox, "guidelinesGroupBox");
            this.guidelinesGroupBox.Controls.Add(this.logTemplateTextTextBox);
            this.errorProvider.SetError(this.guidelinesGroupBox, resources.GetString("guidelinesGroupBox.Error"));
            this.errorProvider.SetIconAlignment(this.guidelinesGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("guidelinesGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.guidelinesGroupBox, ((int)(resources.GetObject("guidelinesGroupBox.IconPadding"))));
            this.guidelinesGroupBox.Name = "guidelinesGroupBox";
            this.guidelinesGroupBox.TabStop = false;
            // 
            // logTemplateTextTextBox
            // 
            resources.ApplyResources(this.logTemplateTextTextBox, "logTemplateTextTextBox");
            this.errorProvider.SetError(this.logTemplateTextTextBox, resources.GetString("logTemplateTextTextBox.Error"));
            this.errorProvider.SetIconAlignment(this.logTemplateTextTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("logTemplateTextTextBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.logTemplateTextTextBox, ((int)(resources.GetObject("logTemplateTextTextBox.IconPadding"))));
            this.logTemplateTextTextBox.Name = "logTemplateTextTextBox";
            this.logTemplateTextTextBox.ReadOnly = false;
            // 
            // workAssignmentGroupBox
            // 
            resources.ApplyResources(this.workAssignmentGroupBox, "workAssignmentGroupBox");
            this.workAssignmentGroupBox.Controls.Add(this.assignmentGridPanel);
            this.workAssignmentGroupBox.Controls.Add(this.workAssignmentButton);
            this.errorProvider.SetError(this.workAssignmentGroupBox, resources.GetString("workAssignmentGroupBox.Error"));
            this.errorProvider.SetIconAlignment(this.workAssignmentGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("workAssignmentGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.workAssignmentGroupBox, ((int)(resources.GetObject("workAssignmentGroupBox.IconPadding"))));
            this.workAssignmentGroupBox.Name = "workAssignmentGroupBox";
            this.workAssignmentGroupBox.TabStop = false;
            // 
            // assignmentGridPanel
            // 
            resources.ApplyResources(this.assignmentGridPanel, "assignmentGridPanel");
            this.assignmentGridPanel.BackColor = System.Drawing.Color.DarkSalmon;
            this.errorProvider.SetError(this.assignmentGridPanel, resources.GetString("assignmentGridPanel.Error"));
            this.errorProvider.SetIconAlignment(this.assignmentGridPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("assignmentGridPanel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.assignmentGridPanel, ((int)(resources.GetObject("assignmentGridPanel.IconPadding"))));
            this.assignmentGridPanel.Name = "assignmentGridPanel";
            // 
            // workAssignmentButton
            // 
            resources.ApplyResources(this.workAssignmentButton, "workAssignmentButton");
            this.errorProvider.SetError(this.workAssignmentButton, resources.GetString("workAssignmentButton.Error"));
            this.errorProvider.SetIconAlignment(this.workAssignmentButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("workAssignmentButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.workAssignmentButton, ((int)(resources.GetObject("workAssignmentButton.IconPadding"))));
            this.workAssignmentButton.Name = "workAssignmentButton";
            this.workAssignmentButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.workAssignmentGroupBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.guidelinesGroupBox, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.appliesToGroupBox, 0, 1);
            this.errorProvider.SetError(this.tableLayoutPanel, resources.GetString("tableLayoutPanel.Error"));
            this.errorProvider.SetIconAlignment(this.tableLayoutPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tableLayoutPanel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.tableLayoutPanel, ((int)(resources.GetObject("tableLayoutPanel.IconPadding"))));
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // appliesToGroupBox
            // 
            resources.ApplyResources(this.appliesToGroupBox, "appliesToGroupBox");
            this.appliesToGroupBox.Controls.Add(this.appliesToDirectivesCheckBox);
            this.appliesToGroupBox.Controls.Add(this.appliesToSummaryLogsCheckBox);
            this.appliesToGroupBox.Controls.Add(this.appliesToLogsCheckBox);
            this.errorProvider.SetError(this.appliesToGroupBox, resources.GetString("appliesToGroupBox.Error"));
            this.errorProvider.SetIconAlignment(this.appliesToGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("appliesToGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.appliesToGroupBox, ((int)(resources.GetObject("appliesToGroupBox.IconPadding"))));
            this.appliesToGroupBox.Name = "appliesToGroupBox";
            this.appliesToGroupBox.TabStop = false;
            // 
            // appliesToDirectivesCheckBox
            // 
            resources.ApplyResources(this.appliesToDirectivesCheckBox, "appliesToDirectivesCheckBox");
            this.errorProvider.SetError(this.appliesToDirectivesCheckBox, resources.GetString("appliesToDirectivesCheckBox.Error"));
            this.errorProvider.SetIconAlignment(this.appliesToDirectivesCheckBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("appliesToDirectivesCheckBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.appliesToDirectivesCheckBox, ((int)(resources.GetObject("appliesToDirectivesCheckBox.IconPadding"))));
            this.appliesToDirectivesCheckBox.Name = "appliesToDirectivesCheckBox";
            this.appliesToDirectivesCheckBox.UseVisualStyleBackColor = true;
            // 
            // appliesToSummaryLogsCheckBox
            // 
            resources.ApplyResources(this.appliesToSummaryLogsCheckBox, "appliesToSummaryLogsCheckBox");
            this.errorProvider.SetError(this.appliesToSummaryLogsCheckBox, resources.GetString("appliesToSummaryLogsCheckBox.Error"));
            this.errorProvider.SetIconAlignment(this.appliesToSummaryLogsCheckBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("appliesToSummaryLogsCheckBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.appliesToSummaryLogsCheckBox, ((int)(resources.GetObject("appliesToSummaryLogsCheckBox.IconPadding"))));
            this.appliesToSummaryLogsCheckBox.Name = "appliesToSummaryLogsCheckBox";
            this.appliesToSummaryLogsCheckBox.UseVisualStyleBackColor = true;
            // 
            // appliesToLogsCheckBox
            // 
            resources.ApplyResources(this.appliesToLogsCheckBox, "appliesToLogsCheckBox");
            this.errorProvider.SetError(this.appliesToLogsCheckBox, resources.GetString("appliesToLogsCheckBox.Error"));
            this.errorProvider.SetIconAlignment(this.appliesToLogsCheckBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("appliesToLogsCheckBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.appliesToLogsCheckBox, ((int)(resources.GetObject("appliesToLogsCheckBox.IconPadding"))));
            this.appliesToLogsCheckBox.Name = "appliesToLogsCheckBox";
            this.appliesToLogsCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            this.errorProvider.SetError(this.panel1, resources.GetString("panel1.Error"));
            this.errorProvider.SetIconAlignment(this.panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("panel1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.panel1, ((int)(resources.GetObject("panel1.IconPadding"))));
            this.panel1.Name = "panel1";
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Com.Suncor.Olt.Client.Presenters.CheckableFunctionalLocationGridDisplayAdapter);
            // 
            // AddEditLogTemplateForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.commentCategoryGroupBox);
            this.Controls.Add(this.siteGroupBox);
            this.Name = "AddEditLogTemplateForm";
            this.commentCategoryGroupBox.ResumeLayout(false);
            this.commentCategoryGroupBox.PerformLayout();
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.guidelinesGroupBox.ResumeLayout(false);
            this.workAssignmentGroupBox.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.appliesToGroupBox.ResumeLayout(false);
            this.appliesToGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton saveButton;
        private OltButton cancelButton;
        private OltTextBox nameTextBox;
        private OltGroupBox siteGroupBox;
        private OltLabelData siteLabelData;
        private OltGroupBox commentCategoryGroupBox;        
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltGroupBox guidelinesGroupBox;
        private System.Windows.Forms.GroupBox workAssignmentGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.BindingSource bindingSource;
        private OltButton workAssignmentButton;
        private Com.Suncor.Olt.Client.Controls.RichTextEditor logTemplateTextTextBox;
        private System.Windows.Forms.GroupBox appliesToGroupBox;
        private System.Windows.Forms.CheckBox appliesToLogsCheckBox;
        private System.Windows.Forms.CheckBox appliesToSummaryLogsCheckBox;
        private System.Windows.Forms.CheckBox appliesToDirectivesCheckBox;
        private System.Windows.Forms.Panel panel1;
        private OltPanel assignmentGridPanel;
        //private Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl multiSelectFunctionalLocationControl1;
    }
}