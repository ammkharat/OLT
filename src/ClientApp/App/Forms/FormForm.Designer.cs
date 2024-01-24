namespace Com.Suncor.Olt.Client.Forms
{
    partial class FormForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.waitingapprovalButton = new System.Windows.Forms.Button();
            this.saveAndEmailButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.invisibleLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.createdByGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.createdByUserLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.createdDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.dateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.lastModifiedGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.lastModifiedUserLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.lastModifiedDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.documentLinksGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.documentLinksControl = new Com.Suncor.Olt.Client.Controls.DocumentLinksControl();
            this.functionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.removeFunctionalLocatnButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.functionalLocationListBox = new Com.Suncor.Olt.Client.Controls.FunctionalLocationListBox();
            this.addFunctionalLocationButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltGroupBox3 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.toLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.fromLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.validToTimePicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.validFromTimePicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.validToDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.validFromDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.contentGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.expandLinkLabel = new Com.Suncor.Olt.Client.OltControls.OltLinkLabel1();
            this.contentRichTextEditor = new Com.Suncor.Olt.Client.Controls.RichTextEditor();
            this.approvalsGridControl = new Com.Suncor.Olt.Client.Controls.ApprovalsGridControl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.oltPanel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.createdByGroupBox.SuspendLayout();
            this.lastModifiedGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.documentLinksGroupBox.SuspendLayout();
            this.functionalLocationGroupBox.SuspendLayout();
            this.oltGroupBox3.SuspendLayout();
            this.contentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(461, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save && Close";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(671, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.waitingapprovalButton);
            this.oltPanel1.Controls.Add(this.saveAndEmailButton);
            this.oltPanel1.Controls.Add(this.cancelButton);
            this.oltPanel1.Controls.Add(this.saveButton);
            this.oltPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.oltPanel1.Location = new System.Drawing.Point(0, 590);
            this.oltPanel1.Name = "oltPanel1";
            this.oltPanel1.Size = new System.Drawing.Size(786, 47);
            this.oltPanel1.TabIndex = 1;
            // 
            // waitingapprovalButton
            // 
            this.waitingapprovalButton.Location = new System.Drawing.Point(325, 12);
            this.waitingapprovalButton.Name = "waitingapprovalButton";
            this.waitingapprovalButton.Size = new System.Drawing.Size(130, 23);
            this.waitingapprovalButton.TabIndex = 3;
            this.waitingapprovalButton.Text = "Approve and Save";        //ayman changed as per Aditya email on June 9/ 2017
            this.waitingapprovalButton.UseVisualStyleBackColor = true;
            // 
            // saveAndEmailButton
            // 
            this.saveAndEmailButton.Location = new System.Drawing.Point(566, 12);
            this.saveAndEmailButton.Name = "saveAndEmailButton";
            this.saveAndEmailButton.Size = new System.Drawing.Size(99, 23);
            this.saveAndEmailButton.TabIndex = 2;
            this.saveAndEmailButton.Text = "Save && Email";
            this.saveAndEmailButton.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.invisibleLabel);
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Controls.Add(this.tableLayoutPanel2);
            this.mainPanel.Controls.Add(this.contentGroupBox);
            this.mainPanel.Controls.Add(this.approvalsGridControl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(786, 590);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.WrapContents = false;
            // 
            // invisibleLabel
            // 
            this.invisibleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.invisibleLabel.Location = new System.Drawing.Point(3, 0);
            this.invisibleLabel.Name = "invisibleLabel";
            this.invisibleLabel.Size = new System.Drawing.Size(743, 10);
            this.invisibleLabel.TabIndex = 0;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 13);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(738, 83);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // createdByGroupBox
            // 
            this.createdByGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createdByGroupBox.Controls.Add(this.createdByUserLabel);
            this.createdByGroupBox.Controls.Add(this.createdDateLabel);
            this.createdByGroupBox.Controls.Add(this.oltLabel1);
            this.createdByGroupBox.Controls.Add(this.dateLabel);
            this.createdByGroupBox.Location = new System.Drawing.Point(3, 3);
            this.createdByGroupBox.Name = "createdByGroupBox";
            this.createdByGroupBox.Size = new System.Drawing.Size(363, 75);
            this.createdByGroupBox.TabIndex = 0;
            this.createdByGroupBox.TabStop = false;
            this.createdByGroupBox.Text = "Created By";
            // 
            // createdByUserLabel
            // 
            this.createdByUserLabel.AutoSize = true;
            this.createdByUserLabel.Location = new System.Drawing.Point(45, 48);
            this.createdByUserLabel.Name = "createdByUserLabel";
            this.createdByUserLabel.Size = new System.Drawing.Size(91, 13);
            this.createdByUserLabel.TabIndex = 3;
            this.createdByUserLabel.Text = "[created by user]";
            // 
            // createdDateLabel
            // 
            this.createdDateLabel.AutoSize = true;
            this.createdDateLabel.Location = new System.Drawing.Point(46, 23);
            this.createdDateLabel.Name = "createdDateLabel";
            this.createdDateLabel.Size = new System.Drawing.Size(77, 13);
            this.createdDateLabel.TabIndex = 1;
            this.createdDateLabel.Text = "[created date]";
            // 
            // oltLabel1
            // 
            this.oltLabel1.AutoSize = true;
            this.oltLabel1.Location = new System.Drawing.Point(6, 48);
            this.oltLabel1.Name = "oltLabel1";
            this.oltLabel1.Size = new System.Drawing.Size(33, 13);
            this.oltLabel1.TabIndex = 2;
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
            this.lastModifiedGroupBox.Controls.Add(this.lastModifiedUserLabel);
            this.lastModifiedGroupBox.Controls.Add(this.lastModifiedDateLabel);
            this.lastModifiedGroupBox.Controls.Add(this.oltLabel3);
            this.lastModifiedGroupBox.Controls.Add(this.oltLabel2);
            this.lastModifiedGroupBox.Location = new System.Drawing.Point(372, 3);
            this.lastModifiedGroupBox.Name = "lastModifiedGroupBox";
            this.lastModifiedGroupBox.Size = new System.Drawing.Size(363, 75);
            this.lastModifiedGroupBox.TabIndex = 1;
            this.lastModifiedGroupBox.TabStop = false;
            this.lastModifiedGroupBox.Text = "Last Modified";
            // 
            // lastModifiedUserLabel
            // 
            this.lastModifiedUserLabel.AutoSize = true;
            this.lastModifiedUserLabel.Location = new System.Drawing.Point(46, 48);
            this.lastModifiedUserLabel.Name = "lastModifiedUserLabel";
            this.lastModifiedUserLabel.Size = new System.Drawing.Size(99, 13);
            this.lastModifiedUserLabel.TabIndex = 3;
            this.lastModifiedUserLabel.Text = "[last modified user]";
            // 
            // lastModifiedDateLabel
            // 
            this.lastModifiedDateLabel.AutoSize = true;
            this.lastModifiedDateLabel.Location = new System.Drawing.Point(46, 23);
            this.lastModifiedDateLabel.Name = "lastModifiedDateLabel";
            this.lastModifiedDateLabel.Size = new System.Drawing.Size(100, 13);
            this.lastModifiedDateLabel.TabIndex = 1;
            this.lastModifiedDateLabel.Text = "[last modified date]";
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
            this.oltLabel2.TabIndex = 0;
            this.oltLabel2.Text = "Date:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.28455F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.71545F));
            this.tableLayoutPanel2.Controls.Add(this.documentLinksGroupBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.functionalLocationGroupBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.oltGroupBox3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 102);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(738, 217);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // documentLinksGroupBox
            // 
            this.documentLinksGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.documentLinksGroupBox, 2);
            this.documentLinksGroupBox.Controls.Add(this.documentLinksControl);
            this.documentLinksGroupBox.Location = new System.Drawing.Point(402, 111);
            this.documentLinksGroupBox.Name = "documentLinksGroupBox";
            this.documentLinksGroupBox.Size = new System.Drawing.Size(333, 103);
            this.documentLinksGroupBox.TabIndex = 2;
            this.documentLinksGroupBox.TabStop = false;
            this.documentLinksGroupBox.Text = "Document Links";
            // 
            // documentLinksControl
            // 
            this.documentLinksControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentLinksControl.DataSource = null;
            this.documentLinksControl.Location = new System.Drawing.Point(6, 20);
            this.documentLinksControl.Name = "documentLinksControl";
            this.documentLinksControl.ReadOnlyList = true;
            this.documentLinksControl.Size = new System.Drawing.Size(312, 74);
            this.documentLinksControl.TabIndex = 0;
            // 
            // functionalLocationGroupBox
            // 
            this.functionalLocationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionalLocationGroupBox.Controls.Add(this.removeFunctionalLocatnButton);
            this.functionalLocationGroupBox.Controls.Add(this.functionalLocationListBox);
            this.functionalLocationGroupBox.Controls.Add(this.addFunctionalLocationButton);
            this.functionalLocationGroupBox.Location = new System.Drawing.Point(3, 3);
            this.functionalLocationGroupBox.Name = "functionalLocationGroupBox";
            this.functionalLocationGroupBox.Size = new System.Drawing.Size(401, 102);
            this.functionalLocationGroupBox.TabIndex = 0;
            this.functionalLocationGroupBox.TabStop = false;
            this.functionalLocationGroupBox.Text = "Functional Locations";
            // 
            // removeFunctionalLocatnButton
            // 
            this.removeFunctionalLocatnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeFunctionalLocatnButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.removeFunctionalLocatnButton.Location = new System.Drawing.Point(304, 54);
            this.removeFunctionalLocatnButton.Name = "removeFunctionalLocatnButton";
            this.removeFunctionalLocatnButton.Size = new System.Drawing.Size(91, 23);
            this.removeFunctionalLocatnButton.TabIndex = 2;
            this.removeFunctionalLocatnButton.Text = "Remove";
            this.removeFunctionalLocatnButton.UseVisualStyleBackColor = true;
            // 
            // functionalLocationListBox
            // 
            this.functionalLocationListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionalLocationListBox.Location = new System.Drawing.Point(6, 20);
            this.functionalLocationListBox.Name = "functionalLocationListBox";
            this.functionalLocationListBox.ReadOnly = false;
            this.functionalLocationListBox.Size = new System.Drawing.Size(277, 69);
            this.functionalLocationListBox.TabIndex = 0;
            // 
            // addFunctionalLocationButton
            // 
            this.addFunctionalLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addFunctionalLocationButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addFunctionalLocationButton.Location = new System.Drawing.Point(304, 25);
            this.addFunctionalLocationButton.Name = "addFunctionalLocationButton";
            this.addFunctionalLocationButton.Size = new System.Drawing.Size(91, 23);
            this.addFunctionalLocationButton.TabIndex = 1;
            this.addFunctionalLocationButton.Text = "Add...";
            this.addFunctionalLocationButton.UseVisualStyleBackColor = true;
            // 
            // oltGroupBox3
            // 
            this.oltGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oltGroupBox3.Controls.Add(this.toLabel);
            this.oltGroupBox3.Controls.Add(this.fromLabel);
            this.oltGroupBox3.Controls.Add(this.validToTimePicker);
            this.oltGroupBox3.Controls.Add(this.validFromTimePicker);
            this.oltGroupBox3.Controls.Add(this.validToDatePicker);
            this.oltGroupBox3.Controls.Add(this.validFromDatePicker);
            this.oltGroupBox3.Location = new System.Drawing.Point(410, 3);
            this.oltGroupBox3.Name = "oltGroupBox3";
            this.oltGroupBox3.Size = new System.Drawing.Size(325, 102);
            this.oltGroupBox3.TabIndex = 1;
            this.oltGroupBox3.TabStop = false;
            this.oltGroupBox3.Text = "Valid";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(7, 58);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(23, 13);
            this.toLabel.TabIndex = 7;
            this.toLabel.Text = "To:";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(7, 29);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(35, 13);
            this.fromLabel.TabIndex = 6;
            this.fromLabel.Text = "From:";
            // 
            // validToTimePicker
            // 
            this.validToTimePicker.Checked = true;
            this.validToTimePicker.CustomFormat = "HH:mm";
            this.validToTimePicker.Location = new System.Drawing.Point(187, 54);
            this.validToTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.validToTimePicker.Name = "validToTimePicker";
            this.validToTimePicker.ShowCheckBox = false;
            this.validToTimePicker.Size = new System.Drawing.Size(60, 21);
            this.validToTimePicker.TabIndex = 5;
            // 
            // validFromTimePicker
            // 
            this.validFromTimePicker.Checked = true;
            this.validFromTimePicker.CustomFormat = "HH:mm";
            this.validFromTimePicker.Location = new System.Drawing.Point(187, 24);
            this.validFromTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.validFromTimePicker.Name = "validFromTimePicker";
            this.validFromTimePicker.ShowCheckBox = false;
            this.validFromTimePicker.Size = new System.Drawing.Size(60, 21);
            this.validFromTimePicker.TabIndex = 2;
            // 
            // validToDatePicker
            // 
            this.validToDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.validToDatePicker.Location = new System.Drawing.Point(45, 54);
            this.validToDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.validToDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.validToDatePicker.Name = "validToDatePicker";
            this.validToDatePicker.PickerEnabled = true;
            this.validToDatePicker.Size = new System.Drawing.Size(132, 21);
            this.validToDatePicker.TabIndex = 4;
            // 
            // validFromDatePicker
            // 
            this.validFromDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.validFromDatePicker.Location = new System.Drawing.Point(45, 24);
            this.validFromDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.validFromDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.validFromDatePicker.Name = "validFromDatePicker";
            this.validFromDatePicker.PickerEnabled = true;
            this.validFromDatePicker.Size = new System.Drawing.Size(132, 21);
            this.validFromDatePicker.TabIndex = 1;
            // 
            // contentGroupBox
            // 
            this.contentGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentGroupBox.Controls.Add(this.expandLinkLabel);
            this.contentGroupBox.Controls.Add(this.contentRichTextEditor);
            this.contentGroupBox.Location = new System.Drawing.Point(11, 322);
            this.contentGroupBox.Margin = new System.Windows.Forms.Padding(11, 0, 3, 3);
            this.contentGroupBox.Name = "contentGroupBox";
            this.contentGroupBox.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.contentGroupBox.Size = new System.Drawing.Size(735, 216);
            this.contentGroupBox.TabIndex = 3;
            this.contentGroupBox.TabStop = false;
            // 
            // expandLinkLabel
            // 
            this.expandLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expandLinkLabel.AutoSize = true;
            this.expandLinkLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.expandLinkLabel.Location = new System.Drawing.Point(678, 9);
            this.expandLinkLabel.Name = "expandLinkLabel";
            this.expandLinkLabel.Size = new System.Drawing.Size(51, 13);
            this.expandLinkLabel.TabIndex = 1;
            this.expandLinkLabel.TabStop = true;
            this.expandLinkLabel.Text = "[Expand]";
            // 
            // contentRichTextEditor
            // 
            this.contentRichTextEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentRichTextEditor.Location = new System.Drawing.Point(6, 25);
            this.contentRichTextEditor.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.contentRichTextEditor.Name = "contentRichTextEditor";
            this.contentRichTextEditor.ReadOnly = false;
            this.contentRichTextEditor.Size = new System.Drawing.Size(723, 185);
            this.contentRichTextEditor.TabIndex = 0;
            // 
            // approvalsGridControl
            // 
            this.approvalsGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.approvalsGridControl.GroupBoxLabel = "Approvals";
            this.approvalsGridControl.Location = new System.Drawing.Point(11, 544);
            this.approvalsGridControl.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.approvalsGridControl.Name = "approvalsGridControl";
            this.approvalsGridControl.Size = new System.Drawing.Size(735, 123);
            this.approvalsGridControl.TabIndex = 6;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(786, 637);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.oltPanel1);
            this.MaximumSize = new System.Drawing.Size(1000, 675);
            this.MinimumSize = new System.Drawing.Size(794, 675);
            this.Name = "FormForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form";
            this.oltPanel1.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.createdByGroupBox.ResumeLayout(false);
            this.createdByGroupBox.PerformLayout();
            this.lastModifiedGroupBox.ResumeLayout(false);
            this.lastModifiedGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.documentLinksGroupBox.ResumeLayout(false);
            this.functionalLocationGroupBox.ResumeLayout(false);
            this.oltGroupBox3.ResumeLayout(false);
            this.oltGroupBox3.PerformLayout();
            this.contentGroupBox.ResumeLayout(false);
            this.contentGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private OltControls.OltPanel oltPanel1;
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private OltControls.OltGroupBox createdByGroupBox;
        private OltControls.OltGroupBox lastModifiedGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OltControls.OltLabel invisibleLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private OltControls.OltGroupBox functionalLocationGroupBox;
        private OltControls.OltButton removeFunctionalLocatnButton;
        private Controls.FunctionalLocationListBox functionalLocationListBox;
        private OltControls.OltButton addFunctionalLocationButton;
        private OltControls.OltGroupBox oltGroupBox3;
        private OltControls.OltTimePicker validToTimePicker;
        private OltControls.OltTimePicker validFromTimePicker;
        private OltControls.OltDatePicker validToDatePicker;
        private OltControls.OltDatePicker validFromDatePicker;
        private Controls.RichTextEditor contentRichTextEditor;
        private OltControls.OltLabel oltLabel1;
        private OltControls.OltLabel dateLabel;
        private OltControls.OltLabel oltLabel3;
        private OltControls.OltLabel oltLabel2;
        private OltControls.OltLinkLabel1 expandLinkLabel;
        private OltControls.OltLabel createdByUserLabel;
        private OltControls.OltLabel createdDateLabel;
        private OltControls.OltLabel lastModifiedUserLabel;
        private OltControls.OltLabel lastModifiedDateLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltControls.OltGroupBox contentGroupBox;
        private System.Windows.Forms.Button saveAndEmailButton;
        private OltControls.OltLabel toLabel;
        private OltControls.OltLabel fromLabel;
        private Controls.ApprovalsGridControl approvalsGridControl;
        private OltControls.OltGroupBox documentLinksGroupBox;
        private Controls.DocumentLinksControl documentLinksControl;
        private System.Windows.Forms.Button waitingapprovalButton;
    }
}