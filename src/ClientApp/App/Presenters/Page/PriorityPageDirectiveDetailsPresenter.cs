using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageDirectiveDetailsPresenter : PriorityPageDetailsPresenter<IDirectiveDetails>
    {
        private readonly IAuthorized authorized;
        private readonly IRemoteEventRepeater remoteEventRepeater;
        private readonly IDirectiveService directiveService;
        private readonly Directive directive;

        private readonly IReportPrintManager<Directive> reportPrintManager;

        public PriorityPageDirectiveDetailsPresenter(long directiveId, IAuthorized authorized, IRemoteEventRepeater remoteEventRepeater) 
            : base(
                StringResources.DomainObjectName_Directive,
                new DirectiveDetails())
        {
            this.authorized = authorized;
            this.remoteEventRepeater = remoteEventRepeater;
            directiveService = ClientServiceRegistry.Instance.GetService<IDirectiveService>();
            
            directive = directiveService.QueryById(directiveId);

            details.MakeAllButtonsInvisible();
            details.MarkAsReadVisible = true;
            details.PrintButtonVisible = true;
            details.MarkAsNotReadVisible = true;//Added by ppanigrahi

            details.MarkAsRead += HandleMarkAsRead;
            details.MarkedAsReadByToggled += HandleMarkedAsReadByToggled;
            details.Print += HandlePrint;
            details.MarkAsNotRead += HandleMarkAsNotRead;

            details.SetDetails(directive);

            details.MarkAsReadEnabled = authorized.ToMarkDirectiveAsRead(userContext.User, new DirectiveDTO(directive), Clock.Now) &&
                            !directiveService.UserMarkedDirectiveAsRead(directiveId, userContext.User.IdValue);
            
            reportPrintManager = new ReportPrintManager<Directive, DirectiveReport, DirectiveReportAdapter>(new DirectivePrintActions());
        }

        protected override void UnsubscribeToEvents()
        {
            details.MarkAsRead -= HandleMarkAsRead;
        }

        private void HandleMarkAsRead()
        {
            Directive requeriedDirective = directiveService.QueryById(directive.IdValue);
            if (!authorized.ToMarkDirectiveAsRead(userContext.User, new DirectiveDTO(requeriedDirective), Clock.Now))
            {
                OltMessageBox.Show((Form)view, StringResources.DirectiveCannotBeMarkedAsRead_Message, StringResources.DirectiveCannotBeMarkedAsRead_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            directiveService.MarkAsRead(directive.IdValue, userContext.User.IdValue, Clock.Now);
            details.MarkAsReadEnabled = false;
            remoteEventRepeater.Dispatch(ApplicationEvent.DirectiveMarkedAsReadByCurrentUser, directive);
            view.Close();
        }
        //Added by ppanigrahi

        private void HandleMarkAsNotRead()
        {
            Directive requeriedDirective = directiveService.QueryById(directive.IdValue);
            MarkAsNotReadForm frm = new MarkAsNotReadForm(requeriedDirective.IdValue);
            frm.ShowDialog();
            frm.Dispose();

        }

        private void HandleMarkedAsReadByToggled(Directive item)
        {
            details.MarkedAsReadBy = directiveService.UsersThatMarkedDirectiveAsRead(item.IdValue);
        }

        private void HandlePrint(object sender, EventArgs e)
        {
            new PrintWithDialogFocus().Print(Print);
        }

        private void Print()
        {
            reportPrintManager.PrintReport(new List<Directive> { directive });
        }
    }
}
