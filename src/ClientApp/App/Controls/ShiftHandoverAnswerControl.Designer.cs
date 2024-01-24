using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class ShiftHandoverAnswerControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftHandoverAnswerControl));
            this.yesNoErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.commentsErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bottomPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.textBoxPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.commentsTextBox = new Com.Suncor.Olt.Client.OltControls.OltSpellCheckTextBox(this.components);
            this.errorProviderPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.errorProviderBindingControl = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.commentsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.commentsLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.helpTextLinkLabel = new Com.Suncor.Olt.Client.OltControls.OltLinkLabel();
            this.questionNumberLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.questionTextLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.radioPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.noRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.yesRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.yesNoErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentsErrorProvider)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.textBoxPanel.SuspendLayout();
            this.errorProviderPanel.SuspendLayout();
            this.commentsPanel.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.radioPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // yesNoErrorProvider
            // 
            this.yesNoErrorProvider.ContainerControl = this;
            // 
            // commentsErrorProvider
            // 
            this.commentsErrorProvider.ContainerControl = this;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.textBoxPanel);
            this.bottomPanel.Controls.Add(this.errorProviderPanel);
            this.bottomPanel.Controls.Add(this.commentsPanel);
            resources.ApplyResources(this.bottomPanel, "bottomPanel");
            this.commentsErrorProvider.SetIconAlignment(this.bottomPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("bottomPanel.IconAlignment"))));
            this.yesNoErrorProvider.SetIconAlignment(this.bottomPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("bottomPanel.IconAlignment1"))));
            this.bottomPanel.Name = "bottomPanel";
            // 
            // textBoxPanel
            // 
            this.textBoxPanel.Controls.Add(this.commentsTextBox);
            resources.ApplyResources(this.textBoxPanel, "textBoxPanel");
            this.commentsErrorProvider.SetIconAlignment(this.textBoxPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textBoxPanel.IconAlignment"))));
            this.yesNoErrorProvider.SetIconAlignment(this.textBoxPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textBoxPanel.IconAlignment1"))));
            this.textBoxPanel.Name = "textBoxPanel";
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.AcceptsTabAndReturn = false;
            resources.ApplyResources(this.commentsTextBox, "commentsTextBox");
            this.yesNoErrorProvider.SetIconAlignment(this.commentsTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("commentsTextBox.IconAlignment"))));
            this.commentsErrorProvider.SetIconAlignment(this.commentsTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("commentsTextBox.IconAlignment1"))));
            this.commentsTextBox.MaxLength = 1024;
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.OltTrimWhitespace = false;
            this.commentsTextBox.ReadOnly = false;
            this.commentsTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            // 
            // errorProviderPanel
            // 
            this.errorProviderPanel.Controls.Add(this.errorProviderBindingControl);
            resources.ApplyResources(this.errorProviderPanel, "errorProviderPanel");
            this.commentsErrorProvider.SetIconAlignment(this.errorProviderPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("errorProviderPanel.IconAlignment"))));
            this.yesNoErrorProvider.SetIconAlignment(this.errorProviderPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("errorProviderPanel.IconAlignment1"))));
            this.errorProviderPanel.Name = "errorProviderPanel";
            // 
            // errorProviderBindingControl
            // 
            resources.ApplyResources(this.errorProviderBindingControl, "errorProviderBindingControl");
            this.commentsErrorProvider.SetIconAlignment(this.errorProviderBindingControl, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("errorProviderBindingControl.IconAlignment"))));
            this.yesNoErrorProvider.SetIconAlignment(this.errorProviderBindingControl, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("errorProviderBindingControl.IconAlignment1"))));
            this.errorProviderBindingControl.Name = "errorProviderBindingControl";
            // 
            // commentsPanel
            // 
            resources.ApplyResources(this.commentsPanel, "commentsPanel");
            this.commentsPanel.Controls.Add(this.commentsLabel);
            this.commentsErrorProvider.SetIconAlignment(this.commentsPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("commentsPanel.IconAlignment"))));
            this.yesNoErrorProvider.SetIconAlignment(this.commentsPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("commentsPanel.IconAlignment1"))));
            this.commentsPanel.Name = "commentsPanel";
            // 
            // commentsLabel
            // 
            resources.ApplyResources(this.commentsLabel, "commentsLabel");
            this.commentsErrorProvider.SetIconAlignment(this.commentsLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("commentsLabel.IconAlignment"))));
            this.yesNoErrorProvider.SetIconAlignment(this.commentsLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("commentsLabel.IconAlignment1"))));
            this.commentsLabel.Name = "commentsLabel";
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.oltPanel1, "oltPanel1");
            this.commentsErrorProvider.SetIconAlignment(this.oltPanel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltPanel1.IconAlignment"))));
            this.yesNoErrorProvider.SetIconAlignment(this.oltPanel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltPanel1.IconAlignment1"))));
            this.oltPanel1.Name = "oltPanel1";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.helpTextLinkLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.questionNumberLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.questionTextLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioPanel, 2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // helpTextLinkLabel
            // 
            this.helpTextLinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(71)))), ((int)(((byte)(163)))));
            resources.ApplyResources(this.helpTextLinkLabel, "helpTextLinkLabel");
            this.commentsErrorProvider.SetIconAlignment(this.helpTextLinkLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("helpTextLinkLabel.IconAlignment"))));
            this.yesNoErrorProvider.SetIconAlignment(this.helpTextLinkLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("helpTextLinkLabel.IconAlignment1"))));
            this.helpTextLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(71)))), ((int)(((byte)(163)))));
            this.helpTextLinkLabel.Name = "helpTextLinkLabel";
            this.helpTextLinkLabel.TabStop = true;
            this.helpTextLinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(71)))), ((int)(((byte)(163)))));
            // 
            // questionNumberLabel
            // 
            this.commentsErrorProvider.SetIconAlignment(this.questionNumberLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("questionNumberLabel.IconAlignment"))));
            this.yesNoErrorProvider.SetIconAlignment(this.questionNumberLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("questionNumberLabel.IconAlignment1"))));
            resources.ApplyResources(this.questionNumberLabel, "questionNumberLabel");
            this.questionNumberLabel.Name = "questionNumberLabel";
            // 
            // questionTextLabel
            // 
            resources.ApplyResources(this.questionTextLabel, "questionTextLabel");
            this.commentsErrorProvider.SetIconAlignment(this.questionTextLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("questionTextLabel.IconAlignment"))));
            this.yesNoErrorProvider.SetIconAlignment(this.questionTextLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("questionTextLabel.IconAlignment1"))));
            this.questionTextLabel.Name = "questionTextLabel";
            this.questionTextLabel.UseMnemonic = false;
            // 
            // radioPanel
            // 
            resources.ApplyResources(this.radioPanel, "radioPanel");
            this.radioPanel.Controls.Add(this.noRadioButton);
            this.radioPanel.Controls.Add(this.yesRadioButton);
            this.yesNoErrorProvider.SetIconAlignment(this.radioPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("radioPanel.IconAlignment"))));
            this.commentsErrorProvider.SetIconAlignment(this.radioPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("radioPanel.IconAlignment1"))));
            this.radioPanel.Name = "radioPanel";
            // 
            // noRadioButton
            // 
            resources.ApplyResources(this.noRadioButton, "noRadioButton");
            this.yesNoErrorProvider.SetIconAlignment(this.noRadioButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("noRadioButton.IconAlignment"))));
            this.commentsErrorProvider.SetIconAlignment(this.noRadioButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("noRadioButton.IconAlignment1"))));
            this.noRadioButton.Name = "noRadioButton";
            this.noRadioButton.TabStop = true;
            this.noRadioButton.UseVisualStyleBackColor = true;
            // 
            // yesRadioButton
            // 
            resources.ApplyResources(this.yesRadioButton, "yesRadioButton");
            this.yesNoErrorProvider.SetIconAlignment(this.yesRadioButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("yesRadioButton.IconAlignment"))));
            this.commentsErrorProvider.SetIconAlignment(this.yesRadioButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("yesRadioButton.IconAlignment1"))));
            this.yesRadioButton.Name = "yesRadioButton";
            this.yesRadioButton.TabStop = true;
            this.yesRadioButton.UseVisualStyleBackColor = true;
            // 
            // ShiftHandoverAnswerControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.oltPanel1);
            this.yesNoErrorProvider.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment"))));
            this.commentsErrorProvider.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment1"))));
            this.Name = "ShiftHandoverAnswerControl";
            ((System.ComponentModel.ISupportInitialize)(this.yesNoErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentsErrorProvider)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.textBoxPanel.ResumeLayout(false);
            this.errorProviderPanel.ResumeLayout(false);
            this.errorProviderPanel.PerformLayout();
            this.commentsPanel.ResumeLayout(false);
            this.commentsPanel.PerformLayout();
            this.oltPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.radioPanel.ResumeLayout(false);
            this.radioPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltLabel questionNumberLabel;
        private OltLabel questionTextLabel;
        private OltPanel radioPanel;
        private OltRadioButton noRadioButton;
        private OltRadioButton yesRadioButton;
        private OltSpellCheckTextBox commentsTextBox;
        private OltLabel commentsLabel;
        private Com.Suncor.Olt.Client.OltControls.OltLinkLabel helpTextLinkLabel;
        private System.Windows.Forms.ErrorProvider yesNoErrorProvider;
        private System.Windows.Forms.ErrorProvider commentsErrorProvider;
        private OltPanel bottomPanel;
        private OltPanel commentsPanel;
        private OltPanel oltPanel1;
        private OltPanel textBoxPanel;
        private OltPanel errorProviderPanel;
        private OltLabel errorProviderBindingControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
