namespace Com.Suncor.Olt.Client.Forms
{
    partial class EditFormTemplateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFormTemplateForm));
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltPanel2 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.richTextEditor = new Com.Suncor.Olt.Client.Controls.RichTextEditor();
            this.oltPanel1.SuspendLayout();
            this.oltPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // oltPanel1
            // 
            resources.ApplyResources(this.oltPanel1, "oltPanel1");
            this.oltPanel1.Controls.Add(this.saveButton);
            this.oltPanel1.Controls.Add(this.cancelButton);
            this.oltPanel1.Name = "oltPanel1";
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
            // oltPanel2
            // 
            resources.ApplyResources(this.oltPanel2, "oltPanel2");
            this.oltPanel2.Controls.Add(this.richTextEditor);
            this.oltPanel2.Name = "oltPanel2";
            // 
            // richTextEditor
            // 
            resources.ApplyResources(this.richTextEditor, "richTextEditor");
            this.richTextEditor.Name = "richTextEditor";
            this.richTextEditor.ReadOnly = false;
            // 
            // EditFormTemplateForm
            // 
            this.AcceptButton = this.saveButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.oltPanel2);
            this.Controls.Add(this.oltPanel1);
            this.Name = "EditFormTemplateForm";
            this.oltPanel1.ResumeLayout(false);
            this.oltPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel oltPanel1;
        private OltControls.OltPanel oltPanel2;
        private Controls.RichTextEditor richTextEditor;
        private OltControls.OltButton saveButton;
        private OltControls.OltButton cancelButton;
    }
}