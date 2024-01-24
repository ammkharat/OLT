using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class CokerCardConfigurationSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CokerCardConfigurationSelectionForm));
            this.oltPanel2 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.okButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.cokerCardListGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.listPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltPanel2.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            this.cokerCardListGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // oltPanel2
            // 
            this.oltPanel2.Controls.Add(this.cancelButton);
            this.oltPanel2.Controls.Add(this.okButton);
            resources.ApplyResources(this.oltPanel2, "oltPanel2");
            this.oltPanel2.Name = "oltPanel2";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.oltLabel1);
            resources.ApplyResources(this.oltPanel1, "oltPanel1");
            this.oltPanel1.Name = "oltPanel1";
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // cokerCardListGroupBox
            // 
            this.cokerCardListGroupBox.Controls.Add(this.listPanel);
            resources.ApplyResources(this.cokerCardListGroupBox, "cokerCardListGroupBox");
            this.cokerCardListGroupBox.Name = "cokerCardListGroupBox";
            this.cokerCardListGroupBox.TabStop = false;
            // 
            // listPanel
            // 
            resources.ApplyResources(this.listPanel, "listPanel");
            this.listPanel.Name = "listPanel";
            // 
            // CokerCardConfigurationSelectionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oltPanel2);
            this.Controls.Add(this.oltPanel1);
            this.Controls.Add(this.cokerCardListGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CokerCardConfigurationSelectionForm";
            this.oltPanel2.ResumeLayout(false);
            this.oltPanel1.ResumeLayout(false);
            this.cokerCardListGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltGroupBox cokerCardListGroupBox;
        private OltLabel oltLabel1;
        private OltButton okButton;
        private OltButton cancelButton;
        private OltPanel oltPanel1;
        private OltPanel oltPanel2;
        private OltPanel listPanel;
    }
}