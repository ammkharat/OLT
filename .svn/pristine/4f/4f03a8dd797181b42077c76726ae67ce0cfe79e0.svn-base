using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters
{
    public delegate void SubmitPermitRequests<TPermitRequestDto>(Date workPermitDate, List<TPermitRequestDto> requestDtos, User user);
    public delegate bool CheckPermitRequestAssociationAlreadyExists<TPermitRequestDto>(Date workPermitDate, List<TPermitRequestDto> requestDtos);

    public class SubmitPermitRequestFormPresenter<TPermitRequestDto> : BaseFormPresenter<ISubmitPermitRequestFormView>
        where TPermitRequestDto : BasePermitRequestDTO
    {
        private readonly List<TPermitRequestDto> requests;
        private Date workPermitDate;
        private readonly SubmitPermitRequests<TPermitRequestDto> submitPermitRequests;
        private readonly CheckPermitRequestAssociationAlreadyExists<TPermitRequestDto> checkPermitRequestAssociationAlreadyExists;

        public SubmitPermitRequestFormPresenter(List<TPermitRequestDto> requests, SubmitPermitRequests<TPermitRequestDto> submitPermitRequests, CheckPermitRequestAssociationAlreadyExists<TPermitRequestDto> checkPermitRequestAssociationAlreadyExists, SubmitPermitRequestFormPresenterHelper<TPermitRequestDto> helper)
            : base(new SubmitPermitRequestForm())
        {
            this.requests = requests ?? new List<TPermitRequestDto>();
            this.submitPermitRequests = submitPermitRequests;
            this.checkPermitRequestAssociationAlreadyExists = checkPermitRequestAssociationAlreadyExists;

            Date unambiguousSubmissionDate = helper.GetUnambiguousSubmissionDate(requests);
            if (unambiguousSubmissionDate != null)
            {
                workPermitDate = unambiguousSubmissionDate;
                view.DateEnabled = false;
            }
            else
            {
                workPermitDate = helper.GetDefaultWorkPermitDate(requests);
                view.DateEnabled = true;
            }

            view.Date = workPermitDate;

            view.CancelButtonClicked += CancelButton_Click;
            view.SubmitButtonClicked += SubmitButton_Click;
        }
        
        private bool ShouldGoAheadWithTheSubmissionProcess(Date permitDate, List<TPermitRequestDto> requestDtos)
        {
            string waringMessage = requestDtos.Count == 1
                                       ? StringResources.DuplicatePermitRequestSubmissionForSinglePermitWarning
                                       : StringResources.DuplicatePermitRequestSubmissionForMultiplePermitsWarning;

            if (checkPermitRequestAssociationAlreadyExists(permitDate, requestDtos))
            {
                DialogResult result = OltMessageBox.ShowCustomYesNo(
                    Form.ActiveForm,
                    String.Format(waringMessage, permitDate),
                    StringResources.PermitRequestAlreadySubmitted,
                    MessageBoxIcon.Asterisk,
                    StringResources.Yes,
                    StringResources.No);
                return result == DialogResult.Yes;
            }
            return true;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (ValidateView() && (ShouldGoAheadWithTheSubmissionProcess(view.Date, requests)))
            {
                workPermitDate = view.Date;
                view.DialogResult = DialogResult.OK;
                view.Close();
            }
        }

        private bool ValidateView()
        {
            SubmitPermitRequestValidator<TPermitRequestDto> validator = new SubmitPermitRequestValidator<TPermitRequestDto>(view);
            validator.ValidateAndSetErrors(requests);
            return !validator.HasErrors;
        }

        public override DialogResult Run(IWin32Window parent)
        {
            if (requests.Count == 0)
            {
                return DialogResult.Cancel;
            }
            DialogResult dialogResult = base.Run(parent);

            if (dialogResult == DialogResult.Cancel)
            {
                return DialogResult.Cancel;
            }
            if (submitPermitRequests != null)
            {
                submitPermitRequests(workPermitDate, requests, ClientSession.GetUserContext().User);
            }

            return DialogResult.OK;
        }

    }
}