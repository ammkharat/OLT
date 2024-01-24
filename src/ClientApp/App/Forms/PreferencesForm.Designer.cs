using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class PreferencesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.workPermitPrintingTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.defaultPermitTimesTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.tabsPanel = new System.Windows.Forms.Panel();
            this.preferencesTabControl = new Com.Suncor.Olt.Client.OltControls.OltTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.fillerPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.buttonPanel.SuspendLayout();
            this.tabsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preferencesTabControl)).BeginInit();
            this.preferencesTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // workPermitPrintingTabControl
            // 
            resources.ApplyResources(this.workPermitPrintingTabControl, "workPermitPrintingTabControl");
            this.workPermitPrintingTabControl.Name = "workPermitPrintingTabControl";
            // 
            // defaultPermitTimesTabControl
            // 
            resources.ApplyResources(this.defaultPermitTimesTabControl, "defaultPermitTimesTabControl");
            this.defaultPermitTimesTabControl.Name = "defaultPermitTimesTabControl";
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // tabsPanel
            // 
            this.tabsPanel.Controls.Add(this.preferencesTabControl);
            resources.ApplyResources(this.tabsPanel, "tabsPanel");
            this.tabsPanel.Name = "tabsPanel";
            // 
            // preferencesTabControl
            // 
            this.preferencesTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.preferencesTabControl.Controls.Add(this.workPermitPrintingTabControl);
            this.preferencesTabControl.Controls.Add(this.defaultPermitTimesTabControl);
            resources.ApplyResources(this.preferencesTabControl, "preferencesTabControl");
            this.preferencesTabControl.Name = "preferencesTabControl";
            this.preferencesTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            ultraTab1.TabPage = this.workPermitPrintingTabControl;
            resources.ApplyResources(ultraTab1, "ultraTab1");
            ultraTab1.ForceApplyResources = "";
            ultraTab2.TabPage = this.defaultPermitTimesTabControl;
            resources.ApplyResources(ultraTab2, "ultraTab2");
            ultraTab2.ForceApplyResources = "";
            this.preferencesTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            // 
            // ultraTabSharedControlsPage1
            // 
            resources.ApplyResources(this.ultraTabSharedControlsPage1, "ultraTabSharedControlsPage1");
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            // 
            // fillerPanel
            // 
            resources.ApplyResources(this.fillerPanel, "fillerPanel");
            this.fillerPanel.Name = "fillerPanel";
            // 
            // PreferencesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabsPanel);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.fillerPanel);
            this.MaximizeBox = false;
            this.Name = "PreferencesForm";
            this.buttonPanel.ResumeLayout(false);
            this.tabsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.preferencesTabControl)).EndInit();
            this.preferencesTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel buttonPanel;
        private OltButton saveButton;
        private OltButton cancelButton;
        private Panel tabsPanel;
        private OltPanel fillerPanel;
        private Com.Suncor.Olt.Client.OltControls.OltTabControl preferencesTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl workPermitPrintingTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl defaultPermitTimesTabControl;

    }
}