namespace Com.Suncor.Olt.Client.Controls.Details
{
    partial class WorkPermitDetailSarniaVersionController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitDetailSarniaVersionController));
            this.workPermitDetails = new WorkPermitDetailsSarnia();
            this.workPermitDetails_v_3_2 = new WorkPermitDetailsSarnia_v_3_2();
            this.SuspendLayout();
            // 
            // workPermitDetails
            // 
            this.workPermitDetails.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.workPermitDetails, "workPermitDetails");
            this.workPermitDetails.Name = "workPermitDetails";
            // 
            // workPermitDetails_v_3_2
            // 
            this.workPermitDetails_v_3_2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.workPermitDetails_v_3_2, "workPermitDetails_v_3_2");
            this.workPermitDetails_v_3_2.Name = "workPermitDetails_v_3_2";
            this.workPermitDetails_v_3_2.ShowButtonAppearance = null;
            // 
            // WorkPermitDetailSarniaVersionController
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.workPermitDetails);
            this.Controls.Add(this.workPermitDetails_v_3_2);
            this.Name = "WorkPermitDetailSarniaVersionController";
            this.ResumeLayout(false);

        }

        #endregion

        private WorkPermitDetailsSarnia workPermitDetails;
        private WorkPermitDetailsSarnia_v_3_2 workPermitDetails_v_3_2;
    }
}
