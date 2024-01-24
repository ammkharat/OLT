using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class FlocLevelSettingForAdmin
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
            this.btnCancel = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.btnSave = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cmbActionItemFlocLevel = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.cmbShiftLogFlocLevel = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.cmbShiftHandoverFlocLevel = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.lblActionItem = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.lblShiftLog = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.lblShiftHandover = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.label4 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.chkActionItem = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkShiftLog = new System.Windows.Forms.CheckBox();
            this.chkShiftHandover = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(336, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(233, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Submit";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // cmbActionItemFlocLevel
            // 
            this.cmbActionItemFlocLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActionItemFlocLevel.FormattingEnabled = true;
            this.cmbActionItemFlocLevel.Location = new System.Drawing.Point(230, 70);
            this.cmbActionItemFlocLevel.Name = "cmbActionItemFlocLevel";
            this.cmbActionItemFlocLevel.Size = new System.Drawing.Size(121, 21);
            this.cmbActionItemFlocLevel.TabIndex = 1;
            // 
            // cmbShiftLogFlocLevel
            // 
            this.cmbShiftLogFlocLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShiftLogFlocLevel.FormattingEnabled = true;
            this.cmbShiftLogFlocLevel.Location = new System.Drawing.Point(230, 116);
            this.cmbShiftLogFlocLevel.Name = "cmbShiftLogFlocLevel";
            this.cmbShiftLogFlocLevel.Size = new System.Drawing.Size(121, 21);
            this.cmbShiftLogFlocLevel.TabIndex = 2;
            // 
            // cmbShiftHandoverFlocLevel
            // 
            this.cmbShiftHandoverFlocLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShiftHandoverFlocLevel.FormattingEnabled = true;
            this.cmbShiftHandoverFlocLevel.Location = new System.Drawing.Point(230, 159);
            this.cmbShiftHandoverFlocLevel.Name = "cmbShiftHandoverFlocLevel";
            this.cmbShiftHandoverFlocLevel.Size = new System.Drawing.Size(121, 21);
            this.cmbShiftHandoverFlocLevel.TabIndex = 3;
            // 
            // lblActionItem
            // 
            this.lblActionItem.AutoSize = true;
            this.lblActionItem.Location = new System.Drawing.Point(142, 71);
            this.lblActionItem.Name = "lblActionItem";
            this.lblActionItem.Size = new System.Drawing.Size(65, 13);
            this.lblActionItem.TabIndex = 4;
            this.lblActionItem.Text = "Action Item ";
            // 
            // lblShiftLog
            // 
            this.lblShiftLog.AutoSize = true;
            this.lblShiftLog.Location = new System.Drawing.Point(142, 117);
            this.lblShiftLog.Name = "lblShiftLog";
            this.lblShiftLog.Size = new System.Drawing.Size(49, 13);
            this.lblShiftLog.TabIndex = 5;
            this.lblShiftLog.Text = "Shift Log";
            // 
            // lblShiftHandover
            // 
            this.lblShiftHandover.AutoSize = true;
            this.lblShiftHandover.Location = new System.Drawing.Point(142, 167);
            this.lblShiftHandover.Name = "lblShiftHandover";
            this.lblShiftHandover.Size = new System.Drawing.Size(79, 13);
            this.lblShiftHandover.TabIndex = 6;
            this.lblShiftHandover.Text = "Shift Handover";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(100, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Floc Structure Level Update";
            // 
            // chkActionItem
            // 
            this.chkActionItem.AutoSize = true;
            this.chkActionItem.Location = new System.Drawing.Point(73, 73);
            this.chkActionItem.Name = "chkActionItem";
            this.chkActionItem.Size = new System.Drawing.Size(15, 14);
            this.chkActionItem.TabIndex = 9;
            this.chkActionItem.UseVisualStyleBackColor = true;
            this.chkActionItem.CheckedChanged += new System.EventHandler(this.chkActionItem_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkShiftHandover);
            this.groupBox1.Controls.Add(this.chkShiftLog);
            this.groupBox1.Controls.Add(this.cmbShiftHandoverFlocLevel);
            this.groupBox1.Controls.Add(this.chkActionItem);
            this.groupBox1.Controls.Add(this.cmbActionItemFlocLevel);
            this.groupBox1.Controls.Add(this.cmbShiftLogFlocLevel);
            this.groupBox1.Controls.Add(this.lblActionItem);
            this.groupBox1.Controls.Add(this.lblShiftHandover);
            this.groupBox1.Controls.Add(this.lblShiftLog);
            this.groupBox1.Location = new System.Drawing.Point(75, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 211);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // chkShiftLog
            // 
            this.chkShiftLog.AutoSize = true;
            this.chkShiftLog.Location = new System.Drawing.Point(73, 118);
            this.chkShiftLog.Name = "chkShiftLog";
            this.chkShiftLog.Size = new System.Drawing.Size(15, 14);
            this.chkShiftLog.TabIndex = 10;
            this.chkShiftLog.UseVisualStyleBackColor = true;
            this.chkShiftLog.CheckedChanged += new System.EventHandler(this.chkShiftLog_CheckedChanged);
            // 
            // chkShiftHandover
            // 
            this.chkShiftHandover.AutoSize = true;
            this.chkShiftHandover.Location = new System.Drawing.Point(73, 166);
            this.chkShiftHandover.Name = "chkShiftHandover";
            this.chkShiftHandover.Size = new System.Drawing.Size(15, 14);
            this.chkShiftHandover.TabIndex = 11;
            this.chkShiftHandover.UseVisualStyleBackColor = true;
            this.chkShiftHandover.CheckedChanged += new System.EventHandler(this.chkShiftHandover_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(318, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Please select the item you want to update";
            // 
            // FlocLevelSettingForAdmin
            // 
            this.ClientSize = new System.Drawing.Size(611, 325);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.Name = "FlocLevelSettingForAdmin";
            this.Text = "Floc Structure Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton btnSave;
        private OltComboBox cmbActionItemFlocLevel;
        private OltComboBox cmbShiftLogFlocLevel;
        private OltComboBox cmbShiftHandoverFlocLevel;
        private OltLabel lblActionItem;
        private OltLabel lblShiftLog;
        private OltLabel lblShiftHandover;
        private OltLabel label4;
        private OltButton btnCancel;
        private System.Windows.Forms.CheckBox chkActionItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkShiftHandover;
        private System.Windows.Forms.CheckBox chkShiftLog;


    }
}