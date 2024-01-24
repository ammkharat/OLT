using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Validation.Lubes
{
    public class PermitRequestLubesOtherWarnings
    {
        private readonly IPermitRequestLubesView view;
        private bool userChoseABroadFloc;

        public PermitRequestLubesOtherWarnings(IPermitRequestLubesView view)
        {
            this.view = view;
        }

        public void Validate()
        {
            ClearWarnings();

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
                return userChoseABroadFloc;
            }
        }

        public List<string> Warnings(bool includeValidationWarning)
        {
            List<string> warnings = new List<string>();
            if (userChoseABroadFloc)
            {
                warnings.Add(StringResources.WorkPermitLubes_SelectedFunctionalLocationIsBroadWarning);
            }
            if (includeValidationWarning)
            {
                warnings.Add(StringResources.PermitRequest_Validation_WarningsOnlyMessage);
            }

            return warnings;
        }
    }
}
