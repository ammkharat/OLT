using System.Windows.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    /// <summary>
    /// Render TargetDefinitionDTO properties to a List View
    /// </summary>
    class TargetDefinitionDTOListViewRenderer: BaseListViewRenderer, IDomainListViewRenderer<TargetDefinitionDTO>
    {
        public ListViewItem RenderItem(TargetDefinitionDTO item)
        {
            var lvi = new DomainListViewItem<TargetDefinitionDTO>(item) {Text = item.Name};

            lvi.SubItems.Add(item.TagName);
            lvi.SubItems.Add(item.FunctionalLocationName);
            return lvi;
        }

        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn colTargetName = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                         {
                                                             Name = "Name",
                                                             Text = RendererStringResources.TargetName
                                                         };

                DomainListViewColumn colTag = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                  {
                                                      Name = "TagName",
                                                      Text = RendererStringResources.PHTag
                                                  };

                DomainListViewColumn colFLOC = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                   {
                                                       Name = "FunctionalLocationName",
                                                       Text = RendererStringResources.Floc
                                                   };

                return new DomainListViewColumnCollection(
                    colTargetName,
                    colTag,
                    colFLOC);
            }
        }
    }
}
