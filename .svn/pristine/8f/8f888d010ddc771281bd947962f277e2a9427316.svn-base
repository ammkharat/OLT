using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureDefaultFlocsForDailyAssignmentForm : BaseForm, IConfigureDefaultFlocsForDailyAssignmentView
    {
        private readonly DomainSummaryGrid<WorkAssignment> workAssignmentGrid;
        
        public ConfigureDefaultFlocsForDailyAssignmentForm()
        {
            InitializeComponent();
           
            flocSelectionControl.Mode = ClientSession.GetInstance().SiteConfiguredFunctionalLocationMode;

            siteDisplayLabel.Text = ClientSession.GetUserContext().Site.Name;

            IGridRenderer renderer = new WorkAssignmentGridRenderer(true, true);
            workAssignmentGrid = new DomainSummaryGrid<WorkAssignment>(renderer, OltGridAppearance.SINGLE_SELECT, "ConfigureDefaultFlocsForDailyAssignmentGrid");
            workAssignmentGrid.Dock = DockStyle.Fill;
            workAssignmentGrid.DisplayLayout.GroupByBox.Hidden = true;
            workAssignmentAreaGroupBox.Controls.Add(workAssignmentGrid);

            InitializePresenter();
        }

        private void InitializePresenter()
        {
            ConfigureDefaultFlocsForDailyAssignnmentPresenter presenter = new ConfigureDefaultFlocsForDailyAssignnmentPresenter(this);

            Load += presenter.HandleLoad;
            workAssignmentGrid.SelectedItemChanged += presenter.HandleWorkAssignmentAreaSelected;
            saveButton.Click += presenter.HandleSaveButtonClicked;
            cancelButton.Click += presenter.HandleCancelButtonClicked;
            clearButton.Click += presenter.HandleClearButtonClicked;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<WorkAssignment> WorkAssignmentList
        {
            set
            {
                workAssignmentGrid.Items = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IList<FunctionalLocation> SelectedAssignmentDefaultFunctionalLocations
        {
            set { flocSelectionControl.UserCheckedFunctionalLocations = value; }
            get { return flocSelectionControl.UserCheckedFunctionalLocations; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool FunctionalLocationSelectionEnabled
        {
            set
            {
                saveButton.Enabled = value;
                flocSelectionControl.Enabled = value;
                workAssignmentGrid.Enabled = value;
            }
        }

        public FunctionalLocationMode FunctionalLocationMode
        {
            set { flocSelectionControl.Mode = value; }
        }

        public void ClearFunctionalLocations()
        {
            flocSelectionControl.UserCheckedFunctionalLocations = new List<FunctionalLocation>();    
        }

        public void SelectFirstWorkAssignment()
        {
            workAssignmentGrid.SelectFirstRow();
        }
    }
}