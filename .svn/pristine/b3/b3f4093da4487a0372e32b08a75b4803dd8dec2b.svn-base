using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormLubesCsdFormView : IFormView
    {
        bool? IsTheCSDForAPressureSafetyValve { get; set; }
        string CriticalSystemDefeated { get; set; }
        event Action PressureSafetyValveAnswerChanged;
        event Action BrowseFunctionalLocationButtonClicked;
        void SetErrorForEmptyOP14CriticalSystemDefeated();
        DialogResult ShowFormHasAdditionalApproversRequired();
        void SetErrorForValidToIsInThePast();
        string LocationText { get; set; }
        FunctionalLocation SelectedFunctionalLocation { get; set; }
        DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector(FunctionalLocation functionalLocation);
        void SetErrorForNoPressureSafetyValveResponse();
        event Action HistoryClicked;
        void SetErrorForEmptyLocation();
    }
}