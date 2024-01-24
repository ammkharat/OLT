using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ShiftHandoverEmailConfigurationForm : BaseForm, IShiftHandoverEmailConfigurationFormView
    {
        public event Action AddButtonClicked;
        public event Action EditButtonClicked;
        public event Action DeleteButtonClicked;
        public event Action CloseButtonClicked;
         
        private DomainSummaryGrid<ShiftHandoverEmailConfiguration> grid; 

        public ShiftHandoverEmailConfigurationForm()
        {
            InitializeComponent();
            grid = new DomainSummaryGrid<ShiftHandoverEmailConfiguration>(new ShiftHandoverEmailConfigurationGridRenderer(), OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT, "Email Configuration");
            grid.DisplayLayout.GroupByBox.Hidden = true;
            grid.TabIndex = 0;
            grid.MaximumBands = 1;
            panel1.Controls.Add(grid);
            grid.Dock = DockStyle.Fill;

            addButton.Click += HandleAddButtonClick;
            editButton.Click += HandleEditButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;
            closeButton.Click += HandleCloseButtonClick;
        }

        public List<ShiftHandoverEmailConfiguration> ShiftHandoverEmailConfigurations
        {
            set { grid.Items = value; }
        }

        public ShiftHandoverEmailConfiguration SelectedConfiguration
        {
            get { return grid.SelectedItem; }
            set { grid.SelectItemById(value.IdValue); }
        }

        public DialogResult ConfirmDeleteDialog()
        {
            return OltMessageBox.Show(this, StringResources.AreYouSureDeleteDialogMessage, string.Empty, MessageBoxButtons.OKCancel);
        }

        public void SelectFirstItem()
        {
            grid.SelectFirstRow();
        }

        private void HandleAddButtonClick(object sender, EventArgs e)
        {
            if (AddButtonClicked != null)
            {
                AddButtonClicked();
            }
        }

        private void HandleEditButtonClick(object sender, EventArgs e)
        {
            if (EditButtonClicked != null)
            {
                EditButtonClicked();
            }
        }

        private void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            if (DeleteButtonClicked != null)
            {
                DeleteButtonClicked();
            }
        }

        private void HandleCloseButtonClick(object sender, EventArgs e)
        {
            if(CloseButtonClicked != null)
            {
                CloseButtonClicked();
            }
        }
    }
}
