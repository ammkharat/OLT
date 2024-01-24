using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Reports.SubReports.ShiftHandoverQuestionnaire
{
    partial class AnswersSubReport
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.CommentTable = new DevExpress.XtraReports.UI.XRTable();
            this.CommentTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.CommentTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.SuppressComment = new DevExpress.XtraReports.UI.FormattingRule();
            this.QuestionPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.QuestionNumberLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.QuestionLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.yesCheckBox = new DevExpress.XtraReports.UI.XRCheckBox();
            this.noCheckBox = new DevExpress.XtraReports.UI.XRCheckBox();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ShiftHandoverQuestionnaireId = new DevExpress.XtraReports.Parameters.Parameter();
            this.adapter = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CommentTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.CommentTable,
            this.QuestionPanel});
            this.Detail.HeightF = 45F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Silver;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(40F, 40F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(725F, 2F);
            this.xrLine1.StylePriority.UseBorderColor = false;
            this.xrLine1.StylePriority.UseForeColor = false;
            // 
            // CommentTable
            // 
            this.CommentTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 21F);
            this.CommentTable.Name = "CommentTable";
            this.CommentTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.CommentTableRow});
            this.CommentTable.SizeF = new System.Drawing.SizeF(770F, 16F);
            // 
            // CommentTableRow
            // 
            this.CommentTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.CommentTableCell});
            this.CommentTableRow.FormattingRules.Add(this.SuppressComment);
            this.CommentTableRow.Name = "CommentTableRow";
            this.CommentTableRow.Weight = 1D;
            // 
            // CommentTableCell
            // 
            this.CommentTableCell.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1});
            this.CommentTableCell.Name = "CommentTableCell";
            this.CommentTableCell.Weight = 3D;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Comments")});
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(615.0001F, 16F);
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(40F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel1.Text = "[Label_Comments]:";
            // 
            // SuppressComment
            // 
            this.SuppressComment.Condition = "[ShouldSuppressComments] == True";
            // 
            // 
            // 
            this.SuppressComment.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.SuppressComment.Name = "SuppressComment";
            // 
            // QuestionPanel
            // 
            this.QuestionPanel.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.QuestionNumberLabel,
            this.QuestionLabel,
            this.yesCheckBox,
            this.noCheckBox});
            this.QuestionPanel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.QuestionPanel.Name = "QuestionPanel";
            this.QuestionPanel.SizeF = new System.Drawing.SizeF(770F, 20F);
            // 
            // QuestionNumberLabel
            // 
            this.QuestionNumberLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Question")});
            this.QuestionNumberLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.QuestionNumberLabel.Name = "QuestionNumberLabel";
            this.QuestionNumberLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.QuestionNumberLabel.SizeF = new System.Drawing.SizeF(25F, 16F);
            xrSummary1.FormatString = "{0}.";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.QuestionNumberLabel.Summary = xrSummary1;
            this.QuestionNumberLabel.Text = "QuestionNumberLabel";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Question")});
            this.QuestionLabel.KeepTogether = true;
            this.QuestionLabel.LocationFloat = new DevExpress.Utils.PointFloat(40F, 0F);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.QuestionLabel.SizeF = new System.Drawing.SizeF(550F, 16F);
            this.QuestionLabel.Text = "QuestionLabel";
            // 
            // yesCheckBox
            // 
            this.yesCheckBox.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_Yes"),
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "Yes")});
            this.yesCheckBox.LocationFloat = new DevExpress.Utils.PointFloat(630.8712F, 0F);
            this.yesCheckBox.Name = "yesCheckBox";
            this.yesCheckBox.SizeF = new System.Drawing.SizeF(60F, 16F);
            this.yesCheckBox.Text = "yesCheckBox";
            // 
            // noCheckBox
            // 
            this.noCheckBox.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_No"),
            new DevExpress.XtraReports.UI.XRBinding("CheckState", null, "No")});
            this.noCheckBox.LocationFloat = new DevExpress.Utils.PointFloat(705F, 0F);
            this.noCheckBox.Name = "noCheckBox";
            this.noCheckBox.SizeF = new System.Drawing.SizeF(60F, 16F);
            this.noCheckBox.Text = "noCheckBox";
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
            this.adapter.DataSource = typeof(ShiftHandoverAnswerReportAdapter);
            // 
            // AnswersSubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.DataSource = this.adapter;
            this.FilterString = "[ParentId] = ?ShiftHandoverQuestionnaireId";
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.SuppressComment});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageWidth = 770;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.ShiftHandoverQuestionnaireId});
            this.Version = "12.2";
            ((System.ComponentModel.ISupportInitialize)(this.CommentTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        public DevExpress.XtraReports.Parameters.Parameter ShiftHandoverQuestionnaireId;
        private System.Windows.Forms.BindingSource adapter;
        private DevExpress.XtraReports.UI.XRCheckBox noCheckBox;
        private DevExpress.XtraReports.UI.XRCheckBox yesCheckBox;
        private DevExpress.XtraReports.UI.XRLabel QuestionLabel;
        private DevExpress.XtraReports.UI.XRLabel QuestionNumberLabel;
        private DevExpress.XtraReports.UI.XRPanel QuestionPanel;
        private DevExpress.XtraReports.UI.XRTable CommentTable;
        private DevExpress.XtraReports.UI.XRTableRow CommentTableRow;
        private DevExpress.XtraReports.UI.XRTableCell CommentTableCell;
        private DevExpress.XtraReports.UI.FormattingRule SuppressComment;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    }
}
