using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class RestrictionLocationConfigurationFormPresenter
    {
        private readonly IRestrictionLocationConfigurationView view;
        private readonly RestrictionLocation selectedRestrictionLocation;

        private readonly IRestrictionLocationService service;
        private readonly IRestrictionReasonCodeService restrictionReasonCodeService;
        private readonly IWorkAssignmentService workAssignmentService;

        private readonly Site site;

        public RestrictionLocationConfigurationFormPresenter(IRestrictionLocationConfigurationView view, long restrictionLocationId)
        {
            this.view = view;
            site = ClientSession.GetUserContext().Site;
        
            service = ClientServiceRegistry.Instance.GetService<IRestrictionLocationService>();
            workAssignmentService = ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>();
            restrictionReasonCodeService = ClientServiceRegistry.Instance.GetService<IRestrictionReasonCodeService>();

            selectedRestrictionLocation = service.QueryById(restrictionLocationId);
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            view.LocationName = selectedRestrictionLocation.Name;
            SetAvailableWorkAssignmentsList();
            SetWorkAssignmentsForSelectedLocationList();
            SetLocationItemTree();
            view.DisableSelection();
        }

        private void SetLocationItemTree()
        {
            // make up a fake Root Node for each loading the tree, and easy adding later.
            LocationItemTreeItem rootTreeItem = LocationItemTreeItem.CreateFakeRoot(selectedRestrictionLocation.Name);

            List<LocationItemTreeItem> locationItems =
                selectedRestrictionLocation.LocationItems.ConvertAll(item => new LocationItemTreeItem(item));

            // Insert the root item at the beginning to make it quick to find later.
            locationItems.Insert(0, rootTreeItem);

            view.LocationItems = locationItems;
        }

        private List<WorkAssignment> workAssignmentsForLocation;
        private void SetWorkAssignmentsForSelectedLocationList()
        {
            workAssignmentsForLocation = selectedRestrictionLocation.WorkAssignments;
            view.WorkAssignmentsForLocation = workAssignmentsForLocation;
        }

        private List<WorkAssignment> availableWorkAssignments;

        private void SetAvailableWorkAssignmentsList()
        {
            availableWorkAssignments = workAssignmentService.QueryBySite(site);
            List<WorkAssignment> assignedWorkAssignments = service.QueryAllAssignedWorkAssignments(site.IdValue);      //ayman restriction

            availableWorkAssignments.RemoveRange(assignedWorkAssignments);

            view.AvailableWorkAssignments = availableWorkAssignments;
        }

        public void HandleAddWorkAssignment(object sender, EventArgs e)
        {
            WorkAssignment selectedAvailableWorkAssignment = view.SelectedAvailableWorkAssignment;
            if (selectedAvailableWorkAssignment == null)
                return;

            availableWorkAssignments.Remove(selectedAvailableWorkAssignment);
            view.AvailableWorkAssignments = availableWorkAssignments;

            workAssignmentsForLocation.Add(selectedAvailableWorkAssignment);
            view.WorkAssignmentsForLocation = workAssignmentsForLocation;
            
            view.SelectedWorkAssignment = selectedAvailableWorkAssignment;
            view.SelectedAvailableWorkAssignment = null;
        }

        public void HandleRemoveWorkAssignment(object sender, EventArgs e)
        {
            WorkAssignment selectedWorkAssignment = view.SelectedWorkAssignment;
            if (selectedWorkAssignment == null)
                return;

            availableWorkAssignments.Add(selectedWorkAssignment);
            view.AvailableWorkAssignments = availableWorkAssignments;

            workAssignmentsForLocation.Remove(selectedWorkAssignment);
            view.WorkAssignmentsForLocation = workAssignmentsForLocation;
            view.SelectedWorkAssignment = null;
            view.SelectedAvailableWorkAssignment = selectedWorkAssignment;
        }

        public void HandleSave()
        {
            bool isValid = Validate();
            if (isValid)
            {
                selectedRestrictionLocation.WorkAssignments = workAssignmentsForLocation;
                // re-sort all items
                selectedRestrictionLocation.SortLocationItems();
                service.Update(selectedRestrictionLocation);
            }
        }

        private bool Validate()
        {
            return true;
        }

        public void HandleCancel()
        {
            view.Close();
        }

        public void HandleLocationItemSelected(object sender, TreeViewEventArgs e)
        {
            LocationItemTreeItem  locationItemTreeItem = view.SelectedLocationItem;

            if (locationItemTreeItem != null)
            {
                view.FunctionalLocation = locationItemTreeItem.FunctionalLocation;
                view.ReasonCodes = locationItemTreeItem.ReasonCodes;
            }
            else
            {
                view.FunctionalLocation = null;
                view.ReasonCodes = new List<RestrictionLocationItemReasonCodeAssociation>(0);
            }

            if (locationItemTreeItem == null || locationItemTreeItem.IsFakeRoot)
            {
                view.DisableSelection();
            }
            else
            {
                view.EnableSelection();
            }
            // for the Fake root, we still want to be able to Add Items
            if (locationItemTreeItem != null && locationItemTreeItem.IsFakeRoot)
            {
                view.EnableAdd();
            }
        }

        public void HandleSelectReasonCodes()
        {
            List<RestrictionReasonCode> restrictionReasonCodes = restrictionReasonCodeService.QueryAll(ClientSession.GetUserContext().SiteId);    //ayman restriction reason codes
            LocationItemTreeItem locationItemTreeItem = view.SelectedLocationItem;

            RestrictionLocationItemReasonCodeForm form = new RestrictionLocationItemReasonCodeForm(locationItemTreeItem.RestrictionLocationItem, restrictionReasonCodes);
            DialogResult dialogResult = form.ShowDialog(view);
            if (dialogResult == DialogResult.OK)
            {
                List<RestrictionLocationItemReasonCodeAssociation> restrictionLocationItemReasonCodes = form.AssociationList;
                // Put them on the selected Item for saving later.
                view.SelectedLocationItem.ReasonCodes = restrictionLocationItemReasonCodes;

                view.ReasonCodes = restrictionLocationItemReasonCodes;
            }
        }

        public void HandleRenameLocationItem()
        {
            LocationItemTreeItem locationItemTreeItem = view.SelectedLocationItem;
            if (locationItemTreeItem == null || locationItemTreeItem.IsFakeRoot)
                return;

            RestrictionLocationItem selectedItem = locationItemTreeItem.RestrictionLocationItem;

            List<RestrictionLocationItem> siblings =
                selectedRestrictionLocation.LocationItems.FindAll(item => item.ParentItemId == selectedItem.ParentItemId && item.IdValue != selectedItem.IdValue);
            
            RestrictionLocationItem parentItem = selectedRestrictionLocation.LocationItems.Find(item => item.IdValue == locationItemTreeItem.ParentId);
            string parentItemName = parentItem != null ? parentItem.Name : selectedRestrictionLocation.Name;

            AddRenameRestrictionLocationItemForm form = new AddRenameRestrictionLocationItemForm(siblings, parentItemName, selectedItem);
            form.ShowDialog(view);

            if (!form.ShouldAddOrUpdate)
            {
                return;
            }

            string newNameOfItem = form.NameOfNewRestrictionLocationItem;

            selectedRestrictionLocation.LocationItems.Remove(selectedItem);
            selectedItem.Name = newNameOfItem;
            selectedRestrictionLocation.LocationItems.Add(selectedItem);

            view.ReplaceSelectedNode(new LocationItemTreeItem(selectedItem));
        }

        public void OnFunctionalLocationClick()
        {
            FunctionalLocation selectedFloc = view.ShowFunctionalLocationSelector();
            if (selectedFloc != null)
            {
                view.FunctionalLocation = selectedFloc;
                view.SelectedLocationItem.RestrictionLocationItem.FunctionalLocation = selectedFloc;
            }
        }

        public void HandleAddItem()
        {
            LocationItemTreeItem selectedParentLocationTreeItem = view.SelectedLocationItem;
            if (selectedParentLocationTreeItem == null)
                return;

            List<RestrictionLocationItem> siblings;
            long? parentId = null;

            if (selectedParentLocationTreeItem.IsFakeRoot)
            {
                siblings = selectedRestrictionLocation.LocationItems.FindAll(item => item.ParentItemId == null);
            }
            else
            {
                RestrictionLocationItem selectedParentItem = selectedParentLocationTreeItem.RestrictionLocationItem;
                parentId = selectedParentItem.IdValue;
                siblings = selectedRestrictionLocation.LocationItems.FindAll(item => item.ParentItemId == selectedParentItem.Id);
            }
            AddRenameRestrictionLocationItemForm form = new AddRenameRestrictionLocationItemForm(siblings, selectedParentLocationTreeItem.Name);
            form.ShowDialog(view);
            if (!form.ShouldAddOrUpdate)
                return;
            string nameOfItem = form.NameOfNewRestrictionLocationItem;
            
            long id = service.GetNextLocationItemSequenceNumber();
            
            RestrictionLocationItem restrictionLocationItem = new RestrictionLocationItem(id, nameOfItem, null, parentId, new List<RestrictionLocationItemReasonCodeAssociation>(0));
            selectedRestrictionLocation.LocationItems.Add(restrictionLocationItem);
            view.AddItemToSelectedNode(new LocationItemTreeItem(restrictionLocationItem));
        }

        public void HandleRemoveItem()
        {
            LocationItemTreeItem locationItemTreeItem = view.SelectedLocationItem;
            if (locationItemTreeItem == null || locationItemTreeItem.IsFakeRoot)
                return;

            RestrictionLocationItem selectedItem = locationItemTreeItem.RestrictionLocationItem;
            selectedRestrictionLocation.RemoveLocationItem(selectedItem);
            
            view.RemoveSelectedNode();
        }
    }
}