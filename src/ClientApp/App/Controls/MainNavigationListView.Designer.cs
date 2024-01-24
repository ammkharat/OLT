
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class MainNavigationListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainNavigationListView));
            this.navigationListView = new OltListView();
            this.SuspendLayout();
            // 
            // navigationListView
            // 
            this.navigationListView.BackColor = System.Drawing.SystemColors.Window;
            this.navigationListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.navigationListView, "navigationListView");
            this.navigationListView.HideSelection = false;
            this.navigationListView.MultiSelect = false;
            this.navigationListView.Name = "navigationListView";
            this.navigationListView.UseCompatibleStateImageBehavior = false;
            // 
            // MainNavigationListView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationListView);
            this.Name = "MainNavigationListView";
            this.ResumeLayout(false);

        }

        #endregion

        private OltListView navigationListView;
    }
}
