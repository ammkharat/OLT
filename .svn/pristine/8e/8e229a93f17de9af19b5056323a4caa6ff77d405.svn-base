using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class TrainingBlockConfigurationForm : BaseForm, ITrainingBlockConfigurationView
    {
        public event Action NewButtonClick;
        public event Action EditButtonClick;
        public event Action DeleteButtonClick;
        public event Action FormLoad;
        public event Action<TrainingBlock> SelectedTrainingBlockChanged;

        private DomainSummaryGrid<TrainingBlock> trainingBlockGrid;

        public TrainingBlockConfigurationForm()
        {
            InitializeComponent();

            flocSelectionControl.Mode = FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration);

            SetupTrainingBlockGrid();

            newButton.Click += HandleNewButtonClick;
            editButton.Click += HandleEditButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;
            
            trainingBlockGrid.SelectedItemChanged += HandleSelectedTrainingBlockChanged;

            flocSelectionControl.TreeViewReadOnly = true;
            flocSelectionControl.ShowSearchPanel = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        private void SetupTrainingBlockGrid()
        {
            IGridRenderer renderer = new TrainingBlockGridRenderer();
            trainingBlockGrid = new DomainSummaryGrid<TrainingBlock>(renderer, OltGridAppearance.SINGLE_SELECT, "TrainingBlockConfigurationFormGrid");
            trainingBlockGrid.Dock = DockStyle.Fill;
            trainingBlockGrid.DisplayLayout.GroupByBox.Hidden = true;
            trainingBlockTablePanel.Controls.Add(trainingBlockGrid);
        }

        public List<TrainingBlock> TrainingBlocks
        {
            get
            {
                if (trainingBlockGrid.Items == null)
                {
                    return new List<TrainingBlock>();
                }

                return new List<TrainingBlock>(trainingBlockGrid.Items);
            }
            set { trainingBlockGrid.Items = value; }
        }

        public IList<FunctionalLocation> FunctionalLocations
        {
            set { flocSelectionControl.UserCheckedFunctionalLocations = value; }
            get { return flocSelectionControl.UserCheckedFunctionalLocations; }
        }

        public TrainingBlock SelectedTrainingBlock
        {
            get { return trainingBlockGrid.SelectedItem; }
            set { trainingBlockGrid.SelectItemByReference(value); }
        }

        public bool EditButtonEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool DeleteButtonEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public void SelectFirstTrainingBlock()
        {
            trainingBlockGrid.SelectFirstRow();
        }

        public void AddTrainingBlock(TrainingBlock trainingBlock)
        {
            List<TrainingBlock> trainingBlocks = TrainingBlocks;
            trainingBlocks.Add(trainingBlock);
            TrainingBlocks = trainingBlocks;
        }

        public void RefreshTrainingBlocks()
        {
            List<TrainingBlock> trainingBlocks = TrainingBlocks;
            TrainingBlocks = trainingBlocks;
        }

        public void RemoveTrainingBlock(TrainingBlock trainingBlock)
        {
            List<TrainingBlock> trainingBlocks = TrainingBlocks;
            trainingBlocks.Remove(trainingBlock);
            TrainingBlocks = trainingBlocks;
        }

        private void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            if (DeleteButtonClick != null)
            {
                DeleteButtonClick();
            }
        }

        private void HandleNewButtonClick(object sender, EventArgs e)
        {
            if (NewButtonClick != null)
            {
                NewButtonClick();
            }
        }

        private void HandleEditButtonClick(object sender, EventArgs e)
        {
            if (EditButtonClick != null)
            {
                EditButtonClick();
            }
        }

        private void HandleSelectedTrainingBlockChanged(object sender, DomainEventArgs<TrainingBlock> e)
        {
            if (SelectedTrainingBlockChanged != null)
            {
                SelectedTrainingBlockChanged(e.SelectedItem);
            }
        }


    }
}
