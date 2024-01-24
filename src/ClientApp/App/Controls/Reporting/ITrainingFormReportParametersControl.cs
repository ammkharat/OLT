using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public interface ITrainingFormReportParametersControl : IReportParametersControl
    {
        Date StartDate { get; set; }
        Date EndDate { get; set; }
        void SetAvailableWorkAssignments(List<WorkAssignment> workAssignments);
        void SetAvailableUsers(List<UserDTO> users);
        List<UserDTO> SelectedUsers { get; }
        List<WorkAssignment> SelectedWorkAssignments { get; }
    }
}
