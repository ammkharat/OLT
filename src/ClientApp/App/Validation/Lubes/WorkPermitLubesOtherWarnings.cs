using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;

namespace Com.Suncor.Olt.Client.Validation.Lubes
{
    public class WorkPermitLubesOtherWarnings
    {
        private readonly IWorkPermitLubesView view;
        private bool userChoseABroadFloc;
        private bool descriptionWillNotFitOnReport;
        private bool hazardsWillNotFitOnReport;

        public WorkPermitLubesOtherWarnings(IWorkPermitLubesView view)
        {
            this.view = view;
        }

        public void Validate()
        {
            ClearWarnings();

            WorkPermitLubesReport_Pre_4_18 report = new WorkPermitLubesReport_Pre_4_18();
            descriptionWillNotFitOnReport = !report.StringWillFitIntoTaskDescriptionField(view.TaskDescription);
            hazardsWillNotFitOnReport = !report.StringWillFitIntoHazardsField(view.OtherHazardsAndOrRequirements);

            if (WorkPermitLubes.IsABroadFunctionalLocation(view.FunctionalLocation))
            {
                userChoseABroadFloc = true;
            }
        }

        private void ClearWarnings()
        {
            userChoseABroadFloc = false;
        }

        public bool HasWarnings
        {
            get
            {
                return userChoseABroadFloc || descriptionWillNotFitOnReport || hazardsWillNotFitOnReport;
            }
        }

        public List<string> Warnings(bool includeValidationWarning)
        {
            List<string> warnings = new List<string>();
            if (descriptionWillNotFitOnReport)
            {
                warnings.Add(StringResources.WorkPermit_TaskDescriptionTooLong);
            }
            if (hazardsWillNotFitOnReport)
            {
                warnings.Add(StringResources.WorkPermit_HazardsTooLong);
            }
            if (userChoseABroadFloc)
            {
                warnings.Add(StringResources.WorkPermitLubes_SelectedFunctionalLocationIsBroadWarning);
            }
            if (includeValidationWarning)
            {
                warnings.Add(StringResources.WorkPermit_Validation_WarningsOnlyMessage);
            }

            return warnings;
        }
    }
}
