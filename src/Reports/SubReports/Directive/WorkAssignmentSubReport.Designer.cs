using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Reports.SubReports.Directive
{
    partial class WorkAssignmentSubReport
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.workAssignmentLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.LogId = new DevExpress.XtraReports.Parameters.Parameter();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.workAssignmentLabel});
            this.Detail.HeightF = 16.87501F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // workAssignmentLabel
            // 
            this.workAssignmentLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "WorkAssignmentName")});
            this.workAssignmentLabel.Font = new System.Drawing.Font("Arial", 9.75F);
            this.workAssignmentLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.workAssignmentLabel.Name = "workAssignmentLabel";
            this.workAssignmentLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.workAssignmentLabel.SizeF = new System.Drawing.SizeF(625F, 16F);
            this.workAssignmentLabel.StylePriority.UseFont = false;
            this.workAssignmentLabel.StylePriority.UsePadding = false;
            this.workAssignmentLabel.Text = "workAssignmentLabel";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // LogId
            // 
            this.LogId.Description = "LogId";
            this.LogId.Name = "LogId";
            this.LogId.Type = typeof(int);
            this.LogId.ValueInfo = "0";
            this.LogId.Visible = false;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Com.Suncor.Olt.Reports.Adapters.WorkAssignmentReportAdapter);
            // 
            // WorkAssignmentSubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.DataSource = this.bindingSource;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageWidth = 625;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "12.2";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel workAssignmentLabel;
        public DevExpress.XtraReports.Parameters.Parameter LogId;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}
