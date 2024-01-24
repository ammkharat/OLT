using System.Windows.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class RestrictionLocationListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<RestrictionLocationDto>
    {
        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn colName = new DomainListViewColumn.ResizeToHeaderSizeColumn("Name", RendererStringResources.Name);
                return new DomainListViewColumnCollection(colName);
            }
            
        }

        public ListViewItem RenderItem(RestrictionLocationDto domainObject)
        {
            ListViewItem result = null;
            if (domainObject != null)
            {
                result = new DomainListViewItem<RestrictionLocationDto>(domainObject) {Text = domainObject.Name};
            }
            return result;
        }
    }
}