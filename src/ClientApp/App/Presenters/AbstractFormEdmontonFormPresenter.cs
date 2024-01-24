using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public abstract class AbstractFormEdmontonFormPresenter<TForm, TFormView> : AddEditBaseFormPresenter<TFormView, TForm>
        where TForm : BaseEdmontonForm
        where TFormView : class, IFormView
    {
        private bool saveWasSuccessful;

        protected AbstractFormEdmontonFormPresenter(TFormView view, TForm editObject)
            : base(view, editObject)
        {
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

            if (view.ValidFrom >= view.ValidTo)
            {
                view.SetErrorForValidFromMustBeBeforeValidTo();
                hasErrors = true;
            }

            return hasErrors;
        }

        protected sealed override void Insert()
        {
            InsertAndSetId();
        }

        private void InsertAndSetId()
        {
            UpdateEditObjectFromView();
            List<NotifiedEvent> events = RawInsert();
            if (events.Count > 0)
            {
                DomainObject domainObject = events[0].DomainObject;
                editObject.Id = domainObject.Id;
            }
        }


        protected override void SaveOrUpdate(bool shouldCloseForm)
        {
            base.SaveOrUpdate(shouldCloseForm);

            saveWasSuccessful = true;
        }

        protected abstract List<NotifiedEvent> RawInsert();


        protected abstract void UpdateEditObjectFromView();

        public DialogResultAndOutput<TForm> RunAndReturnTheEditObject(IBaseForm parent)
        {
            Run(parent);

            if (saveWasSuccessful)
            {
                return new DialogResultAndOutput<TForm>(DialogResult.OK, editObject);
            }

            return new DialogResultAndOutput<TForm>(DialogResult.Cancel, null);
        }

        protected void HandleAddFunctionalLocationButtonClicked()
        {
            DialogResultAndOutput<List<FunctionalLocation>> result = view.ShowFunctionalLocationSelector(view.FunctionalLocations);

            if (result.Result == DialogResult.OK)
            {
                IList<FunctionalLocation> newFlocList = result.Output;
                view.FunctionalLocations = newFlocList == null ? new List<FunctionalLocation>() : new List<FunctionalLocation>(newFlocList);
            }
        }

        protected void HandleRemoveFunctionalLocationButtonClicked()
        {
            FunctionalLocation floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                List<FunctionalLocation> associatedFlocs = view.FunctionalLocations;
                associatedFlocs.Remove(floc);
                var newAssociatedFlocs = new List<FunctionalLocation>(associatedFlocs);

                view.FunctionalLocations = newAssociatedFlocs;
            }
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

        protected void HandleExpandClicked()
        {
            view.DisplayExpandedLogCommentForm();
        }

        protected abstract void ShowEmail();

        protected void SaveWithApprovalCheck(bool showEmail)
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
                //MS: 3664 - Ayman
                var directorAndNotApprovedYet =
                    editObject.AllApprovals.FindAll(
                        approval => approval.Approver.ToLower().StartsWith("directeur") && !approval.IsApproved && approval.Enabled);

                var managerAndNotApprovedYet =
                    editObject.AllApprovals.FindAll(
                        approval => approval.Approver.ToLower().StartsWith("manager opération (> 72 heures)") && !approval.IsApproved && approval.Enabled);

                var othersAndNotApprovedYet =
                    editObject.AllApprovals.FindAll(
                        (approval =>
                            (!approval.Approver.ToLower().StartsWith("directeur") &&
                             !approval.Approver.ToLower().StartsWith("manager opération (> 72 heures)")) &&
                            approval.Enabled && !approval.IsApproved));


                if (othersAndNotApprovedYet.Count > 0)
                {
                    if ((directorAndNotApprovedYet.Count == 0) || (managerAndNotApprovedYet.Count == 0))
                    {
                        editObject.MarkAsUnapproved();
                    }
                    else
                    {
                        editObject.MarkAsApproved(Clock.Now);
                    }
                }
                else
                {
                    if ((directorAndNotApprovedYet.Count == 0) || (managerAndNotApprovedYet.Count == 0))
                    {
                        editObject.MarkAsApproved(null);
                    }
                    else
                    {
                        editObject.MarkAsApproved(Clock.Now);
                    }
                }


            }

            SaveOrUpdate(true);

            if (showEmail)
            {
                ShowEmail();
            }
        }

        protected void SaveWithApprovalCheckForEdmontonForm7And59(bool showEmail, string buttontext) // Swapnil Patki For DMND0005325 Point Number 7
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

                #region ["CSD approval"]

                // RITM0162061 Release 4.31.. 
                // If CSD is been approved by Shift supervisor, it will be marked as Approved ..
                // Amit Shukla             
                if (userContext.IsSarniaSite) //&& buttontext != "saveButton")     //ayman sarnia
                {
                    if (buttontext == null)
                    {

// INC0508116 : CSD Approval behavior chnages -- Added by Vibhor
                        var shiftSupervisorApproval = editObject.AllApprovals.FindAll(approval =>approval.Approver.ToLower().StartsWith("shift supervisor") && approval.IsApproved && approval.Enabled);

                        var operationsApproval = editObject.AllApprovals.FindAll(approval =>approval.Approver.ToLower().StartsWith("operations manager") && approval.IsApproved && approval.Enabled);

                        var omApproval = editObject.AllApprovals.FindAll(approval => approval.Approver.ToLower().Contains(">= 10") && approval.IsApproved && approval.Enabled);

                        var odApproval = editObject.AllApprovals.FindAll(approval => approval.Approver.ToLower().StartsWith("operations director") && approval.IsApproved && approval.Enabled);

                        var edApproval = editObject.AllApprovals.FindAll(approval => approval.Approver.ToLower().StartsWith("engineering director") && approval.IsApproved && approval.Enabled);


                        if (shiftSupervisorApproval.Count == 0 && operationsApproval.Count == 0 && omApproval.Count == 0 && odApproval.Count   == 0 && edApproval.Count == 0)
                        {
                            editObject.MarkAsWaitingForApproval();
                        }
                        if (shiftSupervisorApproval.Count > 0 && (Clock.Now < editObject.FromDateTime.AddDays(3)))
                        {
                            editObject.MarkAsApproved(Clock.Now);
                            
                        }
                        else
                        {
                            if ((Clock.Now >= editObject.FromDateTime.AddDays(3)) && operationsApproval.Count == 0)
                            {
                                editObject.MarkAsWaitingForApproval();
                            }
                        }


                        if (shiftSupervisorApproval.Count > 0  && operationsApproval.Count > 0 && (Clock.Now < editObject.FromDateTime.AddDays(10)))
                        {
                            editObject.MarkAsApproved(Clock.Now);
                        }
                        else
                        {
                            if ((Clock.Now >= editObject.FromDateTime.AddDays(10)) && operationsApproval.Count == 0)
                            {
                                editObject.MarkAsWaitingForApproval();
                            }   
                        }
                        
                        if ((shiftSupervisorApproval.Count > 0 && operationsApproval.Count > 0 && omApproval.Count > 0 ) &&
                            (Clock.Now > editObject.FromDateTime.AddDays(10) && Clock.Now < editObject.FromDateTime.AddDays(30)) )
                        {
                            editObject.MarkAsApproved(Clock.Now);
                        }
                        else
                        {
                            if ( (Clock.Now >= editObject.FromDateTime.AddDays(10)  &&  Clock.Now <= editObject.FromDateTime.AddDays(30) )
                                && omApproval.Count == 0)
                            {
                                editObject.MarkAsWaitingForApproval();
                            }
                        }

                        if ( (shiftSupervisorApproval.Count > 0 && operationsApproval.Count > 0 && omApproval.Count > 0) && (odApproval.Count > 0 && edApproval.Count > 0 ) &&
                            (Clock.Now > editObject.FromDateTime.AddDays(30)) )
                        {
                            editObject.MarkAsApproved(Clock.Now);
                        }
                        else
                        {
                            if ((Clock.Now >= editObject.FromDateTime.AddDays(30)) && (odApproval.Count == 0 && edApproval.Count == 0))
                            {
                                editObject.MarkAsWaitingForApproval();
                            }
                        }

                        //

                        //else
                        //{
                        //    //if (shiftSupervisorApproval.Count > 0 && Clock.Now > editObject.FromDateTime.AddDays(3) || (!editObject.AllApprovalsAreIn()
                        //&& Clock.Now >= editObject.FromDateTime && shiftSupervisorApproval.Count == 0)) 
                        //    //    editObject.MarkAsWaitingForApproval();
                        //}
                    }
                    if (buttontext == "saveButton")
                    {
                        editObject.MarkAsUnapproved();
                    }

                }
                #endregion

                //MS: 3664 - Ayman
                else
                {
                    var directorAndNotApprovedYet =
                        editObject.AllApprovals.FindAll(
                            approval =>
                                approval.Approver.ToLower().StartsWith("directeur") && !approval.IsApproved &&
                                approval.Enabled);

                    var managerAndNotApprovedYet =
                        editObject.AllApprovals.FindAll(
                            approval =>
                                approval.Approver.ToLower().StartsWith("manager opération (> 72 heures)") &&
                                !approval.IsApproved && approval.Enabled);

                    var othersAndNotApprovedYet =
                        editObject.AllApprovals.FindAll(
                            (approval =>
                                (!approval.Approver.ToLower().StartsWith("directeur") &&
                                 !approval.Approver.ToLower().StartsWith("manager opération (> 72 heures)")) &&
                                approval.Enabled && !approval.IsApproved));


                    if (othersAndNotApprovedYet.Count > 0)
                    {
                        if ((directorAndNotApprovedYet.Count == 0) || (managerAndNotApprovedYet.Count == 0))
                        {
                            if (buttontext != null)
                            {
                                editObject.MarkAsUnapproved();
                            }
                            else
                            {
                                editObject.MarkAsWaitingForApproval();
                            }
                        }
                        else
                        {
                            editObject.MarkAsApproved(Clock.Now);
                        }
                    }
                    else
                    {
                        if ((directorAndNotApprovedYet.Count == 0) || (managerAndNotApprovedYet.Count == 0))
                        {
                            editObject.MarkAsApproved(null);
                        }
                        else
                        {
                            editObject.MarkAsApproved(Clock.Now);
                        }
                    }
                }


            }
            SaveOrUpdate(true);

            if (showEmail)
            {
                ShowEmail();
            }
        }

        protected abstract bool SomethingRequiringReapprovalHasChanged();
    }
}
