using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class DeviationAlertResponsePresenter
    {
        private readonly bool canEditComments;
        private readonly bool canRespond;
        private readonly DeviationAlert deviationAlert;
        private readonly IDeviationAlertService deviationAlertService;
        private readonly int deviationWorkingValue;

        private readonly bool isNewResponse;

        private List<DeviationAlertDTO> selectedItems;
        private bool isCopyLastResponse = false;

        private readonly List<DeviationAlertResponseReasonCodeAssignment> masterList
            = new List<DeviationAlertResponseReasonCodeAssignment>();

        private readonly IRestrictionLocationService restrictionLocationService;
        private readonly IDeviationAlertResponseView view;
        private int amountRemainingToBeAssignedWorkingValue;

        private RestrictionLocation restrictionLocationForUserWorkAssignment;
        private int totalAssignedWorkingValue;

        public DeviationAlertResponsePresenter(
            IDeviationAlertResponseView view, DeviationAlert deviationAlert, bool canEditComments, bool canRespond)
        {
            deviationAlertService = ClientServiceRegistry.Instance.GetService<IDeviationAlertService>();
            restrictionLocationService = ClientServiceRegistry.Instance.GetService<IRestrictionLocationService>();

            this.view = view;
            this.deviationAlert = deviationAlert;

            this.canEditComments = canEditComments;
            this.canRespond = canRespond;

            isNewResponse = deviationAlert.DeviationAlertResponse == null;

            if (deviationAlert.DeviationAlertResponse != null)
            {
                masterList.AddRange(deviationAlert.DeviationAlertResponse.ReasonCodeAssignments);
            }

            deviationWorkingValue = deviationAlert.DeviationValue;
            isCopyLastResponse = false;
        }

        public DeviationAlertResponsePresenter(
            IDeviationAlertResponseView view, DeviationAlert deviationAlert, bool canEditComments, bool canRespond, List<DeviationAlertDTO> selectedItems)
        {
            deviationAlertService = ClientServiceRegistry.Instance.GetService<IDeviationAlertService>();
            restrictionLocationService = ClientServiceRegistry.Instance.GetService<IRestrictionLocationService>();

            this.view = view;
            this.deviationAlert = deviationAlert;

            this.canEditComments = canEditComments;
            this.canRespond = canRespond;

            isNewResponse = deviationAlert.DeviationAlertResponse == null;

            if (deviationAlert.DeviationAlertResponse != null)
            {
                masterList.AddRange(deviationAlert.DeviationAlertResponse.ReasonCodeAssignments);
            }

            deviationWorkingValue = deviationAlert.DeviationValue;

            this.selectedItems = selectedItems;
            isCopyLastResponse = true;
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            view.StartDate = deviationAlert.StartDateTime.ToLongDateAndTimeString();
            view.EndDate = deviationAlert.EndDateTime.ToLongDateAndTimeString();

            view.MeasuredTagName = deviationAlert.MeasurementTagName;
            view.TargetTagName = Convert.ToString(deviationAlert.ProductionTargetTagName);

            view.TargetValue = deviationAlert.ProductionTargetValue.Format();
            view.MeasuredValue = deviationAlert.MeasurementValue.Format();

            view.Assignments = masterList;

            view.SummaryDeviationValue = Convert.ToString(deviationWorkingValue);

            view.Comments = deviationAlert.Comments;

            view.EnableControls(canEditComments, canRespond);

            SelectFirstAssignmentInGrid();

            DoPostDataChangeUIUpdates();

            //ayman deviation alert crash
            if (ClientSession.GetUserContext().Assignment != null)
            {
                restrictionLocationForUserWorkAssignment =
                    restrictionLocationService.QueryByWorkAssignment(ClientSession.GetUserContext().Assignment.IdValue);
            }
        }

        private void SelectFirstAssignmentInGrid()
        {
            if (masterList.Count > 0)
            {
                view.SelectedAssignment = masterList[0];
            }
        }

        public void SaveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (DataIsValid())
            {
                if (isCopyLastResponse)
                {
                    SaveCopyLastResponse();
                }
                else
                {
                    Save(); 
                }
                view.Close();
            }
        }

        private void SaveCopyLastResponse()
        {
            var user = ClientSession.GetUserContext().User;

            if (canEditComments)
            {
                deviationAlert.Comments = view.Comments;
                // This could (should?) be changed so that the update is done as part of the update below
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    deviationAlertService.UpdateDeviationAlertComment, deviationAlert, Clock.Now, user);
            }

            if (canRespond)
            {
                if (isNewResponse)
                {
                   


                    var response = new DeviationAlertResponse(deviationAlert.Comments, user, Clock.Now, Clock.Now);
                    response.ReasonCodeAssignments.AddRange(masterList);
                    deviationAlert.DeviationAlertResponse = response;
                }
                else
                {
                    deviationAlert.DeviationAlertResponse.Comments = deviationAlert.Comments;
                    deviationAlert.DeviationAlertResponse.ReasonCodeAssignments.Clear();
                    deviationAlert.DeviationAlertResponse.ReasonCodeAssignments.AddRange(masterList);
                }



                foreach (var item in selectedItems)
                {
                    //var a = new DeviationAlertResponse(item.DeviationValue, user, Clock.Now, Clock.Now); 

                    long id = (long)item.Id;
                    DeviationAlert alert = deviationAlertService.QueryById(id);

                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                        deviationAlertService.UpdateDeviationAlertResponse, alert, Clock.Now, user);

                }


                //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                //    deviationAlertService.UpdateDeviationAlertResponse, deviationAlert, Clock.Now, user);
            }
            else
            {
                // Ensure any changes to the comments are saved in the history
                if (deviationAlert.DeviationAlertResponse != null)
                {
                    deviationAlert.DeviationAlertResponse.Comments = deviationAlert.Comments;
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                        deviationAlertService.UpdateDeviationAlertResponse, deviationAlert, Clock.Now, user);
                }
            }
        }

        private void Save()
        {
            var user = ClientSession.GetUserContext().User;

            if (canEditComments)
            {
                deviationAlert.Comments = view.Comments;
                // This could (should?) be changed so that the update is done as part of the update below
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    deviationAlertService.UpdateDeviationAlertComment, deviationAlert, Clock.Now, user);
            }

            if (canRespond)
            {
                if (isNewResponse)
                {
                    var response = new DeviationAlertResponse(deviationAlert.Comments, user, Clock.Now, Clock.Now);
                    response.ReasonCodeAssignments.AddRange(masterList);
                    deviationAlert.DeviationAlertResponse = response;
                }
                else
                {
                    deviationAlert.DeviationAlertResponse.Comments = deviationAlert.Comments;
                    deviationAlert.DeviationAlertResponse.ReasonCodeAssignments.Clear();
                    deviationAlert.DeviationAlertResponse.ReasonCodeAssignments.AddRange(masterList);
                }

                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    deviationAlertService.UpdateDeviationAlertResponse, deviationAlert, Clock.Now, user);
            }
            else
            {
                // Ensure any changes to the comments are saved in the history
                if (deviationAlert.DeviationAlertResponse != null)
                {
                    deviationAlert.DeviationAlertResponse.Comments = deviationAlert.Comments;
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                        deviationAlertService.UpdateDeviationAlertResponse, deviationAlert, Clock.Now, user);
                }
            }
        }

        private bool DataIsValid()
        {
            view.ClearAllErrors();

            if (!canRespond)
            {
                return true;
            }

            var deviationValue = deviationAlert.DeviationValue;
            var assignedAmount = DeviationAlertResponse.GetTotalAssignedAmount(masterList);

            var dataIsValid = true;

            if (deviationValue != assignedAmount)
            {
                if (masterList.Count == 0 && deviationAlert.IsPositiveDeviation)
                {
                    // do nothing - we allow this
                }
                else
                {
                    var message =
                        StringResources.DeviationAlertResponse_AmountDoesNotEqualDeviationError;
                    view.SetErrorOnRemainingToBeAssigned(message);
                    dataIsValid = false;
                }
            }

            var hasDuplicateReasonCode = new DuplicateReasonCodeValidator(masterList).HasDuplicateAssignments();

            if (hasDuplicateReasonCode)
            {
                var message = StringResources.DeviationAlertResponse_DuplicateReasonCodeError;
                view.SetErrorOnGrid(message);
                dataIsValid = false;
            }

            if (masterList.Count == 0 && !deviationAlert.IsPositiveDeviation)
            {
                var message = StringResources.DeviationAlertResponse_AtLeastOneReasonCodeNeeded;
                view.SetErrorOnGrid(message);
                dataIsValid = false;
            }

            return dataIsValid;
        }

        public void CancelButton_Click(object sender, EventArgs e)
        {
            view.Close();
        }

        public void NewButton_Click(object sender, EventArgs e)
        {
            if (CheckIfNoRestrictionLocationDefinedForUserWorkAssignment())
            {
                return;
            }

            var newAssignment =
                view.OpenAssociationPresenter(restrictionLocationForUserWorkAssignment, null, deviationAlert,
                    amountRemainingToBeAssignedWorkingValue);

            if (newAssignment != null) // null on cancel
            {
                masterList.Add(newAssignment);
                view.Assignments = masterList;
                view.SelectedAssignment = newAssignment;
                DoPostDataChangeUIUpdates();
            }
        }

        private bool CheckIfNoRestrictionLocationDefinedForUserWorkAssignment()
        {
            if (restrictionLocationForUserWorkAssignment == null)
            {
                OltMessageBox.Show(StringResources.RestrictionLocationNotDefinedForWorkAssignment);
                return true;
            }
            return false;
        }

        public void EditButton_Click(object sender, EventArgs e)
        {
            if (CheckIfNoRestrictionLocationDefinedForUserWorkAssignment())
            {
                return;
            }

            var selectedAssignment = view.SelectedAssignment;

            if (selectedAssignment == null)
            {
                OltMessageBox.ShowError(
                    StringResources.DeviationAlertResponse_NoAssignmentSelectedForEditMessageBoxText,
                    StringResources.DeviationAlertResponse_NoAssignmentSelectedForEditMessageBoxCaption);
                return;
            }

            if (selectedAssignment.RestrictionLocationItem == null ||
                !restrictionLocationForUserWorkAssignment.LocationItems.ExistsById(
                    selectedAssignment.RestrictionLocationItem))
            {
                // item is from release 4.12, cannot edit when there was no RestrictionLocationItem in the past
                OltMessageBox.Show(StringResources.DeviationAlertResponse_CannotEditAssignment, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            var editedAssignment =
                view.OpenAssociationPresenter(restrictionLocationForUserWorkAssignment, selectedAssignment,
                    deviationAlert, amountRemainingToBeAssignedWorkingValue);

            if (editedAssignment != null) // null on cancel
            {
                masterList.Remove(selectedAssignment);
                masterList.Add(editedAssignment);
                view.Assignments = masterList;
                view.SelectedAssignment = editedAssignment;
                DoPostDataChangeUIUpdates();
            }
        }

        public void DeleteButton_Click(object sender, EventArgs e)
        {
            var selectedAssignment = view.SelectedAssignment;

            if (selectedAssignment == null)
            {
                OltMessageBox.ShowError(
                    StringResources.DeviationAlertResponse_NoAssignmentSelectedForDeleteMessageBoxText,
                    StringResources.DeviationAlertResponse_NoAssignmentSelectedForDeleteMessageBoxCaption);
                return;
            }

            var dialogResult = OltMessageBox.ShowCustomYesNo(
                StringResources.DeviationAlertResponse_AreYouSureDeleteAssignmentMessageBoxText,
                StringResources.DeviationAlertResponse_AreYouSureDeleteAssignmentMessageBoxCaption);

            if (dialogResult == DialogResult.Yes)
            {
                masterList.Remove(selectedAssignment);

                view.Assignments = masterList;

                SelectFirstAssignmentInGrid();
                DoPostDataChangeUIUpdates();
            }
        }

        private void DoPostDataChangeUIUpdates()
        {
            totalAssignedWorkingValue = DeviationAlertResponseReasonCodeAssignment.GetTotalAssignedInList(masterList);
            amountRemainingToBeAssignedWorkingValue = deviationWorkingValue - totalAssignedWorkingValue;

            view.SummaryTotalAssigned = Convert.ToString(totalAssignedWorkingValue);
            view.SummaryAmountRemainingToBeAssigned = Convert.ToString(amountRemainingToBeAssignedWorkingValue);
        }

        public void CopyLastResponseButton_Click()
        {
            if (ClientSession.GetUserContext().Assignment != null)
            {
                restrictionLocationForUserWorkAssignment =
                    restrictionLocationService.QueryByWorkAssignment(ClientSession.GetUserContext().Assignment.IdValue);
            }
            
            if (CheckIfNoRestrictionLocationDefinedForUserWorkAssignment())
            {
                return;
            }

            var lastRespondedToAlert =
                deviationAlertService.GetLastRespondedToAlert(deviationAlert.RestrictionDefinition);
            if (lastRespondedToAlert == null ||
                lastRespondedToAlert.DeviationAlertResponse == null ||
                lastRespondedToAlert.DeviationAlertResponse.ReasonCodeAssignments.Count == 0 ||
                // Cannot copy if last response was prior to release 4.13 when we didn't have RestrictionLocationItems which are now required.
                lastRespondedToAlert.DeviationAlertResponse.ReasonCodeAssignments.Exists(
                    assignment => assignment.RestrictionLocationItem == null) ||
                !RestrictionLocationFromLastRespondedToAlertsMatchCurrentWorkAssignment(lastRespondedToAlert))
            {
                view.ShowNoLastResponseToCopyFrom();
                return;
            }
            else
            {
                var shouldCopyLastReponse = GetShouldCopyLastReponseClearExistingIfRequested();
                if (shouldCopyLastReponse)
                {
                    var newAssignments =
                        DeviationAlertResponseReasonCodeAssignment.CopyAssignmentsAndAllocateAmountsInProportion(
                            masterList,
                            deviationWorkingValue,
                            lastRespondedToAlert,
                            ClientSession.GetUserContext().User,
                            Clock.Now);
                    masterList.Clear();
                    masterList.AddRange(newAssignments);

                    view.Assignments = masterList;
                    DoPostDataChangeUIUpdates();
                    SelectFirstAssignmentInGrid();
                }
            }
        }


        public void CopyLastResponseButton_Click(object sender, EventArgs e)
        {
            if (CheckIfNoRestrictionLocationDefinedForUserWorkAssignment())
            {
                return;
            }

            var lastRespondedToAlert =
                deviationAlertService.GetLastRespondedToAlert(deviationAlert.RestrictionDefinition);
            if (lastRespondedToAlert == null ||
                lastRespondedToAlert.DeviationAlertResponse == null ||
                lastRespondedToAlert.DeviationAlertResponse.ReasonCodeAssignments.Count == 0 ||
                // Cannot copy if last response was prior to release 4.13 when we didn't have RestrictionLocationItems which are now required.
                lastRespondedToAlert.DeviationAlertResponse.ReasonCodeAssignments.Exists(
                    assignment => assignment.RestrictionLocationItem == null) ||
                !RestrictionLocationFromLastRespondedToAlertsMatchCurrentWorkAssignment(lastRespondedToAlert))
            {
                view.ShowNoLastResponseToCopyFrom();
            }
            else
            {
                var shouldCopyLastReponse = GetShouldCopyLastReponseClearExistingIfRequested();
                if (shouldCopyLastReponse)
                {
                    var newAssignments =
                        DeviationAlertResponseReasonCodeAssignment.CopyAssignmentsAndAllocateAmountsInProportion(
                            masterList,
                            deviationWorkingValue,
                            lastRespondedToAlert,
                            ClientSession.GetUserContext().User,
                            Clock.Now);
                    masterList.Clear();
                    masterList.AddRange(newAssignments);

                    view.Assignments = masterList;
                    DoPostDataChangeUIUpdates();
                    SelectFirstAssignmentInGrid();
                }
            }
        }

        private bool RestrictionLocationFromLastRespondedToAlertsMatchCurrentWorkAssignment(
            DeviationAlert lastRespondedToAlert)
        {
            if (restrictionLocationForUserWorkAssignment == null)
            // this check is redundant, but better safe than sorry (that's what I always say)
            {
                return false;
            }

            var assignments = lastRespondedToAlert.DeviationAlertResponse.ReasonCodeAssignments;
            var restrictionLocationItemsForEachAssignment =
                assignments.ConvertAll(a => a.RestrictionLocationItem.IdValue);
            var allMatch =
                restrictionLocationService.AllItemsAreInGivenRestrictionLocation(
                    restrictionLocationForUserWorkAssignment.IdValue, restrictionLocationItemsForEachAssignment);

            return allMatch;
        }

        private bool GetShouldCopyLastReponseClearExistingIfRequested()
        {
            if (masterList.Count == 0)
            {
                return true;
            }
            var dialogResult = view.ConfirmCopyLastResponseWhenAssignmentsExist();
            if (dialogResult == DialogResult.Cancel)
            {
                return false;
            }
            if (dialogResult == DialogResult.Yes)
            {
                masterList.Clear();
            }
            return true;
        }
    }
}