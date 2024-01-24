using System;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    // This comboBox does not allow users to type into the combo box.
    public class OltComboBox : ComboBox
    {
        public OltComboBox() : this(false) {}

        public OltComboBox(bool showText)
        {
            DropDownStyle = showText ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList;
        }

        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }

        protected override void OnEnter(EventArgs e)
        {
            if (DropDownStyle == ComboBoxStyle.DropDown)
            {
                DropDownStyle = ComboBoxStyle.DropDownList;
                if (Items.Count != 0)
                {
                    SelectedIndex = 0;                    
                }
            }
        }
    }
}