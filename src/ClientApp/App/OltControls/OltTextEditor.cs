using Com.Suncor.Olt.Common.Extension;
using Infragistics.Win.UltraWinEditors;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltTextEditor : UltraTextEditor
    {
        public override string Text
        {
            get { return base.Text.TrimWhitespace(); }
            set { base.Text = value; }
        }
    }
}
