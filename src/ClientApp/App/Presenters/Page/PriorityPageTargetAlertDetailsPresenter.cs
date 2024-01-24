using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageTargetAlertDetailsPresenter : PriorityPageDetailsPresenter<ITargetAlertDetails>
    {
        private readonly ITargetAlertService service;
        private readonly TargetAlert targetAlert;
        private readonly IRemoteEventRepeater remoteEventRepeater;

        public PriorityPageTargetAlertDetailsPresenter(long id, IAuthorized authorized, IRemoteEventRepeater remoteEventRepeater)
            : base(StringResources.DomainObjectName_TargetAlert, new TargetAlertDetails())
        {
            this.remoteEventRepeater = remoteEventRepeater;
            service = ClientServiceRegistry.Instance.GetService<ITargetAlertService>();
            targetAlert = service.QueryById(id);

            TargetAlertPagePresenter.SetDetails(details, targetAlert);
            
            details.AcknowledgeEnabled = false;
            details.AcknowledgeEnabled = AuthorizedToAcknowledgeTargetAlerts(authorized) && targetAlert.Status != TargetAlertStatus.Acknowledged;
            details.RespondEnabled = authorized.ToRespondToTargetAlerts(userContext.UserRoleElements);

            details.SaveGridLayoutVisible = false;
            details.ExportVisible = false;
            details.RangeVisible = false;
            details.GoToDefinitionVisible = false;
            details.ViewAssociatedLogsVisible = false;

            details.Acknowledge += Acknowledge_Event;
            details.Respond += Respond_Event;
        }

        private bool AuthorizedToAcknowledgeTargetAlerts(IAuthorized authorized)
        {
            return authorized.ToAcknowledgeTargetAlerts(userContext.UserRoleElements, new List<TargetAlertDTO> {new TargetAlertDTO(targetAlert)});
        }

        protected override void UnsubscribeToEvents()
        {
            details.Acknowledge -= Acknowledge_Event;
            details.Respond -= Respond_Event;
        }

        private void Respond_Event(object sender, EventArgs e)
        {
            LockResult<DialogResult> lockResult = LockDatabaseObjectWhileInUse<TargetAlert, DialogResult>(Respond, targetAlert);

            if (lockResult.LockAquired && lockResult.ActionResult == DialogResult.OK)
            {
                view.Close();
            }
            details.AcknowledgeEnabled = false;
        }

        private DialogResult Respond(TargetAlert alert)
        {
            TargetAlertResponseForm responseView = new TargetAlertResponseForm();
            SingleSelectFunctionalLocationSelectionForm flocSelectionView = new SingleSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetAll(userContext.SiteConfiguration));
            new TargetAlertResponseFormPresenter(responseView, flocSelectionView, new List<TargetAlert>{targetAlert});
            
            DialogResult dialogResult = responseView.ShowDialog(view);
            responseView.Dispose();

            return dialogResult;
        }

        private void Acknowledge_Event()
        {
            if(targetAlert.RequiresResponse)
            {
                Respond(targetAlert);
            } 
            else
            {
                targetAlert.Acknowledge(userContext.User, Clock.Now);
                service.UpdateTargetAlert(targetAlert);
                remoteEventRepeater.Dispatch(ApplicationEvent.TargetAlertUpdate, targetAlert);
            }
            
            details.AcknowledgeEnabled = false;
        }

    }
}
