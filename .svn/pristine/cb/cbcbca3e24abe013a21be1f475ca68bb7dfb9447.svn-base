using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class WorkPermitMudsValidator
    {
        private readonly IWorkPermitMudsValidationAction action;
        private bool hasErrors;

        public bool warning = false;

        public WorkPermitMudsValidator(IWorkPermitMudsValidationAction action)
        {
            this.action = action;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        public void ValidateTemplateFormAndSetErrors(IWorkPermitMudsFormView view)
        {
            ValidateHasPermitType(view);
            ValidateHasTemplateName(view);
        }

        public void ValidateUserFormAndSetErrors(IWorkPermitMudsFormView view)
        {
            ValidateHasPermitType(view);
            //ValidateHasTemplateSelected(view); //Gabarit // Commented as user don't want validation
            ValidateDates(view);
            ValidateAllCheckedCheckboxesHaveAValue(view);  // Commented by Vibhor - Validation removed under this - RITM0582990 - remove validation
            ValidateHasFunctionalLocation(view);
            //ValidateHasTrade(view);
            ValidateHasDescription(view);
            ValidateTimeSpan(view);
        }

        private void ValidateAllCheckedCheckboxesHaveAValue(IWorkPermitMudsFormView view)
        {

            TernaryString objAutreElev = view.AutresTravaux.Value;
            if (objAutreElev.CheckedWithNoValue)
            {
                action.SetErrorForAutresTravexElev();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objAutreMod = view.AutresInstruction.Value; 
            if (objAutreMod.CheckedWithNoValue)
            {
                action.SetErrorForAutresTravexMod();
                //hasErrors = true;
                warning = true;
            }

            TernaryString objRemplir = view.RemplirLeFormulaireDeCondition.Value;
            //int _value;
            if (objRemplir.CheckedWithNoValue)
            {
                action.SetErrorForRemplir();
                //hasErrors = true;
                warning = true;
            }
            else if (objRemplir.HasValue)
            {
                if (!objRemplir.Text.IsIntegralNumber())
                {
                    action.SetErrorForRemplirForNumeric();
                    //hasErrors = true;
                    warning = true;
                }
            }
            
            TernaryString objProcedureEnt = view.ProcedureEntretien.Value; 
            if (objProcedureEnt.CheckedWithNoValue)
            {
                action.SetErrorForProcedureEnt();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objAutresCondition = view.AutresConditions.Value; 
            if (objAutresCondition.CheckedWithNoValue)
            {
                action.SetErrorForAutresCondition();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objFco = view.ProcedureEntretien.Value; 
            if (objFco.CheckedWithNoValue)
            {
                action.SetErrorForFco();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objEtiquette = view.EtiquettObturateur.Value; 
            if (objEtiquette.CheckedWithNoValue)
            {
                action.SetErrorForEtiquette();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objVehicleComb = view.AppareilEquipementDePrevention.Value; 
            if (objVehicleComb.CheckedWithNoValue)
            {
                action.SetErrorForAutresAppVehicleComb();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objElectricVolt = view.ElectronicVoltRisques.Value; 
            if (objElectricVolt.CheckedWithNoValue)
            {
                action.SetErrorForElectricVolt();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objAutresRisque = view.AutresRisques.Value; 
            if (objAutresRisque.CheckedWithNoValue)
            {
                action.SetErrorForAutresRisque();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objAppreilResp = view.AppareilEquipementDePrevention.Value; 
            if (objAppreilResp.CheckedWithNoValue)
            {
                action.SetErrorForAppreilResp();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objGants = view.GantsEquipementDeProtection.Value; 
            if (objGants.CheckedWithNoValue)
            {
                action.SetErrorForGants();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objEpiAnti = view.EpiAntiArcCatProtecteurEquipementDeProtection.Value; 
            if (objEpiAnti.CheckedWithNoValue)
            {
                action.SetErrorForEpiAnti();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objHabitP = view.HabitProtecteurEquipementDeProtection.Value; 
            if (objHabitP.CheckedWithNoValue)
            {
                action.SetErrorForHabitP();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objAlrmeDcs = view.AlarmeDcs.Value; 
            if (objAlrmeDcs.CheckedWithNoValue)
            {
                action.SetErrorForAlrmeDcs();
                //hasErrors = true;
                warning = true;
            }
            //TernaryString objOutilManuel = view.OutilManuelEquipementDePrevention.Value; 
            //if (objOutilManuel.CheckedWithNoValue)
            //{
            //    action.SetErrorForOutilManuel();
            //    hasErrors = true;
            //}
            TernaryString objPerimetereSecurities = view.PerimetreDeSecurityEquipementDePrevention.Value; 
            if (objPerimetereSecurities.CheckedWithNoValue)
            {
                action.SetErrorForPerimetereSecurities();
                //hasErrors = true;
                warning = true;
            }
            TernaryString objAutresDePrevention = view.AutresEquipementDePrevention.Value; 
            if (objAutresDePrevention.CheckedWithNoValue)
            {
                action.SetErrorForAutresDePrevention();
                //hasErrors = true;
                warning = true;
            }
        }

        private void ValidateHasDescription(IWorkPermitMudsFormView view)
        {
            if (view.Description.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorForNoDescription();
                hasErrors = true;
            }
        }

        private void ValidateHasTemplateName(IWorkPermitMudsFormView view)
        {
            if (view.SelectedPermitTemplateName.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorForNoTemplateName();
                hasErrors = true;
            }
        }

        private void ValidateHasTemplateSelected(IWorkPermitMudsFormView view)
        {
            // User don;t want validation

            //WorkPermitMudsTemplate selectedPermitTemplate = view.SelectedPermitTemplate;
            //if (selectedPermitTemplate == null || selectedPermitTemplate.Id == WorkPermitMudsTemplate.NULL.Id)
            //{
            //    action.SetErrorForNoSelectedTemplate();
            //    hasErrors = true;
            //}
        }

        private void ValidateHasTrade(IWorkPermitMudsFormView view)
        {
            if (view.SelectedTrade.IsNullOrEmptyOrWhitespace())
            {
                action.SetErrorForNoTrade();
                hasErrors = true;
            }
        }

        private void ValidateHasFunctionalLocation(IWorkPermitMudsFormView view)
        {
            if (view.FunctionalLocations == null || view.FunctionalLocations.IsEmpty())
            {
                action.SetErrorForNoFunctionalLocation();
                hasErrors = true;
            }
        }

        private void ValidateDates(IWorkPermitMudsFormView view)
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

        private void ValidateHasPermitType(IWorkPermitMudsFormView view)
        {
            if (view.SelectedPermitType == null || WorkPermitMudsType.NULL.Equals(view.SelectedPermitType))
            {
                action.SetErrorForNoPermitType();
                hasErrors = true;
            }
        }

        private void ValidateTimeSpan(IWorkPermitMudsFormView view)
        {
            DateTime start = view.StartDateTime;
            DateTime end = view.EndDateTime;

            TimeSpan span = end - start;
            if (span.TotalHours > 12)
            {
                view.SetErrorForTimeSpanTooLong();
                hasErrors = true;
            }
           
        }
    }
}