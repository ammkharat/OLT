using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Reports.SubReports.GenericSingleLog
{
    partial class DateTimeAndUserSubReport
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
            this.userLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.dateTimeLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.dateTimeAndUserReportAdapter = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeAndUserReportAdapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.userLabel,
            this.dateTimeLabel});
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // userLabel
            // 
            this.userLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "UserName")});
            this.userLabel.KeepTogether = true;
            this.userLabel.LocationFloat = new DevExpress.Utils.PointFloat(165F, 0F);
            this.userLabel.Name = "userLabel";
            this.userLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.userLabel.SizeF = new System.Drawing.SizeF(460F, 16F);
            this.userLabel.Text = "userLabel";
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.CanGrow = false;
            this.dateTimeLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DateTime", "{0:yyyy/MM/dd HH:mm}")});
            this.dateTimeLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dateTimeLabel.SizeF = new System.Drawing.SizeF(156F, 16F);
            this.dateTimeLabel.Text = "dateTimeLabel";
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
            // dateTimeAndUserReportAdapter
            // 
            this.dateTimeAndUserReportAdapter.DataSource = typeof(DateTimeAndUserReportAdapter);
            // 
            // DateTimeAndUserSubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.DataSource = this.dateTimeAndUserReportAdapter;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageWidth = 770;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "12.2";
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeAndUserReportAdapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel userLabel;
        private DevExpress.XtraReports.UI.XRLabel dateTimeLabel;
        private System.Windows.Forms.BindingSource dateTimeAndUserReportAdapter;
    }
}
