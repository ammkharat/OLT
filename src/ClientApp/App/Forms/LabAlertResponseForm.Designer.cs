using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
namespace Com.Suncor.Olt.Client.Forms
{
    partial class LabAlertResponseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabAlertResponseForm));
            this.oltGroupBox1 = new OltGroupBox();
            this.reasonCodeComboBox = new OltComboBox();
            this.shiftLabelData = new OltLabel();
            this.shiftGroupBox = new OltGroupBox();
            this.oltGroupBox2 = new OltGroupBox();
            this.commentTextBox = new Com.Suncor.Olt.Client.OltControls.OltSpellCheckTextBox(this.components);
            this.cancelButton = new OltButton();
            this.submitButton = new OltButton();
            this.detailsLabelLine = new OltLabelLine();
            this.commentErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.oltLastModifiedDateAuthorHeader = new OltLastModifiedDateAuthorHeader();
            this.createLogCheckBox = new System.Windows.Forms.CheckBox();
            this.flocColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.oltGroupBox1.SuspendLayout();
            this.shiftGroupBox.SuspendLayout();
            this.oltGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commentErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // oltGroupBox1
            // 
            this.oltGroupBox1.Controls.Add(this.reasonCodeComboBox);
            resources.ApplyResources(this.oltGroupBox1, "oltGroupBox1");
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.TabStop = false;
            // 
            // reasonCodeComboBox
            // 
            this.reasonCodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reasonCodeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.reasonCodeComboBox, "reasonCodeComboBox");
            this.reasonCodeComboBox.Name = "reasonCodeComboBox";
            // 
            // shiftLabelData
            // 
            resources.ApplyResources(this.shiftLabelData, "shiftLabelData");
            this.shiftLabelData.Name = "shiftLabelData";
            // 
            // shiftGroupBox
            // 
            resources.ApplyResources(this.shiftGroupBox, "shiftGroupBox");
            this.shiftGroupBox.Controls.Add(this.shiftLabelData);
            this.shiftGroupBox.Name = "shiftGroupBox";
            this.shiftGroupBox.TabStop = false;
            // 
            // oltGroupBox2
            // 
            resources.ApplyResources(this.oltGroupBox2, "oltGroupBox2");
            this.oltGroupBox2.Controls.Add(this.commentTextBox);
            this.oltGroupBox2.Name = "oltGroupBox2";
            this.oltGroupBox2.TabStop = false;
            // 
            // commentTextBox
            // 
            resources.ApplyResources(this.commentTextBox, "commentTextBox");
            this.commentTextBox.MaxLength = 3000;
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.ReadOnly = false;
            this.commentTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            resources.ApplyResources(this.submitButton, "submitButton");
            this.submitButton.Name = "submitButton";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // detailsLabelLine
            // 
            resources.ApplyResources(this.detailsLabelLine, "detailsLabelLine");
            this.detailsLabelLine.Name = "detailsLabelLine";
            this.detailsLabelLine.TabStop = false;
            // 
            // commentErrorProvider
            // 
            this.commentErrorProvider.ContainerControl = this;
            // 
            // oltLastModifiedDateAuthorHeader
            // 
            resources.ApplyResources(this.oltLastModifiedDateAuthorHeader, "oltLastModifiedDateAuthorHeader");
            this.oltLastModifiedDateAuthorHeader.LastModifiedDate = new System.DateTime(((long)(0)));
            this.oltLastModifiedDateAuthorHeader.Name = "oltLastModifiedDateAuthorHeader";
            this.oltLastModifiedDateAuthorHeader.TabStop = false;
            // 
            // createLogCheckBox
            // 
            resources.ApplyResources(this.createLogCheckBox, "createLogCheckBox");
            this.createLogCheckBox.Checked = true;
            this.createLogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createLogCheckBox.Name = "createLogCheckBox";
            this.createLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // LabAlertResponseForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.createLogCheckBox);
            this.Controls.Add(this.oltLastModifiedDateAuthorHeader);
            this.Controls.Add(this.detailsLabelLine);
            this.Controls.Add(this.oltGroupBox1);
            this.Controls.Add(this.shiftGroupBox);
            this.Controls.Add(this.oltGroupBox2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Name = "LabAlertResponseForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.oltGroupBox1.ResumeLayout(false);
            this.shiftGroupBox.ResumeLayout(false);
            this.shiftGroupBox.PerformLayout();
            this.oltGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commentErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltGroupBox oltGroupBox1;
        private OltComboBox reasonCodeComboBox;
        private OltLabel shiftLabelData;
        private OltGroupBox shiftGroupBox;
        private OltGroupBox oltGroupBox2;
        private OltButton cancelButton;
        private OltButton submitButton;
        private OltLabelLine detailsLabelLine;
        private ErrorProvider commentErrorProvider;
        private OltLastModifiedDateAuthorHeader oltLastModifiedDateAuthorHeader;
        private ColumnHeader flocColumnHeader;
        private OltSpellCheckTextBox commentTextBox;
        private CheckBox createLogCheckBox;

    }
}
