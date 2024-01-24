using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class MultiSelectFunctionalLocationControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiSelectFunctionalLocationControl));
            this.searchPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.searchButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.searchTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.treeViewPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.treeView = new Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationTreeView();
            this.searchPanel.SuspendLayout();
            this.treeViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.searchButton);
            this.searchPanel.Controls.Add(this.searchTextBox);
            resources.ApplyResources(this.searchPanel, "searchPanel");
            this.searchPanel.Name = "searchPanel";
            // 
            // searchButton
            // 
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.Name = "searchButton";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.OltAcceptsReturn = true;
            this.searchTextBox.OltTrimWhitespace = true;
            // 
            // treeViewPanel
            // 
            this.treeViewPanel.Controls.Add(this.treeView);
            resources.ApplyResources(this.treeViewPanel, "treeViewPanel");
            this.treeViewPanel.Name = "treeViewPanel";
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.treeView, "treeView");
            this.treeView.FunctionalLocationTreeViewMode = null;
            this.treeView.HideSelection = false;
            this.treeView.Name = "treeView";
            this.treeView.ReadOnly = false;
            this.treeView.RootNodeCollection = new Com.Suncor.Olt.Client.Controls.FunctionalLocationTreeNode[0];
            // 
            // MultiSelectFunctionalLocationControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewPanel);
            this.Controls.Add(this.searchPanel);
            this.Name = "MultiSelectFunctionalLocationControl";
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.treeViewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltPanel searchPanel;
        private OltButton searchButton;
        private OltTextBox searchTextBox;
        private OltPanel treeViewPanel;
        private MultiSelectFunctionalLocationTreeView treeView;
    }
}
