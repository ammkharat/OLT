using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureWorkPermitGroupsForm : BaseForm, IConfigureWorkPermitGroupsView
    {        
        private readonly DomainSummaryGrid<WorkPermitMontrealGroup> grid;

        public event Action MoveUpButtonClicked;
        public event Action MoveDownButtonClicked;
        public event Action AddButtonClicked;
        public event Action DeleteButtonClicked;
        public event Action EditButtonClicked;
        public event Action SaveButtonClicked;
        public event Action CancelButtonClicked;

        public ConfigureWorkPermitGroupsForm()
        {
            InitializeComponent();

            grid = new DomainSummaryGrid<WorkPermitMontrealGroup>(new WorkPermitMontrealGroupGridRenderer(), OltGridAppearance.SINGLE_SELECT, string.Empty);
            
            grid.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;
            gridPanel.Controls.Add(grid);

            moveUpButton.Click += HandleMoveUpButtonClick;
            moveDownButton.Click += HandleMoveDownButtonClick;

            addButton.Click += HandleAddButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;
            editButton.Click += HandleEditButtonClick;
            saveButton.Click += HandleSaveButtonClick;
            cancelButton.Click += HandleCloseButtonClick;             
        }

        private void HandleMoveUpButtonClick(object sender, EventArgs e)
        {
            MoveUpButtonClicked();
        }

        private void HandleMoveDownButtonClick(object sender, EventArgs e)
        {
            MoveDownButtonClicked();
        }

        private void HandleAddButtonClick(object sender, EventArgs e)
        {
            AddButtonClicked();
        }

        private void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            DeleteButtonClicked();
        }

        private void HandleEditButtonClick(object sender, EventArgs e)
        {
            EditButtonClicked();
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            SaveButtonClicked();
        }

        private void HandleCloseButtonClick(object sender, EventArgs e)
        {
            CancelButtonClicked();
        }

        public List<WorkPermitMontrealGroup> Groups
        {
            get { return new List<WorkPermitMontrealGroup>(grid.Items); }
            set { grid.Items = value; }
        }

        public WorkPermitMontrealGroup Selected
        {
            get { return grid.SelectedItem; }
            set { grid.SelectItemByReference(value); }
        }

        public void SelectFirstRow()
        {           
            if (grid.Items.Count > 0)
            {
                grid.SelectSingleItemByIndex(0);
            }
        }

        public void RefreshGrid()
        {
            grid.RefreshBinding();
        }

        public void DisableView()
        {
            SetViewEnabledState(false);
        }

        public void EnableView()
        {
            SetViewEnabledState(true);
        }

        private void SetViewEnabledState(bool enabled)
        {
            ControlBox = enabled;
            deleteButton.Enabled = enabled;
            editButton.Enabled = enabled;
            addButton.Enabled = enabled;
            cancelButton.Enabled = enabled;            
            grid.Enabled = enabled;
        }
    }
}
