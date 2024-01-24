using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ShiftHandoverQuestionnaireForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftHandoverQuestionnaireForm));
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup5 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.shiftGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.shiftLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.lastModifiedDateAuthorHeader = new Com.Suncor.Olt.Client.OltControls.OltLastModifiedDateAuthorHeader();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.oltLabelLine1 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.functionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.removeFunctionalLocationButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.functionalLocationListBox = new Com.Suncor.Olt.Client.Controls.FunctionalLocationListBox();
            this.addFunctionalLocationButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.handoverTypeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.endDateTimeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.ShiftEndDatePickerDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.startDateTimeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.ShiftStartDateDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.FlextShiftHandover_ChkBox = new System.Windows.Forms.CheckBox();
            this.handoverTypeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.FlexiShiftHandoverGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.logLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.ultraExplorerBarContainerControl5 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.richTextCommentDisplay = new Com.Suncor.Olt.Client.Controls.RichTextDisplay();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.viewEditHistoryButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.chkActiveCsdLog = new System.Windows.Forms.CheckBox();
            this.selectShiftLogMessages = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.explorerBar = new Com.Suncor.Olt.Client.OltControls.OltExplorerBar();
            this.functionLocationBlankErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            this.shiftGroupBox.SuspendLayout();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            this.ultraExplorerBarContainerControl2.SuspendLayout();
            this.functionalLocationGroupBox.SuspendLayout();
            this.handoverTypeGroupBox.SuspendLayout();
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            this.ultraExplorerBarContainerControl5.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.explorerBar)).BeginInit();
            this.explorerBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.functionLocationBlankErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.shiftGroupBox);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.lastModifiedDateAuthorHeader);
            resources.ApplyResources(this.ultraExplorerBarContainerControl1, "ultraExplorerBarContainerControl1");
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            // 
            // shiftGroupBox
            // 
            resources.ApplyResources(this.shiftGroupBox, "shiftGroupBox");
            this.shiftGroupBox.Controls.Add(this.shiftLabelData);
            this.shiftGroupBox.Name = "shiftGroupBox";
            this.shiftGroupBox.TabStop = false;
            // 
            // shiftLabelData
            // 
            resources.ApplyResources(this.shiftLabelData, "shiftLabelData");
            this.shiftLabelData.Name = "shiftLabelData";
            this.shiftLabelData.UseMnemonic = false;
            // 
            // lastModifiedDateAuthorHeader
            // 
            resources.ApplyResources(this.lastModifiedDateAuthorHeader, "lastModifiedDateAuthorHeader");
            this.lastModifiedDateAuthorHeader.LastModifiedDate = new System.DateTime(((long)(0)));
            this.lastModifiedDateAuthorHeader.Name = "lastModifiedDateAuthorHeader";
            this.lastModifiedDateAuthorHeader.TabStop = false;
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.oltLabelLine1);
            resources.ApplyResources(this.ultraExplorerBarContainerControl3, "ultraExplorerBarContainerControl3");
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            // 
            // oltLabelLine1
            // 
            resources.ApplyResources(this.oltLabelLine1, "oltLabelLine1");
            this.oltLabelLine1.Name = "oltLabelLine1";
            this.oltLabelLine1.TabStop = false;
            // 
            // ultraExplorerBarContainerControl2
            // 
            this.ultraExplorerBarContainerControl2.Controls.Add(this.functionalLocationGroupBox);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.handoverTypeGroupBox);
            resources.ApplyResources(this.ultraExplorerBarContainerControl2, "ultraExplorerBarContainerControl2");
            this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
            // 
            // functionalLocationGroupBox
            // 
            resources.ApplyResources(this.functionalLocationGroupBox, "functionalLocationGroupBox");
            this.functionalLocationGroupBox.Controls.Add(this.removeFunctionalLocationButton);
            this.functionalLocationGroupBox.Controls.Add(this.functionalLocationListBox);
            this.functionalLocationGroupBox.Controls.Add(this.addFunctionalLocationButton);
            this.functionalLocationGroupBox.Name = "functionalLocationGroupBox";
            this.functionalLocationGroupBox.TabStop = false;
            // 
            // removeFunctionalLocationButton
            // 
            resources.ApplyResources(this.removeFunctionalLocationButton, "removeFunctionalLocationButton");
            this.removeFunctionalLocationButton.Name = "removeFunctionalLocationButton";
            this.removeFunctionalLocationButton.UseVisualStyleBackColor = true;
            // 
            // functionalLocationListBox
            // 
            resources.ApplyResources(this.functionalLocationListBox, "functionalLocationListBox");
            this.functionalLocationListBox.Name = "functionalLocationListBox";
            this.functionalLocationListBox.ReadOnly = false;
            // 
            // addFunctionalLocationButton
            // 
            resources.ApplyResources(this.addFunctionalLocationButton, "addFunctionalLocationButton");
            this.addFunctionalLocationButton.Name = "addFunctionalLocationButton";
            this.addFunctionalLocationButton.UseVisualStyleBackColor = true;
            // 
            // handoverTypeGroupBox
            // 
            this.handoverTypeGroupBox.Controls.Add(this.endDateTimeLabel);
            this.handoverTypeGroupBox.Controls.Add(this.ShiftEndDatePickerDatePicker);
            this.handoverTypeGroupBox.Controls.Add(this.startDateTimeLabel);
            this.handoverTypeGroupBox.Controls.Add(this.ShiftStartDateDatePicker);
            this.handoverTypeGroupBox.Controls.Add(this.FlextShiftHandover_ChkBox);
            this.handoverTypeGroupBox.Controls.Add(this.handoverTypeComboBox);
            this.handoverTypeGroupBox.Controls.Add(this.FlexiShiftHandoverGroupBox);
            resources.ApplyResources(this.handoverTypeGroupBox, "handoverTypeGroupBox");
            this.handoverTypeGroupBox.Name = "handoverTypeGroupBox";
            this.handoverTypeGroupBox.TabStop = false;
            // 
            // endDateTimeLabel
            // 
            resources.ApplyResources(this.endDateTimeLabel, "endDateTimeLabel");
            this.endDateTimeLabel.Name = "endDateTimeLabel";
            // 
            // ShiftEndDatePickerDatePicker
            // 
            this.ShiftEndDatePickerDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.ShiftEndDatePickerDatePicker, "ShiftEndDatePickerDatePicker");
            this.ShiftEndDatePickerDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ShiftEndDatePickerDatePicker.Name = "ShiftEndDatePickerDatePicker";
            this.ShiftEndDatePickerDatePicker.PickerEnabled = true;
            // 
            // startDateTimeLabel
            // 
            resources.ApplyResources(this.startDateTimeLabel, "startDateTimeLabel");
            this.startDateTimeLabel.Name = "startDateTimeLabel";
            // 
            // ShiftStartDateDatePicker
            // 
            this.ShiftStartDateDatePicker.AllowDrop = true;
            this.ShiftStartDateDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.ShiftStartDateDatePicker, "ShiftStartDateDatePicker");
            this.ShiftStartDateDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ShiftStartDateDatePicker.Name = "ShiftStartDateDatePicker";
            this.ShiftStartDateDatePicker.PickerEnabled = true;
            // 
            // FlextShiftHandover_ChkBox
            // 
            resources.ApplyResources(this.FlextShiftHandover_ChkBox, "FlextShiftHandover_ChkBox");
            this.FlextShiftHandover_ChkBox.Name = "FlextShiftHandover_ChkBox";
            this.FlextShiftHandover_ChkBox.UseVisualStyleBackColor = true;
            // 
            // handoverTypeComboBox
            // 
            this.handoverTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.handoverTypeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.handoverTypeComboBox, "handoverTypeComboBox");
            this.handoverTypeComboBox.Name = "handoverTypeComboBox";
            // 
            // FlexiShiftHandoverGroupBox
            // 
            resources.ApplyResources(this.FlexiShiftHandoverGroupBox, "FlexiShiftHandoverGroupBox");
            this.FlexiShiftHandoverGroupBox.Name = "FlexiShiftHandoverGroupBox";
            this.FlexiShiftHandoverGroupBox.TabStop = false;
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.logLine);
            resources.ApplyResources(this.ultraExplorerBarContainerControl4, "ultraExplorerBarContainerControl4");
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            // 
            // logLine
            // 
            resources.ApplyResources(this.logLine, "logLine");
            this.logLine.Name = "logLine";
            this.logLine.TabStop = false;
            // 
            // ultraExplorerBarContainerControl5
            // 
            this.ultraExplorerBarContainerControl5.Controls.Add(this.richTextCommentDisplay);
            resources.ApplyResources(this.ultraExplorerBarContainerControl5, "ultraExplorerBarContainerControl5");
            this.ultraExplorerBarContainerControl5.Name = "ultraExplorerBarContainerControl5";
            // 
            // richTextCommentDisplay
            // 
            this.richTextCommentDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.richTextCommentDisplay, "richTextCommentDisplay");
            this.richTextCommentDisplay.Name = "richTextCommentDisplay";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // viewEditHistoryButton
            // 
            resources.ApplyResources(this.viewEditHistoryButton, "viewEditHistoryButton");
            this.viewEditHistoryButton.Name = "viewEditHistoryButton";
            this.viewEditHistoryButton.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.chkActiveCsdLog);
            this.buttonPanel.Controls.Add(this.selectShiftLogMessages);
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.viewEditHistoryButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // chkActiveCsdLog
            // 
            resources.ApplyResources(this.chkActiveCsdLog, "chkActiveCsdLog");
            this.chkActiveCsdLog.Name = "chkActiveCsdLog";
            this.chkActiveCsdLog.UseVisualStyleBackColor = true;
            this.chkActiveCsdLog.Text = StringResources.ChkCSDText;
            // 
            // selectShiftLogMessages
            // 
            resources.ApplyResources(this.selectShiftLogMessages, "selectShiftLogMessages");
            this.selectShiftLogMessages.Name = "selectShiftLogMessages";
            this.selectShiftLogMessages.UseVisualStyleBackColor = true;
            this.selectShiftLogMessages.Click += new System.EventHandler(this.selectShiftLogMessages_Click);
            // 
            // explorerBar
            // 
            this.explorerBar.AnimationEnabled = false;
            this.explorerBar.AutoScrollStyle = Infragistics.Win.UltraWinExplorerBar.AutoScrollStyle.BringActiveControlIntoView;
            this.explorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.explorerBar.ColumnSpacing = 0;
            this.explorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.explorerBar.Controls.Add(this.ultraExplorerBarContainerControl2);
            this.explorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.explorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            this.explorerBar.Controls.Add(this.ultraExplorerBarContainerControl5);
            resources.ApplyResources(this.explorerBar, "explorerBar");
            ultraExplorerBarGroup4.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup4.Settings.ContainerHeight = 50;
            ultraExplorerBarGroup4.Settings.HeaderVisible = Infragistics.Win.DefaultableBoolean.False;
            resources.ApplyResources(ultraExplorerBarGroup4, "ultraExplorerBarGroup4");
            ultraExplorerBarGroup4.ForceApplyResources = "";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 16;
            ultraExplorerBarGroup2.Settings.HeaderVisible = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Settings.ItemAreaInnerMargins.Left = 5;
            ultraExplorerBarGroup2.Settings.ItemAreaInnerMargins.Right = 5;
            resources.ApplyResources(ultraExplorerBarGroup2, "ultraExplorerBarGroup2");
            ultraExplorerBarGroup2.ForceApplyResources = "";
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl2;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 138;
            ultraExplorerBarGroup1.Settings.HeaderVisible = Infragistics.Win.DefaultableBoolean.False;
            resources.ApplyResources(ultraExplorerBarGroup1, "ultraExplorerBarGroup1");
            ultraExplorerBarGroup1.ForceApplyResources = "";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 16;
            ultraExplorerBarGroup3.Settings.HeaderVisible = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Settings.ItemAreaInnerMargins.Left = 5;
            ultraExplorerBarGroup3.Settings.ItemAreaInnerMargins.Right = 5;
            resources.ApplyResources(ultraExplorerBarGroup3, "ultraExplorerBarGroup3");
            ultraExplorerBarGroup3.ForceApplyResources = "";
            ultraExplorerBarGroup5.Container = this.ultraExplorerBarContainerControl5;
            ultraExplorerBarGroup5.Settings.ContainerHeight = 374;
            ultraExplorerBarGroup5.Settings.HeaderVisible = Infragistics.Win.DefaultableBoolean.False;
            resources.ApplyResources(ultraExplorerBarGroup5, "ultraExplorerBarGroup5");
            ultraExplorerBarGroup5.ForceApplyResources = "";
            this.explorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup4,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup3,
            ultraExplorerBarGroup5});
            this.explorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.explorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            this.explorerBar.GroupSettings.AllowItemDrop = Infragistics.Win.DefaultableBoolean.False;
            this.explorerBar.GroupSettings.AllowItemUncheck = Infragistics.Win.DefaultableBoolean.False;
            appearance1.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(appearance1.FontData, "appearance1.FontData");
            appearance1.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(appearance1, "appearance1");
            appearance1.ForceApplyResources = "FontData|";
            this.explorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance1;
            this.explorerBar.GroupSettings.HeaderButtonStyle = Infragistics.Win.UIElementButtonStyle.ButtonSoft;
            this.explorerBar.GroupSettings.ItemAreaInnerMargins.Left = 30;
            this.explorerBar.GroupSettings.ItemAreaInnerMargins.Right = 30;
            this.explorerBar.GroupSettings.NavigationAllowHide = Infragistics.Win.DefaultableBoolean.False;
            this.explorerBar.GroupSettings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            this.explorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.explorerBar.GroupSpacing = 0;
            this.explorerBar.Name = "explorerBar";
            this.explorerBar.NavigationAllowGroupReorder = false;
            appearance2.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            resources.ApplyResources(appearance2.FontData, "appearance2.FontData");
            resources.ApplyResources(appearance2, "appearance2");
            appearance2.ForceApplyResources = "FontData|";
            scrollBarLook1.Appearance = appearance2;
            this.explorerBar.ScrollBarLook = scrollBarLook1;
            this.explorerBar.ShowDefaultContextMenu = false;
            this.explorerBar.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.VisualStudio2005Toolbox;
            this.explorerBar.TabStop = false;
            this.explorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2000;
            // 
            // functionLocationBlankErrorProvider
            // 
            this.functionLocationBlankErrorProvider.ContainerControl = this;
            // 
            // ShiftHandoverQuestionnaireForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.explorerBar);
            this.Controls.Add(this.buttonPanel);
            this.Name = "ShiftHandoverQuestionnaireForm";
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.shiftGroupBox.ResumeLayout(false);
            this.shiftGroupBox.PerformLayout();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            this.ultraExplorerBarContainerControl2.ResumeLayout(false);
            this.functionalLocationGroupBox.ResumeLayout(false);
            this.handoverTypeGroupBox.ResumeLayout(false);
            this.handoverTypeGroupBox.PerformLayout();
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl5.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.explorerBar)).EndInit();
            this.explorerBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.functionLocationBlankErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton cancelButton;
        private OltButton saveButton;
        private OltButton viewEditHistoryButton;
        private ToolTip toolTip;
        private OltGroupBox handoverTypeGroupBox;
        private OltComboBox handoverTypeComboBox;
        private Panel buttonPanel;
        private OltExplorerBar explorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private OltGroupBox functionalLocationGroupBox;
        private OltButton removeFunctionalLocationButton;
        private FunctionalLocationListBox functionalLocationListBox;
        private OltButton addFunctionalLocationButton;
        private ErrorProvider functionLocationBlankErrorProvider;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
        private OltLabelLine oltLabelLine1;
        private OltLastModifiedDateAuthorHeader lastModifiedDateAuthorHeader;
        private OltGroupBox shiftGroupBox;
        private OltLabelData shiftLabelData;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl5;
        private OltLabelLine logLine;
        private RichTextDisplay richTextCommentDisplay;
        private CheckBox FlextShiftHandover_ChkBox;
        private OltLabel endDateTimeLabel;
        private OltDatePicker ShiftEndDatePickerDatePicker;
        private OltLabel startDateTimeLabel;
        private OltDatePicker ShiftStartDateDatePicker;
        private OltGroupBox FlexiShiftHandoverGroupBox;
        private OltButton selectShiftLogMessages;
        private CheckBox chkActiveCsdLog;

    }
}
