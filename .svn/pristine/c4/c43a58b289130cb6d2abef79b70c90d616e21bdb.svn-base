using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormLubesAlarmDisableFormView : IFormView
    {
        string Criticality { get; set; }
        string Alarm { get; set; }
        string SapNotification { get; set; }
        string LocationText { get; set; }
        FunctionalLocation SelectedFunctionalLocation { get; set; }
        List<string> CriticalityChoices { set; }
        event Action BrowseFunctionalLocationButtonClicked;
        void SetErrorForEmptyCriticality();
        void SetErrorForEmptyAlarm();
        DialogResult ShowFormHasAdditionalApproversRequired();
        void SetErrorForValidToIsInThePast();
        DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector(FunctionalLocation functionalLocation);
        event Action CriticalityChanged;
        event Action AlarmChanged;
        event Action HistoryButtonClicked;
        void SetErrorForTotalDurationExceeds30Days();
        void SetErrorForEmptyLocation();
    }
}