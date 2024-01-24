using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    partial class BasePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasePage));
            this.splitContainer = new Com.Suncor.Olt.Client.OltControls.OltSplitContainer();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.cancelSearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pageTitle = new Com.Suncor.Olt.Client.OltControls.OltLabelTitle();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // searchTextBox
            // 
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            this.searchTextBox.Name = "searchTextBox";
            // 
            // searchButton
            // 
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.BackColor = System.Drawing.SystemColors.Control;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.Name = "searchButton";
            this.searchButton.UseVisualStyleBackColor = false;
            // 
            // cancelSearchButton
            // 
            resources.ApplyResources(this.cancelSearchButton, "cancelSearchButton");
            this.cancelSearchButton.BackColor = System.Drawing.SystemColors.Control;
            this.cancelSearchButton.FlatAppearance.BorderSize = 0;
            this.cancelSearchButton.Name = "cancelSearchButton";
            this.cancelSearchButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.pageTitle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.searchTextBox);
            this.panel1.Controls.Add(this.cancelSearchButton);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Name = "panel1";
            // 
            // pageTitle
            // 
            resources.ApplyResources(this.pageTitle, "pageTitle");
            this.pageTitle.BackColor = System.Drawing.Color.Gray;
            this.pageTitle.ForeColor = System.Drawing.Color.White;
            this.pageTitle.Name = "pageTitle";
            // 
            // BasePage
            // 
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panel1);
            this.Name = "BasePage";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal OltSplitContainer splitContainer;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button cancelSearchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private OltLabelTitle pageTitle;

    }
}
