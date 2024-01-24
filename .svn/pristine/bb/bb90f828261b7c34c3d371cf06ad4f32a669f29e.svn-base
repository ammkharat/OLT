using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IEditCokerCardConfigurationFormView : IBaseForm
    {
        string ConfigurationName { get; set; }        
        FunctionalLocation FunctionalLocation { get; set; }
        List<WorkAssignment> WorkAssignments { get; set; }

        IList<CokerCardConfigurationDrum> Drums { get; set; }
        IList<CokerCardConfigurationCycleStep> Steps { get; set; }

        CokerCardConfigurationDrum SelectedDrum { get; set; }
        CokerCardConfigurationCycleStep SelectedStep { get; set; }

        void SelectFirstDrum();
        void SelectFirstStep();

        DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector();
        string ShowAddItemForm(string formTitle, string value);

        DialogResultAndOutput<IList<WorkAssignment>> ShowWorkAssignmentSelector(List<WorkAssignment> workAssignments);

        void ClearErrors();
        void SetConfigurationNameMissingError();
        void SetFunctionalLocationMissingError();        
        void SetAtLeastOneDrumRequiredError();
        void SetAtLeastOneStepRequiredError();

        bool UserIsSure();        
    }
}
