using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitCopyDestinationFormPresenter
    {                       
        private readonly IWorkPermitCopyDestinationFormView view;
        private readonly WorkPermit sourcePermit;
        private readonly List<WorkPermitSection> sectionsToCopy;
        private readonly IWorkPermitService workPermitService;
        private readonly IObjectLockingService objectLockingService;
        private readonly IAuthorized authorized;
      
        public WorkPermitCopyDestinationFormPresenter(IWorkPermitCopyDestinationFormView view,
            WorkPermit sourcePermit,
            List<WorkPermitSection> sectionsToCopy,
            IWorkPermitService workPermitService,
            IObjectLockingService objectLockingService,
            IAuthorized authorized)
        {
            this.view = view;
            this.sourcePermit = sourcePermit;
            this.sectionsToCopy = sectionsToCopy;
            this.workPermitService = workPermitService;
            this.objectLockingService = objectLockingService;
            this.authorized = authorized;

            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            view.LoadView += LoadView;
            view.Copy += CopyToSelectedWorkPermits;
        }
        
        public void LoadView(object sender, EventArgs e)
        {
            view.Title = string.Format(StringResources.WorkPermitCopyDestinationFormTitle, sourcePermit.PermitNumber);
            RefreshCandidateWorkPermits();
        }

        public void CopyToSelectedWorkPermits(object sender, EventArgs e)
        {
            List<WorkPermit> destinationPermits = view.SelectedWorkPermits;

            List<WorkPermit> destinationPermitsWithData = destinationPermits.FindAll(permit => permit.HasData());

            if (destinationPermitsWithData.Count > 0)
            {
                DialogResult confirmResult = 
                    view.ShowYesNoMessageBox(ConfirmOverwriteDialogMessage(destinationPermitsWithData),
                    StringResources.WorkPermitCopyConfirmOverwriteMessageBoxCaption);

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }
            }

            var exceptions = new List<WorkPermitNotEditableException>();
            foreach (WorkPermit destinationPermit in destinationPermits)
            {
                try
                {
                    CopyToSelectedWorkPermit(destinationPermit);
                }
                catch (WorkPermitNotEditableException exception)
                {
                    exceptions.Add(exception);
                }
            }
            
            if (exceptions.Count > 0)
            {
                var errorMessage = new StringBuilder();
                errorMessage.AppendLine(StringResources.WorkPermitCopyUnableToCopyMessage);
                
                foreach (WorkPermitNotEditableException exception in exceptions)
                {
                    errorMessage.Append(exception.PermitNumber).Append(": ").AppendLine(exception.Status.ToString());
                }
                view.ShowWarningMessage(errorMessage.ToString(), StringResources.UnsuccessfulCopiesTitle);
            }
        }

        private void CopyToSelectedWorkPermit(WorkPermit destinationPermit)
        {
            UserContext ctx = ClientSession.GetUserContext();
            User currentUser = ctx.User;

            ObjectLockResult lockResult =
                objectLockingService.GetLock(destinationPermit, currentUser.IdValue, ClientSession.GetInstance().GuidAsString);

            if (lockResult.Succeeded == false)
            {
                string messageBoxTextLine1 = string.Format(StringResources.WorkPermitCopyLockedMessageBoxTextLine1,
                                                           destinationPermit.PermitNumber);

                string messageBoxTextLine2 = string.Format(StringResources.WorkPermitCopyLockedMessageBoxTextLine2,
                                                           lockResult.LockedByUserName);

                string messageText = messageBoxTextLine1 + Environment.NewLine + messageBoxTextLine2;


                view.ShowMessageBox(string.Format(messageText,
                    destinationPermit.PermitNumber, lockResult.LockedByUserName),
                    StringResources.WorkPermitCopyLockedMessageBoxCaption);
                return;
            }

            try
            {
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    workPermitService.CopyWorkPermit, 
                    sourcePermit, 
                    destinationPermit, 
                    sectionsToCopy,
                    currentUser);
            }
            finally
            {
                objectLockingService.ReleaseLock(destinationPermit, currentUser.IdValue);
            }
        }

        private void RefreshCandidateWorkPermits()
        {
            UserContext userContext = ClientSession.GetUserContext();
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<WorkPermit> workPermits = workPermitService.QueryEditablePermitsByFunctionalLocations(userContext.RootFlocSet);

            workPermits.RemoveAll(wp => !authorized.ToCopyToWorkPermit(userRoleElements, wp, sourcePermit));
                        
            view.CandidateWorkPermits = workPermits;
        }

        private static string ConfirmOverwriteDialogMessage(List<WorkPermit> destinationPermitsWithData)
        {
            var sb = new StringBuilder();
            sb.AppendLine(StringResources.WorkPermitCopyConfirmOverwriteMessageBoxTextHeader);
            sb.AppendLine();
            destinationPermitsWithData.ForEach(permit => sb.AppendFormat("* " + permit.PermitNumber).AppendLine());
            sb.AppendLine();
            sb.Append(StringResources.WorkPermitCopyConfirmOverwriteMessageBoxTextFooter);
            return sb.ToString();
        }
    }
}
