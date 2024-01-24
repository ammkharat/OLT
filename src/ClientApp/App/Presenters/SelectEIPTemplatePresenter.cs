using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;


namespace Com.Suncor.Olt.Client.Presenters
{
    public class SelectEIPTemplatePresenter<TDto, TEdmontonForm, TDetails, TPage> : AbstractDeletableDomainPagePresenter<TDto, TEdmontonForm, TDetails, TPage>

          where TDto : DomainObject, IFormEdmontonDTO
        where TEdmontonForm : DomainObject, IEdmontonForm
        where TDetails : class, IFormEdmontonDetails
        where TPage : FormPage<TDto, TDetails>
    {
        private readonly Range<Date> dateRangeOfPermitRequest;
        private readonly Range<DateTime> dateTimeRangeOfWorkPermit;

        public delegate DialogResult PostSelectFormActionDelegate(long formId);

        private readonly EdmontonFormType formType;
        private readonly List<FormStatus> formStatuses;
        private readonly IGridAndDetailsView view;
        private TDto createdOrEditedFormDTO;
        private readonly PostSelectFormActionDelegate postSelectFormActionDelegate;

        private readonly AbstractEdmontonFormContext<TDto, TEdmontonForm, TDetails> context;

        private readonly bool keepFormOpenAfterNewOrEdit;

        public SelectEIPTemplatePresenter(EdmontonFormType formType, TPage formPage, Range<DateTime> dateTimeRangeOfWorkPermit)
            : this(formType, formPage, null, false, dateTimeRangeOfWorkPermit)
        {
        }

        public SelectEIPTemplatePresenter(EdmontonFormType formType, TPage formPage, Range<Date> dateRangeOfPermitRequest)
            : this(formType, formPage, null, false, dateRangeOfPermitRequest)
        {
        }

        public SelectEIPTemplatePresenter(EdmontonFormType formType, TPage formPage, PostSelectFormActionDelegate postSelectFormActionDelegate, bool keepFormOpenAfterNewOrEdit, Range<DateTime> dateTimeRangeOfWorkPermit)
            : this(formType, new List<FormStatus> { FormStatus.Approved, FormStatus.WaitingForApproval }, true, true, formPage, postSelectFormActionDelegate, keepFormOpenAfterNewOrEdit)
        {
            this.dateTimeRangeOfWorkPermit = dateTimeRangeOfWorkPermit;
        }

        public SelectEIPTemplatePresenter(EdmontonFormType formType, TPage formPage, PostSelectFormActionDelegate postSelectFormActionDelegate, bool keepFormOpenAfterNewOrEdit, Range<Date> dateRangeOfPermitRequest)
            : this(formType, new List<FormStatus> { FormStatus.Approved, FormStatus.WaitingForApproval }, true, true, formPage, postSelectFormActionDelegate, keepFormOpenAfterNewOrEdit)
        {
            this.dateRangeOfPermitRequest = dateRangeOfPermitRequest;
        }

        private SelectEIPTemplatePresenter(EdmontonFormType formType, List<FormStatus> formStatuses, bool allowCreationOfNewForms, bool allowEditOfExistingForms,
            TPage formPage, PostSelectFormActionDelegate postSelectFormActionDelegate, bool keepFormOpenAfterNewOrEdit)
            : base(formPage, new Authorized(),
                ClientServiceRegistry.Instance.RemoteEventRepeater, ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<ITimeService>(), ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            this.keepFormOpenAfterNewOrEdit = keepFormOpenAfterNewOrEdit;

            this.formType = formType;
            this.formStatuses = formStatuses;
            view = new GridAndDetailsForm
            {
                Title = formType.GetName(),
                Height = 749,
                ButtonsVisible = true,
                AcceptButtonText = StringResources.SelectButtonLabel,
                GridAndDetails = page,
                NewButtonVisible = allowCreationOfNewForms,
            };

            this.postSelectFormActionDelegate = postSelectFormActionDelegate;

            page.SplitterDistance = 200;
            page.Details.MakeAllButtonsInvisible();
            page.Details.RangeVisible = true;
            page.Details.EditVisible = allowEditOfExistingForms;

            view.AcceptButtonClicked += AcceptButtonClicked;
            view.NewButtonClicked += NewButtonClicked;
            context = (AbstractEdmontonFormContext<TDto, TEdmontonForm, TDetails>)EdmontonContextFactory.GetContext(formType);
        }

        protected override void Edit(TEdmontonForm domainObject)
        {
            DialogResultAndOutput<TEdmontonForm> dialogResultAndOutput = context.Edit(domainObject, view);

            if (dialogResultAndOutput == null)
            {
                throw new OLTException("The Form Selection page was initialized without a valid form type.");
            }

            DialogResult result = dialogResultAndOutput.Result;
            if (result != DialogResult.Cancel)
            {
                IEdmontonForm form = dialogResultAndOutput.Output;
                createdOrEditedFormDTO = (TDto)form.CreateDTO();

                if (!keepFormOpenAfterNewOrEdit)
                {
                    view.DialogResult = DialogResult.OK;
                    view.Close();
                }
                else
                {
                    RefreshData();
                }
            }
        }

        private void NewButtonClicked()
        {
            DialogResultAndOutput<TEdmontonForm> dialogResultAndOutput = context.CreateNew(view);

            if (dialogResultAndOutput == null)
            {
                throw new OLTException("The Form Selection page was initialized without a valid form type.");
            }

            DialogResult result = dialogResultAndOutput.Result;
            if (result != DialogResult.Cancel)
            {
                IEdmontonForm form = dialogResultAndOutput.Output;
                createdOrEditedFormDTO = (TDto)form.CreateDTO();

                if (!keepFormOpenAfterNewOrEdit)
                {
                    view.DialogResult = DialogResult.OK;
                    view.Close();
                }
                else
                {
                    RefreshData();
                }
            }
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            Date from = Clock.DateNow.AddMonths(-1);
            return new Range<Date>(from, null);
        }

        private void AcceptButtonClicked()
        {
            if (page.Grid.Items.Count == 0)
            {
                view.DialogResult = DialogResult.Cancel;
                view.Close();
            }
            else if (page.FirstSelectedItem == null)
            {
                view.ShowMessageBox(formType.GetName(), StringResources.Form_PleaseSelect);
            }
            else
            {
                TDto firstSelectedItem = page.FirstSelectedItem;

                if (dateRangeOfPermitRequest != null && !firstSelectedItem.IsPermitRequestDatesWithinFormDates(dateRangeOfPermitRequest))
                {
                    DialogResult dialogResult = OltMessageBox.ShowCustomYesNo(StringResources.FormSelection_DatesNotValid_PermitRequest);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else if (dateTimeRangeOfWorkPermit != null && !firstSelectedItem.IsWorkPermitDateTimesWithinFormDateTimes(dateTimeRangeOfWorkPermit))
                {
                    DialogResult dialogResult = OltMessageBox.ShowCustomYesNo(StringResources.FormSelection_DatesNotValid_WorkPermit);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }

                if (postSelectFormActionDelegate != null)
                {
                    DialogResult result = postSelectFormActionDelegate(page.FirstSelectedItem.IdValue);
                    if (DialogResult.Cancel.Equals(result))
                    {
                        return;
                    }
                }

                view.DialogResult = DialogResult.OK;
                view.Close();
            }
        }

        protected override void Grid_DoubleClicked(object sender, DomainEventArgs<TDto> args)
        {
            AcceptButtonClicked();
        }

        public DialogResultAndOutput<TDto> Run(IWin32Window parent, long? selectedItemId)
        {
            DoInitialDataLoad();
            if (selectedItemId == null)
            {
                if (page.FirstSelectedItem != null)
                {
                    selectedItemId = page.FirstSelectedItem.Id;
                }
                else
                {
                    selectedItemId = 0;
                }
            }
            page.SelectSingleItemById(selectedItemId);

            DialogResult dialogResult = view.ShowDialog(parent);
            TDto dto = null;
            if (dialogResult == DialogResult.OK)
            {
                dto = createdOrEditedFormDTO ?? page.FirstSelectedItem;
            }

            view.Dispose();

            return new DialogResultAndOutput<TDto>(dialogResult, dto);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
        }

        protected override TEdmontonForm QueryByDto(TDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return context.QueryByIdAndSiteId(dto.IdValue, userContext.SiteId);  //ayman generic forms
        }

        protected override IList<TDto> GetDtos(Range<Date> dateRange)
        {
            RootFlocSet flocSet;

            if (userContext.SiteConfiguration.FormsFlocSetType.Equals(FunctionalLocationSetType.WorkPermit) && userContext.HasFlocsForWorkPermits)
            {
                flocSet = userContext.RootFlocSetForWorkPermits;
            }
            else
            {
                flocSet = userContext.RootFlocSet;
            }

            return context.GetData(flocSet, new DateRange(dateRange), formStatuses, false);
        }

        protected override TDto CreateDTOFromDomainObject(TEdmontonForm item)
        {
            return (TDto)item.CreateDTO();
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_Form; }
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<TDto> selectedItems = page.SelectedItems;
            bool hasSingleItemSelected = selectedItems.Count == 1;

            IFormEdmontonDetails details = page.Details;

            details.EditEnabled = hasSingleItemSelected && authorized.ToEditEipIssue(userRoleElements) && selectedItems[0].Status != FormStatus.Approved;     //ayman Sarnia eip - 3     //(userRoleElements, selectedItems[0].Status, selectedItems[0].FormType);
        }

        protected override void SetDetailData(TDetails details, TEdmontonForm item)
        {
            context.SetDetailData(details, item);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(TEdmontonForm item)
        {
            throw new NotImplementedException();
        }

        protected override IForm CreateEditForm(TEdmontonForm item)
        {
            throw new NotImplementedException();
        }

        protected override void Delete(TEdmontonForm item)
        {
            throw new NotImplementedException();
        }

        protected override bool IsItemInDateRange(TEdmontonForm item, Range<Date> range)
        {
            BaseEdmontonForm baseEdmontonForm = (BaseEdmontonForm)(DomainObject)item;

            if (baseEdmontonForm.CreatedBy.Id == userContext.User.Id)
            {
                return true;
            }
            DateRange theRange = new DateRange(range ?? GetDefaultDateRange());
            return theRange.Overlaps(baseEdmontonForm.FromDateTime, baseEdmontonForm.ToDateTime);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.Forms; }
        }
    }
}
