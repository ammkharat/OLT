using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class DetailsFunctionalLocationRenderer : BaseListViewRenderer, IDomainListViewRenderer<FunctionalLocation>
    {
        public ListViewItem RenderItem(FunctionalLocation item)
        {
            var lvi = new DomainListViewItem<FunctionalLocation>(item) {Text = item.FullHierarchy};
            lvi.SubItems.Add(item.Description);
            ListViewItem result = lvi;

            return result;
        }

        public DomainListViewColumnCollection Columns
        {
            get
            {
                var colFLOC = new DomainListViewColumn.ResizeToHeaderSizeColumn();

                DomainListViewColumn colDescription = new DomainListViewColumn.ResizeToHeaderSizeColumn();

                colFLOC.Name = "FullHierarchy";
                colDescription.Name = "Description";

                colFLOC.Text = RendererStringResources.FunctionalLocation;
                colDescription.Text = RendererStringResources.Description;

                return new DomainListViewColumnCollection(
                    colFLOC,
                    colDescription);
            }
        }
    }
}