using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IRestrictionLocationConfigurationView : IBaseForm
    {
        List<WorkAssignment> AvailableWorkAssignments { get; set; }
        List<WorkAssignment> WorkAssignmentsForLocation { get; set; }
        List<LocationItemTreeItem> LocationItems { set; }
        WorkAssignment SelectedAvailableWorkAssignment { get; set; }
        WorkAssignment SelectedWorkAssignment { set; get; }
        LocationItemTreeItem SelectedLocationItem { get; }
        FunctionalLocation FunctionalLocation { get; set; }
        List<RestrictionLocationItemReasonCodeAssociation> ReasonCodes { get; set; }
        string LocationName { set; }
        void ReplaceSelectedNode(LocationItemTreeItem newItem);
        void DisableSelection();
        void EnableSelection();
        FunctionalLocation ShowFunctionalLocationSelector();
        void AddItemToSelectedNode(LocationItemTreeItem childItem);
        void RemoveSelectedNode();
        void EnableAdd();
    }

    public interface IRestrictionLocationListConfigurationView : IBaseForm
    {
        List<RestrictionLocation> RestrictionLocationList { set; }
        RestrictionLocation SelectedRestrictionLocation { get; set; }
    }
}