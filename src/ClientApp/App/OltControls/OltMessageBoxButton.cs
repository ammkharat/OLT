using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltMessageBoxButton : OltButton
    {
        public static readonly Size BUTTON_SIZE = new Size(75, 23);
        private readonly DialogResult result;

        public OltMessageBoxButton(string text, DialogResult result)
        {
            base.Text = text;
            this.result = result;
            Size = BUTTON_SIZE;
        }

        public DialogResult Result
        {
            get { return result; }
        }
    }
}