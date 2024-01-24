using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureAreaLabelsForm : BaseForm, IConfigureAreaLabelsView
    {
        public event Action AddAreaLabel;
        public event Action EditAreaLabel;
        public event Action DeleteAreaLabel;
        public event Action SaveAndClose;
        public event Action MoveUp;
        public event Action MoveDown;

        private DomainSummaryGrid<AreaLabel> grid;

        public ConfigureAreaLabelsForm()
        {
            InitializeComponent();
            InitializeGrid();

            addButton.Click += HandleAddValueButtonClick;
            editButton.Click += HandleEditValueButtonClick;
            deleteButton.Click += HandleDeleteValueButtonClick;
            saveAndCloseButton.Click += HandleSaveAndCloseButtonClick;
            moveUpButton.Click += HandleMoveUpButtonClick;
            moveDownButton.Click += HandleMoveDownButtonClick;
        }

        public List<AreaLabel> AreaLabels
        {
            set { grid.Items = value; }
        }

        public AreaLabel SelectedAreaLabel
        {
            get { return grid.SelectedItem; }
            set { grid.SelectItemByReference(value); }
        }

        public bool UserIsSureTheyWantToDelete()
        {
            return UIUtils.ConfirmDeleteDialog();
        }

        public void SelectFirstValue()
        {
            grid.SelectFirstRow();
        }

        private void HandleSaveAndCloseButtonClick(object sender, EventArgs e)
        {
            if (SaveAndClose != null)
            {
                SaveAndClose();
            }
        }

        private void HandleAddValueButtonClick(object sender, EventArgs e)
        {
            if (AddAreaLabel != null)
            {
                AddAreaLabel();
            }
        }

        private void HandleEditValueButtonClick(object sender, EventArgs e)
        {
            if (EditAreaLabel != null)
            {
                EditAreaLabel();
            }
        }

        private void HandleDeleteValueButtonClick(object sender, EventArgs e)
        {
            if (DeleteAreaLabel != null)
            {
                DeleteAreaLabel();
            }
        }

        private void HandleMoveUpButtonClick(object sender, EventArgs e)
        {
            if (MoveUp != null)
            {
                MoveUp();
            }
        }

        private void HandleMoveDownButtonClick(object sender, EventArgs e)
        {
            if (MoveDown != null)
            {
                MoveDown();
            }
        }

        private void InitializeGrid()
        {
            grid = new DomainSummaryGrid<AreaLabel>(new AreaLabelGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);

            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;

            grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            grid.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            gridPanel.Controls.Add(grid);
        }
    }
}
