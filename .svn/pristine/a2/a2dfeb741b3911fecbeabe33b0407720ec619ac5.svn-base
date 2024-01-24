using System.Windows.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class LogReadByListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<ItemReadBy>
    {
         public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn colReadDateTime = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                           {
                                                               Name = "DateTime",
                                                               Text = RendererStringResources.DateTime
                                                           };

                DomainListViewColumn colUserName = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                       {
                                                           Name = "UserFullNameWithUserName",
                                                           Text = RendererStringResources.UserName
                                                       };

                return new DomainListViewColumnCollection(colReadDateTime, colUserName);
            }
        }

         public ListViewItem RenderItem(ItemReadBy itemReadBy)
        {
            var lvi = new DomainListViewItem<ItemReadBy>(itemReadBy) {Text = itemReadBy.DateTime.ToLongDateAndTimeString()};

             lvi.SubItems.Add(itemReadBy.UserFullNameWithUserName);

            return lvi;

        }

    }
    //Added by ppanigrahi
    public class LogNotReadByListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<ItemNotReadBy>
    {
        public DomainListViewColumnCollection Columns
        {
            get
            {
                //DomainListViewColumn colReadDateTime = new DomainListViewColumn.ResizeToHeaderSizeColumn
                //{
                //    Name = "UserID",
                //    Text = RendererStringResources.Id
                //};

                DomainListViewColumn colUserName = new DomainListViewColumn.ResizeToHeaderSizeColumn
                {
                    Name = "UserFullNameWithUserName",
                    Text = RendererStringResources.UserName
                };

                return new DomainListViewColumnCollection(colUserName);
            }
        }

        public ListViewItem RenderItem(ItemNotReadBy itemnotReadBy)
        {
            var lvi = new DomainListViewItem<ItemNotReadBy>(itemnotReadBy) { Text = itemnotReadBy.UserID };

            lvi.SubItems.Add(itemnotReadBy.UserFullNameWithUserName);

            return lvi;

        }

    }

}
