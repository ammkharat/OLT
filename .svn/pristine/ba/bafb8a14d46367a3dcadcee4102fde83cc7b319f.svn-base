using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IRestrictionLocationItemReasonCodeForm : IBaseForm
    {
        List<RestrictionLocationItemReasonCodeAssociation> AssociationList { set; }
        List<RestrictionReasonCode> ReasonCodeList { set; get; }
        List<RestrictionReasonCode> SelectedRestrictionReasonCodes { get; }
        List<RestrictionLocationItemReasonCodeAssociation> SelectedAssociations { get; set; }
        RestrictionLocationItemReasonCodeAssociation SelectedAssociation { set; }
        void ShowNoAssociationsSelectedMessageBox();
        void DisplayEditLimitsForm(List<RestrictionLocationItemReasonCodeAssociation> selectedAssociations);
    }
}