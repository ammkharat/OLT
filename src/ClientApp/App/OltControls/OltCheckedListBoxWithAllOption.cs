using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltCheckedListBoxWithAllOption : UserControl
    {
        public Action<List<object>> ItemChecked;

        private object itemRepresentingAll;

        public OltCheckedListBoxWithAllOption()
        {
            InitializeComponent();
            checkedListBox.CheckOnClick = true;
            checkedListBox.ItemCheck += CheckedListBox_ItemCheck;
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            object item = checkedListBox.Items[e.Index];
            if (ReferenceEquals(item, itemRepresentingAll))
            {
                bool checkAll = e.NewValue == CheckState.Checked;
                checkedListBox.ItemCheck -= CheckedListBox_ItemCheck;
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    if (e.Index != i)
                    {
                        checkedListBox.SetItemChecked(i, checkAll);
                    }
                }
                checkedListBox.ItemCheck += CheckedListBox_ItemCheck;
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                checkedListBox.ItemCheck -= CheckedListBox_ItemCheck;
                checkedListBox.SetItemChecked(checkedListBox.Items.IndexOf(itemRepresentingAll), false);
                checkedListBox.ItemCheck += CheckedListBox_ItemCheck;
            }
            else if (e.NewValue == CheckState.Checked && AllItemsExcludingCurrentAreSelected(e.Index))
            {
                checkedListBox.ItemCheck -= CheckedListBox_ItemCheck;
                checkedListBox.SetItemChecked(checkedListBox.Items.IndexOf(itemRepresentingAll), true);
                checkedListBox.ItemCheck += CheckedListBox_ItemCheck;
            }

            if (ItemChecked != null)
            {
                // checkedListBox.ItemChecked happens before the checkedListBox.CheckedItems 
                // collection gets updated so we have to mannually account for the latest 
                // checked/unchecked item here.
                List<object> selectedItems = CheckedItems;
                if (e.NewValue == CheckState.Checked && !ReferenceEquals(item, itemRepresentingAll))
                {
                    selectedItems.Add(item);
                }
                else if (e.NewValue == CheckState.Unchecked && selectedItems.Contains(item))
                {
                    selectedItems.Remove(item);
                }
                ItemChecked(selectedItems);
            }
        }

        private bool AllItemsExcludingCurrentAreSelected(int currentIndex)
        {
            int itemRepresentingAllIndex = checkedListBox.Items.IndexOf(itemRepresentingAll);
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (i != itemRepresentingAllIndex && 
                    i != currentIndex &&
                    !checkedListBox.GetItemChecked(i))
                {
                    return false;
                }
            }
            return true;
        }

        public void SetItems<T>(List<T> items, T allItem, bool selectAll)
        {
            itemRepresentingAll = allItem;

            checkedListBox.Items.Clear();

            if (items.Count > 0)
            {
                checkedListBox.Items.Add(allItem);
                foreach (T item in items)
                {
                    checkedListBox.Items.Add(item);
                }

                if (selectAll)
                {
                    CheckAll();
                }
            }
        }

        public List<object> CheckedItems
        {
            get
            {
                List<object> checkedItems = new List<object>();

                foreach (object checkedItem in checkedListBox.CheckedItems)
                {
                    if (!ReferenceEquals(checkedItem, itemRepresentingAll))
                    {
                        checkedItems.Add(checkedItem);
                    }
                }

                return checkedItems;
            }
        }

        public void SetItemChecked(object item, bool itemChecked)
        {
            int index = checkedListBox.Items.IndexOf(item);
            if (index >= 0)
            {
                checkedListBox.SetItemChecked(index, itemChecked);
            }
        }

        public void CheckAll()
        {
            SetItemChecked(itemRepresentingAll, true);
        }

        public void UnCheckAll()
        {
            int itemRepresentingAllIndex = checkedListBox.Items.IndexOf(itemRepresentingAll);
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (i != itemRepresentingAllIndex && checkedListBox.GetItemChecked(i))
                {
                    checkedListBox.SetItemChecked(i, false);
                }
            }
        }
    }
}
