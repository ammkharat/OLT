using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class WorkPermitDefaultTimesPreferenceTabPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitDefaultTimesPreferenceTabPage));
            this.titleGroupBox = new OltGroupBox();
            this.endTimeGroupBox = new OltGroupBox();
            this.paddingUnitsLabel2 = new OltLabel();
            this.postShiftPaddingLabel = new OltLabel();
            this.postShiftPaddingPicker = new OltTimePicker();
            this.startTimeGroupBox = new OltGroupBox();
            this.paddingUnitsLabel1 = new OltLabel();
            this.preShiftPaddingLabel = new OltLabel();
            this.preShiftPaddingPicker = new OltTimePicker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.titleGroupBox.SuspendLayout();
            this.endTimeGroupBox.SuspendLayout();
            this.startTimeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // titleGroupBox
            // 
            this.titleGroupBox.AccessibleDescription = null;
            this.titleGroupBox.AccessibleName = null;
            resources.ApplyResources(this.titleGroupBox, "titleGroupBox");
            this.titleGroupBox.BackgroundImage = null;
            this.titleGroupBox.Controls.Add(this.endTimeGroupBox);
            this.titleGroupBox.Controls.Add(this.startTimeGroupBox);
            this.errorProvider.SetError(this.titleGroupBox, resources.GetString("titleGroupBox.Error"));
            this.titleGroupBox.Font = null;
            this.errorProvider.SetIconAlignment(this.titleGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("titleGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.titleGroupBox, ((int)(resources.GetObject("titleGroupBox.IconPadding"))));
            this.titleGroupBox.Name = "titleGroupBox";
            this.titleGroupBox.TabStop = false;
            // 
            // endTimeGroupBox
            // 
            this.endTimeGroupBox.AccessibleDescription = null;
            this.endTimeGroupBox.AccessibleName = null;
            resources.ApplyResources(this.endTimeGroupBox, "endTimeGroupBox");
            this.endTimeGroupBox.BackgroundImage = null;
            this.endTimeGroupBox.Controls.Add(this.paddingUnitsLabel2);
            this.endTimeGroupBox.Controls.Add(this.postShiftPaddingLabel);
            this.endTimeGroupBox.Controls.Add(this.postShiftPaddingPicker);
            this.errorProvider.SetError(this.endTimeGroupBox, resources.GetString("endTimeGroupBox.Error"));
            this.endTimeGroupBox.Font = null;
            this.errorProvider.SetIconAlignment(this.endTimeGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("endTimeGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.endTimeGroupBox, ((int)(resources.GetObject("endTimeGroupBox.IconPadding"))));
            this.endTimeGroupBox.Name = "endTimeGroupBox";
            this.endTimeGroupBox.TabStop = false;
            // 
            // paddingUnitsLabel2
            // 
            this.paddingUnitsLabel2.AccessibleDescription = null;
            this.paddingUnitsLabel2.AccessibleName = null;
            resources.ApplyResources(this.paddingUnitsLabel2, "paddingUnitsLabel2");
            this.errorProvider.SetError(this.paddingUnitsLabel2, resources.GetString("paddingUnitsLabel2.Error"));
            this.paddingUnitsLabel2.Font = null;
            this.errorProvider.SetIconAlignment(this.paddingUnitsLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("paddingUnitsLabel2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.paddingUnitsLabel2, ((int)(resources.GetObject("paddingUnitsLabel2.IconPadding"))));
            this.paddingUnitsLabel2.Name = "paddingUnitsLabel2";
            // 
            // postShiftPaddingLabel
            // 
            this.postShiftPaddingLabel.AccessibleDescription = null;
            this.postShiftPaddingLabel.AccessibleName = null;
            resources.ApplyResources(this.postShiftPaddingLabel, "postShiftPaddingLabel");
            this.errorProvider.SetError(this.postShiftPaddingLabel, resources.GetString("postShiftPaddingLabel.Error"));
            this.postShiftPaddingLabel.Font = null;
            this.errorProvider.SetIconAlignment(this.postShiftPaddingLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postShiftPaddingLabel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.postShiftPaddingLabel, ((int)(resources.GetObject("postShiftPaddingLabel.IconPadding"))));
            this.postShiftPaddingLabel.Name = "postShiftPaddingLabel";
            // 
            // postShiftPaddingPicker
            // 
            this.postShiftPaddingPicker.AccessibleDescription = null;
            this.postShiftPaddingPicker.AccessibleName = null;
            resources.ApplyResources(this.postShiftPaddingPicker, "postShiftPaddingPicker");
            this.postShiftPaddingPicker.BackgroundImage = null;
            this.postShiftPaddingPicker.Checked = true;
            this.errorProvider.SetError(this.postShiftPaddingPicker, resources.GetString("postShiftPaddingPicker.Error"));
            this.postShiftPaddingPicker.Font = null;
            this.errorProvider.SetIconAlignment(this.postShiftPaddingPicker, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postShiftPaddingPicker.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.postShiftPaddingPicker, ((int)(resources.GetObject("postShiftPaddingPicker.IconPadding"))));
            this.postShiftPaddingPicker.Name = "postShiftPaddingPicker";
            this.postShiftPaddingPicker.ShowCheckBox = false;
            // 
            // startTimeGroupBox
            // 
            this.startTimeGroupBox.AccessibleDescription = null;
            this.startTimeGroupBox.AccessibleName = null;
            resources.ApplyResources(this.startTimeGroupBox, "startTimeGroupBox");
            this.startTimeGroupBox.BackgroundImage = null;
            this.startTimeGroupBox.Controls.Add(this.paddingUnitsLabel1);
            this.startTimeGroupBox.Controls.Add(this.preShiftPaddingLabel);
            this.startTimeGroupBox.Controls.Add(this.preShiftPaddingPicker);
            this.errorProvider.SetError(this.startTimeGroupBox, resources.GetString("startTimeGroupBox.Error"));
            this.startTimeGroupBox.Font = null;
            this.errorProvider.SetIconAlignment(this.startTimeGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("startTimeGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.startTimeGroupBox, ((int)(resources.GetObject("startTimeGroupBox.IconPadding"))));
            this.startTimeGroupBox.Name = "startTimeGroupBox";
            this.startTimeGroupBox.TabStop = false;
            // 
            // paddingUnitsLabel1
            // 
            this.paddingUnitsLabel1.AccessibleDescription = null;
            this.paddingUnitsLabel1.AccessibleName = null;
            resources.ApplyResources(this.paddingUnitsLabel1, "paddingUnitsLabel1");
            this.errorProvider.SetError(this.paddingUnitsLabel1, resources.GetString("paddingUnitsLabel1.Error"));
            this.paddingUnitsLabel1.Font = null;
            this.errorProvider.SetIconAlignment(this.paddingUnitsLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("paddingUnitsLabel1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.paddingUnitsLabel1, ((int)(resources.GetObject("paddingUnitsLabel1.IconPadding"))));
            this.paddingUnitsLabel1.Name = "paddingUnitsLabel1";
            // 
            // preShiftPaddingLabel
            // 
            this.preShiftPaddingLabel.AccessibleDescription = null;
            this.preShiftPaddingLabel.AccessibleName = null;
            resources.ApplyResources(this.preShiftPaddingLabel, "preShiftPaddingLabel");
            this.errorProvider.SetError(this.preShiftPaddingLabel, resources.GetString("preShiftPaddingLabel.Error"));
            this.preShiftPaddingLabel.Font = null;
            this.errorProvider.SetIconAlignment(this.preShiftPaddingLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preShiftPaddingLabel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.preShiftPaddingLabel, ((int)(resources.GetObject("preShiftPaddingLabel.IconPadding"))));
            this.preShiftPaddingLabel.Name = "preShiftPaddingLabel";
            // 
            // preShiftPaddingPicker
            // 
            this.preShiftPaddingPicker.AccessibleDescription = null;
            this.preShiftPaddingPicker.AccessibleName = null;
            resources.ApplyResources(this.preShiftPaddingPicker, "preShiftPaddingPicker");
            this.preShiftPaddingPicker.BackgroundImage = null;
            this.preShiftPaddingPicker.Checked = true;
            this.errorProvider.SetError(this.preShiftPaddingPicker, resources.GetString("preShiftPaddingPicker.Error"));
            this.preShiftPaddingPicker.Font = null;
            this.errorProvider.SetIconAlignment(this.preShiftPaddingPicker, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preShiftPaddingPicker.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.preShiftPaddingPicker, ((int)(resources.GetObject("preShiftPaddingPicker.IconPadding"))));
            this.preShiftPaddingPicker.Name = "preShiftPaddingPicker";
            this.preShiftPaddingPicker.ShowCheckBox = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // WorkPermitDefaultTimesPreferenceTabPage
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.titleGroupBox);
            this.errorProvider.SetError(this, resources.GetString("$this.Error"));
            this.Font = null;
            this.errorProvider.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment"))));
            this.errorProvider.SetIconPadding(this, ((int)(resources.GetObject("$this.IconPadding"))));
            this.Name = "WorkPermitDefaultTimesPreferenceTabPage";
            this.titleGroupBox.ResumeLayout(false);
            this.endTimeGroupBox.ResumeLayout(false);
            this.endTimeGroupBox.PerformLayout();
            this.startTimeGroupBox.ResumeLayout(false);
            this.startTimeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltGroupBox titleGroupBox;
        private OltGroupBox endTimeGroupBox;
        private OltGroupBox startTimeGroupBox;
        private OltTimePicker postShiftPaddingPicker;
        private OltTimePicker preShiftPaddingPicker;
        private OltLabel postShiftPaddingLabel;
        private OltLabel preShiftPaddingLabel;
        private OltLabel paddingUnitsLabel2;
        private OltLabel paddingUnitsLabel1;
        private ErrorProvider errorProvider;


    }
}