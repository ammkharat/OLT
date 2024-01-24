using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class StatusModificationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusModificationControl));
            this.modificationUserLabel = new OltLabel();
            this.modificationUser = new OltLabelData();
            this.modificationDateTime = new OltLabelData();
            this.modificationDateTimeLabel = new OltLabel();
            this.previousStatusLabel = new OltLabel();
            this.previousStatus = new OltLabelData();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // modificationUserLabel
            // 
            resources.ApplyResources(this.modificationUserLabel, "modificationUserLabel");
            this.modificationUserLabel.Name = "modificationUserLabel";
            // 
            // modificationUser
            // 
            resources.ApplyResources(this.modificationUser, "modificationUser");
            this.modificationUser.Name = "modificationUser";
            this.modificationUser.UseMnemonic = false;
            // 
            // modificationDateTime
            // 
            resources.ApplyResources(this.modificationDateTime, "modificationDateTime");
            this.modificationDateTime.Name = "modificationDateTime";
            this.modificationDateTime.UseMnemonic = false;
            // 
            // modificationDateTimeLabel
            // 
            resources.ApplyResources(this.modificationDateTimeLabel, "modificationDateTimeLabel");
            this.modificationDateTimeLabel.Name = "modificationDateTimeLabel";
            // 
            // previousStatusLabel
            // 
            resources.ApplyResources(this.previousStatusLabel, "previousStatusLabel");
            this.previousStatusLabel.Name = "previousStatusLabel";
            // 
            // previousStatus
            // 
            resources.ApplyResources(this.previousStatus, "previousStatus");
            this.previousStatus.Name = "previousStatus";
            this.previousStatus.UseMnemonic = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.modificationUserLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.previousStatus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.modificationDateTimeLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.modificationDateTime, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.previousStatusLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.modificationUser, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // StatusModificationControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StatusModificationControl";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltLabel modificationUserLabel;
        private OltLabelData modificationUser;
        private OltLabelData modificationDateTime;
        private OltLabel modificationDateTimeLabel;
        private OltLabel previousStatusLabel;
        private OltLabelData previousStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
