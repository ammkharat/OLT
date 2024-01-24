using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Reports.SubReports.GenericMultiLog
{
    partial class CustomFieldsSubReport
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
            this.fieldThreeName = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldThreeValue = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldTwoName = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldTwoValue = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldOneValue = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldOneName = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.LogId = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.customFieldsReportAdapter = new System.Windows.Forms.BindingSource(this.components);
            this.fieldOneColor = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldTwoColor = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldThreeColor = new DevExpress.XtraReports.UI.XRLabel();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.formattingRule2 = new DevExpress.XtraReports.UI.FormattingRule();
            this.formattingRule3 = new DevExpress.XtraReports.UI.FormattingRule();
            ((System.ComponentModel.ISupportInitialize)(this.customFieldsReportAdapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.fieldThreeColor,
            this.fieldTwoColor,
            this.fieldOneColor,
            this.fieldThreeName,
            this.fieldThreeValue,
            this.fieldTwoName,
            this.fieldTwoValue,
            this.fieldOneValue,
            this.fieldOneName});
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fieldThreeName
            // 
            this.fieldThreeName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldThreeName")});
            this.fieldThreeName.LocationFloat = new DevExpress.Utils.PointFloat(440F, 0F);
            this.fieldThreeName.Name = "fieldThreeName";
            this.fieldThreeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldThreeName.SizeF = new System.Drawing.SizeF(110F, 13F);
            this.fieldThreeName.StylePriority.UseFont = false;
            this.fieldThreeName.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.XrtTableCellOnBeforePrint);
            // 
            // fieldThreeValue
            // 
            this.fieldThreeValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldThreeEntry")});
            this.fieldThreeValue.FormattingRules.Add(this.formattingRule3);
            this.fieldThreeValue.LocationFloat = new DevExpress.Utils.PointFloat(560F, 0F);
            this.fieldThreeValue.Name = "fieldThreeValue";
            this.fieldThreeValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldThreeValue.SizeF = new System.Drawing.SizeF(70F, 13F);
            this.fieldThreeValue.StylePriority.UseFont = false;
            // 
            // fieldTwoName
            // 
            this.fieldTwoName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldTwoName")});
            this.fieldTwoName.LocationFloat = new DevExpress.Utils.PointFloat(220F, 0F);
            this.fieldTwoName.Name = "fieldTwoName";
            this.fieldTwoName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldTwoName.SizeF = new System.Drawing.SizeF(110F, 13F);
            this.fieldTwoName.StylePriority.UseFont = false;
            this.fieldTwoName.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.XrtTableCellOnBeforePrint);
            // 
            // fieldTwoValue
            // 
            this.fieldTwoValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldTwoEntry")});
            this.fieldTwoValue.FormattingRules.Add(this.formattingRule2);
            this.fieldTwoValue.LocationFloat = new DevExpress.Utils.PointFloat(340F, 0F);
            this.fieldTwoValue.Name = "fieldTwoValue";
            this.fieldTwoValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldTwoValue.SizeF = new System.Drawing.SizeF(70F, 13F);
            this.fieldTwoValue.StylePriority.UseFont = false;
            // 
            // fieldOneValue
            // 
            this.fieldOneValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldOneEntry")});
            this.fieldOneValue.FormattingRules.Add(this.formattingRule1);
            this.fieldOneValue.LocationFloat = new DevExpress.Utils.PointFloat(120F, 0F);
            this.fieldOneValue.Name = "fieldOneValue";
            this.fieldOneValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldOneValue.SizeF = new System.Drawing.SizeF(70F, 13F);
            this.fieldOneValue.StylePriority.UseFont = false;
            // 
            // fieldOneName
            // 
            this.fieldOneName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldOneName")});
            this.fieldOneName.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.fieldOneName.Name = "fieldOneName";
            this.fieldOneName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldOneName.SizeF = new System.Drawing.SizeF(110F, 13F);
            this.fieldOneName.StylePriority.UseFont = false;
            this.fieldOneName.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.XrtTableCellOnBeforePrint);
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
            // ReportFooter
            // 
            this.ReportFooter.HeightF = 5F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // customFieldsReportAdapter
            // 
            this.customFieldsReportAdapter.DataSource = typeof(Com.Suncor.Olt.Reports.Adapters.CustomFieldsReportAdapter);
            // 
            // fieldOneColor
            // 
            this.fieldOneColor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldOneEntryColor")});
            this.fieldOneColor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.fieldOneColor.Name = "fieldOneColor";
            this.fieldOneColor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.fieldOneColor.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.fieldOneColor.Visible = false;
            // 
            // fieldTwoColor
            // 
            this.fieldTwoColor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldTwoEntryColor")});
            this.fieldTwoColor.LocationFloat = new DevExpress.Utils.PointFloat(220F, 0F);
            this.fieldTwoColor.Name = "fieldTwoColor";
            this.fieldTwoColor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.fieldTwoColor.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.fieldTwoColor.Visible = false;
            // 
            // fieldThreeColor
            // 
            this.fieldThreeColor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldThreeEntryColor")});
            this.fieldThreeColor.LocationFloat = new DevExpress.Utils.PointFloat(440F, 0F);
            this.fieldThreeColor.Name = "fieldThreeColor";
            this.fieldThreeColor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.fieldThreeColor.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.fieldThreeColor.Visible = false;
            // 
            // formattingRule1
            // 
            this.formattingRule1.Condition = "[FieldOneEntryColor] == \'R\'";
            // 
            // 
            // 
            this.formattingRule1.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule1.Name = "formattingRule1";
            // 
            // formattingRule2
            // 
            this.formattingRule2.Condition = "[FieldTwoEntryColor] == \'R\'";
            // 
            // 
            // 
            this.formattingRule2.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule2.Name = "formattingRule2";
            // 
            // formattingRule3
            // 
            this.formattingRule3.Condition = "[FieldThreeEntryColor] == \'R\'";
            // 
            // 
            // 
            this.formattingRule3.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule3.Name = "formattingRule3";
            // 
            // CustomFieldsSubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter});
            this.DataSource = this.customFieldsReportAdapter;
            this.FilterString = "[ParentId] = ?LogId";
            this.Font = new System.Drawing.Font("Arial Narrow", 8.25F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1,
            this.formattingRule2,
            this.formattingRule3});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageWidth = 630;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.LogId});
            this.ReportPrintOptions.PrintOnEmptyDataSource = false;
            this.Version = "13.2";
            ((System.ComponentModel.ISupportInitialize)(this.customFieldsReportAdapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private System.Windows.Forms.BindingSource customFieldsReportAdapter;
        private DevExpress.XtraReports.UI.XRLabel fieldOneName;
        private DevExpress.XtraReports.UI.XRLabel fieldTwoName;
        private DevExpress.XtraReports.UI.XRLabel fieldTwoValue;
        private DevExpress.XtraReports.UI.XRLabel fieldOneValue;
        private DevExpress.XtraReports.UI.XRLabel fieldThreeName;
        private DevExpress.XtraReports.UI.XRLabel fieldThreeValue;
        public DevExpress.XtraReports.Parameters.Parameter LogId;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel fieldOneColor;
        private DevExpress.XtraReports.UI.XRLabel fieldTwoColor;
        private DevExpress.XtraReports.UI.XRLabel fieldThreeColor;
        private DevExpress.XtraReports.UI.FormattingRule formattingRule1;
        private DevExpress.XtraReports.UI.FormattingRule formattingRule2;
        private DevExpress.XtraReports.UI.FormattingRule formattingRule3;
    }
}
