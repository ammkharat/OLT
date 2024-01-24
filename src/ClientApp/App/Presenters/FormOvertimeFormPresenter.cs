using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.Data.Linq;
using Infragistics.Win;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormOvertimeFormPresenter : AddEditBaseFormPresenter<IFormOvertimeView, OvertimeForm>
    {
        private readonly OvertimeForm originalOvertimeForm;
        private readonly IFormEdmontonService service;
        private readonly IEdmontonSwipeCardService swipeCardService;
        private List<Contractor> contractors;
        private List<CraftOrTrade> craftOrTrades;
        private List<EdmontonPerson> personnelNames;
        private List<string> primaryLocations;


        public FormOvertimeFormPresenter()
            : this(CreateDefaultOvertimeForm())
        {
        }

        public FormOvertimeFormPresenter(OvertimeForm overtimeForm)
            : base(new FormOvertimeForm(), overtimeForm)
        {
            originalOvertimeForm = overtimeForm.DeepClone();

            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            swipeCardService = ClientServiceRegistry.Instance.GetService<IEdmontonSwipeCardService>();

            view.FormLoad += HandleFormLoad;
            view.AddButtonClicked += HandleAddButtonClick;
            view.RemoveButtonClicked += HandleRemoveButtonClick;
            view.CloneButtonClicked += HandleCloneButtonClick;
            view.StartDateChanged += HandleStartDateChanged;
            view.EndDateChanged += HandleEndDateChanged;
            view.ApprovalSelected += HandleApprovalSelected;
            view.ApprovalUnselected += HandleApprovalUnselected;
            view.HistoryButtonClicked += HandleHistoryButtonClick;
            view.SaveAndEmailButtonClicked += HandleSaveAndEmailClicked;
        }

        private static OvertimeForm CreateDefaultOvertimeForm()
        {

            long siteid = ClientSession.GetUserContext().SiteId;
            var now = Clock.Now;
            var userContext = ClientSession.GetUserContext();

            var divisionsForSelectedFunctionalLocations = userContext.DivisionsForSelectedFunctionalLocations;
            // there will always be at least one in this list, or there is a big problem. 
            var edmontonTopLevelFunctionalLocation = divisionsForSelectedFunctionalLocations[0];

            var form = new OvertimeForm(null, FormStatus.Draft, now, now, userContext.User, now,
                new List<OnPremiseContractor>
                {
                    new OnPremiseContractor(null, null, string.Empty, string.Empty, userContext.UserShift.StartDateTime,
                        userContext.UserShift.EndDateTime, false, false, string.Empty,
                        string.Empty, string.Empty, string.Empty, string.Empty,0)
                }, edmontonTopLevelFunctionalLocation, string.Empty, userContext.User, now,null,siteid);     //ayman generic forms

            return form;
        }

        private void HandleHistoryButtonClick()
        {
            var presenter = new EditFormEdmontonOvertimeFormHistoryPresenter(editObject);
            presenter.Run(view);
        }

        private void HandleApprovalUnselected(FormApproval approval)
        {
            approval.ApprovedByUser = null;
            approval.ApprovalDateTime = null;
            approval.WorkAssignmentDisplayName = null;
        }

        private void HandleApprovalSelected(FormApproval approval)
        {
            approval.ApprovedByUser = userContext.User;
            if (userContext.Assignment != null) approval.WorkAssignmentDisplayName = userContext.Assignment.Name;
            approval.ApprovalDateTime = Clock.Now;
        }

        /// <summary>
        ///     When one line of End Dates changes, we need to update the End Dates.
        ///     Could just compare current value of OvertimeEnd with the last one, but this seems like an easy way to make it work
        ///     too.
        /// </summary>
        private void HandleEndDateChanged()
        {
            var overtimeContractorDisplayAdapters = view.OnPremiseContractors;
            if (overtimeContractorDisplayAdapters.IsEmpty())
                return;
            var dateTime = overtimeContractorDisplayAdapters.Max(c => c.EndDate);
            view.OvertimeEnd = dateTime;
        }

        private void HandleStartDateChanged()
        {
            var overtimeContractorDisplayAdapters = view.OnPremiseContractors;
            if (overtimeContractorDisplayAdapters.IsEmpty())
                return;
            var dateTime = overtimeContractorDisplayAdapters.Min(c => c.StartDate);
            view.OvertimeStart = dateTime;
        }

        private void HandleCloneButtonClick()
        {
            var overtimeContractorDisplayAdapter = view.SelectedPersonnel;
            if (overtimeContractorDisplayAdapter == null)
                return;

            var selectedPersonnel = overtimeContractorDisplayAdapter;
            var onPremiseContractor = selectedPersonnel.GetOnPremisePerson();
            var clone = onPremiseContractor.DeepClone();
            clone.Id = null;

            view.AddOnPremiseContractor(new OvertimeContractorDisplayAdapter(clone));
            EnableOrDisableRemoveButton();
        }

        private void HandleRemoveButtonClick()
        {
            view.RemoveSelectedOnPremiseContractor();
            EnableOrDisableRemoveButton();
        }

        private void HandleAddButtonClick()
        {
            var overtimeContractorDisplayAdapter =
                new OvertimeContractorDisplayAdapter(new OnPremiseContractor(null, editObject.Id, string.Empty,
                    string.Empty, userContext.UserShift.StartDateTime,
                    userContext.UserShift.EndDateTime, false, false, string.Empty, string.Empty, string.Empty,
                    string.Empty, string.Empty, 0));

            view.AddOnPremiseContractor(overtimeContractorDisplayAdapter);
            EnableOrDisableRemoveButton();
        }

        private void HandleFormLoad()
        {
            LoadData(new List<Action> {LoadContractors, LoadPrimaryLocations, LoadCraftOrTrades, LoadPersonnelNames});
        }

        private void LoadPersonnelNames()
        {
            personnelNames = swipeCardService.QueryAll();
        }

        private void LoadPrimaryLocations()
        {
            var dropdownValues = ClientServiceRegistry.Instance.GetService<IDropdownValueService>()
                .QueryByKey(userContext.SiteId, OvertimePrimaryLocationDropDownValueKeys.OvertimePrimaryLocations);
            primaryLocations = OvertimePrimaryLocationDropDownValueKeys.PrimaryLocationsDropdownValues(dropdownValues);
        }

        private void LoadContractors()
        {
            contractors = ClientServiceRegistry.Instance.GetService<IContractorService>().QueryBySite(userContext.Site);
        }

        private void LoadCraftOrTrades()
        {
            craftOrTrades =
                ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>().QueryBySite(userContext.Site);
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.CreateOrEditOvertimeRequestFormTitle);

            SetupCraftOrTradesList();
            SetupContractorsList();
            view.PrimaryLocations = primaryLocations;
            view.PersonnelList = personnelNames;

            UpdateViewFromEditObject();

            var authorized = new Authorized();
            if (!authorized.ToApproveOvertimeForm(userContext.UserRoleElements))
            {
                view.DisableApprovals();
            }
            //Start Minlge Story #4003, Change By : Swapnil, Changed On : 29 Mar 2016
            else
            {
                view.ChangeButtonText();
               
                HandleApprovalSelected(view.Approvals[0]);  //Ayman  MS4003
                view.Approvals = editObject.Approvals;      //Ayman MS4003
                view.DisableApprovals();

            }
            //End Minlge Story #4003, Change By : Swapnil, Changed On : 29 Mar 2016
        }

        private void UpdateViewFromEditObject()
        {
            view.Trade = editObject.Trade;
            view.Approvals = editObject.Approvals;
            view.OnPremiseContractors =
                editObject.OnPremiseContractors.ConvertAll(c => new OvertimeContractorDisplayAdapter(c));
            view.DocumentLinks = editObject.DocumentLinks;
            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;
            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;
            view.OvertimeStart = editObject.FromDateTime;
            view.OvertimeEnd = editObject.ToDateTime;
        }

        private void EnableOrDisableRemoveButton()
        {
            view.RemoveButtonEnabled = view.OnPremiseContractors.Count != 1;
        }

        private void SetupContractorsList()
        {
            contractors.Sort(c => c.CompanyName);
            contractors.Insert(0, Contractor.EMPTY);
            view.Contractors = contractors;
        }

        private void SetupCraftOrTradesList()
        {
            craftOrTrades.Sort(c => c.Name);
            craftOrTrades.Insert(0, CraftOrTrade.EMPTY);
            view.AllCraftOrTrades = craftOrTrades;
        }


        protected override bool ValidateViewHasError()
        {
            var hasErrors = false;
            view.ClearErrorProviders();

            if (view.Trade.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForNoTrade();
                hasErrors = true;
            }

            var onPremiseContractors = view.OnPremiseContractors;

            if (onPremiseContractors.Count < 1)
            {
                view.SetErrorForOvertimePersonnel();
                hasErrors = true;
            }

            onPremiseContractors.ForEach(item =>
            {
                if (item.PersonnelName.IsNullOrEmptyOrWhitespace())
                {
                    item.AddError(StringResources.OvertimeForm_ErrorPersonnelRequired);
                    hasErrors = true;
                }
                if (item.PrimaryLocation.IsNullOrEmptyOrWhitespace())
                {
                    item.AddError(StringResources.OvertimeForm_ErrorPrimaryLocationRequired);
                    hasErrors = true;
                }
                if (item.StartDate == DateTime.MinValue || item.EndDate == DateTime.MinValue)
                {
                    item.AddError(StringResources.OvertimeForm_InvalidDate);
                }
                else
                {
                    if (item.StartDate > item.EndDate)
                    {
                        item.AddError(StringResources.OvertimeForm_ErrorStartAfterEnd);
                        hasErrors = true;
                    }

                    if (!item.DayShift && !item.NightShift)
                    {
                        item.AddError(StringResources.OvertimeForm_ErrorShiftRequired);
                        hasErrors = true;
                    }
                    if (!item.DatesContainsRequestedShifts())
                    {
                        item.AddError(StringResources.OvertimeForm_ErrorShiftsNotMatchingStartAndEnd);
                        hasErrors = true;
                    }
                }
                if (item.Description.IsNullOrEmptyOrWhitespace())
                {
                    item.AddError(StringResources.OvertimeForm_ErrorDescriptionRequired);
                    hasErrors = true;
                }
                if (item.Contractor.IsNullOrEmptyOrWhitespace())
                {
                    item.AddError(StringResources.OvertimeForm_ErrorCompanyRequired);
                    hasErrors = true;
                }
                if (item.ExpectedHours <= 0)
                {
                    item.AddError(StringResources.OvertimeForm_ErrorExpectedOvertimeHoursNotGreaterThanZero);
                    hasErrors = true;
                }

                var matchingItems =
                    onPremiseContractors.FindAll(
                        otherItem => string.Equals(item.PersonnelName, otherItem.PersonnelName) &&
                                     string.Equals(item.PrimaryLocation, otherItem.PrimaryLocation) &&
                                     DateTime.Equals(item.StartDate, otherItem.StartDate) &&
                                     DateTime.Equals(item.EndDate, otherItem.EndDate));
                if (matchingItems.Count > 1)
                {
                    item.AddError(StringResources.OvertimeForm_ErrorRowNotUnique);
                    hasErrors = true;
                }
            });

            if (hasErrors)
            {
                view.MakeOvertimePersonGridValidationIconsShowOrDisappear();
            }

            return hasErrors;
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();
            var form =
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    ApplicationEvent.OvertimeFormCreate, service.InsertOvertimeForm, editObject);
            editObject.Id = form.Id;
        }


        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            Save(false);
        }

        private void HandleSaveAndEmailClicked()
        {
            Save(true);
        }

        private void Save(bool showEmail)
        {
            if (Validate())
            {
                return;
            }

            UpdateEditObjectFromView();

            if (IsEdit && FormWillNeedReapproval())
            {
                var result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;
                    // this is just for safety/clarity; if we're editing the form, it should already be in 'draft' mode
                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(ClientSession.GetUserContext().User,
                        view.Approvals);
                    SaveWithApprovalCheck(showEmail);
                }
            }
            else
            {
                SaveWithApprovalCheck(showEmail);
            }
        }

        private void SaveWithApprovalCheck(bool showEmail)
        {
            UpdateEditObjectFromView();

            if (editObject.AllApprovalsAreIn())
            {
                DateTime? approvalDateTime;

                if (IsEdit && !editObject.WillNeedReapproval(originalOvertimeForm))
                {
                    approvalDateTime = editObject.ApprovedDateTime ?? Clock.Now;
                }
                else
                {
                    approvalDateTime = Clock.Now;
                }

                editObject.MarkAsApproved(approvalDateTime);
            }
            else
            {
                editObject.MarkAsUnapproved();
            }

            SaveOrUpdate(true);

            if (showEmail)
            {
                ShowEmail();
            }
        }

        private bool FormWillNeedReapproval()
        {
            return editObject.WillNeedReapproval(originalOvertimeForm);
        }

        private void ShowEmail()
        {
            FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.Overtime.Name, editObject.FormNumber);
        }

        private void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;

            editObject.Trade = view.Trade;
            editObject.FromDateTime = view.OvertimeStart;
            editObject.ToDateTime = view.OvertimeEnd;
            editObject.OnPremiseContractors = view.OnPremiseContractors.ConvertAll(item => item.GetOnPremisePerson());
            editObject.DocumentLinks = view.DocumentLinks;
            editObject.Approvals = view.Approvals;
            if (!editObject.Approvals.IsEmpty())
            {
                editObject.ApprovedDateTime = editObject.Approvals[0].ApprovalDateTime;
            }
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateOvertimeForm,
                editObject);
        }
    }
}