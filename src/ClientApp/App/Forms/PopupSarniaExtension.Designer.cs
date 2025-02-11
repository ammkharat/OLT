﻿using System.Drawing;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class PopupSarniaExtension
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupSarniaExtension));
            this.extensionTimePickerWP = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.extensionDatePickerWP = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.entensionoltLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.infoProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltExtensionTime = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // extensionTimePickerWP
            // 
            this.extensionTimePickerWP.Checked = true;
            this.extensionTimePickerWP.CustomFormat = "HH:mm";
            this.extensionTimePickerWP.Location = new System.Drawing.Point(306, 9);
            this.extensionTimePickerWP.Margin = new System.Windows.Forms.Padding(0);
            this.extensionTimePickerWP.Name = "extensionTimePickerWP";
            this.extensionTimePickerWP.ShowCheckBox = false;
            this.extensionTimePickerWP.Size = new System.Drawing.Size(60, 21);
            this.extensionTimePickerWP.TabIndex = 48;
            // 
            // extensionDatePickerWP
            // 
            this.extensionDatePickerWP.CustomFormat = "ddd MM/dd/yyyy";
            this.extensionDatePickerWP.Location = new System.Drawing.Point(182, 9);
            this.extensionDatePickerWP.Margin = new System.Windows.Forms.Padding(0);
            this.extensionDatePickerWP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.extensionDatePickerWP.Name = "extensionDatePickerWP";
            this.extensionDatePickerWP.PickerEnabled = true;
            this.extensionDatePickerWP.Size = new System.Drawing.Size(110, 21);
            this.extensionDatePickerWP.TabIndex = 47;
            // 
            // entensionoltLabel
            // 
            this.entensionoltLabel.AutoSize = true;
            this.entensionoltLabel.Location = new System.Drawing.Point(-163, 125);
            this.entensionoltLabel.Name = "entensionoltLabel";
            this.entensionoltLabel.Size = new System.Drawing.Size(61, 13);
            this.entensionoltLabel.TabIndex = 49;
            this.entensionoltLabel.Text = "Extension :";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.AutoSize = true;
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.saveButton.Location = new System.Drawing.Point(182, 88);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(76, 23);
            this.saveButton.TabIndex = 52;
            this.saveButton.Text = "&Save && Print";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // infoProvider
            // 
            this.infoProvider.ContainerControl = this;
            this.infoProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("infoProvider.Icon")));
            // 
            // oltLabel1
            // 
            this.oltLabel1.AutoSize = true;
            this.oltLabel1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oltLabel1.Location = new System.Drawing.Point(29, 40);
            this.oltLabel1.Name = "oltLabel1";
            this.oltLabel1.Size = new System.Drawing.Size(112, 13);
            this.oltLabel1.TabIndex = 54;
            this.oltLabel1.Text = "Extension(By Hours) :";
            // 
            // oltExtensionTime
            // 
            this.oltExtensionTime.Checked = true;
            this.oltExtensionTime.CustomFormat = "HH:mm";
            this.oltExtensionTime.Location = new System.Drawing.Point(182, 40);
            this.oltExtensionTime.Margin = new System.Windows.Forms.Padding(0);
            this.oltExtensionTime.Name = "oltExtensionTime";
            this.oltExtensionTime.ShowCheckBox = false;
            this.oltExtensionTime.Size = new System.Drawing.Size(60, 21);
            this.oltExtensionTime.TabIndex = 55;
            // 
            // oltLabel2
            // 
            this.oltLabel2.AutoSize = true;
            this.oltLabel2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oltLabel2.Location = new System.Drawing.Point(5, 9);
            this.oltLabel2.Name = "oltLabel2";
            this.oltLabel2.Size = new System.Drawing.Size(174, 13);
            this.oltLabel2.TabIndex = 56;
            this.oltLabel2.Text = "Workpermit Expiry Date and Time :";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.AutoSize = true;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(293, 88);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(73, 23);
            this.cancelButton.TabIndex = 57;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // PopupSarniaExtension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.saveButton;
            this.ClientSize = new System.Drawing.Size(509, 123);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.oltLabel2);
            this.Controls.Add(this.oltExtensionTime);
            this.Controls.Add(this.oltLabel1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.extensionTimePickerWP);
            this.Controls.Add(this.extensionDatePickerWP);
            this.Controls.Add(this.entensionoltLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "PopupSarniaExtension";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Extension";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltControls.OltTimePicker extensionTimePickerWP;
        private OltControls.OltDatePicker extensionDatePickerWP;
        private OltControls.OltLabel entensionoltLabel;
        private OltControls.OltButton saveButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider infoProvider;
        private OltControls.OltLabel oltLabel1;
        private OltControls.OltTimePicker oltExtensionTime;
        private OltControls.OltLabel oltLabel2;
        private OltControls.OltButton cancelButton;
    }
}