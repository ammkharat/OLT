using System.Windows.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class GasTestElementResulDTOListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<GasTestElementResultDTO>
    {
        public DomainListViewColumnCollection Columns
        {
            get
            {
                return new DomainListViewColumnCollection(CreateResizeToHeaderColumn(RendererStringResources.Element, "Name"),
                                                          CreateResizeToHeaderColumn(RendererStringResources.Limit, "Limit"),
                                                          CreateResizeToHeaderColumn(RendererStringResources.ImmediateArea, "FirstTestResult"),
                                                          CreateResizeToHeaderColumn(RendererStringResources.ConfinedSpace,
                                                                                     "ConfinedSpaceTestResult"));
            }
        }

        public ListViewItem RenderItem(GasTestElementResultDTO gasTestElementResult)
        {
            var listViewItem =
                new DomainListViewItem<GasTestElementResultDTO>(gasTestElementResult) {Text = gasTestElementResult.Name};
            listViewItem.SubItems.Add(gasTestElementResult.Limit);
            listViewItem.SubItems.Add(gasTestElementResult.FirstTestResult.Format());
            listViewItem.SubItems.Add(gasTestElementResult.ConfinedSpaceTestResult.Format());
            return listViewItem;
        }

        private static DomainListViewColumn CreateResizeToHeaderColumn(string headerText, string propertyName)
        {
            DomainListViewColumn column = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                              {
                                                  Name = propertyName,
                                                  Text = headerText
                                              };
            return column;
        }
    }

    public class GasTestElementResultDenverDTOListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<GasTestElementResultDTO>
    {
        public DomainListViewColumnCollection Columns
        {
            get
            {
                return new DomainListViewColumnCollection(CreateResizeToHeaderColumn(RendererStringResources.Element, "Name"),
                                                          CreateResizeToHeaderColumn(RendererStringResources.Limit, "Limit"),
                                                          CreateResizeToHeaderColumn(RendererStringResources.WorkArea, "FirstTestResult"),
                                                          CreateResizeToHeaderColumn(RendererStringResources.ConfinedSpace,
                                                                                     "ConfinedSpaceTestResult"),
                                                          CreateResizeToHeaderColumn(RendererStringResources.SystemEntry,
                                                                                     "SystemEntryTestResult"));
            }
        }

        public ListViewItem RenderItem(GasTestElementResultDTO gasTestElementResult)
        {
            var listViewItem =
                new DomainListViewItem<GasTestElementResultDTO>(gasTestElementResult) { Text = gasTestElementResult.Name };
            listViewItem.SubItems.Add(gasTestElementResult.Limit);
            listViewItem.SubItems.Add(gasTestElementResult.FirstTestResult.Format());
            listViewItem.SubItems.Add(gasTestElementResult.ConfinedSpaceTestResult.Format());
            listViewItem.SubItems.Add(gasTestElementResult.SystemEntryTestResult.Format());
            return listViewItem;
        }

        private static DomainListViewColumn CreateResizeToHeaderColumn(string headerText, string propertyName)
        {
            DomainListViewColumn column = new DomainListViewColumn.ResizeToHeaderSizeColumn
            {
                Name = propertyName,
                Text = headerText
            };
            return column;
        }
    }

    //ayman USPipeline workpermit
    public class GasTestElementResultUSPipelineDTOListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<GasTestElementResultDTO>
    {
        public DomainListViewColumnCollection Columns
        {
            get
            {
                return new DomainListViewColumnCollection(CreateResizeToHeaderColumn(RendererStringResources.Element, "Name"),
                                                          CreateResizeToHeaderColumn(RendererStringResources.Limit, "Limit"),
                                                          CreateResizeToHeaderColumn(RendererStringResources.WorkArea, "FirstTestResult"),
                                                          CreateResizeToHeaderColumn(RendererStringResources.ConfinedSpace,
                                                                                     "ConfinedSpaceTestResult"),
                                                          CreateResizeToHeaderColumn(RendererStringResources.SystemEntry,
                                                                                     "SystemEntryTestResult"));
            }
        }

        public ListViewItem RenderItem(GasTestElementResultDTO gasTestElementResult)
        {
            var listViewItem =
                new DomainListViewItem<GasTestElementResultDTO>(gasTestElementResult) { Text = gasTestElementResult.Name };
            listViewItem.SubItems.Add(gasTestElementResult.Limit);
            listViewItem.SubItems.Add(gasTestElementResult.FirstTestResult.Format());
            listViewItem.SubItems.Add(gasTestElementResult.ConfinedSpaceTestResult.Format());
            listViewItem.SubItems.Add(gasTestElementResult.SystemEntryTestResult.Format());
            return listViewItem;
        }

        private static DomainListViewColumn CreateResizeToHeaderColumn(string headerText, string propertyName)
        {
            DomainListViewColumn column = new DomainListViewColumn.ResizeToHeaderSizeColumn
            {
                Name = propertyName,
                Text = headerText
            };
            return column;
        }
    }

}