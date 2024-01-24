using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.SubReports.DailyShiftLog;

namespace Com.Suncor.Olt.Reports
{
    partial class DailyShiftLogReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyShiftLogReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.subreportLogs = new DevExpress.XtraReports.UI.XRSubreport();
            this.subreportTags = new DevExpress.XtraReports.UI.XRSubreport();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.headerLine = new DevExpress.XtraReports.UI.XRLine();
            this.Text6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Logo_English = new DevExpress.XtraReports.UI.XRPictureBox();
            this.IsNotEnglish = new DevExpress.XtraReports.UI.FormattingRule();
            this.Logo_French = new DevExpress.XtraReports.UI.XRPictureBox();
            this.IsNotFrench = new DevExpress.XtraReports.UI.FormattingRule();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.PageNumber1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subreportLogs,
            this.subreportTags});
            this.Detail.HeightF = 120F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // subreportLogs
            // 
            this.subreportLogs.CanShrink = true;
            this.subreportLogs.Id = 0;
            this.subreportLogs.LocationFloat = new DevExpress.Utils.PointFloat(0F, 70F);
            this.subreportLogs.Name = "subreportLogs";
            this.subreportLogs.ReportSource = new CommentsSubReport();
            this.subreportLogs.Scripts.OnBeforePrint = "subreportLogs_BeforePrint";
            this.subreportLogs.SizeF = new System.Drawing.SizeF(770F, 50F);
            // 
            // subreportTags
            // 
            this.subreportTags.CanShrink = true;
            this.subreportTags.Id = 0;
            this.subreportTags.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.subreportTags.Name = "subreportTags";
            this.subreportTags.ReportSource = new TagInfoSubReport();
            this.subreportTags.Scripts.OnBeforePrint = "subreportTags_BeforePrint";
            this.subreportTags.SizeF = new System.Drawing.SizeF(770F, 50F);
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 20F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 20F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.headerLine,
            this.Text6,
            this.Logo_English,
            this.Logo_French});
            this.PageHeader.HeightF = 50F;
            this.PageHeader.Name = "PageHeader";
            // 
            // headerLine
            // 
            this.headerLine.BackColor = System.Drawing.Color.White;
            this.headerLine.BorderColor = System.Drawing.Color.Black;
            this.headerLine.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.headerLine.ForeColor = System.Drawing.Color.Black;
            this.headerLine.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45F);
            this.headerLine.Name = "headerLine";
            this.headerLine.SizeF = new System.Drawing.SizeF(770F, 2F);
            // 
            // Text6
            // 
            this.Text6.BorderColor = System.Drawing.Color.Black;
            this.Text6.CanGrow = false;
            this.Text6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_Title")});
            this.Text6.Font = new System.Drawing.Font("Arial", 20F);
            this.Text6.ForeColor = System.Drawing.Color.Black;
            this.Text6.LocationFloat = new DevExpress.Utils.PointFloat(137.5F, 0F);
            this.Text6.Name = "Text6";
            this.Text6.SizeF = new System.Drawing.SizeF(494F, 33F);
            this.Text6.StylePriority.UseBackColor = false;
            this.Text6.Text = "Text6";
            this.Text6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Logo_English
            // 
            this.Logo_English.BackColor = System.Drawing.Color.White;
            this.Logo_English.BorderColor = System.Drawing.Color.Black;
            this.Logo_English.FormattingRules.Add(this.IsNotEnglish);
            this.Logo_English.Image = ((System.Drawing.Image)(resources.GetObject("Logo_English.Image")));
            this.Logo_English.LocationFloat = new DevExpress.Utils.PointFloat(670F, 0F);
            this.Logo_English.Name = "Logo_English";
            this.Logo_English.SizeF = new System.Drawing.SizeF(95F, 39F);
            this.Logo_English.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // IsNotEnglish
            // 
            this.IsNotEnglish.Condition = "[ShowEnglishLogo] == False";
            // 
            // 
            // 
            this.IsNotEnglish.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.IsNotEnglish.Name = "IsNotEnglish";
            // 
            // Logo_French
            // 
            this.Logo_French.BackColor = System.Drawing.Color.White;
            this.Logo_French.BorderColor = System.Drawing.Color.Black;
            this.Logo_French.FormattingRules.Add(this.IsNotFrench);
            this.Logo_French.Image = ((System.Drawing.Image)(resources.GetObject("Logo_French.Image")));
            this.Logo_French.LocationFloat = new DevExpress.Utils.PointFloat(670F, 0F);
            this.Logo_French.Name = "Logo_French";
            this.Logo_French.SizeF = new System.Drawing.SizeF(95F, 39F);
            this.Logo_French.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // IsNotFrench
            // 
            this.IsNotFrench.Condition = "[ShowFrenchLogo] == False";
            // 
            // 
            // 
            this.IsNotFrench.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.IsNotFrench.Name = "IsNotFrench";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PageNumber1});
            this.PageFooter.HeightF = 16.66667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // PageNumber1
            // 
            this.PageNumber1.BorderColor = System.Drawing.Color.Black;
            this.PageNumber1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PageNumber1.ForeColor = System.Drawing.Color.Black;
            this.PageNumber1.LocationFloat = new DevExpress.Utils.PointFloat(680F, 0F);
            this.PageNumber1.Name = "PageNumber1";
            this.PageNumber1.PageInfo = DevExpress.XtraPrinting.PageInfo.Number;
            this.PageNumber1.SizeF = new System.Drawing.SizeF(84.99988F, 12F);
            this.PageNumber1.StylePriority.UseBackColor = false;
            this.PageNumber1.StylePriority.UseFont = false;
            this.PageNumber1.StylePriority.UseTextAlignment = false;
            this.PageNumber1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DailyShiftLogReportAdapter);
            // 
            // DailyShiftLogReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.PageFooter});
            this.DataSource = this.bindingSource1;
            this.DefaultPrinterSettingsUsing.UsePaperKind = true;
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.IsNotFrench,
            this.IsNotEnglish});
            this.Margins = new System.Drawing.Printing.Margins(55, 25, 20, 20);
            this.ReportPrintOptions.DetailCount = 1;
            this.ReportPrintOptions.DetailCountOnEmptyDataSource = 0;
            this.ReportPrintOptions.PrintOnEmptyDataSource = false;
            this.ScriptReferencesString = "System.Data.DataSetExtensions.dll\r\nCom.Suncor.Olt.Reporting.dll";
            this.Scripts.OnBeforePrint = "DailyShiftLogReport_BeforePrint";
            this.ScriptsSource = resources.GetString("$this.ScriptsSource");
            this.ShowPrintMarginsWarning = false;
            this.Version = "12.2";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel Text6;
        private DevExpress.XtraReports.UI.XRPictureBox Logo_English;
        private DevExpress.XtraReports.UI.XRPictureBox Logo_French;
        private DevExpress.XtraReports.UI.XRSubreport subreportLogs;
        private DevExpress.XtraReports.UI.XRSubreport subreportTags;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo PageNumber1;
        private DevExpress.XtraReports.UI.XRLine headerLine;
        private DevExpress.XtraReports.UI.FormattingRule IsNotEnglish;
        private DevExpress.XtraReports.UI.FormattingRule IsNotFrench;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
