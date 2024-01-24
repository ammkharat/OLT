using System;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    
    public class DoublePropertyRowComparer<TDomainObject, UFirstObjectTypeToCompare, USecondObjectTypeToCompare> : IRowComparer
        where UFirstObjectTypeToCompare : IComparable
        where USecondObjectTypeToCompare : IComparable
    {
        private readonly Converter<TDomainObject, UFirstObjectTypeToCompare> firstConverter;
        private readonly Converter<TDomainObject, USecondObjectTypeToCompare> secondConverter;

        public DoublePropertyRowComparer(Converter<TDomainObject, UFirstObjectTypeToCompare> firstPropertyToSortOnConverter,
            Converter<TDomainObject, USecondObjectTypeToCompare> secondPropertyTpSortOnConverter)
        {
            firstConverter = firstPropertyToSortOnConverter;
            secondConverter = secondPropertyTpSortOnConverter;
        }

        public int Compare(object x, object y)
        {
            return Compare(((UltraGridCell)x).Row, ((UltraGridCell)y).Row);
        }

        public int Compare(UltraGridRow compareRow, UltraGridRow compareToRow)
        {
            var objectOne = (TDomainObject)compareRow.ListObject;
            var objectTwo = (TDomainObject)compareToRow.ListObject;

            UFirstObjectTypeToCompare convertedOne = firstConverter(objectOne);
            UFirstObjectTypeToCompare convertedTwo = firstConverter(objectTwo);

            int result = convertedOne.CompareTo(convertedTwo);
            if (result == 0)
            {
                USecondObjectTypeToCompare convertedOneAgain = secondConverter(objectOne);
                USecondObjectTypeToCompare convertedTwoAgain = secondConverter(objectTwo);
                result = convertedOneAgain.CompareTo(convertedTwoAgain);
            }
            return result;

        }
    }
}
