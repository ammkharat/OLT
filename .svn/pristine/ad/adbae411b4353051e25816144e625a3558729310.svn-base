using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Com.Suncor.Olt.Client.Domain.CokerCard;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Appearance = Infragistics.Win.Appearance;
using ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle;
using ColumnStyle = Infragistics.Win.UltraWinGrid.ColumnStyle;
using Nullable = Infragistics.Win.UltraWinGrid.Nullable;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class CokerCardRowGridRenderer : AbstractSimpleGridRenderer
    {
        private const int COMMMENTS_MAX_LENGTH = 200;

        private const string DRUM_NAME_COLUMN = "DrumName";
        private const string ENTRY_TYPE_COLUMN = "EntryTypeDescription";
        private const string LAST_CYCLE_STEP_COLUMN = "LastCycleStepId";
        private const string HOURS_INTO_LAST_CYCLE_STEP_COLUMN = "HoursIntoLastCycle";
        private const string COMMENTS_COLUMN = "Comments";

        private const int ENTRY_COLUMN_WIDTH = 52;
        private const int COMMENTS_COLUMN_DEFAULT_WIDTH = 100;
        private const int SEPARATOR_COLUMN_WIDTH = 2;
        private const string SEPARATOR_COLUMN = "SeparatorColumn";

        private readonly bool isReadOnly; 
        private readonly Appearance readOnlyAppearance;
        private readonly Appearance separatorAppearance;

        private List<CycleStepEntryColumnKey> columnKeys = new List<CycleStepEntryColumnKey>();
        private ValueList lastCycleStepValueList = new ValueList();

        private readonly OltDropDownTextEditor commentsColumnEditor;

        private bool skipCellUpdateEvent;

        public CokerCardRowGridRenderer(bool isReadOnly)
        {
            this.isReadOnly = isReadOnly;
            
            readOnlyAppearance = new Appearance { BackColor = Color.Gainsboro};

            separatorAppearance = new Appearance {BackColor = Color.Gainsboro, BorderColor = Color.Gainsboro};

            commentsColumnEditor = new OltDropDownTextEditor(50, 150);   
        }

        public void InitializeGrid(SummaryGrid<CokerCardRow> grid)
        {
            grid.DisplayLayout.Appearance.BorderColor = Color.LightGray;
            grid.DisplayLayout.Override.CellAppearance.TextTrimming = TextTrimming.EllipsisWord;
            grid.DisplayLayout.Override.RowSizing = RowSizing.Fixed;

            grid.InitializeLayout += Grid_InitializeLayout;

            if (!isReadOnly)
            {
                grid.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.False;
                grid.DisplayLayout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells;
                grid.UseExcelLikeEditNavigation();

                grid.CellDataError += Grid_CellDataError;
                grid.AfterCellUpdate += Grid_AfterCellUpdate;
                grid.BeforeEnterEditMode += Grid_BeforeEnterEditMode;
                grid.BeforeCellActivate += Grid_BeforeCellActivate;
            }
            else
            {
                grid.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True;
                grid.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            }
        }

        public List<CycleStepEntryColumnKey> CycleStepEntryColumnKeys
        {
            private get { return columnKeys; }
            set
            {
                columnKeys = value ?? new List<CycleStepEntryColumnKey>();
                lastCycleStepValueList = new ValueList();
                lastCycleStepValueList.ValueListItems.Add(null, "");
                foreach (CycleStepEntryColumnKey columnKey in columnKeys)
                {
                    if (!columnKey.IsLastStepInPreviousCokerCard)
                    {
                        lastCycleStepValueList.ValueListItems.Add(columnKey.CycleStepId, columnKey.CycleStepName);
                    }
                }
            }
        }

        private static void Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.MergedCellStyle = MergedCellStyle.Always;
        }

        private static void Grid_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            e.RaiseErrorEvent = false;
            e.RestoreOriginalValue = true;
            e.StayInEditMode = false;
        }

        private void Grid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (!skipCellUpdateEvent && IsCycleStepEntryColumn(e.Cell.Column))
            {
                CokerCardRow cokerCardRow = (CokerCardRow)e.Cell.Row.ListObject;
                DateTime? value = null;
                if (e.Cell.Value != null && e.Cell.Value is DateTime)
                {
                    value = (DateTime?) e.Cell.Value;
                }
                cokerCardRow.SetCycleStepEntryDateTime((CycleStepEntryColumnKey) e.Cell.Column.Tag, value);
            }
        }

        private static void Grid_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            UltraGrid grid = sender as UltraGrid;
            if (grid != null &&
                grid.ActiveCell != null)
            {
                if (IsCycleStepEntryColumn(grid.ActiveCell.Column))
                {
                    CokerCardRow cokerCardRow = (CokerCardRow) grid.ActiveCell.Row.ListObject;
                    if (cokerCardRow.IsReadOnlyCycleStepEntry((CycleStepEntryColumnKey) grid.ActiveCell.Column.Tag))
                    {
                        e.Cancel = true;
                    }
                }
                else if (grid.ActiveCell.Column.Key == LAST_CYCLE_STEP_COLUMN)
                {
                    CokerCardRow cokerCardRow = (CokerCardRow)grid.ActiveCell.Row.ListObject;
                    if (!cokerCardRow.AllowedToEnterLastCycleStep)
                    {
                        e.Cancel = true;
                    }
                }
                else if (grid.ActiveCell.Column.Key == HOURS_INTO_LAST_CYCLE_STEP_COLUMN)
                {
                    CokerCardRow cokerCardRow = (CokerCardRow)grid.ActiveCell.Row.ListObject;
                    if (!cokerCardRow.AllowedToEnterHoursIntoLastCycleStep)
                    {
                        e.Cancel = true;
                    }
                }
                else if (grid.ActiveCell.Column.Key == COMMENTS_COLUMN)
                {
                    CokerCardRow cokerCardRow = (CokerCardRow) grid.ActiveCell.Row.ListObject;
                    if (!cokerCardRow.AllowedToEnterComments)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void Grid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (!isReadOnly && e.Cell.Column.Key == COMMENTS_COLUMN)
            {
                CokerCardRow cokerCardRow = (CokerCardRow) e.Cell.Row.ListObject;
                e.Cell.EditorComponent = cokerCardRow.AllowedToEnterComments ? commentsColumnEditor : null;
            }
        }

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = isReadOnly ? DefaultableBoolean.False : DefaultableBoolean.True;


            int position = 0;

            band.Columns[DRUM_NAME_COLUMN].Format(RendererStringResources.Drum, position++, 50);
            band.Columns[DRUM_NAME_COLUMN].PerformAutoResize(PerformAutoSizeType.AllRowsInBand, true);

            band.Columns[ENTRY_TYPE_COLUMN].Format("", position++);
            band.Columns[ENTRY_TYPE_COLUMN].PerformAutoResize(PerformAutoSizeType.AllRowsInBand, true);

            int maxCycleStepColumn = ENTRY_COLUMN_WIDTH;

            foreach (CycleStepEntryColumnKey key in CycleStepEntryColumnKeys)
            {
                UltraGridColumn column = band.Columns[key.Key];

                column.Format(key.ColumnCaption, position++, ENTRY_COLUMN_WIDTH, true);
                column.Style = ColumnStyle.Time;
                column.Editor.DataFilter = new TimeDataFilter();
                column.MaskInput = "{time}";

                int autoWidth = column.CalculateAutoResizeWidth(PerformAutoSizeType.None, true);
                int width = Math.Max(ENTRY_COLUMN_WIDTH, autoWidth);
                column.Width = width;

                maxCycleStepColumn = Math.Max(width, maxCycleStepColumn);
            }

            band.Columns[SEPARATOR_COLUMN].Format("", position++, SEPARATOR_COLUMN_WIDTH);

            int lastCycleStepColumnWidth = Math.Max(57, maxCycleStepColumn);
            if (!isReadOnly)
            {
                lastCycleStepColumnWidth += 18;   
            }
            band.Columns[LAST_CYCLE_STEP_COLUMN].Format(RendererStringResources.LastCycleStep, position++, lastCycleStepColumnWidth);
            band.Columns[LAST_CYCLE_STEP_COLUMN].Style = ColumnStyle.DropDownList;
            band.Columns[LAST_CYCLE_STEP_COLUMN].ButtonDisplayStyle = ButtonDisplayStyle.OnCellActivate;
            band.Columns[LAST_CYCLE_STEP_COLUMN].ValueList = lastCycleStepValueList;

            band.Columns[HOURS_INTO_LAST_CYCLE_STEP_COLUMN].Format(RendererStringResources.HoursIntoLastCycle, position++, 50, true);

            int commentsWidth = COMMENTS_COLUMN_DEFAULT_WIDTH;
            if (!isReadOnly)
            {
                commentsWidth += 200;
            }
            band.Columns[COMMENTS_COLUMN].Format(RendererStringResources.Comments, position++, commentsWidth);
            band.Columns[COMMENTS_COLUMN].MaxLength = COMMMENTS_MAX_LENGTH;
            band.Columns[COMMENTS_COLUMN].Nullable = Nullable.EmptyString;
            band.Columns[COMMENTS_COLUMN].ButtonDisplayStyle = ButtonDisplayStyle.OnCellActivate;

            foreach (UltraGridColumn column in band.Columns)
            {
                if (!isReadOnly &&
                    (IsCycleStepEntryColumn(column) ||
                     Equals(column.Key, LAST_CYCLE_STEP_COLUMN) ||
                     Equals(column.Key, HOURS_INTO_LAST_CYCLE_STEP_COLUMN) ||
                     Equals(column.Key, COMMENTS_COLUMN)))
                {
                    column.CellActivation = Activation.AllowEdit;                    
                }
                else if (Equals(column.Key, SEPARATOR_COLUMN))
                {
                    column.CellActivation = Activation.Disabled;                    
                }
                else
                {
                    column.CellActivation = Activation.NoEdit;                    
                }

                column.SortIndicator = SortIndicator.None;
                column.MergedCellEvaluator = new MergedCellEvaluator(isReadOnly);

                if (isReadOnly)
                {
                    column.Header.Appearance.ForeColorDisabled = Color.Black;
                }                
            }
        }

        private static bool IsCycleStepEntryColumn(UltraGridColumn column)
        {
            return column.Tag is CycleStepEntryColumnKey;
        }

        public override void SetupUnboundColumns(UltraGridBand band)
        {
            band.Columns.ClearUnbound();

            UltraGridColumn separatorColumn = band.Columns.Add(SEPARATOR_COLUMN, "");
            separatorColumn.CellActivation = Activation.Disabled;
            separatorColumn.CellAppearance = separatorAppearance;
            separatorColumn.Width = SEPARATOR_COLUMN_WIDTH;
            separatorColumn.MinWidth = SEPARATOR_COLUMN_WIDTH;
            separatorColumn.LockedWidth = true;
            separatorColumn.TabStop = false;
            
            foreach (CycleStepEntryColumnKey key in columnKeys)
            {
                UltraGridColumn column = band.Columns.Add(key.Key, key.ColumnCaption);
                column.Tag = key;
                column.DataType = typeof(DateTime);
                column.Width = ENTRY_COLUMN_WIDTH;
            }   
        }

        public override void SetupRow(UltraGridRow row)
        {
            CokerCardRow cokerCardRow = (CokerCardRow)row.ListObject;

            skipCellUpdateEvent = true;
            foreach (CycleStepEntryColumnKey key in columnKeys)
            {
                row.Cells[key.Key].Value = cokerCardRow.GetCycleStepEntryDateTime(key);
                if (cokerCardRow.IsReadOnlyCycleStepEntry(key))
                {
                    row.Cells[key.Key].Appearance = readOnlyAppearance;
                }
            }
            skipCellUpdateEvent = false;

            if (!isReadOnly)
            {
                if (!cokerCardRow.AllowedToEnterLastCycleStep)
                {
                    row.Cells[LAST_CYCLE_STEP_COLUMN].Appearance = readOnlyAppearance;
                }
                if (!cokerCardRow.AllowedToEnterHoursIntoLastCycleStep)
                {
                    row.Cells[HOURS_INTO_LAST_CYCLE_STEP_COLUMN].Appearance = readOnlyAppearance;
                }
                if (!cokerCardRow.AllowedToEnterComments)
                {
                    row.Cells[COMMENTS_COLUMN].Appearance = readOnlyAppearance;
                }
            }

            if (row.Index % 2 == 1)
            {
                row.RowSpacingAfter = 1;
            }

            if (isReadOnly)
            {
                row.Appearance.ForeColorDisabled = Color.Black;         
            }
        }

        private class MergedCellEvaluator : IMergedCellEvaluator
        {
            private readonly bool isReadOnly;

            public MergedCellEvaluator(bool isReadOnly)
            {
                this.isReadOnly = isReadOnly;
            }

            public bool ShouldCellsBeMerged(UltraGridRow row1, UltraGridRow row2, UltraGridColumn column)
            {
                if (column.Key == DRUM_NAME_COLUMN ||
                    (isReadOnly &&
                     (column.Key == LAST_CYCLE_STEP_COLUMN ||
                      column.Key == HOURS_INTO_LAST_CYCLE_STEP_COLUMN ||
                      column.Key == COMMENTS_COLUMN)))
                {
                    object drumName1 = row1.GetCellValue(DRUM_NAME_COLUMN);
                    object drumName2 = row2.GetCellValue(DRUM_NAME_COLUMN);
                    return Equals(drumName1, drumName2);
                }
                return false;
            }
        }
    }

    public class TimeDataFilter : IEditorDataFilter
    {
        public object Convert(EditorDataFilterConvertArgs args)
        {
            if (args.Direction == ConversionDirection.DisplayToEditor)
            {
                string value = args.Value as string;
                if (value != null)
                {
                    const string hourMinuteDelimiter = ":";
                    if (!Equals(value, hourMinuteDelimiter))
                    {
                        if (value.IndexOf(hourMinuteDelimiter) == 0)
                        {
                            DateTime? converted = ConvertToDateTime("00" + value);
                            if (converted != null)
                            {
                                args.Handled = true;
                                args.IsValid = true;
                                return converted.Value;
                            }
                        }
                        else if (value.IndexOf(hourMinuteDelimiter) == value.Length - 1)
                        {
                            DateTime? converted = ConvertToDateTime(value + "00");
                            if (converted != null)
                            {
                                args.Handled = true;
                                args.IsValid = true;
                                return converted.Value;
                            }
                        }
                    }
                }
            }

            return args.Value;
        }

        private static DateTime? ConvertToDateTime(string displayValue)
        {
            DateTime converted;
            if (DateTime.TryParse(displayValue, out converted))
            {
                return converted;
            }
            return null;
        }

    }
      
    
}
