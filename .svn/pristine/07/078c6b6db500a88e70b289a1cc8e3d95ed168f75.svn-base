using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.XtraRichEdit.Model.History;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using log4net;
using Appearance = Infragistics.Win.Appearance;

namespace Com.Suncor.Olt.Client.Controls
{
    public class SummaryGrid<T> : UltraGrid where T : class
    {
        private const int WrappedTextMaxLines = 3;

        private static readonly ILog logger = GenericLogManager.GetLogger<SummaryGrid<T>>();

        private readonly OltGridAppearance appearance;
        protected readonly IGridRenderer renderer;
        private OltUltraGridFilterUIProvider gridFilterUiProvider;
        private int maximumBands;

        protected SummaryGrid(IGridRenderer renderer, OltGridAppearance appearance, bool loadCustomFilters)
        {
            this.renderer = renderer;
            this.appearance = appearance;

            SetupGrid(loadCustomFilters);
            RegisterEvents();
        }

        public SummaryGrid(IGridRenderer renderer, OltGridAppearance appearance)
            : this(renderer, appearance, true)
        {
        }

        protected string UniqueGridName
        {
            get
            {
                var name = String.Format("{0}-{1}", GetParentName(this), renderer.GetType().Name);
                return name;
            }
        }

        public IList<T> Items
        {
            get
            {
                var bindingList = GetItems();
                if (bindingList == null) return null;
                return new ReadOnlyCollection<T>(bindingList);
            }
            set
            {
                var bindingList = new BindingList<T>(value);
                DataSource = bindingList;
                SetDefaultGridLayout();
            }
        }

        public IList<T> FilteredInItems
        {
            get
            {
                var items = new List<T>();
                foreach (var row in Rows.GetFilteredInNonGroupByRows())
                {
                    var item = (T)row.ListObject;
                    items.Add(item);
                }
                return items;
            }
        }

        public int MaximumBands
        {
            get { return maximumBands; }
            set { maximumBands = value; }
        }

        /// <summary>
        ///     Returns the selected item. Note that if multiple items are selected it will return the first one.
        ///     If nothing is selected, returns null.
        /// </summary>
        public T SelectedItem
        {
            get
            {
                var dataRow = Selected.Rows.Find<UltraGridRow>(row => row.IsDataRow);
                return dataRow != null ? (T)dataRow.ListObject : default(T);
            }
        }

        public List<T> SelectedItems
        {
            get
            {
                var dataRows = Selected.Rows.FindAll<UltraGridRow>(row => row.IsDataRow);
                return dataRows.ConvertAll(dataRow => (T)dataRow.ListObject);
            }
        }

        private void SetupGrid(bool loadCustomFilters)
        {
            DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            DisplayLayout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            //dharmesh start for INC0030492 (#3235) on 23-Sep-2016
            DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            //dharmesh End for INC0030492 (#3235) on 23-Sep-2016
            SetMultiLineSelectEnabled(appearance.MultiLineSelectedEnabled);
            SetWrapCellText(appearance.WrapTextEnabled);
            if (appearance.ExtendLastColumn)
            {
                DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            }
            if (appearance.CanEdit)
            {
                DisplayLayout.Override.CellClickAction = CellClickAction.Edit;
                if (appearance.EditRowSelect)
                {
                    DisplayLayout.Override.ActiveRowAppearance.BackColor = SystemColors.Highlight;
                    DisplayLayout.Override.ActiveRowAppearance.ForeColor = SystemColors.HighlightText;
                }
            }
            else
            {
                // ayman custom field clicked wrong test CellClickAction.RowSelect;

               var RendererType = this.renderer.GetType();

                DisplayLayout.Override.CellClickAction = RendererType.ToString() == "Com.Suncor.Olt.Client.Controls.GridRenderer.CustomFieldEntryGridRenderer" ? CellClickAction.Edit : CellClickAction.RowSelect;

            }
            DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            DisplayLayout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            if (appearance.OutLookStyleEnabled)
            {
                ConfigureOutlookGroupByAppearance();
            }
            else
            {
                DisplayLayout.GroupByBox.Hidden = true;
                if (!appearance.AllowFilterIfNonOutlook)
                {
                    DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False;
                }
                DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed;
                DisplayLayout.Override.SelectTypeCol = SelectType.None;
            }

            if (DisplayLayout.Override.AllowRowFiltering != DefaultableBoolean.False && loadCustomFilters)
            {
                LoadCustomFilters();
            }
        }

        public void LoadCustomFilters()
        {
            if (gridFilterUiProvider == null)
            {
                gridFilterUiProvider = new OltUltraGridFilterUIProvider();
            }

            DisplayLayout.Override.FilterUIProvider = gridFilterUiProvider;
            renderer.SetupCustomFilters(this, gridFilterUiProvider);
        }

        private void SetMultiLineSelectEnabled(bool isEnabled)
        {
            DisplayLayout.Override.SelectTypeRow = (isEnabled) ? SelectType.Extended : SelectType.Single;
        }

        private void SetWrapCellText(bool wrapCellTextEnabled)
        {
            // Setting the RowSizing property of the Override object to AutoFree or
            // AutoFixed will cause the WinGrid to automatically size rows so the multiline
            // cell contents fit. Note in order to take advantage of this functionality you
            // have to have multi-line columns. A column can be made multi-line by setting
            // its CellMultiLine property. This will cause the cells of the column to
            // auto-wrap the text.
            if (wrapCellTextEnabled)
            {
                DisplayLayout.Override.RowSizing = RowSizing.AutoFree;
                DisplayLayout.Override.RowSizingAutoMaxLines = WrappedTextMaxLines;
                DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True;
                DisplayLayout.Override.CellAppearance.TextTrimming = TextTrimming.EllipsisWord;
            }
            else
            {
                DisplayLayout.Override.RowSizing = RowSizing.Fixed;
            }
        }

        private void ConfigureOutlookGroupByAppearance()
        {
            DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            DisplayLayout.GroupByBox.Hidden = false;
            DisplayLayout.Override.GroupByRowInitialExpansionState = GroupByRowInitialExpansionState.Expanded;
            var groupByAppearance = new Appearance
            {
                BackColor = SystemColors.Control,
                BackColor2 = SystemColors.ControlDark,
                BackGradientAlignment = GradientAlignment.Element,
                BackGradientStyle = GradientStyle.Horizontal,
                BorderColor = SystemColors.Window
            };
            groupByAppearance.FontData.BoldAsString = "true";
            groupByAppearance.FontData.SizeInPoints = 10;
            groupByAppearance.ForeColor = Color.Black;
            DisplayLayout.Override.GroupByRowAppearance = groupByAppearance;
        }

        private void RegisterEvents()
        {
            InitializeLayout += Grid_InitializeLayout;
            InitializeRow += Grid_InitializeRow;

            ClickCell += Grid_ClickCell;

            BeforeRowFilterDropDownPopulate += HandleBeforeRowFilterDropDownPopulate;
            BeforeRowFilterDropDown += HandleBeforeRowFilterDropDown;
        }

        private void HandleBeforeRowFilterDropDownPopulate(object sender, BeforeRowFilterDropDownPopulateEventArgs e)
        {
            renderer.BeforeFilterDropDownPopulate(sender, e);
        }

        private void HandleBeforeRowFilterDropDown(object sender, BeforeRowFilterDropDownEventArgs e)
        {
            renderer.BeforeRowFilterDropDown(sender, e);
        }

        private void Grid_ClickCell(object sender, ClickCellEventArgs e)
        {
            renderer.CellClicked(e.Cell);
        }

        private void Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            renderer.SetupUnboundColumns(band);
            if (band.HasSortColumnsSpecified() == false)
            {
                renderer.SetDefaultSortColumns(band.SortedColumns);
            }
        }

        private void Grid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            renderer.SetupRow(e.Row);
        }

        private static string GetParentName(Control control)
        {
            if (control.Parent == null)
            {
                return control.GetType().Name;
            }
            var parentType = control.Parent.GetType();
            return parentType.IsSubclassOf(typeof(UserControl)) ||
                   parentType.IsSubclassOf(typeof(Form))
                ? parentType.Name
                : GetParentName(control.Parent);
        }

        public void SetDefaultGridLayout()
        {
            renderer.SetExistingColumnsInBand(DisplayLayout.Bands[0]);
            HideNestedBands();
            RefreshSortAndFilters();
        }

        private void HideNestedBands()
        {
            if (maximumBands > 0)
            {
                for (var i = maximumBands; i < DisplayLayout.Bands.Count; i++)
                {
                    DisplayLayout.Bands[i].Hidden = true;
                }
            }
        }

        protected void RefreshSortAndFilters()
        {
            DisplayLayout.Override.NotifyPropChange(PropertyIds.SortComparisonType);
            DisplayLayout.RefreshFilters();
        }

        protected BindingList<T> GetItems()
        {
            return DataSource as BindingList<T>;
        }

        public void RefreshBinding()
        {
            GetItems().ResetBindings();
        }

        public void UseExcelLikeEditNavigation()
        {
            AfterEnterEditMode += Grid_AfterEnterEditMode;
            KeyDown += Grid_KeyDown;
        }

        private void Grid_AfterEnterEditMode(object sender, EventArgs e)
        {
            try
            {
                if (ActiveCell != null)
                {
                    ActiveCell.SelectAll();
                }
            }
            catch (Exception exception)
            {
                logger.Error("Error handling AfterEnterEditMode for excel like edit navigation: " + exception);
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        DoArrowKeyAction(e, UltraGridAction.AboveCell);
                        break;
                    case Keys.Enter:
                    case Keys.Down:
                        DoArrowKeyAction(e, UltraGridAction.BelowCell);
                        break;
                    case Keys.Left:
                        DoArrowKeyAction(e, UltraGridAction.PrevCellByTab);
                        break;
                    case Keys.Right:
                        DoArrowKeyAction(e, UltraGridAction.NextCellByTab);
                        break;
                }
            }
            catch (Exception exception)
            {
                logger.Error("Error handling KeyDown for excel like edit navigation: " + exception);
            }
        }

        private void DoArrowKeyAction(KeyEventArgs e, UltraGridAction direction)
        {
            PerformAction(direction, false, false);
            PerformAction(UltraGridAction.EnterEditMode, false, false);
            e.Handled = true;
        }

        private UltraGridRow FindRowByReference(T itemToSelect)
        {
            return FindRowByReference(itemToSelect, Rows);
        }

        private UltraGridRow FindRowByReference(T itemToSelect, IEnumerable<UltraGridRow> rows)
        {
            foreach (var ultraGridRow in rows)
            {
                var row = ultraGridRow as UltraGridGroupByRow;
                if (row != null)
                {
                    var foundRow = FindRowByReference(itemToSelect, row.Rows);
                    if (foundRow != null)
                    {
                        return foundRow;
                    }
                }
                else
                {
                    var listObject = (T)ultraGridRow.ListObject;

                    if (listObject == itemToSelect)
                    {
                        return ultraGridRow;
                    }
                }
            }

            return null;
        }

        public void SelectItemByReference(T itemToSelect)
        {
            var row = FindRowByReference(itemToSelect);

            if (row == null)
            {
                return;
            }

            ActiveRow = row;

            row.Selected = false;
            row.Selected = true;
        }

        public void SelectItemsByReference(List<T> list)
        {
            list.ForEach(SelectItemByReference);
        }

        public void AutoSizeGridToDisplayWithNoScrollbars()
        {
            Height = 0;

            if (!DisplayLayout.GroupByBox.Hidden)
            {
                DisplayLayout.GroupByBox.Style = GroupByBoxStyle.Compact;
            }

            var band = DisplayLayout.Bands[0];

            if (band.HeaderVisible)
            {
                Height += DisplayLayout.Bands[0].Header.Height; //add the height of the headers if visible
            }

            if (band.ColHeadersVisible)
            {
                var columnHeaderHeight = GetLargestColumnHeight(band);
                Height += columnHeaderHeight;
            }
            foreach (var row in Rows)
            {
                Height += GetRowHeight(row);
            }
        }

        private int GetRowHeight(UltraGridRow row)
        {
            var height = 0;

            if (!row.Hidden && row.VisibleIndex != -1)
            {
                height += row.Height;
            }

            if (row.ChildBands != null && row.ChildBands.HasChildRows && row.IsExpanded)
            {
                foreach (UltraGridChildBand band in row.ChildBands)
                {
                    height += GetBandHeight(band);

                    if (!row.IsGroupByRow)
                    {
                        var columnHeaderHeight = GetLargestColumnHeight(row.Band);
                        height += columnHeaderHeight; // Add the height of a column header
                    }
                }
            }

            return height;
        }

        private int GetBandHeight(UltraGridChildBand band)
        {
            var height = 0;

            if (band.Rows.All.Length > 0)
            {
                height += DisplayLayout.Bands.Layout.InterBandSpacing;

                if (band.Band.HeaderVisible)
                {
                    height += band.Band.Header.Height; //add the height of the headers if visible
                }

                if (band.Band.ColHeadersVisible)
                {
                    var columnHeaderHeight = GetLargestColumnHeight(band.Band);
                    height += columnHeaderHeight; // Add the height of a column header
                }
            }

            foreach (UltraGridRow row in band.Rows.All)
            {
                height += GetRowHeight(row); //get the height of all child rows
            }

            return height;
        }

        private int GetLargestColumnHeight(UltraGridBand band)
        {
            return
                (from UltraGridColumn column in band.Columns select column.Header.SizeResolved.Height).Concat(new[] { 0 })
                    .Max();
        }
    }
}