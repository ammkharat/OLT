using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls
{
    // TODO:  When we refactor the details to do a real flow layout, 
    // replace all the copy-paste of this code in other places (LogDetails, SummaryLogDetails) with this same control.
    public partial class ShiftHandoverCustomFieldEntrySetControl : UserControl
    {
        private SummaryGrid<CustomFieldEntryGridRenderer.CustomFieldEntryGridAdapter> customFieldEntryGrid;

        public event CustomFieldEntryClickHandler CustomFieldEntryClicked;

        public ShiftHandoverCustomFieldEntrySetControl()
        {
            InitializeComponent();
            InitializeCustomFieldEntriesGrid();
        }

        private void InitializeCustomFieldEntriesGrid()
        {
            CustomFieldEntryGridRenderer customFieldEntryGridRenderer = new CustomFieldEntryGridRenderer();
            customFieldEntryGridRenderer.CustomFieldEntryClicked += CustomFieldEntryGridRendererCustomFieldEntryClicked;
            customFieldEntryGrid = new SummaryGrid<CustomFieldEntryGridRenderer.CustomFieldEntryGridAdapter>(
                customFieldEntryGridRenderer,
                OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT);

            customFieldEntryGrid.Dock = DockStyle.Fill;
            customFieldEntryGrid.DisplayLayout.BorderStyle = UIElementBorderStyle.None;            
            customFieldEntryGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            customFieldEntryGrid.DisplayLayout.GroupByBox.Hidden = true;
            customFieldEntryGrid.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
            customFieldEntryGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            customFieldEntryGrid.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            customFieldEntryGrid.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.None;
            customFieldEntryGrid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            customFieldEntryGrid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.None;
            customFieldEntryGrid.DisplayLayout.Override.RowSizingAutoMaxLines = CustomFieldEntryGridRenderer.CustomFieldEntryGridAdapter.NumberOfRowsToShow;

            customFieldEntryGrid.DrawFilter = new CustomFieldEntryGridRenderer.DrawFilter();            

            customFieldEntriesPanel.Controls.Add(customFieldEntryGrid);
        }

        private void CustomFieldEntryGridRendererCustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            if (CustomFieldEntryClicked != null && !customFieldEntry.IsJustForDisplay)
            {
                CustomFieldEntryClicked(customFieldEntry);
            }
        }

        public void SetIHasEntriesItem(IHasCustomFieldEntries iHasEntries, List<CustomField> customFields)
        {
            customFieldEntryGrid.Items = CustomFieldEntryGridRenderer.Convert(iHasEntries.CustomFieldEntries, customFields);
        }

        public void FitToContents()
        {
            SuspendLayout();

            int beforeHeight = customFieldEntryGrid.Height;

            int newHeight = 0;
            foreach (UltraGridRow row in customFieldEntryGrid.Rows)
            {
                newHeight += row.Height;
            }
            
            int deltaHeight = newHeight - beforeHeight;

            Height = Height + deltaHeight;
            customFieldEntriesPanel.Height += deltaHeight;
            customFieldEntryGrid.Height = newHeight;
            
            ResumeLayout(false);
        }
    }
}
