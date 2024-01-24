namespace Com.Suncor.Olt.Client.Forms
{
    partial class EmailToRecipientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailToRecipientForm));
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.closeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.removeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltPanel2 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.emailsListView = new Com.Suncor.Olt.Client.OltControls.OltListView();
            this.AddEmailButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.emailTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.oltPanel1.SuspendLayout();
            this.oltPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.closeButton);
            this.oltPanel1.Controls.Add(this.removeButton);
            this.oltPanel1.Controls.Add(this.saveButton);
            resources.ApplyResources(this.oltPanel1, "oltPanel1");
            this.oltPanel1.Name = "oltPanel1";
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            resources.ApplyResources(this.removeButton, "removeButton");
            this.removeButton.Name = "removeButton";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // oltPanel2
            // 
            this.oltPanel2.Controls.Add(this.emailsListView);
            this.oltPanel2.Controls.Add(this.AddEmailButton);
            this.oltPanel2.Controls.Add(this.emailTextBox);
            this.oltPanel2.Controls.Add(this.oltLabel1);
            resources.ApplyResources(this.oltPanel2, "oltPanel2");
            this.oltPanel2.Name = "oltPanel2";
            // 
            // emailsListView
            // 
            this.emailsListView.FullRowSelect = true;
            this.emailsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            resources.ApplyResources(this.emailsListView, "emailsListView");
            this.emailsListView.Name = "emailsListView";
            this.emailsListView.UseCompatibleStateImageBehavior = false;
            // 
            // AddEmailButton
            // 
            resources.ApplyResources(this.AddEmailButton, "AddEmailButton");
            this.AddEmailButton.Name = "AddEmailButton";
            this.AddEmailButton.UseVisualStyleBackColor = true;
            // 
            // emailTextBox
            // 
            resources.ApplyResources(this.emailTextBox, "emailTextBox");
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.OltAcceptsReturn = true;
            this.emailTextBox.OltTrimWhitespace = true;
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // EmailToRecipientForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oltPanel2);
            this.Controls.Add(this.oltPanel1);
            this.Name = "EmailToRecipientForm";
            this.oltPanel1.ResumeLayout(false);
            this.oltPanel2.ResumeLayout(false);
            this.oltPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel oltPanel1;
        private OltControls.OltPanel oltPanel2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltControls.OltButton closeButton;
        private OltControls.OltButton removeButton;
        private OltControls.OltButton saveButton;
        private OltControls.OltButton AddEmailButton;
        private OltControls.OltTextBox emailTextBox;
        private OltControls.OltLabel oltLabel1;
        private OltControls.OltListView emailsListView;
    }
}