using System.Globalization;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class DetailsFormGN75BDevicePositionRenderer : BaseListViewRenderer, IDomainListViewRenderer<DevicePosition>
    {
        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn displayOrderColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("DisplayOrder", string.Empty);
                DomainListViewColumn devicePositionColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("DevicePositionDesc", "Device Position");

                return new DomainListViewColumnCollection(displayOrderColumn, devicePositionColumn);
            }
        }

        public ListViewItem RenderItem(DevicePosition item)
        {
            DomainListViewItem<DevicePosition> listViewItem = new DomainListViewItem<DevicePosition>(item);
            listViewItem.Text = item.DisplayOrder.ToString(CultureInfo.InvariantCulture);
            listViewItem.SubItems.Add(item.DevicePositionDesc);
            return listViewItem;
        }
    }
}
