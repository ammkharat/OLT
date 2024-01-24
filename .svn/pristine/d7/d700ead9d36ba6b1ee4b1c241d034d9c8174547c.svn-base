using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters
{
    // The intention of this class is to be a newer version of the old import error presenter. It uses the newer code. Ideally all imports will move to use this
    // presenter except Edmonton which has weird requirements.
    public class ImportWorkOrderDataErrorFormPresenter : BaseFormPresenter<IImportPermitRequestErrorFormView>
    {
        private readonly List<WorkOrderDataImportResult> importResultList;
        private readonly PermitRequestPostFinalizeResult finalizeResult;

        public ImportWorkOrderDataErrorFormPresenter(List<WorkOrderDataImportResult> importResultList, PermitRequestPostFinalizeResult finalizeResult) : base(new ImportPermitRequestErrorForm())
        {
            view.Load += HandleFormLoad;
            view.OKButtonClicked += HandleOKButtonClicked;
            
            this.importResultList = importResultList;
            this.finalizeResult = finalizeResult;
        }

        private void HandleFormLoad(object sender, EventArgs e)
        {
            string errorLabelText = null;
           
            if (importResultList.Exists(r => r.HasError))
            {
                errorLabelText = StringResources.PermitRequestForm_ErrorLabel;                
            }
            else if (finalizeResult.HasRejections)
            {
                errorLabelText = StringResources.PermitRequestForm_RejectionLabel;
            }
            
            view.ErrorLabelText = errorLabelText;
            view.CopyRecommendationText = StringResources.PermitRequestForm_CopyRecommendation;
            view.MainDisplayText = WorkOrderDataImportResult.BuildDisplayText(finalizeResult, importResultList);             
        }

        private void HandleOKButtonClicked(object sender, EventArgs e)
        {
            view.Close();
        }
    }
}