using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltIntegerBox : OltNumericBox
    {
        public OltIntegerBox()
        {
            MaxLength = 9;
        }

        protected override void OltNumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || 
               (e.KeyChar.Equals('-') && Text.Trim().Length == 0) || 
                backPressed))
            {
                e.Handled = true;
            }

        }
    }
}
