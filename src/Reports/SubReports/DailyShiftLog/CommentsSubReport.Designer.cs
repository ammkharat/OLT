using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Reports.SubReports.DailyShiftLog
{
    partial class CommentsSubReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentsSubReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.LoggedDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCustomField = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Shift = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.UnitFLOC1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.FunctionalLocation = new DevExpress.XtraReports.UI.XRLabel();
            this.Text11 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Text14 = new DevExpress.XtraReports.UI.XRLabel();
            this.LoggedByUser1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.ShowWhenOnFirstPage = new DevExpress.XtraReports.UI.FormattingRule();
            this.ShowEnglishLogo = new DevExpress.XtraReports.UI.FormattingRule();
            this.ShowFrenchLogo = new DevExpress.XtraReports.UI.FormattingRule();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageNumber = new DevExpress.XtraReports.Parameters.Parameter();
            this.CustomFieldDetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.fieldOneColor = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldOneValue = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldTwoValue = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldTwoName = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldThreeValue = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldThreeName = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldOneName = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldTwoColor = new DevExpress.XtraReports.UI.XRLabel();
            this.fieldThreeColor = new DevExpress.XtraReports.UI.XRLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.LogId = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrControlStyleCFEven = new DevExpress.XtraReports.UI.XRControlStyle();
            this.xrControlStyleCFOdd = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText2,
            this.Line2,
            this.LoggedDate1,
            this.xrCustomField});
            this.Detail.HeightF = 42.58337F;
            this.Detail.KeepTogether = true;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            // 
            // xrRichText2
            // 
            this.xrRichText2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Rtf", null, "RtfComments")});
            this.xrRichText2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrRichText2.LocationFloat = new DevExpress.Utils.PointFloat(161.46F, 3.000005F);
            this.xrRichText2.Name = "xrRichText2";
            this.xrRichText2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrRichText2.SerializableRtfString = resources.GetString("xrRichText2.SerializableRtfString");
            this.xrRichText2.SizeF = new System.Drawing.SizeF(595F, 12F);
            this.xrRichText2.StylePriority.UsePadding = false;
            // 
            // Line2
            // 
            this.Line2.BackColor = System.Drawing.Color.White;
            this.Line2.BorderColor = System.Drawing.Color.Black;
            this.Line2.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.LocationFloat = new DevExpress.Utils.PointFloat(45F, 19F);
            this.Line2.Name = "Line2";
            this.Line2.SizeF = new System.Drawing.SizeF(725F, 2F);
            // 
            // LoggedDate1
            // 
            this.LoggedDate1.BackColor = System.Drawing.Color.White;
            this.LoggedDate1.BorderColor = System.Drawing.Color.Black;
            this.LoggedDate1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LoggedDate", "{0:MM/dd/yyyy HH:mm}")});
            this.LoggedDate1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.LoggedDate1.ForeColor = System.Drawing.Color.Black;
            this.LoggedDate1.LocationFloat = new DevExpress.Utils.PointFloat(45F, 3F);
            this.LoggedDate1.Name = "LoggedDate1";
            this.LoggedDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.LoggedDate1.SizeF = new System.Drawing.SizeF(116.4583F, 12F);
            this.LoggedDate1.StylePriority.UseFont = false;
            this.LoggedDate1.StylePriority.UsePadding = false;
            this.LoggedDate1.StylePriority.UseTextAlignment = false;
            this.LoggedDate1.Text = "LoggedDate1";
            this.LoggedDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrCustomField
            // 
            this.xrCustomField.BackColor = System.Drawing.Color.Transparent;
            this.xrCustomField.CanGrow = false;
            this.xrCustomField.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CustomFieldLabelText")});
            this.xrCustomField.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrCustomField.LocationFloat = new DevExpress.Utils.PointFloat(44F, 28.58337F);
            this.xrCustomField.Name = "xrCustomField";
            this.xrCustomField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCustomField.SizeF = new System.Drawing.SizeF(711.46F, 14F);
            this.xrCustomField.StylePriority.UseBackColor = false;
            this.xrCustomField.StylePriority.UseFont = false;
            this.xrCustomField.Text = "xrCustomField";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Shift});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("ShiftStartDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("ShiftName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 15F;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Level = 3;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Shift
            // 
            this.Shift.BackColor = System.Drawing.Color.Black;
            this.Shift.BorderColor = System.Drawing.Color.Black;
            this.Shift.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Shift.ForeColor = System.Drawing.Color.White;
            this.Shift.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Shift.Name = "Shift";
            this.Shift.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.Shift.SizeF = new System.Drawing.SizeF(770F, 15F);
            this.Shift.StylePriority.UsePadding = false;
            this.Shift.StylePriority.UseTextAlignment = false;
            this.Shift.Text = "[Label_ShiftDate_Caps]: [ShiftStartDate] [ShiftName]";
            this.Shift.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.UnitFLOC1});
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("FunctionalLocationUnitLevel", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader2.HeightF = 24F;
            this.GroupHeader2.KeepTogether = true;
            this.GroupHeader2.Level = 2;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // UnitFLOC1
            // 
            this.UnitFLOC1.BackColor = System.Drawing.Color.Gray;
            this.UnitFLOC1.BorderColor = System.Drawing.Color.Black;
            this.UnitFLOC1.CanGrow = false;
            this.UnitFLOC1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.UnitFLOC1.ForeColor = System.Drawing.Color.Black;
            this.UnitFLOC1.LocationFloat = new DevExpress.Utils.PointFloat(15F, 0F);
            this.UnitFLOC1.Name = "UnitFLOC1";
            this.UnitFLOC1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.UnitFLOC1.SizeF = new System.Drawing.SizeF(755F, 20F);
            this.UnitFLOC1.StylePriority.UsePadding = false;
            this.UnitFLOC1.StylePriority.UseTextAlignment = false;
            this.UnitFLOC1.Text = "[Label_Unit_Caps]: [FunctionalLocationUnitLevel] ([FunctionalLocationUnitLevelDes" +
    "cription])";
            this.UnitFLOC1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.FunctionalLocation,
            this.Text11});
            this.GroupHeader3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("FunctionalLocationFullHierarchy", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader3.HeightF = 38.04169F;
            this.GroupHeader3.KeepTogether = true;
            this.GroupHeader3.Level = 1;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // FunctionalLocation
            // 
            this.FunctionalLocation.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FunctionalLocations")});
            this.FunctionalLocation.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.FunctionalLocation.LocationFloat = new DevExpress.Utils.PointFloat(30.00018F, 18F);
            this.FunctionalLocation.Multiline = true;
            this.FunctionalLocation.Name = "FunctionalLocation";
            this.FunctionalLocation.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.FunctionalLocation.SizeF = new System.Drawing.SizeF(739.9998F, 16F);
            this.FunctionalLocation.StylePriority.UseFont = false;
            this.FunctionalLocation.StylePriority.UsePadding = false;
            this.FunctionalLocation.Text = "FunctionalLocation";
            // 
            // Text11
            // 
            this.Text11.BackColor = System.Drawing.Color.White;
            this.Text11.BorderColor = System.Drawing.Color.Black;
            this.Text11.CanGrow = false;
            this.Text11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_FunctionalLocation_Caps")});
            this.Text11.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.Text11.ForeColor = System.Drawing.Color.Black;
            this.Text11.LocationFloat = new DevExpress.Utils.PointFloat(30F, 0F);
            this.Text11.Name = "Text11";
            this.Text11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.Text11.SizeF = new System.Drawing.SizeF(739.9998F, 15F);
            this.Text11.StylePriority.UsePadding = false;
            this.Text11.StylePriority.UseTextAlignment = false;
            this.Text11.Text = "Text11";
            this.Text11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Text14,
            this.LoggedByUser1,
            this.Line3});
            this.GroupHeader4.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("LoggedByUser", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader4.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader4.HeightF = 37F;
            this.GroupHeader4.KeepTogether = true;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // Text14
            // 
            this.Text14.BackColor = System.Drawing.Color.White;
            this.Text14.BorderColor = System.Drawing.Color.Black;
            this.Text14.CanGrow = false;
            this.Text14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_LastEditor_Caps")});
            this.Text14.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.Text14.ForeColor = System.Drawing.Color.Black;
            this.Text14.LocationFloat = new DevExpress.Utils.PointFloat(45F, 0F);
            this.Text14.Name = "Text14";
            this.Text14.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.Text14.SizeF = new System.Drawing.SizeF(353F, 14F);
            this.Text14.StylePriority.UsePadding = false;
            this.Text14.Text = "Text14";
            this.Text14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // LoggedByUser1
            // 
            this.LoggedByUser1.BackColor = System.Drawing.Color.White;
            this.LoggedByUser1.BorderColor = System.Drawing.Color.Black;
            this.LoggedByUser1.CanGrow = false;
            this.LoggedByUser1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LoggedByUser")});
            this.LoggedByUser1.Font = new System.Drawing.Font("Arial", 8F);
            this.LoggedByUser1.ForeColor = System.Drawing.Color.Black;
            this.LoggedByUser1.LocationFloat = new DevExpress.Utils.PointFloat(45F, 17.99999F);
            this.LoggedByUser1.Name = "LoggedByUser1";
            this.LoggedByUser1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.LoggedByUser1.SizeF = new System.Drawing.SizeF(724.9999F, 15F);
            this.LoggedByUser1.StylePriority.UsePadding = false;
            this.LoggedByUser1.Text = "LoggedByUser1";
            this.LoggedByUser1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Line3
            // 
            this.Line3.BackColor = System.Drawing.Color.White;
            this.Line3.BorderColor = System.Drawing.Color.Black;
            this.Line3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.LocationFloat = new DevExpress.Utils.PointFloat(45F, 35F);
            this.Line3.Name = "Line3";
            this.Line3.SizeF = new System.Drawing.SizeF(725F, 2F);
            // 
            // ShowWhenOnFirstPage
            // 
            this.ShowWhenOnFirstPage.Name = "ShowWhenOnFirstPage";
            // 
            // ShowEnglishLogo
            // 
            this.ShowEnglishLogo.Condition = "[ShowEnglishLogo] == True";
            this.ShowEnglishLogo.DataMember = "LogShiftEntry";
            this.ShowEnglishLogo.Name = "ShowEnglishLogo";
            // 
            // ShowFrenchLogo
            // 
            this.ShowFrenchLogo.Condition = "[ShowFrenchLogo] ==  True";
            this.ShowFrenchLogo.DataMember = "LogShiftEntry";
            this.ShowFrenchLogo.Name = "ShowFrenchLogo";
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 0F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 7.791901F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // PageNumber
            // 
            this.PageNumber.Description = "Page Number";
            this.PageNumber.Name = "PageNumber";
            this.PageNumber.Type = typeof(int);
            this.PageNumber.ValueInfo = "0";
            this.PageNumber.Visible = false;
            // 
            // CustomFieldDetailReport
            // 
            this.CustomFieldDetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
            this.CustomFieldDetailReport.DataMember = "CustomFieldsReportAdapters";
            this.CustomFieldDetailReport.DataSource = this.bindingSource1;
            this.CustomFieldDetailReport.Level = 0;
            this.CustomFieldDetailReport.Name = "CustomFieldDetailReport";
            this.CustomFieldDetailReport.Scripts.OnBeforePrint = "CustomFieldDetailReport_BeforePrint";
            this.CustomFieldDetailReport.Visible = false;
            this.CustomFieldDetailReport.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.CustomFieldDetailReport_BeforePrint);
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.fieldOneColor,
            this.fieldOneValue,
            this.fieldTwoValue,
            this.fieldTwoName,
            this.fieldThreeValue,
            this.fieldThreeName,
            this.fieldOneName,
            this.fieldTwoColor,
            this.fieldThreeColor});
            this.Detail1.HeightF = 33.41662F;
            this.Detail1.Name = "Detail1";
            // 
            // fieldOneColor
            // 
            this.fieldOneColor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CustomFieldsReportAdapters.FieldOneEntryColor")});
            this.fieldOneColor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldOneColor.LocationFloat = new DevExpress.Utils.PointFloat(43F, 10.00001F);
            this.fieldOneColor.Name = "fieldOneColor";
            this.fieldOneColor.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 0, 0, 0, 100F);
            this.fieldOneColor.SizeF = new System.Drawing.SizeF(155F, 23F);
            this.fieldOneColor.StylePriority.UseFont = false;
            this.fieldOneColor.StylePriority.UsePadding = false;
            this.fieldOneColor.Visible = false;
            // 
            // fieldOneValue
            // 
            this.fieldOneValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CustomFieldsReportAdapters.FieldOneEntry")});
            this.fieldOneValue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldOneValue.LocationFloat = new DevExpress.Utils.PointFloat(204.9166F, 10.00001F);
            this.fieldOneValue.Name = "fieldOneValue";
            this.fieldOneValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldOneValue.SizeF = new System.Drawing.SizeF(70F, 13F);
            this.fieldOneValue.StylePriority.UseFont = false;
            // 
            // fieldTwoValue
            // 
            this.fieldTwoValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CustomFieldsReportAdapters.FieldTwoEntry")});
            this.fieldTwoValue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldTwoValue.LocationFloat = new DevExpress.Utils.PointFloat(442.9166F, 10.00001F);
            this.fieldTwoValue.Name = "fieldTwoValue";
            this.fieldTwoValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldTwoValue.SizeF = new System.Drawing.SizeF(70F, 13F);
            this.fieldTwoValue.StylePriority.UseFont = false;
            // 
            // fieldTwoName
            // 
            this.fieldTwoName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CustomFieldsReportAdapters.FieldTwoName")});
            this.fieldTwoName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldTwoName.LocationFloat = new DevExpress.Utils.PointFloat(282.9166F, 10.00001F);
            this.fieldTwoName.Name = "fieldTwoName";
            this.fieldTwoName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldTwoName.SizeF = new System.Drawing.SizeF(155F, 13F);
            this.fieldTwoName.StylePriority.UseFont = false;
            // 
            // fieldThreeValue
            // 
            this.fieldThreeValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CustomFieldsReportAdapters.FieldThreeEntry")});
            this.fieldThreeValue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldThreeValue.LocationFloat = new DevExpress.Utils.PointFloat(684.3766F, 10.00001F);
            this.fieldThreeValue.Name = "fieldThreeValue";
            this.fieldThreeValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldThreeValue.SizeF = new System.Drawing.SizeF(70F, 13F);
            this.fieldThreeValue.StylePriority.UseFont = false;
            // 
            // fieldThreeName
            // 
            this.fieldThreeName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CustomFieldsReportAdapters.FieldThreeName")});
            this.fieldThreeName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldThreeName.LocationFloat = new DevExpress.Utils.PointFloat(517.9166F, 10.00001F);
            this.fieldThreeName.Name = "fieldThreeName";
            this.fieldThreeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldThreeName.SizeF = new System.Drawing.SizeF(160F, 13F);
            this.fieldThreeName.StylePriority.UseFont = false;
            // 
            // fieldOneName
            // 
            this.fieldOneName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CustomFieldsReportAdapters.FieldOneName")});
            this.fieldOneName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldOneName.LocationFloat = new DevExpress.Utils.PointFloat(43F, 10.00001F);
            this.fieldOneName.Name = "fieldOneName";
            this.fieldOneName.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 0, 0, 0, 100F);
            this.fieldOneName.SizeF = new System.Drawing.SizeF(155F, 13F);
            this.fieldOneName.StylePriority.UseFont = false;
            this.fieldOneName.StylePriority.UsePadding = false;
            // 
            // fieldTwoColor
            // 
            this.fieldTwoColor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CustomFieldsReportAdapters.FieldTwoEntryColor")});
            this.fieldTwoColor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldTwoColor.LocationFloat = new DevExpress.Utils.PointFloat(282.9166F, 10.00001F);
            this.fieldTwoColor.Name = "fieldTwoColor";
            this.fieldTwoColor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldTwoColor.SizeF = new System.Drawing.SizeF(155F, 23F);
            this.fieldTwoColor.StylePriority.UseFont = false;
            this.fieldTwoColor.Visible = false;
            // 
            // fieldThreeColor
            // 
            this.fieldThreeColor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CustomFieldsReportAdapters.FieldThreeEntryColor")});
            this.fieldThreeColor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldThreeColor.LocationFloat = new DevExpress.Utils.PointFloat(517.9166F, 10.00001F);
            this.fieldThreeColor.Name = "fieldThreeColor";
            this.fieldThreeColor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldThreeColor.SizeF = new System.Drawing.SizeF(155.0001F, 23F);
            this.fieldThreeColor.StylePriority.UseFont = false;
            this.fieldThreeColor.Visible = false;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Com.Suncor.Olt.Reports.Adapters.DailyShiftLogCommentsReportAdapter);
            // 
            // LogId
            // 
            this.LogId.Description = "LogId";
            this.LogId.Name = "LogId";
            this.LogId.Type = typeof(int);
            this.LogId.ValueInfo = "0";
            this.LogId.Visible = false;
            // 
            // xrControlStyleCFEven
            // 
            this.xrControlStyleCFEven.BackColor = System.Drawing.Color.Gainsboro;
            this.xrControlStyleCFEven.Name = "xrControlStyleCFEven";
            this.xrControlStyleCFEven.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // xrControlStyleCFOdd
            // 
            this.xrControlStyleCFOdd.BackColor = System.Drawing.Color.LightGray;
            this.xrControlStyleCFOdd.Name = "xrControlStyleCFOdd";
            this.xrControlStyleCFOdd.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // CommentsSubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupHeader4,
            this.topMarginBand1,
            this.bottomMarginBand1,
            this.CustomFieldDetailReport});
            this.DataSource = this.bindingSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.ShowEnglishLogo,
            this.ShowFrenchLogo,
            this.ShowWhenOnFirstPage});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 8);
            this.PageHeight = 1098;
            this.PageWidth = 770;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.PageNumber,
            this.LogId});
            this.ReportPrintOptions.PrintOnEmptyDataSource = false;
            this.ScriptsSource = "\r\nprivate void xrSubreport1_PrintOnPage(object sender, DevExpress.XtraReports.UI." +
    "PrintOnPageEventArgs e) {\r\n\tif (e.PageCount > 0) \r\n\t{\r\n\t\tif (e.PageIndex == 0)\r\n" +
    "\t\t{\r\n\t\t\te.Cancel = true;\r\n\t\t}\r\n\t}\r\n}\r\n";
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyleCFEven,
            this.xrControlStyleCFOdd});
            this.Version = "13.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel LoggedDate1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel Shift;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.XRLabel UnitFLOC1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3;
        private DevExpress.XtraReports.UI.XRLabel Text11;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader4;
        private DevExpress.XtraReports.UI.XRLabel Text14;
        private DevExpress.XtraReports.UI.XRLabel LoggedByUser1;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.FormattingRule ShowEnglishLogo;
        private DevExpress.XtraReports.UI.FormattingRule ShowFrenchLogo;
        private DevExpress.XtraReports.UI.FormattingRule ShowWhenOnFirstPage;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraReports.UI.XRRichText xrRichText2;
        private DevExpress.XtraReports.UI.DetailReportBand CustomFieldDetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.XRLabel fieldOneColor;
        private DevExpress.XtraReports.UI.XRLabel fieldOneValue;
        private DevExpress.XtraReports.UI.XRLabel fieldTwoValue;
        private DevExpress.XtraReports.UI.XRLabel fieldTwoName;
        private DevExpress.XtraReports.UI.XRLabel fieldThreeValue;
        private DevExpress.XtraReports.UI.XRLabel fieldThreeName;
        private DevExpress.XtraReports.UI.XRLabel fieldOneName;
        private DevExpress.XtraReports.UI.XRLabel fieldTwoColor;
        private DevExpress.XtraReports.UI.XRLabel fieldThreeColor;
        public DevExpress.XtraReports.Parameters.Parameter PageNumber;
        private DevExpress.XtraReports.UI.XRLabel xrCustomField;
        public DevExpress.XtraReports.Parameters.Parameter LogId;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyleCFEven;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyleCFOdd;
        private DevExpress.XtraReports.UI.XRLabel FunctionalLocation;

    }
}
