using System;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public class PropertyRowComparer<TDomainObject, UObjectTypeToCompare> : IRowComparer 
        where UObjectTypeToCompare : IComparable
    {
        private readonly Converter<TDomainObject, UObjectTypeToCompare> converter;

        public PropertyRowComparer(Converter<TDomainObject, UObjectTypeToCompare> converter)
        {
            this.converter = converter;
        }
        
        public int Compare(UltraGridRow compareRow, UltraGridRow compareToRow)
        {
            var objectOne = (TDomainObject) compareRow.ListObject;
            var objectTwo = (TDomainObject) compareToRow.ListObject;

            UObjectTypeToCompare convertedOne = converter(objectOne);
            UObjectTypeToCompare convertedTwo = converter(objectTwo);

            return convertedOne.CompareTo(convertedTwo);
        }

        public int Compare(object x, object y)
        {
            return Compare(((UltraGridCell)x).Row, ((UltraGridCell)y).Row);
        }
    }
}