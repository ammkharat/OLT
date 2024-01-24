using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class WorkPermitProtectiveClothingControl : UserControl
    {
        public WorkPermitProtectiveClothingControl()
        {
            InitializeComponent();
            naCheckBox.CheckedChanged += naCheckBox_CheckedChanged;
        }

        public Control OtherDescriptonTextBoxCheckBox
        {
            get { return otherDescriptonTextBoxCheckBox; }
        }

        public bool IsTyvekSuit
        {
            get { return tyvekSuitCheckBox.Checked; }
            set { tyvekSuitCheckBox.Checked = value; }
        }

        public bool IsKapplerSuit
        {
            get { return kapplerSuitCheckBox.Checked; }
            set { kapplerSuitCheckBox.Checked = value; }
        }

        public bool IsElectricalFlashGear
        {
            get { return electricalFlashGearCheckBox.Checked; }
            set { electricalFlashGearCheckBox.Checked = value; }
        }

        public bool IsCorrosiveClothing
        {
            get { return corrosiveClothingCheckBox.Checked; }
            set { corrosiveClothingCheckBox.Checked = value; }
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


        void naCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in specialProtectiveClothingTypeGroupBox.Controls)
            {
                if ( control.Equals(naCheckBox) == false)
                    control.Enabled = !naCheckBox.Checked;
            }
        }
    }
}
