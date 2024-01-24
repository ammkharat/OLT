using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    /// <summary>
    /// Olt Specific CheckBox
    /// </summary>
    public class OltCheckBox : CheckBox
    {
        private object value;
        private bool escapeAmpersands;

        /// <summary>
        /// The value associated with CheckBox
        /// </summary>
        [Category("Appearance"), Description("The value associated with CheckBox")]
        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Fixed font for Olt Label
        /// </summary>
        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }

        [DefaultValue(false)]
        public bool EscapeAmpersands
        {
            get { return escapeAmpersands; }
            set { escapeAmpersands = value; }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                if (EscapeAmpersands && value != null)
                {
                    base.Text = ReplaceAmpersandsWithDoubleAmpersands(value);
                }
                else
                {
                    base.Text = value;
                }
            }
        }

        private string ReplaceAmpersandsWithDoubleAmpersands(string str)
        {
            return str.Replace("&", "&&");
        }
    }
}