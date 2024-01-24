using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.SubReports.GenericSingleLog;
using FunctionalLocationSubReport = Com.Suncor.Olt.Reports.SubReports.GenericSingleLog.FunctionalLocationSubReport;

namespace Com.Suncor.Olt.Reports
{
    partial class RtfGenericSingleLogReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RtfGenericSingleLogReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabelImage = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableImage = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.markedAsReadByTable = new DevExpress.XtraReports.UI.XRTable();
            this.markedAsReadByTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.markedAsReadByTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.markedAsReadByHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.HideMarkedAsReadBy = new DevExpress.XtraReports.UI.FormattingRule();
            this.modificationsTable = new DevExpress.XtraReports.UI.XRTable();
            this.modificationsTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.modificationsTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.lastModificationsHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.documentLinksTable = new DevExpress.XtraReports.UI.XRTable();
            this.documentLinksTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.documentLinksTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.DocumentLinksHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.HideDocumentLinks = new DevExpress.XtraReports.UI.FormattingRule();
            this.dorCommentsTable = new DevExpress.XtraReports.UI.XRTable();
            this.dorCommentsTableHeaderRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.dorCommentsTableHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.DorCommentsHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.HideDORComments = new DevExpress.XtraReports.UI.FormattingRule();
            this.dorCommentsContentsTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.dorCommentsContentsTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.DorComments = new DevExpress.XtraReports.UI.XRLabel();
            this.commentHeaderTable = new DevExpress.XtraReports.UI.XRTable();
            this.commentTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.commentsTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.RtfCommentsHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.customFieldsHeaderTable = new DevExpress.XtraReports.UI.XRTable();
            this.customFieldsTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.customFieldsTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.CustomFieldHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.HideCustomFields = new DevExpress.XtraReports.UI.FormattingRule();
            this.optionsTable = new DevExpress.XtraReports.UI.XRTable();
            this.optionsTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.optionsTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.LabelOptions = new DevExpress.XtraReports.UI.XRLabel();
            this.recommendForSummaryCheckBox = new DevExpress.XtraReports.UI.XRCheckBox();
            this.HideOptions = new DevExpress.XtraReports.UI.FormattingRule();
            this.followupTable = new DevExpress.XtraReports.UI.XRTable();
            this.followupTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.followupTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.LabelFollowup = new DevExpress.XtraReports.UI.XRLabel();
            this.followupCheckboxTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ehsCheckBox = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.processControlCheckBox = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.operationsCheckBox = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.inspectionCheckBox = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.supervisionCheckBox = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.otherCheckBox = new DevExpress.XtraReports.UI.XRCheckBox();
            this.HideFollowup = new DevExpress.XtraReports.UI.FormattingRule();
            this.functionalLocationPushdownPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.Shift = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelShift = new DevExpress.XtraReports.UI.XRLabel();
            this.WorkAssignment = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelAssignment = new DevExpress.XtraReports.UI.XRLabel();
            this.LastModifiedByName = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelEditedBy = new DevExpress.XtraReports.UI.XRLabel();
            this.labelLogDateTime = new DevExpress.XtraReports.UI.XRLabel();
            this.ActualLoggedDateTime = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelFunctionalLocation = new DevExpress.XtraReports.UI.XRLabel();
            this.HideReferencedLogs = new DevExpress.XtraReports.UI.FormattingRule();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Logo_English = new DevExpress.XtraReports.UI.XRPictureBox();
            this.IsNotEnglish = new DevExpress.XtraReports.UI.FormattingRule();
            this.headerLine = new DevExpress.XtraReports.UI.XRLine();
            this.reportTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.Logo_French = new DevExpress.XtraReports.UI.XRPictureBox();
            this.IsNotFrench = new DevExpress.XtraReports.UI.FormattingRule();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.pageNumberLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.printedDateTimeLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.printDateTime = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.markedAsReadBySubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.lastModificationsSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.documentLinksSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.customFieldsSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.flocSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.genericsinglelogreportadapter = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrTableImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markedAsReadByTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modificationsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentLinksTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dorCommentsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentHeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customFieldsHeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.followupTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.followupCheckboxTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genericsinglelogreportadapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabelImage,
            this.xrTableImage,
            this.markedAsReadBySubreport,
            this.markedAsReadByTable,
            this.lastModificationsSubreport,
            this.modificationsTable,
            this.documentLinksSubreport,
            this.documentLinksTable,
            this.dorCommentsTable,
            this.commentHeaderTable,
            this.customFieldsHeaderTable,
            this.customFieldsSubreport,
            this.optionsTable,
            this.followupTable,
            this.functionalLocationPushdownPanel,
            this.xrRichText1,
            this.Shift,
            this.LabelShift,
            this.WorkAssignment,
            this.LabelAssignment,
            this.LastModifiedByName,
            this.LabelEditedBy,
            this.labelLogDateTime,
            this.ActualLoggedDateTime,
            this.LabelFunctionalLocation,
            this.flocSubreport});
            this.Detail.HeightF = 736.6095F;
            this.Detail.Name = "Detail";
            // 
            // xrLabelImage
            // 
            this.xrLabelImage.BackColor = System.Drawing.Color.Silver;
            this.xrLabelImage.BorderColor = System.Drawing.Color.Silver;
            this.xrLabelImage.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabelImage.CanGrow = false;
            this.xrLabelImage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabelImage.ForeColor = System.Drawing.Color.Black;
            this.xrLabelImage.LocationFloat = new DevExpress.Utils.PointFloat(0F, 627.9429F);
            this.xrLabelImage.Name = "xrLabelImage";
            this.xrLabelImage.SizeF = new System.Drawing.SizeF(770F, 17F);
            this.xrLabelImage.StylePriority.UseFont = false;
            this.xrLabelImage.Text = "[Label_MarkedAsReadBy]";
            this.xrLabelImage.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableImage
            // 
            this.xrTableImage.BackColor = System.Drawing.Color.Gainsboro;
            this.xrTableImage.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableImage.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 684.8596F);
            this.xrTableImage.Name = "xrTableImage";
            this.xrTableImage.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTableImage.SizeF = new System.Drawing.SizeF(766.9999F, 25F);
            this.xrTableImage.StylePriority.UseBackColor = false;
            this.xrTableImage.StylePriority.UseBorders = false;
            this.xrTableImage.StylePriority.UseTextAlignment = false;
            this.xrTableImage.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Location";
            this.xrTableCell7.Weight = 1.248333299049134D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Description";
            this.xrTableCell8.Weight = 2.0916671666722237D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Photo";
            this.xrTableCell9.Weight = 4.3299989239270795D;
            // 
            // markedAsReadByTable
            // 
            this.markedAsReadByTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 548.9999F);
            this.markedAsReadByTable.Name = "markedAsReadByTable";
            this.markedAsReadByTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.markedAsReadByTableRow});
            this.markedAsReadByTable.SizeF = new System.Drawing.SizeF(770F, 34F);
            // 
            // markedAsReadByTableRow
            // 
            this.markedAsReadByTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.markedAsReadByTableCell});
            this.markedAsReadByTableRow.FormattingRules.Add(this.HideMarkedAsReadBy);
            this.markedAsReadByTableRow.Name = "markedAsReadByTableRow";
            this.markedAsReadByTableRow.Weight = 1D;
            // 
            // markedAsReadByTableCell
            // 
            this.markedAsReadByTableCell.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.markedAsReadByHeader});
            this.markedAsReadByTableCell.Name = "markedAsReadByTableCell";
            this.markedAsReadByTableCell.Weight = 3D;
            // 
            // markedAsReadByHeader
            // 
            this.markedAsReadByHeader.BackColor = System.Drawing.Color.Silver;
            this.markedAsReadByHeader.BorderColor = System.Drawing.Color.Silver;
            this.markedAsReadByHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.markedAsReadByHeader.CanGrow = false;
            this.markedAsReadByHeader.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.markedAsReadByHeader.ForeColor = System.Drawing.Color.Black;
            this.markedAsReadByHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8.5F);
            this.markedAsReadByHeader.Name = "markedAsReadByHeader";
            this.markedAsReadByHeader.SizeF = new System.Drawing.SizeF(770F, 17F);
            this.markedAsReadByHeader.StylePriority.UseFont = false;
            this.markedAsReadByHeader.Text = "[Label_MarkedAsReadBy]";
            this.markedAsReadByHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // HideMarkedAsReadBy
            // 
            this.HideMarkedAsReadBy.Condition = "[ShowMarkedAsReadBy] == False";
            // 
            // 
            // 
            this.HideMarkedAsReadBy.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.HideMarkedAsReadBy.Name = "HideMarkedAsReadBy";
            // 
            // modificationsTable
            // 
            this.modificationsTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 477F);
            this.modificationsTable.Name = "modificationsTable";
            this.modificationsTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.modificationsTableRow});
            this.modificationsTable.SizeF = new System.Drawing.SizeF(770F, 34F);
            // 
            // modificationsTableRow
            // 
            this.modificationsTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.modificationsTableCell});
            this.modificationsTableRow.Name = "modificationsTableRow";
            this.modificationsTableRow.Weight = 1D;
            // 
            // modificationsTableCell
            // 
            this.modificationsTableCell.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lastModificationsHeader});
            this.modificationsTableCell.Name = "modificationsTableCell";
            this.modificationsTableCell.Weight = 3D;
            // 
            // lastModificationsHeader
            // 
            this.lastModificationsHeader.BackColor = System.Drawing.Color.Silver;
            this.lastModificationsHeader.BorderColor = System.Drawing.Color.Silver;
            this.lastModificationsHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lastModificationsHeader.CanGrow = false;
            this.lastModificationsHeader.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lastModificationsHeader.ForeColor = System.Drawing.Color.Black;
            this.lastModificationsHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8.5F);
            this.lastModificationsHeader.Name = "lastModificationsHeader";
            this.lastModificationsHeader.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink;
            this.lastModificationsHeader.SizeF = new System.Drawing.SizeF(770F, 17F);
            this.lastModificationsHeader.StylePriority.UseFont = false;
            this.lastModificationsHeader.Text = "[Label_Last5Modifications]";
            this.lastModificationsHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // documentLinksTable
            // 
            this.documentLinksTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 333F);
            this.documentLinksTable.Name = "documentLinksTable";
            this.documentLinksTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.documentLinksTableRow});
            this.documentLinksTable.SizeF = new System.Drawing.SizeF(770F, 34F);
            // 
            // documentLinksTableRow
            // 
            this.documentLinksTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.documentLinksTableCell});
            this.documentLinksTableRow.FormattingRules.Add(this.HideDocumentLinks);
            this.documentLinksTableRow.Name = "documentLinksTableRow";
            this.documentLinksTableRow.Weight = 1D;
            // 
            // documentLinksTableCell
            // 
            this.documentLinksTableCell.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DocumentLinksHeader});
            this.documentLinksTableCell.Name = "documentLinksTableCell";
            this.documentLinksTableCell.Weight = 3D;
            // 
            // DocumentLinksHeader
            // 
            this.DocumentLinksHeader.BackColor = System.Drawing.Color.Silver;
            this.DocumentLinksHeader.BorderColor = System.Drawing.Color.Silver;
            this.DocumentLinksHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.DocumentLinksHeader.CanGrow = false;
            this.DocumentLinksHeader.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.DocumentLinksHeader.ForeColor = System.Drawing.Color.Black;
            this.DocumentLinksHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8.5F);
            this.DocumentLinksHeader.Name = "DocumentLinksHeader";
            this.DocumentLinksHeader.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink;
            this.DocumentLinksHeader.SizeF = new System.Drawing.SizeF(770F, 17F);
            this.DocumentLinksHeader.StylePriority.UseFont = false;
            this.DocumentLinksHeader.Text = "[Label_DocumentLinks]";
            this.DocumentLinksHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // HideDocumentLinks
            // 
            this.HideDocumentLinks.Condition = "[ShowDocumentLinks] ==  False";
            // 
            // 
            // 
            this.HideDocumentLinks.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.HideDocumentLinks.Name = "HideDocumentLinks";
            // 
            // dorCommentsTable
            // 
            this.dorCommentsTable.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 282F);
            this.dorCommentsTable.Name = "dorCommentsTable";
            this.dorCommentsTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.dorCommentsTableHeaderRow,
            this.dorCommentsContentsTableRow});
            this.dorCommentsTable.SizeF = new System.Drawing.SizeF(770F, 51F);
            // 
            // dorCommentsTableHeaderRow
            // 
            this.dorCommentsTableHeaderRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.dorCommentsTableHeaderCell});
            this.dorCommentsTableHeaderRow.FormattingRules.Add(this.HideDORComments);
            this.dorCommentsTableHeaderRow.Name = "dorCommentsTableHeaderRow";
            this.dorCommentsTableHeaderRow.Weight = 1D;
            // 
            // dorCommentsTableHeaderCell
            // 
            this.dorCommentsTableHeaderCell.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DorCommentsHeader});
            this.dorCommentsTableHeaderCell.Name = "dorCommentsTableHeaderCell";
            this.dorCommentsTableHeaderCell.Weight = 3D;
            // 
            // DorCommentsHeader
            // 
            this.DorCommentsHeader.BackColor = System.Drawing.Color.Silver;
            this.DorCommentsHeader.BorderColor = System.Drawing.Color.Silver;
            this.DorCommentsHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.DorCommentsHeader.CanGrow = false;
            this.DorCommentsHeader.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.DorCommentsHeader.ForeColor = System.Drawing.Color.Black;
            this.DorCommentsHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8.5F);
            this.DorCommentsHeader.Name = "DorCommentsHeader";
            this.DorCommentsHeader.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink;
            this.DorCommentsHeader.SizeF = new System.Drawing.SizeF(770F, 17F);
            this.DorCommentsHeader.Text = "[Label_DORComments]";
            this.DorCommentsHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // HideDORComments
            // 
            this.HideDORComments.Condition = "[ShowDorComments] == False";
            // 
            // 
            // 
            this.HideDORComments.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.HideDORComments.Name = "HideDORComments";
            // 
            // dorCommentsContentsTableRow
            // 
            this.dorCommentsContentsTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.dorCommentsContentsTableCell});
            this.dorCommentsContentsTableRow.FormattingRules.Add(this.HideDORComments);
            this.dorCommentsContentsTableRow.KeepTogether = false;
            this.dorCommentsContentsTableRow.Name = "dorCommentsContentsTableRow";
            this.dorCommentsContentsTableRow.Weight = 0.5D;
            // 
            // dorCommentsContentsTableCell
            // 
            this.dorCommentsContentsTableCell.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DorComments});
            this.dorCommentsContentsTableCell.Name = "dorCommentsContentsTableCell";
            this.dorCommentsContentsTableCell.Text = "dorCommentsContentsTableCell";
            this.dorCommentsContentsTableCell.Weight = 3D;
            // 
            // DorComments
            // 
            this.DorComments.BackColor = System.Drawing.Color.White;
            this.DorComments.BorderColor = System.Drawing.Color.Black;
            this.DorComments.ForeColor = System.Drawing.Color.Black;
            this.DorComments.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.DorComments.Multiline = true;
            this.DorComments.Name = "DorComments";
            this.DorComments.SizeF = new System.Drawing.SizeF(770F, 16F);
            this.DorComments.StylePriority.UseFont = false;
            this.DorComments.Text = "[DorComments]";
            this.DorComments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // commentHeaderTable
            // 
            this.commentHeaderTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 232F);
            this.commentHeaderTable.Name = "commentHeaderTable";
            this.commentHeaderTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.commentTableRow});
            this.commentHeaderTable.SizeF = new System.Drawing.SizeF(770F, 34F);
            // 
            // commentTableRow
            // 
            this.commentTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.commentsTableCell});
            this.commentTableRow.Name = "commentTableRow";
            this.commentTableRow.Weight = 1D;
            // 
            // commentsTableCell
            // 
            this.commentsTableCell.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.RtfCommentsHeader});
            this.commentsTableCell.Name = "commentsTableCell";
            this.commentsTableCell.Text = "commentsTableCell";
            this.commentsTableCell.Weight = 3D;
            // 
            // RtfCommentsHeader
            // 
            this.RtfCommentsHeader.BackColor = System.Drawing.Color.Silver;
            this.RtfCommentsHeader.BorderColor = System.Drawing.Color.Silver;
            this.RtfCommentsHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.RtfCommentsHeader.CanGrow = false;
            this.RtfCommentsHeader.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.RtfCommentsHeader.ForeColor = System.Drawing.Color.Black;
            this.RtfCommentsHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8.5F);
            this.RtfCommentsHeader.Name = "RtfCommentsHeader";
            this.RtfCommentsHeader.SizeF = new System.Drawing.SizeF(770F, 17F);
            this.RtfCommentsHeader.StylePriority.UseFont = false;
            this.RtfCommentsHeader.Text = "[Label_Comments]";
            this.RtfCommentsHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // customFieldsHeaderTable
            // 
            this.customFieldsHeaderTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 160F);
            this.customFieldsHeaderTable.Name = "customFieldsHeaderTable";
            this.customFieldsHeaderTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.customFieldsTableRow});
            this.customFieldsHeaderTable.SizeF = new System.Drawing.SizeF(770F, 34F);
            // 
            // customFieldsTableRow
            // 
            this.customFieldsTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.customFieldsTableCell});
            this.customFieldsTableRow.FormattingRules.Add(this.HideCustomFields);
            this.customFieldsTableRow.Name = "customFieldsTableRow";
            this.customFieldsTableRow.Weight = 1D;
            // 
            // customFieldsTableCell
            // 
            this.customFieldsTableCell.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CustomFieldHeader});
            this.customFieldsTableCell.Name = "customFieldsTableCell";
            this.customFieldsTableCell.Weight = 3D;
            // 
            // CustomFieldHeader
            // 
            this.CustomFieldHeader.BackColor = System.Drawing.Color.Silver;
            this.CustomFieldHeader.BorderColor = System.Drawing.Color.Silver;
            this.CustomFieldHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.CustomFieldHeader.CanGrow = false;
            this.CustomFieldHeader.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CustomFieldHeader.ForeColor = System.Drawing.Color.Black;
            this.CustomFieldHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8.5F);
            this.CustomFieldHeader.Name = "CustomFieldHeader";
            this.CustomFieldHeader.SizeF = new System.Drawing.SizeF(770F, 17F);
            this.CustomFieldHeader.StylePriority.UseFont = false;
            this.CustomFieldHeader.Text = "[Label_CustomFields]";
            this.CustomFieldHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // HideCustomFields
            // 
            this.HideCustomFields.Condition = "[ShowCustomFields] == False";
            // 
            // 
            // 
            this.HideCustomFields.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.HideCustomFields.Name = "HideCustomFields";
            // 
            // optionsTable
            // 
            this.optionsTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 140F);
            this.optionsTable.Name = "optionsTable";
            this.optionsTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.optionsTableRow});
            this.optionsTable.SizeF = new System.Drawing.SizeF(770F, 20F);
            // 
            // optionsTableRow
            // 
            this.optionsTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.optionsTableCell});
            this.optionsTableRow.FormattingRules.Add(this.HideOptions);
            this.optionsTableRow.Name = "optionsTableRow";
            this.optionsTableRow.Weight = 1D;
            // 
            // optionsTableCell
            // 
            this.optionsTableCell.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.LabelOptions,
            this.recommendForSummaryCheckBox});
            this.optionsTableCell.Name = "optionsTableCell";
            this.optionsTableCell.Weight = 3D;
            // 
            // LabelOptions
            // 
            this.LabelOptions.BackColor = System.Drawing.Color.White;
            this.LabelOptions.BorderColor = System.Drawing.Color.Black;
            this.LabelOptions.CanGrow = false;
            this.LabelOptions.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.LabelOptions.ForeColor = System.Drawing.Color.Black;
            this.LabelOptions.LocationFloat = new DevExpress.Utils.PointFloat(0F, 3F);
            this.LabelOptions.Name = "LabelOptions";
            this.LabelOptions.SizeF = new System.Drawing.SizeF(150F, 16F);
            this.LabelOptions.StylePriority.UseFont = false;
            this.LabelOptions.Text = "[Label_Options]:";
            this.LabelOptions.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // recommendForSummaryCheckBox
            // 
            this.recommendForSummaryCheckBox.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_RecommendedForSummary"),
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "RecommendForSummary")});
            this.recommendForSummaryCheckBox.LocationFloat = new DevExpress.Utils.PointFloat(155F, 3F);
            this.recommendForSummaryCheckBox.Name = "recommendForSummaryCheckBox";
            this.recommendForSummaryCheckBox.SizeF = new System.Drawing.SizeF(518F, 16F);
            this.recommendForSummaryCheckBox.StylePriority.UseTextAlignment = false;
            this.recommendForSummaryCheckBox.Text = "recommendForSummaryCheckBox";
            // 
            // HideOptions
            // 
            this.HideOptions.Condition = "[ShowRecommendedForSummary] ==  False";
            // 
            // 
            // 
            this.HideOptions.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.HideOptions.Name = "HideOptions";
            // 
            // followupTable
            // 
            this.followupTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.followupTable.Name = "followupTable";
            this.followupTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.followupTableRow});
            this.followupTable.SizeF = new System.Drawing.SizeF(770F, 40F);
            // 
            // followupTableRow
            // 
            this.followupTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.followupTableCell});
            this.followupTableRow.FormattingRules.Add(this.HideFollowup);
            this.followupTableRow.Name = "followupTableRow";
            this.followupTableRow.Weight = 1D;
            // 
            // followupTableCell
            // 
            this.followupTableCell.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.LabelFollowup,
            this.followupCheckboxTable});
            this.followupTableCell.Name = "followupTableCell";
            this.followupTableCell.Weight = 7.75D;
            // 
            // LabelFollowup
            // 
            this.LabelFollowup.BackColor = System.Drawing.Color.White;
            this.LabelFollowup.BorderColor = System.Drawing.Color.Black;
            this.LabelFollowup.CanGrow = false;
            this.LabelFollowup.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.LabelFollowup.ForeColor = System.Drawing.Color.Black;
            this.LabelFollowup.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.LabelFollowup.Name = "LabelFollowup";
            this.LabelFollowup.SizeF = new System.Drawing.SizeF(150F, 16F);
            this.LabelFollowup.StylePriority.UseFont = false;
            this.LabelFollowup.Text = "[Label_Followup]:";
            this.LabelFollowup.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // followupCheckboxTable
            // 
            this.followupCheckboxTable.LocationFloat = new DevExpress.Utils.PointFloat(155F, 0F);
            this.followupCheckboxTable.Name = "followupCheckboxTable";
            this.followupCheckboxTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2});
            this.followupCheckboxTable.SizeF = new System.Drawing.SizeF(538F, 40F);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ehsCheckBox});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Weight = 1.7899999999999998D;
            // 
            // ehsCheckBox
            // 
            this.ehsCheckBox.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "EnvironmentalHealthSafetyFollowUp"),
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_EHS")});
            this.ehsCheckBox.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.ehsCheckBox.Name = "ehsCheckBox";
            this.ehsCheckBox.SizeF = new System.Drawing.SizeF(159F, 16F);
            this.ehsCheckBox.StylePriority.UseTextAlignment = false;
            this.ehsCheckBox.Text = "ehsCheckBox";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.processControlCheckBox});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.Weight = 1.7900000000000005D;
            // 
            // processControlCheckBox
            // 
            this.processControlCheckBox.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_ProcessControl"),
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "ProcessControlFollowUp")});
            this.processControlCheckBox.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.processControlCheckBox.Name = "processControlCheckBox";
            this.processControlCheckBox.SizeF = new System.Drawing.SizeF(156F, 16F);
            this.processControlCheckBox.StylePriority.UseTextAlignment = false;
            this.processControlCheckBox.Text = "processControlCheckBox";
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.operationsCheckBox});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "xrTableCell3";
            this.xrTableCell3.Weight = 1.8000000000000003D;
            // 
            // operationsCheckBox
            // 
            this.operationsCheckBox.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "OperationsFollowUp"),
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_Operations")});
            this.operationsCheckBox.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.operationsCheckBox.Name = "operationsCheckBox";
            this.operationsCheckBox.SizeF = new System.Drawing.SizeF(159.9999F, 16F);
            this.operationsCheckBox.StylePriority.UseTextAlignment = false;
            this.operationsCheckBox.Text = "operationsCheckBox";
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell6,
            this.xrTableCell5});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.inspectionCheckBox});
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Weight = 1.7899999999999998D;
            // 
            // inspectionCheckBox
            // 
            this.inspectionCheckBox.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "InspectionFollowUp"),
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_Inspection")});
            this.inspectionCheckBox.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.inspectionCheckBox.Name = "inspectionCheckBox";
            this.inspectionCheckBox.SizeF = new System.Drawing.SizeF(159F, 15.99999F);
            this.inspectionCheckBox.StylePriority.UseTextAlignment = false;
            this.inspectionCheckBox.Text = "inspectionCheckBox";
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.supervisionCheckBox});
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Weight = 1.7950000000000004D;
            // 
            // supervisionCheckBox
            // 
            this.supervisionCheckBox.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "SupervisionFollowUp"),
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_Supervision")});
            this.supervisionCheckBox.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.supervisionCheckBox.Name = "supervisionCheckBox";
            this.supervisionCheckBox.SizeF = new System.Drawing.SizeF(156F, 16.00001F);
            this.supervisionCheckBox.StylePriority.UseTextAlignment = false;
            this.supervisionCheckBox.Text = "supervisionCheckBox";
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.otherCheckBox});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.Weight = 1.7950000000000004D;
            // 
            // otherCheckBox
            // 
            this.otherCheckBox.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "OtherFollowUp"),
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_OtherSeeComments")});
            this.otherCheckBox.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.otherCheckBox.Name = "otherCheckBox";
            this.otherCheckBox.SizeF = new System.Drawing.SizeF(159.9999F, 16.00001F);
            this.otherCheckBox.StylePriority.UseTextAlignment = false;
            this.otherCheckBox.Text = "otherCheckBox";
            // 
            // HideFollowup
            // 
            this.HideFollowup.Condition = "[ShowFollowup] == False";
            // 
            // 
            // 
            this.HideFollowup.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.HideFollowup.Name = "HideFollowup";
            // 
            // functionalLocationPushdownPanel
            // 
            this.functionalLocationPushdownPanel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 97F);
            this.functionalLocationPushdownPanel.Name = "functionalLocationPushdownPanel";
            this.functionalLocationPushdownPanel.SizeF = new System.Drawing.SizeF(770F, 2F);
            // 
            // xrRichText1
            // 
            this.xrRichText1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Rtf", null, "CommentsAsRtfText")});
            this.xrRichText1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 266F);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
            this.xrRichText1.SizeF = new System.Drawing.SizeF(770F, 16F);
            this.xrRichText1.StylePriority.UseFont = false;
            // 
            // Shift
            // 
            this.Shift.BackColor = System.Drawing.Color.White;
            this.Shift.BorderColor = System.Drawing.Color.Black;
            this.Shift.CanGrow = false;
            this.Shift.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Shift")});
            this.Shift.ForeColor = System.Drawing.Color.Black;
            this.Shift.LocationFloat = new DevExpress.Utils.PointFloat(155F, 20F);
            this.Shift.Name = "Shift";
            this.Shift.SizeF = new System.Drawing.SizeF(549F, 16F);
            this.Shift.StylePriority.UseFont = false;
            this.Shift.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // LabelShift
            // 
            this.LabelShift.BackColor = System.Drawing.Color.White;
            this.LabelShift.BorderColor = System.Drawing.Color.Black;
            this.LabelShift.CanGrow = false;
            this.LabelShift.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.LabelShift.ForeColor = System.Drawing.Color.Black;
            this.LabelShift.LocationFloat = new DevExpress.Utils.PointFloat(0F, 20F);
            this.LabelShift.Name = "LabelShift";
            this.LabelShift.SizeF = new System.Drawing.SizeF(150F, 16F);
            this.LabelShift.StylePriority.UseFont = false;
            this.LabelShift.Text = "[Label_Shift]:";
            this.LabelShift.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // WorkAssignment
            // 
            this.WorkAssignment.BackColor = System.Drawing.Color.White;
            this.WorkAssignment.BorderColor = System.Drawing.Color.Black;
            this.WorkAssignment.CanGrow = false;
            this.WorkAssignment.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "WorkAssignment")});
            this.WorkAssignment.ForeColor = System.Drawing.Color.Black;
            this.WorkAssignment.LocationFloat = new DevExpress.Utils.PointFloat(155F, 60F);
            this.WorkAssignment.Name = "WorkAssignment";
            this.WorkAssignment.SizeF = new System.Drawing.SizeF(549F, 16F);
            this.WorkAssignment.StylePriority.UseFont = false;
            this.WorkAssignment.Text = "WorkAssignment";
            this.WorkAssignment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // LabelAssignment
            // 
            this.LabelAssignment.BackColor = System.Drawing.Color.White;
            this.LabelAssignment.BorderColor = System.Drawing.Color.Black;
            this.LabelAssignment.CanGrow = false;
            this.LabelAssignment.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.LabelAssignment.ForeColor = System.Drawing.Color.Black;
            this.LabelAssignment.LocationFloat = new DevExpress.Utils.PointFloat(0F, 60F);
            this.LabelAssignment.Name = "LabelAssignment";
            this.LabelAssignment.SizeF = new System.Drawing.SizeF(150F, 16F);
            this.LabelAssignment.StylePriority.UseFont = false;
            this.LabelAssignment.Text = "[Label_Assignment]:";
            this.LabelAssignment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // LastModifiedByName
            // 
            this.LastModifiedByName.BackColor = System.Drawing.Color.White;
            this.LastModifiedByName.BorderColor = System.Drawing.Color.Black;
            this.LastModifiedByName.CanGrow = false;
            this.LastModifiedByName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LastModifiedByName")});
            this.LastModifiedByName.ForeColor = System.Drawing.Color.Black;
            this.LastModifiedByName.LocationFloat = new DevExpress.Utils.PointFloat(155F, 40F);
            this.LastModifiedByName.Name = "LastModifiedByName";
            this.LastModifiedByName.SizeF = new System.Drawing.SizeF(549F, 16F);
            this.LastModifiedByName.StylePriority.UseFont = false;
            this.LastModifiedByName.Text = "LastModifiedByName";
            this.LastModifiedByName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // LabelEditedBy
            // 
            this.LabelEditedBy.BackColor = System.Drawing.Color.White;
            this.LabelEditedBy.BorderColor = System.Drawing.Color.Black;
            this.LabelEditedBy.CanGrow = false;
            this.LabelEditedBy.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.LabelEditedBy.ForeColor = System.Drawing.Color.Black;
            this.LabelEditedBy.LocationFloat = new DevExpress.Utils.PointFloat(0F, 40F);
            this.LabelEditedBy.Name = "LabelEditedBy";
            this.LabelEditedBy.SizeF = new System.Drawing.SizeF(150F, 16F);
            this.LabelEditedBy.StylePriority.UseFont = false;
            this.LabelEditedBy.Text = "[Label_EditedBy]:";
            this.LabelEditedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // labelLogDateTime
            // 
            this.labelLogDateTime.BackColor = System.Drawing.Color.White;
            this.labelLogDateTime.BorderColor = System.Drawing.Color.Black;
            this.labelLogDateTime.CanGrow = false;
            this.labelLogDateTime.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelLogDateTime.ForeColor = System.Drawing.Color.Black;
            this.labelLogDateTime.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.labelLogDateTime.Name = "labelLogDateTime";
            this.labelLogDateTime.SizeF = new System.Drawing.SizeF(150F, 16F);
            this.labelLogDateTime.StylePriority.UseFont = false;
            this.labelLogDateTime.Text = "[Label_LogDateTime]:";
            this.labelLogDateTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ActualLoggedDateTime
            // 
            this.ActualLoggedDateTime.BackColor = System.Drawing.Color.White;
            this.ActualLoggedDateTime.BorderColor = System.Drawing.Color.Black;
            this.ActualLoggedDateTime.CanGrow = false;
            this.ActualLoggedDateTime.ForeColor = System.Drawing.Color.Black;
            this.ActualLoggedDateTime.LocationFloat = new DevExpress.Utils.PointFloat(155F, 0F);
            this.ActualLoggedDateTime.Name = "ActualLoggedDateTime";
            this.ActualLoggedDateTime.SizeF = new System.Drawing.SizeF(549F, 16F);
            this.ActualLoggedDateTime.StylePriority.UseFont = false;
            this.ActualLoggedDateTime.Text = "[LogDateTime!dd/MM/yyyy HH:mm]";
            this.ActualLoggedDateTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // LabelFunctionalLocation
            // 
            this.LabelFunctionalLocation.BackColor = System.Drawing.Color.White;
            this.LabelFunctionalLocation.BorderColor = System.Drawing.Color.Black;
            this.LabelFunctionalLocation.CanGrow = false;
            this.LabelFunctionalLocation.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.LabelFunctionalLocation.ForeColor = System.Drawing.Color.Black;
            this.LabelFunctionalLocation.LocationFloat = new DevExpress.Utils.PointFloat(0F, 80F);
            this.LabelFunctionalLocation.Name = "LabelFunctionalLocation";
            this.LabelFunctionalLocation.SizeF = new System.Drawing.SizeF(150F, 16F);
            this.LabelFunctionalLocation.StylePriority.UseFont = false;
            this.LabelFunctionalLocation.Text = "[Label_FunctionalLocations]:";
            this.LabelFunctionalLocation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // HideReferencedLogs
            // 
            this.HideReferencedLogs.Condition = "[ShowReferencedLogs] == False";
            // 
            // 
            // 
            this.HideReferencedLogs.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.HideReferencedLogs.Name = "HideReferencedLogs";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Logo_English,
            this.headerLine,
            this.reportTitle,
            this.Logo_French});
            this.PageHeader.HeightF = 50F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Logo_English
            // 
            this.Logo_English.BackColor = System.Drawing.Color.White;
            this.Logo_English.BorderColor = System.Drawing.Color.Black;
            this.Logo_English.FormattingRules.Add(this.IsNotEnglish);
            this.Logo_English.Image = ((System.Drawing.Image)(resources.GetObject("Logo_English.Image")));
            this.Logo_English.LocationFloat = new DevExpress.Utils.PointFloat(672F, 0F);
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
            // reportTitle
            // 
            this.reportTitle.BackColor = System.Drawing.Color.White;
            this.reportTitle.BorderColor = System.Drawing.Color.Black;
            this.reportTitle.CanGrow = false;
            this.reportTitle.Font = new System.Drawing.Font("Arial", 20F);
            this.reportTitle.ForeColor = System.Drawing.Color.Black;
            this.reportTitle.LocationFloat = new DevExpress.Utils.PointFloat(137.5F, 0F);
            this.reportTitle.Name = "reportTitle";
            this.reportTitle.SizeF = new System.Drawing.SizeF(498F, 35F);
            this.reportTitle.Text = "[Label_Title]";
            this.reportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Logo_French
            // 
            this.Logo_French.BackColor = System.Drawing.Color.White;
            this.Logo_French.BorderColor = System.Drawing.Color.Black;
            this.Logo_French.FormattingRules.Add(this.IsNotFrench);
            this.Logo_French.Image = ((System.Drawing.Image)(resources.GetObject("Logo_French.Image")));
            this.Logo_French.LocationFloat = new DevExpress.Utils.PointFloat(672F, 0F);
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
            this.pageNumberLabel,
            this.printedDateTimeLabel});
            this.PageFooter.HeightF = 32.00002F;
            this.PageFooter.Name = "PageFooter";
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.Font = new System.Drawing.Font("Arial", 8.25F);
            this.pageNumberLabel.LocationFloat = new DevExpress.Utils.PointFloat(518.7499F, 15F);
            this.pageNumberLabel.Name = "pageNumberLabel";
            this.pageNumberLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pageNumberLabel.Scripts.OnPrintOnPage = "pageNumberLabel_PrintOnPage";
            this.pageNumberLabel.SizeF = new System.Drawing.SizeF(250F, 15F);
            this.pageNumberLabel.StylePriority.UseFont = false;
            this.pageNumberLabel.StylePriority.UseTextAlignment = false;
            this.pageNumberLabel.Text = "page";
            this.pageNumberLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // printedDateTimeLabel
            // 
            this.printedDateTimeLabel.Font = new System.Drawing.Font("Arial", 8.25F);
            this.printedDateTimeLabel.LocationFloat = new DevExpress.Utils.PointFloat(52F, 15F);
            this.printedDateTimeLabel.Name = "printedDateTimeLabel";
            this.printedDateTimeLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.printedDateTimeLabel.SizeF = new System.Drawing.SizeF(256.25F, 15F);
            this.printedDateTimeLabel.StylePriority.UseFont = false;
            this.printedDateTimeLabel.Text = "[Label_PrintedOn] [Parameters.printDateTime]";
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 20F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 20F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // printDateTime
            // 
            this.printDateTime.Name = "printDateTime";
            this.printDateTime.Visible = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.Silver;
            this.xrLabel1.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ActionItemResponseDetail")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 657.4429F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.SizeF = new System.Drawing.SizeF(766.9999F, 27.41669F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // markedAsReadBySubreport
            // 
            this.markedAsReadBySubreport.LocationFloat = new DevExpress.Utils.PointFloat(0F, 582.9999F);
            this.markedAsReadBySubreport.Name = "markedAsReadBySubreport";
            this.markedAsReadBySubreport.ReportSource = new Com.Suncor.Olt.Reports.SubReports.GenericSingleLog.DateTimeAndUserSubReport();
            this.markedAsReadBySubreport.Scripts.OnBeforePrint = "MarkedAsReadBySubreport_BeforePrint";
            this.markedAsReadBySubreport.SizeF = new System.Drawing.SizeF(770F, 38F);
            // 
            // lastModificationsSubreport
            // 
            this.lastModificationsSubreport.LocationFloat = new DevExpress.Utils.PointFloat(0F, 511F);
            this.lastModificationsSubreport.Name = "lastModificationsSubreport";
            this.lastModificationsSubreport.ReportSource = new Com.Suncor.Olt.Reports.SubReports.GenericSingleLog.DateTimeAndUserSubReport();
            this.lastModificationsSubreport.SizeF = new System.Drawing.SizeF(770F, 38F);
            // 
            // documentLinksSubreport
            // 
            this.documentLinksSubreport.LocationFloat = new DevExpress.Utils.PointFloat(0F, 367F);
            this.documentLinksSubreport.Name = "documentLinksSubreport";
            this.documentLinksSubreport.ReportSource = new Com.Suncor.Olt.Reports.SubReports.GenericSingleLog.DocumentLinksSubReport();
            this.documentLinksSubreport.Scripts.OnBeforePrint = "DocumentLinksSubreport_BeforePrint";
            this.documentLinksSubreport.SizeF = new System.Drawing.SizeF(770F, 38F);
            // 
            // customFieldsSubreport
            // 
            this.customFieldsSubreport.CanShrink = true;
            this.customFieldsSubreport.LocationFloat = new DevExpress.Utils.PointFloat(7.947286E-06F, 194F);
            this.customFieldsSubreport.Name = "customFieldsSubreport";
            this.customFieldsSubreport.ReportSource = new Com.Suncor.Olt.Reports.SubReports.GenericSingleLog.CustomFieldsSubReport();
            this.customFieldsSubreport.Scripts.OnBeforePrint = "CustomFieldsSubreport_BeforePrint";
            this.customFieldsSubreport.SizeF = new System.Drawing.SizeF(770F, 38F);
            // 
            // flocSubreport
            // 
            this.flocSubreport.LocationFloat = new DevExpress.Utils.PointFloat(150F, 80F);
            this.flocSubreport.Name = "flocSubreport";
            this.flocSubreport.ReportSource = new Com.Suncor.Olt.Reports.SubReports.GenericSingleLog.FunctionalLocationSubReport();
            this.flocSubreport.Scripts.OnBeforePrint = "flocSubreport_BeforePrint";
            this.flocSubreport.SizeF = new System.Drawing.SizeF(620F, 16F);
            // 
            // genericsinglelogreportadapter
            // 
            this.genericsinglelogreportadapter.DataSource = typeof(Com.Suncor.Olt.Reports.Adapters.GenericSingleLogReportAdapter);
            // 
            // RtfGenericSingleLogReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.DataSource = this.genericsinglelogreportadapter;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.IsNotEnglish,
            this.IsNotFrench,
            this.HideFollowup,
            this.HideOptions,
            this.HideCustomFields,
            this.HideDORComments,
            this.HideReferencedLogs,
            this.HideDocumentLinks,
            this.HideMarkedAsReadBy});
            this.Margins = new System.Drawing.Printing.Margins(55, 25, 20, 20);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.printDateTime});
            this.Scripts.OnBeforePrint = "RtfGenericSingleLogReport_BeforePrint";
            this.ScriptsSource = resources.GetString("$this.ScriptsSource");
            this.ShowPrintMarginsWarning = false;
            this.Version = "13.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTableImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markedAsReadByTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modificationsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentLinksTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dorCommentsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentHeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customFieldsHeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.followupTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.followupCheckboxTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genericsinglelogreportadapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel Shift;
        private DevExpress.XtraReports.UI.XRLabel LabelShift;
        private DevExpress.XtraReports.UI.XRLabel WorkAssignment;
        private DevExpress.XtraReports.UI.XRLabel LabelAssignment;
        private DevExpress.XtraReports.UI.XRLabel LastModifiedByName;
        private DevExpress.XtraReports.UI.XRLabel LabelEditedBy;
        private DevExpress.XtraReports.UI.XRLabel labelLogDateTime;
        private DevExpress.XtraReports.UI.XRLabel ActualLoggedDateTime;
        private DevExpress.XtraReports.UI.XRLabel LabelFunctionalLocation;
        private DevExpress.XtraReports.UI.XRLabel LabelFollowup;
        private DevExpress.XtraReports.UI.XRLabel LabelOptions;
        private DevExpress.XtraReports.UI.XRLabel CustomFieldHeader;
        private DevExpress.XtraReports.UI.XRLabel RtfCommentsHeader;
        private DevExpress.XtraReports.UI.XRLabel DorCommentsHeader;
        private DevExpress.XtraReports.UI.XRLabel DorComments;
        private DevExpress.XtraReports.UI.XRLabel DocumentLinksHeader;
        private DevExpress.XtraReports.UI.XRLabel lastModificationsHeader;
        private DevExpress.XtraReports.UI.XRLabel markedAsReadByHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLine headerLine;
        private DevExpress.XtraReports.UI.XRLabel reportTitle;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private System.Windows.Forms.BindingSource genericsinglelogreportadapter;
        private DevExpress.XtraReports.UI.XRTable followupCheckboxTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRCheckBox ehsCheckBox;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRCheckBox operationsCheckBox;
        private DevExpress.XtraReports.UI.XRCheckBox supervisionCheckBox;
        private DevExpress.XtraReports.UI.XRCheckBox processControlCheckBox;
        private DevExpress.XtraReports.UI.XRCheckBox inspectionCheckBox;
        private DevExpress.XtraReports.UI.XRCheckBox otherCheckBox;
        private DevExpress.XtraReports.UI.XRCheckBox recommendForSummaryCheckBox;
        private DevExpress.XtraReports.UI.XRLabel printedDateTimeLabel;
        private DevExpress.XtraReports.UI.XRPictureBox Logo_English;
        private DevExpress.XtraReports.UI.XRPictureBox Logo_French;
        private DevExpress.XtraReports.UI.FormattingRule IsNotEnglish;
        private DevExpress.XtraReports.UI.FormattingRule IsNotFrench;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
        private DevExpress.XtraReports.UI.XRPanel functionalLocationPushdownPanel;
        private DevExpress.XtraReports.UI.XRTable followupTable;
        private DevExpress.XtraReports.UI.XRTableRow followupTableRow;
        private DevExpress.XtraReports.UI.XRTableCell followupTableCell;
        private DevExpress.XtraReports.UI.FormattingRule HideFollowup;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTable optionsTable;
        private DevExpress.XtraReports.UI.XRTableRow optionsTableRow;
        private DevExpress.XtraReports.UI.XRTableCell optionsTableCell;
        private DevExpress.XtraReports.UI.FormattingRule HideOptions;
        private DevExpress.XtraReports.UI.XRSubreport flocSubreport;
        private DevExpress.XtraReports.UI.XRSubreport customFieldsSubreport;
        private DevExpress.XtraReports.UI.XRTable customFieldsHeaderTable;
        private DevExpress.XtraReports.UI.XRTableRow customFieldsTableRow;
        private DevExpress.XtraReports.UI.XRTableCell customFieldsTableCell;
        private DevExpress.XtraReports.UI.FormattingRule HideCustomFields;
        private DevExpress.XtraReports.UI.XRTable commentHeaderTable;
        private DevExpress.XtraReports.UI.XRTableRow commentTableRow;
        private DevExpress.XtraReports.UI.XRTableCell commentsTableCell;
        private DevExpress.XtraReports.UI.XRTable dorCommentsTable;
        private DevExpress.XtraReports.UI.XRTableRow dorCommentsTableHeaderRow;
        private DevExpress.XtraReports.UI.XRTableCell dorCommentsTableHeaderCell;
        private DevExpress.XtraReports.UI.FormattingRule HideDORComments;
        private DevExpress.XtraReports.UI.FormattingRule HideReferencedLogs;
        private DevExpress.XtraReports.UI.XRTable documentLinksTable;
        private DevExpress.XtraReports.UI.XRTableRow documentLinksTableRow;
        private DevExpress.XtraReports.UI.XRTableCell documentLinksTableCell;
        private DevExpress.XtraReports.UI.XRSubreport documentLinksSubreport;
        private DevExpress.XtraReports.UI.XRTable modificationsTable;
        private DevExpress.XtraReports.UI.XRTableRow modificationsTableRow;
        private DevExpress.XtraReports.UI.XRTableCell modificationsTableCell;
        private DevExpress.XtraReports.UI.FormattingRule HideDocumentLinks;
        private DevExpress.XtraReports.UI.FormattingRule HideMarkedAsReadBy;
        private DevExpress.XtraReports.UI.XRTable markedAsReadByTable;
        private DevExpress.XtraReports.UI.XRTableRow markedAsReadByTableRow;
        private DevExpress.XtraReports.UI.XRTableCell markedAsReadByTableCell;
        private DevExpress.XtraReports.UI.XRSubreport lastModificationsSubreport;
        private DevExpress.XtraReports.UI.XRSubreport markedAsReadBySubreport;
        private DevExpress.XtraReports.UI.XRTableRow dorCommentsContentsTableRow;
        private DevExpress.XtraReports.UI.XRTableCell dorCommentsContentsTableCell;
        private DevExpress.XtraReports.Parameters.Parameter printDateTime;
        private DevExpress.XtraReports.UI.XRLabel pageNumberLabel;
        private DevExpress.XtraReports.UI.XRTable xrTableImage;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRLabel xrLabelImage;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;

    }
}
