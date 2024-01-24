using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class IsReadImageColumn : SortableSimpleDomainObjectImageColumn<IHasReadByCurrentUserInfo, ReadStatus>
    {
        private const string COLUMN_KEY = "ReadStatusImage";
        private const int WIDTH = 50;
        
        public IsReadImageColumn() : base(obj => obj.IsReadByCurrentUser.HasValue && obj.IsReadByCurrentUser.Value ? ReadStatus.Read : ReadStatus.Unread, GetImageMapItems())
        {
            nameToEntityMap.Add(ReadStatus.Unread.Name, ReadStatus.Unread);
            nameToEntityMap.Add(ReadStatus.Read.Name, ReadStatus.Read);
        }

        private static List<IImageMapItem<ReadStatus>> GetImageMapItems()
        {
            List<IImageMapItem<ReadStatus>> items = new List<IImageMapItem<ReadStatus>>();
            items.Add(new SortableSimpleDomainObjectImageMapItem<ReadStatus>(ReadStatus.Unread, ResourceUtils.UNREAD));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ReadStatus>(ReadStatus.Read, ResourceUtils.READ));
            return items;
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return StringResources.MarkedAsReadGridColumnHeader; }
        }

        protected override int ColumnWidth
        {
            get { return WIDTH; }
        }
    }
}
