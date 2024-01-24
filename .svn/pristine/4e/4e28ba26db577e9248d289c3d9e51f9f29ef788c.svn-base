using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Utility.Comparer;

namespace Com.Suncor.Olt.Client.Controls
{
    public delegate void DomainEventHandler<TU>(object sender, DomainEventArgs<TU> e) where TU : DomainObject;    

    public class DomainListView<T> : OltListView where T : DomainObject
    {
        public event DomainEventHandler<T> SelectedItemChanged;
        public event DomainEventHandler<T> DoubleClickSelected;

        private readonly IDomainListViewRenderer<T> renderer;
        private readonly DomainListViewColumnCollection domainListViewColumns;
        private List<T> sortItemList = new List<T>();
        private int? groupByColumnIndex;

        bool sortAscending;
        int? lastSortedColumn;

        public DomainListView(IDomainListViewRenderer<T> renderer, bool showItemToolTips)
            : this(renderer, showItemToolTips, false)
        {
            
        }

        public DomainListView(IDomainListViewRenderer<T> renderer, bool showItemToolTips, bool multiSelect)
        {
            ShowItemToolTips = showItemToolTips;
            this.renderer = renderer;
            Dock = DockStyle.Fill;
            View = View.Details;
            AllowColumnReorder = true;
            Sorting = SortOrder.None;
            BorderStyle = BorderStyle.None;
            HideSelection = false;
            FullRowSelect = true;
            MultiSelect = multiSelect;

            domainListViewColumns = renderer.Columns;
            EnsureAllColumnNamesMapToDomainProperty(domainListViewColumns);
            Columns.AddRange(domainListViewColumns.ToColumnHeaders());

            SelectedIndexChanged += OnSelectedIndexChanged;
            DoubleClick += DomainListView_DoubleClick;
            ColumnClick += OnColumnClick;
        }

        private static void EnsureAllColumnNamesMapToDomainProperty(DomainListViewColumnCollection domainListViewColumnsToMap)
        {
            domainListViewColumnsToMap.ForEach(column =>
                                                   {
                                                       if (DomainMissingProperty(column.Name))
                                                       {
                                                           throw new ArgumentException("Column name:<" + column.Name
                                                                                       +
                                                                                       "> doesn't map to a property on domain object:<" +
                                                                                       typeof (T) + ">");
                                                       }
                                                   });
        }

        private static bool DomainMissingProperty(string propertyName)
        {
            return typeof(T).GetProperty(propertyName) == null;
        }

        private void DomainListView_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedItem != null && DoubleClickSelected != null)
            {
                DoubleClickSelected(this, new DomainEventArgs<T>(SelectedItem.Item));
            }
        }

        public bool SortAscending
        {
            get { return sortAscending; }
        }

        public List<T> ItemList
        {
            get { return sortItemList; }
            set
            {
                sortItemList = new List<T>(value);
                RenderListView();
            }
        }


        public void SearchAndFilter(string filterValue, string searchString)
        {
            renderer.FilterString = filterValue;
            renderer.SearchString = searchString;
            RenderListView();
        }

        public int? GroupByColumnIndex
        {
            get
            {
                return groupByColumnIndex;
            }
            set
            {
                groupByColumnIndex = value;
                RenderListView();
            }
        }

        private void RenderListView()
        {
            DomainListViewItem<T> previouslySelected = SelectedItem;
            Items.Clear();
            foreach (T item in sortItemList)
            {
                ListViewItem lvi = renderer.RenderItem(item);
                if (lvi != null)
                {
                    if (groupByColumnIndex.HasValue && Groups.Count > 0)
                    {

                        lvi.Group = Groups[lvi.SubItems[(int)groupByColumnIndex].Text];
                    }
           
                    Items.Add(lvi);
                    if (previouslySelected != null && previouslySelected.Item.Equals(item))
                    {
                        lvi.Selected = true;
                    }
                }
            }

            if (SelectedItem == null && Items.Count > 0)
            {
                Items[Items.Count - 1].Selected = true;
            }
            SetColumnSizes();
        }

        private void SetColumnSizes()
        {
            domainListViewColumns.SetColumnHeaderWidths(Columns);
        }

        private void OnSelectedIndexChanged(object sender, EventArgs args)
        {
            if (SelectedItem != null && SelectedItemChanged != null)
            {
                SelectedItemChanged(this, new DomainEventArgs<T>(SelectedItem.Item));
            }
        }

        public DomainListViewItem<T> SelectedItem
        {
            get
            {
                DomainListViewItem<T> result = null;
                if (SelectedItems.Count > 0)
                {
                    result = SelectedItems[0] as DomainListViewItem<T>;
                }
                return result;
            }
        }

        public List<T> GetSelectedItems()
        {
            return SelectedItems.ConvertAll<T, DomainListViewItem<T>>(item => item.Item);
        }
        
        public void SetSelectedItems(List<T> newSelectedItems)
        {
            foreach (DomainListViewItem<T> listViewItem in Items)
            {
                listViewItem.Selected = newSelectedItems.Contains(listViewItem.Item);              
            }
        }

        public void SelectFirstItem()
        {
            if (Items.Count > 0)
            {
                Items[0].Selected = true;
            }
        }

        private void OnColumnClick(object sender, ColumnClickEventArgs args)
        {            
            SortByColumn(args.Column);
        }

        //toggles the sort on that column index
        public void SortByColumn(int columnIndex)
        {
            //check to see if possible column value
            if (columnIndex < Columns.Count)
            {
                if (lastSortedColumn.HasValue && lastSortedColumn == columnIndex)
                {
                    sortAscending = !sortAscending;
                }
                else
                {
                    sortAscending = true;
                    lastSortedColumn = columnIndex;
                }

                ColumnHeader columnHeader = Columns[columnIndex];
                Sort(sortItemList, columnHeader.Name, sortAscending);
                Sorting = SortOrder.None;

                RenderListView();
            }
        }

        private static void Sort<T>(List<T> items, string propertyName, bool sortByAscendOrder)
        {
            IComparer<T> comparer = new PropertyComparer<T>(propertyName);

            if (sortByAscendOrder == false)
            {
                comparer = new ReverseComparer<T>(comparer);
            }

            items.Sort(comparer);
        }
    }
}
