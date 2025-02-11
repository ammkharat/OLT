﻿using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.SubReports.GNForm;
using Com.Suncor.Olt.Reports.SubReports.GenericSingleLog;

namespace Com.Suncor.Olt.Reports
{
    partial class DirectiveReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectiveReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabelMarAsRead = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableMarkasRead = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellMarasReadDatetime = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellMarkasReadUserName = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableImage = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabelImage = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.commentsAsRtf = new DevExpress.XtraReports.UI.XRRichText();
            this.flocLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.CustomFieldHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.creationDateTimeLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.lastModifiedDateTimeLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.lastModifiedDateTimeDataLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.creationDateTimeDataLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.lastModifiedByDataLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.createdByDataLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.lastModifiedByLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.createdByLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.HideOpFields = new DevExpress.XtraReports.UI.FormattingRule();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Logo_French = new DevExpress.XtraReports.UI.XRPictureBox();
            this.IsNotFrench = new DevExpress.XtraReports.UI.FormattingRule();
            this.Logo_English = new DevExpress.XtraReports.UI.XRPictureBox();
            this.IsNotEnglish = new DevExpress.XtraReports.UI.FormattingRule();
            this.headerLine = new DevExpress.XtraReports.UI.XRLine();
            this.permitNumberDataLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.reportTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.pageNumberLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.printedDateTimeLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.printDateTime = new DevExpress.XtraReports.Parameters.Parameter();
            this.workAssignmentSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.flocSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.directiveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrTableMarkasRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentsAsRtf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.directiveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabelMarAsRead,
            this.xrTableMarkasRead,
            this.xrTableImage,
            this.xrLabelImage,
            this.xrLabel1,
            this.workAssignmentSubreport,
            this.xrLine1,
            this.xrTable2,
            this.commentsAsRtf,
            this.flocSubreport,
            this.flocLabel,
            this.CustomFieldHeader,
            this.creationDateTimeLabel,
            this.lastModifiedDateTimeLabel,
            this.lastModifiedDateTimeDataLabel,
            this.creationDateTimeDataLabel,
            this.lastModifiedByDataLabel,
            this.createdByDataLabel,
            this.lastModifiedByLabel,
            this.createdByLabel});
            this.Detail.HeightF = 425F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabelMarAsRead
            // 
            this.xrLabelMarAsRead.BackColor = System.Drawing.Color.Silver;
            this.xrLabelMarAsRead.BorderColor = System.Drawing.Color.Silver;
            this.xrLabelMarAsRead.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabelMarAsRead.CanGrow = false;
            this.xrLabelMarAsRead.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabelMarAsRead.ForeColor = System.Drawing.Color.Black;
            this.xrLabelMarAsRead.LocationFloat = new DevExpress.Utils.PointFloat(0F, 339.25F);
            this.xrLabelMarAsRead.Name = "xrLabelMarAsRead";
            this.xrLabelMarAsRead.SizeF = new System.Drawing.SizeF(770F, 17F);
            this.xrLabelMarAsRead.StylePriority.UseFont = false;
            this.xrLabelMarAsRead.Text = "Marked As Read";
            this.xrLabelMarAsRead.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableMarkasRead
            // 
            this.xrTableMarkasRead.BackColor = System.Drawing.Color.Gainsboro;
            this.xrTableMarkasRead.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableMarkasRead.LocationFloat = new DevExpress.Utils.PointFloat(3.000132F, 356.25F);
            this.xrTableMarkasRead.Name = "xrTableMarkasRead";
            this.xrTableMarkasRead.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTableMarkasRead.SizeF = new System.Drawing.SizeF(766.9999F, 25F);
            this.xrTableMarkasRead.StylePriority.UseBackColor = false;
            this.xrTableMarkasRead.StylePriority.UseBorders = false;
            this.xrTableMarkasRead.StylePriority.UseTextAlignment = false;
            this.xrTableMarkasRead.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellMarasReadDatetime,
            this.xrTableCellMarkasReadUserName});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCellMarasReadDatetime
            // 
            this.xrTableCellMarasReadDatetime.Name = "xrTableCellMarasReadDatetime";
            this.xrTableCellMarasReadDatetime.Text = "Date/Time";
            this.xrTableCellMarasReadDatetime.Weight = 3.835000375004185D;
            // 
            // xrTableCellMarkasReadUserName
            // 
            this.xrTableCellMarkasReadUserName.Name = "xrTableCellMarkasReadUserName";
            this.xrTableCellMarkasReadUserName.Text = "UserName";
            this.xrTableCellMarkasReadUserName.Weight = 3.8349990146442523D;
            // 
            // xrTableImage
            // 
            this.xrTableImage.BackColor = System.Drawing.Color.Gainsboro;
            this.xrTableImage.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableImage.LocationFloat = new DevExpress.Utils.PointFloat(0F, 286F);
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
            // xrLabelImage
            // 
            this.xrLabelImage.BackColor = System.Drawing.Color.Silver;
            this.xrLabelImage.BorderColor = System.Drawing.Color.Silver;
            this.xrLabelImage.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabelImage.CanGrow = false;
            this.xrLabelImage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabelImage.ForeColor = System.Drawing.Color.Black;
            this.xrLabelImage.LocationFloat = new DevExpress.Utils.PointFloat(0F, 268.75F);
            this.xrLabelImage.Name = "xrLabelImage";
            this.xrLabelImage.SizeF = new System.Drawing.SizeF(770F, 17F);
            this.xrLabelImage.StylePriority.UseFont = false;
            this.xrLabelImage.Text = "[Label_Directive Images]";
            this.xrLabelImage.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.White;
            this.xrLabel1.BorderColor = System.Drawing.Color.Black;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_WorkAssignments")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 124F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.SizeF = new System.Drawing.SizeF(209.5833F, 15.99999F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 214F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(770F, 5F);
            // 
            // xrTable2
            // 
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 163F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5,
            this.xrTableRow4});
            this.xrTable2.SizeF = new System.Drawing.SizeF(770F, 50F);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 0.69444444444444442D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel5});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.Weight = 3D;
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.White;
            this.xrLabel2.BorderColor = System.Drawing.Color.Black;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.SizeF = new System.Drawing.SizeF(128.3333F, 18F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "[Label_ActiveFrom]:";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.BackColor = System.Drawing.Color.White;
            this.xrLabel5.BorderColor = System.Drawing.Color.Black;
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ActiveFrom")});
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(145F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.SizeF = new System.Drawing.SizeF(150F, 18F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 0.69444444444444442D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel4});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "xrTableCell3";
            this.xrTableCell3.Weight = 3D;
            // 
            // xrLabel3
            // 
            this.xrLabel3.BackColor = System.Drawing.Color.White;
            this.xrLabel3.BorderColor = System.Drawing.Color.Black;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.SizeF = new System.Drawing.SizeF(128.3333F, 18F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "[Label_ActiveTo]:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.BackColor = System.Drawing.Color.White;
            this.xrLabel4.BorderColor = System.Drawing.Color.Black;
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ActiveTo")});
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(145F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.SizeF = new System.Drawing.SizeF(150F, 18F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // commentsAsRtf
            // 
            this.commentsAsRtf.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Rtf", null, "Content")});
            this.commentsAsRtf.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentsAsRtf.LocationFloat = new DevExpress.Utils.PointFloat(0.0001220703F, 220F);
            this.commentsAsRtf.Name = "commentsAsRtf";
            this.commentsAsRtf.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.commentsAsRtf.SerializableRtfString = resources.GetString("commentsAsRtf.SerializableRtfString");
            this.commentsAsRtf.SizeF = new System.Drawing.SizeF(766.25F, 16F);
            this.commentsAsRtf.StylePriority.UseFont = false;
            this.commentsAsRtf.StylePriority.UsePadding = false;
            // 
            // flocLabel
            // 
            this.flocLabel.BackColor = System.Drawing.Color.White;
            this.flocLabel.BorderColor = System.Drawing.Color.Black;
            this.flocLabel.CanGrow = false;
            this.flocLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_FunctionalLocations")});
            this.flocLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.flocLabel.ForeColor = System.Drawing.Color.Black;
            this.flocLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 85.00001F);
            this.flocLabel.Name = "flocLabel";
            this.flocLabel.SizeF = new System.Drawing.SizeF(209.5833F, 16F);
            this.flocLabel.StylePriority.UseFont = false;
            this.flocLabel.Text = "flocLabel";
            this.flocLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CustomFieldHeader
            // 
            this.CustomFieldHeader.BackColor = System.Drawing.Color.Silver;
            this.CustomFieldHeader.BorderColor = System.Drawing.Color.Silver;
            this.CustomFieldHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.CustomFieldHeader.CanGrow = false;
            this.CustomFieldHeader.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_Details")});
            this.CustomFieldHeader.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CustomFieldHeader.ForeColor = System.Drawing.Color.Black;
            this.CustomFieldHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 60F);
            this.CustomFieldHeader.Name = "CustomFieldHeader";
            this.CustomFieldHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100F);
            this.CustomFieldHeader.SizeF = new System.Drawing.SizeF(770F, 20F);
            this.CustomFieldHeader.StylePriority.UseFont = false;
            this.CustomFieldHeader.StylePriority.UsePadding = false;
            this.CustomFieldHeader.StylePriority.UseTextAlignment = false;
            this.CustomFieldHeader.Text = "CustomFieldHeader";
            this.CustomFieldHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // creationDateTimeLabel
            // 
            this.creationDateTimeLabel.BackColor = System.Drawing.Color.White;
            this.creationDateTimeLabel.BorderColor = System.Drawing.Color.Black;
            this.creationDateTimeLabel.CanGrow = false;
            this.creationDateTimeLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_CreationDateTime")});
            this.creationDateTimeLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.creationDateTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.creationDateTimeLabel.LocationFloat = new DevExpress.Utils.PointFloat(446F, 10F);
            this.creationDateTimeLabel.Name = "creationDateTimeLabel";
            this.creationDateTimeLabel.SizeF = new System.Drawing.SizeF(165.625F, 18F);
            this.creationDateTimeLabel.StylePriority.UseFont = false;
            this.creationDateTimeLabel.Text = "creationDateTimeLabel";
            this.creationDateTimeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lastModifiedDateTimeLabel
            // 
            this.lastModifiedDateTimeLabel.BackColor = System.Drawing.Color.White;
            this.lastModifiedDateTimeLabel.BorderColor = System.Drawing.Color.Black;
            this.lastModifiedDateTimeLabel.CanGrow = false;
            this.lastModifiedDateTimeLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_LastModifiedDateTime")});
            this.lastModifiedDateTimeLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lastModifiedDateTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.lastModifiedDateTimeLabel.LocationFloat = new DevExpress.Utils.PointFloat(446F, 35F);
            this.lastModifiedDateTimeLabel.Name = "lastModifiedDateTimeLabel";
            this.lastModifiedDateTimeLabel.SizeF = new System.Drawing.SizeF(165.625F, 18F);
            this.lastModifiedDateTimeLabel.StylePriority.UseFont = false;
            this.lastModifiedDateTimeLabel.Text = "lastModifiedDateTimeLabel";
            this.lastModifiedDateTimeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lastModifiedDateTimeDataLabel
            // 
            this.lastModifiedDateTimeDataLabel.BackColor = System.Drawing.Color.White;
            this.lastModifiedDateTimeDataLabel.BorderColor = System.Drawing.Color.Black;
            this.lastModifiedDateTimeDataLabel.CanGrow = false;
            this.lastModifiedDateTimeDataLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LastModifiedDateTime")});
            this.lastModifiedDateTimeDataLabel.ForeColor = System.Drawing.Color.Black;
            this.lastModifiedDateTimeDataLabel.LocationFloat = new DevExpress.Utils.PointFloat(620.6251F, 34.99999F);
            this.lastModifiedDateTimeDataLabel.Name = "lastModifiedDateTimeDataLabel";
            this.lastModifiedDateTimeDataLabel.SizeF = new System.Drawing.SizeF(149.3749F, 18F);
            this.lastModifiedDateTimeDataLabel.StylePriority.UseFont = false;
            this.lastModifiedDateTimeDataLabel.Text = "lastModifiedDateTimeDataLabel";
            this.lastModifiedDateTimeDataLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // creationDateTimeDataLabel
            // 
            this.creationDateTimeDataLabel.BackColor = System.Drawing.Color.White;
            this.creationDateTimeDataLabel.BorderColor = System.Drawing.Color.Black;
            this.creationDateTimeDataLabel.CanGrow = false;
            this.creationDateTimeDataLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CreationDateTime")});
            this.creationDateTimeDataLabel.ForeColor = System.Drawing.Color.Black;
            this.creationDateTimeDataLabel.LocationFloat = new DevExpress.Utils.PointFloat(620.6251F, 9.99999F);
            this.creationDateTimeDataLabel.Name = "creationDateTimeDataLabel";
            this.creationDateTimeDataLabel.SizeF = new System.Drawing.SizeF(149.3749F, 18F);
            this.creationDateTimeDataLabel.StylePriority.UseFont = false;
            this.creationDateTimeDataLabel.Text = "creationDateTimeDataLabel";
            this.creationDateTimeDataLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lastModifiedByDataLabel
            // 
            this.lastModifiedByDataLabel.BackColor = System.Drawing.Color.White;
            this.lastModifiedByDataLabel.BorderColor = System.Drawing.Color.Black;
            this.lastModifiedByDataLabel.CanGrow = false;
            this.lastModifiedByDataLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LastModifiedBy")});
            this.lastModifiedByDataLabel.ForeColor = System.Drawing.Color.Black;
            this.lastModifiedByDataLabel.LocationFloat = new DevExpress.Utils.PointFloat(179.5833F, 34.99997F);
            this.lastModifiedByDataLabel.Name = "lastModifiedByDataLabel";
            this.lastModifiedByDataLabel.SizeF = new System.Drawing.SizeF(250F, 18F);
            this.lastModifiedByDataLabel.StylePriority.UseFont = false;
            this.lastModifiedByDataLabel.Text = "lastModifiedByDataLabel";
            this.lastModifiedByDataLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // createdByDataLabel
            // 
            this.createdByDataLabel.BackColor = System.Drawing.Color.White;
            this.createdByDataLabel.BorderColor = System.Drawing.Color.Black;
            this.createdByDataLabel.CanGrow = false;
            this.createdByDataLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CreatedBy")});
            this.createdByDataLabel.ForeColor = System.Drawing.Color.Black;
            this.createdByDataLabel.LocationFloat = new DevExpress.Utils.PointFloat(179.5833F, 10.00001F);
            this.createdByDataLabel.Name = "createdByDataLabel";
            this.createdByDataLabel.SizeF = new System.Drawing.SizeF(250F, 18F);
            this.createdByDataLabel.StylePriority.UseFont = false;
            this.createdByDataLabel.Text = "createdByDataLabel";
            this.createdByDataLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lastModifiedByLabel
            // 
            this.lastModifiedByLabel.BackColor = System.Drawing.Color.White;
            this.lastModifiedByLabel.BorderColor = System.Drawing.Color.Black;
            this.lastModifiedByLabel.CanGrow = false;
            this.lastModifiedByLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_LastModifiedBy")});
            this.lastModifiedByLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lastModifiedByLabel.ForeColor = System.Drawing.Color.Black;
            this.lastModifiedByLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 35.00001F);
            this.lastModifiedByLabel.Name = "lastModifiedByLabel";
            this.lastModifiedByLabel.SizeF = new System.Drawing.SizeF(172.0833F, 18F);
            this.lastModifiedByLabel.StylePriority.UseFont = false;
            this.lastModifiedByLabel.Text = "lastModifiedByLabel";
            this.lastModifiedByLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // createdByLabel
            // 
            this.createdByLabel.BackColor = System.Drawing.Color.White;
            this.createdByLabel.BorderColor = System.Drawing.Color.Black;
            this.createdByLabel.CanGrow = false;
            this.createdByLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_CreatedBy")});
            this.createdByLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.createdByLabel.ForeColor = System.Drawing.Color.Black;
            this.createdByLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.createdByLabel.Name = "createdByLabel";
            this.createdByLabel.SizeF = new System.Drawing.SizeF(145F, 18F);
            this.createdByLabel.StylePriority.UseFont = false;
            this.createdByLabel.Text = "createdByLabel";
            this.createdByLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // HideOpFields
            // 
            this.HideOpFields.Condition = "[ShowOpFormFields] == False";
            // 
            // 
            // 
            this.HideOpFields.Formatting.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.HideOpFields.Name = "HideOpFields";
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
            this.PageHeader.BorderWidth = 2F;
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Logo_French,
            this.Logo_English,
            this.headerLine,
            this.permitNumberDataLabel,
            this.reportTitle});
            this.PageHeader.HeightF = 50F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StylePriority.UseBorders = false;
            this.PageHeader.StylePriority.UseBorderWidth = false;
            // 
            // Logo_French
            // 
            this.Logo_French.BackColor = System.Drawing.Color.White;
            this.Logo_French.BorderColor = System.Drawing.Color.Black;
            this.Logo_French.FormattingRules.Add(this.IsNotFrench);
            this.Logo_French.Image = ((System.Drawing.Image)(resources.GetObject("Logo_French.Image")));
            this.Logo_French.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
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
            // Logo_English
            // 
            this.Logo_English.BackColor = System.Drawing.Color.White;
            this.Logo_English.BorderColor = System.Drawing.Color.Black;
            this.Logo_English.FormattingRules.Add(this.IsNotEnglish);
            this.Logo_English.Image = ((System.Drawing.Image)(resources.GetObject("Logo_English.Image")));
            this.Logo_English.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Logo_English.Name = "Logo_English";
            this.Logo_English.SizeF = new System.Drawing.SizeF(95F, 39F);
            this.Logo_English.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // IsNotEnglish
            // 
            this.IsNotEnglish.Condition = " [ShowEnglishLogo] == False";
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
            // permitNumberDataLabel
            // 
            this.permitNumberDataLabel.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.permitNumberDataLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FormNumber")});
            this.permitNumberDataLabel.LocationFloat = new DevExpress.Utils.PointFloat(675F, 12.5F);
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
            this.reportTitle.BackColor = System.Drawing.Color.White;
            this.reportTitle.BorderColor = System.Drawing.Color.Black;
            this.reportTitle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.reportTitle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Label_Title")});
            this.reportTitle.Font = new System.Drawing.Font("Arial", 20F);
            this.reportTitle.ForeColor = System.Drawing.Color.Black;
            this.reportTitle.LocationFloat = new DevExpress.Utils.PointFloat(112.5F, 0F);
            this.reportTitle.Name = "reportTitle";
            this.reportTitle.SizeF = new System.Drawing.SizeF(545.9167F, 35F);
            this.reportTitle.StylePriority.UseBorders = false;
            this.reportTitle.StylePriority.UseFont = false;
            this.reportTitle.Text = "reportTitle";
            this.reportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pageNumberLabel,
            this.printedDateTimeLabel});
            this.PageFooter.HeightF = 30.00003F;
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
            // workAssignmentSubreport
            // 
            this.workAssignmentSubreport.LocationFloat = new DevExpress.Utils.PointFloat(0F, 143F);
            this.workAssignmentSubreport.Name = "workAssignmentSubreport";
            this.workAssignmentSubreport.ReportSource = new Com.Suncor.Olt.Reports.SubReports.Directive.WorkAssignmentSubReport();
            this.workAssignmentSubreport.SizeF = new System.Drawing.SizeF(621.2502F, 16F);
            // 
            // flocSubreport
            // 
            this.flocSubreport.LocationFloat = new DevExpress.Utils.PointFloat(6.103516E-05F, 104F);
            this.flocSubreport.Name = "flocSubreport";
            this.flocSubreport.ReportSource = new Com.Suncor.Olt.Reports.SubReports.Directive.FunctionalLocationSubReport();
            this.flocSubreport.SizeF = new System.Drawing.SizeF(621.2501F, 16F);
            // 
            // directiveBindingSource
            // 
            this.directiveBindingSource.DataSource = typeof(Com.Suncor.Olt.Reports.Adapters.DirectiveReportAdapter);
            // 
            // DirectiveReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.TopMargin,
            this.BottomMargin,
            this.PageFooter});
            this.DataSource = this.directiveBindingSource;
            this.DefaultPrinterSettingsUsing.UsePaperKind = true;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.HideOpFields,
            this.IsNotEnglish,
            this.IsNotFrench});
            this.Margins = new System.Drawing.Printing.Margins(55, 25, 20, 20);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.printDateTime});
            this.ReportPrintOptions.PrintOnEmptyDataSource = false;
            this.Scripts.OnBeforePrint = "FormReport_BeforePrint";
            this.ScriptsSource = resources.GetString("$this.ScriptsSource");
            this.ShowPrintMarginsWarning = false;
            this.Version = "13.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTableMarkasRead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentsAsRtf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.directiveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel permitNumberDataLabel;
        private DevExpress.XtraReports.UI.XRLabel reportTitle;
        private DevExpress.XtraReports.UI.XRLabel pageNumberLabel;
        private DevExpress.XtraReports.UI.XRLabel printedDateTimeLabel;
        private DevExpress.XtraReports.UI.XRLabel creationDateTimeLabel;
        private DevExpress.XtraReports.UI.XRLabel lastModifiedDateTimeLabel;
        private DevExpress.XtraReports.UI.XRLabel lastModifiedDateTimeDataLabel;
        private DevExpress.XtraReports.UI.XRLabel creationDateTimeDataLabel;
        private DevExpress.XtraReports.UI.XRLabel lastModifiedByDataLabel;
        private DevExpress.XtraReports.UI.XRLabel createdByDataLabel;
        private DevExpress.XtraReports.UI.XRLabel lastModifiedByLabel;
        private DevExpress.XtraReports.UI.XRLabel createdByLabel;
        private DevExpress.XtraReports.UI.XRLabel CustomFieldHeader;
        private DevExpress.XtraReports.UI.XRLabel flocLabel;
        private DevExpress.XtraReports.UI.XRSubreport flocSubreport;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRRichText commentsAsRtf;
        private DevExpress.XtraReports.Parameters.Parameter printDateTime;
        private DevExpress.XtraReports.UI.XRLine headerLine;
        private DevExpress.XtraReports.UI.FormattingRule HideOpFields;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private System.Windows.Forms.BindingSource directiveBindingSource;
        private DevExpress.XtraReports.UI.XRSubreport workAssignmentSubreport;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPictureBox Logo_English;
        private DevExpress.XtraReports.UI.XRPictureBox Logo_French;
        private DevExpress.XtraReports.UI.FormattingRule IsNotEnglish;
        private DevExpress.XtraReports.UI.FormattingRule IsNotFrench;
        private DevExpress.XtraReports.UI.XRLabel xrLabelImage;
        private DevExpress.XtraReports.UI.XRTable xrTableImage;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTable xrTableMarkasRead;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellMarasReadDatetime;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellMarkasReadUserName;
        private DevExpress.XtraReports.UI.XRLabel xrLabelMarAsRead;
    }
}
