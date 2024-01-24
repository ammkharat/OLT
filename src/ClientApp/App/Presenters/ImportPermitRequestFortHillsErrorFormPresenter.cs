using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ImportPermitRequestFortHillsErrorFormPresenter : BaseFormPresenter<IImportPermitRequestErrorFormView>
    {
        private readonly List<PermitRequestImportResult> resultList;
        private readonly int additionalSuccessCount = 0;

        public ImportPermitRequestFortHillsErrorFormPresenter(List<PermitRequestImportResult> resultList, int additionalSuccessCount) : base(new ImportPermitRequestErrorForm())
        {
            view.Load += HandleFormLoad;
            view.OKButtonClicked += HandleOKButtonClicked;

            this.additionalSuccessCount = additionalSuccessCount;
            this.resultList = resultList;
        }

        private void HandleFormLoad(object sender, EventArgs e)
        {
            string errorLabelText = null;
           
            if (resultList.HasErrors())
            {
                errorLabelText = StringResources.PermitRequestForm_ErrorLabel;                
            }
            else if (resultList.HasRejections())
            {
                errorLabelText = StringResources.PermitRequestForm_RejectionLabel;
            }
            
            view.ErrorLabelText = errorLabelText;
            view.CopyRecommendationText = StringResources.PermitRequestForm_CopyRecommendation;
            view.MainDisplayText = PermitRequestImportResult.BuildDisplayText(resultList, additionalSuccessCount);             
        }

        private void HandleOKButtonClicked(object sender, EventArgs e)
        {
            view.Close();
        }
    }
}