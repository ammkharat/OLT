
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfiguredDocumentLinkConfigurationForm : BaseForm, IConfiguredDocumentLinkConfigurationView
    {
        public event Action<ConfiguredDocumentLinkLocation> EditButtonClicked;

        private DomainSummaryGrid<ConfiguredDocumentLinkLocation> grid;

        public ConfiguredDocumentLinkConfigurationForm()
        {
            InitializeComponent();

            InitializeGrid();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            editButton.Click += EditButtonOnClick;
            grid.DoubleClickSelected += GridOnDoubleClickSelected;
        }

        private void GridOnDoubleClickSelected(object sender, DomainEventArgs<ConfiguredDocumentLinkLocation> domainEventArgs)
        {
            EditButtonOnClick(sender, EventArgs.Empty);
        }

        private void EditButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (EditButtonClicked != null)
            {
                ConfiguredDocumentLinkLocation location = grid.SelectedItem;
                EditButtonClicked(location);
            }
        }

        private void InitializeGrid()
        {
            grid = new DomainSummaryGrid<ConfiguredDocumentLinkLocation>(new SingleColumnGridRenderer(StringResources.DocumentLinkLocation, "DisplayName"),
                                                                         OltGridAppearance.NON_OUTLOOK, string.Empty);

            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;

            grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            gridPanel.Controls.Add(grid);
        }

        public List<ConfiguredDocumentLinkLocation> Locations
        {
            set { grid.Items = value; }
        }

        public void SelectFirstRow()
        {
            grid.SelectFirstRow();
        }
    }
}
