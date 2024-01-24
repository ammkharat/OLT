using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class ShiftSelectorListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<ShiftPattern>
    {
        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn colShift = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                colShift.Name = "StartTime";

                colShift.Text = RendererStringResources.Shift;

                return new DomainListViewColumnCollection(
                    colShift);
             }
        }

        public ListViewItem RenderItem(ShiftPattern shiftPattern)
        {
            ListViewItem result = null;

            if (shiftPattern != null)
            {
                var lvi = new DomainListViewItem<ShiftPattern>(shiftPattern)
                              {
                                  Text = new ShiftPatternFormatter(shiftPattern).Format()
                              };

                result = lvi;
            }

            return result;

        }
    }
}
