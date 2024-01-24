using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Controls.ToolStrips
{
    public delegate void SearchFilterEventHandler(object sender, SearchFilterEventArgs e);

    public partial class SearchFilterStrip : UserControl
    {
        public event SearchFilterEventHandler SearchAndFilter;

        public SearchFilterStrip()
        {
            InitializeComponent();

            searchButton.Click += SearchAndFilterChanged;
            searchTextBox.KeyDown += SearchTextBoxTextKeyDownEvent;
            filterComboBox.SelectedIndexChanged += SearchAndFilterChanged;
            searchTextBox.TextChanged += searchTextBoxTextChangedEvent;
            ClearSearchButton.Click += ClearSearchButtonClickEvent;
            ClearSearchButton.Enabled = false;
        }

        private void searchTextBoxTextChangedEvent(object sender, EventArgs e)
        {
            ClearSearchButton.Enabled = searchTextBox.TextLength > 0;
        }

        private void ClearSearchButtonClickEvent(object sender, EventArgs e)
        {
            searchTextBox.Text = String.Empty;

            var args = new SearchFilterEventArgs(filterComboBox.SelectedItem.ToString(), searchTextBox.Text);
            SearchAndFilter(this, args);

        }

        private void SearchTextBoxTextKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                if (SearchAndFilter != null)
                {
                    var args = new SearchFilterEventArgs(filterComboBox.SelectedItem.ToString(), searchTextBox.Text);
                    SearchAndFilter(this, args);
                }
            }
        }
        private void SearchAndFilterChanged(object sender, EventArgs e)
        {
            if (SearchAndFilter != null)
            {
                var args = new SearchFilterEventArgs(filterComboBox.SelectedItem.ToString(), searchTextBox.Text);
                SearchAndFilter(this, args);
            }
        }

        public List<string> FilterItemList
        {
            set
            {
                filterComboBox.Items.Clear();
                filterComboBox.Items.Add(StringResources.All);
                filterComboBox.Items.AddRange(value.ToArray());
                if (value.Count > 0)
                {
                    filterComboBox.SelectedIndex = 0;
                }
            }
        }

        public string CurrentFilterItem
        {
            set
            {
                if (!value.IsNullOrEmptyOrWhitespace())
                {
                    filterComboBox.SelectedItem = value;
                }
            }
        }
    }
}