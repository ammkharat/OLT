namespace Com.Suncor.Olt.Client.Forms
{
    public interface IChangeActiveRestrictionFunctionalLocationView : IMultiSelectFunctionalLocationSelectionForm
    {
        string Assignment { set; }
        bool LoadDefaultAssignmentFlocsButtonEnabled { set; }
    }
}