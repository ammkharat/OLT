using System.ComponentModel;
using DevExpress.XtraTreeList;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltTreeList : TreeList
    {
        public OltTreeList()
        {
            base.TreeLineStyle = LineStyle.None;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new LineStyle TreeLineStyle
        {
            get { return base.TreeLineStyle; }
            set { }
        }
    }
}
