using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class TagInfoGroupListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<TagInfoGroup>
    {
        public ListViewItem RenderItem(TagInfoGroup tagInfoGroup)
        {
            var listViewItem = new DomainListViewItem<TagInfoGroup>(tagInfoGroup) {Text = tagInfoGroup.Name};
            return listViewItem;
        }

        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn nameColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                      {
                                                          Name = "Name",
                                                          Text = RendererStringResources.Name
                                                      };

                return new DomainListViewColumnCollection(nameColumn);
            }
        }
    }
}