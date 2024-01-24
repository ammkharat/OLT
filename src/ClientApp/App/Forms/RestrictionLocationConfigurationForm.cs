using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class RestrictionLocationConfigurationForm : BaseForm, IRestrictionLocationConfigurationView
    {
        private readonly SummaryGrid<RestrictionLocationItemReasonCodeAssociation> associatedReasonCodeGrid;

        public RestrictionLocationConfigurationForm(long restrictionLocation)
        {
            InitializeComponent();
            RestrictionLocationConfigurationFormPresenter presenter = new RestrictionLocationConfigurationFormPresenter(this, restrictionLocation);

            associatedReasonCodeGrid = new SummaryGrid<RestrictionLocationItemReasonCodeAssociation>(
                new RestrictionReasonCodeAssociationGridRenderer(), OltGridAppearance.MULTI_SELECT) { Dock = DockStyle.Fill };
            associatedReasonCodeGrid.DisplayLayout.GroupByBox.Hidden = true;
            itemReasonCodePanel.Controls.Add(associatedReasonCodeGrid);

            RegisterEventHandlersOnPresenter(presenter);
        }

        private void RegisterEventHandlersOnPresenter(RestrictionLocationConfigurationFormPresenter presenter)
        {
            Load += presenter.HandleFormLoad;
            
            saveButton.Click += (sender, args) => presenter.HandleSave();
            cancelButton.Click += (sender, args) => presenter.HandleCancel();
            
            addWorkAssignmentButton.Click += presenter.HandleAddWorkAssignment;
            removeWorkAssignmentButton.Click += presenter.HandleRemoveWorkAssignment;
            locationItemTreeView.AfterSelect += presenter.HandleLocationItemSelected;

            selectReasonCodesButton.Click += (sender, args) => presenter.HandleSelectReasonCodes();
            renameItemButton.Click += (sender, args) => presenter.HandleRenameLocationItem();
            addItemButton.Click += (sender, args) => presenter.HandleAddItem();
            removeItemButton.Click += (sender, args) => presenter.HandleRemoveItem();

            functionalLocationBrowseButton.Click += (sender, args) => presenter.OnFunctionalLocationClick();
        }


        public FunctionalLocation ShowFunctionalLocationSelector()
        {
            ISingleSelectFunctionalLocationSelectionForm functionalLocationSelectionForm =
                new SingleSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration));

            DialogResult result = functionalLocationSelectionForm.ShowDialog(this);
            return result == DialogResult.OK ? functionalLocationSelectionForm.SelectedFunctionalLocation : null;
        }

        public List<WorkAssignment> AvailableWorkAssignments
        {
            get { return allAvailableWorkAssignmentsListBox.DataSource as List<WorkAssignment>; }
            set
            {
                allAvailableWorkAssignmentsListBox.BeginUpdate();
                allAvailableWorkAssignmentsListBox.DataSource = null;
                allAvailableWorkAssignmentsListBox.DataSource = value;
                allAvailableWorkAssignmentsListBox.DisplayMember = "Name";
                allAvailableWorkAssignmentsListBox.EndUpdate();
            }
        }

        public List<WorkAssignment> WorkAssignmentsForLocation
        {
            get { return workAssignmentsForThisLocation.DataSource as List<WorkAssignment>; }
            set
            {
                workAssignmentsForThisLocation.BeginUpdate();
                workAssignmentsForThisLocation.DataSource = null;
                workAssignmentsForThisLocation.DataSource = value;
                workAssignmentsForThisLocation.DisplayMember = "Name";
                workAssignmentsForThisLocation.EndUpdate();
            }
        }

        public LocationItemTreeItem SelectedLocationItem
        {
            get { return locationItemTreeView.SelectedItem; }
        }

        public void AddItemToSelectedNode(LocationItemTreeItem childItem)
        {
            locationItemTreeView.AddItemToSelectedNode(childItem);
        }

        public void RemoveSelectedNode()
        {
            locationItemTreeView.RemoveSelectedNode();
        }

        public void ReplaceSelectedNode(LocationItemTreeItem newItem)
        {
            locationItemTreeView.ReplaceSelectedNode(newItem);
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocationTextBox.Tag as FunctionalLocation; }
            set
            {
                if (value != null)
                {
                    functionalLocationTextBox.Text = value.FullHierarchyWithDescription;
                    functionalLocationTextBox.Tag = value;
                }
                else
                {
                    functionalLocationTextBox.Text = string.Empty;
                    functionalLocationTextBox.Tag = null;
                }
            }
        }

        public List<RestrictionLocationItemReasonCodeAssociation> ReasonCodes
        {
            set { associatedReasonCodeGrid.Items = value; }
            get { return new List<RestrictionLocationItemReasonCodeAssociation>(associatedReasonCodeGrid.Items); }
        }

        public string LocationName
        {
            set { locationDisplayLabel.Text = value; }
        }

        public List<LocationItemTreeItem> LocationItems
        {
            set
            {
                locationItemTreeView.LoadItems(value);
            }
        }

        public WorkAssignment SelectedAvailableWorkAssignment
        {
            get { return allAvailableWorkAssignmentsListBox.SelectedItem as WorkAssignment; }
            set
            {
                if (value == null)
                {
                    allAvailableWorkAssignmentsListBox.ClearSelected();
                }
                else
                {
                    int indexOf = allAvailableWorkAssignmentsListBox.Items.IndexOf(value);
                    if (indexOf != -1)
                    {
                        allAvailableWorkAssignmentsListBox.SelectedIndex = indexOf;
                    }
                }
            }

        }

        public WorkAssignment SelectedWorkAssignment
        {
            set
            {
                if (value == null)
                {
                    workAssignmentsForThisLocation.ClearSelected();
                }
                else
                {
                    int indexOf = workAssignmentsForThisLocation.Items.IndexOf(value);
                    if (indexOf != -1)
                        workAssignmentsForThisLocation.SelectedIndex = indexOf;
                }
            }
            get { return workAssignmentsForThisLocation.SelectedItem as WorkAssignment; }
        }

        public void DisableSelection()
        {
            SetEnabled(false);
        }

        public void EnableSelection()
        {
            SetEnabled(true);
        }

        public void EnableAdd()
        {
            addItemButton.Enabled = true;
        }
        private void SetEnabled(bool enabled)
        {
            addItemButton.Enabled = enabled;
            removeItemButton.Enabled = enabled;
            moveItemButton.Enabled = enabled;
            renameItemButton.Enabled = enabled;
            functionalLocationBrowseButton.Enabled = enabled;
            selectReasonCodesButton.Enabled = enabled;
        }

    }
}