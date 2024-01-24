using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class ConfinedSpaceViewValidator
    {
        private readonly IConfinedSpaceValidationAction action;
        private bool hasErrors;

        public ConfinedSpaceViewValidator(IConfinedSpaceValidationAction action)
        {
            this.action = action;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        public void ValidateViewAndSetErrors(IConfinedSpaceView view)
        {
            ValidateDates(view);
            ValidateHasFunctionalLocation(view);
            ValidateAllCheckedCheckboxesHaveAValue(view);
        }

        private void ValidateDates(IConfinedSpaceView view)
        {
            if (view.StartDateTime > view.EndDateTime)
            {
                view.SetErrorForStartDateTimeAfterEndDateTime();
                hasErrors = true;
            }
            
            if (view.EndDateTime < Clock.Now)
            {
                view.SetErrorForEndDateMustBeonOrAfterTodayError();
                hasErrors = true;
            }

        }

        private void ValidateHasFunctionalLocation(IConfinedSpaceView view)
        {
            if (view.FunctionalLocation == null)
            {
                action.SetErrorForNoFunctionalLocation();
                hasErrors = true;
            }
        }

        private void ValidateAllCheckedCheckboxesHaveAValue(IConfinedSpaceView view)
        {
            TernaryString corrosif = view.Corrosif;
            if (corrosif.CheckedWithNoValue)
            {
                action.SetErrorForCorrosif();
                hasErrors = true;
            }

            TernaryString aromatique = view.Aromatique;
            if (aromatique.CheckedWithNoValue)
            {
                action.SetErrorForAromatique();
                hasErrors = true;
            }

            TernaryString autresSubstances = view.AutresSubstances;
            if (autresSubstances.CheckedWithNoValue)
            {
                action.SetErrorForAutresSubstances();
                hasErrors = true;
            }

            TernaryString dessins = view.DessinsRequis;
            if (dessins.CheckedWithNoValue)
            {
                action.SetErrorForDessinsRequis();
                hasErrors = true;
            }

            TernaryString autreConditions = view.AutreConditions;
            if (autreConditions.CheckedWithNoValue)
            {
                action.SetErrorForAutreConditions();
                hasErrors = true;
            }

        }

    }
}