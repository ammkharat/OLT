using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class WorkPermitProtectiveClothingControlSarnia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitProtectiveClothingControlSarnia));
            this.specialProtectiveClothingTypeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.paperCoverallsCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.otherDescriptonTextBoxCheckBox = new Com.Suncor.Olt.Client.Controls.OtherCheckBoxTextBox();
            this.acidClothingTypeIDComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.naCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.acidClothingCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.causticWearCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.rainCoatCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.rainPantsCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.specialProtectiveClothingTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // specialProtectiveClothingTypeGroupBox
            // 
            this.specialProtectiveClothingTypeGroupBox.Controls.Add(this.paperCoverallsCheckBox);
            this.specialProtectiveClothingTypeGroupBox.Controls.Add(this.otherDescriptonTextBoxCheckBox);
            this.specialProtectiveClothingTypeGroupBox.Controls.Add(this.acidClothingTypeIDComboBox);
            this.specialProtectiveClothingTypeGroupBox.Controls.Add(this.naCheckBox);
            this.specialProtectiveClothingTypeGroupBox.Controls.Add(this.acidClothingCheckBox);
            this.specialProtectiveClothingTypeGroupBox.Controls.Add(this.causticWearCheckBox);
            this.specialProtectiveClothingTypeGroupBox.Controls.Add(this.rainCoatCheckBox);
            this.specialProtectiveClothingTypeGroupBox.Controls.Add(this.rainPantsCheckBox);
            resources.ApplyResources(this.specialProtectiveClothingTypeGroupBox, "specialProtectiveClothingTypeGroupBox");
            this.specialProtectiveClothingTypeGroupBox.Name = "specialProtectiveClothingTypeGroupBox";
            this.specialProtectiveClothingTypeGroupBox.TabStop = false;
            // 
            // paperCoverallsCheckBox
            // 
            resources.ApplyResources(this.paperCoverallsCheckBox, "paperCoverallsCheckBox");
            this.paperCoverallsCheckBox.Name = "paperCoverallsCheckBox";
            this.paperCoverallsCheckBox.Value = null;
            // 
            // otherDescriptonTextBoxCheckBox
            // 
            this.otherDescriptonTextBoxCheckBox.CheckBoxChecked = false;
            this.otherDescriptonTextBoxCheckBox.CheckBoxText = "Other:";
            resources.ApplyResources(this.otherDescriptonTextBoxCheckBox, "otherDescriptonTextBoxCheckBox");
            this.otherDescriptonTextBoxCheckBox.MaxLength = 50;
            this.otherDescriptonTextBoxCheckBox.Name = "otherDescriptonTextBoxCheckBox";
            this.otherDescriptonTextBoxCheckBox.Load += new System.EventHandler(this.otherDescriptonTextBoxCheckBox_Load);
            // 
            // acidClothingTypeIDComboBox
            // 
            this.acidClothingTypeIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.acidClothingTypeIDComboBox, "acidClothingTypeIDComboBox");
            this.acidClothingTypeIDComboBox.Name = "acidClothingTypeIDComboBox";
            this.acidClothingTypeIDComboBox.SelectedIndexChanged += new System.EventHandler(this.acidClothingTypeIDComboBox_SelectedIndexChanged);
            // 
            // naCheckBox
            // 
            resources.ApplyResources(this.naCheckBox, "naCheckBox");
            this.naCheckBox.Name = "naCheckBox";
            this.naCheckBox.Value = null;
            this.naCheckBox.CheckedChanged += new System.EventHandler(this.acidClothingCheckBox_CheckedChanged);
            // 
            // acidClothingCheckBox
            // 
            resources.ApplyResources(this.acidClothingCheckBox, "acidClothingCheckBox");
            this.acidClothingCheckBox.Name = "acidClothingCheckBox";
            this.acidClothingCheckBox.Value = null;
            this.acidClothingCheckBox.CheckedChanged += new System.EventHandler(this.acidClothingCheckBox_CheckedChanged);
            // 
            // causticWearCheckBox
            // 
            resources.ApplyResources(this.causticWearCheckBox, "causticWearCheckBox");
            this.causticWearCheckBox.Name = "causticWearCheckBox";
            this.causticWearCheckBox.Value = null;
            // 
            // rainCoatCheckBox
            // 
            resources.ApplyResources(this.rainCoatCheckBox, "rainCoatCheckBox");
            this.rainCoatCheckBox.Name = "rainCoatCheckBox";
            this.rainCoatCheckBox.Value = null;
            // 
            // rainPantsCheckBox
            // 
            resources.ApplyResources(this.rainPantsCheckBox, "rainPantsCheckBox");
            this.rainPantsCheckBox.Name = "rainPantsCheckBox";
            this.rainPantsCheckBox.Value = null;
            // 
            // WorkPermitProtectiveClothingControlSarnia
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.specialProtectiveClothingTypeGroupBox);
            this.Name = "WorkPermitProtectiveClothingControlSarnia";
            this.specialProtectiveClothingTypeGroupBox.ResumeLayout(false);
            this.specialProtectiveClothingTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltGroupBox specialProtectiveClothingTypeGroupBox;
        private OtherCheckBoxTextBox otherDescriptonTextBoxCheckBox;
        private OltComboBox acidClothingTypeIDComboBox;
        private OltCheckBox acidClothingCheckBox;
        private OltCheckBox causticWearCheckBox;
        private OltCheckBox rainCoatCheckBox;
        private OltCheckBox rainPantsCheckBox;
        private OltCheckBox naCheckBox;
        private OltCheckBox paperCoverallsCheckBox;
    }
}
