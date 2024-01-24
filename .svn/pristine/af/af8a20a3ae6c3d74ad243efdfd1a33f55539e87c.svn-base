using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public abstract class StatusImageColumn<TRow, TCell> : SortableSimpleDomainObjectImageColumn<TRow, TCell>
        where TRow : IHasStatus<TCell>
        where TCell : SortableSimpleDomainObject
    {
        private const string COLUMN_KEY = "StatusImage";
        private const int WIDTH = 50;

        private readonly string columnCaption;
        
        protected StatusImageColumn(string columnCaption, List<IImageMapItem<TCell>> imageMapItems) : base(obj => obj.Status, imageMapItems)
        {
            this.columnCaption = columnCaption;
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return columnCaption; }
        }

        protected override int ColumnWidth
        {
            get { return WIDTH; }
        }
    }
}
