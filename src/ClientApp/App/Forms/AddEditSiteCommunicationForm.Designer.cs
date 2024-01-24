using Com.Suncor.Olt.Client.Security;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class AddEditSiteCommunicationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditSiteCommunicationForm));
            this.buttonsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.mainPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.endTimePicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.endDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.startTimePicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.startDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.messageTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkAllSites = new System.Windows.Forms.CheckBox();
            this.buttonsPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.cancelButton);
            this.buttonsPanel.Controls.Add(this.saveButton);
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.chkAllSites);
            this.mainPanel.Controls.Add(this.endTimePicker);
            this.mainPanel.Controls.Add(this.endDatePicker);
            this.mainPanel.Controls.Add(this.startTimePicker);
            this.mainPanel.Controls.Add(this.startDatePicker);
            this.mainPanel.Controls.Add(this.oltLabel3);
            this.mainPanel.Controls.Add(this.oltLabel2);
            this.mainPanel.Controls.Add(this.messageTextBox);
            this.mainPanel.Controls.Add(this.oltLabel1);
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Name = "mainPanel";
            // 
            // endTimePicker
            // 
            this.endTimePicker.Checked = true;
            this.endTimePicker.CustomFormat = "HH:mm";
            resources.ApplyResources(this.endTimePicker, "endTimePicker");
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowCheckBox = false;
            // 
            // endDatePicker
            // 
            this.endDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.endDatePicker, "endDatePicker");
            this.endDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.PickerEnabled = true;
            // 
            // startTimePicker
            // 
            this.startTimePicker.Checked = true;
            this.startTimePicker.CustomFormat = "HH:mm";
            resources.ApplyResources(this.startTimePicker, "startTimePicker");
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowCheckBox = false;
            // 
            // startDatePicker
            // 
            this.startDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.startDatePicker, "startDatePicker");
            this.startDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.PickerEnabled = true;
            // 
            // oltLabel3
            // 
            resources.ApplyResources(this.oltLabel3, "oltLabel3");
            this.oltLabel3.Name = "oltLabel3";
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // messageTextBox
            // 
            resources.ApplyResources(this.messageTextBox, "messageTextBox");
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.OltAcceptsReturn = true;
            this.messageTextBox.OltTrimWhitespace = true;
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
            // chkAllSites                          //ayman Site Communication
            // 
            //Authorized authorized = new Authorized();
            //if (authorized.ToPerformTechnicalAdminTasks(ClientSession.GetUserContext().UserRoleElements))
            //{
                resources.ApplyResources(this.chkAllSites, "chkAllSites");
                this.chkAllSites.Name = "chkAllSites";
                this.chkAllSites.UseVisualStyleBackColor = true;
           // }
            // 
            // AddEditSiteCommunicationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonsPanel);
            this.Name = "AddEditSiteCommunicationForm";
            this.buttonsPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel buttonsPanel;
        private OltControls.OltPanel mainPanel;
        private OltControls.OltButton cancelButton;
        private OltControls.OltButton saveButton;
        private OltControls.OltTextBox messageTextBox;
        private OltControls.OltLabel oltLabel1;
        private OltControls.OltLabel oltLabel3;
        private OltControls.OltLabel oltLabel2;
        private OltControls.OltDatePicker endDatePicker;
        private OltControls.OltTimePicker startTimePicker;
        private OltControls.OltDatePicker startDatePicker;
        private OltControls.OltTimePicker endTimePicker;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox chkAllSites;
    }
}