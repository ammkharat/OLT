using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class DomainObjectChangeSetListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<DomainObjectChangeSet> 
    {
        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn colChangeDateTime = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                             {
                                                                 Name = "ChangeDateTime",
                                                                 Text = RendererStringResources.DateTime
                                                             };

                DomainListViewColumn colUserName = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                       {
                                                           Name = "UserName",
                                                           Text = RendererStringResources.UserName
                                                       };

                return new DomainListViewColumnCollection(colChangeDateTime, colUserName);
            }
        }

        public ListViewItem RenderItem(DomainObjectChangeSet target)
        {
            var lvi = new DomainListViewItem<DomainObjectChangeSet>(target)
                          {Text = target.ChangeDateTime.ToLongDateAndTimeString()};

            lvi.SubItems.Add(target.UserName);

            return lvi;
        }
    }
}
