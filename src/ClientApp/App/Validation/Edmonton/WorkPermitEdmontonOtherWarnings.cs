using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;

namespace Com.Suncor.Olt.Client.Validation.Edmonton
{
    public class WorkPermitEdmontonOtherWarnings
    {
        private readonly IWorkPermitEdmontonView view;

        private bool descriptionWillNotFitOnReport;
        private bool workerIsToProvideGasTestDataAndNoGasTestLineEntriesExist;
        private bool shiftSupervisorFieldShouldProbablyBeFilledOut;

        public WorkPermitEdmontonOtherWarnings(IWorkPermitEdmontonView view)
        {
            this.view = view;
        }

        public void Validate()
        {
            ClearWarnings();

            WorkPermitEdmontonReport report = new WorkPermitEdmontonReport();
            descriptionWillNotFitOnReport = !report.StringWillFitIntoTaskDescriptionField(view.Description);
            workerIsToProvideGasTestDataAndNoGasTestLineEntriesExist = WorkerIsToProvideGasTestDataAndNoGasTestLineEntriesExist();
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

        private bool WorkerIsToProvideGasTestDataAndNoGasTestLineEntriesExist()
        {
            bool workerIsToProvideGasTestData = view.WorkerToProvideGasTestDataEnabled && view.WorkerToProvideGasTestData;

            bool line1Empty = WorkPermitEdmontonValidator.GasTestLineIsEmpty(
                view.GasTestDataLine1CombustibleGas, view.GasTestDataLine1Oxygen,
                view.GasTestDataLine1ToxicGas, view.GasTestDataLine1Time);

            bool line2Empty = WorkPermitEdmontonValidator.GasTestLineIsEmpty(
                view.GasTestDataLine2CombustibleGas, view.GasTestDataLine2Oxygen,
                view.GasTestDataLine2ToxicGas, view.GasTestDataLine2Time);

            bool line3Empty = WorkPermitEdmontonValidator.GasTestLineIsEmpty(
                view.GasTestDataLine3CombustibleGas, view.GasTestDataLine3Oxygen,
                view.GasTestDataLine3ToxicGas, view.GasTestDataLine3Time);

            bool line4Empty = WorkPermitEdmontonValidator.GasTestLineIsEmpty(
                view.GasTestDataLine4CombustibleGas, view.GasTestDataLine4Oxygen,
                view.GasTestDataLine4ToxicGas, view.GasTestDataLine4Time);

            return (workerIsToProvideGasTestData && line1Empty && line2Empty && line3Empty && line4Empty);
        }

        private bool ShiftSupervisorFieldShouldProbablyBeFilledOut()
        {
            if (!view.ShiftSupervisor.IsNullOrEmptyOrWhitespace())
            {
                return false;
            }

            bool gn75AIsChecked = view.GN75A;
            bool gn24IsChecked = view.GN24;
            bool gn6IsChecked = view.GN6;
            bool groupIsMaintenanceOrConstruction = view.Group != null && !view.Group.IsTurnaround;
            
            bool permitTypeIsHighEnergyHotWork = view.WorkPermitType == WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK;
            bool specialWorkOrConfinedSpaceIsTicked = view.ConfinedSpace || view.SpecialWork;

            return gn75AIsChecked || gn24IsChecked || gn6IsChecked || (groupIsMaintenanceOrConstruction && (permitTypeIsHighEnergyHotWork || specialWorkOrConfinedSpaceIsTicked));
        }
    }

}
