using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormOilsandsTrainingFormPresenter : AddEditBaseFormPresenter<IFormOilsandsTrainingView, FormOilsandsTraining>
    {
        private readonly IFormOilsandsService formService;

        private readonly IShiftPatternService shiftService;
        private readonly ITrainingBlockService trainingBlockService;

        private List<ShiftPattern> shiftPatterns;

        private List<FunctionalLocation> originalFlocs;
        private readonly List<FormOilsandsTrainingItem> originalTrainingItems = new List<FormOilsandsTrainingItem>();
        private Date originalTrainingDate;
        private string originalGeneralComments;
        private ShiftPattern originalShiftPattern;

        private readonly bool isClone;

        public FormOilsandsTrainingFormPresenter() : this(CreateDefaultForm())
        {
            isClone = false;
        }

        public FormOilsandsTrainingFormPresenter(FormOilsandsTraining form) : base(new FormOilsandsTrainingForm(), form)
        {
            SaveOriginalFormValues();

            isClone = form.Id == null;

            view.AddFunctionalLocationButtonClicked += HandleAddFunctionalLocationButtonClicked;
            view.RemoveFunctionalLocationButtonClicked += HandleRemoveFunctionalLocationButtonClicked;
            view.FormLoad += HandleFormLoad;
            view.ApprovalSelected += HandleApprovalSelected;
            view.ApprovalUnselected += HandleApprovalUnselected;
            view.SaveAndEmailButtonClicked += HandleSaveAndEmailClicked;
            view.AddTrainingBlockClicked += HandleAddTrainingBlock;
            view.RemoveTrainingBlockClicked += HandleRemoveTrainingBlock;
            view.HistoryClicked += HandleHistoryClicked;

            view.FlocValidator = new FunctionalLocationValidator(this);

            shiftService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();
            trainingBlockService = ClientServiceRegistry.Instance.GetService<ITrainingBlockService>();
            formService = ClientServiceRegistry.Instance.GetService<IFormOilsandsService>();
        }

        protected override bool IsClone
        {
            get { return isClone; }
        }

        private void HandleHistoryClicked()
        {
            EditHistoryFormPresenter presenter = new EditFormOilsandsTrainingHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        private void SaveOriginalFormValues()
        {
            editObject.TrainingItems.ForEach(item => originalTrainingItems.Add(item.DeepClone()));
            originalFlocs = new List<FunctionalLocation>(editObject.FunctionalLocations);
            originalGeneralComments = editObject.GeneralComments.DeepClone();
            originalTrainingDate = editObject.TrainingDate.DeepClone();
            originalShiftPattern = editObject.ShiftPattern.DeepClone();
        }

        private void HandleFormLoad()
        {
            LoadData(new List<Action> { QueryShiftPatterns });
        }

        protected override void AfterDataLoad()
        {
            view.ShiftPatterns = shiftPatterns;

            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.DomainObjectName_FormOilsandsTraining);
            UpdateViewFromEditObject();
            UpdateTrainingBlocksBasedOnFunctionalLocations();
            view.HistoryButtonEnabled = IsEdit;

            if (!IsEdit && !IsClone)
            {
                HandleAddTrainingBlock();
            }

            EnableOrDisableRemoveButton();

            Authorized authorized = new Authorized();
            view.ApprovalsEnabled = authorized.ToApproveOilsandsTrainingForm(ClientSession.GetUserContext().UserRoleElements);
        }

        private void QueryShiftPatterns()
        {
            shiftPatterns = shiftService.QueryBySite(ClientSession.GetUserContext().Site);
        }

        private void EnableOrDisableRemoveButton()
        {
            view.RemoveButtonEnabled = view.TrainingItems.Count != 1;
        }

        protected override bool ValidateViewHasError()
        {
            bool hasErrors = false;

            view.ClearErrorProviders();

            decimal totalHours = FormOilsandsTraining.CalculateHours(view.TrainingItems.ConvertAll(item => item.GetTrainingItem()));
            if (FormOilsandsTraining.IsOutsideIdealNumberOfHours(totalHours) && view.GeneralComments.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForNoGeneralComments();
                hasErrors = true;
            }

            if (view.SelectedFunctionalLocation == null)
            {
                view.SetErrorForNoFunctionalLocationSelected();
                hasErrors = true;
            }

            if (view.TrainingDate > Clock.DateNow)
            {
                view.SetErrorForTrainingDateCannotBeInTheFuture();
                hasErrors = true;  
            }
            else
            {
                UserShift currentUserShift = userContext.UserShift;
                UserShift enteredUserShift = new UserShift(view.Shift, view.TrainingDate);
                if (enteredUserShift.StartDateTime > currentUserShift.StartDateTime)
                {
                    view.SetErrorForTrainingDateCannotBeInTheFuture();
                    hasErrors = true;
                }
            }

            List<OilsandsTrainingItemDisplayAdapter> trainingItems = view.TrainingItems;
            
            trainingItems.ForEach(item =>
                {
                    if (item.TrainingBlock == null)
                    {
                        item.AddError(StringResources.FormOilsandsTrainingValidation_TrainingBlockMustBeSelected);
                        hasErrors = true;
                    }

                    if (item.Hours == null)
                    {
                        item.AddError(StringResources.FormOilsandsTrainingValidation_MustEnterHours);
                        hasErrors = true;
                    }

                    if (item.Hours == 0 && item.Comments.IsNullOrEmptyOrWhitespace())
                    {
                        item.AddError(StringResources.FormOilsandsTrainingValidation_MustEnterComment);
                        hasErrors = true;
                    }                    
                });

            List<OilsandsTrainingItemDisplayAdapter> itemsWithTrainingBlocks = trainingItems.FindAll(item => item.TrainingBlock != null);

            // check for duplicate training blocks on this form
            foreach (OilsandsTrainingItemDisplayAdapter item in itemsWithTrainingBlocks)
            {
                List<OilsandsTrainingItemDisplayAdapter> matchingItems = itemsWithTrainingBlocks.FindAll(x => x.TrainingBlock.IdValue == item.TrainingBlock.IdValue);
                if (matchingItems.Count > 1)
                {
                    item.AddError(String.Format(StringResources.FormOilsandsTraining_AlreadyRecordedBlockOnSameForm, item.TrainingBlock.Name));
                    hasErrors = true;
                }
            }

            // check for duplicate date/shift/work assignment combos on existing forms
            long? duplicateFormNumber = formService.QueryDateShiftAndAssignmentDuplicatesOnOtherFormOilsandTrainings(editObject.Id, view.TrainingDate, view.Shift, editObject.WorkAssignment, editObject.CreatedBy);
            if (duplicateFormNumber != null)
            {
                hasErrors = true;
                view.SetErrorForDuplicateTrainingDateAndShift(StringResources.FormOilsandsTraining_AlreadyRecordedDateAndShiftOnOtherForm);
            }

            if (hasErrors)
            {
                view.MakeTrainingGridValidationIconsShowOrDisappear();
            }

            return hasErrors;
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();
            FormOilsandsTraining form = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.FormOilsandsTrainingCreate, formService.InsertFormOilsandsTraining, editObject);
            editObject.Id = form.Id;
        }


        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateFormOilsandsTraining, editObject);
        }

        private static FormOilsandsTraining CreateDefaultForm()
        {
            DateTime now = Clock.Now;
            UserContext context = ClientSession.GetUserContext();
            User currentUser = context.User;
            Role createdByRole = context.Role;

            FormOilsandsTraining form = new FormOilsandsTraining(null, FormStatus.Draft, currentUser, now, createdByRole);

            form.TrainingDate = Clock.DateNow;
            form.ShiftPattern = context.UserShift.ShiftPattern;
            form.FunctionalLocations = context.RootsForSelectedFunctionalLocations;
            form.WorkAssignment = context.Assignment;

            return form;
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            Save(false);
        }

        private void Save(bool showEmail)
        {
            if (Validate())
            {
                return;
            }

            UpdateEditObjectFromView();

            bool formWillNeedReapproval = IsEdit && FormWillNeedReapproval();
            bool totalHoursIsNotTheIdealAmount = FormOilsandsTraining.IsOutsideIdealNumberOfHours(editObject.TotalHours);

            List<string> warnings = new List<string>();
            if (formWillNeedReapproval)
            {
                warnings.Add(StringResources.FormOilsandsTraining_FormReapprovalWarning);
            }
            if (totalHoursIsNotTheIdealAmount && userContext.SiteId != 15 && userContext.SiteId != 6 // ayman remove the message for forthills and E&U
                && userContext.SiteId != 11)  //mangesh- remove message for ETF # RITM0156978    
            {
                warnings.Add(StringResources.FormOilsandsTraining_HoursWarning);
            }

            if (warnings.Count > 0)
            {
                DialogResult result = view.ShowWarnings(warnings);

                if (result == DialogResult.Yes)
                {
                    if (formWillNeedReapproval)
                    {
                        FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(ClientSession.GetUserContext().User, view.Approvals);    
                    }
                    
                    SaveWithApprovalCheck(showEmail);
                }
            }
            else
            {
                SaveWithApprovalCheck(showEmail);
            }
        }

        protected void SaveWithApprovalCheck(bool showEmail)
        {
            UpdateEditObjectFromView();

            if (editObject.AllApprovalsAreIn())
            {
                // If all approvals are in, find the approval with the most recent ApprovalDateTime and use that as the ApprovedDateTime on the form.
                List<FormApproval> approvals = new List<FormApproval>(editObject.Approvals);
                approvals.Sort(approval => approval.ApprovalDateTime.GetValueOrDefault(DateTime.MinValue));
                editObject.MarkAsApproved(approvals.Last().ApprovalDateTime.GetValueOrDefault(Clock.Now));
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

        protected void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;
            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.TrainingItems = view.TrainingItems.ConvertAll(item => item.GetTrainingItem());
            editObject.Approvals = view.Approvals;
            editObject.TrainingDate = view.TrainingDate;
            editObject.ShiftPattern = view.Shift;
            editObject.GeneralComments = view.GeneralComments;
        }

        private void UpdateViewFromEditObject()
        {
            view.FunctionalLocations = editObject.FunctionalLocations;
            view.TrainingItems = editObject.TrainingItems.ConvertAll(item => new OilsandsTrainingItemDisplayAdapter(item));
            view.Approvals = editObject.Approvals;
            view.TrainingDate = editObject.TrainingDate;
            view.Shift = editObject.ShiftPattern;
            view.GeneralComments = editObject.GeneralComments;

            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;
        }

        private void ShowEmail()
        {
            ShowEmail(editObject.IdValue);
        }

        public static void ShowEmail(long formNumber)
        {
            string body = String.Format("Training Form #{0} is waiting for approval. Please log into OLT to review and approve.", formNumber);
            string subject = String.Format("Training Form #{0} is waiting for approval.", formNumber);

            EmailPresenter emailPresenter = new EmailPresenter();
            emailPresenter.Email(subject, body);
        }

        protected void HandleAddFunctionalLocationButtonClicked()
        {
            DialogResultAndOutput<List<FunctionalLocation>> result = view.ShowFunctionalLocationSelector(view.FunctionalLocations);

            if (result.Result == DialogResult.OK)
            {
                IList<FunctionalLocation> newFlocList = result.Output;
                view.FunctionalLocations = newFlocList == null ? new List<FunctionalLocation>() : new List<FunctionalLocation>(newFlocList);

                UpdateTrainingBlocksBasedOnFunctionalLocations();
            }
        }

        private void UpdateTrainingBlocksBasedOnFunctionalLocations()
        {
            SortAndSetTrainingBlocksOnView(trainingBlockService.QueryByFunctionalLocations(new RootFlocSet(view.FunctionalLocations)));
        }

        protected void HandleRemoveFunctionalLocationButtonClicked()
        {
            FunctionalLocation floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                List<FunctionalLocation> associatedFlocs = view.FunctionalLocations;                
                var newAssociatedFlocs = new List<FunctionalLocation>(associatedFlocs);
                newAssociatedFlocs.Remove(floc);

                List<TrainingBlock> applicableTrainingBlocks = trainingBlockService.QueryByFunctionalLocations(new RootFlocSet(newAssociatedFlocs));
                List<TrainingBlock> userSelectedTrainingBlocksThatMustBeRemovedBeforeThisFlocCanBeRemoved = TrainingBlocksThatMustBeRemoved(applicableTrainingBlocks);

                if (userSelectedTrainingBlocksThatMustBeRemovedBeforeThisFlocCanBeRemoved.Count > 0)
                {
                    List<string> trainingBlockNames = userSelectedTrainingBlocksThatMustBeRemovedBeforeThisFlocCanBeRemoved.ConvertAll(tb => tb.Name);
                    view.ShowUnableToRemoveFunctionalLocationMessage(trainingBlockNames);
                }
                else
                {
                    view.FunctionalLocations = newAssociatedFlocs;
                    SortAndSetTrainingBlocksOnView(applicableTrainingBlocks);
                }
            }
        }

        private void SortAndSetTrainingBlocksOnView(List<TrainingBlock> trainingBlocks)
        {
            trainingBlocks.Sort(tb => tb.Name);
            view.TrainingBlocks = trainingBlocks;
        }

        private List<TrainingBlock> TrainingBlocksThatMustBeRemoved(List<TrainingBlock> applicableTrainingBlocks)
        {
            List<TrainingBlock> trainingBlocksThatMustBeRemoved = new List<TrainingBlock>();
            List<TrainingBlock> userSelectedTrainingBlocks = view.TrainingItems.FindAll(ti => ti.TrainingBlock != null).ConvertAll(ti => ti.TrainingBlock);

            foreach (TrainingBlock userSelectedTrainingBlock in userSelectedTrainingBlocks)
            {
                if (!applicableTrainingBlocks.Exists(tb => tb.IdValue == userSelectedTrainingBlock.IdValue))
                {
                    trainingBlocksThatMustBeRemoved.Add(userSelectedTrainingBlock);
                }
            }
            return trainingBlocksThatMustBeRemoved;
        }

        protected void HandleApprovalUnselected(FormApproval approval)
        {
            approval.ApprovedByUser = null;
            approval.ApprovalDateTime = null;
        }

        protected void HandleApprovalSelected(FormApproval approval)
        {
            approval.ApprovedByUser = ClientSession.GetUserContext().User;
            approval.ApprovalDateTime = Clock.Now;
        }

        private void HandleSaveAndEmailClicked()
        {
            Save(true);
        }

        private void HandleRemoveTrainingBlock()
        {
            view.RemoveSelectedTrainingItem();
            EnableOrDisableRemoveButton();
        }

        private void HandleAddTrainingBlock()
        {
            OilsandsTrainingItemDisplayAdapter trainingItem = new OilsandsTrainingItemDisplayAdapter(new FormOilsandsTrainingItem(null, null, null,null, null, false, 0));
            view.AddTrainingItem(trainingItem);
            EnableOrDisableRemoveButton();
        }

        private bool FormWillNeedReapproval()
        {
            return editObject.WillNeedReapproval(originalGeneralComments, originalTrainingDate, originalShiftPattern, originalTrainingItems, originalFlocs, ClientSession.GetUserContext().User);
        }

        private class FunctionalLocationValidator : IFunctionalLocationValidator
        {
            private readonly FormOilsandsTrainingFormPresenter presenter;

            private List<TrainingBlock> userSelectedTrainingBlocksThatMustBeRemovedBeforeThisFlocCanBeRemoved;

            public FunctionalLocationValidator(FormOilsandsTrainingFormPresenter presenter)
            {
                this.presenter = presenter;
            }

            public bool AreValid(List<FunctionalLocation> functionalLocations)
            {
                List<TrainingBlock> applicableTrainingBlocks = presenter.trainingBlockService.QueryByFunctionalLocations(new RootFlocSet(functionalLocations));
                userSelectedTrainingBlocksThatMustBeRemovedBeforeThisFlocCanBeRemoved = presenter.TrainingBlocksThatMustBeRemoved(applicableTrainingBlocks);

                return userSelectedTrainingBlocksThatMustBeRemovedBeforeThisFlocCanBeRemoved.Count == 0;
            }

            public string ErrorMessage()
            {
                if (userSelectedTrainingBlocksThatMustBeRemovedBeforeThisFlocCanBeRemoved == null)
                {
                    throw new InvalidOperationException("AreValid must be called before ErrorMessage.");
                }

                List<string> trainingBlockNames = userSelectedTrainingBlocksThatMustBeRemovedBeforeThisFlocCanBeRemoved.ConvertAll(tb => tb.Name);
                userSelectedTrainingBlocksThatMustBeRemovedBeforeThisFlocCanBeRemoved = null;

                return String.Format(StringResources.FormOilsandsTraining_UnableToRemoveFlocMessage_AddFlocVersion, trainingBlockNames.Join(", "));
            }
        }


    }
}
