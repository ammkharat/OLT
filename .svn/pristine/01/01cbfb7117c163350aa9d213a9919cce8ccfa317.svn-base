using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public abstract class SubmitPermitRequestWithGroupsOptionFormPresenter<TPermitRequestDTO> : BaseFormPresenter<ISubmitPermitRequestWithGroupsOptionFormView>
        where TPermitRequestDTO : BasePermitRequestDTO
    {
        private readonly List<TPermitRequestDTO> userSelectedRequests;
        private Date workPermitDate;
        private readonly SubmitPermitRequests<TPermitRequestDTO> submitPermitRequests;
        private readonly CheckPermitRequestAssociationAlreadyExists<TPermitRequestDTO> checkPermitRequestAssociationAlreadyExists;
        private readonly bool selectedPermitRequestsOnlyMode;

        public SubmitPermitRequestWithGroupsOptionFormPresenter(List<TPermitRequestDTO> requests, SubmitPermitRequests<TPermitRequestDTO> submitPermitRequests, CheckPermitRequestAssociationAlreadyExists<TPermitRequestDTO> checkPermitRequestAssociationAlreadyExists, bool selectedPermitRequestsOnlyMode)
            : base(new SubmitPermitRequestWithGroupsOptionForm())
        {            
            userSelectedRequests = requests ?? new List<TPermitRequestDTO>();
            this.submitPermitRequests = submitPermitRequests;
            this.checkPermitRequestAssociationAlreadyExists = checkPermitRequestAssociationAlreadyExists;
            this.selectedPermitRequestsOnlyMode = selectedPermitRequestsOnlyMode;

            view.CancelButtonClicked += CancelButton_Click;
            view.SubmitButtonClicked += SubmitButton_Click;
            view.SubmissionTypeChanged += SubmissionType_Changed;
            view.Load += ViewOnLoad;
        }

        private void ViewOnLoad(object sender, EventArgs eventArgs)
        {
            List<IWorkPermitGroup> groups = QueryAllGroups();
            view.AllGroups = groups;

            if (groups.Count == 0 || selectedPermitRequestsOnlyMode)
            {
                view.DisableAllCompletedPermitRequestsOption();
            }

            SubmissionType_Changed();
        }

        protected abstract List<IWorkPermitGroup> QueryAllGroups();

        private void UpdateDateField()
        {
            Date tomorrow = Clock.DateNow.AddDays(1);

            if (view.SubmitAllCompletedPermitRequestsForASpecificGroup)
            {
                view.DateEnabled = true;
                view.Date = tomorrow;
                return;
            }

            List<TPermitRequestDTO> dtos = Requests;

            if (dtos.Count == 0)
            {
                view.DateEnabled = false;
                view.Date = tomorrow;
                return;
            }

            SubmitPermitRequestFormPresenterHelper<TPermitRequestDTO> helper = new SubmitPermitRequestFormPresenterHelper<TPermitRequestDTO>();
            Date unambiguousSubmissionDate = helper.GetUnambiguousSubmissionDate(dtos);
            if (unambiguousSubmissionDate != null)
            {
                view.DateEnabled = false;
                view.Date = unambiguousSubmissionDate;
            }
            else
            {
                DateRange sharedDates = helper.GetSharedDates(dtos);
                
                if (sharedDates == null)
                {
                    view.DateEnabled = false;
                    view.Date = tomorrow;        // Just set it to anything. Validation will fail.
                }
                else
                {
                    Date startDate = new Date(sharedDates.SqlFriendlyStart);
                    Date endDate = new Date(sharedDates.SqlFriendlyEnd);

                    Date firstSharedDateLaterThanToday = null;
                    sharedDates.ForEachDay(day =>
                    {
                        if (firstSharedDateLaterThanToday == null && day >= tomorrow)
                        {
                            firstSharedDateLaterThanToday = day;
                        }
                    });

                    if (firstSharedDateLaterThanToday != null)
                    {
                        view.Date = firstSharedDateLaterThanToday;
                    }
                    else
                    {
                        view.Date = Clock.DateNow;
                    }

                    if (startDate.Equals(endDate))  // the requests only share one date
                    {
                        view.DateEnabled = false;
                    }
                    else  // the requests share multiple dates
                    {
                        view.DateEnabled = true;
                    }
                }
            }
        }

        private List<TPermitRequestDTO> Requests
        {
            get
            {
                if (view.SubmitOnlySelectedPermitRequests)
                {
                    return userSelectedRequests;
                }
                else
                {
                    if (view.Group != null)
                    {
                        return QueryPermitRequestsByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete, PermitRequestCompletionStatus.ForReview }, view.Group.Id.Value, view.Date);
                    }

                    return new List<TPermitRequestDTO>();
                }
            }
        }

        protected abstract List<TPermitRequestDTO> QueryPermitRequestsByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date);
        
        private void SubmissionType_Changed()
        {
            UpdateDateField();

            if (view.SubmitOnlySelectedPermitRequests)
            {
                view.GroupSelectionEnabled = false;
            }
            else
            {
                view.GroupSelectionEnabled = true;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (ValidateView() && (ShouldGoAheadWithTheSubmissionProcess(view.Date, Requests)))
            {
                workPermitDate = view.Date;
                view.DialogResult = DialogResult.OK;
                view.Close();
            }
        }

        private bool ShouldGoAheadWithTheSubmissionProcess(Date permitDate, List<TPermitRequestDTO> requestDtos)
        {
            string waringMessage = requestDtos.Count == 1
                                       ? StringResources.DuplicatePermitRequestSubmissionForSinglePermitWarning
                                       : StringResources.DuplicatePermitRequestSubmissionForMultiplePermitsWarning;

            if (checkPermitRequestAssociationAlreadyExists != null && checkPermitRequestAssociationAlreadyExists(permitDate, requestDtos))
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

        private bool ValidateView()
        {
            List<TPermitRequestDTO> requests = Requests;

            SubmitPermitRequestValidator<TPermitRequestDTO> validator = new SubmitPermitRequestValidator<TPermitRequestDTO>(view);
            validator.ValidateAndSetErrors(requests);

            // return here if there are errors so that our 'no completed permit requests found' error doesn't replace the more basic 'date cannot be in the past' one
            if (validator.HasErrors)
            {
                return false;
            }
            
            // this validation is Edmonton specific so we do it here instead of in the validator
            if (requests.Count == 0)
            {
                view.SetErrorForNoCompletedPermitRequestsFound();
                return false;
            }
            
            return true;
        }

        public override DialogResult Run(IWin32Window parent)
        {
            DialogResult dialogResult = base.Run(parent);

            if (dialogResult == DialogResult.Cancel)
            {
                return DialogResult.Cancel;
            }
            else
            {
                if (submitPermitRequests != null)
                {
                    submitPermitRequests(workPermitDate, Requests, ClientSession.GetUserContext().User);
                }

                return DialogResult.OK;                    
            }
        }

    }
}