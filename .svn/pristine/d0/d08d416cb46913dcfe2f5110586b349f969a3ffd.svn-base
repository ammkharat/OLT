using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class WorkPermitMontrealValidator
    {
        private readonly IWorkPermitMontrealValidationAction action;
        private bool hasErrors;

        public WorkPermitMontrealValidator(IWorkPermitMontrealValidationAction action)
        {
            this.action = action;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        public void ValidateTemplateFormAndSetErrors(IWorkPermitMontrealFormView view)
        {
            ValidateHasPermitType(view);
            ValidateHasTemplateName(view);
        }

        public void ValidateUserFormAndSetErrors(IWorkPermitMontrealFormView view)
        {
            ValidateHasPermitType(view);
            ValidateHasTemplateSelected(view);
            ValidateDates(view);
            ValidateAllCheckedCheckboxesHaveAValue(view);
            ValidateHasFunctionalLocation(view);
            ValidateHasTrade(view);
            ValidateHasDescription(view);
            ValidateTimeSpan(view);
        }

        private void ValidateAllCheckedCheckboxesHaveAValue(IWorkPermitMontrealFormView view)
        {
            TernaryString corrosif = view.Corrosif.Value;
            if (corrosif.CheckedWithNoValue)
            {
                action.SetErrorForCorrosif();
                hasErrors = true;
            }

            TernaryString aromatique = view.Aromatique.Value;
            if (aromatique.CheckedWithNoValue)
            {
                action.SetErrorForAromatique();
                hasErrors = true;
            }

            TernaryString autresSubstances = view.AutresSubstances.Value;
            if (autresSubstances.CheckedWithNoValue)
            {
                action.SetErrorForAutresSubstances();
                hasErrors = true;
            }

            TernaryString dessins = view.DessinsRequis.Value;
            if (dessins.CheckedWithNoValue)
            {
                action.SetErrorForDessinsRequis();
                hasErrors = true;
            }

            TernaryString boite = view.BoiteEnergieZero.Value;
            if (boite.CheckedWithNoValue)
            {
                action.SetErrorForBoiteEnergieZero();
                hasErrors = true;
            }

            TernaryString formulaire = view.FormulaireDespaceClosAffiche.Value;
            if (formulaire.CheckedWithNoValue)
            {
                action.SetErrorForFormulaireDespaceClosAffiche();
                hasErrors = true;
            }

            TernaryString autreConditions = view.AutreConditions.Value;
            if (autreConditions.CheckedWithNoValue)
            {
                action.SetErrorForAutreConditions();
                hasErrors = true;
            }

            TernaryString protection = view.ProtectionRespiratoire.Value;
            if (protection.CheckedWithNoValue)
            {
                action.SetErrorForProtectionRespiratoire();
                hasErrors = true;
            }

            TernaryString habits = view.Habits.Value;
            if (habits.CheckedWithNoValue)
            {
                action.SetErrorForHabits();
                hasErrors = true;
            }

            TernaryString autreProtection = view.AutreProtection.Value;
            if (autreProtection.CheckedWithNoValue)
            {
                action.SetErrorForAutreProtection();
                hasErrors = true;
            }

            TernaryString autreProtectionIncendie = view.AutresEquipementDincendie.Value;
            if (autreProtectionIncendie.CheckedWithNoValue)
            {
                action.SetErrorForAutresEquipementDincendie();
                hasErrors = true;
            }

            TernaryString surveillant = view.Surveillant.Value;
            if (surveillant.CheckedWithNoValue)
            {
                action.SetErrorForSurveillant();
                hasErrors = true;
            }

            TernaryString detectionContinueDesGaz = view.DetectionContinueDesGaz.Value;
            if (detectionContinueDesGaz.CheckedWithNoValue)
            {
                action.SetErrorForDetectionContinueDesGaz();
                hasErrors = true;
            }

            TernaryString autreEquipmentsSecuritie = view.AutreEquipementsSecurite.Value;
            if (autreEquipmentsSecuritie.CheckedWithNoValue)
            {
                action.SetErrorForAutreEquipementsSecurite();
                hasErrors = true;
            }
        }

        private void ValidateHasDescription(IWorkPermitMontrealFormView view)
        {
            if (view.Description.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorForNoDescription();
                hasErrors = true;
            }
        }

        private void ValidateHasTemplateName(IWorkPermitMontrealFormView view)
        {
            if (view.SelectedPermitTemplateName.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorForNoTemplateName();
                hasErrors = true;
            }
        }

        private void ValidateHasTemplateSelected(IWorkPermitMontrealFormView view)
        {
            WorkPermitMontrealTemplate selectedPermitTemplate = view.SelectedPermitTemplate;
            if (selectedPermitTemplate == null || selectedPermitTemplate.Id == WorkPermitMontrealTemplate.NULL.Id)
            {
                action.SetErrorForNoSelectedTemplate();
                hasErrors = true;
            }
        }

        private void ValidateHasTrade(IWorkPermitMontrealFormView view)
        {
            if (view.SelectedTrade.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorForNoTrade();
                hasErrors = true;
            }
        }

        private void ValidateHasFunctionalLocation(IWorkPermitMontrealFormView view)
        {
            if (view.FunctionalLocations == null || view.FunctionalLocations.IsEmpty())
            {
                action.SetErrorForNoFunctionalLocation();
                hasErrors = true;
            }
        }

        private void ValidateDates(IWorkPermitMontrealFormView view)
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

        private void ValidateHasPermitType(IWorkPermitMontrealFormView view)
        {
            if (view.SelectedPermitType == null || WorkPermitMontrealType.NULL.Equals(view.SelectedPermitType))
            {
                action.SetErrorForNoPermitType();
                hasErrors = true;
            }
        }

        private void ValidateTimeSpan(IWorkPermitMontrealFormView view)
        {
            DateTime start = view.StartDateTime;
            DateTime end = view.EndDateTime;

            TimeSpan span = end - start;

            if (WorkPermitMontrealType.VEHICLE_ENTRY.Equals(view.SelectedPermitType))
            {                               
                if (span.TotalHours > 1)
                {
                    view.SetErrorForTimeSpanTooLongForVehicleEntryType();
                    hasErrors = true;
                }
            }
            else if (view.SelectedPermitType.IsOneOf(WorkPermitMontrealType.DURATION_PERMIT_TYPES))
            {
                if (span.TotalDays > 30)
                {
                    view.SetErrorForTimeSpanTooLongForDurationType();
                    hasErrors = true;
                }
            }
            else
            {
                if (span.TotalHours > 12)
                {
                    view.SetErrorForTimeSpanTooLong();
                    hasErrors = true;
                }
            }
        }
    }
}