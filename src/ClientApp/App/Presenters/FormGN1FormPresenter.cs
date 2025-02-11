﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormGN1FormPresenter : AddEditBaseFormPresenter<IFormGN1View, FormGN1>
    {
        private readonly IFormEdmontonService service;

        private bool saveWasSuccessful;

        private FunctionalLocation originalFunctionalLocation;
        private DateTime originalStartDateTime;
        private DateTime originalEndDateTime;
        private string originalCSELevel;
        private string originalJobDescription;
        private string originalPlanningWorksheetPlainTextContent;
        private string originalRescuePlanPlainTextContent;
        private List<TradeChecklist> originalTradeChecklists;

        private readonly bool isClone;

        private int tradeChecklistNextSequenceNumber = 1;

        private string buttontext; // Swapnil Patki For DMND0005325 Point Number 7


        public FormGN1FormPresenter() : this(CreateDefaultForm())
        {
        }

        public FormGN1FormPresenter(FormGN1 form) : this(form, false)
        {

            bool allapproved = MainFormWillNeedReapproval();
           
        }

        public FormGN1FormPresenter(FormGN1 form, bool isClone) : base(new FormGN1Form(), form)
        {
            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();

            this.isClone = isClone;
            SaveOriginalFormValues(form);

            view.FormLoad += HandleFormLoad;
            view.SaveAndEmailButtonClicked += HandleSaveAndEmailClicked;
            view.WaitingApprovalButtonClicked += HandleWaitingApprovalClicked; // Swapnil Patki For DMND0005325 Point Number 7
            view.HistoryButtonClicked += HandleHistoryButtonClicked;
            view.BrowseFunctionalLocationButtonClicked += HandleBrowseFunctionalLocationButtonClicked;
            view.PlanningWorksheetApprovalSelected += HandleApprovalSelected;
            view.PlanningWorksheetApprovalUnselected += HandleApprovalUnselected;
            view.RescuePlanApprovalSelected += HandleApprovalSelected;
            view.RescuePlanApprovalUnselected += HandleApprovalUnselected;
            view.ExpandPlanningWorksheetContentClicked += HandleExpandPlanningWorksheetContentClicked;
            view.ExpandRescuePlanContentClicked += HandleExpandRescuePlanContentClicked;
            view.SelectedCSELevelChanged += HandleSelectedCSELevelChanged;

            view.AddTradeChecklistButtonClicked += HandleAddTradeChecklistButtonClicked;
            view.EditTradeChecklistButtonClicked += HandleEditTradeChecklistButtonClicked;
            view.RemoveTradeChecklistButtonClicked += HandleRemoveTradeChecklistButtonClicked;
            view.CloneTradeChecklistButtonClicked += HandleCloneTradeChecklistButtonClicked;

            view.TradeChecklistConstFieldMaintCoordApprovalSelected +=
                HandleTradeChecklistConstFieldMaintCoordApprovalSelected;
            view.TradeChecklistConstFieldMaintCoordApprovalUnselected +=
                HandleTradeChecklistConstFieldMaintCoordApprovalUnselected;

            view.TradeChecklistOpsCoordApprovalSelected += HandleTradeChecklistOpsCoordApprovalSelected;
            view.TradeChecklistOpsCoordApprovalUnselected += HandleTradeChecklistOpsCoordApprovalUnselected;

            view.TradeChecklistAreaManagerApprovalSelected += HandleTradeChecklistAreaManagerApprovalSelected;
            view.TradeChecklistAreaManagerApprovalUnselected += HandleTradeChecklistAreaManagerApprovalUnselected;

        }

        private void HandleFormLoad()
        {
            if (!IsEdit && !IsClone)
            {
                FormTemplate planningWorksheetTemplate = service.QueryFormTemplateByFormTypeAndKey(
                    EdmontonFormType.GN1, FormTemplateKeys.GN1_PLANNING_WORKSHEET);
                FormTemplate rescuePlanTemplate = service.QueryFormTemplateByFormTypeAndKey(EdmontonFormType.GN1,
                    FormTemplateKeys.GN1_RESCUE_PLAN);

                if (planningWorksheetTemplate != null)
                {
                    editObject.PlanningWorksheetContent = planningWorksheetTemplate.Template;
                }

                if (rescuePlanTemplate != null)
                {
                    editObject.RescuePlanContent = rescuePlanTemplate.Template;
                }

                tradeChecklistNextSequenceNumber = 1;
            }
            else if (IsClone)
            {
                tradeChecklistNextSequenceNumber = TradeChecklist.GetNextSequenceNumber(originalTradeChecklists);
            }
            else
            {
                tradeChecklistNextSequenceNumber = service.GetNextTradeChecklistSequenceNumber(editObject.IdValue);

                //Commented By Vibhor - RITM0625837 : OLT GN1 issue, CSE Level are disabled in edit mode
                //view.DisableCseLevelSelection();
            }

            view.UpdateTitleAsCreateOrEdit(IsEdit, EdmontonFormType.GN1.GetName());
            view.HistoryButtonEnabled = IsEdit;
            view.CSELevelValues = PermitFormHelper.GetConfinedSpaceClassSelectionList();

            UpdateViewFromEditObject();

            view.ActivateFirstTradeChecklistRowAndEnableButtons();
        }

        private void HandleAddTradeChecklistButtonClicked()
        {
            TradeChecklist newTradeChecklist = new TradeChecklist
            {
                SequenceNumber = GetNextSequenceNumberAndIncrement(),
                LastModifiedUser = ClientSession.GetUserContext().User,
                LastModifiedDateTime = Clock.Now,
                ParentFormNumber = IsEdit ? editObject.Id : null
            };

            AddEditTradeChecklistFormPresenter presenter = new AddEditTradeChecklistFormPresenter(newTradeChecklist,
                false);
            DialogResult dialogResult = presenter.Run(view);

            if (DialogResult.Cancel.Equals(dialogResult))
            {
                RestoreTradeChecklistSequenceNumber(newTradeChecklist.SequenceNumber);
            }
            else
            {
                List<TradeChecklist> checklists = view.TradeChecklists;
                checklists.Add(newTradeChecklist);
                view.TradeChecklists = checklists;

                UpdateWaitingForApprovalButtonStatus();     //ayman enable/disable waiting for approval button
            }

            view.ActivateFirstTradeChecklistRowAndEnableButtons();
        }

        private void RestoreTradeChecklistSequenceNumber(int sequenceNumber)
        {
            tradeChecklistNextSequenceNumber = sequenceNumber;
        }

        private int GetNextSequenceNumberAndIncrement()
        {
            int next = tradeChecklistNextSequenceNumber;
            tradeChecklistNextSequenceNumber++;
            return next;
        }

        private void HandleSelectedCSELevelChanged()
        {
            string selectedCSELevel = view.SelectedCSELevel;

            if (WorkPermitEdmonton.ConfinedSpaceLevel3.Equals(selectedCSELevel))
            {
                view.CollapsePlanningWorksheetAndTradeChecklistSections();
                view.HideTradeChecklistApprovalColumns();
            }
            else
            {
                view.ExpandPlanningWorksheetAndTradeChecklistSections();
                view.ShowTradeChecklistApprovalColumns();

                if (string.IsNullOrEmpty(view.RescuePlanPlainTextContent) ||
                    string.IsNullOrEmpty(view.PlanningWorksheetPlainTextContent))
                {
                    FormTemplate planningWorksheetTemplate =
                        service.QueryFormTemplateByFormTypeAndKey(EdmontonFormType.GN1,
                            FormTemplateKeys.GN1_PLANNING_WORKSHEET);
                    FormTemplate rescuePlanTemplate = service.QueryFormTemplateByFormTypeAndKey(EdmontonFormType.GN1,
                        FormTemplateKeys.GN1_RESCUE_PLAN);

                    if (planningWorksheetTemplate != null)
                    {
                        view.PlanningWorksheetContent = planningWorksheetTemplate.Template;
                    }

                    if (rescuePlanTemplate != null)
                    {
                        view.RescuePlanContent = rescuePlanTemplate.Template;
                    }
                }
            }
        }

        private void HandleEditTradeChecklistButtonClicked()
        {
            // Get the selected item
            TradeChecklist selectedTradeChecklist = view.SelectedTradeChecklist;

            AddEditTradeChecklistFormPresenter presenter = new AddEditTradeChecklistFormPresenter(
                selectedTradeChecklist, true);
            presenter.Run(view);
        }

        private void HandleRemoveTradeChecklistButtonClicked()
        {
            TradeChecklist selectedTradeChecklist = view.SelectedTradeChecklist;

            if (selectedTradeChecklist == null)
            {
                return;
            }

            DialogResult result = view.ShowRemoveSelectedTradeChecklistMessage();

            if (DialogResult.Yes.Equals(result))
            {
                List<TradeChecklist> tradeChecklists = view.TradeChecklists;
                tradeChecklists.Remove(selectedTradeChecklist);

                view.TradeChecklists = tradeChecklists;
                view.ActivateFirstTradeChecklistRowAndEnableButtons();
            }
        }

        private void HandleCloneTradeChecklistButtonClicked()
        {
            if (view.SelectedTradeChecklist == null)
            {
                return;
            }
            TradeChecklist selectedTradeChecklist = new TradeChecklist(view.SelectedTradeChecklist);
            selectedTradeChecklist.ConvertToClone(ClientSession.GetUserContext().User);
            selectedTradeChecklist.SequenceNumber = GetNextSequenceNumberAndIncrement();
            selectedTradeChecklist.ParentFormNumber = IsEdit ? editObject.Id : null;
            selectedTradeChecklist.Trade = null;
            AddEditTradeChecklistFormPresenter presenter = new AddEditTradeChecklistFormPresenter(
                selectedTradeChecklist, true);
            DialogResult dialogResult = presenter.Run(view);

            if (DialogResult.Cancel.Equals(dialogResult))
            {
                RestoreTradeChecklistSequenceNumber(selectedTradeChecklist.SequenceNumber);
            }
            else
            {
                List<TradeChecklist> checklists = view.TradeChecklists;
                checklists.Add(selectedTradeChecklist);
                view.TradeChecklists = checklists;
            }
            view.ActivateFirstTradeChecklistRowAndEnableButtons();
        }

        // In this presenter, we store the new object as the edit object so the base class's clone doesn't work.
        protected override bool IsClone
        {
            get { return isClone; }
        }

        private void HandleExpandPlanningWorksheetContentClicked()
        {
            view.DisplayExpandedPlanningWorksheetContentForm();
        }

        private void HandleExpandRescuePlanContentClicked()
        {
            view.DisplayExpandedRescuePlanContentForm();
        }

        private void HandleHistoryButtonClicked()
        {
            EditFormGN1HistoryFormPresenter presenter = new EditFormGN1HistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        private void SaveOriginalFormValues(FormGN1 form)
        {
            originalFunctionalLocation = form.FunctionalLocation;
            originalStartDateTime = form.FromDateTime;
            originalEndDateTime = form.ToDateTime;
            originalCSELevel = form.CSELevel;
            originalJobDescription = form.JobDescription;
            originalPlanningWorksheetPlainTextContent = form.PlanningWorksheetPlainTextContent;
            originalRescuePlanPlainTextContent = form.RescuePlanPlainTextContent;
            originalTradeChecklists = CopyOriginalTradeChecklists(form.TradeChecklists);
        }

        private List<TradeChecklist> CopyOriginalTradeChecklists(List<TradeChecklist> originals)
        {
            List<TradeChecklist> listOfCopies = new List<TradeChecklist>();

            foreach (TradeChecklist originalTradeChecklist in originals)
            {
                listOfCopies.Add(new TradeChecklist(originalTradeChecklist));
            }

            return listOfCopies;
        }

        private static FormGN1 CreateDefaultForm()
        {
            DateTime now = Clock.Now;
            User currentUser = ClientSession.GetUserContext().User;

            //ayman generic forms
            long siteid = ClientSession.GetUserContext().Site.IdValue;

            FormGN1 form = new FormGN1(null, FormStatus.Draft, null, null, now, now, currentUser, now,siteid);   //ayman generic forms
            form.SetDefaultDatesBasedOnShift(WorkPermitEdmonton.IsDayShift(now.ToTime()), now.ToDate(), now.ToTime());
            return form;
        }

        private void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;

            //ayman generic forms
            editObject.SiteId = userContext.SiteId;

            editObject.FunctionalLocation = view.SelectedFunctionalLocation;
            editObject.Location = view.LocationText;
            editObject.FromDateTime = view.ValidFrom;
            editObject.ToDateTime = view.ValidTo;
            editObject.JobDescription = view.JobDescription;
            editObject.CSELevel = view.SelectedCSELevel;

            editObject.PlanningWorksheetContent = view.PlanningWorksheetContent;
            editObject.PlanningWorksheetPlainTextContent = view.PlanningWorksheetPlainTextContent;
            editObject.RescuePlanContent = view.RescuePlanContent;
            editObject.RescuePlanPlainTextContent = view.RescuePlanPlainTextContent;
            editObject.TradeChecklists = view.TradeChecklists;
            editObject.DocumentLinks = view.DocumentLinks;

            UpdateEditObjectApprovalsFromView();

            if (WorkPermitEdmonton.ConfinedSpaceLevel3.Equals(editObject.CSELevel))
            {
                ClearDataForCseLevel3();
            }
        }

        /// <summary>
        /// When the items is a CSE Level 3, we want to clear all the approval data on the Edit object before saving.
        /// </summary>
        private void ClearDataForCseLevel3()
        {
            editObject.PlanningWorksheetContent = null;
            editObject.PlanningWorksheetPlainTextContent = null;
            editObject.RescuePlanContent = null;
            editObject.RescuePlanPlainTextContent = null;

            List<FormApproval> planningWorksheetApprovals = editObject.PlanningWorksheetApprovals;
            List<FormApproval> rescuePlanApprovals = editObject.RescuePlanApprovals;

            FormApproval.UnapproveApprovals(planningWorksheetApprovals);
            FormApproval.UnapproveApprovals(rescuePlanApprovals);

            List<TradeChecklist> tradeChecklists = editObject.TradeChecklists;
            tradeChecklists.ForEach(cl =>
            {
                cl.ClearAreaManagerApproval();
                cl.ClearConstFieldMaintCoordApproval();
                cl.ClearOpsCoordApproval();
            });
        }

        private void UpdateEditObjectApprovalsFromView()
        {
            List<FormApproval> planningWorksheetApprovals = new List<FormApproval>(view.PlanningWorksheetApprovals);
            DisplayOrderHelper.SortAndResetDisplayOrder(planningWorksheetApprovals);
            editObject.PlanningWorksheetApprovals = planningWorksheetApprovals;

            List<FormApproval> rescuePlanApprovals = new List<FormApproval>(view.RescuePlanApprovals);
            DisplayOrderHelper.SortAndResetDisplayOrder(rescuePlanApprovals);
            editObject.RescuePlanApprovals = rescuePlanApprovals;
        }

        private void UpdateViewFromEditObject()
        {
            view.SelectedFunctionalLocation = editObject.FunctionalLocation;
            view.LocationText = editObject.Location;
            view.ValidTo = editObject.ToDateTime;
            view.ValidFrom = editObject.FromDateTime;
            view.JobDescription = editObject.JobDescription;
            view.SelectedCSELevel = editObject.CSELevel;
            view.DocumentLinks = editObject.DocumentLinks;
            view.TradeChecklists = editObject.TradeChecklists;
            view.PlanningWorksheetContent = editObject.PlanningWorksheetContent;
            view.RescuePlanContent = editObject.RescuePlanContent;

            UpdateViewApprovalsFromEditObject();

            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            
        }

        protected override bool ValidateViewHasError()
        {
            bool hasErrors = false;

            view.ClearErrorProviders();

            if (view.SelectedFunctionalLocation == null)
            {
                view.SetErrorForNoFunctionalLocationSelected();
                hasErrors = true;
            }

            if (string.IsNullOrEmpty(view.SelectedCSELevel))
            {
                view.SetErrorForNoCSELevelSelected();
                hasErrors = true;
            }

            if (view.ValidFrom >= view.ValidTo)
            {
                view.SetErrorForValidFromMustBeBeforeValidTo();
                hasErrors = true;
            }

            if (string.IsNullOrEmpty(view.JobDescription))
            {
                view.SetErrorForNoJobDescription();
                hasErrors = true;
            }

            if (view.TradeChecklists.Count == 0)
            {
                view.SetErrorForNoTradeChecklists();
                hasErrors = true;
            }

            return hasErrors;
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();
            editObject.TradeChecklists.ForEach(tc => tc.LastModifiedUser = userContext.User);
                // This needs to be done last.
            FormGN1 form =
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.FormGN1Create,
                    service.InsertGN1, editObject);
            editObject.Id = form.Id;
        }


        private void UpdateWaitingForApprovalButtonStatus()
        {
            //ayman enable/disable waiting for approval button
            if (editObject.AllApprovalsAreIn())
            {
                view.DisableWaitingApprovalButton();
            }
            else
            {
                view.EnableWaitingApprovalButton();
            }
            
        }

        private void HandleApprovalUnselected(FormApproval approval)
        {
            approval.ApprovedByUser = null;
            approval.ApprovalDateTime = null;
            UpdateWaitingForApprovalButtonStatus();     //ayman enable/disable waiting for approval button
        }



        private void HandleApprovalSelected(FormApproval approval)
        {
            approval.ApprovedByUser = ClientSession.GetUserContext().User;
            approval.ApprovalDateTime = Clock.Now;
            UpdateWaitingForApprovalButtonStatus();     //ayman enable/disable waiting for approval button
        }

        private void HandleTradeChecklistConstFieldMaintCoordApprovalSelected(TradeChecklist tradeChecklist)
        {
            tradeChecklist.SetConstFieldMaintApproval(true, userContext.User, Clock.Now);
            UpdateWaitingForApprovalButtonStatus();     //ayman enable/disable waiting for approval button
        }


        private void HandleTradeChecklistConstFieldMaintCoordApprovalUnselected(TradeChecklist tradeChecklist)
        {
            tradeChecklist.ClearConstFieldMaintCoordApproval();
            UpdateWaitingForApprovalButtonStatus();     //ayman enable/disable waiting for approval button
        }

        private void HandleTradeChecklistOpsCoordApprovalSelected(TradeChecklist tradeChecklist)
        {
            tradeChecklist.SetOpsCoordApproval(true, userContext.User, Clock.Now);
            UpdateWaitingForApprovalButtonStatus();     //ayman enable/disable waiting for approval button
        }

        private void HandleTradeChecklistOpsCoordApprovalUnselected(TradeChecklist tradeChecklist)
        {
            tradeChecklist.ClearOpsCoordApproval();
            UpdateWaitingForApprovalButtonStatus();     //ayman enable/disable waiting for approval button
        }

        private void HandleTradeChecklistAreaManagerApprovalSelected(TradeChecklist tradeChecklist)
        {
            tradeChecklist.SetAreaManagerApproval(true, userContext.User, Clock.Now);
            UpdateWaitingForApprovalButtonStatus();     //ayman enable/disable waiting for approval button
        }

        private void HandleTradeChecklistAreaManagerApprovalUnselected(TradeChecklist tradeChecklist)
        {
            tradeChecklist.ClearAreaManagerApproval();
            UpdateWaitingForApprovalButtonStatus();     //ayman enable/disable waiting for approval button
        }

        protected override void Update()
        {
            LabelAttributes attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();

            UpdateEditObjectFromView();
            editObject.TradeChecklists.ForEach(tc => tc.LastModifiedUser = userContext.User);
                // This needs to be done last.
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                (formGn1, labelAttributes) => service.UpdateGN1(formGn1, labelAttributes), editObject,
                attributesForHazardsLabel);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            buttontext = ((System.Windows.Forms.Control)(sender)).Name; // Swapnil Patki For DMND0005325 Point Number 7
           Save(false);
        }

        private void HandleWaitingApprovalClicked() // Swapnil Patki For DMND0005325 Point Number 7
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

            if (IsEdit && MainFormWillNeedReapproval())
            {
                DialogResult result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;
                        // this is just for safety/clarity; if we're editing the form, it should already be in 'draft' mode
                    User currentUser = ClientSession.GetUserContext().User;
                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(currentUser,
                        view.PlanningWorksheetApprovals);
                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(currentUser, view.RescuePlanApprovals);
                    view.TradeChecklists.ForEach(tc => tc.UnapproveApprovalsNotByUser(currentUser));

                    SaveWithApprovalCheck(showEmail);
                }
            }
            else if (IsEdit && PlanningWorksheetAndRescuePlanWillNeedReapproval())
            {
                DialogResult result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;
                    User currentUser = ClientSession.GetUserContext().User;
                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(currentUser,
                        view.PlanningWorksheetApprovals);
                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(currentUser, view.RescuePlanApprovals);

                    SaveWithApprovalCheck(showEmail);
                }
            }
            else if (IsEdit && PlanningWorksheetWillNeedReapproval())
            {
                DialogResult result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;
                    User currentUser = ClientSession.GetUserContext().User;
                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(currentUser,
                        view.PlanningWorksheetApprovals);

                    SaveWithApprovalCheck(showEmail);
                }
            }
            else if (IsEdit && RescuePlanWillNeedReapproval())
            {
                DialogResult result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;
                    User currentUser = ClientSession.GetUserContext().User;
                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(currentUser, view.RescuePlanApprovals);

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

                if (IsEdit && !SomethingRequiringReapprovalHasChanged())
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
                if (buttontext != null) // Swapnil Patki For DMND0005325 Point Number 7
                {
                    editObject.MarkAsUnapproved();
                }
                else
                {
                    editObject.MarkAsWaitingForApproval();
                }
            }

            SaveOrUpdate(true);

            if (showEmail)
            {
                ShowEmail();
            }
        }

        private void ShowEmail()
        {
            FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.GN1.Name, editObject.FormNumber);
        }

        private bool MainFormWillNeedReapproval()
        {
            
            return editObject.EntireFormWillNeedReapproval(userContext.User, originalFunctionalLocation);

        }

        private bool PlanningWorksheetAndRescuePlanWillNeedReapproval()
        {
            Authorized authorized = new Authorized();
            User currentUser = ClientSession.GetUserContext().User;

            bool noReapprovalRequiredForEndDateChange =
                authorized.ToChangeEndDateOfGN1WithNoReapprovalRequired(userContext.UserRoleElements);

            return editObject.PlanningWorksheetAndRescuePlanWillNeedReapproval(
                noReapprovalRequiredForEndDateChange,
                currentUser,
                originalFunctionalLocation,
                originalStartDateTime,
                originalEndDateTime,
                originalJobDescription,
                originalCSELevel);
        }

        private bool PlanningWorksheetWillNeedReapproval()
        {
            return editObject.PlanningWorksheetWillNeedReapproval(ClientSession.GetUserContext().User,
                originalPlanningWorksheetPlainTextContent);
        }

        private bool RescuePlanWillNeedReapproval()
        {
            return editObject.RescuePlanWillNeedReapproval(ClientSession.GetUserContext().User,
                originalRescuePlanPlainTextContent);
        }

        private bool SomethingRequiringReapprovalHasChanged()
        {
            Authorized authorized = new Authorized();
            bool noReapprovalRequiredForEndDateChange =
                authorized.ToChangeEndDateOfGN1WithNoReapprovalRequired(userContext.UserRoleElements);

            return editObject.SomethingRequiringReapprovalHasChanged(noReapprovalRequiredForEndDateChange,
                originalFunctionalLocation, originalStartDateTime, originalEndDateTime, originalCSELevel,
                originalJobDescription, originalPlanningWorksheetPlainTextContent, originalRescuePlanPlainTextContent);
        }

        private void HandleBrowseFunctionalLocationButtonClicked()
        {
            bool userHasChangedLocation = HasTheUserChangedTheLocation();

            DialogResultAndOutput<FunctionalLocation> result =
                view.ShowFunctionalLocationSelector(view.SelectedFunctionalLocation);

            if (result.Result == DialogResult.OK)
            {
                FunctionalLocation floc = result.Output;
                view.SelectedFunctionalLocation = floc;

                if (!userHasChangedLocation)
                {
                    view.LocationText = WorkPermitEdmonton.GetLocation(floc);
                }
            }
        }

        private bool HasTheUserChangedTheLocation()
        {
            // This is because, for some reason, the OLT text box likes to return "" even after it's been set to null.
            string locationTextValue = string.IsNullOrEmpty(view.LocationText) ? null : view.LocationText;

            return (locationTextValue != WorkPermitEdmonton.GetLocation(view.SelectedFunctionalLocation));
        }

        private void UpdateViewApprovalsFromEditObject()
        {
            view.PlanningWorksheetApprovals = editObject.EnabledPlanningWorksheetApprovals;
            view.RescuePlanApprovals = editObject.EnabledRescuePlanApprovals;

            //ayman enable/disable waiting for approval button
            if (editObject.AllApprovalsAreIn())
            {
                view.DisableWaitingApprovalButton();
            }

        }

        public DialogResultAndOutput<FormGN1> RunAndReturnTheEditObject(IBaseForm parent)
        {
            Run(parent);

            if (saveWasSuccessful)
            {
                return new DialogResultAndOutput<FormGN1>(DialogResult.OK, editObject);
            }

            return new DialogResultAndOutput<FormGN1>(DialogResult.Cancel, null);
        }

        protected override void SaveOrUpdate(bool shouldCloseForm)
        {
            base.SaveOrUpdate(shouldCloseForm);
            saveWasSuccessful = true;
        }
    }
}