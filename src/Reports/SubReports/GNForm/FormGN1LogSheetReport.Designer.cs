namespace Com.Suncor.Olt.Reports.SubReports.GNForm
{
    partial class FormGN1LogSheetReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGN1LogSheetReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCheckBox3 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox2 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox1 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.headerLine = new DevExpress.XtraReports.UI.XRLine();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.permitNumberDataLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.reportTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.pageNumberLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.printedDateTimeLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.printDateTime = new DevExpress.XtraReports.Parameters.Parameter();
            this.formReportAdapter = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formReportAdapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText1,
            this.xrLabel1,
            this.xrTable2});
            this.Detail.HeightF = 888.5417F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrRichText1
            // 
            this.xrRichText1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 95F);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.Padding = new DevExpress.XtraPrinting.PaddingInfo(9, 0, 0, 0, 100F);
            this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
            this.xrRichText1.SizeF = new System.Drawing.SizeF(770F, 780F);
            this.xrRichText1.StylePriority.UsePadding = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 70F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(770F, 23F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Log Milestone Work Progress and any Changes to Plan. Sign and Date (legibly)";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.BorderWidth = 2;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2,
            this.xrTableRow5});
            this.xrTable2.SizeF = new System.Drawing.SizeF(770F, 50F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseBorderWidth = false;
            this.xrTable2.StylePriority.UsePadding = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell1});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 0.69444444444444442D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.Text = "Functional Location:";
            this.xrTableCell2.Weight = 0.564935064935065D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FunctionalLocation")});
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.Text = "xrTableCell1";
            this.xrTableCell1.Weight = 2.4350649350649349D;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell14,
            this.xrTableCell7});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 0.69444444444444442D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.Text = "Location:";
            this.xrTableCell5.Weight = 0.564935064935065D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Location")});
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.Text = "xrTableCell6";
            this.xrTableCell6.Weight = 1.4951303457284904D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.StylePriority.UseBorders = false;
            this.xrTableCell14.StylePriority.UseFont = false;
            this.xrTableCell14.Text = "CSE Level:";
            this.xrTableCell14.Weight = 0.31899326869419653D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrCheckBox3,
            this.xrCheckBox2,
            this.xrCheckBox1});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.Text = "xrTableCell7";
            this.xrTableCell7.Weight = 0.62094132064224838D;
            // 
            // xrCheckBox3
            // 
            this.xrCheckBox3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCheckBox3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "IsCseLevel3")});
            this.xrCheckBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrCheckBox3.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.xrCheckBox3.LocationFloat = new DevExpress.Utils.PointFloat(100F, 2.5F);
            this.xrCheckBox3.Name = "xrCheckBox3";
            this.xrCheckBox3.SizeF = new System.Drawing.SizeF(33.12F, 20F);
            this.xrCheckBox3.StylePriority.UseBorders = false;
            this.xrCheckBox3.StylePriority.UseFont = false;
            this.xrCheckBox3.Text = "3";
            // 
            // xrCheckBox2
            // 
            this.xrCheckBox2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCheckBox2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "IsCseLevel2")});
            this.xrCheckBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrCheckBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.xrCheckBox2.LocationFloat = new DevExpress.Utils.PointFloat(54.37488F, 2.5F);
            this.xrCheckBox2.Name = "xrCheckBox2";
            this.xrCheckBox2.SizeF = new System.Drawing.SizeF(33.12F, 20F);
            this.xrCheckBox2.StylePriority.UseBorders = false;
            this.xrCheckBox2.StylePriority.UseFont = false;
            this.xrCheckBox2.Text = "2";
            // 
            // xrCheckBox1
            // 
            this.xrCheckBox1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCheckBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "IsCseLevel1")});
            this.xrCheckBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrCheckBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.xrCheckBox1.LocationFloat = new DevExpress.Utils.PointFloat(6.749878F, 2.5F);
            this.xrCheckBox1.Name = "xrCheckBox1";
            this.xrCheckBox1.SizeF = new System.Drawing.SizeF(33.12F, 20F);
            this.xrCheckBox1.StylePriority.UseBorders = false;
            this.xrCheckBox1.StylePriority.UseFont = false;
            this.xrCheckBox1.Text = "1";
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
            // PageHeader
            // 
            this.PageHeader.BorderWidth = 2;
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.headerLine,
            this.xrPictureBox1,
            this.permitNumberDataLabel,
            this.reportTitle});
            this.PageHeader.HeightF = 60F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseBorders = false;
            this.PageHeader.StylePriority.UseBorderWidth = false;
            // 
            // headerLine
            // 
            this.headerLine.BackColor = System.Drawing.Color.White;
            this.headerLine.BorderColor = System.Drawing.Color.Black;
            this.headerLine.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.headerLine.ForeColor = System.Drawing.Color.Black;
            this.headerLine.LocationFloat = new DevExpress.Utils.PointFloat(0F, 58F);
            this.headerLine.Name = "headerLine";
            this.headerLine.SizeF = new System.Drawing.SizeF(770F, 2F);
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8.499995F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(95F, 39F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.xrPictureBox1.StylePriority.UseBorders = false;
            // 
            // permitNumberDataLabel
            // 
            this.permitNumberDataLabel.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.permitNumberDataLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FormNumber")});
            this.permitNumberDataLabel.LocationFloat = new DevExpress.Utils.PointFloat(675F, 16.5F);
            this.permitNumberDataLabel.Name = "permitNumberDataLabel";
            this.permitNumberDataLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.permitNumberDataLabel.SizeF = new System.Drawing.SizeF(91.25012F, 23F);
            this.permitNumberDataLabel.StylePriority.UseBorders = false;
            this.permitNumberDataLabel.StylePriority.UseTextAlignment = false;
            this.permitNumberDataLabel.Text = "permitNumberDataLabel";
            this.permitNumberDataLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // reportTitle
            // 
            this.reportTitle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.reportTitle.CanGrow = false;
            this.reportTitle.Font = new System.Drawing.Font("Arial", 16F);
            this.reportTitle.ForeColor = System.Drawing.Color.Black;
            this.reportTitle.LocationFloat = new DevExpress.Utils.PointFloat(114.5833F, 0.4999956F);
            this.reportTitle.Multiline = true;
            this.reportTitle.Name = "reportTitle";
            this.reportTitle.SizeF = new System.Drawing.SizeF(545.9167F, 55F);
            this.reportTitle.StylePriority.UseBackColor = false;
            this.reportTitle.StylePriority.UseBorderColor = false;
            this.reportTitle.StylePriority.UseBorders = false;
            this.reportTitle.StylePriority.UseFont = false;
            this.reportTitle.StylePriority.UseTextAlignment = false;
            this.reportTitle.Text = "GN-1 Confined Space Entry\r\nLog Sheet";
            this.reportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.reportTitle.WordWrap = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pageNumberLabel,
            this.printedDateTimeLabel});
            this.PageFooter.HeightF = 50F;
            this.PageFooter.Name = "PageFooter";
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.CanGrow = false;
            this.pageNumberLabel.Font = new System.Drawing.Font("Arial", 8.25F);
            this.pageNumberLabel.LocationFloat = new DevExpress.Utils.PointFloat(510F, 15F);
            this.pageNumberLabel.Name = "pageNumberLabel";
            this.pageNumberLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pageNumberLabel.Scripts.OnPrintOnPage = "pageNumberLabel_PrintOnPage";
            this.pageNumberLabel.SizeF = new System.Drawing.SizeF(256.25F, 15F);
            this.pageNumberLabel.StylePriority.UseFont = false;
            this.pageNumberLabel.StylePriority.UseTextAlignment = false;
            this.pageNumberLabel.Text = "pageNumberLabel";
            this.pageNumberLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.pageNumberLabel.WordWrap = false;
            // 
            // printedDateTimeLabel
            // 
            this.printedDateTimeLabel.CanGrow = false;
            this.printedDateTimeLabel.Font = new System.Drawing.Font("Arial", 8.25F);
            this.printedDateTimeLabel.LocationFloat = new DevExpress.Utils.PointFloat(52F, 15F);
            this.printedDateTimeLabel.Name = "printedDateTimeLabel";
            this.printedDateTimeLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.printedDateTimeLabel.Scripts.OnPrintOnPage = "printedDateTimeLabel_PrintOnPage";
            this.printedDateTimeLabel.SizeF = new System.Drawing.SizeF(256.25F, 15F);
            this.printedDateTimeLabel.StylePriority.UseFont = false;
            this.printedDateTimeLabel.Text = "[Label_PrintedOn] [Parameters.printDateTime]";
            this.printedDateTimeLabel.WordWrap = false;
            // 
            // printDateTime
            // 
            this.printDateTime.Description = "printDateTime";
            this.printDateTime.Name = "printDateTime";
            this.printDateTime.Visible = false;
            // 
            // formReportAdapter
            // 
            this.formReportAdapter.DataSource = typeof(Com.Suncor.Olt.Reports.Adapters.FormGN1ReportAdapter);
            // 
            // FormGN1LogSheetReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.TopMargin,
            this.BottomMargin,
            this.PageFooter});
            this.DataSource = this.formReportAdapter;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 1400;
            this.PageWidth = 770;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.printDateTime});
            this.ReportPrintOptions.PrintOnEmptyDataSource = false;
            this.Scripts.OnBeforePrint = "FormReport_BeforePrint";
            this.ScriptsSource = resources.GetString("$this.ScriptsSource");
            this.ShowPrintMarginsWarning = false;
            this.Version = "12.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formReportAdapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel permitNumberDataLabel;
        private DevExpress.XtraReports.UI.XRLabel reportTitle;
        private DevExpress.XtraReports.UI.XRLabel pageNumberLabel;
        private DevExpress.XtraReports.UI.XRLabel printedDateTimeLabel;
        private System.Windows.Forms.BindingSource formReportAdapter;
        private DevExpress.XtraReports.Parameters.Parameter printDateTime;
        private DevExpress.XtraReports.UI.XRLine headerLine;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRCheckBox xrCheckBox3;
        private DevExpress.XtraReports.UI.XRCheckBox xrCheckBox2;
        private DevExpress.XtraReports.UI.XRCheckBox xrCheckBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
    }
}