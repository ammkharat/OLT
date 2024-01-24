using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.Validation.FortHills;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;

namespace Com.Suncor.Olt.Client.Validation.FortHills
{
    public class WorkPermitFortHillsOtherWarnings
    {
        private readonly IWorkPermitFortHillsView view;

        private bool descriptionWillNotFitOnReport;
        private bool workerIsToProvideGasTestDataAndNoGasTestLineEntriesExist;
        private bool shiftSupervisorFieldShouldProbablyBeFilledOut;

        public WorkPermitFortHillsOtherWarnings(IWorkPermitFortHillsView view)
        {
            this.view = view;
        }

        public void Validate()
        {
            ClearWarnings();
            WorkPermitEdmontonReport report = new WorkPermitEdmontonReport();
            descriptionWillNotFitOnReport = !report.StringWillFitIntoTaskDescriptionField(view.Description);
            shiftSupervisorFieldShouldProbablyBeFilledOut = ShiftSupervisorFieldShouldProbablyBeFilledOut();
        }

        private void ClearWarnings()
        {
            descriptionWillNotFitOnReport = false;
            workerIsToProvideGasTestDataAndNoGasTestLineEntriesExist = false;
            shiftSupervisorFieldShouldProbablyBeFilledOut = false;
        }

        public bool HasWarnings
        {
            get
            {
                return descriptionWillNotFitOnReport || workerIsToProvideGasTestDataAndNoGasTestLineEntriesExist || shiftSupervisorFieldShouldProbablyBeFilledOut;
            }
        }

        public List<string> Warnings(bool includeValidationWarning)
        {
            List<string> warnings = new List<string>();
            if (descriptionWillNotFitOnReport)
            {
                warnings.Add(StringResources.WorkPermit_TaskDescriptionTooLong);
            }
            if (workerIsToProvideGasTestDataAndNoGasTestLineEntriesExist)
            {
                warnings.Add(StringResources.WorkPermitEdmonton_NoGasTestDataEntered);
            }
            if (includeValidationWarning)
            {
                warnings.Add(StringResources.WorkPermit_Validation_WarningsOnlyMessage);
            }
            if (shiftSupervisorFieldShouldProbablyBeFilledOut)
            {
                warnings.Add(StringResources.WorkPermitEdmonton_NoShiftSupervisorEntered);
            }

            return warnings;
        }

        //private bool WorkerIsToProvideGasTestDataAndNoGasTestLineEntriesExist()
        //{
        //    bool workerIsToProvideGasTestData = view.WorkerToProvideGasTestDataEnabled && view.WorkerToProvideGasTestData;

        //    bool line1Empty = WorkPermitFortHillsValidator.GasTestLineIsEmpty(
        //        view.GasTestDataLine1CombustibleGas, view.GasTestDataLine1Oxygen,
        //        view.GasTestDataLine1ToxicGas, view.GasTestDataLine1Time);

        //    bool line2Empty = WorkPermitFortHillsValidator.GasTestLineIsEmpty(
        //        view.GasTestDataLine2CombustibleGas, view.GasTestDataLine2Oxygen,
        //        view.GasTestDataLine2ToxicGas, view.GasTestDataLine2Time);

        //    bool line3Empty = WorkPermitFortHillsValidator.GasTestLineIsEmpty(
        //        view.GasTestDataLine3CombustibleGas, view.GasTestDataLine3Oxygen,
        //        view.GasTestDataLine3ToxicGas, view.GasTestDataLine3Time);

        //    bool line4Empty = WorkPermitFortHillsValidator.GasTestLineIsEmpty(
        //        view.GasTestDataLine4CombustibleGas, view.GasTestDataLine4Oxygen,
        //        view.GasTestDataLine4ToxicGas, view.GasTestDataLine4Time);

        //    return (workerIsToProvideGasTestData && line1Empty && line2Empty && line3Empty && line4Empty);
        //}

        private bool ShiftSupervisorFieldShouldProbablyBeFilledOut()
        {
            //if (!view.ShiftSupervisor.IsNullOrEmptyOrWhitespace())
            //{
            //    return false;
            //}
            bool groupIsMaintenanceOrConstruction = view.Group != null && !view.Group.IsTurnaround;
            
            bool permitTypeIsHighEnergyHotWork = view.WorkPermitType == WorkPermitFortHillsType.BLANKET_HOT;
            bool specialWorkOrConfinedSpaceIsTicked = view.ConfinedSpace; //|| view.SpecialWork;

            //return gn75AIsChecked || gn24IsChecked || gn6IsChecked || (groupIsMaintenanceOrConstruction && (permitTypeIsHighEnergyHotWork || specialWorkOrConfinedSpaceIsTicked));
            return (groupIsMaintenanceOrConstruction && (permitTypeIsHighEnergyHotWork || specialWorkOrConfinedSpaceIsTicked));
        }
    }

}
