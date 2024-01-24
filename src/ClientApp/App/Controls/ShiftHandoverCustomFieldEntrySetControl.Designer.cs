using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class ShiftHandoverCustomFieldEntrySetControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftHandoverCustomFieldEntrySetControl));
            this.customFieldEntriesPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.SuspendLayout();
            // 
            // customFieldEntriesPanel
            // 
            resources.ApplyResources(this.customFieldEntriesPanel, "customFieldEntriesPanel");
            this.customFieldEntriesPanel.Name = "customFieldEntriesPanel";
            // 
            // ShiftHandoverCustomFieldEntrySetControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customFieldEntriesPanel);
            this.Name = "ShiftHandoverCustomFieldEntrySetControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltPanel customFieldEntriesPanel;
    }
}
