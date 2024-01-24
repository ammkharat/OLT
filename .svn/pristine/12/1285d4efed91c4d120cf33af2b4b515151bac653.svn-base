using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client
{
    public static class InfragisticsExtensions
    {
        public static bool DoesHave(this KeyedSubObjectsCollectionBase collection, string key)
        {
            return collection != null && collection.Exists(key);
        }

        public static bool DoesNotHave(this KeyedSubObjectsCollectionBase collection, string key)
        {
            return !DoesHave(collection, key);
        }

        public static UltraGridRow FindRow<T>(this IEnumerable<UltraGridRow> rows, long? id) where T : DomainObject
        {
            foreach(UltraGridRow row in rows)
            {
                UltraGridGroupByRow groupByRow = row as UltraGridGroupByRow;
                if(groupByRow != null)
                {
                    UltraGridRow foundRow = groupByRow.Rows.FindRow<T>(id);
                    if (foundRow != null)
                    {
                        return foundRow;
                    }
                }
                else
                {
                    if(((T) row.ListObject).Id == id)
                    {
                        return row;
                    }
                }
            }
            return null;
        }

        public static bool HasSortColumnsSpecified(this UltraGridBand band)
        {
            return band.SortedColumns.Count > 0;
        }

        public static bool HasGroupByColumn(this UltraGridBand band)
        {
            foreach(UltraGridColumn c in band.Columns)
            {
                if (c.IsGroupByColumn) return true;
            }
            return false;
        }

        /// <summary>
        /// Set up the column to auto resize based on header and the contents.
        /// Avoid using this if you can get away with a fixed width, as this operation takes a while.
        /// </summary>
        public static void AutoResizeAllRows(this UltraGridColumn column)
        {
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, true);
        }

        public static void HideAllColumns(this UltraGridBand band)
        {
            foreach (UltraGridColumn column in band.Columns)
            {
                column.Hidden = true;
            }
        }

        private static void SetFormat(this UltraGridColumn ultraGridColumn, string format)
        {
            ultraGridColumn.Format = format;            
            ultraGridColumn.CellDisplayStyle = CellDisplayStyle.FormattedText;
        }

        public static void FormatAsDateTime(this UltraGridColumn ultraGridColumn, string headerCaption, int position)
        {
            FormatAsDateTime(ultraGridColumn, headerCaption, position, 110);            
        }

        public static void FormatAsDateTime(this UltraGridColumn ultraGridColumn, string headerCaption, int position, int width)
        {
            ultraGridColumn.FormatAsDateTime(headerCaption, position, "g", width);
        }

        public static void FormatAsDate(this UltraGridColumn ultraGridColumn, string headerCaption, int position)
        {
            ultraGridColumn.FormatAsDate(headerCaption, position, 145);
        }

        public static void FormatAsDate(this UltraGridColumn ultraGridColumn, string headerCaption, int position, int width)
        {
            ultraGridColumn.FormatAsDateTime(headerCaption, position, "D", width);
        }

        public static void FormatAsTime(this UltraGridColumn ultraGridColumn, string headerCaption, int position, int width)
        {
            ultraGridColumn.FormatAsDateTime(headerCaption, position, "t", width);
        }

        public static void FormatAsTime(this UltraGridColumn ultraGridColumn, string headerCaption, int position)
        {
            ultraGridColumn.FormatAsDateTime(headerCaption, position, "t", 81);
        }

        private static void FormatAsDateTime(this UltraGridColumn ultraGridColumn, string headerCaption, int position, string dateTimeFormat, int? columnWidth)
        {
            ultraGridColumn.Format(headerCaption, position, columnWidth, false);
            ultraGridColumn.SetFormat(dateTimeFormat);
        }

        public static void FormatAsCurrency(this UltraGridColumn ultraGridColumn, string headerCaption, int position, int width, bool rightJustify)
        {
            ultraGridColumn.Format(headerCaption, position, width, rightJustify);
            ultraGridColumn.SetFormat("C");
        }

        public static void FormatAsCurrencyNoCents(this UltraGridColumn ultraGridColumn, string headerCaption, int position, int width, bool rightJustify)
        {
            ultraGridColumn.Format(headerCaption, position, width, rightJustify);
            ultraGridColumn.SetFormat("C0");
        }

        public static void FormatAsDecimal(this UltraGridColumn ultraGridColumn, string headerCaption, int position, int width, bool rightJustify)
        {
            ultraGridColumn.Format(headerCaption, position, width, rightJustify);
            ultraGridColumn.SetFormat("N2");
        }
        public static void FormatAsDecimalThreePlaces(this UltraGridColumn ultraGridColumn, string headerCaption, int position, int width, bool rightJustify)
        {
            ultraGridColumn.Format(headerCaption, position, width, rightJustify);
            ultraGridColumn.SetFormat("N3");
        }

        public static void FormatAsInt(this UltraGridColumn ultraGridColumn, string headerCaption, int position, int width, bool rightJustify)
        {
            ultraGridColumn.Format(headerCaption, position, width, rightJustify);            
        }

        public static void Format(this UltraGridColumn ultraGridColumn, string headerCaption, int position)
        {
            Format(ultraGridColumn, headerCaption, position, null, false, false);
        }

        public static void Format(this UltraGridColumn ultraGridColumn, string headerCaption, int position, bool rightJustify)
        {
            Format(ultraGridColumn, headerCaption, position, null, false, rightJustify);
        }

        public static void Format(this UltraGridColumn ultraGridColumn, string headerCaption, int position, int width)
        {
            Format(ultraGridColumn, headerCaption, position, width, false, false);
        }

        public static void Format(this UltraGridColumn ultraGridColumn, string headerCaption, int position, int? width, bool rightJustify)
        {
            Format(ultraGridColumn, headerCaption, position, width, false, rightJustify);
        }

        private static void Format(UltraGridColumn ultraGridColumn, string headerCaption, int position, int? width, bool isHidden, bool rightJustify)
        {
            ultraGridColumn.Hidden = isHidden;
            ultraGridColumn.Header.Caption = headerCaption;
            ultraGridColumn.Header.VisiblePosition = position;
            ultraGridColumn.CellAppearance.TextHAlign = (rightJustify) ? HAlign.Right : HAlign.Left;

            if (width.HasValue)
            {
                ultraGridColumn.Width = width.Value;  // Don't autosize it, but set width (autosize takes a long time).
            }
        }
        // Start Custom Field Changes By : Swapnil Patki
        public static void FormatAsRange(this UltraGridCell cell)
        {
            cell.Appearance.FontData.SizeInPoints = 9;

            cell.Appearance.ForeColor = Color.Red;
            cell.Appearance.TextHAlign = HAlign.Left;
            cell.Appearance.Cursor = Cursors.Hand;
        }
        //End Custom Field Changes By : Swapnil Patki

        public static void FormatAsLink(this UltraGridCell cell)
        {
            cell.Appearance.BackColor = SystemColors.Control;
            cell.Activation = Activation.ActivateOnly;
            cell.Appearance.ForeColor = Color.Blue;
            cell.Appearance.FontData.Underline = DefaultableBoolean.True;
            cell.Appearance.TextHAlign = HAlign.Left;
            cell.Appearance.Cursor = Cursors.Hand;
            
        }
        public static void FormatAsHeading(this UltraGridCell cell)
        {
            cell.Appearance.BackColor = SystemColors.Control;
            cell.Appearance.FontData.Bold = DefaultableBoolean.True;
            cell.Appearance.FontData.SizeInPoints = 9;

            cell.Appearance.ForeColor = Color.Black;
            cell.Appearance.TextHAlign = HAlign.Left;
            
        }
        public static void FormatAsLink(this UltraGridColumn ultraGridColumn, string headerCaption, int position)
        {
            ultraGridColumn.Hidden = false;
            ultraGridColumn.Header.Caption = headerCaption;
            ultraGridColumn.Header.VisiblePosition = position;

            ultraGridColumn.CellAppearance.BackColor = SystemColors.Control;
            ultraGridColumn.CellActivation = Activation.ActivateOnly;
            ultraGridColumn.CellAppearance.ForeColor = Color.Blue;
            ultraGridColumn.CellAppearance.FontData.Underline = DefaultableBoolean.True;
            ultraGridColumn.CellAppearance.TextHAlign = HAlign.Left;
            ultraGridColumn.CellAppearance.Cursor = Cursors.Hand;
        }

        public static void ScrollToRow(this UltraGrid grid, UltraGridRow row)
        {
            grid.DisplayLayout.RowScrollRegions[0].ScrollRowIntoView(row);                        
        }

        /// <summary>
        /// To be used only with the Column Compare routine to recursively find the Compare Group Row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static UltraGridRow FindCompareGroupRow(this UltraGridRow row)
        {
            if (null != row.ListObject)
            {
                return row;
            }
            return ((UltraGridGroupByRow) row).Rows[0].FindCompareGroupRow();
        }

        public static void CentreImageColumn(this UltraGridColumn column)
        {
            column.CellAppearance.ImageHAlign = HAlign.Center; 
        }
    }
}
