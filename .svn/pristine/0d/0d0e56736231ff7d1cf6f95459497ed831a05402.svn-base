using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class DetailsWorkAssignmentRenderer : BaseListViewRenderer, IDomainListViewRenderer<WorkAssignment>
    {
        public ListViewItem RenderItem(WorkAssignment item)
        {
            var lvi = new DomainListViewItem<WorkAssignment>(item) {Text = item.Name};
            lvi.SubItems.Add(item.Description);
            ListViewItem result = lvi;

            return result;
        }

        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn colName = new DomainListViewColumn.ManualColumn("Name",
                    RendererStringResources.Name, 220);

                DomainListViewColumn colDescription = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                colDescription.Name = "Description";
                colDescription.Text = RendererStringResources.Description;

                return new DomainListViewColumnCollection(colName, colDescription);
            }
        }
    }
}