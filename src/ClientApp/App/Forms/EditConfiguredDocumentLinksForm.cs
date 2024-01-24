
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class EditConfiguredDocumentLinksForm : BaseForm, IEditConfiguredDocumentLinksView
    {
        public event EventHandler AddButtonClick;
        public event EventHandler EditButtonClick;
        public event EventHandler MoveUpButtonClick;
        public event EventHandler MoveDownButtonClick;
        public event EventHandler DeleteButtonClick;
        public event EventHandler SaveAndCloseButtonClick;

        private DomainSummaryGrid<ConfiguredDocumentLink> grid;

        public EditConfiguredDocumentLinksForm()
        {
            InitializeComponent();
            InitializeGrid();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            addButton.Click += AddButtonOnClick;
            editButton.Click += EditButtonOnClick;
            moveUpButton.Click += MoveUpButtonOnClick;
            moveDownButton.Click += MoveDownButtonOnClick;
            deleteButton.Click += DeleteButtonOnClick;
            saveAndCloseButton.Click += SaveAndCloseButtonOnClick;
        }

        private void SaveAndCloseButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (SaveAndCloseButtonClick != null)
            {
                SaveAndCloseButtonClick(sender, eventArgs);
            }
        }

        private void DeleteButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (DeleteButtonClick != null)
            {
                DeleteButtonClick(sender, eventArgs);
            }
        }

        private void MoveDownButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (MoveDownButtonClick != null)
            {
                MoveDownButtonClick(sender, eventArgs);
            }
        }

        private void MoveUpButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (MoveUpButtonClick != null)
            {
                MoveUpButtonClick(sender, eventArgs);
            }
        }

        private void EditButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (EditButtonClick != null)
            {
                EditButtonClick(sender, eventArgs);
            }
        }

        private void AddButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (AddButtonClick != null)
            {
                AddButtonClick(sender, eventArgs);
            }
        }


        private void InitializeGrid()
        {
            grid = new DomainSummaryGrid<ConfiguredDocumentLink>(new ConfiguredDocumentLinkGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);

            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;

            grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            grid.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            gridPanel.Controls.Add(grid);
        }

        public List<ConfiguredDocumentLink> ConfiguredDocumentLinks
        {
            set { grid.Items = value; }
        }

        public string LocationName
        {
            set { locationLabel.Text = value; }
        }

        public ConfiguredDocumentLink SelectedLink
        {
            get { return grid.SelectedItem; }
            set { grid.SelectItemByReference(value); }
        }

        public void SelectFirstRow()
        {
            grid.SelectFirstRow();
        }

        public bool UserIsSure()
        {
            return UIUtils.ConfirmDeleteDialog();
        }

    }
}
