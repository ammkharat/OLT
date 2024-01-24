using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ShiftHandoverConfigurationForm : BaseForm, IShiftHandoverConfigurationForm
    {
        private readonly DomainSummaryGrid<ShiftHandoverConfigurationDTO> grid;

        public ShiftHandoverConfigurationForm()
        {
            InitializeComponent();
            InitializePresenter();

            grid = new DomainSummaryGrid<ShiftHandoverConfigurationDTO>(
                new ShiftHandoverConfigurationDTOGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);

            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;
            gridPanel.Controls.Add(grid);
        }

        private void InitializePresenter()
        {
            ShiftHandoverConfigurationPresenter presenter = new ShiftHandoverConfigurationPresenter(this);
            Load += presenter.Load;

            addButton.Click += presenter.AddButton_Click;
            editButton.Click += presenter.EditButton_Click;
            removeButton.Click += presenter.RemoveButton_Click;
            closeButton.Click += presenter.CloseButton_Clicked;            
        }

        public List<ShiftHandoverConfigurationDTO> ShiftHandoverConfigurationDTOs
        {
            set { grid.Items = value; }
        }

        public ShiftHandoverConfigurationDTO SelectedItem
        {
            get { return grid.SelectedItem; }
        }

        public void LaunchEditShiftHandoverConfigurationForm(ShiftHandoverConfiguration selected)
        {
            EditShiftHandoverConfigurationForm form = new EditShiftHandoverConfigurationForm(selected);
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
    }
}