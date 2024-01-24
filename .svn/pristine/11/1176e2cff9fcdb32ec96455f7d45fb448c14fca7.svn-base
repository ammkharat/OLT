using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class WorkPermitProtectiveClothingControlSarnia : UserControl
    {
        public WorkPermitProtectiveClothingControlSarnia()
        {
            InitializeComponent();
            naCheckBox.CheckedChanged += naCheckBox_CheckedChanged;
        }

        public Control OtherDescriptonTextBoxCheckBox
        {
            get { return otherDescriptonTextBoxCheckBox; }
        }

        public Control AcidClothingTypeIDComboBox
        {
            get { return acidClothingTypeIDComboBox; }
        }

        public bool IsAcidClothing
        {
            get { return acidClothingCheckBox.Checked; }
            set { acidClothingCheckBox.Checked = value; }
        }

        public AcidClothingType AcidClothingType
        {
            get { return acidClothingTypeIDComboBox.SelectedItem as AcidClothingType; }
            set 
            {
                if (value == null)
                {
                    acidClothingTypeIDComboBox.SelectedIndex = -1;
                    acidClothingTypeIDComboBox.Enabled = false;
                }
                else
                {
                    acidClothingTypeIDComboBox.SelectedItem = value;
                    acidClothingTypeIDComboBox.Enabled = true;
                }
            }
        }

        public IList<AcidClothingType> AcidClothingTypes
        {
            set 
            {
                acidClothingTypeIDComboBox.DisplayMember = "Name";
                acidClothingTypeIDComboBox.DataSource = value; 
            }
        }

        public bool IsCausticWear
        {
            get { return causticWearCheckBox.Checked; }
            set { causticWearCheckBox.Checked = value; }
        }

        public bool IsRainCoat
        {
            get { return rainCoatCheckBox.Checked; }
            set { rainCoatCheckBox.Checked = value; }
        }

        public bool IsRainPants
        {
            get { return rainPantsCheckBox.Checked; }
            set { rainPantsCheckBox.Checked = value; }
        }

        public bool IsPaperCoveralls
        {
            get { return paperCoverallsCheckBox.Checked; }
            set { paperCoverallsCheckBox.Checked = value; }
        }

        public string OtherDescription
        {
            get { return otherDescriptonTextBoxCheckBox.Text; }
            set { otherDescriptonTextBoxCheckBox.Text = value; }
        }

        public bool IsOtherItemDescription
        {
            get { return otherDescriptonTextBoxCheckBox.CheckBoxChecked; }
        }

        public bool IsNotApplicable
        {
            get { return naCheckBox.Checked; }
            set { naCheckBox.Checked = value; }
        }

        public void DisableItemsThatShouldBeDisabled()
        {
            naCheckBox_CheckedChanged(this, EventArgs.Empty);
        }

        private void acidClothingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            acidClothingTypeIDComboBox.Enabled = acidClothingCheckBox.Checked && naCheckBox.Checked == false;


            // Default the Acid Clothing type to D if there is no clothing type text specified.
            //   This means that D will be defaulted only on new Work Permits where AcidClothingType is checked by the user.
            if (acidClothingCheckBox.Checked && AcidClothingType == null)
            {
                AcidClothingType = AcidClothingType.D_ACIDCLOTHINGTYPE;
            }
        }

        void naCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in specialProtectiveClothingTypeGroupBox.Controls)
            {
                if ( control.Equals(naCheckBox) == false)
                    control.Enabled = !naCheckBox.Checked;
            }
            acidClothingCheckBox_CheckedChanged(this, EventArgs.Empty);
        }

        private void acidClothingTypeIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void otherDescriptonTextBoxCheckBox_Load(object sender, EventArgs e)
        {

        }
    }
}
