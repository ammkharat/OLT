using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.OltControls
{
    // TODO: Eric: For next release, consider using OltUltra version for consistency
    public class OltNumericBox : TextBox
    {
        protected bool backPressed;

        public OltNumericBox()
        {
            TextAlign = HorizontalAlignment.Right;
            base.Text = string.Empty;
            KeyDown += OltNumericTextBox_KeyDown;
            KeyPress += OltNumericTextBox_KeyPress;
        }

        private void OltNumericTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            backPressed = false;
            if (e.KeyCode == Keys.Back)
            {
                backPressed = true;
            }
        }

        public double? NumericValue
        {
            get
            {
                double result;
                string strVal = Text.Trim();
                if (strVal.TryParseNumber(out result))
                    return result;
                return null;
            }
            set {
                Text = value.HasValue ? value.ToString() : string.Empty;
            }
        }

        public decimal? DecimalValue
        {
            get
            {
                decimal result;
                string strVal = Text.Trim();
                if (strVal.TryParse(out result))
                    return result;
                return null;
            }
            set {
                Text = value.HasValue ? value.ToString() : string.Empty;
            }
        }

        public int? IntegerValue
        {
            get
            {
                int result;
                string strVal = Text.Trim();
                if (strVal.TryParse(out result))
                    return result;
                return null;
            }
            set
            {
                Text = value.HasValue ? value.ToString() : string.Empty;
            }
        }


        protected virtual void OltNumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) ||
                  (e.KeyChar.Equals('.') && Text.IndexOf('.') == -1) ||
                  (e.KeyChar.Equals('-') && Text.Trim().Length == 0) ||
                  backPressed))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Fixed font for Olt Label
        /// </summary>
        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }
    }
}