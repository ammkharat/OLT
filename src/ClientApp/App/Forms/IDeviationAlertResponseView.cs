using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IDeviationAlertResponseView : IBaseForm
    {
        string StartDate { set; }
        string EndDate { set; }

        string TargetTagName { set; }
        string MeasuredTagName { set; }

        string TargetValue { set; }
        string MeasuredValue { set; }

        string SummaryDeviationValue { set; }
        string SummaryTotalAssigned { set; }
        string SummaryAmountRemainingToBeAssigned { set; }
        
        string Comments { get; set; }

        List<DeviationAlertResponseReasonCodeAssignment> Assignments { set; }
        DeviationAlertResponseReasonCodeAssignment SelectedAssignment { get; set; }

        DeviationAlertResponseReasonCodeAssignment OpenAssociationPresenter(RestrictionLocation restrictionLocation, DeviationAlertResponseReasonCodeAssignment assignment,
            DeviationAlert deviationAlert, int amountRemainingToBeAllocated);

        void ClearAllErrors();
        void SetErrorOnRemainingToBeAssigned(string message);
        void SetErrorOnGrid(string message);

        void ShowNoLastResponseToCopyFrom();
        DialogResult ConfirmCopyLastResponseWhenAssignmentsExist();
        void EnableControls(bool isEditingComments, bool canRespond);
    }
}
