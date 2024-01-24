using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltLinkLabel : LinkLabel
    {
        public OltLinkLabel()
        {
            base.LinkColor = UIConstants.HyperlinkColor;
            base.ActiveLinkColor = UIConstants.HyperlinkColor;
            base.VisitedLinkColor = UIConstants.HyperlinkColor;
        }

        public new System.Drawing.Color LinkColor
        {
            get { return UIConstants.HyperlinkColor; }
            set {  }
        }

        public new System.Drawing.Color ActiveLinkColor
        {
            get { return UIConstants.HyperlinkColor; }
            set { }
        }

        public new System.Drawing.Color VisitedLinkColor
        {
            get { return UIConstants.HyperlinkColor; }
            set { }
        }
    }
}
