using System.Collections.Generic;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ICreateOrEditAssignmentView : IBaseForm
    {
        string AssignmentName { get; set; }
        string AssignmentDescription { get; set; }
        string Category { get; set; }
        string ViewTitle { set; }
        string AssignmentSite { set; }        

        List<Role> Roles { get; set; }
        Role SelectedRole { get; set; }
        List<string> Categories { set; }        
        List<WorkAssignmentVisibilityGroupGridDisplayAdapter> VisibilityGroupAdapters { get; set; }

        void ClearErrorProviders();
        void ShowNameIsEmptyError();
        void ShowRoleIsNullError();
        void ShowDescriptionIsEmptyError();
        void ShowNameAlreadyExistsError();

        void SetDialogResultOK();
        void ShowNoGroupWithBothReadAndWriteError();
    }
}