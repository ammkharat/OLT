using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public delegate void CustomFieldEntryClickHandler(CustomFieldEntry customFieldEntry);

    public class CustomFieldEntryGridRenderer : AbstractSimpleGridRenderer
    {
        public event CustomFieldEntryClickHandler CustomFieldEntryClicked;

        protected override void SetUpColumns(UltraGridBand band)
        {
            var column = 0;

            band.HideAllColumns();
            band.Columns["FieldName0"].Format(RendererStringResources.FieldName, column++);
            band.Columns["Entry0"].Format(RendererStringResources.Entry, column++);
            band.Columns["FieldName1"].Format(RendererStringResources.FieldName, column++);
            band.Columns["Entry1"].Format(RendererStringResources.Entry, column++);
            band.Columns["FieldName2"].Format(RendererStringResources.FieldName, column++);
            band.Columns["Entry2"].Format(RendererStringResources.Entry, column++);

            band.ColHeadersVisible = false;
            band.Override.RowSelectors = DefaultableBoolean.False;
            band.Columns["FieldName0"].CellAppearance.BackColor = SystemColors.Control;
            band.Columns["FieldName1"].CellAppearance.BackColor = SystemColors.Control;
            band.Columns["FieldName2"].CellAppearance.BackColor = SystemColors.Control;
        }

        public override void CellClicked(UltraGridCell cell)
        {
            var tag = cell.Tag;
            if (tag != null)
            {
                var customFieldEntry = tag as CustomFieldEntry;
                if (CustomFieldEntryClicked != null && customFieldEntry != null && !customFieldEntry.IsJustForDisplay)
                {
                    CustomFieldEntryClicked(customFieldEntry);
                }
            }
        }

        public override void SetupRow(UltraGridRow row)
        {
            var listObject = row.ListObject;
            var adapter = listObject as CustomFieldEntryGridAdapter;

            if (adapter == null)
                return;

            var entry0 = adapter.GetCustomField(0);
            var entry1 = adapter.GetCustomField(1);
            var entry2 = adapter.GetCustomField(2);

            

            if (entry0 != null && !entry0.IsJustForDisplay)
            {
                var ultraGridCell = row.Cells["FieldName0"];
                ultraGridCell.FormatAsLink();
                ultraGridCell.Tag = entry0;

                // Start Custom Field Changes By : Swapnil Patki
                if (entry0.Color == "R") // Start Custom Field Changes By : Swapnil Patki
                {
                    var ultraGridCellN = row.Cells["Entry0"];
                    ultraGridCellN.FormatAsRange();
                }
                //else if (entry0.MinValueofRange != null)
                //{
                //    var ultraGridCellN = row.Cells["Entry0"];
                //    ultraGridCellN.FormatAsRange();
                //}
                //else if (entry0.LessThanRangeValue != null && entry0.GreaterThanRangeValue != null)
                //{
                //    var ultraGridCellN = row.Cells["Entry0"];
                //    ultraGridCellN.FormatAsRange();
                //}//swapnil
                //END Custom Field Changes By : Swapnil Patki
            }

            if (entry1 != null && !entry1.IsJustForDisplay)
            {
                var ultraGridCell = row.Cells["FieldName1"];
                ultraGridCell.FormatAsLink();
                ultraGridCell.Tag = entry1;

                // Start Custom Field Changes By : Swapnil Patki
                if (entry1.Color == "R")
                {
                    var ultraGridCellN = row.Cells["Entry1"];
                    ultraGridCellN.FormatAsRange();
                }
                //else if (entry1.MinValueofRange != null)
                //{
                //    var ultraGridCellN = row.Cells["Entry1"];
                //    ultraGridCellN.FormatAsRange();
                //}
                //else if (entry1.LessThanRangeValue != null && entry1.GreaterThanRangeValue != null)
                //{
                //    var ultraGridCellN = row.Cells["Entry1"];
                //    ultraGridCellN.FormatAsRange();
                //}
                // End Custom Field Changes By : Swapnil Patki
            }

            if (entry2 != null && !entry2.IsJustForDisplay)
            { 
                var ultraGridCell = row.Cells["FieldName2"];
                ultraGridCell.FormatAsLink();
                ultraGridCell.Tag = entry2;

                // Start Custom Field Changes By : Swapnil Patki
                if (entry2.Color == "R")
                {
                    var ultraGridCellN = row.Cells["Entry2"];
                    ultraGridCellN.FormatAsRange();
                }
                //else if (entry2.MinValueofRange != null)
                //{
                //    var ultraGridCellN = row.Cells["Entry2"];
                //    ultraGridCellN.FormatAsRange();
                //}
                //else if (entry2.LessThanRangeValue != null && entry2.GreaterThanRangeValue != null)
                //{
                //    var ultraGridCellN = row.Cells["Entry2"];
                //    ultraGridCellN.FormatAsRange();
                //}//swapnil
                // End Custom Field Changes By : Swapnil Patki
            }

            if (entry0 != null && entry0.IsJustForDisplay && !entry0.CustomFieldName.IsNullOrEmptyOrWhitespace())
            {
                var ultraGridCell = row.Cells["FieldName0"];
                ultraGridCell.FormatAsHeading();
                ultraGridCell.Tag = entry0;
            }
            
            if (entry1 != null && entry1.IsJustForDisplay && !entry1.CustomFieldName.IsNullOrEmptyOrWhitespace())
            {
                var ultraGridCell = row.Cells["FieldName1"];
                ultraGridCell.FormatAsHeading();
                ultraGridCell.Tag = entry1;
            }
            if (entry2 != null && entry2.IsJustForDisplay && !entry2.CustomFieldName.IsNullOrEmptyOrWhitespace())
            {
                var ultraGridCell = row.Cells["FieldName2"];
                ultraGridCell.FormatAsHeading();
                ultraGridCell.Tag = entry2;
            }
        }

        public static IList<CustomFieldEntryGridAdapter> Convert(List<CustomFieldEntry> entries,
            List<CustomField> customFields)
        {
            CustomField.SortAndResetDisplayOrder(customFields);

            var adapters = new List<CustomFieldEntryGridAdapter>();

            for (var i = 0; i < customFields.Count; i += 3)
            {
                var adapter = new CustomFieldEntryGridAdapter();

                for (var j = 0; j < 3; j++)
                {
                    var index = i + j;
                    if (index < customFields.Count)
                    {
                        var customField = customFields[index];
                        var customFieldEntry = entries.Find(entry => entry.CustomFieldId == customField.Id) ??
                                               new CustomFieldEntry(customField);

                        if (customFieldEntry.GreaterThanValue != null && customFieldEntry.GreaterThanValue >= customFieldEntry.NumericFieldEntry)
                        {
                            customFieldEntry.Color = "R";
                        }

                        if (customFieldEntry.LessThanValue != null && customFieldEntry.LessThanValue <= customFieldEntry.NumericFieldEntry)
                        {
                            customFieldEntry.Color = "R";
                        }

                        if (customFieldEntry.MaxValueofRange != null && customFieldEntry.MinValueofRange != null 
                            && customFieldEntry.MinValueofRange > customFieldEntry.NumericFieldEntry || customFieldEntry.MaxValueofRange < customFieldEntry.NumericFieldEntry)
                        {
                            customFieldEntry.Color = "R";
                        }

                        adapter.Add(customFieldEntry);
                    }
                }

                adapters.Add(adapter);
            }

            return adapters;
        }

        public class CustomFieldEntryGridAdapter
        {
            public const int NumberOfRowsToShow = 10;
            private readonly List<CustomFieldEntry> entries = new List<CustomFieldEntry>();

            public string FieldName0
            {
                get { return GetFieldName(0); }
            }

            public string FieldName1
            {
                get { return GetFieldName(1); }
            }

            public string FieldName2
            {
                get { return GetFieldName(2); }
            }

            public string Entry0
            {
                get { return GetEntry(0); }
            }

            public string Entry1
            {
                get { return GetEntry(1); }
            }

            public string Entry2
            {
                get { return GetEntry(2); }
            }

            public void Add(CustomFieldEntry entry)
            {
                entries.Add(entry);
            }

            internal CustomFieldEntry GetCustomField(int i)
            {
                return i < entries.Count ? entries[i] : null;
            }

            private string GetFieldName(int i)
            {
                if (i < entries.Count)
                {
                    return entries[i].CustomFieldName;
                }
                return null;
            }

            private string GetEntry(int i)
            {
                if (i < entries.Count)
                {
                    return entries[i].FieldEntryForDisplay;
                }
                return null;
            }
        }

        public class DrawFilter : IUIElementDrawFilter
        {
            public DrawPhase GetPhasesToFilter(ref UIElementDrawParams drawParams)
            {
                if (drawParams.Element is CellUIElement || drawParams.Element is UltraGridUIElement ||
                    drawParams.Element is RowUIElement)
                {
                    return DrawPhase.AfterDrawElement | DrawPhase.BeforeDrawBorders;
                }

                return DrawPhase.None;
            }

            public bool DrawElement(DrawPhase drawPhase, ref UIElementDrawParams drawParams)
            {
                if (drawPhase == DrawPhase.BeforeDrawBorders)
                {
                    return true;
                }

                var cellUiElement = drawParams.Element as CellUIElement;

                if (drawPhase == DrawPhase.AfterDrawElement && cellUiElement != null)
                {
                    var cell = cellUiElement.Cell;
                    var visiblePosition = cell.Column.Header.VisiblePosition;

                    if ((visiblePosition%2) != 0 && (visiblePosition != cell.Band.Columns.Count - 1))
                    {
                        drawParams.DrawBorders(UIElementBorderStyle.Solid, Border3DSide.Right | Border3DSide.Bottom);
                        drawParams.AppearanceData.BackColor = Color.Red;
                    }
                    else
                    {
                        drawParams.DrawBorders(UIElementBorderStyle.Solid, Border3DSide.Bottom);
                    }

                    return true;
                }

                return false;
            }
        }
    }
}