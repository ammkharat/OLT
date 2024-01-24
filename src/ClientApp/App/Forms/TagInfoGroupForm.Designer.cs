using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class TagInfoGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagInfoGroupForm));
            this.phTagListNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.phTagsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.clearButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.removeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.phTagListPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.phTagListNameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.phtagListNameGroupBox = new System.Windows.Forms.GroupBox();
            this.phTagsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phTagListNameErrorProvider)).BeginInit();
            this.phtagListNameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // phTagListNameTextBox
            // 
            resources.ApplyResources(this.phTagListNameTextBox, "phTagListNameTextBox");
            this.phTagListNameTextBox.Name = "phTagListNameTextBox";
            this.phTagListNameTextBox.OltAcceptsReturn = true;
            this.phTagListNameTextBox.OltTrimWhitespace = true;
            // 
            // phTagsGroupBox
            // 
            this.phTagsGroupBox.Controls.Add(this.clearButton);
            this.phTagsGroupBox.Controls.Add(this.removeButton);
            this.phTagsGroupBox.Controls.Add(this.addButton);
            this.phTagsGroupBox.Controls.Add(this.phTagListPanel);
            resources.ApplyResources(this.phTagsGroupBox, "phTagsGroupBox");
            this.phTagsGroupBox.Name = "phTagsGroupBox";
            this.phTagsGroupBox.TabStop = false;
            // 
            // clearButton
            // 
            resources.ApplyResources(this.clearButton, "clearButton");
            this.clearButton.Name = "clearButton";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            resources.ApplyResources(this.removeButton, "removeButton");
            this.removeButton.Name = "removeButton";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // phTagListPanel
            // 
            resources.ApplyResources(this.phTagListPanel, "phTagListPanel");
            this.phTagListPanel.Name = "phTagListPanel";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
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
            // phTagListNameErrorProvider
            // 
            this.phTagListNameErrorProvider.ContainerControl = this;
            // 
            // phtagListNameGroupBox
            // 
            this.phtagListNameGroupBox.Controls.Add(this.phTagListNameTextBox);
            resources.ApplyResources(this.phtagListNameGroupBox, "phtagListNameGroupBox");
            this.phtagListNameGroupBox.Name = "phtagListNameGroupBox";
            this.phtagListNameGroupBox.TabStop = false;
            // 
            // TagInfoGroupForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.phtagListNameGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.phTagsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TagInfoGroupForm";
            this.phTagsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.phTagListNameErrorProvider)).EndInit();
            this.phtagListNameGroupBox.ResumeLayout(false);
            this.phtagListNameGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltTextBox phTagListNameTextBox;
        private OltGroupBox phTagsGroupBox;
        private OltPanel phTagListPanel;
        private OltButton clearButton;
        private OltButton removeButton;
        private OltButton addButton;
        private OltButton saveButton;
        private OltButton cancelButton;
        private ErrorProvider phTagListNameErrorProvider;
        private System.Windows.Forms.GroupBox phtagListNameGroupBox;
    }
}