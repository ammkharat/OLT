using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Reports.SubReports.ShiftHandoverQuestionnaire
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
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.logTypeData = new DevExpress.XtraReports.UI.XRLabel();
            this.functionalLocationsData = new DevExpress.XtraReports.UI.XRLabel();
            this.CreatedByUserTable = new DevExpress.XtraReports.UI.XRTable();
            this.CreatedByUserTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.CreatedByUserTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.createdByUserLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.HideCreatedByUser = new DevExpress.XtraReports.UI.FormattingRule();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeaderLogType = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.HideHeader = new DevExpress.XtraReports.UI.FormattingRule();
            this.ShiftHandoverQuestionnaireId = new DevExpress.XtraReports.Parameters.Parameter();
            this.adapter = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedByUserTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText1,
            this.xrLine1,
            this.xrPanel1,
            this.CreatedByUserTable});
            this.Detail.HeightF = 75F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("LogDateTime", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrRichText1
            // 
            this.xrRichText1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Rtf", null, "Comments")});
            this.xrRichText1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(2.141484E-06F, 49.99999F);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
            this.xrRichText1.SizeF = new System.Drawing.SizeF(770F, 16F);
            // 
            // xrLine1
            // 
            this.xrLine1.BorderColor = System.Drawing.Color.Transparent;
            this.xrLine1.ForeColor = System.Drawing.Color.Silver;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 70F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(770F, 5F);
            this.xrLine1.StylePriority.UseBorderColor = false;
            this.xrLine1.StylePriority.UseForeColor = false;
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logTypeData,
            this.functionalLocationsData});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(770F, 23F);
            // 
            // logTypeData
            // 
            this.logTypeData.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LogTime")});
            this.logTypeData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.logTypeData.LocationFloat = new DevExpress.Utils.PointFloat(0F, 3F);
            this.logTypeData.Name = "logTypeData";
            this.logTypeData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.logTypeData.SizeF = new System.Drawing.SizeF(45F, 16F);
            this.logTypeData.StylePriority.UseFont = false;
            this.logTypeData.Text = "logTypeData";
            // 
            // functionalLocationsData
            // 
            this.functionalLocationsData.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LocationText")});
            this.functionalLocationsData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.functionalLocationsData.LocationFloat = new DevExpress.Utils.PointFloat(50F, 2.999999F);
            this.functionalLocationsData.Name = "functionalLocationsData";
            this.functionalLocationsData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.functionalLocationsData.SizeF = new System.Drawing.SizeF(720F, 16F);
            this.functionalLocationsData.StylePriority.UseFont = false;
            this.functionalLocationsData.Text = "functionalLocationsData";
            // 
            // CreatedByUserTable
            // 
            this.CreatedByUserTable.LocationFloat = new DevExpress.Utils.PointFloat(50F, 25F);
            this.CreatedByUserTable.Name = "CreatedByUserTable";
            this.CreatedByUserTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.CreatedByUserTableRow});
            this.CreatedByUserTable.SizeF = new System.Drawing.SizeF(720F, 20F);
            // 
            // CreatedByUserTableRow
            // 
            this.CreatedByUserTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.CreatedByUserTableCell});
            this.CreatedByUserTableRow.FormattingRules.Add(this.HideCreatedByUser);
            this.CreatedByUserTableRow.Name = "CreatedByUserTableRow";
            this.CreatedByUserTableRow.Weight = 1D;
            // 
            // CreatedByUserTableCell
            // 
            this.CreatedByUserTableCell.CanGrow = false;
            this.CreatedByUserTableCell.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.createdByUserLabel});
            this.CreatedByUserTableCell.Name = "CreatedByUserTableCell";
            this.CreatedByUserTableCell.Text = "CreatedByUserTableCell";
            this.CreatedByUserTableCell.Weight = 2.9793103448275864D;
            // 
            // createdByUserLabel
            // 
            this.createdByUserLabel.CanGrow = false;
            this.createdByUserLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CreatedByUser")});
            this.createdByUserLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.createdByUserLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.createdByUserLabel.Name = "createdByUserLabel";
            this.createdByUserLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.createdByUserLabel.SizeF = new System.Drawing.SizeF(720F, 16F);
            this.createdByUserLabel.StylePriority.UseFont = false;
            this.createdByUserLabel.StylePriority.UseTextAlignment = false;
            this.createdByUserLabel.Text = "createdByUserLabel";
            // 
            // HideCreatedByUser
            // 
            this.HideCreatedByUser.Condition = "[SuppressCreatedByUser] == True";
            // 
            // 
            // 
            this.HideCreatedByUser.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.HideCreatedByUser.Name = "HideCreatedByUser";
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
            // GroupHeaderLogType
            // 
            this.GroupHeaderLogType.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLine2});
            this.GroupHeaderLogType.FormattingRules.Add(this.HideHeader);
            this.GroupHeaderLogType.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("LogTypeLabel", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending)});
            this.GroupHeaderLogType.HeightF = 30F;
            this.GroupHeaderLogType.KeepTogether = true;
            this.GroupHeaderLogType.Name = "GroupHeaderLogType";
            // 
            // xrLabel1
            // 
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LogTypeLabel")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(770F, 16F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLine2
            // 
            this.xrLine2.BorderColor = System.Drawing.Color.Transparent;
            this.xrLine2.ForeColor = System.Drawing.Color.Silver;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(770F, 2F);
            this.xrLine2.StylePriority.UseBorderColor = false;
            this.xrLine2.StylePriority.UseForeColor = false;
            // 
            // HideHeader
            // 
            this.HideHeader.Condition = "[SuppressLogTypeLabel] == True";
            // 
            // 
            // 
            this.HideHeader.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.HideHeader.Name = "HideHeader";
            // 
            // ShiftHandoverQuestionnaireId
            // 
            this.ShiftHandoverQuestionnaireId.Description = "Parameter1";
            this.ShiftHandoverQuestionnaireId.Name = "ShiftHandoverQuestionnaireId";
            this.ShiftHandoverQuestionnaireId.Type = typeof(int);
            this.ShiftHandoverQuestionnaireId.ValueInfo = "0";
            this.ShiftHandoverQuestionnaireId.Visible = false;
            // 
            // adapter
            // 
            this.adapter.DataSource = typeof(CommentsReportAdapter);
            // 
            // CommentsSubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeaderLogType});
            this.DataSource = this.adapter;
            this.FilterString = "[ParentId] = ?ShiftHandoverQuestionnaireId";
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.HideHeader,
            this.HideCreatedByUser});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageWidth = 770;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.ShiftHandoverQuestionnaireId});
            this.Version = "12.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedByUserTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private System.Windows.Forms.BindingSource adapter;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderLogType;
        private DevExpress.XtraReports.UI.XRLabel functionalLocationsData;
        private DevExpress.XtraReports.UI.XRLabel logTypeData;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.FormattingRule HideHeader;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRTable CreatedByUserTable;
        private DevExpress.XtraReports.UI.XRTableRow CreatedByUserTableRow;
        private DevExpress.XtraReports.UI.XRTableCell CreatedByUserTableCell;
        private DevExpress.XtraReports.UI.XRLabel createdByUserLabel;
        private DevExpress.XtraReports.UI.FormattingRule HideCreatedByUser;
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        public DevExpress.XtraReports.Parameters.Parameter ShiftHandoverQuestionnaireId;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
    }
}
