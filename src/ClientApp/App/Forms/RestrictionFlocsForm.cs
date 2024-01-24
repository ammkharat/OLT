using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class RestrictionFlocsForm : BaseForm, IRestrictionFlocsFormView
    {
        private readonly DomainSummaryGrid<AssignmentFlocConfiguration> workAssignmentGrid;

        public event Action SaveClicked;
        public event Action FormLoad;
        public event Action<AssignmentFlocConfiguration> WorkAssignmentAreaSelected;
        public event Action CancelClicked;
        public event Action ClearClicked;
        public event Action CopyLoginFlocsClicked;

        public RestrictionFlocsForm()
        {
            InitializeComponent();

            flocSelectionControl.Mode = FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration);

            copyLoginFlocsButton.Visible = false;

            siteDisplayLabel.Text = ClientSession.GetUserContext().Site.Name;

            IGridRenderer renderer = new WorkAssignmentGridRenderer(true, true);
            workAssignmentGrid = new DomainSummaryGrid<AssignmentFlocConfiguration>(
                renderer, OltGridAppearance.SINGLE_SELECT, "WorkPermitAssignmentConfigurationGrid")
                                     {Dock = DockStyle.Fill};
            workAssignmentGrid.DisplayLayout.GroupByBox.Hidden = true;
            workAssignmentAreaGroupBox.Controls.Add(workAssignmentGrid);

            workAssignmentGrid.SelectedItemChanged += WorkAssignmentGridOnSelectedItemChanged;
            saveButton.Click += SaveButtonOnClick;
            cancelButton.Click += CancelButtonOnClick;
            clearButton.Click += ClearButtonOnClick;
            copyLoginFlocsButton.Click += CopyLoginFlocsButtonOnClick;
        }

        private void CopyLoginFlocsButtonOnClick(object sender, EventArgs e)
        {
            if (CopyLoginFlocsClicked != null)
            {
                CopyLoginFlocsClicked();
            }            
        }

        public bool CopyLoginFlocsButtonVisible
        {
            set { copyLoginFlocsButton.Visible = value; }
        }

        public string Title
        {
            set { Text = value; }
        }

        private void ClearButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (ClearClicked != null)
            {
                ClearClicked();
            }
        }

        private void CancelButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (CancelClicked != null)
            {
                CancelClicked();
            }
        }

        private void SaveButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (SaveClicked != null)
            {
                SaveClicked();
            }
        }

        private void WorkAssignmentGridOnSelectedItemChanged(object sender, DomainEventArgs<AssignmentFlocConfiguration> e)
        {
            if (WorkAssignmentAreaSelected != null)
            {
                AssignmentFlocConfiguration selectedConfiguration = e.SelectedItem;
                WorkAssignmentAreaSelected(selectedConfiguration);
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<AssignmentFlocConfiguration> ConfigurationList
        {
            set { workAssignmentGrid.Items = value; }
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
                copyLoginFlocsButton.Enabled = value;
            }
        }

        public void ClearFunctionalLocations()
        {
            flocSelectionControl.UserCheckedFunctionalLocations = new List<FunctionalLocation>();    
        }

        public void SelectFirstWorkAssignment()
        {
            workAssignmentGrid.SelectFirstRow();
        }

        public DialogResult ShowYesNoWarningBox(string title, string message)
        {
            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public void ShowInfoMessageBox(string title, string message)
        {
            OltMessageBox.Show(this, message, title);
        }
    }
}