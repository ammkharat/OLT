using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class DocumentLinksControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentLinksControl));
            this.documentLinksListBox = new OltListBox();
            this.buttons = new OltPanel();
            this.AddLinkButton = new OltButton();
            this.openLinkButton = new OltButton();
            this.RemoveLinkButton = new OltButton();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentLinksListBox
            // 
            this.documentLinksListBox.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.documentLinksListBox, "documentLinksListBox");
            this.documentLinksListBox.FormattingEnabled = true;
            this.documentLinksListBox.Name = "documentLinksListBox";
            this.documentLinksListBox.ReadOnly = false;
            // 
            // buttons
            // 
            this.buttons.Controls.Add(this.AddLinkButton);
            this.buttons.Controls.Add(this.openLinkButton);
            this.buttons.Controls.Add(this.RemoveLinkButton);
            resources.ApplyResources(this.buttons, "buttons");
            this.buttons.Name = "buttons";
            // 
            // AddLinkButton
            // 
            resources.ApplyResources(this.AddLinkButton, "AddLinkButton");
            this.AddLinkButton.Name = "AddLinkButton";
            this.AddLinkButton.UseVisualStyleBackColor = true;
            // 
            // openLinkButton
            // 
            resources.ApplyResources(this.openLinkButton, "openLinkButton");
            this.openLinkButton.Name = "openLinkButton";
            this.openLinkButton.UseVisualStyleBackColor = true;
            // 
            // RemoveLinkButton
            // 
            resources.ApplyResources(this.RemoveLinkButton, "RemoveLinkButton");
            this.RemoveLinkButton.Name = "RemoveLinkButton";
            this.RemoveLinkButton.UseVisualStyleBackColor = true;
            // 
            // DocumentLinksControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.documentLinksListBox);
            this.Controls.Add(this.buttons);
            this.Name = "DocumentLinksControl";
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltListBox documentLinksListBox;
        private OltButton AddLinkButton;
        private OltButton RemoveLinkButton;
        private OltButton openLinkButton;
        private OltPanel buttons;
    }
}
