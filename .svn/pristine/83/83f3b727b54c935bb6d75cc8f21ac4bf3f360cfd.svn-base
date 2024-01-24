using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SelectHazardForm : BaseForm, ISelectHazardView
    {
        public event Action FormLoad;

        public event Action<WorkPermitEdmontonHazardDTO> AddHazardButtonClick;
        public event Action SelectedItemChange;

        private readonly DomainSummaryGrid<WorkPermitEdmontonHazardDTO> grid;

        public SelectHazardForm()
        {
            InitializeComponent();

            grid = new DomainSummaryGrid<WorkPermitEdmontonHazardDTO>(new WorkPermitEdmontonHazardGridRenderer(), OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT, "WorkPermitEdmontonHazardGrid");
            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;
            gridPanel.Controls.Add(grid);

            addButton.Click += HandleAddButtonClick;
            grid.SelectedItemChanged += HandleSelectedItemChanged;
        }

        private void HandleSelectedItemChanged(object sender, DomainEventArgs<WorkPermitEdmontonHazardDTO> e)
        {
            if (SelectedItemChange != null)
            {
                SelectedItemChange();
            }
        }

        private void HandleAddButtonClick(object sender, EventArgs eventArgs)
        {
            if (AddHazardButtonClick != null)
            {
                WorkPermitEdmontonHazardDTO dto = grid.SelectedItem;
                AddHazardButtonClick(dto);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        public List<WorkPermitEdmontonHazardDTO> HazardDtos
        {
            set
            {
                grid.Items = value;
            }
        }

        public WorkPermitEdmontonHazardDTO SelectedItem
        {
            get { return grid.SelectedItem; }
        }

        public void SelectFirstRow()
        {
            if (grid.Items.Count > 0)
            {
                grid.SelectFirstRow();
            }
        }

        public bool AddHazardButtonEnabled
        {
            set { addButton.Enabled = value; }
        }

    }
}
