using System.Security.AccessControl;
using Infragistics.Win.UltraWinForm;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    partial class EdmontonOvertimeFormDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.invisibleLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.createdByGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.createdByUserDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.createdDateDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.dateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.lastModifiedGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.lastModifiedUserDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.lastModifiedDateDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.functionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.tradeDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.formInformationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.formNumberDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.oltLabel6 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.oltGroupBox2 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelledLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.oltLabel4 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.approvedLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.oltLabel5 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.validToDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.validToLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.validFromDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.validFromLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.onPremiseContractorsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.approvalsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.documentLinksGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.documentLinksControl = new Com.Suncor.Olt.Client.Controls.DocumentLinksControl();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.historyButton = new System.Windows.Forms.ToolStripButton();
            this.cloneButton = new System.Windows.Forms.ToolStripButton();
            this.printButton = new System.Windows.Forms.ToolStripButton();
            this.printPreviewButton = new System.Windows.Forms.ToolStripButton();
            this.emailButton = new System.Windows.Forms.ToolStripButton();
            this.cancelButton = new System.Windows.Forms.ToolStripButton();
            this.exportAllButton = new System.Windows.Forms.ToolStripButton();
            this.dateRangeButton = new System.Windows.Forms.ToolStripButton();
            this.saveGridLayoutButton = new System.Windows.Forms.ToolStripButton();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.createdByGroupBox.SuspendLayout();
            this.lastModifiedGroupBox.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.functionalLocationGroupBox.SuspendLayout();
            this.formInformationGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.oltGroupBox2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.oltGroupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.documentLinksGroupBox.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.invisibleLabel);
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Controls.Add(this.tableLayoutPanel5);
            this.mainPanel.Controls.Add(this.tableLayoutPanel2);
            this.mainPanel.Controls.Add(this.onPremiseContractorsGroupBox);
            this.mainPanel.Controls.Add(this.approvalsGroupBox);
            this.mainPanel.Controls.Add(this.documentLinksGroupBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainPanel.Location = new System.Drawing.Point(0, 25);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(680, 539);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.WrapContents = false;
            // 
            // invisibleLabel
            // 
            this.invisibleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.invisibleLabel.Location = new System.Drawing.Point(3, 0);
            this.invisibleLabel.Name = "invisibleLabel";
            this.invisibleLabel.Size = new System.Drawing.Size(636, 10);
            this.invisibleLabel.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.createdByGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lastModifiedGroupBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 83);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // createdByGroupBox
            // 
            this.createdByGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createdByGroupBox.Controls.Add(this.createdByUserDataLabel);
            this.createdByGroupBox.Controls.Add(this.createdDateDataLabel);
            this.createdByGroupBox.Controls.Add(this.oltLabel1);
            this.createdByGroupBox.Controls.Add(this.dateLabel);
            this.createdByGroupBox.Location = new System.Drawing.Point(3, 3);
            this.createdByGroupBox.Name = "createdByGroupBox";
            this.createdByGroupBox.Size = new System.Drawing.Size(312, 75);
            this.createdByGroupBox.TabIndex = 0;
            this.createdByGroupBox.TabStop = false;
            this.createdByGroupBox.Text = "Created By";
            // 
            // createdByUserDataLabel
            // 
            this.createdByUserDataLabel.AutoSize = true;
            this.createdByUserDataLabel.Location = new System.Drawing.Point(46, 48);
            this.createdByUserDataLabel.Name = "createdByUserDataLabel";
            this.createdByUserDataLabel.Size = new System.Drawing.Size(91, 13);
            this.createdByUserDataLabel.TabIndex = 4;
            this.createdByUserDataLabel.Text = "[created by user]";
            this.createdByUserDataLabel.UseMnemonic = false;
            // 
            // createdDateDataLabel
            // 
            this.createdDateDataLabel.AutoSize = true;
            this.createdDateDataLabel.Location = new System.Drawing.Point(46, 23);
            this.createdDateDataLabel.Name = "createdDateDataLabel";
            this.createdDateDataLabel.Size = new System.Drawing.Size(92, 13);
            this.createdDateDataLabel.TabIndex = 3;
            this.createdDateDataLabel.Text = "[created by date]";
            this.createdDateDataLabel.UseMnemonic = false;
            // 
            // oltLabel1
            // 
            this.oltLabel1.AutoSize = true;
            this.oltLabel1.Location = new System.Drawing.Point(6, 48);
            this.oltLabel1.Name = "oltLabel1";
            this.oltLabel1.Size = new System.Drawing.Size(33, 13);
            this.oltLabel1.TabIndex = 1;
            this.oltLabel1.Text = "User:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(6, 23);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(34, 13);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Date:";
            // 
            // lastModifiedGroupBox
            // 
            this.lastModifiedGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastModifiedGroupBox.Controls.Add(this.lastModifiedUserDataLabel);
            this.lastModifiedGroupBox.Controls.Add(this.lastModifiedDateDataLabel);
            this.lastModifiedGroupBox.Controls.Add(this.oltLabel3);
            this.lastModifiedGroupBox.Controls.Add(this.oltLabel2);
            this.lastModifiedGroupBox.Location = new System.Drawing.Point(321, 3);
            this.lastModifiedGroupBox.Name = "lastModifiedGroupBox";
            this.lastModifiedGroupBox.Size = new System.Drawing.Size(312, 75);
            this.lastModifiedGroupBox.TabIndex = 1;
            this.lastModifiedGroupBox.TabStop = false;
            this.lastModifiedGroupBox.Text = "Last Modified";
            // 
            // lastModifiedUserDataLabel
            // 
            this.lastModifiedUserDataLabel.AutoSize = true;
            this.lastModifiedUserDataLabel.Location = new System.Drawing.Point(46, 48);
            this.lastModifiedUserDataLabel.Name = "lastModifiedUserDataLabel";
            this.lastModifiedUserDataLabel.Size = new System.Drawing.Size(99, 13);
            this.lastModifiedUserDataLabel.TabIndex = 6;
            this.lastModifiedUserDataLabel.Text = "[last modified user]";
            this.lastModifiedUserDataLabel.UseMnemonic = false;
            // 
            // lastModifiedDateDataLabel
            // 
            this.lastModifiedDateDataLabel.AutoSize = true;
            this.lastModifiedDateDataLabel.Location = new System.Drawing.Point(46, 23);
            this.lastModifiedDateDataLabel.Name = "lastModifiedDateDataLabel";
            this.lastModifiedDateDataLabel.Size = new System.Drawing.Size(100, 13);
            this.lastModifiedDateDataLabel.TabIndex = 5;
            this.lastModifiedDateDataLabel.Text = "[last modified date]";
            this.lastModifiedDateDataLabel.UseMnemonic = false;
            // 
            // oltLabel3
            // 
            this.oltLabel3.AutoSize = true;
            this.oltLabel3.Location = new System.Drawing.Point(6, 48);
            this.oltLabel3.Name = "oltLabel3";
            this.oltLabel3.Size = new System.Drawing.Size(33, 13);
            this.oltLabel3.TabIndex = 2;
            this.oltLabel3.Text = "User:";
            // 
            // oltLabel2
            // 
            this.oltLabel2.AutoSize = true;
            this.oltLabel2.Location = new System.Drawing.Point(6, 23);
            this.oltLabel2.Name = "oltLabel2";
            this.oltLabel2.Size = new System.Drawing.Size(34, 13);
            this.oltLabel2.TabIndex = 2;
            this.oltLabel2.Text = "Date:";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.functionalLocationGroupBox, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.formInformationGroupBox, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 102);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(636, 50);
            this.tableLayoutPanel5.TabIndex = 26;
            // 
            // functionalLocationGroupBox
            // 
            this.functionalLocationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionalLocationGroupBox.Controls.Add(this.tradeDataLabel);
            this.functionalLocationGroupBox.Location = new System.Drawing.Point(321, 3);
            this.functionalLocationGroupBox.Name = "functionalLocationGroupBox";
            this.functionalLocationGroupBox.Size = new System.Drawing.Size(312, 44);
            this.functionalLocationGroupBox.TabIndex = 10;
            this.functionalLocationGroupBox.TabStop = false;
            this.functionalLocationGroupBox.Text = "Trade";
            // 
            // tradeDataLabel
            // 
            this.tradeDataLabel.AutoSize = true;
            this.tradeDataLabel.Location = new System.Drawing.Point(7, 20);
            this.tradeDataLabel.Name = "tradeDataLabel";
            this.tradeDataLabel.Size = new System.Drawing.Size(51, 13);
            this.tradeDataLabel.TabIndex = 5;
            this.tradeDataLabel.Text = "<Trade>";
            // 
            // formInformationGroupBox
            // 
            this.formInformationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formInformationGroupBox.Controls.Add(this.formNumberDataLabel);
            this.formInformationGroupBox.Controls.Add(this.oltLabel6);
            this.formInformationGroupBox.Location = new System.Drawing.Point(6, 3);
            this.formInformationGroupBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.formInformationGroupBox.Name = "formInformationGroupBox";
            this.formInformationGroupBox.Size = new System.Drawing.Size(309, 44);
            this.formInformationGroupBox.TabIndex = 21;
            this.formInformationGroupBox.TabStop = false;
            this.formInformationGroupBox.Text = "Form Information";
            // 
            // formNumberDataLabel
            // 
            this.formNumberDataLabel.AutoSize = true;
            this.formNumberDataLabel.Location = new System.Drawing.Point(59, 23);
            this.formNumberDataLabel.Name = "formNumberDataLabel";
            this.formNumberDataLabel.Size = new System.Drawing.Size(48, 13);
            this.formNumberDataLabel.TabIndex = 5;
            this.formNumberDataLabel.Text = "[form #]";
            this.formNumberDataLabel.UseMnemonic = false;
            // 
            // oltLabel6
            // 
            this.oltLabel6.AutoSize = true;
            this.oltLabel6.Location = new System.Drawing.Point(7, 23);
            this.oltLabel6.Name = "oltLabel6";
            this.oltLabel6.Size = new System.Drawing.Size(46, 13);
            this.oltLabel6.TabIndex = 4;
            this.oltLabel6.Text = "Form #:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.oltGroupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.oltGroupBox1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 158);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(636, 79);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // oltGroupBox2
            // 
            this.oltGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oltGroupBox2.Controls.Add(this.tableLayoutPanel6);
            this.oltGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.oltGroupBox2.Name = "oltGroupBox2";
            this.oltGroupBox2.Size = new System.Drawing.Size(312, 73);
            this.oltGroupBox2.TabIndex = 12;
            this.oltGroupBox2.TabStop = false;
            this.oltGroupBox2.Text = "Miscellaneous";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.cancelledLabelData, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.oltLabel4, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.approvedLabelData, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.oltLabel5, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(300, 47);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // cancelledLabelData
            // 
            this.cancelledLabelData.AutoSize = true;
            this.cancelledLabelData.Location = new System.Drawing.Point(67, 23);
            this.cancelledLabelData.Name = "cancelledLabelData";
            this.cancelledLabelData.Size = new System.Drawing.Size(109, 13);
            this.cancelledLabelData.TabIndex = 3;
            this.cancelledLabelData.Text = "[cancelled date/user]";
            this.cancelledLabelData.UseMnemonic = false;
            // 
            // oltLabel4
            // 
            this.oltLabel4.AutoSize = true;
            this.oltLabel4.Location = new System.Drawing.Point(3, 23);
            this.oltLabel4.Name = "oltLabel4";
            this.oltLabel4.Size = new System.Drawing.Size(57, 13);
            this.oltLabel4.TabIndex = 1;
            this.oltLabel4.Text = "Cancelled:";
            // 
            // approvedLabelData
            // 
            this.approvedLabelData.AutoSize = true;
            this.approvedLabelData.Location = new System.Drawing.Point(67, 0);
            this.approvedLabelData.Name = "approvedLabelData";
            this.approvedLabelData.Size = new System.Drawing.Size(111, 13);
            this.approvedLabelData.TabIndex = 2;
            this.approvedLabelData.Text = "[approved date/user]";
            this.approvedLabelData.UseMnemonic = false;
            // 
            // oltLabel5
            // 
            this.oltLabel5.AutoSize = true;
            this.oltLabel5.Location = new System.Drawing.Point(3, 0);
            this.oltLabel5.Name = "oltLabel5";
            this.oltLabel5.Size = new System.Drawing.Size(58, 13);
            this.oltLabel5.TabIndex = 0;
            this.oltLabel5.Text = "Approved:";
            // 
            // oltGroupBox1
            // 
            this.oltGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oltGroupBox1.Controls.Add(this.tableLayoutPanel3);
            this.oltGroupBox1.Location = new System.Drawing.Point(321, 3);
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.Size = new System.Drawing.Size(312, 73);
            this.oltGroupBox1.TabIndex = 11;
            this.oltGroupBox1.TabStop = false;
            this.oltGroupBox1.Text = "Overall Overtime Period";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.validToDataLabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.validToLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.validFromDataLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.validFromLabel, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(300, 47);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // validToDataLabel
            // 
            this.validToDataLabel.AutoSize = true;
            this.validToDataLabel.Location = new System.Drawing.Point(44, 23);
            this.validToDataLabel.Name = "validToDataLabel";
            this.validToDataLabel.Size = new System.Drawing.Size(50, 13);
            this.validToDataLabel.TabIndex = 3;
            this.validToDataLabel.Text = "[to date]";
            this.validToDataLabel.UseMnemonic = false;
            // 
            // validToLabel
            // 
            this.validToLabel.AutoSize = true;
            this.validToLabel.Location = new System.Drawing.Point(3, 23);
            this.validToLabel.Name = "validToLabel";
            this.validToLabel.Size = new System.Drawing.Size(29, 13);
            this.validToLabel.TabIndex = 1;
            this.validToLabel.Text = "End:";
            // 
            // validFromDataLabel
            // 
            this.validFromDataLabel.AutoSize = true;
            this.validFromDataLabel.Location = new System.Drawing.Point(44, 0);
            this.validFromDataLabel.Name = "validFromDataLabel";
            this.validFromDataLabel.Size = new System.Drawing.Size(62, 13);
            this.validFromDataLabel.TabIndex = 2;
            this.validFromDataLabel.Text = "[from date]";
            this.validFromDataLabel.UseMnemonic = false;
            // 
            // validFromLabel
            // 
            this.validFromLabel.AutoSize = true;
            this.validFromLabel.Location = new System.Drawing.Point(3, 0);
            this.validFromLabel.Name = "validFromLabel";
            this.validFromLabel.Size = new System.Drawing.Size(35, 13);
            this.validFromLabel.TabIndex = 0;
            this.validFromLabel.Text = "Start:";
            // 
            // onPremiseContractorsGroupBox
            // 
            this.onPremiseContractorsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.onPremiseContractorsGroupBox.Location = new System.Drawing.Point(6, 243);
            this.onPremiseContractorsGroupBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.onPremiseContractorsGroupBox.Name = "onPremiseContractorsGroupBox";
            this.onPremiseContractorsGroupBox.Size = new System.Drawing.Size(633, 180);
            this.onPremiseContractorsGroupBox.TabIndex = 19;
            this.onPremiseContractorsGroupBox.TabStop = false;
            this.onPremiseContractorsGroupBox.Text = "On Premise Contractors";
            // 
            // approvalsGroupBox
            // 
            this.approvalsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.approvalsGroupBox.Location = new System.Drawing.Point(6, 429);
            this.approvalsGroupBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.approvalsGroupBox.Name = "approvalsGroupBox";
            this.approvalsGroupBox.Size = new System.Drawing.Size(633, 100);
            this.approvalsGroupBox.TabIndex = 20;
            this.approvalsGroupBox.TabStop = false;
            this.approvalsGroupBox.Text = "Approvals";
            // 
            // documentLinksGroupBox
            // 
            this.documentLinksGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentLinksGroupBox.Controls.Add(this.documentLinksControl);
            this.documentLinksGroupBox.Location = new System.Drawing.Point(6, 535);
            this.documentLinksGroupBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.documentLinksGroupBox.Name = "documentLinksGroupBox";
            this.documentLinksGroupBox.Size = new System.Drawing.Size(633, 100);
            this.documentLinksGroupBox.TabIndex = 18;
            this.documentLinksGroupBox.TabStop = false;
            this.documentLinksGroupBox.Text = "Document Links";
            // 
            // documentLinksControl
            // 
            this.documentLinksControl.DataSource = null;
            this.documentLinksControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentLinksControl.Location = new System.Drawing.Point(3, 16);
            this.documentLinksControl.Name = "documentLinksControl";
            this.documentLinksControl.ReadOnlyList = false;
            this.documentLinksControl.Size = new System.Drawing.Size(627, 81);
            this.documentLinksControl.TabIndex = 17;
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteButton,
            this.editButton,
            this.historyButton,
            this.cloneButton,
            this.printButton,
            this.printPreviewButton,
            this.emailButton,
            this.cancelButton,
            this.exportAllButton,
            this.dateRangeButton,
            this.saveGridLayoutButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(680, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.Delete;
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.White;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(60, 22);
            this.deleteButton.Text = "Delete";
            // 
            // editButton
            // 
            this.editButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.edit_16;
            this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(47, 22);
            this.editButton.Text = "Edit";
            // 
            // historyButton
            // 
            this.historyButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.view_edit_history;
            this.historyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(65, 22);
            this.historyButton.Text = "History";
            // 
            // cloneButton
            // 
            this.cloneButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.clonePermit_16;
            this.cloneButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(58, 22);
            this.cloneButton.Text = "Clone";
            // 
            // printButton
            // 
            this.printButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.print_16;
            this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(52, 22);
            this.printButton.Text = "Print";
            // 
            // printPreviewButton
            // 
            this.printPreviewButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.preview;
            this.printPreviewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewButton.Name = "printPreviewButton";
            this.printPreviewButton.Size = new System.Drawing.Size(68, 22);
            this.printPreviewButton.Text = "Preview";
            // 
            // emailButton
            // 
            this.emailButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.email;
            this.emailButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.emailButton.Name = "emailButton";
            this.emailButton.Size = new System.Drawing.Size(56, 22);
            this.emailButton.Text = "Email";
            // 
            // cancelButton
            // 
            this.cancelButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.closePermit_16;
            this.cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(63, 22);
            this.cancelButton.Text = "Cancel";
            // 
            // exportAllButton
            // 
            this.exportAllButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exportAllButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.export_all;
            this.exportAllButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportAllButton.Name = "exportAllButton";
            this.exportAllButton.Size = new System.Drawing.Size(85, 22);
            this.exportAllButton.Text = "Export Grid";
            this.exportAllButton.ToolTipText = "Export Grid data to Excel";
            // 
            // dateRangeButton
            // 
            this.dateRangeButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.dateRangeButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.show_date_range;
            this.dateRangeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dateRangeButton.Name = "dateRangeButton";
            this.dateRangeButton.Size = new System.Drawing.Size(60, 22);
            this.dateRangeButton.Text = "Range";
            this.dateRangeButton.ToolTipText = "Change displayed Date Range";
            // 
            // saveGridLayoutButton
            // 
            this.saveGridLayoutButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveGridLayoutButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.grid_16;
            this.saveGridLayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveGridLayoutButton.Name = "saveGridLayoutButton";
            this.saveGridLayoutButton.Size = new System.Drawing.Size(88, 20);
            this.saveGridLayoutButton.Text = "Grid Layout";
            // 
            // EdmontonOvertimeFormDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.toolStrip);
            this.Name = "EdmontonOvertimeFormDetails";
            this.Size = new System.Drawing.Size(680, 564);
            this.mainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.createdByGroupBox.ResumeLayout(false);
            this.createdByGroupBox.PerformLayout();
            this.lastModifiedGroupBox.ResumeLayout(false);
            this.lastModifiedGroupBox.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.functionalLocationGroupBox.ResumeLayout(false);
            this.functionalLocationGroupBox.PerformLayout();
            this.formInformationGroupBox.ResumeLayout(false);
            this.formInformationGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.oltGroupBox2.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.oltGroupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.documentLinksGroupBox.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private OltControls.OltLabel invisibleLabel;
        private OltControls.OltLabelData validToDataLabel;
        private OltControls.OltLabelData validFromDataLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OltControls.OltGroupBox createdByGroupBox;
        private OltControls.OltLabel oltLabel1;
        private OltControls.OltLabel dateLabel;
        private OltControls.OltGroupBox lastModifiedGroupBox;
        private OltControls.OltLabel oltLabel3;
        private OltControls.OltLabel oltLabel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private OltControls.OltGroupBox functionalLocationGroupBox;
        private OltControls.OltGroupBox oltGroupBox1;
        private OltControls.OltLabel validToLabel;
        private OltControls.OltLabel validFromLabel;
        private OltControls.OltGroupBox onPremiseContractorsGroupBox;
        private OltControls.OltLabelData createdByUserDataLabel;
        private OltControls.OltLabelData createdDateDataLabel;
        private OltControls.OltLabelData lastModifiedUserDataLabel;
        private OltControls.OltLabelData lastModifiedDateDataLabel;
        private OltControls.OltGroupBox formInformationGroupBox;
        private OltControls.OltLabel oltLabel6;
        private OltControls.OltLabelData formNumberDataLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripButton editButton;
        private System.Windows.Forms.ToolStripButton historyButton;
        private System.Windows.Forms.ToolStripButton cloneButton;
        private System.Windows.Forms.ToolStripButton printButton;
        private System.Windows.Forms.ToolStripButton printPreviewButton;
        private System.Windows.Forms.ToolStripButton emailButton;
        private System.Windows.Forms.ToolStripButton cancelButton;
        private System.Windows.Forms.ToolStripButton exportAllButton;
        private System.Windows.Forms.ToolStripButton dateRangeButton;
        private System.Windows.Forms.ToolStripButton saveGridLayoutButton;
        private OltControls.OltGroupBox documentLinksGroupBox;
        private DocumentLinksControl documentLinksControl;
        private OltControls.OltLabel tradeDataLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private OltControls.OltGroupBox oltGroupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private OltControls.OltLabelData cancelledLabelData;
        private OltControls.OltLabel oltLabel4;
        private OltControls.OltLabelData approvedLabelData;
        private OltControls.OltLabel oltLabel5;
        private OltControls.OltGroupBox approvalsGroupBox;


    }
}
