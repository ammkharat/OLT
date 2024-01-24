using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Reports.SubReports.GenericSingleLog
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
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.fieldOneValue = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldOneName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.fieldTwoName = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldTwoValue = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.fieldThreeName = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.customFieldOddStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.customFieldEvenStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.fieldThreeValue = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldOneColor = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldTwoColor = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldThreeColor = new DevExpress.XtraReports.UI.XRLabel();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.customFieldsReportAdapter = new System.Windows.Forms.BindingSource(this.components);
            this.formattingRule2 = new DevExpress.XtraReports.UI.FormattingRule();
            this.formattingRule3 = new DevExpress.XtraReports.UI.FormattingRule();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customFieldsReportAdapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.EvenStyleName = "customFieldEvenStyle";
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.OddStyleName = "customFieldOddStyle";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(769.9933F, 16F);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 0.69565217391304346D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrTableCell1.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrTableCell1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.fieldOneValue,
            this.fieldOneName,
            this.fieldOneColor});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorderDashStyle = false;
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.Text = "xrTableCell1";
            this.xrTableCell1.Weight = 0.99349686227865108D;
            // 
            // fieldOneValue
            // 
            this.fieldOneValue.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.fieldOneValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldOneEntry")});
            this.fieldOneValue.FormattingRules.Add(this.formattingRule1);
            this.fieldOneValue.LocationFloat = new DevExpress.Utils.PointFloat(165F, 0F);
            this.fieldOneValue.Name = "fieldOneValue";
            this.fieldOneValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldOneValue.SizeF = new System.Drawing.SizeF(70F, 13F);
            this.fieldOneValue.StylePriority.UseBorders = false;
            this.fieldOneValue.StylePriority.UseFont = false;
            // 
            // fieldOneName
            // 
            this.fieldOneName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.fieldOneName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldOneName")});
            this.fieldOneName.Font = new System.Drawing.Font("Arial Narrow", 8.25F);
            this.fieldOneName.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.fieldOneName.Name = "fieldOneName";
            this.fieldOneName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldOneName.SizeF = new System.Drawing.SizeF(150F, 13F);
            this.fieldOneName.StylePriority.UseBorders = false;
            this.fieldOneName.StylePriority.UseFont = false;
            this.fieldOneName.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.XrtTableCellOnBeforePrint);
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrTableCell2.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrTableCell2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.fieldTwoName,
            this.fieldTwoValue,
            this.fieldTwoColor});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBorderDashStyle = false;
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.Weight = 0.99349686227661D;
            // 
            // fieldTwoName
            // 
            this.fieldTwoName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.fieldTwoName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldTwoName")});
            this.fieldTwoName.Font = new System.Drawing.Font("Arial Narrow", 8.25F);
            this.fieldTwoName.LocationFloat = new DevExpress.Utils.PointFloat(10.00004F, 0F);
            this.fieldTwoName.Name = "fieldTwoName";
            this.fieldTwoName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldTwoName.SizeF = new System.Drawing.SizeF(150F, 13F);
            this.fieldTwoName.StylePriority.UseBorders = false;
            this.fieldTwoName.StylePriority.UseFont = false;
            this.fieldTwoName.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.XrtTableCellOnBeforePrint);
            // 
            // fieldTwoValue
            // 
            this.fieldTwoValue.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.fieldTwoValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldTwoEntry")});
            this.fieldTwoValue.FormattingRules.Add(this.formattingRule2);
            this.fieldTwoValue.LocationFloat = new DevExpress.Utils.PointFloat(165F, 0F);
            this.fieldTwoValue.Name = "fieldTwoValue";
            this.fieldTwoValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldTwoValue.SizeF = new System.Drawing.SizeF(70F, 13F);
            this.fieldTwoValue.StylePriority.UseBorders = false;
            this.fieldTwoValue.StylePriority.UseFont = false;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.fieldThreeValue,
            this.fieldThreeName,
            this.fieldThreeColor});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "xrTableCell3";
            this.xrTableCell3.Weight = 0.99354818954880442D;
            // 
            // fieldThreeName
            // 
            this.fieldThreeName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldThreeName")});
            this.fieldThreeName.Font = new System.Drawing.Font("Arial Narrow", 8.25F);
            this.fieldThreeName.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.fieldThreeName.Name = "fieldThreeName";
            this.fieldThreeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldThreeName.SizeF = new System.Drawing.SizeF(150F, 13F);
            this.fieldThreeName.StylePriority.UseFont = false;
            this.fieldThreeName.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.XrtTableCellOnBeforePrint);
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
            // customFieldOddStyle
            // 
            this.customFieldOddStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.customFieldOddStyle.Name = "customFieldOddStyle";
            // 
            // customFieldEvenStyle
            // 
            this.customFieldEvenStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.customFieldEvenStyle.Name = "customFieldEvenStyle";
            this.customFieldEvenStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // fieldThreeValue
            // 
            this.fieldThreeValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldThreeEntry")});
            this.fieldThreeValue.FormattingRules.Add(this.formattingRule3);
            this.fieldThreeValue.LocationFloat = new DevExpress.Utils.PointFloat(165F, 0F);
            this.fieldThreeValue.Name = "fieldThreeValue";
            this.fieldThreeValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldThreeValue.SizeF = new System.Drawing.SizeF(70F, 13F);
            this.fieldThreeValue.StylePriority.UseFont = false;
            // 
            // fieldOneColor
            // 
            this.fieldOneColor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldOneEntryColor")});
            this.fieldOneColor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.fieldOneColor.Name = "fieldOneColor";
            this.fieldOneColor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldOneColor.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.fieldOneColor.Visible = false;
            // 
            // fieldTwoColor
            // 
            this.fieldTwoColor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldTwoEntryColor")});
            this.fieldTwoColor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.fieldTwoColor.Name = "fieldTwoColor";
            this.fieldTwoColor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldTwoColor.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.fieldTwoColor.Visible = false;
            // 
            // fieldThreeColor
            // 
            this.fieldThreeColor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FieldThreeEntryColor")});
            this.fieldThreeColor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.fieldThreeColor.Name = "fieldThreeColor";
            this.fieldThreeColor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldThreeColor.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.fieldThreeColor.Visible = false;
            // 
            // formattingRule1
            // 
            this.formattingRule1.Condition = "[FieldOneEntryColor] ==  \'R\'";
            // 
            // 
            // 
            this.formattingRule1.Formatting.ForeColor = System.Drawing.Color.Red;
            this.formattingRule1.Name = "formattingRule1";
            // 
            // customFieldsReportAdapter
            // 
            this.customFieldsReportAdapter.DataSource = typeof(Com.Suncor.Olt.Reports.Adapters.CustomFieldsReportAdapter);
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
            this.BottomMargin});
            this.DataSource = this.customFieldsReportAdapter;
            this.Font = new System.Drawing.Font("Arial Narrow", 8.25F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1,
            this.formattingRule2,
            this.formattingRule3});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageWidth = 770;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportPrintOptions.PrintOnEmptyDataSource = false;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.customFieldOddStyle,
            this.customFieldEvenStyle});
            this.Version = "13.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.XrtTableCellOnBeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
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
        private DevExpress.XtraReports.UI.XRControlStyle customFieldOddStyle;
        private DevExpress.XtraReports.UI.XRControlStyle customFieldEvenStyle;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRLabel fieldThreeValue;
        private DevExpress.XtraReports.UI.XRLabel fieldTwoColor;
        private DevExpress.XtraReports.UI.XRLabel fieldOneColor;
        private DevExpress.XtraReports.UI.XRLabel fieldThreeColor;
        private DevExpress.XtraReports.UI.FormattingRule formattingRule1;
        private DevExpress.XtraReports.UI.FormattingRule formattingRule2;
        private DevExpress.XtraReports.UI.FormattingRule formattingRule3;

    }
}
