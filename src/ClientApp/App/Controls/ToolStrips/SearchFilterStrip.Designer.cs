using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.ToolStrips
{
    partial class SearchFilterStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchFilterStrip));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.filterLabel = new OltToolStripLabel();
            this.filterComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.seperator = new System.Windows.Forms.ToolStripSeparator();
            this.searchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.searchButton = new System.Windows.Forms.ToolStripButton();
            this.ClearSearchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterLabel,
            this.filterComboBox,
            this.seperator,
            this.searchTextBox,
            this.searchButton,
            this.ClearSearchButton});
            this.toolStrip.Name = "toolStrip";
            // 
            // filterLabel
            // 
            resources.ApplyResources(this.filterLabel, "filterLabel");
            this.filterLabel.Name = "filterLabel";
            // 
            // filterComboBox
            // 
            this.filterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterComboBox.Name = "filterComboBox";
            resources.ApplyResources(this.filterComboBox, "filterComboBox");
            // 
            // seperator
            // 
            this.seperator.Name = "seperator";
            resources.ApplyResources(this.seperator, "seperator");
            // 
            // searchTextBox
            // 
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Name = "searchTextBox";
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            // 
            // searchButton
            // 
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.Name = "searchButton";
            // 
            // ClearSearchButton
            // 
            this.ClearSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.ClearSearchButton, "ClearSearchButton");
            this.ClearSearchButton.Name = "ClearSearchButton";
            // 
            // SearchFilterStrip
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Name = "SearchFilterStrip";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripComboBox filterComboBox;
        private System.Windows.Forms.ToolStripTextBox searchTextBox;
        private System.Windows.Forms.ToolStripSeparator seperator;
        private OltToolStripLabel filterLabel;
        private System.Windows.Forms.ToolStripButton searchButton;
        private System.Windows.Forms.ToolStripButton ClearSearchButton;

    }
}