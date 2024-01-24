using System.Windows.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class DetailsWorkPermitEdmontonRenderer : BaseListViewRenderer, IDomainListViewRenderer<WorkPermitEdmontonDTO>
    {
        public ListViewItem RenderItem(WorkPermitEdmontonDTO item)
        {
            DomainListViewItem<WorkPermitEdmontonDTO> listViewItem = new DomainListViewItem<WorkPermitEdmontonDTO>(item);
            listViewItem.Text = item.PermitNumber.ToString();
            listViewItem.SubItems.Add(item.WorkPermitStatus.ToString());
            listViewItem.SubItems.Add(item.StartDateTime == null ? "" : item.StartDateTime.Value.ToLongDateAndTimeString());
            listViewItem.SubItems.Add(item.EndDateTime.ToLongDateAndTimeString());
            return listViewItem;
        }

        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn permitNumberColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn statusColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn issuedDateTime = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn expiredDateTime = new DomainListViewColumn.ResizeToHeaderSizeColumn();

                permitNumberColumn.Name = "PermitNumber";
                statusColumn.Name = "WorkPermitStatus";
                issuedDateTime.Name = "StartDateTime";
                expiredDateTime.Name = "EndDateTime";

                permitNumberColumn.Text = RendererStringResources.PermitNumber;
                statusColumn.Text = RendererStringResources.Status;
                issuedDateTime.Text = RendererStringResources.IssuedDate;
                expiredDateTime.Text = RendererStringResources.ExpiredDate;

                return new DomainListViewColumnCollection(permitNumberColumn, statusColumn, issuedDateTime, expiredDateTime);
            }
        }

    }
}

