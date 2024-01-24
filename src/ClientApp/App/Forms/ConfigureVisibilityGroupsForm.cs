using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureVisibilityGroupsForm : BaseForm, IConfigureVisibilityGroupsView
    {
        private DomainSummaryGrid<VisibilityGroup> visibilityGroupGrid;

        public ConfigureVisibilityGroupsForm()
        {
            InitializeComponent();

            InitializeGrid();
            ConfigurationVisibilityGroupsFormPresenter presenter = new ConfigurationVisibilityGroupsFormPresenter(this);
            RegisterEventHandlersOnPresenter(presenter);

        }

        private void RegisterEventHandlersOnPresenter(ConfigurationVisibilityGroupsFormPresenter presenter)
        {
            Load += presenter.HandleFormLoad;
            newButton.Click += presenter.HandleNewVisibilityGroupClick;
            editButton.Click += presenter.HandleEditVisibilityGroupClick;
            deleteButton.Click += presenter.HandleDeleteVisibilityGroupClick;
            closeButton.Click += HandleCloseButtonClick;
        }

        private void HandleCloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeGrid()
        {
            // OltGridAppearance.EDIT_ROW_SELECT  can select and unselect checkboxes, but can't delete the row.
            // OltGridAppearance.EDIT_CELL_SELECT same as above.
            // OltGridAppearance.NON_OUTLOOK can delete row, but not select values.
            // OltGridAppearance.SINGLE_SELELCT can delete row, but not select values.
            visibilityGroupGrid = new DomainSummaryGrid<VisibilityGroup>(new VisibilityGroupsGridRenderer(),
                                                                                                         OltGridAppearance.SINGLE_SELECT, "visibilityGroups");
            visibilityGroupGrid.Padding = new Padding(3);
            visibilityGroupGrid.HideGroupByArea = true;
            visibilityGroupGrid.Dock = DockStyle.Fill;
            visibilityGroupsPanel.Controls.Add(visibilityGroupGrid);
        }

        public List<VisibilityGroup> VisibilityGroups
        {
            set { visibilityGroupGrid.Items = value; }
        }

        public VisibilityGroup SelectedVisibilityGroup
        {
            get { return visibilityGroupGrid.SelectedItem; }
        }
    }
}
