using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls
{
    public delegate void DomainGridEventHandler<TDomainObject>(object sender, DomainEventArgs<TDomainObject> e) where TDomainObject : DomainObject;

    public class DomainSummaryGrid<T> : SummaryGrid<T>, IDomainSummaryGrid where T : DomainObject
    {
        public event DomainGridEventHandler<T> SelectedItemChanged;
        public event DomainGridEventHandler<T> DoubleClickSelected;        

        public DomainSummaryGrid(IGridRenderer renderer, OltGridAppearance appearance, string gridName, bool loadCustomFilters) : base(renderer, appearance, loadCustomFilters)
        {
            Name = gridName;
            RegisterEvents();            
        }

        public DomainSummaryGrid(IGridRenderer renderer, OltGridAppearance appearance, string gridName) : this(renderer, appearance, gridName, true)
        {                     
        }

        private void RegisterEvents()
        {
            DoubleClickRow += DomainSummaryGrid_DoubleClickRow;
        }
                      
        public bool ContainsItem(long? id)
        {
            return FindRowById(id) != null;
        }

        public void SelectItem(T itemToSelect)
        {
            if(null != itemToSelect)
            {
                SelectItemById(itemToSelect.Id);
            }
        }

        public void SelectItemById(long? id)
        {
            UltraGridRow row = FindRowById(id);
            if (row == null) return;

            ActiveRow = row; //this causes the scroll to the selected row in grid
            // NOTE: Eric: We un-select then re-select the item in order for the HandleSelectedItemChanged
            //       event to be fired again. This is desirable when a remote event gets raised,
            //       and the currently selected item has changes.
            row.Selected = false;
            row.Selected = true;
        }

        public void ScrollToItemById(long? id)
        {
            UltraGridRow row = FindRowById(id);
            if (row == null) return;

            this.ScrollToRow(row);
        }

        public void ClearSelections()
        {
            Selected.Rows.Clear();
        }

        public T FindItem(long? id)
        {
            UltraGridRow row = FindRowById(id);
            return row == null ? null : (T) row.ListObject;
        }

        public bool ItemIsInGrid(long id)
        {
            return FindItem(id) != null;
        }
       
        public UltraGridRow FindRowById(long? id)
        {
            return id == null ? null : Rows.FindRow<T>(id);
        }

        private void DomainSummaryGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            //Get the underlying DTO object
            T selectedItem = SelectedItem;
            //raise it if there's a selected item
            if(selectedItem != null && DoubleClickSelected != null)
            {
                DoubleClickSelected(this, new DomainEventArgs<T>(selectedItem));
            }
        }

        public void AddItem(T item)
        {
            BindingList<T> items = GetItems();
            if (items != null)
            {
                items.Add(item);
                RefreshSortAndFiltersAndMaintainSelectedItem();                
            }
        }

        // when the grid is grouped by a column, we have to manually re-select the selected row
        private void RefreshSortAndFiltersAndMaintainSelectedItem()
        {
            T selectedItem = SelectedItem;

            RefreshSortAndFilters();

            if (selectedItem != null && GridIsGroupedBySomething())
            {
                SelectItemByReference(selectedItem);
            }
        }

        private bool GridIsGroupedBySomething()
        {
            return Rows.Exists(row => row.IsGroupByRow);
        }

        public void RemoveItemByReferenceAndSelectFirstRow(T item)
        {
            if (DataSource is BindingList<T>)
            {
                GetItems().Remove(item);
            }
            else
            {
                List<T> items = new List<T>(Items);
                items.Remove(item);
                Items = items;
            }
            if (Items.Count > 0)
            {
                SelectFirstRow();
            }
        }

        public void RemoveItem(T item)
        {
            UltraGridRow row = FindRowById(item.Id);
            if (row != null)
            {
                GetItems().Remove(item);

                // Fire event to indicate the selection might have changed:
                OnAfterSelectChange(new AfterSelectChangeEventArgs(typeof (UltraGridRow)));
            }
        }

        public void AddOrUpdateItems(List<T> updatedItems)
        {
            BindingList<T> items = GetItems();
            if (items == null) return;

            foreach (T item in updatedItems)
            {
                var oldVersion = FindItem(item.Id);
                var updateIndex = Items.IndexOf(oldVersion);
                 
                if (updateIndex == -1)
                {
                    items.Add(item);
                }
                else if (Items.HasIndex(updateIndex))
                {
                    items[updateIndex] = item;
                    renderer.SetupRow(Rows.FindRow<T>(item.Id));
                }
            }

            RefreshSortAndFiltersAndMaintainSelectedItem();
        }

        public void UpdateItem(int updateIndex, T updatedVersion)
        {
            BindingList<T> items = GetItems();
            items[updateIndex] = updatedVersion;
            renderer.SetupRow(Rows.FindRow<T>(updatedVersion.Id));
            RefreshSortAndFiltersAndMaintainSelectedItem();
        }

        protected override void OnAfterSelectChange(AfterSelectChangeEventArgs e)
        {
            base.OnAfterSelectChange(e);
            if (SelectedItemChanged != null)
            {
                T selectedItem = SelectedItem;
                SelectedItemChanged(this, new DomainEventArgs<T>(selectedItem));
            }
        }

        internal void SetPriorityDisplaySettings()
        {
            DisplayLayout.GroupByBox.Hidden = true;            
            DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False;
        }

        public void SelectFirstRow()
        {
            RowsCollection rowsCollection = Rows;

            if (rowsCollection.Count > 0)
            {
                UltraGridRow ultraGridRow = rowsCollection[0];
                ultraGridRow.Selected = true;
                ultraGridRow.Activated = true;
            }            
        }

        public bool HideGroupByArea
        {
            set
            {
                DisplayLayout.GroupByBox.Hidden = value;
            }
        }

        public IGridRenderer Renderer
        {
            get { return renderer; }
        }

        public void SelectSingleItemByIndex(int visibleIndex)
        {
            ClearSelections();
            SelectAdditionalItemByIndex(visibleIndex);
        }

        private void SelectAdditionalItemByIndex(int visibleIndex)
        {
            List<UltraGridRow> rows = ExtractDataRows(Rows);

            if (rows.Count > visibleIndex)
            {
                rows[visibleIndex].Selected = true;
            }
        }

        private List<UltraGridRow> ExtractDataRows(IEnumerable<UltraGridRow> rows)
        {
            List<UltraGridRow> resultRows = new List<UltraGridRow>();

            foreach (UltraGridRow ultraGridRow in rows)
            {
                UltraGridGroupByRow row = ultraGridRow as UltraGridGroupByRow;
                if (row != null)
                {
                    resultRows.AddRange(ExtractDataRows(row.Rows));
                }
                else
                {
                    resultRows.Add(ultraGridRow);
                }
            }

            return resultRows;
        }
    }
}