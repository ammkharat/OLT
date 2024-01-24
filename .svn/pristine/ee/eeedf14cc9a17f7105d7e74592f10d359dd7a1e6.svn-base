using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Infragistics.Win.UltraWinGrid;
using Com.Suncor.Olt.Client.Controls.GridRenderer;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class CokerCardConfigurationForm : BaseForm, ICokerCardConfigurationFormView
    {
        private readonly DomainSummaryGrid<CokerCardConfiguration> grid;

        public CokerCardConfigurationForm()
        {
            InitializeComponent();
            InitializePresenter();

            grid = new DomainSummaryGrid<CokerCardConfiguration>(
                new CokerCardConfigurationGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty) {Dock = DockStyle.Fill};

            grid.DisplayLayout.GroupByBox.Hidden = true;
            gridPanel.Controls.Add(grid);
        }

        private void InitializePresenter()
        {
            CokerCardConfigurationPresenter presenter = new CokerCardConfigurationPresenter(this);
            Load += presenter.Load;

            addButton.Click += presenter.AddButton_Click;
            editButton.Click += presenter.EditButton_Click;
            deleteButton.Click += presenter.DeleteButton_Click;
            closeButton.Click += presenter.CloseButton_Clicked;
        }

        public List<CokerCardConfiguration> CokerCardConfigurations
        {
            set { grid.Items = value; }
        }

        public CokerCardConfiguration SelectedItem
        {
            get { return grid.SelectedItem; }
        }

        public void LaunchEditConfigurationForm(CokerCardConfiguration selected)
        {
            EditCokerCardConfigurationForm form = new EditCokerCardConfigurationForm(selected);
            form.ShowDialog(this);
            SelectFirstRow();
        }

        public void SelectFirstRow()
        {
            grid.SelectFirstRow();
        }

        public bool UserIsSure()
        {
            return UIUtils.ConfirmDeleteDialog();
        }

        private class CokerCardConfigurationGridRenderer : AbstractSimpleGridRenderer
        {
            private const string NAME_FIELD = "Name";
            private const string FLOC_FIELD = "FunctionalLocation";

            protected override void SetUpColumns(UltraGridBand band)
            {
                band.Columns[NAME_FIELD].Format("Name", 0, 150);
                band.Columns[FLOC_FIELD].Format("Functional Location", 1, 150);
            }

            public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
            {
                sortedColumns.Add(NAME_FIELD, false);
            }
        }
    }
}