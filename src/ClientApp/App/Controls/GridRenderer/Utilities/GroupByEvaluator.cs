using System;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public class GroupByEvaluator<TRow, TSortByType, TGroupByType> : IGroupByEvaluator
        where TSortByType : IComparable
        where TGroupByType : IComparable
    {
        private readonly IRowComparer comparer;
        private readonly Converter<TRow, TGroupByType> converter;

        public GroupByEvaluator(
            Converter<TRow, TSortByType> propertyToSortConverter, 
            Converter<TRow, TGroupByType> converter)
        {
            comparer = new PropertyRowComparer<TRow, TSortByType>(propertyToSortConverter);
            this.converter = converter;
        }

        public bool DoesGroupContainRow(UltraGridGroupByRow groupByRow, UltraGridRow row)
        {
            UltraGridRow compareRow = groupByRow.Rows[0].FindCompareGroupRow();
            return comparer.Compare(compareRow, row) == 0;
        }

        public object GetGroupByValue(UltraGridGroupByRow groupByRow, UltraGridRow row)
        {
            var dtoOne = (TRow)row.ListObject;
            return converter(dtoOne);
        }
    }

}
