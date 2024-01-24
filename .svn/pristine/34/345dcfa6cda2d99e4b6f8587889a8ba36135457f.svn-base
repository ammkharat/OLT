using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureSiteCommunicationsForm : BaseForm, IConfigureSiteCommunicationsView
    {
        public event Action AddSiteCommunication;
        public event Action EditSiteCommunication;
        public event Action DeleteSiteCommunication;
        public event Action SelectedSiteCommunicationChanged;

        private bool deleteAllChecked = false;

        private DomainSummaryGrid<SiteCommunicationDisplayAdapter> grid;

        public ConfigureSiteCommunicationsForm()
        {
            InitializeComponent();
            InitializeGrid();

            //ayman site communication
            if (ClientSession.GetUserContext().Role.Name == "Technical Administrator")
            {
                chkDeleteAll.Visible = true;
                DeleteAllChecked = true;
            }
            else
            {
                chkDeleteAll.Visible = false;
                DeleteAllChecked = false;
            }

            addButton.Click += HandleAddButtonClick;
            editButton.Click += HandleEditButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;

            grid.SelectedItemChanged += HandleSelectedItemChanged;
            grid.InitializeRow += HandleInitializeGridRow;
        }

        private void HandleInitializeGridRow(object sender, InitializeRowEventArgs e)
        {
            UltraGridCell cell = e.Row.Cells["TimeUntilActive"];

            string value = (string)cell.Value;
            if (value == SiteCommunicationDisplayAdapter.GetActiveText())
            {
                cell.Appearance.ForeColor = Color.Green;
            }
            else if (value == SiteCommunicationDisplayAdapter.GetExpiredText())
            {
                cell.Appearance.ForeColor = Color.Gray;
            }
            else
            {
                cell.Appearance.ForeColor = Color.Black;
            }
        }

        private void HandleSelectedItemChanged(object sender, DomainEventArgs<SiteCommunicationDisplayAdapter> e)
        {
            if (SelectedSiteCommunicationChanged != null)
            {
                SelectedSiteCommunicationChanged();
            }
        }

        private void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            if (DeleteSiteCommunication != null)
            {
                DeleteSiteCommunication();
            }
        }

        private void HandleEditButtonClick(object sender, EventArgs e)
        {
            if (EditSiteCommunication != null)
            {
                EditSiteCommunication();
            }
        }

        private void HandleAddButtonClick(object sender, EventArgs eventArgs)
        {
            if (AddSiteCommunication != null)
            {
                AddSiteCommunication();
            }
        }

        private void InitializeGrid()
        {
            grid = new DomainSummaryGrid<SiteCommunicationDisplayAdapter>(new SiteCommunicationGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);

            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;

            grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            grid.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            gridPanel.Controls.Add(grid);
        }

        public List<SiteCommunication> SiteCommunications
        {
            set { grid.Items = value.ConvertAll(sc => new SiteCommunicationDisplayAdapter(sc)); }
        }

        public SiteCommunication SelectedSiteCommunication
        {
            get
            {
                return grid.SelectedItem == null ? null : grid.SelectedItem.GetSiteCommunication();
            }
            set
            {
                SiteCommunicationDisplayAdapter displayAdapter = grid.Items.Find(adapter => adapter.GetSiteCommunication().IdValue == value.IdValue);
                grid.SelectItemByReference(displayAdapter);
            }
        }

        //ayman Site Communication
        public bool DeleteAllChecked
        {
            set { deleteAllChecked = value; }
            get { return deleteAllChecked; }
        }

        public bool EditButtonEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool DeleteButtonEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool UserIsSureTheyWantToDelete()
        {
            return UIUtils.ConfirmDeleteDialog();
        }

        public void SelectFirstValue()
        {
            grid.SelectFirstRow();
        }
    }
}
