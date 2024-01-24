using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class DetailsFormOvertimeApprovalRenderer : BaseListViewRenderer, IDomainListViewRenderer<FormApproval>
    {
        public ListViewItem RenderItem(FormApproval item)
        {
            DomainListViewItem<FormApproval> listViewItem = new DomainListViewItem<FormApproval>(item);
            listViewItem.Text = item.Approver;
            listViewItem.SubItems.Add(item.ApprovedByUserName);
            listViewItem.SubItems.Add(item.WorkAssignmentDisplayName);
            listViewItem.SubItems.Add(item.ApprovalDateTime == null ? string.Empty : item.ApprovalDateTime.Value.ToLongDateAndTimeString());
            return listViewItem;
        }

        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn.ManualColumn approverColumn = new DomainListViewColumn.ManualColumn { Width = -1 };
                DomainListViewColumn approvedByUserNameColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn workAssignmentDisplayNameColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                DomainListViewColumn approvalDateTimeColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn();

                approverColumn.Name = "Approver";
                approvedByUserNameColumn.Name = "ApprovedByUserName";
                workAssignmentDisplayNameColumn.Name = "WorkAssignmentDisplayName";
                approvalDateTimeColumn.Name = "ApprovalDateTime";

                approverColumn.Text = RendererStringResources.Approver;
                approvedByUserNameColumn.Text = RendererStringResources.Name;
                workAssignmentDisplayNameColumn.Text = "Work Assignment";
                approvalDateTimeColumn.Text = RendererStringResources.DateApproved;

                return new DomainListViewColumnCollection(approverColumn, approvedByUserNameColumn,workAssignmentDisplayNameColumn, approvalDateTimeColumn);
            }
        }
    }
}
