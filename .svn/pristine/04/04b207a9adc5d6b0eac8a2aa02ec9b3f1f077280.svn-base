using System.Globalization;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class DetailsFormGN75BIsolationRenderer : BaseListViewRenderer, IDomainListViewRenderer<IsolationItem>
    {
        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn displayOrderColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("DisplayOrder", string.Empty);
                DomainListViewColumn isolationTypeColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("IsolationType", "Type of Isolation");
                DomainListViewColumn locationOfEnergyIsolationColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("LocationOfEnergyIsolation", "Location of Energy Isolation");
                if (ClientSession.GetUserContext().IsSarniaSite)
                {
                    DomainListViewColumn devicePosition = new DomainListViewColumn.ResizeToHeaderSizeColumn("DevicePosition", "Device Position");   //ayman Sarnia eip DMND0008992
                    return new DomainListViewColumnCollection(displayOrderColumn, isolationTypeColumn, locationOfEnergyIsolationColumn, devicePosition);     //ayman Sarnia eip DMND0008992
                }
                else
                {
                    return new DomainListViewColumnCollection(displayOrderColumn, isolationTypeColumn, locationOfEnergyIsolationColumn);     //ayman Sarnia eip DMND0008992
                }
            }
        }

        public ListViewItem RenderItem(IsolationItem item)
        {
            DomainListViewItem<IsolationItem> listViewItem = new DomainListViewItem<IsolationItem>(item);
            listViewItem.Text = item.DisplayOrder.ToString(CultureInfo.InvariantCulture);
            listViewItem.SubItems.Add(item.IsolationType);
            listViewItem.SubItems.Add(item.LocationOfEnergyIsolation);
            if (item.SiteId == 1)
            {
                listViewItem.SubItems.Add(item.DevicePosition);             //ayman Sarnia eip DMND0008992
            }
            return listViewItem;
        }
    }
}